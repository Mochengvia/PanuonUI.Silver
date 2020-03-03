using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Panuon.UI.Silver.Core
{
    public abstract class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T identifer, T value, [CallerMemberName]string propertyName = null)
        {
            identifer = value;
            NotifyPropertyChanged(propertyName);
        }
    }
}
