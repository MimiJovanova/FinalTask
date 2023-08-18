using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace FinalTask.Pages
{
    public class Wishlist
    {
        IWebDriver driver;


        By wishlistButtonLocator = By.LinkText("Wishlist");
        By wishListPageLocator = By.XPath("//*[@id=\"masthead\"]/div[1]/div[1]/div[2]/div[2]");
        By ProductNameLocator = By.CssSelector("tbody.wishlist-items-wrapper");


        public Wishlist(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void addProductToWishlist()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            IWebElement wishList = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("Wishlist")));
            IWebElement wishlist = driver.FindElement(wishlistButtonLocator);
            wishlist.Click();
        }
        public void navigateToWishlistPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            IWebElement wishListp = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"masthead\"]/div[1]/div[1]/div[2]/div[2]")));
            IWebElement wishListPage = driver.FindElement(wishListPageLocator);
            wishListPage.Click();
        }

        public void VerifyProductIsInTheWishlist()
        {
            IWebElement productName = driver.FindElement(ProductNameLocator);

            Assert.IsNotNull(productName);
            Console.WriteLine("The product is successfully added to the wishlist");
        }
    }

}



