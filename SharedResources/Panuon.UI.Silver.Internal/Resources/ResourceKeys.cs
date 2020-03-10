using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Panuon.UI.Silver.Internal
{
    internal static class ResourceKeys
    {
        #region Converters
        public const string CloneConverter = nameof(CloneConverter);

        public const string BoolToVisibleConverter = nameof(BoolToVisibleConverter);

        public static readonly string BoolToCollapseConverter = nameof(BoolToCollapseConverter);

        public static readonly string NullToVisibleConverter = nameof(NullToVisibleConverter);

        public static readonly string TrueToFalseConverter = nameof(TrueToFalseConverter);

        public static readonly string NullOrEmptyToVisibleConverter = nameof(NullOrEmptyToVisibleConverter);

        public static readonly string NullToCollapseConverter = nameof(NullToCollapseConverter);

        public static readonly string NullOrEmptyToCollapseConverter = nameof(NullOrEmptyToCollapseConverter);

        public static readonly string IsNullConverter = nameof(IsNullConverter);

        public static readonly string IsNotNullConverter = nameof(IsNotNullConverter);

        public static readonly string IsNullOrEmptyConverter = nameof(IsNullOrEmptyConverter);

        public static readonly string HoverBrushConverter = nameof(HoverBrushConverter);

        public static readonly string IconPositionToOrientationConverter = nameof(IconPositionToOrientationConverter);

        public static readonly string BrushToColorConverter = nameof(BrushToColorConverter);

        public static readonly string GridLengthConverter = nameof(GridLengthConverter);

        public static readonly string GridLengthStringToDoubleConverter = nameof(GridLengthStringToDoubleConverter);

        public static readonly string GridLengthIsAbsoluteOrAutoConverter = nameof(GridLengthIsAbsoluteOrAutoConverter);

        public static readonly string DividedBy2Converter = nameof(DividedBy2Converter);

        public static readonly string DividedBy2_5Converter = nameof(DividedBy2_5Converter);

        public static readonly string DividedByMinus2Converter = nameof(DividedByMinus2Converter);

        public static readonly string DividedBy3Converter = nameof(DividedBy3Converter);

        public static readonly string DividedBy4Converter = nameof(DividedBy4Converter);

        public static readonly string DividedBy5Converter = nameof(DividedBy5Converter);

        public static readonly string DividedBy6Converter = nameof(DividedBy6Converter);

        public static readonly string DividedBy7Converter = nameof(DividedBy7Converter);

        public static readonly string DividedBy10Converter = nameof(DividedBy10Converter);

        public static readonly string DividedBy12Converter = nameof(DividedBy12Converter);

        public static readonly string DividedBy15Converter = nameof(DividedBy15Converter);

        public static readonly string Add3Converter = nameof(Add3Converter);

        public static readonly string Add5Converter = nameof(Add5Converter);

        public static readonly string Add7Converter = nameof(Add7Converter);

        public static readonly string Add10Converter = nameof(Add10Converter);

        public static readonly string Add16Converter = nameof(Add16Converter);

        public static readonly string Minus1Converter = nameof(Minus1Converter);

        public static readonly string Minus0_5Converter = nameof(Minus0_5Converter);

        public static readonly string Minus2Converter = nameof(Minus2Converter);

        public static readonly string Minus3Converter = nameof(Minus3Converter);

        public static readonly string Minus5Converter = nameof(Minus5Converter);

        public static readonly string Minus7Converter = nameof(Minus7Converter);

        public static readonly string Minus10Converter = nameof(Minus10Converter);

        public static readonly string DoubleMinConverter = nameof(DoubleMinConverter);

        public static readonly string DoubleEqualsConverter = nameof(DoubleEqualsConverter);

        public static readonly string DoubleToRightMarginConverter = nameof(DoubleToRightMarginConverter);

        
        public static readonly string IsGreaterThanZeroConverter = nameof(IsGreaterThanZeroConverter);

        public static readonly string IsLessThanZeroConverter = nameof(IsLessThanZeroConverter);

        public static readonly string ArcConverter = nameof(ArcConverter);

        public static readonly string TreeViewPaddingConverter = nameof(TreeViewPaddingConverter);

        public static readonly string TreeViewChainHorizontalMarginConverter = nameof(TreeViewChainHorizontalMarginConverter);

        public static readonly string TreeViewChainVerticalMarginConverter = nameof(TreeViewChainVerticalMarginConverter);
        
        public static readonly string CornerRadiusToDoubleConverter = nameof(CornerRadiusToDoubleConverter);

        public static readonly string ThicknessToDoubleConverter = nameof(ThicknessToDoubleConverter);

        public static readonly string ThicknessWithoutTopConverter = nameof(ThicknessWithoutTopConverter);

        public static readonly string ThicknessWithTopOnlyConverter = nameof(ThicknessWithTopOnlyConverter);

        public static readonly string ThicknessWithBottomOnlyConverter = nameof(ThicknessWithBottomOnlyConverter);

        public static readonly string CheckBoxStandardGlyphPathConverter = nameof(CheckBoxStandardGlyphPathConverter);

        public static readonly string CheckBoxSwitchToggleMarginConverter = nameof(CheckBoxSwitchToggleMarginConverter);

        public static readonly string CheckBoxSwitch2DecorationMarginConverter = nameof(CheckBoxSwitch2DecorationMarginConverter);

        public static readonly string CheckBoxSwitch3ToggleMarginConverter = nameof(CheckBoxSwitch3ToggleMarginConverter);

        public static readonly string CheckBoxSwitch3ToggleTrackMarginConverter = nameof(CheckBoxSwitch3ToggleTrackMarginConverter);

        public static readonly string NullableColorToColorConverter = nameof(NullableColorToColorConverter);

        public static readonly string CombineToArrayConverter = nameof(CombineToArrayConverter);

        public static readonly string DropDownPathDataConverter = nameof(DropDownPathDataConverter);

        public static readonly string MsgBoxIconConverter = nameof(MsgBoxIconConverter);

        public static readonly string MsgBoxIconForegroundConverter = nameof(MsgBoxIconForegroundConverter);

        public static readonly string MsgBoxButtonVisibilityConverter = nameof(MsgBoxButtonVisibilityConverter);

        public static readonly string MsgBoxButtonIsDefaultConverter = nameof(MsgBoxButtonIsDefaultConverter);

        public static readonly string MsgBoxStackPanelFlowDirectionConverter = nameof(MsgBoxStackPanelFlowDirectionConverter);

        public static readonly string StateControlTemplateConverter = nameof(StateControlTemplateConverter);

        #endregion

        #region Common
        public const string DefaultForegroundColor = nameof(DefaultForegroundColor);
        #endregion

        #region WindowX
        public static readonly string WindowXTemplate = nameof(WindowXTemplate);

        public static readonly string WindowXToolWindowTemplate = nameof(WindowXToolWindowTemplate);

        public static readonly string WindowXDefaultHeader = nameof(WindowXDefaultHeader);

        public static readonly string WindowXCaptionForeground = nameof(WindowXCaptionForeground);

        public static readonly string WindowXCaptionBackground = nameof(WindowXCaptionBackground);

        public static readonly string WindowXCaptionHeight = nameof(WindowXCaptionHeight);

        public static readonly string WindowXCaptionHorizontalHeaderAlignment = nameof(WindowXCaptionHorizontalHeaderAlignment);

        public static readonly string WindowXCaptionMinimizeButtonHoverBrush = nameof(WindowXCaptionMinimizeButtonHoverBrush);

        public static readonly string WindowXCaptionMaximizeButtonHoverBrush = nameof(WindowXCaptionMaximizeButtonHoverBrush);

        public static readonly string WindowXCaptionCloseButtonHoverBrush = nameof(WindowXCaptionCloseButtonHoverBrush);


        #endregion

        #region Loading
        public const string LoadingClassicRenderTransformOriginConverter = nameof(LoadingClassicRenderTransformOriginConverter);


        #endregion

        #region Button
        public const string ButtonTemplate = nameof(ButtonTemplate);

        public const string ButtonDefaultCornerRadius = nameof(ButtonDefaultCornerRadius);

        public const string ButtonDefaultClickStyle = nameof(ButtonDefaultClickStyle);

        public const string ButtonDefaultIconPosition = nameof(ButtonDefaultIconPosition);

        public const string ButtonDefaultWaitingContent = nameof(ButtonDefaultWaitingContent);




        public const string ButtonStandardDefaultBackground = nameof(ButtonStandardDefaultBackground);

        public const string ButtonStandardDefaultForeground = nameof(ButtonStandardDefaultForeground);

        public const string ButtonStandardDefaultBorderBrush = nameof(ButtonStandardDefaultBorderBrush);

        public const string ButtonStandardDefaultHoverBrush = nameof(ButtonStandardDefaultHoverBrush);

        public const string ButtonStandardDefaultBorderThickness = nameof(ButtonStandardDefaultBorderThickness);



        public const string ButtonOutlineDefaultBackground = nameof(ButtonOutlineDefaultBackground);

        public const string ButtonOutlineDefaultForeground = nameof(ButtonOutlineDefaultForeground);

        public const string ButtonOutlineDefaultBorderBrush = nameof(ButtonOutlineDefaultBorderBrush);

        public const string ButtonOutlineDefaultHoverBrush = nameof(ButtonOutlineDefaultHoverBrush);

        public const string ButtonOutlineDefaultBorderThickness = nameof(ButtonOutlineDefaultBorderThickness);



        public const string ButtonHollowDefaultBackground = nameof(ButtonHollowDefaultBackground);

        public const string ButtonHollowDefaultForeground = nameof(ButtonHollowDefaultForeground);

        public const string ButtonHollowDefaultBorderBrush = nameof(ButtonHollowDefaultBorderBrush);

        public const string ButtonHollowDefaultHoverBrush = nameof(ButtonHollowDefaultHoverBrush);

        public const string ButtonHollowDefaultBorderThickness = nameof(ButtonHollowDefaultBorderThickness);



        public const string ButtonLinkDefaultBackground = nameof(ButtonLinkDefaultBackground);

        public const string ButtonLinkDefaultForeground = nameof(ButtonLinkDefaultForeground);

        public const string ButtonLinkDefaultBorderBrush = nameof(ButtonLinkDefaultBorderBrush);

        public const string ButtonLinkDefaultHoverBrush = nameof(ButtonLinkDefaultHoverBrush);

        public const string ButtonLinkDefaultBorderThickness = nameof(ButtonLinkDefaultBorderThickness);

        #endregion

        #region RepeatButton
        public const string RepeatButtonTemplate = nameof(RepeatButtonTemplate);

        public const string RepeatButtonDefaultCornerRadius = nameof(RepeatButtonDefaultCornerRadius);

        public const string RepeatButtonDefaultClickStyle = nameof(RepeatButtonDefaultClickStyle);

        public const string RepeatButtonDefaultIconPosition = nameof(RepeatButtonDefaultIconPosition);

        public const string RepeatButtonDefaultWaitingContent = nameof(RepeatButtonDefaultWaitingContent);




        public const string RepeatButtonStandardDefaultBackground = nameof(RepeatButtonStandardDefaultBackground);

        public const string RepeatButtonStandardDefaultForeground = nameof(RepeatButtonStandardDefaultForeground);

        public const string RepeatButtonStandardDefaultBorderBrush = nameof(RepeatButtonStandardDefaultBorderBrush);

        public const string RepeatButtonStandardDefaultHoverBrush = nameof(RepeatButtonStandardDefaultHoverBrush);

        public const string RepeatButtonStandardDefaultBorderThickness = nameof(RepeatButtonStandardDefaultBorderThickness);



        public const string RepeatButtonOutlineDefaultBackground = nameof(RepeatButtonOutlineDefaultBackground);

        public const string RepeatButtonOutlineDefaultForeground = nameof(RepeatButtonOutlineDefaultForeground);

        public const string RepeatButtonOutlineDefaultBorderBrush = nameof(RepeatButtonOutlineDefaultBorderBrush);

        public const string RepeatButtonOutlineDefaultHoverBrush = nameof(RepeatButtonOutlineDefaultHoverBrush);

        public const string RepeatButtonOutlineDefaultBorderThickness = nameof(RepeatButtonOutlineDefaultBorderThickness);



        public const string RepeatButtonHollowDefaultBackground = nameof(RepeatButtonHollowDefaultBackground);

        public const string RepeatButtonHollowDefaultForeground = nameof(RepeatButtonHollowDefaultForeground);

        public const string RepeatButtonHollowDefaultBorderBrush = nameof(RepeatButtonHollowDefaultBorderBrush);

        public const string RepeatButtonHollowDefaultHoverBrush = nameof(RepeatButtonHollowDefaultHoverBrush);

        public const string RepeatButtonHollowDefaultBorderThickness = nameof(RepeatButtonHollowDefaultBorderThickness);



        public const string RepeatButtonLinkDefaultBackground = nameof(RepeatButtonLinkDefaultBackground);

        public const string RepeatButtonLinkDefaultForeground = nameof(RepeatButtonLinkDefaultForeground);

        public const string RepeatButtonLinkDefaultBorderBrush = nameof(RepeatButtonLinkDefaultBorderBrush);

        public const string RepeatButtonLinkDefaultHoverBrush = nameof(RepeatButtonLinkDefaultHoverBrush);

        public const string RepeatButtonLinkDefaultBorderThickness = nameof(RepeatButtonLinkDefaultBorderThickness);

        #endregion

        #region ToggleButton
        public const string ToggleButtonTemplate = nameof(ToggleButtonTemplate);

        public const string ToggleButtonDefaultCornerRadius = nameof(ToggleButtonDefaultCornerRadius);

        public const string ToggleButtonDefaultClickStyle = nameof(ToggleButtonDefaultClickStyle);

        public const string ToggleButtonDefaultIconPosition = nameof(ToggleButtonDefaultIconPosition);

        public const string ToggleButtonDefaultWaitingContent = nameof(ToggleButtonDefaultWaitingContent);




        public const string ToggleButtonStandardDefaultBackground = nameof(ToggleButtonStandardDefaultBackground);

        public const string ToggleButtonStandardDefaultForeground = nameof(ToggleButtonStandardDefaultForeground);

        public const string ToggleButtonStandardDefaultBorderBrush = nameof(ToggleButtonStandardDefaultBorderBrush);

        public const string ToggleButtonStandardDefaultHoverBrush = nameof(ToggleButtonStandardDefaultHoverBrush);

        public const string ToggleButtonStandardDefaultBorderThickness = nameof(ToggleButtonStandardDefaultBorderThickness);

        public const string ToggleButtonStandardCheckedBrush = nameof(ToggleButtonStandardCheckedBrush);



        public const string ToggleButtonOutlineDefaultBackground = nameof(ToggleButtonOutlineDefaultBackground);

        public const string ToggleButtonOutlineDefaultForeground = nameof(ToggleButtonOutlineDefaultForeground);

        public const string ToggleButtonOutlineDefaultBorderBrush = nameof(ToggleButtonOutlineDefaultBorderBrush);

        public const string ToggleButtonOutlineDefaultHoverBrush = nameof(ToggleButtonOutlineDefaultHoverBrush);

        public const string ToggleButtonOutlineDefaultBorderThickness = nameof(ToggleButtonOutlineDefaultBorderThickness);

        public const string ToggleButtonOutlineCheckedBrush = nameof(ToggleButtonOutlineCheckedBrush);



        public const string ToggleButtonHollowDefaultBackground = nameof(ToggleButtonHollowDefaultBackground);

        public const string ToggleButtonHollowDefaultForeground = nameof(ToggleButtonHollowDefaultForeground);

        public const string ToggleButtonHollowDefaultBorderBrush = nameof(ToggleButtonHollowDefaultBorderBrush);

        public const string ToggleButtonHollowDefaultHoverBrush = nameof(ToggleButtonHollowDefaultHoverBrush);

        public const string ToggleButtonHollowDefaultBorderThickness = nameof(ToggleButtonHollowDefaultBorderThickness);

        public const string ToggleButtonHollowCheckedBrush = nameof(ToggleButtonHollowCheckedBrush);



        public const string ToggleButtonLinkDefaultBackground = nameof(ToggleButtonLinkDefaultBackground);

        public const string ToggleButtonLinkDefaultForeground = nameof(ToggleButtonLinkDefaultForeground);

        public const string ToggleButtonLinkDefaultBorderBrush = nameof(ToggleButtonLinkDefaultBorderBrush);

        public const string ToggleButtonLinkDefaultHoverBrush = nameof(ToggleButtonLinkDefaultHoverBrush);

        public const string ToggleButtonLinkDefaultBorderThickness = nameof(ToggleButtonLinkDefaultBorderThickness);

        public const string ToggleButtonLinkCheckedBrush = nameof(ToggleButtonLinkCheckedBrush);

        #endregion

        #region Card
        public const string CardDefaultShadowColor = nameof(CardDefaultShadowColor);

        public const string CardDefaultCornerRadius = nameof(CardDefaultCornerRadius);

        public const string CardStandardVerticalTemplate = nameof(CardStandardVerticalTemplate);

        public const string CardStandardHorizontalTemplate = nameof(CardStandardHorizontalTemplate);

        public const string CardStandardDefaultBackground = nameof(CardStandardDefaultBackground);

        public const string CardStandardDefaultBorderBrush = nameof(CardStandardDefaultBorderBrush);

        public const string CardStandardDefaultBorderThickness = nameof(CardStandardDefaultBorderThickness);


        #endregion

        #region CheckBox
        public const string CheckBoxStandardTemplate = nameof(CheckBoxStandardTemplate);

        public const string CheckBoxSwitchTemplate = nameof(CheckBoxSwitchTemplate);

        public const string CheckBoxSwitch2Template = nameof(CheckBoxSwitch2Template);

        public const string CheckBoxSwitch3Template = nameof(CheckBoxSwitch3Template);

        public const string CheckBoxButtonTemplate = nameof(CheckBoxButtonTemplate);

        public const string CheckBoxSelectorTemplate = nameof(CheckBoxSelectorTemplate);

        public const string CheckBoxBranchTemplate = nameof(CheckBoxBranchTemplate);



        public const string CheckBoxStandardDefaultCornerRadius = nameof(CheckBoxStandardDefaultCornerRadius);

        public const string CheckBoxStandardDefaultBoxHeight = nameof(CheckBoxStandardDefaultBoxHeight);

        public const string CheckBoxStandardDefaultBoxWidth = nameof(CheckBoxStandardDefaultBoxWidth);

        public const string CheckBoxStandardDefaultBackground = nameof(CheckBoxStandardDefaultBackground);

        public const string CheckBoxStandardDefaultBorderBrush = nameof(CheckBoxStandardDefaultBorderBrush);

        public const string CheckBoxStandardDefaultBorderThickness = nameof(CheckBoxStandardDefaultBorderThickness);

        public const string CheckBoxStandardDefaultCheckedBackground = nameof(CheckBoxStandardDefaultCheckedBackground);

        public const string CheckBoxStandardDefaultGlyphBrush = nameof(CheckBoxStandardDefaultGlyphBrush);

        public const string CheckBoxStandardDefaultCheckedGlyphBrush = nameof(CheckBoxStandardDefaultCheckedGlyphBrush);

        public const string CheckBoxStandardDefaultCheckedBorderBrush = nameof(CheckBoxStandardDefaultCheckedBorderBrush);


        public const string CheckBoxSwitchDefaultCornerRadius = nameof(CheckBoxSwitchDefaultCornerRadius);

        public const string CheckBoxSwitchDefaultBoxHeight = nameof(CheckBoxSwitchDefaultBoxHeight);

        public const string CheckBoxSwitchDefaultBoxWidth = nameof(CheckBoxSwitchDefaultBoxWidth);

        public const string CheckBoxSwitchDefaultBackground = nameof(CheckBoxSwitchDefaultBackground);

        public const string CheckBoxSwitchDefaultBorderBrush = nameof(CheckBoxSwitchDefaultBorderBrush);

        public const string CheckBoxSwitchDefaultBorderThickness = nameof(CheckBoxSwitchDefaultBorderThickness);

        public const string CheckBoxSwitchDefaultCheckedBackground = nameof(CheckBoxSwitchDefaultCheckedBackground);

        public const string CheckBoxSwitchDefaultGlyphBrush = nameof(CheckBoxSwitchDefaultGlyphBrush);

        public const string CheckBoxSwitchDefaultCheckedGlyphBrush = nameof(CheckBoxSwitchDefaultCheckedGlyphBrush);

        public const string CheckBoxSwitchDefaultCheckedBorderBrush = nameof(CheckBoxSwitchDefaultCheckedBorderBrush);


        public const string CheckBoxSwitch2DefaultCornerRadius = nameof(CheckBoxSwitch2DefaultCornerRadius);

        public const string CheckBoxSwitch2DefaultBoxHeight = nameof(CheckBoxSwitch2DefaultBoxHeight);

        public const string CheckBoxSwitch2DefaultBoxWidth = nameof(CheckBoxSwitch2DefaultBoxWidth);

        public const string CheckBoxSwitch2DefaultBackground = nameof(CheckBoxSwitch2DefaultBackground);

        public const string CheckBoxSwitch2DefaultBorderBrush = nameof(CheckBoxSwitch2DefaultBorderBrush);

        public const string CheckBoxSwitch2DefaultBorderThickness = nameof(CheckBoxSwitch2DefaultBorderThickness);

        public const string CheckBoxSwitch2DefaultCheckedBackground = nameof(CheckBoxSwitch2DefaultCheckedBackground);

        public const string CheckBoxSwitch2DefaultGlyphBrush = nameof(CheckBoxSwitch2DefaultGlyphBrush);

        public const string CheckBoxSwitch2DefaultCheckedGlyphBrush = nameof(CheckBoxSwitch2DefaultCheckedGlyphBrush);

        public const string CheckBoxSwitch2DefaultCheckedBorderBrush = nameof(CheckBoxSwitch2DefaultCheckedBorderBrush);



        public const string CheckBoxSwitch3DefaultCornerRadius = nameof(CheckBoxSwitch3DefaultCornerRadius);

        public const string CheckBoxSwitch3DefaultBoxHeight = nameof(CheckBoxSwitch3DefaultBoxHeight);

        public const string CheckBoxSwitch3DefaultBoxWidth = nameof(CheckBoxSwitch3DefaultBoxWidth);

        public const string CheckBoxSwitch3DefaultBackground = nameof(CheckBoxSwitch3DefaultBackground);

        public const string CheckBoxSwitch3DefaultBorderBrush = nameof(CheckBoxSwitch3DefaultBorderBrush);

        public const string CheckBoxSwitch3DefaultBorderThickness = nameof(CheckBoxSwitch3DefaultBorderThickness);

        public const string CheckBoxSwitch3DefaultCheckedBackground = nameof(CheckBoxSwitch3DefaultCheckedBackground);

        public const string CheckBoxSwitch3DefaultGlyphBrush = nameof(CheckBoxSwitch3DefaultGlyphBrush);

        public const string CheckBoxSwitch3DefaultCheckedGlyphBrush = nameof(CheckBoxSwitch3DefaultCheckedGlyphBrush);

        public const string CheckBoxSwitch3DefaultCheckedBorderBrush = nameof(CheckBoxSwitch3DefaultCheckedBorderBrush);


        public const string CheckBoxButtonDefaultCornerRadius = nameof(CheckBoxButtonDefaultCornerRadius);

        public const string CheckBoxButtonDefaultBoxHeight = nameof(CheckBoxButtonDefaultBoxHeight);

        public const string CheckBoxButtonDefaultBoxWidth = nameof(CheckBoxButtonDefaultBoxWidth);

        public const string CheckBoxButtonDefaultBackground = nameof(CheckBoxButtonDefaultBackground);

        public const string CheckBoxButtonDefaultBorderBrush = nameof(CheckBoxButtonDefaultBorderBrush);

        public const string CheckBoxButtonDefaultBorderThickness = nameof(CheckBoxButtonDefaultBorderThickness);

        public const string CheckBoxButtonDefaultCheckedBackground = nameof(CheckBoxButtonDefaultCheckedBackground);

        public const string CheckBoxButtonDefaultGlyphBrush = nameof(CheckBoxButtonDefaultGlyphBrush);

        public const string CheckBoxButtonDefaultCheckedGlyphBrush = nameof(CheckBoxButtonDefaultCheckedGlyphBrush);

        public const string CheckBoxButtonDefaultCheckedBorderBrush = nameof(CheckBoxButtonDefaultCheckedBorderBrush);


        public const string CheckBoxSelectorDefaultCornerRadius = nameof(CheckBoxSelectorDefaultCornerRadius);

        public const string CheckBoxSelectorDefaultBoxHeight = nameof(CheckBoxSelectorDefaultBoxHeight);

        public const string CheckBoxSelectorDefaultBoxWidth = nameof(CheckBoxSelectorDefaultBoxWidth);

        public const string CheckBoxSelectorDefaultBackground = nameof(CheckBoxSelectorDefaultBackground);

        public const string CheckBoxSelectorDefaultBorderBrush = nameof(CheckBoxSelectorDefaultBorderBrush);

        public const string CheckBoxSelectorDefaultBorderThickness = nameof(CheckBoxSelectorDefaultBorderThickness);

        public const string CheckBoxSelectorDefaultCheckedBackground = nameof(CheckBoxSelectorDefaultCheckedBackground);

        public const string CheckBoxSelectorDefaultGlyphBrush = nameof(CheckBoxSelectorDefaultGlyphBrush);

        public const string CheckBoxSelectorDefaultCheckedGlyphBrush = nameof(CheckBoxSelectorDefaultCheckedGlyphBrush);

        public const string CheckBoxSelectorDefaultCheckedBorderBrush = nameof(CheckBoxSelectorDefaultCheckedBorderBrush);

        #endregion

        #region RadioButton
        public const string RadioButtonStandardTemplate = nameof(RadioButtonStandardTemplate);

        public const string RadioButtonSwitchTemplate = nameof(RadioButtonSwitchTemplate);

        public const string RadioButtonSwitch2Template = nameof(RadioButtonSwitch2Template);

        public const string RadioButtonSwitch3Template = nameof(RadioButtonSwitch3Template);

        public const string RadioButtonButtonTemplate = nameof(RadioButtonButtonTemplate);

        public const string RadioButtonSelectorTemplate = nameof(RadioButtonSelectorTemplate);

        public const string RadioButtonBranchTemplate = nameof(RadioButtonBranchTemplate);



        public const string RadioButtonStandardDefaultCornerRadius = nameof(RadioButtonStandardDefaultCornerRadius);

        public const string RadioButtonStandardDefaultBoxHeight = nameof(RadioButtonStandardDefaultBoxHeight);

        public const string RadioButtonStandardDefaultBoxWidth = nameof(RadioButtonStandardDefaultBoxWidth);

        public const string RadioButtonStandardDefaultBackground = nameof(RadioButtonStandardDefaultBackground);

        public const string RadioButtonStandardDefaultBorderBrush = nameof(RadioButtonStandardDefaultBorderBrush);

        public const string RadioButtonStandardDefaultBorderThickness = nameof(RadioButtonStandardDefaultBorderThickness);

        public const string RadioButtonStandardDefaultCheckedBackground = nameof(RadioButtonStandardDefaultCheckedBackground);

        public const string RadioButtonStandardDefaultGlyphBrush = nameof(RadioButtonStandardDefaultGlyphBrush);

        public const string RadioButtonStandardDefaultCheckedGlyphBrush = nameof(RadioButtonStandardDefaultCheckedGlyphBrush);

        public const string RadioButtonStandardDefaultCheckedBorderBrush = nameof(RadioButtonStandardDefaultCheckedBorderBrush);


        public const string RadioButtonSwitchDefaultCornerRadius = nameof(RadioButtonSwitchDefaultCornerRadius);

        public const string RadioButtonSwitchDefaultBoxHeight = nameof(RadioButtonSwitchDefaultBoxHeight);

        public const string RadioButtonSwitchDefaultBoxWidth = nameof(RadioButtonSwitchDefaultBoxWidth);

        public const string RadioButtonSwitchDefaultBackground = nameof(RadioButtonSwitchDefaultBackground);

        public const string RadioButtonSwitchDefaultBorderBrush = nameof(RadioButtonSwitchDefaultBorderBrush);

        public const string RadioButtonSwitchDefaultBorderThickness = nameof(RadioButtonSwitchDefaultBorderThickness);

        public const string RadioButtonSwitchDefaultCheckedBackground = nameof(RadioButtonSwitchDefaultCheckedBackground);

        public const string RadioButtonSwitchDefaultGlyphBrush = nameof(RadioButtonSwitchDefaultGlyphBrush);

        public const string RadioButtonSwitchDefaultCheckedGlyphBrush = nameof(RadioButtonSwitchDefaultCheckedGlyphBrush);

        public const string RadioButtonSwitchDefaultCheckedBorderBrush = nameof(RadioButtonSwitchDefaultCheckedBorderBrush);


        public const string RadioButtonSwitch2DefaultCornerRadius = nameof(RadioButtonSwitch2DefaultCornerRadius);

        public const string RadioButtonSwitch2DefaultBoxHeight = nameof(RadioButtonSwitch2DefaultBoxHeight);

        public const string RadioButtonSwitch2DefaultBoxWidth = nameof(RadioButtonSwitch2DefaultBoxWidth);

        public const string RadioButtonSwitch2DefaultBackground = nameof(RadioButtonSwitch2DefaultBackground);

        public const string RadioButtonSwitch2DefaultBorderBrush = nameof(RadioButtonSwitch2DefaultBorderBrush);

        public const string RadioButtonSwitch2DefaultBorderThickness = nameof(RadioButtonSwitch2DefaultBorderThickness);

        public const string RadioButtonSwitch2DefaultCheckedBackground = nameof(RadioButtonSwitch2DefaultCheckedBackground);

        public const string RadioButtonSwitch2DefaultGlyphBrush = nameof(RadioButtonSwitch2DefaultGlyphBrush);

        public const string RadioButtonSwitch2DefaultCheckedGlyphBrush = nameof(RadioButtonSwitch2DefaultCheckedGlyphBrush);

        public const string RadioButtonSwitch2DefaultCheckedBorderBrush = nameof(RadioButtonSwitch2DefaultCheckedBorderBrush);



        public const string RadioButtonSwitch3DefaultCornerRadius = nameof(RadioButtonSwitch3DefaultCornerRadius);

        public const string RadioButtonSwitch3DefaultBoxHeight = nameof(RadioButtonSwitch3DefaultBoxHeight);

        public const string RadioButtonSwitch3DefaultBoxWidth = nameof(RadioButtonSwitch3DefaultBoxWidth);

        public const string RadioButtonSwitch3DefaultBackground = nameof(RadioButtonSwitch3DefaultBackground);

        public const string RadioButtonSwitch3DefaultBorderBrush = nameof(RadioButtonSwitch3DefaultBorderBrush);

        public const string RadioButtonSwitch3DefaultBorderThickness = nameof(RadioButtonSwitch3DefaultBorderThickness);

        public const string RadioButtonSwitch3DefaultCheckedBackground = nameof(RadioButtonSwitch3DefaultCheckedBackground);

        public const string RadioButtonSwitch3DefaultGlyphBrush = nameof(RadioButtonSwitch3DefaultGlyphBrush);

        public const string RadioButtonSwitch3DefaultCheckedGlyphBrush = nameof(RadioButtonSwitch3DefaultCheckedGlyphBrush);

        public const string RadioButtonSwitch3DefaultCheckedBorderBrush = nameof(RadioButtonSwitch3DefaultCheckedBorderBrush);


        public const string RadioButtonButtonDefaultCornerRadius = nameof(RadioButtonButtonDefaultCornerRadius);

        public const string RadioButtonButtonDefaultBoxHeight = nameof(RadioButtonButtonDefaultBoxHeight);

        public const string RadioButtonButtonDefaultBoxWidth = nameof(RadioButtonButtonDefaultBoxWidth);

        public const string RadioButtonButtonDefaultBackground = nameof(RadioButtonButtonDefaultBackground);

        public const string RadioButtonButtonDefaultBorderBrush = nameof(RadioButtonButtonDefaultBorderBrush);

        public const string RadioButtonButtonDefaultBorderThickness = nameof(RadioButtonButtonDefaultBorderThickness);

        public const string RadioButtonButtonDefaultCheckedBackground = nameof(RadioButtonButtonDefaultCheckedBackground);

        public const string RadioButtonButtonDefaultGlyphBrush = nameof(RadioButtonButtonDefaultGlyphBrush);

        public const string RadioButtonButtonDefaultCheckedGlyphBrush = nameof(RadioButtonButtonDefaultCheckedGlyphBrush);

        public const string RadioButtonButtonDefaultCheckedBorderBrush = nameof(RadioButtonButtonDefaultCheckedBorderBrush);


        public const string RadioButtonSelectorDefaultCornerRadius = nameof(RadioButtonSelectorDefaultCornerRadius);

        public const string RadioButtonSelectorDefaultBoxHeight = nameof(RadioButtonSelectorDefaultBoxHeight);

        public const string RadioButtonSelectorDefaultBoxWidth = nameof(RadioButtonSelectorDefaultBoxWidth);

        public const string RadioButtonSelectorDefaultBackground = nameof(RadioButtonSelectorDefaultBackground);

        public const string RadioButtonSelectorDefaultBorderBrush = nameof(RadioButtonSelectorDefaultBorderBrush);

        public const string RadioButtonSelectorDefaultBorderThickness = nameof(RadioButtonSelectorDefaultBorderThickness);

        public const string RadioButtonSelectorDefaultCheckedBackground = nameof(RadioButtonSelectorDefaultCheckedBackground);

        public const string RadioButtonSelectorDefaultGlyphBrush = nameof(RadioButtonSelectorDefaultGlyphBrush);

        public const string RadioButtonSelectorDefaultCheckedGlyphBrush = nameof(RadioButtonSelectorDefaultCheckedGlyphBrush);

        public const string RadioButtonSelectorDefaultCheckedBorderBrush = nameof(RadioButtonSelectorDefaultCheckedBorderBrush);

        #endregion

        #region Loading
        public static readonly string LoadingStandardRectangleStyle = nameof(LoadingStandardRectangleStyle);

        public static readonly string LoadingStandardTemplate = nameof(LoadingStandardTemplate);

        public static readonly string LoadingWaveRectangleStyle = nameof(LoadingWaveRectangleStyle);

        public static readonly string LoadingWaveTemplate = nameof(LoadingWaveTemplate);

        public static readonly string LoadingRingTemplate = nameof(LoadingRingTemplate);

        public static readonly string LoadingRing2Template = nameof(LoadingRing2Template);

        public static readonly string LoadingClassicTemplate = nameof(LoadingClassicTemplate);

        public static readonly string LoadingForeground = nameof(LoadingForeground);

        public static readonly string LoadingBackground = nameof(LoadingBackground);

        public static readonly string LoadingClassicEllipseStyle = nameof(LoadingClassicEllipseStyle);
        #endregion

        #region TextBox
        public static readonly string TextBoxTemplate = nameof(TextBoxTemplate);

        public static readonly string TextBoxBorderBrush = nameof(TextBoxBorderBrush);

        public static readonly string TextBoxBorderThickness = nameof(TextBoxBorderThickness);

        public static readonly string TextBoxValidationErrorTemplate = nameof(TextBoxValidationErrorTemplate);

        public static readonly string TextBoxFocusedBorderBrush = nameof(TextBoxFocusedBorderBrush);

        public static readonly string TextBoxFocusedShadowColor = nameof(TextBoxFocusedShadowColor);

        public static readonly string TextBoxCornerRadius = nameof(TextBoxCornerRadius);
        #endregion

        #region PasswordBox
        public static readonly string PasswordBoxTemplate = nameof(PasswordBoxTemplate);

        public static readonly string PasswordBoxBorderBrush = nameof(PasswordBoxBorderBrush);

        public static readonly string PasswordBoxBorderThickness = nameof(PasswordBoxBorderThickness);

        public static readonly string PasswordBoxValidationErrorTemplate = nameof(PasswordBoxValidationErrorTemplate);

        public static readonly string PasswordBoxFocusedBorderBrush = nameof(PasswordBoxFocusedBorderBrush);

        public static readonly string PasswordBoxFocusedShadowColor = nameof(PasswordBoxFocusedShadowColor);

        public static readonly string PasswordBoxCornerRadius = nameof(PasswordBoxCornerRadius);
        #endregion

        #region ComboBox
        public static readonly string ComboBoxTemplate = nameof(ComboBoxTemplate);

        public static readonly string ComboBoxBorderBrush = nameof(ComboBoxBorderBrush);

        public static readonly string ComboBoxBorderThickness = nameof(ComboBoxBorderThickness);

        public static readonly string ComboBoxBackground = nameof(ComboBoxBackground);

        public static readonly string ComboBoxCornerRadius = nameof(ComboBoxCornerRadius);

        public static readonly string ComboBoxMaxDropDownHeight = nameof(ComboBoxMaxDropDownHeight);

        public static readonly string ComboBoxDropDownCornerRadius = nameof(ComboBoxDropDownCornerRadius);

        public static readonly string ComboBoxDropDownPadding = nameof(ComboBoxDropDownPadding);

        public static readonly string ComboBoxShadowColor = nameof(ComboBoxShadowColor);

        public static readonly string ComboBoxStandardToggleButtonTemplate = nameof(ComboBoxStandardToggleButtonTemplate);

        public static readonly string ComboBoxStandardToggleButtonStyle = nameof(ComboBoxStandardToggleButtonStyle);

        public static readonly string ComboBoxSimpleToggleButtonTemplate = nameof(ComboBoxSimpleToggleButtonTemplate);

        public static readonly string ComboBoxSimpleToggleButtonStyle = nameof(ComboBoxSimpleToggleButtonStyle);

        public static readonly string ComboBoxEditableTextBoxTemplate = nameof(ComboBoxEditableTextBoxTemplate);

        public static readonly string ComboBoxEditableTextBoxStyle = nameof(ComboBoxEditableTextBoxStyle);

        public static readonly string ComboBoxItemsHoverBackground = nameof(ComboBoxItemsHoverBackground);

        public static readonly string ComboBoxItemsHoverForeground = nameof(ComboBoxItemsHoverForeground);

        public static readonly string ComboBoxItemsHoverBorderBrush = nameof(ComboBoxItemsHoverBorderBrush);

        public static readonly string ComboBoxItemsSelectedBackground = nameof(ComboBoxItemsSelectedBackground);

        public static readonly string ComboBoxItemsSelectedForeground = nameof(ComboBoxItemsSelectedForeground);

        public static readonly string ComboBoxItemsSelectedBorderBrush = nameof(ComboBoxItemsSelectedBorderBrush);

        public static readonly string ComboBoxItemsHeight = nameof(ComboBoxItemsHeight);

        #region ComboBoxItem
        public static readonly string ComboBoxItemTemplate = nameof(ComboBoxItemTemplate);

        public static readonly string ComboBoxItemBackground = nameof(ComboBoxItemBackground);

        public static readonly string ComboBoxItemBorderBrush = nameof(ComboBoxItemBorderBrush);

        public static readonly string ComboBoxItemBorderThickness = nameof(ComboBoxItemBorderThickness);
        #endregion

        #endregion

        #region ScrollViewer
        public static readonly string ScrollViewerTemplate = nameof(ScrollViewerTemplate);

        public static readonly string ScrollViewerThumbTemplate = nameof(ScrollViewerThumbTemplate);

        public static readonly string ScrollViewerThumbStyle = nameof(ScrollViewerThumbStyle);

        public static readonly string ScrollViewerVerticalScrollBarTemplate = nameof(ScrollViewerVerticalScrollBarTemplate);

        public static readonly string ScrollViewerHorizontalScrollBarTemplate = nameof(ScrollViewerHorizontalScrollBarTemplate);

        public static readonly string ScrollViewerScrollBarStyle = nameof(ScrollViewerScrollBarStyle);

        #endregion

        #region TreeView
        public static readonly string TreeViewBorderBrush = nameof(TreeViewBorderBrush);

        public static readonly string TreeViewBorderThickness = nameof(TreeViewBorderThickness);

        public static readonly string TreeViewBackground = nameof(TreeViewBackground);

        public static readonly string TreeViewItemStandardTemplate = nameof(TreeViewItemStandardTemplate);

        public static readonly string TreeViewItemModernTemplate = nameof(TreeViewItemModernTemplate);

        public static readonly string TreeViewItemChainTemplate = nameof(TreeViewItemChainTemplate);

        public static readonly string TreeViewStandardItemsHoverBackground = nameof(TreeViewStandardItemsHoverBackground);

        public static readonly string TreeViewStandardHoverForeground = nameof(TreeViewStandardHoverForeground);

        public static readonly string TreeViewStandardItemsToggleBrush = nameof(TreeViewStandardItemsToggleBrush);

        public static readonly string TreeViewStandardItemsHoverToggleBrush = nameof(TreeViewStandardItemsHoverToggleBrush);

        public static readonly string TreeViewStandardItemsSelectedBackground = nameof(TreeViewStandardItemsSelectedBackground);

        public static readonly string TreeViewStandardSelectedForeground = nameof(TreeViewStandardSelectedForeground);

        public static readonly string TreeViewStandardItemHeight = nameof(TreeViewStandardItemHeight);

        public static readonly string TreeViewStandardItemPadding = nameof(TreeViewStandardItemPadding);

        public static readonly string TreeViewStandardToggleButtonStyle = nameof(TreeViewStandardToggleButtonStyle);

        public static readonly string TreeViewModernItemsHoverBackground = nameof(TreeViewModernItemsHoverBackground);

        public static readonly string TreeViewModernHoverForeground = nameof(TreeViewModernHoverForeground);

        public static readonly string TreeViewModernItemsToggleBrush = nameof(TreeViewModernItemsToggleBrush);

        public static readonly string TreeViewModernItemsHoverToggleBrush = nameof(TreeViewModernItemsHoverToggleBrush);

        public static readonly string TreeViewModernItemsSelectedToggleBrush = nameof(TreeViewModernItemsSelectedToggleBrush);
        
        public static readonly string TreeViewModernItemsSelectedBackground = nameof(TreeViewModernItemsSelectedBackground);

        public static readonly string TreeViewModernSelectedForeground = nameof(TreeViewModernSelectedForeground);

        public static readonly string TreeViewModernItemHeight = nameof(TreeViewModernItemHeight);

        public static readonly string TreeViewModernItemPadding = nameof(TreeViewModernItemPadding);

        public static readonly string TreeViewModernToggleButtonStyle = nameof(TreeViewModernToggleButtonStyle);

        public static readonly string TreeViewChainItemsHoverBackground = nameof(TreeViewChainItemsHoverBackground);

        public static readonly string TreeViewChainHoverForeground = nameof(TreeViewChainHoverForeground);

        public static readonly string TreeViewChainItemsToggleBrush = nameof(TreeViewChainItemsToggleBrush);

        public static readonly string TreeViewChainItemsHoverToggleBrush = nameof(TreeViewChainItemsHoverToggleBrush);

        public static readonly string TreeViewChainItemsSelectedBackground = nameof(TreeViewChainItemsSelectedBackground);

        public static readonly string TreeViewChainSelectedForeground = nameof(TreeViewChainSelectedForeground);

        public static readonly string TreeViewChainItemHeight = nameof(TreeViewChainItemHeight);

        public static readonly string TreeViewChainItemPadding = nameof(TreeViewChainItemPadding);

        public static readonly string TreeViewChainToggleButtonStyle = nameof(TreeViewChainToggleButtonStyle);
        #endregion

        #region TabControl
        public static readonly string TabControlBorderBrush = nameof(TabControlBorderBrush);

        public static readonly string TabControlBorderThickness = nameof(TabControlBorderThickness);

        public static readonly string TabControlPadding = nameof(TabControlPadding);

        public static readonly string TabControlBackground = nameof(TabControlBackground);

        public static readonly string TabControlStandardTopTemplate = nameof(TabControlStandardTopTemplate);

        public static readonly string TabControlStandardBottomTemplate = nameof(TabControlStandardBottomTemplate);

        public static readonly string TabControlStandardLeftTemplate = nameof(TabControlStandardLeftTemplate);

        public static readonly string TabControlStandardRightTemplate = nameof(TabControlStandardRightTemplate);

        public static readonly string TabControlExpandableTopTemplate = nameof(TabControlExpandableTopTemplate);

        public static readonly string TabControlExpandableBottomTemplate = nameof(TabControlExpandableBottomTemplate);

        public static readonly string TabControlExpandableLeftTemplate = nameof(TabControlExpandableLeftTemplate);

        public static readonly string TabControlExpandableRightTemplate = nameof(TabControlExpandableRightTemplate);

        public static readonly string TabControlScrollableTopTemplate = nameof(TabControlScrollableTopTemplate);

        public static readonly string TabControlScrollableBottomTemplate = nameof(TabControlScrollableBottomTemplate);

        public static readonly string TabControlScrollableLeftTemplate = nameof(TabControlScrollableLeftTemplate);

        public static readonly string TabControlScrollableRightTemplate = nameof(TabControlScrollableRightTemplate);

        public static readonly string TabItemStandardTemplate = nameof(TabItemStandardTemplate);

        public static readonly string TabItemModernTemplate = nameof(TabItemModernTemplate);

        public static readonly string TabItemModern2Template = nameof(TabItemModern2Template);

        public static readonly string TabItemCardTemplate = nameof(TabItemCardTemplate);

        #endregion

        #region DropDown
        public static readonly string DropDownStandardTemplate = nameof(DropDownStandardTemplate);

        public static readonly string DropDownToggleButtonTemplate = nameof(DropDownToggleButtonTemplate);

        public static readonly string DropDownToggleButtonStyle = nameof(DropDownToggleButtonStyle);


        #endregion


        #region ListBox
        public static readonly string ListBoxBorderBrush = nameof(ListBoxBorderBrush);

        public static readonly string ListBoxBorderThickness = nameof(ListBoxBorderThickness);

        public static readonly string ListBoxBackground = nameof(ListBoxBackground);

        public static readonly string ListBoxItemsHoverBackground = nameof(ListBoxItemsHoverBackground);

        public static readonly string ListBoxItemsSelectedBackground = nameof(ListBoxItemsSelectedBackground);
        #endregion

        #region MsgBox
        public static readonly string MsgBoxButtonStyle = nameof(MsgBoxButtonStyle);

        public static readonly string MsgBoxTextBoxStyle = nameof(MsgBoxTextBoxStyle);

        public static readonly string MsgBoxStandardContent = nameof(MsgBoxStandardContent);

        public static readonly string MsgBoxClassicContent = nameof(MsgBoxClassicContent);

        public static readonly string MsgBoxModernContent = nameof(MsgBoxModernContent);

        #endregion

        #region CalendarX
        public static readonly string CalendarXBorderBrush = nameof(CalendarXBorderBrush);

        public static readonly string CalendarXBorderThickness = nameof(CalendarXBorderThickness);

        public static readonly string CalendarXThemeBrush = nameof(CalendarXThemeBrush);

        public static readonly string CalendarXTemplate = nameof(CalendarXTemplate);

        public static readonly string CalendarXHeaderPanelHeight = nameof(CalendarXHeaderPanelHeight);

        public static readonly string CalendarXHeaderPanelBackground = nameof(CalendarXHeaderPanelBackground);
        #endregion

        #region Clock
        public static readonly string ClockTemplate = nameof(ClockTemplate);

        public static readonly string ClockThemeBrush = nameof(ClockThemeBrush);

        public static readonly string ClockBorderBrush = nameof(ClockBorderBrush);

        public static readonly string ClockBorderThickness = nameof(ClockBorderThickness);

        public static readonly string ClockBackground = nameof(ClockBackground);

        public static readonly string ClockItemsControlStyle = nameof(ClockItemsControlStyle);
        
        #endregion

        #region GroupBox
        public static readonly string GroupBoxStandardTemplate = nameof(GroupBoxStandardTemplate);


        public static readonly string GroupBoxStandardBorderBrush = nameof(GroupBoxStandardBorderBrush);

        public static readonly string GroupBoxStandardBorderThickness = nameof(GroupBoxStandardBorderThickness);

        public static readonly string GroupBoxStandardBackground = nameof(GroupBoxStandardBackground);

        public static readonly string GroupBoxPostTemplate = nameof(GroupBoxPostTemplate);

        public static readonly string GroupBoxPostBorderBrush = nameof(GroupBoxPostBorderBrush);

        public static readonly string GroupBoxPostBorderThickness = nameof(GroupBoxPostBorderThickness);

        public static readonly string GroupBoxPostBackground = nameof(GroupBoxPostBackground);

        public static readonly string GroupBoxFootnoteTemplate = nameof(GroupBoxFootnoteTemplate);

        public static readonly string GroupBoxFootnoteBorderBrush = nameof(GroupBoxFootnoteBorderBrush);

        public static readonly string GroupBoxFootnoteBorderThickness = nameof(GroupBoxFootnoteBorderThickness);

        public static readonly string GroupBoxFootnoteBackground = nameof(GroupBoxFootnoteBackground);
        #endregion

        #region ListBox
        public static readonly string ListBoxStandardTemplate = nameof(ListBoxStandardTemplate);

        public static readonly string ListBoxItemStandardTemplate = nameof(ListBoxItemStandardTemplate);

        public static readonly string ListBoxItemStandardBorderBrush = nameof(ListBoxItemStandardBorderBrush);

        public static readonly string ListBoxItemStandardBorderThickness = nameof(ListBoxItemStandardBorderThickness);

        public static readonly string ListBoxItemStandardBackground = nameof(ListBoxItemStandardBackground);

        #endregion

        #region DataGrid
        public static readonly string DataGridBorderBrush = nameof(DataGridBorderBrush);

        public static readonly string DataGridBorderThickness = nameof(DataGridBorderThickness);

        public static readonly string DataGridBackground = nameof(DataGridBackground);

        public static readonly string DataGridHorizontalGridLinesBrush = nameof(DataGridHorizontalGridLinesBrush);

        public static readonly string DataGridMinRowHeight = nameof(DataGridMinRowHeight);

        public static readonly string DataGridColumnHeaderHeight = nameof(DataGridColumnHeaderHeight);

        public static readonly string DataGridResizeThumbTemplate = nameof(DataGridResizeThumbTemplate);

        public static readonly string DataGridResizeThumbStyle = nameof(DataGridResizeThumbStyle);

        public static readonly string DataGridSelectAllButtonTemplate = nameof(DataGridSelectAllButtonTemplate);

        public static readonly string DataGridScrollViewerTemplate = nameof(DataGridScrollViewerTemplate);

        public static readonly string DataGridColumnHeaderTemplate = nameof(DataGridColumnHeaderTemplate);

        public static readonly string DataGridRowHeaderTemplate = nameof(DataGridRowHeaderTemplate);

        public static readonly string DataGridRowTemplate = nameof(DataGridRowTemplate);

        public static readonly string DataGridCellTemplate = nameof(DataGridCellTemplate);

        public static readonly string DataGridStandardTemplate = nameof(DataGridStandardTemplate);
        #endregion

        #region Pagination

        public static readonly string PaginationTemplate = nameof(PaginationTemplate);

        #endregion

        #region CarouselViewer
        public static readonly string CarouselViewerIndicatorStyle = nameof(CarouselViewerIndicatorStyle);

        public static readonly string CarouselViewerHorizontalTemplate = nameof(CarouselViewerHorizontalTemplate);
     
        public static readonly string CarouselViewerSideButtonStyle = nameof(CarouselViewerSideButtonStyle);
       
        public static readonly string CarouselViewerVerticalTemplate = nameof(CarouselViewerVerticalTemplate);

        #endregion

        #region Drawer
        public static readonly string DrawerTemplate = nameof(DrawerTemplate);
        #endregion
    }
}
