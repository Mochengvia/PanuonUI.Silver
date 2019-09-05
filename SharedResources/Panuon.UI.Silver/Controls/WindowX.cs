using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver
{
    public class WindowX : Window
    {
        #region Constructor
        public WindowX()
        {
            Loaded += WindowX_Loaded;
        }

        static WindowX()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowX), new FrameworkPropertyMetadata(typeof(WindowX)));
        }
        #endregion

        #region Property

        #region Mask
        public bool IsMaskVisible
        {
            get { return (bool)GetValue(IsMaskVisibleProperty); }
            set { SetValue(IsMaskVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsMaskVisibleProperty =
            DependencyProperty.Register("IsMaskVisible", typeof(bool), typeof(WindowX));

        public Brush MaskBrush
        {
            get { return (Brush)GetValue(MaskBrushProperty); }
            set { SetValue(MaskBrushProperty, value); }
        }

        public static readonly DependencyProperty MaskBrushProperty =
            DependencyProperty.Register("MaskBrush", typeof(Brush), typeof(WindowX));

        #endregion

        #endregion

        #region Internal Property
        internal ICommand CloseCommand
        {
            get { return (ICommand)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }

        internal static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(WindowX), new PropertyMetadata(new CloseCommand()));

        internal ICommand MinCommand
        {
            get { return (ICommand)GetValue(MinCommandProperty); }
            set { SetValue(MinCommandProperty, value); }
        }

        internal static readonly DependencyProperty MinCommandProperty =
            DependencyProperty.Register("MinCommand", typeof(ICommand), typeof(WindowX), new PropertyMetadata(new MinCommand()));

        internal ICommand MaxCommand
        {
            get { return (ICommand)GetValue(MaxCommandProperty); }
            set { SetValue(MaxCommandProperty, value); }
        }

        internal static readonly DependencyProperty MaxCommandProperty =
            DependencyProperty.Register("MaxCommand", typeof(ICommand), typeof(WindowX), new PropertyMetadata(new MaxCommand()));

        #endregion

        #region Event
        private void WindowX_Loaded(object sender, RoutedEventArgs e)
        {
            var grdTitle = VisualTreeHelper.GetChild(((VisualTreeHelper.GetChild(this, 0) as Border).Child as Grid), 0) as Grid;
            grdTitle.MouseLeftButtonDown += GrdTitle_MouseLeftButtonDown;
        }

        private void GrdTitle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion
    }

    #region Commands
    internal class CloseCommand : ICommand
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
            var window = (parameter as Window);
            window.Close();
        }
    }
    internal class MaxCommand : ICommand
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
            var window = (parameter as Window);
            if (window.WindowState == WindowState.Maximized)
                window.WindowState = WindowState.Normal;
            else
                window.WindowState = WindowState.Maximized;
        }
    }
    internal class MinCommand : ICommand
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
            (parameter as Window).WindowState = WindowState.Minimized;
        }
    }

    #endregion

}
