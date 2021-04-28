using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace UnitTestProject1
{
    [Binding]
    public class CalculatorSteps
    {
        IWebDriver driver;
        //[Given(@"I have entered (.*) into the calculator")]
        //public void GivenIHaveEnteredIntoTheCalculator(int p0)
        //{
        //    //ScenarioContext.Current.Pending();
        //}
        
        //[When(@"I press add")]
        //public void WhenIPressAdd()
        //{
        //    //ScenarioContext.Current.Pending();
        //}
        
        //[Then(@"the result should be (.*) on the screen")]
        //public void ThenTheResultShouldBeOnTheScreen(int p0)
        //{
        //    //ScenarioContext.Current.Pending();
        //}

        [Given(@"I have ORBITA login page")]
        public void GivenIHaveORBITALoginPage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev");
            //driver.Navigate().GoToUrl("https://staging.orbita.bombardier.com/fm.1.6.Portal.Web/Views/");
        }

        [When(@"I enter the credentials and click ok button")]
        public void WhenIEnterTheCredentialsAndClickOkButton()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"I am on the default home page of ORBITA")]
        public void ThenIAmOnTheDefaultHomePageOfORBITA()
        {
            //ScenarioContext.Current.Pending();
        }


    }
}
