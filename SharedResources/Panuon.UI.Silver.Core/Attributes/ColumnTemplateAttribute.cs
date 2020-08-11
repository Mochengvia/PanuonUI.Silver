using System;
using System.Reflection;
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

        public ColumnTemplateAttribute(Type editingElementType, string editingBindingPropertyName, object editingElementStyleKey)
            : this(editingElementType, editingBindingPropertyName)
        {
            EditingElementStyleKey = editingElementStyleKey;
        }

        public ColumnTemplateAttribute(Type editingElementType, string editingBindingPropertyName, Type elementType, string bindingPropertyName)
            : this(editingElementType, editingBindingPropertyName)
        {
            ElementType = elementType;
            var bindingFieldInfo = elementType.GetField(bindingPropertyName, BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            BindingProperty = bindingFieldInfo?.GetValue(null) as DependencyProperty;
            if (BindingProperty == null)
            {
                throw new Exception($"Can not find property {bindingPropertyName} in type {elementType}.");
            }
        }

        public ColumnTemplateAttribute(Type editingElementType, string editingBindingPropertyName, object editingElementStyleKey, Type elementType, string bindingPropertyName, object elementStyleKey)
            : this(editingElementType, editingBindingPropertyName)
        {
            ElementStyleKey = elementStyleKey;
            EditingElementStyleKey = editingElementStyleKey;

            ElementType = elementType;
            var bindingFieldInfo = elementType.GetField(bindingPropertyName, BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            BindingProperty = bindingFieldInfo?.GetValue(null) as DependencyProperty;
            if (BindingProperty == null)
            {
                throw new Exception($"Can not find property {bindingPropertyName} in type {elementType}.");
            }
        }
        #endregion

        #region Properties
        public Type ElementType { get; set; }

        public object ElementStyleKey { get; set; }

        public Type EditingElementType { get; set; }

        public object EditingElementStyleKey { get; set; }

        public DependencyProperty BindingProperty { get; set; }

        public DependencyProperty EditingElementBindingProperty { get; set; }
        #endregion
    }
}
