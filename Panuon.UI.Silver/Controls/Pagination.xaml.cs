using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Panuon.UI.Silver
{
    /// <summary>
    /// Pagination.xaml 的交互逻辑
    /// </summary>
    public partial class Pagination : ContentControl
    {
        public Pagination()
        {
            InitializeComponent();
            GroupId = Guid.NewGuid().ToString();
            IndexItems = new ObservableCollection<PaginationItem>();
        }

        #region Routed Event
        public static readonly RoutedEvent CurrentIndexChangedEvent = EventManager.RegisterRoutedEvent("CurrentIndexChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Pagination));
        public event RoutedEventHandler CurrentIndexChanged
        {
            add { AddHandler(CurrentIndexChangedEvent, value); }
            remove { RemoveHandler(CurrentIndexChangedEvent, value); }
        }

        void RaiseCurrentIndexChanged()
        {
            var arg = new RoutedEventArgs(CurrentIndexChangedEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region Property
        public int CurrentIndex
        {
            get { return (int)GetValue(CurrentIndexProperty); }
            set { SetValue(CurrentIndexProperty, value); }
        }

        public static readonly DependencyProperty CurrentIndexProperty =
            DependencyProperty.Register("CurrentIndex", typeof(int), typeof(Pagination), new PropertyMetadata(0, OnCurrentIndexChanged));

        public int TotalIndex
        {
            get { return (int)GetValue(TotalIndexProperty); }
            set { SetValue(TotalIndexProperty, value); }
        }

        public static readonly DependencyProperty TotalIndexProperty =
            DependencyProperty.Register("TotalIndex", typeof(int), typeof(Pagination), new PropertyMetadata(1, OnTotalIndexChanged));

        public Brush ThemeBrush
        {
            get { return (Brush)GetValue(ThemeBrushProperty); }
            set { SetValue(ThemeBrushProperty, value); }
        }

        public static readonly DependencyProperty ThemeBrushProperty =
            DependencyProperty.Register("ThemeBrush", typeof(Brush), typeof(Pagination), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3E3E3E"))));



        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Pagination), new PropertyMetadata(new CornerRadius(2)));


        #endregion

        #region Internal Property
        internal ObservableCollection<PaginationItem> IndexItems
        {
            get { return (ObservableCollection<PaginationItem>)GetValue(IndexItemsProperty); }
            set { SetValue(IndexItemsProperty, value); }
        }

        internal static readonly DependencyProperty IndexItemsProperty =
            DependencyProperty.Register("IndexItems", typeof(ObservableCollection<PaginationItem>), typeof(Pagination));



        public string GroupId
        {
            get { return (string)GetValue(GroupIdProperty); }
            set { SetValue(GroupIdProperty, value); }
        }

        public static readonly DependencyProperty GroupIdProperty =
            DependencyProperty.Register("GroupId", typeof(string), typeof(Pagination));


        #endregion

        #region Event
        private static void OnCurrentIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pagination = d as Pagination;
            if (pagination.CurrentIndex < 1)
            {
                pagination.CurrentIndex = 1;
                return;
            }
            if (pagination.CurrentIndex > pagination.TotalIndex)
            {
                pagination.CurrentIndex = pagination.TotalIndex;
                return;
            }
            if (e.NewValue != e.OldValue)
                pagination.RaiseCurrentIndexChanged();

            pagination.UpdateSelect();

        }

        private static void OnTotalIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pagination = d as Pagination;

            if (pagination.TotalIndex < 1)
            {
                pagination.TotalIndex = 1;
                return;
            }
            if (pagination.CurrentIndex > pagination.TotalIndex)
            {
                pagination.CurrentIndex = pagination.TotalIndex;
                return;
            }

            pagination.UpdateSelect();
        }

        private void RdbIndex_Click(object sender, RoutedEventArgs e)
        {
            var rdb = sender as RadioButton;
            if (rdb.Tag is int)
            {
                CurrentIndex = (int)rdb.Tag;
            }
        }
        #endregion

        #region Function
        private void UpdateSelect()
        {
            IndexItems.Clear();

            if (TotalIndex <= 7)
            {
                for (var i = 1; i <= TotalIndex; i++)
                {
                    IndexItems.Add(new PaginationItem(i, CurrentIndex));
                }
            }
            else
            {
                IndexItems.Add(new PaginationItem(1, CurrentIndex));
                IndexItems.Add(new PaginationItem(2, CurrentIndex));

                if (CurrentIndex == 1 || CurrentIndex == 2 || CurrentIndex == 3 || CurrentIndex == 4)
                {
                    IndexItems.Add(new PaginationItem(3, CurrentIndex));
                    IndexItems.Add(new PaginationItem(4, CurrentIndex));
                    IndexItems.Add(new PaginationItem(5, CurrentIndex));
                }

                IndexItems.Add(new PaginationItem(0, CurrentIndex, false));


                //距离终点小于4，直接追加直到末尾
                if (CurrentIndex >= TotalIndex - 3)
                {
                    IndexItems.Add(new PaginationItem(0, CurrentIndex, false));

                    for (var i = TotalIndex - 4; i <= TotalIndex; i++)
                    {
                        IndexItems.Add(new PaginationItem(i, CurrentIndex));
                    }
                    return;
                }
                if (CurrentIndex != 1 && CurrentIndex != 2 && CurrentIndex != 3 && CurrentIndex != 4)
                {
                    //追加三条
                    for (var i = CurrentIndex - 1; i <= (CurrentIndex + 1); i++)
                    {
                        IndexItems.Add(new PaginationItem(i, CurrentIndex));
                    }
                }
                IndexItems.Add(new PaginationItem(0, CurrentIndex, false));
                for (var i = TotalIndex - 1; i <= TotalIndex; i++)
                {
                    IndexItems.Add(new PaginationItem(i, CurrentIndex));
                }
            }
        }

        #endregion

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            CurrentIndex++;
        }

        private void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            CurrentIndex--;
        }
    }

    public class PaginationItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PaginationItem(int index, int currentIndex, bool isIndex = true)
        {
            Index = index;
            IsChecked = index == currentIndex;
            IsIndex = isIndex;
        }

        public int Index
        {
            get { return _index; }
            set { _index = value; NotifyPropertyChanged("Index"); }
        }
        private int _index;

        public bool IsIndex
        {
            get { return _isIndex; }
            set { _isIndex = value; NotifyPropertyChanged("IsIndex"); }
        }
        private bool _isIndex;

        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; NotifyPropertyChanged("IsChecked"); }
        }
        private bool _isChecked;
    }

}
