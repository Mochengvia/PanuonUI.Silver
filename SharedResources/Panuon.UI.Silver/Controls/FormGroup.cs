using Panuon.UI.Silver.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver
{
    public class FormGroup : Grid, IFormItem
    {
        #region Ctor

        #endregion

        #region Properties

        #endregion

        #region Override
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            ColumnDefinitions.Clear();
            var index = 0;
            foreach (UIElement child in InternalChildren)
            {
                var groupItem = child as FormGroupItem;
                if (groupItem != null)
                {
                    ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLengthUtils.ConvertToGridLength(groupItem.GroupWidth) });
                    Grid.SetColumn(groupItem, index);
                    index++;
                }
            }
            base.OnRenderSizeChanged(sizeInfo);
        }
        #endregion
    }
}
