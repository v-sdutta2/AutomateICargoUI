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
    public class OPR344_EXP_00004_SplitAWBOPR344manifestsplitpiecestoflightStepDefinition : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;       
        private CreateShipmentPage csp;
        private ExportManifestPage emp;
     

        ILog Log = LogManager.GetLogger(typeof(OPR344_EXP_00004_SplitAWBOPR344manifestsplitpiecestoflightStepDefinition));


        public OPR344_EXP_00004_SplitAWBOPR344manifestsplitpiecestoflightStepDefinition(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.pageObjectManager = new PageObjectManager(driver);
           
            this.csp = pageObjectManager.GetCreateShipmentPage();
            this.emp= pageObjectManager.GetExportManifestPage();           

        }

        [When(@"User filterouts the Booked AWB from '([^']*)' Split And Assign with Pieces ""([^""]*)""")]
        public void WhenUserFilteroutsTheBookedAWBFromSplitAndAssign(string awbSectionName, string splitPieces)
        {
            csp.FilterSplitAndAssignAWBToULDExportManifest(awbSectionName, splitPieces);
        }

        



    }
}
