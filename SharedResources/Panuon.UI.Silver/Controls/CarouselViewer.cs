using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver
{
    public class CarouselViewer : ItemsControl
    {
        #region Ctor
        static CarouselViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CarouselViewer), new FrameworkPropertyMetadata(typeof(CarouselViewer)));
        }
        #endregion

        #region Properties

        #region CurrentIndex
        public int CurrentIndex
        {
            get { return (int)GetValue(CurrentIndexProperty); }
            set { SetValue(CurrentIndexProperty, value); }
        }

        public static readonly DependencyProperty CurrentIndexProperty =
            DependencyProperty.Register("CurrentIndex", typeof(int), typeof(CarouselViewer), new PropertyMetadata(1, null, OnCurrentIndexCoerceValue));
        #endregion

        #region IsSideButtonVisible
        public bool IsSideButtonVisible
        {
            get { return (bool)GetValue(IsSideButtonVisibleProperty); }
            set { SetValue(IsSideButtonVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsSideButtonVisibleProperty =
            DependencyProperty.Register("IsSideButtonVisible", typeof(bool), typeof(CarouselViewer));
        #endregion

        #region SideButtonStyle
        public Style SideButtonStyle
        {
            get { return (Style)GetValue(SideButtonStyleProperty); }
            set { SetValue(SideButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty SideButtonStyleProperty =
            DependencyProperty.Register("SideButtonStyle", typeof(Style), typeof(CarouselViewer));
        #endregion

        #region IsIndicatorVisible
        public bool IsIndicatorVisible
        {
            get { return (bool)GetValue(IsIndicatorVisibleProperty); }
            set { SetValue(IsIndicatorVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsIndicatorVisibleProperty =
            DependencyProperty.Register("IsIndicatorVisible", typeof(bool), typeof(CarouselViewer));
        #endregion

        #region IndicatorStyle
        public Style IndicatorStyle
        {
            get { return (Style)GetValue(IndicatorStyleProperty); }
            set { SetValue(IndicatorStyleProperty, value); }
        }

        public static readonly DependencyProperty IndicatorStyleProperty =
            DependencyProperty.Register("IndicatorStyle", typeof(Style), typeof(CarouselViewer));
        #endregion

        #region AnimationDuration
        public TimeSpan AnimationDuration
        {
            get { return (TimeSpan)GetValue(AnimationDurationProperty); }
            set { SetValue(AnimationDurationProperty, value); }
        }

        public static readonly DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register("AnimationDuration", typeof(TimeSpan), typeof(CarouselViewer));
        #endregion

        #region AnimationEase
        public AnimationEase AnimationEase
        {
            get { return (AnimationEase)GetValue(AnimationEaseProperty); }
            set { SetValue(AnimationEaseProperty, value); }
        }

        public static readonly DependencyProperty AnimationEaseProperty =
            DependencyProperty.Register("AnimationEase", typeof(AnimationEase), typeof(CarouselViewer), new PropertyMetadata(AnimationEase.CubicOut));
        #endregion

        #region Orientation
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(CarouselViewer));
        #endregion

        #endregion

        #region Event Handler
        private static object OnCurrentIndexCoerceValue(DependencyObject d, object baseValue)
        {
            var carousel = d as CarouselViewer;
            var index = (int)baseValue;
            if (index < 1)
            {
                index = 1;
            }
            else
            {
                if (carousel.Items.Count > 1 && index > carousel.Items.Count)
                {
                    index = carousel.Items.Count;
                }
            }
            return index;
        }
        #endregion

        #region Methods
        #endregion

        #region Function
        #endregion
    }
}
