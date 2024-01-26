using Guru99.PageObjects;
using Guru99.Utilities;
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
    public class E2ETest:Base
    {

        [Test]
        public void ValidLoginTest()
        {
            Login login = new Login(getDriver());
            HomeObject home = login.validLogin("mngr549647", "abYtanu");

            home.waitForNextPageDisplay();
            Assert.That("Guru99 Bank Manager HomePage", Is.EqualTo(home.getTitle()));
        }


        [Test,TestCaseSource("AddTestDataConfig")]
         public void InvalidLoginTest( string username, string password)
        {
            Login login = new Login(getDriver());
            login.validLogin(username, password);

            IAlert alert = driver.SwitchTo().Alert();
            String alertText = alert.Text;   
            Assert.That("User or Password is not valid", Is.EqualTo(alertText));

        }



        public static IEnumerable <TestCaseData> AddTestDataConfig()
        {
       
            yield return new  TestCaseData("invalid", "abYtanu");
            yield return new  TestCaseData("mngr549647", "invalid");
            yield return new TestCaseData("invalid", "invalid");

        }

    }
}
