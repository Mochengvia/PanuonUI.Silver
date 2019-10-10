using System.ComponentModel;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class TagItemModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Constructor
        public TagItemModel()
        {
        }

        public TagItemModel(string content, Brush background = null, bool removable = true)
        {
            Content = content;
            Background = background;
            Removable = removable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="background">HEX Color, like #3E3E3E</param>
        public TagItemModel(string content, string background = null, bool removable = true)
        {
            Content = content;
            Background = background;
            Removable = removable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="background">Color background</param>
        public TagItemModel(string content, Color background, bool removable = true)
        {
            Content = content;
            Background = background;
            Removable = removable;
        }
        #endregion

        #region Property
        public string Content
        {
            get => _content;
            set { _content = value; NotifyPropertyChanged("Content"); }
        }
        private string _content;


        public bool Removable
        {
            get => _removable;
            set { _removable = value; NotifyPropertyChanged("Removable"); }
        }
        private bool _removable = true;


        public object Background
        {
            get => _background;
            set { _background = value; NotifyPropertyChanged("Background"); }
        }
        private object _background;
        #endregion
    }
}
