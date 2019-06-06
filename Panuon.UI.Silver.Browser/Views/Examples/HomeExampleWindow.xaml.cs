using Panuon.UI.Silver.Browser.Models;
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
using System.Windows.Shapes;

namespace Panuon.UI.Silver.Browser.Views.Examples
{
    /// <summary>
    /// HomeExampleWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HomeExampleWindow : Window
    {
        public HomeExampleWindow()
        {
            InitializeComponent();
            DataContext = this;

            TagItems = new ObservableCollection<TagItemModel>();

            Init();
        }

        #region Property
        public ObservableCollection<TagItemModel> TagItems { get; set; }
        #endregion

        #region Event
        #endregion

        #region Function
        private void Init()
        {
            TagItems.Add(new TagItemModel("WPF", FindResource("LightBlue") as Brush));
            TagItems.Add(new TagItemModel("C#", FindResource("LightOrange") as Brush));
            TagItems.Add(new TagItemModel("ASP.NET MVC", FindResource("LightGreen") as Brush));
            TagItems.Add(new TagItemModel("React", FindResource("LightPink") as Brush));
            TagItems.Add(new TagItemModel("Angular", FindResource("LightRed") as Brush));
            TagItems.Add(new TagItemModel("Java", FindResource("LightBlue") as Brush));
            TagItems.Add(new TagItemModel("Python", FindResource("LightOrange") as Brush));
            TagItems.Add(new TagItemModel("ASP.NET Core", FindResource("LightGreen") as Brush));
            TagItems.Add(new TagItemModel("PHP", FindResource("LightPink") as Brush));
            TagItems.Add(new TagItemModel("HTML", FindResource("LightRed") as Brush));
            TagItems.Add(new TagItemModel("JavaScript", FindResource("LightBlue") as Brush));
        }
        #endregion
    }
}
