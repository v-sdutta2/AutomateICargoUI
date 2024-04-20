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
    public class LTE001_ACC_00008_ReopenAWBchangepiececountandweightandreexecute : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;
        private createShipmentPage csp;
        ILog Log = LogManager.GetLogger(typeof(LTE001_ACC_00008_ReopenAWBchangepiececountandweightandreexecute));

        public LTE001_ACC_00008_ReopenAWBchangepiececountandweightandreexecute(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.pageObjectManager = new PageObjectManager(driver);
            this.csp = pageObjectManager.GetCreateShipmentPage();
        }

        [When(@"User landed on the Homepage again")]
        public void WhenUserLandedOnTheHomepageAgain()
        {
            Log.Info("Step: Landing on the Homepage again");
            SwitchToDefaultContent();
        }


        [When(@"User enters the Executed AWB number")]
        public void WhenUserEntersTheExecutedAWBNumber()
        {
            Log.Info("Step: Entering the Executed AWB number");
            csp.alreadyExecutedAWB();
        }


        [When(@"User Reopens the AWB")]
        public void WhenUserReopensTheAWB()
        {
            Log.Info("Step: Reopening the AWB");
            csp.reOpenAWB();
        }

        [When(@"User verifies and Update the Shipment Details")]
        public void WhenUserVerifiesAndUpdateTheShipmentDetails()
        {
            Log.Info("Step: Verifying and Updating the Shipment Details");
            csp.verifyAndUpdateShipmentDetails();
        }

        [When(@"User verifies and Update the Flight Details")]
        public void WhenUserVerifiesAndUpdateTheFlightDetails()
        {
            Log.Info("Step: Verifying and Updating the Flight Details");
            csp.verifyAndUpdateFlightDetails();
        }


        [When(@"User verifies and Update the Acceptance Details")]
        public void WhenUserVerifiesAndUpdateTheAcceptanceDetails()
        {
            Log.Info("Step: Verifying and Updating the Acceptance Details");
            csp.verifyAndUpdateAcceptanceDetails();
        }

        [When(@"User verifies and Update the Screening Details")]
        public void WhenUserVerifiesAndUpdateTheScreeningDetails()
        {
            Log.Info("Step: Verifying and Updating the Screening Details");
            csp.verifyAndUpdateScreeningDetails();
        }


    }
}
