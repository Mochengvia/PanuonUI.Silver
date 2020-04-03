using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIBrowser.Core;

namespace UIBrowser.ViewModels.Partials.Customs
{
    public  class WindowXViewModel : Screen, IShell, IPartialView
    {
        #region Event
        public event UpdatePaletteEventHandler UpdatePalette;
        #endregion

        #region Properties

        #region PaletteControlType
        public ControlType PaletteControlType { get { return ControlType.WindowX; } }

        public bool IsPaletteEnabled => true;

        #endregion

        #endregion
    }
}
