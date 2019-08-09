using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Panuon.UI.Silver
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataGridColumnAttribute : Attribute
    {
        public DataGridColumnAttribute(bool ignore)
        {
            Ignore = ignore;
        }

        public DataGridColumnAttribute(string displayName)
        {
            DisplayName = displayName;
        }

        public DataGridColumnAttribute(string displayName, string width)
        {
            DisplayName = displayName;
            Width = width;
        }

        public string DisplayName { get; set; }

        public bool Ignore { get; set; }

        public string Width { get; set; }
    }
}
