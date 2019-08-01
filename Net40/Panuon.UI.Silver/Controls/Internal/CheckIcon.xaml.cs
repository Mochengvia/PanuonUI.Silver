using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            }
        }
    }
}
