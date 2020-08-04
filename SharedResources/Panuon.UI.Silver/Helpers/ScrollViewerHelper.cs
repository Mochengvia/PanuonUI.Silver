using Panuon.UI.Silver.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class ScrollViewerHelper
    {
        #region Properties

        #region TrackBrush
        public static Brush GetTrackBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(TrackBrushProperty);
        }

        public static void SetTrackBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(TrackBrushProperty, value);
        }

        public static readonly DependencyProperty TrackBrushProperty =
            DependencyProperty.RegisterAttached("TrackBrush", typeof(Brush), typeof(ScrollViewerHelper), new FrameworkPropertyMetadata(new SolidColorBrush("#EEEEEE".ToColor(Colors.Transparent)), FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region ThumbBrush
        public static Brush GetThumbBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ThumbBrushProperty);
        }

        public static void SetThumbBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(ThumbBrushProperty, value);
        }

        public static readonly DependencyProperty ThumbBrushProperty =
            DependencyProperty.RegisterAttached("ThumbBrush", typeof(Brush), typeof(ScrollViewerHelper), new FrameworkPropertyMetadata(new SolidColorBrush("#AAAAAA".ToColor(Colors.Transparent)), FrameworkPropertyMetadataOptions.Inherits));


        #endregion

        #region ScrollBarThickness
        public static double GetScrollBarThickness(DependencyObject obj)
        {
            return (double)obj.GetValue(ScrollBarThicknessProperty);
        }

        public static void SetScrollBarThickness(DependencyObject obj, double value)
        {
            obj.SetValue(ScrollBarThicknessProperty, value);
        }

        public static readonly DependencyProperty ScrollBarThicknessProperty =
            DependencyProperty.RegisterAttached("ScrollBarThickness", typeof(double), typeof(ScrollViewerHelper), new FrameworkPropertyMetadata(14.0, FrameworkPropertyMetadataOptions.Inherits));


        #endregion

        #region ScrollBarCornerRadius
        public static CornerRadius GetScrollBarCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(ScrollBarCornerRadiusProperty);
        }

        public static void SetScrollBarCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(ScrollBarCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty ScrollBarCornerRadiusProperty =
            DependencyProperty.RegisterAttached("ScrollBarCornerRadius", typeof(CornerRadius), typeof(ScrollViewerHelper), new FrameworkPropertyMetadata(new CornerRadius(0), FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region ScrollButtons
        public static ScrollButtons GetScrollButtons(DependencyObject obj)
        {
            return (ScrollButtons)obj.GetValue(ScrollButtonsProperty);
        }

        public static void SetScrollButtons(DependencyObject obj, ScrollButtons value)
        {
            obj.SetValue(ScrollButtonsProperty, value);
        }

        public static readonly DependencyProperty ScrollButtonsProperty =
            DependencyProperty.RegisterAttached("ScrollButtons", typeof(ScrollButtons), typeof(ScrollViewerHelper), new FrameworkPropertyMetadata(ScrollButtons.None, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region ScrollButtonStyle
        public static Style GetScrollButtonStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(ScrollButtonStyleProperty);
        }

        public static void SetScrollButtonStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(ScrollButtonStyleProperty, value);
        }

        public static readonly DependencyProperty ScrollButtonStyleProperty =
            DependencyProperty.RegisterAttached("ScrollButtonStyle", typeof(Style), typeof(ScrollViewerHelper), new FrameworkPropertyMetadata(default, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region HandleMouseWheel
        public static bool GetHandleMouseWheel(DependencyObject obj)
        {
            return (bool)obj.GetValue(HandleMouseWheelProperty);
        }

        public static void SetHandleMouseWheel(DependencyObject obj, bool value)
        {
            obj.SetValue(HandleMouseWheelProperty, value);
        }

        public static readonly DependencyProperty HandleMouseWheelProperty =
            DependencyProperty.RegisterAttached("HandleMouseWheel", typeof(bool), typeof(ScrollViewerHelper), new PropertyMetadata(OnHandleMouseWheelChanged));
        #endregion

        #endregion

        #region Event Handler
        private static void OnHandleMouseWheelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scrollViewer = d as ScrollViewer;
            scrollViewer.PreviewMouseWheel -= OnScrollViewerPreviewMouseWheel;

            if ((bool)e.NewValue)
            {
                scrollViewer.PreviewMouseWheel += OnScrollViewerPreviewMouseWheel;
            }
        }


        private static void OnScrollViewerPreviewMouseWheel(object sender, RoutedEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;

            if (scrollViewer == null)
                return;

            var handleMouseWheel = GetHandleMouseWheel(scrollViewer);
            if (handleMouseWheel)
            {
                var args = e as MouseWheelEventArgs;
                if (args.Delta > 0)
                {
                    scrollViewer.LineUp();
                }
                else
                {
                    scrollViewer.LineDown();

                }
                e.Handled = true;
            }
        }
        #endregion
    }
}
