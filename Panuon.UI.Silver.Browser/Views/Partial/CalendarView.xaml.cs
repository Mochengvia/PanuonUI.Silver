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
    public partial class CalendarView : UserControl
    {
        public CalendarView()
        {
            InitializeComponent();
            ViewModel = new SIMViewModel()
            {
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
