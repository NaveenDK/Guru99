﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99.PageObjects
{

    public class HomeObject
    {
        private IWebDriver driver;

        public HomeObject(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[3]/td")]
        private IWebElement ManagerText;


        public void waitForNextPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("layout")));

        }


        public String getManagerId()
        {
            return ManagerText.Text;

        }
        public String getTitle()
        {
            return driver.Title;
        }

    
        public bool isLoginSuccessful()
        {

            return driver.Title.Equals("Guru99 Bank Manager HomePage", StringComparison.OrdinalIgnoreCase);
        }
    }
}
