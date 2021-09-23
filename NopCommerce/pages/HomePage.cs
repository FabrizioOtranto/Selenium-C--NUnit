using NUnit.Framework;
using OpenQA.Selenium;


namespace NopCommerce.pages
{
    class HomePage
    {

        IWebDriver driver;

        public By validateTitle = By.XPath("//*[text() = 'Welcome to our store']");



        public HomePage(IWebDriver driver)
        {
            this.driver = driver;

        }
        public void ValidateTitle()
        {
            Assert.That(this.driver.FindElement(validateTitle,10).Text, Is.EqualTo("Welcome to our store")); 
        }

    }
}
