using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver
{
    public class IndexIndicator : Control
    {
        #region Ctor
        public IndexIndicator()
        {
            AddHandler(RadioButton.ClickEvent, new RoutedEventHandler(OnClicked));
            IndexList = new ObservableCollection<int>();
        }

        #endregion

        #region Properties

        #region Orientation


        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(IndexIndicator));
        #endregion

        #region CurrentIndex
        public int CurrentIndex
        {
            get { return (int)GetValue(CurrentIndexProperty); }
            set { SetValue(CurrentIndexProperty, value); }
        }

        public static readonly DependencyProperty CurrentIndexProperty =
            DependencyProperty.Register("CurrentIndex", typeof(int), typeof(IndexIndicator));


        #endregion

        #region TotalIndex
        public int TotalIndex
        {
            get { return (int)GetValue(TotalIndexProperty); }
            set { SetValue(TotalIndexProperty, value); }
        }

        public static readonly DependencyProperty TotalIndexProperty =
            DependencyProperty.Register("TotalIndex", typeof(int), typeof(IndexIndicator), new PropertyMetadata(OnTotalIndexChanged));

        
        #endregion

        #region IndexIndicatorItemStyle
        public Style IndexIndicatorItemStyle
        {
            get { return (Style)GetValue(IndexIndicatorItemStyleProperty); }
            set { SetValue(IndexIndicatorItemStyleProperty, value); }
        }

        public static readonly DependencyProperty IndexIndicatorItemStyleProperty =
            DependencyProperty.Register("IndexIndicatorItemStyle", typeof(Style), typeof(IndexIndicator));
        #endregion

        #endregion

        #region Internal Properties
        internal ObservableCollection<int> IndexList
        {
            get { return (ObservableCollection<int>)GetValue(IndexListProperty); }
            set { SetValue(IndexListProperty, value); }
        }

        internal static readonly DependencyProperty IndexListProperty =
            DependencyProperty.Register("IndexList", typeof(ObservableCollection<int>), typeof(IndexIndicator));
        #endregion

        #region Event Handler
        private void OnClicked(object sender, RoutedEventArgs e)
        {
            var radioButton = e.OriginalSource as RadioButton;
            if (radioButton == null)
            {
                return;
            }
            CurrentIndex = (int)radioButton.Tag;
        }

        private static void OnTotalIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var indicator = d as IndexIndicator;
            indicator.UpdateIndexList();
        }
        #endregion

        #region Methods
        #endregion

        #region Function
        private void UpdateIndexList()
        {
            IndexList.Clear();

            for(int i = 1; i <= TotalIndex; i++)
            {
                IndexList.Add(i);
            }
        }
        #endregion

    }
}
