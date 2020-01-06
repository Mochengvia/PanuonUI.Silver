using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver.Internal.Utils
{
    internal static class GridLengthUtils
    {
        #region Identifier
        private static TypeConverter _tcGridLength;
        private static TypeConverter _tcDataGridLength;
        #endregion

        #region Ctor
        static GridLengthUtils()
        {
            _tcGridLength = TypeDescriptor.GetConverter(typeof(GridLength));
            _tcDataGridLength = TypeDescriptor.GetConverter(typeof(DataGridLength));
        }
        #endregion

        #region Methods
        public static GridLength ConvertToGridLength(string widthOrHeight)
        {
            try
            {
                return (GridLength)_tcGridLength.ConvertFromString(widthOrHeight);
            }
            catch
            {
                return new GridLength(1, GridUnitType.Auto);
            }
        }

        public static DataGridLength ConvertToDataGridLength(string widthOrHeight)
        {
            try
            {
                return (DataGridLength)_tcDataGridLength.ConvertFromString(widthOrHeight);
            }
            catch
            {
                return new DataGridLength(1, DataGridLengthUnitType.Auto);
            }
        }
        #endregion
    }
}
