using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace View
{
    public static class Visualizer
    {
        public static void Visualize(string path, string errorText)
        {
            visualizeDescription(path);

            visualizeVariants(path);

            visualizeError(errorText);
        }

        #region description
        private static void visualizeDescription(string path)
        {
            string description = getDescription(path);

            Console.WriteLine(description);
        }

        internal static string getDescription(string path)
        {
            return getTxtFileName(path);
        }

        private static string getTxtFileName(string path)
        {
            string[] fullPaths = Directory.GetFiles(path);

            List<string> txtFilesName = new List<string>();

            foreach (string fp in fullPaths)
            {
                string fileNameAndExtension = Path.GetFileName(fp);
                string[] fpSplited = fileNameAndExtension.Split('.');

                //It's txt exactly?
                if (fpSplited[1] == "txt")
                {
                    txtFilesName.Add(fpSplited[0]);
                }
            }

            if (txtFilesName.Count == 0)
            {
                return null;
            }
            else
            {
                return txtFilesName[0];
                // [0] - it's in case if a user is create more than 1 file with description
            }
        }
        #endregion

        #region variants
        private static void visualizeVariants(string path)
        {
            string[] variants = getVariants(path);

            for (int i = 1; i < variants.Length+1; i++)
            {
                Console.WriteLine(i + ". " + variants[i - 1]);
            }
        }

        internal static string[] getVariants(string path)
        {
            return getFoldersName(path).Concat(getShortcutsFolderName(path)).ToArray();
        }

        private static string[] getFoldersName(string path)
        {
            string[] fullPaths = Directory.GetDirectories(path);

            List<string> foldersName = new List<string>();

            foreach (string fp in fullPaths)
            {
                string folderName = Path.GetFileNameWithoutExtension(fp);
                foldersName.Add(folderName);
            }

            return foldersName.ToArray();
        }

        private static string[] getShortcutsFolderName(string path)
        {
            string[] fullPaths = Directory.GetFiles(path);
            List<string> shortcutFilesName = new List<string>();

            foreach (string fp in fullPaths)
            {
                string fileNameAndExtension = Path.GetFileName(fp);
                string[] fpSplited = fileNameAndExtension.Split('.');

                //It's lnk exactly?
                if (fpSplited[1] == "lnk")
                {
                    shortcutFilesName.Add(fpSplited[0]);
                }
            }

            return shortcutFilesName.ToArray();
        }
        #endregion

        #region error
        private static void visualizeError(string errorText)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorText);
            Console.ResetColor();
        }
        #endregion
    }
}
