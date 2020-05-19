using System;
using System.Collections.Generic;
using System.Text;

namespace Panuon.UI.Silver.Internal.Utils
{
    internal static class LocalizationUtils
    {
        #region Fields
        private static IDictionary<string, IDictionary<string, string>> _localizedStringDictionary;
        #endregion

        #region Ctor
        static LocalizationUtils()
        {
            _localizedStringDictionary = new Dictionary<string, IDictionary<string, string>>();
            _localizedStringDictionary.Add(nameof(Yes), new Dictionary<string, string>()
            {
                { "zh-CN", "是" },
                { "ja-JP", "はい" },
                { "en-US", "Yes" },

            });
            _localizedStringDictionary.Add(nameof(No), new Dictionary<string, string>()
            {
                { "zh-CN", "否" },
                { "ja-JP", "いいえ" },
                { "en-US", "No" },
            });
            _localizedStringDictionary.Add(nameof(Cancel), new Dictionary<string, string>()
            {
                { "zh-CN", "取 消" },
                { "ja-JP", "キャンセル" },
                { "en-US", "Cancel" },
            });
            _localizedStringDictionary.Add(nameof(OK), new Dictionary<string, string>()
            {
                { "zh-CN", "确 定" },
                { "ja-JP", "了 解" },
                { "en-US", "OK" },
            });
        }
        #endregion

        #region Properties
        public static string Yes => GetLocalizedString(nameof(Yes));

        public static string No => GetLocalizedString(nameof(No));

        public static string Cancel => GetLocalizedString(nameof(Cancel));

        public static string OK => GetLocalizedString(nameof(OK));
        #endregion

        #region Function
        private static string GetLocalizedString(string propertyName)
        {
            if (_localizedStringDictionary.ContainsKey(propertyName))
            {
                var ietf = System.Threading.Thread.CurrentThread.CurrentUICulture.IetfLanguageTag;
                var stringDictionary = _localizedStringDictionary[propertyName];
                if (stringDictionary.ContainsKey(ietf))
                    return stringDictionary[ietf];
                else if (stringDictionary.ContainsKey("en-US"))
                    return stringDictionary["en-US"];
            }
            return null;
        }
        #endregion
    }
}
