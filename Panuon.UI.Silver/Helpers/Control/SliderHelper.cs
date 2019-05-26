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
            DependencyProperty.RegisterAttached("SliderStyle", typeof(SliderStyle), typeof(SliderHelper));
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
            DependencyProperty.RegisterAttached("TrackBrush", typeof(Brush), typeof(SliderHelper));
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
    }

}
