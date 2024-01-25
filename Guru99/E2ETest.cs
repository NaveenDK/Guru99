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
            HomeObject home= login.validLogin("mngr549647","abYtanu");
         
            home.waitForNextPageDisplay();       
           Assert.That("Guru99 Bank Manager HomePage", Is.EqualTo(home.getTitle()));
        }

        [Test]
        public void InvalidLoginTest()
        {
            Login login = new Login(getDriver());
            login.validLogin("wrong", "wrong");
 
            IAlert alert = driver.SwitchTo().Alert();

             
            String alertText = alert.Text;
            Assert.IsTrue(alertText.Contains("User or Password is not valid"));

        }

    }
}
