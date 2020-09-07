using UIBrowser.Core;
using UIBrowser.Core.Properties;

namespace UIBrowser.ViewModels.Partials
{
    public class DropDownViewModel : ViewModelBase, IPartialView
    {
        #region Properties
        public string Caption => Resources.DropDown;

        public string[] LabelLevels => new string[] { Resources.CustomControls };

        #endregion
    }
}
