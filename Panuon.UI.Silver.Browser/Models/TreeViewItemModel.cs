using System.Collections.ObjectModel;
using System.Windows;

namespace Panuon.UI.Silver.Browser.Models
{
    public class TreeViewItemModel : PropertyChangedBase
    {
        #region Constructor
        public TreeViewItemModel()
        {
            Items = new ObservableCollection<TreeViewItemModel>();
        }

        public TreeViewItemModel(string header) : this()
        {
            Header = header;
        }

        public TreeViewItemModel(string header, object value, bool isSelected = false) : this(header)
        {
            Value = value;
            IsSelected = isSelected;
        }

        public TreeViewItemModel(string header, object value, Thickness padding, bool isSelected = false) : this(header)
        {
            Value = value;
            IsSelected = isSelected;
            Padding = padding;
        }
        #endregion

        #region Property
        public string Header
        {
            get { return _header; }
            set { _header = value; NotifyPropertyChanged("Header"); }
        }
        private string _header;

        public object Value
        {
            get { return _value; }
            set { _value = value; NotifyPropertyChanged("Value"); }
        }
        private object _value;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; NotifyPropertyChanged("IsSelected"); }
        }
        private bool _isSelected;

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { _isExpanded = value; NotifyPropertyChanged("IsExpanded"); }
        }
        private bool _isExpanded;

        public Thickness Padding
        {
            get { return _padding; }
            set { _padding = value; NotifyPropertyChanged("Padding"); }
        }
        private Thickness _padding;

        public ObservableCollection<TreeViewItemModel> Items
        {
            get { return _items; }
            set { _items = value; NotifyPropertyChanged("Items"); }
        }
        private ObservableCollection<TreeViewItemModel> _items;

        #endregion
    }
}
