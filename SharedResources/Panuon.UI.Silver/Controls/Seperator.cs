using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public class Separator : FrameworkElement
    {
        #region Ctor
        static Separator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Separator), new FrameworkPropertyMetadata(typeof(Separator)));
        }
        #endregion

        #region Properties

        #region Brush
        public Brush Brush
        {
            get { return (Brush)GetValue(BrushProperty); }
            set { SetValue(BrushProperty, value); }
        }

        public static readonly DependencyProperty BrushProperty =
            DependencyProperty.Register("Brush", typeof(Brush), typeof(Separator));
        #endregion

        #region Alignment

        public Alignment Alignment
        {
            get { return (Alignment)GetValue(AlignmentProperty); }
            set { SetValue(AlignmentProperty, value); }
        }

        public static readonly DependencyProperty AlignmentProperty =
            DependencyProperty.Register("Alignment", typeof(Alignment), typeof(Separator));

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
            drawingContext.DrawRectangle(Brush, null, new Rect(1, 1, RenderSize.Width, RenderSize.Height));
        }
    }
    #endregion
}
