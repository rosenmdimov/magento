
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playtech.Main.Pages
{
    public class LoginPage(IWebDriver driver) : BasePage(driver)
    {
        private string url = "/customer/account/login/referer/";

        private IWebElement EmailInput
        {
            get
            {
                return this.driver.FindElement(By.Id("email"));
            }
        }
        private IWebElement PasswordInput
        {
            get
            {
                return this.driver.FindElement(By.Id("pass"));
            }
        }
        private IWebElement SignInButton
        {
            get
            {
                return this.driver.FindElement(By.Id("send2"));
            }
        }
        private IWebElement ErrorAlert
        {
            get
            {
                wait.Until(e => e.FindElement(By.CssSelector("div[data-ui-id=\"message-error\"] div")).Displayed);
                return this.driver.FindElement(By.CssSelector("div[data-ui-id=\"message-error\"] div"));
            }
        }
        private IWebElement EmailErrorMessage
        {
            get
            {
                return this.driver.FindElement(By.Id("email-error"));
            }
        }
        private IWebElement PasswordErrorMessage
        {
            get
            {
                return this.driver.FindElement(By.Id("pass-error"));
            }
        }


        public void GoTo()
        {
            base.NavigateTo(url);
        }
        public void Login(string username, string password)
        {
            TypeText(EmailInput, username);
            TypeText(PasswordInput, password);
            ClickLoginButton();
        }
        public void ClickLoginButton()
        {
            SignInButton.Click();
        }
        public void VerifyErrorAlertDisplayed(string message)
        {
            Assert.That(message.Equals(ErrorAlert.Text), "The messages are not equal");
        }

        internal void VerifyEmailErrorMessageDisplayed(string emailErrorMessage)
        {
            Assert.That(emailErrorMessage.Equals(EmailErrorMessage.Text), "The messages are not equal");
        }
        internal void VerifyPasswordErrorMessageDisplayed(string passwordErrorMessage)
        {
            Assert.That(passwordErrorMessage.Equals(PasswordErrorMessage.Text), "The messages are not equal");
        }
    }
}
