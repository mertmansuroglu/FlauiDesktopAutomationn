using FlaUI.Core.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using ToolBaseUIAutomation.toolBase.elements;
using ToolBaseUIAutomation.toolBase.enums;
using ToolBaseUIAutomation.toolBase.Models;
using ToolBaseUIAutomation.toolBase.setup;

namespace ToolBaseUIAutomation.toolBase.json
{
    public class JsonReader 
    {
   

        public static Dictionary<String, UIElementModel> json(String locatorFilePath, FlaUI.Core.Conditions.ConditionFactory cf)
    {
            string jsonData = File.ReadAllText(locatorFilePath);
            Dictionary<String, UIElementModel> locatorMap = new Dictionary<String, UIElementModel>();
            JObject json = JObject.Parse(jsonData);
            foreach (JProperty parsedProperty in json.Properties())
            {
               
                if (!parsedProperty.Name.Equals("locatorType_examples") & !parsedProperty.Name.Equals("elementType_examples"))
                {
                    String key = parsedProperty.Name.ToString();
                    //Console.WriteLine(parsedProperty.Name);
                    JObject fullElement=(JObject)((JObject)parsedProperty.Value).GetValue("Windows");
                    String locatorType = fullElement.GetValue("locatorType").ToString();
                    String locatorValue = fullElement.GetValue("locatorValue").ToString();
                    String elementType = fullElement.GetValue("elementType").ToString();
                    UIElementModel uiElementModel = new UIElementModel();

                    LocatorTypes enumLocatorTypes;
                    Enum.TryParse<LocatorTypes>(locatorType, out enumLocatorTypes);
                    

                    if (enumLocatorTypes == LocatorTypes.XPATH)
                    {
                        uiElementModel.xpath=locatorValue;
                    }
                    else
                    {
                        uiElementModel.propCond = GetPropCond.getByValue(enumLocatorTypes, locatorValue, cf);
                    }
                   
                    ElementType enumElementType;
                    Enum.TryParse<ElementType>(elementType, out enumElementType);
                    uiElementModel.elementType = enumElementType;

                    locatorMap.Add(key, uiElementModel);
                   // Console.WriteLine(locatorType+" "+ locatorValue+ " "+ elementType);
                }
            }

            
            return locatorMap;
    }
   
}

}
