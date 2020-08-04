﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class Validator : ContentControl
    {
        #region Ctor
        static Validator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Validator), new FrameworkPropertyMetadata(typeof(Validator)));
        }
        #endregion

        #region Override
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            if (newContent != null)
            {
                var binding = new Binding()
                {
                    Path = new PropertyPath(ValidationErrorTipsProperty),
                    Source = newContent,
                    Mode = BindingMode.OneWay,
                };
                SetBinding(ValidationErrorTipsProperty, binding);
            }

        }
        #endregion

        #region Properties

        #region ValidationErrorTips
        public static string GetValidationErrorTips(DependencyObject obj)
        {
            return (string)obj.GetValue(ValidationErrorTipsProperty);
        }

        public static void SetValidationErrorTips(DependencyObject obj, string value)
        {
            obj.SetValue(ValidationErrorTipsProperty, value);
        }

        public static readonly DependencyProperty ValidationErrorTipsProperty =
            DependencyProperty.Register("ValidationErrorTips", typeof(string), typeof(Validator));
        #endregion

        #region ValidationErrorForeground
        public Brush ValidationErrorForeground
        {
            get { return (Brush)GetValue(ValidationErrorForegroundProperty); }
            set { SetValue(ValidationErrorForegroundProperty, value); }
        }

        public static readonly DependencyProperty ValidationErrorForegroundProperty =
            DependencyProperty.Register("ValidationErrorForeground", typeof(Brush), typeof(Validator));

        #endregion

        #endregion

    }
}
