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
    public class OPR344_EXP_00001_ManifestAWBUnknownShipperonpaxflightStepDefinition : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;       
        private CreateShipmentPage csp;
        private ExportManifestPage emp;
     

        ILog Log = LogManager.GetLogger(typeof(LTE001_ACC_00016_CreateAWBEmployeeShipmentStepDefinition));


        public OPR344_EXP_00001_ManifestAWBUnknownShipperonpaxflightStepDefinition(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.pageObjectManager = new PageObjectManager(driver);           
            this.csp = pageObjectManager.GetCreateShipmentPage();
            this.emp= pageObjectManager.GetExportManifestPage();           

        }
       

        [When(@"User enters the Booked FlightNumber with ""([^""]*)""")]
        public void WhenUserEntersTheBookedFlightNumberWith(string fltnumber)
        {
            Hooks.Hooks.createNode();
            emp.SwitchToManifestFrame();
            emp.ClickOnFlightTextBox();
            csp.EnterFlightinExportManifest(fltnumber);
        }


        [When(@"User enters Booked ShipmentDate")]
        public void WhenUserEntersBookedShipmentDate()
        {
            Hooks.Hooks.createNode();
            csp.EnterFlightDateExportManifest();
        }

        [When(@"User clicks on the List button to fetch the Booked Shipment")]
        public void WhenUserClicksOnTheListButtonToFetchTheBookedShipment()
        {
            Hooks.Hooks.createNode();
            emp.ClickOnListButton();
        }
       

        [When(@"User creates new ULD/Cart in Assigned Shipment with cartType ""([^""]*)"" and pou ""([^""]*)""")]
        public void WhenUserCreatesNewULDCartInAssignedShipmentWithCartTypeAndPou(string cartType, string pou)
        {
            Hooks.Hooks.createNode();
            csp.CreateNewULDCartExportManifest(cartType, pou);
        }



        [When(@"User filterouts the Booked AWB from '([^']*)' and Created ULD_Cart")]
        public void WhenUserFilteroutsTheBookedAWBFromAndCreatedULD_Cart(string awbSectionName)
        {
            Hooks.Hooks.createNode();
            csp.FilterOutAWBULDInExportManifest(awbSectionName);
        }   
        




        [When(@"User clicks on the Manifest button")]
        public void WhenUserClicksOnTheManifestButton()
        {
           emp.clickOnManifestButton();
        }

        [When(@"User generates the Manifest PDF from the PrintPDF window")]
        public void WhenUserGeneratesTheManifestPDFFromThePrintPDFWindow()
        {
            emp.PrintManifestWindow();
        }

        [When(@"User closes the PrintPDF window")]
        public void WhenUserClosesThePrintPDFWindow()
        {
            emp.ClosePrintPDFWindow();
        }

        [When(@"User validates the AWB is ""([^""]*)"" in the Export Manifest screen")]
        public void WhenUserValidatesTheAWBIsInTheExportManifestScreen(string awbStatus)
        {
            emp.ValidateAWBStatusInExportManifest(awbStatus);
        }


        [Then(@"User closes the Export Manifest screen")]
        public void ThenUserClosesTheOPRScreen()
        {
           emp.CloseOPR344Screen();
        }

        [When(@"User validates the error popover message as ""([^""]*)""")]
        public void WhenUserValidatesTheErrorPopoverMessageAs(string expectedWarnMsg)
        {
            Log.Info("Step: Validating the popped up error message");           
            emp.ValidateOPR344WarningMessage(expectedWarnMsg);

        }
    }
}
