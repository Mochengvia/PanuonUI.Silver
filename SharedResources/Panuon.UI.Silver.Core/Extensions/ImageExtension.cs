using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace Panuon.UI.Silver.Core
{
    public static class ImageExtension
    {
        #region ToBitmapImage
        /// <summary>
        /// Convert bitmap to bitmap image.
        /// </summary>
        /// <param name="bmp">Bitmap to convert.</param>
        public static BitmapImage ToBitmapImage(this Bitmap bmp)
        {
            using (var ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                ms.Seek(0, SeekOrigin.Begin);
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
        #endregion

        #region ToBitmapImage
        /// <summary>
        /// Convert bitmap source to bitmap image.
        /// </summary>
        /// <param name="source">Bitmap source to convert.</param>
        public static BitmapImage ToBitmapImage(this BitmapSource source)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                BitmapImage bImg = new BitmapImage();

                encoder.Frames.Add(BitmapFrame.Create(source));
                encoder.Save(memoryStream);

                memoryStream.Position = 0;
                bImg.BeginInit();
                bImg.StreamSource = new MemoryStream(memoryStream.ToArray());
                bImg.EndInit();
                return bImg;
            }
        }
        #endregion
    }
}
