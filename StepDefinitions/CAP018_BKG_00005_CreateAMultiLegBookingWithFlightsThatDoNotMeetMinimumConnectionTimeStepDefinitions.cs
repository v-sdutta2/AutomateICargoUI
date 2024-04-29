using iCargoUIAutomation.pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace iCargoUIAutomation.StepDefinitions
{
    [Binding]
    public class CAP018_BKG_00005_CreateAMultiLegBookingWithFlightsThatDoNotMeetMinimumConnectionTimeStepDefinitions :BasePage
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

        //[Then(@"User clicks on select flight to search for the given Flight No ""([^""]*)""")]
        //public void ThenUserClicksOnSelectFlightToSearchForTheGivenFlightNo(string flightnbr)
        //{
        //    this.flightnbr = flightnbr;
        //    mbp.MultilegFlightSearch(flightnbr);
        //}


        //[Then(@"User gets RES bubble '([^']*)' a warning message as '([^']*)'")]
        //public void ThenUserGetsRESBubbleAWarningMessageAs(string rescolr, string reswarning)
        //{
        //    mbp.VerifyMinimumConnectionTimeWarning(rescolr, reswarning);
        //}

        [Then(@"User searches for the multileg flight to verify RES bubble '([^']*)' a warning message as '([^']*)' and product code as ""([^""]*)""")]
        public void ThenUserSearchesForTheMultilegFlightToVerifyRESBubbleAWarningMessageAs(string rescolr, string reswarning, string productcode)
        {
            this.productcode = productcode;
           mbp.selectMultilegflight(rescolr, reswarning, productcode);
        }                

    }
}
