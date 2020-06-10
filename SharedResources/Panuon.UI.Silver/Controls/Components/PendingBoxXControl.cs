using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Panuon.UI.Silver.Components
{
    public class PendingBoxXControl : Control
    {
        #region Fields
        private Button _cancelButton;

        private object _cancelButtonContent;

        private bool _canCancel;
        #endregion

        #region Ctor
        static PendingBoxXControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PendingBoxXControl), new FrameworkPropertyMetadata(typeof(PendingBoxXControl)));
        }

        public PendingBoxXControl(string message,  string caption, bool canCancel, object cancelButtonContent)
        {
            Message = message;
            Caption = caption;
            _cancelButtonContent = cancelButtonContent;
            _canCancel = canCancel;
        }
        #endregion

        #region Overrides

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(() =>
            {
                _cancelButton = Template.FindName("PART_CancelButton", this) as Button;
                UpdateState();
            }));
        }
        #endregion

        #region Properties

        #region Caption
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(PendingBoxXControl));
        #endregion

        #region Message
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(PendingBoxXControl));
        #endregion

        #region LoadingStyle
        public Style LoadingStyle
        {
            get { return (Style)GetValue(LoadingStyleProperty); }
            set { SetValue(LoadingStyleProperty, value); }
        }

        public static readonly DependencyProperty LoadingStyleProperty =
            DependencyProperty.Register("LoadingStyle", typeof(Style), typeof(PendingBoxXControl));
        #endregion

        #region ShadowColor
        public Color? ShadowColor
        {
            get { return (Color?)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color?), typeof(PendingBoxXControl));
        #endregion

        #region CornerRadius
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(PendingBoxXControl));
        #endregion

        #region CancelButtonStyle
        public Style CancelButtonStyle
        {
            get { return (Style)GetValue(CancelButtonStyleProperty); }
            set { SetValue(CancelButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty CancelButtonStyleProperty =
            DependencyProperty.Register("CancelButtonStyle", typeof(Style), typeof(PendingBoxXControl));
        #endregion

        #endregion

        #region Event
        public event EventHandler Cancel;
        #endregion

        #region Internal Properties

   
        #region IsLoading
        internal bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        internal static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(PendingBoxXControl));
        #endregion

        #endregion

        #region Event Handlers

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Cancel?.Invoke(this, null);
        }
        #endregion

        #region Function
        private void UpdateState()
        {
            if (_cancelButton != null)
            {
                _cancelButton.Content = _cancelButtonContent;
                _cancelButton.Visibility = _canCancel ? Visibility.Visible : Visibility.Collapsed;
                _cancelButton.IsCancel = true;
                _cancelButton.Click -= CancelButton_Click;
                _cancelButton.Click += CancelButton_Click;
            }
        }

      
        #endregion
    }
}
