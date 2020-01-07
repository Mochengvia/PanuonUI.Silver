using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class CheckBoxHelper
    {
        #region Properties

        #region CheckBoxStyle
        public static CheckBoxStyle GetCheckBoxStyle(CheckBox checkBox)
        {
            return (CheckBoxStyle)checkBox.GetValue(CheckBoxStyleProperty);
        }

        public static void SetCheckBoxStyle(CheckBox checkBox, CheckBoxStyle value)
        {
            checkBox.SetValue(CheckBoxStyleProperty, value);
        }

        public static readonly DependencyProperty CheckBoxStyleProperty =
            DependencyProperty.RegisterAttached("CheckBoxStyle", typeof(CheckBoxStyle), typeof(CheckBoxHelper));
        #endregion

        #region CheckedBackground
        public static Brush GetCheckedBackground(CheckBox checkBox)
        {
            return (Brush)checkBox.GetValue(CheckedBackgroundProperty);
        }

        public static void SetCheckedBackground(CheckBox checkBox, Brush value)
        {
            checkBox.SetValue(CheckedBackgroundProperty, value);
        }

        public static readonly DependencyProperty CheckedBackgroundProperty =
            DependencyProperty.RegisterAttached("CheckedBackground", typeof(Brush), typeof(CheckBoxHelper));
        #endregion

        #region GlyphBrush
        public static Brush GetGlyphBrush(CheckBox checkBox)
        {
            return (Brush)checkBox.GetValue(GlyphBrushProperty);
        }

        public static void SetGlyphBrush(CheckBox checkBox, Brush value)
        {
            checkBox.SetValue(GlyphBrushProperty, value);
        }

        public static readonly DependencyProperty GlyphBrushProperty =
            DependencyProperty.RegisterAttached("GlyphBrush", typeof(Brush), typeof(CheckBoxHelper));
        #endregion

        #region CheckedGlyphBrush
        public static Brush GetCheckedGlyphBrush(CheckBox checkBox)
        {
            return (Brush)checkBox.GetValue(CheckedGlyphBrushProperty);
        }

        public static void SetCheckedGlyphBrush(CheckBox checkBox, Brush value)
        {
            checkBox.SetValue(CheckedGlyphBrushProperty, value);
        }

        public static readonly DependencyProperty CheckedGlyphBrushProperty =
            DependencyProperty.RegisterAttached("CheckedGlyphBrush", typeof(Brush), typeof(CheckBoxHelper));
        #endregion

        #region CheckedBorderBrush
        public static Brush GetCheckedBorderBrush(CheckBox checkBox)
        {
            return (Brush)checkBox.GetValue(CheckedBorderBrushProperty);
        }

        public static void SetCheckedBorderBrush(CheckBox checkBox, Brush value)
        {
            checkBox.SetValue(CheckedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty CheckedBorderBrushProperty =
            DependencyProperty.RegisterAttached("CheckedBorderBrush", typeof(Brush), typeof(CheckBoxHelper));
        #endregion

        #region BoxHeight
        public static double GetBoxHeight(CheckBox checkBox)
        {
            return (double)checkBox.GetValue(BoxHeightProperty);
        }

        public static void SetBoxHeight(CheckBox checkBox, double value)
        {
            checkBox.SetValue(BoxHeightProperty, value);
        }

        public static readonly DependencyProperty BoxHeightProperty =
            DependencyProperty.RegisterAttached("BoxHeight", typeof(double), typeof(CheckBoxHelper));
        #endregion

        #region BoxWidth
        public static double GetBoxWidth(CheckBox checkBox)
        {
            return (double)checkBox.GetValue(BoxWidthProperty);
        }

        public static void SetBoxWidth(CheckBox checkBox, double value)
        {
            checkBox.SetValue(BoxWidthProperty, value);
        }

        public static readonly DependencyProperty BoxWidthProperty =
            DependencyProperty.RegisterAttached("BoxWidth", typeof(double), typeof(CheckBoxHelper));
        #endregion

        #region CornerRadius
        public static CornerRadius GetCornerRadius(CheckBox checkBox)
        {
            return (CornerRadius)checkBox.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(CheckBox checkBox, CornerRadius value)
        {
            checkBox.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(CheckBoxHelper));
        #endregion

        #region CheckedContent
        public static object GetCheckedContent(CheckBox checkBox)
        {
            return (object)checkBox.GetValue(CheckedContentProperty);
        }

        public static void SetCheckedContent(CheckBox checkBox, object value)
        {
            checkBox.SetValue(CheckedContentProperty, value);
        }

        public static readonly DependencyProperty CheckedContentProperty =
            DependencyProperty.RegisterAttached("CheckedContent", typeof(object), typeof(CheckBoxHelper));
        #endregion

        #endregion
    }
}
