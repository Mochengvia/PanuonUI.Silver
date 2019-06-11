
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="background">HEX Color, like #3E3E3E</param>
        public TagItemModel(string content, string background = null)
        {
            Content = content;
            Background = background;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="background">Color background</param>
        public TagItemModel(string content, Color background)
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
        private bool _canDelete = true;


        public object Background
        {
            get { return _background; }
            set { _background = value; NotifyPropertyChanged("Background"); }
        }
        private object _background;
        #endregion
    }
}
