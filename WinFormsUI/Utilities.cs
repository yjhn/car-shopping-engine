using DataTypes;
using Frontend;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CarEngine
{
    internal static class Utilities
    {
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using var wrapMode = new ImageAttributes();
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
            }

            return destImage;
        }

        public static Image Base64ToImg(string base64Image)
        {
            byte[] bytes = Convert.FromBase64String(base64Image);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            return image;
        }

        public static string ConvertImageToBase64(Image file)
        {
            using MemoryStream memoryStream = new MemoryStream();
            file.Save(memoryStream, file.RawFormat);
            byte[] imageBytes = memoryStream.ToArray();
            return Convert.ToBase64String(imageBytes);
        }

        public static CarAdMinimal[] VehicleListToAds(List<Car> vehicleList, UserInfo userInfo)
        {
            if (vehicleList == null)
            {
                return null;
            }
            CarAdMinimal[] minimalAds = new CarAdMinimal[vehicleList.Count];

            // might not get the amount of ads we asked for
            for (int i = 0; i < vehicleList.Count; i++)
            {
                minimalAds[i] = new CarAdMinimal(vehicleList[i], userInfo);
            }
            return minimalAds;
        }

        public static bool ValidateInput(string username, string password)
        {
            return !(username == "" || username.Contains(' ') || password == "" || password.Contains(' '));
        }

        public static string EncryptPassword(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var saltedPassword = string.Format("{0}{1}", salt, password);
            byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
            return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
        }
    }
}
