using Panuon.UI.Silver;
using Panuon.UI.Silver.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
        }

        public ObservableCollection<Model> Models { get; set; } = new ObservableCollection<Model>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
        }

        public static string GetRelativePath(string rootPath, string targetPath)
        {
            var targetUri = new Uri(targetPath);
            var rootUri = new Uri(rootPath);
            return Uri.UnescapeDataString(rootUri.MakeRelativeUri(targetUri)?.ToString()?.Replace('/', Path.DirectorySeparatorChar));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TbText.Text = "";
            for (int i = 0;i < 10; i++)
            {
                var st = Stopwatch.StartNew();
                var test = new TestWindow();
                test.Show();
                st.Stop();
                test.Close();
                TbText.Text += $"{st.ElapsedMilliseconds}\n";
            }
            
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
