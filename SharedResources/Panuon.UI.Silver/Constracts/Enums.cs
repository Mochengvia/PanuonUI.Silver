namespace Panuon.UI.Silver
{
    #region Button & RepeatButton
    public enum ButtonStyle
    {
        Standard,
        Outline,
        Hollow,
        Link,
    }

    public enum RepeatButtonStyle
    {
        Standard,
        Outline,
        Hollow,
        Link,
    }

    public enum ToggleButtonStyle
    {
        Standard,
        Outline,
        Hollow,
        Link,
    }

    public enum ClickStyle
    {
        None,
        Sink,
    }

    public enum IconPosition
    {
        Left,
        Top,
    }
    #endregion

    #region TextBlock
    public enum HighlightRule
    {
        All,
        First,
    }
    #endregion

    #region CheckBox
    public enum CheckBoxStyle
    {
        Standard,
        Switch,
        Switch2,
        Switch3,
        Button,
        Selector
    }
    #endregion

    #region NeonLabel
    public enum NeonAnimation
    {
        Notice,
        Marble,
        Barrage,
        Conspicuous,
        FadeNext,
    }
    #endregion

    #region RadioButton
    public enum RadioButtonStyle
    {
        Standard,
        Switch,
        Switch2,
        Switch3,
        Button,
        Selector
    }

    #endregion

    #region ScrollViewer
    public enum ScrollButtons
    {
        None,
        UpDown,
        TopBottom,
        All,
    }
    #endregion

    #region Popup
    public enum ActualPlacement
    {
        Left,
        TopLeft,
        Top,
        TopRight,
        Right,
        BottomRight,
        Bottom,
        BottomLeft,
    }
    #endregion

    #region TreeView
    public enum TreeViewStyle
    {
        Standard,
        Modern,
        Chain
    }

    #endregion

    #region TabControl
    public enum TabControlStyle
    {
        Standard,
        Card,
        Modern,
    }

    public enum TabControlHeaderStyle
    {
        Standard,
        Expandable,
        Scrollable,
    }
    #endregion

    #region DropDown
    public enum DropDownStyle
    {
        Standard,
        Standard2,
        Smooth,
    }
    public enum DropDownPlacement
    {
        BottomLeft,
        Bottom,
        BottomRight,
        Top,
        TopRight,
        TopLeft,
    }
    #endregion

    #region ComboBoxStyle
    public enum ComboBoxStyle
    {
        Standard,
        Simple
    }
    #endregion

    #region MessageBox
    public enum MessageBoxStyle
    {
        Standard,
        Classic,
        Modern,
    }

    public enum MessageBoxIcon
    {
        None,
        Info,
        Warning,
        Error,
        Success,
        Question,
    }

    public enum DefaultButton
    {
        Unset,
        YesOK,
        NoCancel,
        CancelNo
    }
    #endregion

    #region CalendarX

    public enum CalendarSelectionMode
    {
        Date,
        YearMonth,
        Year,
    }

    public enum YearMonthDay
    {
        Year,
        Month,
        Day
    }

    #endregion

    #region GroupBox
    public enum GroupBoxStyle
    {
        Standard,
        Post,
        Footnote
    }

    #endregion

    #region Clock
    public enum HourMinuteSecond
    {
        Hour,
        Minute,
        Second
    }

    public enum TimePeriod
    {
        AM,
        PM
    }

    #endregion

    #region DateTimePicker
    public enum DateTimePickerMode
    {
        DateTime,
        Date,
        Time
    }
    #endregion

    #region Separator
    public enum SeparatorAlignment
    {
        Left,
        Top,
        Right,
        Bottom,
        HorizontalCenter,
        VerticalCenter,
    }
    #endregion

    #region AnimationEasing
    public enum AnimationEase
    {
        None,
        CubicIn,
        CubicOut,
        CubicInOut,
        CircleIn,
        CircleOut,
        CircleInOut,
        QuadraticIn,
        QuadraticOut,
        QuadraticInOut,
        BackIn,
        BackOut,
        BackInOut,
        PowerIn,
        PowerOut,
        PowerInOut,
    }
    #endregion

    #region SideButtonVisibility
    public enum SideButtonVisibility
    {
        Visible,
        Fade,
        Collapsed,
    }

    public enum IndicatorVisibility
    {
        Visible,
        Fade,
        Collapsed,
    }

    public enum IndicatorPosition
    {
        BottomOrRight,
        TopOrLeft,
    }
    #endregion

    #region Drawer
    public enum DrawerPlacement
    {
        Left,
        Top,
        Right,
        Bottom,
    }
    #endregion
}
