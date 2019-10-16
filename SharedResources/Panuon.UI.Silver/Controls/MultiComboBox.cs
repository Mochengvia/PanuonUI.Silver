using Panuon.UI.Silver.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class MultiComboBox : System.Windows.Controls.Primitives.MultiSelector
    {
        #region Identifier
        private PropertyInfo _displayMemberPropertyInfo;

        private FrameworkElement _lblIcon;
        #endregion

        #region Constructor
        static MultiComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MultiComboBox), new FrameworkPropertyMetadata(typeof(MultiComboBox)));
        }

        public MultiComboBox()
        {
            Loaded -= MultiComboBox_Loaded;
            Loaded += MultiComboBox_Loaded;
            SizeChanged -= MultiComboBox_SizeChanged;
            SizeChanged += MultiComboBox_SizeChanged;
        }

        #endregion

        public virtual string GenerateText(IList selectedItems)
        {
            var text = "";
            var isFirst = true;

            foreach (var item in selectedItems)
            {
                if (!isFirst)
                    text += TextSeparator;
                else
                    isFirst = false;

                if (item is MultiComboBoxItem)
                {
                    var msi = item as MultiComboBoxItem;
                    text += msi.Content.ToString();
                }
                else
                {
                    if (_displayMemberPropertyInfo == null || _displayMemberPropertyInfo.Name != DisplayMemberPath)
                        _displayMemberPropertyInfo = item.GetType().GetProperty(DisplayMemberPath);

                    text += _displayMemberPropertyInfo.GetValue(item, null).ToString();
                }

                if (MaxTextLength == null)
                {
                    if (!ValidateStringWidth(text + ExceededTextFiller))
                    {
                        if (text.Length == 0)
                            return null;
                        text = text.Remove(text.Length - 1);
                        while(!ValidateStringWidth(text + ExceededTextFiller))
                        {
                            if (text.Length == 0)
                                return null;
                            text = text.Remove(text.Length - 1);
                        }
                        return text + ExceededTextFiller;
                    }
                }
                else if (text.Length >= MaxTextLength)
                {
                    return text.Cut((int)MaxTextLength, ExceededTextFiller);
                }
            }
            return text;
        }

        #region Event
        public static readonly RoutedEvent SearchTextChangedEvent = EventManager.RegisterRoutedEvent("SearchTextChanged", RoutingStrategy.Bubble, typeof(SearchTextChangedEventHandler), typeof(MultiComboBox));
        public event SearchTextChangedEventHandler SearchTextChanged
        {
            add { AddHandler(SearchTextChangedEvent, value); }
            remove { RemoveHandler(SearchTextChangedEvent, value); }
        }
        void RaiseSearchTextChanged(string newValue)
        {
            var arg = new SearchTextChangedEventArgs(newValue, SearchTextChangedEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region Property
        /// <summary>
        /// Gets or sets icon.
        /// </summary>
        public object Icon
        {
            get { return (object)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(object), typeof(MultiComboBox));


        /// <summary>
        /// Gets or sets watermark (place holder).
        /// </summary>
        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.Register("Watermark", typeof(string), typeof(MultiComboBox));

        /// <summary>
        /// Gets or sets max drop down height.
        /// </summary>
        public double MaxDropDownHeight
        {
            get { return (double)GetValue(MaxDropDownHeightProperty); }
            set { SetValue(MaxDropDownHeightProperty, value); }
        }
        public static readonly DependencyProperty MaxDropDownHeightProperty =
            DependencyProperty.Register("MaxDropDownHeight", typeof(double), typeof(MultiComboBox));

        /// <summary>
        /// Gets or sets is drop down open.
        /// </summary>
        public bool IsDropDownOpen
        {
            get { return (bool)GetValue(IsDropDownOpenProperty); }
            set { SetValue(IsDropDownOpenProperty, value); }
        }
        public static readonly DependencyProperty IsDropDownOpenProperty =
            DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(MultiComboBox));

        /// <summary>
        /// Gets or sets stays open.
        /// </summary>
        public bool StaysOpen
        {
            get { return (bool)GetValue(StaysOpenProperty); }
            set { SetValue(StaysOpenProperty, value); }
        }

        public static readonly DependencyProperty StaysOpenProperty =
            DependencyProperty.Register("StaysOpen", typeof(bool), typeof(MultiComboBox));

        /// <summary>
        /// Gets or sets text.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MultiComboBox));

        /// <summary>
        /// Gets or sets checkbox style.
        /// </summary>
        public Style CheckBoxStyle
        {
            get { return (Style)GetValue(CheckBoxStyleProperty); }
            set { SetValue(CheckBoxStyleProperty, value); }
        }
        public static readonly DependencyProperty CheckBoxStyleProperty =
            DependencyProperty.Register("CheckBoxStyle", typeof(Style), typeof(MultiComboBox));

        /// <summary>
        /// Gets or sets text separator.
        /// </summary>
        public string TextSeparator
        {
            get { return (string)GetValue(TextSeparatorProperty); }
            set { SetValue(TextSeparatorProperty, value); }
        }

        public static readonly DependencyProperty TextSeparatorProperty =
            DependencyProperty.Register("TextSeparator", typeof(string), typeof(MultiComboBox), new PropertyMetadata(","));

        /// <summary>
        /// Gets or sets max text length.
        /// </summary>
        public int? MaxTextLength
        {
            get { return (int?)GetValue(MaxTextLengthProperty); }
            set { SetValue(MaxTextLengthProperty, value); }
        }

        public static readonly DependencyProperty MaxTextLengthProperty =
            DependencyProperty.Register("MaxTextLength", typeof(int?), typeof(MultiComboBox));

        /// <summary>
        /// Gets or sets text filler when text length exceeded.
        /// </summary>
        public string ExceededTextFiller
        {
            get { return (string)GetValue(ExceededTextFillerProperty); }
            set { SetValue(ExceededTextFillerProperty, value); }
        }

        public static readonly DependencyProperty ExceededTextFillerProperty =
            DependencyProperty.Register("ExceededTextFiller", typeof(string), typeof(MultiComboBox), new PropertyMetadata("..."));

        /// <summary>
        /// Gets or sets shadow color.
        /// </summary>
        public Color ShadowColor
        {
            get { return (Color)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color), typeof(MultiComboBox));

        /// <summary>
        /// Gets or sets corner radius.
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(MultiComboBox));

        /// <summary>
        /// Gets or sets item height.
        /// </summary>
        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register("ItemHeight", typeof(double), typeof(MultiComboBox));

        /// <summary>
        /// Gets or sets item padding.
        /// </summary>
        public Thickness ItemPadding
        {
            get { return (Thickness)GetValue(ItemPaddingProperty); }
            set { SetValue(ItemPaddingProperty, value); }
        }

        public static readonly DependencyProperty ItemPaddingProperty =
            DependencyProperty.Register("ItemPadding", typeof(Thickness), typeof(MultiComboBox));


        /// <summary>
        /// Gets or sets is search textbox visible.
        /// </summary>
        public bool IsSearchTextBoxVisible
        {
            get { return (bool)GetValue(IsSearchTextBoxVisibleProperty); }
            set { SetValue(IsSearchTextBoxVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsSearchTextBoxVisibleProperty =
            DependencyProperty.Register("IsSearchTextBoxVisible", typeof(bool), typeof(MultiComboBox));


        /// <summary>
        /// Gets or sets search text.
        /// </summary>
        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }

        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register("SearchText", typeof(string), typeof(MultiComboBox), new PropertyMetadata(OnSearchTextChanged));


        /// <summary>
        /// Gets or sets search text box watermark.
        /// </summary>
        public string SearchTextBoxWatermark
        {
            get { return (string)GetValue(SearchTextBoxWatermarkProperty); }
            set { SetValue(SearchTextBoxWatermarkProperty, value); }
        }

        public static readonly DependencyProperty SearchTextBoxWatermarkProperty =
            DependencyProperty.Register("SearchTextBoxWatermark", typeof(string), typeof(MultiComboBox));


        #endregion

        #region EventHandler
        private static void OnSearchTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = d as MultiComboBox;
            selector.RaiseSearchTextChanged(e.NewValue as string);
        }

        private void MultiComboBox_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!IsLoaded)
                return;

            UpdateText();
        }
        private void MultiComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateText();
        }
        #endregion

        #region Override
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MultiComboBoxItem();
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            if (!IsLoaded)
                return;

            UpdateText();
            base.OnSelectionChanged(e);
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            if (item is MultiComboBoxItem)
                return true;
            else
                return false;
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var uie = element as FrameworkElement;

            if(!(item is MultiComboBoxItem))
            {
                var textBinding = new Binding(DisplayMemberPath);
                textBinding.Source = item;
                uie.SetBinding(ContentPresenter.ContentProperty, textBinding);
            }

            base.PrepareContainerForItemOverride(element, item);
        }

        #endregion

        #region Function
        private void UpdateText()
        {
            Text = GenerateText(SelectedItems);
        }

        private bool ValidateStringWidth(string text)
        {
            if(_lblIcon == null)
            {
                _lblIcon = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(this, 0), 1), 0) as FrameworkElement;
            }
            var size = MeasureString(text);
            if (size.Width > (ActualWidth - Padding.Left - Padding.Right - 30 - _lblIcon?.ActualWidth))
                return false;
            else
                return true;

        }

        private Size MeasureString(string candidate)
        {
            var formattedText = new FormattedText(candidate,System.Globalization.CultureInfo.CurrentCulture,FlowDirection.LeftToRight,new Typeface(FontFamily, FontStyle, FontWeight, FontStretch),FontSize,Brushes.Black,new NumberSubstitution(), TextFormattingMode.Display);

            return new Size(formattedText.Width, formattedText.Height);
        }
        #endregion
    }

}
