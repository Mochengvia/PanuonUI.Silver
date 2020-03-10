using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Panuon.UI.Silver
{
    public class FormTextGroupItem : FormGroupItem
    {
        #region Ctor
        static FormTextGroupItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FormTextGroupItem), new FrameworkPropertyMetadata(typeof(FormTextGroupItem)));
        }
        #endregion

        #region Properties

        #region Text
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(FormTextGroupItem), new FrameworkPropertyMetadata());
        #endregion

        #region Watermark
        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.Register("Watermark", typeof(string), typeof(FormTextGroupItem));
        #endregion

        #region IsReadOnly
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(FormTextGroupItem));
        #endregion

        #region TextBoxStyle
        public Style TextBoxStyle
        {
            get { return (Style)GetValue(TextBoxStyleProperty); }
            set { SetValue(TextBoxStyleProperty, value); }
        }

        public static readonly DependencyProperty TextBoxStyleProperty =
            DependencyProperty.Register("TextBoxStyle", typeof(Style), typeof(FormTextGroupItem));
        #endregion

        #endregion
    }
}
