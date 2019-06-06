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
    public partial class TabControlView : UserControl
    {
        public TabControlView()
        {
            InitializeComponent();
            ViewModel = new SIMViewModel()
            {
                TabItems = new ObservableCollection<TabItemModel>()
                {
                    new TabItemModel("Item1"),
                    new TabItemModel("Item2"),
                    new TabItemModel("Item3"),
                    new TabItemModel("Item4"),
                    new TabItemModel("Item5"),
                    new TabItemModel("Item6"),
                    new TabItemModel("Item7"),
                    new TabItemModel("Item8"),
                },
                Properties = new ObservableCollection<PropertyModel>()
                {
                   
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
