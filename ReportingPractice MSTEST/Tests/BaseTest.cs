using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingPracticeMSTEST
{
    [TestClass]
    public class BaseTest
        //the base test is used directly by TESTS and not pages. Hence ONLY TESTs should inherit from the base class
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        protected IWebDriver Driver;
        public TestContext TestContext { get; set; }
        private ScreenshotTaker ScreenshotTaker { get; set; }
        


        [TestInitialize]

        public void SetupBeforeEveryTest()
        {
            Logger.Debug("*************************************** TEST STARTED");
            Logger.Debug("*************************************** TEST STARTED");
         
            Report.AddTestCaseMetadataToHtmlReport(TestContext);
            WebDriverFactory factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            Driver.Manage().Window.Maximize();
            ScreenshotTaker = new ScreenshotTaker(Driver, TestContext);


        }

        [TestCleanup]

        public void TearDownForEveryTest()
        {
            Logger.Debug(GetType().FullName + " started a method tear down");
            try
            {
                TakeScreenshotForTestFailure();
            }
            catch (Exception e)
            {
                Logger.Error(e.Source);
                Logger.Error(e.StackTrace);
                Logger.Error(e.InnerException);
                Logger.Error(e.Message);
            }
            finally
            {
                StopBrowser();
                Logger.Debug(TestContext.TestName);
                Logger.Debug("*************************************** TEST STOPPED");
                Logger.Debug("*************************************** TEST STOPPED");
            }
        }


        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotTaker != null)
            {
                ScreenshotTaker.CreateScreenshotIfTestFailed();
                Report.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                Report.ReportTestOutcome("");
            }
        }



        private void StopBrowser()
        {
            if (Driver == null)
                return;
          Driver.Quit();
            Driver = null;
            Logger.Trace("Browser stopped successfully.");

        }
    }
}
