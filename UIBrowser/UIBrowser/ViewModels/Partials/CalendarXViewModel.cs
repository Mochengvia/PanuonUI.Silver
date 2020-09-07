using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using UIBrowser.Core;
using UIBrowser.Core.Properties;

namespace UIBrowser.ViewModels.Partials
{
    public class CalendarXViewModel : ViewModelBase, IPaletteView
    {
        #region Properties
        public string Caption => Resources.CalendarX;

        public string[] LabelLevels => new string[] { Resources.CustomControls };

        public IDictionary<string, DependencyProperty> PaletteProperties => new Dictionary<string, DependencyProperty>
        {

        };

        public IList<DependencyProperty> GeneralProperties => new List<DependencyProperty>
        {
        };

        #region SelectedDates
        public ObservableCollection<DateTime> SelectedDates { get => _selectedDates; set => Set(ref _selectedDates, value); }
        private ObservableCollection<DateTime> _selectedDates;
        #endregion 

        #region SelectedDate
        public DateTime? SelectedDate { get => _selectedDate; set => Set(ref _selectedDate, value); }
        private DateTime? _selectedDate;
        #endregion 

        #endregion

        #region Methods
        public void Test()
        {
            SelectedDates = new ObservableCollection<DateTime>()
            {
                DateTime.Now.Date,
                DateTime.Now.Date.AddDays(5),
                DateTime.Now.Date.AddDays(-5),
            };
            SelectedDate = DateTime.Now.Date;
        }
        #endregion

        #region Event Handlers
        public void OnSelectedDatesChanged(Panuon.UI.Silver.Core.SelectedDatesChangedRoutedEventArgs e)
        {
            var dates = e.SelectedDates;
        }
        #endregion

    }
}
