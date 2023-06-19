using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToolBaseUIAutomation.toolBase.json;
using ToolBaseUIAutomation.toolBase.Models;
using System.Net.NetworkInformation;
using FlaUI.Core.Capturing;
using ToolBaseUIAutomation.toolBase.ExtentReport;

namespace ToolBaseUIAutomation.toolBase.setup
{
 
    public class Setup
    {
        public  ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
        public Window window;
        public Dictionary<String, UIElementModel> locators;
        public Application application;
        Report report;// For Report


        public  Setup()
        {
            string locatorJsonPath = Properties.Resources.locatorsJsonPath;
            locators = JsonReader.json(locatorJsonPath, cf);
            report = new Report();// For Report
        }

        [SetUp]
        public void setup()
        {
            report.StartExtentTest(TestContext.CurrentContext.Test.Name);// For Report
            application = FlaUI.Core.Application.Launch(@Properties.Resources.appPath);
            var automation = new UIA3Automation();
            window = application.GetMainWindow(automation);

           
        }
        [TearDown]
        public void endTest()
        {
             Thread.Sleep(100);// For Report

            report.LoggingTestStatusExtentReport();// For Report
            application.Close();
           
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            report.StartReport();// For Report
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            report.EndReport();// For Report

        }

        


    }
}
