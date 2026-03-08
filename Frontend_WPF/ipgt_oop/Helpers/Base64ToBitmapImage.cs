using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ipgt_oop.Helpers
{
    class Base64ToBitmapImage
    {
        public static BitmapImage Base64Converter(string base64)
        {
            if (base64.Contains(","))
                base64 = base64.Substring(base64.IndexOf(",") + 1);

            byte[] imageBytes = Convert.FromBase64String(base64);

            using (var ms = new MemoryStream(imageBytes))
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = ms;
                bitmap.EndInit();
                bitmap.Freeze();
                return bitmap;
            }
        }
    }
}
