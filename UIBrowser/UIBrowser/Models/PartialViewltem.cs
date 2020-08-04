using System;
using UIBrowser.Core;
using System.Linq;

namespace UIBrowser.Models
{
    public class PartialViewltem : TreeViewItemBase<PartialViewltem>
    {
        #region ViewType
        public Type ViewType { get => _viewType; set => Set(ref _viewType, value); }
        private Type _viewType;
        #endregion

        #region Instance
        public IPartialView Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = Activator.CreateInstance(ViewType) as IPartialView;
                }
                return _instance;
            }
        }
        private IPartialView _instance;
        #endregion 
    } 
}
