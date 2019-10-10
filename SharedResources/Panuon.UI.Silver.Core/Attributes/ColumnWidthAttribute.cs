using System;

namespace Panuon.UI.Silver.Core
{

    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnWidthAttribute : Attribute
    {
        /// <summary>
        /// Auto column width.
        /// </summary>
        public ColumnWidthAttribute()
        {
            Width = "auto";
        }

        /// <summary>
        /// Custom column width. Pixel, star or auto.
        /// </summary>
        /// <param name="width"></param>
        public ColumnWidthAttribute(string width)
        {
            Width = width;
        }

        public string Width { get; set; }
    }
}
