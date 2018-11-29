using NLog;
using OpenQA.Selenium;
using System;

namespace ReportingPractice.Tests
{
    public class UltimateQAComplicatedPage
    {
        private IWebDriver Driver;

        //logging items
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        

        // locators using properties with auto implemented getter
        IWebElement NameField => Driver.FindElement(By.Id("et_pb_contact_name_1"));
        IWebElement EmailField => Driver.FindElement(By.Id("et_pb_contact_email_1"));
        IWebElement MessageField => Driver.FindElement(By.Id("et_pb_contact_message_1"));
        IWebElement Capthcha => Driver.FindElement(By.CssSelector("input[name = 'et_pb_contact_captcha_0']"));
        IWebElement ContactMessage => Driver.FindElement(By.CssSelector("[class='et-pb-contact-message']"));
            


        public UltimateQAComplicatedPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

       public void goTo()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/complicated-page/");
            Driver.Manage().Window.Maximize();
            _logger.Info("launch the ultimate qa page");
        }

      

        public void fillOutForm(string name, string email, string message)
        {
            NameField.SendKeys(name);
            EmailField.SendKeys(email);
            MessageField.SendKeys(message);
            _logger.Info("fill out the first from with name, email and message. sumbit the form");
        }

        public void VerifyCaptchaAndSubmitForm() {
            var answer = int.Parse(Capthcha.GetAttribute("data-first_digit")) +
                int.Parse(Capthcha.GetAttribute("data-second_digit"));
            Capthcha.SendKeys(answer.ToString());

            Driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            _logger.Info("enter the captcha answer and submit the form");

        }

        public bool? ContactMessageIsVisible()
        {
            try
            {
                return
                    ContactMessage.Displayed;
            }
            catch (ElementNotVisibleException)
            {
                return false;
            }

        }





    }
}