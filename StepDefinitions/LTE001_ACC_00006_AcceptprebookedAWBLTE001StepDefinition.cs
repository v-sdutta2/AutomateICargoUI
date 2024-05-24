using iCargoUIAutomation.Features;
using iCargoUIAutomation.pages;
using iCargoUIAutomation.utilities;
using log4net;
using log4net.Filter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace iCargoUIAutomation.StepDefinitions
{
    [Binding]
    public class LTE001_ACC_00006_AcceptprebookedAWBLTE001 : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;
       
        private CreateShipmentPage csp;
        public static string preBookedpieces="";
        ILog Log = LogManager.GetLogger(typeof(LTE001_ACC_00006_AcceptprebookedAWBLTE001));


        public LTE001_ACC_00006_AcceptprebookedAWBLTE001(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.pageObjectManager = new PageObjectManager(driver);          
            this.csp = pageObjectManager.GetCreateShipmentPage();
        }


        [When(@"User enters an AWB ""([^""]*)"" of a PreBooked Shipment")]
        public void WhenUserEntersAnAWBOfAPreBookedShipment(string preBookedAWB)
        {
            Log.Info("Step: Entering the AWB of a PreBooked Shipment");
            preBookedAWB = preBookedAWB.Split("-")[1];
            csp.switchToLTEContentFrame();
            csp.enterAWBTextBox(preBookedAWB);
            csp.clickOnListButton();
        }

        [When(@"User opens & verifies the Participant Details")]
        public void WhenUserOpensVerifiesTheParticipantDetails()
        {
            Log.Info("Step: Opening and Verifying the Participant Details");
            csp.openAndVerifyParticipants();
        }

        [When(@"User opens & verifies the Shipment Details")]
        public void WhenUserOpensVerifiesTheShipmentDetails()
        {
            Log.Info("Step: Opening and Verifying the Shipment Details");
            csp.openAndVerifyShipments();            
        }

        [When(@"User opens & verifies the Flight Details")]
        public void WhenUserOpensVerifiesTheFlightDetails()
        {
            Log.Info("Step: Opening and Verifying the Flight Details");
            csp.openAndVerifyFlightDetails();
           
        }

        [When(@"user opens the Charge Details")]
        public void WhenUserOpensTheChargeDetails()
        {
            Log.Info("Step: Opening the Charge Details");
            csp.openAndVerifyChargeDetails();
        }

        [When(@"User enters the Acceptance details with PreBooked pieces")]
        public void WhenUserEntersTheAcceptanceDetailsWithPreBookedPieces()
        {
            Log.Info("Step: Entering the Acceptance details with PreBooked pieces");
            csp.enterAcceptanceDetails();
        }

    }
}
