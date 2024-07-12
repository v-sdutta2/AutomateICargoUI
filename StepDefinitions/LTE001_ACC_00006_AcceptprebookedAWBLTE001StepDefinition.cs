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
            Hooks.Hooks.createNode();
            Log.Info("Step: Entering the AWB of a PreBooked Shipment");
            preBookedAWB = preBookedAWB.Split("-")[1];
            csp.SwitchToLTEContentFrame();
            csp.ClickOnAwbTextBox();
            csp.EnterAWBTextBox(preBookedAWB);
            csp.ClickOnListButton();
        }

        [When(@"User opens & verifies the Participant Details")]
        public void WhenUserOpensVerifiesTheParticipantDetails()
        {
            Hooks.Hooks.createNode();
            Log.Info("Step: Opening and Verifying the Participant Details");
            csp.OpenAndVerifyParticipants();
        }

        [When(@"User opens & verifies the Shipment Details")]
        public void WhenUserOpensVerifiesTheShipmentDetails()
        {
            Hooks.Hooks.createNode();
            Log.Info("Step: Opening and Verifying the Shipment Details");
            csp.OpenAndVerifyShipments();            
        }

        [When(@"User opens & verifies the Flight Details")]
        public void WhenUserOpensVerifiesTheFlightDetails()
        {
            Hooks.Hooks.createNode();
            Log.Info("Step: Opening and Verifying the Flight Details");
            csp.OpenAndVerifyFlightDetails();
           
        }

        [When(@"user opens the Charge Details")]
        public void WhenUserOpensTheChargeDetails()
        {
            Hooks.Hooks.createNode();
            Log.Info("Step: Opening the Charge Details");
            csp.OpenAndVerifyChargeDetails();
        }

        [When(@"User enters the Acceptance details with PreBooked pieces")]
        public void WhenUserEntersTheAcceptanceDetailsWithPreBookedPieces()
        {
            Hooks.Hooks.createNode();
            Log.Info("Step: Entering the Acceptance details with PreBooked pieces");
            csp.EnterAcceptanceDetails();
        }

    }
}
