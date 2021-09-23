using NUnit.Framework;

namespace NopCommerce.data.register
{
    class RegisterData
    { 
      public static TestCaseData[] RegisterValidData()
    {
        return new TestCaseData[]
        {
            new TestCaseData("male","Fabrizio","Otranto","31","October","1995","testing","testing","testing").SetDescription("First registration data"),
            new TestCaseData("female","Agustin","Salgado","10","May","1992","testing","testing","testing").SetDescription("Second registration data"),
    };
    }
}
}