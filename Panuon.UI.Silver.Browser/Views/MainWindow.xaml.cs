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
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("Window"), typeof(WindowView)));
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("Button"), typeof(ButtonView)));
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("CheckBox"), typeof(CheckBoxView)));
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("RadioButton"), typeof(RadioButtonView)));
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("TextBox"), typeof(TextBoxView)));
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("PasswordBox"), typeof(PasswordBoxView)));
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("ComboBox"), typeof(ComboBoxView)));
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("Treeview"), typeof(TreeviewView)));
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("TabControl"), typeof(TabControlView)));
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("ProgressBar"), typeof(ProgressBarView)));
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("Calendar"), typeof(CalendarView)));
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("TagPanel"), typeof(TagPanelView)));
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("Loading"), typeof(LoadingView)));
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("NeonLabel"), typeof(NeonLabelView)));
            ViewModel.MenuItems.Add(new Models.TreeViewItemModel(GetString("ImageCuter"), typeof(ImageCuterView)));
        }

        public void ResetMenuItemNames()
        {
            foreach(var menuItem in ViewModel.MenuItems)
            {
                var type = menuItem.Value as Type;
                if (type == null)
                    continue;

                menuItem.Header = GetString(type.Name.Remove(type.Name.Length - 4, 4));
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
