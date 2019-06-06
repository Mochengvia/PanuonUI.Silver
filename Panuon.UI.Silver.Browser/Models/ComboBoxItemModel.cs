
namespace Panuon.UI.Silver.Browser.Models
{
    public class ComboBoxItemModel : PropertyChangedBase
    {
        #region Constructor
        public ComboBoxItemModel()
        {
        }

        public ComboBoxItemModel(string content)
        {
            Content = content;
        }
        #endregion

        #region Property
        public string Content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged("Content"); }
        }
        private string _content;
        #endregion
    }
}
