using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class PopupX : Popup
    {
        #region Fields
        private IntPtr _popupHandle = IntPtr.Zero;

        private Window _parentWindow;

        #endregion

        #region Ctor
        public PopupX()
        {
            base.Placement = PlacementMode.Custom;
            CustomPopupPlacementCallback = GetPopupPlacement;
        }

        #endregion

        #region Properties
        public ActualPlacement ActualPlacement
        {
            get { return (ActualPlacement)GetValue(ActualPlacementProperty); }
            private set { SetValue(ActualPlacementProperty, value); }
        }

        public static readonly DependencyProperty ActualPlacementProperty =
            DependencyProperty.Register("ActualPlacement", typeof(ActualPlacement), typeof(PopupX));


        public bool AutoFollow
        {
            get { return (bool)GetValue(AutoFollowProperty); }
            set { SetValue(AutoFollowProperty, value); }
        }

        public static readonly DependencyProperty AutoFollowProperty =
            DependencyProperty.Register("AutoFollow", typeof(bool), typeof(PopupX), new PropertyMetadata(true));


        public new bool StaysOpen
        {
            get { return (bool)GetValue(StaysOpenProperty); }
            set { SetValue(StaysOpenProperty, value); }
        }

        public new static readonly DependencyProperty StaysOpenProperty =
            DependencyProperty.Register("StaysOpen", typeof(bool), typeof(PopupX));


        public new DropDownPlacement Placement
        {
            get { return (DropDownPlacement)GetValue(PlacementProperty); }
            set { SetValue(PlacementProperty, value); }
        }

        public new static readonly DependencyProperty PlacementProperty =
            DependencyProperty.Register("Placement", typeof(DropDownPlacement), typeof(PopupX), new PropertyMetadata(OnPlacementChanged));

        public FrameworkElement PartnerElement
        {
            get { return (FrameworkElement)GetValue(PartnerElementProperty); }
            set { SetValue(PartnerElementProperty, value); }
        }

        public static readonly DependencyProperty PartnerElementProperty =
            DependencyProperty.Register("PartnerElement", typeof(FrameworkElement), typeof(PopupX));
        #endregion

        #region Override
        protected override void OnOpened(EventArgs e)
        {
            if (_popupHandle == IntPtr.Zero)
            {
                _popupHandle = ((HwndSource)PresentationSource.FromVisual(this.Child)).Handle;
            }
            _parentWindow = Window.GetWindow(this);

            if (_parentWindow != null)
            {
                _parentWindow.LocationChanged -= ParentWindow_LocationChanged;
                _parentWindow.LocationChanged += ParentWindow_LocationChanged;
                _parentWindow.PreviewMouseDown -= Window_PreviewMouseDown;
                _parentWindow.PreviewMouseDown += Window_PreviewMouseDown;
            }
            UpdateActualPlacement();
            base.OnOpened(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            if(_parentWindow != null)
            {
                _parentWindow.LocationChanged -= ParentWindow_LocationChanged;
                _parentWindow.PreviewMouseDown -= Window_PreviewMouseDown;
            }
            base.OnClosed(e);
        }


        private void UpdateActualPlacement()
        {
            var target = PlacementTarget ?? VisualTreeHelper.GetParent(this) as UIElement;
            var location = Child.TranslatePoint(new Point(0, 0), target);


            if(location.X >= 0)
            {
                if(location.Y > 0)
                {
                    ActualPlacement = ActualPlacement.BottomRight;
                }
                else
                {
                    ActualPlacement = ActualPlacement.TopRight;
                }
            }
            else if(location.X == ((target as FrameworkElement).ActualWidth - (Child as FrameworkElement).ActualWidth) / 2)
            {
                if (location.Y > 0)
                {
                    ActualPlacement = ActualPlacement.Bottom;
                }
                else
                {
                    ActualPlacement = ActualPlacement.Top;
                }
            }
            else
            {
                if (location.Y > 0)
                {
                    ActualPlacement = ActualPlacement.BottomLeft;
                }
                else
                {
                    ActualPlacement = ActualPlacement.TopLeft;
                }
            }
        }
        #endregion

        #region Event Handler
        private static void OnPlacementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var popupX = d as PopupX;
            switch ((DropDownPlacement)e.NewValue)
            {
                case DropDownPlacement.TopRight:
                    popupX.SetBasePlacement(PlacementMode.Top);
                    break;
                case DropDownPlacement.BottomRight:
                    popupX.SetBasePlacement(PlacementMode.Bottom);
                    break;
                default:
                    popupX.SetBasePlacement(PlacementMode.Custom);
                    break;
            }
        }

        private void ParentWindow_LocationChanged(object sender, EventArgs e)
        {
            if (AutoFollow)
            {
                var offset = HorizontalOffset;
                HorizontalOffset = offset + 1;
                HorizontalOffset = offset;
            }
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var partnerElement = PartnerElement;
            if (!IsMouseOver && !StaysOpen && (partnerElement == null || !partnerElement.IsMouseOver))
            {
                IsOpen = false;
            }
        }

        private CustomPopupPlacement[] GetPopupPlacement(Size popupSize, Size targetSize, Point offset)
        {
            var margin = (Child as FrameworkElement)?.Margin ?? new Thickness();
            var left = margin.Left;
            var top = margin.Top;
            var right = margin.Right;
            var bottom = margin.Bottom;

            var bottomRightPoint = new Point(-left, targetSize.Height - top);
            var bottomPoint = new Point((targetSize.Width - popupSize.Width) / 2 - left, targetSize.Height - top);
            var bottomLeftPoint = new Point(targetSize.Width - popupSize.Width - right, targetSize.Height - top);

            var topRightPoint = new Point(-left, - popupSize.Height - bottom);
            var topPoint = new Point((targetSize.Width - popupSize.Width) / 2 - left, - popupSize.Height - bottom);
            var topLeftPoint = new Point(targetSize.Width - popupSize.Width - right, - popupSize.Height - bottom);

            switch (Placement)
            {
                case DropDownPlacement.Top:
                    return new[] { new CustomPopupPlacement(topPoint, PopupPrimaryAxis.Horizontal), new CustomPopupPlacement(bottomPoint, PopupPrimaryAxis.Horizontal) };
                case DropDownPlacement.TopLeft:
                    return new[] { new CustomPopupPlacement(topLeftPoint, PopupPrimaryAxis.Horizontal), new CustomPopupPlacement(bottomLeftPoint, PopupPrimaryAxis.Horizontal) };
                case DropDownPlacement.BottomLeft:
                    return new[] { new CustomPopupPlacement(bottomLeftPoint, PopupPrimaryAxis.Horizontal), new CustomPopupPlacement(topLeftPoint, PopupPrimaryAxis.Horizontal) };
                case DropDownPlacement.TopRight:
                    return new[] { new CustomPopupPlacement(topRightPoint, PopupPrimaryAxis.Horizontal), new CustomPopupPlacement(bottomRightPoint, PopupPrimaryAxis.Horizontal) };
                case DropDownPlacement.BottomRight:
                    return new[] { new CustomPopupPlacement(bottomRightPoint, PopupPrimaryAxis.Horizontal), new CustomPopupPlacement(topRightPoint, PopupPrimaryAxis.Horizontal) };
                default:
                    return new[] {  new CustomPopupPlacement(bottomPoint, PopupPrimaryAxis.Horizontal), new CustomPopupPlacement(topPoint, PopupPrimaryAxis.Horizontal) };
            }
        }

        private void SetBasePlacement(PlacementMode placementMode)
        {
            base.Placement = placementMode;
        }

        #endregion
    }
}
