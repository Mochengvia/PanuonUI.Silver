using Panuon.UI.Silver.Core;
using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver.Controls.Internal
{
    /// <summary>
    /// MsgBox.xaml 的交互逻辑
    /// </summary>
    internal partial class MsgBox : Window
    {
        public MsgBox(Window owner, string message, string title, MessageBoxButton messageBoxButton, MessageBoxXConfigurations messageBoxXConfigurations)
        {
            InitializeComponent();

            Title = title;
            Owner = owner;
            Text = message;
            MessageBoxStyle = messageBoxXConfigurations.MessageBoxStyle;
            Topmost = messageBoxXConfigurations.Topmost;
            ShowInTaskbar = messageBoxXConfigurations.ShowInTaskbar;
            MessageBoxIcon = messageBoxXConfigurations.MessageBoxIcon;
            MessageBoxButton = messageBoxButton;
            WindowStartupLocation = messageBoxXConfigurations.WindowStartupLocation;
            YesButton = messageBoxXConfigurations.YesButton;
            NoButton = messageBoxXConfigurations.NoButton;
            OKButton = messageBoxXConfigurations.OKButton;
            CancelButton = messageBoxXConfigurations.CancelButton;
            ThemeBrush = messageBoxXConfigurations.ButtonBrush;
            MinWidth = messageBoxXConfigurations.MinWidth;
            MinHeight = messageBoxXConfigurations.MinHeight;
            DefaultButton = messageBoxXConfigurations.DefaultButton;
            MaxContentHeight = messageBoxXConfigurations.MaxContentHeight;
            MaxContentWidth = messageBoxXConfigurations.MaxContentWidth;
            ReverseButtonSequence = messageBoxXConfigurations.ReverseButtonSequence;
            FontSize = messageBoxXConfigurations.FontSize;

        }

        #region Property
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(MsgBox), new PropertyMetadata(new CornerRadius(5)));

        public MessageBoxStyle MessageBoxStyle
        {
            get { return (MessageBoxStyle)GetValue(MessageBoxStyleProperty); }
            set { SetValue(MessageBoxStyleProperty, value); }
        }

        public static readonly DependencyProperty MessageBoxStyleProperty =
            DependencyProperty.Register("MessageBoxStyle", typeof(MessageBoxStyle), typeof(MsgBox), new PropertyMetadata(MessageBoxStyle.Standard, OnMessageBoxStyleChanged));

        public MessageBoxButton MessageBoxButton
        {
            get { return (MessageBoxButton)GetValue(MessageBoxButtonProperty); }
            set { SetValue(MessageBoxButtonProperty, value); }
        }

        public static readonly DependencyProperty MessageBoxButtonProperty =
            DependencyProperty.Register("MessageBoxButton", typeof(MessageBoxButton), typeof(MsgBox), new PropertyMetadata(MessageBoxButton.OK));

        public MessageBoxResult MessageBoxResult
        {
            get { return (MessageBoxResult)GetValue(MessageBoxResultProperty); }
            set { SetValue(MessageBoxResultProperty, value); }
        }

        public static readonly DependencyProperty MessageBoxResultProperty =
            DependencyProperty.Register("MessageBoxResult", typeof(MessageBoxResult), typeof(MsgBox), new PropertyMetadata(MessageBoxResult.No));


        public MessageBoxIcon MessageBoxIcon
        {
            get { return (MessageBoxIcon)GetValue(MessageBoxIconProperty); }
            set { SetValue(MessageBoxIconProperty, value); }
        }

        public static readonly DependencyProperty MessageBoxIconProperty =
            DependencyProperty.Register("MessageBoxIcon", typeof(MessageBoxIcon), typeof(MsgBox), new PropertyMetadata(MessageBoxIcon.None));

        public HorizontalAlignment ButtonGroupHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(ButtonGroupHorizontalAlignmentProperty); }
            set { SetValue(ButtonGroupHorizontalAlignmentProperty, value); }
        }

        public static readonly DependencyProperty ButtonGroupHorizontalAlignmentProperty =
            DependencyProperty.Register("ButtonGroupHorizontalAlignment", typeof(HorizontalAlignment), typeof(MsgBox), new PropertyMetadata(HorizontalAlignment.Left));



        public double MaxContentWidth
        {
            get { return (double)GetValue(MaxContentWidthProperty); }
            set { SetValue(MaxContentWidthProperty, value); }
        }

        public static readonly DependencyProperty MaxContentWidthProperty =
            DependencyProperty.Register("MaxContentWidth", typeof(double), typeof(MsgBox));


        public double MaxContentHeight
        {
            get { return (double)GetValue(MaxContentHeightProperty); }
            set { SetValue(MaxContentHeightProperty, value); }
        }

        public static readonly DependencyProperty MaxContentHeightProperty =
            DependencyProperty.Register("MaxContentHeight", typeof(double), typeof(MsgBox));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MsgBox));

        public string YesButton
        {
            get { return (string)GetValue(YesButtonProperty); }
            set { SetValue(YesButtonProperty, value); }
        }

        public static readonly DependencyProperty YesButtonProperty =
            DependencyProperty.Register("YesButton", typeof(string), typeof(MsgBox));

        public string NoButton
        {
            get { return (string)GetValue(NoButtonProperty); }
            set { SetValue(NoButtonProperty, value); }
        }

        public static readonly DependencyProperty NoButtonProperty =
            DependencyProperty.Register("NoButton", typeof(string), typeof(MsgBox));

        public string OKButton
        {
            get { return (string)GetValue(OKButtonProperty); }
            set { SetValue(OKButtonProperty, value); }
        }

        public static readonly DependencyProperty OKButtonProperty =
            DependencyProperty.Register("OKButton", typeof(string), typeof(MsgBox));

        public string CancelButton
        {
            get { return (string)GetValue(CancelButtonProperty); }
            set { SetValue(CancelButtonProperty, value); }
        }

        public static readonly DependencyProperty CancelButtonProperty =
            DependencyProperty.Register("CancelButton", typeof(string), typeof(MsgBox));

        public double MinContentWidth
        {
            get { return (double)GetValue(MinContentWidthProperty); }
            set { SetValue(MinContentWidthProperty, value); }
        }

        public static readonly DependencyProperty MinContentWidthProperty =
            DependencyProperty.Register("MinContentWidth", typeof(double), typeof(MsgBox));

        public double MinContentHeight
        {
            get { return (double)GetValue(MinContentHeightProperty); }
            set { SetValue(MinContentHeightProperty, value); }
        }

        public static readonly DependencyProperty MinContentHeightProperty =
            DependencyProperty.Register("MinContentHeight", typeof(double), typeof(MsgBox));

        public DefaultButton DefaultButton
        {
            get { return (DefaultButton)GetValue(DefaultButtonProperty); }
            set { SetValue(DefaultButtonProperty, value); }
        }

        public static readonly DependencyProperty DefaultButtonProperty =
            DependencyProperty.Register("DefaultButton", typeof(DefaultButton), typeof(MsgBox));

        public Brush ThemeBrush
        {
            get { return (Brush)GetValue(ThemeBrushProperty); }
            set { SetValue(ThemeBrushProperty, value); }
        }

        public static readonly DependencyProperty ThemeBrushProperty =
            DependencyProperty.Register("ThemeBrush", typeof(Brush), typeof(MsgBox));

        public bool ReverseButtonSequence
        {
            get { return (bool)GetValue(ReverseButtonSequenceProperty); }
            set { SetValue(ReverseButtonSequenceProperty, value); }
        }

        public static readonly DependencyProperty ReverseButtonSequenceProperty =
            DependencyProperty.Register("ReverseButtonSequence", typeof(bool), typeof(MsgBox), new PropertyMetadata(OnReverseButtonSequenceChanged));

        private static void OnReverseButtonSequenceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var msb = d as MsgBox;
            if (msb.ReverseButtonSequence)
            {
                msb.StkButtonGroup1.Visibility = Visibility.Collapsed;
                msb.StkButtonGroup2.Visibility = Visibility.Collapsed;
                msb.StkButtonGroupReverse1.Visibility = Visibility.Visible;
                msb.StkButtonGroupReverse2.Visibility = Visibility.Visible;
            }
            else
            {
                msb.StkButtonGroup1.Visibility = Visibility.Visible;
                msb.StkButtonGroup2.Visibility = Visibility.Visible;
                msb.StkButtonGroupReverse1.Visibility = Visibility.Collapsed;
                msb.StkButtonGroupReverse2.Visibility = Visibility.Collapsed;
            }
        }
        #endregion

        #region EventHandler
        private void BdrMain_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private static void OnMessageBoxStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var msb = d as MsgBox;
            switch (msb.MessageBoxStyle)
            {
                case MessageBoxStyle.Modern:
                    msb.GrdStandard.Visibility = Visibility.Collapsed;
                    msb.GrdClassic.Visibility = Visibility.Collapsed;
                    msb.GrdModern.Visibility = Visibility.Visible;
                    break;
                case MessageBoxStyle.Classic:
                    msb.GrdStandard.Visibility = Visibility.Collapsed;
                    msb.GrdModern.Visibility = Visibility.Collapsed;
                    msb.GrdClassic.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void BtnYes_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = MessageBoxResult.Yes;
            Close();
        }

        private void BtnNo_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = MessageBoxResult.No;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = MessageBoxResult.Cancel;
            Close();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult = MessageBoxResult.OK;
            Close();
        }
        #endregion


    }
}
