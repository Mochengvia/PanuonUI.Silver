using System.Windows;
using System.Windows.Data;

namespace Panuon.UI.Silver
{
    public class FormCheckBoxGroup : FormGroup
    {
        #region Ctor
        static FormCheckBoxGroup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FormCheckBoxGroup), new FrameworkPropertyMetadata(typeof(FormCheckBoxGroup)));
        }
        #endregion

        #region Properties

        #region IsChecked
        public bool? IsChecked
        {
            get { return (bool?)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool?), typeof(FormCheckBoxGroup), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region Content
        public string Content
        {
            get { return (string)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(string), typeof(FormCheckBoxGroup));
        #endregion

        #region CheckedContent
        public object CheckedContent
        {
            get { return (object)GetValue(CheckedContentProperty); }
            set { SetValue(CheckedContentProperty, value); }
        }

        public static readonly DependencyProperty CheckedContentProperty =
            DependencyProperty.Register("CheckedContent", typeof(object), typeof(FormCheckBoxGroup));
        #endregion

        #region CheckBoxStyle
        public Style CheckBoxStyle
        {
            get { return (Style)GetValue(CheckBoxStyleProperty); }
            set { SetValue(CheckBoxStyleProperty, value); }
        }

        public static readonly DependencyProperty CheckBoxStyleProperty =
            DependencyProperty.Register("CheckBoxStyle", typeof(Style), typeof(FormCheckBoxGroup));
        #endregion

        #endregion
    }
}
