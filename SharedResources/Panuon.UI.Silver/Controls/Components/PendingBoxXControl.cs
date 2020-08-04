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
        internal event EventHandler OnTemplatedChanged;
        #endregion

        #region Properties

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

        #endregion

        #region Override
        protected override void OnTemplateChanged(ControlTemplate oldTemplate, ControlTemplate newTemplate)
        {
            base.OnTemplateChanged(oldTemplate, newTemplate);
            Dispatcher.BeginInvoke(new Action(() =>
            {
                _cancelButton = newTemplate?.FindName("PART_CancelButton", this) as Button;
                OnTemplatedChanged?.Invoke(this, new EventArgs());
            }), DispatcherPriority.DataBind);
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
