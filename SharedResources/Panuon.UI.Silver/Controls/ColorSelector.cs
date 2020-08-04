using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public class ColorSelector : Control
    {
        #region Fields
        private Fench _fench;

        private Thumb _thumb;
        #endregion

        #region Ctor
        static ColorSelector()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorSelector), new FrameworkPropertyMetadata(typeof(ColorSelector)));
        }

        public ColorSelector()
        {
        }
        #endregion

        #region Overrides
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(() =>
            {
                _fench = Template?.FindName("PART_Fench", this) as Fench;
                _thumb = Template?.FindName("PART_Thumb", this) as Thumb;

                _fench.MouseLeftButtonDown -= OnFenchMouseLeftButtonDown;
                _fench.MouseLeftButtonDown += OnFenchMouseLeftButtonDown;
            }));
        }
        #endregion

        #region Properties

        #region Mode
        public ColorMode Mode
        {
            get { return (ColorMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(ColorMode), typeof(ColorSelector));
        #endregion

        #region Panels
        public ColorSelectorPanels Panels
        {
            get { return (ColorSelectorPanels)GetValue(PanelsProperty); }
            set { SetValue(PanelsProperty, value); }
        }

        public static readonly DependencyProperty PanelsProperty =
            DependencyProperty.Register("Panels", typeof(ColorSelectorPanels), typeof(ColorSelector));
        #endregion

        #region CornerRadius
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ColorSelector));
        #endregion

        #region SelectedBrush
        public SolidColorBrush SelectedBrush
        {
            get { return (SolidColorBrush)GetValue(SelectedBrushProperty); }
            set { SetValue(SelectedBrushProperty, value); }
        }

        public static readonly DependencyProperty SelectedBrushProperty =
            DependencyProperty.Register("SelectedBrush", typeof(SolidColorBrush), typeof(ColorSelector), new PropertyMetadata(null, OnSelectedBrushChanged));
        #endregion

        #region SelectedHex
        public string SelectedHex
        {
            get { return (string)GetValue(SelectedHexProperty); }
            set { SetValue(SelectedHexProperty, value); }
        }

        public static readonly DependencyProperty SelectedHexProperty =
            DependencyProperty.Register("SelectedHex", typeof(string), typeof(ColorSelector), new PropertyMetadata(null, OnSelectedHexChanged, CoerceSelectedHex));

        #endregion

        #region SelectedColor
        public Color? SelectedColor
        {
            get { return (Color?)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register("SelectedColor", typeof(Color?), typeof(ColorSelector), new PropertyMetadata(null, OnSelectedColorChanged, CoerceSelectedColor));
        #endregion

        #region SelectedA
        public byte? SelectedA
        {
            get { return (byte?)GetValue(SelectedAProperty); }
            set { SetValue(SelectedAProperty, value); }
        }

        public static readonly DependencyProperty SelectedAProperty =
            DependencyProperty.Register("SelectedA", typeof(byte?), typeof(ColorSelector), new PropertyMetadata(null, OnSelectedAChanged, CoerceSelectedA));
        #endregion

        #region SelectedR
        public byte? SelectedR
        {
            get { return (byte?)GetValue(SelectedRProperty); }
            set { SetValue(SelectedRProperty, value); }
        }

        public static readonly DependencyProperty SelectedRProperty =
            DependencyProperty.Register("SelectedR", typeof(byte?), typeof(ColorSelector), new PropertyMetadata(null, OnSelectedRChanged));
        #endregion

        #region SelectedG
        public byte? SelectedG
        {
            get { return (byte?)GetValue(SelectedGProperty); }
            set { SetValue(SelectedGProperty, value); }
        }

        public static readonly DependencyProperty SelectedGProperty =
            DependencyProperty.Register("SelectedG", typeof(byte?), typeof(ColorSelector), new PropertyMetadata(null, OnSelectedGChanged));
        #endregion

        #region SelectedB
        public byte? SelectedB
        {
            get { return (byte?)GetValue(SelectedBProperty); }
            set { SetValue(SelectedBProperty, value); }
        }

        public static readonly DependencyProperty SelectedBProperty =
            DependencyProperty.Register("SelectedB", typeof(byte?), typeof(ColorSelector), new PropertyMetadata(null, OnSelectedBChanged));
        #endregion

        #region DefaultPaletteBrushes
        public ObservableCollection<SolidColorBrush> DefaultPaletteBrushes
        {
            get
            {
                if (_defaultPaletteBrushes == null)
                {
                    _defaultPaletteBrushes = new ObservableCollection<SolidColorBrush>();
                }
                return _defaultPaletteBrushes;
            }
        }
        private ObservableCollection<SolidColorBrush> _defaultPaletteBrushes;
        #endregion

        #endregion

        #region Internal Properties

        #region MainColorBackground
        internal Brush MainColorBackground
        {
            get { return (Brush)GetValue(MainColorBackgroundProperty); }
            set { SetValue(MainColorBackgroundProperty, value); }
        }

        internal static readonly DependencyProperty MainColorBackgroundProperty =
            DependencyProperty.Register("MainColorBackground", typeof(Brush), typeof(ColorSelector));
        #endregion

        #endregion

        #region Methods
        #endregion

        #region Event Handlers

        private void OnFenchMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var position = e.GetPosition(_fench);
            RelocationThumb(position.X, position.Y);
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() => _thumb.RaiseEvent(e)));
        }


        private static void OnSelectedAChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        private static object CoerceSelectedA(DependencyObject d, object baseValue)
        {
            var selector = d as ColorSelector;
            if (selector.Mode == ColorMode.Rgb)
            {
                return null;
            }
            return baseValue;
        }

        private static void OnSelectedRChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        private static void OnSelectedGChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        private static void OnSelectedBChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        private static void OnSelectedHexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        private static object CoerceSelectedHex(DependencyObject d, object baseValue)
        {
            var selector = d as ColorSelector;
            return selector.VerifyHexString(baseValue as string);
        }

        private static void OnSelectedColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        private static object CoerceSelectedColor(DependencyObject d, object baseValue)
        {
            var selector = d as ColorSelector;
            return selector.VerifyColor(baseValue as Color?);
        }

        private static void OnSelectedBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion

        #region Functions
        private void RelocationThumb(double left, double top)
        {
            if (_thumb == null)
            {
                return;
            }
            var width = _thumb.DesiredSize.Width;
            var height = _thumb.DesiredSize.Height;
            Canvas.SetLeft(_thumb, left - width / 2);
            Canvas.SetTop(_thumb, top - height / 2);
        }


        private Color? VerifyColor(Color? color)
        {
            return color;
        }

        private string VerifyHexString(string hex)
        {
            return hex;
        }
        #endregion
    }
}
