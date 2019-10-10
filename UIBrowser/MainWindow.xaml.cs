using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UIBrowser.Models;

namespace UIBrowser
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowX
    {
        #region Identity
        private static IDictionary<string, Type> _partialViewDic;
        #endregion

        #region Property
        public MainWindowViewModel ViewModel { get; set; }

        public string Text { get; set; }
        #endregion

        #region Constructor
        static MainWindow()
        {
            _partialViewDic = new Dictionary<string, Type>();
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.FullName.StartsWith("UIBrowser"));
            assembly.GetTypes().Where(x => x.Namespace.StartsWith("UIBrowser.PartialViews") && x.IsSubclassOf(typeof(UserControl))).ToList().ForEach(x => _partialViewDic.Add(x.Name.Remove(x.Name.Length - 4), x));
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

            if (_partialViewDic.ContainsKey(tag))
                ContentControl.Content = Activator.CreateInstance(_partialViewDic[tag]);
            else
                ContentControl.Content = null;
        }
        #endregion

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SearchText = "";
        }

        private void WindowX_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Column1", typeof(int));
            dataTable.Columns.Add("Column2", typeof(string));

            var row1 = dataTable.NewRow();
            row1["Column1"] = 1;
            row1["Column2"] = "1";
            dataTable.Rows.Add(row1);

            var row2 = dataTable.NewRow();
            row2["Column1"] = 2;
            row2["Column2"] = "2";
            dataTable.Rows.Add(row2);

            DataTable newDataTable;
                newDataTable = dataTable.Clone();
                foreach (var row in dataTable.Select("Column1 > 1"))
                {
                    var newRow = newDataTable.NewRow();
                    foreach (DataColumn column in newDataTable.Columns)
                    {
                        newRow[column.ColumnName] = row[column.ColumnName];
                    }
                    newDataTable.Rows.Add(newRow);
                }
        }
    }
}
