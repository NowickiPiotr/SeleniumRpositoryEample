using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebDriverFrameworkUnitTests.PropertiesCollection;

namespace WebDriverFrameworkUnitTests
{
    public static class SeleniumCustomMethods
    {
        public  static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);   
        }

        public static void SelectDropDownElementByText(this IWebElement element,
             string value)
        {
            new SelectElement(element).SelectByText(value);
        }

        public static string GetText(this IWebElement element)
        {
            return element.GetAttribute("value");

        }

        public static string GetSingleOrDefaultTextFromDDl(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }

        public static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); 
            return path;
        }
    }
}
