using System;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReportingPracticeMSTEST
{
    [TestClass]
    //using a category allows us to group tests to view in the test explorer
    //[TestCategory("MSTEST Reporting annd logging - search page")]
    public class SearchPageTests : BaseTest
    {
      
        
     
        [TestMethod]
        //using a description allows us to describe each test case
        [Description("check that we can load the home page and run a search for blouse")]
        public void MSTCD1()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();
            SearchPage searchPage = homePage.Search("Blouse");
            Assert.IsTrue(searchPage.Contains(Item.Blouse));

        }



  
    }
}
