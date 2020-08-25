using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Panuon.UI.Silver.Components
{
    public sealed class PendingBoxXControl : Control
    {
        #region Fields
        internal Button _cancelButton;
        #endregion

        #region Ctor
        static PendingBoxXControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PendingBoxXControl), new FrameworkPropertyMetadata(typeof(PendingBoxXControl)));
        }
        #endregion

        #region Events
        internal event EventHandler TemplateApplied;
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
        public object Message
        {
            get { return (object)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(object), typeof(PendingBoxXControl));
        #endregion

        #region ImageSource
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(string), typeof(PendingBoxXControl));
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

        #region CancelButtonStyle
        public Style CancelButtonStyle
        {
            get { return (Style)GetValue(CancelButtonStyleProperty); }
            set { SetValue(CancelButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty CancelButtonStyleProperty =
            DependencyProperty.Register("CancelButtonStyle", typeof(Style), typeof(PendingBoxXControl));
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

        #region CanCancel
        public bool CanCancel
        {
            get { return (bool)GetValue(CanCancelProperty); }
            set { SetValue(CanCancelProperty, value); }
        }

        public static readonly DependencyProperty CanCancelProperty =
            DependencyProperty.Register("CanCancel", typeof(bool), typeof(PendingBoxXControl));
        #endregion

        #region IsEscEnabled
        public bool IsEscEnabled
        {
            get { return (bool)GetValue(IsEscEnabledProperty); }
            set { SetValue(IsEscEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsEscEnabledProperty =
            DependencyProperty.Register("IsEscEnabled", typeof(bool), typeof(PendingBoxXControl));
        #endregion


        #endregion

        #region Override
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Dispatcher.BeginInvoke(new Action(() =>
            {
                _cancelButton = Template?.FindName("PART_CancelButton", this) as Button;
                TemplateApplied?.Invoke(this, new EventArgs());
            }), DispatcherPriority.Loaded);
        }
        #endregion

        #region Methods
        #endregion

        #region Event Handlers
        #endregion

        #region Functions
        #endregion
    }
}
