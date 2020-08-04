using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;

namespace Panuon.UI.Silver.Internal.Utils
{
    static class WindowUtils
    {
        
        #region Methods
        internal static IntPtr GetHwnd(Window window)
        {
            return new WindowInteropHelper(window).Handle;
        }

        #region GetWindowRect
        internal static Rect GetWindowRect(IntPtr window)
        {
            var rect = new Rect();
            if (window != IntPtr.Zero)
            {
                try
                {
                    User32Utils.GetWindowRect(window, out User32Utils.RECT windowRect);
                    rect.Width = Math.Abs(windowRect.Right - windowRect.Left);
                    rect.Height = Math.Abs(windowRect.Bottom - windowRect.Top);
                    rect.X = windowRect.Left;
                    rect.Y = windowRect.Top;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            return rect;
        }
        #endregion

        #endregion


        #region Functions
        #endregion
    }
}
