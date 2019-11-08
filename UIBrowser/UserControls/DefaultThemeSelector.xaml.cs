using System;
using System.Windows;
using System.Windows.Controls;

namespace UIBrowser.UserControls
{
    /// <summary>
    /// DefaultThemeSelector.xaml 的交互逻辑
    /// </summary>
    public partial class DefaultThemeSelector : UserControl
    {
        public DefaultThemeSelector()
        {
            InitializeComponent();
        }

        #region Property
        /// <summary>
        /// Gets or sets header.
        /// </summary>
        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(DefaultThemeSelector));

        /// <summary>
        /// Gets or sets header width.
        /// </summary>
        public string HeaderWidth
        {
            get { return (string)GetValue(HeaderWidthProperty); }
            set { SetValue(HeaderWidthProperty, value); }
        }

        public static readonly DependencyProperty HeaderWidthProperty =
            DependencyProperty.Register("HeaderWidth", typeof(string), typeof(DefaultThemeSelector));

        /// <summary>
        /// Gets or sets preset theme
        /// </summary>
        public PresetTheme PresetTheme
        {
            get { return (PresetTheme)GetValue(PresetThemeProperty); }
            set { SetValue(PresetThemeProperty, value); }
        }

        public static readonly DependencyProperty PresetThemeProperty =
            DependencyProperty.Register("PresetTheme", typeof(PresetTheme), typeof(DefaultThemeSelector));
        #endregion

        private void RdbPresetTheme_Checked(object sender, RoutedEventArgs e)
        {
            var rdb = sender as RadioButton;
            if (rdb?.Tag == null)
                return;

            PresetTheme = (PresetTheme)Enum.Parse(typeof(PresetTheme), rdb.Tag.ToString());
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            RdbPresetTheme.IsChecked = true;
        }
    }
}
