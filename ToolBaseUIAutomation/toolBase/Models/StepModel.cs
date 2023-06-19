using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBaseUIAutomation.toolBase.Models
{
    public class StepModel
    {

        public String command;
        public String elementName;
        public String value;

        public String getErrorString()
        {
            return "The value <" + value + "> is not in the element name <" + elementName + ">";
        }

        public string stepString()
        {
            return $"{command}({elementName} ['{value}'])";
        }
        
    }

}
