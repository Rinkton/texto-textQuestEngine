using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Common;

namespace View
{
    public static class Visualizer
    {
        public static void Visualize(string path, string errorText)
        {
            Console.Clear();

            visualizeDescription(path);

            visualizeVariants(path);

            visualizeError(errorText);
        }

        #region description
        private static void visualizeDescription(string path)
        {
            string description = getDescription(path);

            if (string.IsNullOrEmpty(description))
            {
                return;
            }
            else
            {
                Console.WriteLine(description);
            }
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
            string[] variants = IOFunctions.GetVariants(path);

            for (int i = 1; i < variants.Length+1; i++)
            {
                Console.WriteLine(i + ". " + variants[i - 1]);
            }
        }
        #endregion

        #region error
        private static void visualizeError(string errorText)
        {
            if (string.IsNullOrEmpty(errorText))
            {
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + errorText);
            Console.ResetColor();
        }
        #endregion
    }
}
