using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager.DriverConfigs.Impl;

namespace Playtech.Main.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected IConfigurationRoot configBuilder = new ConfigurationBuilder().
                                        AddJsonFile("appsettings.json").Build();
        protected string url = "";

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
            driver.Manage().Window.Maximize();
        }

        public string baseUrl
        {
            get
            {
                IConfigurationSection configSection = configBuilder.GetSection("AppSettings");
                return configSection["baseUrl"];
            }
        }
        protected string GetTitle()
        {
            return driver.Title;
        }
        public virtual void NavigateTo(string url)
        {
            url = baseUrl + url;
            this.driver.Navigate().GoToUrl(url);
        }
        public void TypeText(IWebElement inputField, string text)
        {
            inputField.Clear();
            inputField.SendKeys(text);
        }
    }
}
