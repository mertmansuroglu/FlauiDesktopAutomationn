using FlaUI.Core.AutomationElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBaseUIAutomation.toolBase.elements;
using ToolBaseUIAutomation.toolBase.enums;
using ToolBaseUIAutomation.toolBase.Models;

namespace ToolBaseUIAutomation.toolBase.expects
{
    
    public class Expect
    {
         public enum Option
        {
            Equal,
            Contain
        }
        public static void equal(UIElementModel uiElement, StepModel step, Window window)
        {
            expect(uiElement,step,window,Option.Equal);

        }
        public static void contain(UIElementModel uiElement, StepModel step, Window window)
        {
           expect(uiElement, step, window, Option.Contain);
        }

        public static void expect(UIElementModel uiElement, StepModel step, Window window, Option option)
        {
            switch (uiElement.elementType)
            {
                case ElementType.COMBOBOX:
                    ComboBox combo = AutoElement.getAutomationElementAs<ComboBox>(uiElement, window);
                    Assert.IsNotNull( combo.Items.FirstOrDefault(x=> equalOrContain(x.AsListBoxItem().Text, step.value,option)),$"Expectetion was not realize in {step.stepString()}");
                    break;
                case ElementType.BUTTON:
                    Button buton = AutoElement.getAutomationElementAs<Button>(uiElement, window); ;
                    Assert.IsTrue(equalOrContain(buton.Name, step.value,option),$"Expectetion was not realize in {step.stepString()}");
                    break;
                case ElementType.TEXTBOX:
                    TextBox textBox = AutoElement.getAutomationElementAs<TextBox>(uiElement, window);
                    Assert.IsTrue(equalOrContain(textBox.Text, step.value, option), $"Expectetion was not realize in {step.stepString()}");
                    break;
                case ElementType.LISTBOX:
                    ListBox listBox = AutoElement.getAutomationElementAs<ListBox>(uiElement, window);
                    Assert.IsNotNull(listBox.Items.FirstOrDefault(x => equalOrContain(x.AsListBoxItem().Text, step.value, option)), $"Expectetion was not realize in {step.stepString()}");
                    break ;
                case ElementType.LABEL:
                    Label label = AutoElement.getAutomationElementAs<Label>(uiElement, window); ;
                    Assert.IsTrue(equalOrContain(label.Text, step.value, option), $"Expectetion was not realize in {step.stepString()}");
                    break;
                
                default:
                    String errorMessage = step.stepString() + " couldn't run";
                    throw new Exception($"{uiElement.elementType} is not found int the context  {errorMessage}");
                    
            }

        }

        public static bool equalOrContain(String string1, String string2, Option option)
        {
            if (option == Option.Equal)
            {
                return string1.Equals(string2);
            }
            else
            {
                return string1.Contains(string2);
            }
        }
    }
}
