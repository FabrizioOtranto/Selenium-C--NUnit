using Applitools.Selenium;
using NopCommerce.data.register;
using NopCommerce.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;

namespace NopCommerce
{
    public class RegisterTest
    {
        
        IWebDriver driver;
        Eyes eyes;
        public string URL = "https://demo.nopcommerce.com/register";
        RegisterPage registerPage;


        [SetUp]
        public void Setup()
        {
            eyes = new Eyes();
            driver = new ChromeDriver(".");
            registerPage = new RegisterPage(driver);
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
        }

        [Test]
        [TestCaseSource(typeof(RegisterData), nameof(RegisterData.RegisterValidData))]
        [Parallelizable]
        public void RegisterWithValidCredentials(string gender, string firstname, string lastname, string birthDay, string birthMonth, string BirthYear, string email, string password, string confirmpassword)
        {
            Random r = new Random();
            var Email = email + r.Next() +"@gmail.com";
           
            registerPage.SetGender(gender);
            registerPage.SetFirstname(firstname);
            registerPage.SetLastname(lastname);
            registerPage.SetBirthDay(birthDay);
            registerPage.SetBirthMonth(birthMonth);
            registerPage.SetBirthYear(BirthYear);
            registerPage.SetEmail(Email);
            registerPage.SetPassword(password);
            registerPage.SetConfirmPassword(confirmpassword);
            if (firstname == "Fabrizio")
            {
                eyes.Open(driver, "Register Test", "Register Page", new Size(1540, 730));
                By form = By.ClassName("page-body");
                eyes.CheckElement(form);
                eyes.CloseAsync();
            }
            registerPage.ClickRegisterBtn();
            registerPage.ValidateRegistration();
            if (firstname == "Fabrizio")
            {
                eyes.Open(driver, "Register Test", "Register Confirmation", new Size(1540, 730));
                eyes.CheckWindow();
                eyes.CloseAsync();
            }


        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            //eyes.AbortIfNotClosed();
        }
    }
}
