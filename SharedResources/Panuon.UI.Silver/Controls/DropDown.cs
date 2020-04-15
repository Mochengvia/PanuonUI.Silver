using Panuon.UI.Silver.Controls.Internal;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class DropDown : ContentControl
    {
        static DropDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DropDown), new FrameworkPropertyMetadata(typeof(DropDown)));
        }

        public DropDown()
        {
            AddHandler(NotTopMostPopup.OpeningEvent, new RoutedEventHandler(OnOpening));
            AddHandler(NotTopMostPopup.ClosingEvent, new RoutedEventHandler(OnClosing));
        }

        #region Event
        public event EventHandler Opened;

        public event EventHandler Closed;
        #endregion

        #region RoutedEvent 
        private void OnOpening(object sender, RoutedEventArgs e)
        {
            Opened?.Invoke(this, null);
        }

        private void OnClosing(object sender, RoutedEventArgs e)
        {
            Closed?.Invoke(this, null);
        }

        #endregion

        #region Property
        /// <summary>
        /// Gets or sets shadow color.
        /// </summary>
        public Color ShadowColor
        {
            get { return (Color)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color), typeof(DropDown));

        /// <summary>
        /// Gets or sets child
        /// </summary>
        public UIElement Child
        {
            get { return (UIElement)GetValue(ChildProperty); }
            set { SetValue(ChildProperty, value); }
        }

        public static readonly DependencyProperty ChildProperty =
            DependencyProperty.Register("Child", typeof(UIElement), typeof(DropDown));

        /// <summary>
        /// Gets or sets drop down placement.
        /// </summary>
        public DropDownPlacement DropDownPlacement
        {
            get { return (DropDownPlacement)GetValue(DropDownPlacementProperty); }
            set { SetValue(DropDownPlacementProperty, value); }
        }

        public static readonly DependencyProperty DropDownPlacementProperty =
            DependencyProperty.Register("DropDownPlacement", typeof(DropDownPlacement), typeof(DropDown), new PropertyMetadata(DropDownPlacement.LeftBottom));

        /// <summary>
        /// Gets or sets corner radius.
        /// </summary>
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(double), typeof(DropDown));

        /// <summary>
        /// Gets or sets is open.
        /// </summary>
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(DropDown));

        /// <summary>
        /// Gets or sets is angle visible.
        /// </summary>
        public bool IsAngleVisible
        {
            get { return (bool)GetValue(IsAngleVisibleProperty); }
            set { SetValue(IsAngleVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsAngleVisibleProperty =
            DependencyProperty.Register("IsAngleVisible", typeof(bool), typeof(DropDown));

        /// <summary>
        /// Gets or sets stays open.
        /// </summary>
        public bool StaysOpen
        {
            get { return (bool)GetValue(StaysOpenProperty); }
            set { SetValue(StaysOpenProperty, value); }
        }

        public static readonly DependencyProperty StaysOpenProperty =
            DependencyProperty.Register("StaysOpen", typeof(bool), typeof(DropDown));


        #endregion
    }
}
