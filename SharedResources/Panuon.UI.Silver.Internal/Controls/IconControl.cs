using Panuon.UI.Silver.Internal.TemplateSelectors;
using System.Windows;
using System.Windows.Controls;

namespace Panuon.UI.Silver.Internal.Controls
{
    internal class IconControl : ContentControl
    {
        #region Ctor
        static IconControl()
        {
            ContentTemplateSelectorProperty.OverrideMetadata(typeof(IconControl), new FrameworkPropertyMetadata(new IconControlDataTemplateSelector()));
        }
        #endregion

        #region Override
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
        }
        #endregion
    }
}
