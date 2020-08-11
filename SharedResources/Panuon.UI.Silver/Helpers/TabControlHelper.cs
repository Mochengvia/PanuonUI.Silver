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

        public static void AddItemRemovingHandler(TabControl d, RemovingRoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.AddHandler(ItemRemovingEvent, handler);
            }
        }

        public static void RemoveItemRemovingHandler(TabControl d, RemovingRoutedEventHandler handler)
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

        public static void AddItemRemovedHandler(TabControl d, RemovedRoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.AddHandler(ItemRemovedEvent, handler);
            }
        }

        public static void RemoveItemRemovedHandler(TabControl d, RemovedRoutedEventHandler handler)
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

        #region CanHeaderScroll
        public static bool GetCanHeaderScroll(TabControl tabControl)
        {
            return (bool)tabControl.GetValue(CanHeaderScrollProperty);
        }

        public static void SetCanHeaderScroll(TabControl tabControl, bool value)
        {
            tabControl.SetValue(CanHeaderScrollProperty, value);
        }

        public static readonly DependencyProperty CanHeaderScrollProperty =
            DependencyProperty.RegisterAttached("CanHeaderScroll", typeof(bool), typeof(TabControlHelper));
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

        #region HeaderPanelRibbonLineVisibility
        public static Visibility GetHeaderPanelRibbonLineVisibility(TabControl tabControl)
        {
            return (Visibility)tabControl.GetValue(HeaderPanelRibbonLineVisibilityProperty);
        }

        public static void SetHeaderPanelRibbonLineVisibility(TabControl tabControl, Visibility value)
        {
            tabControl.SetValue(HeaderPanelRibbonLineVisibilityProperty, value);
        }

        public static readonly DependencyProperty HeaderPanelRibbonLineVisibilityProperty =
            DependencyProperty.RegisterAttached("HeaderPanelRibbonLineVisibility", typeof(Visibility), typeof(TabControlHelper));
        #endregion

        #region HeaderPanelRibbonLineBrush
        public static Brush GetHeaderPanelRibbonLineBrush(TabControl tabControl)
        {
            return (Brush)tabControl.GetValue(HeaderPanelRibbonLineBrushProperty);
        }

        public static void SetHeaderPanelRibbonLineBrush(TabControl tabControl, Brush value)
        {
            tabControl.SetValue(HeaderPanelRibbonLineBrushProperty, value);
        }

        public static readonly DependencyProperty HeaderPanelRibbonLineBrushProperty =
            DependencyProperty.RegisterAttached("HeaderPanelRibbonLineBrush", typeof(Brush), typeof(TabControlHelper));
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

        #region ItemBorderBrush
        public static Brush GetItemsBorderBrush(TabControl tabControl)
        {
            return (Brush)tabControl.GetValue(ItemsBorderBrushProperty);
        }

        public static void SetItemsBorderBrush(TabControl tabControl, Brush value)
        {
            tabControl.SetValue(ItemsBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemsBorderBrush", typeof(Brush), typeof(TabControlHelper));

        #endregion

        #region ItemBorderThickness
        public static Thickness? GetItemsBorderThickness(TabControl tabControl)
        {
            return (Thickness?)tabControl.GetValue(ItemsBorderThicknessProperty);
        }

        public static void SetItemsBorderThickness(TabControl tabControl, Thickness? value)
        {
            tabControl.SetValue(ItemsBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty ItemsBorderThicknessProperty =
            DependencyProperty.RegisterAttached("ItemsBorderThickness", typeof(Thickness?), typeof(TabControlHelper));

        #endregion

        #region ItemCornerRadius
        public static CornerRadius GetItemsCornerRadius(TabControl tabControl)
        {
            return (CornerRadius)tabControl.GetValue(ItemsCornerRadiusProperty);
        }

        public static void SetItemsCornerRadius(TabControl tabControl, CornerRadius value)
        {
            tabControl.SetValue(ItemsCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty ItemsCornerRadiusProperty =
            DependencyProperty.RegisterAttached("ItemsCornerRadius", typeof(CornerRadius), typeof(TabControlHelper));

        public static CornerRadius GetItemCornerRadius(TabItem tabControl)
        {
            return (CornerRadius)tabControl.GetValue(ItemCornerRadiusProperty);
        }

        public static void SetItemCornerRadius(TabItem tabItem, CornerRadius value)
        {
            tabItem.SetValue(ItemCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty ItemCornerRadiusProperty =
            DependencyProperty.RegisterAttached("ItemCornerRadius", typeof(CornerRadius), typeof(TabControlHelper));
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

        #region ItemSelectedBorderBrush
        public static Brush GetItemsSelectedBorderBrush(TabControl tabControl)
        {
            return (Brush)tabControl.GetValue(ItemsSelectedBorderBrushProperty);
        }

        public static void SetItemsSelectedBorderBrush(TabControl tabControl, Brush value)
        {
            tabControl.SetValue(ItemsSelectedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedBorderBrush", typeof(Brush), typeof(TabControlHelper));

        public static Brush GetItemSelectedBorderBrush(TabItem tabItem)
        {
            return (Brush)tabItem.GetValue(ItemSelectedBorderBrushProperty);
        }

        public static void SetItemSelectedBorderBrush(TabItem tabItem, Brush value)
        {
            tabItem.SetValue(ItemSelectedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemSelectedBorderBrush", typeof(Brush), typeof(TabControlHelper));
        #endregion

        #region ItemSelectedBorderThickness
        public static Thickness? GetItemsSelectedBorderThickness(TabControl tabControl)
        {
            return (Thickness?)tabControl.GetValue(ItemsSelectedBorderThicknessProperty);
        }

        public static void SetItemsSelectedBorderThickness(TabControl tabControl, Thickness? value)
        {
            tabControl.SetValue(ItemsSelectedBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedBorderThicknessProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedBorderThickness", typeof(Thickness?), typeof(TabControlHelper));

        public static Thickness? GetItemSelectedBorderThickness(TabItem tabControl)
        {
            return (Thickness?)tabControl.GetValue(ItemSelectedBorderThicknessProperty);
        }

        public static void SetItemSelectedBorderThickness(TabItem tabItem, Thickness? value)
        {
            tabItem.SetValue(ItemSelectedBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedBorderThicknessProperty =
            DependencyProperty.RegisterAttached("ItemSelectedBorderThickness", typeof(Thickness?), typeof(TabControlHelper));
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
            DependencyProperty.RegisterAttached("ItemsHeight", typeof(double), typeof(TabControlHelper));
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
            DependencyProperty.RegisterAttached("ItemsWidth", typeof(double), typeof(TabControlHelper));
        #endregion

        #region ItemsVerticalHeaderAlignment
        public static VerticalAlignment GetItemsVerticalHeaderAlignment(TabControl tabControl)
        {
            return (VerticalAlignment)tabControl.GetValue(ItemsVerticalHeaderAlignmentProperty);
        }

        public static void SetItemsVerticalHeaderAlignment(TabControl tabControl, VerticalAlignment value)
        {
            tabControl.SetValue(ItemsVerticalHeaderAlignmentProperty, value);
        }

        public static readonly DependencyProperty ItemsVerticalHeaderAlignmentProperty =
            DependencyProperty.RegisterAttached("ItemsVerticalHeaderAlignment", typeof(VerticalAlignment), typeof(TabControlHelper));
        #endregion

        #region ItemsHorizontalHeaderAlignment
        public static HorizontalAlignment GetItemsHorizontalHeaderAlignment(TabControl tabControl)
        {
            return (HorizontalAlignment)tabControl.GetValue(ItemsHorizontalHeaderAlignmentProperty);
        }

        public static void SetItemsHorizontalHeaderAlignment(TabControl tabControl, HorizontalAlignment value)
        {
            tabControl.SetValue(ItemsHorizontalHeaderAlignmentProperty, value);
        }

        public static readonly DependencyProperty ItemsHorizontalHeaderAlignmentProperty =
            DependencyProperty.RegisterAttached("ItemsHorizontalHeaderAlignment", typeof(HorizontalAlignment), typeof(TabControlHelper));
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
        public static Style GetRemoveButtonStyle(TabControl tabControl)
        {
            return (Style)tabControl.GetValue(RemoveButtonStyleProperty);
        }

        public static void SetRemoveButtonStyle(TabControl tabControl, Style value)
        {
            tabControl.SetValue(RemoveButtonStyleProperty, value);
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
