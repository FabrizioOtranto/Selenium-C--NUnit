using Applitools.Selenium;
using NopCommerce.data.login;
using NopCommerce.data.register;
using NopCommerce.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;

namespace NopCommerce
{
    public class LogintTest
    {
        
        IWebDriver driver;
        Eyes eyes;
        public string URL = "https://demo.nopcommerce.com/login";
        LoginPage loginPage;
        HomePage homePage;


        [SetUp]
        public void Setup()
        {
            eyes = new Eyes();
            driver = new ChromeDriver(".");
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
        }

        [Test]
        [TestCaseSource(typeof(LoginData), nameof(LoginData.LoginValidData))]
        [Parallelizable]
        public void LoginWithValidCredentials(string email, string password)
        {
            loginPage.SetEmail(email);
            loginPage.SetPassword(password);
            loginPage.ClickLoginBtn();
            if (email == "tester@gmail.com")
            {
                eyes.Open(driver, "Login Test Valid Data", "Valid data", new Size(1540, 730));
                eyes.CheckWindow();
                eyes.CloseAsync();
            }
        }

        [Test]
        [TestCaseSource(typeof(LoginData), nameof(LoginData.LoginInvalidData))]
        [Parallelizable]
        public void LoginWitInvalidCredentials(string email, string password)
        {
            loginPage.SetEmail(email);
            loginPage.SetPassword(password);
            loginPage.ClickLoginBtn();
            if (email == "WrongEmail@gmail.com")
            {
                eyes.Open(driver, "Login Test Invalid email", "Invalid email", new Size(1540, 730));
                eyes.CheckWindow();
                eyes.CloseAsync();
            }
            else
            {
                eyes.Open(driver, "Login Test Invalid Password", "Invalid Password", new Size(1540, 730));
                eyes.CheckWindow();
                eyes.CloseAsync();
            }
        }

        [Test]
        [TestCaseSource(typeof(LoginData), nameof(LoginData.RecoverPasswordData))]
        [Parallelizable]
        public void RecoverPasswordValidCredentials(string email)
        {
            loginPage.ClickForgotPasswordLink();
            loginPage.SetEmail(email);
            loginPage.ClickRecoverBtn();
            if (email == "testing123@gmail.com")
            {
                eyes.Open(driver, "Recover Data Valid email", "Recover password with alid email", new Size(1540, 730));
                eyes.CheckWindow();
                eyes.CloseAsync();
            }
            else
            {
                eyes.Open(driver, "Recover Data Valid email", "Recover password with invalid email", new Size(1540, 730));
                eyes.CheckWindow();
                eyes.CloseAsync();
            }

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            eyes.AbortIfNotClosed();
        }
    }
}
