using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Panuon.UI.Silver.Components
{
    public class MessageBoxX : WindowX
    {
        #region Fields
        private Button _yesButton;

        private Button _noButton;

        private Button _okButton;

        private Button _cancelButton;

        private object _yesButtonContent;

        private object _noButtonContent;

        private object _okButtonContent;

        private object _cancelButtonContent;

        private MessageBoxButton _messageBoxButton;

        private DefaultButton _defaultButton;

        private bool _isEscEnabled;

        private bool _isResultSet;
        #endregion

        #region Ctor
        internal MessageBoxX(string message, string caption, MessageBoxButton button, MessageBoxIcon icon, DefaultButton defaultButton, MessageBoxButtonArrangement buttonArrangement, bool isEscEnabled, Window owner, object yesButton, object noButton, object cancelButton, object okButton)
        {
            Message = message;
            if (!string.IsNullOrEmpty(caption))
            {
                Title = caption;
            }

            _yesButtonContent = yesButton;
            _noButtonContent = noButton;
            _okButtonContent = okButton;
            _cancelButtonContent = cancelButton;

            _messageBoxButton = button;
            _defaultButton = defaultButton;
            _isEscEnabled = isEscEnabled;

            MessageBoxIcon = icon;
            ButtonArrangement = buttonArrangement;

            if (owner != null)
            {
                Owner = owner;
                WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            else
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
        }
        #endregion

        #region Override
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(() =>
            {
                var presenter = VisualUtils.GetVisualChild<ContentPresenter>(this);
                _yesButton = ContentTemplate?.FindName("PART_YesButton", presenter) as Button;
                _noButton = ContentTemplate?.FindName("PART_NoButton", presenter) as Button;
                _okButton = ContentTemplate?.FindName("PART_OKButton", presenter) as Button;
                _cancelButton = ContentTemplate?.FindName("PART_CancelButton", presenter) as Button;
                UpdateState();
            }));
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!_isResultSet)
            {
                if(_messageBoxButton == MessageBoxButton.OK)
                {
                    MessageBoxResult = MessageBoxResult.OK;
                }
                else
                {
                    MessageBoxResult = MessageBoxResult.Cancel;
                }
            }
            base.OnClosing(e);
        }
        #endregion

        #region Properties

        #region MaxContentWidth
        public double MaxContentWidth
        {
            get { return (double)GetValue(MaxContentWidthProperty); }
            set { SetValue(MaxContentWidthProperty, value); }
        }

        public static readonly DependencyProperty MaxContentWidthProperty =
            DependencyProperty.Register("MaxContentWidth", typeof(double), typeof(MessageBoxX));
        #endregion

        #region MaxContentHeight
        public double MaxContentHeight
        {
            get { return (double)GetValue(MaxContentHeightProperty); }
            set { SetValue(MaxContentHeightProperty, value); }
        }

        public static readonly DependencyProperty MaxContentHeightProperty =
            DependencyProperty.Register("MaxContentHeight", typeof(double), typeof(MessageBoxX));
        #endregion

        #region Message
        public object Message
        {
            get { return (object)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(object), typeof(MessageBoxX));
        #endregion

        #region MessageBoxIcon
        public MessageBoxIcon MessageBoxIcon
        {
            get { return (MessageBoxIcon)GetValue(MessageBoxIconProperty); }
            set { SetValue(MessageBoxIconProperty, value); }
        }

        public static readonly DependencyProperty MessageBoxIconProperty =
            DependencyProperty.Register("MessageBoxIcon", typeof(MessageBoxIcon), typeof(MessageBoxX));

        #endregion

        #region MessageBoxResult
        public MessageBoxResult MessageBoxResult
        {
            get { return (MessageBoxResult)GetValue(MessageBoxResultProperty); }
            set { SetValue(MessageBoxResultProperty, value); }
        }

        public static readonly DependencyProperty MessageBoxResultProperty =
            DependencyProperty.Register("MessageBoxResult", typeof(MessageBoxResult), typeof(MessageBoxX));
        #endregion

        #region ButtonStyle
        public Style ButtonStyle
        {
            get { return (Style)GetValue(ButtonStyleProperty); }
            set { SetValue(ButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(MessageBoxX));
        #endregion

        #region ButtonArrangement

        public MessageBoxButtonArrangement ButtonArrangement
        {
            get { return (MessageBoxButtonArrangement)GetValue(ButtonArrangementProperty); }
            set { SetValue(ButtonArrangementProperty, value); }
        }

        public static readonly DependencyProperty ButtonArrangementProperty =
            DependencyProperty.Register("ButtonArrangement", typeof(MessageBoxButtonArrangement), typeof(MessageBoxX), new PropertyMetadata(MessageBoxButtonArrangement.Standard));

        #endregion

        #endregion

        #region Function

        private void UpdateState()
        {
            WindowXCaption.SetDisableCloseButton(this, _messageBoxButton == MessageBoxButton.YesNo);
            if (_yesButton != null)
            {
                _yesButton.Content = _yesButtonContent;
                _yesButton.Visibility = _messageBoxButton.IsIncluded(MessageBoxButton.YesNo, MessageBoxButton.YesNoCancel) ? Visibility.Visible : Visibility.Collapsed;
                _yesButton.IsDefault = _defaultButton == DefaultButton.YesOK;
                _yesButton.Click -= YesButton_Click;
                _yesButton.Click += YesButton_Click;
            }

            if (_noButton != null)
            {
                _noButton.Content = _noButtonContent;
                _noButton.Visibility = _messageBoxButton.IsIncluded(MessageBoxButton.YesNo, MessageBoxButton.YesNoCancel) ? Visibility.Visible : Visibility.Collapsed;
                _noButton.IsDefault = _messageBoxButton == MessageBoxButton.YesNoCancel ? _defaultButton == DefaultButton.NoCancel : _defaultButton == DefaultButton.CancelNo;
                _noButton.Click -= NoButton_Click;
                _noButton.Click += NoButton_Click;
            }

            if (_cancelButton != null)
            {
                _cancelButton.Content = _cancelButtonContent;
                _cancelButton.Visibility = _messageBoxButton.IsIncluded(MessageBoxButton.OKCancel, MessageBoxButton.YesNoCancel) ? Visibility.Visible : Visibility.Collapsed;
                _cancelButton.IsDefault = _messageBoxButton == MessageBoxButton.YesNoCancel ? _defaultButton == DefaultButton.CancelNo : _defaultButton == DefaultButton.NoCancel;
                _cancelButton.IsCancel = _isEscEnabled ? _messageBoxButton.IsIncluded(MessageBoxButton.OKCancel, MessageBoxButton.YesNoCancel) : false;
                _cancelButton.Click -= CancelButton_Click;
                _cancelButton.Click += CancelButton_Click;

            }

            if (_okButton != null)
            {
                _okButton.Content = _okButtonContent;
                _okButton.Visibility = _messageBoxButton.IsIncluded(MessageBoxButton.OK, MessageBoxButton.OKCancel) ? Visibility.Visible : Visibility.Collapsed;
                _okButton.IsDefault = _defaultButton == DefaultButton.YesOK;
                _okButton.IsCancel = _isEscEnabled ? _messageBoxButton == MessageBoxButton.OK : false;
                _okButton.Click -= OKButton_Click;
                _okButton.Click += OKButton_Click;

            }

        }
        #endregion

        #region Event Handlers
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = MessageBoxResult.Yes;
            _isResultSet = true;
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = MessageBoxResult.No;
            _isResultSet = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = MessageBoxResult.Cancel;
            _isResultSet = true;
            Close();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = MessageBoxResult.OK;
            _isResultSet = true;
            Close();
        }
        #endregion
    }
}
