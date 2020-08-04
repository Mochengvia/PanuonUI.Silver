using System.Windows;

namespace Panuon.UI.Silver.Internal.Utils
{
    static class DependencyPropertyUtils
    {
        #region Methods
        internal static bool IsDefaultValue(DependencyObject d, DependencyProperty dp)
        {
            return DependencyPropertyHelper.GetValueSource(d, dp).BaseValueSource == BaseValueSource.Default;
        }
        #endregion
    }
}
