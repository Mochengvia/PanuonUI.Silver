using System.Collections.Generic;

namespace Panuon.UI.Silver.Internal.Utils
{
    internal static class LocalizationUtils
    {
        #region Fields
        private static IDictionary<string, string> _localizedStringDictionary;
        #endregion

        #region Ctor
        static LocalizationUtils()
        {
            _localizedStringDictionary = new Dictionary<string, string>();

            var ietf = System.Threading.Thread.CurrentThread.CurrentUICulture.IetfLanguageTag;
            switch (ietf)
            {
                case "zh-CN":
                    _localizedStringDictionary.Add(nameof(Yes), "是");
                    _localizedStringDictionary.Add(nameof(No), "否");
                    _localizedStringDictionary.Add(nameof(Cancel), "取 消");
                    _localizedStringDictionary.Add(nameof(OK), "确 定");
                    break;
                case "ja-JP":
                    _localizedStringDictionary.Add(nameof(Yes), "はい");
                    _localizedStringDictionary.Add(nameof(No), "いいえ");
                    _localizedStringDictionary.Add(nameof(Cancel), "キャンセル");
                    _localizedStringDictionary.Add(nameof(OK), "了 解");
                    break;
                default:
                    _localizedStringDictionary.Add(nameof(Yes), "Yes");
                    _localizedStringDictionary.Add(nameof(No), "No");
                    _localizedStringDictionary.Add(nameof(Cancel), "Cancel");
                    _localizedStringDictionary.Add(nameof(OK), "OK");
                    break;
            }
        }
        #endregion

        #region Properties
        public static string Yes => _localizedStringDictionary[nameof(Yes)];

        public static string No => _localizedStringDictionary[nameof(No)];

        public static string Cancel => _localizedStringDictionary[nameof(Cancel)];

        public static string OK => _localizedStringDictionary[nameof(OK)];
        #endregion
    }

}
