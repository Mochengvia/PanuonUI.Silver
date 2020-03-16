using System;
using System.Collections.Generic;
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
