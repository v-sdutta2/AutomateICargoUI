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
        string agentcode = "";
        string shippingdate = "";
        string productcode = "";
        string unknownshipper = "";
        string consignee = "";

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
            mbp.AWBBookingfromStock();
        }

        //[Then(@"User enters shipment details with Origin ""([^""]*)"", Destination ""([^""]*)"",Agent Code ""([^""]*)"", Shipping Date ""([^""]*)"", Product Code ""([^""]*)""")]
        //public void ThenUserEntersShipmentDetailsWithOriginDestinationAgentCodeShippingDateProductCode(string origin, string destination, string agentcode, string shippingdate, string productcode)
        //{
        //    this.origin = origin;
        //    this.destination = destination;
        //    this.agentcode = agentcode;
        //    this.shippingdate = shippingdate;
        //    this.productcode = productcode;
        //    mbp.UnknownAgentShipmentDetails(origin, destination, agentcode, shippingdate, productcode);
        //}
        [Then(@"User enters unknown shipment details with Origin ""([^""]*)"", Destination ""([^""]*)"", Product Code ""([^""]*)""")]
        public void ThenUserEntersShipmentDetailsWithOriginDestinationAgentCodeProductCode(string origin, string destination, string productcode)
        {
            this.origin = origin;
            this.destination = destination;                       
            this.productcode = productcode;
            mbp.UnknownAgentShipmentDetails(origin, destination,productcode);
        }


        [Then(@"User enters Unknown Shipper ""([^""]*)"" and Consignee ""([^""]*)"" details")]
        public void ThenUserEntersUnknownShipperAndConsigneeDetails(string shipper, string consignee)
        {
           this.unknownshipper = shipper;
            this.consignee = consignee;
            mbp.UnknownShipperConsigneeDetails(shipper, consignee);
        }

    }
}
