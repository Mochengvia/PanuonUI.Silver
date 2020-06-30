using Panuon.UI.Silver.Core;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public partial class WindowX : Window
    {
        #region Identifer
        private bool _closeHandler = true;
        #endregion

        #region Ctor
        static WindowX()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowX), new FrameworkPropertyMetadata(typeof(WindowX)));
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

        #region DisableForceClosing
        /// <summary>
        /// Gets or sets is force closing disabled.
        /// </summary>
        public bool DisableForceClosing
        {
            get { return (bool)GetValue(DisableForceClosingProperty); }
            set { SetValue(DisableForceClosingProperty, value); }
        }

        public static readonly DependencyProperty DisableForceClosingProperty =
            DependencyProperty.Register("DisableForceClosing", typeof(bool), typeof(WindowX));
        #endregion

        #region IsMaskVisible
        /// <summary>
        /// Gets or sets is mask visible.
        /// </summary>
        public bool IsMaskVisible
        {
            get { return (bool)GetValue(IsMaskVisibleProperty); }
            set { SetValue(IsMaskVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsMaskVisibleProperty =
            DependencyProperty.Register("IsMaskVisible", typeof(bool), typeof(WindowX));
        #endregion

        #region MaskBrush
        /// <summary>
        /// Gets or sets mask brush.
        /// </summary>
        public Brush MaskBrush
        {
            get { return (Brush)GetValue(MaskBrushProperty); }
            set { SetValue(MaskBrushProperty, value); }
        }

        public static readonly DependencyProperty MaskBrushProperty =
            DependencyProperty.Register("MaskBrush", typeof(Brush), typeof(WindowX));
        #endregion

        #region Backstage
        /// <summary>
        /// Gets or sets backstage.
        /// </summary>
        public object Backstage
        {
            get { return (object)GetValue(BackstageProperty); }
            set { SetValue(BackstageProperty, value); }
        }

        public static readonly DependencyProperty BackstageProperty =
            DependencyProperty.Register("Backstage", typeof(object), typeof(WindowX));
        #endregion

        #region IsBackstageVisible
        /// <summary>
        /// Gets or sets is backstage visible.
        /// </summary>
        public bool IsBackstageVisible
        {
            get { return (bool)GetValue(IsBackstageVisibleProperty); }
            set { SetValue(IsBackstageVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsBackstageVisibleProperty =
            DependencyProperty.Register("IsBackstageVisible", typeof(bool), typeof(WindowX));
        #endregion

        #endregion

        #region Attached Property
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

        #region Commands
        public static readonly DependencyProperty MinimizeCommandProperty =
            DependencyProperty.Register("MinimizeCommand", typeof(ICommand), typeof(WindowX), new PropertyMetadata(new RelayCommand(OnMinimizeCommandExecute)));

        public static readonly DependencyProperty MaximizeCommandProperty =
            DependencyProperty.Register("MaximizeCommand", typeof(ICommand), typeof(WindowX), new PropertyMetadata(new RelayCommand(OnMaximizeCommandExecute)));

        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(WindowX), new PropertyMetadata(new RelayCommand(OnCloseCommandExecute)));
        #endregion

        #region Event Handler
        private static void OnIsDragMoveAreaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as UIElement;
            SetIsHitTestVisibleInChrome(element, true);
            if ((bool)e.NewValue)
                SetIsHitTestVisibleInChrome(element, false);
        }

        private static void OnMinimizeCommandExecute(object obj)
        {
            var windowX = (obj as WindowX);
            windowX.Minimize();
        }

        private static void OnMaximizeCommandExecute(object obj)
        {
            var window = (obj as WindowX);
            window.MaximizeOrNormalmize();
        }


        private static void OnCloseCommandExecute(object obj)
        {
            var windowX = (obj as WindowX);
            windowX.Close();
        }

        #endregion

        #region Override
        protected override void OnClosing(CancelEventArgs e)
        {
            if (DisableForceClosing && _closeHandler)
            {
                return;
            }
            base.OnClosing(e);
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            InvalidateVisual();
        }
        #endregion

        #region Methods
        public new void Close()
        {
            _closeHandler = false;
            base.Close();
        }

        public void Minimize()
        {
            WindowState = WindowState.Minimized;
        }

        public void Maximize()
        {
            WindowState = WindowState.Maximized;
        }

        public void Normalmize()
        {
            WindowState = WindowState.Normal;
        }

        public void MaximizeOrNormalmize()
        {
            if (WindowState == WindowState.Maximized)
                Normalmize();
            else
                Maximize();
        }
        #endregion
    }
}
