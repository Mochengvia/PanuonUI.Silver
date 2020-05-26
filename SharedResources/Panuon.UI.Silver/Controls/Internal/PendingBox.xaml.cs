using Panuon.UI.Silver.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver.Controls.Internal
{
    /// <summary>
    /// CheckIcon.xaml 的交互逻辑
    /// </summary>
    internal partial class PendingBox : Window
    {
        #region Identifier
        private bool _closeHandler = true;
        #endregion

        public PendingBox(Window owner, string message, string title,bool cancelable, PendingBoxConfigurations configurations)
        {
            InitializeComponent();

            PendingBoxStyle = configurations.PendingBoxStyle;
            if(configurations.PendingBoxStyle == PendingBoxStyle.Standard)
            {
                if (!string.IsNullOrEmpty(title))
                {
                    TxtTitle.Text = title;
                    TxtTitle.Visibility = Visibility.Visible;
                    Title = title;
                    WindowXCaption.SetHeight(this, 30);
                }
            }
            else if(configurations.PendingBoxStyle == PendingBoxStyle.Classic)
            {
                if (!string.IsNullOrEmpty(title))
                {
                    TxtTitle2.Text = title;
                    TxtTitle2.Visibility = Visibility.Visible;
                    Title = title;
                    WindowXCaption.SetHeight(this, 30);
                }
                GrdStandard.Visibility = Visibility.Collapsed;
                GrdClassic.Visibility = Visibility.Visible;
            }

            Owner = owner;
            Cancelable = cancelable;
            Message = message;
            CancelButton = configurations.CancelButton;

            Foreground = configurations.Foreground;
            LoadingBackground = configurations.LoadingBackground;
            LoadingForeground = configurations.LoadingForeground;
            ButtonBrush = configurations.ButtonBrush;

            ShowInTaskbar = configurations.ShowInTaskbar;
            Topmost = configurations.Topmost;
            FontSize = configurations.FontSize;
            WindowStartupLocation = configurations.WindowStartupLocation;
            LoadingStyle = configurations.LoadingStyle;
            LoadingSize = configurations.LoadingSize;
            MinHeight = configurations.MinHeight;
            MinWidth = configurations.MinWidth;
            MaxHeight = configurations.MaxHeight;
            MaxWidth = configurations.MaxWidth;
        }

        #region Event
        public event EventHandler Canceled;
        #endregion

        #region Property


        public bool Cancelable
        {
            get { return (bool)GetValue(CancelableProperty); }
            set { SetValue(CancelableProperty, value); }
        }

        public static readonly DependencyProperty CancelableProperty =
            DependencyProperty.Register("Cancelable", typeof(bool), typeof(PendingBox));



        public PendingBoxStyle PendingBoxStyle
        {
            get { return (PendingBoxStyle)GetValue(PendingBoxStyleProperty); }
            set { SetValue(PendingBoxStyleProperty, value); }
        }

        public static readonly DependencyProperty PendingBoxStyleProperty =
            DependencyProperty.Register("PendingBoxStyle", typeof(PendingBoxStyle), typeof(PendingBox));


        /// <summary>
        /// Gets or sets loading style.
        /// </summary>
        public LoadingStyle LoadingStyle
        {
            get { return (LoadingStyle)GetValue(LoadingStyleProperty); }
            set { SetValue(LoadingStyleProperty, value); }
        }

        public static readonly DependencyProperty LoadingStyleProperty =
            DependencyProperty.Register("LoadingStyle", typeof(LoadingStyle), typeof(PendingBox), new PropertyMetadata(OnLoadingStyleChanged));



        public Brush ButtonBrush
        {
            get { return (Brush)GetValue(ButtonBrushProperty); }
            set { SetValue(ButtonBrushProperty, value); }
        }

        public static readonly DependencyProperty ButtonBrushProperty =
            DependencyProperty.Register("ButtonBrush", typeof(Brush), typeof(PendingBox));


        /// <summary>
        /// Gets or sets loading stroke.
        /// </summary>
        public Brush LoadingBackground
        {
            get { return (Brush)GetValue(LoadingBackgroundProperty); }
            set { SetValue(LoadingBackgroundProperty, value); }
        }

        public static readonly DependencyProperty LoadingBackgroundProperty =
            DependencyProperty.Register("LoadingBackground", typeof(Brush), typeof(PendingBox), new PropertyMetadata(OnLoadingStyleChanged));

        /// <summary>
        /// Gets or sets loading stroke cover.
        /// </summary>
        public Brush LoadingForeground
        {
            get { return (Brush)GetValue(LoadingForegroundProperty); }
            set { SetValue(LoadingForegroundProperty, value); }
        }

        public static readonly DependencyProperty LoadingForegroundProperty =
            DependencyProperty.Register("LoadingForeground", typeof(Brush), typeof(PendingBox), new PropertyMetadata(OnLoadingStyleChanged));

        /// <summary>
        /// Gets or sets message.
        /// </summary>
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(PendingBox));

        /// <summary>
        /// Gets or sets loading size.
        /// </summary>
        public double LoadingSize
        {
            get { return (double)GetValue(LoadingSizeProperty); }
            set { SetValue(LoadingSizeProperty, value); }
        }

        public static readonly DependencyProperty LoadingSizeProperty =
            DependencyProperty.Register("LoadingSize", typeof(double), typeof(PendingBox));

        /// <summary>
        /// Gets or sets cancel button content.
        /// </summary>
        public string CancelButton
        {
            get { return (string)GetValue(CancelButtonProperty); }
            set { SetValue(CancelButtonProperty, value); }
        }

        public static readonly DependencyProperty CancelButtonProperty =
            DependencyProperty.Register("CancelButton", typeof(string), typeof(PendingBox));
        #endregion

        #region Event Handler
        private void PendingBox_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(_closeHandler)
                e.Cancel = true;
        }

        private void PendingBox_Loaded(object sender, RoutedEventArgs e)
        {
            if(PendingBoxStyle == PendingBoxStyle.Standard)
                LdMain.IsRunning = true;
            else
                LdMain2.IsRunning = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Canceled?.Invoke(this, e);
            var btnCancel = sender as Button;
            btnCancel.IsEnabled = false;
        }

        private static void OnLoadingStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var box = d as PendingBox;
            if (box.LoadingBackground != null)
                box.LdMain.Background = box.LoadingBackground;
            if (box.LoadingForeground != null)
                box.LdMain.Foreground = box.LoadingForeground;

            box.LdMain.LoadingStyle = box.LoadingStyle;
        }
        #endregion

        #region Calling Methods
        public void UpdateMessage(string message)
        {
            Message = message;
        }

        public void ForceClose()
        {
            _closeHandler = false;
            Close();
        }
        #endregion
    }
}
