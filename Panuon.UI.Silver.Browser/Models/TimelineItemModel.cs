
using System.Windows.Media;

namespace Panuon.UI.Silver.Browser.Models
{
    public class TabItemModel : PropertyChangedBase
    {
        #region Constructor
        public TabItemModel()
        {
        }

        public TabItemModel(string header)
        {
            Header = header;
        }
        #endregion

        #region Property
        public string Header
        {
            get { return _header; }
            set { _header = value; NotifyPropertyChanged("Header"); }
        }
        private string _header;
        #endregion
    }
}
