using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playtech.Main.Pages
{
    public class ItemDetailsPage(IWebDriver driver) : BasePage(driver)
    {
        string size;
        string color;
        private IWebElement SelectSizeButton
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("div[option-label='" + size + "']"));
            }
        }
        private IWebElement SelectColorButton
        {
            get
            {
                wait.Until(e => e.FindElement(By.CssSelector(".swatch-option.color")).Enabled);
                return this.driver.FindElement(By.CssSelector("div[option-label='" + color + "']"));
            }
        }
        private IWebElement SelectQuanityInput
        {
            get
            {
                return this.driver.FindElement(By.Id("qty"));
            }
        }
        private IWebElement AddToCartButton
        {
            get
            {
                return this.driver.FindElement(By.Id("product-addtocart-button"));
            }
        }
        private IWebElement CartIconButton
        {
            get
            {                
                return this.driver.FindElement(By.CssSelector("div[data-block=\"minicart\"]"));
            }
        }
        private IWebElement ProceedToCheckoutButton
        {
            get
            {
                wait.Until(e => e.FindElement(By.Id("top-cart-btn-checkout")).Displayed);
                return this.driver.FindElement(By.Id("top-cart-btn-checkout"));
            }
        }

        public void SelectSizeColorQuantity(string size, string color, int quantity)
        {
            SelectColor(color);
        }
        private void SelectColor(string color) 
        {
            this.color = color;
            SelectColorButton.Click();
        }
        private void SelectSize(string size)
        {
            this.size = size;
            SelectSizeButton.Click();
        }
        private void SelectQuantity(int quantity)
        {
            if (quantity > 1)
            {
                TypeText(SelectQuanityInput, quantity.ToString());
            }
        }
        public void CheckCartContent()
        {
            CartIconButton.Click();
        }
        public void ProceedToCheckout()
        {
            ProceedToCheckoutButton.Click();
        }
    }
}
