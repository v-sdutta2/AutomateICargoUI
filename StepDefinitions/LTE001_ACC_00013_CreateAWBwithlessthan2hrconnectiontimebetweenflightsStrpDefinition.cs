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
    public class LTE001_ACC_00013_CreateAWBwithlessthan2hrconnectiontimebetweenflightsStrpDefinition : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;       
        private CreateShipmentPage csp;

        ILog Log = LogManager.GetLogger(typeof(LTE001_ACC_00013_CreateAWBwithlessthan2hrconnectiontimebetweenflightsStrpDefinition));


        public LTE001_ACC_00013_CreateAWBwithlessthan2hrconnectiontimebetweenflightsStrpDefinition(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.pageObjectManager = new PageObjectManager(driver);
           
            this.csp = pageObjectManager.GetCreateShipmentPage();
        }

        [When(@"User selects flights having Minimum Handling / Connection Time Fails restriction")]
        public void WhenUserSelectsFlightsHavingMinimumHandlingConnectionTimeFailsRestriction()
        {
            csp.selectFlightWithRestriction();
        }






    }
}
