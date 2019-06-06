using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
}
