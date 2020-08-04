using System.Windows;
using System.Windows.Controls.Primitives;

namespace Panuon.UI.Silver
{
    public class Badge : ButtonBase
    {
        #region Fields
        #endregion

        #region Ctor
        static Badge()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Badge), new FrameworkPropertyMetadata(typeof(Badge)));
        }
        #endregion

        #region Overrides
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
        }
        #endregion

        #region Properties

        #region CornerRadius
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(double), typeof(Badge));
        #endregion

        #region IsWaving
        public bool IsWaving
        {
            get { return (bool)GetValue(IsWavingProperty); }
            set { SetValue(IsWavingProperty, value); }
        }

        public static readonly DependencyProperty IsWavingProperty =
            DependencyProperty.Register("IsWaving", typeof(bool), typeof(Badge));
        #endregion

        #region Placement
        public BadgePlacement Placement
        {
            get { return (BadgePlacement)GetValue(PlacementProperty); }
            set { SetValue(PlacementProperty, value); }
        }

        public static readonly DependencyProperty PlacementProperty =
            DependencyProperty.Register("Placement", typeof(BadgePlacement), typeof(Badge));
        #endregion

        #endregion
    }
}
