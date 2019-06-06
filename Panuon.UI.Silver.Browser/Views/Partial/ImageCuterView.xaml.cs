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
    /// ImageCuterView.xaml 的交互逻辑
    /// </summary>
    public partial class ImageCuterView : UserControl
    {
        public ImageCuterView()
        {
            InitializeComponent();

            ImageCuter.ImageSource = new BitmapImage(new Uri("/Panuon.UI.Silver.Browser;component/Resources/Images/cuter_test.jpg", UriKind.RelativeOrAbsolute));
        }

        private void ButtonCut_Click(object sender, RoutedEventArgs e)
        {
            Image.Source = ImageCuter.GetCutedImage();
        }
    }
}
