using Panuon.UI.Silver.Internal.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
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

        #region IsSelectedMemberPath
        public string IsSelectedMemberPath
        {
            get { return (string)GetValue(IsSelectedMemberPathProperty); }
            set { SetValue(IsSelectedMemberPathProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedMemberPathProperty =
            DependencyProperty.Register("IsSelectedMemberPath", typeof(string), typeof(RadioButtonGroup));
        #endregion

        #endregion

        #region Overrides
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var radioButton = element as RadioButton;
            if (radioButton != null)
            {
                if (!(item is RadioButton))
                {
                    if (string.IsNullOrEmpty(radioButton.GroupName))
                    {
                        radioButton.GroupName = _groupName;
                    }
                    var displayNameBinding = new Binding()
                    {
                        Path = new PropertyPath(DisplayMemberPath),
                        Source = item,
                    };
                    radioButton.SetBinding(RadioButton.ContentProperty, displayNameBinding);
                    var isSelectedBinding = new Binding()
                    {
                        Path = new PropertyPath(IsSelectedMemberPath),
                        Source = item,
                        Mode = BindingMode.TwoWay,
                    };
                    radioButton.SetBinding(RadioButton.IsCheckedProperty, isSelectedBinding);
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
            if (e.AddedItems.Count == 0 && e.RemovedItems.Count > 0)
            {
                return;
            }
            
            foreach(var item in e.AddedItems)
            {
                if(item is RadioButton)
                {
                    (item as RadioButton).IsChecked = true;
                }
                else if(!string.IsNullOrEmpty(IsSelectedMemberPath))
                {
                    var selectedPropertyInfo = item.GetType().GetProperty(IsSelectedMemberPath);
                    if(selectedPropertyInfo != null)
                    {
                        selectedPropertyInfo.SetValue(item, true, null);
                    }
                }
            }
            base.OnSelectionChanged(e);
        }

        #endregion

        #region Event Handler
        private static void OnBindToEnumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var radioButtonGroup = d as RadioButtonGroup;

            var type = e.NewValue.GetType();

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
                            enumList.Add(new RadioButtonGroupItem
                            {
                                Name = descriptions[0].Description,
                                Enum = item,
                                IsSelected = true,
                            });
                        }
                        else
                            enumList.Add(new RadioButtonGroupItem
                            {
                                Name = item.ToString(),
                                Enum = item,
                                IsSelected = false,
                            });
                    }
                }
                radioButtonGroup.ItemsSource = enumList;
                radioButtonGroup.DisplayMemberPath = "Name";
                radioButtonGroup.SelectedValuePath = "Enum";
                radioButtonGroup.IsSelectedMemberPath = "IsSelected";
                radioButtonGroup.SelectedValue = radioButtonGroup.SelectedValue ?? e.NewValue;
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
