using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Panuon.UI.Silver
{
    [ContentProperty(nameof(Items))]
    public class Form : Control
    {
        #region Ctor
        static Form()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Form), new FrameworkPropertyMetadata(typeof(Form)));
        }

        public Form()
        {
            Items = new ObservableCollection<IFormItem>();
        }
        #endregion

        #region Properties

        #region ItemsHeight
        public double ItemsHeight
        {
            get { return (double)GetValue(ItemsHeightProperty); }
            set { SetValue(ItemsHeightProperty, value); }
        }

        public static readonly DependencyProperty ItemsHeightProperty =
            DependencyProperty.Register("ItemsHeight", typeof(double), typeof(Form));
        #endregion

        #region ItemsHeaderHeight
        public string ItemsHeaderHeight
        {
            get { return (string)GetValue(ItemsHeaderHeightProperty); }
            set { SetValue(ItemsHeaderHeightProperty, value); }
        }

        public static readonly DependencyProperty ItemsHeaderHeightProperty =
            DependencyProperty.Register("ItemsHeaderHeight", typeof(string), typeof(Form));
        #endregion

        #region ItemsHeaderWidth
        public string ItemsHeaderWidth
        {
            get { return (string)GetValue(ItemsHeaderWidthProperty); }
            set { SetValue(ItemsHeaderWidthProperty, value); }
        }

        public static readonly DependencyProperty ItemsHeaderWidthProperty =
            DependencyProperty.Register("ItemsHeaderWidth", typeof(string), typeof(Form));
        #endregion

        #region ItemsPadding
        public Thickness ItemsPadding
        {
            get { return (Thickness)GetValue(ItemsPaddingProperty); }
            set { SetValue(ItemsPaddingProperty, value); }
        }

        public static readonly DependencyProperty ItemsPaddingProperty =
            DependencyProperty.Register("ItemsPadding", typeof(Thickness), typeof(Form));
        #endregion

        #region Spacing
        public double Spacing
        {
            get { return (double)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }

        public static readonly DependencyProperty SpacingProperty =
            DependencyProperty.Register("Spacing", typeof(double), typeof(Form));
        #endregion

        #region Items
        public ObservableCollection<IFormItem> Items
        {
            get { return (ObservableCollection<IFormItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ObservableCollection<IFormItem>), typeof(Form));
        #endregion

        #region 
        #endregion

        #endregion
    }
}
