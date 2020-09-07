using Caliburn.Micro;
using Panuon.UI.Silver;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UIBrowser.Core;
using UIBrowser.Core.Properties;

namespace UIBrowser.ViewModels.Partials
{
    public class SwitchCheckBoxViewModel : ViewModelBase, IPaletteView
    {
        #region Properties
        public string Caption => Resources.SwitchCheckBox;

        public string[] LabelLevels => new string[] { Resources.CustomControls };

        public IDictionary<string, DependencyProperty> PaletteProperties => new Dictionary<string, DependencyProperty>
        {
       
        };

        public IList<DependencyProperty> GeneralProperties => new List<DependencyProperty>
        {
           
        };

        #endregion

        public SwitchCheckBoxViewModel()
        {
        }
    }
}
