using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class SliderHelper
    {
        #region SliderStyle
        public static SliderStyle GetSliderStyle(DependencyObject obj)
        {
            return (SliderStyle)obj.GetValue(SliderStyleProperty);
        }

        public static void SetSliderStyle(DependencyObject obj, SliderStyle value)
        {
            obj.SetValue(SliderStyleProperty, value);
        }

        public static readonly DependencyProperty SliderStyleProperty =
            DependencyProperty.RegisterAttached("SliderStyle", typeof(SliderStyle), typeof(SliderHelper), new PropertyMetadata(SliderStyle.Standard));
        #endregion

        #region ThemeBrush
        public static Brush GetThemeBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ThemeBrushProperty);
        }

        public static void SetThemeBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(ThemeBrushProperty, value);
        }

        public static readonly DependencyProperty ThemeBrushProperty =
            DependencyProperty.RegisterAttached("ThemeBrush", typeof(Brush), typeof(SliderHelper));
        #endregion

        #region TrackThickness
        public static double GetTrackThickness(DependencyObject obj)
        {
            return (double)obj.GetValue(TrackThicknessProperty);
        }

        public static void SetTrackThickness(DependencyObject obj, double value)
        {
            obj.SetValue(TrackThicknessProperty, value);
        }

        public static readonly DependencyProperty TrackThicknessProperty =
            DependencyProperty.RegisterAttached("TrackThickness", typeof(double), typeof(SliderHelper));


        #endregion

        #region ThumbSize
        public static double GetThumbSize(DependencyObject obj)
        {
            return (double)obj.GetValue(ThumbSizeProperty);
        }

        public static void SetThumbSize(DependencyObject obj, double value)
        {
            obj.SetValue(ThumbSizeProperty, value);
        }

        public static readonly DependencyProperty ThumbSizeProperty =
            DependencyProperty.RegisterAttached("ThumbSize", typeof(double), typeof(SliderHelper));


        #endregion

        #region IsTickValueVisible
        public static bool GetIsTickValueVisible(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsTickValueVisibleProperty);
        }

        public static void SetIsTickValueVisible(DependencyObject obj, bool value)
        {
            obj.SetValue(IsTickValueVisibleProperty, value);
        }

        public static readonly DependencyProperty IsTickValueVisibleProperty =
            DependencyProperty.RegisterAttached("IsTickValueVisible", typeof(bool), typeof(SliderHelper));
        #endregion

        #region Header
        public static object GetHeader(DependencyObject obj)
        {
            return (object)obj.GetValue(HeaderProperty);
        }

        public static void SetHeader(DependencyObject obj, object value)
        {
            obj.SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.RegisterAttached("Header", typeof(object), typeof(SliderHelper));
        #endregion

        #region HeaderWidth
        public static string GetHeaderWidth(DependencyObject obj)
        {
            return (string)obj.GetValue(HeaderWidthProperty);
        }

        public static void SetHeaderWidth(DependencyObject obj, string value)
        {
            obj.SetValue(HeaderWidthProperty, value);
        }

        public static readonly DependencyProperty HeaderWidthProperty =
            DependencyProperty.RegisterAttached("HeaderWidth", typeof(string), typeof(SliderHelper));
        #endregion
    }

}
