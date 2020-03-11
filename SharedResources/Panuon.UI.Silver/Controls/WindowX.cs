using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public partial class WindowX : Window
    {
        #region Identifier
        private bool _closeHandler = true;
        #endregion

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
        /// <summary>
        /// Show or hide mask cover. The default is false.
        /// </summary>
        public bool IsMaskVisible
        {
            get { return (bool)GetValue(IsMaskVisibleProperty); }
            set { SetValue(IsMaskVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsMaskVisibleProperty =
            DependencyProperty.Register("IsMaskVisible", typeof(bool), typeof(WindowX));

        /// <summary>
        /// Fill of mask cover. The default is #AA3E3E3E.
        /// </summary>
        public Brush MaskBrush
        {
            get { return (Brush)GetValue(MaskBrushProperty); }
            set { SetValue(MaskBrushProperty, value); }
        }

        public static readonly DependencyProperty MaskBrushProperty =
            DependencyProperty.Register("MaskBrush", typeof(Brush), typeof(WindowX));

        #endregion

        #region Function
        /// <summary>
        /// Disable force closing , such as "Alt + F4". The default is false.
        /// </summary>
        public bool DisableForceClosing
        {
            get { return (bool)GetValue(DisableForceClosingProperty); }
            set { SetValue(DisableForceClosingProperty, value); }
        }

        public static readonly DependencyProperty DisableForceClosingProperty =
            DependencyProperty.Register("DisableForceClosing", typeof(bool), typeof(WindowX));
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

        #region Event Handler
        private void WindowX_Loaded(object sender, RoutedEventArgs e)
        {
            var grdTitle = VisualTreeHelper.GetChild(((VisualTreeHelper.GetChild(this, 0) as Border).Child as Grid), 0) as Grid;
            grdTitle.MouseLeftButtonDown += GrdTitle_MouseLeftButtonDown;
        }
        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            InvalidateVisual();
        }
        private void GrdTitle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DisableForceClosing && _closeHandler)
            {
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }

        #endregion

        #region Calling Methods
        public void ForceClose()
        {
            _closeHandler = false;
            Close();
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
            var window = (parameter as WindowX);
            window.ForceClose();
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
            var window = (parameter as WindowX);
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
            (parameter as WindowX).WindowState = WindowState.Minimized;
        }
    }
    #endregion

}
