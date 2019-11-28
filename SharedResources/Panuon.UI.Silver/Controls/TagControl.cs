using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Specialized;
using System;
using System.ComponentModel;
using Panuon.UI.Silver.Core;

namespace Panuon.UI.Silver
{
    public class TagControl : ItemsControl
    {
        #region Ctor
        static TagControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TagControl), new FrameworkPropertyMetadata(typeof(TagControl)));
            EventManager.RegisterClassHandler(typeof(TagControl), TagItem.RemovingEvent, new RoutedEventHandler(OnTagItemRemoved));
        }
        #endregion

        #region Property
        /// <summary>
        /// Gets or sets item height.
        /// </summary>
        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register("ItemHeight", typeof(double), typeof(TagControl));

        /// <summary>
        /// Gets or sets corner radius.
        /// </summary>
        public CornerRadius ItemCornerRadius
        {
            get { return (CornerRadius)GetValue(ItemCornerRadiusProperty); }
            set { SetValue(ItemCornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty ItemCornerRadiusProperty =
            DependencyProperty.Register("ItemCornerRadius", typeof(CornerRadius), typeof(TagControl));

        /// <summary>
        /// Gets or sets ItemRemovable.
        /// </summary>
        public bool ItemRemovable
        {
            get { return (bool)GetValue(ItemRemovableProperty); }
            set { SetValue(ItemRemovableProperty, value); }
        }

        public static readonly DependencyProperty ItemRemovableProperty =
            DependencyProperty.Register("ItemRemovable", typeof(bool), typeof(TagControl), new PropertyMetadata(true));

        // <summary>
        /// Gets or sets horizontal scroll bar visibility.
        /// </summary>
        public ScrollBarVisibility HorizontalScrollBarVisibility
        {
            get { return (ScrollBarVisibility)GetValue(HorizontalScrollBarVisibilityProperty); }
            set { SetValue(HorizontalScrollBarVisibilityProperty, value); }
        }

        public static readonly DependencyProperty HorizontalScrollBarVisibilityProperty =
            DependencyProperty.Register("HorizontalScrollBarVisibility", typeof(ScrollBarVisibility), typeof(TagControl));

        /// <summary>
        /// Gets or sets vertical scroll bar visibility.
        /// </summary>
        public ScrollBarVisibility VerticalScrollBarVisibility
        {
            get { return (ScrollBarVisibility)GetValue(VerticalScrollBarVisibilityProperty); }
            set { SetValue(VerticalScrollBarVisibilityProperty, value); }
        }

        public static readonly DependencyProperty VerticalScrollBarVisibilityProperty =
            DependencyProperty.Register("VerticalScrollBarVisibility", typeof(ScrollBarVisibility), typeof(TagControl));

        /// <summary>
        /// Gets or sets vertical spacing.
        /// </summary>
        public double VerticalSpacing
        {
            get { return (double)GetValue(VerticalSpacingProperty); }
            set { SetValue(VerticalSpacingProperty, value); }
        }

        public static readonly DependencyProperty VerticalSpacingProperty =
            DependencyProperty.Register("VerticalSpacing", typeof(double), typeof(TagControl));

        /// <summary>
        /// Gets or sets horizontal spacing.
        /// </summary>
        public double HorizontalSpacing
        {
            get { return (double)GetValue(HorizontalSpacingProperty); }
            set { SetValue(HorizontalSpacingProperty, value); }
        }

        public static readonly DependencyProperty HorizontalSpacingProperty =
            DependencyProperty.Register("HorizontalSpacing", typeof(double), typeof(TagControl));
        #endregion

       

        #region Event
        public event CancelableEventHandler Removing;

        public static readonly RoutedEvent RemovedEvent = EventManager.RegisterRoutedEvent("Removed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TagControl));
        public event RoutedEventHandler Removed
        {
            add { AddHandler(RemovedEvent, value); }
            remove { RemoveHandler(RemovedEvent, value); }
        }
        #endregion

        #region Override
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TagItem();
        }
        #endregion

        #region EventHandler
        private static void OnTagItemRemoved(object sender, RoutedEventArgs e)
        {
            var tagControl = sender as TagControl;

            var args = new CancelableEventArgs();
            tagControl.Removing?.Invoke(tagControl, args);
            if (args.Cancel)
            {
                e.Handled = true;
                return;
            }

            if(tagControl.ItemsSource == null)
            {
                try
                {
                    tagControl.Items.Remove(e.OriginalSource);
                }
                catch
                {

                }
            }
        }

        #endregion
    }
}
