using NUnit.Framework;
using OpenQA.Selenium;


namespace NopCommerce.pages
{
    class LoginPage
    {

        IWebDriver driver;

        public By email = By.Id("Email");
        public By password = By.Id("Password");
        public By loginBtn = By.ClassName("login-button");
        public By ForogtPasswordLink = By.LinkText("Forgot password?");
        public By recoverBtn = By.ClassName("password-recovery-button");
        public By validateMessage = By.ClassName("result");



        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        public void SetEmail(string text)
        {
            this.driver.FindElement(email,10).SendKeys(text);
        }

        public void SetPassword(string text)
        {
            this.driver.FindElement(password,10).SendKeys(text);
        }


        public void ClickLoginBtn( )
        {
            this.driver.FindElement(loginBtn,10).Click();
        }

        

          public void ClickForgotPasswordLink()
        {
            this.driver.FindElement(ForogtPasswordLink, 10).Click();
        }

        public void ClickRecoverBtn()
        {
            this.driver.FindElement(recoverBtn, 10).Click();
        }

        public void ValidateForgotPasswordValidEmail()
        {
            Assert.That(this.driver.FindElement(validateMessage,10).Text, Is.EqualTo("Email with instructions has been sent to you.")); 
        }

        public void ValidateForgotPasswordInvalidEmail()
        {
            Assert.That(this.driver.FindElement(validateMessage,10).Text, Is.EqualTo("Email not found."));
        }

    }
}
