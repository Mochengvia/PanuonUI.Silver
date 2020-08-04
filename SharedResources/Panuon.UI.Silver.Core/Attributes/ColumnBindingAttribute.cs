using System;
using System.Windows.Data;

namespace Panuon.UI.Silver.Core
{
    public class ColumnBindingAttribute : Attribute
    {
        #region Ctor
        public ColumnBindingAttribute(BindingMode bindingMode, UpdateSourceTrigger updateSourceTrigger)
        {
            BindingMode = bindingMode;
            UpdateSourceTrigger = updateSourceTrigger;
        }
        #endregion

        #region Properties
        public UpdateSourceTrigger UpdateSourceTrigger { get; set; }

        public BindingMode BindingMode { get; set; }
        #endregion
    }
}
