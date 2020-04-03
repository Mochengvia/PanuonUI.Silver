using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIBrowser.Models
{
    public class PartialViewItem : PropertyChangedBase
    {
        #region DisplayName
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; NotifyOfPropertyChange(); }
        }
        private string _displayName;
        #endregion

        #region IsVisible
        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; NotifyOfPropertyChange(); }
        }
        private bool _isVisible = true;
        #endregion

        #region ViewType
        public Type ViewType { get; set; }
        #endregion


    }
}
