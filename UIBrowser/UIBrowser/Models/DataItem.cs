using Panuon.UI.Silver.Core;
using System.Windows.Controls;
using UIBrowser.Components;

namespace UIBrowser.Models
{
    public class DataItem : PropertyChangedBase
    {
        #region Ctor
        public DataItem(string number, string displayName, Sex sex, bool isEnabled)
        {
            Number = number;
            DisplayName = displayName;
            Sex = sex;
            IsEnabled = isEnabled;
        }
        #endregion

        #region Properties

        #region Number
        public string Number { get => _number; set => Set(ref _number, value); }
        private string _number;
        #endregion
    
        #region DisplayName
        [ColumnWidth("*")]
        [ColumnTemplate(typeof(TextBox), nameof(TextBox.TextProperty))]
        public string DisplayName { get => _displayName; set => Set(ref _displayName, value); }
        private string _displayName;
        #endregion

        #region Sex
        public Sex Sex { get => _sex; set => Set(ref _sex, value); }
        private Sex _sex;
        #endregion 

        #region IsEnabled
        public bool IsEnabled { get => _isEnabled; set => Set(ref _isEnabled, value); }
        private bool _isEnabled;
        #endregion 

        #endregion

    }
}
