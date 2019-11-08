using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Reflection;

namespace UIBrowser
{
    public class LocalizationManager
    {
        private static ResourceManager _resourceManager = new ResourceManager(Properties.Resource.ResourceManager.BaseName, Assembly.GetExecutingAssembly());

        public static string GetString(string localizeKey)
        {
            return _resourceManager.GetString(localizeKey);
        }
    }
}
