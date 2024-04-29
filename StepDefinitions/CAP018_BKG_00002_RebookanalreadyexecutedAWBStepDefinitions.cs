using iCargoUIAutomation.pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace iCargoUIAutomation.StepDefinitions
{
    [Binding]
    public class CAP018_BKG_00002_RebookanalreadyexecutedAWBStepDefinitions
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;
        private homePage hp;
        private MaintainBookingPage mbp;
        string awb = "";
        string flightOrigin = "";
        string flightDestination = "";
        string flightNumber = "";
        string flightDate = "";
        string flightPieces = "";
        string flightWeight = "";

        public CAP018_BKG_00002_RebookanalreadyexecutedAWBStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            pageObjectManager = new PageObjectManager(driver);
            hp = pageObjectManager.GetHomePage();
            mbp = pageObjectManager.GetMaintainBookingPage();
        }
        [Then(@"User enters the AWB number as ""([^""]*)""")]
        public void ThenUserEntersTheAWBNumberAs(string awb)
        {
            this.awb = awb;
            mbp.EnterAWBNumber(awb); 
        }



        [Then(@"User deletes the flight details and adds new flight details")]
        public void ThenUserDeletesTheFlightDetailsAndAddsNewFlightDetails()
        {
            mbp.DeleteAddFlights();
        }

        //[Then(@"User enters new Carrier details with Origin ""([^""]*)"", Destination ""([^""]*)"", Flight No ""([^""]*)"", Flight Date ""([^""]*)"", Pieces ""([^""]*)"", Weight ""([^""]*)""")]
        //public void ThenUserEntersNewCarrierDetailsWithOriginDestinationFlightNoFlightDatePiecesWeight(string flightOrigin, string flightDestination, string flightNumber, string flightDate, string flightPieces, string flightWeight)
        //{
        //    this.flightOrigin = flightOrigin;
        //    this.flightDestination = flightDestination;
        //    this.flightNumber = flightNumber;
        //    this.flightDate = flightDate;
        //    this.flightPieces = flightPieces;
        //    this.flightWeight = flightWeight;
        //    mbp.addNewFlightDetails(flightOrigin,flightDestination, flightNumber, flightDate, flightPieces, flightWeight);
        //}

        [Then(@"User selects new carrier details")]
        public void ThenUserSelectsNewCarrierDetails()
        {
            mbp.addNewFlightDetails();
        }


        [Then(@"User clicks on Save button to save new flight details")]
        public void ThenUserClicksOnSaveButtonToSaveNewFlightDetails()
        {
            mbp.clickOnSaveButtonToSaveNewFlightDetails();
        }



        [Then(@"User captures the irregularity details")]
        public void ThenUserCapturesTheIrregularityDetails()
        {
            mbp.CaptureIrregularity();
        }


    }
}
