using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Tools;
using FlaUI.UIA3;
using ToolBaseUIAutomation.toolBase.actions;
using ToolBaseUIAutomation.toolBase.data;
using ToolBaseUIAutomation.toolBase.Data;
using ToolBaseUIAutomation.toolBase.elements;
using ToolBaseUIAutomation.toolBase.enums;
using ToolBaseUIAutomation.toolBase.expects;
using ToolBaseUIAutomation.toolBase.json;
using ToolBaseUIAutomation.toolBase.Models;
using ToolBaseUIAutomation.toolBase.setup;

namespace ToolBaseUIAutomation
{
    [TestFixture]
    public class Tests:Setup
    {
       

      

        [TestCaseSource(typeof(TestData), nameof(TestData.readTestCaseDataFromJson))]
        public void SampleTest(string indexNo, string testCaseID, string description, string steps)
        {
           

            List<StepModel> stepList = Data.testCaseStringParse(steps);

            foreach (var step in stepList)
            {
                UIElementModel uiElement = locators[step.elementName];
                switch (step.command)
                {
                    case "expectEqual":
                        Expect.equal(uiElement, step, window);
                        break;
                    case "expectContain":
                        Expect.contain(uiElement, step, window);
                        break;

                    default:
                        ElementAction.apply(uiElement, step, window);
                        break;
                }

            

            }


        }
    }
}