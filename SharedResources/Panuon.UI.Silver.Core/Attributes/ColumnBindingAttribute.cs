using System;
using System.Windows.Data;

namespace Panuon.UI.Silver.Core
{

    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnBindingAttribute : Attribute
    {
        /// <summary>
        /// Custom binding mode.
        /// </summary>
        public ColumnBindingAttribute()
        {
            BindingMode = BindingMode.TwoWay;
            UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
        }

        /// <summary>
        /// Custom binding mode.
        /// </summary>
        public ColumnBindingAttribute(BindingMode bindingMode)
        {
            BindingMode = bindingMode;
            UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
        }

        /// <summary>
        /// Custom binding mode.
        /// </summary>
        public ColumnBindingAttribute(BindingMode bindingMode, UpdateSourceTrigger updateSourceTrigger)
        {
            BindingMode = bindingMode;
            UpdateSourceTrigger = updateSourceTrigger;
        }

        public BindingMode BindingMode { get; set; }

        public UpdateSourceTrigger UpdateSourceTrigger { get; set; }
    }
}
