using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using UIBrowser.Core;
using UIBrowser.Models;
using UIBrowser.Palette.ViewModels;
using UIBrowser.Utils;

namespace UIBrowser.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<IShell>.Collection.OneActive, IShell
    {
        #region Fields
        private static List<Type> _viewIndexList;
        #endregion

        #region Ctor
        [ImportingConstructor]
        public ShellViewModel()
        {
            LoadPartialViews();
        }

        static ShellViewModel()
        {
            _viewIndexList = new List<Type>()
            {
                typeof(Views.Partials.Customs.WindowXView)
            };
        }

        #endregion

        #region Properties

        #region PartialViews
        public BindableCollection<PartialViewItem> PartialViews { get; private set; } = new BindableCollection<PartialViewItem>();
        #endregion

        #region SelectedPartialView
        public PartialViewItem SelectedPartialView
        {
            get { return _selectedPartialView; }
            set { _selectedPartialView = value; NotifyOfPropertyChange(); ActivateView(value.ViewType); }
        }
        private PartialViewItem _selectedPartialView;
        #endregion

        #region SearchText
        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; NotifyOfPropertyChange(); }
        }
        private string _searchText;
        #endregion

        #region PaletteViewModel
        public PaletteViewModel PaletteViewModel { get; private set; } = new PaletteViewModel();
        #endregion

        #region IsPaletteOpen
        public bool IsPaletteOpen
        {
            get { return _isPaletteOpen; }
            set { _isPaletteOpen = value; NotifyOfPropertyChange(); }
        }
        private bool _isPaletteOpen;
        #endregion

        #region IsPaletteEnabled
        public bool IsPaletteEnabled
        {
            get { return _isPaletteEnabled; }
            set { _isPaletteEnabled = value; NotifyOfPropertyChange(); }
        }
        private bool _isPaletteEnabled;
        #endregion

        #endregion

        #region Methods
        #endregion

        #region Function
        private void LoadPartialViews()
        {
            ViewUtils.GetViewInfos()
                .OrderBy(x => _viewIndexList.IndexOf(x.ViewType)).ToList()
               .ForEach(x => PartialViews.Add(new PartialViewItem() { DisplayName = Localization.Properties.Resources.ResourceManager.GetString(x.DisplayName), ViewType = x.ViewType }));

            SelectedPartialView = PartialViews.FirstOrDefault();
        }

        private void ActivateView(Type viewType)
        {
            var view = Activator.CreateInstance(viewType);
            ActivateItem(view as IShell);
            if(view is IPartialView)
            {
                PaletteViewModel.PaletteControlType = (view as IPartialView).PaletteControlType;
                IsPaletteEnabled = (view as IPartialView).IsPaletteEnabled;
                if (!(view as IPartialView).IsPaletteEnabled)
                {
                    IsPaletteOpen = false;
                }

                (view as IPartialView).UpdatePalette -= ShellViewModel_UpdatePalette;
                (view as IPartialView).UpdatePalette += ShellViewModel_UpdatePalette;
            }
        }

        private void ShellViewModel_UpdatePalette(object sender, UpdatePaletteEventArgs e)
        {
            PaletteViewModel.UpdateValues(e.Values);
        }

        #endregion
    }
}
