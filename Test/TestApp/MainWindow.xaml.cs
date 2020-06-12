using Panuon.UI.Silver;
using Panuon.UI.Silver.Core;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace TestApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowX
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Models.Add(new Model()
            {
                Message = "1",
                Name = "1",
                Value = "1",
            });
            Models.Add(new Model()
            {
                Message = "2",
                Name = "2",
                Value = "2",
            });
            Models.Add(new Model()
            {
                Message = "3",
                Name = "3",
                Value = "3",
            });
        }

        public ObservableCollection<Model> Models { get; set; } = new ObservableCollection<Model>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
        }

    }

    public class Model : PropertyChangedBase
    {
        public string Name { get => _name; set => SetValue(ref _name, value); }
        private string _name;


        public string Message { get => _message; set => SetValue(ref _message, value); }
        private string _message;

        public string Value { get => _value; set => SetValue(ref _value, value); }
        private string _value;
    }
    
}
