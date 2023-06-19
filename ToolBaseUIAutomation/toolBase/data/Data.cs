using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBaseUIAutomation.toolBase.Models;

namespace ToolBaseUIAutomation.toolBase.Data
{
    public class Data {

        public static String? getStringBtwnTwoChars(String value, char firstChar, char secondChar)
        {
            int firstCharIndex = value.IndexOf(firstChar);
            int secondCharIndex = value.IndexOf(secondChar);
            if (firstCharIndex != -1 & secondCharIndex != -1)
            {
                return value.Substring(firstCharIndex + 1, secondCharIndex - firstCharIndex - 1);
            }
            else
            {
                return null;
            }
        }

        public static List<StepModel> testCaseStringParse(String testCaseString)
        {
            List<StepModel> caseItemModelList = new List<StepModel>();
            String[] array = testCaseString.Split("::");

            foreach (String item in array)
            {

                StepModel caseItemModel = new StepModel();
                caseItemModel.command = item.Substring(0, item.IndexOf('(')).Trim();
                String elementAndValue = getStringBtwnTwoChars(item, '(', ')');
                caseItemModel.value = getStringBtwnTwoChars(elementAndValue, '[', ']');
                if (caseItemModel.value == null)
                {
                    caseItemModel.elementName = elementAndValue;
                }
                else
                {
                    caseItemModel.elementName = elementAndValue.Substring(0, elementAndValue.IndexOf('[')).Trim();
                    caseItemModel.value = caseItemModel.value.Trim().Replace("'", "");
                }
                //Console.WriteLine(caseItemModel.command + " " + caseItemModel.elementName + " " + caseItemModel.value);
                caseItemModelList.Add(caseItemModel);

            }

            return caseItemModelList;
        }
    }
}