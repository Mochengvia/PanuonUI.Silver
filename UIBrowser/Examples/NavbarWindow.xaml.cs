using Panuon.UI.Silver;
using System.Windows;

namespace UIBrowser.Examples
{
    /// <summary>
    /// MacLikeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NavbarWindow : WindowX
    {
        public NavbarWindow()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnMax_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Minimized;
        }
    }
}
