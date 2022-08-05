using AventStack.ExtentReports;
using CompetitionMars.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CompetitionMars.Global.GlobalDefinitions;

namespace CompetitionMars.Global
{
    public class Base
    {
        #region To access Path from resource file

        public static int Browser = 2;
        public static String ExcelPath = @"D:\Coding\IC\Competition Mars\Project-Mars-Competition-task\CompetitionMars\CompetitionMars\ExcelData\TestData.xlsx";
        public static string ScreenshotPath = "";
        public static string ReportPath = "";
        public static string IsLogin = "true";
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion


        #region setup and tear down
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



                #region Initialise Reports

                //extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
                //extent.LoadConfig(MarsResource.ReportXMLPath);

                #endregion

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

            }
        }


        [TearDown]
        public void TearDown()
        {
            // Screenshot
            //String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
            //test.Log(LogStatus.Info, "Image example: " + img);
            // end test. (Reports)
            //extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            //extent.Flush();
            // Close the driver :)            
            //GlobalDefinitions.driver.Close();
            //GlobalDefinitions.driver.Quit();
        }
        #endregion

    }
}
