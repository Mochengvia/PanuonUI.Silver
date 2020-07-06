using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class SliderHelper
    {
        #region Properties
        
        #region SliderStyle
        public static SliderStyle GetSliderStyle(Slider slider)
        {
            return (SliderStyle)slider.GetValue(SliderStyleProperty);
        }

        public static void SetSliderStyle(Slider slider, SliderStyle value)
        {
            slider.SetValue(SliderStyleProperty, value);
        }

        public static readonly DependencyProperty SliderStyleProperty =
            DependencyProperty.RegisterAttached("SliderStyle", typeof(SliderStyle), typeof(SliderHelper));
        #endregion

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
        public static double GetThumbCornerRadius(Slider slider)
        {
            return (double)slider.GetValue(ThumbCornerRadiusProperty);
        }

        public static void SetThumbCornerRadius(Slider slider, double value)
        {
            slider.SetValue(ThumbCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty ThumbCornerRadiusProperty =
            DependencyProperty.RegisterAttached("ThumbCornerRadius", typeof(double), typeof(SliderHelper));
        #endregion

        #region ThumbBrush
        public static Brush GetThumbBrush(Slider slider)
        {
            return (Brush)slider.GetValue(ThumbBrushProperty);
        }

        public static void SetThumbBrush(Slider slider, Brush value)
        {
            slider.SetValue(ThumbBrushProperty, value);
        }

        public static readonly DependencyProperty ThumbBrushProperty =
            DependencyProperty.RegisterAttached("ThumbBrush", typeof(Brush), typeof(SliderHelper));
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
