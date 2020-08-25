using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class Dropdown : ContentControl
    {
        #region Ctor
        static Dropdown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Dropdown), new FrameworkPropertyMetadata(typeof(Dropdown)));
        }
        #endregion

        #region RoutedEvents
        public event RoutedEventHandler Opened
        {
            add { AddHandler(OpenedEvent, value); }
            remove { RemoveHandler(OpenedEvent, value); }
        }

        public static readonly RoutedEvent OpenedEvent =
            EventManager.RegisterRoutedEvent("Opened", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Dropdown));


        public event RoutedEventHandler Closed
        {
            add { AddHandler(ClosedEvent, value); }
            remove { RemoveHandler(ClosedEvent, value); }
        }

        public static readonly RoutedEvent ClosedEvent =
            EventManager.RegisterRoutedEvent("Closed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Dropdown));
        #endregion

        #region Properties

        #region ContentContainerStyle
        public Style ContentContainerStyle
        {
            get { return (Style)GetValue(ContentContainerStyleProperty); }
            set { SetValue(ContentContainerStyleProperty, value); }
        }

        public static readonly DependencyProperty ContentContainerStyleProperty =
            DependencyProperty.Register("ContentContainerStyle", typeof(Style), typeof(Dropdown));

        #endregion

        #region DropdownStyle
        public DropdownStyle DropdownStyle
        {
            get { return (DropdownStyle)GetValue(DropdownStyleProperty); }
            set { SetValue(DropdownStyleProperty, value); }
        }

        public static readonly DependencyProperty DropdownStyleProperty =
            DependencyProperty.Register("DropdownStyle", typeof(DropdownStyle), typeof(Dropdown));
        #endregion

        #region IsOpen
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(Dropdown));
        #endregion

        #region StaysOpen
        public bool StaysOpen
        {
            get { return (bool)GetValue(StaysOpenProperty); }
            set { SetValue(StaysOpenProperty, value); }
        }

        public static readonly DependencyProperty StaysOpenProperty =
            DependencyProperty.Register("StaysOpen", typeof(bool), typeof(Dropdown));
        #endregion

        #region Child
        public UIElement Child
        {
            get { return (UIElement)GetValue(ChildProperty); }
            set { SetValue(ChildProperty, value); }
        }

        public static readonly DependencyProperty ChildProperty =
            DependencyProperty.Register("Child", typeof(UIElement), typeof(Dropdown));
        #endregion

        #region ChildTemplate
        public DataTemplate ChildTemplate
        {
            get { return (DataTemplate)GetValue(ChildTemplateProperty); }
            set { SetValue(ChildTemplateProperty, value); }
        }

        public static readonly DependencyProperty ChildTemplateProperty =
            DependencyProperty.Register("ChildTemplate", typeof(DataTemplate), typeof(Dropdown));
        #endregion

        #region ChildTemplateSelector
        public DataTemplateSelector ChildTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(ChildTemplateSelectorProperty); }
            set { SetValue(ChildTemplateSelectorProperty, value); }
        }

        public static readonly DependencyProperty ChildTemplateSelectorProperty =
            DependencyProperty.Register("ChildTemplateSelector", typeof(DataTemplateSelector), typeof(Dropdown));
        #endregion

        #region DropdownShadowColor
        public Color? DropdownShadowColor
        {
            get { return (Color?)GetValue(DropdownShadowColorProperty); }
            set { SetValue(DropdownShadowColorProperty, value); }
        }

        public static readonly DependencyProperty DropdownShadowColorProperty =
            DependencyProperty.Register("DropdownShadowColor", typeof(Color?), typeof(Dropdown));
        #endregion

        #region DropdownCornerRadius
        public CornerRadius DropdownCornerRadius
        {
            get { return (CornerRadius)GetValue(DropdownCornerRadiusProperty); }
            set { SetValue(DropdownCornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty DropdownCornerRadiusProperty =
            DependencyProperty.Register("DropdownCornerRadius", typeof(CornerRadius), typeof(Dropdown));
        #endregion

        #region DropdownPlacement
        public PopupXPlacement DropdownPlacement
        {
            get { return (PopupXPlacement)GetValue(DropdownPlacementProperty); }
            set { SetValue(DropdownPlacementProperty, value); }
        }

        public static readonly DependencyProperty DropdownPlacementProperty =
            DependencyProperty.Register("DropdownPlacement", typeof(PopupXPlacement), typeof(Dropdown));
        #endregion

        #region DropdownStroke
        public Brush DropdownStroke
        {
            get { return (Brush)GetValue(DropdownStrokeProperty); }
            set { SetValue(DropdownStrokeProperty, value); }
        }

        public static readonly DependencyProperty DropdownStrokeProperty =
            DependencyProperty.Register("DropdownStroke", typeof(Brush), typeof(Dropdown));
        #endregion

        #region DropdownStrokeThickness
        public double DropdownStrokeThickness
        {
            get { return (double)GetValue(DropdownStrokeThicknessProperty); }
            set { SetValue(DropdownStrokeThicknessProperty, value); }
        }

        public static readonly DependencyProperty DropdownStrokeThicknessProperty =
            DependencyProperty.Register("DropdownStrokeThickness", typeof(double), typeof(Dropdown));
        #endregion

        #endregion
    }
}
