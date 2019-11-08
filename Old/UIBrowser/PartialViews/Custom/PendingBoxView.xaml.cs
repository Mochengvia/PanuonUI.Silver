using Panuon.UI.Silver;
using Panuon.UI.Silver.Core;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace UIBrowser.PartialViews.Custom
{
    /// <summary>
    /// WindowView.xaml 的交互逻辑
    /// </summary>
    public partial class PendingBoxView : UserControl
    {
        #region Identity
        private string _message = "This is a test message. This is a test message. This is a test message. This is a test message. This is a test message. This is a test message.This is a test message. This is a test message. This is a test message. This is a test message. This is a test message. This is a test message.This is a test message. This is a test message. This is a test message. This is a test message. This is a test message. This is a test message.";
        private string _message2 = "This is a test message.";
        #endregion

        public PendingBoxView()
        {
            InitializeComponent();
        }

        #region Event Handler
        private async void BtnStandard_Click(object sender, RoutedEventArgs e)
        {
            var handler = PendingBox.Show("Please wait (1/2)...", "Processing", false, Application.Current.MainWindow, new PendingBoxConfigurations()
            {
                LoadingForeground = "#5DBBEC".ToColor().ToBrush(),
                ButtonBrush = "#5DBBEC".ToColor().ToBrush(),
            });
            await Task.Delay(2000);
            handler.UpdateMessage("Almost complete (2/2)...");
            await Task.Delay(2000);
            handler.Close();
        }

        private async void BtnStandardCancelable_Click(object sender, RoutedEventArgs e)
        {
            var handler = PendingBox.Show("Please wait (1/2)...", "Processing", true, Application.Current.MainWindow, new PendingBoxConfigurations()
            {
                LoadingForeground = "#5DBBEC".ToColor().ToBrush(),
                ButtonBrush = "#5DBBEC".ToColor().ToBrush(),
            });
            handler.Cancel += delegate
            {
                handler.Close();
            };

            await Task.Delay(2000);
            handler.UpdateMessage("Almost complete (2/2)...");
            await Task.Delay(2000);
            handler.Close();
        }

        private async void BtnClassic_Click(object sender, RoutedEventArgs e)
        {
            var handler = PendingBox.Show("Please wait (1/2)...", "Processing", false, Application.Current.MainWindow, new PendingBoxConfigurations()
            {
                LoadingForeground = "#5DBBEC".ToColor().ToBrush(),
                ButtonBrush = "#5DBBEC".ToColor().ToBrush(),
                LoadingSize = 50,
                PendingBoxStyle = PendingBoxStyle.Classic,
                FontSize = 14,
            });
            await Task.Delay(2000);
            handler.UpdateMessage("Almost complete (2/2)...");
            await Task.Delay(2000);
            handler.Close();
        }

        private async void BtnClassicCancelable_Click(object sender, RoutedEventArgs e)
        {
            var handler = PendingBox.Show("Please wait (1/2)...", "Processing", true, Application.Current.MainWindow, new PendingBoxConfigurations()
            {
                LoadingForeground = "#5DBBEC".ToColor().ToBrush(),
                ButtonBrush = "#5DBBEC".ToColor().ToBrush(),
                LoadingSize = 50,
                PendingBoxStyle = PendingBoxStyle.Classic,
                FontSize = 14,
            });
            handler.Cancel += delegate
            {
                handler.Close();
            };

            await Task.Delay(2000);
            handler.UpdateMessage("Almost complete (2/2)...");
            await Task.Delay(2000);
            handler.Close();
        }
        #endregion

    }

}
