using System;
using System.IO;
using System.Drawing;

namespace Frontend
{
    // for unknown reason this is not working
    internal static class Utilities
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