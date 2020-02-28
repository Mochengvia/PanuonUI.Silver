using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal;
using Panuon.UI.Silver.Internal.Models;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver
{
    public class Drawer : ContentControl
    {
        #region Ctorcdasd
        static Drawer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Drawer), new FrameworkPropertyMetadata(typeof(Drawer)));
        }
        #endregion

        #region Properties

        #region DrawePlacement
        public DrawerPlacement Placement
        {
            get { return (DrawerPlacement)GetValue(PlacementProperty); }
            set { SetValue(PlacementProperty, value); }
        }

        public static readonly DependencyProperty PlacementProperty =
            DependencyProperty.Register("Placement", typeof(DrawerPlacement), typeof(Drawer));
        #endregion

        #region IsOpen
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(Drawer), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnIsOpenChanged));
        #endregion

        #region AnimationDuration
        public TimeSpan AnimationDuration
        {
            get { return (TimeSpan)GetValue(AnimationDurationProperty); }
            set { SetValue(AnimationDurationProperty, value); }
        }

        public static readonly DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register("AnimationDuration", typeof(TimeSpan), typeof(Drawer));

        #endregion

        #region AnimationEase
        public AnimationEase AnimationEase
        {
            get { return (AnimationEase)GetValue(AnimationEaseProperty); }
            set { SetValue(AnimationEaseProperty, value); }
        }

        public static readonly DependencyProperty AnimationEaseProperty =
            DependencyProperty.Register("AnimationEase", typeof(AnimationEase), typeof(Drawer));
        #endregion

        #region CornerRadius
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Drawer));
        #endregion

        #region ShadowColor


        public Color? ShadowColor
        {
            get { return (Color?)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color?), typeof(Drawer));
        #endregion

        #endregion

        #region Methods

        private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var drawer = d as Drawer;
            switch (drawer.Placement)
            {
                case DrawerPlacement.Left:
                case DrawerPlacement.Right:
                    if (double.IsNaN(drawer.MaxWidth))
                    {
                        throw new Exception("Drawer Exception : value of MaxWidth property can not be Auto.");
                    }
                    if (!drawer.IsLoaded || drawer.AnimationDuration.TotalMilliseconds == 0)
                    {
                        if ((bool)e.NewValue)
                        {
                            drawer.Width = drawer.MaxWidth;
                        }
                        else
                        {
                            drawer.Width = 0;
                        }
                    }
                    else
                    {
                        if ((bool)e.NewValue)
                        {
                            if (double.IsNaN(drawer.Width))
                            {
                                drawer.Width = drawer.ActualWidth;
                            }
                            AnimationUtils.BeginAnimation(drawer, WidthProperty, drawer.MaxWidth, drawer.AnimationDuration, drawer.AnimationEase);
                        }
                        else
                        {
                            if (double.IsNaN(drawer.Width))
                            {
                                drawer.Width = drawer.ActualWidth;
                            }
                            AnimationUtils.BeginAnimation(drawer, WidthProperty, 0, drawer.AnimationDuration, drawer.AnimationEase);
                        }
                    }
                    break;
                case DrawerPlacement.Top:
                case DrawerPlacement.Bottom:
                    if (double.IsNaN(drawer.MaxWidth))
                    {
                        throw new Exception("Drawer Exception : value of MaxHeight property can not be Auto.");
                    }
                    if (!drawer.IsLoaded || drawer.AnimationDuration.TotalMilliseconds == 0)
                    {
                        if ((bool)e.NewValue)
                        {
                            drawer.Height = drawer.MaxHeight;
                        }
                        else
                        {
                            drawer.Height = 0;
                        }
                    }
                    else
                    {
                        if ((bool)e.NewValue)
                        {
                            if (double.IsNaN(drawer.Height))
                            {
                                drawer.Height = drawer.ActualHeight;
                            }
                            AnimationUtils.BeginAnimation(drawer, HeightProperty, drawer.MaxHeight, drawer.AnimationDuration, drawer.AnimationEase);
                        }
                        else
                        {
                            if (double.IsNaN(drawer.Height))
                            {
                                drawer.Height = drawer.ActualHeight;
                            }
                            AnimationUtils.BeginAnimation(drawer, HeightProperty, 0, drawer.AnimationDuration, drawer.AnimationEase);
                        }
                    }
                    break;
            }


        }
        #endregion

        #region Function
        #endregion
    }
}
