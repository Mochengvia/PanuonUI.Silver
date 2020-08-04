using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Panuon.UI.Silver.Core
{
    public abstract class PropertyChangedBase : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods

        #region NotifyOfPropertyChange
        public void NotifyOfPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NotifyOfPropertyChange<TProperty>(Expression<Func<TProperty>> property)
        {
            NotifyOfPropertyChange(property.Name);
        }
        #endregion

        #region Set
        public void Set<T>(ref T identifer, T value, [CallerMemberName] string propertyName = null)
        {
            identifer = value;
            NotifyOfPropertyChange(propertyName);
        }
        #endregion

        #endregion
    }
}
