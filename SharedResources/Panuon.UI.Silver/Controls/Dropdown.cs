using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class DropDown : ContentControl
    {
        #region Ctor
        static DropDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DropDown), new FrameworkPropertyMetadata(typeof(DropDown)));
        }
        #endregion

        #region RoutedEvents
        public event RoutedEventHandler Opened
        {
            add { AddHandler(OpenedEvent, value); }
            remove { RemoveHandler(OpenedEvent, value); }
        }

        public static readonly RoutedEvent OpenedEvent =
            EventManager.RegisterRoutedEvent("Opened", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DropDown));


        public event RoutedEventHandler Closed
        {
            add { AddHandler(ClosedEvent, value); }
            remove { RemoveHandler(ClosedEvent, value); }
        }

        public static readonly RoutedEvent ClosedEvent =
            EventManager.RegisterRoutedEvent("Closed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DropDown));
        #endregion

        #region Properties

        #region ContentContainerStyle
        public Style ContentContainerStyle
        {
            get { return (Style)GetValue(ContentContainerStyleProperty); }
            set { SetValue(ContentContainerStyleProperty, value); }
        }

        public static readonly DependencyProperty ContentContainerStyleProperty =
            DependencyProperty.Register("ContentContainerStyle", typeof(Style), typeof(DropDown));

        #endregion

        #region DropDownStyle
        public DropDownStyle DropDownStyle
        {
            get { return (DropDownStyle)GetValue(DropDownStyleProperty); }
            set { SetValue(DropDownStyleProperty, value); }
        }

        public static readonly DependencyProperty DropDownStyleProperty =
            DependencyProperty.Register("DropDownStyle", typeof(DropDownStyle), typeof(DropDown));
        #endregion

        #region IsOpen
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(DropDown));
        #endregion

        #region StaysOpen
        public bool StaysOpen
        {
            get { return (bool)GetValue(StaysOpenProperty); }
            set { SetValue(StaysOpenProperty, value); }
        }

        public static readonly DependencyProperty StaysOpenProperty =
            DependencyProperty.Register("StaysOpen", typeof(bool), typeof(DropDown));
        #endregion

        #region Child
        public UIElement Child
        {
            get { return (UIElement)GetValue(ChildProperty); }
            set { SetValue(ChildProperty, value); }
        }

        public static readonly DependencyProperty ChildProperty =
            DependencyProperty.Register("Child", typeof(UIElement), typeof(DropDown));
        #endregion

        #region ChildTemplate
        public DataTemplate ChildTemplate
        {
            get { return (DataTemplate)GetValue(ChildTemplateProperty); }
            set { SetValue(ChildTemplateProperty, value); }
        }

        public static readonly DependencyProperty ChildTemplateProperty =
            DependencyProperty.Register("ChildTemplate", typeof(DataTemplate), typeof(DropDown));
        #endregion

        #region ChildTemplateSelector
        public DataTemplateSelector ChildTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(ChildTemplateSelectorProperty); }
            set { SetValue(ChildTemplateSelectorProperty, value); }
        }

        public static readonly DependencyProperty ChildTemplateSelectorProperty =
            DependencyProperty.Register("ChildTemplateSelector", typeof(DataTemplateSelector), typeof(DropDown));
        #endregion

        #region DropDownShadowColor
        public Color? DropDownShadowColor
        {
            get { return (Color?)GetValue(DropDownShadowColorProperty); }
            set { SetValue(DropDownShadowColorProperty, value); }
        }

        public static readonly DependencyProperty DropDownShadowColorProperty =
            DependencyProperty.Register("DropDownShadowColor", typeof(Color?), typeof(DropDown));
        #endregion

        #region DropDownCornerRadius
        public CornerRadius DropDownCornerRadius
        {
            get { return (CornerRadius)GetValue(DropDownCornerRadiusProperty); }
            set { SetValue(DropDownCornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty DropDownCornerRadiusProperty =
            DependencyProperty.Register("DropDownCornerRadius", typeof(CornerRadius), typeof(DropDown));
        #endregion

        #region DropDownPlacement
        public PopupXPlacement DropDownPlacement
        {
            get { return (PopupXPlacement)GetValue(DropDownPlacementProperty); }
            set { SetValue(DropDownPlacementProperty, value); }
        }

        public static readonly DependencyProperty DropDownPlacementProperty =
            DependencyProperty.Register("DropDownPlacement", typeof(PopupXPlacement), typeof(DropDown));
        #endregion

        #region DropDownStroke
        public Brush DropDownStroke
        {
            get { return (Brush)GetValue(DropDownStrokeProperty); }
            set { SetValue(DropDownStrokeProperty, value); }
        }

        public static readonly DependencyProperty DropDownStrokeProperty =
            DependencyProperty.Register("DropDownStroke", typeof(Brush), typeof(DropDown));
        #endregion

        #region DropDownStrokeThickness
        public double DropDownStrokeThickness
        {
            get { return (double)GetValue(DropDownStrokeThicknessProperty); }
            set { SetValue(DropDownStrokeThicknessProperty, value); }
        }

        public static readonly DependencyProperty DropDownStrokeThicknessProperty =
            DependencyProperty.Register("DropDownStrokeThickness", typeof(double), typeof(DropDown));
        #endregion

        #endregion
    }
}
