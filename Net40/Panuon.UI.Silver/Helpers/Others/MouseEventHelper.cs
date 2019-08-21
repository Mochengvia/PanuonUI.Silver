using Panuon.UI.Silver.Core;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public class MouseEventHelper
    {
        #region IsEnabled
        public static bool GetIsEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnabledProperty);
        }

        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnabledProperty, value);
        }

        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(MouseEventHelper), new PropertyMetadata(OnIsEnabledChanged));

        private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as UIElement;
            if (element == null)
                throw new Exception("MouseEventHelper : Target element must be \"UIElement\" type.");

            element.MouseDown -= Element_MouseDown;
            element.MouseUp -= Element_MouseUp;
            element.MouseMove -= Element_MouseMove;
            element.MouseEnter -= Element_MouseEnter;
            element.MouseLeave -= Element_MouseLeave;

            if ((bool)e.NewValue)
            {
                element.MouseDown += Element_MouseDown;
                element.MouseUp += Element_MouseUp;
                element.MouseMove += Element_MouseMove;
                element.MouseEnter += Element_MouseEnter;
                element.MouseLeave += Element_MouseLeave;
            }
        }


        #endregion

        #region MinimuimDoubleClickSeconds
        public static double GetMinimuimDoubleClickSeconds(DependencyObject obj)
        {
            return (double)obj.GetValue(MinimuimDoubleClickSecondsProperty);
        }

        public static void SetMinimuimDoubleClickSeconds(DependencyObject obj, double value)
        {
            obj.SetValue(MinimuimDoubleClickSecondsProperty, value);
        }

        public static readonly DependencyProperty MinimuimDoubleClickSecondsProperty =
            DependencyProperty.RegisterAttached("MinimuimDoubleClickSeconds", typeof(double), typeof(MouseEventHelper), new PropertyMetadata(0.2));
        #endregion

        #region MinimumLongPressSeconds
        public static double GetMinimumLongPressSeconds(DependencyObject obj)
        {
            return (double)obj.GetValue(MinimumLongPressSecondsProperty);
        }

        public static void SetMinimumLongPressSeconds(DependencyObject obj, double value)
        {
            obj.SetValue(MinimumLongPressSecondsProperty, value);
        }

        public static readonly DependencyProperty MinimumLongPressSecondsProperty =
            DependencyProperty.RegisterAttached("MinimumLongPressSeconds", typeof(double), typeof(MouseEventHelper), new PropertyMetadata(0.5));
        #endregion

        #region MinimumDragDeviation
        public static double GetMinimumDragDeviation(DependencyObject obj)
        {
            return (double)obj.GetValue(MinimumDragDeviationProperty);
        }

        public static void SetMinimumDragDeviation(DependencyObject obj, double value)
        {
            obj.SetValue(MinimumDragDeviationProperty, value);
        }

        public static readonly DependencyProperty MinimumDragDeviationProperty =
            DependencyProperty.RegisterAttached("MinimumDragDeviation", typeof(double), typeof(MouseEventHelper), new PropertyMetadata(0.0));
        #endregion

        #region RoutedEvent

        #region Click
        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(ClickEventHandler), typeof(MouseEventHelper));
        public static void AddClickHandler(DependencyObject d, ClickEventHandler handler)
        {
            var element = d as UIElement;
            if (element == null)
                return;

            element.AddHandler(ClickEvent, handler);
        }
        public static void RemoveClickHandler(DependencyObject d, ClickEventHandler handler)
        {
            var element = d as UIElement;
            if (element == null)
                return;
            element.RemoveHandler(ClickEvent, handler);
        }

        public static void RaiseClickEvent(UIElement element, Point position)
        {
            if (GetCancelOperation(element))
            {
                SetCancelOperation(element, false);
                return;
            }
            var arg = new ClickEventArgs(position, ClickEvent);
            element.RaiseEvent(arg);
        }
        #endregion

        #region DoubleClick
        public static readonly RoutedEvent DoubleClickEvent = EventManager.RegisterRoutedEvent("DoubleClick", RoutingStrategy.Bubble, typeof(DoubleClickEventHandler), typeof(MouseEventHelper));
        public static void AddDoubleClickHandler(DependencyObject d, DoubleClickEventHandler handler)
        {
            var element = d as UIElement;
            if (element == null)
                return;
            element.AddHandler(DoubleClickEvent, handler);

        }
        public static void RemoveDoubleClickHandler(DependencyObject d, DoubleClickEventHandler handler)
        {
            var element = d as UIElement;
            if (element == null)
                return;
            element.RemoveHandler(DoubleClickEvent, handler);

        }

        public static void RaiseDoubleClickEvent(UIElement element, Point position)
        {
            if (GetCancelOperation(element))
            {
                SetCancelOperation(element, false);
                return;
            }
            var arg = new DoubleClickEventArgs(position, DoubleClickEvent);
            element.RaiseEvent(arg);
        }
        #endregion

        #region LongPress
        public static readonly RoutedEvent LongPressEvent = EventManager.RegisterRoutedEvent("LongPress", RoutingStrategy.Bubble, typeof(LongPressEventHandler), typeof(MouseEventHelper));
        public static void AddLongPressHandler(DependencyObject d, LongPressEventHandler handler)
        {
            var element = d as UIElement;
            if (element == null)
                return;
            element.AddHandler(LongPressEvent, handler);

        }
        public static void RemoveLongPressHandler(DependencyObject d, LongPressEventHandler handler)
        {
            var element = d as UIElement;
            if (element == null)
                return;
            element.RemoveHandler(LongPressEvent, handler);

        }

        public static void RaiseLongPressEvent(UIElement element, Point position, TimeSpan duration)
        {
            if (GetCancelOperation(element))
            {
                SetCancelOperation(element, false);
                return;
            }
            var arg = new LongPressEventArgs(position, duration, LongPressEvent);
            element.RaiseEvent(arg);
        }
        #endregion

        #region Draging
        public static readonly RoutedEvent DragingEvent = EventManager.RegisterRoutedEvent("Draging", RoutingStrategy.Bubble, typeof(DragingEventHandler), typeof(MouseEventHelper));
        public static void AddDragingHandler(DependencyObject d, DragingEventHandler handler)
        {
            var element = d as UIElement;
            if (element == null)
                return;
            element.AddHandler(DragingEvent, handler);

        }
        public static void RemoveDragingHandler(DependencyObject d, DragingEventHandler handler)
        {
            var element = d as UIElement;
            if (element == null)
                return;
            element.RemoveHandler(DragingEvent, handler);
        }

        public static void RaiseDragingEvent(UIElement element, Point startPosition, Point endPosition)
        {
            if (GetCancelOperation(element))
            {
                SetCancelOperation(element, false);
                return;
            }
            var arg = new DragingEventArgs(startPosition, endPosition, DragingEvent);
            element.RaiseEvent(arg);
        }
        #endregion

        #region DragArea
        public static readonly RoutedEvent DragAreaEvent = EventManager.RegisterRoutedEvent("DragArea", RoutingStrategy.Bubble, typeof(DragAreaEventHandler), typeof(MouseEventHelper));
        public static void AddDragAreaHandler(DependencyObject d, DragAreaEventHandler handler)
        {
            var element = d as UIElement;
            if (element == null)
                return;
            element.AddHandler(DragAreaEvent, handler);
        }
        public static void RemoveDragAreaHandler(DependencyObject d, DragAreaEventHandler handler)
        {
            var element = d as UIElement;
            if (element == null)
                return;
            element.RemoveHandler(DragAreaEvent, handler);
        }

        public static void RaiseDragAreaEvent(UIElement element, Point startPosition, Point endPosition, TimeSpan duration)
        {
            if (GetCancelOperation(element))
            {
                SetCancelOperation(element, false);
                return;
            }
            var arg = new DragAreaEventArgs(startPosition, endPosition, duration, DragAreaEvent);
            element.RaiseEvent(arg);
        }
        #endregion

        #endregion

        #region (InternalProperty)

        #region DispatcherTimer
        internal static DispatcherTimer GetDispatcherTimer(DependencyObject obj)
        {
            return (DispatcherTimer)obj.GetValue(DispatcherTimerProperty);
        }

        internal static void SetDispatcherTimer(DependencyObject obj, DispatcherTimer value)
        {
            obj.SetValue(DispatcherTimerProperty, value);
        }

        internal static readonly DependencyProperty DispatcherTimerProperty =
            DependencyProperty.RegisterAttached("DispatcherTimer", typeof(DispatcherTimer), typeof(MouseEventHelper));
        #endregion

        #region LastMouseDown
        internal static DateTime GetLastMouseDown(DependencyObject obj)
        {
            return (DateTime)obj.GetValue(LastMouseDownProperty);
        }

        internal static void SetLastMouseDown(DependencyObject obj, DateTime value)
        {
            obj.SetValue(LastMouseDownProperty, value);
        }

        internal static readonly DependencyProperty LastMouseDownProperty =
            DependencyProperty.RegisterAttached("LastMouseDown", typeof(DateTime), typeof(MouseEventHelper));
        #endregion

        #region LastMouseUp
        internal static DateTime GetLastMouseUp(DependencyObject obj)
        {
            return (DateTime)obj.GetValue(LastMouseUpProperty);
        }

        internal static void SetLastMouseUp(DependencyObject obj, DateTime value)
        {
            obj.SetValue(LastMouseUpProperty, value);
        }

        internal static readonly DependencyProperty LastMouseUpProperty =
            DependencyProperty.RegisterAttached("LastMouseUp", typeof(DateTime), typeof(MouseEventHelper));
        #endregion

        #region LastMouseDownPosition
        internal static Point GetLastMouseDownPosition(DependencyObject obj)
        {
            return (Point)obj.GetValue(LastMouseDownPositionProperty);
        }

        internal static void SetLastMouseDownPosition(DependencyObject obj, Point value)
        {
            obj.SetValue(LastMouseDownPositionProperty, value);
        }

        internal static readonly DependencyProperty LastMouseDownPositionProperty =
            DependencyProperty.RegisterAttached("LastMouseDownPosition", typeof(Point), typeof(MouseEventHelper));
        #endregion

        #region DragHandler
        internal static bool GetDragHandler(DependencyObject obj)
        {
            return (bool)obj.GetValue(DragHandlerProperty);
        }

        internal static void SetDragHandler(DependencyObject obj, bool value)
        {
            obj.SetValue(DragHandlerProperty, value);
        }

        internal static readonly DependencyProperty DragHandlerProperty =
            DependencyProperty.RegisterAttached("DragHandler", typeof(bool), typeof(MouseEventHelper));
        #endregion

        #region DoubleClicked
        internal static bool GetDoubleClicked(DependencyObject obj)
        {
            return (bool)obj.GetValue(DoubleClickedProperty);
        }

        internal static void SetDoubleClicked(DependencyObject obj, bool value)
        {
            obj.SetValue(DoubleClickedProperty, value);
        }

        internal static readonly DependencyProperty DoubleClickedProperty =
            DependencyProperty.RegisterAttached("DoubleClicked", typeof(bool), typeof(MouseEventHelper));
        #endregion

        #region CancelOperation
        internal static bool GetCancelOperation(DependencyObject obj)
        {
            return (bool)obj.GetValue(CancelOperationProperty);
        }

        internal static void SetCancelOperation(DependencyObject obj, bool value)
        {
            obj.SetValue(CancelOperationProperty, value);
        }


        internal static readonly DependencyProperty CancelOperationProperty =
            DependencyProperty.RegisterAttached("CancelOperation", typeof(bool), typeof(MouseEventHelper));
        #endregion

        #endregion

        #region EventHandler
        private static void Element_MouseLeave(object sender, MouseEventArgs e)
        {
            var element = sender as UIElement;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                SetCancelOperation(element, true);
            }
        }

        private static void Element_MouseEnter(object sender, MouseEventArgs e)
        {
            var element = sender as UIElement;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                SetCancelOperation(element, true);
            }
        }

        private static void Element_MouseMove(object sender, MouseEventArgs e)
        {
            var element = sender as UIElement;
            var lastMouseUp = GetLastMouseUp(element);
            var lastMouseDown = GetLastMouseDown(element);
            var lastMouseDownPosition = GetLastMouseDownPosition(element);
            var dragDeviation = GetMinimumDragDeviation(element);

            if (e.LeftButton != MouseButtonState.Pressed || lastMouseDownPosition == null)
                return;

            var currentPosition = e.GetPosition(element);

            if (GetDragHandler(element))
            {
                RaiseDragingEvent(element, new Point(lastMouseDownPosition.X, lastMouseDownPosition.Y), currentPosition);
                return;
            }

            if (Math.Abs(currentPosition.X - lastMouseDownPosition.X) > dragDeviation || Math.Abs(currentPosition.Y - lastMouseDownPosition.Y) > dragDeviation)
            {
                SetDragHandler(element, true);
                StopTimer(element);
            }
        }

        private static void Element_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var element = sender as UIElement;

            SetLastMouseUp(element, DateTime.Now);

            var lastMouseUp = GetLastMouseUp(element);
            var lastMouseDown = GetLastMouseDown(element);
            var lastMouseDownPosition = GetLastMouseDownPosition(element);


            if (GetDragHandler(element))
            {
                var currentPosition = e.GetPosition(element);
                RaiseDragAreaEvent(element, new Point(lastMouseDownPosition.X, lastMouseDownPosition.Y), currentPosition, lastMouseUp.Subtract(lastMouseDown));
            }
            else if (lastMouseUp.Subtract(lastMouseDown).TotalSeconds > GetMinimumLongPressSeconds(element))
            {
                RaiseLongPressEvent(element, new Point(lastMouseDownPosition.X, lastMouseDownPosition.Y), lastMouseUp.Subtract(lastMouseDown));
            }
            else if (!GetDoubleClicked(element))
            {
                StopTimer(element);
                StartTimer(element);
            }
        }

        private static void Element_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var element = sender as UIElement;

            SetLastMouseDown(element, DateTime.Now);

            var lastMouseUp = GetLastMouseUp(element);
            var lastMouseDownPosition = GetLastMouseDownPosition(element);

            if (!GetDoubleClicked(element) && DateTime.Now.Subtract(lastMouseUp).TotalSeconds <= GetMinimuimDoubleClickSeconds(element))
            {
                StopTimer(element);
                RaiseDoubleClickEvent(element, lastMouseDownPosition);
                SetDoubleClicked(element, true);
            }
            else
            {
                SetDoubleClicked(element, false);
                StopTimer(element);
                StartTimer(element);
            }
            SetLastMouseDownPosition(element, e.GetPosition(element));
            SetDragHandler(element, false);
        }
        #endregion

        #region Function
        private static void StartTimer(UIElement element)
        {
            var timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(GetMinimuimDoubleClickSeconds(element)),
                Tag = element,
            };
            timer.Tick += Timer_Tick;
            timer.Start();
            SetDispatcherTimer(element, timer);
        }

        private static void StopTimer(UIElement element)
        {
            var timer = GetDispatcherTimer(element);
            if (timer == null)
                return;

            timer.Stop();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            var timer = sender as DispatcherTimer;
            var element = timer.Tag as UIElement;

            if (Mouse.LeftButton != MouseButtonState.Pressed)
                RaiseClickEvent(element, GetLastMouseDownPosition(element));

            timer.Stop();
        }
        #endregion
    }
}
