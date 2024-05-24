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
    public class LTE001_ACC_00003_CreateaDGAWBinLTE001 : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;       
        private CreateShipmentPage csp;

        ILog Log = LogManager.GetLogger(typeof(LTE001_ACC_00003_CreateaDGAWBinLTE001));


        public LTE001_ACC_00003_CreateaDGAWBinLTE001(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.pageObjectManager = new PageObjectManager(driver);
           
            this.csp = pageObjectManager.GetCreateShipmentPage();
        }

       


        [When(@"User Save Shipment Capture Checksheet & DG Details with ChargeType ""([^""]*)"",UNID ""([^""]*)"", ProperShipmentName ""([^""]*)"", PackingInstruction ""([^""]*)"",NoOfPkg ""([^""]*)"", NetQtyPerPkg ""([^""]*)"", ReportableQnty ""([^""]*)""")]
        public void SaveShipmentWithDGAndCheckSheet(string chargetype,string unid, string propershipmntname, string pi, string noOFPkg, string netqtyperpkg, string reportable)
        {
           Log.Info("Step: Save Shipment Capture Checksheet & DG Details");
           csp.SaveWithDGAndCheckSheet(chargetype,unid, propershipmntname, pi, noOFPkg, netqtyperpkg, reportable);

        }


    }
}
