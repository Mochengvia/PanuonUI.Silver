
using System.Windows.Media;

namespace Panuon.UI.Silver.Browser.Models
{
    public class TagItemModel : PropertyChangedBase
    {
        #region Constructor
        public TagItemModel()
        {
        }

        public TagItemModel(string content, Brush background = null)
        {
            Content = content;
            Background = background;
        }
        #endregion

        #region Property
        public string Content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged("Content"); }
        }
        private string _content;


        public bool CanDelete
        {
            get { return _canDelete; }
            set { _canDelete = value; NotifyPropertyChanged("CanDelete"); }
        }
        private bool _canDelete;


        public Brush Background
        {
            get { return _background; }
            set { _background = value; NotifyPropertyChanged("Background"); }
        }
        private Brush _background;
        #endregion
    }
}
