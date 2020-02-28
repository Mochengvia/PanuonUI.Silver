using Panuon.UI.Silver.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class Loading : Control
    {
        #region Ctor
        static Loading()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Loading), new FrameworkPropertyMetadata(typeof(Loading)));
        }
        #endregion

        #region Property
        /// <summary>
        /// Gets or sets is loading control running.
        /// </summary>
        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(Loading));

        /// <summary>
        /// Gets or sets base style of loading control.
        /// </summary>
        public LoadingStyle LoadingStyle
        {
            get { return (LoadingStyle)GetValue(LoadingStyleProperty); }
            set { SetValue(LoadingStyleProperty, value); }
        }

        public static readonly DependencyProperty LoadingStyleProperty =
            DependencyProperty.Register("LoadingStyle", typeof(LoadingStyle), typeof(Loading));


        /// <summary>
        /// Gets or sets thickness of loading control.
        /// </summary>
        public double Thickness
        {
            get { return (double)GetValue(ThicknessProperty); }
            set { SetValue(ThicknessProperty, value); }
        }

        public static readonly DependencyProperty ThicknessProperty =
            DependencyProperty.Register("Thickness", typeof(double), typeof(Loading));


        /// <summary>
        /// Gets or sets corner radius of loading control. Only works in standard and wave style.
        /// </summary>
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(double), typeof(Loading));


        /// <summary>
        /// Gets or sets running speed of loading control.
        /// </summary>
        public LoadingSpeed Speed
        {
            get { return (LoadingSpeed)GetValue(SpeedProperty); }
            set { SetValue(SpeedProperty, value); }
        }

        public static readonly DependencyProperty SpeedProperty =
            DependencyProperty.Register("Speed", typeof(LoadingSpeed), typeof(Loading));


        #endregion

        #region (Internal) Property
        internal static double GetPercent(DependencyObject obj)
        {
            return (double)obj.GetValue(PercentProperty);
        }

        internal static void SetPercent(DependencyObject obj, double value)
        {
            obj.SetValue(PercentProperty, value);
        }

        internal static readonly DependencyProperty PercentProperty =
            DependencyProperty.RegisterAttached("Percent", typeof(double), typeof(Loading));
        #endregion

    }
}
