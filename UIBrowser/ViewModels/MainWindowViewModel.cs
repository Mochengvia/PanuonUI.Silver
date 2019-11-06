using Panuon.UI.Silver.Core;
using System.Collections.ObjectModel;
using UIBrowser.Models;

namespace UIBrowser.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        public MainWindowViewModel()
        {
            MenuItems = new ObservableCollection<TreeViewItemModel>()
            {
                new TreeViewItemModel(Properties.Resource.Introduction,"Introduction", "\uf05a"),
                new TreeViewItemModel(Properties.Resource.Overview,"Overview", "\uf0eb"),
                new TreeViewItemModel(Properties.Resource.NativeControls,"NativeControls", "\uf17a")
                {
                     MenuItems = new ObservableCollection<TreeViewItemModel>()
                     {
                         new TreeViewItemModel(Properties.Resource.Button,"Button"),
                         new TreeViewItemModel(Properties.Resource.TextBox,"TextBox"),
                         new TreeViewItemModel(Properties.Resource.PasswordBox,"PasswordBox"),
                         new TreeViewItemModel(Properties.Resource.CheckBox,"CheckBox"),
                         new TreeViewItemModel(Properties.Resource.RadioButton,"RadioButton"),
                         new TreeViewItemModel(Properties.Resource.ComboBox,"ComboBox"),
                         new TreeViewItemModel(Properties.Resource.ProgressBar,"ProgressBar"),
                         new TreeViewItemModel(Properties.Resource.TabControl,"TabControl"),
                         new TreeViewItemModel(Properties.Resource.TreeView,"TreeView"),
                         new TreeViewItemModel(Properties.Resource.Slider,"Slider"),
                         new TreeViewItemModel(Properties.Resource.DataGrid,"DataGrid"),
                         new TreeViewItemModel(Properties.Resource.ContextMenu,"ContextMenu"),
                         new TreeViewItemModel(Properties.Resource.Menu,"Menu"),
                         new TreeViewItemModel(Properties.Resource.ListBox,"ListBox"),
                         new TreeViewItemModel(Properties.Resource.GroupBox,"GroupBox"),
                         new TreeViewItemModel(Properties.Resource.Expander,"Expander"),
                     }
                },
                new TreeViewItemModel(Properties.Resource.CustomControls,"CustomControls", "\uf040")
                {
                     MenuItems = new ObservableCollection<TreeViewItemModel>()
                     {
                         new TreeViewItemModel(Properties.Resource.WindowX,"WindowX"),
                         new TreeViewItemModel(Properties.Resource.MessageBoxX,"MessageBoxX"),
                         new TreeViewItemModel(Properties.Resource.PendingBox,"PendingBox"),
                         new TreeViewItemModel(Properties.Resource.MultiComboBox,"MultiComboBox"),
                         new TreeViewItemModel(Properties.Resource.Notice,"Notice"),
                         new TreeViewItemModel(Properties.Resource.Badge,"Badge"),
                         new TreeViewItemModel(Properties.Resource.Calendar,"Calendar"),
                         new TreeViewItemModel(Properties.Resource.DateTimePicker,"DateTimePicker"),
                         new TreeViewItemModel(Properties.Resource.ColorSelector,"ColorSelector"),
                         new TreeViewItemModel(Properties.Resource.ColorPicker,"ColorPicker"),
                         new TreeViewItemModel(Properties.Resource.DropDown,"DropDown"),
                         new TreeViewItemModel(Properties.Resource.Loading,"Loading"),
                         new TreeViewItemModel(Properties.Resource.Carousel,"Carousel"),
                         new TreeViewItemModel(Properties.Resource.WaterfallViewer,"WaterfallViewer"),
                         new TreeViewItemModel(Properties.Resource.Countdown,"Countdown"),
                         new TreeViewItemModel(Properties.Resource.Clock,"Clock"),
                         new TreeViewItemModel(Properties.Resource.ImageCuter,"ImageCuter"),
                         new TreeViewItemModel(Properties.Resource.NeonLabel,"NeonLabel"),
                         new TreeViewItemModel(Properties.Resource.Pagination,"Pagination"),
                         new TreeViewItemModel(Properties.Resource.Timeline,"Timeline"),
                     }
                },
                new TreeViewItemModel(Properties.Resource.ExtraHelpers,"ExtraHelpers", "\uf06b")
                {
                     MenuItems = new ObservableCollection<TreeViewItemModel>()
                     {
                         new TreeViewItemModel(Properties.Resource.AnimationHelper,"AnimationHelper"),
                         new TreeViewItemModel(Properties.Resource.LayoutHelper,"LayoutHelper"),
                     }
                }
            };
        }

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; NotifyPropertyChanged(); OnSearchTextChanged(); }
        }


        private string _searchText;

        public ObservableCollection<TreeViewItemModel> MenuItems { get; } = new ObservableCollection<TreeViewItemModel>();

        #region Event
        private void OnSearchTextChanged()
        {
            foreach (var item in MenuItems)
            {
                ChangeItemVisibility(item);
            }
        }

        private bool ChangeItemVisibility(TreeViewItemModel model)
        {
            var result = false;

            if (model.Header.ToLower().Contains(SearchText.ToLower()))
                result = true;

            if (model.MenuItems.Count != 0)
            {
                foreach (var item in model.MenuItems)
                {
                    var inner = ChangeItemVisibility(item);
                    result = result ? true : inner;
                }
            }

            model.Visibility = result ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            model.IsExpanded = result;
            return result;
        }

        #endregion

    }
}