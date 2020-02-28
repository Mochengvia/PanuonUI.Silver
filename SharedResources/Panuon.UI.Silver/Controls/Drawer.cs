using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal;
using Panuon.UI.Silver.Internal.Models;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver
{
    [ContentProperty(nameof(Content))]
    public class Drawer : UIElement
    {
        #region Ctor
        public Drawer()
        {

        }
        #endregion

        #region Properties

        #region Alignment


        public Alignment Alignment
        {
            get { return (Alignment)GetValue(AlignmentProperty); }
            set { SetValue(AlignmentProperty, value); }
        }

        public static readonly DependencyProperty AlignmentProperty =
            DependencyProperty.Register("Alignment", typeof(Alignment), typeof(Drawer), new FrameworkPropertyMetadata(Alignment.Left, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));
        #endregion

        #region Content
        public UIElement Content
        {
            get { return (UIElement)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(UIElement), typeof(Drawer));
        #endregion

        #region IsOpen
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(Drawer), new PropertyMetadata(true, OnIsOpenChanged));
        #endregion

        #region Width
        public double Width
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register("Width", typeof(double), typeof(Drawer), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
        #endregion

        #region Height
        public double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(double), typeof(Drawer), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
        #endregion

        #endregion

        #region Internal Properties
        public Rect PositionOffset
        {
            get { return (Rect)GetValue(PositionOffsetProperty); }
            set { SetValue(PositionOffsetProperty, value); }
        }

        public static readonly DependencyProperty PositionOffsetProperty =
            DependencyProperty.Register("PositionOffset", typeof(Rect), typeof(Drawer), new PropertyMetadata(new Rect(), new PropertyChangedCallback(OnPositionOffsetChanged)));

        private static void OnPositionOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var drawer = d as Drawer;
            drawer.ArrangeCore(new Rect(0, 0, drawer.Width, drawer.DesiredSize.Height));
        }
        #endregion

        #region Event Handler
        private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var drawer = d as Drawer;
            if (drawer.RenderSize.Width == 0 && drawer.RenderSize.Height == 0)
            {
                if ((bool)e.NewValue)
                {
                    drawer.PositionOffset = new Rect(0, 0, 0, 0);
                }
                else
                {
                    drawer.PositionOffset = new Rect(0, 0, drawer.Width, drawer.Height);
                }
            }
            else
            {
                if ((bool)e.NewValue)
                {
                    var animation = new RectAnimation()
                    {
                        To = new Rect(),
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = AnimationUtils.CreateEasingFunction( AnimationEase.CubicOut),
                    };
                    drawer.BeginAnimation(PositionOffsetProperty, animation);
                }
                else
                {
                    var animation = new RectAnimation()
                    {
                        To = new Rect(0, 0 , drawer.Width, drawer.Height),
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = AnimationUtils.CreateEasingFunction(AnimationEase.CubicOut),
                    };
                    drawer.BeginAnimation(PositionOffsetProperty, animation);
                }
            }
        }
        #endregion

        #region Override

        protected override Visual GetVisualChild(int index)
        {
            return Content;
        }

        protected override int VisualChildrenCount => 1;

        protected override Size MeasureCore(Size availableSize)
        {
            Content?.Measure(availableSize);
            return availableSize;
        }

        protected override void ArrangeCore(Rect finalRect)
        {
            Content?.Arrange(new Rect(finalRect.Left, finalRect.Top, Width, finalRect.Height));

            var newRect = new Rect();
            if(Alignment == Alignment.Left || Alignment == Alignment.Right)
            {
                newRect = new Rect(0, 0, Width - PositionOffset.Width, finalRect.Height);
            }
            else
            {
                newRect = new Rect(0, 0, finalRect.Width, Height - PositionOffset.Height);
            }
        }
        #endregion

        #region Methods
        #endregion

        #region Function
        #endregion
    }
}
