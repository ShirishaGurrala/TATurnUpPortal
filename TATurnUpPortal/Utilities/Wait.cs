using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace TATurnUpPortal.Utilities
{
    public class Wait
    {
        public static void WaitToBeClickable(IWebDriver driver, String locatorType, String locatorValue, int seconds)
        {
            // function crated only for button, pass parameter, driver, time, element(locator value), locator type
            WebDriverWait webDriverWait = new WebDriverWait(driver, new TimeSpan(0,0,seconds));
            if (locatorType == "XPath")
            {
                webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath((locatorValue))));
            }
            if (locatorType == "Id")
            {
                webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id((locatorValue))));
            }
        }
        public static void WaitToBeVisible(IWebDriver driver, String locatorType, String locatorValue, int seconds)
        {
            // function crated only for button, pass parameter, driver, time, element(locator value), locator type
            WebDriverWait webDriverWait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            if (locatorType == "XPath")
            {
                webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath((locatorValue))));
            }
            if (locatorType == "Id")
            {
                webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id((locatorValue))));
            }
        }
    }
}
