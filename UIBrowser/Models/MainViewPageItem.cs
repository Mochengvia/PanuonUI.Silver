using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIBrowser.Models
{
    public class MainViewPageItem : TreeViewItemBase
    {
        #region Ctor
        public MainViewPageItem()
        {
            Visibility = System.Windows.Visibility.Visible;
        }

        public MainViewPageItem(string displayName) : this()
        {
            DisplayName = displayName;
        }

        public MainViewPageItem(string displayName, Type pageType) : this()
        {
            DisplayName = displayName;
            PageType = pageType;
        }
        #endregion

        #region PageType
        public Type PageType
        {
            get { return _pageType; }
            set { _pageType = value; NotifyPropertyChanged(); }
        }
        private Type _pageType;
        #endregion

        #region Items
        public ObservableCollection<MainViewPageItem> Items { get; } = new ObservableCollection<MainViewPageItem>();
        #endregion
    }
}
