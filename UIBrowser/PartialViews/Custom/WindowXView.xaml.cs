using System.Windows;
using System.Windows.Controls;
using UIBrowser.Examples;

namespace UIBrowser.PartialViews.Custom
{
    /// <summary>
    /// WindowView.xaml 的交互逻辑
    /// </summary>
    public partial class WindowXView : UserControl
    {
        #region Identity
        #endregion

        public WindowXView()
        {
            InitializeComponent();
        }


        private void BtnWindow_Click(object sender, RoutedEventArgs e)
        {
            Window window = null;
            switch ((sender as Button).Tag.ToString())
            {
                case "MacLike":
                    window = new MacLikeWindow();
                    break;
                case "Navbar":
                    window = new NavbarWindow();
                    break;
                case "NeteaseMusic":
                    window = new NeteaseMusicWindow();
                    break;
            }
            if (window != null)
            {
                (Application.Current.MainWindow as MainWindow).IsMaskVisible = true;
                window.ShowDialog();
                (Application.Current.MainWindow as MainWindow).IsMaskVisible = false;
            }
        }
    }
}
