using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using UIBrowser.Models;

namespace UIBrowser.ViewModels.Partials.Native
{
    public class ButtonViewModel : ControlViewModelBase
    {
        #region Override
        protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SourceCode" || e.PropertyName == "StyleCode")
                return;

            SourceElementCore = SourceCodeGenerator.NewElement("Button", nameof(ButtonStyle))
                .AddDependencyProperty(nameof(Content), Content, null)
                .AddDependencyProperty(nameof(Width), Width, null)
                .AddDependencyProperty(nameof(Height), 30, null)
                .AddDependencyProperty(nameof(Background), Background, null)
                .AddDependencyProperty(nameof(Foreground), Foreground, null)
                .AddDependencyProperty(nameof(BorderBrush), BorderBrush, null)
                .AddAttachedProperty(typeof(ButtonHelper), nameof(ButtonStyle), ButtonStyle, ButtonStyle.Standard)
                .AddAttachedProperty(typeof(ButtonHelper), nameof(HoverBrush), HoverBrush, null)
                .AddAttachedProperty(typeof(ButtonHelper), nameof(IsWaiting), IsWaiting,  false)
                .AddAttachedProperty(typeof(ButtonHelper), nameof(ClickStyle), ClickStyle, ClickStyle.None)
                .AddAttachedProperty(typeof(ButtonHelper), nameof(CornerRadius), CornerRadius, 0);

            SourceCode = SourceElementCore.ToSourceCode();
            StyleCode = SourceElementCore.ToStyleCode();
        }

        protected override void OnPresetThemeChanged(object sender, EventArgs e)
        {
            if (PresetTheme == PresetTheme.Custom)
                return;

            var baseBrush = ThemeResources.GetLightPresetThemeBrush(PresetTheme);
            var hoverBrush = ThemeResources.GetPresetThemeBrush(PresetTheme);
            switch (ButtonStyle)
            {
                case ButtonStyle.Standard:
                    Background = baseBrush;
                    Foreground = Brushes.White;
                    HoverBrush = hoverBrush;
                    BorderBrush = Brushes.Transparent;
                    break;
                case ButtonStyle.Outline:
                case ButtonStyle.Hollow:
                    Background = baseBrush;
                    Foreground = baseBrush;
                    HoverBrush = hoverBrush;
                    BorderBrush = baseBrush;
                    break;
                case ButtonStyle.Link:
                    Background = Brushes.Transparent;
                    Foreground = baseBrush;
                    HoverBrush = hoverBrush;
                    BorderBrush = Brushes.Transparent;
                    break;
            }
        }

        internal override void Reset()
        {
            PresetTheme = PresetTheme.Custom;
            Background = "#4D4D4D".ToColor().ToBrush();
            HoverBrush = "#3E3E3E".ToColor().ToBrush();
            Foreground = "#FFFFFF".ToColor().ToBrush();
            Content = "Button";
            CornerRadius = new System.Windows.CornerRadius(0);
            Width = 150;
            SinkWhenClick = false;
            IsWaiting = false;
        }
        #endregion

        #region Property
        /// <summary>
        /// Gets or sets button style.
        /// </summary>
        public ButtonStyle ButtonStyle
        {
            get { return _buttonStyle; }
            set { UpdateStyles(_buttonStyle, value); _buttonStyle = value; NotifyPropertyChanged();  }
        }
        private ButtonStyle _buttonStyle;

        /// <summary>
        /// Gets or sets sink when click
        /// </summary>
        public bool SinkWhenClick
        {
            get { return _sinkWhenClick; }
            set { _sinkWhenClick = value; NotifyPropertyChanged(); ClickStyle = value ? ClickStyle.Sink : ClickStyle.None; }
        }

        private bool _sinkWhenClick;

        /// <summary>
        /// Gets or sets click style.
        /// </summary>
        public ClickStyle ClickStyle
        {
            get { return _clickStyle; }
            set { _clickStyle = value; NotifyPropertyChanged(); }
        }
        private ClickStyle _clickStyle;

        /// <summary>
        /// Gets or sets is waiting.
        /// </summary>
        public bool IsWaiting
        {
            get { return _isWaiting; }
            set { _isWaiting = value; NotifyPropertyChanged(); }
        }
        private bool _isWaiting;

        #endregion

        #region Function
        private void UpdateStyles(ButtonStyle oldStyle, ButtonStyle newStyle)
        {
            Brush baseBrush;
            switch (oldStyle)
            {
                case ButtonStyle.Standard:
                    baseBrush = Background;
                    break;
                case ButtonStyle.Outline:
                    baseBrush = BorderBrush;
                    break;
                case ButtonStyle.Hollow:
                    baseBrush = BorderBrush;
                    break;
                case ButtonStyle.Link:
                    baseBrush = Foreground;
                    break;
                default:
                    return;
            }

            switch (newStyle)
            {
                case ButtonStyle.Standard:
                    Background = baseBrush;
                    Foreground = Brushes.White;
                    BorderBrush = Brushes.Transparent;
                    break;
                case ButtonStyle.Outline:
                    Background = Brushes.Transparent;
                    Foreground = baseBrush;
                    BorderBrush = baseBrush;
                    break;
                case ButtonStyle.Hollow:
                    Background = Brushes.Transparent;
                    Foreground = baseBrush;
                    BorderBrush = baseBrush;
                    break;
                case ButtonStyle.Link:
                    Background = Brushes.Transparent;
                    Foreground = baseBrush;
                    BorderBrush = Brushes.Transparent;
                    break;
            }

        }
        #endregion
    }
}
