using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIBrowser.Models
{
    public class DependencyPropertyItem
    {
        #region Ctor
        public DependencyPropertyItem(string propertyName, object propertyValue, object defaultValue)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            DefaultValue = defaultValue;
        }
        #endregion

        #region Property
        public string PropertyName { get; set; }

        public object PropertyValue { get; set; }

        public object DefaultValue { get; set; }
        #endregion

        #region Methods
        public string ToSourceCode()
        {
            return $"{PropertyName}=\"{PropertyValue}\"";
        }

        public string ToStyleCode()
        {
            return $"<Setter Property=\"{PropertyName}\"\nValue=\"{PropertyValue}\" />";
        }
        #endregion
    }
}
