
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReportingPracticeMSTEST

{

    [TestClass]
    //using a category allows us to group tests to view in the test explorer
    //[TestCategory("MSTEST Reporting and logging - search page")]
    public class SliderTest : BaseTest
    {
       

        [TestMethod]
        [Description("test the slider on the homepage cycles bac and forward")]
        public void MSTCD3()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();

            var currentImagetext = homePage.Slider.CurrentImageText;

            homePage.Slider.clickNext();

            var newimageText = homePage.Slider.CurrentImageText;

            Assert.AreEqual(currentImagetext, newimageText, " the slider images did not change when pressing the next button!");

       }


 


    }
}
