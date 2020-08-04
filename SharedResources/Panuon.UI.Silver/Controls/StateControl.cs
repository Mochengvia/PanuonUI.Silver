using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Panuon.UI.Silver
{
    [ContentProperty(nameof(Items))]
    public class StateControl : Control
    {
        #region Ctor
        static StateControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StateControl), new FrameworkPropertyMetadata(typeof(StateControl)));
        }
        #endregion

        #region Events
        public event RoutedEventHandler CurrentStateChanged
        {
            add { AddHandler(CurrentStateChangedEvent, value); }
            remove { RemoveHandler(CurrentStateChangedEvent, value); }
        }

        public static readonly RoutedEvent CurrentStateChangedEvent =
            EventManager.RegisterRoutedEvent("CurrentStateChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(StateControl));
        #endregion

        #region Properties

        #region CurrentState
        public object CurrentState
        {
            get { return (object)GetValue(CurrentStateProperty); }
            set { SetValue(CurrentStateProperty, value); }
        }

        public static readonly DependencyProperty CurrentStateProperty =
            DependencyProperty.Register("CurrentState", typeof(object), typeof(StateControl), new PropertyMetadata(OnCurrentStateChanged));
        #endregion

        #region Content
        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(StateControl));
        #endregion

        #region ContentTemplate
        public DataTemplate ContentTemplate
        {
            get { return (DataTemplate)GetValue(ContentTemplateProperty); }
            set { SetValue(ContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty ContentTemplateProperty =
            DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(StateControl));
        #endregion

        #region ContentTemplateSelector
        public DataTemplateSelector ContentTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(ContentTemplateSelectorProperty); }
            set { SetValue(ContentTemplateSelectorProperty, value); }
        }

        public static readonly DependencyProperty ContentTemplateSelectorProperty =
            DependencyProperty.Register("ContentTemplateSelector", typeof(DataTemplateSelector), typeof(StateControl));
        #endregion

        #region Items
        public Collection<StateItem> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new Collection<StateItem>();
                }
                return _items;
            }
        }
        private Collection<StateItem> _items;

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(Collection<StateItem>), typeof(StateControl));
        #endregion

        #endregion

        #region Overrides
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            OnStateChanged();
        }

        private static void OnCurrentStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var stateControl = d as StateControl;
            stateControl.RaiseEvent(new RoutedEventArgs(CurrentStateChangedEvent, stateControl));
            stateControl.OnStateChanged();
        }
        #endregion

        #region Functions
        private void OnStateChanged()
        {
            if (!IsLoaded)
            {
                return;
            }

            if (Items != null)
            {
                foreach (var item in Items)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    if (VerifyState(item.State))
                    {
                        Content = item.Content;
                        ContentTemplate = item.ContentTemplate;
                        ContentTemplateSelector = item.ContentTemplateSelector;
                        break;
                    }
                }
            }
        }

        private bool VerifyState(object rawState)
        {
            if (CurrentState == null)
            {
                return rawState == null;
            }

            if (rawState == null)
            {
                return false;
            }

            var targetType = CurrentState.GetType();
            if (targetType.IsInstanceOfType(rawState))
            {
                return rawState.Equals(CurrentState);
            }
            var fromType = rawState.GetType();
            var converter = TypeDescriptor.GetConverter(targetType);
            if(converter.CanConvertFrom(fromType))
            {
                var state = converter.ConvertFrom(rawState);
                return state.Equals(CurrentState);
            }
            return false;
        }
        #endregion
    }
}
