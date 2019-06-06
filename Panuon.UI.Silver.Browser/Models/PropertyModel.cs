using Panuon.UI.Silver.Browser.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panuon.UI.Silver.Browser.Models
{
    public class PropertyModel
    {
        public PropertyModel(string propertyName, string propertyType, string defaultValue)
        {
            PropertyName = propertyName;
            PropertyType = propertyType;
            DefaultValue = defaultValue;
            Description = MainWindow.GetString("PROP_" + propertyName);
        }

        public string PropertyName { get; set; }

        public string PropertyType { get; set; }

        public string DefaultValue { get; set; }

        public string Description { get; set; }
    }
}
