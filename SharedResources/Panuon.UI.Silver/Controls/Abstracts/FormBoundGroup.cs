using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace Panuon.UI.Silver
{
   public class FormBoundGroup : FormGroup
    {
        #region Fields
        #endregion

        #region Ctor
        public FormBoundGroup()
        {
        }
        #endregion

        #region Properties

        #region Binding

        public BindingBase Binding
        {
            get { return _binding; }
            set 
            {
                var oldBinding = _binding;
                _binding = value;
                OnBindingChanged(oldBinding, _binding);
            }
        }
        private BindingBase _binding;

        #endregion

        #endregion

        #region Event Handlers
        protected virtual void OnBindingChanged(BindingBase oldBinding, BindingBase newBinding)
        {

        }
        #endregion

    }
}
