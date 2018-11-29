using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReportingPracticeMSTEST
{
    [TestClass]
   //using a category allows us to group tests to view in the test explorer
   //[TestCategory("MSTEST Reporting and logging - contact us page")]

    public class ContactUsPageTests : BaseTest

    {
        

        [TestMethod]
        //using a description allows us to describe each test case
        [Description("check that we can load the contact us page and it loads sucessfully")]
        public void MSTCD2()
        {
            //the driver used is inherited from the base class, we then pass this on and use it in the page methods
            ContactUsPage contactUsPage = new ContactUsPage(Driver);
            contactUsPage.GoTo();

            Assert.IsTrue(contactUsPage.IsLoaded(), "page failed to load sucessfully");

        }


   

    }
}
