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
    public class LTE001_ACC_00015_CreateAWBCAODGshipmentandbookonpaxflight : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;       
        private CreateShipmentPage csp;

        ILog Log = LogManager.GetLogger(typeof(LTE001_ACC_00015_CreateAWBCAODGshipmentandbookonpaxflight));


        public LTE001_ACC_00015_CreateAWBCAODGshipmentandbookonpaxflight(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            this.pageObjectManager = new PageObjectManager(driver);
           
            this.csp = pageObjectManager.GetCreateShipmentPage();
        }

        [When(@"User selects an ""([^""]*)"" flight")]
        public void WhenUserSelectsAnFlight(string typeOfFlight)
        {
           csp.bookWithSpecificFlightType(typeOfFlight);
        }



        [When(@"User enters details for CAO DG shipment with ChargeType ""([^""]*)"",UNID ""([^""]*)"", ProperShipmentName ""([^""]*)"", PackingInstruction ""([^""]*)"",NoOfPkg ""([^""]*)"", NetQtyPerPkg ""([^""]*)"", ReportableQnty ""([^""]*)""")]
        public void UserEnterDetailsForCAODGShipment(string chargetype, string unid, string propershipmntname, string pi, string noOFPkg, string netqtyperpkg, string reportable)
        {
            csp.enterCAODGDetails(chargetype, unid, propershipmntname, pi, noOFPkg, netqtyperpkg, reportable);
        }

        [When(@"User saves the CAO DG shipment with ""([^""]*)"" flight")]
        public void WhenUserSavesTheCAODGShipmentWithFlight(string typeOfFlight)
        {
            csp.saveCAODGshipment(typeOfFlight);
        }




    }
}
