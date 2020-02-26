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
            DependencyProperty.Register("CurrentIndex", typeof(int), typeof(CarouselViewer));
        #endregion

        #region IsSideButtonVisible
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

        #region AnimationDuration
        public TimeSpan AnimationDuration
        {
            get { return (TimeSpan)GetValue(AnimationDurationProperty); }
            set { SetValue(AnimationDurationProperty, value); }
        }

        public static readonly DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register("AnimationDuration", typeof(TimeSpan), typeof(CarouselViewer));
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



        #region Methods
        #endregion

        #region Function
        #endregion
    }
}
