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

        public ColumnBindingAttribute(BindingMode bindingMode, UpdateSourceTrigger updateSourceTrigger, string stringFormat)
            : this(bindingMode, updateSourceTrigger)
        {
            StringFormat = stringFormat;
        }

        public ColumnBindingAttribute(string stringFormat)
        {
            StringFormat = stringFormat;
        }
        #endregion

        #region Properties
        public UpdateSourceTrigger UpdateSourceTrigger { get; set; }

        public BindingMode BindingMode { get; set; }

        public string StringFormat { get; set; }
        #endregion
    }
}
