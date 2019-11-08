using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIBrowser.Models;
using UIBrowser.Views.Partials;
using UIBrowser.Views.Partials.Native;

namespace UIBrowser.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        #region Ctor
        static MainViewModel()
        {
            //Introduction
            MainViewPages.Add(new MainViewPageItem(Properties.Resource.Introduction, typeof(IntroductionView))
            {
                IsSelected = true
            });
            //Overview
            MainViewPages.Add(new MainViewPageItem(Properties.Resource.Overview, typeof(OverviewView)));
            //Native
            var nativeCategory = new MainViewPageItem(Properties.Resource.NativeControls)
            {
                IsExpanded = true
            };
            nativeCategory.Items.Add(new MainViewPageItem(Properties.Resource.WindowX, typeof(WindowXView)));
            nativeCategory.Items.Add(new MainViewPageItem(Properties.Resource.Button, typeof(ButtonView)));
            MainViewPages.Add(nativeCategory);
        }
        #endregion

        #region Property
        public static ObservableCollection<MainViewPageItem> MainViewPages { get; } = new ObservableCollection<MainViewPageItem>();
        #endregion

    }
}
