using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Data;
using System.Diagnostics;
using System;
using System.ComponentModel;

namespace Panuon.UI.Silver
{
    public class Timeline : ItemsControl
    {
        #region Ctor
        static Timeline()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata(typeof(Timeline)));
        }

        #endregion

        #region Property
        /// <summary>
        /// Gets or sets line brush.
        /// </summary>
        public Brush ItemLineBrush
        {
            get { return (Brush)GetValue(ItemLineBrushProperty); }
            set { SetValue(ItemLineBrushProperty, value); }
        }

        public static readonly DependencyProperty ItemLineBrushProperty =
            DependencyProperty.Register("ItemLineBrush", typeof(Brush), typeof(Timeline));

        /// <summary>
        /// Gets or sets line thickness.
        /// </summary>
        public double ItemLineThickness
        {
            get { return (double)GetValue(ItemLineThicknessProperty); }
            set { SetValue(ItemLineThicknessProperty, value); }
        }

        public static readonly DependencyProperty ItemLineThicknessProperty =
            DependencyProperty.Register("ItemLineThickness", typeof(double), typeof(Timeline));

        /// <summary>
        /// Gets or sets line margin.
        /// </summary>
        public Thickness ItemLineMargin
        {
            get { return (Thickness)GetValue(ItemLineMarginProperty); }
            set { SetValue(ItemLineMarginProperty, value); }
        }

        public static readonly DependencyProperty ItemLineMarginProperty =
            DependencyProperty.Register("ItemLineMargin", typeof(Thickness), typeof(Timeline));

        /// <summary>
        /// Gets or sets toggle size.
        /// </summary>
        public double ItemToggleSize
        {
            get { return (double)GetValue(ItemToggleSizeProperty); }
            set { SetValue(ItemToggleSizeProperty, value); }
        }

        public static readonly DependencyProperty ItemToggleSizeProperty =
            DependencyProperty.Register("ItemToggleSize", typeof(double), typeof(Timeline));

        /// <summary>
        /// Gets or sets toggle margin.
        /// </summary>
        public Thickness ItemToggleMargin
        {
            get { return (Thickness)GetValue(ItemToggleMarginProperty); }
            set { SetValue(ItemToggleMarginProperty, value); }
        }

        public static readonly DependencyProperty ItemToggleMarginProperty =
            DependencyProperty.Register("ItemToggleMargin", typeof(Thickness), typeof(Timeline));

        /// <summary>
        /// Gets or sets toggle stroke.
        /// </summary>
        public Brush ItemToggleStroke
        {
            get { return (Brush)GetValue(ItemToggleStrokeProperty); }
            set { SetValue(ItemToggleStrokeProperty, value); }
        }

        public static readonly DependencyProperty ItemToggleStrokeProperty =
            DependencyProperty.Register("ItemToggleStroke", typeof(Brush), typeof(Timeline));

        /// <summary>
        /// Gets or sets toggle stroke thickness.
        /// </summary>
        public double ItemToggleStrokeThickness
        {
            get { return (double)GetValue(ItemToggleStrokeThicknessProperty); }
            set { SetValue(ItemToggleStrokeThicknessProperty, value); }
        }

        public static readonly DependencyProperty ItemToggleStrokeThicknessProperty =
            DependencyProperty.Register("ItemToggleStrokeThickness", typeof(double), typeof(Timeline));

        /// <summary>
        /// Gets or sets toggle fill.
        /// </summary>
        public Brush ItemToggleFill
        {
            get { return (Brush)GetValue(ItemToggleFillProperty); }
            set { SetValue(ItemToggleFillProperty, value); }
        }

        public static readonly DependencyProperty ItemToggleFillProperty =
            DependencyProperty.Register("ItemToggleFill", typeof(Brush), typeof(Timeline));

        /// <summary>
        /// Gets or sets toggle shadow color.
        /// </summary>
        public Color? ItemToggleShadowColor
        {
            get { return (Color?)GetValue(ItemToggleShadowColorProperty); }
            set { SetValue(ItemToggleShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ItemToggleShadowColorProperty =
            DependencyProperty.Register("ItemToggleShadowColor", typeof(Color?), typeof(Timeline));

        /// <summary>
        /// Gets or sets header padding.
        /// </summary>
        public DataTemplate HeaderTemplate
        {
            get { return (DataTemplate)GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }

        public static readonly DependencyProperty HeaderTemplateProperty =
            DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(Timeline));

        /// <summary>
        /// Gets or sets header template selector.
        /// </summary>
        public DataTemplateSelector HeaderTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(HeaderTemplateSelectorProperty); }
            set { SetValue(HeaderTemplateSelectorProperty, value); }
        }

        public static readonly DependencyProperty HeaderTemplateSelectorProperty =
            DependencyProperty.Register("HeaderTemplateSelector", typeof(DataTemplateSelector), typeof(Timeline));

        /// <summary>
        /// Gets or sets header member path.
        /// </summary>
        public string HeaderMemberPath
        {
            get { return (string)GetValue(HeaderMemberPathProperty); }
            set { SetValue(HeaderMemberPathProperty, value); }
        }

        public static readonly DependencyProperty HeaderMemberPathProperty =
            DependencyProperty.Register("HeaderMemberPath", typeof(string), typeof(Timeline), new PropertyMetadata(OnHeaderMemberPathChanged));

        /// <summary>
        /// Gets or sets horizontal scroll bar visibility.
        /// </summary>
        public ScrollBarVisibility HorizontalScrollBarVisibility
        {
            get { return (ScrollBarVisibility)GetValue(HorizontalScrollBarVisibilityProperty); }
            set { SetValue(HorizontalScrollBarVisibilityProperty, value); }
        }

        public static readonly DependencyProperty HorizontalScrollBarVisibilityProperty =
            DependencyProperty.Register("HorizontalScrollBarVisibility", typeof(ScrollBarVisibility), typeof(Timeline));

        /// <summary>
        /// Gets or sets vertical scroll bar visibility.
        /// </summary>
        public ScrollBarVisibility VerticalScrollBarVisibility
        {
            get { return (ScrollBarVisibility)GetValue(VerticalScrollBarVisibilityProperty); }
            set { SetValue(VerticalScrollBarVisibilityProperty, value); }
        }

        public static readonly DependencyProperty VerticalScrollBarVisibilityProperty =
            DependencyProperty.Register("VerticalScrollBarVisibility", typeof(ScrollBarVisibility), typeof(Timeline));

        /// <summary>
        /// Gets or sets timelime strip placement.
        /// </summary>
        public TimelimeStripPlacement TimelimeStripPlacement
        {
            get { return (TimelimeStripPlacement)GetValue(TimelimeStripPlacementProperty); }
            set { SetValue(TimelimeStripPlacementProperty, value); }
        }

        public static readonly DependencyProperty TimelimeStripPlacementProperty =
            DependencyProperty.Register("TimelimeStripPlacement", typeof(TimelimeStripPlacement), typeof(Timeline), new PropertyMetadata(TimelimeStripPlacement.Left));


        #endregion

        #region Override
        private static void OnHeaderMemberPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var Timeline = d as Timeline;
            Timeline.UpdateHeaderMemberTemplateSelector();
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TimelineItem() { IsCreateByItemsControl = true };
        }
        #endregion

        #region Function
        private void UpdateHeaderMemberTemplateSelector()
        {
            var headerMemberPath = HeaderMemberPath;
            if (!string.IsNullOrEmpty(headerMemberPath))
            {
                HeaderTemplateSelector = new HeaderTemplateSelector(headerMemberPath);
            }
            else
            {
                ClearValue(HeaderMemberPathProperty);
            }
        }
        #endregion
    }

    internal class HeaderTemplateSelector : DataTemplateSelector
    {
        private string _headerMemberPath;

        public HeaderTemplateSelector(string headerMemberPath)
        {
            _headerMemberPath = headerMemberPath;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var text = new FrameworkElementFactory(typeof(ContentControl));
            Binding dataContext = new Binding() { Source = item };
            text.SetBinding(ContentControl.DataContextProperty, dataContext);
            Binding header = new Binding(_headerMemberPath);
            text.SetBinding(ContentControl.ContentProperty, header);

            var dataTemplate = new DataTemplate
            {
                VisualTree = text
            };
            dataTemplate.Seal();
            return dataTemplate;
        }
    }
}
