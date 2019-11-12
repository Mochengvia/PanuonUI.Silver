using Panuon.UI.Silver.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class TagItem : ContentControl
    {
        #region Ctor
       
        static TagItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TagItem), new FrameworkPropertyMetadata(typeof(TagItem)));
            EventManager.RegisterClassHandler(typeof(TagItem), Button.ClickEvent, new RoutedEventHandler(OnRemoveButtonClicked));
        }
        #endregion

        #region RoutedEvent
        public static readonly RoutedEvent RemovingEvent = TagControl.RemovedEvent.AddOwner(typeof(TagItem));

        internal void RaiseRemoving()
        {
            var arg = new RoutedEventArgs(RemovingEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region EventHandler
        private static void OnRemoveButtonClicked(object sender, RoutedEventArgs e)
        {
            var tagItem = sender as TagItem;

            var button = e.OriginalSource as Button;
            if (button?.Name != "PART_RemoveButton")
                return;

            tagItem?.RaiseRemoving();
        }
        #endregion

        #region Property
        /// <summary>
        /// Gets or sets hover brush.
        /// </summary>
        public Brush HoverBrush
        {
            get { return (Brush)GetValue(HoverBrushProperty); }
            set { SetValue(HoverBrushProperty, value); }
        }

        public static readonly DependencyProperty HoverBrushProperty =
            DependencyProperty.Register("HoverBrush", typeof(Brush), typeof(TagItem));

        /// <summary>
        /// Gets or sets removable.
        /// </summary>
        public bool Removable
        {
            get { return (bool)GetValue(RemovableProperty); }
            set { SetValue(RemovableProperty, value); }
        }

        public static readonly DependencyProperty RemovableProperty =
            DependencyProperty.Register("Removable", typeof(bool), typeof(TagItem), new PropertyMetadata(true));

        /// <summary>
        /// Gets or sets remove button style.
        /// </summary>
        public Style RemoveButtonStyle
        {
            get { return (Style)GetValue(RemoveButtonStyleProperty); }
            set { SetValue(RemoveButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty RemoveButtonStyleProperty =
            DependencyProperty.Register("RemoveButtonStyle", typeof(Style), typeof(TagItem));

        /// <summary>
        /// Gets or sets corner radius.
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(TagItem));
        #endregion

       
    }
}
