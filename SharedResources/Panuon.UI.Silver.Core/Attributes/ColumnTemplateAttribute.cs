using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class ColumnTemplateAttribute : Attribute
    {

        #region Ctor

        public ColumnTemplateAttribute(Type editingElementType, string editingBindingPropertyName)
        {
            EditingElementType = editingElementType;

            var fieldInfo = editingElementType.GetField(editingBindingPropertyName, BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            EditingElementBindingProperty = fieldInfo?.GetValue(null) as DependencyProperty;
            if(EditingElementBindingProperty == null)
            {
                throw new Exception($"Can not find property {editingBindingPropertyName} in type {editingElementType}.");
            }
        }

        public ColumnTemplateAttribute(Type elementType, string bindingPropertyName, Type editingElementType, string editingBindingPropertyName)
        {
            ElementType = elementType;
            var bindingFieldInfo = elementType.GetField(bindingPropertyName, BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            BindingProperty = bindingFieldInfo?.GetValue(null) as DependencyProperty;
            if (BindingProperty == null)
            {
                throw new Exception($"Can not find property {bindingPropertyName} in type {elementType}.");
            }

            EditingElementType = editingElementType;

            var editingFieldInfo = editingElementType.GetField(editingBindingPropertyName, BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            EditingElementBindingProperty = editingFieldInfo?.GetValue(null) as DependencyProperty;
            if (EditingElementBindingProperty == null)
            {
                throw new Exception($"Can not find property {editingBindingPropertyName} in type {editingElementType}.");
            }
        }

        #endregion

        #region Properties
        public Type ElementType { get; set; }

        public Type EditingElementType { get; set; }

        public DependencyProperty BindingProperty { get; set; }

        public DependencyProperty EditingElementBindingProperty { get; set; }
        #endregion
    }
}
