using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    [ContentProperty(nameof(Text))]
    public class MatchTextBlock : TextBlock
    {
        static MatchTextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MatchTextBlock), new FrameworkPropertyMetadata(typeof(MatchTextBlock)));
        }

        #region Property
        /// <summary>
        /// Gets or sets match text.
        /// </summary>
        public string MatchText
        {
            get { return (string)GetValue(MatchTextProperty); }
            set { SetValue(MatchTextProperty, value); }
        }

        public static readonly DependencyProperty MatchTextProperty =
            DependencyProperty.Register("MatchText", typeof(string), typeof(MatchTextBlock), new PropertyMetadata(OnMatchTextChanged));

        /// <summary>
        /// Gets or sets matched text foreground/
        /// </summary>
        public Brush MatchedForeground
        {
            get { return (Brush)GetValue(MatchedForegroundProperty); }
            set { SetValue(MatchedForegroundProperty, value); }
        }

        public static readonly DependencyProperty MatchedForegroundProperty =
            DependencyProperty.Register("MatchedForeground", typeof(Brush), typeof(MatchTextBlock), new PropertyMetadata("#FF3C3C".ToColor().ToBrush()));


        #endregion

        #region Event Handler
        private static void OnMatchTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBlock = d as MatchTextBlock;

            textBlock.Inlines.Clear();

            if (string.IsNullOrEmpty(textBlock.MatchText) || !textBlock.Text.Contains(textBlock.MatchText))
            {
                textBlock.Text = textBlock.Text;
                return;
            }
            else
                textBlock.Text = null;

            var splits = textBlock.Text.Split(new string[] { textBlock.MatchText }, StringSplitOptions.None);
            if (splits == null || splits.Length != 2)
            {
                textBlock.Text = textBlock.Text;
                return;
            }

            textBlock.Inlines.Add(new Run() { Text = splits[0] });
            textBlock.Inlines.Add(new Run() { Text = textBlock.MatchText, Foreground = textBlock.MatchedForeground });
            textBlock.Inlines.Add(new Run() { Text = splits[1] });
        }
        #endregion
    }
}
