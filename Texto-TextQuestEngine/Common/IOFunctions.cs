using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Common
{
    public class IOFunctions
    {
        /// <summary>
        /// Just add name and extension(if it exist) of file/directory to path
        /// </summary>
        public static string AddThisToPath(string currentPath, string name, string extension = "")
        {
            string newPath;

            if (string.IsNullOrEmpty(extension))
            {
                newPath = currentPath + @"\" + name;
            }
            else
            {
                newPath = currentPath + @"\" + name + "." + extension;
            }

            return newPath;
        }

        public static string[] GetVariants(string path)
        {
            return getFoldersName(path).Concat(GetShortcutsFolderName(path)).ToArray();
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

        public static string[] GetShortcutsFolderName(string path)
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
    }
}
