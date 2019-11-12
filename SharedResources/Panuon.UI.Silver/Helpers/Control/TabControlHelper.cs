using Panuon.UI.Silver.Core;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver
{
    public class TabControlHelper
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
            DependencyProperty.RegisterAttached("TabControlStyle", typeof(TabControlStyle), typeof(TabControlHelper), new PropertyMetadata(TabControlStyle.Standard));
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
            DependencyProperty.RegisterAttached("ItemHeight", typeof(double), typeof(TabControlHelper));
        #endregion

        #region ItemIcon
        public static object GetItemIcon(DependencyObject obj)
        {
            return obj.GetValue(ItemIconProperty);
        }

        public static void SetItemIcon(DependencyObject obj, object value)
        {
            obj.SetValue(ItemIconProperty, value);
        }

        public static readonly DependencyProperty ItemIconProperty =
            DependencyProperty.RegisterAttached("ItemIcon", typeof(object), typeof(TabControlHelper));
        #endregion

        #region ItemPadding
        public static Thickness GetItemPadding(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(ItemPaddingProperty);
        }

        public static void SetItemPadding(DependencyObject obj, Thickness value)
        {
            obj.SetValue(ItemPaddingProperty, value);
        }

        public static readonly DependencyProperty ItemPaddingProperty =
            DependencyProperty.RegisterAttached("ItemPadding", typeof(Thickness), typeof(TabControlHelper));
        #endregion

        #region ItemCornerRadius
        public static CornerRadius GetItemCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(ItemCornerRadiusProperty);
        }

        public static void SetItemCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(ItemCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty ItemCornerRadiusProperty =
            DependencyProperty.RegisterAttached("ItemCornerRadius", typeof(CornerRadius), typeof(TabControlHelper));
        #endregion

        #region ItemsAlignment
        public static ItemsAlignment GetItemsAlignment(DependencyObject obj)
        {
            return (ItemsAlignment)obj.GetValue(ItemsAlignmentProperty);
        }

        public static void SetItemsAlignment(DependencyObject obj, ItemsAlignment value)
        {
            obj.SetValue(ItemsAlignmentProperty, value);
        }

        public static readonly DependencyProperty ItemsAlignmentProperty =
            DependencyProperty.RegisterAttached("ItemsAlignment", typeof(ItemsAlignment), typeof(TabControlHelper));
        #endregion

        #region ItemBackground
        public static Brush GetItemBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ItemBackgroundProperty);
        }

        public static void SetItemBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(ItemBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemBackground", typeof(Brush), typeof(TabControlHelper));
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

        #region SelectedForeground
        public static Brush GetSelectedForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(SelectedForegroundProperty);
        }

        public static void SetSelectedForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(SelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty SelectedForegroundProperty =
            DependencyProperty.RegisterAttached("SelectedForeground", typeof(Brush), typeof(TabControlHelper));
        #endregion

        #region SelectedBackground
        public static Brush GetSelectedBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(SelectedBackgroundProperty);
        }

        public static void SetSelectedBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(SelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty SelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("SelectedBackground", typeof(Brush), typeof(TabControlHelper));
        #endregion

        #region ExtendControl
        public static UIElement GetExtendControl(DependencyObject obj)
        {
            return (UIElement)obj.GetValue(ExtendControlProperty);
        }

        public static void SetExtendControl(DependencyObject obj, UIElement value)
        {
            obj.SetValue(ExtendControlProperty, value);
        }

        public static readonly DependencyProperty ExtendControlProperty =
            DependencyProperty.RegisterAttached("ExtendControl", typeof(UIElement), typeof(TabControlHelper));


        #endregion

        #region CanRemove
        public static bool GetCanRemove(DependencyObject obj)
        {
            return (bool)obj.GetValue(CanRemoveProperty);
        }

        public static void SetCanRemove(DependencyObject obj, bool value)
        {
            obj.SetValue(CanRemoveProperty, value);
        }

        public static readonly DependencyProperty CanRemoveProperty =
            DependencyProperty.RegisterAttached("CanRemove", typeof(bool), typeof(TabControlHelper));
        #endregion

        #region DisableScrollButton
        public static bool GetDisableScrollButton(DependencyObject obj)
        {
            return (bool)obj.GetValue(DisableScrollButtonProperty);
        }

        public static void SetDisableScrollButton(DependencyObject obj, bool value)
        {
            obj.SetValue(DisableScrollButtonProperty, value);
        }

        public static readonly DependencyProperty DisableScrollButtonProperty =
            DependencyProperty.RegisterAttached("DisableScrollButton", typeof(bool), typeof(TabControlHelper));
        #endregion

        #region (Event) Removed
        public static readonly RoutedEvent RemovedEvent = EventManager.RegisterRoutedEvent("Removed", RoutingStrategy.Bubble, typeof(TabItemRemovedEventHandler), typeof(TabControlHelper));
        public static void AddRemovedHandler(DependencyObject d, TabItemRemovedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.AddHandler(RemovedEvent, handler);
            }
        }
        public static void RemoveRemovedHandler(DependencyObject d, TabItemRemovedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.RemoveHandler(RemovedEvent, handler);
            }
        }

        internal static void RaiseRemoved(UIElement uie, TabItem newValue, bool removedFromSource)
        {
            var arg = new TabItemRemovedEventArgs(newValue, removedFromSource, RemovedEvent);
            uie.RaiseEvent(arg);
        }
        #endregion

        #region (Internal Command)
        internal static ICommand GetScrollLeftCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ScrollLeftCommandProperty);
        }

        internal static void SetScrollLeftCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ScrollLeftCommandProperty, value);
        }

        internal static readonly DependencyProperty ScrollLeftCommandProperty =
            DependencyProperty.RegisterAttached("ScrollLeftCommand", typeof(ICommand), typeof(TabControlHelper), new PropertyMetadata(new ScrollLeftCommand()));

        internal static ICommand GetScrollRightCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ScrollRightCommandProperty);
        }

        internal static void SetScrollRightCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ScrollRightCommandProperty, value);
        }

        internal static readonly DependencyProperty ScrollRightCommandProperty =
            DependencyProperty.RegisterAttached("ScrollRightCommand", typeof(ICommand), typeof(TabControlHelper), new PropertyMetadata(new ScrollRightCommand()));

        internal static ICommand GetScrollUpCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ScrollUpCommandProperty);
        }

        internal static void SetScrollUpCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ScrollUpCommandProperty, value);
        }

        internal static readonly DependencyProperty ScrollUpCommandProperty =
            DependencyProperty.RegisterAttached("ScrollUpCommand", typeof(ICommand), typeof(TabControlHelper), new PropertyMetadata(new ScrollUpCommand()));

        internal static ICommand GetScrollDownCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ScrollDownCommandProperty);
        }

        internal static void SetScrollDownCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ScrollDownCommandProperty, value);
        }

        internal static readonly DependencyProperty ScrollDownCommandProperty =
            DependencyProperty.RegisterAttached("ScrollDownCommand", typeof(ICommand), typeof(TabControlHelper), new PropertyMetadata(new ScrollDownCommand()));

        internal static ICommand GetRemoveCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(RemoveCommandProperty);
        }

        internal static void SetRemoveCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(RemoveCommandProperty, value);
        }

        internal static readonly DependencyProperty RemoveCommandProperty =
            DependencyProperty.RegisterAttached("RemoveCommand", typeof(ICommand), typeof(TabControlHelper), new PropertyMetadata(new TabItemRemoveCommand()));


        #endregion

    }

    internal class ScrollLeftCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var scrollViewer = (parameter as ScrollViewer);
            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - 20);
        }
    }

    internal class ScrollRightCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var scrollViewer = (parameter as ScrollViewer);
            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + 20);
        }
    }

    internal class ScrollUpCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var scrollViewer = (parameter as ScrollViewer);
            scrollViewer.LineUp();
        }
    }

    internal class ScrollDownCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var scrollViewer = (parameter as ScrollViewer);
            scrollViewer.LineDown();
        }
    }

    internal class TabItemRemoveCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var values = (object[])parameter;

            var tabItem = values[0] as TabItem;
            var tabControl = values[1] as TabControl;

            if (tabItem != null && tabControl != null)
            {
                var isVertical = tabItem.TabStripPlacement == Dock.Top || tabItem.TabStripPlacement == Dock.Bottom;

                tabItem.IsSelected = false;

                var anima1 = new DoubleAnimation()
                {
                    From = isVertical ? tabItem.ActualWidth : tabItem.ActualHeight,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.3),
                    EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut },
                };
                anima1.Completed += delegate
                {
                    IEditableCollectionView items = tabControl.Items; //Cast to interface
                    if (items.CanRemove)
                    {
                        items.Remove(tabItem);
                    }
                    TabControlHelper.RaiseRemoved(tabControl, tabItem, items.CanRemove);
                };

                var anima2 = new DoubleAnimation()
                {
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.3),
                };
                tabItem.BeginAnimation(isVertical ? TabItem.WidthProperty : TabItem.HeightProperty, anima1);
                tabItem.BeginAnimation(TabItem.OpacityProperty, anima2);
            }
        }
    }
}
