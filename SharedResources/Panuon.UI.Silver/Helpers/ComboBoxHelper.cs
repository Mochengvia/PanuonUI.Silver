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


        public static ComboBoxStyle GetComboBoxStyle(ComboBox comboBox)
        {
            return (ComboBoxStyle)comboBox.GetValue(ComboBoxStyleProperty);
        }

        public static void SetComboBoxStyle(ComboBox comboBox, ComboBoxStyle value)
        {
            comboBox.SetValue(ComboBoxStyleProperty, value);
        }

        public static readonly DependencyProperty ComboBoxStyleProperty =
            DependencyProperty.RegisterAttached("ComboBoxStyle", typeof(ComboBoxStyle), typeof(ComboBoxHelper));
        #endregion

        #region ItemsHeight
        public static double GetItemsHeight(ComboBox comboBox)
        {
            return (double)comboBox.GetValue(ItemsHeightProperty);
        }

        public static void SetItemsHeight(ComboBox comboBox, double value)
        {
            comboBox.SetValue(ItemsHeightProperty, value);
        }

        public static readonly DependencyProperty ItemsHeightProperty =
            DependencyProperty.RegisterAttached("ItemsHeight", typeof(double), typeof(ComboBoxHelper), new FrameworkPropertyMetadata(30.0, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region ItemRemovable
        public static bool GetItemsRemovable(ComboBox comboBox)
        {
            return (bool)comboBox.GetValue(ItemsRemovableProperty);
        }

        public static void SetItemsRemovable(ComboBox comboBox, bool value)
        {
            comboBox.SetValue(ItemsRemovableProperty, value);
        }

        public static readonly DependencyProperty ItemsRemovableProperty =
            DependencyProperty.RegisterAttached("ItemsRemovable", typeof(bool), typeof(ComboBoxHelper));

        public static bool GetItemRemovable(ComboBoxItem comboBoxItem)
        {
            return (bool)comboBoxItem.GetValue(ItemRemovableProperty);
        }

        public static void SetItemRemovable(ComboBoxItem comboBoxItem, bool value)
        {
            comboBoxItem.SetValue(ItemRemovableProperty, value);
        }

        public static readonly DependencyProperty ItemRemovableProperty =
            DependencyProperty.RegisterAttached("ItemRemovable", typeof(bool), typeof(ComboBoxHelper));
        #endregion

        #region ItemHoverBackground
        public static Brush GetItemsHoverBackground(ComboBox comboBox)
        {
            return (Brush)comboBox.GetValue(ItemHoverBackgroundProperty);
        }

        public static void SetItemsHoverBackground(ComboBox comboBox, Brush value)
        {
            comboBox.SetValue(ItemsHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemsHoverBackground", typeof(Brush), typeof(ComboBoxHelper));

        public static Brush GetItemHoverBackground(ComboBoxItem comboBoxItem)
        {
            return (Brush)comboBoxItem.GetValue(ItemHoverBackgroundProperty);
        }

        public static void SetItemHoverBackground(ComboBoxItem comboBoxItem, Brush value)
        {
            comboBoxItem.SetValue(ItemHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemHoverBackground", typeof(Brush), typeof(ComboBoxHelper));


        #endregion

        #region ItemHoverForeground
        public static Brush GetItemsHoverForeground(ComboBox comboBox)
        {
            return (Brush)comboBox.GetValue(ItemsHoverForegroundProperty);
        }

        public static void SetItemsHoverForeground(ComboBox comboBox, Brush value)
        {
            comboBox.SetValue(ItemsHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverForegroundProperty =
            DependencyProperty.RegisterAttached("ItemsHoverForeground", typeof(Brush), typeof(ComboBoxHelper));



        public static Brush GetItemHoverForeground(ComboBoxItem comboBoxItem)
        {
            return (Brush)comboBoxItem.GetValue(ItemHoverForegroundProperty);
        }

        public static void SetItemHoverForeground(ComboBoxItem comboBoxItem, Brush value)
        {
            comboBoxItem.SetValue(ItemHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemHoverForegroundProperty =
            DependencyProperty.RegisterAttached("ItemHoverForeground", typeof(Brush), typeof(ComboBoxHelper));


        #endregion

        #region ItemHoverBorderBrush
        public static Brush GetItemsHoverBorderBrush(ComboBox comboBox)
        {
            return (Brush)comboBox.GetValue(ItemsHoverBorderBrushProperty);
        }

        public static void SetItemsHoverBorderBrush(ComboBox comboBox, Brush value)
        {
            comboBox.SetValue(ItemsHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsHoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemsHoverBorderBrush", typeof(Brush), typeof(ComboBoxHelper));

        public static Brush GetItemHoverBorderBrush(ComboBoxItem comboBoxItem)
        {
            return (Brush)comboBoxItem.GetValue(ItemHoverBorderBrushProperty);
        }

        public static void SetItemHoverBorderBrush(ComboBoxItem comboBoxItem, Brush value)
        {
            comboBoxItem.SetValue(ItemHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemHoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemHoverBorderBrush", typeof(Brush), typeof(ComboBoxHelper));
        #endregion

        #region ItemSelectedBackground
        public static Brush GetItemsSelectedBackground(ComboBox comboBox)
        {
            return (Brush)comboBox.GetValue(ItemsSelectedBackgroundProperty);
        }

        public static void SetItemsSelectedBackground(ComboBox comboBox, Brush value)
        {
            comboBox.SetValue(ItemsSelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedBackground", typeof(Brush), typeof(ComboBoxHelper));

        public static Brush GetItemSelectedBackground(ComboBoxItem comboBoxItem)
        {
            return (Brush)comboBoxItem.GetValue(ItemSelectedBackgroundProperty);
        }

        public static void SetItemSelectedBackground(ComboBoxItem comboBoxItem, Brush value)
        {
            comboBoxItem.SetValue(ItemSelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedBackgroundProperty =
            DependencyProperty.RegisterAttached("ItemSelectedBackground", typeof(Brush), typeof(ComboBoxHelper));
        #endregion

        #region ItemSelectedForeground
        public static Brush GetItemsSelectedForeground(ComboBox comboBox)
        {
            return (Brush)comboBox.GetValue(ItemsSelectedForegroundProperty);
        }

        public static void SetItemsSelectedForeground(ComboBox comboBox, Brush value)
        {
            comboBox.SetValue(ItemsSelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedForegroundProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedForeground", typeof(Brush), typeof(ComboBoxHelper));


        public static Brush GetItemSelectedForeground(ComboBoxItem comboBoxItem)
        {
            return (Brush)comboBoxItem.GetValue(ItemSelectedForegroundProperty);
        }

        public static void SetItemSelectedForeground(ComboBoxItem comboBoxItem, Brush value)
        {
            comboBoxItem.SetValue(ItemSelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedForegroundProperty =
            DependencyProperty.RegisterAttached("ItemSelectedForeground", typeof(Brush), typeof(ComboBoxHelper));


        #endregion

        #region ItemSelectedBorderBrush
        public static Brush GetItemsSelectedBorderBrush(ComboBox comboBox)
        {
            return (Brush)comboBox.GetValue(ItemsSelectedBorderBrushProperty);
        }

        public static void SetItemsSelectedBorderBrush(ComboBox comboBox, Brush value)
        {
            comboBox.SetValue(ItemsSelectedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemsSelectedBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemsSelectedBorderBrush", typeof(Brush), typeof(ComboBoxHelper));

        public static Brush GetItemSelectedBorderBrush(ComboBoxItem comboBoxItem)
        {
            return (Brush)comboBoxItem.GetValue(ItemSelectedBorderBrushProperty);
        }

        public static void SetItemSelectedBorderBrush(ComboBoxItem comboBoxItem, Brush value)
        {
            comboBoxItem.SetValue(ItemSelectedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemSelectedBorderBrushProperty =
            DependencyProperty.RegisterAttached("ItemSelectedBorderBrush", typeof(Brush), typeof(ComboBoxHelper));
        #endregion

        #region Icon


        public static object GetIcon(ComboBox comboBox)
        {
            return (object)comboBox.GetValue(IconProperty);
        }

        public static void SetIcon(ComboBox comboBox, object value)
        {
            comboBox.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(ComboBoxHelper));


        #endregion

        #region Watermark

        public static string GetWatermark(ComboBox comboBox)
        {
            return (string)comboBox.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(ComboBox comboBox, string value)
        {
            comboBox.SetValue(WatermarkProperty, value);
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(ComboBoxHelper));


        #endregion

        #region CornerRadius


        public static CornerRadius GetCornerRadius(ComboBox comboBox)
        {
            return (CornerRadius)comboBox.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(ComboBox comboBox, CornerRadius value)
        {
            comboBox.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ComboBoxHelper));


        #endregion

        #region DropDownCornerRadius


        public static CornerRadius GetDropDownCornerRadius(ComboBox comboBox)
        {
            return (CornerRadius)comboBox.GetValue(DropDownCornerRadiusProperty);
        }

        public static void SetDropDownCornerRadius(ComboBox comboBox, CornerRadius value)
        {
            comboBox.SetValue(DropDownCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty DropDownCornerRadiusProperty =
            DependencyProperty.RegisterAttached("DropDownCornerRadius", typeof(CornerRadius), typeof(ComboBoxHelper));


        #endregion

        #region DropDownPadding


        public static Thickness GetDropDownPadding(ComboBox comboBox)
        {
            return (Thickness)comboBox.GetValue(DropDownPaddingProperty);
        }

        public static void SetDropDownPadding(ComboBox comboBox, Thickness value)
        {
            comboBox.SetValue(DropDownPaddingProperty, value);
        }

        public static readonly DependencyProperty DropDownPaddingProperty =
            DependencyProperty.RegisterAttached("DropDownPadding", typeof(Thickness), typeof(ComboBoxHelper));


        #endregion

        #region DropDownShadowColor


        public static Color? GetDropDownShadowColor(ComboBox comboBox)
        {
            return (Color?)comboBox.GetValue(DropDownShadowColorProperty);
        }

        public static void SetDropDownShadowColor(ComboBox comboBox, Color? value)
        {
            comboBox.SetValue(DropDownShadowColorProperty, value);
        }

        public static readonly DependencyProperty DropDownShadowColorProperty =
            DependencyProperty.RegisterAttached("DropDownShadowColor", typeof(Color?), typeof(ComboBoxHelper));


        #endregion

        #region BindToEnum


        public static Enum GetBindToEnum(ComboBox comboBox)
        {
            return (Enum)comboBox.GetValue(BindToEnumProperty);
        }

        public static void SetBindToEnum(ComboBox comboBox, Enum value)
        {
            comboBox.SetValue(BindToEnumProperty, value);
        }

        public static readonly DependencyProperty BindToEnumProperty =
            DependencyProperty.RegisterAttached("BindToEnum", typeof(Enum), typeof(ComboBoxHelper), new PropertyMetadata(OnBindToEnumChanged));

        #endregion

        #region BindToNumberRange
        public static NumberRange GetBindToNumberRange(ComboBox comboBox)
        {
            return (NumberRange)comboBox.GetValue(BindToNumberRangeProperty);
        }

        public static void SetBindToNumberRange(ComboBox comboBox, NumberRange value)
        {
            comboBox.SetValue(BindToNumberRangeProperty, value);
        }

        public static readonly DependencyProperty BindToNumberRangeProperty =
            DependencyProperty.RegisterAttached("BindToNumberRange", typeof(NumberRange), typeof(ComboBoxHelper), new PropertyMetadata(OnNumberRangeChanged));

        #endregion

        #endregion

        #region Commands
        public static readonly DependencyProperty RemoveCommandProperty =
            DependencyProperty.RegisterAttached("RemoveCommand", typeof(ICommand), typeof(ComboBoxHelper), new PropertyMetadata(new RelayCommand(OnRemoveCommandExecute)));
        #endregion

        #region Event Handler

        private static void OnNumberRangeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var comboBox = d as ComboBox;
            var numberRange = e.NewValue as NumberRange;
            if(numberRange == null)
            {
                comboBox.ItemsSource = null;
                return;
            }
            if((numberRange.Maximum % 1) == 0 && (numberRange.Minimum % 1) == 0 && (numberRange.Interval % 1) == 0)
            {
                var dataList = new List<int>();
                var max = (int)numberRange.Maximum;
                var min = (int)numberRange.Minimum;
                var interval = (int)numberRange.Interval;
                for(var i = min; i <= max; i += interval)
                {
                    dataList.Add(i);
                }
                comboBox.ItemsSource = dataList;
                comboBox.SelectedValuePath = ".";
            }
            else
            {
                var dataList = new List<double>();
                var max = numberRange.Maximum;
                var min = numberRange.Minimum;
                var interval = numberRange.Interval;
                for (var i = min; i <= max; i += interval)
                {
                    dataList.Add(i);
                }
                comboBox.ItemsSource = dataList;
                comboBox.SelectedValuePath = ".";
            }
        }

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

            StoryboardUtils.BeginBrushStoryboard(button, dic);
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

            StoryboardUtils.BeginBrushStoryboard(button, list);
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

            var type = e.NewValue?.GetType();

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
                comboBox.SelectedValue = comboBox.SelectedValue ?? e.NewValue;
            }
        }

        #endregion
    }

}
