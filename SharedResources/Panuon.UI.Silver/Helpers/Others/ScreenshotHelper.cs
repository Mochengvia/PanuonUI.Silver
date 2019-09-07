using Panuon.UI.Silver.Controls.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Panuon.UI.Silver
{
    public class ScreenshotHelper
    {
        public static BitmapSource BeginScreenshot()
        {
            var window = new ScreenshotWindow();
            window.ShowDialog();
            return window.Result;
        }
    }
}
