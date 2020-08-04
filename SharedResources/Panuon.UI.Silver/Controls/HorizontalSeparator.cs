using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Panuon.UI.Silver
{
    [ContentProperty(nameof(Caption))]
    public class HorizontalSeparator : Control
    {
        #region Fields
        #endregion

        #region Ctor
        static HorizontalSeparator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HorizontalSeparator), new FrameworkPropertyMetadata(typeof(HorizontalSeparator)));
        }
        #endregion

        #region Properties

        #region Caption
        public object Caption
        {
            get { return (object)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(object), typeof(HorizontalSeparator));
        #endregion

        #region Thickness
        public double Thickness
        {
            get { return (double)GetValue(ThicknessProperty); }
            set { SetValue(ThicknessProperty, value); }
        }

        public static readonly DependencyProperty ThicknessProperty =
            DependencyProperty.Register("Thickness", typeof(double), typeof(HorizontalSeparator));
        #endregion

        #region MinTipWidth
        public double MinTipWidth
        {
            get { return (double)GetValue(MinTipWidthProperty); }
            set { SetValue(MinTipWidthProperty, value); }
        }

        public static readonly DependencyProperty MinTipWidthProperty =
            DependencyProperty.Register("MinTipWidth", typeof(double), typeof(HorizontalSeparator));
        #endregion

        #endregion
      
    }
}
