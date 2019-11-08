using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIBrowser.Models
{
    public class AttachedPropertyItem : DependencyPropertyItem
    {
        #region Ctor
        public AttachedPropertyItem(Type attachedPropertyClassType, string propertyName, object propertyValue) : base(propertyName, propertyValue)
        {
            AttachedPropertyClassType = attachedPropertyClassType;
        }
        #endregion

        #region Property
        public Type AttachedPropertyClassType { get; set; }
        #endregion

        #region Methods
        public new string ToSourceCode()
        {
            return $"pu:{AttachedPropertyClassType.Name}.{PropertyName}=\"{PropertyValue}\"";
        }

        public new string ToStyleCode()
        {
            return $"<Setter Property=\"pu:{AttachedPropertyClassType.Name}.{PropertyName}\"\nValue=\"{PropertyValue}\" />";
        }
        #endregion
    }
}
