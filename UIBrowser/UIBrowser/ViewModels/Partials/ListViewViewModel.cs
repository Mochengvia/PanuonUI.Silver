using Caliburn.Micro;
using Panuon.UI.Silver;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UIBrowser.Components;
using UIBrowser.Core;
using UIBrowser.Core.Properties;
using UIBrowser.Models;

namespace UIBrowser.ViewModels.Partials
{
    public class ListViewViewModel : ViewModelBase, IPaletteView
    {
        #region Ctor
        public ListViewViewModel()
        {
            DataItems = new BindableCollection<DataItem>()
            {
                new DataItem("00204131", "John", Sex.Male, false),
                new DataItem("00204132", "Alex", Sex.Male, false),
                new DataItem("00204133", "Judy", Sex.Female, true),
            };
        }
        #endregion

        #region Properties
        public string Caption => Resources.ListView;

        public string[] LabelLevels => new string[] { Resources.NativeControls };

        public IDictionary<string, DependencyProperty> PaletteProperties => new Dictionary<string, DependencyProperty>
        {
        };

        public IList<DependencyProperty> GeneralProperties => new List<DependencyProperty>
        {
        };

        #region DataItems
        public BindableCollection<DataItem> DataItems { get => _dataItems; set => Set(ref _dataItems, value); }
        private BindableCollection<DataItem> _dataItems;
        #endregion 

        #endregion
    }
}
