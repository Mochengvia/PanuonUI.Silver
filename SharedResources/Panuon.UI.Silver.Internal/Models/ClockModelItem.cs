using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panuon.UI.Silver.Internal.Models
{


    internal class ClockModelItem : PropertyChangedBase
    {

        #region Properties
        public int Value { get => _value; set => SetValue(ref _value, value); }
        private int _value;

        public string DisplayName { get => _displayNumber; set => SetValue(ref _displayNumber, value); }
        private string _displayNumber;

        public bool IsEnabled { get => _isEnabled; set => SetValue(ref _isEnabled, value); }
        private bool _isEnabled;

        public bool IsChecked { get => _isChecked; set => SetValue(ref _isChecked, value); }
        private bool _isChecked;

        #endregion

    }
}
