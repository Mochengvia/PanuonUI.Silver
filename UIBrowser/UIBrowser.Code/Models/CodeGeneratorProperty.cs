using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UIBrowser.Code
{
    public class CodeGeneratorProperty
    {
        public CodeGeneratorProperty(DependencyProperty property, object value)
        {
            Property = property;
            Value = value;
        }

        #region Properties
        public DependencyProperty Property { get; private set; }

        public object Value { get; set; }
        #endregion
    }
}
