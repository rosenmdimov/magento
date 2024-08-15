using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playtech.Main.Pages
{
    public class ItemsListPage(IWebDriver driver) : BasePage(driver)
    {
        private IWebElement FirstItem
        {
            get
            {
                wait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
                return this.driver.FindElement(By.CssSelector("ol .product-item:first-of-type img"));
            }
        }

        public void OpenFirstItemDetails()
        {
            

            for (int i = 0; i < 5000; i++)
            {
                try
                {
                    FirstItem.Click();
                }
                catch (ElementClickInterceptedException ex){ }
                catch (ElementNotInteractableException ex) { }
            }
        }
    }
}
