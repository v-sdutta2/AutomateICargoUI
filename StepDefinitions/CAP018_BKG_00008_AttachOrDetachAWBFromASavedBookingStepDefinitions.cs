using iCargoUIAutomation.pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace iCargoUIAutomation.StepDefinitions
{
    [Binding]
    public class CAP018_BKG_00008_AttachOrDetachAWBFromASavedBookingStepDefinitions : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;
        private homePage hp;
        private MaintainBookingPage mbp;
        string agentcode = "";

        public CAP018_BKG_00008_AttachOrDetachAWBFromASavedBookingStepDefinitions(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            pageObjectManager = new PageObjectManager(driver);
            hp = pageObjectManager.GetHomePage();
            mbp = pageObjectManager.GetMaintainBookingPage();
        }


        [Then(@"User clicks on Attach/Detach button")]
        public void ThenUserClicksOnAttachDetachButton()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            {
                mbp.AttachOrDetachAWB();
            }
            else
            {
                ScenarioContext.Current.Pending();
            }            
        }

        [Then(@"User enters new Agent Code ""([^""]*)""")]
        public void ThenUserEntersNewAgentCode(string agentcode)
        {
            this.agentcode = agentcode;
            if (ScenarioContext.Current["Execute"] == "true")
            mbp.EnterNewAgentCode(agentcode);
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [Then(@"User enters the AWB number")]
        public void ThenUserEntersTheAWBNumberAs()
        {
            if (ScenarioContext.Current["Execute"] == "true")
            mbp.EnterAWBNumber();
            else
            {
                ScenarioContext.Current.Pending();
            }
        }
      

    }
}
