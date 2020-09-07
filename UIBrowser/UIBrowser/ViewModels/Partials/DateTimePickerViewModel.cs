using UIBrowser.Core;
using UIBrowser.Core.Properties;

namespace UIBrowser.ViewModels.Partials
{
    public class DateTimePickerViewModel : ViewModelBase, IPartialView
    {
        #region Properties
        public string Caption => Resources.DateTimePicker;

        public string[] LabelLevels => new string[] { Resources.CustomControls };

        #endregion
    }
}
