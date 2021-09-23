using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace NopCommerce.pages
{
    class RegisterPage
    {

        IWebDriver driver;

        public By firstname = By.Id("FirstName");
        public By lastname = By.Id("LastName");
        public By birthDay = By.Name("DateOfBirthDay");
        public By birthMonth = By.Name("DateOfBirthMonth");
        public By birthYear = By.Name("DateOfBirthYear");
        public By email = By.Id("Email");
        public By password = By.Id("Password");
        public By confirmPassword = By.Id("ConfirmPassword");
        public By registerBtn = By.Id("register-button");
        public By validateMessage = By.ClassName("result");



        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void SetGender(string Gender)
        {
            By gender = By.Id("gender-" + Gender);
            this.driver.FindElement(gender, 10).Click();
        }

        public void SetFirstname(string text)
        {
            this.driver.FindElement(firstname,10).SendKeys(text);
        }

        public void SetLastname(string text)
        {
            this.driver.FindElement(lastname,10).SendKeys(text);
        }

        public void SetBirthDay(string text)
        {
            IWebElement selectElement = this.driver.FindElement(birthDay,10);
            var selectObject = new SelectElement(selectElement);
            selectObject.SelectByText(text);
        }

        public void SetBirthMonth(string text)
        {
            IWebElement selectElement = this.driver.FindElement(birthMonth,10);
            var selectObject = new SelectElement(selectElement);
            selectObject.SelectByText(text);
        }

        public void SetBirthYear(string text)
        {
            IWebElement selectElement = this.driver.FindElement(birthYear,10);
            var selectObject = new SelectElement(selectElement);
            selectObject.SelectByText(text);
        }


        public void SetEmail(string text)
        {
            this.driver.FindElement(email,10).SendKeys(text);
        }

        public void SetPassword(string text)
        {
            this.driver.FindElement(password,10).SendKeys(text);
        }

        public void SetConfirmPassword(string text)
        {
            this.driver.FindElement(confirmPassword,10).SendKeys(text);
        }

        public void ClickRegisterBtn( )
        {
            this.driver.FindElement(registerBtn,10).Click();
        }

        public void ValidateRegistration()
        {
            Assert.That(this.driver.FindElement(validateMessage,10).Text, Is.EqualTo("Your registration completed")); 
        }

    }
}
