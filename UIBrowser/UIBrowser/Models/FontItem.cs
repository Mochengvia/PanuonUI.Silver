using Caliburn.Micro;

namespace UIBrowser.Models
{
    public class FontItem : PropertyChangedBase
    {
        #region Icon
        public char Icon
        {
            get { return _icon; }
            set { _icon = value; NotifyOfPropertyChange(); }
        }
        private char _icon;
        #endregion

        #region Code
        public string Code
        {
            get { return _code; }
            set { _code = value; NotifyOfPropertyChange(); }
        }
        private string _code;
        #endregion
    }
}
