using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PhoneAnalyzer.Helpers
{
    public static class FileHelper
    {
        private static readonly string PhotoDir = Application.StartupPath + "\\Photo";
        private static readonly string DocDir = Application.StartupPath + "\\Photo";

        public static string CopyFile(string directory, string filePath, string newFileName, string extention = "")
        {
            CreateDirectory(directory);
            string newFilePath = string.Format("{0}\\{1}{2}", directory, newFileName, extention).Replace("\\\\", "\\");
            File.Copy(filePath, newFilePath);
            return newFilePath;
        }

        internal static string SavePhoto(Image image, int width = 0, int height = 0)
        {
            if ((width > 0) && (height > 0))
            {
                image = CutImage(image, width, height);
            }

            CreateDirectory(PhotoDir);
            string newFilePath = string.Format("{0}\\{1}.png", PhotoDir, Guid.NewGuid()).Replace("\\\\", "\\");
            image.Save(newFilePath);
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

        public static Image ResizeImage(Image image, float width, float height)
        {
            var newImage = new Bitmap((int) width, (int) height);

            float relation = Math.Max(image.Width / width, image.Height / height);
            float newWidth = image.Width / relation;
            float newHeight = image.Height / relation;
            float x = (width - newWidth) / 2;
            float y = (height - newHeight) / 2;

            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);
                graphics.DrawImage(image, x, y, newWidth, newHeight);
            }

            return newImage;
        }

        public static Image CutImage(Image image, float width, float height)
        {
            var newImage = new Bitmap((int) width, (int) height);

            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);
                graphics.DrawImage(image, 0, 0);
            }

            return newImage;
        }

        public static Image CenterImage(Image image, float width, float height)
        {
            var newImage = new Bitmap((int) width, (int) height);

            float relation = Math.Min(image.Width / width, image.Height / height);
            float newWidth = image.Width / relation;
            float newHeight = image.Height / relation;
            float x = (width - newWidth) / 2;
            float y = (height - newHeight) / 2;

            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);
                graphics.DrawImage(image, x, y, newWidth, newHeight);
            }

            return newImage;
        }

        public static bool IsFileExists(string fileName)
        {
            return (fileName.Length > 0) && (File.Exists(fileName));
        }
    }
}