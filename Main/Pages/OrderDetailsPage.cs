using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playtech.Main.Pages
{
    public class OrderDetailsPage(IWebDriver driver):BasePage(driver)
    {

        private IWebElement OrderNumber
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("data-ui-id"));
            }
        }
        public void VerifyOrderExists(string orderId)
        {
            Assert.That(OrderNumber.Equals(orderId));
        }
    }
}
