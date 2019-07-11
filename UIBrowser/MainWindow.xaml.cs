using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Panuon.UI.Silver;
using UIBrowser.Models;

namespace UIBrowser
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Identity
        private static IDictionary<string, Type> _dicPartialView;
        #endregion

        #region Property
        public MainWindowViewModel ViewModel { get; set; }
        #endregion

        #region Constructor
        static MainWindow()
        {
            _dicPartialView = new Dictionary<string, Type>();
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.FullName.StartsWith("UIBrowser"));
            assembly.GetTypes().Where(x => x.Namespace.StartsWith("UIBrowser.PartialViews") && x.IsSubclassOf(typeof(UserControl))).ToList().ForEach(x =>_dicPartialView.Add(x.Name.Remove(x.Name.Length - 4), x));
        }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();
            DataContext = ViewModel;
        }

        #endregion

        #region EventHandler
        private void TvMenu_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (!IsLoaded)
                return;

            var selectedItem = TvMenu.SelectedItem as TreeViewItemModel;
            var tag = selectedItem.Tag;
            if (tag.IsNullOrEmpty())
                return;

            if (_dicPartialView.ContainsKey(tag))
                ContentControl.Content = Activator.CreateInstance(_dicPartialView[tag]);
            else
                ContentControl.Content = null;
        }
        #endregion

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SearchText = "";
        }
    }

    public enum TestEnum
    {
        Enum1,
        Enum2,
        Enum3,
    }
}
