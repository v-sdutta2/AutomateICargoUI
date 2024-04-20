using iCargoUIAutomation.pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace iCargoUIAutomation.StepDefinitions
{
    [Binding]
    public class CAP018_BKG_00007_CreateABookingForAnAVIStepDefinitions : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;
        private homePage hp;
        private MaintainBookingPage mbp;

        public CAP018_BKG_00007_CreateABookingForAnAVIStepDefinitions(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            pageObjectManager = new PageObjectManager(driver);
            hp = pageObjectManager.GetHomePage();
            mbp = pageObjectManager.GetMaintainBookingPage();
        }
        [Then(@"User clicks on Save button and fills the checksheet details to generate awb")]
        public void ThenUserFillsTheChecksheetDetailsToGenerateAwb()
        {
            mbp.AVIBookingChecksheetDetails();
        }
    }
}
