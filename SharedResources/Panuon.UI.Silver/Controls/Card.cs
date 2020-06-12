using Panuon.UI.Silver.Internal.Utils;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class Card : ButtonBase
    {
        #region Ctor
        static Card()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Card), new FrameworkPropertyMetadata(typeof(Card)));
        }

        public Card()
        {
            MouseEnter += Card_MouseEnter;
            MouseLeave += Card_MouseLeave;
        }

        private void Card_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(HoverBorderBrush == null)
            {
                return;
            }
            var dic = new Dictionary<DependencyProperty, Brush>();
            dic.Add(BorderBrushProperty, HoverBorderBrush);
            StoryboardUtils.BeginBrushStoryboard(this, dic);
        }

        private void Card_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (HoverBorderBrush == null)
            {
                return;
            }
            var list = new List<DependencyProperty>();
            list.Add(BorderBrushProperty);
            StoryboardUtils.BeginBrushStoryboard(this, list);
        }
        #endregion

        #region Properties

        #region HoverBorderBrush
        public Brush HoverBorderBrush
        {
            get { return (Brush)GetValue(HoverBorderBrushProperty); }
            set { SetValue(HoverBorderBrushProperty, value); }
        }

        public static readonly DependencyProperty HoverBorderBrushProperty =
            DependencyProperty.Register("HoverBorderBrush", typeof(Brush), typeof(Card));
        #endregion

        #region ShadowColor
        /// <summary>
        /// Gets or sets the shadow color of the card. Shadow effect will be disabled if it's null.
        /// </summary>
        public Color? ShadowColor
        {
            get { return (Color?)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.Card.ShadowColor dependency property.
        /// </summary>
        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color?), typeof(Card));
        #endregion

        #region CornerRadius
        /// <summary>
        /// Gets or sets the corner radius of the card.
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.Card.CornerRadius dependency property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Card));
        #endregion

        #region ImageSource
        /// <summary>
        /// Gets or sets the image source of the card. Picture will not be displayed if it's null.
        /// </summary>
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.Card.ImageSource dependency property.
        /// </summary>
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(Card));
        #endregion

        #region Orientation
        /// <summary>
        /// Gets or sets the orientation of the card.
        /// </summary>
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.Card.Orientation dependency property.
        /// </summary>
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(Card));
        #endregion

        #endregion
    }
}
