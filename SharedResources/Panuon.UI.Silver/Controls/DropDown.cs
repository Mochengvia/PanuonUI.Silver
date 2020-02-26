using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

        public DropDown()
        {
        }
        #endregion

        #region Event Handler
        public event EventHandler Opened;

        public event EventHandler Closed;
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

        #region ShadowColor
        public Color? ShadowColor
        {
            get { return (Color?)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color?), typeof(DropDown));
        #endregion

        #region CornerRadius
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(DropDown));
        #endregion

        #region Placement
        public DropDownPlacement Placement
        {
            get { return (DropDownPlacement)GetValue(PlacementProperty); }
            set { SetValue(PlacementProperty, value); }
        }

        public static readonly DependencyProperty PlacementProperty =
            DependencyProperty.Register("Placement", typeof(DropDownPlacement), typeof(DropDown));
        #endregion

        #endregion
    }
}
