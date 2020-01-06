using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Panuon.UI.Silver
{
    public static class ComboBoxHelper
    {
        #region Ctor
        static ComboBoxHelper()
        {
            EventManager.RegisterClassHandler(typeof(ComboBoxItem), ComboBoxItem.MouseEnterEvent, new RoutedEventHandler(OnComboBoxItemMouseEnter));
            EventManager.RegisterClassHandler(typeof(ComboBoxItem), ComboBoxItem.MouseLeaveEvent, new RoutedEventHandler(OnComboBoxItemMouseLeave));
        }
     
        #endregion

        #region Routed Event
        #region ItemRemoving
        public static readonly RoutedEvent ItemRemovingEvent = EventManager.RegisterRoutedEvent("ItemRemoving", RoutingStrategy.Bubble, typeof(RemovingRoutedEventHandler), typeof(ComboBoxHelper));

        public static void AddItemRemovingHandler(DependencyObject d, RemovingRoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.AddHandler(ItemRemovingEvent, handler);
            }
        }

        public static void RemoveItemRemovingHandler(DependencyObject d, RemovingRoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.RemoveHandler(ItemRemovingEvent, handler);
            }
        }

        internal static bool RaiseItemRemoving(UIElement uie, object item)
        {
            var arg = new RemovingRoutedEventArgs(item, ItemRemovingEvent);
            uie.RaiseEvent(arg);
            return !arg.Cancel;
        }
        #endregion

        #region ItemRemoved
        public static readonly RoutedEvent ItemRemovedEvent = EventManager.RegisterRoutedEvent("ItemRemoved", RoutingStrategy.Bubble, typeof(RemovedRoutedEventHandler), typeof(ComboBoxHelper));

        public static void AddItemRemovedHandler(DependencyObject d, RemovedRoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.AddHandler(ItemRemovedEvent, handler);
            }
        }

        public static void RemoveItemRemovedHandler(DependencyObject d, RemovedRoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.RemoveHandler(ItemRemovedEvent, handler);
            }
        }

        internal static void RaiseItemRemoved(UIElement uie, object item, bool hasRemovedFromSource)
        {
            var arg = new RemovedRoutedEventArgs(item, hasRemovedFromSource, ItemRemovedEvent);
            uie.RaiseEvent(arg);
        }
        #endregion
        #endregion

        #region Properties

        #region ComboBoxStyle


        public static ComboBoxStyle GetComboBoxStyle(DependencyObject obj)
        {
            return (ComboBoxStyle)obj.GetValue(ComboBoxStyleProperty);
        }

        public static void SetComboBoxStyle(DependencyObject obj, ComboBoxStyle value)
        {
            obj.SetValue(ComboBoxStyleProperty, value);
        }

        public static readonly DependencyProperty ComboBoxStyleProperty =
            DependencyProperty.RegisterAttached("ComboBoxStyle", typeof(ComboBoxStyle), typeof(ComboBoxHelper));
        #endregion

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
            DependencyProperty.RegisterAttached("ItemHeight", typeof(double), typeof(ComboBoxHelper), new FrameworkPropertyMetadata(30.0, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region ItemRemovable
        public static bool GetItemRemovable(DependencyObject obj)
        {
            return (bool)obj.GetValue(ItemRemovableProperty);
        }

        public static void SetItemRemovable(DependencyObject obj, bool value)
        {
            obj.SetValue(ItemRemovableProperty, value);
        }

        public static readonly DependencyProperty ItemRemovableProperty =
            DependencyProperty.RegisterAttached("ItemRemovable", typeof(bool), typeof(ComboBoxHelper), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region ItemHoverBackground

        public static Brush GetItemHoverBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ItemHoverBackgroundProperty);
        }

        public static void SetItemHoverBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(ItemHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemHoverBackground", typeof(Brush), typeof(ComboBoxHelper), new FrameworkPropertyMetadata("#EEEEEE".ToColor().ToBrush(), FrameworkPropertyMetadataOptions.Inherits));


        #endregion

        #region ItemHoverForeground


        public static Brush GetItemHoverForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ItemHoverForegroundProperty);
        }

        public static void SetItemHoverForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(ItemHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemHoverForegroundProperty =
            DependencyProperty.RegisterAttached("ItemHoverForeground", typeof(Brush), typeof(ComboBoxHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));


        #endregion

        #region ItemHoverBorderBrush
        public static Brush GetItemHoverBorderBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ItemHoverBorderBrushProperty);
        }

        public static void SetItemHoverBorderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(ItemHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemHoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemHoverBorderBrush", typeof(Brush), typeof(ComboBoxHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region ItemSelectedBackground

        public static Brush GetItemSelectedBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ItemSelectedBackgroundProperty);
        }

        public static void SetItemSelectedBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(ItemSelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemSelectedBackground", typeof(Brush), typeof(ComboBoxHelper), new FrameworkPropertyMetadata("#DDDDDD".ToColor().ToBrush(), FrameworkPropertyMetadataOptions.Inherits));


        #endregion

        #region ItemSelectedForeground


        public static Brush GetItemSelectedForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ItemSelectedForegroundProperty);
        }

        public static void SetItemSelectedForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(ItemSelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedForegroundProperty =
            DependencyProperty.RegisterAttached("ItemSelectedForeground", typeof(Brush), typeof(ComboBoxHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));


        #endregion

        #region ItemSelectedBorderBrush
        public static Brush GetItemSelectedBorderBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ItemSelectedBorderBrushProperty);
        }

        public static void SetItemSelectedBorderBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(ItemSelectedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemSelectedBorderBrush", typeof(Brush), typeof(ComboBoxHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
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

        #region DropDownPlacement
        public static DropDownPlacement GetDropDownPlacement(DependencyObject obj)
        {
            return (DropDownPlacement)obj.GetValue(DropDownPlacementProperty);
        }

        public static void SetDropDownPlacement(DependencyObject obj, DropDownPlacement value)
        {
            obj.SetValue(DropDownPlacementProperty, value);
        }

        public static readonly DependencyProperty DropDownPlacementProperty =
            DependencyProperty.RegisterAttached("DropDownPlacement", typeof(DropDownPlacement), typeof(ComboBoxHelper));
        #endregion

        #region ShadowColor


        public static Color? GetShadowColor(DependencyObject obj)
        {
            return (Color?)obj.GetValue(ShadowColorProperty);
        }

        public static void SetShadowColor(DependencyObject obj, Color? value)
        {
            obj.SetValue(ShadowColorProperty, value);
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.RegisterAttached("ShadowColor", typeof(Color?), typeof(ComboBoxHelper));


        #endregion

        #region CanSearch


        public static bool GetCanSearch(DependencyObject obj)
        {
            return (bool)obj.GetValue(CanSearchProperty);
        }

        public static void SetCanSearch(DependencyObject obj, bool value)
        {
            obj.SetValue(CanSearchProperty, value);
        }

        public static readonly DependencyProperty CanSearchProperty =
            DependencyProperty.RegisterAttached("CanSearch", typeof(bool), typeof(ComboBoxHelper));


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

        #endregion

        #endregion

        #region Commands
        public static readonly DependencyProperty RemoveCommandProperty =
            DependencyProperty.RegisterAttached("RemoveCommand", typeof(ICommand), typeof(ComboBoxHelper), new PropertyMetadata(new Command(OnRemoveCommandExecute)));
        #endregion

        #region Event Handler
        private static void OnComboBoxItemMouseEnter(object sender, RoutedEventArgs e)
        {
            var button = sender as ComboBoxItem;
            var hoverBackground = GetItemHoverBackground(button);
            var hoverBorderBrush = GetItemHoverBorderBrush(button);
            var hoverForeground = GetItemHoverForeground(button);

            if (hoverBackground == null && hoverBorderBrush == null && hoverForeground == null)
                return;

            var dic = new Dictionary<DependencyProperty, Brush>();
            dic.Add(ComboBoxItem.BackgroundProperty, hoverBackground);
            dic.Add(ComboBoxItem.ForegroundProperty, hoverForeground);
            dic.Add(ComboBoxItem.BorderBrushProperty, hoverBorderBrush);

            StoryboardUtils.BeginStoryboard(button, dic);
        }

        private static void OnComboBoxItemMouseLeave(object sender, RoutedEventArgs e)
        {
            var button = sender as ComboBoxItem;
            var hoverBackground = GetItemHoverBackground(button);
            var hoverBorderBrush = GetItemHoverBorderBrush(button);
            var hoverForeground = GetItemHoverForeground(button);

            if (hoverBackground == null && hoverBorderBrush == null && hoverForeground == null)
                return;

            var list = new List<DependencyProperty>();
            list.Add(ComboBoxItem.BackgroundProperty);
            list.Add(ComboBoxItem.ForegroundProperty);
            list.Add(ComboBoxItem.BorderBrushProperty);

            StoryboardUtils.BeginStoryboard(button, list);
        }

        private static void OnRemoveCommandExecute(object obj)
        {
            var parameters = obj as object[];
            var comboBoxItem = parameters[0] as ComboBoxItem;
            var comboBox = parameters[1] as ComboBox;

            var dataObject = comboBox.ItemContainerGenerator.ItemFromContainer(comboBoxItem);
            var result = ComboBoxHelper.RaiseItemRemoving(comboBox, dataObject);
            if (!result)
            {
                return;
            }
            else
            {
                bool hasRemovedFromSource = false;
                if (dataObject is ComboBoxItem)
                {
                    try
                    {
                        comboBox.Items.Remove(comboBoxItem);
                        hasRemovedFromSource = true;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }
                }
                ComboBoxHelper.RaiseItemRemoved(comboBox, dataObject, hasRemovedFromSource);
            }
        }

        private static void OnBindToEnumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var comboBox = d as ComboBox;
            var selectedValue = comboBox.SelectedValue ?? e.NewValue as object;
            if (selectedValue == null)
                return;

            var type = selectedValue.GetType();
            if (!type.IsEnum)
                throw new Exception($"\"{type.FullName}\" is not an enumeration type.");

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
                comboBox.SelectedValue = selectedValue;
            }
        }

        #endregion
    }

}
