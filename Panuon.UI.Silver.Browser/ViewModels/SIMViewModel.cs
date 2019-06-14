using Panuon.UI.Silver.Browser.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace Panuon.UI.Silver.Browser.ViewModels
{
    public class SIMViewModel : PropertyChangedBase
    {

        public SIMViewModel()
        {
            TreeViewItems = new ObservableCollection<TreeViewItemModel>();
            ComboBoxItems = new ObservableCollection<ComboBoxItemModel>();
            TagItems = new ObservableCollection<TagItemModel>();
        }

        #region Property
        public ObservableCollection<TreeViewItemModel> TreeViewItems
        {
            get { return _treeViewItems; }
            set { _treeViewItems = value; NotifyPropertyChanged("TreeViewItems"); }
        }
        private ObservableCollection<TreeViewItemModel> _treeViewItems;

        public ObservableCollection<ComboBoxItemModel> ComboBoxItems
        {
            get { return _comboBoxItems; }
            set { _comboBoxItems = value; NotifyPropertyChanged("ComboBoxItems"); }
        }
        private ObservableCollection<ComboBoxItemModel> _comboBoxItems;

        public ObservableCollection<TabItemModel> TabItems
        {
            get { return _tabItems; }
            set { _tabItems = value; NotifyPropertyChanged("TabItems"); }
        }
        private ObservableCollection<TabItemModel> _tabItems;

        public ObservableCollection<TagItemModel> TagItems
        {
            get { return _tagItems; }
            set { _tagItems = value; NotifyPropertyChanged("TagItems"); }
        }
        private ObservableCollection<TagItemModel> _tagItems;

        public ObservableCollection<TimelineItemModel> TimelineItems
        {
            get { return _timelineItems; }
            set { _timelineItems = value; NotifyPropertyChanged("TimelineItems"); }
        }
        private ObservableCollection<TimelineItemModel> _timelineItems;

        public ObservableCollection<PropertyModel> Properties
        {
            get { return _properties; }
            set { _properties = value; NotifyPropertyChanged("Properties"); }
        }
        private ObservableCollection<PropertyModel> _properties;

        #endregion
    }
}
