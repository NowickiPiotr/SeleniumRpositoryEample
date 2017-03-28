using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverFrameworkUnitTests.Bisnode.POM;
using static WebDriverFrameworkUnitTests.PropertiesCollection;

namespace WebDriverFrameworkUnitTests
{
    [TestFixture]
    public class BisnodeNavigationUnitTest
    {

        private BisnodeBasicNavigation bisnodeFactory()
        {
            return new BisnodeBasicNavigation();
        }
        private BisnodeBasicNavigation bisnode;

        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new ChromeDriver(@"C:\chromedriver_win32");
            PropertiesCollection.driver.Navigate().GoToUrl("http://www.bisnode.pl/");
            bisnode = bisnodeFactory();
        }


        [Test]
        public void SimpleNavigation_BackToPoland_PolishLanguage()
        {
            bisnode.EnterTextInSearchForm("s");
            bisnode.s_Name.SendKeys(Keys.Return);
            bisnode.GroupButtonClick();
            bisnode.SelectCountryByName("Dania");
            bisnode.SelectCountryByName("Polska");
            string result = bisnode.GetCountrFromDropDownList();
            Assert.AreEqual("Polska", result);
        }

        [TearDown]
        public void PostConditions()
        {
            //close() – it will close the browser where the control is.
            //quit() – it will close all the browsers opened by WebDriver.  
            PropertiesCollection.driver.Close();   
        }

    }
}
