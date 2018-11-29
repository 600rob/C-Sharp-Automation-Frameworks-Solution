using System;
using OpenQA.Selenium;
using NLog;

namespace ReportingPractice


{
    public class ContactUsPage {

        //loging items
        //use this to create log information at various levels
        private static Logger _logger = LogManager.GetCurrentClassLogger();



        private IWebDriver Driver;
        private string testUrl = "http://automationpractice.com/index.php?controller-contact";

        public ContactUsPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(testUrl);
            Driver.Manage().Window.Maximize();
            _logger.Info($"load the target url=>{testUrl}");
}

        public bool IsLoaded()
        {
            try {
                _logger.Info($"verify the contact us page is loaded");
                return Driver.FindElement(By.Id("center_column")).Displayed;
                
            }

            catch (NoSuchElementException)
            {
                return false;
            }
           
        }

    }
}
