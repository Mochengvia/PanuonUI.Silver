using Panuon.UI.Silver.Core;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    [ContentProperty(nameof(Children))]
    public class Carousel : Control
    {
        #region Identifier
        private StackPanel _stkMain;

        private DispatcherTimer _dtAutoPlay;
        #endregion

        #region Constructor
        static Carousel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Carousel), new FrameworkPropertyMetadata(typeof(Carousel)));
        }

        public Carousel()
        {
            Children = new ObservableCollection<UIElement>();
            Loaded += Carousel_Loaded;
            SizeChanged += Carousel_SizeChanged;
        }
        #endregion

        #region RoutedEvent
        public static readonly RoutedEvent IndexChangedEvent = EventManager.RegisterRoutedEvent("IndexChanged", RoutingStrategy.Bubble, typeof(IndexChangedEventHandler), typeof(Carousel));
        public event IndexChangedEventHandler IndexChanged
        {
            add { AddHandler(IndexChangedEvent, value); }
            remove { RemoveHandler(IndexChangedEvent, value); }
        }
        void RaiseIndexChanged(int newValue)
        {
            var arg = new IndexChangedEventArgs(newValue, IndexChangedEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region Property
        /// <summary>
        /// get the children collection.
        /// </summary>
        public ObservableCollection<UIElement> Children
        {
            get { return (ObservableCollection<UIElement>)GetValue(ChildrenProperty); }
            private set { SetValue(ChildrenProperty, value); }
        }

        public static readonly DependencyProperty ChildrenProperty =
            DependencyProperty.Register("Children", typeof(ObservableCollection<UIElement>), typeof(Carousel));

        /// <summary>
        /// get or set orientation
        /// </summary>
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(Carousel), new PropertyMetadata(Orientation.Horizontal));

        /// <summary>
        /// get or set index
        /// </summary>
        public int Index
        {
            get { return (int)GetValue(IndexProperty); }
            set { SetValue(IndexProperty, value); }
        }

        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.Register("Index", typeof(int), typeof(Carousel), new PropertyMetadata(0, OnIndexChanged));

        /// <summary>
        /// Gets or sets animation duration.
        /// </summary>
        public TimeSpan AnimateDuration
        {
            get { return (TimeSpan)GetValue(AnimateDurationProperty); }
            set { SetValue(AnimateDurationProperty, value); }
        }

        public static readonly DependencyProperty AnimateDurationProperty =
            DependencyProperty.Register("AnimateDuration", typeof(TimeSpan), typeof(Carousel), new PropertyMetadata(TimeSpan.FromSeconds(0.5)));

        /// <summary>
        /// Gets or sets recyclable.
        /// </summary>
        public bool Recyclable
        {
            get { return (bool)GetValue(RecyclableProperty); }
            set { SetValue(RecyclableProperty, value); }
        }

        public static readonly DependencyProperty RecyclableProperty =
            DependencyProperty.Register("Recyclable", typeof(bool), typeof(Carousel), new PropertyMetadata(false));


        public TimeSpan AutoPlayInterval
        {
            get { return (TimeSpan)GetValue(AutoPlayIntervalProperty); }
            set { SetValue(AutoPlayIntervalProperty, value); }
        }

        public static readonly DependencyProperty AutoPlayIntervalProperty =
            DependencyProperty.Register("AutoPlayInterval", typeof(TimeSpan), typeof(Carousel), new PropertyMetadata(OnAutoPlayIntervalChanged));


        #endregion

        #region Event Handler
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _stkMain = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(this, 0), 0) as StackPanel;
        }

        private void Carousel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (FrameworkElement child in Children)
            {
                child.Width = ActualWidth;
                child.Height = ActualHeight;
            }
        }

        private void Carousel_Loaded(object sender, RoutedEventArgs e)
        {
            if (Children == null)
                return;

            foreach (FrameworkElement child in Children)
            {
                child.Width = ActualWidth;
                child.Height = ActualHeight;
            }
        }

        private static void OnAutoPlayIntervalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var carousel = d as Carousel;
            carousel.RestartAutoPlayTimer();
        }

        private void DispatcherTimerAutoPlay_Tick(object sender, EventArgs e)
        {
            Index++;
        }

        private static void OnIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var carousel = d as Carousel;
            if (!carousel.IsLoaded)
                return;

            var targetIndex = 0;
            if (!carousel.Recyclable)
                targetIndex = carousel.Index > (carousel.Children.Count - 1) ? carousel.Children.Count - 1 : (carousel.Index < 0 ? 0 : carousel.Index);
            else
                targetIndex = carousel.Index > (carousel.Children.Count - 1) ? 0 : (carousel.Index < 0 ? carousel.Children.Count - 1 : carousel.Index);

            if (targetIndex != carousel.Index)
            {
                carousel.Index = targetIndex;
                return;
            }

            carousel.ResetAutoPlayTimer();
            if (carousel.Orientation == Orientation.Vertical)
            {
                carousel._stkMain.BeginAnimation(StackPanel.MarginProperty, new ThicknessAnimation()
                {
                    To = new Thickness(0, -1 * carousel.ActualHeight * carousel.Index, 0, 0),
                    Duration = carousel.AnimateDuration,
                    EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut }
                });
            }
            else
            {
                carousel._stkMain.BeginAnimation(StackPanel.MarginProperty, new ThicknessAnimation()
                {
                    To = new Thickness(-1 * carousel.ActualWidth * carousel.Index, 0, 0, 0),
                    Duration = carousel.AnimateDuration,
                    EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut }
                });
            }
            carousel.RaiseIndexChanged(targetIndex);
        }

        #endregion

        #region Function
        private void RestartAutoPlayTimer()
        {
            if(_dtAutoPlay != null)
            {
                _dtAutoPlay.Stop();
            }
            if(AutoPlayInterval.TotalSeconds != 0)
            {
                _dtAutoPlay = new DispatcherTimer()
                {
                    Interval = AutoPlayInterval,
                };
                _dtAutoPlay.Tick += DispatcherTimerAutoPlay_Tick;
                _dtAutoPlay.Start();
            }
        }

        private void ResetAutoPlayTimer()
        {
            if (_dtAutoPlay != null)
            {
                _dtAutoPlay.Stop();
                _dtAutoPlay.Start();
            }
        }

        #endregion
    }
}
