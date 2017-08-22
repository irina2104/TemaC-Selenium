using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaCSelenium
{
    class SelectedMenuResults
    {
        private IWebDriver driver;
        public SelectedMenuResults(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='MenuLeft']/div[1]/div[8]/div[2]/div/div/div[3]/a/span")]
        private IWebElement result { get; set; }

        public void clickOnResultNr()
        {
            //Actions action = new Actions(driver);
            result.Click();
        }
    }
}
