using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Panuon.UI.Silver.Controls.Internal
{
    internal partial class ScreenshotWindow : Window
    {
        #region Extern
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,
        }
        #endregion

        #region Constructor
        public ScreenshotWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Property
        public BitmapSource Result { get; set; }
        #endregion

        #region Event Handler
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    Close();
                    break;
            }
        }

        private void Border_Draging(object sender, Core.DragingEventArgs e)
        {
            Txt.Text = $"({e.StartPosition.X},{e.StartPosition.Y})({e.EndPosition.X},{e.EndPosition.Y})";

            var left = Math.Min(e.StartPosition.X, e.EndPosition.X);
            var top = Math.Min(e.StartPosition.Y, e.EndPosition.Y);

            CvaMain.Children.Clear();
            var rect = new System.Windows.Shapes.Rectangle()
            {
                Width = e.Size.Width,
                Height = e.Size.Height,
                Stroke = "#B1DBFF".ToColor().ToBrush(),
                StrokeThickness = 2,
                Fill = "#88EEF7FF".ToColor().ToBrush(),
            };

            Canvas.SetLeft(rect, left);
            Canvas.SetTop(rect, top);

            CvaMain.Children.Add(rect);
        }

        private void Border_DragArea(object sender, Core.DragAreaEventArgs e)
        {
            Hide();

            var scaling = GetScalingFactor();

            var left = (int)Math.Min(e.StartPosition.X, e.EndPosition.X);
            var top = (int)Math.Min(e.StartPosition.Y, e.EndPosition.Y);

            using (Bitmap bmp = new Bitmap((int)e.Size.Width, (int)e.Size.Height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen((int)(left * scaling - 5), (int)(top * scaling - 5), 0, 0, bmp.Size);
                }
                Result = Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                Close();
            }
        }
        #endregion

        #region Function
        private float GetScalingFactor()
        {
            var graphics = Graphics.FromHwnd(IntPtr.Zero);
            var desktop = graphics.GetHdc();
            int logicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
            int physicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);

            float screenScalingFactor = (float)physicalScreenHeight / (float)logicalScreenHeight;

            return screenScalingFactor;
        }
        #endregion

    }
}
