using Caliburn.Micro;
using System;
using System.Linq;
using UIBrowser.Core;
using UIBrowser.Core.Properties;
using UIBrowser.Models;

namespace UIBrowser.ViewModels.Partials
{
    public class IconViewModel : ViewModelBase, IPartialView
    {
        #region Ctor
        public IconViewModel()
        {
        }
        #endregion

        #region Overrides
        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            LoadFontItems();
        }
        #endregion

        #region Properties
        public string Caption => Resources.IconFont;

        public string[] LabelLevels => new string[] { Resources.Miscellaneous };

        #region FontItems
        public BindableCollection<FontItem> FontItems { get => _fontItems; set => Set(ref _fontItems, value); }
        private BindableCollection<FontItem> _fontItems;
        #endregion

        #region SelectedFontItem
        public FontItem SelectedFontItem { get => _selectedFontItem; set => Set(ref _selectedFontItem, value); }
        private FontItem _selectedFontItem;
        #endregion

        #endregion

        #region Function
        private void LoadFontItems()
        {
            FontItems = new BindableCollection<FontItem>();
            var start = Convert.ToInt32("e900", 16);
            for (int i = 0; i < 235; i++)
            {
                var value = start + i;
                var icon = value.ToString("X4").ToLower();
                FontItems.Add(new FontItem() { Icon = (char)value, Code = icon });
            }
            SelectedFontItem = FontItems.First();
        }
        #endregion
    }
}
