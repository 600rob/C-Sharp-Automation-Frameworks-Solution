using System;
using OpenQA.Selenium;

namespace ReportingPracticeMSTEST

{
    internal class Slider
    {
        private IWebDriver Driver;

        public Slider(IWebDriver driver)
        {
            this.Driver = driver;
        }
        //locate the mina slider image 
        private IWebElement MainSliderImage => Driver.FindElement(By.Id("homeslider"));
        // store the image text for the current image ( use this for comparison later)
        public string CurrentImageText => MainSliderImage.GetAttribute("style");

        public void clickNext()
        {
            Driver.FindElement(By.ClassName("bx-next")).Click();
        }
    }
}