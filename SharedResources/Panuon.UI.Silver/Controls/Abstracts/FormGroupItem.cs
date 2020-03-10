using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver
{
    public abstract class FormGroupItem : Control, IFormItem
    {

        #region Properties

        #region GroupWidth
        public string GroupWidth
        {
            get { return (string)GetValue(GroupWidthProperty); }
            set { SetValue(GroupWidthProperty, value); }
        }

        public static readonly DependencyProperty GroupWidthProperty =
            DependencyProperty.Register("GroupWidth", typeof(string), typeof(FormGroupItem));
        #endregion

        #region HeaderWidth
        public string HeaderWidth
        {
            get { return (string)GetValue(HeaderWidthProperty); }
            set { SetValue(HeaderWidthProperty, value); }
        }

        public static readonly DependencyProperty HeaderWidthProperty =
            DependencyProperty.Register("HeaderWidth", typeof(string), typeof(FormGroupItem));
        #endregion

        #region HeaderHeight
        public string HeaderHeight
        {
            get { return (string)GetValue(HeaderHeightProperty); }
            set { SetValue(HeaderHeightProperty, value); }
        }

        public static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.Register("HeaderHeight", typeof(string), typeof(FormGroupItem));
        #endregion

        #region Header
        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(FormGroupItem));
        #endregion

        #region HeaderTemplate
        public DataTemplate HeaderTemplate
        {
            get { return (DataTemplate)GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }

        public static readonly DependencyProperty HeaderTemplateProperty =
            DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(FormGroupItem));
        #endregion

        #region HeaderTemplateSelector
        public DataTemplateSelector HeaderTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(HeaderTemplateSelectorProperty); }
            set { SetValue(HeaderTemplateSelectorProperty, value); }
        }

        public static readonly DependencyProperty HeaderTemplateSelectorProperty =
            DependencyProperty.Register("HeaderTemplateSelector", typeof(DataTemplateSelector), typeof(FormGroupItem));
        #endregion

        #region IsRequired
        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }

        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.Register("IsRequired", typeof(bool), typeof(FormGroupItem));
        #endregion

        #endregion
    }
}
