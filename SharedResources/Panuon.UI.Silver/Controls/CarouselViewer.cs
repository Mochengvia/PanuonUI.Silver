using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        #region SideButtonVisibility
        public SideButtonVisibility SideButtonVisibility
        {
            get { return (SideButtonVisibility)GetValue(SideButtonVisibilityProperty); }
            set { SetValue(SideButtonVisibilityProperty, value); }
        }

        public static readonly DependencyProperty SideButtonVisibilityProperty =
            DependencyProperty.Register("SideButtonVisibility", typeof(SideButtonVisibility), typeof(CarouselViewer));
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

        #region IndicatorVisibility
        public IndicatorVisibility IndicatorVisibility
        {
            get { return (IndicatorVisibility)GetValue(IndicatorVisibilityProperty); }
            set { SetValue(IndicatorVisibilityProperty, value); }
        }

        public static readonly DependencyProperty IndicatorVisibilityProperty =
            DependencyProperty.Register("IndicatorVisibility", typeof(IndicatorVisibility), typeof(CarouselViewer));
        #endregion

        #region IndicatorPosition
        public IndicatorPosition IndicatorPosition
        {
            get { return (IndicatorPosition)GetValue(IndicatorPositionProperty); }
            set { SetValue(IndicatorPositionProperty, value); }
        }

        public static readonly DependencyProperty IndicatorPositionProperty =
            DependencyProperty.Register("IndicatorPosition", typeof(IndicatorPosition), typeof(CarouselViewer));
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

        #region Commands
        internal ICommand PreviousCommand
        {
            get { return (ICommand)GetValue(PreviousCommandProperty); }
            set { SetValue(PreviousCommandProperty, value); }
        }

        internal static readonly DependencyProperty PreviousCommandProperty =
            DependencyProperty.Register("PreviousCommand", typeof(ICommand), typeof(CarouselViewer), new PropertyMetadata(new RelayCommand(OnPreviousCommandExecute)));

        internal ICommand NextCommand
        {
            get { return (ICommand)GetValue(NextCommandProperty); }
            set { SetValue(NextCommandProperty, value); }
        }

        internal static readonly DependencyProperty NextCommandProperty =
            DependencyProperty.Register("NextCommand", typeof(ICommand), typeof(CarouselViewer), new PropertyMetadata(new RelayCommand(OnNextCommandExecute)));

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

        private static void OnPreviousCommandExecute(object obj)
        {
            var pagination = (obj as CarouselViewer);
            pagination.CurrentIndex--;
        }

        private static void OnNextCommandExecute(object obj)
        {
            var pagination = (obj as CarouselViewer);
            pagination.CurrentIndex++;
        }
        #endregion

        #region Methods
        #endregion

        #region Function
        #endregion
    }
}
