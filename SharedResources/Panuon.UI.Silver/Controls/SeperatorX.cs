using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public class SeparatorX : UIElement
    {
        #region Properties

        #region Thickness
        public double Thickness
        {
            get { return (double)GetValue(ThicknessProperty); }
            set { SetValue(ThicknessProperty, value); }
        }

        public static readonly DependencyProperty ThicknessProperty =
            DependencyProperty.Register("Thickness", typeof(double), typeof(SeparatorX), new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region Brush
        public Brush Brush
        {
            get { return (Brush)GetValue(BrushProperty); }
            set { SetValue(BrushProperty, value); }
        }

        public static readonly DependencyProperty BrushProperty =
            DependencyProperty.Register("Brush", typeof(Brush), typeof(SeparatorX), new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region Alignment

        public SeparatorAlignment Alignment
        {
            get { return (SeparatorAlignment)GetValue(AlignmentProperty); }
            set { SetValue(AlignmentProperty, value); }
        }

        public static readonly DependencyProperty AlignmentProperty =
            DependencyProperty.Register("Alignment", typeof(SeparatorAlignment), typeof(SeparatorX), new FrameworkPropertyMetadata(SeparatorAlignment.Bottom, FrameworkPropertyMetadataOptions.AffectsRender));

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

            switch (Alignment)
            {
                case SeparatorAlignment.Left:
                    drawingContext.DrawLine(new Pen(Brush, Thickness), new Point(0, 0), new Point(0, RenderSize.Height));
                    break;
                case SeparatorAlignment.Right:
                    drawingContext.DrawLine(new Pen(Brush, Thickness), new Point(RenderSize.Width - Thickness, 0), new Point(RenderSize.Width - Thickness, RenderSize.Height));
                    break;
                case SeparatorAlignment.Top:
                    drawingContext.DrawLine(new Pen(Brush, Thickness), new Point(0, Thickness / 2), new Point(RenderSize.Width, Thickness / 2));
                    break;
                case SeparatorAlignment.HorizontalCenter:
                    drawingContext.DrawLine(new Pen(Brush, Thickness), new Point((RenderSize.Width - Thickness) / 2, 0), new Point(0, RenderSize.Height));
                    break;
                case SeparatorAlignment.VerticalCenter:
                    drawingContext.DrawLine(new Pen(Brush, Thickness), new Point(0, (RenderSize.Height - Thickness) / 2), new Point(RenderSize.Width, Thickness / 2));
                    break;
                default:
                    drawingContext.DrawLine(new Pen(Brush, Thickness), new Point(0, RenderSize.Height - Thickness / 2), new Point(RenderSize.Width - Thickness, RenderSize.Height - Thickness / 2));
                    break;
            }
        }
    }
    #endregion
}
