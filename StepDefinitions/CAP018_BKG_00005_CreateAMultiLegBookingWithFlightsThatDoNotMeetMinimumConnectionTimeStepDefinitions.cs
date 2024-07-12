using iCargoUIAutomation.pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace iCargoUIAutomation.StepDefinitions
{
    [Binding]
    public class CAP018_BKG_00005_CreateAMultiLegBookingWithFlightsThatDoNotMeetMinimumConnectionTimeStepDefinitions : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;
        private homePage hp;
        private MaintainBookingPage mbp;
        string flightnbr = "";
        string productcode = "";

        public CAP018_BKG_00005_CreateAMultiLegBookingWithFlightsThatDoNotMeetMinimumConnectionTimeStepDefinitions(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            pageObjectManager = new PageObjectManager(driver);
            hp = pageObjectManager.GetHomePage();
            mbp = pageObjectManager.GetMaintainBookingPage();
        }

        [Then(@"User searches for the multileg flight to verify RES bubble '([^']*)' a warning message as '([^']*)' and product code as ""([^""]*)""")]
        public void ThenUserSearchesForTheMultilegFlightToVerifyRESBubbleAWarningMessageAs(string rescolr, string reswarning, string productcode)
        {
            this.productcode = productcode;
            if (ScenarioContext.Current["Execute"] == "true")
            {
                mbp.SelectMultilegflight(rescolr, reswarning, productcode);
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

    }
}
