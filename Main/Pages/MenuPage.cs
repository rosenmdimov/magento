using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playtech.Main.Pages
{
    public class MenuPage(IWebDriver driver) : BasePage(driver)
    {
        private IWebElement WomenSection
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("li.level0:nth-of-type(2)"));
            }
        }
        private IWebElement SubMenuTops
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("li.level1.nav-2-1"));
            }
        }
        private IWebElement CategoryJacets
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("li.level2.nav-2-1-1"));
            }
        }

        public void GoToWomenJacetsList()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(WomenSection)
                .MoveToElement(SubMenuTops)
                .MoveToElement(CategoryJacets)
                .Click()
                .Perform();
        }
    }
}
