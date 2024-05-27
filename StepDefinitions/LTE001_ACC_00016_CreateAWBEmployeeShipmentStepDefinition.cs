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
    public class LTE001_ACC_00016_CreateAWBEmployeeShipmentStepDefinition : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;       
        private CreateShipmentPage csp;

        ILog Log = LogManager.GetLogger(typeof(LTE001_ACC_00016_CreateAWBEmployeeShipmentStepDefinition));


        public LTE001_ACC_00016_CreateAWBEmployeeShipmentStepDefinition(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.pageObjectManager = new PageObjectManager(driver);
           
            this.csp = pageObjectManager.GetCreateShipmentPage();
        }



        [When(@"User captures the checksheet")]
        public void WhenUserCapturesTheChecksheet()
        {
            csp.captureCheckSheetForDG();
        }




    }
}
