using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver.Controls.Internal
{
    /// <summary>
    /// CheckIcon.xaml 的交互逻辑
    /// </summary>
    internal partial class CheckIcon : UserControl
    {
        public CheckIcon()
        {
            InitializeComponent();
        }

        public MessageBoxIcon MessageBoxIcon
        {
            get { return (MessageBoxIcon)GetValue(MessageBoxIconProperty); }
            set { SetValue(MessageBoxIconProperty, value); }
        }

        public static readonly DependencyProperty MessageBoxIconProperty =
            DependencyProperty.Register("MessageBoxIcon", typeof(MessageBoxIcon), typeof(CheckIcon), new PropertyMetadata(MessageBoxIcon.None, OnMessageBoxIconChanged));


        public double Thickness
        {
            get { return (double)GetValue(ThicknessProperty); }
            set { SetValue(ThicknessProperty, value); }
        }

        public static readonly DependencyProperty ThicknessProperty =
            DependencyProperty.Register("Thickness", typeof(double), typeof(CheckIcon), new PropertyMetadata(5.0));



        private static void OnMessageBoxIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var icon = d as CheckIcon;
            switch (icon.MessageBoxIcon)
            {
                case MessageBoxIcon.Success:
                    icon.GrdSuccess.Visibility = Visibility.Visible;
                    break;
                case MessageBoxIcon.Info:
                    icon.GrdInfo.Visibility = Visibility.Visible;
                    break;
                case MessageBoxIcon.Error:
                    icon.GrdError.Visibility = Visibility.Visible;
                    break;
                case MessageBoxIcon.Warning:
                    icon.GrdWarn.Visibility = Visibility.Visible;
                    break;
                case MessageBoxIcon.Question:
                    icon.GrdQuestion.Visibility = Visibility.Visible;
                    break;

            }
        }
    }
}
