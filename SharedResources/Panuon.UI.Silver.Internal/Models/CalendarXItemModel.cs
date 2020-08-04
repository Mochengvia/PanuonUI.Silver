using Panuon.UI.Silver.Core;
using System;

namespace Panuon.UI.Silver.Internal.Models
{
    internal class CalendarXItemModel : PropertyChangedBase
    {
        #region Ctor
        #endregion

        #region Properties

        #region IsSelected
        public bool IsChecked 
        { 
            get => _isChecked;
            set
            {
                if(_isChecked != value)
                {
                    Set(ref _isChecked, value);
                }
            }
        }
        private bool _isChecked;
        #endregion

        #region Content
        public object Content { get => _content; set => Set(ref _content, value); }
        private object _content;
        #endregion

        #region Value
        public DateTime Value { get; set; }
        #endregion

        #region IsToday
        public bool IsToday { get => _isToday; set => Set(ref _isToday, value); }
        private bool _isToday;
        #endregion

        #region IsEnabled
        public bool IsEnabled { get => _isEnabled; set => Set(ref _isEnabled, value); }
        private bool _isEnabled;
        #endregion

        #region IsWeakenDisplay
        public bool IsWeakenDisplay { get => _isWeakenDisplay; set => Set(ref _isWeakenDisplay, value); }
        private bool _isWeakenDisplay;
        #endregion 

        #endregion

    }
}
