using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using static Panuon.UI.Silver.Internal.Utils.User32Utils;

namespace Panuon.UI.Silver
{
    public class PopupX : Popup
    {
        #region Fields
        private IntPtr _popupHwnd;

        private Window _parentWindow;
        #endregion

        #region Ctor
        public PopupX()
        {
            base.Placement = PlacementMode.Custom;
            CustomPopupPlacementCallback = PopupPlacementCallback;
        }
        #endregion

        #region Properties

        #region Placement 
        public new PopupXPlacement Placement
        {
            get { return (PopupXPlacement)GetValue(PlacementProperty); }
            set { SetValue(PlacementProperty, value); }
        }

        public new static readonly DependencyProperty PlacementProperty =
            DependencyProperty.Register("Placement", typeof(PopupXPlacement), typeof(PopupX));
        #endregion

        #region FollowStrategy 
        public FollowStrategy FollowStrategy
        {
            get { return (FollowStrategy)GetValue(FollowStrategyProperty); }
            set { SetValue(FollowStrategyProperty, value); }
        }

        public static readonly DependencyProperty FollowStrategyProperty =
            DependencyProperty.Register("FollowStrategy", typeof(FollowStrategy), typeof(PopupX), new PropertyMetadata(FollowStrategy.ParentWindow));
        #endregion

        #region StaysOpen 
        public new bool StaysOpen
        {
            get { return (bool)GetValue(StaysOpenProperty); }
            set { SetValue(StaysOpenProperty, value); }
        }

        public new static readonly DependencyProperty StaysOpenProperty =
            DependencyProperty.Register("StaysOpen", typeof(bool), typeof(PopupX));
        #endregion

        #region ActualPlacement 
        public PopupXPlacement ActualPlacement
        {
            get { return (PopupXPlacement)GetValue(ActualPlacementProperty); }
            set { SetValue(ActualPlacementProperty, value); }
        }

        public static readonly DependencyProperty ActualPlacementProperty =
            DependencyProperty.Register("ActualPlacement", typeof(PopupXPlacement), typeof(PopupX));
        #endregion

        #region RelativePosition
        public Point RelativePosition
        {
            get { return (Point)GetValue(RelativePositionProperty); }
            set { SetValue(RelativePositionProperty, value); }
        }

        public static readonly DependencyProperty RelativePositionProperty =
            DependencyProperty.Register("RelativePosition", typeof(Point), typeof(PopupX));
        #endregion

        #endregion

        #region Overrides
        protected override void OnOpened(EventArgs e)
        {
            if(Child != null)
            {
                if (_popupHwnd == IntPtr.Zero)
                {
                    _popupHwnd = ((HwndSource)PresentationSource.FromVisual(Child)).Handle;
                }

                if (GetWindowRect(_popupHwnd, out RECT rect))
                {
                    SetWindowPos(_popupHwnd, -2, rect.Left, rect.Top, (int)this.Width, (int)this.Height, 0);
                }
            }

            _parentWindow = Window.GetWindow(this);
            if (_parentWindow != null)
            {
                _parentWindow.LocationChanged -= ParentWindow_LocationChanged;
                _parentWindow.LocationChanged += ParentWindow_LocationChanged;
                _parentWindow.PreviewMouseDown -= Window_PreviewMouseDown;
                _parentWindow.PreviewMouseDown += Window_PreviewMouseDown;
            }
            base.OnOpened(e);
            UpdateActualPlacement();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (_parentWindow != null)
            {
                _parentWindow.LocationChanged -= ParentWindow_LocationChanged;
                _parentWindow.PreviewMouseDown -= Window_PreviewMouseDown;
            }
            base.OnClosed(e);
        }
        #endregion

        #region Event Handlers
        private CustomPopupPlacement[] PopupPlacementCallback(Size popupSize, Size targetSize, Point offset)
        {
            var margin = (Child as FrameworkElement)?.Margin ?? new Thickness();
            var left = margin.Left;
            var top = margin.Top;
            var right = margin.Right;
            var bottom = margin.Bottom;

            var leftPoint = new Point(targetSize.Width - popupSize.Width - left - targetSize.Width, -popupSize.Height / 2 + targetSize.Height / 2 - bottom);
            var bottomRightPoint = new Point(-left, targetSize.Height - top);
            var bottomPoint = new Point((targetSize.Width - popupSize.Width) / 2 - left, targetSize.Height - top);
            var bottomLeftPoint = new Point(targetSize.Width - popupSize.Width - right, targetSize.Height - top);

            var rightPoint = new Point(-left + targetSize.Width, -popupSize.Height / 2 + targetSize.Height / 2 - bottom);
            var topRightPoint = new Point(-left, -popupSize.Height - bottom - top);
            var topPoint = new Point((targetSize.Width - popupSize.Width) / 2 - left, -popupSize.Height - bottom - top);
            var topLeftPoint = new Point(targetSize.Width - popupSize.Width - right, -popupSize.Height - bottom - top);

            switch (Placement)
            {
                case PopupXPlacement.Left:
                    return new[] { new CustomPopupPlacement(leftPoint, PopupPrimaryAxis.Horizontal), new CustomPopupPlacement(rightPoint, PopupPrimaryAxis.Horizontal) };
                case PopupXPlacement.Top:
                    return new[] { new CustomPopupPlacement(topPoint, PopupPrimaryAxis.Horizontal), new CustomPopupPlacement(bottomPoint, PopupPrimaryAxis.Horizontal) };
                case PopupXPlacement.TopLeft:
                    return new[] { new CustomPopupPlacement(topLeftPoint, PopupPrimaryAxis.Horizontal), new CustomPopupPlacement(bottomLeftPoint, PopupPrimaryAxis.Horizontal) };
                case PopupXPlacement.BottomLeft:
                    return new[] { new CustomPopupPlacement(bottomLeftPoint, PopupPrimaryAxis.Horizontal), new CustomPopupPlacement(topLeftPoint, PopupPrimaryAxis.Horizontal) };
                case PopupXPlacement.TopRight:
                    return new[] { new CustomPopupPlacement(topRightPoint, PopupPrimaryAxis.Horizontal), new CustomPopupPlacement(bottomRightPoint, PopupPrimaryAxis.Horizontal) };
                case PopupXPlacement.BottomRight:
                    return new[] { new CustomPopupPlacement(bottomRightPoint, PopupPrimaryAxis.Horizontal), new CustomPopupPlacement(topRightPoint, PopupPrimaryAxis.Horizontal) };
                case PopupXPlacement.Right:
                    return new[] { new CustomPopupPlacement(rightPoint, PopupPrimaryAxis.Horizontal), new CustomPopupPlacement(leftPoint, PopupPrimaryAxis.Horizontal) };
                default:
                    return new[] { new CustomPopupPlacement(bottomPoint, PopupPrimaryAxis.Horizontal), new CustomPopupPlacement(topPoint, PopupPrimaryAxis.Horizontal) };
            }
        }

        private void ParentWindow_LocationChanged(object sender, EventArgs e)
        {
            if (FollowStrategy == FollowStrategy.ParentWindow)
            {
                var offset = HorizontalOffset;
                HorizontalOffset = offset + 1;
                HorizontalOffset = offset;
            }
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsMouseOver && !StaysOpen && (PlacementTarget == null || !PlacementTarget.IsMouseOver))
            {
                IsOpen = false;
            }
        }

        private void UpdateActualPlacement()
        {
            var target = PlacementTarget ?? VisualTreeHelper.GetParent(this) as UIElement;
            if(Child == null)
            {
                return;
            }

            var location = Child.TranslatePoint(new Point(0, 0), target);
            if(RelativePosition.X != location.X || RelativePosition.Y != location.Y)
            {
                RelativePosition = location;
            }
            var centerX = location.X + (Child.RenderSize.Width - target.RenderSize.Width) / 2;

            if(centerX > -2 && centerX < 2)
            {
                if(location.Y < 0)
                {
                    ActualPlacement = PopupXPlacement.Top;
                }
                else
                {
                    ActualPlacement = PopupXPlacement.Bottom;
                }
            }
            else if(centerX > 2)
            {
                if (location.Y > 0)
                {
                    ActualPlacement = PopupXPlacement.BottomRight;
                }
                else if (-location.Y >= Child.RenderSize.Height)
                {
                    ActualPlacement = PopupXPlacement.TopRight;
                }
                else
                {
                    ActualPlacement = PopupXPlacement.Right;
                }
            }
            else if (centerX < -2)
            {
                if (location.Y > 0)
                {
                    ActualPlacement = PopupXPlacement.BottomLeft;
                }
                else if (-location.Y >= Child.RenderSize.Height)
                {
                    ActualPlacement = PopupXPlacement.TopLeft;
                }
                else
                {
                    ActualPlacement = PopupXPlacement.Left;
                }
            }
        }

        #endregion

    }
}
