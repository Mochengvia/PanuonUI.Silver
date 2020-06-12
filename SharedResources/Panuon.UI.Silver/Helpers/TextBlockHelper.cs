using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class TextBlockHelper
    {
        #region Properties

        #region HighlightText
        public static string GetHighlightText(TextBlock textBlock)
        {
            return (string)textBlock.GetValue(HighlightTextProperty);
        }

        public static void SetHighlightText(TextBlock textBlock, string value)
        {
            textBlock.SetValue(HighlightTextProperty, value);
        }

        public static readonly DependencyProperty HighlightTextProperty =
            DependencyProperty.RegisterAttached("HighlightText", typeof(string), typeof(TextBlockHelper), new PropertyMetadata(OnHighlightTextChanged));
        #endregion

        #region HighlightRule
        public static HighlightRule GetHighlightRule(TextBlock textBlock)
        {
            return (HighlightRule)textBlock.GetValue(HighlightRuleProperty);
        }

        public static void SetHighlightRule(TextBlock textBlock, HighlightRule value)
        {
            textBlock.SetValue(HighlightRuleProperty, value);
        }

        public static readonly DependencyProperty HighlightRuleProperty =
            DependencyProperty.RegisterAttached("HighlightRule", typeof(HighlightRule), typeof(TextBlockHelper), new PropertyMetadata(HighlightRule.All));
        #endregion

        #region HighlightForeground
        public static Brush GetHighlightForeground(TextBlock textBlock)
        {
            return (Brush)textBlock.GetValue(HighlightForegroundProperty);
        }

        public static void SetHighlightForeground(TextBlock textBlock, Brush value)
        {
            textBlock.SetValue(HighlightForegroundProperty, value);
        }

        public static readonly DependencyProperty HighlightForegroundProperty =
            DependencyProperty.RegisterAttached("HighlightForeground", typeof(Brush), typeof(TextBlockHelper), new PropertyMetadata(Brushes.Red));
        #endregion

        #region HighlightBackground
        public static Brush GetHighlightBackground(TextBlock textBlock)
        {
            return (Brush)textBlock.GetValue(HighlightBackgroundProperty);
        }

        public static void SetHighlightBackground(TextBlock textBlock, Brush value)
        {
            textBlock.SetValue(HighlightBackgroundProperty, value);
        }

        public static readonly DependencyProperty HighlightBackgroundProperty =
            DependencyProperty.RegisterAttached("HighlightBackground", typeof(Brush), typeof(TextBlockHelper), new PropertyMetadata(null));

        #endregion

        #endregion

        #region Event Handler
        private static void OnHighlightTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBlock = d as TextBlock;
            if(textBlock == null)
            {
                return;
            }
            var text = textBlock.Text;
            var highlightText = GetHighlightText(textBlock);
            var foreground = GetHighlightForeground(textBlock);
            var background = GetHighlightBackground(textBlock);
            var rule = GetHighlightRule(textBlock);

            if(string.IsNullOrEmpty(text) || string.IsNullOrEmpty(highlightText))
            {
                textBlock.Inlines.Clear();
                textBlock.Inlines.Add(new Run(text));
                return;
            }

            var index = text.IndexOf(highlightText, StringComparison.CurrentCultureIgnoreCase);
            if (index < 0)
            {
                textBlock.Inlines.Clear();
                textBlock.Inlines.Add(new Run(text));
                return;
            }

            textBlock.Inlines.Clear();

            while (true)
            {
                textBlock.Inlines.AddRange(new Inline[]
                    {
                        new Run(text.Substring(0, index)),
                        new Run(text.Substring(index, highlightText.Length))
                        {
                            Background = background,
                            Foreground = foreground
                        }
                    });

                text = text.Substring(index + highlightText.Length);
                index = text.IndexOf(highlightText, StringComparison.CurrentCultureIgnoreCase);

                if (index < 0 || rule == HighlightRule.First)
                {
                    textBlock.Inlines.Add(new Run(text));
                    break;
                }
            }
        }
        #endregion

    }
}
