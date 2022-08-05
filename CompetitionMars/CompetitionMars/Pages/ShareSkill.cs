using CompetitionMars.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CompetitionMars.Global.GlobalDefinitions;


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
        private IWebElement Tags => driver.FindElement(By.XPath("//div[@class='form-wrapper field  ']//input"));

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

        //Enter the amount for Credit
        private IWebElement CreditAmount => driver.FindElement(By.XPath("//input[@placeholder='Amount']"));

        //Click on Active/Hidden option
        private IWebElement ActiveOption => driver.FindElement(By.XPath("//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']"));
        private IWebElement HiddenOption => driver.FindElement(By.XPath("//div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));

        //Click on Save button
        private IWebElement Save => driver.FindElement(By.XPath("//input[@value='Save']"));

        public void GoToShareSkillPage()
        {
            ShareSkillButton.WaitForElementClickable(driver, 60);
            ShareSkillButton.Click();
        }

        public void CreateShareSkill()
        {
            //read the excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "CreateShareSkill");

            //input title from excel file
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //input descripton from excel file
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //click category dropdown box
            CategoryDropDown.WaitForElementClickable(driver, 60);
            CategoryDropDown.Click();

            //choose category
            SelectElement CategoryOption = new SelectElement(CategoryDropDown);
            CategoryOption.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            //click SubCategory dropdown box
            SubCategoryDropDown.WaitForElementClickable(driver, 60);
            SubCategoryDropDown.Click();

            //choose SubCategory 
            SelectElement SubCategoryOption = new SelectElement(SubCategoryDropDown);
            SubCategoryOption.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            //input tags
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //choose service type
            if (GlobalDefinitions.ExcelLib.ReadData(2, "Service Type") == "Hourly basis service")
            {
                HourlyBasisBervice.Click();
            }
            else
            {
                OneOffService.Click();
            }

            //choose location type
            if(GlobalDefinitions.ExcelLib.ReadData(2, "Location Type") == "Online")
            {
                Online.Click();
            }
            else
            {
                OnSite.Click();
            }

            //input start date
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartDays"));

            //input end date
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndDays"));

            //input start time
            StartTimeDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Start Times"));

            //input end times
            EndTimeDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "End Times"));

            //choose skill trade type
            if (GlobalDefinitions.ExcelLib.ReadData(2, "Skill Trade") == "Credit")
            {
                CreditOption.Click();
                
            }
            else
            {
                SkillExchangeOption.Click();
            }

            //input Credit Amount
            CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CreditAmount"));

            //upload Work Samples

            //choose active
            if (GlobalDefinitions.ExcelLib.ReadData(2, "Active Status") == "Active")
            {
                ActiveOption.Click();
            }
            else
            {
                HiddenOption.Click();
            }

            //click on save button
            Save.WaitForElementClickable(driver, 60);
            Save.Click();
        }


        public void EditShareSkill()
        {

        }

    }
}
