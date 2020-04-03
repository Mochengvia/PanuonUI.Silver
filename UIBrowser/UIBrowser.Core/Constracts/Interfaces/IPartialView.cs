using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIBrowser.Core
{
    public interface IPartialView
    {
        ControlType PaletteControlType { get; }

        bool IsPaletteEnabled { get; }

        event UpdatePaletteEventHandler UpdatePalette;
    }
}
