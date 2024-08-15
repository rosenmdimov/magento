using NUnit.Framework;
using OpenQA.Selenium;

namespace Playtech.Main.Pages
{
    public class MyAccountPage(IWebDriver driver) : BasePage(driver)
    {
        private IWebElement WelcomeMessage
        {
            get
            {
                wait.Until(e => e.FindElement(By.CssSelector(".panel.header .logged-in")).Displayed);
                return this.driver.FindElement(By.CssSelector(".panel.header .logged-in"));
            }
        }
        internal void VerifyTitle(string title)
        {
            Assert.That(title.Equals(GetTitle()), "Actual title is: " + GetTitle());
        }

        internal void VerifyWellcomeMessageContains(string firstName)
        {
            Assert.That(WelcomeMessage.Text.Contains(firstName));
        }
    }
}
