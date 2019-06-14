using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class Timeline : Control
    {
        static Timeline()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata(typeof(Timeline)));
        }

        #region Property

        public Brush ThemeBrush
        {
            get { return (Brush)GetValue(ThemeBrushProperty); }
            set { SetValue(ThemeBrushProperty, value); }
        }

        public static readonly DependencyProperty ThemeBrushProperty =
            DependencyProperty.Register("ThemeBrush", typeof(Brush), typeof(Timeline));



        public Brush HeaderForeground
        {
            get { return (Brush)GetValue(HeaderForegroundProperty); }
            set { SetValue(HeaderForegroundProperty, value); }
        }

        public static readonly DependencyProperty HeaderForegroundProperty =
            DependencyProperty.Register("HeaderForeground", typeof(Brush), typeof(Timeline));



        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(Timeline));

        public string HeaderMemberPath
        {
            get { return (string)GetValue(HeaderMemberPathProperty); }
            set { SetValue(HeaderMemberPathProperty, value); }
        }

        public static readonly DependencyProperty HeaderMemberPathProperty =
            DependencyProperty.Register("HeaderMemberPath", typeof(string), typeof(Timeline));


        public string ContentMemberPath
        {
            get { return (string)GetValue(ContentMemberPathProperty); }
            set { SetValue(ContentMemberPathProperty, value); }
        }

        public static readonly DependencyProperty ContentMemberPathProperty =
            DependencyProperty.Register("ContentMemberPath", typeof(string), typeof(Timeline));
        #endregion
    }
}
