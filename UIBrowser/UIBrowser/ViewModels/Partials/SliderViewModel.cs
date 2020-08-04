﻿using Panuon.UI.Silver;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UIBrowser.Core;
using UIBrowser.Core.Properties;

namespace UIBrowser.ViewModels.Partials
{
    public class SliderViewModel : ViewModelBase, IPaletteView
    {
        #region Properties
        public string Caption => Resources.Slider;

        public string[] LabelLevels => new string[] { Resources.NativeControls };

        public IDictionary<string, DependencyProperty> PaletteProperties => new Dictionary<string, DependencyProperty>
        {
        };

        public IList<DependencyProperty> GeneralProperties => new List<DependencyProperty>
        {
        };
        #endregion
    }
}
