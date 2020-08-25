using UIBrowser.Core;
using UIBrowser.Core.Properties;

namespace UIBrowser.ViewModels.Partials
{
    public class DropdownViewModel : ViewModelBase, IPartialView
    {
        #region Properties
        public string Caption => Resources.Dropdown;

        public string[] LabelLevels => new string[] { Resources.CustomControls };

        #endregion
    }
}
