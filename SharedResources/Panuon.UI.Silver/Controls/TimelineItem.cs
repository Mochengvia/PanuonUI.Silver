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
    public class TimelineItem : ListBoxItem
    {
        static TimelineItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimelineItem), new FrameworkPropertyMetadata(typeof(TimelineItem)));
        }

        #region Property
        /// <summary>
        /// Gets or sets icon.
        /// </summary>
        public object Icon
        {
            get { return (object)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(object), typeof(TimelineItem));

        /// <summary>
        /// Gets or sets header.
        /// </summary>
        public object Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(TimelineItem));

        /// <summary>
        /// Gets or sets line brush.
        /// </summary>
        public Brush LineBrush
        {
            get { return (Brush)GetValue(LineBrushProperty); }
            set { SetValue(LineBrushProperty, value); }
        }

        public static readonly DependencyProperty LineBrushProperty =
            DependencyProperty.Register("LineBrush", typeof(Brush), typeof(TimelineItem));

        /// <summary>
        /// Gets or sets line thickness.
        /// </summary>
        public double LineThickness
        {
            get { return (double)GetValue(LineThicknessProperty); }
            set { SetValue(LineThicknessProperty, value); }
        }

        public static readonly DependencyProperty LineThicknessProperty =
            DependencyProperty.Register("LineThickness", typeof(double), typeof(TimelineItem));


        /// <summary>
        /// Gets or sets line margin.
        /// </summary>
        public Thickness LineMargin
        {
            get { return (Thickness)GetValue(LineMarginProperty); }
            set { SetValue(LineMarginProperty, value); }
        }

        public static readonly DependencyProperty LineMarginProperty =
            DependencyProperty.Register("LineMargin", typeof(Thickness), typeof(TimelineItem));

        /// <summary>
        /// Gets or sets toggle size.
        /// </summary>
        public double ToggleSize
        {
            get { return (double)GetValue(ToggleSizeProperty); }
            set { SetValue(ToggleSizeProperty, value); }
        }

        public static readonly DependencyProperty ToggleSizeProperty =
            DependencyProperty.Register("ToggleSize", typeof(double), typeof(TimelineItem));

        /// <summary>
        /// Gets or sets toggle margin.
        /// </summary>
        public Thickness ToggleMargin
        {
            get { return (Thickness)GetValue(ToggleMarginProperty); }
            set { SetValue(ToggleMarginProperty, value); }
        }

        public static readonly DependencyProperty ToggleMarginProperty =
            DependencyProperty.Register("ToggleMargin", typeof(Thickness), typeof(TimelineItem));

        /// <summary>
        /// Gets or sets toggle stroke.
        /// </summary>
        public Brush ToggleStroke
        {
            get { return (Brush)GetValue(ToggleStrokeProperty); }
            set { SetValue(ToggleStrokeProperty, value); }
        }

        public static readonly DependencyProperty ToggleStrokeProperty =
            DependencyProperty.Register("ToggleStroke", typeof(Brush), typeof(TimelineItem));

        /// <summary>
        /// Gets or sets toggle stroke thickness.
        /// </summary>
        public double ToggleStrokeThickness
        {
            get { return (double)GetValue(ToggleStrokeThicknessProperty); }
            set { SetValue(ToggleStrokeThicknessProperty, value); }
        }

        public static readonly DependencyProperty ToggleStrokeThicknessProperty =
            DependencyProperty.Register("ToggleStrokeThickness", typeof(double), typeof(TimelineItem));

        /// <summary>
        /// Gets or sets toggle fill.
        /// </summary>
        public Brush ToggleFill
        {
            get { return (Brush)GetValue(ToggleFillProperty); }
            set { SetValue(ToggleFillProperty, value); }
        }

        public static readonly DependencyProperty ToggleFillProperty =
            DependencyProperty.Register("ToggleFill", typeof(Brush), typeof(TimelineItem));


        /// <summary>
        /// Gets or sets toggle shadow color.
        /// </summary>
        public Color? ToggleShadowColor
        {
            get { return (Color?)GetValue(ToggleShadowColorProperty); }
            set { SetValue(ToggleShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ToggleShadowColorProperty =
            DependencyProperty.Register("ToggleShadowColor", typeof(Color?), typeof(TimelineItem));


        #endregion

        #region Internal Property
        internal TimelimeStripPlacement TimelimeStripPlacement
        {
            get { return (TimelimeStripPlacement)GetValue(TimelimeStripPlacementProperty); }
            set { SetValue(TimelimeStripPlacementProperty, value); }
        }

        internal static readonly DependencyProperty TimelimeStripPlacementProperty =
            DependencyProperty.Register("TimelimeStripPlacement", typeof(TimelimeStripPlacement), typeof(TimelineItem));

        internal bool IsCreateByItemsControl
        {
            get { return (bool)GetValue(IsCreateByItemsControlProperty); }
            set { SetValue(IsCreateByItemsControlProperty, value); }
        }

        internal static readonly DependencyProperty IsCreateByItemsControlProperty =
            DependencyProperty.Register("IsCreateByItemsControl", typeof(bool), typeof(TimelineItem));
        #endregion
    }
}
