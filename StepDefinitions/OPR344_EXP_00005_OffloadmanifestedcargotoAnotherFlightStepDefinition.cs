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
    public class OPR344_EXP_00005_OffloadmanifestedcargotoAnotherFlightStepDefinition : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;       
        private CreateShipmentPage csp;
        private ExportManifestPage emp;
     

        ILog Log = LogManager.GetLogger(typeof(OPR344_EXP_00005_OffloadmanifestedcargotoAnotherFlightStepDefinition));


        public OPR344_EXP_00005_OffloadmanifestedcargotoAnotherFlightStepDefinition(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.pageObjectManager = new PageObjectManager(driver);
           
            this.csp = pageObjectManager.GetCreateShipmentPage();
            this.emp= pageObjectManager.GetExportManifestPage();           

        }

        [When(@"User expands the cart/uld to check the awb")]
        public void WhenUserExpandsTheCartUldToCheckTheAwb()
        {
            Hooks.Hooks.createNode();
            emp.ClickOnCartULDExpandButton();
        }

        [When(@"User cliks on the offload button to open the offload popup")]
        public void WhenUserCliksOnTheOffloadButtonToOpenTheOffloadPopup()
        {
            Hooks.Hooks.createNode();
            emp.ClickOnOffloadAWBButton();
        }

        [When(@"User enters the details to move to another NewFlightNumber ""([^""]*)"" and POU ""([^""]*)""")]
        public void WhenUserEntersTheDetailsToMoveToAnotherNewFlightNumber(string newFlightNum, string POUoffload)
        {
            Hooks.Hooks.createNode();
            emp.FillOffloadFormAndMoveToAnotherFlight(newFlightNum, POUoffload);
        }

        [When(@"User clicks on the orange pencil to edit the manifest")]
        public void WhenUserClicksOnTheOrangePencilToEditTheManifest()
        {
            Hooks.Hooks.createNode();
            emp.ClickOrangePencilToEditManifest();
        }

        [When(@"User enters the new flight number ""([^""]*)"" to move the offloaded shipment")]
        public void WhenUserEntersTheNewFlightNumberToMoveTheOffloadedShipment(string newFlightNum)
        {
            Hooks.Hooks.createNode();
            emp.ClickOnFlightTextBox();
            csp.EnterFlightinExportManifest(newFlightNum);
        }





    }
}
