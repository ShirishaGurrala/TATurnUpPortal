using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V131.Tethering;
using TATurnUpPortal.Pages;

internal class Program
{
    private static void Main(string[] args)
    {
        // Open Chrome Browser
        IWebDriver driver = new ChromeDriver();

        // Login page object initialization
        LoginPage loginPage = new LoginPage();
        loginPage.LoginActions(driver);

        // Home page object initialization
        HomePage homePage = new HomePage();
        homePage.NavigateToTMPage(driver);

        // TM page object initialization
        TMPage tMPage = new TMPage();
        tMPage.CreateTimeRecord(driver);

        // Edit record verification
        tMPage.EditTimeRecord(driver);
        tMPage.DeleteTimeRecord(driver);
    }
}
   
