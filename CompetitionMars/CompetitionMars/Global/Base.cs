using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CompetitionMars.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static CompetitionMars.Global.GlobalDefinitions;

namespace CompetitionMars.Global
{
    public class Base
    {
        #region To access Path from resource file

        public static int Browser = 2;
        public static string IsLogin = "true";
        public static string ExcelPath = @"D:\Coding\IC\Competition Mars\Project-Mars-Competition-task\CompetitionMars\CompetitionMars\ExcelData\TestData.xlsx";
        public static string ScreenshotPath = @"D:\Coding\IC\Competition Mars\Project-Mars-Competition-task\CompetitionMars\CompetitionMars\TestReports\ScreenShots\";
        public static string reportPath = @"D:\Coding\IC\Competition Mars\Project-Mars-Competition-task\CompetitionMars\CompetitionMars\TestReports\TestReports"
            + "/Report_" + DateTime.Now.ToString("_dd-MM-yyyy_HHmm") + "/";
        #endregion

        #region reports
        public static ExtentTest test;

        public static ExtentReports extent;
        #endregion


        #region setup and tear down

        [OneTimeSetUp]
        protected void ExtentStart()
        {
            //initialize reports
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Config.DocumentTitle = "Mars-Competition Extent Report";
            htmlReporter.Config.ReportName = "Create, Edit, Delete the share skill";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("OS", "Windows 10");
            extent.AddSystemInfo("Tester Name", "Maeve");
        }

        [SetUp]
        public void Inititalize()
        {
            {

                switch (Browser)
                {

                    case 1:
                        GlobalDefinitions.driver = new FirefoxDriver();
                        break;
                    case 2:
                        GlobalDefinitions.driver = new ChromeDriver();
                        GlobalDefinitions.driver.Manage().Window.Maximize();
                        break;

                }

                GlobalDefinitions.driver.Navigate().GoToUrl("http://localhost:5000/");
                
                if (IsLogin == "true")
                {              
                    SignIn loginobj = new SignIn();
                    loginobj.LoginSteps();
                    GlobalDefinitions.wait(20);
                }
                else
                {
                    SignUp obj = new SignUp();
                    obj.register();
                    GlobalDefinitions.wait(20);
                }

                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            }
        }


        [TearDown]
        public void TearDown()
        {

            // log with info
            var TestResultStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var ErrorMessageShowed = TestContext.CurrentContext.Result.Message;
            string GetScreenShot = SaveScreenShotClass.GetScreenshot();

            Status logStatus = default;

            switch (TestResultStatus)
            {
                case TestStatus.Failed:

                    logStatus = Status.Fail;
                    test.Log(Status.Fail, TestResultStatus + ErrorMessageShowed, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenShot).Build());
                    break;

                case TestStatus.Skipped:

                    logStatus = Status.Skip;
                    test.Log(Status.Skip, ErrorMessageShowed, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenShot).Build());
                    break;

                case TestStatus.Inconclusive:

                    logStatus = Status.Warning;
                    test.Log(Status.Warning, "Test Warning");
                    break;

                case TestStatus.Passed:

                    logStatus = Status.Pass;
                    test.Log(Status.Pass, "Test Passed");
                    break;

                default:
                    break;

            }

            // Close the driver            
            driver.Close();
            driver.Quit();
        }

        [OneTimeTearDown]
        protected void ExtentClose()
        {
            // Calling Flush to writes test results into reports 
            extent.Flush();
        }

        #endregion

    }
}
