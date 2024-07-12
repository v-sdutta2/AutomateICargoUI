using iCargoUIAutomation.Features;
using iCargoUIAutomation.pages;
using iCargoUIAutomation.utilities;
using log4net;
using log4net.Filter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using TechTalk.SpecFlow;

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
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Clicking on the List button");
                csp.SwitchToLTEContentFrame();
                csp.ClickOnAwbTextBox();
                csp.ClickOnListButton();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [When(@"User enters the Participant details with AgentCode ""([^""]*)"", ShipperCode ""([^""]*)"", ConsigneeCode ""([^""]*)""")]
        public void WhenUserEntersTheParticipantDetailsWithAgentCodeShipperCodeConsigneeCode(string agent, string shipper, string consignee)
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Entering the Participant details");
                csp.EnterParticipantDetailsAsync(agent, shipper, consignee);
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }



        [When(@"User clicks on the ContinueParticipant button")]
        public void UserClicksOnContinueParticipantButton()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Clicking on the ContinueParticipant button");
                csp.ClickOnContinueParticipantButton();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [When(@"User enters the Certificate details")]
        public void UserEntersTheCertificateDetails()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Entering the Certificate details");
                csp.EnterCertificateDetails();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [When(@"User clicks on the ContinueCertificate button")]
        public void UserClicksOnContinueCertificateButton()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Clicking on the ContinueCertificate button");
                csp.ClickOnContinueCertificateButton();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }


        [When(@"User enters the Shipment details with Origin ""([^""]*)"", Destination ""([^""]*)"", ProductCode ""([^""]*)"", SCCCode ""([^""]*)"", Commodity ""([^""]*)"", ShipmentDescription""([^""]*)"", ServiceCargoClass ""([^""]*)"", Piece ""([^""]*)"", Weight ""([^""]*)""")]
        public void UserEnterShipmentDetails(string origin, string destination, string productCode, string scc, string commodity, string shipmentdesc, string serviceCargoClass, string piece, string weight)
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Entering the Shipment details");
                csp.EnterShipmentDetails(origin, destination, productCode, scc, commodity, shipmentdesc, serviceCargoClass, piece, weight);
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }


        [When(@"User clicks on the ContinueShipment button")]
        public void UserClicksOnContinueShipmentButton()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Clicking on the ContinueShipment button");
                csp.ClickOnContinueShipmentButton();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [When(@"User enters the Flight details with CarrierCode ""([^""]*)"", FlightNo ""([^""]*)""")]
        public void UserEntersFlightDetails(string carrier, string fltnum)
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Entering the Flight details");
                csp.EnterFlightDetails(carrier, fltnum);
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [When(@"User clicks on the Select Flight Button")]
        public void WhenUserClicksOnTheSelectFlightButton()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                csp.ClickOnSelectFlightButton();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [When(@"User selects an available flight")]
        public void WhenUserSelectsAnAvailableFlight()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                csp.BookFlightWithAllAvailability();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [When(@"User selects an ""([^""]*)"" flight")]
        public void WhenUserSelectsAnFlight(string typeOfFlight)
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                csp.BookWithSpecificFlightType(typeOfFlight);
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }


        [When(@"User clicks on the ContinueFlightDetails button")]
        public void UserClicksOnContinueFlightDetailsButton()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Clicking on the ContinueFlightDetails button");
                csp.ClickOnContinueFlightDetailsButton();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [When(@"User enters the Charge details with ChargeType ""([^""]*)"" and ModeOfPayment ""([^""]*)""")]
        public void UserEntersChargeDetails(string chargeType, string modeOfPayment)
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Entering the Charge details");
                csp.EnterChargeDetails(chargeType, modeOfPayment);
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }


        [When(@"User clicks on the CalculateCharges button")]
        public void WhenUserClicksOnCalculateChargesButton()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Clicking on the CalculateCharges button");
                csp.ClickOnCalculateChargeButton();
                csp.ClickingYesOnPopupWarnings("");
            }
            else
            {
                ScenarioContext.Current.Pending();
            }

        }

        [When(@"User clicks on the ContinueChargeDetails button")]
        public void WhenUserClicksOnContinueChargeDetailsButton()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Clicking on the ContinueChargeDetails button");
                csp.ClickOnContinueChargeButton();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }

        }

        [When(@"User enters the Acceptance details")]
        public void WhenUserEntersTheAcceptanceDetails()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Entering the Acceptance details");
                csp.EnterAcceptanceDetails();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [When(@"User clicks on the ContinueAcceptanceDetails button")]
        public void UserClicksOnContinueAcceptanceDetailsButton()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Clicking on the ContinueAcceptanceDetails button");
                csp.ClickOnContinueAcceptanceButton();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }


        [When(@"User enters the Screening details for row (.*) with screeingMethod as '([^']*)' and ScreeningResult as '([^']*)'")]
        public void WhenUserEntersTheScreeningDetailsForRowWithScreeingMethodAsAndScreeningResultAs(int rownum, string screeningMethod, string screeningResult)
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Entering the Screening details");
                csp.EnterScreeningDetails(rownum, screeningMethod, screeningResult);
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }


        [When(@"User clicks on the ContinueScreeningDetails button")]
        public void UserClicksOnContinueScreeningDetailsButton()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Clicking on the ContinueScreeningDetails button");
                csp.ClickOnContinueScreeningButton();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [When(@"User fills up the checksheet for ProductCode ""([^""]*)"" if applicable")]
        public void WhenUserFillsUpTheChecksheetForProductCodeIfApplicable(string productCode)
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                if (productCode == "PRIORITY")
                {
                    csp.ClickSave();
                    Log.Info("Step: Filling up the checksheet for ProductCode " + productCode);
                    csp.CaptureCheckSheetForDG();
                }
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }


        [When(@"User checks the AWB_Verified checkbox")]
        public void UserChecksAWB_VerifiedCheckbox()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Checking the AWB_Verified checkbox");
                csp.ClickOnAWBVerifiedCheckbox();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [When(@"User clicks on the save button")]
        public void WhenUserClicksOnTheSaveButton()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                csp.ClickSave();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [When(@"User closes the Payment Portal tab and retry")]
        public void WhenUserClosesThePaymentPortalTabAndRetry()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                csp.ClosePaymentPortalWindow();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [When(@"User handles the Payment portal window with chargeType ""([^""]*)""")]
        public void WhenUserHandlesThePaymentPortalWindowWithChargeType(string chargeType)
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                csp.PaymentWithPPCCinPortal(chargeType);
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }



        [When(@"User clicks on the save button & handle Payment Portal")]
        public void WhenUserClicksOnTheSaveButtonAndHandlePaymentPortal()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                csp.ClickOnSaveButtonHandlePaymentPortal();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }


        [When(@"User saves all the details & handles all the popups")]
        public void UserSavesAllDetailsHandlesAllThePopups()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Saving all the details & handling all the popups");
                csp.SaveShipmentDetailsAndHandlePopups();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }



        [When(@"User handles the error popups with errorType as '([^']*)'")]
        public void WhenUserHandlesTheErrorPopupsWithErrorTypeAs(string errorType)
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                csp.ClickingYesOnPopupWarnings(errorType);
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }


        [When(@"User closes the LTE screen")]
        public void UserClosesLTEScreen()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                Hooks.Hooks.createNode();
                Log.Info("Step: Closing the LTE screen");
                csp.CloseLTE001Screen();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }



    }
}
