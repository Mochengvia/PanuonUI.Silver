using Panuon.UI.Silver.Browser.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Panuon.UI.Silver.Browser.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {

        public MainViewModel()
        {
            MenuItems = new ObservableCollection<TreeViewItemModel>();
        }

        #region Property
        public ObservableCollection<TreeViewItemModel> MenuItems
        {
            get { return _menuItems; }
            set { _menuItems = value; NotifyPropertyChanged("MenuItems"); }
        }
        private ObservableCollection<TreeViewItemModel> _menuItems;
        #endregion
    }
}
