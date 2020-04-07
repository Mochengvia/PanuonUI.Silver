using Panuon.UI.Silver;
using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int ints = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (ints)
            {
                case 0:
                    AstpPanel.Children.RemoveAt(1);
                    break;
                case 1:
                    AstpPanel.Children.RemoveAt(1);
                    break;
                case 2:
                    AstpPanel.Children.Insert(1, new Label()
                    {
                        Height = 30,
                        Foreground = Brushes.White,
                        Background = "#FFCFDB".ToColor().ToBrush(),
                        Content = "Label"
                    });
                    break;
                case 3:
                    AstpPanel.Children.Insert(1, new Label()
                    {
                        Height = 30,
                        Foreground = Brushes.White,
                        Background = "#B1DEF1".ToColor().ToBrush(),
                        Content = "Label"
                    });
                    break;
            }
            ints++;
        }
    }
}
