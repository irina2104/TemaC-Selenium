using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaCSelenium
{
    class ChartDetails
    {
        private IWebDriver driver;

        public ChartDetails(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.XPath, Using = ".//div[@id='mesaj_custom']/div[2]/a[@id='btngocart']")]
        private IWebElement detailsButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cantitate input[name='cart_quantity[]']")]
        private IWebElement quantity { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".pret_total_final")]
        private IWebElement newPrice { get; set; }

        public void seeDetails()
        {
            detailsButton.Click();
        }
        public string verifyPageTitle()
        {
            return driver.Title;
        }
        public void modifyQuantity(string nr)
        {
            quantity.Click();
            quantity.SendKeys(Keys.Control + "a");
            quantity.SendKeys(Keys.Delete);
            quantity.SendKeys(nr);
            quantity.Submit();
        }
        public String verifyPrice()
        {
            return newPrice.Text;
        }
    }
}
