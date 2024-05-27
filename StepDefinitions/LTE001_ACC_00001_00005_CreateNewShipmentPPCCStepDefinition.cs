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
    public class LTE001_ACC_00001_00005_CreateNewShipmentPPCCStepDefinition : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;
        private homePage hp;
        private CreateShipmentPage csp;
       
        ILog Log = LogManager.GetLogger(typeof(LTE001_ACC_00001_00005_CreateNewShipmentPPCCStepDefinition));


        public LTE001_ACC_00001_00005_CreateNewShipmentPPCCStepDefinition(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.pageObjectManager = new PageObjectManager(driver);
            this.hp = pageObjectManager.GetHomePage();
            this.csp = pageObjectManager.GetCreateShipmentPage();
        }


        [When(@"user clicks on the List button")]
        public void UserClickOnListButton()
        {
            Log.Info("Step: Clicking on the List button");
            csp.switchToLTEContentFrame();
            csp.clickOnAwbTextBox();
            csp.clickOnListButton();
        }

        [When(@"User enters the Participant details with AgentCode ""([^""]*)"", ShipperCode ""([^""]*)"", ConsigneeCode ""([^""]*)""")]
        public void WhenUserEntersTheParticipantDetailsWithAgentCodeShipperCodeConsigneeCode(string agent, string shipper, string consignee)
        {
            Log.Info("Step: Entering the Participant details");
            csp.EnterParticipantDetailsAsync(agent,shipper,consignee); 
        }     



        [When(@"User clicks on the ContinueParticipant button")]
        public void UserClicksOnContinueParticipantButton()
        {

            Log.Info("Step: Clicking on the ContinueParticipant button");
            csp.clickOnContinueParticipantButton();
        }

        [When(@"User enters the Certificate details")]
        public void UserEntersTheCertificateDetails()
        {
            Log.Info("Step: Entering the Certificate details");
            csp.EnterCertificateDetails();
        }

        [When(@"User clicks on the ContinueCertificate button")]
        public void UserClicksOnContinueCertificateButton()
        {
            Log.Info("Step: Clicking on the ContinueCertificate button");
            csp.clickOnContinueCertificateButton();
        }


        [When(@"User enters the Shipment details with Origin ""([^""]*)"", Destination ""([^""]*)"", ProductCode ""([^""]*)"", SCCCode ""([^""]*)"", Commodity ""([^""]*)"", ShipmentDescription""([^""]*)"", ServiceCargoClass ""([^""]*)"", Piece ""([^""]*)"", Weight ""([^""]*)""")]
        public void UserEnterShipmentDetails(string origin, string destination, string productCode, string scc, string commodity, string shipmentdesc, string serviceCargoClass, string piece, string weight)
        {

            Log.Info("Step: Entering the Shipment details");
            csp.EnterShipmentDetails(origin, destination, productCode, scc, commodity, shipmentdesc, serviceCargoClass, piece, weight);
        }


        [When(@"User clicks on the ContinueShipment button")]
        public void UserClicksOnContinueShipmentButton()
        {
            Log.Info("Step: Clicking on the ContinueShipment button");
            csp.clickOnContinueShipmentButton();
        }

        [When(@"User enters the Flight details with CarrierCode ""([^""]*)"", FlightNo ""([^""]*)""")]
        public void UserEntersFlightDetails(string carrier, string fltnum)
        {

            Log.Info("Step: Entering the Flight details");
            csp.EnterFlightDetails(carrier, fltnum);
        }

        [When(@"User clicks on the Select Flight Button")]
        public void WhenUserClicksOnTheSelectFlightButton()
        {
            csp.clickOnSelectFlightButton();
        }

        [When(@"User selects an available flight")]
        public void WhenUserSelectsAnAvailableFlight()
        {
            csp.bookFlightWithAllAvailability();
        }


        [When(@"User clicks on the ContinueFlightDetails button")]
        public void UserClicksOnContinueFlightDetailsButton()
        {
            Log.Info("Step: Clicking on the ContinueFlightDetails button");
            csp.clickOnContinueFlightDetailsButton();
        }

        [When(@"User enters the Charge details with ChargeType ""([^""]*)"" and ModeOfPayment ""([^""]*)""")]
        public void UserEntersChargeDetails(string chargeType, string modeOfPayment)
        {
            Log.Info("Step: Entering the Charge details");
            csp.enterChargeDetails(chargeType, modeOfPayment);
        }


        [When(@"User clicks on the CalculateCharges button")]
        public void WhenUserClicksOnCalculateChargesButton()
        {
            Log.Info("Step: Clicking on the CalculateCharges button");
            csp.clickOnCalculateChargeButton();

        }

        [When(@"User clicks on the ContinueChargeDetails button")]
        public void WhenUserClicksOnContinueChargeDetailsButton()
        {
            Log.Info("Step: Clicking on the ContinueChargeDetails button");
            csp.clickOnContinueChargeButton();

        }

        [When(@"User enters the Acceptance details")]
        public void WhenUserEntersTheAcceptanceDetails()
        {
            Log.Info("Step: Entering the Acceptance details");
            csp.enterAcceptanceDetails();
        }

        [When(@"User clicks on the ContinueAcceptanceDetails button")]
        public void UserClicksOnContinueAcceptanceDetailsButton()
        {
            Log.Info("Step: Clicking on the ContinueAcceptanceDetails button");
            csp.clickOnContinueAcceptanceButton();
        }


        [When(@"User enters the Screening details for row (.*) with screeingMethod as '([^']*)' and ScreeningResult as '([^']*)'")]
        public void WhenUserEntersTheScreeningDetailsForRowWithScreeingMethodAsAndScreeningResultAs(int rownum, string screeningMethod, string screeningResult)
        {
            Log.Info("Step: Entering the Screening details");
            csp.enterScreeningDetails(rownum, screeningMethod, screeningResult);
        }        


        [When(@"User clicks on the ContinueScreeningDetails button")]
        public void UserClicksOnContinueScreeningDetailsButton()
        {
            Log.Info("Step: Clicking on the ContinueScreeningDetails button");
            csp.clickOnContinueScreeningButton();
        }

        [When(@"User checks the AWB_Verified checkbox")]
        public void UserChecksAWB_VerifiedCheckbox()
        {
            Log.Info("Step: Checking the AWB_Verified checkbox");
            csp.clickOnAWBVerifiedCheckbox();
        }

        [When(@"User clicks on the save button")]
        public void WhenUserClicksOnTheSaveButton()
        {
            csp.clickSave();
        }


        [When(@"User clicks on the save button & handle Payment Portal")]
        public void WhenUserClicksOnTheSaveButtonAndHandlePaymentPortal()
        {
           csp.clickOnSaveButtonHandlePaymentPortal();
        }


        [When(@"User saves all the details & handles all the popups")]
        public void UserSavesAllDetailsHandlesAllThePopups()
        {
            Log.Info("Step: Saving all the details & handling all the popups");
            csp.saveShipmentDetailsAndHandlePopups();
        }

       

        [When(@"User handles the error popups with errorType as '([^']*)'")]
        public void WhenUserHandlesTheErrorPopupsWithErrorTypeAs(string errorType)
        {
            csp.clickingYesOnPopupWarnings(errorType);
        }


        [When(@"User closes the LTE screen")]
        public void UserClosesLTEScreen()
        {
            Log.Info("Step: Closing the LTE screen");
            csp.closeLTE001Screen();
        }



    }
}
