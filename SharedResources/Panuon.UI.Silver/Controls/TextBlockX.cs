using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    [ContentProperty(nameof(Text))]
    public class TextBlockX : Control
    {
        #region Ctor
        static TextBlockX()
        {
            ClipToBoundsProperty.OverrideMetadata(typeof(TextBlockX), new PropertyMetadata(true));
        }
        #endregion

        #region Properties

        #region Text
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextBlockX), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region TextAdaption
        public TextAdaption TextAdaption
        {
            get { return (TextAdaption)GetValue(TextAdaptionProperty); }
            set { SetValue(TextAdaptionProperty, value); }
        }

        public static readonly DependencyProperty TextAdaptionProperty =
            DependencyProperty.Register("TextAdaption", typeof(TextAdaption), typeof(TextBlockX), new FrameworkPropertyMetadata(TextAdaption.None, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region TextWrapping
        public TextWrapping TextWrapping
        {
            get { return (TextWrapping)GetValue(TextWrappingProperty); }
            set { SetValue(TextWrappingProperty, value); }
        }

        public static readonly DependencyProperty TextWrappingProperty =
            DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(TextBlockX));
        #endregion

        #region MatchText
        public string MatchText
        {
            get { return (string)GetValue(MatchTextProperty); }
            set { SetValue(MatchTextProperty, value); }
        }

        public static readonly DependencyProperty MatchTextProperty =
            DependencyProperty.Register("MatchText", typeof(string), typeof(TextBlockX), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region MatchedForeground
        public Brush MatchedForeground
        {
            get { return (Brush)GetValue(MatchedForegroundProperty); }
            set { SetValue(MatchedForegroundProperty, value); }
        }

        public static readonly DependencyProperty MatchedForegroundProperty =
            DependencyProperty.Register("MatchedForeground", typeof(Brush), typeof(TextBlockX), new FrameworkPropertyMetadata(Brushes.Red, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region MatchRule
        public MatchRule MatchRule
        {
            get { return (MatchRule)GetValue(MatchRuleProperty); }
            set { SetValue(MatchRuleProperty, value); }
        }

        public static readonly DependencyProperty MatchRuleProperty =
            DependencyProperty.Register("MatchRule", typeof(MatchRule), typeof(TextBlockX), new FrameworkPropertyMetadata(MatchRule.First, FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #endregion

        #region Methods
        #endregion

        #region Event Handlers
        protected override void OnRender(DrawingContext drawingContext)
        {
            var width = ActualWidth;
            var height = ActualHeight;

            if (width == 0 || height == 0 || string.IsNullOrEmpty(Text))
            {
                return;
            }

            var matchedPointers = GetMatchedPointers();
            var yOffset = 0.0;
            var chars = 0;

            var text = Text;
            var formattedText = CreateFormattedText(text);
            var textHeight = formattedText.Height;
            var charWidth = formattedText.Width / formattedText.Text.Length;

            System.Drawing.Point? lastPointer = null;
            while (true)
            {
                var currentText = GetBoundedText(text, charWidth, width);
                if (currentText.Text.Length == 0)
                {
                    break;
                }
                if (TextAdaption == TextAdaption.ClipToBounds && (yOffset + textHeight * 2) > height)
                {
                    var lastText = CreateFormattedText(text);
                    lastText.MaxTextHeight = textHeight;
                    lastText.MaxTextWidth = width;
                    RenderText(lastText, matchedPointers.Where(x => x >= chars && x < chars + currentText.Text.Length).Select(x => x - chars), ref lastPointer);
                    drawingContext.DrawText(lastText, new Point(0, yOffset));
                    break;
                }
                RenderText(currentText, matchedPointers.Where(x => x >= chars && x < chars + currentText.Text.Length).Select(x => x - chars), ref lastPointer);
                drawingContext.DrawText(currentText, new Point(0, yOffset));

                if (text.Length <= currentText.Text.Length)
                {
                    break;
                }
                chars += currentText.Text.Length;
                yOffset += textHeight;
                text = text.Remove(0, currentText.Text.Length);
            }
        }
        #endregion

        #region Function
        private FormattedText CreateFormattedText(string text)
        {
            return new FormattedText(text,
                Dispatcher.Thread.CurrentUICulture, FlowDirection,
                new Typeface(FontFamily, FontStyle, FontWeight, FontStretch)
                , FontSize
                , Foreground);
        }

        private FormattedText GetBoundedText(string text, double charWidth, double targetWidth)
        {
            var chars = (int)Math.Ceiling(targetWidth / charWidth) - 1;
            var formattedText = CreateFormattedText(chars >= text.Length ? text : text.Remove(chars));

            while (true)
            {
                if (formattedText.Width > targetWidth)
                {
                    chars--;
                    formattedText = CreateFormattedText(text.Remove(chars));
                    continue;
                }
                else if (formattedText.Width < targetWidth)
                {
                    chars++;
                    if (chars > text.Length - 1)
                    {
                        break;
                    }
                    var testText = CreateFormattedText(text.Remove(chars));
                    if (testText.Width < targetWidth)
                    {
                        chars++;
                        formattedText = testText;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return formattedText;
        }

        private IList<int> GetMatchedPointers()
        {
            var list = new List<int>();
            if (string.IsNullOrEmpty(Text) || string.IsNullOrEmpty(MatchText))
            {
                return list;
            }

            if (MatchRule == MatchRule.First)
            {
                var start = Text.IndexOf(MatchText);
                if (start != -1)
                {
                    list.Add(start);
                }
            }
            else
            {
                var splits = Text.Split(new string[] { MatchText }, StringSplitOptions.None);
                var start = splits[0].Length;
                if (start != Text.Length)
                {
                    list.Add(start);
                    for (int i = 1; i < splits.Length - 1; i++)
                    {
                        var text = splits[i];
                        start += MatchText.Length;
                        start += text.Length;
                        list.Add(start);
                    }
                }
            }
            return list;
        }

        private void RenderText(FormattedText formattedText, IEnumerable<int> pointers, ref System.Drawing.Point? lastPointer)
        {
            if (lastPointer != null)
            {
                var pointer = (System.Drawing.Point)lastPointer;
                var count = pointer.Y;
                if (count > formattedText.Text.Length - pointer.Y)
                {
                    count = formattedText.Text.Length - pointer.Y;
                }
                if (count > 0)
                {
                    formattedText.SetForegroundBrush(MatchedForeground, pointer.X, count);
                }
                lastPointer = null;
            }
            foreach (var pointer in pointers)
            {
                var count = MatchText.Length;
                if (count > formattedText.Text.Length - pointer)
                {
                    count = formattedText.Text.Length - pointer;
                    lastPointer = new System.Drawing.Point(0, MatchText.Length - count);
                }
                if (count > 0)
                {
                    formattedText.SetForegroundBrush(MatchedForeground, pointer, count);
                }
            }
        }
        #endregion
    }
}
