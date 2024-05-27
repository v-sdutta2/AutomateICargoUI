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
    public class LTE001_ACC_00007_CreateAWBLTE001thathaspiecesthatfailscreening : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;       
        private CreateShipmentPage csp;
        ILog Log = LogManager.GetLogger(typeof(LTE001_ACC_00007_CreateAWBLTE001thathaspiecesthatfailscreening));


        public LTE001_ACC_00007_CreateAWBLTE001thathaspiecesthatfailscreening(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.pageObjectManager = new PageObjectManager(driver);           
            this.csp = pageObjectManager.GetCreateShipmentPage();
        }


        [When(@"USer adds another screening line")]
        public void WhenUSerAddsAnotherScreeningLine()
        {
            Log.Info("Step: Adding another screening line");
            csp.addAnotherScreeningLine();
        }

        [When(@"User saves all the details with ChargeType ""([^""]*)""")]
        public void WhenUserSavesAllTheDetailsWithChargeType(string chargeType)
        {
            Log.Info("Step: Saving all the details with ChargeType");
            csp.saveDetailsWithChargeType(chargeType);
        }
      

        [When(@"User validates the popped up error message as ""([^""]*)""")]
        public void WhenUserValidatesThePoppedUpErrorMessageAs(string expectedWarnMsg)
        {
            Log.Info("Step: Validating the popped up error message");
            csp.validateWarningMessage(expectedWarnMsg);
        }




    }
}
