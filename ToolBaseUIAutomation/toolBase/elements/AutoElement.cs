using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBaseUIAutomation.toolBase.Models;

namespace ToolBaseUIAutomation.toolBase.elements
{
    public class AutoElement
    {
        public static AutomationElement getAutomationElementWithRetry(UIElementModel uiElement, int timeOutSec, int intervalMiliSec, Window window)
        {
            RetrySettings retrySettings = new RetrySettings
            {
                Timeout = TimeSpan.FromSeconds(timeOutSec),
                Interval = TimeSpan.FromMilliseconds(intervalMiliSec)
            };
            if (uiElement.xpath != null)
            {
                return Retry.Find(() => window.FindFirstByXPath(uiElement.xpath), retrySettings);
                
            }
            else if (uiElement.propCond != null)
            {
                return Retry.Find(() => window.FindFirstDescendant(uiElement.propCond), retrySettings);
            }
            else
            {
                throw new Exception($"Xpath and Prop Cond Null!!");
            }
         
        }
        public static AutomationElement getAutomationElementWithRetry(UIElementModel uiElement,  Window window)
        {
            RetrySettings retrySettings = new RetrySettings
            {
                Timeout = TimeSpan.FromSeconds(Int32.Parse( Properties.Resources.timeout)),
                Interval = TimeSpan.FromMilliseconds(Int32.Parse(Properties.Resources.interval))
            };
            if (uiElement.xpath != null)
            {
                return Retry.Find(() => window.FindFirstByXPath(uiElement.xpath), retrySettings);
            }
            else if (uiElement.propCond != null)
            {
                return Retry.Find(() => window.FindFirstDescendant(uiElement.propCond), retrySettings);
            }
            else
            {
                throw new Exception($"Xpath and Prop Cond Null!!");
            }
        }
        public static AutomationElement getAutomationElement(UIElementModel uiElement, Window window)
        {
            if (uiElement.xpath != null)
            {
                return window.FindFirstByXPath(uiElement.xpath);
            }
            else if (uiElement.propCond != null)
            {
                return window.FindFirstDescendant(uiElement.propCond);
            }
            else
            {
                throw new Exception($"Xpath and Prop Cond Null!!");
            }
        }

        public static T getAutomationElementAs<T>(UIElementModel uiElement, Window window)  where T : AutomationElement
        {
            AutomationElement automationElement = AutoElement.getAutomationElementWithRetry(uiElement, window);
            Assert.IsNotNull(automationElement, $"{uiElement.getElementName()} was not found in windows");

            T  guiElement= automationElement.As<T>();

            Assert.IsNotNull(guiElement, $"{uiElement.getElementName()} is not {typeof(T)}");
         //   guiElement.DrawHighlight();
         
            return guiElement;
        }
    }
}
