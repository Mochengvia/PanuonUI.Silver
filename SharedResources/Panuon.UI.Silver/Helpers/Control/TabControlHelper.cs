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

        #region (Internal) TabControlHook
        internal static bool GetTabControlHook(DependencyObject obj)
        {
            return (bool)obj.GetValue(TabControlHookProperty);
        }

        internal static void SetTabControlHook(DependencyObject obj, bool value)
        {
            obj.SetValue(TabControlHookProperty, value);
        }

        internal static readonly DependencyProperty TabControlHookProperty =
            DependencyProperty.RegisterAttached("TabControlHook", typeof(bool), typeof(TabControlHelper), new PropertyMetadata(OnTabControlHookChanged));

        private static void OnTabControlHookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var tabControl = d as TabControl;
            tabControl.AddHandler(Button.ClickEvent, new EventHandler(OnRemoveButtonClicked));
        }

        private static void OnRemoveButtonClicked(object sender, EventArgs e)
        {
            var BtnRemove = sender as Button;
            if (BtnRemove.Name != "PART_RemoveButton")
                return;
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



        public static ICommand GetRemoveCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(RemoveCommandProperty);
        }

        public static void SetRemoveCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(RemoveCommandProperty, value);
        }

        public static readonly DependencyProperty RemoveCommandProperty =
            DependencyProperty.RegisterAttached("RemoveCommand", typeof(ICommand), typeof(TabControlHelper), new PropertyMetadata(new RemoveCommand()));


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

    internal class RemoveCommand : ICommand
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
                tabItem.IsSelected = false;

                var anima1 = new DoubleAnimation()
                {
                    From = tabItem.ActualWidth,
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
                tabItem.BeginAnimation(TabItem.WidthProperty, anima1);
                tabItem.BeginAnimation(TabItem.OpacityProperty, anima2);
            }
        }
    }
}
