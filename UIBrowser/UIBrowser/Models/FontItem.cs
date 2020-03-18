using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
