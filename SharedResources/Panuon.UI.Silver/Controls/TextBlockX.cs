using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    [ContentProperty(nameof(Text))]
    public class TextBlockX : Control
    {
        #region Identifer
        private TextBlock _textBlock;
        #endregion

        #region Ctor
        static TextBlockX()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBlockX), new FrameworkPropertyMetadata(typeof(TextBlockX)));
        }
        #endregion

        #region Properties

        #region Text
        /// <summary>
        /// Gets or sets text of textBlockX.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.TextBlockX.Text dependency property.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextBlockX), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));
        #endregion

        #region MatchText
        /// <summary>
        /// Gets or sets the match text of the textblockX control. The matched text will be highlighted.
        /// </summary>
        public string MatchText
        {
            get { return (string)GetValue(MatchTextProperty); }
            set { SetValue(MatchTextProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.TextBlockX.MatchText dependency property.
        /// </summary>
        public static readonly DependencyProperty MatchTextProperty =
            DependencyProperty.Register("MatchText", typeof(string), typeof(TextBlockX), new FrameworkPropertyMetadata(null,FrameworkPropertyMetadataOptions.AffectsArrange));

        #endregion

        #region MatchedForeground
        /// <summary>
        /// Gets or sets the foreground of the matched text when it's highlighted.
        /// </summary>
        public Brush MatchedForeground
        {
            get { return (Brush)GetValue(MatchedForegroundProperty); }
            set { SetValue(MatchedForegroundProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.TextBlockX.MatchedForeground dependency property.
        /// </summary>
        public static readonly DependencyProperty MatchedForegroundProperty =
            DependencyProperty.Register("MatchedForeground", typeof(Brush), typeof(TextBlockX), new FrameworkPropertyMetadata(Brushes.Red,FrameworkPropertyMetadataOptions.AffectsArrange));

        #endregion

        #region AutoAdaptation
        /// <summary>
        /// Gets or sets whether the text is adaptive to the control size. 
        /// Overflowing text will be cropped and filled with the value of the ExceededTextFiller property.
        /// </summary>
        public bool AutoAdaptation
        {
            get { return (bool)GetValue(AutoAdaptationProperty); }
            set { SetValue(AutoAdaptationProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.TextBlockX.AutoAdaptation dependency property.
        /// </summary>
        public static readonly DependencyProperty AutoAdaptationProperty =
            DependencyProperty.Register("AutoAdaptation", typeof(bool), typeof(TextBlockX), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.AffectsArrange));
        #endregion

        #region ExceededTextFiller
        /// <summary>
        /// Gets or sets the text appended to the cropped text when the text exceeds the size of the control.
        /// Only works when the AutoAdaptation property is True.
        /// </summary>
        public string ExceededTextFiller
        {
            get { return (string)GetValue(ExceededTextFillerProperty); }
            set { SetValue(ExceededTextFillerProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.TextBlockX.ExceededTextFiller dependency property.
        /// </summary>
        public static readonly DependencyProperty ExceededTextFillerProperty =
            DependencyProperty.Register("ExceededTextFiller", typeof(string), typeof(TextBlockX), new FrameworkPropertyMetadata("...", FrameworkPropertyMetadataOptions.AffectsArrange));
        #endregion

        #region MatchRule
        /// <summary>
        /// Gets or sets the match rule of the textblockX.
        /// </summary>
        public MatchRule MatchRule
        {
            get { return (MatchRule)GetValue(MatchRuleProperty); }
            set { SetValue(MatchRuleProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.TextBlockX.MatchRule dependency property.
        /// </summary>
        public static readonly DependencyProperty MatchRuleProperty =
            DependencyProperty.Register("MatchRule", typeof(MatchRule), typeof(TextBlockX), new FrameworkPropertyMetadata(MatchRule.First,FrameworkPropertyMetadataOptions.AffectsArrange));

        #endregion

        #region TextWrapping
        /// <summary>
        /// Gets or sets text wrapping of textblockX.
        /// </summary>
        public TextWrapping TextWrapping
        {
            get { return (TextWrapping)GetValue(TextWrappingProperty); }
            set { SetValue(TextWrappingProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.TextBlockX.TextWrappingProperty dependency property.
        /// </summary>
        public static readonly DependencyProperty TextWrappingProperty =
            DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(TextBlockX), new FrameworkPropertyMetadata(TextWrapping.WrapWithOverflow,FrameworkPropertyMetadataOptions.AffectsArrange));
        #endregion

        #region TextAlignment
        /// <summary>
        /// Gets or sets text alignment of textblockX.
        /// </summary>
        public TextAlignment TextAlignment
        {
            get { return (TextAlignment)GetValue(TextAlignmentProperty); }
            set { SetValue(TextAlignmentProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.TextBlockX.TextAlignment dependency property.
        /// </summary>
        public static readonly DependencyProperty TextAlignmentProperty =
            DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(TextBlockX), new FrameworkPropertyMetadata(TextAlignment.Left,FrameworkPropertyMetadataOptions.AffectsArrange));
        #endregion

        #region TextEffects
        /// <summary>
        /// Gets or sets text effects of textblockX.
        /// </summary>
        public TextEffectCollection TextEffects
        {
            get { return (TextEffectCollection)GetValue(TextEffectsProperty); }
            private set { SetValue(TextEffectsProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.TextBlockX.TextEffects dependency property.
        /// </summary>
        public static readonly DependencyProperty TextEffectsProperty =
            DependencyProperty.Register("TextEffects", typeof(TextEffectCollection), typeof(TextBlockX), new FrameworkPropertyMetadata(new TextEffectCollection(), FrameworkPropertyMetadataOptions.AffectsArrange));
        #endregion

        #region TextDecorations
        /// <summary>
        /// Gets or sets text decorations of textblockX.
        /// </summary>
        public TextDecorationCollection TextDecorations
        {
            get { return (TextDecorationCollection)GetValue(TextDecorationsProperty); }
            private set { SetValue(TextDecorationsProperty, value); }
        }

        /// <summary>
        /// Identifies the Panuon.UI.Silver.TextBlockX.TextDecorations dependency property.
        /// </summary>
        public static readonly DependencyProperty TextDecorationsProperty =
            DependencyProperty.Register("TextDecorations", typeof(TextDecorationCollection), typeof(TextBlockX), new FrameworkPropertyMetadata(new TextDecorationCollection(), FrameworkPropertyMetadataOptions.AffectsArrange));
        #endregion

        #endregion

        #region Override
        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            if (_textBlock == null)
                _textBlock = VisualTreeHelper.GetChild(this, 0) as TextBlock;

            var width = arrangeBounds.Width;
            var height = arrangeBounds.Height;

            var text = Text;

            if (AutoAdaptation)
            {
                var filler = ExceededTextFiller;
                var fillerLength = filler?.Length ?? 0;

                var size = TextUtils.MeasureTextSize(text, TextWrapping, FontFamily, FontStyle, FontWeight, FontStretch, FontSize, double.IsNaN(width) ? double.PositiveInfinity : width);
                if (size.Width > width || size.Height > height)
                {
                    if ((size.Width / width) > 2 || (size.Height / height) > 2)
                    {
                        var index = BinaryMeasureSize(text + filler, width, height, filler, 0, text.Length + fillerLength);
                        text = text.Remove(index + fillerLength) + filler;
                    }
                    else
                    {
                        int count = 0;
                        while (size.Width > width || size.Height > height)
                        {
                            text = Text.Remove(Text.Length - fillerLength - count++) + filler;
                            size = TextUtils.MeasureTextSize(text, TextWrapping, FontFamily, FontStyle, FontWeight, FontStretch, FontSize, double.IsNaN(width) ? double.PositiveInfinity : width);
                        }
                    }
                }
            }

            _textBlock.Inlines.Clear();

            if (string.IsNullOrEmpty(MatchText) || text.IndexOf(MatchText) < 0)
            {
                _textBlock.Inlines.Add(new Run() { Text = text });
            }
            else
            {
                var splits = text.Split(new string[] { MatchText }, StringSplitOptions.None);
                foreach (var split in splits)
                {
                    if (string.IsNullOrEmpty(split))
                        _textBlock.Inlines.Add(new Run() { Text = MatchText, Foreground = MatchedForeground });
                    else
                        _textBlock.Inlines.Add(new Run() { Text = split });
                }
            }
            return base.ArrangeOverride(arrangeBounds);
        }
        #endregion

        #region Function


        private int BinaryMeasureSize(string text, double width, double height, string filler, int low, int high)
        {
            var middle = (high - low) / 2 + low;
            var size = TextUtils.MeasureTextSize(text.Remove(middle + filler?.Length ?? 0) + filler, TextWrapping, FontFamily, FontStyle, FontWeight, FontStretch, FontSize, double.IsNaN(width) ? double.PositiveInfinity : width);
            if (size.Width > width || size.Height > height)
            {
                if (high - low == 2)
                {
                    return middle - 1;
                }
                return BinaryMeasureSize(text, width, height, filler, low, middle);
            }
            else
            {
                if (high - low == 2)
                {
                    return middle;
                }
                return BinaryMeasureSize(text, width, height, filler, middle, high);
            }
        }
        #endregion
    }
}
