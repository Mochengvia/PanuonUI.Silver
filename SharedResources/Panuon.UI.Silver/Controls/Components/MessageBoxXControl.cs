using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Panuon.UI.Silver.Components
{
    public sealed class MessageBoxXControl : Control
    {
        #region Fields
        internal Button _yesButton;

        internal Button _noButton;

        internal Button _okButton;

        internal Button _cancelButton;
        #endregion

        #region Event Handlers
        internal event EventHandler OnTemplatedChanged;
        #endregion


        #region Ctor
        static MessageBoxXControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MessageBoxXControl), new FrameworkPropertyMetadata(typeof(MessageBoxXControl)));
        }
        #endregion

        #region Override
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Dispatcher.BeginInvoke(new Action(() =>
            {
                _yesButton = Template?.FindName("PART_YesButton", this) as Button;
                _noButton = Template?.FindName("PART_NoButton", this) as Button;
                _okButton = Template?.FindName("PART_OKButton", this) as Button;
                _cancelButton = Template?.FindName("PART_CancelButton", this) as Button;
                OnTemplatedChanged?.Invoke(this, new EventArgs());
            }), DispatcherPriority.Loaded);
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
            DependencyProperty.Register("MaxContentWidth", typeof(double), typeof(MessageBoxXControl));
        #endregion

        #region MaxContentHeight
        public double MaxContentHeight
        {
            get { return (double)GetValue(MaxContentHeightProperty); }
            set { SetValue(MaxContentHeightProperty, value); }
        }

        public static readonly DependencyProperty MaxContentHeightProperty =
            DependencyProperty.Register("MaxContentHeight", typeof(double), typeof(MessageBoxXControl));
        #endregion

        #region Message
        public object Message
        {
            get { return (object)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(object), typeof(MessageBoxXControl));
        #endregion

        #region MessageBoxIcon
        public MessageBoxIcon Icon
        {
            get { return (MessageBoxIcon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(MessageBoxIcon), typeof(MessageBoxXControl));
        #endregion

        #region ButtonStyle
        public Style ButtonStyle
        {
            get { return (Style)GetValue(ButtonStyleProperty); }
            set { SetValue(ButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(MessageBoxXControl));
        #endregion

        #region ButtonArrangement

        public MessageBoxButtonArrangement ButtonArrangement
        {
            get { return (MessageBoxButtonArrangement)GetValue(ButtonArrangementProperty); }
            set { SetValue(ButtonArrangementProperty, value); }
        }

        public static readonly DependencyProperty ButtonArrangementProperty =
            DependencyProperty.Register("ButtonArrangement", typeof(MessageBoxButtonArrangement), typeof(MessageBoxXControl), new PropertyMetadata(MessageBoxButtonArrangement.Standard));

        #endregion
        #endregion

        #region Methods
        #endregion

        #region Event Handlers
        #endregion

        #region Functions
        #endregion
    }
}
