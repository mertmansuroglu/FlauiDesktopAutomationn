using FlaUI.Core.AutomationElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBaseUIAutomation.toolBase.elements;
using ToolBaseUIAutomation.toolBase.enums;
using ToolBaseUIAutomation.toolBase.Models;

namespace ToolBaseUIAutomation.toolBase.actions
{
    public class ElementAction
    {

        public static void apply(UIElementModel uiElement, StepModel step, Window window)
        {
           
            Console.WriteLine(uiElement.elementType + " " + uiElement.xpath + " " + uiElement.propCond);
            
            switch (uiElement.elementType)
            {
                case ElementType.COMBOBOX:
                    ComboBox combo = AutoElement.getAutomationElementAs<ComboBox>(uiElement, window);   
                    combo.Select(step.value).Click();
                    break;
                case ElementType.BUTTON:
                    Button buton = AutoElement.getAutomationElementAs<Button>(uiElement, window); ;
                    buton.Click();
                    break;
                case ElementType.TEXTBOX:
                    TextBox textBox = AutoElement.getAutomationElementAs<TextBox>(uiElement, window);
                    textBox.Enter(step.value);
                    break;
                case ElementType.LISTBOX:
                    ListBox listBox = AutoElement.getAutomationElementAs<ListBox>(uiElement, window);
                    listBox.Select(step.value);
                    break;
                default:
                    String errorMessage = step.stepString() + " couldn't run";
                    throw new Exception($"{uiElement.elementType} is not found int the context \n {errorMessage}");
                   
            }
        }

       

      
    }
}
