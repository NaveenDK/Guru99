using Guru99.PageObjects;
using Guru99.Utilities;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Guru99
{

    [AllureNUnit]
    public class E2ETest:Base
    {


        [Test(Description="Verify Valid login")]
        [AllureStory("Login with valid password")]
        [AllureStep("Login with valid Password")]
        
        public void ValidLoginTest()
        {
            String userID = "mngr549647";
            Login login = new Login(getDriver());
            HomeObject home = login.validLogin(userID, "abYtanu");

            home.waitForNextPageDisplay();        
             Screenshot screenshot = (driver.Value as ITakesScreenshot).GetScreenshot();
             screenshot.SaveAsFile(driver.Value.Title + "_" + "Screenshot.png");
             StringAssert.Contains(userID, home.getManagerId(),"ManagerID is not displayed");
     

        }
        [Parallelizable(ParallelScope.All)]

        [Test(Description = "Verify Invalid login"), TestCaseSource("AddTestDataConfig")]
        //[Test(Description = "Verify Valid login")]
        [AllureStory("Login with Invalid password")]
        [AllureStep("Login with Invalid Password")]
        public void InvalidLoginTest( string username, string password)
        {
            Login login = new Login(getDriver());
            login.validLogin(username, password);

            IAlert alert = driver.Value.SwitchTo().Alert();
            String alertText = alert.Text;   
            Assert.That("User or Password is not valid", Is.EqualTo(alertText));

        }

 

        public static IEnumerable <TestCaseData> AddTestDataConfig()
        {
       
            yield return new  TestCaseData(getDataParser().extractData("username_wrong"), getDataParser().extractData("password_wrong"));;
            yield return new  TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password_wrong"));
            yield return new TestCaseData(getDataParser().extractData("username_wrong"), getDataParser().extractData("password"));

        }

    }
}
