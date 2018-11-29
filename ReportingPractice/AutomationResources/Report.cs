﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReportingPractice
{
    //The Report class is used across the entire framework and we use this class (not the actual extent reporter) for our reports
    //the class is a static class so that we dont have to insantiate it everywhere we want to use it

    public static class Report
    //properties
    {
        //TheLogger allows us to log test activity to a file
        private static readonly Logger TheLogger = LogManager.GetCurrentClassLogger();
        //ReportManager allows ot create an Extent report
        private static ExtentReports ReportManager { get; set; }
        //This creates the top levlel folder for our reports and debugging in c:\temp
        private static string ApplicationDebuggingFolder => "c://temp/CreatingReports-Nunit";
        //path to where our extent report will get stored
        private static string HtmlReportFullPath { get; set; }
        // This sets a time dated, folder inside our top level folder wihch gets created with every test run
        public static string LatestResultsReportFolder { get; set; }
        //This creates a testContext object which Provides the context information of the current test.
        private static TestContext MyTestContext { get; set; }
        // I Think this creates a test case that gets used in the HTML report (TBC)
        private static ExtentTest CurrentTestCase { get; set; }
       //We can do this
        // public static TestContext Test { get; set; }
      








        //This method initalises a report so we can use it.



        public static void StartReporter()
        {
            // and set it like this, i thin se need to set it before passing it in to the method
            //Test = TestContext.CurrentContext;

            TheLogger.Trace("Starting a one time setup for the entire" +
                            " .ReportingPractice namespace." +
                            "Going to initialize the reporter next...");
            // It creates a directory for the report(separate method)
            CreateReportDir();
            // It creates an html report
            var htmlReporter = new ExtentHtmlReporter(HtmlReportFullPath);
            //Then it creates a report manager to handle the html report
            ReportManager = new ExtentReports();
            //Think this allows the report manager access all started tests, nodes and logs
            ReportManager.AttachReporter(htmlReporter);


        }

        //method to create a directory for HTML reports
        private static void CreateReportDir()
        {
            //take the path for our top level folder
            var filePath = Path.GetFullPath(ApplicationDebuggingFolder);
            //set the name and location for the latest results folder, suffix it with date and time
            LatestResultsReportFolder = Path.Combine(filePath, DateTime.Now.ToString("MMdd_HHmm"));
            //create the directory for the latest results folder
            Directory.CreateDirectory(LatestResultsReportFolder);

            //Sets path to where our extent report will get stored every time a new test run is started and give it a filename
            HtmlReportFullPath = $"{LatestResultsReportFolder}\\TestResults.html";
            TheLogger.Trace("Full path of HTML report=>" + HtmlReportFullPath);

        }

        // this initialises our testContext object and initialises the current test case
        //do we do this for each test???(TBC)
        public static void AddTestCaseMetadataToHtmlReport(TestContext testContext)
        {
            testContext = TestContext.CurrentContext;
            MyTestContext = testContext;
            CurrentTestCase = ReportManager.CreateTest(MyTestContext.Test.FullName);
        }

        public static void LogPassingTestStepToBugLogger(string message)
        {
            //this captures informational messages as test steps and puts them in the HTML report
            TheLogger.Info(message);
            // this places test steps into the html report current test case( i think it only records passing stesp TBC)
            CurrentTestCase.Log(Status.Pass, message);
        }

        public static void ReportTestOutcome(string screenshotPath)
        {
            var status = MyTestContext.Result.Outcome.Status;

            switch (status)
            {
                case TestStatus.Failed:
                    TheLogger.Error($"Test Failed=>{MyTestContext.Test.FullName}");
                    CurrentTestCase.AddScreenCaptureFromPath(screenshotPath);
                    CurrentTestCase.Fail("Fail");
                    break;
                case TestStatus.Inconclusive:
                    CurrentTestCase.AddScreenCaptureFromPath(screenshotPath);
                    CurrentTestCase.Warning("Inconclusive");
                    break;
                case TestStatus.Warning:
                    CurrentTestCase.Skip("Test skipped");
                    break;
                default:
                    CurrentTestCase.Pass("Pass");
                    break;
            }

            ReportManager.Flush();
        }

        public static void LogTestStepForBugLogger(Status status, string message)
        {
            //this also captures informational messages as test steps and puts them somewhere
            //just not sure where yet!
            // Also think it handles more than just passing test steps-need to investigate this one more
            TheLogger.Info(message);
            CurrentTestCase.Log(status, message);
        }





    }
}
