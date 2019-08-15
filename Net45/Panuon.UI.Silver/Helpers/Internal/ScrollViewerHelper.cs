using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    internal class ScrollViewerHelper
    {
        #region (Internal) ScrollViewerHook
        public static bool GetScrollViewerHook(DependencyObject obj)
        {
            return (bool)obj.GetValue(ScrollViewerHookProperty);
        }

        public static void SetScrollViewerHook(DependencyObject obj, bool value)
        {
            obj.SetValue(ScrollViewerHookProperty, value);
        }

        public static readonly DependencyProperty ScrollViewerHookProperty =
            DependencyProperty.RegisterAttached("ScrollViewerHook", typeof(bool), typeof(ScrollViewerHelper), new PropertyMetadata(OnScrollViewerHookChanged));

        private static void OnScrollViewerHookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scrollViewer = d as ScrollViewer;
            scrollViewer.PreviewMouseWheel += ScrollViewer_PreviewMouseWheel;
        }

        private static void ScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;

            if (e.Delta > 0)
            {
                if (scrollViewer.ComputedVerticalScrollBarVisibility == Visibility.Visible)
                    scrollViewer.LineUp();
                else if (scrollViewer.ComputedHorizontalScrollBarVisibility == Visibility.Visible)
                    scrollViewer.LineLeft();
                else if (scrollViewer.VerticalScrollBarVisibility != ScrollBarVisibility.Disabled)
                    scrollViewer.LineUp();
                else if (scrollViewer.HorizontalScrollBarVisibility != ScrollBarVisibility.Disabled)
                    scrollViewer.LineLeft();
                else
                    return;
            }
            else
            {
                if (scrollViewer.ComputedVerticalScrollBarVisibility == Visibility.Visible)
                    scrollViewer.LineDown();
                else if (scrollViewer.ComputedHorizontalScrollBarVisibility == Visibility.Visible)
                    scrollViewer.LineRight();
                else if (scrollViewer.VerticalScrollBarVisibility != ScrollBarVisibility.Disabled)
                    scrollViewer.LineDown();
                else if (scrollViewer.HorizontalScrollBarVisibility != ScrollBarVisibility.Disabled)
                    scrollViewer.LineRight();
                else
                    return;
            }
                

            if (scrollViewer.ComputedVerticalScrollBarVisibility == Visibility.Visible || scrollViewer.ComputedHorizontalScrollBarVisibility == Visibility.Visible)
                e.Handled = true;
        }
        #endregion
    }
}
