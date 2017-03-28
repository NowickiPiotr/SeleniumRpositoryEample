using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverFrameworkUnitTests.Bisnode.POM
{
    public class BisnodeMainSite
    {
        //Site under test
        //http://www.bisnode.pl/

        public BisnodeMainSite()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }


        [FindsBy(How = How.Name, Using = "s_email")]
        public IWebElement s_email_EmailForm { get; set; }

        [FindsBy(How = How.Name, Using = "s_property1")]
        public IWebElement s_property1_FirstName { get; set; }

        [FindsBy(How = How.Name, Using = "s_property2")]
        public IWebElement s_property2_LastNanme { get; set; }

        [FindsBy(How = How.Name, Using = "s_property4")]
        public IWebElement s_property4_Position { get; set; }

        [FindsBy(How = How.ClassName, Using = "slider-right")]
        public IWebElement Slider_right_ClassName { get; set; }

        [FindsBy(How = How.ClassName, Using = "slider-left")]
        public IWebElement Slider_left_ClassName { get; set; }

        [FindsBy(How = How.ClassName, Using = "blue")]
        public IWebElement Blue_ClassName { get; set; }

        [FindsBy(How = How.ClassName, Using = "green")]
        public IWebElement Green_ClassName { get; set; }

        [FindsBy(How = How.Name, Using = "s_email")]
        public IWebElement S_email_Name { get; set; }

        [FindsBy(How=How.CssSelector, Using = "input[class*='wpcf7-form-control'][value='Zapisz się']")]
        public IWebElement Save_button_CSSSelector { get; set; }

        [FindsBy(How = How.LinkText, Using = "Blog")]
        public IWebElement Blog_LinkText { get; set; }

        [FindsBy(How = How.LinkText, Using = "Rankingi")]
        public IWebElement Rankings_LinkText { get; set; }

        [FindsBy(How = How.LinkText, Using = "Zaufali nam")]
        public IWebElement they_trusted_us_LinkText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='wpcf7-form-control wpcf7-submit big-button']")]
        public IWebElement SaveButton_XPath { get; set; }
    }
}
