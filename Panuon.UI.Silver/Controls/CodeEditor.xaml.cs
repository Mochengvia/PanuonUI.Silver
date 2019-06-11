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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Panuon.UI.Silver
{
    /// <summary>
    /// CodeTextBox.xaml 的交互逻辑
    /// </summary>
    [ContentProperty(nameof(Text))]
    public partial class CodeEditor : UserControl
    {
        public CodeEditor()
        {
            InitializeComponent();
            LineBrushList = new ObservableCollection<LineBrushModel>();
            LayoutUpdated += new EventHandler(OnLayoutUpdated);
            TbText.LayoutUpdated += new EventHandler(OnLayoutUpdated);

        }

        private void OnLayoutUpdated(object sender, EventArgs e)
        {
            LineCount = TbText.LineCount < 1 ? 1 : TbText.LineCount;
        }

        #region RoutedEvent
        public static readonly RoutedEvent TextChangedEvent = EventManager.RegisterRoutedEvent("TextChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<string>), typeof(CodeEditor));
        public event RoutedPropertyChangedEventHandler<string> TextChanged
        {
            add { AddHandler(TextChangedEvent, value); }
            remove { RemoveHandler(TextChangedEvent, value); }
        }
        internal void OnTextChanged(string oldItem, string newItem)
        {
            RoutedPropertyChangedEventArgs<string> arg = new RoutedPropertyChangedEventArgs<string>(oldItem, newItem, TextChangedEvent); RaiseEvent(arg);
        }
        #endregion

        #region Property
        public int LineCount
        {
            get { return (int)GetValue(LineCountProperty); }
            set { SetValue(LineCountProperty, value); }
        }

        public static readonly DependencyProperty LineCountProperty =
            DependencyProperty.Register("LineCount", typeof(int), typeof(CodeEditor), new PropertyMetadata(OnLineCountChanged));

        private static void OnLineCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var codeTextBox = d as CodeEditor;
            if (codeTextBox.LineBrushList.Count > codeTextBox.LineCount)
            {
                for (int i = codeTextBox.LineBrushList.Count - 1; i > codeTextBox.LineCount - 1; i--)
                {
                    codeTextBox.LineBrushList.RemoveAt(i);
                }
            }
            else
            {
                for (int i = codeTextBox.LineBrushList.Count; i < codeTextBox.LineCount; i++)
                {
                    codeTextBox.LineBrushList.Add(new LineBrushModel()
                    {
                        LineHeight = codeTextBox.TbText.FontSize + 10,
                        LineBrush = i % 2 == 0 ? codeTextBox.LineBrush1 : codeTextBox.LineBrush2,
                        LineIndex = (i + 1) + ".",
                    });
                }
            }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(CodeEditor));



        public Brush LineBrush1
        {
            get { return (Brush)GetValue(LineBrush1Property); }
            set { SetValue(LineBrush1Property, value); }
        }

        public static readonly DependencyProperty LineBrush1Property =
            DependencyProperty.Register("LineBrush1", typeof(Brush), typeof(CodeEditor), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AADDDDDD"))));




        public Brush LineBrush2
        {
            get { return (Brush)GetValue(LineBrush2Property); }
            set { SetValue(LineBrush2Property, value); }
        }

        public static readonly DependencyProperty LineBrush2Property =
            DependencyProperty.Register("LineBrush2", typeof(Brush), typeof(CodeEditor), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AAFAFAFA"))));


        #endregion

        #region Internal Property
        internal ObservableCollection<LineBrushModel> LineBrushList
        {
            get { return (ObservableCollection<LineBrushModel>)GetValue(LineBrushListProperty); }
            set { SetValue(LineBrushListProperty, value); }
        }

        internal static readonly DependencyProperty LineBrushListProperty =
            DependencyProperty.Register("LineBrushList", typeof(ObservableCollection<LineBrushModel>), typeof(CodeEditor));
        #endregion

        internal class LineBrushModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            public void NotifyPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(propertyName, null);
            }

            public Brush LineBrush
            {
                get { return _lineBrush; }
                set { _lineBrush = value; NotifyPropertyChanged("LineBrush"); }
            }
            private Brush _lineBrush;

            public double LineHeight
            {
                get { return _lineHeight; }
                set { _lineHeight = value; NotifyPropertyChanged("LineHeight"); }
            }
            private double _lineHeight;

            public string LineIndex
            {
                get { return _lineIndex; }
                set { _lineIndex = value; NotifyPropertyChanged("LineIndex"); }
            }
            private string _lineIndex;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            OnTextChanged(TbText.Text, TbText.Text);
        }
    }


}
