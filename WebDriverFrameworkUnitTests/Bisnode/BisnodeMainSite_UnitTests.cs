using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebDriverFrameworkUnitTests.Bisnode.POM
{
    [TestFixture]
    public class BisnodeMainSite_UnitTests
    {
        private BisnodeMainSite bisnodeMainSiteFactory()
        {
            return new BisnodeMainSite();
        }

        private BisnodeMainSite bisnode;
        private Actions actions;
        private WebDriverWait wait;

        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new ChromeDriver(@"C:\chromedriver_win32");
            PropertiesCollection.driver.Navigate().GoToUrl("http://www.bisnode.pl/");
            actions = new Actions(PropertiesCollection.driver);
            wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(5));

            bisnode = bisnodeMainSiteFactory();

        }


        //Navigate to http://www.bisnode.pl/
        //Go to foot
        //Click on <Zapisz sie>
        [Test]
        public void NewsletterForm_EmptyForm_ShouldNotSwitchToAnotherWindow_False()
        {
          
            bisnode.S_email_Name.Click();
            bisnode.S_email_Name.SendKeys(Keys.Return);
            PropertiesCollection.driver.SwitchTo().Window(PropertiesCollection.driver.WindowHandles.Last());
            Assert.AreEqual( "Zarządzanie ryzykiem biznesowym | Bisnode Polska", PropertiesCollection.driver.Title);
        }

        
        //Is form wrong?
        [Test]
        public void NewsletterForm_EmptyForm_True()
        {
            bisnode.Save_button_CSSSelector.Click();
            PropertiesCollection.driver.SwitchTo().Window(PropertiesCollection.driver.WindowHandles.Last());
            string message = PropertiesCollection.driver.FindElement(By.TagName("p")).Text;            
            Assert.True(message.Contains("Niepoprawne"));
        }

        //Is form correct?
        [Test]
        public void NewsletterForm_NewEmailInDB_True()
        {
            string RandomEmail = SeleniumCustomMethods.GetRandomString() +"@test.com";

            bisnode.s_email_EmailForm.SendKeys(RandomEmail);
            bisnode.s_property1_FirstName.SendKeys("test");
            bisnode.s_property2_LastNanme.SendKeys("test");
            bisnode.s_property4_Position.SendKeys("test");

            bisnode.SaveButton_XPath.Click();
            PropertiesCollection.driver.SwitchTo().Window(PropertiesCollection.driver.WindowHandles.Last());
            string message = PropertiesCollection.driver.FindElement(By.TagName("p")).Text;
            Assert.True(message.Contains("został dopisany do naszej bazy."));
        }

        //What if email is in DB?
        [Test]
        public void NewsletterForm_CheckValidate_EmailIsInDB()
        {
            bisnode.s_email_EmailForm.SendKeys("test@test.com");
            bisnode.s_property1_FirstName.SendKeys("test@test.com");
            bisnode.s_property2_LastNanme.SendKeys("test@test.com");
            bisnode.s_property4_Position.SendKeys("test@test.com");

            bisnode.SaveButton_XPath.Click();
            PropertiesCollection.driver.SwitchTo().Window(PropertiesCollection.driver.WindowHandles.Last());
            string message = PropertiesCollection.driver.FindElement(By.TagName("p")).Text;
            Assert.True(message.Contains("jest już w bazie"));
        }

        [Test]
        public void Navigation_sub_navigation_GoTo()
        {
            bisnode.Blog_LinkText.Click();
            PropertiesCollection.driver.Navigate().Back();
            bisnode.Rankings_LinkText.Click();
            PropertiesCollection.driver.Navigate().Back();

            bisnode.they_trusted_us_LinkText.Click();
            PropertiesCollection.driver.Navigate().Back();
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
