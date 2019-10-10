using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class MultiSelector : Control
    {
        #region Identity
        private PropertyInfo _selectedPropertyInfo;

        private PropertyInfo _displayPropertyInfo;

        private List<string> _selectedNameList;
        #endregion

        #region Constructor
        static MultiSelector()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MultiSelector), new FrameworkPropertyMetadata(typeof(MultiSelector)));
        }

        public MultiSelector()
        {
            _selectedNameList = new List<string>();
            AddHandler(CheckBox.ClickEvent, new RoutedEventHandler(OnIsCheckedOrUncheckedChanged));
        }
        #endregion

        #region Routed Event
        public static readonly RoutedEvent SelectionChangedEvent = EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MultiSelector));
        public event RoutedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }

        void RaiseSelectionChanged()
        {
            var arg = new RoutedEventArgs(SelectionChangedEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region Event Handler
        private void OnIsCheckedOrUncheckedChanged(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded)
                return;

            var checkBox = e.OriginalSource as CheckBox;
            if (checkBox == null || checkBox.Tag == null)
                return;

            var item = checkBox.Tag;
            _selectedPropertyInfo.SetValue(item, checkBox.IsChecked, null);
            var value = _displayPropertyInfo.GetValue(item, null);
            if (checkBox.IsChecked == true)
            {
                _selectedNameList.Add(value.ToString());
            }
            else
            {
                _selectedNameList.Remove(value.ToString());
            }
            RaiseSelectionChanged();
            UpdateText();
        }
        #endregion

        #region Property
        /// <summary>
        /// gets or sets max text length.
        /// </summary>
        public int MaxTextLength
        {
            get { return (int)GetValue(MaxTextLengthProperty); }
            set { SetValue(MaxTextLengthProperty, value); }
        }

        public static readonly DependencyProperty MaxTextLengthProperty =
            DependencyProperty.Register("MaxTextLength", typeof(int), typeof(MultiSelector), new PropertyMetadata(20));

        /// <summary>
        /// gets or sets corner radius.
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(MultiSelector));

        /// <summary>
        /// gets or sets watermark
        /// </summary>
        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.Register("Watermark", typeof(string), typeof(MultiSelector));

        /// <summary>
        /// gets or sets itemssource
        /// </summary>
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(MultiSelector), new PropertyMetadata(OnItemsSourceChanged));

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = d as MultiSelector;
            selector.CheckSelectedPropertyInfo();
            selector.InitSelectedNameList();
            selector.UpdateText();
        }

        /// <summary>
        /// gets or sets display member path
        /// </summary>
        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }

        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register("DisplayMemberPath", typeof(string), typeof(MultiSelector));

        /// <summary>
        /// gets or sets selected member path
        /// </summary>
        public string SelectedMemberPath
        {
            get { return (string)GetValue(SelectedMemberPathProperty); }
            set { SetValue(SelectedMemberPathProperty, value); }
        }

        public static readonly DependencyProperty SelectedMemberPathProperty =
            DependencyProperty.Register("SelectedMemberPath", typeof(string), typeof(MultiSelector));

        /// <summary>
        /// gets or sets shadowcolor
        /// </summary>
        public Color ShadowColor
        {
            get { return (Color)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color), typeof(MultiSelector));

        /// <summary>
        /// gets or sets isdropdownopen
        /// </summary>
        public bool IsDropDownOpen
        {
            get { return (bool)GetValue(IsDropDownOpenProperty); }
            set { SetValue(IsDropDownOpenProperty, value); }
        }

        public static readonly DependencyProperty IsDropDownOpenProperty =
            DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(MultiSelector));

        /// <summary>
        /// gets or sets text
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MultiSelector));

        /// <summary>
        /// gets or sets checkbox style
        /// </summary>
        public Style CheckBoxStyle
        {
            get { return (Style)GetValue(CheckBoxStyleProperty); }
            set { SetValue(CheckBoxStyleProperty, value); }
        }

        public static readonly DependencyProperty CheckBoxStyleProperty =
            DependencyProperty.Register("CheckBoxStyle", typeof(Style), typeof(MultiSelector));


        /// <summary>
        /// Gets or sets max dropdown height.
        /// </summary>
        public double MaxDropDownHeight
        {
            get { return (double)GetValue(MaxDropDownHeightProperty); }
            set { SetValue(MaxDropDownHeightProperty, value); }
        }

        public static readonly DependencyProperty MaxDropDownHeightProperty =
            DependencyProperty.Register("MaxDropDownHeight", typeof(double), typeof(MultiSelector), new PropertyMetadata(250.0));



        public bool StaysOpen
        {
            get { return (bool)GetValue(StaysOpenProperty); }
            set { SetValue(StaysOpenProperty, value); }
        }

        public static readonly DependencyProperty StaysOpenProperty =
            DependencyProperty.Register("StaysOpen", typeof(bool), typeof(MultiSelector));


        #endregion

        #region Function
        private void CheckSelectedPropertyInfo()
        {
            object firstItem = null;
            foreach (var item in ItemsSource)
            {
                firstItem = item;
                break;
            }
            if (firstItem == null)
                return;

            if (DisplayMemberPath.IsNullOrEmpty())
                throw new Exception("Property 'DisplayMemberPath' can not be null or empty.");

            if (SelectedMemberPath.IsNullOrEmpty())
                throw new Exception("Property 'SelectedMemberPath' can not be null.");

            _selectedPropertyInfo = firstItem.GetType().GetProperty(SelectedMemberPath);
            _displayPropertyInfo = firstItem.GetType().GetProperty(DisplayMemberPath);

            if (_displayPropertyInfo == null)
            {
                throw new Exception("'" + DisplayMemberPath + "' does not existed.");
            }
            if (_selectedPropertyInfo == null || _selectedPropertyInfo.PropertyType != typeof(bool))
            {
                throw new Exception("'" + SelectedMemberPath + "' does not existed , or is not 'bool' type.");
            }
        }

        private void InitSelectedNameList()
        {
            _selectedNameList.Clear();
            foreach (var item in ItemsSource)
            {
                if ((_selectedPropertyInfo.GetValue(item, null) as bool?) == true)
                {
                    _selectedNameList.Add(_displayPropertyInfo.GetValue(item, null).ToString());
                }
            }
        }

        private void UpdateText()
        {
            _selectedNameList.Sort();
            var text = string.Join(",", _selectedNameList);
            if (text.Length > MaxTextLength)
            {
                text = text.Remove(MaxTextLength, text.Length - MaxTextLength);
                text += "...";
            }
            Text = text;
        }
        #endregion
    }

}
