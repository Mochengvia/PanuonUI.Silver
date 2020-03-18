using Caliburn.Micro;
using System.Collections.Generic;
using System.Windows.Media;
using UIBrowser.Code;
using UIBrowser.Core;
using UIBrowser.Palette.Constracts.Interfaces;

namespace UIBrowser.Palette.ViewModels.Base
{
    public abstract class ViewModelBase : Screen, IPaletteView
    {
        #region Properties

        #region Foreground
        public Brush Foreground
        {
            get { return _foreground; }
            set { _foreground = value; NotifyOfPropertyChange(); }
        }
        private Brush _foreground = Brushes.Black;
        #endregion

        #region Background
        public Brush Background
        {
            get { return _Background; }
            set { _Background = value; NotifyOfPropertyChange(); }
        }
        private Brush _Background;
        #endregion

        #region BorderBrush
        public Brush BorderBrush
        {
            get { return _BorderBrush; }
            set { _BorderBrush = value; NotifyOfPropertyChange(); }
        }
        private Brush _BorderBrush;
        #endregion

        #region CodeGenerator
        public abstract CodeGenerator CodeGenerator { get; }
        #endregion

        #endregion

        #region Abstract Methods
        public abstract PaletteComponent GetAvaiableComponents();

        public abstract void UpdateValues(IDictionary<PaletteComponent, object> values);
        #endregion
    }
}
