using OpenQA.Selenium;
using System;

namespace ECommExercise
{
    internal class HomePage
    {
        private IWebDriver Driver;

        public HomePage(IWebDriver driver)
        {
            this.Driver = driver;

            Slider = new Slider(Driver);
        }

        //slider is a property of this page but we will define it in a separate class in order to keep the 
        // page objects small
        //However, note we ONLY create a SINGLE slider object when we create a home page object!
        // Home page only contains one slider....this is why the constructor contains a new slider
        public Slider Slider { get; internal set; }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com");
            Driver.Manage().Window.Maximize();
        }

        public SearchPage Search(string ItemToSearchFor)
        {
            Driver.FindElement(By.Id("search_query_top")).SendKeys(ItemToSearchFor);
            Driver.FindElement(By.Name("submit_search")).Click();

            return new SearchPage(Driver);
               
        }
    }
}