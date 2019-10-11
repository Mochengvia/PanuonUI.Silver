using Panuon.UI.Silver.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    /// <summary>
    /// WaterfallViewer.xaml 的交互逻辑
    /// </summary>
    [ContentProperty(nameof(Children))]
    public partial class WaterfallViewer : UserControl
    {
        #region Identifier
        private double _lastLazyLoadingOffset;

        private int _lastLazyLoadingChildrenCount;

        #endregion

        public WaterfallViewer()
        {
            InitializeComponent();
            Children = WaterfallPanel.Children;
        }

        
        #region RoutedEvent
        /// <summary>
        /// LazyLoading.
        /// </summary>
        public static readonly RoutedEvent LazyLoadingEvent = EventManager.RegisterRoutedEvent("LazyLoading", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WaterfallViewer));
        public event RoutedEventHandler LazyLoading
        {
            add { AddHandler(LazyLoadingEvent, value); }
            remove { RemoveHandler(LazyLoadingEvent, value); }
        }

        internal void RaiseLazyLoading()
        {
            var arg = new RoutedEventArgs(LazyLoadingEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region Property
        public UIElementCollection Children
        {
            get { return (UIElementCollection)GetValue(ChildrenProperty); }
            set { SetValue(ChildrenProperty, value); }
        }

        public static readonly DependencyProperty ChildrenProperty =
            DependencyProperty.Register("Children", typeof(UIElementCollection), typeof(WaterfallViewer));

        /// <summary>
        /// Groups
        /// </summary>
        public int Groups
        {
            get { return (int)GetValue(GroupsProperty); }
            set { SetValue(GroupsProperty, value); }
        }

        public static readonly DependencyProperty GroupsProperty =
            DependencyProperty.Register("Groups", typeof(int), typeof(WaterfallViewer), new PropertyMetadata(2));

        /// <summary>
        /// Orientation
        /// </summary>
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(WaterfallViewer), new PropertyMetadata(Orientation.Vertical, OnOrientationChanged));

       
        /// <summary>
        /// Vertical spacing.
        /// </summary>
        public double VerticalSpacing
        {
            get { return (double)GetValue(VerticalSpacingProperty); }
            set { SetValue(VerticalSpacingProperty, value); }
        }

        public static readonly DependencyProperty VerticalSpacingProperty =
            DependencyProperty.Register("VerticalSpacing", typeof(double), typeof(WaterfallViewer), new PropertyMetadata(10.0));


        /// <summary>
        /// Horizontal spacing.
        /// </summary>
        public double HorizontalSpacing
        {
            get { return (double)GetValue(HorizontalSpacingProperty); }
            set { SetValue(HorizontalSpacingProperty, value); }
        }

        public static readonly DependencyProperty HorizontalSpacingProperty =
            DependencyProperty.Register("HorizontalSpacing", typeof(double), typeof(WaterfallViewer), new PropertyMetadata(10.0));


        /// <summary>
        /// Loading style.
        /// </summary>
        public LoadingStyle LoadingStyle
        {
            get { return (LoadingStyle)GetValue(LoadingStyleProperty); }
            set { SetValue(LoadingStyleProperty, value); }
        }

        public static readonly DependencyProperty LoadingStyleProperty =
            DependencyProperty.Register("LoadingStyle", typeof(LoadingStyle), typeof(WaterfallViewer), new PropertyMetadata(LoadingStyle.Standard));


        /// <summary>
        /// Loading stroke
        /// </summary>
        public Brush LoadingBackground
        {
            get { return (Brush)GetValue(LoadingBackgroundProperty); }
            set { SetValue(LoadingBackgroundProperty, value); }
        }

        public static readonly DependencyProperty LoadingBackgroundProperty =
            DependencyProperty.Register("LoadingBackground", typeof(Brush), typeof(WaterfallViewer), new PropertyMetadata(Brushes.Gray));


        /// <summary>
        /// Loading stroke cover
        /// </summary>
        public Brush LoadingForeground
        {
            get { return (Brush)GetValue(LoadingForegroundProperty); }
            set { SetValue(LoadingForegroundProperty, value); }
        }

        public static readonly DependencyProperty LoadingForegroundProperty =
            DependencyProperty.Register("LoadingForeground", typeof(Brush), typeof(WaterfallViewer), new PropertyMetadata(Brushes.Gray));

        /// <summary>
        /// Is loading visible.
        /// </summary>
        public bool IsLazyLoadingEnabled
        {
            get { return (bool)GetValue(IsLazyLoadingEnabledProperty); }
            set { SetValue(IsLazyLoadingEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsLazyLoadingEnabledProperty =
            DependencyProperty.Register("IsLazyLoadingEnabled", typeof(bool), typeof(WaterfallViewer), new PropertyMetadata(OnIsLazyLoadingEnabledChanged));


        /// <summary>
        /// Gets or sets is children square.
        /// </summary>
        public ChildrenShape ChildrenShape
        {
            get { return (ChildrenShape)GetValue(ChildrenShapeProperty); }
            set { SetValue(ChildrenShapeProperty, value); }
        }

        public static readonly DependencyProperty ChildrenShapeProperty =
            DependencyProperty.Register("ChildrenShape", typeof(ChildrenShape), typeof(WaterfallViewer));



        public double ChildrenShapeSizeDelta
        {
            get { return (double)GetValue(ChildrenShapeSizeDeltaProperty); }
            set { SetValue(ChildrenShapeSizeDeltaProperty, value); }
        }

        public static readonly DependencyProperty ChildrenShapeSizeDeltaProperty =
            DependencyProperty.Register("ChildrenShapeSizeDelta", typeof(double), typeof(WaterfallViewer));


        #endregion

        #region EventHandler

        private static void OnOrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var waterFall = d as WaterfallViewer;
            if(waterFall.Orientation == Orientation.Vertical)
            {
                waterFall.SvMain.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                waterFall.SvMain.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            }
            else
            {
                waterFall.SvMain.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
                waterFall.SvMain.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            }
        }

        private static void OnIsLazyLoadingEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var waterFall = d as WaterfallViewer;

            waterFall._lastLazyLoadingOffset = 0;
            waterFall._lastLazyLoadingChildrenCount = 0;

            waterFall.SvMain.ScrollChanged -= waterFall.SvMain_ScrollChanged;

            if(waterFall.IsLazyLoadingEnabled)
                waterFall.SvMain.ScrollChanged += waterFall.SvMain_ScrollChanged;
        }

        private void SvMain_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (Orientation == Orientation.Vertical)
            {
                if (e.VerticalOffset >= (SvMain.ScrollableHeight - 75) && (WaterfallPanel.ActualHeight != _lastLazyLoadingOffset || Children.Count != _lastLazyLoadingChildrenCount))
                {
                    _lastLazyLoadingOffset = WaterfallPanel.ActualHeight;
                    _lastLazyLoadingChildrenCount = Children.Count;
                    RaiseLazyLoading();
                }
            }
            else
            {
                if (e.HorizontalOffset >= (SvMain.ScrollableWidth - 75) && (WaterfallPanel.ActualWidth != _lastLazyLoadingOffset || Children.Count != _lastLazyLoadingChildrenCount))
                {
                    _lastLazyLoadingOffset = WaterfallPanel.ActualWidth;
                    _lastLazyLoadingChildrenCount = Children.Count;
                    RaiseLazyLoading();
                }
            }
        }
        #endregion


    }
}
