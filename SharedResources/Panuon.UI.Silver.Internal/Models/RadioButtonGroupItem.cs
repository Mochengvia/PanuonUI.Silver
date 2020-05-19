using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panuon.UI.Silver.Internal.Models
{
    internal class RadioButtonGroupItem : PropertyChangedBase
    {
        public string Name { get => _name; set => SetValue(ref _name, value); }
        private string _name;

        public Enum Enum { get => _enum; set => SetValue(ref _enum, value); }
        private Enum _enum;

        public bool IsSelected { get => _isSelected; set => SetValue(ref _isSelected, value); }
        private bool _isSelected;
    }
}
