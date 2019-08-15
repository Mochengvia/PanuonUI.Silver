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
    public partial class MainWindow : WindowX
    {
        #region Identity
        private static IDictionary<string, Type> _partialViewDic;
        #endregion

        #region Property
        public MainWindowViewModel ViewModel { get; set; }
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
        }


        private void MouseOperationContainer_Click(object sender, Panuon.UI.Silver.Core.ClickEventArgs e)
        {
            txt.Text += $"Click({e.Position.X},{e.Position.Y})\n";
        }

        private void MouseOperationContainer_DoubleClick(object sender, Panuon.UI.Silver.Core.DoubleClickEventArgs e)
        {
            txt.Text += $"DoubleClick({e.Position.X},{e.Position.Y})\n";
        }

        private void MouseOperationContainer_DragArea(object sender, Panuon.UI.Silver.Core.DragAreaEventArgs e)
        {
            txt.Text += $"DragArea({e.StartPosition.X},{e.StartPosition.Y})({e.EndPosition.X},{e.EndPosition.Y})\n";
        }

        private void MouseOperationContainer_LongPress(object sender, Panuon.UI.Silver.Core.LongPressEventArgs e)
        {
            txt.Text += "Long press\n";
        }

        private void MouseOperationContainer_Draging(object sender, Panuon.UI.Silver.Core.DragingEventArgs e)
        {
            txt.Text += $"Draging({e.StartPosition.X},{e.StartPosition.Y})({e.EndPosition.X},{e.EndPosition.Y})\n";
        }
    }
}
