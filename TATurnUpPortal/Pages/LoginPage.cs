using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TATurnUpPortal.Pages
{
    public class LoginPage
    {
        public void LoginActions(IWebDriver driver)
        {
            // Launch Turnup Portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
            driver.Manage().Window.Maximize();

            // Identify username textbox and enter valid username
            IWebElement userNameTextbox = driver.FindElement(By.Id("UserName"));
            userNameTextbox.SendKeys("hari");

            // Identify password textbox and enter valid password;
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            // Identify login button and click on it
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginButton.Click();
            Thread.Sleep(2000);

        }
    }
}
