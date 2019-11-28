using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;


namespace Panuon.UI.Silver
{
    [ContentProperty(nameof(Text))]
    public sealed partial class PUTextBlock : UserControl
    {
        public PUTextBlock()
        {
            this.InitializeComponent();
        }

        #region Property
        /// <summary>
        /// Gets or sets text.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(PUTextBlock), new PropertyMetadata(OnTextChanged));

        /// <summary>
        /// Gets or sets match text.
        /// </summary>
        public string MatchText
        {
            get { return (string)GetValue(MatchTextProperty); }
            set { SetValue(MatchTextProperty, value); }
        }

        public static readonly DependencyProperty MatchTextProperty =
            DependencyProperty.Register("MatchText", typeof(string), typeof(PUTextBlock), new PropertyMetadata(OnTextChanged));

        /// <summary>
        /// Gets or sets matched text foreground/
        /// </summary>
        public Brush MatchedForeground
        {
            get { return (Brush)GetValue(MatchedForegroundProperty); }
            set { SetValue(MatchedForegroundProperty, value); }
        }

        public static readonly DependencyProperty MatchedForegroundProperty =
            DependencyProperty.Register("MatchedForeground", typeof(Brush), typeof(PUTextBlock), new PropertyMetadata("#FF3C3C".ToColor().ToBrush()));

        /// <summary>
        /// Gets or sets auto adaptation.
        /// </summary>
        public bool AutoAdaptation
        {
            get { return (bool)GetValue(AutoAdaptationProperty); }
            set { SetValue(AutoAdaptationProperty, value); }
        }

        public static readonly DependencyProperty AutoAdaptationProperty =
            DependencyProperty.Register("AutoAdaptation", typeof(bool), typeof(PUTextBlock));

        /// <summary>
        /// Gets or sets exceeded text filler.
        /// </summary>
        public string ExceededTextFiller
        {
            get { return (string)GetValue(ExceededTextFillerProperty); }
            set { SetValue(ExceededTextFillerProperty, value); }
        }

        public static readonly DependencyProperty ExceededTextFillerProperty =
            DependencyProperty.Register("ExceededTextFiller", typeof(string), typeof(PUTextBlock), new PropertyMetadata("..."));

        /// <summary>
        /// Gets or sets text wrapping.
        /// </summary>
        public TextWrapping TextWrapping
        {
            get { return (TextWrapping)GetValue(TextWrappingProperty); }
            set { SetValue(TextWrappingProperty, value); }
        }

        public static readonly DependencyProperty TextWrappingProperty =
            DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(PUTextBlock));

        /// <summary>
        /// Gets or sets text alignment.
        /// </summary>
        public TextAlignment TextAlignment
        {
            get { return (TextAlignment)GetValue(TextAlignmentProperty); }
            set { SetValue(TextAlignmentProperty, value); }
        }

        public static readonly DependencyProperty TextAlignmentProperty =
            DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(PUTextBlock));

        /// <summary>
        /// Gets or sets text effects.
        /// </summary>
        public TextEffectCollection TextEffects
        {
            get { return (TextEffectCollection)GetValue(TextEffectsProperty); }
            set { SetValue(TextEffectsProperty, value); }
        }

        public static readonly DependencyProperty TextEffectsProperty =
            DependencyProperty.Register("TextEffects", typeof(TextEffectCollection), typeof(PUTextBlock));

        /// <summary>
        /// Gets or sets match rule.
        /// </summary>
        public MatchRule MatchRule
        {
            get { return (MatchRule)GetValue(MatchRuleProperty); }
            set { SetValue(MatchRuleProperty, value); }
        }

        public static readonly DependencyProperty MatchRuleProperty =
            DependencyProperty.Register("MatchRule", typeof(MatchRule), typeof(PUTextBlock));

        /// <summary>
        /// Gets or sets text decorations.
        /// </summary>
        public TextDecorationCollection TextDecorations
        {
            get { return (TextDecorationCollection)GetValue(TextDecorationsProperty); }
            set { SetValue(TextDecorationsProperty, value); }
        }

        public static readonly DependencyProperty TextDecorationsProperty =
            DependencyProperty.Register("TextDecorations", typeof(TextDecorationCollection), typeof(PUTextBlock));
        #endregion

        #region Event Handler
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBlock = d as PUTextBlock;
            textBlock.AdaptText();
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            AdaptText();
        }
        #endregion

        #region Function
        private void AdaptText()
        {
            TxtContent.Inlines.Clear();
            if (Text == null)
            {
                TxtContent.Text = null;
                return;
            }

            var text = Text;

            if (AutoAdaptation)
            {
                if (ActualWidth != 0)
                    text = GetAdaptedText(text, ExceededTextFiller, ActualHeight, ActualWidth);
            }

            if (string.IsNullOrEmpty(MatchText) || string.IsNullOrEmpty(Text) || !Text.Contains(MatchText))
            {
                TxtContent.Text = text;
                return;
            }
            else
                TxtContent.Text = null;

            if(MatchRule == MatchRule.All)
            {
                var splits = text.Split(new string[] { MatchText }, StringSplitOptions.None);
                if (splits == null || splits.Length < 2)
                {
                    TxtContent.Text = text;
                    return;
                }

                for (int i = 0; i < splits.Length; i++)
                {
                    var split = splits[i];
                    if (string.IsNullOrEmpty(split))
                        split = MatchText;
                    var run = new Run() { Text = split };
                    if (split == MatchText)
                        run.Foreground = MatchedForeground;
                    TxtContent.Inlines.Add(run);
                }
            }
            else if(MatchRule == MatchRule.First)
            {
                var index = text.IndexOf(MatchText);
                TxtContent.Inlines.Add(new Run() { Text = Text.Substring(0, index) });
                TxtContent.Inlines.Add(new Run() { Text = Text.Substring(index, MatchText.Length) , Foreground = MatchedForeground });
                TxtContent.Inlines.Add(new Run() { Text = Text.Substring(index + MatchText.Length) });
            }

        }

        private string GetAdaptedText(string text, string filler, double height, double width)
        {
            bool isAnyChanged = false;

            var textBlock = new System.Windows.Controls.TextBlock
            {
                Text = text,
                TextWrapping = TxtContent.TextWrapping,
                FontSize = FontSize,
                FontFamily = FontFamily,
                FontStretch = FontStretch,
                FontStyle = FontStyle,
                FontWeight = FontWeight,
            };

            textBlock.Measure(new Size(width, Double.PositiveInfinity));
            textBlock.Arrange(new Rect(textBlock.DesiredSize));

            while (text.Length > 1 && (textBlock.ActualHeight > height || textBlock.ActualWidth > width))
            {
                isAnyChanged = true;

                text = text.Remove(text.Length - 1);
                textBlock = new System.Windows.Controls.TextBlock
                {
                    Text = text + filler,
                    TextWrapping = TextWrapping,
                    FontSize = FontSize,
                    FontFamily = FontFamily,
                    FontStretch = FontStretch,
                    FontStyle = FontStyle,
                    FontWeight = FontWeight,
                };
                textBlock.Measure(new Size(width, Double.PositiveInfinity));
                textBlock.Arrange(new Rect(textBlock.DesiredSize));
            }
            return isAnyChanged ? (text + filler) : text;
        }
       
        #endregion

    }
}
