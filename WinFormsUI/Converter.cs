using DataTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

// this should be moved to Frontend project

namespace CarEngine
{
    internal static class Converter
    {
        public static Image Base64ToImg(string base64Image)
        {
            //data:image/gif;base64,
            //this image is a single pixel (black)
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
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.Save(memoryStream, file.RawFormat);
                byte[] imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

        public static CarAdMinimal[] vehicleListToAds(List<Car> vehicleList)
        {
            if(vehicleList == null)
            {
                return null;
            }
            CarAdMinimal[] minimalAds = new CarAdMinimal[vehicleList.Count];

            // might not get the amount of ads we asked for
            for (int i = 0; i < vehicleList.Count; i++)
            {
                minimalAds[i] = new CarAdMinimal(vehicleList[i]);
            }
            return minimalAds;
        }
    }
}
