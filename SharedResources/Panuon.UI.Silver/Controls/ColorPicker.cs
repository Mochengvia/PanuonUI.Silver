using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class ColorPicker : Control
    {
        #region Fields
        #endregion

        #region Ctor
        static ColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker), new FrameworkPropertyMetadata(typeof(ColorPicker)));
        }

        public ColorPicker()
        {
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
            DependencyProperty.Register("Mode", typeof(ColorMode), typeof(ColorPicker));
        #endregion

        #region Panels
        public ColorPickerPanels Panels
        {
            get { return (ColorPickerPanels)GetValue(PanelsProperty); }
            set { SetValue(PanelsProperty, value); }
        }

        public static readonly DependencyProperty PanelsProperty =
            DependencyProperty.Register("Panels", typeof(ColorPickerPanels), typeof(ColorPicker));
        #endregion

        #region CornerRadius
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ColorPicker));
        #endregion

        #region DropDownCornerRadius
        public CornerRadius DropDownCornerRadius
        {
            get { return (CornerRadius)GetValue(DropDownCornerRadiusProperty); }
            set { SetValue(DropDownCornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty DropDownCornerRadiusProperty =
            DependencyProperty.Register("DropDownCornerRadius", typeof(CornerRadius), typeof(ColorPicker));


        #endregion

        #region DropDownShadowColor
        public Color? DropDownShadowColor
        {
            get { return (Color?)GetValue(DropDownShadowColorProperty); }
            set { SetValue(DropDownShadowColorProperty, value); }
        }

        public static readonly DependencyProperty DropDownShadowColorProperty =
            DependencyProperty.Register("DropDownShadowColor", typeof(Color?), typeof(ColorPicker));
        #endregion

        #region SelectedBrush
        public SolidColorBrush SelectedBrush
        {
            get { return (SolidColorBrush)GetValue(SelectedBrushProperty); }
            set { SetValue(SelectedBrushProperty, value); }
        }

        public static readonly DependencyProperty SelectedBrushProperty =
            DependencyProperty.Register("SelectedBrush", typeof(SolidColorBrush), typeof(ColorPicker), new PropertyMetadata(null, OnSelectedBrushChanged, CoerceSelectedBrush));
        #endregion

        #region SelectedHex
        public string SelectedHex
        {
            get { return (string)GetValue(SelectedHexProperty); }
            set { SetValue(SelectedHexProperty, value); }
        }

        public static readonly DependencyProperty SelectedHexProperty =
            DependencyProperty.Register("SelectedHex", typeof(string), typeof(ColorPicker), new PropertyMetadata(null, OnSelectedHexChanged, CoerceSelectedHex));

        #endregion

        #region SelectedColor
        public Color? SelectedColor
        {
            get { return (Color?)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register("SelectedColor", typeof(Color?), typeof(ColorPicker), new PropertyMetadata(null, OnSelectedColorChanged, CoerceSelectedColor));


        #endregion

        #region SelectedA
        public byte? SelectedA
        {
            get { return (byte?)GetValue(SelectedAProperty); }
            set { SetValue(SelectedAProperty, value); }
        }

        public static readonly DependencyProperty SelectedAProperty =
            DependencyProperty.Register("SelectedA", typeof(byte?), typeof(ColorPicker), new PropertyMetadata(null, OnSelectedAChanged, CoerceSelectedA));
        #endregion

        #region SelectedR
        public byte? SelectedR
        {
            get { return (byte?)GetValue(SelectedRProperty); }
            set { SetValue(SelectedRProperty, value); }
        }

        public static readonly DependencyProperty SelectedRProperty =
            DependencyProperty.Register("SelectedR", typeof(byte?), typeof(ColorPicker), new PropertyMetadata(null, OnSelectedRChanged));
        #endregion

        #region SelectedG
        public byte? SelectedG
        {
            get { return (byte?)GetValue(SelectedGProperty); }
            set { SetValue(SelectedGProperty, value); }
        }

        public static readonly DependencyProperty SelectedGProperty =
            DependencyProperty.Register("SelectedG", typeof(byte?), typeof(ColorPicker), new PropertyMetadata(null, OnSelectedGChanged));
        #endregion

        #region SelectedB
        public byte? SelectedB
        {
            get { return (byte?)GetValue(SelectedBProperty); }
            set { SetValue(SelectedBProperty, value); }
        }

        public static readonly DependencyProperty SelectedBProperty =
            DependencyProperty.Register("SelectedB", typeof(byte?), typeof(ColorPicker), new PropertyMetadata(null, OnSelectedBChanged));
        #endregion

        #endregion

        #region Methods
        #endregion

        #region Event Handlers
        private static void OnSelectedAChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        private static object CoerceSelectedA(DependencyObject d, object baseValue)
        {
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
            if (baseValue == null)
            {
                return null;
            }
        }

        private static void OnSelectedColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        private static object CoerceSelectedColor(DependencyObject d, object baseValue)
        {
            if (baseValue == null)
            {
                return null;
            }
        }

        private static void OnSelectedBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        private static object CoerceSelectedBrush(DependencyObject d, object baseValue)
        {
            if (baseValue == null)
            {
                return null;
            }
        }
        #endregion

        #region Functions
        #endregion
    }
}
