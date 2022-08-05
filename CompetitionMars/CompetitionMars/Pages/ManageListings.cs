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
        private IWebElement delete => driver.FindElement(By.XPath("//table[1]/tbody[1]"));
         
        //Activate or De-activate listing
        private IWebElement ActiveButton => driver.FindElement(By.XPath("//div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input"));

        //click on next page
        private IWebElement nextPageBtn => driver.FindElement(By.XPath("//div[2]/div[1]/div[2]/button[5]"));

        //click on previous page
        private IWebElement previousPageBtn => driver.FindElement(By.XPath("//div[2]/div[1]/div[2]/button[1]"));

        public void GoToManageListingsPage()
        {
            manageListingsLink.WaitForElementClickable(driver, 60);
            manageListingsLink.Click();
        }
        public void ViewListing()
        {
            view.WaitForElementClickable(driver, 60);
            view.Click();
        }

        public void EditListing()
        {
            edit.WaitForElementClickable(driver, 60);
            edit.Click();
        }
        public void DeleteListing()
        {
            delete.WaitForElementClickable(driver, 60);
            delete.Click();

            //comfirm deletion
            driver.SwitchTo().Alert().Accept();
        }

        public void ActivateOrDeactivateSkill()
        {
            ActiveButton.WaitForElementClickable(driver, 60);
            ActiveButton.Click();
        }

        public void GoToNextPage()
        {
            nextPageBtn.WaitForElementClickable(driver, 60);
            nextPageBtn.Click();
        }

        public void GoToPreviousPage()
        {
            previousPageBtn.WaitForElementClickable(driver, 60);
            previousPageBtn.Click();
        }

    }
}
