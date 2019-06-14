using Panuon.UI.Silver.Browser.Models;
using Panuon.UI.Silver.Browser.ViewModels;
using Panuon.UI.Silver.Browser.Views.Partial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Panuon.UI.Silver.Browser.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LanguageInfo.Current = Thread.CurrentThread.CurrentCulture.IetfLanguageTag;
            Instance = this;
            ViewModel = new MainViewModel();
            DataContext = ViewModel;

            InitMenuItems();
        }

        #region Property
        public static MainWindow Instance { get; set; }

        public MainViewModel ViewModel { get; set; }
        #endregion

        #region Event
        private void BtnHelp_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Ruris/PanuonUI.Silver");
        }

        private void TvMenu_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ActiveContent(TvMenu.SelectedValue as Type);
        }
        #endregion

        #region Function
        private void InitMenuItems()
        {
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("Introduction"), typeof(IntroductionView), true));
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("StylesWithHelper"), "StylesWithHelper")
            {
                IsExpanded = true,
                Items = new System.Collections.ObjectModel.ObservableCollection<Models.TreeViewItemModel>()
                {
                    new TreeViewItemModel(GetString("Window"), typeof(WindowView)),
                    new TreeViewItemModel(GetString("Button"), typeof(ButtonView)),
                    new TreeViewItemModel(GetString("CheckBox"), typeof(CheckBoxView)),
                    new TreeViewItemModel(GetString("RadioButton"), typeof(RadioButtonView)),
                    new TreeViewItemModel(GetString("TextBox"), typeof(TextBoxView)),
                    new TreeViewItemModel(GetString("PasswordBox"), typeof(PasswordBoxView)),
                    new TreeViewItemModel(GetString("ComboBox"), typeof(ComboBoxView)),
                    new TreeViewItemModel(GetString("Treeview"), typeof(TreeviewView)),
                    new TreeViewItemModel(GetString("TabControl"), typeof(TabControlView)),
                    new TreeViewItemModel(GetString("Slider"), typeof(SliderView)),
                    new TreeViewItemModel(GetString("ProgressBar"), typeof(ProgressBarView)),
                }
            });
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("Control"), "Control")
            {
                IsExpanded = true,
                Items = new System.Collections.ObjectModel.ObservableCollection<Models.TreeViewItemModel>()
                {
                    new TreeViewItemModel(GetString("Calendar"), typeof(CalendarView)),
                    new TreeViewItemModel(GetString("DateTimePicker"), typeof(DateTimePickerView)),
                    new TreeViewItemModel(GetString("TagPanel"), typeof(TagPanelView)),
                    new TreeViewItemModel(GetString("Loading"), typeof(LoadingView)),
                    new TreeViewItemModel(GetString("DropDown"), typeof(DropDownView)),
                    new TreeViewItemModel(GetString("NeonLabel"), typeof(NeonLabelView)),
                    new TreeViewItemModel(GetString("ImageCuter"), typeof(ImageCuterView)),
                }
            });
        }

        public void ResetMenuItemNames()
        {
            UpdateMenuItemNames(ViewModel.MenuItems);
        }

        private void UpdateMenuItemNames(IList<TreeViewItemModel> treeViewItemModels)
        {
            foreach(var menuItem in treeViewItemModels)
            {
                if (menuItem.Value is string)
                    menuItem.Header = GetString(menuItem.Value as string);
                else if (menuItem.Value is Type)
                {
                    var type = menuItem.Value as Type;
                    menuItem.Header = GetString(type.Name.Remove(type.Name.Length - 4, 4));
                }

                UpdateMenuItemNames(menuItem.Items);
            }
        }

        private void ActiveContent(Type menuValue)
        {
            UIElement element = null;

            if (menuValue != null)
                element = Activator.CreateInstance(menuValue) as UIElement;    
            
            ContentControl.Content = element;
        }


        public static string GetString(string resourceKey)
        {
            return Instance.FindResource(resourceKey) as string;
        }
        #endregion

        
    }
}
