using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver.Internal.Utils
{
    public static class ImageUtils
    {
        public static ImageSource GetImageSource(System.Drawing.Icon icon)
        {
            if (icon == null)
                return null;
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

        }
    }

}
