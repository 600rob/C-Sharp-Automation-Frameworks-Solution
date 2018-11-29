using System;
using OpenQA.Selenium;


namespace ReportingPracticeMSTEST


{
    public class ContactUsPage { 

        private IWebDriver Driver;

        public ContactUsPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller-contact");
            Driver.Manage().Window.Maximize();
        }

        public bool IsLoaded()
        {
            try {
               
                    return Driver.FindElement(By.Id("center_column")).Displayed;

                }
               
            catch(NoSuchElementException)
            {
                return false;
            }

        }

    }
}
