using System.Collections.Generic;
using System.Windows;

namespace UIBrowser.Core
{
    public interface IPaletteView : IPartialView
    {
        IDictionary<string, DependencyProperty> PaletteProperties { get; }

        IList<DependencyProperty> GeneralProperties { get; }
    }
}
