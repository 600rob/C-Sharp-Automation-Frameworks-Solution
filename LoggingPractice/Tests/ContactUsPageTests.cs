using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoggingPractice
{
    [TestFixture]
    //using a category allows us to group tests to view in the test explorer
    [Category("logging contact us page")]
    public class ContactUsPageTests

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
        [Description("check that we can load the contact us page and it loads sucessfully")]
        public void CanSubmitContactUsForm()
        {
            ContactUsPage contactUsPage = new ContactUsPage(Driver);
            contactUsPage.GoTo();

            Assert.IsTrue(contactUsPage.IsLoaded(), "page failed to load sucessfully");

        }


        [TearDown]
        public void stopDriver()
        {
            Driver.Close();
            Driver.Quit();

        }

    }
}
