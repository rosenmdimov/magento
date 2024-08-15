using OpenQA.Selenium;

namespace Playtech.Main.Pages
{
    public class LandingPage(IWebDriver driver) : BasePage(driver)
    {
        string url = "";

        public void GoTo()
        {
            base.NavigateTo(url);
        }

    }
}
