using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverFrameworkUnitTests
{
   public class BisnodeBasicNavigation
    {
        //Site under test
        //http://www.bisnode.pl/

        public BisnodeBasicNavigation()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

       [FindsBy(How = How.ClassName, Using = "group-button")]
        public IWebElement Group_ButtonClassName { get; set; } 

        [FindsBy(How = How.Name, Using = "s")]
        public IWebElement s_Name { get; set; }

        [FindsBy(How = How.Name, Using = "country")]
        public IWebElement CountryDropDown { get; set; } 

        public void EnterTextInSearchForm(string value)
        {
            s_Name.EnterText(value);          
        }

        public void GroupButtonClick()
        {
            Group_ButtonClassName.Click();
        }

        public void SelectCountryByName(string value)
        {
            CountryDropDown.SelectDropDownElementByText(value);      
        }

        public string GetCountryText()
        {
            return CountryDropDown.GetText();
        }
        public string GetCountrFromDropDownList()
        {
            return CountryDropDown.GetSingleOrDefaultTextFromDDl();
        }

        public BisnodeBasicNavigation SiteNavigation()
        {
            Group_ButtonClassName.Click();
            return new BisnodeBasicNavigation();
        }
    }
}

