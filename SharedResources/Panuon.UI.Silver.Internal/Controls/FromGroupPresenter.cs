using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Panuon.UI.Silver.Internal.Controls
{
    class FormGroupPresenter : ItemsControl
    {

        #region Form
        public Form Form
        {
            get { return (Form)GetValue(FormProperty); }
            set { SetValue(FormProperty, value); }
        }

        public static readonly DependencyProperty FormProperty =
            DependencyProperty.Register("Form", typeof(Form), typeof(FormGroupPresenter));
        #endregion


        protected override DependencyObject GetContainerForItemOverride()
        {
            return new FormGroupControl();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is FormGroupControl;
        }

        protected override void PrepareContainerForItemOverride(DependencyObject d, object item)
        {
            var element = d as FormGroupControl;
            var formGroup = item as FormGroup;
            BindingUtils.BindingProperty(element, FormGroupControl.HeaderProperty, formGroup, FormGroup.HeaderProperty);
            BindingUtils.BindingProperty(element, FormGroupControl.HeaderTemplateProperty, formGroup, FormGroup.HeaderTemplateProperty);
            BindingUtils.BindingProperty(element, FormGroupControl.HeaderTemplateSelectorProperty, formGroup, FormGroup.HeaderTemplateSelectorProperty);
            BindingUtils.BindingProperty(element, FormGroupControl.RowSpacingProperty, Form, Form.RowSpacingProperty);
            BindingUtils.BindingProperty(element, FormGroupControl.HeaderHeightProperty, formGroup, FormGroup.HeaderHeightProperty, Form, Form.HeaderHeightProperty);
            BindingUtils.BindingProperty(element, FormGroupControl.HeaderWidthProperty, formGroup, FormGroup.HeaderWidthProperty, Form, Form.HeaderWidthProperty);
            BindingUtils.BindingProperty(element, FormGroupControl.HeaderPaddingProperty, formGroup, FormGroup.HeaderPaddingProperty, Form, Form.HeaderPaddingProperty);
            BindingUtils.BindingProperty(element, FormGroupControl.HeightProperty, formGroup, FormGroup.HeightProperty, Form, Form.RowHeightProperty);

            //if(formGroup is FormTemplateGroup)
            //{
            //    var formTemplateGroup = formGroup as FormTemplateGroup;
            //    element.SetValue(FormGroupControl.ContentTemplateProperty, formTemplateGroup.ContentTemplate);
            //    element.SetValue(FormGroupControl.ContentTemplateSelectorProperty, formTemplateGroup.ContentTemplateSelector);
            //}
            //else 
            if (formGroup is FormTextGroup)
            {
                var formTextGroup = formGroup as FormTextGroup;
                element.SetValue(FormGroupControl.ContentTemplateProperty, CreateTextBoxTemplate(formTextGroup.TextBoxStyle, formTextGroup));
            }

            element.ActualHeaderWidthChanged += delegate
            {
                formGroup.ActualHeaderWidth = element.ActualHeaderWidth;
            };
        }

        private DataTemplate CreateTextBoxTemplate(Style textBoxStyle
            , FormTextGroup formTextGroup)
        {
            var binding = formTextGroup.Binding as Binding;
            var factory = new FrameworkElementFactory(typeof(TextBox));
            if (textBoxStyle != null)
            {
                factory.SetValue(TextBox.StyleProperty, textBoxStyle);
            }
            BindingUtils.BindingPropertyIfNonDefault(factory, TextBox.VerticalContentAlignmentProperty, formTextGroup, FormTextGroup.VerticalContentAlignmentProperty);
            BindingUtils.BindingPropertyIfNonDefault(factory, TextBox.PaddingProperty, formTextGroup, FormTextGroup.PaddingProperty);
            if (binding != null && binding.Source == null && string.IsNullOrEmpty(binding.ElementName))
            {
                ((Binding)binding).Source = DataContext;
                factory.SetBinding(TextBox.TextProperty, binding);
            }
            return new DataTemplate()
            {
                VisualTree = factory,
            };
        }
    }
}
