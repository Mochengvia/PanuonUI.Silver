using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Panuon.UI.Silver
{
    public class GroupBoxHelper
    {
        #region CornerRadius
        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(GroupBoxHelper));
        #endregion

        #region HeaderBackground
        public static Brush GetHeaderBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HeaderBackgroundProperty);
        }

        public static void SetHeaderBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(HeaderBackgroundProperty, value);
        }

        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.RegisterAttached("HeaderBackground", typeof(Brush), typeof(GroupBoxHelper));
        #endregion

        #region Effect
        public static Effect GetEffect(DependencyObject obj)
        {
            return (Effect)obj.GetValue(EffectProperty);
        }

        public static void SetEffect(DependencyObject obj, Effect value)
        {
            obj.SetValue(EffectProperty, value);
        }

        public static readonly DependencyProperty EffectProperty =
            DependencyProperty.RegisterAttached("Effect", typeof(Effect), typeof(GroupBoxHelper));
        #endregion
    }
}
