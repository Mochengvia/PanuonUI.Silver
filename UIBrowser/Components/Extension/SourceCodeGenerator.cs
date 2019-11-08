using System;
using System.Collections.Generic;
using UIBrowser.Models;

namespace UIBrowser
{
    public static class SourceCodeGenerator
    {
        public static SourceElementCore NewElement(string elementName)
        {
            return new SourceElementCore(elementName);
        }

        public static SourceElementCore AddDependencyProperty(this SourceElementCore element, string propertyName, object propertyValue)
        {
            if (propertyValue is double)
                propertyValue = ((double)propertyValue).ToString("N1");

            element.DependencyProperties.Add(new DependencyPropertyItem(propertyName, propertyValue));
            return element;
        }

        public static SourceElementCore AddDependencyPropertyIf(this SourceElementCore element, string propertyName, object propertyValue, bool condition)
        {
            if (!condition)
                return element;

            if (propertyValue is double)
                propertyValue = ((double)propertyValue).ToString("N1");

            element.DependencyProperties.Add(new DependencyPropertyItem(propertyName, propertyValue));
            return element;
        }

        public static SourceElementCore AddAttachedProperty(this SourceElementCore element, Type attachedPropertyClassType, string propertyName, object propertyValue)
        {
            if (propertyValue is double)
                propertyValue = ((double)propertyValue).ToString("N1");

            element.AttachedProperties.Add(new AttachedPropertyItem(attachedPropertyClassType, propertyName, propertyValue));
            return element;
        }

        public static SourceElementCore AddAttachedPropertyIf(this SourceElementCore element, Type attachedPropertyClassType, string propertyName, object propertyValue, bool condition)
        {
            if (!condition)
                return element;

            if (propertyValue is double)
                propertyValue = ((double)propertyValue).ToString("N1");

            element.AttachedProperties.Add(new AttachedPropertyItem(attachedPropertyClassType, propertyName, propertyValue));
            return element;
        }
    }

    
}
