using iCargoUIAutomation.pages;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace iCargoUIAutomation.StepDefinitions
{
    [Binding]
    public class CAP018_BKG_00001_Create_a_booking_StepDefinitions : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;
        private homePage hp;
        private MaintainBookingPage mbp;
        string origin = "";
        string destination = "";
        //string shippingDate = "";
        string productCode = "";
        string commodity = "";
        string piece = "";
        string weight = "";
        string flightno = "";
        string flightDate = "";

        public CAP018_BKG_00001_Create_a_booking_StepDefinitions(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            pageObjectManager = new PageObjectManager(driver);
            hp = pageObjectManager.GetHomePage();
            mbp = pageObjectManager.GetMaintainBookingPage();
        }

        [When(@"User enters screen name as '([^']*)'")]
        public void WhenUserEntersScreenNameAs(string screenName)
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                hp.enterScreenName(screenName);
                mbp.SwitchToCAP018Frame();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }

        }

        [Then(@"User clicks on New/List button")]
        public void ThenUserClicksOnNewListButton()
        {
            if (ScenarioContext.Current["Execute"] == "true")
                mbp.ClickNewListButton();
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [Then(@"User enters shipment details with Origin ""([^""]*)"", Destination ""([^""]*)"", Product Code ""([^""]*)"" and Agent code")]
        public void ThenUserEntersShipmentDetailsWithOriginDestinationShippingDateProductCode(string origin, string destination, string productCode)
        {
            this.origin = origin;
            this.destination = destination;
            this.productCode = productCode;
            if (ScenarioContext.Current["Execute"] == "true")
                mbp.EnterShipmentDetails(origin, destination, productCode);
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [Then(@"User enters Shipper and Consignee details")]
        public void ThenUserEntersShipperAndConsigneeDetails()
        {
            if (ScenarioContext.Current["Execute"] == "true")
                mbp.EnterShipperConsigneeDetails();
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [Then(@"User enters commodity details with Commodity ""([^""]*)"", Pieces ""([^""]*)"", Weight ""([^""]*)""")]
        public void ThenUserEntersCommodityDetailsWithCommodityPiecesWeight(string commodity, string piece, string weight)
        {
            this.commodity = commodity;
            this.piece = piece;
            this.weight = weight;
            if (ScenarioContext.Current["Execute"] == "true")
                mbp.EnterCommodityDetails(commodity, piece, weight);
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        //[Then(@"User enters Carrier details with Origin ""([^""]*)"", Destination ""([^""]*)"", Flight No ""([^""]*)"", Flight Date ""([^""]*)"", Pieces ""([^""]*)"", Weight ""([^""]*)""")]
        //public void ThenUserEntersCarrierDetailsWithOriginDestinationFlightNoFlightDatePiecesWeight(string origin, string destination, string flightno, string flightdate, string piece, string weight)
        //{
        //    this.flightno = flightno;
        //    this.flightDate = flightdate;
        //    mbp.EnterCarrierDetails(origin, destination, flightno, flightdate, piece, weight);
        //}

        [Then(@"User clicks on Save button")]
        public void ThenUserClicksOnSaveButton()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                mbp.ClickSaveButton();
                mbp.CaptureAwbNumber();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        //[Then(@"User selects flight")]
        //public void ThenUserSelectsFlight()
        //{
        //    mbp.SelectFlight();
        //}
        [Then(@"User selects flight for ""([^""]*)""")]
        public void ThenUserSelectsFlightFor(string productCode)
        {
            if (ScenarioContext.Current["Execute"] == "true")
            mbp.SelectFlight(productCode);
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [Given(@"User wants to execute the example ""([^""]*)""")]
        [Obsolete]
        public void GivenUserWantsToExecuteTheExample(string execute)
        {
            if (execute == "No")
            {
                ScenarioContext.Current["Execute"] = "false";
            }
            else
            {
                ScenarioContext.Current["Execute"] = "true";
            }
        }

    }
}
