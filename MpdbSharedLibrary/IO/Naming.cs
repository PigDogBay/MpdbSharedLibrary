using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MpdBaileyTechnology.Shared.IO
{
    /// <summary>
    /// Functions for generating file and directory names
    /// </summary>
    public static class Naming
    {
        private const string TimeStampFormat = "yyyyMMdd_HHmmss";

        /// <summary>
        /// Creates a custom filename that includes a time stamp
        /// </summary>
        /// <param name="folder">Windows special folder</param>
        /// <param name="prefix">File name prefix</param>
        /// <param name="extension">File name extension</param>
        /// <returns>Time stamped filename</returns>
        public static string GenerateTimeStampedName(Environment.SpecialFolder folder, string prefix, string extension)
        {
            return GenerateTimeStampedName(Environment.GetFolderPath(folder), prefix, extension);
        }
        /// <summary>
        /// Creates a custom filename that includes a time stamp
        /// </summary>
        /// <param name="folder">Directory name</param>
        /// <param name="prefix">File name prefix</param>
        /// <param name="extension">File name extension</param>
        /// <returns>Time stamped filename</returns>
        public static string GenerateTimeStampedName(string directory, string prefix, string extension)
        {
            string date = DateTime.Now.ToString(TimeStampFormat);
            return string.Format(@"{0}\{1}_{2}.{3}", directory, prefix, date, extension);
        }
        /// <summary>
        /// Ensures that the file name is unique, by adding " (x)", where x is appropriate number to ensure uniqueness
        /// </summary>
        /// <param name="fileName">File name to make unique</param>
        /// <returns>Unique file name</returns>
        public static String GetUniqueFileName(String fileName)
        {
            if (!File.Exists(fileName))
            {
                //filename is already unique
                return fileName;
            }
            //break file up into path, filename and extension
            String ext = Path.GetExtension(fileName);
            String name = Path.GetFileNameWithoutExtension(fileName);
            String path = Path.GetDirectoryName(fileName);
            String baseName = path + Path.DirectorySeparatorChar + name;
            int count = 1;
            String newName = null;
            do
            {
                newName = baseName + " (" + count + ")" + ext;
                count++;
            } while (File.Exists(newName));
            return newName;
        }
        /// <summary>
        /// Ensures that the directory name is unique, by adding " (x)", where x is appropriate number to ensure uniqueness
        /// </summary>
        /// <param name="fileName">Directory name to make unique</param>
        /// <returns>Unique Directory name</returns>
        public static String GetUniqueDirectoryName(String dirName)
        {
            if (!Directory.Exists(dirName))
            {
                //directory name is unique
                return dirName;
            }
            int count = 1;
            String newName = null;
            do
            {
                newName = dirName + " (" + count + ")";
                count++;
            } while (Directory.Exists(newName));
            return newName;
        }

    }
}
