using CompetitionMars.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CompetitionMars.Global.GlobalDefinitions;
//using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace CompetitionMars.Pages
{
    internal class ShareSkill
    {
        //Click on ShareSkill Button
        private IWebElement ShareSkillButton => driver.FindElement(By.LinkText("Share Skill"));

        //Enter the Title in textbox
        private IWebElement Title => driver.FindElement(By.Name("title"));

        //Enter the Description in textbox
        private IWebElement Description => driver.FindElement(By.Name("description"));

        //Click on Category Dropdown
        private IWebElement CategoryDropDown => driver.FindElement(By.Name("categoryId"));

        //Click on SubCategory Dropdown
        private IWebElement SubCategoryDropDown => driver.FindElement(By.Name("subcategoryId"));

        //Enter Tag names in textbox
        private IWebElement Tags => driver.FindElement(By.XPath("//div[2]/div/form/div[4]/div[2]/div[1]/div/div/div/input"));

        //Click on Tag remove button
        private IWebElement RemoveTagButton => driver.FindElement(By.XPath("//div[2]/div/form/div[4]/div[2]/div/div/div/span/a"));

        //Select the Service type
        private IWebElement HourlyBasisBervice => driver.FindElement(By.XPath("//div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));
        private IWebElement OneOffService => driver.FindElement(By.XPath("//div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));

        //Select the Location Type
        private IWebElement OnSite => driver.FindElement(By.XPath("//div[2]/div/form/div[6]/div[2]/div/div[1]/div/input"));
        private IWebElement Online => driver.FindElement(By.XPath("//div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));

        //Click on Start Date dropdown
        private IWebElement StartDateDropDown => driver.FindElement(By.Name("startDate"));

        //Click on End Date dropdown
        private IWebElement EndDateDropDown => driver.FindElement(By.Name("endDate"));

        //Storing the table of available days
        private IWebElement Days => driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]"));

        //Storing the starttime
        private IWebElement StartTime => driver.FindElement(By.XPath("//div[3]/div[2]/input[1]"));

        //Click on StartTime dropdown
        private IWebElement StartTimeDropDown => driver.FindElement(By.XPath("//div[3]/div[2]/input[1]"));

        //Click on EndTime dropdown
        private IWebElement EndTimeDropDown => driver.FindElement(By.XPath("//div[3]/div[3]/input[1]"));

        //Click on Skill Trade option
        private IWebElement SkillExchangeOption => driver.FindElement(By.XPath("//div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));
        private IWebElement CreditOption => driver.FindElement(By.XPath("//div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));

        //Enter Skill Exchange
        private IWebElement SkillExchange => driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@type='text']"));

        //Click on remove skill exchange tag button
        private IWebElement RemoveSkillExchangeButton => driver.FindElement(By.XPath("//div[2]/div/form/div[8]/div[4]/div/div/div/div/span/a"));

        //Enter the amount for Credit
        private IWebElement CreditAmount => driver.FindElement(By.XPath("//input[@placeholder='Amount']"));

        //Click on Active/Hidden option
        private IWebElement ActiveOption => driver.FindElement(By.XPath("//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']"));
        private IWebElement HiddenOption => driver.FindElement(By.XPath("//div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));

        //Click on Upload Work Sample button
        private IWebElement UploadWorkSamplebutton => driver.FindElement(By.XPath("//div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));

        //Click on delete Work Sample button
        private IWebElement DeleteWorkSamplebutton => driver.FindElement(By.XPath("//div[2]/div/form/div[9]/div/div[2]/section/div/label/div/div/i[1]"));

        //Click on Save button
        private IWebElement Save => driver.FindElement(By.XPath("//input[@value='Save']"));



        //XPath for Assert
        //Category of the latest listing
        private IWebElement LatestCategory => driver.FindElement(By.XPath("//div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]"));

        //Title of the latest listing
        private IWebElement LatestTitle => driver.FindElement(By.XPath("//div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));

        //Description of the latest listing
        private IWebElement LatestDescription => driver.FindElement(By.XPath("//div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]"));


        

        public string GetNewCategory()
        {
            return LatestCategory.Text;
        }

        public string GetNewTitle()
        {
            return LatestTitle.Text;
        }

        public string GetNewDescription()
        {
            return LatestDescription.Text;
        }


        public void CreateShareSkill()
        {
            //read the excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "CreateShareSkill");

            //go to share skill page
            ShareSkillButton.WaitForElementClickable(driver, 60);
            ShareSkillButton.Click();

            //input title from excel file
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Title"));

            //input descripton from excel file
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Description"));

            //click category dropdown box
            CategoryDropDown.WaitForElementClickable(driver, 60);
            CategoryDropDown.Click();

            //choose category
            var CategoryOption = new SelectElement(CategoryDropDown);
            CategoryOption.SelectByText(GlobalDefinitions.ExcelLib.ReadData(3, "Category"));

            //click SubCategory dropdown box
            SubCategoryDropDown.WaitForElementClickable(driver, 60);
            SubCategoryDropDown.Click();

            //choose SubCategory 
            var SubCategoryOption = new SelectElement(SubCategoryDropDown);
            SubCategoryOption.SelectByText(GlobalDefinitions.ExcelLib.ReadData(3, "SubCategory"));

            //input tags
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //choose service type
            if (GlobalDefinitions.ExcelLib.ReadData(3, "Service Type") == "Hourly basis service")
            {
                HourlyBasisBervice.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(3, "Service Type") == "One-off service")
            {
                OneOffService.Click();
            }

            //choose location type
            if (GlobalDefinitions.ExcelLib.ReadData(3, "Location Type") == "Online")
            {
                Online.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(3, "Location Type") == "On-site")
            {
                OnSite.Click();
            }

            //input start date
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "StartDays"));

            //input end date
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "EndDays"));

            //choose available day, start time, and end time
            //Create a string list of week days which equal to the string showed on check box
            List<string> listOfWeekDays = new List<string> { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            //Create a list of available days check box
            IList<IWebElement> listOfAvailableDaysCheckBox = Days.FindElements(By.Name("Available"));

            //Create a list of start time input box
            IList<IWebElement> listOfStartTimeInputBox = Days.FindElements(By.Name("StartTime"));

            //create a list of end time input box
            IList<IWebElement> listOfEndTimeInputBox = Days.FindElements(By.Name("EndTime"));

            //identify the available day from excel file
            string AvailableDaysValue = GlobalDefinitions.ExcelLib.ReadData(3, "Available Day");

            //identify the start time from excel file
            string StartTimeValue = GlobalDefinitions.ExcelLib.ReadData(3, "Start Times");

            //identify the end time from excel file
            string EndTimeVlue = GlobalDefinitions.ExcelLib.ReadData(3, "End Times");


            //click on available day and time
            for (int i = 0; i < listOfAvailableDaysCheckBox.Count; i++)
            {
                if (AvailableDaysValue.Contains(listOfWeekDays[i]))
                {
                    listOfAvailableDaysCheckBox[i].Click();

                    listOfStartTimeInputBox[i].SendKeys(Keys.ArrowRight);

                    listOfStartTimeInputBox[i].SendKeys(StartTimeValue);

                    listOfEndTimeInputBox[i].SendKeys(Keys.ArrowRight);

                    listOfEndTimeInputBox[i].SendKeys(EndTimeVlue);

                }
            }


            //choose skill trade type and input data
            if (GlobalDefinitions.ExcelLib.ReadData(3, "Skill Trade") == "Credit")
            {
                //choose credit option
                CreditOption.Click();

                //input credit amount
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "CreditAmount"));
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(3, "Skill Trade") == "Skill-exchange")
            {
                //choose skill exchange option
                SkillExchangeOption.Click();

                //input skill exchange tag
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Enter);

            }

            //upload Work Samples
            UploadWorkSamplebutton.Click();

            Thread.Sleep(2000);

            using (Process exeProcess = Process.Start(@"D:\Coding\IC\Competition Mars\Project-Mars-Competition-task\CompetitionMars\CompetitionMars\UploadWorkSample\FileUploadScript.exe"))
            {
                exeProcess.WaitForExit();
            }

            Thread.Sleep(1000);

            //choose active
            if (GlobalDefinitions.ExcelLib.ReadData(3, "Active Status") == "Active")
            {
                ActiveOption.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(3, "Active Status") == "Hidden")
            {
                HiddenOption.Click();
            }

            //click on save button
            Save.WaitForElementClickable(driver, 60);
            Save.Click();

            wait(5);
        }


        public void EditShareSkill()
        {
            //read the excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "EditListing");

            //clear and input new title
            Title.Clear();
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //clear and input new description
            Description.Clear();
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //change category
            CategoryDropDown.WaitForElementClickable(driver, 60);
            CategoryDropDown.Click();

            //choose category
            var CategoryOption = new SelectElement(CategoryDropDown);
            CategoryOption.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));


            //change SubCategory
            SubCategoryDropDown.WaitForElementClickable(driver, 60);
            SubCategoryDropDown.Click();

            //choose SubCategory
            var SubCategoryOption = new SelectElement(SubCategoryDropDown);
            SubCategoryOption.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            //clear and input new tag
            RemoveTagButton.Click();
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //change service type
            if (GlobalDefinitions.ExcelLib.ReadData(2, "Service Type") == "Hourly basis service")
            {
                HourlyBasisBervice.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "Service Type") == "One-off service")
            {
                OneOffService.Click();
            }

            //change location type
            if (GlobalDefinitions.ExcelLib.ReadData(2, "Location Type") == "Online")
            {
                Online.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "Location Type") == "On-site")
            {
                OnSite.Click();
            }

            //change start date
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartDays"));

            //change end date
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndDays"));

            //choose available day, start time, and end time
            //Create a string list of week days which equal to the string showed on check box
            List<string> listOfWeekDays = new List<string> { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            //Create a list of available days check box
            IList<IWebElement> listOfAvailableDaysCheckBox = Days.FindElements(By.Name("Available"));

            //Create a list of start time input box
            IList<IWebElement> listOfStartTimeInputBox = Days.FindElements(By.Name("StartTime"));

            //create a list of end time input box
            IList<IWebElement> listOfEndTimeInputBox = Days.FindElements(By.Name("EndTime"));

            //identify the available day from excel file
            string AvailableDaysValue = GlobalDefinitions.ExcelLib.ReadData(2, "Available Day");

            //identify the start time from excel file
            string StartTimeValue = GlobalDefinitions.ExcelLib.ReadData(2, "Start Times");

            //identify the end time from excel file
            string EndTimeVlue = GlobalDefinitions.ExcelLib.ReadData(2, "End Times");

            //Clear checkbox data and startime and end time
            for (int i = 0; i < listOfAvailableDaysCheckBox.Count; i++)
            {

                if (listOfAvailableDaysCheckBox[i].Selected is true)
                {
                    listOfAvailableDaysCheckBox[i].Click();

                    listOfStartTimeInputBox[i].SendKeys(Keys.ArrowRight);

                    listOfStartTimeInputBox[i].Clear();

                    listOfEndTimeInputBox[i].SendKeys(Keys.ArrowRight);

                    listOfEndTimeInputBox[i].Clear();
                }
            }

            //click on available day and input new start time and end time
            for (int i = 0; i < listOfAvailableDaysCheckBox.Count; i++)
            {
                if (AvailableDaysValue.Contains(listOfWeekDays[i]))
                {
                    listOfAvailableDaysCheckBox[i].Click();

                    listOfStartTimeInputBox[i].SendKeys(Keys.ArrowRight);

                    listOfStartTimeInputBox[i].SendKeys(StartTimeValue);

                    listOfEndTimeInputBox[i].SendKeys(Keys.ArrowRight);

                    listOfEndTimeInputBox[i].SendKeys(EndTimeVlue);

                }
            }

            //change skill trade type
            if (GlobalDefinitions.ExcelLib.ReadData(2, "Skill Trade") == "Credit")
            {
                //choose Credit Option
                CreditOption.Click();

                //input new credit amount
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CreditAmount"));
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "Skill Trade") == "Skill-exchange")
            {
                //choose skill exchange option
                SkillExchangeOption.Click();

                //clear and input new skill exchange tag
                RemoveSkillExchangeButton.Click();
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Enter);
            }

            //upload new work sample
            DeleteWorkSamplebutton.Click();
            UploadWorkSamplebutton.Click();

            Thread.Sleep(2500);
            

            using (Process exeProcess = Process.Start(@"D:\Coding\IC\Competition Mars\Project-Mars-Competition-task\CompetitionMars\CompetitionMars\UploadWorkSample\FileUploadScript.exe"))
            {
                exeProcess.WaitForExit();
            }

            Thread.Sleep(2500);
            

            //choose active type
            if (GlobalDefinitions.ExcelLib.ReadData(2, "Active Status") == "Active")
            {
                ActiveOption.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "Active Status") == "Hidden")
            {
                HiddenOption.Click();
            }

            //click on save button
            Save.WaitForElementClickable(driver, 60);
            Save.Click();

            wait(5);
            
        }


    }
}
