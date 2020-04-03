using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Panuon.UI.Silver.Internal.Controls
{
    internal class MsgBox : WindowX
    {
        #region Identifer
        private bool _interactOwnerMask;

        private WindowX _owner;
        #endregion

        #region Ctor
        public MsgBox(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon, DefaultButton defaultButton, MessageBoxXConfigurations messageBoxXConfigurations)
        {
            Owner = owner;
            if(owner == null)
            {
                try
                {
                    Owner = Application.Current.MainWindow;
                }
                catch
                {

                }
            }

            _owner = owner as WindowX;

            MessageBoxText = messageBoxText;
            Title = caption ?? "";
            MessageBoxButton = button;
            MessageBoxIcon = icon;
            DefaultButton = defaultButton;
            MessageBoxStyle = messageBoxXConfigurations.MessageBoxStyle;
            DefaultButtonBrush = messageBoxXConfigurations.DefaultButtonBrush;
            MinHeight = messageBoxXConfigurations.MinHeight;
            MinWidth = messageBoxXConfigurations.MinWidth;
            FontSize = messageBoxXConfigurations.FontSize;
            ContentHeight = messageBoxXConfigurations.ContentHeight;
            ContentWidth = messageBoxXConfigurations.ContentWidth;
            ShowInTaskbar = messageBoxXConfigurations.ShowInTaskbar;
            Topmost = messageBoxXConfigurations.Topmost;
            WindowStartupLocation = messageBoxXConfigurations.WindowStartupLocation;
            YesButton = messageBoxXConfigurations.YesButton;
            NoButton = messageBoxXConfigurations.NoButton;
            OKButton = messageBoxXConfigurations.OKButton;
            CancelButton = messageBoxXConfigurations.CancelButton;
            ReverseButtonSequence = messageBoxXConfigurations.ReverseButtonSequence;
            _interactOwnerMask = messageBoxXConfigurations.InteractOwnerMask;

            if(_interactOwnerMask && _owner != null)
            {
                _owner.IsMaskVisible = true;
            }
        }
        #endregion

        #region Properties

        #region DefaultButtonBrush
        public Brush DefaultButtonBrush
        {
            get { return (Brush)GetValue(DefaultButtonBrushProperty); }
            set { SetValue(DefaultButtonBrushProperty, value); }
        }

        public static readonly DependencyProperty DefaultButtonBrushProperty =
            DependencyProperty.Register("DefaultButtonBrush", typeof(Brush), typeof(MsgBox));
        #endregion

        #region ContentHeight
        public double ContentHeight
        {
            get { return (double)GetValue(ContentHeightProperty); }
            set { SetValue(ContentHeightProperty, value); }
        }

        public static readonly DependencyProperty ContentHeightProperty =
            DependencyProperty.Register("ContentHeight", typeof(double), typeof(MsgBox));
        #endregion

        #region ContentWidth
        public double ContentWidth
        {
            get { return (double)GetValue(ContentWidthProperty); }
            set { SetValue(ContentWidthProperty, value); }
        }

        public static readonly DependencyProperty ContentWidthProperty =
            DependencyProperty.Register("ContentWidth", typeof(double), typeof(MsgBox));
        #endregion

        #region MessageBoxButton
        public MessageBoxButton MessageBoxButton
        {
            get { return (MessageBoxButton)GetValue(MessageBoxButtonProperty); }
            set { SetValue(MessageBoxButtonProperty, value); }
        }

        public static readonly DependencyProperty MessageBoxButtonProperty =
            DependencyProperty.Register("MessageBoxButton", typeof(MessageBoxButton), typeof(MsgBox));
        #endregion

        #region ReverseButtonSequence
        public bool ReverseButtonSequence
        {
            get { return (bool)GetValue(ReverseButtonSequenceProperty); }
            set { SetValue(ReverseButtonSequenceProperty, value); }
        }

        public static readonly DependencyProperty ReverseButtonSequenceProperty =
            DependencyProperty.Register("ReverseButtonSequence", typeof(bool), typeof(MsgBox));
        #endregion

        #region YesButton
        public string YesButton
        {
            get { return (string)GetValue(YesButtonProperty); }
            set { SetValue(YesButtonProperty, value); }
        }

        public static readonly DependencyProperty YesButtonProperty =
            DependencyProperty.Register("YesButton", typeof(string), typeof(MsgBox));
        #endregion

        #region NoButton
        public string NoButton
        {
            get { return (string)GetValue(NoButtonProperty); }
            set { SetValue(NoButtonProperty, value); }
        }

        public static readonly DependencyProperty NoButtonProperty =
            DependencyProperty.Register("NoButton", typeof(string), typeof(MsgBox));
        #endregion

        #region CancelButton
        public string CancelButton
        {
            get { return (string)GetValue(CancelButtonProperty); }
            set { SetValue(CancelButtonProperty, value); }
        }

        public static readonly DependencyProperty CancelButtonProperty =
            DependencyProperty.Register("CancelButton", typeof(string), typeof(MsgBox));
        #endregion

        #region OKButton
        public string OKButton
        {
            get { return (string)GetValue(OKButtonProperty); }
            set { SetValue(OKButtonProperty, value); }
        }

        public static readonly DependencyProperty OKButtonProperty =
            DependencyProperty.Register("OKButton", typeof(string), typeof(MsgBox));
        #endregion

        #region MessageBoxIcon
        public MessageBoxIcon MessageBoxIcon
        {
            get { return (MessageBoxIcon)GetValue(MessageBoxIconProperty); }
            set { SetValue(MessageBoxIconProperty, value); }
        }

        public static readonly DependencyProperty MessageBoxIconProperty =
            DependencyProperty.Register("MessageBoxIcon", typeof(MessageBoxIcon), typeof(MsgBox));
        #endregion

        #region MessageBoxStyle
        public MessageBoxStyle MessageBoxStyle
        {
            get { return (MessageBoxStyle)GetValue(MessageBoxStyleProperty); }
            set { SetValue(MessageBoxStyleProperty, value); }
        }

        public static readonly DependencyProperty MessageBoxStyleProperty =
            DependencyProperty.Register("MessageBoxStyle", typeof(MessageBoxStyle), typeof(MsgBox));
        #endregion

        #region DefaultButton
        public DefaultButton DefaultButton
        {
            get { return (DefaultButton)GetValue(DefaultButtonProperty); }
            set { SetValue(DefaultButtonProperty, value); }
        }

        public static readonly DependencyProperty DefaultButtonProperty =
            DependencyProperty.Register("DefaultButton", typeof(DefaultButton), typeof(MsgBox));
        #endregion

        #region MessageBoxText
        public string MessageBoxText
        {
            get { return (string)GetValue(MessageBoxTextProperty); }
            set { SetValue(MessageBoxTextProperty, value); }
        }

        public static readonly DependencyProperty MessageBoxTextProperty =
            DependencyProperty.Register("MessageBoxText", typeof(string), typeof(MsgBox));
        #endregion

        #region MessageBoxResult
        public MessageBoxResult MessageBoxResult { get; private set; }
        #endregion

        #endregion

        #region Commands
        public ICommand OKCommand
        {
            get { return (ICommand)GetValue(OKCommandProperty); }
            set { SetValue(OKCommandProperty, value); }
        }

        public static readonly DependencyProperty OKCommandProperty =
            DependencyProperty.Register("OKCommand", typeof(ICommand), typeof(MsgBox), new PropertyMetadata(new RelayCommand(OnOKButtonClicked)));

       

        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }

        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(MsgBox), new PropertyMetadata(new RelayCommand(OnCancelButtonClicked)));

      
        public ICommand YesCommand
        {
            get { return (ICommand)GetValue(YesCommandProperty); }
            set { SetValue(YesCommandProperty, value); }
        }

        public static readonly DependencyProperty YesCommandProperty =
            DependencyProperty.Register("YesCommand", typeof(ICommand), typeof(MsgBox), new PropertyMetadata(new RelayCommand(OnYesButtonClicked)));

        
        public ICommand NoCommand
        {
            get { return (ICommand)GetValue(NoCommandProperty); }
            set { SetValue(NoCommandProperty, value); }
        }

        public static readonly DependencyProperty NoCommandProperty =
            DependencyProperty.Register("NoCommand", typeof(ICommand), typeof(MsgBox), new PropertyMetadata(new RelayCommand(OnNoButtonClicked)));

      
        #endregion

        #region Overrides
        protected override void OnClosed(EventArgs e)
        {
            if (_interactOwnerMask && _owner != null)
            {
                _owner.IsMaskVisible = false;
            }
            base.OnClosed(e);
        }
        #endregion

        #region Event Handlers
        private static void OnNoButtonClicked(object obj)
        {
            var msgBox = obj as MsgBox;
            msgBox.MessageBoxResult = MessageBoxResult.No;
            msgBox.Close();
        }

        private static void OnYesButtonClicked(object obj)
        {
            var msgBox = obj as MsgBox;
            msgBox.MessageBoxResult = MessageBoxResult.Yes;
            msgBox.Close();
        }

        private static void OnCancelButtonClicked(object obj)
        {
            var msgBox = obj as MsgBox;
            msgBox.MessageBoxResult = MessageBoxResult.Cancel;
            msgBox.Close();
        }
        private static void OnOKButtonClicked(object obj)
        {
            var msgBox = obj as MsgBox;
            msgBox.MessageBoxResult = MessageBoxResult.OK;
            msgBox.Close();
        }
        #endregion

    }
}
