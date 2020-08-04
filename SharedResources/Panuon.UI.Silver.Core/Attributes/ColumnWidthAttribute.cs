using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Windows.Controls;

namespace Panuon.UI.Silver.Core
{
    public class ColumnWidthAttribute : Attribute
    {
        #region Ctor
        public ColumnWidthAttribute(string width)
        {
            Width = GridLengthUtils.ConvertToDataGridLength(width);
        }
        #endregion

        #region Properties
        public DataGridLength Width { get; set; }
        #endregion
    }
}
