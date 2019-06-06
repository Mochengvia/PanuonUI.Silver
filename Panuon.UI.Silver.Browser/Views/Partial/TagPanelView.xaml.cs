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
    /// ComboBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class TagPanelView : UserControl
    {
        public TagPanelView()
        {
            InitializeComponent();
            ViewModel = new SIMViewModel()
            {
                TagItems = new ObservableCollection<TagItemModel>()
                {
                    new TagItemModel("WPF", FindResource("LightBlue") as Brush),
                    new TagItemModel("C#",FindResource("LightOrange") as Brush),
                    new TagItemModel("ASP.NET MVC",FindResource("LightGreen") as Brush),
                    new TagItemModel("React",FindResource("LightPink") as Brush),
                    new TagItemModel("Angular",FindResource("LightRed") as Brush),
                    new TagItemModel("Java",FindResource("LightBlue") as Brush),
                    new TagItemModel("Python",FindResource("LightOrange") as Brush),
                    new TagItemModel("ASP.NET Core",FindResource("LightGreen") as Brush),
                    new TagItemModel("PHP",FindResource("LightPink") as Brush),
                    new TagItemModel("HTML",FindResource("LightRed") as Brush),
                    new TagItemModel("JavaScript",FindResource("LightBlue") as Brush),
                    new TagItemModel("TypeScript",FindResource("LightOrange") as Brush),
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

        private void TagPanel_RemoveButtonClicked(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var model = e.NewValue as TagItemModel;
            ViewModel.TagItems.Remove(model);
        }
    }
}
