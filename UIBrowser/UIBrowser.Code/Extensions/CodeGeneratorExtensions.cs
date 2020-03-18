using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UIBrowser.Code
{
    public static class CodeGeneratorExtensions
    {




        public static CodeGenerator AddProperty(this CodeGenerator codeGenerator, DependencyProperty property, object value)
        {
            codeGenerator.Properties.Add(new CodeGeneratorProperty(property, value));
            return codeGenerator;
        }

        public static CodeGeneratorEffectiveProperty AddProperty(this CodeGeneratorEffectiveProperty effectiveProperty, DependencyProperty property, object value)
        {
            effectiveProperty.Properties.Add(new CodeGeneratorProperty(property, value));
            return effectiveProperty;
        }
    }
}
