using NLog;
using OpenQA.Selenium;
using System;

namespace ReportingPractice
{

    public class SigninPage
    {
        //loggin items
        //use this to create log information at various levels
        private static Logger _logger = LogManager.GetCurrentClassLogger();


        private IWebDriver Driver;

        public SigninPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public bool? IsLoaded()
        {
            try
                
            {
                _logger.Info($"verify the sign in page is loaded");
                return Driver.FindElement(By.CssSelector("button[name='SubmitLogin']")).Displayed;
               
                    }

            catch
        (NoSuchElementException)
            {
                _logger.Warn($"Element not found - signin page not loaded");
                return false;
            }

        }
    }
}