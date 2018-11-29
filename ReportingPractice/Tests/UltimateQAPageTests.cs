using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingPractice.Tests
{
    [TestFixture]
    [Category("Ultimate QA page tests")]


    
    class UltimateQAPageTests : BaseTest
    {
        // set some field for use in the test
        string name = "robbo";
        string email = "robbo@testing.com";
        string message = "automation testing is  fun!";



        [Test]
        [Description("navigate to the complicated page, fill out the form and submit it")]

        public void TCDC6()
        {
            UltimateQAComplicatedPage complicatedPage = new UltimateQAComplicatedPage(Driver);
            complicatedPage.goTo();
            Report.LogPassingTestStepToBugLogger("Load the ultimate QA comploicated page");
            complicatedPage.fillOutForm(name, email, message);
            Report.LogPassingTestStepToBugLogger("fill out the fist form");
            complicatedPage.VerifyCaptchaAndSubmitForm();
            Report.LogPassingTestStepToBugLogger("submit the form");

            Assert.IsTrue(complicatedPage.ContactMessageIsVisible());


        }


        



    }
}
