using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;

namespace Panuon.UI.Silver
{
    internal class NotTopMostPopup : Popup
    {
        private Window _window;
        protected override void OnOpened(EventArgs e)
        {
            var hwnd = ((HwndSource)PresentationSource.FromVisual(this.Child)).Handle;
            RECT rect;

            if (GetWindowRect(hwnd, out rect))
            {
                SetWindowPos(hwnd, -2, rect.Left, rect.Top, (int)this.Width, (int)this.Height, 0);
            }

            _window = Window.GetWindow(this);
            _window.PreviewMouseDown -= Window_PreviewMouseDown;
            _window.PreviewMouseDown += Window_PreviewMouseDown;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            PreviewMouseDown += NotTopMostPopup_PreviewMouseDown;
            _window.PreviewMouseDown -= Window_PreviewMouseDown;
        }

        private void NotTopMostPopup_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var element = Tag as FrameworkElement;

            if (Placement == PlacementMode.Bottom)
            {
                var position = Mouse.GetPosition(this);
                if (position.X < 0 || position.Y < 0 || position.X > (Child as FrameworkElement).ActualWidth)
                {
                    IsOpen = false;
                    return;
                }
                else if (element != null)
                {
                    if (element.ActualWidth != 0 && position.Y > (Child as FrameworkElement).ActualHeight + element.ActualHeight)
                    {
                        IsOpen = false;
                        return;
                    }
                    if (element.ActualWidth != 0 && position.X > element.ActualWidth && (position.Y > (Child as FrameworkElement).ActualHeight + element.ActualHeight || position.Y < element.ActualHeight))
                    {
                        IsOpen = false;
                        return;
                    }
                }
            }
            else if (Placement == PlacementMode.Left)
            {
                var position = Mouse.GetPosition(this);
                if (position.X > element.ActualWidth || position.Y > (Child as FrameworkElement).ActualHeight + element.ActualHeight)
                {
                    IsOpen = false;
                    return;
                }
                else if (element != null)
                {
                    if (position.X < -(Child as FrameworkElement).ActualWidth + element.ActualWidth || position.Y < 0)
                    {
                        IsOpen = false;
                        return;
                    }
                    if (position.X > element.ActualWidth && (position.Y > (Child as FrameworkElement).ActualHeight || position.Y < element.ActualHeight))
                    {
                        IsOpen = false;
                        return;
                    }
                }
            }

        }

        #region P/Invoke imports & definitions

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32", EntryPoint = "SetWindowPos")]
        private static extern int SetWindowPos(IntPtr hWnd, int hwndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        #endregion
    }
}
