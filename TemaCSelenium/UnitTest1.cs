using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TemaCSelenium.Pages;

namespace TemaCSelenium
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.cel.ro");

            HomePageCel page = new HomePageCel(driver);
           
            var logoText = page.VerifyLogo();
            Assert.IsTrue(logoText.Contains("CEL"));
            page.checkVisibility();
            page.clickCategoryNr(7);

            Thread.Sleep(5000);

            SelectedMenuResults result = new SelectedMenuResults(driver);
            result.clickOnResultNr();

            AntivirusResultsPage antivirus = new AntivirusResultsPage(driver);
            var path = antivirus.checkPath();
            Assert.AreEqual("CEL.ro/Software/Antivirus", path);

            var antivirusTitle = antivirus.VerifyTitle();
            Assert.IsTrue(antivirusTitle.Contains("Antivirus"));
          
            antivirus.findProduct();

            Thread.Sleep(5000);

            AntivirusPage popUp = new AntivirusPage(driver);
            popUp.closePopUp();
            var prodTitle = popUp.verifyProductTitle();
            Assert.IsTrue(prodTitle.Contains("Kaspersky Anti-Virus 2017 1PC 1An+3luni gratuite"));
            
            Thread.Sleep(5000);

            antivirus.addProductToChart();

            Thread.Sleep(5000);

            ChartDetails details = new ChartDetails(driver);
            details.seeDetails();
            var pageTitle = details.verifyPageTitle();
            Assert.IsTrue(pageTitle.Contains("Continut cos"));

            Thread.Sleep(5000);

            details.modifyQuantity("3");

            var newPrice = details.verifyPrice();
            Assert.AreEqual("300", newPrice);
        }
    }
}
