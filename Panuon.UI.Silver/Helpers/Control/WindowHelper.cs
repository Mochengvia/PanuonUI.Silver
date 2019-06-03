using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public class WindowHelper
    {
        #region Import
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);
        #endregion

        #region Identity
        private enum ResizeDirection
        {
            Left = 1,
            Right = 2,
            Top = 3,
            TopLeft = 4,
            TopRight = 5,
            Bottom = 6,
            BottomLeft = 7,
            BottomRight = 8,
        }

        #endregion

        #region Applying
        public static bool GetApplying(DependencyObject obj)
        {
            return (bool)obj.GetValue(ApplyingProperty);
        }

        public static void SetApplying(DependencyObject obj, bool value)
        {
            obj.SetValue(ApplyingProperty, value);
        }

        public static readonly DependencyProperty ApplyingProperty =
            DependencyProperty.RegisterAttached("Applying", typeof(bool), typeof(WindowHelper), new PropertyMetadata(OnApplyingChanged));

        private static void OnApplyingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            try
            {
                if (window.Style != window.FindResource("PanuonWindow"))
                    window.Style = window.FindResource("PanuonWindow") as Style;
            }
            catch
            {
                throw new Exception("Style resources not found. Have you imported resource dictionary in your project ?");
            }
        }
        #endregion

        #region WindowAnimation
        public static WindowAnimation GetWindowAnimation(DependencyObject obj)
        {
            return (WindowAnimation)obj.GetValue(WindowAnimationProperty);
        }

        public static void SetWindowAnimation(DependencyObject obj, WindowAnimation value)
        {
            obj.SetValue(WindowAnimationProperty, value);
        }

        public static readonly DependencyProperty WindowAnimationProperty =
            DependencyProperty.RegisterAttached("WindowAnimation", typeof(WindowAnimation), typeof(WindowHelper));

        #endregion

        #region OpenCoverMask
        public static bool GetOpenCoverMask(DependencyObject obj)
        {
            return (bool)obj.GetValue(OpenCoverMaskProperty);
        }

        public static void SetOpenCoverMask(DependencyObject obj, bool value)
        {
            obj.SetValue(OpenCoverMaskProperty, value);
        }

        public static readonly DependencyProperty OpenCoverMaskProperty =
            DependencyProperty.RegisterAttached("OpenCoverMask", typeof(bool), typeof(WindowHelper));
        #endregion

        #region Icon
        public static object GetIcon(DependencyObject obj)
        {
            return (object)obj.GetValue(IconProperty);
        }

        public static void SetIcon(DependencyObject obj, object value)
        {
            obj.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(WindowHelper));
        #endregion

        #region NavbarBackground
        public static Brush GetNavbarBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(NavbarBackgroundProperty);
        }

        public static void SetNavbarBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(NavbarBackgroundProperty, value);
        }

        public static readonly DependencyProperty NavbarBackgroundProperty =
            DependencyProperty.RegisterAttached("NavbarBackground", typeof(Brush), typeof(WindowHelper));
        #endregion

        #region NavbarHeight
        public static double GetNavbarHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(NavbarHeightProperty);
        }

        public static void SetNavbarHeight(DependencyObject obj, double value)
        {
            obj.SetValue(NavbarHeightProperty, value);
        }

        public static readonly DependencyProperty NavbarHeightProperty =
            DependencyProperty.RegisterAttached("NavbarHeight", typeof(double), typeof(WindowHelper));
        #endregion

        #region ExtendNavControl
        public static UIElement GetExtendNavControl(DependencyObject obj)
        {
            return (UIElement)obj.GetValue(ExtendNavControlProperty);
        }

        public static void SetExtendNavControl(DependencyObject obj, UIElement value)
        {
            obj.SetValue(ExtendNavControlProperty, value);
        }

        public static readonly DependencyProperty ExtendNavControlProperty =
            DependencyProperty.RegisterAttached("ExtendNavControl", typeof(UIElement), typeof(WindowHelper));
        #endregion

        #region DisableCloseButton
        public static bool GetDisableCloseButton(DependencyObject obj)
        {
            return (bool)obj.GetValue(DisableCloseButtonProperty);
        }

        public static void SetDisableCloseButton(DependencyObject obj, bool value)
        {
            obj.SetValue(DisableCloseButtonProperty, value);
        }

        public static readonly DependencyProperty DisableCloseButtonProperty =
            DependencyProperty.RegisterAttached("DisableCloseButton", typeof(bool), typeof(WindowHelper));
        #endregion

        #region (Internal) WindowHook
        internal static bool GetWindowHook(DependencyObject obj)
        {
            return (bool)obj.GetValue(WindowHookProperty);
        }

        internal static void SetWindowHook(DependencyObject obj, bool value)
        {
            obj.SetValue(WindowHookProperty, value);
        }

        internal static readonly DependencyProperty WindowHookProperty =
            DependencyProperty.RegisterAttached("WindowHook", typeof(bool), typeof(WindowHelper), new PropertyMetadata(OnWindowHookChanged));

        private static void OnWindowHookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;

            window.Loaded += Window_Loaded;
            window.Closing += Window_Closing;
        }

        #endregion

        #region (Internal) Commands
        internal static ICommand GetMaxCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(MaxCommandProperty);
        }

        internal static void SetMaxCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(MaxCommandProperty, value);
        }

        internal static readonly DependencyProperty MaxCommandProperty =
            DependencyProperty.RegisterAttached("MaxCommand", typeof(ICommand), typeof(WindowHelper), new PropertyMetadata(new MaxCommand()));

        internal static ICommand GetMinCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(MinCommandProperty);
        }

        internal static void SetMinCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(MinCommandProperty, value);
        }

        internal static readonly DependencyProperty MinCommandProperty =
            DependencyProperty.RegisterAttached("MinCommand", typeof(ICommand), typeof(WindowHelper), new PropertyMetadata(new MinCommand()));

        internal static ICommand GetCloseCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CloseCommandProperty);
        }

        internal static void SetCloseCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CloseCommandProperty, value);
        }

        internal static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.RegisterAttached("CloseCommand", typeof(ICommand), typeof(WindowHelper), new PropertyMetadata(new CloseCommand()));

        #endregion

        #region(Internal) DialogResult
        internal static bool? GetDialogResult(DependencyObject obj)
        {
            return (bool?)obj.GetValue(DialogResultProperty);
        }

        internal static void SetDialogResult(DependencyObject obj, bool? value)
        {
            obj.SetValue(DialogResultProperty, value);
        }

        internal static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.RegisterAttached("DialogResult", typeof(bool?), typeof(WindowHelper));
        #endregion

        #region APIs
        public static void ShowPopup(Window window, string content, double durationSeconds = 2)
        {
            var grid = window.Content as Grid;
            if (grid == null)
                throw new Exception("The window which to show popup must has \"Grid\" as root node.");

            var border = new Border()
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AA3E3E3E")),
                CornerRadius = new CornerRadius(3),
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 20),
                Opacity = 0,
                Effect = new DropShadowEffect()
                {
                    ShadowDepth = 0,
                    Color = Colors.DimGray,
                    Opacity = 0.7,
                }
            };
            var textBlock = new TextBlock()
            {
                Text = content,
                Foreground = new SolidColorBrush(Colors.White),
                FontSize = 14,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(30, 10, 30, 10),
            };
            border.Child = textBlock;
            grid.Children.Add(border);
            BeginPopupInAnimation(border);
            var timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(durationSeconds) };
            timer.Tick += delegate
            {
                BeginPopupOutAnimation(border, grid);
            };
            timer.Start();
        }

        public static void ShowMessage(string content, string title = "Tips", Window owner = null, bool showInTaskbar = true, bool autoCoverMask = true)
        {
            var msgBox = new MsgBox(content, title, MsgBox.MsgType.Message, owner, autoCoverMask);

            msgBox.ShowDialog();
            if (owner != null && autoCoverMask)
            {
                SetOpenCoverMask(owner, false);
            }
        }

        public static bool ShowConfirm(string content, string title = "Tips", Window owner = null, bool showInTaskbar = true, bool autoCoverMask = true)
        {
            var msgBox = new MsgBox(content, title, MsgBox.MsgType.Confirm, owner, autoCoverMask);
            if (owner != null)
            {
                if (autoCoverMask)
                    SetOpenCoverMask(owner, true);
                msgBox.Owner = owner;
                msgBox.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            var result = msgBox.ShowDialog() == true;
            if (owner != null)
            {
                SetOpenCoverMask(owner, false);
            }
            return result;
        }

        /// <summary>
        /// Popup a waiting box. Each window can handle one waiting box.
        /// </summary>
        /// <param name="owner">Owner window.Each window can handle one waiting box.</param>
        /// <param name="content">Content.</param>
        /// <param name="title">Title.</param>
        /// <param name="cancelCallback">Action when user click cancel button. Cancel button will be disabled if its value is null.</param>
        /// <param name="showInTaskbar">Show in task bar.</param>
        /// <param name="autoCoverMask">Open cover mask of the owner window when waiting box popuped, and hide it when waiting box closed.</param>
        public static void ShowWaiting(Window owner, string content, string title = "Processing", Action cancelCallback = null, bool showInTaskbar = false, bool autoCoverMask = true)
        {
            SetOpenCoverMask(owner, true);
            var msgBox = new MsgBox(content, title, MsgBox.MsgType.Await, owner, autoCoverMask, cancelCallback);
            msgBox.ShowDialog();

        }

        /// <summary>
        /// Close waiting box. If you don't specialfy the owner window, all of the opened waiting box will be closed.
        /// </summary>
        /// <param name="owner">Close waiting box of specialfy window.</param>
        public static void CloseWaiting(Window owner = null)
        {
            if (MsgBox.InstanceDictionarty != null)
            {
                if (owner == null)
                {
                    var keys = new List<Window>(MsgBox.InstanceDictionarty.Keys);
                    for (int i = 0; i < MsgBox.InstanceDictionarty.Count - 1; i++)
                    {
                        MsgBox.InstanceDictionarty[keys[i]].Close();
                    }
                }
                else
                {
                    if (MsgBox.InstanceDictionarty.ContainsKey(owner))
                        MsgBox.InstanceDictionarty[owner].Close();
                }
            }
        }

        #endregion

        #region Function
        private static void ResizeWindow(ResizeDirection direction, Window window)
        {
            var hwndSource = (HwndSource)PresentationSource.FromVisual(window);
            SendMessage(hwndSource.Handle, 0x112, (IntPtr)(61440 + direction), IntPtr.Zero);
        }

        private static void BeginGradulInAnimation(Window window)
        {
            var storyboard = new Storyboard();
            var doubleAnimation = new DoubleAnimation()
            {
                To = 1,
                Duration = TimeSpan.FromSeconds(0.4),
            };
            Storyboard.SetTarget(doubleAnimation, window);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Window.OpacityMask).(LinearGradientBrush.GradientStops)[1].Offset"));
            storyboard.Children.Add(doubleAnimation);

            var colorAnimation = new ColorAnimation()
            {
                To = Colors.White,
                Duration = TimeSpan.FromSeconds(0.2),
                BeginTime = TimeSpan.FromSeconds(0.3),
            };
            Storyboard.SetTarget(colorAnimation, window);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Window.OpacityMask).(LinearGradientBrush.GradientStops)[1].Color"));
            storyboard.Children.Add(colorAnimation);
            storyboard.Begin();
        }

        private static void BeginGradulOutAnimation(Window window)
        {
            var storyboard = new Storyboard();
            var colorAnimation = new ColorAnimation()
            {
                To = Colors.Transparent,
                Duration = TimeSpan.FromSeconds(0.3),
            };
            Storyboard.SetTarget(colorAnimation, window);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Window.OpacityMask).(LinearGradientBrush.GradientStops)[0].Color"));
            storyboard.Children.Add(colorAnimation);

            var doubleAnimation = new DoubleAnimation()
            {
                To = 1,
                BeginTime = TimeSpan.FromSeconds(0.2),
                Duration = TimeSpan.FromSeconds(0.3),
            };
            Storyboard.SetTarget(doubleAnimation, window);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Window.OpacityMask).(LinearGradientBrush.GradientStops)[0].Offset"));
            storyboard.Children.Add(doubleAnimation);

            storyboard.Completed += delegate
            {
                Quit(window);
            };
            storyboard.Begin();
        }

        private static void BeginFadeInAnimation(Window window)
        {
            var storyboard = new Storyboard();
            var doubleAnimation = new DoubleAnimation()
            {
                To = 1,
                Duration = TimeSpan.FromSeconds(0.4),
            };
            Storyboard.SetTarget(doubleAnimation, window);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));
            storyboard.Children.Add(doubleAnimation);

            storyboard.Begin();
        }

        private static void BeginFadeOutAnimation(Window window)
        {
            var storyboard = new Storyboard();
            var doubleAnimation = new DoubleAnimation()
            {
                To = 0,
                BeginTime = TimeSpan.FromSeconds(0.4),
            };
            Storyboard.SetTarget(doubleAnimation, window);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));
            storyboard.Children.Add(doubleAnimation);

            storyboard.Completed += delegate
            {
                Quit(window);
            };
            storyboard.Begin();
        }

        private static void BeginScaleInAnimation(Window window)
        {
            var border = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(window, 0), 0) as Border;
            var storyboard = new Storyboard();
            var doubleAnimation = new DoubleAnimation()
            {
                To = 1,
                Duration = TimeSpan.FromSeconds(0.4),
            };
            Storyboard.SetTarget(doubleAnimation, window);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));
            storyboard.Children.Add(doubleAnimation);

            var sacleXAnimation = new DoubleAnimation()
            {
                To = 1,
                Duration = TimeSpan.FromSeconds(0.4),
            };
            Storyboard.SetTarget(sacleXAnimation, border);
            Storyboard.SetTargetProperty(sacleXAnimation, new PropertyPath("(Border.RenderTransform).(ScaleTransform.ScaleX)"));
            storyboard.Children.Add(sacleXAnimation);

            var sacleYAnimation = new DoubleAnimation()
            {
                To = 1,
                Duration = TimeSpan.FromSeconds(0.4),
            };
            Storyboard.SetTarget(sacleYAnimation, border);
            Storyboard.SetTargetProperty(sacleYAnimation, new PropertyPath("(Border.RenderTransform).(ScaleTransform.ScaleY)"));
            storyboard.Children.Add(sacleYAnimation);

            storyboard.Begin();
        }

        private static void BeginScaleOutAnimation(Window window)
        {
            var border = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(window, 0), 0) as Border;
            var storyboard = new Storyboard();
            var doubleAnimation = new DoubleAnimation()
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3),
            };
            Storyboard.SetTarget(doubleAnimation, window);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));
            storyboard.Children.Add(doubleAnimation);

            var sacleXAnimation = new DoubleAnimation()
            {
                To = 0.95,
                Duration = TimeSpan.FromSeconds(0.3),
            };
            Storyboard.SetTarget(sacleXAnimation, border);
            Storyboard.SetTargetProperty(sacleXAnimation, new PropertyPath("(Grid.RenderTransform).(ScaleTransform.ScaleX)"));
            storyboard.Children.Add(sacleXAnimation);

            var sacleYAnimation = new DoubleAnimation()
            {
                To = 0.95,
                Duration = TimeSpan.FromSeconds(0.3),
            };
            Storyboard.SetTarget(sacleYAnimation, border);
            Storyboard.SetTargetProperty(sacleYAnimation, new PropertyPath("(Border.RenderTransform).(ScaleTransform.ScaleY)"));
            storyboard.Children.Add(sacleYAnimation);

            storyboard.Completed += delegate
            {
                Quit(window);
            };
            storyboard.Begin();
        }


        private static void BeginPopupInAnimation(FrameworkElement element)
        {
            element.RenderTransformOrigin = new Point(0.5, 0.5);
            var translate = new TranslateTransform(0, 20);
            element.RenderTransform = translate;


            var doubleAnimation = new DoubleAnimation()
            {
                To = 1,
                Duration = TimeSpan.FromSeconds(0.2),
            };
            element.BeginAnimation(FrameworkElement.OpacityProperty, doubleAnimation);

            var translateAnimation = new DoubleAnimation()
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut },
            };
            translate.BeginAnimation(TranslateTransform.YProperty, translateAnimation);
        }

        private static void BeginPopupOutAnimation(FrameworkElement element, Grid container)
        {
            var translate = element.RenderTransform as TranslateTransform;

            var doubleAnimation = new DoubleAnimation()
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0.2),
            };
            element.BeginAnimation(FrameworkElement.OpacityProperty, doubleAnimation);

            var translateAnimation = new DoubleAnimation()
            {
                To = 20,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut },
            };

            translateAnimation.Completed += delegate
            {
                container.Children.Remove(element);
            };
            translate.BeginAnimation(TranslateTransform.YProperty, translateAnimation);


        }

        private static void Quit(Window window)
        {
            var result = GetDialogResult(window);
            if (result == null)
                window.Close();
            else
                window.DialogResult = result;
        }
        #endregion

        #region Event
        private static void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (e.Cancel == true)
                return;

            var window = sender as Window;

            SetDialogResult(window, window.DialogResult);

            window.Closing -= Window_Closing;

            switch (GetWindowAnimation(window))
            {
                case WindowAnimation.Fade:
                    e.Cancel = true;
                    BeginFadeOutAnimation(window);
                    break;
                case WindowAnimation.Gradual:
                    e.Cancel = true;
                    BeginGradulOutAnimation(window);
                    break;
                case WindowAnimation.Scale:
                    e.Cancel = true;
                    BeginScaleOutAnimation(window);
                    break;
            }
        }

        private static void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var window = sender as Window;
            var border = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(window, 0), 0) as Border;
            var grid = border.Child as Grid;
            var grdNavbar = VisualTreeHelper.GetChild(grid, 0) as Grid;
            if (grdNavbar != null)
            {
                grdNavbar.MouseLeftButtonDown += delegate
                {
                    window.DragMove();
                };
            }
            var grdResize = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(window, 0), 1) as Grid;
            if (grdResize != null)
            {
                foreach (Rectangle resizeRectangle in grdResize.Children)
                {
                    resizeRectangle.PreviewMouseDown += delegate
                    {
                        ResizeWindow((ResizeDirection)Enum.Parse(typeof(ResizeDirection), resizeRectangle.Tag.ToString()), window);
                    };
                }
            }
            switch (GetWindowAnimation(window))
            {
                case WindowAnimation.Fade:
                    BeginFadeInAnimation(window);
                    break;
                case WindowAnimation.Gradual:
                    BeginGradulInAnimation(window);
                    break;
                case WindowAnimation.Scale:
                    BeginScaleInAnimation(window);
                    break;
            }
        }
        #endregion
    }

    internal class CloseCommand : ICommand
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
            var window = (parameter as Window);
            window.Close();
        }
    }
    internal class MaxCommand : ICommand
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
            var window = (parameter as Window);
            if (window.WindowState == WindowState.Maximized)
                window.WindowState = WindowState.Normal;
            else
                window.WindowState = WindowState.Maximized;
        }
    }
    internal class MinCommand : ICommand
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
            (parameter as Window).WindowState = WindowState.Minimized;
        }
    }
}
