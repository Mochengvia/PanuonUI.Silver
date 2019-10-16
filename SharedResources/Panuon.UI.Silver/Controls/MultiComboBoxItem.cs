using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver
{
    public class MultiComboBoxItem : ListBoxItem
    {
        static MultiComboBoxItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MultiComboBoxItem), new FrameworkPropertyMetadata(typeof(MultiComboBoxItem)));
        }

        #region Event 
       
        #endregion

        #region Property
        public Style CheckBoxStyle
        {
            get { return (Style)GetValue(CheckBoxStyleProperty); }
            set { SetValue(CheckBoxStyleProperty, value); }
        }

        public static readonly DependencyProperty CheckBoxStyleProperty =
            DependencyProperty.Register("CheckBoxStyle", typeof(Style), typeof(MultiComboBoxItem));


        #endregion
    }
}
