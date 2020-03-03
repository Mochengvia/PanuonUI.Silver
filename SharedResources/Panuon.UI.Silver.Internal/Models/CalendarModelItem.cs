using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panuon.UI.Silver.Internal.Models
{


    internal class CalendarXModelItem : PropertyChangedBase
    {

        #region Properties
        public DateTime Value
        {
            get { return _value; }
            set { _value = value; NotifyPropertyChanged(); }
        }
        private DateTime _value;

        public string DisplayName
        {
            get { return _displayNumber; }
            set { _displayNumber = value; NotifyPropertyChanged(); }
        }
        private string _displayNumber;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; NotifyPropertyChanged(); }
        }
        private bool _isEnabled;

        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; NotifyPropertyChanged(); }
        }
        private bool _isChecked;


        public bool IsNotCurrentMonth
        {
            get { return _isNotCurrentMonth; }
            set { _isNotCurrentMonth = value; NotifyPropertyChanged(); }
        }
        private bool _isNotCurrentMonth;

        #endregion

    }
}
