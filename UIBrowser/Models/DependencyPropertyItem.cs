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
        public DependencyPropertyItem(string propertyName, object propertyValue)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }
        #endregion

        #region Property
        public string PropertyName { get; set; }

        public object PropertyValue { get; set; }
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
