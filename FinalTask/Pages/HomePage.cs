using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;


namespace FinalTask.Pages
{
    public class HomePage
    {
        IWebDriver driver;

        By trendingStylesLocator = By.Id("menu-item-5345");
        By purpleSoloLocator = By.LinkText("Purple Solo 2 Wireless");
        By backToHomePageLocator = By.CssSelector("li.menu-item-5445");
        By contactPageButtonLocator = By.LinkText("Contact");



        public HomePage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void clikTrendingStyles()
        {

            IWebElement trendingStyles = driver.FindElement(trendingStylesLocator);
            trendingStyles.Click();
        }

        public void FindPurpleSolo()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 1000)");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement purpleSolo = driver.FindElement(purpleSoloLocator);
            IWebElement purpleSolo1 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("Purple Solo 2 Wireless")));

            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click()", purpleSolo);
        }
        
        
        public void BackToHomePage()
        {
            IWebElement homePageButton = driver.FindElement(backToHomePageLocator);
            homePageButton.Click();
        }


        public void clickContactButton()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");

            IWebElement contactPageButton = driver.FindElement(contactPageButtonLocator);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click()", contactPageButton);

        }


    }

    
    
}
