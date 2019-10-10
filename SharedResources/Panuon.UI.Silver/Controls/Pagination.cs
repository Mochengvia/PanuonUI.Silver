using Panuon.UI.Silver.Core;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class Pagination : Control
    {
        static Pagination()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Pagination), new FrameworkPropertyMetadata(typeof(Pagination)));
        }

        public Pagination()
        {
            if (TotalIndex == 0)
                TotalIndex = 1;
            if (CurrentIndex == 0)
                CurrentIndex = 1;
        }

        #region Routed Event
        public static readonly RoutedEvent CurrentIndexChangedEvent = EventManager.RegisterRoutedEvent("CurrentIndexChanged", RoutingStrategy.Bubble, typeof(CurrentIndexChangedEventHandler), typeof(Pagination));
        public event CurrentIndexChangedEventHandler CurrentIndexChanged
        {
            add { AddHandler(CurrentIndexChangedEvent, value); }
            remove { RemoveHandler(CurrentIndexChangedEvent, value); }
        }
        void RaiseCurrentIndexChanged(int index)
        {
            var arg = new CurrentIndexChangedEventArgs(index, CurrentIndexChangedEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region Property
        /// <summary>
        /// Current index.
        /// </summary>
        public int CurrentIndex
        {
            get { return (int)GetValue(CurrentIndexProperty); }
            set { SetValue(CurrentIndexProperty, value); }
        }

        public static readonly DependencyProperty CurrentIndexProperty =
            DependencyProperty.Register("CurrentIndex", typeof(int), typeof(Pagination), new PropertyMetadata(OnCurrentIndexChanged));


        /// <summary>
        /// Total index.
        /// </summary>
        public int TotalIndex
        {
            get { return (int)GetValue(TotalIndexProperty); }
            set { SetValue(TotalIndexProperty, value); }
        }

        public static readonly DependencyProperty TotalIndexProperty =
            DependencyProperty.Register("TotalIndex", typeof(int), typeof(Pagination), new PropertyMetadata(OnTotalIndexChanged));


        /// <summary>
        /// Theme brush.
        /// </summary>
        public Brush HoverBrush
        {
            get { return (Brush)GetValue(HoverBrushProperty); }
            set { SetValue(HoverBrushProperty, value); }
        }

        public static readonly DependencyProperty HoverBrushProperty =
            DependencyProperty.Register("HoverBrush", typeof(Brush), typeof(Pagination));

        /// <summary>
        /// Pagination style.
        /// </summary>
        public PaginationStyle PaginationStyle
        {
            get { return (PaginationStyle)GetValue(PaginationStyleProperty); }
            set { SetValue(PaginationStyleProperty, value); }
        }

        public static readonly DependencyProperty PaginationStyleProperty =
            DependencyProperty.Register("PaginationStyle", typeof(PaginationStyle), typeof(Pagination), new PropertyMetadata(PaginationStyle.Standard));

        /// <summary>
        /// Spacing
        /// </summary>
        public double Spacing
        {
            get { return (double)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }

        public static readonly DependencyProperty SpacingProperty =
            DependencyProperty.Register("Spacing", typeof(double), typeof(Pagination));


        /// <summary>
        /// CornerRadius
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Pagination));
        #endregion

        #region Internal Property
        internal ObservableCollection<PaginationItem> PaginationItems
        {
            get { return (ObservableCollection<PaginationItem>)GetValue(PaginationItemsProperty); }
            set { SetValue(PaginationItemsProperty, value); }
        }

        internal static readonly DependencyProperty PaginationItemsProperty =
            DependencyProperty.Register("PaginationItems", typeof(ObservableCollection<PaginationItem>), typeof(Pagination));

        internal ICommand PreviousCommand
        {
            get { return (ICommand)GetValue(PreviousCommandProperty); }
            set { SetValue(PreviousCommandProperty, value); }
        }

        internal static readonly DependencyProperty PreviousCommandProperty =
            DependencyProperty.Register("PreviousCommand", typeof(ICommand), typeof(Pagination), new PropertyMetadata(new PreviousCommand()));



        internal ICommand NextCommand
        {
            get { return (ICommand)GetValue(NextCommandProperty); }
            set { SetValue(NextCommandProperty, value); }
        }

        internal static readonly DependencyProperty NextCommandProperty =
            DependencyProperty.Register("NextCommand", typeof(ICommand), typeof(Pagination), new PropertyMetadata(new NextCommand()));



        internal ICommand IndexCommand
        {
            get { return (ICommand)GetValue(IndexCommandProperty); }
            set { SetValue(IndexCommandProperty, value); }
        }

        internal static readonly DependencyProperty IndexCommandProperty =
            DependencyProperty.Register("IndexCommand", typeof(ICommand), typeof(Pagination), new PropertyMetadata(new IndexCommand()));


        #endregion

        #region EventHandler
        private static void OnCurrentIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pagination = d as Pagination;

            if (pagination.CurrentIndex > pagination.TotalIndex)
            {
                pagination.CurrentIndex = pagination.TotalIndex;
                return;
            }
            else if (pagination.CurrentIndex < 1)
            {
                pagination.CurrentIndex = 1;
                return;
            }

            pagination.UpdatePaginationItems();
            pagination.RaiseCurrentIndexChanged(pagination.CurrentIndex);
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
            }

            pagination.UpdatePaginationItems();
        }
        #endregion

        #region Function
        private void UpdatePaginationItems()
        {
            if (PaginationItems == null)
                PaginationItems = new ObservableCollection<PaginationItem>();

            PaginationItems.Clear();

            if (TotalIndex <= 7)
            {
                for (var i = 1; i <= TotalIndex; i++)
                {
                    PaginationItems.Add(new PaginationItem(i, CurrentIndex == i));
                }
            }
            else
            {
                PaginationItems.Add(new PaginationItem(1, CurrentIndex == 1));
                PaginationItems.Add(new PaginationItem(2, CurrentIndex == 2));


                if (CurrentIndex == 1 || CurrentIndex == 2 || CurrentIndex == 3 || CurrentIndex == 4)
                {
                    PaginationItems.Add(new PaginationItem(3, CurrentIndex == 3));
                    PaginationItems.Add(new PaginationItem(4, CurrentIndex == 4));
                    PaginationItems.Add(new PaginationItem(5, CurrentIndex == 5));
                }

                PaginationItems.Add(new PaginationItem(null));

                if (CurrentIndex >= TotalIndex - 3)
                {
                    PaginationItems.Add(new PaginationItem(null));

                    for (var i = TotalIndex - 4; i <= TotalIndex; i++)
                    {
                        PaginationItems.Add(new PaginationItem(i, CurrentIndex == i));
                    }
                    return;
                }
                if (CurrentIndex != 1 && CurrentIndex != 2 && CurrentIndex != 3 && CurrentIndex != 4)
                {
                    for (var i = CurrentIndex - 1; i <= (CurrentIndex + 1); i++)
                    {
                        PaginationItems.Add(new PaginationItem(i, CurrentIndex == i));
                    }
                }
                PaginationItems.Add(new PaginationItem(null));
                for (var i = TotalIndex - 1; i <= TotalIndex; i++)
                {
                    PaginationItems.Add(new PaginationItem(i, CurrentIndex == i));
                }
            }
        }
        #endregion
    }

    internal class PaginationItem
    {
        public PaginationItem(int? value)
        {
            Value = value;
        }

        public PaginationItem(int? value, bool isSelected)
        {
            Value = value;
            IsSelected = isSelected;
        }

        public int? Value { get; set; }

        public bool IsSelected { get; set; }
    }

    internal class PreviousCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var pagination = (parameter as Pagination);

            if (pagination.CurrentIndex - 1 < 0)
                return;

            pagination.CurrentIndex--;
        }
    }

    internal class NextCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var pagination = (parameter as Pagination);

            if (pagination.CurrentIndex + 1 > pagination.TotalIndex)
                return;

            pagination.CurrentIndex++;
        }
    }

    internal class IndexCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var objs = parameter as object[];

            var pagination = objs[0] as Pagination;
            var index = (int)objs[1];


            pagination.CurrentIndex = index;
        }
    }

    
}
