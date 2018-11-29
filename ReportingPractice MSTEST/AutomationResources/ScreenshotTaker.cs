using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using System;

namespace ReportingPracticeMSTEST
{
    public class ScreenshotTaker
    { 
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        //private IWebDriver driver;
      
        private readonly IWebDriver _driver;
        private readonly TestContext _testContext;
        public string ScreenshotFilePath { get; private set; }
        private string ScreenshotFileName { get; set; }


        public ScreenshotTaker(IWebDriver driver, TestContext testContext)
        {
           
            if (driver == null)
                return;
            _driver = driver;
            _testContext = testContext;
            ScreenshotFileName = _testContext.TestName;

        }

        public void CreateScreenshotIfTestFailed()
        {
            if (_testContext.CurrentTestOutcome == UnitTestOutcome.Failed ||
                _testContext.CurrentTestOutcome == UnitTestOutcome.Inconclusive)
                TakeScreenshotForFailure();
        }
        public bool TakeScreenshotForFailure()
        {
            ScreenshotFileName = $"FAIL_{ScreenshotFileName}";

            var ss = GetScreenshot();
            var successfullySaved = TryToSaveScreenshot(ScreenshotFileName, ss);
            if (successfullySaved)
                Logger.Error($"Screenshot Of Error=>{ScreenshotFilePath}");
            return successfullySaved;
        }

        private Screenshot GetScreenshot()
        {
            return ((ITakesScreenshot)_driver)?.GetScreenshot();
        }



        private bool TryToSaveScreenshot(string screenshotFileName, Screenshot ss)
        {
            try
            {
                SaveScreenshot(screenshotFileName, ss);
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e.InnerException);
                Logger.Error(e.Message);
                Logger.Error(e.StackTrace);
                return false;
            }
        }


        private void SaveScreenshot(string screenshotName, Screenshot ss)
        {
            if (ss == null)
                return;
            ScreenshotFilePath = $"{Report.LatestResultsReportFolder}\\{screenshotName}.jpg";
            ScreenshotFilePath = ScreenshotFilePath.Replace('/', ' ').Replace('"', ' ');
            ss.SaveAsFile(ScreenshotFilePath, ScreenshotImageFormat.Png);
        }






    }
}