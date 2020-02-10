using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class TabControlHelper
    {
        #region Properties

        #region TabControlStyle
        public static TabControlStyle GetTabControlStyle(TabControl tabControl)
        {
            return (TabControlStyle)tabControl.GetValue(TabControlStyleProperty);
        }

        public static void SetTabControlStyle(TabControl tabControl, TabControlStyle value)
        {
            tabControl.SetValue(TabControlStyleProperty, value);
        }

        public static readonly DependencyProperty TabControlStyleProperty =
            DependencyProperty.RegisterAttached("TabControlStyle", typeof(TabControlStyle), typeof(TabControlHelper), new FrameworkPropertyMetadata(TabControlStyle.Standard, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region TabControlHeaderStyle
        public static TabControlHeaderStyle GetTabControlHeaderStyle(TabControl tabControl)
        {
            return (TabControlHeaderStyle)tabControl.GetValue(TabControlHeaderStyleProperty);
        }

        public static void SetTabControlHeaderStyle(TabControl tabControl, TabControlHeaderStyle value)
        {
            tabControl.SetValue(TabControlHeaderStyleProperty, value);
        }

        public static readonly DependencyProperty TabControlHeaderStyleProperty =
            DependencyProperty.RegisterAttached("TabControlHeaderStyle", typeof(TabControlHeaderStyle), typeof(TabControlHelper));
        #endregion

        #region HeaderPanelBackground
        public static Brush GetHeaderPanelBackground(TabControl tabControl)
        {
            return (Brush)tabControl.GetValue(HeaderPanelBackgroundProperty);
        }

        public static void SetHeaderPanelBackground(TabControl tabControl, Brush value)
        {
            tabControl.SetValue(HeaderPanelBackgroundProperty, value);
        }

        public static readonly DependencyProperty HeaderPanelBackgroundProperty =
            DependencyProperty.RegisterAttached("HeaderPanelBackground", typeof(Brush), typeof(TabControlHelper));
        #endregion

        #region ItemForeground
        public static Brush GetItemsForeground(TabControl tabControl)
        {
            return (Brush)tabControl.GetValue(ItemsForegroundProperty);
        }

        public static void SetItemsForeground(TabControl tabControl, Brush value)
        {
            tabControl.SetValue(ItemsForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemsForegroundProperty =
            DependencyProperty.RegisterAttached("ItemsForeground", typeof(Brush), typeof(TabControlHelper));


        public static Brush GetItemForeground(TabItem tabItem)
        {
            return (Brush)tabItem.GetValue(ItemForegroundProperty);
        }

        public static void SetItemForeground(TabItem tabItem, Brush value)
        {
            tabItem.SetValue(ItemForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemForegroundProperty =
            DependencyProperty.RegisterAttached("ItemForeground", typeof(Brush), typeof(TabControlHelper));
        #endregion

        #region ItemSelectedForeground
        public static Brush GetItemsSelectedForeground(TabControl tabControl)
        {
            return (Brush)tabControl.GetValue(ItemsSelectedForegroundProperty);
        }

        public static void SetItemsSelectedForeground(TabControl tabControl, Brush value)
        {
            tabControl.SetValue(ItemsSelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedForegroundProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedForeground", typeof(Brush), typeof(TabControlHelper));

        public static Brush GetItemSelectedForeground(TabItem tabControl)
        {
            return (Brush)tabControl.GetValue(ItemSelectedForegroundProperty);
        }

        public static void SetItemSelectedForeground(TabItem tabItem, Brush value)
        {
            tabItem.SetValue(ItemSelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedForegroundProperty =
            DependencyProperty.RegisterAttached("ItemSelectedForeground", typeof(Brush), typeof(TabControlHelper));
        #endregion

        #region ItemSelectedBackground
        public static Brush GetItemsSelectedBackground(TabControl tabControl)
        {
            return (Brush)tabControl.GetValue(ItemsSelectedBackgroundProperty);
        }

        public static void SetItemsSelectedBackground(TabControl tabControl, Brush value)
        {
            tabControl.SetValue(ItemsSelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedBackground", typeof(Brush), typeof(TabControlHelper));

        public static Brush GetItemSelectedBackground(TabItem tabItem)
        {
            return (Brush)tabItem.GetValue(ItemSelectedBackgroundProperty);
        }

        public static void SetItemSelectedBackground(TabItem tabItem, Brush value)
        {
            tabItem.SetValue(ItemSelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemSelectedBackground", typeof(Brush), typeof(TabControlHelper));
        #endregion

        #region ItemSelectedRibbonBrush
        public static Brush GetItemsSelectedRibbonBrush(TabControl tabControl)
        {
            return (Brush)tabControl.GetValue(ItemsSelectedRibbonBrushProperty);
        }

        public static void SetItemsSelectedRibbonBrush(TabControl tabControl, Brush value)
        {
            tabControl.SetValue(ItemsSelectedRibbonBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedRibbonBrushProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedRibbonBrush", typeof(Brush), typeof(TabControlHelper));


        public static Brush GetItemSelectedRibbonBrush(TabItem tabItem)
        {
            return (Brush)tabItem.GetValue(ItemSelectedRibbonBrushProperty);
        }

        public static void SetItemSelectedRibbonBrush(TabItem tabItem, Brush value)
        {
            tabItem.SetValue(ItemSelectedRibbonBrushProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedRibbonBrushProperty =
            DependencyProperty.RegisterAttached("ItemSelectedRibbonBrush", typeof(Brush), typeof(TabControlHelper));
        #endregion

        #region ItemHeight
        public static double GetItemsHeight(TabControl tabControl)
        {
            return (double)tabControl.GetValue(ItemsHeightProperty);
        }

        public static void SetItemsHeight(TabControl tabControl, double value)
        {
            tabControl.SetValue(ItemsHeightProperty, value);
        }

        public static readonly DependencyProperty ItemsHeightProperty =
            DependencyProperty.RegisterAttached("ItemsHeight", typeof(double), typeof(TabControlHelper), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.Inherits));
 #endregion

        #region ItemWidth
        public static double GetItemsWidth(TabControl tabControl)
        {
            return (double)tabControl.GetValue(ItemsWidthProperty);
        }

        public static void SetItemsWidth(TabControl tabControl, double value)
        {
            tabControl.SetValue(ItemsWidthProperty, value);
        }

        public static readonly DependencyProperty ItemsWidthProperty =
            DependencyProperty.RegisterAttached("ItemsWidth", typeof(double), typeof(TabControlHelper), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region ItemRemovable
        public static bool GetItemsRemovable(TabControl tabControl)
        {
            return (bool)tabControl.GetValue(ItemsRemovableProperty);
        }

        public static void SetItemsRemovable(TabControl tabControl, bool value)
        {
            tabControl.SetValue(ItemsRemovableProperty, value);
        }

        public static readonly DependencyProperty ItemsRemovableProperty =
            DependencyProperty.RegisterAttached("ItemsRemovable", typeof(bool), typeof(TabControlHelper), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

        public static bool GetItemRemovable(TabItem tabItem)
        {
            return (bool)tabItem.GetValue(ItemRemovableProperty);
        }

        public static void SetItemRemovable(TabItem tabItem, bool value)
        {
            tabItem.SetValue(ItemRemovableProperty, value);
        }

        public static readonly DependencyProperty ItemRemovableProperty =
            DependencyProperty.RegisterAttached("ItemRemovable", typeof(bool), typeof(TabControlHelper), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));


        #endregion

        #region ItemIcon
        public static object GetItemsIcon(TabControl tabControl)
        {
            return (object)tabControl.GetValue(ItemsIconProperty);
        }

        public static void SetItemsIcon(TabControl tabControl, object value)
        {
            tabControl.SetValue(ItemsIconProperty, value);
        }

        public static readonly DependencyProperty ItemsIconProperty =
            DependencyProperty.RegisterAttached("ItemsIcon", typeof(object), typeof(TabControlHelper));

        public static object GetItemIcon(TabItem tabItem)
        {
            return (object)tabItem.GetValue(ItemIconProperty);
        }

        public static void SetItemIcon(TabItem tabItem, object value)
        {
            tabItem.SetValue(ItemIconProperty, value);
        }

        public static readonly DependencyProperty ItemIconProperty =
            DependencyProperty.RegisterAttached("ItemIcon", typeof(object), typeof(TabControlHelper));
        #endregion

        #region FrontControl
        public static object GetFrontControl(TabControl tabControl)
        {
            return (object)tabControl.GetValue(FrontControlProperty);
        }

        public static void SetFrontControl(TabControl tabControl, object value)
        {
            tabControl.SetValue(FrontControlProperty, value);
        }

        public static readonly DependencyProperty FrontControlProperty =
            DependencyProperty.RegisterAttached("FrontControl", typeof(object), typeof(TabControlHelper));
        #endregion

        #region EndControl
        public static object GetEndControl(TabControl tabControl)
        {
            return (object)tabControl.GetValue(EndControlProperty);
        }

        public static void SetEndControl(TabControl tabControl, object value)
        {
            tabControl.SetValue(EndControlProperty, value);
        }

        public static readonly DependencyProperty EndControlProperty =
            DependencyProperty.RegisterAttached("EndControl", typeof(object), typeof(TabControlHelper));
        #endregion

        #endregion
    }
}
