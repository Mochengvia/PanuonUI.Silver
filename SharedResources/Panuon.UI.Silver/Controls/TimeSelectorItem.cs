using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Panuon.UI.Silver
{
    public class TimeSelectorItem : ToggleButton
    {
        #region Fields
        #endregion

        #region Ctor
        static TimeSelectorItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeSelectorItem), new FrameworkPropertyMetadata(typeof(TimeSelectorItem)));
        }
        #endregion
    }
}
