using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UnitTestProject1
{
    [Binding]
    public class AutomationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private FeatureContext _featureContext;
        //private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(AutomationSteps));
        
        public IWebDriver driver;

        public AutomationSteps(ScenarioContext scenarioContext, FeatureContext featureContext)
        {            
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        public void WaitUntilDocumentIsReady()
        {
            //this IWebDriver driver
            //            int timeoutInSeconds = int.Parse(getConfigValue("pagetimeout"));
            int timeoutInSeconds = 10;
            {
                var javaScriptExecutor = driver as IJavaScriptExecutor;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                try
                {
                    ThreadSleepWait();
                    wait.Until(wd => javaScriptExecutor.ExecuteScript("return document.readyState").ToString() == "complete");
                }
                catch (Exception e)
                {
                    Console.WriteLine("The exception found: "+e.Message);
                }
            }
        }

        public void ThreadSleepWait()
        {
            Thread.Sleep(1000);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //Log.Info($"Starting scenario: {_scenarioContext.ScenarioInfo.Title}");            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //Log.Info($"Starting scenario: {_scenarioContext.ScenarioInfo.Title}");
            //_browserHelper.GoToPage("connectionStatus");
            //driver.Quit();
            driver?.Dispose();
        }

        [Given(@"I am on the site (.*)")]
        public void GivenIAmOnThe(string url)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [Given(@"I login with my credentials")]
        public void GivenILoginWithMyCredentials()
        {
            //WaitUntilDocumentIsReady();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Sign in")).Click();
            //WaitUntilDocumentIsReady();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("email")).SendKeys("pss.qaeng@gmail.com");
            driver.FindElement(By.Id("passwd")).SendKeys("Lmchrist7");
            driver.FindElement(By.Id("SubmitLogin")).Click();
        }

        [When(@"I click on the link T-Shirts")]
        public void WhenIClickOnTheLinkT_Shirts()
        {
            //WaitUntilDocumentIsReady();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@id='block_top_menu']/ul/li/a[@title='T-shirts']")).Click();            
        }

        [When(@"I hover over the first item and click on (.*) and (.*)")]
        public void WhenIHoverOverTheFirstItemAndClickOn(string str1, string btnString)
        {
            //WaitUntilDocumentIsReady();
            Thread.Sleep(2000);
            //IWebElement elem = driver.FindElement(By.XPath("//div[@class='product-container']/div[1]/div/a[1]/img"));
            //WaitUntilDocumentIsReady();
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", elem);
            Actions act = new Actions(driver);
            //act.MoveToElement(elem);
            driver.FindElement(By.XPath("//h1/span[@class='heading-counter']")).Click();
            act.SendKeys(Keys.PageDown);
            Thread.Sleep(2000);
            IWebElement elem = driver.FindElement(By.XPath("//div[@class='product-container']/div[1]/div/a[1]/img"));
            elem.Click();
            //WaitUntilDocumentIsReady();
            Thread.Sleep(2000);
            //act.MoveToElement(elem);
            //driver.FindElement(By.XPath("//span[text()='Add to cart']/parent::a")).Click();
            driver.FindElement(By.XPath("//span[text()='Add to cart']/parent::button")).Click();
            //WaitUntilDocumentIsReady();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath($"//div[@id='layer_cart']//a[@title='{btnString}']")).Click();
        }

        public void proceedToCheckout(string btnString)
        {
            //WaitUntilDocumentIsReady();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath($"//div[@id='center_column']//a[@title='{btnString}']")).Click();
        }

        [When(@"I click on (.*) in the Summary phase")]
        public void WhenIClickOnInTheSummaryPhase(string btnString)
        {
            //WaitUntilDocumentIsReady();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath($"//div[@id='center_column']//a[@title='{btnString}']")).Click();
            //div[@id='center_column']//a[@title='Proceed to checkout']
        }


        [When(@"I click on (.*) in the sign-in phase")]
        public void WhenIClickOnInTheSign_InPhase(string btnString)
        {
            //WaitUntilDocumentIsReady();
            Thread.Sleep(3000);
            proceedToCheckout(btnString);
        }

        [When(@"I click on (.*) in the address phase")]
        public void WhenIClickOnInTheAddressPhase(string btnString)
        {
            //WaitUntilDocumentIsReady();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath($"//button[@name='processAddress']")).Click();
        }

        [When(@"I select checkbox to agree terms in shipping phase")]
        public void WhenISelectCheckboxToAgreeTermsInShippingPhase()
        {
            //WaitUntilDocumentIsReady();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("cgv")).Click();
        }

        [When(@"I click on (.*) in the shipping phase")]
        public void WhenIClickOnInTheShippingPhase(string btnString)
        {
            //WaitUntilDocumentIsReady();
            driver.FindElement(By.XPath($"//button[@name='processCarrier']")).Click();
        }

        [When(@"I click on (.*) in the payment phase")]
        public void WhenIClickOnInThePaymentPhase(string btnString)
        {
            //WaitUntilDocumentIsReady();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath($"//div[@id='center_column']//a[@title='{btnString}']")).Click();
        }

        [When(@"I click on (.*) button")]
        public void WhenIClickOn(string btnString)
        {
            //WaitUntilDocumentIsReady();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath($"//p[@id='cart_navigation']/button")).Click();            
        }

        [Then(@"I click on the my username on the top right hand side of the site")]
        public void ThenIClickOnTheMyUsernameOnTheTopRightHandSideOfTheSite()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath($"//a[@title='View my customer account']")).Click();
        }

        [Then(@"I click on Order history and details and click on details link in next page")]
        public void ThenIClickOnOrderHistoryAndDetailsAndClickOnDetailsLinkInNextPage()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath($"//a[@title='View my customer account']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath($"//a[@title='Orders']")).Click();

        }

        [Then(@"I see that the order for the product is referenced on the page")]
        public void ThenISeeThatTheOrderForTheProductIsReferencedOnThePage()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath($"//tbody/tr[1]/td[7]/a[1]")).Click();
        }

        [When(@"I click on (.*) link")]
        public void WhenIClickOnTheLink(string p0)
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath($"//a[@title='Information']")).Click();            
        }

        [When(@"I enter the updated FirstName")]
        public void WhenIEnterTheUpdatedFirstName()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.Id($"firstname")).Clear();
            driver.FindElement(By.Id($"firstname")).SendKeys("Updated FirstName");
        }

        [When(@"I enter the user password")]
        public void WhenIEnterTheUserPassword()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.Id("old_passwd")).SendKeys("Lmchrist7");
        }

        [When(@"I click on the Save button")]
        public void WhenIClickOnTheSaveButton()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.Name("submitIdentity")).Click();
        }

        [Then(@"I see the message that the first name has been updated")]
        public void ThenISeeTheMessageThatTheFirstNameHasBeenUpdated()
        {
            String text = driver.FindElement(By.XPath("//div[@id='center_column']/div/p")).Text;
            Assert.IsTrue(text.Contains("successfully updated"));
        }

    }
}