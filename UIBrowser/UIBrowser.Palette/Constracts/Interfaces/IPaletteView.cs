using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIBrowser.Code;
using UIBrowser.Core;

namespace UIBrowser.Palette.Constracts.Interfaces
{
    public interface IPaletteView
    {
        CodeGenerator CodeGenerator { get; }

        PaletteComponent GetAvaiableComponents();

        void UpdateValues(IDictionary<PaletteComponent, object> values);
    }
}
