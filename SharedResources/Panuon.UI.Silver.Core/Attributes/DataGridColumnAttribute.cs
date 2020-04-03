using System;
using System.Windows.Data;


namespace Panuon.UI.Silver.Core
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataGridColumnAttribute : Attribute
    {
        #region Ctor
        public DataGridColumnAttribute(string columnWidth, bool ignore = false, bool readOnly = false, BindingMode? bindingMode = null, UpdateSourceTrigger? updateSourceTrigger = null)
        {
            ColumnWidth = columnWidth;
            Ignore = ignore;
            ReadOnly = readOnly;
            BindingMode = bindingMode;
            UpdateSourceTrigger = updateSourceTrigger;
        }

        public DataGridColumnAttribute(string columnWidth)
        {
            ColumnWidth = columnWidth;
        }

        public DataGridColumnAttribute(string columnWidth, bool ignore)
        {
            ColumnWidth = columnWidth;
            Ignore = ignore;
        }

        public DataGridColumnAttribute(bool ignore)
        {
            Ignore = ignore;
        }

        public DataGridColumnAttribute(bool ignore, bool readOnly)
        {
            Ignore = ignore;
            ReadOnly = readOnly;
        }

        public DataGridColumnAttribute(BindingMode? bindingMode)
        {
            BindingMode = bindingMode;
        }

        public DataGridColumnAttribute(UpdateSourceTrigger? updateSourceTrigger) 
        {
            UpdateSourceTrigger = updateSourceTrigger;
        }
        #endregion

        #region Properties
        public string ColumnWidth { get; set; }

        public bool Ignore { get; set; }

        public bool ReadOnly { get; set; }

        public BindingMode? BindingMode { get; set; }

        public UpdateSourceTrigger? UpdateSourceTrigger { get; set; }
        #endregion
    }
}
