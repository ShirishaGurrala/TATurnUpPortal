using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TATurnUpPortal.Pages
{
    public class HomePage
    {
        public void NavigateToTMPage() 
        {
            // Create a Time record

            // Navigate to Time and Material Page
            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
            administrationTab.Click();

            IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeAndMaterialOption.Click();

        }
    }
}
