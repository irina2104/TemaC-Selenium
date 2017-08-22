using NUnit.Framework;
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
    class AntivirusResultsPage
    {
        private IWebDriver driver;
        public AntivirusResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public string VerifyTitle()
        {
            return driver.Title;
        }

        [FindsBy(How=How.CssSelector, Using = ".productTitle span")]
        private IList<IWebElement> products { get; set; }

       String productName = "Kaspersky Anti-Virus 2017 1PC 1An+3luni";
        public void findProduct() {
            foreach (IWebElement i in products)
            {if (i.Text.Contains(productName)) { 
                   
                   i.Click();
                   break;
                }
            }
        }
        [FindsBy(How = How.CssSelector, Using = ".buttons form")]
        private IWebElement addButton { get; set; }

        public void addProductToChart()
        {
            addButton.Click();

        }

        [FindsBy(How = How.CssSelector, Using = ".breadCrumb>span>span>a>b")]
        private IList<IWebElement> pathElem { get; set; }
        List<string> list = new List<string>();
        public String checkPath()
        {
            foreach(IWebElement elem in pathElem)
            {
                list.Add(elem.Text);
            }
            string concat = String.Join("/", list.ToArray());
            return concat;
        }

    }
}
