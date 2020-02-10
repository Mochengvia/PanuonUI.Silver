using Panuon.UI.Silver;
using System.Windows.Controls;

namespace UIBrowser.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : WindowX
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var tb = sender as TextBox;
            if(tb.Text == "123")
            {
                TextBoxHelper.SetValidationErrorTips(tb, "值不能为123!");
            }
            else
            {
                TextBoxHelper.SetValidationErrorTips(tb, null);
            }
        }

        private void PasswordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            var psb = sender as PasswordBox;
            if (psb.Password== "123")
            {
                PasswordBoxHelper.SetValidationErrorTips(psb, "值不能为123!");
            }
            else
            {
                PasswordBoxHelper.SetValidationErrorTips(psb, null);
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxX.DefaultMessageBoxXConfigurations.YesButton = "是";
            MessageBoxX.DefaultMessageBoxXConfigurations.NoButton = "否";
            MessageBoxX.DefaultMessageBoxXConfigurations.MessageBoxStyle = MessageBoxStyle.Standard;

            MessageBoxX.Show("WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING !", "Tips", System.Windows.MessageBoxButton.YesNoCancel, MessageBoxIcon.Info, DefaultButton.NoCancel);
            MessageBoxX.Show("WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING !", "Tips", icon: MessageBoxIcon.Error);
            MessageBoxX.Show("WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING !", "Tips", icon: MessageBoxIcon.Warning);
            MessageBoxX.Show("WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING !", "Tips", icon: MessageBoxIcon.Question);
            MessageBoxX.Show("WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING ! WARNING !", "Tips", icon: MessageBoxIcon.Success);
        }
    }
}
