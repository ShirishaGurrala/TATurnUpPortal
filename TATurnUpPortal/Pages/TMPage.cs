using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TATurnUpPortal.Utilities;

namespace TATurnUpPortal.Pages
{
    public class TMPage
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            try
            {
                IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
                createNewButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Create New Button hasn't been found.");
            }
            

            // Select Time from dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            //Create webdriver object which takes driver and timespan as params
            //using above webdriver object created call until method
            //Inside until method use seleniumextras.waithelpers.expectedCon element vsible
            //Inside element visible use use id and give the element value
            WebDriverWait waitCodeTextBox = new WebDriverWait(driver, TimeSpan.FromMilliseconds(2000));
            waitCodeTextBox.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("Code")));

            // wait util class can call its methods directly because the methods declared are static, refer below
            //public static void WaitToBeVisible(IWebDriver driver, String locatorType, String locatorValue, int seconds)
            //Wait.WaitToBeVisible(driver, "Id", "Code", 2);


        // Type code into Code textbox
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("TA Programme");

            //Type description into Description textbox
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("This is a description");

            // Type price into Price textbox
            IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("12");

            // Click on Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(3000);

            // Check if Time record has been created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

         
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(newCode.Text == "TA Programme", "New time record has not been created!");
            //{
            //   Assert.Pass("Time record created successfuly!");
            //}
            //else
            //{
            //   Assert.Fail("New time record has not been created!");
            //}
            Thread.Sleep(3000);

        }
        public void EditTimeRecord(IWebDriver driver)
        {
            // Go to last page 
            IWebElement goToLastEditPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastEditPageButton.Click();

            // edit last item ( identify edit button the last item)
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();
            Thread.Sleep(3000);


            // Similar to create update values & save
            // Type code into Code textbox
            IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
            editCodeTextbox.Clear();
            editCodeTextbox.SendKeys("Editedtest12");

            //Type description into Description textbox
            IWebElement editDescriptionTextbox = driver.FindElement(By.Id("Description"));
            editDescriptionTextbox.Clear();
            editDescriptionTextbox.SendKeys("Editedtest12 description");

            // Click on Save button
            IWebElement saveEditButton = driver.FindElement(By.Id("SaveButton"));
            saveEditButton.Click();
            Thread.Sleep(3000);

            // navigate to last page
            IWebElement goToLastEditedPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastEditedPageButton.Click();

            // identify last element and verify two fields 

            IWebElement newEditCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if (newEditCode.Text == "Editedtest12")
            {
                Console.WriteLine("Time record code edited successfuly!");
            }
            else
            {
                Console.WriteLine("Time record has not been edited!");
            }

            IWebElement newEditDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            if (newEditDescription.Text == "Editedtest12 description")
            {
                Console.WriteLine("Time record description edited successfuly!");
            }
            else
            {
                Console.WriteLine("Time record has not been edited!");
            }
            Thread.Sleep(3000);
        }
        public void DeleteTimeRecord(IWebDriver driver)
        {
            //Identify fisrt element and retrieve code and description values
            //Print the values                                                    
            IWebElement retrieveCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[1]/td[1]"));
            Console.WriteLine($"The code value is {retrieveCode.Text}");
            Console.WriteLine("The code value is " + retrieveCode.Text);

            //Identify Delete button and click
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[1]/td[5]/a[2]"));
            deleteButton.Click();
        }
    }
}
