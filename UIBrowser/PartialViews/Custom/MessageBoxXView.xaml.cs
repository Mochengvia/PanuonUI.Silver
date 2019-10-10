using Panuon.UI.Silver;
using Panuon.UI.Silver.Core;
using System.Windows;
using System.Windows.Controls;

namespace UIBrowser.PartialViews.Custom
{
    /// <summary>
    /// WindowView.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBoxXView : UserControl
    {
        #region Identity
        private string _message = "This is a test message. This is a test message. This is a test message. This is a test message. This is a test message. This is a test message.This is a test message. This is a test message. This is a test message. This is a test message. This is a test message. This is a test message.This is a test message. This is a test message. This is a test message. This is a test message. This is a test message. This is a test message.";
        private string _message2 = "This is a test message.";
        #endregion

        public MessageBoxXView()
        {
            InitializeComponent();
        }



        private void BtnStandardInfo_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBoxX.Show(_message2, "Infomation", Application.Current.MainWindow, MessageBoxButton.YesNo);
        }

        private void BtnStandardError_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBoxX.Show(_message, "Error", Application.Current.MainWindow, MessageBoxButton.YesNo, new MessageBoxXConfigurations()
            {
                MessageBoxIcon = MessageBoxIcon.Error,
                ButtonBrush = "#FF4C4C".ToColor().ToBrush(),
            });
        }

        private void BtnStandardSuccess_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBoxX.Show(_message, "Success", Application.Current.MainWindow, MessageBoxButton.YesNo, new MessageBoxXConfigurations()
            {
                MessageBoxIcon = MessageBoxIcon.Success,
                ButtonBrush = "#75CD43".ToColor().ToBrush(),
            });
        }

        private void BtnStandardWarn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBoxX.Show(_message, "Warning", Application.Current.MainWindow, MessageBoxButton.YesNo, new MessageBoxXConfigurations()
            {
                MessageBoxIcon = MessageBoxIcon.Warning,
                ButtonBrush = "#F1C825".ToColor().ToBrush(),
            });
        }

        private void BtnModernInfo_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBoxX.Show(_message2, "Infomation", Application.Current.MainWindow, MessageBoxButton.YesNo, new MessageBoxXConfigurations()
            {
                MessageBoxStyle = MessageBoxStyle.Modern,
            });
        }

        private void BtnModernSuccess_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBoxX.Show(_message2, "Success", Application.Current.MainWindow, MessageBoxButton.YesNo, new MessageBoxXConfigurations()
            {
                MessageBoxStyle = MessageBoxStyle.Modern,
                MessageBoxIcon = MessageBoxIcon.Success,
                ButtonBrush = "#75CD43".ToColor().ToBrush(),
            });
        }

        private void BtnModernError_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBoxX.Show(_message, "Error", Application.Current.MainWindow, MessageBoxButton.YesNo, new MessageBoxXConfigurations()
            {
                MessageBoxStyle = MessageBoxStyle.Modern,
                MessageBoxIcon = MessageBoxIcon.Error,
                ButtonBrush = "#FF4C4C".ToColor().ToBrush(),
            });
        }

        private void BtnModernWarning_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBoxX.Show(_message, "Warning", Application.Current.MainWindow, MessageBoxButton.YesNo, new MessageBoxXConfigurations()
            {
                MessageBoxStyle = MessageBoxStyle.Modern,
                MessageBoxIcon = MessageBoxIcon.Warning,
                ButtonBrush = "#F1C825".ToColor().ToBrush(),
            });
        }

        private void BtnClassicInfo_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBoxX.Show(_message2, "Infomation", Application.Current.MainWindow, MessageBoxButton.YesNo, new MessageBoxXConfigurations()
            {
                MessageBoxStyle = MessageBoxStyle.Classic,
            });
        }

        private void BtnClassicError_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBoxX.Show(_message2, "Success", Application.Current.MainWindow, MessageBoxButton.YesNo, new MessageBoxXConfigurations()
            {
                MessageBoxStyle = MessageBoxStyle.Classic,
                MessageBoxIcon = MessageBoxIcon.Success,
                ButtonBrush = "#75CD43".ToColor().ToBrush(),
            });
        }

        private void BtnClassicSuccess_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBoxX.Show(_message, "Error", Application.Current.MainWindow, MessageBoxButton.YesNo, new MessageBoxXConfigurations()
            {
                MessageBoxStyle = MessageBoxStyle.Classic,
                MessageBoxIcon = MessageBoxIcon.Error,
                ButtonBrush = "#FF4C4C".ToColor().ToBrush(),
            });
        }

        private void BtnClassicWarning_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBoxX.Show(_message, "Warning", Application.Current.MainWindow, MessageBoxButton.YesNo, new MessageBoxXConfigurations()
            {
                MessageBoxStyle = MessageBoxStyle.Classic,
                MessageBoxIcon = MessageBoxIcon.Warning,
                ButtonBrush = "#F1C825".ToColor().ToBrush(),
            });
        }

        private void BtnLoading_Click(object sender, RoutedEventArgs e)
        {

        }



        //private void BtnPosterInfo_Click(object sender, RoutedEventArgs e)
        //{
        //    var result = MessageBoxX.Show(_message2, "Info", Application.Current.MainWindow, MessageBoxButton.YesNo, new MessageBoxXConfigurations()
        //    {
        //        MessageBoxStyle = MessageBoxStyle.Poster,
        //    });
        //}

        //private void BtnPosterSuccess_Click(object sender, RoutedEventArgs e)
        //{
        //    var result = MessageBoxX.Show(_message2, "Success", Application.Current.MainWindow, MessageBoxButton.YesNo, new MessageBoxXConfigurations()
        //    {
        //        MessageBoxStyle = MessageBoxStyle.Poster,
        //        MessageBoxIcon = MessageBoxIcon.Success,
        //        ThemeBrush = "#75CD43".ToColor().ToBrush(),
        //    });
        //}

        //private void BtnPosterError_Click(object sender, RoutedEventArgs e)
        //{
        //    var result = MessageBoxX.Show(_message2, "Success", Application.Current.MainWindow, MessageBoxButton.YesNo, new MessageBoxXConfigurations()
        //    {
        //        MessageBoxStyle = MessageBoxStyle.Poster,
        //        MessageBoxIcon = MessageBoxIcon.Success,
        //        ThemeBrush = "#75CD43".ToColor().ToBrush(),
        //    });
        //}
    }

}
