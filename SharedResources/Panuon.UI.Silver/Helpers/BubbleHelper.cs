using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public class BubbleHelper
    {
        public static void Show(Window window, string content, double durationSeconds = 2, double opacity = 0.7, PopupPosition popupPosition = PopupPosition.Bottom)
        {
            var grid = window.Content as Grid;
            if (grid == null)
                throw new Exception("The window which to show bubble must has \"Grid\" as root node.");

            var border = new Border()
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AA3E3E3E")),
                CornerRadius = new CornerRadius(3),
                VerticalAlignment = popupPosition == PopupPosition.Bottom ? VerticalAlignment.Bottom : (popupPosition == PopupPosition.Center ? VerticalAlignment.Center : VerticalAlignment.Top),
                HorizontalAlignment = HorizontalAlignment.Center,
                Height = double.NaN,
                Margin = popupPosition == PopupPosition.Bottom ? new Thickness(0, 0, 0, 20) : (popupPosition == PopupPosition.Center ? new Thickness(0, 0, 0, 0) : new Thickness(0, 20, 0, 0)),
                Opacity = 0,
                Effect = new DropShadowEffect()
                {
                    ShadowDepth = 0,
                    Color = Colors.DimGray,
                    Opacity = opacity,
                },
            };

            if ((grid.RowDefinitions?.Count ?? 0) != 0)
                Grid.SetRowSpan(border, grid.RowDefinitions.Count);

            if ((grid.ColumnDefinitions?.Count ?? 0) != 0)
                Grid.SetColumnSpan(border, grid.ColumnDefinitions.Count);

            var textBlock = new System.Windows.Controls.TextBlock()
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
            BeginPopupInAnimation(border, popupPosition);
            var timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(durationSeconds) };
            timer.Tick += delegate
            {
                BeginPopupOutAnimation(border, grid, popupPosition);
            };
            timer.Start();
        }

        #region Function
        private static void BeginPopupInAnimation(FrameworkElement element, PopupPosition popupPosition)
        {
            element.RenderTransformOrigin = new Point(0.5, 0.5);
            var translate = new TranslateTransform(0, popupPosition == PopupPosition.Top ? -20 : 20);
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

        private static void BeginPopupOutAnimation(FrameworkElement element, Grid container, PopupPosition popupPosition)
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
                To = popupPosition == PopupPosition.Top ? -20 : 20,
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut },
            };

            translateAnimation.Completed += delegate
            {
                container.Children.Remove(element);
            };
            translate.BeginAnimation(TranslateTransform.YProperty, translateAnimation);


        }
        #endregion
    }
}
