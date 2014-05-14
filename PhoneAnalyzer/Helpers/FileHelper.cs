using System.IO;

namespace PhoneAnalyzer.Helpers
{
    /// <summary>
    /// Содержит методы, для работы с файлами
    /// </summary>
    public static class FileHelper
    {
        public static string CopyFile(string directory, string filePath, string newFileName, string extention = "")
        {
            CreateDirectory(directory);
            string newFilePath = string.Format("{0}\\{1}{2}", directory, newFileName, extention).Replace("\\\\", "\\");
            File.Copy(filePath, newFilePath);
            return newFilePath;
        }

        public static void CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public static void DeleteDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory);
            }
        }

        public static string GetExtention(string filePath)
        {
            string[] values = filePath.Split(".".ToCharArray());
            return values.Length == 1 ? "" : string.Format(".{0}", values[values.Length - 1]);
        }

        public static bool IsFileExists(string fileName)
        {
            return (fileName.Length > 0) && (File.Exists(fileName));
        }
    }
}