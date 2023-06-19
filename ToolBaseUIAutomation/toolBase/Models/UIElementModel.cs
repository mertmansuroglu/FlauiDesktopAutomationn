using FlaUI.Core.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBaseUIAutomation.toolBase.enums;

namespace ToolBaseUIAutomation.toolBase.Models
{
    public class UIElementModel
    {
        public PropertyCondition?  propCond;
        public ElementType? elementType = null;
        public string? xpath = null;

        public UIElementModel(PropertyCondition propCond, ElementType elementType)
        {
            this.elementType = elementType;
            this.propCond = propCond;
        }
        public UIElementModel()
        {

        } 

        public Object? getElementName()
        {
            if (xpath!=null)
            {
                return xpath;
            }
            else
            {
                return propCond;
            }
        }


     
    }
}
