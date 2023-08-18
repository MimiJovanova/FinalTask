using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace FinalTask.Pages
{
    public class ContactPage
    {
        IWebDriver driver;


        By firstNameFieldLocator = By.Id("wpforms-5460-field_0");
        By lastNameFiedLocator = By.Id("wpforms-5460-field_0-last");
        By emailFieldLocator = By.Id("wpforms-5460-field_1");
        By messageFieldLocator = By.Id("wpforms-5460-field_2");
        By sendMessageButtonLocator = By.XPath("//*[@id=\"wpforms-submit-5460\"]");
        By emailMessageLocator = By.XPath("//*[@id=\"wpforms-confirmation-5460\"]/p");
        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        public void enterFirstName()
        {
            IWebElement firstNameField = driver.FindElement(firstNameFieldLocator);
            firstNameField.Clear();
            firstNameField.SendKeys("Mimi");
        }
        public void enterLastName()
        {
            IWebElement lastNameFied = driver.FindElement(lastNameFiedLocator);
            lastNameFied.Clear();
            lastNameFied.SendKeys("Jovanova");
        }
        public void enterEmail()
        {
            IWebElement emailField = driver.FindElement(emailFieldLocator);
            emailField.Clear();
            Random randomGenerator = new Random();
            int randomInt = (int)randomGenerator.NextInt64(1000);
            emailField.SendKeys("username" + randomInt + "@gmail.com");

        }
        public void enterMessage()
        {
            IWebElement messageField = driver.FindElement(messageFieldLocator);
            messageField.Clear();
            messageField.SendKeys("Iam a QA student at Brainster");
        }
        public void clickSendMessageButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            IWebElement buttonMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"wpforms-submit-5460\"]")));

            IWebElement sendmessage = driver.FindElement(sendMessageButtonLocator);

            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click()", sendmessage);
        }


        public void VerifyThatMessageWasSent()
        {
            IWebElement emailmessage = driver.FindElement(emailMessageLocator);
            string message = emailmessage.GetAttribute("value");

            Assert.That(driver.FindElement(emailMessageLocator).Displayed);
            Console.WriteLine("The message was successfully sent");
        }
    }
}





    

