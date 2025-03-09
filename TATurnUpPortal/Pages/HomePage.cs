using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TATurnUpPortal.Utilities;

namespace TATurnUpPortal.Pages
{
    public class HomePage
    {
        public void NavigateToTMPage(IWebDriver driver) 
        {
            // Create a Time record



            // function crated only for button, pass parameter, driver, time, element(locator value), locator type
            // calling wait method directly without util, refer below 2 commented codelines
            // WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(2000));
            //webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(("/html/body/div[3]/div/div/ul/li[5]/a/span"))));

            // wait util class can call its methods directly because the methods declared are static, refer below
            //public static void WaitToBeClickable(IWebDriver driver, String locatorType, String locatorValue, int seconds)

            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/a/span", 2);

            // Navigate to Time and Material Page
            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
            administrationTab.Click();

            IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeAndMaterialOption.Click();

            


        }
    }
}
