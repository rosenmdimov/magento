using NUnit.Framework;
using OpenQA.Selenium;
using Playtech.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Internal.Logging;
using System.IO;
using OpenQA.Selenium.Remote;
using log4net.Repository.Hierarchy;
using NUnit.Framework.Interfaces;

namespace Playtech.Main.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected WebApp webApp;
        string path = "../../../Logs/";
        string fileName = "testLogs.txt";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.Create(fileName);
           // Log.Handlers.Add(new FileLogHandler(path + fileName));
        }

        [SetUp]
        public void SetUp()
        {
           // Log.SetLevel(LogEventLevel.Debug).Dispose();
            webApp = new WebApp();
            webApp.OpenBrowser();
            webApp.LandingPage().GoTo();
        }
        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                webApp.TakeScreenshot();
            }
                webApp.ShutdownBrowser();
        }
    }
}
