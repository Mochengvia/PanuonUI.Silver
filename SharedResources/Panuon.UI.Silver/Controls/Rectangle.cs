using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public class Rectangle : UIElement
    {
        #region Properties

        #region StrokeThickness

        public Thickness StrokeThickness
        {
            get { return (Thickness)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.RegisterAttached("StrokeThickness", typeof(Thickness), typeof(Rectangle), new FrameworkPropertyMetadata(new Thickness(0), FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region Stroke

        public Brush Stroke
        {
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.RegisterAttached("Stroke", typeof(Brush), typeof(Rectangle), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));


        #endregion

        #region LeftStroke
        public Brush LeftStroke
        {
            get { return (Brush)GetValue(LeftStrokeProperty); }
            set { SetValue(LeftStrokeProperty, value); }
        }

        public static readonly DependencyProperty LeftStrokeProperty =
            DependencyProperty.RegisterAttached("LeftStroke", typeof(Brush), typeof(Rectangle), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));


        #endregion

        #region TopStroke


        public Brush TopStroke
        {
            get { return (Brush)GetValue(TopStrokeProperty); }
            set { SetValue(TopStrokeProperty, value); }
        }

        public static readonly DependencyProperty TopStrokeProperty =
            DependencyProperty.RegisterAttached("TopStroke", typeof(Brush), typeof(Rectangle), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));


        #endregion

        #region RightStroke
        public Brush RightStroke
        {
            get { return (Brush)GetValue(RightStrokeProperty); }
            set { SetValue(RightStrokeProperty, value); }
        }

        public static readonly DependencyProperty RightStrokeProperty =
            DependencyProperty.RegisterAttached("RightStroke", typeof(Brush), typeof(Rectangle), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));


        #endregion

        #region BottomStroke

        public Brush BottomStroke
        {
            get { return (Brush)GetValue(BottomStrokeProperty); }
            set { SetValue(BottomStrokeProperty, value); }
        }

        public static readonly DependencyProperty BottomStrokeProperty =
            DependencyProperty.RegisterAttached("BottomStroke", typeof(Brush), typeof(Rectangle), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));


        #endregion

        #region Fill


        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill", typeof(Brush), typeof(Rectangle), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #endregion

        #region Overrides
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (RenderSize.Width == 0 || RenderSize.Height == 0)
            {
                return;
            }

            drawingContext.DrawLine(new Pen(TopStroke ?? Stroke, StrokeThickness.Top), new Point(0, StrokeThickness.Top / 2), new Point(RenderSize.Width, StrokeThickness.Top / 2));
            drawingContext.DrawLine(new Pen(LeftStroke ?? Stroke, StrokeThickness.Left), new Point(0, 0), new Point(0, RenderSize.Height));
            drawingContext.DrawLine(new Pen(BottomStroke ?? Stroke, StrokeThickness.Bottom), new Point(0, RenderSize.Height - StrokeThickness.Bottom / 2), new Point(RenderSize.Width, RenderSize.Height - StrokeThickness.Bottom / 2));
            drawingContext.DrawLine(new Pen(RightStroke ?? Stroke, StrokeThickness.Right), new Point(RenderSize.Width, 0), new Point(RenderSize.Width, RenderSize.Height));
     
            drawingContext.DrawRectangle(Fill, null, new Rect(StrokeThickness.Left, StrokeThickness.Top, RenderSize.Width - StrokeThickness.Left - StrokeThickness.Right, RenderSize.Height - StrokeThickness.Top - StrokeThickness.Bottom));
        }
    }
    #endregion
}
