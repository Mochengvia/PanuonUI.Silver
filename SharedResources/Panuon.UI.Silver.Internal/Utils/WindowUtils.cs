using Panuon.UI.Silver.Internal.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;

namespace Panuon.UI.Silver.Internal.Utils
{
    internal static class WindowUtils
    {
        #region Fields
        private const int GWL_HWNDPARENT = -8;
        #endregion

        #region Methods

        #region GetWindowRect
        public static Rect GetWindowRect(IntPtr window)
        {
            var rect = new Rect();
            if (window != IntPtr.Zero)
            {
                try
                {
                    User32.GetWindowRect(window, out User32.RECT windowRect);
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

        #region SetOwner
        public static void SetWindowOwner(IntPtr window, IntPtr ownerWindow)
        {
            if (window != IntPtr.Zero && ownerWindow != IntPtr.Zero)
            {
                try
                {
                    User32.SetWindowLong(window, GWL_HWNDPARENT, ownerWindow.ToInt32());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
        #endregion

        #endregion



    }
}
