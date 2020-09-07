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

        public ColumnWidthAttribute(string width, double maxWidth)
            : this(width)
        {
            MaxWidth = maxWidth;
        }

        public ColumnWidthAttribute(string width, double maxWidth, double minWidth)
          : this(width, maxWidth)
        {
            MinWidth = minWidth;
        }
        #endregion

        #region Properties
        public DataGridLength Width { get; set; }

        public double? MaxWidth { get; set; }

        public double? MinWidth { get; set; }
        #endregion
    }
}
