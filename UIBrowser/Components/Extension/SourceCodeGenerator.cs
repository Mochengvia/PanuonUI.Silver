using System;
using System.Collections.Generic;
using UIBrowser.Models;

namespace UIBrowser
{
    public static class SourceCodeGenerator
    {
        public static SourceElementCore NewElement(string elementName, string baseStylePropertyName)
        {
            return new SourceElementCore(elementName, baseStylePropertyName);
        }

        public static SourceElementCore AddDependencyProperty(this SourceElementCore element, string propertyName, object propertyValue, object defaultValue)
        {
            if (propertyValue is double)
                propertyValue = double.Parse(((double)propertyValue).ToString("N1"));

            element.DependencyProperties.Add(new DependencyPropertyItem(propertyName, propertyValue, defaultValue));
            return element;
        }


        public static SourceElementCore AddAttachedProperty(this SourceElementCore element, Type attachedPropertyClassType, string propertyName, object propertyValue, object defaultValue)
        {
            if (propertyValue is double)
                propertyValue = double.Parse(((double)propertyValue).ToString("N1"));

            element.AttachedProperties.Add(new AttachedPropertyItem(attachedPropertyClassType, propertyName, propertyValue, defaultValue));
            return element;
        }
    }

    
}
