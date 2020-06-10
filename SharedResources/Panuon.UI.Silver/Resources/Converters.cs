using System;
using System.Collections.Generic;
using System.Text;

namespace Panuon.UI.Silver.Resources
{
    public static class Converters
    {
        #region Visibility
        public const string TrueToVisibleConverter = nameof(TrueToVisibleConverter);

        public const string TrueToCollapseConverter = nameof(TrueToCollapseConverter);
        #endregion

        #region Reverse
        public const string TrueToFalseConverter = nameof(TrueToFalseConverter);

        #endregion

        #region Math
        public const string DoubleMinusConverter = nameof(DoubleMinusConverter);

        public const string DoublePlusConverter = nameof(DoublePlusConverter);

        public const string DoubleMultiplyByConverter = nameof(DoubleMultiplyByConverter);

        public const string DoubleDivideByConverter = nameof(DoubleDivideByConverter);

        #endregion

        #region Convert
        public const string StringFormatConverter = nameof(StringFormatConverter);
        #endregion

    }
}
