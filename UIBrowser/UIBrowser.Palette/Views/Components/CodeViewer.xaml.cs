using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UIBrowser.Palette.Views.Components
{
    /// <summary>
    /// CodeViewer.xaml 的交互逻辑
    /// </summary>
    public partial class CodeViewer : UserControl
    {
        public CodeViewer()
        {
            InitializeComponent();
        }

        #region Properties


        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("Code", typeof(string), typeof(CodeViewer), new PropertyMetadata(OnCodeChanged));

        private static void OnCodeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var viewer = d as CodeViewer;
            viewer.TeCode.Text = e.NewValue.ToString();
        }


        #endregion
    }
}
