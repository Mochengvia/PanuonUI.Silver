using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver.Internal.Utils
{
    internal static class StoryboardUtils
    {
        #region Methods

        #region BeginBrushStoryboard

        public static void BeginBrushStoryboard(DependencyObject dependencyObj, IDictionary<DependencyProperty, Brush> toDictionary)
        {
            var storyboard = new Storyboard();
            foreach (var keyValue in toDictionary)
            {
                var anima = new BrushAnimation()
                {
                    To = keyValue.Value,
                    Duration = TimeSpan.FromSeconds(0.4),
                };
                Storyboard.SetTarget(anima, dependencyObj);
                Storyboard.SetTargetProperty(anima, new PropertyPath(keyValue.Key));
                storyboard.Children.Add(anima);
            }
            storyboard.Begin();
        }

        public static void BeginBrushStoryboard(DependencyObject dependencyObj, IList<DependencyProperty> dpList)
        {
            var storyboard = new Storyboard();
            foreach (var dp in dpList)
            {
                var anima = new BrushAnimation()
                {
                    Duration = TimeSpan.FromSeconds(0.4),
                };
                Storyboard.SetTarget(anima, dependencyObj);
                Storyboard.SetTargetProperty(anima, new PropertyPath(dp));
                storyboard.Children.Add(anima);
            }
            storyboard.Begin();
        }
        #endregion

        #endregion
    }
}
