using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public class Drawer : ContentControl
    {
        #region Ctor
        static Drawer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Drawer), new FrameworkPropertyMetadata(typeof(Drawer)));
        }
        #endregion

        #region Properties

        #region ContentPlacement
        public DrawerPlacement ContentPlacement
        {
            get { return (DrawerPlacement)GetValue(ContentPlacementProperty); }
            set { SetValue(ContentPlacementProperty, value); }
        }

        public static readonly DependencyProperty ContentPlacementProperty =
            DependencyProperty.Register("ContentPlacement", typeof(DrawerPlacement), typeof(Drawer));
        #endregion

        #region Placement
        public DrawerPlacement Placement
        {
            get { return (DrawerPlacement)GetValue(PlacementProperty); }
            set { SetValue(PlacementProperty, value); }
        }

        public static readonly DependencyProperty PlacementProperty =
            DependencyProperty.Register("Placement", typeof(DrawerPlacement), typeof(Drawer));
        #endregion

        #region CanResize
        public bool CanResize
        {
            get { return (bool)GetValue(CanResizeProperty); }
            set { SetValue(CanResizeProperty, value); }
        }

        public static readonly DependencyProperty CanResizeProperty =
            DependencyProperty.Register("CanResize", typeof(bool), typeof(Drawer));
        #endregion

        #region IsOpen
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(Drawer), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnIsOpenChanged));
        #endregion

        #region AnimationDuration
        public TimeSpan AnimationDuration
        {
            get { return (TimeSpan)GetValue(AnimationDurationProperty); }
            set { SetValue(AnimationDurationProperty, value); }
        }

        public static readonly DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register("AnimationDuration", typeof(TimeSpan), typeof(Drawer));

        #endregion

        #region AnimationEase
        public AnimationEase AnimationEase
        {
            get { return (AnimationEase)GetValue(AnimationEaseProperty); }
            set { SetValue(AnimationEaseProperty, value); }
        }

        public static readonly DependencyProperty AnimationEaseProperty =
            DependencyProperty.Register("AnimationEase", typeof(AnimationEase), typeof(Drawer));
        #endregion

        #region CornerRadius
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Drawer));
        #endregion

        #region ShadowColor


        public Color? ShadowColor
        {
            get { return (Color?)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color?), typeof(Drawer));
        #endregion

        #endregion

        #region Internal Properties

        #region IsDragging
        internal bool IsDragging
        {
            get { return (bool)GetValue(IsDraggingProperty); }
            set { SetValue(IsDraggingProperty, value); }
        }

        internal static readonly DependencyProperty IsDraggingProperty =
            DependencyProperty.Register("IsDragging", typeof(bool), typeof(Drawer));
        #endregion

        #endregion

        #region Overrides
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            UpdateState();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var thumb = Template?.FindName("PART_Thumb", this) as Thumb;
            thumb.DragStarted -= Thumb_DragStarted;
            thumb.DragStarted += Thumb_DragStarted;
            thumb.DragDelta -= Thumb_DragDelta;
            thumb.DragDelta += Thumb_DragDelta;
            thumb.DragCompleted -= Thumb_DragCompleted;
            thumb.DragCompleted += Thumb_DragCompleted;
        }

        private void Thumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            IsDragging = false;
            switch (Placement)
            {
                case DrawerPlacement.Top:
                case DrawerPlacement.Bottom:
                    MaxHeight = ActualHeight;
                    break;
                default:
                    MaxWidth = ActualWidth;
                    break;
            }
        }

        private void Thumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            IsDragging = true;
            switch (Placement)
            {
                case DrawerPlacement.Top:
                case DrawerPlacement.Bottom:
                    var height = ActualHeight;
                    BeginAnimation(HeightProperty, null);
                    Height = height;
                    MaxHeight = double.PositiveInfinity;
                    break;
                default:
                    var width = ActualWidth;
                    BeginAnimation(WidthProperty, null);
                    if (!double.IsInfinity(width))
                    {
                        Width = width;
                    }
                    MaxWidth = double.PositiveInfinity;
                    break;
            }
        }

        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {

            bool isVertical = Placement == DrawerPlacement.Bottom
                || Placement == DrawerPlacement.Top;

            var value = isVertical
                ? (Placement == DrawerPlacement.Top ?
                    ActualHeight + e.VerticalChange : ActualHeight - e.VerticalChange)
                : (Placement == DrawerPlacement.Left ?
                    ActualWidth + e.HorizontalChange : ActualWidth - e.HorizontalChange);


            if (isVertical)
            {
                value = value < MinHeight ? MinHeight : value;
                if (!double.IsInfinity(value))
                {
                    Height = value;
                }
            }
            else
            {
                value = value < MinWidth ? MinWidth : value;
                if (!double.IsInfinity(value))
                {
                    Width = value;
                }
            }

        }
        #endregion

        #region Methods

        private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var drawer = d as Drawer;
            drawer.UpdateState();
        }
        #endregion

        #region Function
        private void UpdateState()
        {
            if (!IsInitialized)
            {
                return;
            }
            switch (ContentPlacement)
            {
                case DrawerPlacement.Left:
                case DrawerPlacement.Right:
                    if (double.IsNaN(MaxWidth))
                    {
                        throw new Exception("Drawer Exception : value of MaxWidth property can not be Auto.");
                    }
                    if (!IsLoaded || AnimationDuration.TotalMilliseconds == 0)
                    {
                        if (IsOpen)
                        {
                            if (!double.IsInfinity(MaxWidth))
                            {
                                Width = MaxWidth;
                            }
                        }
                        else
                        {
                            Width = 0;
                        }
                    }
                    else
                    {
                        if (IsOpen)
                        {
                            if (double.IsNaN(Width))
                            {
                                Width = ActualWidth;
                            }
                            UIElementUtils.BeginAnimation(this, WidthProperty, MaxWidth, AnimationDuration, AnimationEase);
                        }
                        else
                        {
                            if (double.IsNaN(Width))
                            {
                                Width = ActualWidth;

                            }
                            UIElementUtils.BeginAnimation(this, WidthProperty, 0, AnimationDuration, AnimationEase);
                        }
                    }
                    break;
                case DrawerPlacement.Top:
                case DrawerPlacement.Bottom:
                    if (double.IsNaN(MaxWidth))
                    {
                        throw new Exception("Drawer Exception : value of MaxHeight property can not be Auto.");
                    }
                    if (!IsLoaded || AnimationDuration.TotalMilliseconds == 0)
                    {
                        if (IsOpen)
                        {
                            if (!double.IsInfinity(MaxHeight))
                            {
                                Height = MaxHeight;
                            }
                        }
                        else
                        {
                            Height = 0;
                        }
                    }
                    else
                    {
                        if (IsOpen)
                        {
                            if (double.IsNaN(Height))
                            {
                                Height = ActualHeight;
                            }
                            UIElementUtils.BeginAnimation(this, HeightProperty, MaxHeight, AnimationDuration, AnimationEase);
                        }
                        else
                        {
                            if (double.IsNaN(Height))
                            {
                                Height = ActualHeight;
                            }
                            UIElementUtils.BeginAnimation(this, HeightProperty, 0, AnimationDuration, AnimationEase);
                        }
                    }
                    break;
            }

        }
        #endregion
    }
}
