using FlaUI.Core.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ToolBaseUIAutomation.toolBase.enums;

namespace ToolBaseUIAutomation.toolBase.elements
{
    public class GetPropCond
    {
        public static PropertyCondition getByValue(LocatorTypes type, String value,ConditionFactory cf)
        {

            switch (type)
            {
                case LocatorTypes.ID:
                        return cf.ByAutomationId(value);

           //   case LocatorTypes.XPATH:
           //           return cf.B(value);

                case LocatorTypes.NAME:
                        return cf.ByName(value);

                case LocatorTypes.TEXT:
                        return cf.ByText(value);

                case LocatorTypes.CLASS_NAME:
                        return cf.ByClassName(value);
                    
                default:
                    throw new Exception("Unexpected locator value: " + type);
            }
        }
    }
}
