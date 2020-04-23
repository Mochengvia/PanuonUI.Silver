using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using UIBrowser.Core;
using UIBrowser.Models;

namespace UIBrowser.ViewModels.Partials.Miscellaneous
{
    public class IconFontViewModel : Screen, IShell, IPartialView
    {
        #region Fields
        #endregion

        #region Ctor
        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            LoadFonts();
        }
        #endregion

        #region Events
        public event UpdatePaletteEventHandler UpdatePalette;
        #endregion

        #region Properties
        public bool IsPaletteEnabled => true;

        #region Fonts
        public BindableCollection<FontItem> Fonts { get; private set; } = new BindableCollection<FontItem>();

        public FontItem SelectedFont
        {
            get { return _selectedFont; }
            set
            {
                _selectedFont = value;
                NotifyOfPropertyChange(); 
                if(value != null)
                {
                    RaiseUpdatePalette(value.Icon);
                }
            }
        }
        private FontItem _selectedFont;

        #endregion

        #region Foreground

        public Brush Foreground
        {
            get { return _foreground; }
            set { _foreground = value;  NotifyOfPropertyChange(); }
        }
        private Brush _foreground;

        #endregion

        #region PaletteControlType
        public ControlType PaletteControlType { get { return ControlType.IconFont; } }
        #endregion

        #endregion

        #region Function
        private void LoadFonts()
        {
            var start = Convert.ToInt32("e900", 16);
            for (int i = 0; i < 235; i++)
            {
                var value = start + i;
                var icon = value.ToString("X4").ToLower();
                Fonts.Add(new FontItem() { Icon = (char)value, Code = icon });
            }
            SelectedFont = Fonts.First();
        }

        private void RaiseUpdatePalette(char icon)
        {
            UpdatePalette?.Invoke(this, new UpdatePaletteEventArgs(new Dictionary<PaletteComponent, object>
            {
                { PaletteComponent.Content, icon }
            }));
        }
        #endregion
    }
}
