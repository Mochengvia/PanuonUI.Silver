using Panuon.UI.Silver.Core;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class ComboBoxHelper
    {
        #region ItemHeight
        public static double GetItemHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(ItemHeightProperty);
        }

        public static void SetItemHeight(DependencyObject obj, double value)
        {
            obj.SetValue(ItemHeightProperty, value);
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.RegisterAttached("ItemHeight", typeof(double), typeof(ComboBoxHelper));
        #endregion

        #region HoverForeground
        public static Brush GetHoverForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HoverForegroundProperty);
        }

        public static void SetHoverForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(HoverForegroundProperty, value);
        }

        public static readonly DependencyProperty HoverForegroundProperty =
            DependencyProperty.RegisterAttached("HoverForeground", typeof(Brush), typeof(ComboBoxHelper));
        #endregion

        #region HoverBackground
        public static Brush GetHoverBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HoverBackgroundProperty);
        }

        public static void SetHoverBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(HoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.RegisterAttached("HoverBackground", typeof(Brush), typeof(ComboBoxHelper));
        #endregion

        #region SelectedForeground
        public static Brush GetSelectedForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(SelectedForegroundProperty);
        }

        public static void SetSelectedForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(SelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty SelectedForegroundProperty =
            DependencyProperty.RegisterAttached("SelectedForeground", typeof(Brush), typeof(ComboBoxHelper));
        #endregion

        #region SelectedBackground
        public static Brush GetSelectedBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(SelectedBackgroundProperty);
        }

        public static void SetSelectedBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(SelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty SelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("SelectedBackground", typeof(Brush), typeof(ComboBoxHelper));
        #endregion

        #region CornerRadius
        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ComboBoxHelper));
        #endregion

        #region Icon
        public static object GetIcon(DependencyObject obj)
        {
            return obj.GetValue(IconProperty);
        }

        public static void SetIcon(DependencyObject obj, object value)
        {
            obj.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(ComboBoxHelper));
        #endregion

        #region Watermark
        public static string GetWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(ComboBoxHelper));
        #endregion

        #region ShadowColor
        public static Color GetShadowColor(DependencyObject obj)
        {
            return (Color)obj.GetValue(ShadowColorProperty);
        }

        public static void SetShadowColor(DependencyObject obj, Color value)
        {
            obj.SetValue(ShadowColorProperty, value);
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.RegisterAttached("ShadowColor", typeof(Color), typeof(ComboBoxHelper));
        #endregion

        #region IsSearchTextBoxVisible
        public static bool GetIsSearchTextBoxVisible(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsSearchTextBoxVisibleProperty);
        }

        public static void SetIsSearchTextBoxVisible(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSearchTextBoxVisibleProperty, value);
        }

        public static readonly DependencyProperty IsSearchTextBoxVisibleProperty =
            DependencyProperty.RegisterAttached("IsSearchTextBoxVisible", typeof(bool), typeof(ComboBoxHelper));
        #endregion

        #region SearchTextBoxWatermark
        public static string GetSearchTextBoxWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(SearchTextBoxWatermarkProperty);
        }

        public static void SetSearchTextBoxWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(SearchTextBoxWatermarkProperty, value);
        }

        public static readonly DependencyProperty SearchTextBoxWatermarkProperty =
            DependencyProperty.RegisterAttached("SearchTextBoxWatermark", typeof(string), typeof(ComboBoxHelper));
        #endregion

        #region DropDownCornerRadius
        public static CornerRadius GetDropDownCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(DropDownCornerRadiusProperty);
        }

        public static void SetDropDownCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(DropDownCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty DropDownCornerRadiusProperty =
            DependencyProperty.RegisterAttached("DropDownCornerRadius", typeof(CornerRadius), typeof(ComboBoxHelper));
        #endregion

        #region DropDownPadding
        public static Thickness GetDropDownPadding(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(DropDownPaddingProperty);
        }

        public static void SetDropDownPadding(DependencyObject obj, Thickness value)
        {
            obj.SetValue(DropDownPaddingProperty, value);
        }

        public static readonly DependencyProperty DropDownPaddingProperty =
            DependencyProperty.RegisterAttached("DropDownPadding", typeof(Thickness), typeof(ComboBoxHelper));
        #endregion

        #region (Event) SearchTextChanged

        public static readonly RoutedEvent SearchTextChangedEvent = EventManager.RegisterRoutedEvent("SearchTextChanged", RoutingStrategy.Bubble, typeof(SearchTextChangedEventHandler), typeof(ComboBoxHelper));
        public static void AddSearchTextChangedHandler(DependencyObject d, SearchTextChangedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.AddHandler(SearchTextChangedEvent, handler);
            }
        }
        public static void RemoveSearchTextChangedHandler(DependencyObject d, SearchTextChangedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.RemoveHandler(SearchTextChangedEvent, handler);
            }
        }

        private static void RaiseSearchTextChanged(UIElement uie, string newValue)
        {
            var arg = new SearchTextChangedEventArgs(newValue, SearchTextChangedEvent);
            uie.RaiseEvent(arg);
        }
        #endregion

        #region SearchText

        public static string GetSearchText(DependencyObject obj)
        {
            return (string)obj.GetValue(SearchTextProperty);
        }

        public static void SetSearchText(DependencyObject obj, string value)
        {
            obj.SetValue(SearchTextProperty, value);
        }

        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.RegisterAttached("SearchText", typeof(string), typeof(ComboBoxHelper), new PropertyMetadata(OnSearchTextChanged));

        private static void OnSearchTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var comboBox = d as ComboBox;
            comboBox.DropDownClosed -= ComboBox_DropDownClosed;
            comboBox.DropDownClosed += ComboBox_DropDownClosed;
            RaiseSearchTextChanged(comboBox, (string)e.NewValue);
        }

        private static void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            SetSearchText(comboBox, "");
        }
        #endregion

        #region Header
        public static object GetHeader(DependencyObject obj)
        {
            return obj.GetValue(HeaderProperty);
        }

        public static void SetHeader(DependencyObject obj, object value)
        {
            obj.SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.RegisterAttached("Header", typeof(object), typeof(ComboBoxHelper));
        #endregion

        #region HeaderWidth
        public static string GetHeaderWidth(DependencyObject obj)
        {
            return (string)obj.GetValue(HeaderWidthProperty);
        }

        public static void SetHeaderWidth(DependencyObject obj, string value)
        {
            obj.SetValue(HeaderWidthProperty, value);
        }

        public static readonly DependencyProperty HeaderWidthProperty =
            DependencyProperty.RegisterAttached("HeaderWidth", typeof(string), typeof(ComboBoxHelper), new PropertyMetadata("Auto"));
        #endregion

        #region BindToEnum
        public static Enum GetBindToEnum(DependencyObject obj)
        {
            return (Enum)obj.GetValue(BindToEnumProperty);
        }

        public static void SetBindToEnum(DependencyObject obj, Enum value)
        {
            obj.SetValue(BindToEnumProperty, value);
        }

        public static readonly DependencyProperty BindToEnumProperty =
            DependencyProperty.RegisterAttached("BindToEnum", typeof(Enum), typeof(ComboBoxHelper), new PropertyMetadata(OnBindToEnumChanged));

        private static void OnBindToEnumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var comboBox = d as ComboBox;
            var obj = comboBox.SelectedValue ?? e.NewValue as object;
            if (obj == null)
                return;

            var type = obj.GetType();
            if (!type.IsEnum)
                throw new Exception($"\"{type.Name}\" is not enum type.");

            if (type == null)
            {
                comboBox.ItemsSource = null;
                comboBox.SelectedItem = null;
            }
            else
            {
                var enumList = new ArrayList();
                foreach (Enum item in Enum.GetValues(type))
                {
                    var field = type.GetField(item.ToString());
                    if (null != field)
                    {
                        var descriptions = field.GetCustomAttributes(typeof(DescriptionAttribute), true) as DescriptionAttribute[];
                        if (descriptions.Length > 0)
                        {
                            enumList.Add(new
                            {
                                Name = descriptions[0].Description,
                                Enum = item,
                            });
                        }
                        else
                            enumList.Add(new
                            {
                                Name = item.ToString(),
                                Enum = item,
                            });
                    }
                }
                comboBox.ItemsSource = enumList;
                comboBox.DisplayMemberPath = "Name";
                comboBox.SelectedValuePath = "Enum";
                comboBox.SelectedValue = obj;
            }
        }
        #endregion

    }
}
