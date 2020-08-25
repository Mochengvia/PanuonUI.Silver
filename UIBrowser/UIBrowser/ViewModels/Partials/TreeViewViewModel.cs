using UIBrowser.Core;
using UIBrowser.Core.Properties;

namespace UIBrowser.ViewModels.Partials
{
    public class TreeViewViewModel : ViewModelBase, IPartialView
    {
        #region Properties
        public string Caption => Resources.TreeView;

        public string[] LabelLevels => new string[] { Resources.NativeControls };

        #endregion
    }
}
