using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;

namespace Panuon.UI.Silver.Controls.Internal
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
            _window.LocationChanged -= Window_LocationChanged;
            _window.LocationChanged += Window_LocationChanged;
            RaiseOpening();
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            var offset = HorizontalOffset;
            HorizontalOffset = offset + 1;
            HorizontalOffset = offset;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if(_window != null)
                _window.PreviewMouseDown -= Window_PreviewMouseDown;

            RaiseClosing();
        }


        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var element = Tag as FrameworkElement;
            if (!StaysOpen && !IsMouseOver && !element.IsMouseOver)
                IsOpen = false;
        }

        #region Event
        public static readonly RoutedEvent OpeningEvent = EventManager.RegisterRoutedEvent("Opening", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MultiComboBox));
        public event RoutedEventHandler Opening
        {
            add { AddHandler(OpeningEvent, value); }
            remove { RemoveHandler(OpeningEvent, value); }
        }
        void RaiseOpening()
        {
            var arg = new RoutedEventArgs(OpeningEvent);
            RaiseEvent(arg);
        }

        public static readonly RoutedEvent ClosingEvent = EventManager.RegisterRoutedEvent("Closing", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MultiComboBox));
        public event RoutedEventHandler Closing
        {
            add { AddHandler(ClosingEvent, value); }
            remove { RemoveHandler(ClosingEvent, value); }
        }
        void RaiseClosing()
        {
            var arg = new RoutedEventArgs(ClosingEvent);
            RaiseEvent(arg);
        }
        #endregion

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
