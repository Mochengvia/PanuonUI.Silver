using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver
{
    public class FormGroup : ContentControl
    {
        #region Ctor
        static FormGroup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FormGroup), new FrameworkPropertyMetadata(typeof(FormGroup)));
        }
        #endregion

        #region Property
        /// <summary>
        /// Gets or sets header.
        /// </summary>
        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(FormGroup));


        public static DataTemplate GetHeaderTemplate(DependencyObject obj)
        {
            return (DataTemplate)obj.GetValue(HeaderTemplateProperty);
        }

        public static void SetHeaderTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(HeaderTemplateProperty, value);
        }

        public static readonly DependencyProperty HeaderTemplateProperty =
            DependencyProperty.RegisterAttached("HeaderTemplate", typeof(DataTemplate), typeof(FormGroup));



        public static DataTemplateSelector GetHeaderTemplateSelector(DependencyObject obj)
        {
            return (DataTemplateSelector)obj.GetValue(HeaderTemplateSelectorProperty);
        }

        public static void SetHeaderTemplateSelector(DependencyObject obj, DataTemplateSelector value)
        {
            obj.SetValue(HeaderTemplateSelectorProperty, value);
        }

        public static readonly DependencyProperty HeaderTemplateSelectorProperty =
            DependencyProperty.RegisterAttached("HeaderTemplateSelector", typeof(DataTemplateSelector), typeof(FormGroup));

        public string HeaderWidth
        {
            get { return (string)GetValue(HeaderWidthProperty); }
            set { SetValue(HeaderWidthProperty, value); }
        }

        public static readonly DependencyProperty HeaderWidthProperty =
            DependencyProperty.Register("HeaderWidth", typeof(string), typeof(FormGroup));



        public string HeaderHeight
        {
            get { return (string)GetValue(HeaderHeightProperty); }
            set { SetValue(HeaderHeightProperty, value); }
        }

        public static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.Register("HeaderHeight", typeof(string), typeof(FormGroup));


        /// <summary>
        /// Gets or sets orientation.
        /// </summary>
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(FormGroup));

        /// <summary>
        /// Gets or sets is required.
        /// </summary>
        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }

        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.Register("IsRequired", typeof(bool), typeof(FormGroup));
        #endregion


    }
}
