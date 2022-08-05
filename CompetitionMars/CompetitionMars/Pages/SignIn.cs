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
    public class SignIn
    {
        #region 
        //Initialize Web Elements 
        //Finding the Sign Link
        private IWebElement SignIntab => driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a"));

        // Finding the Email Field
        private IWebElement Email => driver.FindElement(By.Name("email"));

        //Finding the Password Field
        private IWebElement Password => driver.FindElement(By.Name("password"));

        //Finding the Login Button
        private IWebElement LoginBtn => driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));
        #endregion

        public void LoginSteps()
        {
            // Read the excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            //click on sign in button
            SignIntab.WaitForElementClickable(driver, 60);
            SignIntab.Click();

            //get email address from excel file and input data
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));

            //get password from excel file and input data
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //click on sign in button
            LoginBtn.Click();


        }

    }
}
