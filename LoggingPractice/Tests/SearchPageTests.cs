using System;

using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;


namespace LoggingPractice
{
    [TestFixture]
    //using a category allows us to group tests to view in the test explorer
    [Category("logging search page")]
    public class SearchPageTests
    {
        public IWebDriver Driver { get; private set; }


        [SetUp]
        public void startDriverBeforeEachTest()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Driver = new ChromeDriver(outputDirectory);

        }




        [Test]
        //using a description allows us to describe each test case
        [Description("check that we can load the home page and run a search")]
        public void CanUseSearchFunction()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();
            SearchPage searchPage = homePage.Search("Blouse");
            Assert.IsTrue(searchPage.Contains(Item.Blouse));



        }



        [TearDown]
        public void closeBroswerAfterEachTest()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
