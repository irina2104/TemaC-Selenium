using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaCSelenium
{
    class AntivirusPage
    {
        private IWebDriver driver;

        public AntivirusPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#mesaj_custom")]
        private IWebElement popUp { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class='close']/a[contains(@onclick,'modal_close();return false;')]")]
        private IWebElement closeButton { get; set; }
           

        public void closePopUp()
        {
            if (popUp.Displayed) { closeButton.Click(); }
        }

        public string verifyProductTitle()
        {
            return driver.Title;
        }

      
    }
}
