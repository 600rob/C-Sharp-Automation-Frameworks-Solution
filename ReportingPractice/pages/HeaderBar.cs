using System;
using OpenQA.Selenium;
using NLog;

namespace ReportingPractice
{
    public class HeaderBar
    {

        


        private IWebDriver Driver;
        //logging items
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public HeaderBar(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public ContactUsPage ClickContactUs()
        {
            Driver.FindElement(By.CssSelector("a[title='Contact Us']")).Click();
            _logger.Info($"click on the contact us button");
            return new ContactUsPage(Driver);
        }
    }
}