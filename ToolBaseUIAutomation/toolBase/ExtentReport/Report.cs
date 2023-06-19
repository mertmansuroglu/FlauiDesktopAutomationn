using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FlaUI.Core.Capturing;

namespace ToolBaseUIAutomation.toolBase.ExtentReport
{
    public class Report
    {
        public static string screenShotImagesPath = "";
        public static ExtentReports extent;
        public static ExtentTest testlog;
        
        public void StartReport()
        {
           
            string path = Assembly.GetCallingAssembly().Location;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

            string reportPath = projectPath + "Reports\\";
            screenShotImagesPath = reportPath + "ScreenShots\\";

            System.IO.Directory.CreateDirectory(reportPath);
            System.IO.Directory.CreateDirectory(screenShotImagesPath);
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Tester", Environment.UserName);
            extent.AddSystemInfo("MachineName", Environment.MachineName);



        }

        public void EndReport()
        {

            extent.Flush();
        }

        public  void StartExtentTest(string testsToStart)
        {
            testlog = extent.CreateTest(testsToStart);
        }

        public  void LoggingTestStatusExtentReport()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = string.Empty + TestContext.CurrentContext.Result.StackTrace + string.Empty;
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        testlog.Log(Status.Fail, "Test steps NOT Completed for Test case " + TestContext.CurrentContext.Test.Name + " ");
                        testlog.Log(Status.Fail, "Test ended with " + Status.Fail + " – " + errorMessage);
                        var fullscreenImg = Capture.MainScreen();
                        string imageFile = screenShotImagesPath + "screenShot_" + DateTime.Now.Ticks.ToString() + ".png";
                        fullscreenImg.ToFile(@imageFile);
                        testlog.Fail("Test information").AddScreenCaptureFromPath(@imageFile);
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        testlog.Log(Status.Skip, "Test ended with " + Status.Skip);
                        break;
                    default:
                        logstatus = Status.Pass;
                        testlog.Log(Status.Pass, "Test steps finished for test case " + TestContext.CurrentContext.Test.Name);
                        testlog.Log(Status.Pass, "Test ended with " + Status.Pass);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
