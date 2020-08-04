using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class GroupBoxHelper
    {
        #region Properties

        #region HorizontalHeaderAlignment
        public static HorizontalAlignment GetHorizontalHeaderAlignment(GroupBox groupBox)
        {
            return (HorizontalAlignment)groupBox.GetValue(HorizontalHeaderAlignmentProperty);
        }

        public static void SetHorizontalHeaderAlignment(GroupBox groupBox, HorizontalAlignment value)
        {
            groupBox.SetValue(HorizontalHeaderAlignmentProperty, value);
        }

        public static readonly DependencyProperty HorizontalHeaderAlignmentProperty =
            DependencyProperty.RegisterAttached("HorizontalHeaderAlignment", typeof(HorizontalAlignment), typeof(GroupBoxHelper));
        #endregion

        #region VerticalHeaderAlignment
        public static GroupBoxVerticalHeaderAlignment GetVerticalHeaderAlignment(GroupBox groupBox)
        {
            return (GroupBoxVerticalHeaderAlignment)groupBox.GetValue(VerticalHeaderAlignmentProperty);
        }

        public static void SetVerticalHeaderAlignment(GroupBox groupBox, GroupBoxVerticalHeaderAlignment value)
        {
            groupBox.SetValue(VerticalHeaderAlignmentProperty, value);
        }

        public static readonly DependencyProperty VerticalHeaderAlignmentProperty =
            DependencyProperty.RegisterAttached("VerticalHeaderAlignment", typeof(GroupBoxVerticalHeaderAlignment), typeof(GroupBoxHelper));
        #endregion

        #region HeaderForeground
        public static Brush GetHeaderForeground(GroupBox groupBox)
        {
            return (Brush)groupBox.GetValue(HeaderForegroundProperty);
        }

        public static void SetHeaderForeground(GroupBox groupBox, Brush value)
        {
            groupBox.SetValue(HeaderForegroundProperty, value);
        }

        public static readonly DependencyProperty HeaderForegroundProperty =
            DependencyProperty.RegisterAttached("HeaderForeground", typeof(Brush), typeof(GroupBoxHelper));
        #endregion

        #region HeaderBackground
        public static Brush GetHeaderBackground(GroupBox groupBox)
        {
            return (Brush)groupBox.GetValue(HeaderBackgroundProperty);
        }

        public static void SetHeaderBackground(GroupBox groupBox, Brush value)
        {
            groupBox.SetValue(HeaderBackgroundProperty, value);
        }

        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.RegisterAttached("HeaderBackground", typeof(Brush), typeof(GroupBoxHelper));
        #endregion

        #region HeaderHeight
        public static double GetHeaderHeight(GroupBox groupBox)
        {
            return (double)groupBox.GetValue(HeaderHeightProperty);
        }

        public static void SetHeaderHeight(GroupBox groupBox, double value)
        {
            groupBox.SetValue(HeaderHeightProperty, value);
        }

        public static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.RegisterAttached("HeaderHeight", typeof(double), typeof(GroupBoxHelper));
        #endregion

        #region HeaderFontSize
        public static int GetFontSize(GroupBox groupBox)
        {
            return (int)groupBox.GetValue(FontSizeProperty);
        }

        public static void SetFontSize(GroupBox groupBox, int value)
        {
            groupBox.SetValue(FontSizeProperty, value);
        }

        public static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.RegisterAttached("FontSize", typeof(int), typeof(GroupBoxHelper));
        #endregion

        #region HeaderPadding
        public static Thickness GetHeaderPadding(GroupBox groupBox)
        {
            return (Thickness)groupBox.GetValue(HeaderPaddingProperty);
        }

        public static void SetHeaderPadding(GroupBox groupBox, Thickness value)
        {
            groupBox.SetValue(HeaderPaddingProperty, value);
        }

        public static readonly DependencyProperty HeaderPaddingProperty =
            DependencyProperty.RegisterAttached("HeaderPadding", typeof(Thickness), typeof(GroupBoxHelper));
        #endregion

        #region HeaderRibbonLineVisibility
        public static Visibility GetHeaderRibbonLineVisibility(GroupBox groupBox)
        {
            return (Visibility)groupBox.GetValue(HeaderRibbonLineVisibilityProperty);
        }

        public static void SetHeaderRibbonLineVisibility(GroupBox groupBox, Visibility value)
        {
            groupBox.SetValue(HeaderRibbonLineVisibilityProperty, value);
        }

        public static readonly DependencyProperty HeaderRibbonLineVisibilityProperty =
            DependencyProperty.RegisterAttached("HeaderRibbonLineVisibility", typeof(Visibility), typeof(GroupBoxHelper));
        #endregion

        #region HeaderRibbonLineBrush
        public static Brush GetHeaderRibbonLineBrush(GroupBox groupBox)
        {
            return (Brush)groupBox.GetValue(HeaderRibbonLineBrushProperty);
        }

        public static void SetHeaderRibbonLineBrush(GroupBox groupBox, Brush value)
        {
            groupBox.SetValue(HeaderRibbonLineBrushProperty, value);
        }

        public static readonly DependencyProperty HeaderRibbonLineBrushProperty =
            DependencyProperty.RegisterAttached("HeaderRibbonLineBrush", typeof(Brush), typeof(GroupBoxHelper));
        #endregion

        #region HeaderRibbonLineThickness
        public static double GetHeaderRibbonLineThickness(GroupBox groupBox)
        {
            return (double)groupBox.GetValue(HeaderRibbonLineThicknessProperty);
        }

        public static void SetHeaderRibbonLineThickness(GroupBox groupBox, double value)
        {
            groupBox.SetValue(HeaderRibbonLineThicknessProperty, value);
        }

        public static readonly DependencyProperty HeaderRibbonLineThicknessProperty =
            DependencyProperty.RegisterAttached("HeaderRibbonLineThickness", typeof(double), typeof(GroupBoxHelper));
        #endregion

        #region Icon
        public static object GetIcon(GroupBox groupBox)
        {
            return (object)groupBox.GetValue(IconProperty);
        }

        public static void SetIcon(GroupBox groupBox, object value)
        {
            groupBox.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(GroupBoxHelper));
        #endregion

        #region CornerRadius
        public static CornerRadius GetCornerRadius(GroupBox groupBox)
        {
            return (CornerRadius)groupBox.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(GroupBox groupBox, CornerRadius value)
        {
            groupBox.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(GroupBoxHelper));
        #endregion

        #region ShadowColor
        public static Color? GetShadowColor(GroupBox groupBox)
        {
            return (Color?)groupBox.GetValue(ShadowColorProperty);
        }

        public static void SetShadowColor(GroupBox groupBox, Color? value)
        {
            groupBox.SetValue(ShadowColorProperty, value);
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.RegisterAttached("ShadowColor", typeof(Color?), typeof(GroupBoxHelper));
        #endregion

        #region ExtendControl
        public static object GetExtendControl(GroupBox groupBox)
        {
            return (object)groupBox.GetValue(ExtendControlProperty);
        }

        public static void SetExtendControl(GroupBox groupBox, object value)
        {
            groupBox.SetValue(ExtendControlProperty, value);
        }

        public static readonly DependencyProperty ExtendControlProperty =
            DependencyProperty.RegisterAttached("ExtendControl", typeof(object), typeof(GroupBoxHelper));
        #endregion

        #endregion

    }
}
