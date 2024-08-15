using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Playtech.Main.Pages
{
    public class SuccessPage(IWebDriver driver) : BasePage(driver)
    {
        private IWebElement OrderNumber
        {
            get
            {
                wait.Until(e => e.FindElement(By.CssSelector("#checkout-step-shipping_method button")).Enabled);
                return this.driver.FindElement(By.CssSelector("#checkout-step-shipping_method button"));
            }
        }
        public string GetOrderAndOpenIt()
        {
            string orderNumber = OrderNumber.Text;
            for (int i = 0; i < 5000; i++)
            {
                try
                {
                    OrderNumber.Click();
                }
                catch (ElementClickInterceptedException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ElementNotInteractableException ex) { }
            }

            return orderNumber;
        }
    }
}
