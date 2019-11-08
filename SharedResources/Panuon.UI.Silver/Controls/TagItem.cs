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
        }
        #endregion

        #region Event
        public event CancelableEventHandler Removing;
        #endregion

        #region RoutedEvent
        public static readonly RoutedEvent RemovedEvent = EventManager.RegisterRoutedEvent("Removed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TagItem));
        public event RoutedEventHandler Removed
        {
            add { AddHandler(RemovedEvent, value); }
            remove { RemoveHandler(RemovedEvent, value); }
        }
        internal void RaiseRemoved()
        {
            var arg = new RoutedEventArgs(RemovedEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region Command
        internal ICommand RemoveCommand
        {
            get { return (ICommand)GetValue(RemoveCommandProperty); }
            set { SetValue(RemoveCommandProperty, value); }
        }

        internal static readonly DependencyProperty RemoveCommandProperty =
            DependencyProperty.Register("RemoveCommand", typeof(ICommand), typeof(TagItem), new PropertyMetadata(new TagItemRemoveCommand()));
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

        #region Internal Calling Methods
        internal bool RaiseRemoving()
        {
            var args = new CancelableEventArgs();
            Removing?.Invoke(this, args);
            return !args.Cancel;
        }
        #endregion
    }

    internal class TagItemRemoveCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var tagItem = parameter as TagItem;
            var result = tagItem.RaiseRemoving();

            if (!result)
                return;
            tagItem.RaiseRemoved();

            var s = tagItem.TemplatedParent;
            if(tagItem.Parent != null && tagItem.Parent is Panel)
            {
                var panel = tagItem.Parent as Panel;
                panel.Children.Remove(tagItem);
            }
        }
    }
}
