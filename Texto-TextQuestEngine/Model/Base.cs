using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using IWshRuntimeLibrary;

namespace Model
{
    public class Base
    {
        /// <summary>
        /// Path to directory, where located info about present step
        /// </summary>
        /// <remarks>
        /// Changes frequently
        /// </remarks>
        public static StringBuilder Path = new StringBuilder("quest");

        public static Errors.Error Error = new Errors.None();

        public static void SendPathToVisualizer()
        {
            View.Visualizer.Visualize(Path.ToString(), Error.Text);
        }

        public static Errors.Error ValidateUserInput(string userInput)
        {
            #region is numeric
            int userChoice; // It will converted to int userInput
            bool isNumeric = int.TryParse(userInput, out userChoice);

            if (!isNumeric)
            {
                return new Errors.InvalidUserInput();
            }
            #endregion

            #region user choice in correct range
            int variantsCount = GetVariantsCount();

            if (variantsCount < userChoice || userChoice <= 0)
            {
                return new Errors.InvalidUserInput();
            }
            #endregion

            return new Errors.None();
        }

        public static int GetVariantsCount()
        {
            return IOFunctions.GetVariants(Path.ToString()).Length;
        }

        public static string GetNewPath(int variant)
        {
            string variantName = getVariantName(variant);
            bool isShortcut = itShortcut(variantName);

            string newPath;

            if (isShortcut)
            {
                string shortcutPath = IOFunctions.AddThisToPath(Path.ToString(), variantName, "lnk");
                newPath = getPathThatLinkedByShortcut(shortcutPath);
            }
            else
            {
                newPath = getFolderPath(variantName);
            }

            return newPath;
        }

        private static string getVariantName(int variant)
        {
            string[] allVariants = IOFunctions.GetVariants(Path.ToString());
            return allVariants[variant - 1];
        }

        private static bool itShortcut(string variantName)
        {
            bool isShortcut = false;

            foreach (string shortcutName in IOFunctions.GetShortcutsFolderName(Path.ToString()))
            {
                if (variantName == shortcutName)
                {
                    isShortcut = true;
                    break;
                }
            }

            return isShortcut;
        }

        private static string getPathThatLinkedByShortcut(string shortcutPath)
        {
            //TODO: At this moment i'm thought about to security it all, check on existing this file, not null it

            WshShell shell = new WshShell();
            IWshShortcut link = (IWshShortcut)shell.CreateShortcut(shortcutPath);

            string path = Path.ToString();
            int parentFolderLength = path.IndexOf(@"\", StringComparison.InvariantCulture);

            string parentFolder;

            // @"/" is not existing, it's means, that returns -1 and it's means that we already in parent folder too
            if (parentFolderLength == -1)
            {
                parentFolder = path;
            }
            else
            {
                parentFolder = path.Substring(0, parentFolderLength);
            }

            string relativeLink = getRelativePath(link.TargetPath, parentFolder);

            return relativeLink;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="relativeFolder">The folder to split the path to (this will be a relative path)</param>
        /// <returns></returns>
        private static string getRelativePath(string fullPath,  string relativeFolder)
        {
            int toWhatSplit = fullPath.IndexOf(relativeFolder, StringComparison.InvariantCulture);
            string relativePath = fullPath.Remove(0, toWhatSplit);
            return relativePath;
        }

        private static string getFolderPath(string folderName)
        {
            string folderPath = IOFunctions.AddThisToPath(Path.ToString(), folderName);
            return folderPath;
        }
    }
}
