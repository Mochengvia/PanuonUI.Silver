using System.Windows;

namespace UIBrowser.Code
{
    public class CodeGeneratorEffectiveProperty : CodeGeneratorProperty
    {
        public CodeGeneratorEffectiveProperty(DependencyProperty property, object value)
            : base(property, value)
        {
        }

        #region Properties
        public CodeGeneratorPropertyCollection Properties { get; } = new CodeGeneratorPropertyCollection();
        #endregion
    }
}
