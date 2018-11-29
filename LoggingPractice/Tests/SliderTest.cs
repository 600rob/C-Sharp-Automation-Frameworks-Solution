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
    [Category("logging search page")]
    public class SliderTest
    {
        public IWebDriver Driver { get; private set; }


        [SetUp]
        public void startDriverBeforeEachTest()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Driver = new ChromeDriver(outputDirectory);

        }

        [Test]
        [Description("test the slider on the homepage cycles bac and forward")]
        public void sliderTest()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();

            var currentImagetext = homePage.Slider.CurrentImageText;

            homePage.Slider.clickNext();

            var newimageText = homePage.Slider.CurrentImageText;

            Assert.AreEqual(currentImagetext, newimageText, " the slider images did not change when pressing the next button!");

       }


        [TearDown]
        public void stopDriver()
        {
            Driver.Close();
            Driver.Quit();

        }


    }
}
