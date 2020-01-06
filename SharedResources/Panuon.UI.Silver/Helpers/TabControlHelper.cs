using Panuon.UI.Silver.Core;
using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class TabControlHelper
    {
        #region TabControlStyle
        public static TabControlStyle GetTabControlStyle(DependencyObject obj)
        {
            return (TabControlStyle)obj.GetValue(TabControlStyleProperty);
        }

        public static void SetTabControlStyle(DependencyObject obj, TabControlStyle value)
        {
            obj.SetValue(TabControlStyleProperty, value);
        }

        public static readonly DependencyProperty TabControlStyleProperty =
            DependencyProperty.RegisterAttached("TabControlStyle", typeof(TabControlStyle), typeof(TabControlHelper), new FrameworkPropertyMetadata(TabControlStyle.Standard, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region TabControlHeaderStyle
        public static TabControlHeaderStyle GetTabControlHeaderStyle(DependencyObject obj)
        {
            return (TabControlHeaderStyle)obj.GetValue(TabControlHeaderStyleProperty);
        }

        public static void SetTabControlHeaderStyle(DependencyObject obj, TabControlHeaderStyle value)
        {
            obj.SetValue(TabControlHeaderStyleProperty, value);
        }

        public static readonly DependencyProperty TabControlHeaderStyleProperty =
            DependencyProperty.RegisterAttached("TabControlHeaderStyle", typeof(TabControlHeaderStyle), typeof(TabControlHelper));
        #endregion

        #region HeaderPanelBackground
        public static Brush GetHeaderPanelBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HeaderPanelBackgroundProperty);
        }

        public static void SetHeaderPanelBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(HeaderPanelBackgroundProperty, value);
        }

        public static readonly DependencyProperty HeaderPanelBackgroundProperty =
            DependencyProperty.RegisterAttached("HeaderPanelBackground", typeof(Brush), typeof(TabControlHelper));
        #endregion

        #region ItemSelectedForeground
        public static Brush GetItemSelectedForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ItemSelectedForegroundProperty);
        }

        public static void SetItemSelectedForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(ItemSelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedForegroundProperty =
            DependencyProperty.RegisterAttached("ItemSelectedForeground", typeof(Brush), typeof(TabControlHelper));
        #endregion

        #region ItemSelectedBackground
        public static Brush GetItemSelectedBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ItemSelectedBackgroundProperty);
        }

        public static void SetItemSelectedBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(ItemSelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemSelectedBackground", typeof(Brush), typeof(TabControlHelper));
        #endregion

        #region ItemSelectedRibbonBrush
        public static Brush GetItemSelectedRibbonBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ItemSelectedRibbonBrushProperty);
        }

        public static void SetItemSelectedRibbonBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(ItemSelectedRibbonBrushProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedRibbonBrushProperty =
            DependencyProperty.RegisterAttached("ItemSelectedRibbonBrush", typeof(Brush), typeof(TabControlHelper));
        #endregion

        #region ItemHeight
        public static double GetItemHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(ItemHeightProperty);
        }

        public static void SetItemHeight(DependencyObject obj, double value)
        {
            obj.SetValue(ItemHeightProperty, value);
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.RegisterAttached("ItemHeight", typeof(double), typeof(TabControlHelper), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region ItemWidth
        public static double GetItemWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(ItemWidthProperty);
        }

        public static void SetItemWidth(DependencyObject obj, double value)
        {
            obj.SetValue(ItemWidthProperty, value);
        }

        public static readonly DependencyProperty ItemWidthProperty =
            DependencyProperty.RegisterAttached("ItemWidth", typeof(double), typeof(TabControlHelper), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.Inherits));

        #endregion

        #region ItemRemovable
        public static bool GetItemRemovable(DependencyObject obj)
        {
            return (bool)obj.GetValue(ItemRemovableProperty);
        }

        public static void SetItemRemovable(DependencyObject obj, bool value)
        {
            obj.SetValue(ItemRemovableProperty, value);
        }

        public static readonly DependencyProperty ItemRemovableProperty =
            DependencyProperty.RegisterAttached("ItemRemovable", typeof(bool), typeof(TabControlHelper), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));


        #endregion

        #region ItemIcon
        public static object GetItemIcon(DependencyObject obj)
        {
            return (object)obj.GetValue(ItemIconProperty);
        }

        public static void SetItemIcon(DependencyObject obj, object value)
        {
            obj.SetValue(ItemIconProperty, value);
        }

        public static readonly DependencyProperty ItemIconProperty =
            DependencyProperty.RegisterAttached("ItemIcon", typeof(object), typeof(TabControlHelper));
        #endregion

        #region FrontControl
        public static object GetFrontControl(DependencyObject obj)
        {
            return (object)obj.GetValue(FrontControlProperty);
        }

        public static void SetFrontControl(DependencyObject obj, object value)
        {
            obj.SetValue(FrontControlProperty, value);
        }

        public static readonly DependencyProperty FrontControlProperty =
            DependencyProperty.RegisterAttached("FrontControl", typeof(object), typeof(TabControlHelper));
        #endregion

        #region EndControl
        public static object GetEndControl(DependencyObject obj)
        {
            return (object)obj.GetValue(EndControlProperty);
        }

        public static void SetEndControl(DependencyObject obj, object value)
        {
            obj.SetValue(EndControlProperty, value);
        }

        public static readonly DependencyProperty EndControlProperty =
            DependencyProperty.RegisterAttached("EndControl", typeof(object), typeof(TabControlHelper));
        #endregion

    }
}
