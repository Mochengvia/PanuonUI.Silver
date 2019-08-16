using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public class MouseOperationContainer : ContentControl
    {
        #region Identifier
        private DispatcherTimer _dispatcherTimer { get; set; }

        private DateTime _lastMouseDown;

        private DateTime _lastMouseUp { get; set; }

        private Point _lastMouseDownPosition { get; set; }

        private bool _dragHandler;

        private bool _doubleClicked;

        private bool _cancelOperation;
        #endregion

        #region Constructor
        public MouseOperationContainer()
        {
            MouseDown += MouseOperationContainer_MouseDown;
            MouseUp += MouseOperationContainer_MouseUp;
            MouseMove += MouseOperationContainer_MouseMove;
            MouseEnter += MouseOperationContainer_MouseEnter;
            MouseLeave += MouseOperationContainer_MouseLeave;
        }

        #endregion

        #region Routed Event
        /// <summary>
        /// Single click.
        /// </summary>
        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(ClickEventHandler), typeof(MouseOperationContainer));
        public event ClickEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        internal void RaiseClick(Point position)
        {
            if (_cancelOperation)
            {
                _cancelOperation = false;
                return;
            }
            var arg = new ClickEventArgs(position, ClickEvent);
            RaiseEvent(arg);
        }

        /// <summary>
        /// Double click.
        /// </summary>
        public static readonly RoutedEvent DoubleClickEvent = EventManager.RegisterRoutedEvent("DoubleClick", RoutingStrategy.Bubble, typeof(DoubleClickEventHandler), typeof(MouseOperationContainer));
        public event DoubleClickEventHandler DoubleClick
        {
            add { AddHandler(DoubleClickEvent, value); }
            remove { RemoveHandler(DoubleClickEvent, value); }
        }

        internal void RaiseDoubleClick(Point position)
        {
            if (_cancelOperation)
            {
                _cancelOperation = false;
                return;
            }
            var arg = new DoubleClickEventArgs(position, DoubleClickEvent);
            RaiseEvent(arg);
        }

        /// <summary>
        /// Drag area.
        /// </summary>
        public static readonly RoutedEvent DragAreaEvent = EventManager.RegisterRoutedEvent("DragArea", RoutingStrategy.Bubble, typeof(DragAreaEventHandler), typeof(MouseOperationContainer));
        public event DragAreaEventHandler DragArea
        {
            add { AddHandler(DragAreaEvent, value); }
            remove { RemoveHandler(DragAreaEvent, value); }
        }

        internal void RaiseDragArea(Point startPosition, Point endPosition, TimeSpan duration)
        {
            if (_cancelOperation)
            {
                _cancelOperation = false;
                return;
            }
            var arg = new DragAreaEventArgs(startPosition, endPosition, duration, DragAreaEvent);
            RaiseEvent(arg);
        }

        /// <summary>
        /// Long press.
        /// </summary>
        public static readonly RoutedEvent LongPressEvent = EventManager.RegisterRoutedEvent("LongPress", RoutingStrategy.Bubble, typeof(LongPressEventHandler), typeof(MouseOperationContainer));
        public event LongPressEventHandler LongPress
        {
            add { AddHandler(LongPressEvent, value); }
            remove { RemoveHandler(LongPressEvent, value); }
        }

        internal void RaiseLongPress(Point position, TimeSpan duration)
        {
            if (_cancelOperation)
            {
                _cancelOperation = false;
                return;
            }
            var arg = new LongPressEventArgs(position, duration, LongPressEvent);
            RaiseEvent(arg);
        }

        /// <summary>
        /// Draging
        /// </summary>
        public static readonly RoutedEvent DragingEvent = EventManager.RegisterRoutedEvent("Draging", RoutingStrategy.Bubble, typeof(DragingEventHandler), typeof(MouseOperationContainer));
        public event DragingEventHandler Draging
        {
            add { AddHandler(DragingEvent, value); }
            remove { RemoveHandler(DragingEvent, value); }
        }

        internal void RaiseDraging(Point startPosition, Point endPosition)
        {
            if (_cancelOperation)
            {
                _cancelOperation = false;
                return;
            }

            var arg = new DragingEventArgs(startPosition, endPosition, DragingEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region Property
        /// <summary>
        /// Click mode. Fire click event when double clicked, or fire double click event only.
        /// </summary>
        public ClickMode ClickMode
        {
            get { return (ClickMode)GetValue(ClickModeProperty); }
            set { SetValue(ClickModeProperty, value); }
        }

        public static readonly DependencyProperty ClickModeProperty =
            DependencyProperty.Register("ClickMode", typeof(ClickMode), typeof(MouseOperationContainer), new PropertyMetadata(ClickMode.OnlyOne));


        /// <summary>
        /// Minimum double click time.
        /// </summary>
        public double MinimumDoubleClickTime
        {
            get { return (double)GetValue(MinimumDoubleClickTimeProperty); }
            set { SetValue(MinimumDoubleClickTimeProperty, value); }
        }

        public static readonly DependencyProperty MinimumDoubleClickTimeProperty =
            DependencyProperty.Register("MinimumDoubleClickTime", typeof(double), typeof(MouseOperationContainer), new PropertyMetadata(0.2));


        /// <summary>
        ///  Minimum long press time.
        /// </summary>
        public double MinimumLongPressTime
        {
            get { return (double)GetValue(MinimumLongPressTimeProperty); }
            set { SetValue(MinimumLongPressTimeProperty, value); }
        }

        public static readonly DependencyProperty MinimumLongPressTimeProperty =
            DependencyProperty.Register("MinimumLongPressTime", typeof(double), typeof(MouseOperationContainer), new PropertyMetadata(0.5));

        /// <summary>
        /// Drag deviation.
        /// </summary>
        public double DragDeviation
        {
            get { return (double)GetValue(DragDeviationProperty); }
            set { SetValue(DragDeviationProperty, value); }
        }

        public static readonly DependencyProperty DragDeviationProperty =
            DependencyProperty.Register("DragDeviation", typeof(double), typeof(MouseOperationContainer), new PropertyMetadata(0.0));

        #endregion

        #region Calling Methods
        internal void StartTimer()
        {
            _dispatcherTimer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(MinimumDoubleClickTime),
            };
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
            _dispatcherTimer.Start();
        }

        internal void StopTimer()
        {
            if (_dispatcherTimer == null)
                return;
            _dispatcherTimer.Stop();
        }
        #endregion

        #region EventHandler
        private void MouseOperationContainer_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _lastMouseUp = DateTime.Now;
            if (_dragHandler)
            {
                var currentPosition = e.GetPosition(this);
                RaiseDragArea(new Point(_lastMouseDownPosition.X, _lastMouseDownPosition.Y), currentPosition, _lastMouseUp.Subtract(_lastMouseDown));
            }
            else if (_lastMouseUp.Subtract(_lastMouseDown).TotalSeconds > MinimumLongPressTime)
            {
                RaiseLongPress(new Point(_lastMouseDownPosition.X, _lastMouseDownPosition.Y), _lastMouseUp.Subtract(_lastMouseDown));
            }
            else if (!_doubleClicked)
            {
                StopTimer();
                StartTimer();
            }

            _dragHandler = false;
        }

        private void MouseOperationContainer_MouseDown(object sender, MouseButtonEventArgs e)
        {

            _lastMouseDown = DateTime.Now;
            if (!_doubleClicked && DateTime.Now.Subtract(_lastMouseUp).TotalSeconds <= MinimumDoubleClickTime)
            {
                if (ClickMode == ClickMode.OnlyOne)
                    StopTimer();
                RaiseDoubleClick(_lastMouseDownPosition);
                _doubleClicked = true;
            }
            else
            {
                _doubleClicked = false;
                StopTimer();
                StartTimer();
            }
            _lastMouseDownPosition = e.GetPosition(this);

            _dragHandler = false;
        }

        private void MouseOperationContainer_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _cancelOperation = true;
            }
        }

        private void MouseOperationContainer_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _cancelOperation = true;
            }
        }


        private void MouseOperationContainer_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.LeftButton != MouseButtonState.Pressed || _lastMouseDownPosition == null)
                return;

            var currentPosition = e.GetPosition(this);

            if (_dragHandler)
            {
                RaiseDraging(new Point(_lastMouseDownPosition.X, _lastMouseDownPosition.Y), currentPosition);
                return;
            }

            if (Math.Abs(currentPosition.X - _lastMouseDownPosition.X) > DragDeviation || Math.Abs(currentPosition.Y - _lastMouseDownPosition.Y) > DragDeviation)
            {
                _dragHandler = true;
                StopTimer();
            }
        }


        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (Mouse.LeftButton != MouseButtonState.Pressed)
                RaiseClick(_lastMouseDownPosition);

            _dispatcherTimer.Stop();
        }
        #endregion
    }
}
