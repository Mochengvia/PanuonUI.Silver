using System.Windows.Shell;

namespace Panuon.UI.Silver
{
    public static partial class WindowXCaption
    {
        #region Function
        private static void SetCaptionHeight(WindowX windowX, double height)
        {
            var chrome = WindowChrome.GetWindowChrome(windowX);
            if (chrome == null)
                return;
            chrome.CaptionHeight = height;
        }
        #endregion

    }
}
