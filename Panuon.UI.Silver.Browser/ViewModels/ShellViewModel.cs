using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Panuon.UI.Silver.Browser.ViewModels
{
    public class ShellViewModel : INotifyPropertyChanged
    {
        public ShellViewModel()
        {
            SourceItems = new ObservableCollection<SourceItemModel>()
            {
                new SourceItemModel(){ Content = "Item 1",
                    Items = new ObservableCollection<SourceItemModel>()
                    {
                        new SourceItemModel(){ Content = "Item 1", },
                        new SourceItemModel(){ Content = "Item 2", },
                        new SourceItemModel(){ Content = "Item 3", },
                    }
                },
                new SourceItemModel(){ Content = "Item 2",
                    Items = new ObservableCollection<SourceItemModel>()
                    {
                        new SourceItemModel(){ Content = "Item 1", },
                        new SourceItemModel(){ Content = "Item 2", },
                        new SourceItemModel(){ Content = "Item 3", },
                    }
                },
                new SourceItemModel(){ Content = "Item 3",
                    Items = new ObservableCollection<SourceItemModel>()
                    {
                        new SourceItemModel(){ Content = "Item 1", },
                        new SourceItemModel(){ Content = "Item 2", },
                        new SourceItemModel(){ Content = "Item 3", },
                    }
                },
                new SourceItemModel(){ Content = "Item 4",
                    Items = new ObservableCollection<SourceItemModel>()
                    {
                        new SourceItemModel(){ Content = "Item 1", },
                        new SourceItemModel(){ Content = "Item 2", },
                        new SourceItemModel(){ Content = "Item 3", },
                    }
                },
                new SourceItemModel(){ Content = "Item 5",
                    Items = new ObservableCollection<SourceItemModel>()
                    {
                        new SourceItemModel(){ Content = "Item 1", },
                        new SourceItemModel(){ Content = "Item 2", },
                        new SourceItemModel(){ Content = "Item 3", },
                    }
                },
                new SourceItemModel(){ Content = "Item 6",
                    Items = new ObservableCollection<SourceItemModel>()
                    {
                        new SourceItemModel(){ Content = "Item 1", },
                        new SourceItemModel(){ Content = "Item 2", },
                        new SourceItemModel(){ Content = "Item 3", },
                    }
                },
                new SourceItemModel(){ Content = "Item 7",
                    Items = new ObservableCollection<SourceItemModel>()
                    {
                        new SourceItemModel(){ Content = "Item 1", },
                        new SourceItemModel(){ Content = "Item 2", },
                        new SourceItemModel(){ Content = "Item 3", },
                    }
                },
            };
            DataGridItems = new ObservableCollection<DataGridItemModel>()
            {
                new DataGridItemModel(){ Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"},
                new DataGridItemModel(){ Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"},
                new DataGridItemModel(){ Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"},
                new DataGridItemModel(){ Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"},
                new DataGridItemModel(){ Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"},
                new DataGridItemModel(){ Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"},
                new DataGridItemModel(){ Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"},
                new DataGridItemModel(){ Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"},
                new DataGridItemModel(){ Column1 = "Column1", Column2 = "Column2", Column3 = "Column3"},
            };
        }

        /// <summary>
        /// get or set multi selector items
        /// </summary>
        public ObservableCollection<SourceItemModel> SourceItems
        {
            get { return _sourceItems; }
            set { _sourceItems = value; NotifyPropertyChanged("MultiSelectorItems"); }
        }
        private ObservableCollection<SourceItemModel> _sourceItems;

        public ObservableCollection<DataGridItemModel> DataGridItems
        {
            get { return _dataGridItems; }
            set { _dataGridItems = value; NotifyPropertyChanged("DataGridItems"); }
        }
        private ObservableCollection<DataGridItemModel> _dataGridItems;



        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class SourceItemModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public string Content { get; set; }

        public bool IsSelected { get; set; }

        public ObservableCollection<SourceItemModel> Items
        {
            get { return _items; }
            set { _items = value; NotifyPropertyChanged("Items"); }
        }
        private ObservableCollection<SourceItemModel> _items;
    }

    public class DataGridItemModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }

    }
}
