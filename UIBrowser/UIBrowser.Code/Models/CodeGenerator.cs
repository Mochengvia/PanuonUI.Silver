using Panuon.UI.Silver.Core;
using System;
using System.Linq;
using System.Text;

namespace UIBrowser.Code
{
    public class CodeGenerator
    {
        #region Ctor
        public CodeGenerator(Type type)
        {
            Type = type;
        }
        #endregion

        #region Properties
        public Type Type { get; }

        public CodeGeneratorPropertyCollection Properties { get; } = new CodeGeneratorPropertyCollection();
        #endregion

        #region Methods
        public string ToXamlCode()
        {
            var codeBuilder = new StringBuilder();
            codeBuilder.Append($"<{Type.Name} ");

            if (Properties.Any())
            {
                for (int i = 0; i < Properties.Count; i++)
                {
                    var property = Properties[i];
                    codeBuilder.Append($"{property.Property.Name}=\"{property.Value}\"");
                    if (i < Properties.Count - 1)
                    {
                        codeBuilder.Append(" ");
                    }
                }
            }
            codeBuilder.Append(">\n");

            codeBuilder.Append($"</{Type.Name}>");
            return codeBuilder.ToString();
        }

        public string ToStyleCode()
        {
            var codeBuilder = new StringBuilder();

            return codeBuilder.ToString();
        }

        #endregion
    }
}
