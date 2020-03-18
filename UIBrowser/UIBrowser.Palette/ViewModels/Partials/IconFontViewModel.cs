using System.Collections.Generic;
using System.Windows.Controls;
using UIBrowser.Code;
using UIBrowser.Core;
using UIBrowser.Palette.ViewModels.Base;

namespace UIBrowser.Palette.ViewModels.Partials
{
    public class IconFontViewModel : ViewModelBase
    {
        #region Fields
        private static CodeGenerator _codeGenerator;
        #endregion

        #region Ctor
        static IconFontViewModel()
        {
            _codeGenerator = new CodeGenerator(typeof(TextBlock));
            _codeGenerator.AddProperty(TextBlock.ForegroundProperty, null)
                .AddProperty(TextBlock.TextProperty, null)
                .AddProperty(TextBlock.FontFamilyProperty, "{StaticResource PanuonIconFont}");
        }
        #endregion

        #region Properties

        #region CodeGenerator
        public override CodeGenerator CodeGenerator { get { return _codeGenerator; } }
        #endregion

        #region Icon
        public char Icon
        {
            get { return _icon; }
            set { _icon = value; NotifyOfPropertyChange(); }
        }
        private char _icon;
        #endregion

        #endregion

        #region Methods

        public override PaletteComponent GetAvaiableComponents()
        {
            return PaletteComponent.Background |
                PaletteComponent.Foreground;
        }

        public override void UpdateValues(IDictionary<PaletteComponent, object> values)
        {
            foreach (var value in values)
            {
                switch (value.Key)
                {
                    case PaletteComponent.Content:
                        Icon = (char)value.Value;
                        break;
                }
            }
            UpdateCodeGenerator();
        }


        #endregion

        #region Function
        private void UpdateCodeGenerator()
        {
            _codeGenerator.Properties[0].Value = Foreground;
            _codeGenerator.Properties[1].Value = $"&#x{((int)Icon).ToString("X4").ToLower()};";
        }
        #endregion
    }
}
