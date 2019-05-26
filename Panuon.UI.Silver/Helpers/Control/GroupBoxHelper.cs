using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class GroupBoxHelper
    {
        #region ShadowColor
        public static Color GetShadowColor(DependencyObject obj)
        {
            return (Color)obj.GetValue(ShadowColorProperty);
        }

        public static void SetShadowColor(DependencyObject obj, Color value)
        {
            obj.SetValue(ShadowColorProperty, value);
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.RegisterAttached("ShadowColor", typeof(Color), typeof(GroupBoxHelper));
        #endregion
    }
}
