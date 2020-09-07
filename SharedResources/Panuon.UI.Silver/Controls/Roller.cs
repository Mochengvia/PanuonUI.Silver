using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class Roller : Selector
    {
        #region Fields
        private StackPanel _stkPanel;

        private bool _isDraging;

        private Point _lastPosition;

        private object _mouseDownItem;

        private double _delta;

        private bool _isFirstLoad;
        #endregion

        #region Ctor
        static Roller()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Roller), new FrameworkPropertyMetadata(typeof(Roller)));
        }
        public Roller()
        {
            ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
        }

        private void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        {
            if (!_isFirstLoad && ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
            {
                if (SelectedItem != null)
                {
                    var rollerItem = ItemContainerGenerator.ContainerFromItem(SelectedItem) as RollerItem;
                    if(rollerItem != null)
                    {
                        rollerItem.InternalSetIsSelected(true);
                    }
                }
                _isFirstLoad = true;
            }
        }
        #endregion

        #region Events
        public event SelectionChangingRoutedEventHandler SelectionChanging
        {
            add { AddHandler(SelectionChangingEvent, value); }
            remove { RemoveHandler(SelectionChangingEvent, value); }
        }

        public static readonly RoutedEvent SelectionChangingEvent =
            EventManager.RegisterRoutedEvent("SelectionChanging", RoutingStrategy.Bubble, typeof(SelectionChangingRoutedEventHandler), typeof(Roller));
        #endregion

        #region Overrides
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is RollerItem;
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new RollerItem();
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _stkPanel = Template?.FindName("PART_Container", this) as StackPanel;
            if (_stkPanel == null)
            {
                throw new Exception("Can not find \"PART_Container\" in Roller.");
            }
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            
            base.OnRenderSizeChanged(sizeInfo);
            UpdateRoller();
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            var args = new SelectionChangingRoutedEventArgs(SelectionChangingEvent, e.RemovedItems, e.AddedItems, SelectedIndex);
             RaiseEvent(args);
            if (args.Cancel)
            {
                e.Handled = true;
                return;
            }
            foreach(var item in e.AddedItems)
            {
                var rollerItem = ItemContainerGenerator.ContainerFromItem(item) as RollerItem;
                if(rollerItem != null)
                {
                    rollerItem.InternalSetIsSelected(true);
                }
            }
            foreach (var item in e.RemovedItems)
            {
                var rollerItem = ItemContainerGenerator.ContainerFromItem(item) as RollerItem;
                if (rollerItem != null)
                {
                    rollerItem.InternalSetIsSelected(false);
                }
            }
            
            UpdateRoller();
            base.OnSelectionChanged(e);
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);
            _mouseDownItem = e.Source;
        }

        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonUp(e);
            var item = e.Source is Roller ? GetContext(VisualTreeHelper.GetParent(e.OriginalSource as DependencyObject)) : e.Source as DependencyObject;
            if (!_isDraging && item != null && Items.Contains(item))
            {
                if (SelectedItem != item)
                {
                    SelectedItem = item;
                }
            }
            if (_isDraging && _mouseDownItem != null)
            {
                OnRollingCompleted();
            }
            _isDraging = false;
            _mouseDownItem = null;
        }

        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);
            var postion = e.GetPosition(this);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (_lastPosition.X != 0 || _lastPosition.Y != 0)
                {
                    var delta = postion.Y - _lastPosition.Y;
                    Rolling(delta);
                    _isDraging = true;
                }
                _lastPosition = postion;
            }
            else
            {
                _isDraging = false;
                _lastPosition = new Point(0, 0);
            }
        }

        protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
        {
            base.OnPreviewMouseWheel(e);
            Rolling(e.Delta);
            e.Handled = true;
        }
        #endregion

        #region Properties

        #region AnimationDuration
        public TimeSpan AnimationDuration
        {
            get { return (TimeSpan)GetValue(AnimationDurationProperty); }
            set { SetValue(AnimationDurationProperty, value); }
        }

        public static readonly DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register("AnimationDuration", typeof(TimeSpan), typeof(Roller), new PropertyMetadata(TimeSpan.FromSeconds(0.5)));
        #endregion

        #region AnimationEase
        public AnimationEase AnimationEase
        {
            get { return (AnimationEase)GetValue(AnimationEaseProperty); }
            set { SetValue(AnimationEaseProperty, value); }
        }

        public static readonly DependencyProperty AnimationEaseProperty =
            DependencyProperty.Register("AnimationEase", typeof(AnimationEase), typeof(Roller), new PropertyMetadata(AnimationEase.CubicOut));
        #endregion

        #endregion

        #region Methods
        #endregion

        #region Event Handlers
        #endregion

        #region Functions
        private void UpdateRoller()
        {
            if (RenderSize.Height == 0)
            {
                return;
            }
            
            var offset = RenderSize.Height / 2;

            if (Items.Count > 0)
            {
                if (SelectedIndex < 0)
                {
                    var firstItem = GetItem(0) as UIElement;
                    if (firstItem != null)
                    {
                        offset += firstItem.RenderSize.Height / 2;
                    }
                }
                for (var i = 0; i <= SelectedIndex; i++)
                {
                    var targetItem = GetItem(i) as UIElement;
                    if (targetItem != null)
                    {
                        if (SelectedIndex == i)
                        {
                            offset -= targetItem.RenderSize.Height / 2;
                        }
                        else
                        {
                            offset -= targetItem.RenderSize.Height;
                        }
                    }
                }
                if (IsLoaded)
                {
                    UIElementUtils.BeginAnimation(_stkPanel, StackPanel.MarginProperty, new Thickness(0, offset, 0, 0), AnimationDuration, AnimationEase, false);
                }
                else
                {
                    _stkPanel.Margin = new Thickness(0, offset, 0, 0);
                }
            }
        }

        private void Rolling(double delta)
        {
            if (Items.Count < 0)
            {
                return;
            }
            _delta += delta;
            var item = (SelectedIndex < 0 ? GetItem(0) : GetItem(SelectedIndex)) as UIElement;
            if (item == null)
            {
                return;
            }
            if (Math.Abs(_delta) > item.RenderSize.Height)
            {
                var newIndex = _delta > 0 ? (SelectedIndex - 1) : (SelectedIndex + 1);
                ChangeSelectedIndex(newIndex);
                _delta = 0;
            }
        }

        private void ChangeSelectedIndex(int newIndex)
        {
            var index = CoreceIndex(newIndex);
            var forward = newIndex < SelectedIndex;
            var availableIndex = GetAvailableIndex(newIndex, forward);

            if (availableIndex < -1)
            {
                availableIndex = -1;
            }
            if(availableIndex > Items.Count - 1)
            {
                availableIndex = Items.Count - 1;
            }

            SelectedIndex = availableIndex;
        }

        private int GetAvailableIndex(int loopIndex, bool forward)
        {
            while (true)
            {
                var item = GetItem(loopIndex);
                if (item == null || item.IsEnabled)
                {
                    break;
                }
                loopIndex = forward ? (loopIndex - 1) : (loopIndex + 1);
            }
            return loopIndex;

        }
        private int CoreceIndex(int newIndex)
        {
            if (newIndex < 0)
            {
                 if (newIndex < -1)
                {
                    newIndex = -1;
                }
            }
            else if (newIndex > Items.Count - 1)
            {
                newIndex = Items.Count - 1;
            }
            return newIndex;
        }

        private void OnRollingCompleted()
        {
            _delta = 0;
            _lastPosition = new Point(0, 0);
        }

        private UIElement GetItem(int index)
        {
            if(index < 0 || index > Items.Count - 1)
            {
                return null;
            }
            return ItemContainerGenerator.ContainerFromIndex(index) as UIElement;
        }

        private object GetContext(DependencyObject container)
        {
            if (container == null)
            {
                return null;
            }
            return ItemContainerGenerator.ItemFromContainer(container);
        }
        #endregion
    }
}
