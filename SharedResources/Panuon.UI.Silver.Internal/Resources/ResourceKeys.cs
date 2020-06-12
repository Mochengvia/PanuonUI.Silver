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


        public const string NullToVisibleConverter = nameof(NullToVisibleConverter);

        public const string NullOrEmptyToVisibleConverter = nameof(NullOrEmptyToVisibleConverter);

        public const string NullToCollapseConverter = nameof(NullToCollapseConverter);

        public const string NullOrEmptyToCollapseConverter = nameof(NullOrEmptyToCollapseConverter);

        public const string IsNullConverter = nameof(IsNullConverter);

        public const string IsNotNullConverter = nameof(IsNotNullConverter);

        public const string IsNullOrEmptyConverter = nameof(IsNullOrEmptyConverter);

        public const string HoverBrushConverter = nameof(HoverBrushConverter);

        public const string IconPositionToOrientationConverter = nameof(IconPositionToOrientationConverter);

        public const string BrushToColorConverter = nameof(BrushToColorConverter);

        public const string GridLengthConverter = nameof(GridLengthConverter);

        public const string GridLengthStringToDoubleConverter = nameof(GridLengthStringToDoubleConverter);

        public const string GridLengthIsAbsoluteOrAutoConverter = nameof(GridLengthIsAbsoluteOrAutoConverter);

        public const string DoubleMinConverter = nameof(DoubleMinConverter);

        public const string DoubleEqualsConverter = nameof(DoubleEqualsConverter);

        public const string DoubleToLeftMarginConverter = nameof(DoubleToLeftMarginConverter);

        public const string DoubleToRightMarginConverter = nameof(DoubleToRightMarginConverter);

        public const string DoubleToTopMarginConverter = nameof(DoubleToTopMarginConverter);

        public const string DoubleToBottomMarginConverter = nameof(DoubleToBottomMarginConverter);

        public const string DoubleLimitMin1Converter = nameof(DoubleLimitMin1Converter);
        
        public const string IsGreaterThanZeroConverter = nameof(IsGreaterThanZeroConverter);

        public const string IsLessThanZeroConverter = nameof(IsLessThanZeroConverter);

        public const string ArcConverter = nameof(ArcConverter);

        public const string TreeViewPaddingConverter = nameof(TreeViewPaddingConverter);

        public const string TreeViewChainHorizontalMarginConverter = nameof(TreeViewChainHorizontalMarginConverter);

        public const string TreeViewChainVerticalMarginConverter = nameof(TreeViewChainVerticalMarginConverter);
        
        public const string CornerRadiusToDoubleConverter = nameof(CornerRadiusToDoubleConverter);

        public const string CornerRadiusWithLeftOnlyConverter = nameof(CornerRadiusWithLeftOnlyConverter);

        public const string CornerRadiusWithRightOnlyConverter = nameof(CornerRadiusWithRightOnlyConverter);

        public const string CornerRadiusWithTopOnlyConverter = nameof(CornerRadiusWithTopOnlyConverter);

        public const string CornerRadiusWithBottomOnlyConverter = nameof(CornerRadiusWithBottomOnlyConverter);
        
        public const string ThicknessToDoubleConverter = nameof(ThicknessToDoubleConverter);

        public const string ThicknessWithoutTopConverter = nameof(ThicknessWithoutTopConverter);

        public const string ThicknessWithTopOnlyConverter = nameof(ThicknessWithTopOnlyConverter);

        public const string ThicknessWithBottomOnlyConverter = nameof(ThicknessWithBottomOnlyConverter);

        public const string ThicknessWithLeftOnlyConverter = nameof(ThicknessWithLeftOnlyConverter);

        public const string ThicknessWithRightOnlyConverter = nameof(ThicknessWithRightOnlyConverter);

        public const string CheckBoxStandardGlyphPathConverter = nameof(CheckBoxStandardGlyphPathConverter);

        public const string CheckBoxSwitchToggleMarginConverter = nameof(CheckBoxSwitchToggleMarginConverter);

        public const string CheckBoxSwitch2DecorationMarginConverter = nameof(CheckBoxSwitch2DecorationMarginConverter);

        public const string CheckBoxSwitch3ToggleMarginConverter = nameof(CheckBoxSwitch3ToggleMarginConverter);

        public const string CheckBoxSwitch3ToggleTrackMarginConverter = nameof(CheckBoxSwitch3ToggleTrackMarginConverter);

        public const string NullableColorToColorConverter = nameof(NullableColorToColorConverter);

        public const string NullableColorToShadowEffectConverter = nameof(NullableColorToShadowEffectConverter);

        public const string CombineToArrayConverter = nameof(CombineToArrayConverter);

        public const string DropDownPathDataConverter = nameof(DropDownPathDataConverter);
        #endregion

        #region Common
        public const string DefaultForegroundColor = nameof(DefaultForegroundColor);
        #endregion

        #region WindowX
        public const string WindowXStyle = nameof(WindowXStyle);

        public const string WindowXTemplate = nameof(WindowXTemplate);

        public const string WindowXToolWindowTemplate = nameof(WindowXToolWindowTemplate);

        public const string WindowXDefaultHeader = nameof(WindowXDefaultHeader);

        public const string WindowXCaptionForeground = nameof(WindowXCaptionForeground);

        public const string WindowXCaptionBackground = nameof(WindowXCaptionBackground);

        public const string WindowXCaptionHeight = nameof(WindowXCaptionHeight);

        public const string WindowXCaptionHorizontalHeaderAlignment = nameof(WindowXCaptionHorizontalHeaderAlignment);

        public const string WindowXCaptionMinimizeButtonHoverBrush = nameof(WindowXCaptionMinimizeButtonHoverBrush);

        public const string WindowXCaptionMaximizeButtonHoverBrush = nameof(WindowXCaptionMaximizeButtonHoverBrush);

        public const string WindowXCaptionCloseButtonHoverBrush = nameof(WindowXCaptionCloseButtonHoverBrush);


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
        public const string LoadingStandardRectangleStyle = nameof(LoadingStandardRectangleStyle);

        public const string LoadingStandardTemplate = nameof(LoadingStandardTemplate);

        public const string LoadingWaveRectangleStyle = nameof(LoadingWaveRectangleStyle);

        public const string LoadingWaveTemplate = nameof(LoadingWaveTemplate);

        public const string LoadingRingTemplate = nameof(LoadingRingTemplate);

        public const string LoadingRing2Template = nameof(LoadingRing2Template);

        public const string LoadingClassicTemplate = nameof(LoadingClassicTemplate);

        public const string LoadingForeground = nameof(LoadingForeground);

        public const string LoadingBackground = nameof(LoadingBackground);

        public const string LoadingClassicEllipseStyle = nameof(LoadingClassicEllipseStyle);
        #endregion

        #region TextBox
        public const string TextBoxTemplate = nameof(TextBoxTemplate);

        public const string TextBoxBorderBrush = nameof(TextBoxBorderBrush);

        public const string TextBoxBorderThickness = nameof(TextBoxBorderThickness);

        public const string TextBoxValidationErrorTemplate = nameof(TextBoxValidationErrorTemplate);

        public const string TextBoxFocusedBorderBrush = nameof(TextBoxFocusedBorderBrush);

        public const string TextBoxFocusedShadowColor = nameof(TextBoxFocusedShadowColor);

        public const string TextBoxCornerRadius = nameof(TextBoxCornerRadius);
        #endregion

        #region PasswordBox
        public const string PasswordBoxTemplate = nameof(PasswordBoxTemplate);

        public const string PasswordBoxBorderBrush = nameof(PasswordBoxBorderBrush);

        public const string PasswordBoxBorderThickness = nameof(PasswordBoxBorderThickness);

        public const string PasswordBoxValidationErrorTemplate = nameof(PasswordBoxValidationErrorTemplate);

        public const string PasswordBoxFocusedBorderBrush = nameof(PasswordBoxFocusedBorderBrush);

        public const string PasswordBoxFocusedShadowColor = nameof(PasswordBoxFocusedShadowColor);

        public const string PasswordBoxCornerRadius = nameof(PasswordBoxCornerRadius);
        #endregion

        #region ComboBox
        public const string ComboBoxTemplate = nameof(ComboBoxTemplate);

        public const string ComboBoxBorderBrush = nameof(ComboBoxBorderBrush);

        public const string ComboBoxBorderThickness = nameof(ComboBoxBorderThickness);

        public const string ComboBoxBackground = nameof(ComboBoxBackground);

        public const string ComboBoxCornerRadius = nameof(ComboBoxCornerRadius);

        public const string ComboBoxMaxDropDownHeight = nameof(ComboBoxMaxDropDownHeight);

        public const string ComboBoxDropDownCornerRadius = nameof(ComboBoxDropDownCornerRadius);

        public const string ComboBoxDropDownPadding = nameof(ComboBoxDropDownPadding);

        public const string ComboBoxDropDownShadowColor = nameof(ComboBoxDropDownShadowColor);

        public const string ComboBoxStandardToggleButtonTemplate = nameof(ComboBoxStandardToggleButtonTemplate);

        public const string ComboBoxStandardToggleButtonStyle = nameof(ComboBoxStandardToggleButtonStyle);

        public const string ComboBoxSimpleToggleButtonTemplate = nameof(ComboBoxSimpleToggleButtonTemplate);

        public const string ComboBoxSimpleToggleButtonStyle = nameof(ComboBoxSimpleToggleButtonStyle);

        public const string ComboBoxEditableTextBoxTemplate = nameof(ComboBoxEditableTextBoxTemplate);

        public const string ComboBoxEditableTextBoxStyle = nameof(ComboBoxEditableTextBoxStyle);

        public const string ComboBoxItemsHoverBackground = nameof(ComboBoxItemsHoverBackground);

        public const string ComboBoxItemsHoverForeground = nameof(ComboBoxItemsHoverForeground);

        public const string ComboBoxItemsHoverBorderBrush = nameof(ComboBoxItemsHoverBorderBrush);

        public const string ComboBoxItemsSelectedBackground = nameof(ComboBoxItemsSelectedBackground);

        public const string ComboBoxItemsSelectedForeground = nameof(ComboBoxItemsSelectedForeground);

        public const string ComboBoxItemsSelectedBorderBrush = nameof(ComboBoxItemsSelectedBorderBrush);

        public const string ComboBoxItemsHeight = nameof(ComboBoxItemsHeight);

        #region ComboBoxItem
        public const string ComboBoxItemTemplate = nameof(ComboBoxItemTemplate);

        public const string ComboBoxItemBackground = nameof(ComboBoxItemBackground);

        public const string ComboBoxItemBorderBrush = nameof(ComboBoxItemBorderBrush);

        public const string ComboBoxItemBorderThickness = nameof(ComboBoxItemBorderThickness);
        #endregion

        #endregion

        #region ScrollViewer
        public const string ScrollViewerTemplate = nameof(ScrollViewerTemplate);

        public const string ScrollViewerThumbTemplate = nameof(ScrollViewerThumbTemplate);

        public const string ScrollViewerThumbStyle = nameof(ScrollViewerThumbStyle);

        public const string ScrollViewerVerticalScrollBarTemplate = nameof(ScrollViewerVerticalScrollBarTemplate);

        public const string ScrollViewerHorizontalScrollBarTemplate = nameof(ScrollViewerHorizontalScrollBarTemplate);

        public const string ScrollViewerScrollBarStyle = nameof(ScrollViewerScrollBarStyle);

        #endregion

        #region TreeView
        public const string TreeViewBorderBrush = nameof(TreeViewBorderBrush);

        public const string TreeViewBorderThickness = nameof(TreeViewBorderThickness);

        public const string TreeViewBackground = nameof(TreeViewBackground);

        public const string TreeViewItemStandardTemplate = nameof(TreeViewItemStandardTemplate);

        public const string TreeViewItemModernTemplate = nameof(TreeViewItemModernTemplate);

        public const string TreeViewItemChainTemplate = nameof(TreeViewItemChainTemplate);

        public const string TreeViewStandardItemsHoverBackground = nameof(TreeViewStandardItemsHoverBackground);

        public const string TreeViewStandardHoverForeground = nameof(TreeViewStandardHoverForeground);

        public const string TreeViewStandardItemsToggleBrush = nameof(TreeViewStandardItemsToggleBrush);

        public const string TreeViewStandardItemsHoverToggleBrush = nameof(TreeViewStandardItemsHoverToggleBrush);

        public const string TreeViewStandardItemsSelectedBackground = nameof(TreeViewStandardItemsSelectedBackground);

        public const string TreeViewStandardSelectedForeground = nameof(TreeViewStandardSelectedForeground);

        public const string TreeViewStandardItemHeight = nameof(TreeViewStandardItemHeight);

        public const string TreeViewStandardItemPadding = nameof(TreeViewStandardItemPadding);

        public const string TreeViewStandardToggleButtonStyle = nameof(TreeViewStandardToggleButtonStyle);

        public const string TreeViewModernItemsHoverBackground = nameof(TreeViewModernItemsHoverBackground);

        public const string TreeViewModernHoverForeground = nameof(TreeViewModernHoverForeground);

        public const string TreeViewModernItemsToggleBrush = nameof(TreeViewModernItemsToggleBrush);

        public const string TreeViewModernItemsHoverToggleBrush = nameof(TreeViewModernItemsHoverToggleBrush);

        public const string TreeViewModernItemsSelectedToggleBrush = nameof(TreeViewModernItemsSelectedToggleBrush);
        
        public const string TreeViewModernItemsSelectedBackground = nameof(TreeViewModernItemsSelectedBackground);

        public const string TreeViewModernSelectedForeground = nameof(TreeViewModernSelectedForeground);

        public const string TreeViewModernItemHeight = nameof(TreeViewModernItemHeight);

        public const string TreeViewModernItemPadding = nameof(TreeViewModernItemPadding);

        public const string TreeViewModernToggleButtonStyle = nameof(TreeViewModernToggleButtonStyle);

        public const string TreeViewChainItemsHoverBackground = nameof(TreeViewChainItemsHoverBackground);

        public const string TreeViewChainHoverForeground = nameof(TreeViewChainHoverForeground);

        public const string TreeViewChainItemsToggleBrush = nameof(TreeViewChainItemsToggleBrush);

        public const string TreeViewChainItemsHoverToggleBrush = nameof(TreeViewChainItemsHoverToggleBrush);

        public const string TreeViewChainItemsSelectedBackground = nameof(TreeViewChainItemsSelectedBackground);

        public const string TreeViewChainSelectedForeground = nameof(TreeViewChainSelectedForeground);

        public const string TreeViewChainItemHeight = nameof(TreeViewChainItemHeight);

        public const string TreeViewChainItemPadding = nameof(TreeViewChainItemPadding);

        public const string TreeViewChainToggleButtonStyle = nameof(TreeViewChainToggleButtonStyle);
        #endregion

        #region TabControl
        public const string TabControlBorderBrush = nameof(TabControlBorderBrush);

        public const string TabControlBorderThickness = nameof(TabControlBorderThickness);

        public const string TabControlPadding = nameof(TabControlPadding);

        public const string TabControlBackground = nameof(TabControlBackground);

        public const string TabControlStandardTemplate = nameof(TabControlStandardTemplate);

        public const string TabControlExpandableTopTemplate = nameof(TabControlExpandableTopTemplate);

        public const string TabControlExpandableBottomTemplate = nameof(TabControlExpandableBottomTemplate);

        public const string TabControlExpandableLeftTemplate = nameof(TabControlExpandableLeftTemplate);

        public const string TabControlExpandableRightTemplate = nameof(TabControlExpandableRightTemplate);

        public const string TabControlScrollableTopTemplate = nameof(TabControlScrollableTopTemplate);

        public const string TabControlScrollableBottomTemplate = nameof(TabControlScrollableBottomTemplate);

        public const string TabControlScrollableLeftTemplate = nameof(TabControlScrollableLeftTemplate);

        public const string TabControlScrollableRightTemplate = nameof(TabControlScrollableRightTemplate);

        public const string TabItemStandardTemplate = nameof(TabItemStandardTemplate);

        public const string TabItemModernTemplate = nameof(TabItemModernTemplate);

        public const string TabItemCardTemplate = nameof(TabItemCardTemplate);
        
        #endregion

        #region DropDown
        public const string DropDownStandardTemplate = nameof(DropDownStandardTemplate);

        public const string DropDownToggleButtonTemplate = nameof(DropDownToggleButtonTemplate);

        public const string DropDownToggleButtonStyle = nameof(DropDownToggleButtonStyle);


        #endregion

        #region ListBox
        public const string ListBoxBorderBrush = nameof(ListBoxBorderBrush);

        public const string ListBoxBorderThickness = nameof(ListBoxBorderThickness);

        public const string ListBoxBackground = nameof(ListBoxBackground);

        public const string ListBoxItemsHoverBackground = nameof(ListBoxItemsHoverBackground);

        public const string ListBoxItemsSelectedBackground = nameof(ListBoxItemsSelectedBackground);
        #endregion

        #region ListView
        public const string ListViewBorderBrush = nameof(ListViewBorderBrush);

        public const string ListViewBorderThickness = nameof(ListViewBorderThickness);

        public const string ListViewBackground = nameof(ListViewBackground);

        public const string ListViewItemsHoverBackground = nameof(ListViewItemsHoverBackground);

        public const string ListViewItemsSelectedBackground = nameof(ListViewItemsSelectedBackground);
        #endregion

        #region MsgBox
        public const string MsgBoxButtonStyle = nameof(MsgBoxButtonStyle);

        public const string MsgBoxTextBoxStyle = nameof(MsgBoxTextBoxStyle);

        public const string MsgBoxStandardContent = nameof(MsgBoxStandardContent);

        public const string MsgBoxClassicContent = nameof(MsgBoxClassicContent);

        public const string MsgBoxModernContent = nameof(MsgBoxModernContent);

        #endregion

        #region CalendarX
        public const string CalendarXBorderBrush = nameof(CalendarXBorderBrush);

        public const string CalendarXBorderThickness = nameof(CalendarXBorderThickness);

        public const string CalendarXThemeBrush = nameof(CalendarXThemeBrush);

        public const string CalendarXTemplate = nameof(CalendarXTemplate);

        public const string CalendarXHeaderPanelHeight = nameof(CalendarXHeaderPanelHeight);

        public const string CalendarXHeaderPanelBackground = nameof(CalendarXHeaderPanelBackground);
        #endregion

        #region Clock
        public const string ClockTemplate = nameof(ClockTemplate);

        public const string ClockThemeBrush = nameof(ClockThemeBrush);

        public const string ClockBorderBrush = nameof(ClockBorderBrush);

        public const string ClockBorderThickness = nameof(ClockBorderThickness);

        public const string ClockBackground = nameof(ClockBackground);

        public const string ClockItemsControlStyle = nameof(ClockItemsControlStyle);
        
        #endregion

        #region GroupBox
        public const string GroupBoxStandardTemplate = nameof(GroupBoxStandardTemplate);


        public const string GroupBoxStandardBorderBrush = nameof(GroupBoxStandardBorderBrush);

        public const string GroupBoxStandardBorderThickness = nameof(GroupBoxStandardBorderThickness);

        public const string GroupBoxStandardBackground = nameof(GroupBoxStandardBackground);

        public const string GroupBoxPostTemplate = nameof(GroupBoxPostTemplate);

        public const string GroupBoxPostBorderBrush = nameof(GroupBoxPostBorderBrush);

        public const string GroupBoxPostBorderThickness = nameof(GroupBoxPostBorderThickness);

        public const string GroupBoxPostBackground = nameof(GroupBoxPostBackground);

        public const string GroupBoxFootnoteTemplate = nameof(GroupBoxFootnoteTemplate);

        public const string GroupBoxFootnoteBorderBrush = nameof(GroupBoxFootnoteBorderBrush);

        public const string GroupBoxFootnoteBorderThickness = nameof(GroupBoxFootnoteBorderThickness);

        public const string GroupBoxFootnoteBackground = nameof(GroupBoxFootnoteBackground);
        #endregion

        #region ListBox
        public const string ListBoxStandardTemplate = nameof(ListBoxStandardTemplate);

        public const string ListBoxItemStandardTemplate = nameof(ListBoxItemStandardTemplate);


        public const string ListBoxItemStandardBorderThickness = nameof(ListBoxItemStandardBorderThickness);
        #endregion

        #region ListView
        public const string ListViewStandardTemplate = nameof(ListViewStandardTemplate);

        public const string ListViewItemStandardTemplate = nameof(ListViewItemStandardTemplate);


        public const string ListViewItemStandardBorderThickness = nameof(ListViewItemStandardBorderThickness);
        #endregion

        #region DataGrid
        public const string DataGridBorderBrush = nameof(DataGridBorderBrush);

        public const string DataGridBorderThickness = nameof(DataGridBorderThickness);

        public const string DataGridBackground = nameof(DataGridBackground);

        public const string DataGridHorizontalGridLinesBrush = nameof(DataGridHorizontalGridLinesBrush);

        public const string DataGridMinRowHeight = nameof(DataGridMinRowHeight);

        public const string DataGridColumnHeaderHeight = nameof(DataGridColumnHeaderHeight);

        public const string DataGridResizeThumbTemplate = nameof(DataGridResizeThumbTemplate);

        public const string DataGridResizeThumbStyle = nameof(DataGridResizeThumbStyle);

        public const string DataGridSelectAllButtonTemplate = nameof(DataGridSelectAllButtonTemplate);

        public const string DataGridScrollViewerTemplate = nameof(DataGridScrollViewerTemplate);

        public const string DataGridColumnHeaderTemplate = nameof(DataGridColumnHeaderTemplate);

        public const string DataGridRowHeaderTemplate = nameof(DataGridRowHeaderTemplate);

        public const string DataGridRowTemplate = nameof(DataGridRowTemplate);

        public const string DataGridCellTemplate = nameof(DataGridCellTemplate);

        public const string DataGridStandardTemplate = nameof(DataGridStandardTemplate);
        #endregion

        #region ListView
        public const string ListViewScrollViewerTemplate = nameof(ListViewScrollViewerTemplate);

        public const string ListViewResizeThumbTemplate = nameof(ListViewResizeThumbTemplate);

        public const string ListViewResizeThumbStyle = nameof(ListViewResizeThumbStyle);
        #endregion

        #region Pagination

        public const string PaginationTemplate = nameof(PaginationTemplate);

        #endregion

        #region CarouselViewer
        public const string CarouselViewerIndicatorStyle = nameof(CarouselViewerIndicatorStyle);

        public const string CarouselViewerHorizontalTemplate = nameof(CarouselViewerHorizontalTemplate);
     
        public const string CarouselViewerSideButtonStyle = nameof(CarouselViewerSideButtonStyle);
       
        public const string CarouselViewerVerticalTemplate = nameof(CarouselViewerVerticalTemplate);

        #endregion

        #region Drawer
        public const string DrawerTemplate = nameof(DrawerTemplate);
        #endregion

        #region GroupBox
        public const string GroupBoxStandardHeaderTemplate = nameof(GroupBoxStandardHeaderTemplate);

        public const string GroupBoxPostHeaderTemplate = nameof(GroupBoxPostHeaderTemplate);

        public const string GroupBoxFootnoteHeaderTemplate = nameof(GroupBoxFootnoteHeaderTemplate);

        #endregion

        #region ProgressBar
        public const string ProgressBarProgressBarStandardTemplate = nameof(ProgressBarProgressBarStandardTemplate);

        public const string ProgressBarProgressBarRingTemplate = nameof(ProgressBarProgressBarRingTemplate);

        public const string ProgressBarProgressBarWaveTemplate = nameof(ProgressBarProgressBarWaveTemplate);

        public const string ProgressBarWidthOrHeightConverter = nameof(ProgressBarWidthOrHeightConverter);

        public const string ProgressBarPercentTextConverter = nameof(ProgressBarPercentTextConverter);

        public const string ProgressBarPercentTextForegroundConverter = nameof(ProgressBarPercentTextForegroundConverter);

        public const string ProgressBarProgressBarIndeterminateMarginTemplate = nameof(ProgressBarProgressBarIndeterminateMarginTemplate);

        public const string ProgressBarProgressBarRingArcConverter = nameof(ProgressBarProgressBarRingArcConverter);

        public const string ProgressBarProgressBarWavePathConverter = nameof(ProgressBarProgressBarWavePathConverter);

        public const string ProgressBarProgressBarWaveMarginConverter = nameof(ProgressBarProgressBarWaveMarginConverter);

        #endregion

    }
}
