using iCargoUIAutomation.pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace iCargoUIAutomation.StepDefinitions
{
    [Binding]
    public class CAP018_BKG_00003_CreateABookingForAnUnknownShipperOnAPaxFlightStepDefinitions
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;
        private homePage hp;
        private MaintainBookingPage mbp;
        string unkShipper = "";
        string unkConsignee = "";

        public CAP018_BKG_00003_CreateABookingForAnUnknownShipperOnAPaxFlightStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            pageObjectManager = new PageObjectManager(driver);
            hp = pageObjectManager.GetHomePage();
            mbp = pageObjectManager.GetMaintainBookingPage();
        }
        [Then(@"User enters Unknown Shipper ""([^""]*)"" and Consignee ""([^""]*)"" with all details")]
        public void ThenUserEntersUnknownShipperAndConsigneeWithAllDetails(string unkShipper, string unkConsignee)
        {
            this.unkShipper = unkShipper;
            this.unkConsignee = unkConsignee;
            mbp.UnknownShipperConsigneeALLDetails(unkShipper, unkConsignee);
        }
    }
}
