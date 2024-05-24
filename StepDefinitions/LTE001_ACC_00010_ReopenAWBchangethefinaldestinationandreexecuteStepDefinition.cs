using AventStack.ExtentReports.Gherkin.Model;
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
    public class LTE001_ACC_00010_ReopenAWBchangefinaldestinationandreexecute : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;
        private CreateShipmentPage csp;
        ILog Log = LogManager.GetLogger(typeof(LTE001_ACC_00010_ReopenAWBchangefinaldestinationandreexecute));

        public LTE001_ACC_00010_ReopenAWBchangefinaldestinationandreexecute(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.pageObjectManager = new PageObjectManager(driver);
            this.csp = pageObjectManager.GetCreateShipmentPage();
        }
        

        [When(@"User saves the details with capturing irregularity for flight destination change with ChargeType ""([^""]*)""")]
        public void WhenUserSavesTheDetailsWithCapturingIrregularityForFlightDestinationChangeWithChargeType(string charge)
        {
            csp.saveDetailsWithCapturingIrregularity(charge);
        }




    }
}
