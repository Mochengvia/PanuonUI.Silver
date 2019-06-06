using Panuon.UI.Silver.Browser.Models;
using Panuon.UI.Silver.Browser.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// ButtonView.xaml 的交互逻辑
    /// </summary>
    public partial class ButtonView : UserControl
    {
        public ButtonView()
        {
            InitializeComponent();
            ViewModel = new SIMViewModel()
            {
                Properties = new ObservableCollection<PropertyModel>()
                {
                    new PropertyModel("ButtonStyle", "Enum(ButtonStyle)", "Standard[/Hollow/Outline/Link]"),
                    new PropertyModel("ClickStyle", "Enum(ClickStyle)", "None[/Sink]"),
                    new PropertyModel("HoverBrush", "Brush", "#3E3E3E"),
                    new PropertyModel("ClickCoverBrush", "Brush", "#22FFFFFF"),
                    new PropertyModel("CornerRadius", "CornerRadius", "0"),
                    new PropertyModel("IsWaiting", "Boolean", "False"),
                    new PropertyModel("WaitingContent", "String", "\"Please wait...\""),
                    new PropertyModel("Icon", "Object", "<Null>"),
                }
            };
            DataContext = ViewModel;
        }

        public SIMViewModel ViewModel { get; set; }

        private void BtnDocument_Click(object sender, RoutedEventArgs e)
        {
            Carousel.Index++;
        }

        private void BtnExample_Click(object sender, RoutedEventArgs e)
        {
            Carousel.Index--;
        }
    }
}
