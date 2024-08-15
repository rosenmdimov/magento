using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Playtech.Main.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playtech.Main.Tests
{
    [TestFixture]
    internal class LoginNegativeTests : BaseTest
    {

        [Test]
        public void LoginWithInvalidCredentials()
        {
            string invalidEmail = "invalid@email.com";
            string invalidPasword = "Inv@lidPassw0rd";

            webApp.LoginPage().GoTo();
            webApp.LoginPage().Login(invalidEmail, invalidPasword);
            webApp.LoginPage()
                .VerifyErrorAlertDisplayed("The account sign-in was incorrect or your account is disabled temporarily. Please wait and try again later.");
        }
        [Test]
        public void LoginWithoutCredentials()
        {
            webApp.LoginPage().GoTo();
            webApp.LoginPage().ClickLoginButton();
            webApp.LoginPage()
                .VerifyEmailErrorMessageDisplayed("This is a required field.");
            webApp.LoginPage()
                .VerifyPasswordErrorMessageDisplayed("This is a required field.");
        }
    }

}
