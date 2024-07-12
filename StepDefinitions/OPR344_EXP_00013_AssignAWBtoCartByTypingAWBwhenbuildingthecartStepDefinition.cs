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
    public class OPR344_EXP_00013_AssignAWBtoCartByTypingAWBwhenbuildingthecartStepDefinition : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;       
        private CreateShipmentPage csp;
        private ExportManifestPage emp;
     

        ILog Log = LogManager.GetLogger(typeof(OPR344_EXP_00013_AssignAWBtoCartByTypingAWBwhenbuildingthecartStepDefinition));


        public OPR344_EXP_00013_AssignAWBtoCartByTypingAWBwhenbuildingthecartStepDefinition(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.pageObjectManager = new PageObjectManager(driver);           
            this.csp = pageObjectManager.GetCreateShipmentPage();
            this.emp= pageObjectManager.GetExportManifestPage();           

        }


        [When(@"User creates new ULD/Cart in Assigned Shipment with with cartType ""([^""]*)"" and pou ""([^""]*)"" and the AWB Number typed in with piece ""([^""]*)""")]
        public void WhenUserCreatesNewULDCartInAssignedShipmentWithWithCartTypeAndPouAndTheAWBNumberTypedIn(string cartType, string pou, string pieces)
        {
            Hooks.Hooks.createNode();
            csp.CreateNewULDCartTypingAWBExportManifest(cartType, pou, pieces);
        }

        

    }
}
