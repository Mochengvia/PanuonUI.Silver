using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace Panuon.UI.Silver
{
    public class RadioButtonGroup : Selector
    {
        #region Fields
        private string _groupName;
        #endregion

        #region Ctor
        static RadioButtonGroup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RadioButtonGroup), new FrameworkPropertyMetadata(typeof(RadioButtonGroup)));
        }

        public RadioButtonGroup()
        {
            _groupName = Guid.NewGuid().ToString();
            AddHandler(RadioButton.CheckedEvent, new RoutedEventHandler(OnRadioButtonChecked));
            AddHandler(RadioButton.UncheckedEvent, new RoutedEventHandler(OnRadioButtonUnchecked));
        }

        #endregion

        #region Properties

        #region BindToEnum
        public Enum BindToEnum
        {
            get { return (Enum)GetValue(BindToEnumProperty); }
            set { SetValue(BindToEnumProperty, value); }
        }

        public static readonly DependencyProperty BindToEnumProperty =
            DependencyProperty.Register("BindToEnum", typeof(Enum), typeof(RadioButtonGroup), new PropertyMetadata(OnBindToEnumChanged));

        #endregion

        #endregion

        #region Overrides

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var radioButton = element as RadioButton;
            if (radioButton != null)
            {
                if(!(item is RadioButton))
                {
                    var binding = new Binding()
                    {
                        Path = new PropertyPath(DisplayMemberPath),
                        Source = item,
                    };
                    radioButton.SetBinding(RadioButton.ContentProperty, binding);
                }
                if (string.IsNullOrEmpty(radioButton.GroupName))
                {
                    radioButton.GroupName = _groupName;
                }
            }
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new RadioButton();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is RadioButton;
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count == 0 && e.RemovedItems.Count > 0)
            {
                return;
            }
            base.OnSelectionChanged(e);
        }
        #endregion

        #region Event Handler
        private static void OnBindToEnumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var radioButtonGroup = d as RadioButtonGroup;
            var selectedValue = radioButtonGroup.SelectedValue ?? e.NewValue as object;
            if (selectedValue == null)
                return;

            var type = selectedValue.GetType();
            if (!type.IsEnum)
                throw new Exception($"\"{type.FullName}\" is not an enumeration type.");

            if (type == null)
            {
                radioButtonGroup.ItemsSource = null;
                radioButtonGroup.SelectedItem = null;
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
                radioButtonGroup.ItemsSource = enumList;
                radioButtonGroup.DisplayMemberPath = "Name";
                radioButtonGroup.SelectedValuePath = "Enum";
                radioButtonGroup.SelectedValue = selectedValue;
            }
        }

        private void OnRadioButtonUnchecked(object sender, RoutedEventArgs e)
        {
            var radioButton = e.OriginalSource as RadioButton;
            if (radioButton.GroupName == _groupName)
            {
                radioButton.RaiseEvent(new RoutedEventArgs(Selector.UnselectedEvent, radioButton));
            }
        }

        private void OnRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            var radioButton = e.OriginalSource as RadioButton;
            if (radioButton.GroupName == _groupName)
            {
                radioButton.RaiseEvent(new RoutedEventArgs(Selector.SelectedEvent, radioButton));
            }
        }
        #endregion
    }
}
