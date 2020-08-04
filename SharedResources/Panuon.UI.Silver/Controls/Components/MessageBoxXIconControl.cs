using Panuon.UI.Silver.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver.Components
{
    public sealed class MessageBoxXIconControl : ContentControl
    {
        #region Ctor
        static MessageBoxXIconControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MessageBoxXIconControl), new FrameworkPropertyMetadata(typeof(MessageBoxXIconControl)));
        }
        #endregion

        #region Properties

        #region InfoBrush
        public Brush InfoBrush
        {
            get { return (Brush)GetValue(InfoBrushProperty); }
            set { SetValue(InfoBrushProperty, value); }
        }

        public static readonly DependencyProperty InfoBrushProperty =
            DependencyProperty.Register("InfoBrush", typeof(Brush), typeof(MessageBoxXIconControl), new PropertyMetadata("#80BEE8".ToColor().ToBrush()));
        #endregion

        #region QuestionBrush
        public Brush QuestionBrush
        {
            get { return (Brush)GetValue(QuestionBrushProperty); }
            set { SetValue(QuestionBrushProperty, value); }
        }

        public static readonly DependencyProperty QuestionBrushProperty =
            DependencyProperty.Register("QuestionBrush", typeof(Brush), typeof(MessageBoxXIconControl), new PropertyMetadata("#80BEE8".ToColor().ToBrush()));
        #endregion

        #region WarningBrush
        public Brush WarningBrush
        {
            get { return (Brush)GetValue(WarningBrushProperty); }
            set { SetValue(WarningBrushProperty, value); }
        }

        public static readonly DependencyProperty WarningBrushProperty =
            DependencyProperty.Register("WarningBrush", typeof(Brush), typeof(MessageBoxXIconControl), new PropertyMetadata("#F9D01A".ToColor().ToBrush()));
        #endregion

        #region ErrorBrush
        public Brush ErrorBrush
        {
            get { return (Brush)GetValue(ErrorBrushProperty); }
            set { SetValue(ErrorBrushProperty, value); }
        }

        public static readonly DependencyProperty ErrorBrushProperty =
            DependencyProperty.Register("ErrorBrush", typeof(Brush), typeof(MessageBoxXIconControl), new PropertyMetadata("#FF5656".ToColor().ToBrush()));
        #endregion

        #region SuccessBrush
        public Brush SuccessBrush
        {
            get { return (Brush)GetValue(SuccessBrushProperty); }
            set { SetValue(SuccessBrushProperty, value); }
        }

        public static readonly DependencyProperty SuccessBrushProperty =
            DependencyProperty.Register("SuccessBrush", typeof(Brush), typeof(MessageBoxXIconControl), new PropertyMetadata("#75CD43".ToColor().ToBrush()));
        #endregion

        #region InfoIcon
        public string InfoIcon
        {
            get { return (string)GetValue(InfoIconProperty); }
            set { SetValue(InfoIconProperty, value); }
        }

        public static readonly DependencyProperty InfoIconProperty =
            DependencyProperty.Register("InfoIcon", typeof(string), typeof(MessageBoxXIconControl), new PropertyMetadata("\ue92f"));
        #endregion

        #region QuestionIcon
        public string QuestionIcon
        {
            get { return (string)GetValue(QuestionIconProperty); }
            set { SetValue(QuestionIconProperty, value); }
        }

        public static readonly DependencyProperty QuestionIconProperty =
            DependencyProperty.Register("QuestionIcon", typeof(string), typeof(MessageBoxXIconControl), new PropertyMetadata("\ue937"));
        #endregion

        #region WarningIcon
        public string WarningIcon
        {
            get { return (string)GetValue(WarningIconProperty); }
            set { SetValue(WarningIconProperty, value); }
        }

        public static readonly DependencyProperty WarningIconProperty =
            DependencyProperty.Register("WarningIcon", typeof(string), typeof(MessageBoxXIconControl), new PropertyMetadata("\ue931"));
        #endregion

        #region ErrorIcon
        public string ErrorIcon
        {
            get { return (string)GetValue(ErrorIconProperty); }
            set { SetValue(ErrorIconProperty, value); }
        }

        public static readonly DependencyProperty ErrorIconProperty =
            DependencyProperty.Register("ErrorIcon", typeof(string), typeof(MessageBoxXIconControl), new PropertyMetadata("\ue933"));
        #endregion

        #region  SuccessIcon
        public string SuccessIcon
        {
            get { return (string)GetValue(SuccessIconProperty); }
            set { SetValue(SuccessIconProperty, value); }
        }

        public static readonly DependencyProperty SuccessIconProperty =
            DependencyProperty.Register("SuccessIcon", typeof(string), typeof(MessageBoxXIconControl), new PropertyMetadata("\ue935"));
        #endregion

        #region MessageBoxIcon
        public MessageBoxIcon MessageBoxIcon
        {
            get { return (MessageBoxIcon)GetValue(MessageBoxIconProperty); }
            set { SetValue(MessageBoxIconProperty, value); }
        }

        public static readonly DependencyProperty MessageBoxIconProperty =
            DependencyProperty.Register("MessageBoxIcon", typeof(MessageBoxIcon), typeof(MessageBoxXIconControl));
        #endregion

        #endregion

    }
}
