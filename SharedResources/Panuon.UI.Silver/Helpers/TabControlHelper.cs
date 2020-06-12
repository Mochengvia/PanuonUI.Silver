using Panuon.UI.Silver.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class TabControlHelper
    {
        #region Routed Event
        #region ItemRemoving
        public static readonly RoutedEvent ItemRemovingEvent = EventManager.RegisterRoutedEvent("ItemRemoving", RoutingStrategy.Bubble, typeof(RemovingRoutedEventHandler), typeof(TabControlHelper));

        public static void AddItemRemovingHandler(DependencyObject d, RemovingRoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.AddHandler(ItemRemovingEvent, handler);
            }
        }

        public static void RemoveItemRemovingHandler(DependencyObject d, RemovingRoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.RemoveHandler(ItemRemovingEvent, handler);
            }
        }

        internal static bool RaiseItemRemoving(UIElement uie, object item)
        {
            var arg = new RemovingRoutedEventArgs(item, ItemRemovingEvent);
            uie.RaiseEvent(arg);
            return !arg.Cancel;
        }
        #endregion

        #region ItemRemoved
        public static readonly RoutedEvent ItemRemovedEvent = EventManager.RegisterRoutedEvent("ItemRemoved", RoutingStrategy.Bubble, typeof(RemovedRoutedEventHandler), typeof(TabControlHelper));

        public static void AddItemRemovedHandler(DependencyObject d, RemovedRoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.AddHandler(ItemRemovedEvent, handler);
            }
        }

        public static void RemoveItemRemovedHandler(DependencyObject d, RemovedRoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.RemoveHandler(ItemRemovedEvent, handler);
            }
        }

        internal static void RaiseItemRemoved(UIElement uie, object item, bool hasRemovedFromSource)
        {
            var arg = new RemovedRoutedEventArgs(item, hasRemovedFromSource, ItemRemovedEvent);
            uie.RaiseEvent(arg);
        }
        #endregion
        #endregion

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
            DependencyProperty.RegisterAttached("TabControlStyle", typeof(TabControlStyle), typeof(TabControlHelper));
        #endregion

        //#region TabControlHeaderStyle
        //public static TabControlHeaderStyle GetTabControlHeaderStyle(TabControl tabControl)
        //{
        //    return (TabControlHeaderStyle)tabControl.GetValue(TabControlHeaderStyleProperty);
        //}

        //public static void SetTabControlHeaderStyle(TabControl tabControl, TabControlHeaderStyle value)
        //{
        //    tabControl.SetValue(TabControlHeaderStyleProperty, value);
        //}

        //public static readonly DependencyProperty TabControlHeaderStyleProperty =
        //    DependencyProperty.RegisterAttached("TabControlHeaderStyle", typeof(TabControlHeaderStyle), typeof(TabControlHelper));
        //#endregion

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

        #region HeaderPanelRibbonLineVisibility
        public static Visibility GetHeaderPanelRibbonLineVisibility(DependencyObject obj)
        {
            return (Visibility)obj.GetValue(HeaderPanelRibbonLineVisibilityProperty);
        }

        public static void SetHeaderPanelRibbonLineVisibility(DependencyObject obj, Visibility value)
        {
            obj.SetValue(HeaderPanelRibbonLineVisibilityProperty, value);
        }

        public static readonly DependencyProperty HeaderPanelRibbonLineVisibilityProperty =
            DependencyProperty.RegisterAttached("HeaderPanelRibbonLineVisibility", typeof(Visibility), typeof(TabControlHelper));
        #endregion

        #region HeaderPanelAlignment

        public static HeaderPanelAlignment GetHeaderPanelAlignment(TabControl tabControl)
        {
            return (HeaderPanelAlignment)tabControl.GetValue(HeaderPanelAlignmentProperty);
        }

        public static void SetHeaderPanelAlignment(TabControl tabControl, HeaderPanelAlignment value)
        {
            tabControl.SetValue(HeaderPanelAlignmentProperty, value);
        }

        public static readonly DependencyProperty HeaderPanelAlignmentProperty =
            DependencyProperty.RegisterAttached("HeaderPanelAlignment", typeof(HeaderPanelAlignment), typeof(TabControlHelper));
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

        #region ItemBackground
        public static Brush GetItemsBackground(TabControl tabControl)
        {
            return (Brush)tabControl.GetValue(ItemsBackgroundProperty);
        }

        public static void SetItemsBackground(TabControl tabControl, Brush value)
        {
            tabControl.SetValue(ItemsBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemsBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemsBackground", typeof(Brush), typeof(TabControlHelper));
     
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

        #region ItemRibbonThickness
        public static double GetItemRibbonThickness(TabItem tabItem)
        {
            return (double)tabItem.GetValue(ItemRibbonThicknessProperty);
        }

        public static void SetItemRibbonThickness(TabItem tabItem, double value)
        {
            tabItem.SetValue(ItemRibbonThicknessProperty, value);
        }

        public static readonly DependencyProperty ItemRibbonThicknessProperty =
            DependencyProperty.RegisterAttached("ItemRibbonThickness", typeof(double), typeof(TabControlHelper));



        public static double GetItemsRibbonThickness(TabControl tabControl)
        {
            return (double)tabControl.GetValue(ItemsRibbonThicknessProperty);
        }

        public static void SetItemsRibbonThickness(TabControl tabControl, double value)
        {
            tabControl.SetValue(ItemsRibbonThicknessProperty, value);
        }

        public static readonly DependencyProperty ItemsRibbonThicknessProperty =
            DependencyProperty.RegisterAttached("ItemsRibbonThickness", typeof(double), typeof(TabControlHelper));


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

        #region ItemPadding
        public static Thickness GetItemsPadding(TabControl tabControl)
        {
            return (Thickness)tabControl.GetValue(ItemsPaddingProperty);
        }

        public static void SetItemsPadding(TabControl tabControl, Thickness value)
        {
            tabControl.SetValue(ItemsPaddingProperty, value);
        }

        public static readonly DependencyProperty ItemsPaddingProperty =
            DependencyProperty.RegisterAttached("ItemsPadding", typeof(Thickness), typeof(TabControlHelper));
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
            DependencyProperty.RegisterAttached("ItemsRemovable", typeof(bool), typeof(TabControlHelper));

        public static bool GetItemRemovable(TabItem tabItem)
        {
            return (bool)tabItem.GetValue(ItemRemovableProperty);
        }

        public static void SetItemRemovable(TabItem tabItem, bool value)
        {
            tabItem.SetValue(ItemRemovableProperty, value);
        }

        public static readonly DependencyProperty ItemRemovableProperty =
            DependencyProperty.RegisterAttached("ItemRemovable", typeof(bool), typeof(TabControlHelper));


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

        #region RemoveButtonStyle
        public static Style GetRemoveButtonStyle(DependencyObject obj)
        {
            return (Style)obj.GetValue(RemoveButtonStyleProperty);
        }

        public static void SetRemoveButtonStyle(DependencyObject obj, Style value)
        {
            obj.SetValue(RemoveButtonStyleProperty, value);
        }

        public static readonly DependencyProperty RemoveButtonStyleProperty =
            DependencyProperty.RegisterAttached("RemoveButtonStyle", typeof(Style), typeof(TabControlHelper));
        #endregion

        #endregion

        #region Internal Properties

        #region (Internal) RemoveCommand
        internal static readonly DependencyProperty RemoveCommandProperty =
            DependencyProperty.RegisterAttached("RemoveCommand", typeof(ICommand), typeof(TabControlHelper), new PropertyMetadata(new RelayCommand(OnRemoveCommandExecute)));
        #endregion

        #endregion

        #region Event Handlers
        private static void OnRemoveCommandExecute(object obj)
        {
            var parameters = obj as object[];
            var tabItem = parameters[0] as TabItem;
            var tabControl = parameters[1] as TabControl;

            var dataObject = tabControl.ItemContainerGenerator.ItemFromContainer(tabItem);
            var result = TabControlHelper.RaiseItemRemoving(tabControl, dataObject);
            if (!result)
            {
                return;
            }
            else
            {
                bool hasRemovedFromSource = false;
                if (dataObject is TabItem)
                {
                    try
                    {
                        tabControl.Items.Remove(tabItem);
                        hasRemovedFromSource = true;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }
                }
                TabControlHelper.RaiseItemRemoved(tabControl, dataObject, hasRemovedFromSource);
            }
        }
        #endregion
    }
}
