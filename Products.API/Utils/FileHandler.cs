using System;
using System.Drawing;
using System.IO;

namespace Products_API.Utils
{
    public static class FileHandler
    {
        public static byte[] GetImageByteArray(string imageFileName)
        {
            string imagePath = GetFilePath($"Resources/Images/{imageFileName}");

            Image image = Image.FromFile(imagePath);

            using(MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private static string GetFilePath(string filePath)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
        }
    }
}
