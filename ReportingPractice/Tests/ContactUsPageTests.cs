using NUnit.Framework;


namespace ReportingPractice
{
    [TestFixture]
    //using a category allows us to group tests to view in the test explorer
    [Category("Reporting annd logging - contact us page")]
    public class ContactUsPageTests : BaseTest

    {
        

        [Test]
        //using a description allows us to describe each test case
        [Description("check that we can load the contact us page and it loads sucessfully")]
        public void TCD2()
        {
            //the driver used is inherited from the base class, we then pass this on and use it in the page methods
            ContactUsPage contactUsPage = new ContactUsPage(Driver);
            contactUsPage.GoTo();

            Assert.IsTrue(contactUsPage.IsLoaded(), "page failed to load sucessfully");

        }



        [Test]
        [Description("go to automation practice.com, click on contact us, verifiy the page opens")]

        public void TCD4()
        {
            
            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();

            ContactUsPage contactPage = homePage.Header.ClickContactUs();

            Assert.IsTrue(contactPage.IsLoaded());
           
            }


        [Test]
        [Description("click on the signin page and verify that it opens sucessfully")]

        public void TCD5()
        {
            SigninPage signIn;
       HomePage automationhomepage = new HomePage(Driver);
            automationhomepage.GoTo();

            signIn = automationhomepage.clickSignIn();
            Assert.IsTrue(signIn.IsLoaded());


        }



    }
}
