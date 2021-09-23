using NUnit.Framework;

namespace NopCommerce.data.login
{
    class LoginData
    {
        public static TestCaseData[] LoginValidData()
        {
            return new TestCaseData[]
            {
            new TestCaseData("tester@gmail.com", "testing").SetDescription("First Login valid data"),
            new TestCaseData("testing123@gmail.com", "testing").SetDescription("Second Login valid data"),
        };
        }

            public static TestCaseData[] LoginInvalidData()
            {
                return new TestCaseData[]
                {
            new TestCaseData("WrongEmail@gmail.com", "testing").SetDescription("Login data with invalid email"),
            new TestCaseData("testing123@gmail.com", "WrongPassword").SetDescription("Login data with invalid password"),
            };
            }

        public static TestCaseData[] RecoverPasswordData()
        {
            return new TestCaseData[]
            {
            new TestCaseData("testing123@gmail.com").SetDescription("Recover data with valid email"),
            new TestCaseData("WrongEmail@gmail.com").SetDescription("Recover data with invalid email"),
            
        };
        }
    }
}