using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Panuon.UI.Silver
{
    [ContentProperty(nameof(FormGroups))]
    public class Form : Control
    {
        #region Fields
        #endregion

        #region Ctor
        static Form()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Form), new FrameworkPropertyMetadata(typeof(Form)));
        }
        #endregion

        #region Properties

        #region Forms
        public ObservableCollection<FormGroup> FormGroups
        {
            get 
            {
                if(_formGroups == null)
                {
                    _formGroups = new ObservableCollection<FormGroup>();
                }
                return _formGroups;
            }
        }
        private ObservableCollection<FormGroup> _formGroups;
        #endregion

        #region HeaderPadding
        public Thickness HeaderPadding
        {
            get { return (Thickness)GetValue(HeaderPaddingProperty); }
            set { SetValue(HeaderPaddingProperty, value); }
        }

        public static readonly DependencyProperty HeaderPaddingProperty =
            DependencyProperty.Register("HeaderPadding", typeof(Thickness), typeof(Form));
        #endregion

        #region HeaderHeight
        public GridLength HeaderHeight
        {
            get { return (GridLength)GetValue(HeaderHeightProperty); }
            set { SetValue(HeaderHeightProperty, value); }
        }

        public static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.Register("HeaderHeight", typeof(GridLength), typeof(Form));
        #endregion

        #region HeaderWidth
        public GridLength HeaderWidth
        {
            get { return (GridLength)GetValue(HeaderWidthProperty); }
            set { SetValue(HeaderWidthProperty, value); }
        }

        public static readonly DependencyProperty HeaderWidthProperty =
            DependencyProperty.Register("HeaderWidth", typeof(GridLength), typeof(Form));
        #endregion

        #region RowSpacing
        public double RowSpacing
        {
            get { return (double)GetValue(RowSpacingProperty); }
            set { SetValue(RowSpacingProperty, value); }
        }

        public static readonly DependencyProperty RowSpacingProperty =
            DependencyProperty.Register("RowSpacing", typeof(double), typeof(Form));
        #endregion

        #region RowHeight
        public double RowHeight
        {
            get { return (double)GetValue(RowHeightProperty); }
            set { SetValue(RowHeightProperty, value); }
        }

        public static readonly DependencyProperty RowHeightProperty =
            DependencyProperty.Register("RowHeight", typeof(double), typeof(Form));
        #endregion
        
        #endregion

        #region Methods
        #endregion

        #region Event Handlers
        #endregion

        #region Functions
        #endregion
    }
}
