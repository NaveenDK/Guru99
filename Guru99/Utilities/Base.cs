﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using Guru99.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using System.Threading;

namespace Guru99.Utilities
{
    public class Base
    {
      //  public IWebDriver driver;
        public  ThreadLocal <IWebDriver> driver = new ThreadLocal<IWebDriver>(); 

        [SetUp]
        public void StartBrowser()
        {
            // String browserName = "Chrome";
            String browserName = ConfigurationManager.AppSettings["browser"];
            String url = ConfigurationManager.AppSettings["Url"];
            
            // Console.WriteLine(browserName);
            InitBrowser(browserName);

            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Value.Manage().Window.Maximize();

            driver.Value.Url = url;
        }
        //public void StartBrowser()
        //{
        //    try
        //    {
        //        string browserName = ConfigurationManager.AppSettings["browser"];
        //        string url = ConfigurationManager.AppSettings["URL"];

        //        if (string.IsNullOrEmpty(browserName) || string.IsNullOrEmpty(url))
        //        {
        //            throw new ConfigurationException("Browser or URL configuration is missing or invalid.");
        //        }

        //        InitBrowser(browserName);

        //        driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        //        driver.Value.Manage().Window.Maximize();

        //        driver.Value.Url = url;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle or log the exception appropriately
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //    }
        //}

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;
                case "Edge":
                    driver.Value = new EdgeDriver();
                    break;

            }
        }

        public IWebDriver getDriver()
        {
            return driver.Value;
        }

        public static JsonReader getDataParser()
        {
            return new JsonReader();
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Value.Quit();
        }
    }
}
