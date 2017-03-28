using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverFrameworkUnitTests
{
    public class PropertiesCollection
    {
        //public enum PropertyType
        //{
        //    Id,
        //    Name,
        //    ClassName,
        //    LinkText,
        //}

        // interface through which  the use controls the browser in any method of my code
        public static IWebDriver driver { get; set; }
    }
}
