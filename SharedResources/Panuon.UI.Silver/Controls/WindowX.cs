using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Utils;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class WindowX : Window
    {
        #region Fields
        private WindowState _lastWindowState;
        #endregion

        #region Ctor
        static WindowX()
        {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowX), new FrameworkPropertyMetadata(typeof(WindowX)));
        }
        #endregion

        #region Overrides
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!CanClose)
            {
                e.Cancel = true;
            }
            base.OnClosing(e);
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            InvalidateVisual();
        }
        #endregion

        #region Properties

        #region IsEscEnabled
        public bool IsEscEnabled
        {
            get { return (bool)GetValue(IsEscEnabledProperty); }
            set { SetValue(IsEscEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsEscEnabledProperty =
            DependencyProperty.Register("IsEscEnabled", typeof(bool), typeof(WindowX));
        #endregion

        #region CanClose
      public bool CanClose
        {
            get { return (bool)GetValue(CanCloseProperty); }
            set { SetValue(CanCloseProperty, value); }
        }

        public static readonly DependencyProperty CanCloseProperty =
            DependencyProperty.Register("CanClose", typeof(bool), typeof(WindowX), new PropertyMetadata(true));
        #endregion

        #region IsMaskVisible
        public bool IsMaskVisible
        {
            get { return (bool)GetValue(IsMaskVisibleProperty); }
            set { SetValue(IsMaskVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsMaskVisibleProperty =
            DependencyProperty.Register("IsMaskVisible", typeof(bool), typeof(WindowX));
        #endregion

        #region MaskBrush
        public Brush MaskBrush
        {
            get { return (Brush)GetValue(MaskBrushProperty); }
            set { SetValue(MaskBrushProperty, value); }
        }

        public static readonly DependencyProperty MaskBrushProperty =
            DependencyProperty.Register("MaskBrush", typeof(Brush), typeof(WindowX));
        #endregion

        #region Backstage
        public object Backstage
        {
            get { return (object)GetValue(BackstageProperty); }
            set { SetValue(BackstageProperty, value); }
        }

        public static readonly DependencyProperty BackstageProperty =
            DependencyProperty.Register("Backstage", typeof(object), typeof(WindowX));
        #endregion

        #region IsBackstageVisible
        public bool IsBackstageVisible
        {
            get { return (bool)GetValue(IsBackstageVisibleProperty); }
            set { SetValue(IsBackstageVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsBackstageVisibleProperty =
            DependencyProperty.Register("IsBackstageVisible", typeof(bool), typeof(WindowX));
        #endregion

        #region IsDragMoveArea
        public static bool? GetIsDragMoveArea(DependencyObject obj)
        {
            return (bool?)obj.GetValue(IsDragMoveAreaProperty);
        }

        public static void SetIsDragMoveArea(DependencyObject obj, bool? value)
        {
            obj.SetValue(IsDragMoveAreaProperty, value);
        }

        public static readonly DependencyProperty IsDragMoveAreaProperty =
            DependencyProperty.RegisterAttached("IsDragMoveArea", typeof(bool?), typeof(WindowX), new PropertyMetadata(OnIsDragMoveAreaChanged));
        #endregion

        #endregion

        #region Methods

        #region Close
        public new void Close()
        {
            CanClose = true;
            base.Close();
        }
        #endregion

        #region Minimize
        public void Minimize()
        {
            _lastWindowState = WindowState;
            WindowState = WindowState.Minimized;
        }
        #endregion

        #region Maximize
        public void Maximize()
        {
            _lastWindowState = WindowState;
            WindowState = WindowState.Maximized;
        }
        #endregion

        #region Normalmize
        public void Normalmize()
        {
            _lastWindowState = WindowState;
            WindowState = WindowState.Normal;
        }
        #endregion

        #region MaximizeOrRestore
        public void MaximizeOrRestore()
        {
            _lastWindowState = WindowState;
            if (WindowState == WindowState.Maximized)
            {
                WindowState = _lastWindowState;
            }
            else
            {
                Maximize();
            }
        }
        #endregion

        #region MinimizeOrRestore
        public void MinimizeOrRestore()
        {
            _lastWindowState = WindowState;
            if (WindowState == WindowState.Minimized)
            {
                WindowState = _lastWindowState;
            }
            else
            {
                Minimize();
            }
        }
        #endregion

        #endregion

        #region Commands
        public static readonly DependencyProperty MinimizeCommandProperty =
            DependencyProperty.Register("MinimizeCommand", typeof(ICommand), typeof(WindowX), new PropertyMetadata(new RelayCommand(OnMinimizeCommandExecute)));

        public static readonly DependencyProperty MaximizeCommandProperty =
            DependencyProperty.Register("MaximizeCommand", typeof(ICommand), typeof(WindowX), new PropertyMetadata(new RelayCommand(OnMaximizeCommandExecute)));

        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(WindowX), new PropertyMetadata(new RelayCommand(OnCloseCommandExecute)));
        #endregion

        #region Event Handlers
        private static void OnIsDragMoveAreaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as UIElement;
            WindowChromeUtils.SetIsHitTestVisibleInChrome(element, true);
            if ((bool)e.NewValue)
            {
                WindowChromeUtils.SetIsHitTestVisibleInChrome(element, false);
            }
        }

        private static void OnMinimizeCommandExecute(object obj)
        {
            var windowX = (obj as WindowX);
            windowX.Minimize();
        }

        private static void OnMaximizeCommandExecute(object obj)
        {
            var window = (obj as WindowX);
            if (window.WindowState == WindowState.Maximized)
            {
                window.WindowState = WindowState.Normal;
            }
            else
            {
                window.WindowState = WindowState.Maximized;
            }
        }


        private static void OnCloseCommandExecute(object obj)
        {
            var windowX = (obj as WindowX);
            windowX.Close();
        }

        #endregion

    }
}
