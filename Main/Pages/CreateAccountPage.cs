using NUnit.Framework;
using OpenQA.Selenium;
using Playtech.Main.Utils;
using System;
using System.Collections.Generic;

namespace Playtech.Main.Pages
{
    public class CreateAccountPage(IWebDriver driver) : BasePage(driver)
    {
        private string url =  "/customer/account/create/";

        private IWebElement FirstNameInput
        {
            get
            {
                return this.driver.FindElement(By.Id("firstname"));
            }
        }

        private IWebElement LastNameInput
        {
            get
            {
                return this.driver.FindElement(By.Id("lastname"));
            }
        }

        private IWebElement EmailInput
        {
            get
            {
                return this.driver.FindElement(By.Id("email_address"));
            }
        }

        private IWebElement PasswordInput
        {
            get
            {
                return this.driver.FindElement(By.Id("password"));
            }
        }
        private IWebElement SubmitButton
        {
            get
            {
                return this.driver.FindElement(By.CssSelector(".submit"));
            }
        }

        private IWebElement PasswordConfirmInput
        {
            get
            {
                return this.driver.FindElement(By.Id("password-confirmation"));
            }
        }
        private IList<IWebElement> UsedEmailAlert
        {
            get
            {
                return this.driver.FindElements(By.Id("password-confirmation"));
            }
        }


        public  void GoTo()
        {
            base.NavigateTo(url);
        }

        internal void FillInDetails(User user)
        {
            //driver.Navigate().Refresh();
            TypeText(FirstNameInput, user.FirstName);
            TypeText(LastNameInput, user.LastName);
            TypeText(EmailInput, user.Email);
            TypeText(PasswordInput, user.Password);
            TypeText(PasswordConfirmInput, user.Password);

            
        }

        internal bool RegisterUser()
        {

            SubmitButton.Click();
            //wait.Until(e => e.Url.Equals("https://magento.softwaretestingboard.com/customer/account/"));
            if (UsedEmailAlert.Count > 0)
            {
                return false;
            }
            return true;
        }

    }
}
