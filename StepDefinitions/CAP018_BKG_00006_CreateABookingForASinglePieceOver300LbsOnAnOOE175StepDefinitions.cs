using iCargoUIAutomation.pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace iCargoUIAutomation.StepDefinitions
{
    [Binding]
    public class CAP018_BKG_00006_CreateABookingForASinglePieceOver300LbsOnAnOOE175StepDefinitions : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;
        private homePage hp;
        private MaintainBookingPage mbp;

        public CAP018_BKG_00006_CreateABookingForASinglePieceOver300LbsOnAnOOE175StepDefinitions(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            pageObjectManager = new PageObjectManager(driver);
            hp = pageObjectManager.GetHomePage();
            mbp = pageObjectManager.GetMaintainBookingPage();
        }

        [Then(@"An an Embargo pops up with a warning message to generate new AWB")]
        public void ThenAnAnEmbargoPopsUpWithAWarningMessageToGenerateNewAWB()
        {
            throw new PendingStepException();
        }
    }
}
