﻿using iCargoUIAutomation.Features;
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
            Hooks.Hooks.createNode();
            Log.Info("Step: Adding another screening line");
            csp.AddAnotherScreeningLine();
        }

        [When(@"User saves all the details with ChargeType ""([^""]*)""")]
        public void WhenUserSavesAllTheDetailsWithChargeType(string chargeType)
        {
            Hooks.Hooks.createNode();
            Log.Info("Step: Saving all the details with ChargeType");
            csp.SaveDetailsWithChargeType(chargeType);
        }
      

      




    }
}
