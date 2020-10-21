using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using UIBrowser.Core;
using UIBrowser.Models;

namespace UIBrowser.ViewModels
{
    [Export(typeof(IPartialView))]
    public class ShellViewModel : Conductor<IPartialView>.Collection.OneActive
    {
        #region Fields
        private static IEnumerable<IPartialView> _partialViews;
        #endregion

        #region Ctor
        static ShellViewModel()
        {
            _partialViews = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(IPartialView).IsAssignableFrom(x))
                .Select(x => (IPartialView)Activator.CreateInstance(x))
                .OrderBy(x => x.Caption);
        }

        [ImportingConstructor]
        public ShellViewModel()
        {
            if (_partialViews != null)
            {
                InitPartialViewItems(_partialViews);
            }
        }
        #endregion

        #region Properties

        #region SelectedDate
        public DateTime SelectedDate { get => _selectedDate; set => Set(ref _selectedDate, value); }
        private DateTime _selectedDate = DateTime.Now.Date;
        #endregion

        #region IsPaletteEnabled
        public bool IsPaletteEnabled { get => _isPaletteEnabled; set => Set(ref _isPaletteEnabled, value); }
        private bool _isPaletteEnabled;
        #endregion

        #region IsPaletteOpen
        public bool IsPaletteOpen { get => _isPaletteOpen; set => Set(ref _isPaletteOpen, value); }
        private bool _isPaletteOpen;
        #endregion 

        #region PartialViews
        public BindableCollection<PartialViewltem> PartialViewItems { get => _partialViewItems; set => Set(ref _partialViewItems, value); }
        private BindableCollection<PartialViewltem> _partialViewItems;
        #endregion

        #endregion

        #region Methods

        #region ActivateView
        public void ActivateView(PartialViewltem partialViewltem)
        {
            if(partialViewltem == null || partialViewltem.ViewType == null)
            {
                return;
            }
            ActivateItem(partialViewltem.Instance);
            IsPaletteEnabled = partialViewltem.Instance is IPaletteView;
        }
        #endregion

        #endregion

        #region Event Handlers
        public void OnKeyboradKeyDown(KeyEventArgs args)
        {
            if (args.Key == Key.LeftCtrl || args.Key == Key.RightCtrl)
            {
                (GetView() as System.Windows.Window).Cursor = Cursors.Pen;
            }
        }

        public void OnKeyboradKeyUp(KeyEventArgs args)
        {
            if(args.Key == Key.LeftCtrl || args.Key == Key.RightCtrl)
            {
                (GetView() as System.Windows.Window).Cursor = Cursors.Arrow;
            }
        }
        #endregion

        #region Functions

        #region InitPartialViewltem


        private void InitPartialViewItems(IEnumerable<IPartialView> views)
        {
            PartialViewItems = new BindableCollection<PartialViewltem>();

            foreach (var view in views)
            {
                AddPartialViewItem(null, view, view.LabelLevels.ToList());
            }
        }

        private void AddPartialViewItem(PartialViewltem parentItem, IPartialView view, IList<string> labelLevels)
        {
            if (labelLevels == null || !labelLevels.Any())
            {
                var childItem = new PartialViewltem()
                {
                    DisplayName = view.Caption,
                    ViewType = view.GetType(),
                };
                if(parentItem == null)
                {
                    PartialViewItems.Add(childItem);
                    return;
                }
                else
                {
                    if(parentItem.Items == null)
                    {
                        parentItem.Items = new BindableCollection<PartialViewltem>();
                    }
                    parentItem.Items.Add(childItem);
                    return;
                }
            }
            else
            {
                if(parentItem == null)
                {
                    parentItem = PartialViewItems.FirstOrDefault(x => x.DisplayName == labelLevels.First());
                }
                else
                {
                    parentItem = parentItem.Items.FirstOrDefault(x => x.DisplayName == labelLevels.First());
                }
                
                if (parentItem == null)
                {
                    parentItem = new PartialViewltem()
                    {
                        DisplayName = labelLevels.First(),
                        IsExpanded = true,
                    };
                    PartialViewItems.Add(parentItem);
                }
                labelLevels.RemoveAt(0);
                AddPartialViewItem(parentItem, view, labelLevels);
            }
        }

        #endregion

        #endregion
    }
}
