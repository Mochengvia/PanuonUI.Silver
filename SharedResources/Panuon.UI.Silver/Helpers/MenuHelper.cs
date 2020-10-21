using Panuon.UI.Silver.Internal.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public static class MenuHelper
    {
        #region Properties

        #region HasItemsIconTemplate
        public static DataTemplate GetHasItemsIconTemplate(Menu menu)
        {
            return (DataTemplate)menu.GetValue(HasItemsIconTemplateProperty);
        }

        public static void SetHasItemsIconTemplate(Menu menu, DataTemplate value)
        {
            menu.SetValue(HasItemsIconTemplateProperty, value);
        }

        public static readonly DependencyProperty HasItemsIconTemplateProperty =
            DependencyProperty.RegisterAttached("HasItemsIconTemplate", typeof(DataTemplate), typeof(MenuHelper));
        #endregion

        #region CheckedIconTemplate
        public static DataTemplate GetCheckedIconTemplate(Menu menu)
        {
            return (DataTemplate)menu.GetValue(CheckedIconTemplateProperty);
        }

        public static void SetCheckedIconTemplate(Menu menu, DataTemplate value)
        {
            menu.SetValue(CheckedIconTemplateProperty, value);
        }

        public static readonly DependencyProperty CheckedIconTemplateProperty =
            DependencyProperty.RegisterAttached("CheckedIconTemplate", typeof(DataTemplate), typeof(MenuHelper));
        #endregion

        #region TopLevelItemForeground
        public static Brush GetTopLevelItemsForeground(Menu menu)
        {
            return (Brush)menu.GetValue(TopLevelItemsForegroundProperty);
        }

        public static void SetTopLevelItemsForeground(Menu menu, Brush value)
        {
            menu.SetValue(TopLevelItemsForegroundProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsForegroundProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsForeground", typeof(Brush), typeof(MenuHelper));


        public static Brush GetTopLevelItemForeground(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(TopLevelItemForegroundProperty);
        }

        public static void SetTopLevelItemForeground(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(TopLevelItemForegroundProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemForegroundProperty =
            DependencyProperty.RegisterAttached("TopLevelItemForeground", typeof(Brush), typeof(MenuHelper));
        #endregion

        #region TopLevelItemBackground
        public static Brush GetTopLevelItemsBackground(Menu menu)
        {
            return (Brush)menu.GetValue(TopLevelItemsBackgroundProperty);
        }

        public static void SetTopLevelItemsBackground(Menu menu, Brush value)
        {
            menu.SetValue(TopLevelItemsBackgroundProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsBackgroundProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsBackground", typeof(Brush), typeof(MenuHelper));

        #endregion

        #region TopLevelItemBorderBrush
        public static Brush GetTopLevelItemsBorderBrush(Menu menu)
        {
            return (Brush)menu.GetValue(TopLevelItemsBorderBrushProperty);
        }

        public static void SetTopLevelItemsBorderBrush(Menu menu, Brush value)
        {
            menu.SetValue(TopLevelItemsBorderBrushProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsBorderBrushProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsBorderBrush", typeof(Brush), typeof(MenuHelper));

        #endregion

        #region TopLevelItemBorderThickness
        public static Thickness GetTopLevelItemsBorderThickness(Menu menu)
        {
            return (Thickness)menu.GetValue(TopLevelItemsBorderThicknessProperty);
        }

        public static void SetTopLevelItemsBorderThickness(Menu menu, Thickness value)
        {
            menu.SetValue(TopLevelItemsBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsBorderThicknessProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsBorderThickness", typeof(Thickness), typeof(MenuHelper));

        #endregion

        #region TopLevelItemCornerRadius
        public static CornerRadius GetTopLevelItemsCornerRadius(Menu menu)
        {
            return (CornerRadius)menu.GetValue(TopLevelItemsCornerRadiusProperty);
        }

        public static void SetTopLevelItemsCornerRadius(Menu menu, CornerRadius value)
        {
            menu.SetValue(TopLevelItemsCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsCornerRadiusProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsCornerRadius", typeof(CornerRadius), typeof(MenuHelper));



        public static CornerRadius GetTopLevelItemCornerRadius(MenuItem menuItem)
        {
            return (CornerRadius)menuItem.GetValue(TopLevelItemCornerRadiusProperty);
        }

        public static void SetTopLevelItemCornerRadius(MenuItem menuItem, CornerRadius value)
        {
            menuItem.SetValue(TopLevelItemCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemCornerRadiusProperty =
            DependencyProperty.RegisterAttached("TopLevelItemCornerRadius", typeof(CornerRadius), typeof(MenuHelper));


        #endregion

        #region TopLevelItemHoverBackground
        public static Brush GetTopLevelItemsHoverBackground(Menu menu)
        {
            return (Brush)menu.GetValue(TopLevelItemHoverBackgroundProperty);
        }

        public static void SetTopLevelItemsHoverBackground(Menu menu, Brush value)
        {
            menu.SetValue(TopLevelItemsHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsHoverBackground", typeof(Brush), typeof(MenuHelper));

        public static Brush GetTopLevelItemHoverBackground(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(TopLevelItemHoverBackgroundProperty);
        }

        public static void SetTopLevelItemHoverBackground(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(TopLevelItemHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("TopLevelItemHoverBackground", typeof(Brush), typeof(MenuHelper));
        #endregion

        #region TopLevelItemHoverForeground
        public static Brush GetTopLevelItemsHoverForeground(Menu menu)
        {
            return (Brush)menu.GetValue(TopLevelItemsHoverForegroundProperty);
        }

        public static void SetTopLevelItemsHoverForeground(Menu menu, Brush value)
        {
            menu.SetValue(TopLevelItemsHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsHoverForegroundProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsHoverForeground", typeof(Brush), typeof(MenuHelper));



        public static Brush GetTopLevelItemHoverForeground(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(TopLevelItemHoverForegroundProperty);
        }

        public static void SetTopLevelItemHoverForeground(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(TopLevelItemHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemHoverForegroundProperty =
            DependencyProperty.RegisterAttached("TopLevelItemHoverForeground", typeof(Brush), typeof(MenuHelper));


        #endregion

        #region TopLevelItemHoverBorderBrush
        public static Brush GetTopLevelItemsHoverBorderBrush(Menu menu)
        {
            return (Brush)menu.GetValue(TopLevelItemsHoverBorderBrushProperty);
        }

        public static void SetTopLevelItemsHoverBorderBrush(Menu menu, Brush value)
        {
            menu.SetValue(TopLevelItemsHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsHoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsHoverBorderBrush", typeof(Brush), typeof(MenuHelper));

        public static Brush GetTopLevelItemHoverBorderBrush(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(TopLevelItemHoverBorderBrushProperty);
        }

        public static void SetTopLevelItemHoverBorderBrush(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(TopLevelItemHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemHoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("TopLevelItemHoverBorderBrush", typeof(Brush), typeof(MenuHelper));
        #endregion

        #region TopLevelItemCheckedBackground
        public static Brush GetTopLevelItemsCheckedBackground(Menu menu)
        {
            return (Brush)menu.GetValue(TopLevelItemCheckedBackgroundProperty);
        }

        public static void SetTopLevelItemsCheckedBackground(Menu menu, Brush value)
        {
            menu.SetValue(TopLevelItemsCheckedBackgroundProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsCheckedBackgroundProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsCheckedBackground", typeof(Brush), typeof(MenuHelper));

        public static Brush GetTopLevelItemCheckedBackground(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(TopLevelItemCheckedBackgroundProperty);
        }

        public static void SetTopLevelItemCheckedBackground(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(TopLevelItemCheckedBackgroundProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemCheckedBackgroundProperty =
            DependencyProperty.RegisterAttached("TopLevelItemCheckedBackground", typeof(Brush), typeof(MenuHelper));
        #endregion

        #region TopLevelItemCheckedForeground
        public static Brush GetTopLevelItemsCheckedForeground(Menu menu)
        {
            return (Brush)menu.GetValue(TopLevelItemsCheckedForegroundProperty);
        }

        public static void SetTopLevelItemsCheckedForeground(Menu menu, Brush value)
        {
            menu.SetValue(TopLevelItemsCheckedForegroundProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsCheckedForegroundProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsCheckedForeground", typeof(Brush), typeof(MenuHelper));



        public static Brush GetTopLevelItemCheckedForeground(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(TopLevelItemCheckedForegroundProperty);
        }

        public static void SetTopLevelItemCheckedForeground(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(TopLevelItemCheckedForegroundProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemCheckedForegroundProperty =
            DependencyProperty.RegisterAttached("TopLevelItemCheckedForeground", typeof(Brush), typeof(MenuHelper));


        #endregion

        #region TopLevelItemCheckedBorderBrush
        public static Brush GetTopLevelItemsCheckedBorderBrush(Menu menu)
        {
            return (Brush)menu.GetValue(TopLevelItemsCheckedBorderBrushProperty);
        }

        public static void SetTopLevelItemsCheckedBorderBrush(Menu menu, Brush value)
        {
            menu.SetValue(TopLevelItemsCheckedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsCheckedBorderBrushProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsCheckedBorderBrush", typeof(Brush), typeof(MenuHelper));

        public static Brush GetTopLevelItemCheckedBorderBrush(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(TopLevelItemCheckedBorderBrushProperty);
        }

        public static void SetTopLevelItemCheckedBorderBrush(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(TopLevelItemCheckedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemCheckedBorderBrushProperty =
            DependencyProperty.RegisterAttached("TopLevelItemCheckedBorderBrush", typeof(Brush), typeof(MenuHelper));
        #endregion

        #region TopLevelItemIconPlacement
        public static Dock GetTopLevelItemsIconPlacement(Menu menu)
        {
            return (Dock)menu.GetValue(TopLevelItemsIconPlacementProperty);
        }

        public static void SetTopLevelItemsIconPlacement(Menu menu, Dock value)
        {
            menu.SetValue(TopLevelItemsIconPlacementProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsIconPlacementProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsIconPlacement", typeof(Dock), typeof(MenuHelper));

        public static Dock GetTopLevelItemIconPlacement(MenuItem menuItem)
        {
            return (Dock)menuItem.GetValue(TopLevelItemIconPlacementProperty);
        }

        public static void SetTopLevelItemIconPlacement(MenuItem menuItem, Dock value)
        {
            menuItem.SetValue(TopLevelItemIconPlacementProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemIconPlacementProperty =
            DependencyProperty.RegisterAttached("TopLevelItemIconPlacement", typeof(Dock), typeof(MenuHelper));
        #endregion

        #region TopLevelItemsHeight
        public static double GetTopLevelItemsHeight(Menu contextMneu)
        {
            return (double)contextMneu.GetValue(TopLevelItemsHeightProperty);
        }

        public static void SetTopLevelItemsHeight(Menu menu, double value)
        {
            menu.SetValue(TopLevelItemsHeightProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsHeightProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsHeight", typeof(double), typeof(MenuHelper));
        #endregion

        #region TopLevelItemsWidth
        public static double GetTopLevelItemsWidth(Menu contextMneu)
        {
            return (double)contextMneu.GetValue(TopLevelItemsWidthProperty);
        }

        public static void SetTopLevelItemsWidth(Menu menu, double value)
        {
            menu.SetValue(TopLevelItemsWidthProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsWidthProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsWidth", typeof(double), typeof(MenuHelper));
        #endregion

        #region TopLevelItemsPadding
        public static Thickness GetTopLevelItemsPadding(Menu menu)
        {
            return (Thickness)menu.GetValue(TopLevelItemsPaddingProperty);
        }

        public static void SetTopLevelItemsPadding(Menu menu, Thickness value)
        {
            menu.SetValue(TopLevelItemsPaddingProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsPaddingProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsPadding", typeof(Thickness), typeof(MenuHelper));
        #endregion

        #region TopLevelItemsMargin
        public static Thickness GetTopLevelItemsMargin(Menu menu)
        {
            return (Thickness)menu.GetValue(TopLevelItemsMarginProperty);
        }

        public static void SetTopLevelItemsMargin(Menu menu, Thickness value)
        {
            menu.SetValue(TopLevelItemsMarginProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsMarginProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsMargin", typeof(Thickness), typeof(MenuHelper));
        #endregion

        #region TopLevelItemsIcon
        public static object GetTopLevelItemsIcon(Menu menu)
        {
            return (object)menu.GetValue(TopLevelItemsIconProperty);
        }

        public static void SetTopLevelItemsIcon(Menu menu, object value)
        {
            menu.SetValue(TopLevelItemsIconProperty, value);
        }

        public static readonly DependencyProperty TopLevelItemsIconProperty =
            DependencyProperty.RegisterAttached("TopLevelItemsIcon", typeof(object), typeof(MenuHelper));
        #endregion

        #region SubmenuItemForeground
        public static Brush GetSubmenuItemsForeground(Menu menu)
        {
            return (Brush)menu.GetValue(SubmenuItemsForegroundProperty);
        }

        public static void SetSubmenuItemsForeground(Menu menu, Brush value)
        {
            menu.SetValue(SubmenuItemsForegroundProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemsForegroundProperty =
            DependencyProperty.RegisterAttached("SubmenuItemsForeground", typeof(Brush), typeof(MenuHelper));


        public static Brush GetSubmenuItemForeground(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(SubmenuItemForegroundProperty);
        }

        public static void SetSubmenuItemForeground(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(SubmenuItemForegroundProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemForegroundProperty =
            DependencyProperty.RegisterAttached("SubmenuItemForeground", typeof(Brush), typeof(MenuHelper));
        #endregion

        #region SubmenuItemBackground
        public static Brush GetSubmenuItemsBackground(Menu menu)
        {
            return (Brush)menu.GetValue(SubmenuItemsBackgroundProperty);
        }

        public static void SetSubmenuItemsBackground(Menu menu, Brush value)
        {
            menu.SetValue(SubmenuItemsBackgroundProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemsBackgroundProperty =
            DependencyProperty.RegisterAttached("SubmenuItemsBackground", typeof(Brush), typeof(MenuHelper));

        #endregion

        #region SubmenuItemBorderThickness
        public static Thickness GetSubmenuItemsBorderThickness(Menu menu)
        {
            return (Thickness)menu.GetValue(SubmenuItemsBorderThicknessProperty);
        }

        public static void SetSubmenuItemsBorderThickness(Menu menu, Thickness value)
        {
            menu.SetValue(SubmenuItemsBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemsBorderThicknessProperty =
            DependencyProperty.RegisterAttached("SubmenuItemsBorderThickness", typeof(Thickness), typeof(MenuHelper));

        #endregion

        #region SubmenuItemBorderBrush
        public static Brush GetSubmenuItemsBorderBrush(Menu menu)
        {
            return (Brush)menu.GetValue(SubmenuItemsBorderBrushProperty);
        }

        public static void SetSubmenuItemsBorderBrush(Menu menu, Brush value)
        {
            menu.SetValue(SubmenuItemsBorderBrushProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemsBorderBrushProperty =
            DependencyProperty.RegisterAttached("SubmenuItemsBorderBrush", typeof(Brush), typeof(MenuHelper));

        #endregion

        #region SubmenuItemCornerRadius
        public static CornerRadius GetSubmenuItemsCornerRadius(Menu menu)
        {
            return (CornerRadius)menu.GetValue(SubmenuItemsCornerRadiusProperty);
        }

        public static void SetSubmenuItemsCornerRadius(Menu menu, CornerRadius value)
        {
            menu.SetValue(SubmenuItemsCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemsCornerRadiusProperty =
            DependencyProperty.RegisterAttached("SubmenuItemsCornerRadius", typeof(CornerRadius), typeof(MenuHelper));



        public static CornerRadius GetSubmenuItemCornerRadius(MenuItem menuItem)
        {
            return (CornerRadius)menuItem.GetValue(SubmenuItemCornerRadiusProperty);
        }

        public static void SetSubmenuItemCornerRadius(MenuItem menuItem, CornerRadius value)
        {
            menuItem.SetValue(SubmenuItemCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemCornerRadiusProperty =
            DependencyProperty.RegisterAttached("SubmenuItemCornerRadius", typeof(CornerRadius), typeof(MenuHelper));


        #endregion

        #region SubmenuItemHoverBackground
        public static Brush GetSubmenuItemsHoverBackground(Menu menu)
        {
            return (Brush)menu.GetValue(SubmenuItemHoverBackgroundProperty);
        }

        public static void SetSubmenuItemsHoverBackground(Menu menu, Brush value)
        {
            menu.SetValue(SubmenuItemsHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemsHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("SubmenuItemsHoverBackground", typeof(Brush), typeof(MenuHelper));

        public static Brush GetSubmenuItemHoverBackground(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(SubmenuItemHoverBackgroundProperty);
        }

        public static void SetSubmenuItemHoverBackground(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(SubmenuItemHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemHoverBackgroundProperty =
            DependencyProperty.RegisterAttached("SubmenuItemHoverBackground", typeof(Brush), typeof(MenuHelper));
        #endregion

        #region SubmenuItemHoverForeground
        public static Brush GetSubmenuItemsHoverForeground(Menu menu)
        {
            return (Brush)menu.GetValue(SubmenuItemsHoverForegroundProperty);
        }

        public static void SetSubmenuItemsHoverForeground(Menu menu, Brush value)
        {
            menu.SetValue(SubmenuItemsHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemsHoverForegroundProperty =
            DependencyProperty.RegisterAttached("SubmenuItemsHoverForeground", typeof(Brush), typeof(MenuHelper));



        public static Brush GetSubmenuItemHoverForeground(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(SubmenuItemHoverForegroundProperty);
        }

        public static void SetSubmenuItemHoverForeground(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(SubmenuItemHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemHoverForegroundProperty =
            DependencyProperty.RegisterAttached("SubmenuItemHoverForeground", typeof(Brush), typeof(MenuHelper));


        #endregion

        #region SubmenuItemHoverBorderBrush
        public static Brush GetSubmenuItemsHoverBorderBrush(Menu menu)
        {
            return (Brush)menu.GetValue(SubmenuItemsHoverBorderBrushProperty);
        }

        public static void SetSubmenuItemsHoverBorderBrush(Menu menu, Brush value)
        {
            menu.SetValue(SubmenuItemsHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemsHoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("SubmenuItemsHoverBorderBrush", typeof(Brush), typeof(MenuHelper));

        public static Brush GetSubmenuItemHoverBorderBrush(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(SubmenuItemHoverBorderBrushProperty);
        }

        public static void SetSubmenuItemHoverBorderBrush(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(SubmenuItemHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemHoverBorderBrushProperty =
            DependencyProperty.RegisterAttached("SubmenuItemHoverBorderBrush", typeof(Brush), typeof(MenuHelper));
        #endregion

        #region SubmenuItemCheckedBackground
        public static Brush GetSubmenuItemsCheckedBackground(Menu menu)
        {
            return (Brush)menu.GetValue(SubmenuItemCheckedBackgroundProperty);
        }

        public static void SetSubmenuItemsCheckedBackground(Menu menu, Brush value)
        {
            menu.SetValue(SubmenuItemsCheckedBackgroundProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemsCheckedBackgroundProperty =
            DependencyProperty.RegisterAttached("SubmenuItemsCheckedBackground", typeof(Brush), typeof(MenuHelper));

        public static Brush GetSubmenuItemCheckedBackground(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(SubmenuItemCheckedBackgroundProperty);
        }

        public static void SetSubmenuItemCheckedBackground(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(SubmenuItemCheckedBackgroundProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemCheckedBackgroundProperty =
            DependencyProperty.RegisterAttached("SubmenuItemCheckedBackground", typeof(Brush), typeof(MenuHelper));
        #endregion

        #region SubmenuItemCheckedForeground
        public static Brush GetSubmenuItemsCheckedForeground(Menu menu)
        {
            return (Brush)menu.GetValue(SubmenuItemsCheckedForegroundProperty);
        }

        public static void SetSubmenuItemsCheckedForeground(Menu menu, Brush value)
        {
            menu.SetValue(SubmenuItemsCheckedForegroundProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemsCheckedForegroundProperty =
            DependencyProperty.RegisterAttached("SubmenuItemsCheckedForeground", typeof(Brush), typeof(MenuHelper));



        public static Brush GetSubmenuItemCheckedForeground(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(SubmenuItemCheckedForegroundProperty);
        }

        public static void SetSubmenuItemCheckedForeground(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(SubmenuItemCheckedForegroundProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemCheckedForegroundProperty =
            DependencyProperty.RegisterAttached("SubmenuItemCheckedForeground", typeof(Brush), typeof(MenuHelper));


        #endregion

        #region SubmenuItemCheckedBorderBrush
        public static Brush GetSubmenuItemsCheckedBorderBrush(Menu menu)
        {
            return (Brush)menu.GetValue(SubmenuItemsCheckedBorderBrushProperty);
        }

        public static void SetSubmenuItemsCheckedBorderBrush(Menu menu, Brush value)
        {
            menu.SetValue(SubmenuItemsCheckedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemsCheckedBorderBrushProperty =
            DependencyProperty.RegisterAttached("SubmenuItemsCheckedBorderBrush", typeof(Brush), typeof(MenuHelper));

        public static Brush GetSubmenuItemCheckedBorderBrush(MenuItem menuItem)
        {
            return (Brush)menuItem.GetValue(SubmenuItemCheckedBorderBrushProperty);
        }

        public static void SetSubmenuItemCheckedBorderBrush(MenuItem menuItem, Brush value)
        {
            menuItem.SetValue(SubmenuItemCheckedBorderBrushProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemCheckedBorderBrushProperty =
            DependencyProperty.RegisterAttached("SubmenuItemCheckedBorderBrush", typeof(Brush), typeof(MenuHelper));
        #endregion

        #region SubmenuItemsHeight
        public static double GetSubmenuItemsHeight(Menu contextMneu)
        {
            return (double)contextMneu.GetValue(SubmenuItemsHeightProperty);
        }

        public static void SetSubmenuItemsHeight(Menu menu, double value)
        {
            menu.SetValue(SubmenuItemsHeightProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemsHeightProperty =
            DependencyProperty.RegisterAttached("SubmenuItemsHeight", typeof(double), typeof(MenuHelper));
        #endregion

        #region SubmenuItemsWidth
        public static double GetSubmenuItemsWidth(Menu contextMneu)
        {
            return (double)contextMneu.GetValue(SubmenuItemsWidthProperty);
        }

        public static void SetSubmenuItemsWidth(Menu menu, double value)
        {
            menu.SetValue(SubmenuItemsWidthProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemsWidthProperty =
            DependencyProperty.RegisterAttached("SubmenuItemsWidth", typeof(double), typeof(MenuHelper));
        #endregion

        #region SubmenuItemsPadding
        public static Thickness GetSubmenuItemsPadding(Menu menu)
        {
            return (Thickness)menu.GetValue(SubmenuItemsPaddingProperty);
        }

        public static void SetSubmenuItemsPadding(Menu menu, Thickness value)
        {
            menu.SetValue(SubmenuItemsPaddingProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemsPaddingProperty =
            DependencyProperty.RegisterAttached("SubmenuItemsPadding", typeof(Thickness), typeof(MenuHelper));
        #endregion

        #region SubmenuItemsMargin
        public static Thickness GetSubmenuItemsMargin(Menu menu)
        {
            return (Thickness)menu.GetValue(SubmenuItemsMarginProperty);
        }

        public static void SetSubmenuItemsMargin(Menu menu, Thickness value)
        {
            menu.SetValue(SubmenuItemsMarginProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemsMarginProperty =
            DependencyProperty.RegisterAttached("SubmenuItemsMargin", typeof(Thickness), typeof(MenuHelper));
        #endregion

        #region SubmenuItemsIcon
        public static object GetSubmenuItemsIcon(Menu menu)
        {
            return (object)menu.GetValue(SubmenuItemsIconProperty);
        }

        public static void SetSubmenuItemsIcon(Menu menu, object value)
        {
            menu.SetValue(SubmenuItemsIconProperty, value);
        }

        public static readonly DependencyProperty SubmenuItemsIconProperty =
            DependencyProperty.RegisterAttached("SubmenuItemsIcon", typeof(object), typeof(MenuHelper));
        #endregion

        #region DropDownPadding
        public static Thickness GetDropDownPadding(Menu menu)
        {
            return (Thickness)menu.GetValue(DropDownPaddingProperty);
        }

        public static void SetDropDownPadding(Menu menu, Thickness value)
        {
            menu.SetValue(DropDownPaddingProperty, value);
        }

        public static readonly DependencyProperty DropDownPaddingProperty =
            DependencyProperty.RegisterAttached("DropDownPadding", typeof(Thickness), typeof(MenuHelper));
        #endregion

        #region DropDownCornerRadius
        public static CornerRadius GetDropDownCornerRadius(Menu menu)
        {
            return (CornerRadius)menu.GetValue(DropDownCornerRadiusProperty);
        }

        public static void SetDropDownCornerRadius(Menu menu, CornerRadius value)
        {
            menu.SetValue(DropDownCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty DropDownCornerRadiusProperty =
            DependencyProperty.RegisterAttached("DropDownCornerRadius", typeof(CornerRadius), typeof(MenuHelper));
        #endregion

        #region DropDownShadowColor
        public static Color? GetDropDownShadowColor(Menu menu)
        {
            return (Color?)menu.GetValue(DropDownShadowColorProperty);
        }

        public static void SetDropDownShadowColor(Menu menu, Color? value)
        {
            menu.SetValue(DropDownShadowColorProperty, value);
        }

        public static readonly DependencyProperty DropDownShadowColorProperty =
            DependencyProperty.RegisterAttached("DropDownShadowColor", typeof(Color?), typeof(MenuHelper));
        #endregion

        #region DropDownShadowDepth
        public static double GetDropDownShadowDepth(Menu menu)
        {
            return (double)menu.GetValue(DropDownShadowDepthProperty);
        }

        public static void SetDropDownShadowDepth(Menu menu, double value)
        {
            menu.SetValue(DropDownShadowDepthProperty, value);
        }

        public static readonly DependencyProperty DropDownShadowDepthProperty =
            DependencyProperty.RegisterAttached("DropDownShadowDepth", typeof(double), typeof(MenuHelper));
        #endregion

        #region DropDownBorderBrush
        public static Brush GetDropDownBorderBrush(Menu menu)
        {
            return (Brush)menu.GetValue(DropDownBorderBrushProperty);
        }

        public static void SetDropDownBorderBrush(Menu menu, Brush value)
        {
            menu.SetValue(DropDownBorderBrushProperty, value);
        }

        public static readonly DependencyProperty DropDownBorderBrushProperty =
            DependencyProperty.RegisterAttached("DropDownBorderBrush", typeof(Brush), typeof(MenuHelper));
        #endregion

        #region DropDownBorderThickness
        public static Thickness GetDropDownBorderThickness(Menu menu)
        {
            return (Thickness)menu.GetValue(DropDownBorderThicknessProperty);
        }

        public static void SetDropDownBorderThickness(Menu menu, Thickness value)
        {
            menu.SetValue(DropDownBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty DropDownBorderThicknessProperty =
            DependencyProperty.RegisterAttached("DropDownBorderThickness", typeof(Thickness), typeof(MenuHelper));
        #endregion

        #region DropDownBackground
        public static Brush GetDropDownBackground(Menu menu)
        {
            return (Brush)menu.GetValue(DropDownBackgroundProperty);
        }

        public static void SetDropDownBackground(Menu menu, Brush value)
        {
            menu.SetValue(DropDownBackgroundProperty, value);
        }

        public static readonly DependencyProperty DropDownBackgroundProperty =
            DependencyProperty.RegisterAttached("DropDownBackground", typeof(Brush), typeof(MenuHelper));
        #endregion

        #region DropDownWidth
        public static double GetDropDownWidth(Menu menu)
        {
            return (double)menu.GetValue(DropDownWidthProperty);
        }

        public static void SetDropDownWidth(Menu menu, double value)
        {
            menu.SetValue(DropDownWidthProperty, value);
        }

        public static readonly DependencyProperty DropDownWidthProperty =
            DependencyProperty.RegisterAttached("DropDownWidth", typeof(double), typeof(MenuHelper));
        #endregion

        #region DropDownMinWidth
        public static double GetDropDownMinWidth(Menu menu)
        {
            return (double)menu.GetValue(DropDownMinWidthProperty);
        }

        public static void SetDropDownMinWidth(Menu menu, double value)
        {
            menu.SetValue(DropDownMinWidthProperty, value);
        }

        public static readonly DependencyProperty DropDownMinWidthProperty =
            DependencyProperty.RegisterAttached("DropDownMinWidth", typeof(double), typeof(MenuHelper));
        #endregion

        #region DropDownMaxWidth
        public static double GetDropDownMaxWidth(Menu menu)
        {
            return (double)menu.GetValue(DropDownMaxWidthProperty);
        }

        public static void SetDropDownMaxWidth(Menu menu, double value)
        {
            menu.SetValue(DropDownMaxWidthProperty, value);
        }

        public static readonly DependencyProperty DropDownMaxWidthProperty =
            DependencyProperty.RegisterAttached("DropDownMaxWidth", typeof(double), typeof(MenuHelper), new PropertyMetadata(double.PositiveInfinity));
        #endregion

        #region DropDownMaxHeight
        public static double GetDropDownMaxHeight(Menu menu)
        {
            return (double)menu.GetValue(DropDownMaxHeightProperty);
        }

        public static void SetDropDownMaxHeight(Menu menu, double value)
        {
            menu.SetValue(DropDownMaxHeightProperty, value);
        }

        public static readonly DependencyProperty DropDownMaxHeightProperty =
            DependencyProperty.RegisterAttached("DropDownMaxHeight", typeof(double), typeof(MenuHelper), new PropertyMetadata(double.PositiveInfinity));
        #endregion


        #endregion

        #region Internal Properties

        #region MenuItemHook
        internal static bool GetMenuItemHook(MenuItem menuItem)
        {
            return (bool)menuItem.GetValue(MenuItemHookProperty);
        }

        internal static void SetMenuItemHook(MenuItem menuItem, bool value)
        {
            menuItem.SetValue(MenuItemHookProperty, value);
        }

        internal static readonly DependencyProperty MenuItemHookProperty =
            DependencyProperty.RegisterAttached("MenuItemHook", typeof(bool), typeof(MenuHelper), new PropertyMetadata(OnMenuItemHookChanged));
        #endregion

        #endregion

        #region Functions
        private static void OnMenuItemHookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var menuItem = (MenuItem)d;
            menuItem.MouseEnter -= OnMenuItemMouseEnter;
            menuItem.MouseLeave -= OnMenuItemMouseLeave;

            if ((bool)e.NewValue)
            {
                menuItem.MouseEnter += OnMenuItemMouseEnter;
                menuItem.MouseLeave += OnMenuItemMouseLeave;
            }
        }

        private static void OnMenuItemMouseEnter(object sender, MouseEventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var isTopLevel = menuItem.Role == MenuItemRole.TopLevelHeader || menuItem.Role == MenuItemRole.TopLevelItem;

            var dic = new Dictionary<DependencyProperty, Brush>();
            var hoverBackground = isTopLevel ? GetTopLevelItemHoverBackground(menuItem) : GetSubmenuItemHoverBackground(menuItem);
            var hoverForeground = isTopLevel ? GetTopLevelItemHoverForeground(menuItem) : GetSubmenuItemHoverForeground(menuItem);
            var hoverBorderBrush = isTopLevel ? GetTopLevelItemHoverBorderBrush(menuItem) : GetSubmenuItemHoverBorderBrush(menuItem);

            if (hoverBackground != null)
            {
                dic.Add(MenuItem.BackgroundProperty, hoverBackground);
            }
            if (hoverForeground != null)
            {
                dic.Add(MenuItem.ForegroundProperty, hoverForeground);
            }
            if (hoverBorderBrush != null)
            {
                dic.Add(MenuItem.BorderBrushProperty, hoverBorderBrush);
            }
            if (dic.Any())
            {

                UIElementUtils.BeginStoryboard(menuItem, dic);
            }
        }

        private static void OnMenuItemMouseLeave(object sender, MouseEventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var isTopLevel = menuItem.Role == MenuItemRole.TopLevelHeader || menuItem.Role == MenuItemRole.TopLevelItem;

            var hoverBackground = isTopLevel ? GetTopLevelItemHoverBackground(menuItem) : GetSubmenuItemHoverBackground(menuItem);
            var hoverForeground = isTopLevel ? GetTopLevelItemHoverForeground(menuItem) : GetSubmenuItemHoverForeground(menuItem);
            var hoverBorderBrush = isTopLevel ? GetTopLevelItemHoverBorderBrush(menuItem) : GetSubmenuItemHoverBorderBrush(menuItem);

            var list = new List<DependencyProperty>();
            if (hoverBackground != null)
            {
                list.Add(MenuItem.BackgroundProperty);
            }
            if (hoverForeground != null)
            {
                list.Add(MenuItem.ForegroundProperty);
            }
            if (hoverBorderBrush != null)
            {
                list.Add(MenuItem.BorderBrushProperty);
            }
            if (list.Any())
            {
                UIElementUtils.BeginStoryboard(menuItem, list);
            }
        }
        #endregion
    }
}

