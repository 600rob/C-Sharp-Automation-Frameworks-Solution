using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace ReportingPractice { 
    public class WebDriverFactory
    //So, the webdriver factory is a class that we use to create different browser types
    //when we call the create method. We can implement additional case statments and methods for each browser
    //type as we want to use them in our tests
    {
        public IWebDriver Create(BrowserType browser)
        {
            switch(browser)
            {
                case BrowserType.Chrome:
                    return GetChromeBrowser();
                default:
                    throw new ArgumentNullException("the browser entered does not exist");


            }
            
        }

        //helper methods to get each browser
        private IWebDriver GetChromeBrowser()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory);

            //create an explicit wait for reuse and possibly use this in each method?
        }
    }
}