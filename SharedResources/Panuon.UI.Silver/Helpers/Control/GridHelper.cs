using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class GridHelper
    {
        #region GridLineBrush
        public static Brush GetGridLineBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(GridLineBrushProperty);
        }

        public static void SetGridLineBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(GridLineBrushProperty, value);
        }

        public static readonly DependencyProperty GridLineBrushProperty =
            DependencyProperty.RegisterAttached("GridLineBrush", typeof(Brush), typeof(GridHelper), new PropertyMetadata(OnGridLineChanged));
        #endregion

        #region GridLineThickness
        public static double GetGridLineThickness(DependencyObject obj)
        {
            return (double)obj.GetValue(GridLineThicknessProperty);
        }

        public static void SetGridLineThickness(DependencyObject obj, double value)
        {
            obj.SetValue(GridLineThicknessProperty, value);
        }

        public static readonly DependencyProperty GridLineThicknessProperty =
            DependencyProperty.RegisterAttached("GridLineThickness", typeof(double), typeof(GridHelper), new PropertyMetadata(1.0, OnGridLineChanged));

        private static void OnGridLineChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = d as Grid;
            if (grid == null)
                return;

            var brush = GetGridLineBrush(grid);
            var thickness = GetGridLineThickness(grid);

            var type = Type.GetType("System.Windows.Controls.Grid+GridLinesRenderer, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");

            var render = Activator.CreateInstance(type);
            render.GetType().GetField("s_oddDashPen", BindingFlags.Static | BindingFlags.NonPublic).SetValue(render, new Pen(brush, thickness));
            render.GetType().GetField("s_evenDashPen", BindingFlags.Static | BindingFlags.NonPublic).SetValue(render, new Pen(brush, thickness));

        }
        #endregion
    }

}
