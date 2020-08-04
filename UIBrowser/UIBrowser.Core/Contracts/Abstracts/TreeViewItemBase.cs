using Caliburn.Micro;

namespace UIBrowser.Core
{
    public abstract class TreeViewItemBase<T> : SearchableItemBase
        where T : SearchableItemBase
    {
        #region Properties

        #region Items
        public BindableCollection<T> Items { get => _items; set => Set(ref _items, value); }
        private BindableCollection<T> _items;
        #endregion

        #region IsExpanded
        public bool IsExpanded { get => _isExpanded; set => Set(ref _isExpanded, value); }
        private bool _isExpanded;
        #endregion

        #endregion

        #region Methods
        public new bool Search(string text)
        {
            var result = base.Search(text);
            if (Items != null)
            {
                foreach (var item in Items)
                {
                    var childResult = item.Search(text);
                    if (childResult)
                    {
                        result = true;
                    }
                }
            }
            if (result)
            {
                IsExpanded = true;
            }
            IsVisible = result;
            return result;
        }
        #endregion
    }
}
