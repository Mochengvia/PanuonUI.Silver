using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MenuItems = new BindableCollection<TreeViewItemModel>();
        }

        public string Icon { get; set; }

        public string Header { get; set; }

        public string Tag { get; set; }

        public Visibility Visibility
        {
            get { return _visibility; }
            set { _visibility = value; NotifyOfPropertyChange(); }
        }
        private Visibility _visibility = Visibility.Visible;

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { _isExpanded = value; NotifyOfPropertyChange(); }
        }
        private bool _isExpanded = true;

        public IObservableCollection<TreeViewItemModel> MenuItems
        {
            get { return _menuItems; }
            set { _menuItems = value; NotifyOfPropertyChange(); }
        }
        private IObservableCollection<TreeViewItemModel> _menuItems;

    }
}
