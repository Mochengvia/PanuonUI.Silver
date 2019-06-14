using Panuon.UI.Silver.Browser.Views.Examples;
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

namespace Panuon.UI.Silver.Browser.Views.Partial
{
    /// <summary>
    /// WindowView.xaml 的交互逻辑
    /// </summary>
    public partial class WindowView : UserControl
    {
        public WindowView()
        {
            InitializeComponent();
        }

        private void BtnConfigExample_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.SetOpenCoverMask(MainWindow.Instance, true);
            var window = new HomeExampleWindow();
            window.ShowDialog();
            WindowHelper.SetOpenCoverMask(MainWindow.Instance, false);
        }

        private void BtnDocument_Click(object sender, RoutedEventArgs e)
        {
            Carousel.Index++;
        }

        private void BtnExample_Click(object sender, RoutedEventArgs e)
        {
            Carousel.Index--;
        }

        private void BtnCURDExample_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.SetOpenCoverMask(MainWindow.Instance, true);
            var window = new CURDExampleWindow();
            window.ShowDialog();
            WindowHelper.SetOpenCoverMask(MainWindow.Instance, false);
        }
    }
}
