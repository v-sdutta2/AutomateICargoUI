using iCargoUIAutomation.pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace iCargoUIAutomation.StepDefinitions
{
    [Binding]
    public class GreenpointLoginAWBValidationStepDefinitions:BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;
        private GreenpointPage gp;
        string fltnbr;
        string awb;
        string pieces;
        string weight;

        public string gpAppUrl = "https://smartsuite.qa.insideaag.com/shell/login.html";

        public GreenpointLoginAWBValidationStepDefinitions(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            pageObjectManager = new PageObjectManager(driver);
            gp = pageObjectManager.GetGreenpointPage();
        }

        [Given(@"User launches to Greenpoint Application")]
        public void GivenUserLoginsToGreenpointApplication()
        {
            DeleteAllCookies();
            Open(gpAppUrl);
        }

        [When(@"User enter valid username and password")]
        public void WhenUserEnterValidUsernameAndPassword()
        {
            driver.FindElement(By.XPath("//*[@test-locator='login']/div/div/input")).Click();
            driver.FindElement(By.XPath("//*[@test-locator='login']/div/div/input")).SendKeys("asha");
            driver.FindElement(By.XPath("//*[@test-locator='password']/div/div/input")).SendKeys("1234");
            driver.FindElement(By.XPath("//*[@test-locator='continue']/div/span")).Click();
        }

        [Then(@"logs into the Greenpoint Application")]
        public void ThenLogsIntoGpApplication()
        {
            gp.ClickOnAgentSelectEnterBtn();
            gp.ChooseAssignment();
        }       

        [Then(@"User searches for flight ""([^""]*)"" and clicks on the cargo gate")]
        public void ThenUserSearchesForFlightAndClicksOnTheCargoGate(string fltnbr)
        {
            this.fltnbr = fltnbr;
            gp.SearchFlight(fltnbr);
        }

        [Then(@"validates the manifested ""([^""]*)"" number, ""([^""]*)"" and ""([^""]*)""")]
        public void ThenValidatesTheManifestedNumberAnd(string awb, string pieces, string weight)
        {
            this.awb = awb;
            this.pieces = pieces;
            this.weight = weight;
            gp.CargoAwbValidation(awb,pieces,weight);
        }


        [Then(@"User logs out of the Greenpoint application")]
        public void ThenUserLogsOutOfTheGreenpointApplication()
        {
           gp.GreenpointLogOut();
        }
    }
}
