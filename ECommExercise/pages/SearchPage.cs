using System;
using OpenQA.Selenium;

namespace ECommExercise
{
    internal class SearchPage
    {
        private IWebDriver Driver;

        public SearchPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public bool Contains(Item blouse)
        {
            switch (blouse)
            {
                case Item.Blouse:
                    return Driver.FindElement(By.XPath("//*[@title='Blouse']")).Displayed;
                default:
                    // throw this to handle passing in an item that does not exist
                    throw new ArgumentOutOfRangeException("the item you passed in does not exist");



            }
        }
    }
}