using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIBrowser.Core;
using UIBrowser.Palette.Constracts.Interfaces;
using UIBrowser.Palette.ViewModels.Partials;

namespace UIBrowser.Palette.ViewModels
{
    public class PaletteViewModel : Screen, IShell
    {

        #region Properties

        #region PaletteControlType
        public ControlType PaletteControlType
        {
            set
            {
                UpdateScreen(value);
            }
        }
        #endregion

        #region ScreenViewModel
        public IPaletteView ScreenViewModel
        {
            get { return _screenViewModel; }
            set { _screenViewModel = value; NotifyOfPropertyChange(); }
        }
        private IPaletteView _screenViewModel;
        #endregion

        #region SelectedIndex
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                NotifyOfPropertyChange();
                switch (value)
                {
                    case 1:
                        UpdateXamlCode();
                        break;
                    case 2:
                        UpdateStyleCode();
                        break;
                }
            }
        }
        private int _selectedIndex;
        #endregion

        #region XamlCode
        public string XamlCode
        {
            get { return _xamlCode; }
            set { _xamlCode = value; NotifyOfPropertyChange(); }
        }
        private string _xamlCode;
        #endregion

        #region StyleCode
        public string StyleCode
        {
            get { return _styleCode; }
            set { _styleCode = value; NotifyOfPropertyChange(); }
        }
        private string _styleCode;
        #endregion

        #endregion

        #region Methods
        public void UpdateValues(IDictionary<PaletteComponent, object> values)
        {
            ScreenViewModel.UpdateValues(values);
            switch (SelectedIndex)
            {
                case 1:
                    UpdateXamlCode();
                    break;
                case 2:
                    UpdateStyleCode();
                    break;
            }
        }

        #endregion

        #region Function
        private void UpdateScreen(ControlType paletteControlType)
        {
            switch (paletteControlType)
            {
                case ControlType.IconFont:
                    ScreenViewModel = new IconFontViewModel();
                    break;
            }
        }

        private void UpdateXamlCode()
        {
            if(ScreenViewModel != null)
            {
                XamlCode = ScreenViewModel.CodeGenerator.ToXamlCode();
            }
        }

        private void UpdateStyleCode()
        {
            if (ScreenViewModel != null)
            {
               StyleCode =  ScreenViewModel.CodeGenerator.ToStyleCode();
            }
        }
        #endregion
    }
}
