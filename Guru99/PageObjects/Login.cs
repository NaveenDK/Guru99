using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99.PageObjects
{
    public class Login
    {
        private IWebDriver driver;

        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //pageobject factory
        [FindsBy(How = How.XPath, Using = "//input[@type=\"text\"]")]
        private IWebElement username;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.Name, Using = "btnLogin")]
        private IWebElement signInButton;

      
        public HomeObject validLogin(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            signInButton.Click();
       
            return new HomeObject(driver);
            

        }
        public void invalidLogin(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            signInButton.Click();

        }
        public IWebElement getUserName()
        {
            return username;
        }

     


    }
}
