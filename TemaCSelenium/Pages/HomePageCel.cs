using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace TemaCSelenium.Pages
{
    class HomePageCel
    {
        private IWebDriver driver;
          
        [FindsBy(How = How.CssSelector, Using = "#logo_head")]
        public IWebElement logo { get; set; }

        public HomePageCel(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string VerifyLogo()
        {
            return driver.Title;
        }

        public bool checkVisibility()
        {
           return logo.Displayed;
        }

        [FindsBy(How = How.ClassName, Using ="parent_categ")]
        private IList<IWebElement> categories { get; set; }

        public void clickCategoryNr(int index)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(categories[index]).Perform();
        }
    }
}
