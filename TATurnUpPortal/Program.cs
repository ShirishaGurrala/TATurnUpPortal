using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V131.Tethering;

internal class Program
{
    private static void Main(string[] args)
    {
        // Open Chrome Browser
        IWebDriver driver = new ChromeDriver();
        
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

        // check if user has logged in successfully
        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        if (helloHari.Text == "Hello hari!")
        {
            Console.WriteLine("User has logged in successfully. Test Passed!");
        }
        else
        {
            Console.WriteLine("User has not logged in. Test failed!");
        }

        // Create a Time record

        // Navigate to Time and Material Page
        IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
        administrationTab.Click();

        IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        timeAndMaterialOption.Click();

        // Click on Create New Button
        IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createNewButton.Click();

        // Select Time from dropdown
        IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        typeCodeDropdown.Click();

        IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        timeOption.Click();

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

                                                                        ////*[@id="tmsGrid"]/div[3]/table/tbody/tr[4]
                                                                        /// //*[@id="tmsGrid"]/div[3]/table/tbody/tr[4]/td[3]
                                                                        /// //*[@id="tmsGrid"]/div[3]/table/tbody/tr[4]/td[5]/a[1]
        IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (newCode.Text == "TA Programme")
        {
            Console.WriteLine("Time record created successfuly!");
        }
        else
        {
            Console.WriteLine("New time record has not been created!");
        }
        Thread.Sleep(3000);

        //$$$$$$$$$$$$$$$$ Edit flow $$$$$$$$$$$$$$$
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

        //$$$$$$$$$ Delete entry $$$$$$$$
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
   
