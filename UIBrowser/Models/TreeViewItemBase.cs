using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UIBrowser.Models
{
    public class TreeViewItemBase : PropertyChangedBase
    {
        #region DisplayName & MatchedDisplayName
        /// <summary>
        /// Gets or sets display name.
        /// </summary>
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; NotifyPropertyChanged(); }
        }
        private string _displayName;

        /// <summary>
        /// Gets or sets matched display name.
        /// </summary>
        public string MatchedDisplayName
        {
            get { return _matchedDisplayName; }
            set { _matchedDisplayName = value; NotifyPropertyChanged(); }
        }
        private string _matchedDisplayName;
        #endregion

        #region IsSelected & IsExpanded & Visibility
        /// <summary>
        /// Gets or sets isselected.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; NotifyPropertyChanged(); }
        }
        private bool _isSelected;

        /// <summary>
        /// Gets or sets isexpanded.
        /// </summary>
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { _isExpanded = value; NotifyPropertyChanged(); }
        }
        private bool _isExpanded;

        /// <summary>
        /// Gets or sets visibility
        /// </summary>
        public Visibility Visibility
        {
            get { return _visibility; }
            set { _visibility = value; NotifyPropertyChanged(); }
        }
        private Visibility _visibility;
        #endregion
    }
}
