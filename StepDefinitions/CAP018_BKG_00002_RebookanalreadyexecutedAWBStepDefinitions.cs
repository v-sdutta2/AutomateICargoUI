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



        [Then(@"User deletes the flight details and adds new flight details")]
        public void ThenUserDeletesTheFlightDetailsAndAddsNewFlightDetails()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                mbp.DeleteAddFlights();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
            
        }        

        [Then(@"User selects new carrier details")]
        public void ThenUserSelectsNewCarrierDetails()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                mbp.AddNewFlightDetails();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
            
        }


        [Then(@"User clicks on Save button to save new flight details")]
        public void ThenUserClicksOnSaveButtonToSaveNewFlightDetails()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                mbp.clickOnSaveButtonToSaveNewFlightDetails();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }            
        }



        [Then(@"User captures the irregularity details")]
        public void ThenUserCapturesTheIrregularityDetails()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                mbp.CaptureIrregularity();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }            
        }


    }
}
