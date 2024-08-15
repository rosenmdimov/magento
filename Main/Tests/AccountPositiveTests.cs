using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Playtech.Main.Utils;

namespace Playtech.Main.Tests
{
    [TestFixture]
    public class AccountPositiveTests : BaseTest
    {
        static IConfigurationRoot configBuilder = new ConfigurationBuilder().
                                                   AddJsonFile("appsettings.json").Build();
        IConfigurationSection configSection = configBuilder.GetSection("User");
        private User user;

        [Test]
        public void CreateNewAccount() 
        {
            int registerTriesCount = 0;
            user = new User(
                configSection["firstName"],
                configSection["lastName"], 
                configSection["email"], 
                configSection["password"]);
           
            webApp.CreateAccountPage().GoTo();
            bool isRegistered;
            do
            {
                webApp.CreateAccountPage().FillInDetails(user);
                registerTriesCount++;
                user.Email = webApp.ChangeEmailAndReadUsed(user.Email, registerTriesCount);
                isRegistered = webApp.CreateAccountPage().RegisterUser();
            }
            while (!isRegistered);

            webApp.MyAccountPage().VerifyTitle("My Account");
            webApp.MyAccountPage().VerifyWellcomeMessageContains(user.FirstName);
        }

        [Test]
        public void Purchase()
        {
            string orderNumber;
            user = new User(
                configSection["firstName"],
                configSection["lastName"],
                configSection["email"],
                configSection["password"],
                configSection["streetAddress"],
                configSection["city"],
                configSection["state"],
                configSection["country"],
                configSection["phoneNumber"],
                configSection["zip"]
                );

            webApp.LoginPage().GoTo();
            webApp.LoginPage().Login(user.Email, user.Password);
            webApp.MenuPage().GoToWomenJacetsList();
            webApp.ItemsListPage().OpenFirstItemDetails();
            webApp.ItemDetailsPage().SelectSizeColorQuantity("XS", "Black", 1);
            webApp.ItemDetailsPage().CheckCartContent();
            webApp.ItemDetailsPage().ProceedToCheckout();
            webApp.CheckoutPage().FillShippingAddress(user);
            webApp.CheckoutPage().GoToPaymentMethod();
            orderNumber = webApp.SuccessPage().GetOrderAndOpenIt();
            webApp.OrderDetailsPage().VerifyOrderExists(orderNumber);
        }
    }
}
