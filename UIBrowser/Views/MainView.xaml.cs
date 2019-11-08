using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UIBrowser.Models;
using UIBrowser.ViewModels;

namespace UIBrowser.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : WindowX
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void BtnThemePalette_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnGithub_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TvPages_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var type = TvPages.SelectedValue as Type;
            if (type == null)
                return;

            PageContainer.Content = Activator.CreateInstance(type);
        }

        private void This_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl) && e.IsRepeat)
            {
                Cursor = Cursors.Help;
            }
        }

        private void This_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
            {
                Cursor = Cursors.Arrow;
            }
        }

    }
}
