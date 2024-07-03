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
    public class OPR344_EXP_00002_ManifestAWBfromlyinglistStepDefinition : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;       
        private CreateShipmentPage csp;
        private ExportManifestPage emp;
     

        ILog Log = LogManager.GetLogger(typeof(OPR344_EXP_00002_ManifestAWBfromlyinglistStepDefinition));


        public OPR344_EXP_00002_ManifestAWBfromlyinglistStepDefinition(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.pageObjectManager = new PageObjectManager(driver);
           
            this.csp = pageObjectManager.GetCreateShipmentPage();
            this.emp= pageObjectManager.GetExportManifestPage();           

        }

        [When(@"User clicks on the lying list")]
        public void WhenUserClicksOnTheLyingList()
        {
            emp.ClickOnLyingList();
        }

        [When(@"User clicks on the filter button")]
        public void WhenUserClicksOnTheFilterButton()
        {
            emp.ClickOnLyingListFilter();
        }

        [When(@"User selects ""([^""]*)"" from the Ready For Carriage dropdown")]
        public void WhenUserSelectsFromTheReadyForCarriageDropdown(string option)
        {
            emp.SelectReadyForCarriage(option);
        }

        [When(@"User clicks on the Apply button")]
        public void WhenUserClicksOnTheApplyButton()
        {
           emp.ClickOnApplyFilter();
        }

        [When(@"User selects the checkbox of the first shipment from Lying list")]
        public void WhenUserSelectsTheCheckboxOfTheFirstShipment()
        {
            emp.ClickOnCheckBoxLyingListAWB();
        }

        [When(@"User place the shipment on the cart to manifest")]
        public void WhenUserPlaceTheShipmentOnTheCartToManifest()
        {
            emp.PlaceShipmentOnCartToManifest();
        }

        [When(@"User handles any pop up error message")]
        public void WhenUserHandlesAnyPopUpErrorMessage()
        {
           emp.HandleWarningMessage();
        }


        [When(@"User validates the warning message ""([^""]*)""")]
        public void WhenUserValidatesTheWarningMessage(string messageToValidate)
        {
            emp.ValidateWarningMessageAndCloseModal(messageToValidate);
        }

    }
}
