using Panuon.UI.Silver;
using System.ComponentModel;
using System.Windows;

namespace TestApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowX, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private string _text = "123456";

        public string Text
        {
            get { return _text; }
            set { _text = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text))); }
        }

        public ButtonStyle ButtonStyle
        {
            get { return _buttonStyle; }
            set { _buttonStyle = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ButtonStyle))); }
        }
        private ButtonStyle _buttonStyle = ButtonStyle.Hollow;


        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxX.Show("This is a error message. ", "Error", MessageBoxButton.OK, MessageBoxIcon.Error);
        }
    }
    
}
