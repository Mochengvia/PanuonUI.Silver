using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Panuon.UI.Silver
{
    [ContentProperty(nameof(ContentTemplate))]
    public class FormTemplateGroup : FormGroup
    {
        #region Properties

        #region ContentTemplate
        public DataTemplate ContentTemplate
        {
            get { return (DataTemplate)GetValue(ContentTemplateProperty); }
            set { SetValue(ContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty ContentTemplateProperty =
            DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(FormTemplateGroup));
        #endregion

        #region ContentTemplateSelector
        public DataTemplateSelector ContentTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(ContentTemplateSelectorProperty); }
            set { SetValue(ContentTemplateSelectorProperty, value); }
        }

        public static readonly DependencyProperty ContentTemplateSelectorProperty =
            DependencyProperty.Register("ContentTemplateSelector", typeof(DataTemplateSelector), typeof(FormTemplateGroup));
        #endregion

        #endregion

        #region Methods
        #endregion

        #region Event Handlers
        #endregion

        #region Functions
        #endregion
    }
}
