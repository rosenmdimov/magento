using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Playtech.Main.Utils;
using System;
using System.Collections.Generic;

namespace Playtech.Main.Pages
{
    public class CheckoutPage(IWebDriver driver) : BasePage(driver)
    {
        string inputKeyword;
        private IWebElement ShippingInputField
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("input[name=\"" + inputKeyword + "\"]"));
            }
        }
        private IWebElement StateDropdown
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("select[name=\"region_id\"]"));
            }
        }
        private IWebElement CountryDropdown
        {
            get
            {
                wait.Until(e => e.FindElement(By.CssSelector("select[name=\"country_id\"]")).Displayed);
                return this.driver.FindElement(By.CssSelector("select[name=\"country_id\"]"));
            }
        }
        private IWebElement NextButton
        {
            get
            {
                wait.Until(e => e.FindElement(By.CssSelector("button.button.action.continue.primary")).Enabled);
                //wait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
                return this.driver.FindElement(By.CssSelector("button.button.action.continue.primary"));
            }
        }
        private IWebElement PlaceOrderButton
        {
            get
            {
                return this.driver.FindElement(By.CssSelector("button[title=\"Place Order\"]"));
            }
        }
        private IWebElement NewAddressButton
        {
            get
            {
                wait.Until(e => e.FindElement(By.CssSelector(".new-address-popup button")).Displayed);
                return this.driver.FindElement(By.CssSelector(".new-address-popup button"));
            }
        }
        private IWebElement ShipHereButton
        {
            get
            {
                return this.driver.FindElement(By.CssSelector(".modal-footer button.primary"));
            }
        }
        private IList<IWebElement> ShippingAddressItem
        {
            get
            {
                wait.Until(e => e.FindElement(By.Id("co-shipping-method-form")).Displayed);
                return this.driver.FindElements(By.CssSelector(".shipping-address-item"));
            }
        }



        internal void FillShippingAddress(User user)
        {

            bool isShippingAddressAvailable = ShippingAddressItem.Count > 0;

            if (isShippingAddressAvailable)
            {
                NewAddressButton.Click();
            }

            SelectElement countryOptions = new SelectElement(CountryDropdown);
            SelectElement stateOptions = new SelectElement(StateDropdown);

            this.inputKeyword = "street[0]";
            TypeText(ShippingInputField, user.StreetAddress);
            this.inputKeyword = "city";
            TypeText(ShippingInputField, user.City);
            this.inputKeyword = "postcode";
            TypeText(ShippingInputField, user.Zip);
            this.inputKeyword = "telephone";
            TypeText(ShippingInputField, user.PhoneNumber);

            countryOptions.SelectByText(user.Country);
            stateOptions.SelectByText(user.State);
            if (isShippingAddressAvailable)
            {
                ShipHereButton.Click();
            }
        }
        public void GoToPaymentMethod()
        {
            //Thread.Sleep(3000);


            for (int i = 0; i < 5000; i++) 
            {
                try
                {
                    NextButton.Click();
                }
                catch (ElementClickInterceptedException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ElementNotInteractableException ex) { }
            }
        }
        public void PlaceOrder()
        {
            PlaceOrderButton.Click();
        }
    }
}
