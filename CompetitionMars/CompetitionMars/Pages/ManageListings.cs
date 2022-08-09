using CompetitionMars.Global;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CompetitionMars.Global.GlobalDefinitions;

namespace CompetitionMars.Pages
{
    public class ManageListings
    {
        //Click on Manage Listings Link
        private IWebElement manageListingsLink => driver.FindElement(By.LinkText("Manage Listings"));
        
        //View the listing     
        private IWebElement view => driver.FindElement(By.XPath("(//i[@class='eye icon'])[1]"));

        //Edit the listing
        private IWebElement edit => driver.FindElement(By.XPath("(//i[@class='outline write icon'])[1]"));

        //Delete the listing
        private IWebElement delete => driver.FindElement(By.XPath("//div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));

        //Click on Yes Button
        private IWebElement ComfirmDeletionButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));

        public void ViewListing()
        {
            //read excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "CreateShareSkill");

            //go to manage listing page
            manageListingsLink.WaitForElementClickable(driver, 60);
            manageListingsLink.Click();

            //click on view button
            view.WaitForElementClickable(driver, 60);
            view.Click();
        }

        public void EditListing()
        {
            //go to manage listing page
            manageListingsLink.WaitForElementClickable(driver, 60);
            manageListingsLink.Click();

            //click on edit button
            edit.WaitForElementClickable(driver, 60);
            edit.Click();

            //edit the listing
            ShareSkill shareSkillObj = new ShareSkill();
            shareSkillObj.EditShareSkill();
        }
        public void DeleteListing()
        {
            //read excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "EditListing");

            //go to manage listing page
            manageListingsLink.WaitForElementClickable(driver, 60);
            manageListingsLink.Click();

            //click on delete button
            delete.WaitForElementClickable(driver, 60);
            delete.Click();

            //comfirm deletion
            GlobalDefinitions.wait(10);
            ComfirmDeletionButton.Click();

            //refresh the page
            driver.Navigate().Refresh();
        }

    }
}
