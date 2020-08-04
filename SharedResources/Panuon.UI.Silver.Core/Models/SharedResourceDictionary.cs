using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Panuon.UI.Silver.Core
{
    public class SharedResourceDictionary : ResourceDictionary
    {
        #region Fields
        private static IDictionary<Uri, ResourceDictionary> _sharedDictionaries = new Dictionary<Uri, ResourceDictionary>();

        private Uri _sourceUri;
        #endregion

        #region Properties
        public new Uri Source
        {
            get
            {
                return _sourceUri;
            }
            set
            {
                _sourceUri = value;

                if (!_sharedDictionaries.ContainsKey(value))
                {
                    base.Source = value;
                    _sharedDictionaries.Add(value, this);
                }
                else
                {
                    MergedDictionaries.Add(_sharedDictionaries[value]);
                }
            }
        }
        #endregion

    }
}
