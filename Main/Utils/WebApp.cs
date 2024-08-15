using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Internal.Logging;
using OpenQA.Selenium.Support.UI;
using Playtech.Main.Pages;
using System;
using System.IO;
using WebDriverManager.DriverConfigs.Impl;


namespace Playtech.Main.Utils
{
    public class WebApp
    {
        WebDriver driver;
        IConfigurationRoot configBuilder = new ConfigurationBuilder().
                                AddJsonFile("appsettings.json").Build();

        //Pages
        private LandingPage landingPage;
        private CreateAccountPage createAccountPage;
        private MyAccountPage myAccountPage;
        private LoginPage loginPage;
        private MenuPage menuPage;
        private ItemsListPage itemsListPage;
        private ItemDetailsPage itemDetailsPage;
        private CheckoutPage checkoutPage;
        private OrderDetailsPage orderDetailsPage;
        private SuccessPage successPage;


        public void OpenBrowser()
        {
            IConfigurationSection configSection = configBuilder.GetSection("AppSettings");
            string browserName = configSection["browserName"];
            ChromeOptions options = new ChromeOptions();

            switch (browserName)
            {
                case "chrome":
                    {
                        options.AddArguments("--remote-allow-origins=*");
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver(options);
                        break;
                    }
                case "firefox":
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver();
                        break;
                    }
                case "headless":
                    {
                        options.AddArguments("--headless=new", "--window-size=1920x1080", "--disable-extensions", "--remote-allow-origins=*");
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver(options);
                        break;
                    }
                default:
                    throw new ArgumentException(
                    string.Format("Incorrect browser name was provided: {0}", browserName));
            }
        }

        //Pages-------------------------------------------------

        public LandingPage LandingPage()
        {
            if(landingPage == null)
            {
                landingPage = new LandingPage(driver);
            }
            return landingPage;
        }
        public CreateAccountPage CreateAccountPage()
        {
            if (createAccountPage == null)
            {
                createAccountPage = new CreateAccountPage(driver);
            }
            return createAccountPage;
        }
        public MyAccountPage MyAccountPage()
        {
            if (myAccountPage == null)
            {
                myAccountPage = new MyAccountPage(driver);
            }
            return myAccountPage;
        }
        public LoginPage LoginPage()
        {
            if (loginPage == null)
            {
                loginPage = new LoginPage(driver);
            }
            return loginPage;
        }
        public MenuPage MenuPage()
        {
            if (menuPage == null)
            {
                menuPage = new MenuPage(driver);
            }
            return menuPage;
        }
        public ItemsListPage ItemsListPage()
        {
            if (itemsListPage == null)
            {
                itemsListPage = new ItemsListPage(driver);
            }
            return itemsListPage;
        }
        public ItemDetailsPage ItemDetailsPage()
        {
            if (itemDetailsPage == null)
            {
                itemDetailsPage = new ItemDetailsPage(driver);
            }
            return itemDetailsPage;
        }
        public CheckoutPage CheckoutPage()
        {
            if (checkoutPage == null)
            {
                checkoutPage = new CheckoutPage(driver);
            }
            return checkoutPage;
        }
        public OrderDetailsPage OrderDetailsPage()
        {
            if (orderDetailsPage == null)
            {
                orderDetailsPage = new OrderDetailsPage(driver);
            }
            return orderDetailsPage;
        }
        public SuccessPage SuccessPage()
        {
            if (successPage == null)
            {
                successPage = new SuccessPage(driver);
            }
            return successPage;
        }


        //Actions----------------------------------------

        public void ShutdownBrowser()
        {
            driver.Quit();
        }

        internal string ChangeEmailAndReadUsed(string email, int registerTriesCount)
        {
            string[] emailParts = email.Split("@");
            string newEmail = emailParts[0].Substring(emailParts.Length-1) + registerTriesCount + "@" + emailParts[1];

            return newEmail;
        }
        public void TakeScreenshot()
        {
            string fileName = string.Join("_", TestContext.CurrentContext.Test.Name).Replace("\"", "").Replace(",", "_");
            string path = "../../../Logs/";
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            screenshot.SaveAsFile(path + fileName + ".png");
        }
       
    }
}
