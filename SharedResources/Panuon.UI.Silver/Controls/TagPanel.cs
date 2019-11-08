using Panuon.UI.Silver.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Specialized;

namespace Panuon.UI.Silver
{
    public class TagPanel : ItemsControl
    {
        public TagPanel()
        {
            AlternationBackgrounds = new ObservableCollection<Brush>();
            AlternationHoverBrushes = new ObservableCollection<Brush>();

            var factoryPanel = new FrameworkElementFactory(typeof(AnimateWrapPanel));
            factoryPanel.SetValue(AnimateWrapPanel.IsItemsHostProperty, true);
            ItemsPanel = new ItemsPanelTemplate()
            {
                VisualTree = factoryPanel
            };
        }

        #region Property
        /// <summary>
        /// Gets or sets item height.
        /// </summary>
        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register("ItemHeight", typeof(double), typeof(TagPanel));

        /// <summary>
        /// Gets or sets alternation background list.
        /// </summary>
        public ObservableCollection<Brush> AlternationBackgrounds
        {
            get { return (ObservableCollection<Brush>)GetValue(AlternationBackgroundsProperty); }
            set { SetValue(AlternationBackgroundsProperty, value); }
        }

        public static readonly DependencyProperty AlternationBackgroundsProperty =
            DependencyProperty.Register("AlternationBackgrounds", typeof(ObservableCollection<Brush>), typeof(TagPanel));

        /// <summary>
        /// Gets or sets alternation hover backgrounds
        /// </summary>
        public ObservableCollection<Brush> AlternationHoverBrushes
        {
            get { return (ObservableCollection<Brush>)GetValue(AlternationHoverBrushesProperty); }
            set { SetValue(AlternationHoverBrushesProperty, value); }
        }

        public static readonly DependencyProperty AlternationHoverBrushesProperty =
            DependencyProperty.Register("AlternationHoverBrushes", typeof(ObservableCollection<Brush>), typeof(TagPanel));

        /// <summary>
        /// Gets or sets corner radius.
        /// </summary>
        public CornerRadius ItemCornerRadius
        {
            get { return (CornerRadius)GetValue(ItemCornerRadiusProperty); }
            set { SetValue(ItemCornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty ItemCornerRadiusProperty =
            DependencyProperty.Register("ItemCornerRadius", typeof(CornerRadius), typeof(TagPanel));

        /// <summary>
        /// Gets or sets removable.
        /// </summary>
        public bool ItemRemovable
        {
            get { return (bool)GetValue(ItemRemovableProperty); }
            set { SetValue(ItemRemovableProperty, value); }
        }

        public static readonly DependencyProperty ItemRemovableProperty =
            DependencyProperty.Register("ItemRemovable", typeof(bool), typeof(TagPanel), new PropertyMetadata(true));

        /// <summary>
        /// Gets or sets removable member path.
        /// </summary>
        public string RemovableMemberPath
        {
            get { return (string)GetValue(RemovableMemberPathProperty); }
            set { SetValue(RemovableMemberPathProperty, value); }
        }

        public static readonly DependencyProperty RemovableMemberPathProperty =
            DependencyProperty.Register("RemovableMemberPath", typeof(string), typeof(TagPanel));


        #endregion

        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
        }

        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TagItem();
        }
    }
}
