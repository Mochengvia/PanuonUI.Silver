using Caliburn.Micro;
using Panuon.UI.Silver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UIBrowser.Components;
using UIBrowser.Core;
using UIBrowser.Core.Properties;
using UIBrowser.Models;

namespace UIBrowser.ViewModels.Partials
{
    public class FormViewModel : ViewModelBase, IPaletteView
    {
        #region Ctor
        public FormViewModel()
        {
        }
        #endregion

        #region Properties
        public string Caption => Resources.Form;

        public string[] LabelLevels => new string[] { Resources.NativeControls };

        public IDictionary<string, DependencyProperty> PaletteProperties => new Dictionary<string, DependencyProperty>
        {
        };

        public IList<DependencyProperty> GeneralProperties => new List<DependencyProperty>
        {
        };
        #region Header
        public string Header { get => _header; set => Set(ref _header, value); }
        private string _header = "1";
        #endregion 

        #endregion

    }
}
