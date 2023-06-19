using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBaseUIAutomation.toolBase.data
{
    public class TestData
    {
        

       public static Object[] readTestCaseDataFromJson()
        {
            
            string fullPath =  Properties.Resources.scenariosJsonPath ;
            string jsonData = File.ReadAllText(fullPath);
            JArray jsonArray = JArray.Parse(jsonData);
            Object[] testCases = new object[jsonArray.Count];

            for (int i = 0; i < jsonArray.Count; i++)
            {
                string[] testCaseItemData = new string[4];
                testCaseItemData[0] = jsonArray[i]["IndexNo"].ToString();
                testCaseItemData[1] = jsonArray[i]["TestCaseID"].ToString(); ;
                testCaseItemData[2] = jsonArray[i]["Description"].ToString(); ;
                testCaseItemData[3] = jsonArray[i]["Steps"].ToString(); ;
                testCases[i]=testCaseItemData;
            }
                       
            return testCases;
        }
    }
}
