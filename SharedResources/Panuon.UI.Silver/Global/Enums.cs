namespace Panuon.UI.Silver
{
    #region MessageBoxX
    #region MessageBoxStyle
    public enum MessageBoxStyle
    {
        Standard,
        Modern,
        Classic,
        //Poster
    }

    public enum MessageBoxIcon
    {
        None,
        Info,
        Success,
        Error,
        Warning,
        Question,
    }

    public enum DefaultButton
    {
        None,
        YesOK,
        NoOrCancel,
        CancelOrNo,
    }
    #endregion
    #endregion

    #region Waterfall
    public enum ChildrenShape
    {
        Custom,
        Square,
    }
    #endregion

    #region PendingBox
    public enum PendingBoxStyle
    {
        Standard,
        Classic,
    }
    #endregion

    #region Button
    #region ClickMode
    public enum ClickMode
    {
        Both,
        OnlyOne,
    }
    #endregion

    #region Button
    public enum ButtonStyle
    {
        Standard,
        Hollow,
        Outline,
        Link,
    }

    public enum ClickStyle
    {
        None,
        Sink,
    }
    #endregion
    #endregion

    #region RepeatButton
    public enum RepeatButtonStyle
    {
        Standard,
        Hollow,
        Outline,
        Link,
    }
    #endregion

    #region Loading
    public enum LoadingStyle
    {
        Standard,
        Wave,
        Ring,
        Ring2,
        Classic
    }
    #endregion

    #region TreeView
    public enum TreeViewStyle
    {
        Standard,
        Classic,
        Modern,
        Chain,
    }

    public enum SelectMode
    {
        Any,
        ChildOnly,
        Disabled
    }

    public enum ExpandMode
    {
        DoubleClick,
        SingleClick
    }

    public enum ExpandBehaviour
    {
        Any,
        OnlyOne,
    }
    #endregion

    #region Expander
    public enum ExpanderStyle
    {
        Standard,
        Classic,
    }
    #endregion

    #region CheckBox
    public enum CheckBoxStyle
    {
        Standard,
        Switch,
        Switch2,
        Button,
        Selector,
    }
    #endregion

    #region RadioButton
    public enum RadioButtonStyle
    {
        Standard,
        Switch,
        Switch2,
        Button,
        Selector,
    }
    #endregion

    #region Calendar
    public enum CalendarMode
    {
        Date,
        YearMonth,
        Year,
    }
    #endregion

    #region Clock
    public enum ClockStyle
    {
        Standard,
        Dial,
    }
    #endregion

    #region Slider
    public enum SliderStyle
    {
        Standard,
        Classic,

    }
    #endregion

    #region ProgressBarStyle
    public enum ProgressBarStyle
    {
        Standard,
        Ring
    }
    #endregion

    #region DateTimePickerMode
    public enum DateTimePickerMode
    {
        DateTime,
        Date,
        Time,
    }
    #endregion

    #region TabControlStyle
    public enum TabControlStyle
    {
        Standard,
        Classic,
        Card,
    }

    public enum ItemsAlignment
    {
        LeftOrTop,
        Center,
    }
    #endregion

    #region ImageCuter
    public enum ImageType
    {
        Rectangle,
        Square,
    }
    #endregion

    #region NeonLabel
    public enum NeonLabelType
    {
        /// <summary>
        /// Fade out current background, and fade in next background.
        /// </summary>
        FadeBackground,
        /// <summary>
        /// Fade out current foreground, and fade in next foreground.
        /// </summary>
        FadeForeground,
        /// <summary>
        /// Fade out current content, and fade in next content.
        /// </summary>
        FadeNext,
        /// <summary>
        /// Slide out current content , and slide in next content.
        /// </summary>
        SlideNext,
        /// <summary>
        /// Scroll to end
        /// </summary>
        ScrollToEnd,
    }
    #endregion

    #region DropDown
    public enum DropDownPlacement
    {
        Bottom,
        RightBottom,
        LeftBottom
    }
    #endregion

    #region PopupPosition
    public enum PopupPosition
    {
        Bottom,
        Top,
        Center,
    }
    #endregion

    #region ColumnStyle
    public enum ColumnStyle
    {
        Standard,
        Hover
    }
    #endregion

    #region ItemsControl
    public enum ItemAnimation
    {
        None,
        Slide,
        Gradual,
        Fade,
    }
    #endregion

    #region PaginationStyle
    public enum PaginationStyle
    {
        Standard,
        Classic,
        Simple,
    }
    #endregion

    #region MenuStyle
    public enum MenuStyle
    {
        Standard,
        Modern,
    }
    #endregion

    #region StateIcon
    public enum IconState
    {
        Normal,
        Success,
        Failed,
        Warning,
        Error,
        Tips,
    }
    #endregion

    #region MatchRule
    public enum MatchRule
    {
        First,
        All,
    }
    #endregion

    #region TextAdaption
    public enum TextAdaption
    {
        None,
        ClipToBounds,
    }
    #endregion

    #region TimelimeStripPlacement
    public enum TimelimeStripPlacement
    {
        Left,
        Right,
        Top,
        Bottom,
    }
    #endregion

    }
