using Microsoft.Windows.Shell;
using System;
using System.Windows;

namespace Panuon.UI.Silver.Utils
{
    static class WindowChromeUtils
    {
        internal static void SetIsHitTestVisibleInChrome(UIElement element, bool hitTestVisible)
        {
            WindowChrome.SetIsHitTestVisibleInChrome(element, hitTestVisible);
        }

        internal static void SetCaptionHeight(WindowX windowX, double height)
        {
            var action = new Action(() =>
            {
                var chrome = WindowChrome.GetWindowChrome(windowX);
                if (chrome == null)
                {
                    return;
                }
                chrome.CaptionHeight = height;
            });

            if (windowX.IsLoaded)
            {
                action();
            }
            else
            {
                windowX.Loaded += delegate
                {
                    action();
                };
            }

        }

    }
}
