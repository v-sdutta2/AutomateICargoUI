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
    public class LTE001_ACC_00011_CreateAWBfirstflightfreighternextflightpaxStepDefinition : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;       
        private CreateShipmentPage csp;

        ILog Log = LogManager.GetLogger(typeof(LTE001_ACC_00011_CreateAWBfirstflightfreighternextflightpaxStepDefinition));


        public LTE001_ACC_00011_CreateAWBfirstflightfreighternextflightpaxStepDefinition(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.pageObjectManager = new PageObjectManager(driver);
           
            this.csp = pageObjectManager.GetCreateShipmentPage();
        }


        [When(@"User selects first flight as '([^']*)' flight and second flight as '([^']*)' flight")]
        public void WhenUserSelectsFirstFlightAsFlightAndSecondFlightAsFlight(string firstFlightType, string secondFlightType)
        {
            csp.bookConnectingFlightWithDifferentFlightTypes(firstFlightType, secondFlightType);
        }





    }
}
