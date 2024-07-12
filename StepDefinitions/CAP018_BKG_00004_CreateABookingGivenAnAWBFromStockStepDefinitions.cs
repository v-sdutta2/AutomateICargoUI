using iCargoUIAutomation.pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace iCargoUIAutomation.StepDefinitions
{
    [Binding]
    public class CAP018_BKG_00004_CreateABookingGivenAnAWBFromStockStepDefinitions : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;
        private homePage hp;
        private MaintainBookingPage mbp;
        string origin = "";
        string destination = "";
        string agentCode = "";
        string shippingDate = "";
        string productCode = "";
        string unknownShipper = "";
        string consignee = "";
        string awb = "";

        public CAP018_BKG_00004_CreateABookingGivenAnAWBFromStockStepDefinitions(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            pageObjectManager = new PageObjectManager(driver);
            hp = pageObjectManager.GetHomePage();
            mbp = pageObjectManager.GetMaintainBookingPage();
        }
        [Then(@"a banner appears for the awb does not exist")]
        public void ThenABannerAppearsForTheAwbDoesNotExist()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                mbp.AWBBookingfromStock();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
            
        }
        
        [Then(@"User enters unknown shipment details with Origin ""([^""]*)"", Destination ""([^""]*)"", Product Code ""([^""]*)""")]
        public void ThenUserEntersShipmentDetailsWithOriginDestinationAgentCodeProductCode(string origin, string destination, string productCode)
        {
            this.origin = origin;
            this.destination = destination;                       
            this.productCode = productCode;
            if (ScenarioContext.Current["Execute"] == "true")
            mbp.UnknownAgentShipmentDetails(origin, destination,productCode);
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [Then(@"User enters the AWB number as ""([^""]*)""")]
        public void ThenUserEntersTheAWBNumberAs(string awb)     
        {
            this.awb = awb;
            if (ScenarioContext.Current["Execute"] == "true")
            mbp.EnterAWBNumberFromStock(awb);
            else
            {
                ScenarioContext.Current.Pending();
            }
        }


        [Then(@"User enters Unknown Shipper ""([^""]*)"" and Consignee ""([^""]*)"" details")]
        public void ThenUserEntersUnknownShipperAndConsigneeDetails(string shipper, string consignee)
        {
           this.unknownShipper = shipper;
            this.consignee = consignee;
            if (ScenarioContext.Current["Execute"] == "true")
            mbp.UnknownShipperConsigneeDetails(shipper, consignee);
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

    }
}
