using System;
using System.Drawing;
using System.IO;

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


    }
}
