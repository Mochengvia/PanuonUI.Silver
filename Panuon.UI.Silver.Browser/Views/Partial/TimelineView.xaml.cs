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
    /// TimelineView.xaml 的交互逻辑
    /// </summary>
    public partial class TimelineView : UserControl
    {
        public TimelineView()
        {
            InitializeComponent();
            ViewModel = new SIMViewModel()
            {
                TimelineItems = new ObservableCollection<TimelineItemModel>()
                {
                    new TimelineItemModel("Para1","NOT all that Mrs. Bennet, however, with the assistance of her five daughters, could ask on the subject was sufficient to draw from her husband any satisfactory description of Mr. Bingley. "),
                    new TimelineItemModel("Para2","They attacked him in various ways; with barefaced questions, ingenious suppositions, and distant surmises; but he eluded the skill of them all; and they were at last obliged to accept the second-hand intelligence of their neighbour Lady Lucas. "),
                    new TimelineItemModel("Para3","Her report was highly favourable. Sir William had been delighted with him. He was quite young, wonderfully handsome, extremely agreeable, and, to crown the whole, he meant to be at the next assembly with a large party. Nothing could be more delightful! "),
                    new TimelineItemModel("Para4","To be fond of dancing was a certain step towards falling in love; and very lively hopes of Mr. Bingley's heart were entertained."),
                    new TimelineItemModel("End",null),
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
