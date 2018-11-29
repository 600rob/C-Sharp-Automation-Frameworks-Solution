using NLog;
using OpenQA.Selenium;
using System;
using System.Diagnostics;

namespace ReportingPractice
{
    internal class HomePage
    {
        private IWebDriver Driver;
        //use this to create log information at various levels
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private string testUrl = "http://automationpractice.com";
        //not got the event logger workign yet so comment this out for now
        //private EventLog robEventLog = new EventLog("appName", "robEvent");

        //page properties (sub sections)
        //slider is a property of this page but we will define it in a separate class in order to keep the 
        // page objects small
        //However, note we ONLY create a SINGLE slider object when we create a home page object!
        // Home page only contains one slider....this is why the constructor for te home page contains a new slider
        //the same goes for any other page propeties that we decide to make
        public Slider Slider { get; internal set; }
        public HeaderBar Header { get; internal set; }




        public HomePage(IWebDriver driver)
        {
            this.Driver = driver;

            Slider = new Slider(Driver);
            Header = new HeaderBar(Driver);
        }
       
       

        public void GoTo()
        {
            //robEventLog.BeginInit();

            Driver.Navigate().GoToUrl(testUrl);
            Driver.Manage().Window.Maximize();
            _logger.Info($"opened url=>{testUrl}");
        }

        public SearchPage Search(string ItemToSearchFor)
        {
            Driver.FindElement(By.Id("search_query_top")).SendKeys(ItemToSearchFor);
            Driver.FindElement(By.Name("submit_search")).Click();
            _logger.Info($"search for item n serch bar=>{ItemToSearchFor}");
           
          return new SearchPage(Driver);
               
        }

        public SigninPage clickSignIn()
        {

            Driver.FindElement(By.CssSelector("a[title*='Log in']")).Click();
            _logger.Info($"click on the signin in link");
            return new SigninPage(Driver);

        }



    }
}