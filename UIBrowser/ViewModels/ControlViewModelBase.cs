using Panuon.UI.Silver.Core;
using System;
using System.Windows.Input;
using System.Windows.Media;
using UIBrowser.Models;

namespace UIBrowser.ViewModels
{
    public abstract class ControlViewModelBase : PropertyChangedBase
    {
        public ControlViewModelBase()
        {
            PropertyChanged += OnPropertyChanged;
            PresetThemeChanged += OnPresetThemeChanged;
        }

        #region Abstract
        protected abstract void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e);

        protected abstract void OnPresetThemeChanged(object sender, EventArgs e);

        internal abstract void Reset();
        #endregion

        #region Event 
        public event EventHandler PresetThemeChanged;
        #endregion

        #region Property
        public SourceElementCore SourceElementCore { get; protected set; }

        /// <summary>
        /// Gets or sets text.
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; NotifyPropertyChanged(); }
        }
        private string _text;

        /// <summary>
        /// Gets or sets content
        /// </summary>
        public object Content
        {
            get { return _content; }
            set { _content = value; NotifyPropertyChanged(); }
        }
        private object _content;


        /// <summary>
        /// Gets or sets preset theme.
        /// </summary>
        public PresetTheme PresetTheme
        {
            get { return _presetTheme; }
            set { _presetTheme = value;
                PresetThemeChanged?.Invoke(this, new EventArgs()); }
        }
        private PresetTheme _presetTheme;

        /// <summary>
        /// Gets or sets code.
        /// </summary>
        public string SourceCode
        {
            get { return _sourceCode; }
            set { _sourceCode = value; NotifyPropertyChanged(); }
        }
        private string _sourceCode;

        /// <summary>
        /// Gets or sets style code.
        /// </summary>
        public string StyleCode
        {
            get { return _styleCode; }
            set { _styleCode = value; NotifyPropertyChanged(); }
        }
        private string _styleCode;

        /// <summary>
        /// Gets or sets height.
        /// </summary>
        public double Height
        {
            get { return _height; }
            set { _height = value; NotifyPropertyChanged(); }
        }
        private double _height;

        /// <summary>
        /// Gets or sets width.
        /// </summary>
        public double Width
        {
            get { return _width; }
            set { _width = value; NotifyPropertyChanged(); }
        }
        private double _width = 150;

        /// <summary>
        /// Gets or sets background.
        /// </summary>
        public Brush Background
        {
            get { return _background; }
            set { _background = value; NotifyPropertyChanged(); }
        }
        private Brush _background;

        // <summary>
        /// Gets or sets foreground.
        /// </summary>
        public Brush Foreground
        {
            get { return _foreground; }
            set { _foreground = value; NotifyPropertyChanged(); }
        }
        private Brush _foreground;

        // <summary>
        /// Gets or sets hover brush.
        /// </summary>
        public Brush HoverBrush
        {
            get { return _hoverBrush; }
            set { _hoverBrush = value; NotifyPropertyChanged(); }
        }
        private Brush _hoverBrush;

        // <summary>
        /// Gets or sets hover background.
        /// </summary>
        public Brush HoverBackground
        {
            get { return _hoverBackground; }
            set { _hoverBackground = value; NotifyPropertyChanged(); }
        }
        private Brush _hoverBackground;

        // <summary>
        /// Gets or sets hover foreground.
        /// </summary>
        public Brush HoverForeground
        {
            get { return _hoverForeground; }
            set { _hoverForeground = value; NotifyPropertyChanged(); }
        }
        private Brush _hoverForeground;

        // <summary>
        /// Gets or sets hover cornerRadius.
        /// </summary>
        public double CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; NotifyPropertyChanged(); }
        }
        private double _cornerRadius;

        // <summary>
        /// Gets or sets hover border brush.
        /// </summary>
        public Brush BorderBrush
        {
            get { return _borderBrush; }
            set { _borderBrush = value; NotifyPropertyChanged(); }
        }
        private Brush _borderBrush;

        /// <summary>
        /// Gets or sets carousel index.
        /// </summary>
        public int CarouselIndex
        {
            get { return _carouselIndex; }
            set { _carouselIndex = value; NotifyPropertyChanged(); }
        }
        private int _carouselIndex;
        #endregion

        #region Commands
        public ICommand IncreaseCarouselIndexCommand { get; set; } = new IncreaseCarouselIndexCommand();

        public ICommand DecreaseCarouselIndexCommand { get; set; } = new DecreaseCarouselIndexCommand();

        public ICommand ResetCommand { get; set; } = new ResetCommand();
        #endregion
    }

    public class ResetCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var viewModel = parameter as ControlViewModelBase;
            viewModel.Reset();
        }
    }
    
    public class IncreaseCarouselIndexCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var viewModel = parameter as ControlViewModelBase;
            viewModel.CarouselIndex++;
        }
    }

    public class DecreaseCarouselIndexCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var viewModel = parameter as ControlViewModelBase;
            viewModel.CarouselIndex--;
        }
    }

}
