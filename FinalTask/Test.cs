using FinalTask.Pages;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace FinalTask
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;
        HomePage homePageObject;
        Wishlist wishlistObject;
        ContactPage contactPageObject;



        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://electro.madrasthemes.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            homePageObject = new HomePage(driver);
            wishlistObject = new Wishlist(driver);
            contactPageObject = new ContactPage(driver);    

        }

        [Test]
        public void ClickTrendingStylesAndSelectTheProduct()
        {
            homePageObject.clikTrendingStyles();
            homePageObject.FindPurpleSolo();
                 
        }

        [Test]
        public void AddProductAndNavigateToWishlistPage()
        {
            homePageObject.clikTrendingStyles();
            homePageObject.FindPurpleSolo();
            wishlistObject.addProductToWishlist();
            wishlistObject.navigateToWishlistPage();
        }

        [Test]
        public void VerifyProductIsSuccessfullyAdded()
        {
            homePageObject.clikTrendingStyles();
            homePageObject.FindPurpleSolo();
            wishlistObject.addProductToWishlist();
            wishlistObject.navigateToWishlistPage();
            wishlistObject.VerifyProductIsInTheWishlist();

        }

        [Test]
        public void BackToHomePageAndNavigateToContactPage()
        {
            homePageObject.clikTrendingStyles();
            homePageObject.FindPurpleSolo();
            wishlistObject.addProductToWishlist();
            wishlistObject.navigateToWishlistPage();
            wishlistObject.VerifyProductIsInTheWishlist();
            homePageObject.BackToHomePage();
            homePageObject.clickContactButton();

        }

        [Test]
        public void FillInMessageDetailsAndClickSendButton()
        {
            homePageObject.clikTrendingStyles();
            homePageObject.FindPurpleSolo();
            wishlistObject.addProductToWishlist();
            wishlistObject.navigateToWishlistPage();
            wishlistObject.VerifyProductIsInTheWishlist();
            homePageObject.BackToHomePage();
            homePageObject.clickContactButton();
            contactPageObject.enterFirstName();
            contactPageObject.enterLastName();  
            contactPageObject.enterEmail();
            contactPageObject.enterMessage();
            contactPageObject.clickSendMessageButton();

        }

        [Test]
        public void VerifyThatMessageWasSuccessfullySent()
        {
            homePageObject.clikTrendingStyles();
            homePageObject.FindPurpleSolo();
            wishlistObject.addProductToWishlist();
            wishlistObject.navigateToWishlistPage();
            wishlistObject.VerifyProductIsInTheWishlist();
            homePageObject.BackToHomePage();
            homePageObject.clickContactButton();
            contactPageObject.enterFirstName();
            contactPageObject.enterLastName();
            contactPageObject.enterEmail();
            contactPageObject.enterMessage();
            contactPageObject.clickSendMessageButton();
            contactPageObject.VerifyThatMessageWasSent();

        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}