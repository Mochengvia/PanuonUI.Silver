using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

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

        #region HoverBrush
        public static Brush GetHoverBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HoverBrushProperty);
        }

        public static void SetHoverBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(HoverBrushProperty, value);
        }

        public static readonly DependencyProperty HoverBrushProperty =
            DependencyProperty.RegisterAttached("HoverBrush", typeof(Brush), typeof(ComboBoxHelper));
        #endregion

        #region SelectedBrush
        public static Brush GetSelectedBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(SelectedBrushProperty);
        }

        public static void SetSelectedBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(SelectedBrushProperty, value);
        }

        public static readonly DependencyProperty SelectedBrushProperty =
            DependencyProperty.RegisterAttached("SelectedBrush", typeof(Brush), typeof(ComboBoxHelper));
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
            return (object)obj.GetValue(IconProperty);
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

        #region (Event) SearchTextChanged

        public static readonly RoutedEvent SearchTextChangedEvent = EventManager.RegisterRoutedEvent("SearchTextChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<string>), typeof(ComboBoxHelper));
        public static void AddSearchTextChangedHandler(DependencyObject d, RoutedPropertyChangedEventHandler<string> handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.AddHandler(SearchTextChangedEvent, handler);
            }
        }
        public static void RemoveSearchTextChangedHandler(DependencyObject d, RoutedPropertyChangedEventHandler<string> handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.RemoveHandler(SearchTextChangedEvent, handler);
            }
        }

        private static void RaiseSearchTextChanged(UIElement uie, string newValue, string oldValue)
        {
            var arg = new RoutedPropertyChangedEventArgs<string>(oldValue, newValue, SearchTextChangedEvent);
            uie.RaiseEvent(arg);
        }
        #endregion

        #region (Internal) SearchText

        internal static string GetSearchText(DependencyObject obj)
        {
            return (string)obj.GetValue(SearchTextProperty);
        }

        internal static void SetSearchText(DependencyObject obj, string value)
        {
            obj.SetValue(SearchTextProperty, value);
        }

        internal static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.RegisterAttached("SearchText", typeof(string), typeof(ComboBoxHelper), new PropertyMetadata(OnSearchTextChanged));

        private static void OnSearchTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var comboBox = d as ComboBox;
            comboBox.DropDownClosed -= ComboBox_DropDownClosed;
            comboBox.DropDownClosed += ComboBox_DropDownClosed;
            RaiseSearchTextChanged(comboBox, (string)e.NewValue, (string)e.OldValue);
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
            return (object)obj.GetValue(HeaderProperty);
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
        public static object GetBindToEnum(DependencyObject obj)
        {
            return (object)obj.GetValue(BindToEnumProperty);
        }

        public static void SetBindToEnum(DependencyObject obj, Enum value)
        {
            obj.SetValue(BindToEnumProperty, value);
        }

        public static readonly DependencyProperty BindToEnumProperty =
            DependencyProperty.RegisterAttached("BindToEnum", typeof(object), typeof(ComboBoxHelper), new PropertyMetadata(OnBindToEnumChanged));

        private static void OnBindToEnumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var comboBox = d as ComboBox;
            var obj = e.NewValue as object;
            var en = obj.GetType();
            if (!en.IsEnum)
                throw new Exception($"\"{en.Name}\" is not enum type.");

            if (en == null)
            {
                comboBox.ItemsSource = null;
                comboBox.SelectedItem = null;
            }
            else
            {
                comboBox.ItemsSource = Enum.GetValues(en).Cast<Enum>();
                comboBox.SelectedItem = obj;
            }
        }
        #endregion

    }
}
