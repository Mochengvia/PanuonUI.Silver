using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver.Utils
{
    internal class GridLengthUtil
    {
        private static TypeConverter _tcGridLength;
        private static TypeConverter _tcDataGridLength;


        static GridLengthUtil()
        {
            _tcGridLength = TypeDescriptor.GetConverter(typeof(GridLength));
            _tcDataGridLength = TypeDescriptor.GetConverter(typeof(DataGridLength));
        }

        public static GridLength ConvertToGridLength(string widthOrHeight)
        {
            try
            {
                if (string.IsNullOrEmpty(widthOrHeight) || 
                    widthOrHeight.Equals("NaN", StringComparison.OrdinalIgnoreCase)) 
                    return new GridLength(1, GridUnitType.Auto);
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
                if (string.IsNullOrEmpty(widthOrHeight) || 
                    widthOrHeight.Equals("NaN", StringComparison.OrdinalIgnoreCase)) 
                    return new DataGridLength(1, DataGridLengthUnitType.Auto);
                return (DataGridLength)_tcDataGridLength.ConvertFromString(widthOrHeight);
            }
            catch (Exception ex)
            {
                return new DataGridLength(1, DataGridLengthUnitType.Auto);
            }
        }
    }
}
