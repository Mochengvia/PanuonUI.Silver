using Panuon.UI.Silver.Core;
using System.Collections.ObjectModel;
using System.Windows;

namespace UIBrowser.Models
{
    public class TreeViewItemModel : PropertyChangedBase
    {
        public TreeViewItemModel(string header, string tag, string icon = null)
        {
            Header = header;
            Tag = tag;
            Icon = icon;
            MenuItems = new ObservableCollection<TreeViewItemModel>();
        }

        public string Icon { get; set; }

        public string Header { get; set; }

        public string Tag { get; set; }

        public Visibility Visibility
        {
            get => _visibility;
            set { _visibility = value; NotifyPropertyChanged(); }
        }
        private Visibility _visibility = Visibility.Visible;

        public bool IsExpanded
        {
            get => _isExpanded;
            set { _isExpanded = value; NotifyPropertyChanged(); }
        }
        private bool _isExpanded = true;

        public ObservableCollection<TreeViewItemModel> MenuItems
        {
            get => _menuItems;
            set { _menuItems = value; NotifyPropertyChanged(); }
        }
        private ObservableCollection<TreeViewItemModel> _menuItems;

    }
}
