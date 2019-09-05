using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panuon.UI.Silver.Utils
{
    internal static class Cache
    {
        public static string Language
        {
            get
            {
                if (_language.IsNullOrEmpty())
                {
                    _language = System.Threading.Thread.CurrentThread.CurrentUICulture.IetfLanguageTag;
                }
                return _language;
            }
        }
        private static string _language;
    }
}
