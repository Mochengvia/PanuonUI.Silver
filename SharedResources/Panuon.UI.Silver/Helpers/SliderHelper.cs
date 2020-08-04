using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class SliderHelper
    {
        #region Properties
        
        #region TrackThickness
        public static double GetTrackThickness(Slider slider)
        {
            return (double)slider.GetValue(TrackThicknessProperty);
        }

        public static void SetTrackThickness(Slider slider, double value)
        {
            slider.SetValue(TrackThicknessProperty, value);
        }

        public static readonly DependencyProperty TrackThicknessProperty =
            DependencyProperty.RegisterAttached("TrackThickness", typeof(double), typeof(SliderHelper));
        #endregion

        #region ThumbSize
        public static double GetThumbSize(Slider slider)
        {
            return (double)slider.GetValue(ThumbSizeProperty);
        }

        public static void SetThumbSize(Slider slider, double value)
        {
            slider.SetValue(ThumbSizeProperty, value);
        }

        public static readonly DependencyProperty ThumbSizeProperty =
            DependencyProperty.RegisterAttached("ThumbSize", typeof(double), typeof(SliderHelper));
        #endregion

        #region ThumbCornerRadius
        public static CornerRadius GetThumbCornerRadius(Slider slider)
        {
            return (CornerRadius)slider.GetValue(ThumbCornerRadiusProperty);
        }

        public static void SetThumbCornerRadius(Slider slider, CornerRadius value)
        {
            slider.SetValue(ThumbCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty ThumbCornerRadiusProperty =
            DependencyProperty.RegisterAttached("ThumbCornerRadius", typeof(CornerRadius), typeof(SliderHelper));
        #endregion

        #region ThumbBackground
        public static Brush GetThumbBackground(Slider slider)
        {
            return (Brush)slider.GetValue(ThumbBackgroundProperty);
        }

        public static void SetThumbBackground(Slider slider, Brush value)
        {
            slider.SetValue(ThumbBackgroundProperty, value);
        }

        public static readonly DependencyProperty ThumbBackgroundProperty =
            DependencyProperty.RegisterAttached("ThumbBackground", typeof(Brush), typeof(SliderHelper));
        #endregion

        #region ThumbBorderBrush
        public static Brush GetThumbBorderBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ThumbBorderBrushProperty);
        }

        public static void SetThumbBorderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(ThumbBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ThumbBorderBrushProperty =
            DependencyProperty.RegisterAttached("ThumbBorderBrush", typeof(Brush), typeof(SliderHelper));
        #endregion

        #region ThumbBorderThickness
        public static double GetThumbBorderThickness(DependencyObject obj)
        {
            return (double)obj.GetValue(ThumbBorderThicknessProperty);
        }

        public static void SetThumbBorderThickness(DependencyObject obj, double value)
        {
            obj.SetValue(ThumbBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty ThumbBorderThicknessProperty =
            DependencyProperty.RegisterAttached("ThumbBorderThickness", typeof(double), typeof(SliderHelper));
        #endregion

        #region ThumbShadowColor
        public static Color? GetThumbShadowColor(Slider slider)
        {
            return (Color?)slider.GetValue(ThumbShadowColorProperty);
        }

        public static void SetThumbShadowColor(Slider slider, Color? value)
        {
            slider.SetValue(ThumbShadowColorProperty, value);
        }

        public static readonly DependencyProperty ThumbShadowColorProperty =
            DependencyProperty.RegisterAttached("ThumbShadowColor", typeof(Color?), typeof(SliderHelper));
        #endregion

        #endregion

    }
}
