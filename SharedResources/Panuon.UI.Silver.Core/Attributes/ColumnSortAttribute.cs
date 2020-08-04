using System;

namespace Panuon.UI.Silver.Core
{
    public class ColumnSortAttribute : Attribute
    {
        #region Ctor
        public ColumnSortAttribute(bool canUserSort)
        {
            CanUserSort = canUserSort;
        }

        #endregion

        #region Properties
        public bool CanUserSort { get; set; }
        #endregion
    }
}
