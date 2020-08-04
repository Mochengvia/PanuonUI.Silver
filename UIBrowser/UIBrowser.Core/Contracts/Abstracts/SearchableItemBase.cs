using Caliburn.Micro;
using System;

namespace UIBrowser.Core
{
    public abstract class SearchableItemBase : PropertyChangedBase
    {
        #region Properties

        #region DisplayName
        public string DisplayName { get => _displayName; set => Set(ref _displayName, value); }
        private string _displayName;
        #endregion

        #region MatchedDisplayName
        public string MatchedDisplayName { get => _matchedDisplayName; set => Set(ref _matchedDisplayName, value); }
        private string _matchedDisplayName;
        #endregion 

        #region IsVisible
        public bool IsVisible { get => _isVisible; set => Set(ref _isVisible, value); }
        private bool _isVisible = true;
        #endregion 

        #endregion

        #region Methods
        public bool Search(string text)
        {
            var isMatched = false;
            if (string.IsNullOrEmpty(text))
            {
                MatchedDisplayName = null;
                isMatched = true;
            }
            else
            {
                if (!string.IsNullOrEmpty(DisplayName))
                {
                    var index = DisplayName.IndexOf(text, StringComparison.CurrentCultureIgnoreCase);
                    if (index >= 0)
                    {
                        MatchedDisplayName = DisplayName.Substring(index, text.Length);
                        isMatched = true;
                    }
                }
                else
                {
                    MatchedDisplayName = null;
                }
            }
            IsVisible = isMatched;
            return isMatched;
        }
        #endregion
    }
}
