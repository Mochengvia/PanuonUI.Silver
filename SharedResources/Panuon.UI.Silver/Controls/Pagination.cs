using Panuon.UI.Silver.Core;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Panuon.UI.Silver
{
    public class Pagination : Control
    {
        #region Ctor
        static Pagination()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Pagination), new FrameworkPropertyMetadata(typeof(Pagination)));
        }

        public Pagination()
        {
            AddHandler(RadioButton.ClickEvent, new RoutedEventHandler(OnClicked));
            IndexList = new ObservableCollection<int?>();
        }
        #endregion

        #region Properties

        #region ItemContainerStyle
        public Style ItemContainerStyle
        {
            get { return (Style)GetValue(ItemContainerStyleProperty); }
            set { SetValue(ItemContainerStyleProperty, value); }
        }

        public static readonly DependencyProperty ItemContainerStyleProperty =
            DependencyProperty.Register("ItemContainerStyle", typeof(Style), typeof(Pagination));
        #endregion

        #region SideRepeatButtonStyle
        public Style SideRepeatButtonStyle
        {
            get { return (Style)GetValue(SideRepeatButtonStyleProperty); }
            set { SetValue(SideRepeatButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty SideRepeatButtonStyleProperty =
            DependencyProperty.Register("SideRepeatButtonStyle", typeof(Style), typeof(Pagination));
        #endregion

        #region OmitTextBlockStyle
        public Style OmitTextBlockStyle
        {
            get { return (Style)GetValue(OmitTextBlockStyleProperty); }
            set { SetValue(OmitTextBlockStyleProperty, value); }
        }

        public static readonly DependencyProperty OmitTextBlockStyleProperty =
            DependencyProperty.Register("OmitTextBlockStyle", typeof(Style), typeof(Pagination));
        #endregion

        #region CurrentIndex
        public int CurrentIndex
        {
            get { return (int)GetValue(CurrentIndexProperty); }
            set { SetValue(CurrentIndexProperty, value); }
        }

        public static readonly DependencyProperty CurrentIndexProperty =
            DependencyProperty.Register("CurrentIndex", typeof(int), typeof(Pagination), new PropertyMetadata(1, OnCurrentIndexChanged, OnCurrentIndexCoerceValue));


        #endregion

        #region TotalIndex
        public int TotalIndex
        {
            get { return (int)GetValue(TotalIndexProperty); }
            set { SetValue(TotalIndexProperty, value); }
        }

        public static readonly DependencyProperty TotalIndexProperty =
            DependencyProperty.Register("TotalIndex", typeof(int), typeof(Pagination), new PropertyMetadata(1, OnTotalIndexChanged, OnTotalIndexCoerceValue));
        #endregion

        #region Spacing
        public double Spacing
        {
            get { return (double)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }

        public static readonly DependencyProperty SpacingProperty =
            DependencyProperty.Register("Spacing", typeof(double), typeof(Pagination));
        #endregion

        #endregion

        #region Internal Properties
        internal ObservableCollection<int?> IndexList
        {
            get { return (ObservableCollection<int?>)GetValue(IndexListProperty); }
            set { SetValue(IndexListProperty, value); }
        }

        internal static readonly DependencyProperty IndexListProperty =
            DependencyProperty.Register("IndexList", typeof(ObservableCollection<int?>), typeof(Pagination));
        #endregion

        #region Commands
        
        internal static readonly DependencyProperty PreviousCommandProperty =
            DependencyProperty.Register("PreviousCommand", typeof(ICommand), typeof(Pagination), new PropertyMetadata(new RelayCommand(OnPreviousCommandExecute)));

        internal static readonly DependencyProperty NextCommandProperty =
            DependencyProperty.Register("NextCommand", typeof(ICommand), typeof(Pagination), new PropertyMetadata(new RelayCommand(OnNextCommandExecute)));
        #endregion

        #region Event Handler

        private void OnClicked(object sender, RoutedEventArgs e)
        {
            var radioButton = e.OriginalSource as RadioButton;
            if (radioButton == null)
            {
                return;
            }
            CurrentIndex = (int)radioButton.Content;
        }

        private static object OnTotalIndexCoerceValue(DependencyObject d, object baseValue)
        {
            var result = (int)baseValue;
            if (result <= 0)
            {
                result = 1;
            }
            return result;
        }

        private static void OnTotalIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pagination = d as Pagination;
            pagination.CoerceValue(CurrentIndexProperty);
            pagination.UpdateIndexList();
        }

        private static object OnCurrentIndexCoerceValue(DependencyObject d, object baseValue)
        {
            var result = (int)baseValue;
            var pagination = d as Pagination;
            if (result <= 0)
            {
                result = 1;
            }
            else if (result > pagination.TotalIndex)
            {
                result = pagination.TotalIndex;
            }
            return result;
        }

        private static void OnCurrentIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pagination = d as Pagination;
            pagination.UpdateIndexList();
        }

        private static void OnPreviousCommandExecute(object obj)
        {
            var pagination = (obj as Pagination);
            pagination.CurrentIndex--;
        }

        private static void OnNextCommandExecute(object obj)
        {
            var pagination = (obj as Pagination);
            pagination.CurrentIndex++;
        }

        #endregion

        #region Function
        private void UpdateIndexList()
        {
            IndexList.Clear();

            if (TotalIndex <= 7)
            {
                for (var i = 1; i <= TotalIndex; i++)
                {
                    IndexList.Add(i);
                }
            }
            else
            {
                IndexList.Add(1);
                IndexList.Add(2);


                if (CurrentIndex == 1 || CurrentIndex == 2 || CurrentIndex == 3 || CurrentIndex == 4)
                {
                    IndexList.Add(3);
                    IndexList.Add(4);
                    IndexList.Add(5);
                }

                IndexList.Add(null);

                if (CurrentIndex >= TotalIndex - 3)
                {
                    IndexList.Add(null);

                    for (var i = TotalIndex - 4; i <= TotalIndex; i++)
                    {
                        IndexList.Add(i);
                    }
                    return;
                }
                if (CurrentIndex != 1 && CurrentIndex != 2 && CurrentIndex != 3 && CurrentIndex != 4)
                {
                    for (var i = CurrentIndex - 1; i <= (CurrentIndex + 1); i++)
                    {
                        IndexList.Add(i);
                    }
                }
                IndexList.Add(null);
                for (var i = TotalIndex - 1; i <= TotalIndex; i++)
                {
                    IndexList.Add(i);
                }
            }
        }
        #endregion
    }
}
