using Caliburn.Micro;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UIBrowser.Core;

namespace UIBrowser.Utils
{
    public static class ViewUtils
    {
        public static IEnumerable<ViewInfo> GetViewInfos()
        {
            var assembly = Assembly.GetEntryAssembly();
            return assembly.GetTypes()
                .Where(x => x.FullName.StartsWith("UIBrowser.ViewModels.Partials") && x.IsSubclassOf(typeof(Screen)))
                .Select(x => new ViewInfo()
                {
                    DisplayName = x.Name.Remove(x.Name.Length - 9),
                    ViewType = x
                });
        }
    }
}
