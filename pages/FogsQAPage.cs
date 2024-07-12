using iCargoUIAutomation.utilities;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCargoUIAutomation.pages
{
    public class FogsQAPage : BasePage
    {
        public static string fogsPortalUrlQA = "https://qa.manifest.apps.alaskacargo.com/";
        public FogsQAPage(IWebDriver driver) : base(driver)
        {
        }

        //   Fogs QA Portal //

        // Search Section//
        private By txtStation_Css = By.CssSelector("input[formcontrolname='station']");
        private By txtFlightNumber_Css = By.CssSelector("input[formcontrolname='flightNumber']");
        private By btnView_Xpath = By.XPath("//button[text()='View']");
        // Manifest Details Section//
        private By lblManifest_Xpath = By.XPath("//*[@class='manifest-tabs']//li");
        private By sectionCargoContainer_Xpath = By.XPath("//*[@id='containerComponent']/div[@class='cargo-container']");
        private By awbNumberInContainer_Xpath = By.XPath("//tr[1]/td[1]");
        private By handlingCodeInContainer_Xpath = By.XPath("//tr[1]/td[6]");


        ILog Log = LogManager.GetLogger(typeof(FogsQAPage));


        public void OpenFogsPortal()
        {
            Log.Info("Opening Fogs Portal");
            Open(fogsPortalUrlQA);
            WaitForElementToBeVisible(txtStation_Css, TimeSpan.FromSeconds(10));
        }

        public void EnterStation(string station)
        {
            Log.Info("Entering Station");
            EnterText(txtStation_Css, station);
            EnterKeys(txtStation_Css, Keys.Tab);
        }

        public void EnterFlightNumber(string flightNumber)
        {
            Log.Info("Entering Flight Number");
            EnterText(txtFlightNumber_Css, flightNumber);
            EnterKeys(txtFlightNumber_Css, Keys.Tab);
        }

        public void ClickView()
        {
            Log.Info("Clicking View");
            Click(btnView_Xpath);
            WaitForElementToBeVisible(lblManifest_Xpath, TimeSpan.FromSeconds(10));
        }

        public void ValidateManifestDetails()
        {
            Log.Info("Validating Manifest Details");
            if (IsElementDisplayed(sectionCargoContainer_Xpath))
            {
                Log.Info("Manifest Details displayed successfully");
            }
            else
            {
                Log.Error("Manifest Details not displayed");
            }

        }

        public void ValidateHandlingCodeForAWB(string awb, string expectedHandlingCode)
        {
            Log.Info("Validating Handling Code for AWB");
            string handlingCode = "";
            try
            {
                List<IWebElement> cargoContainers = GetElements(sectionCargoContainer_Xpath);


                for (int i = 1; i <= cargoContainers.Count; i++)
                {
                    string awbToExtract_string = "(//*[@id='containerComponent']/div[@class='cargo-container'])[" + i + "]//tr[1]/td[1]";
                    string handlingCodeToExtract_string = "(//*[@id='containerComponent']/div[@class='cargo-container'])[" + i + "]//tr[1]/td[6]";
                    //public By awbToExtract_Xpath= By.XPath(awbToExtract_string);

                    if (GetText(By.XPath(awbToExtract_string)).Split("-")[1].Contains(awb))
                    {
                        handlingCode= GetText(By.XPath(handlingCodeToExtract_string));
                        Log.Info("Handling Code for AWB " + awb + " is " + handlingCode);
                        break;
                    }                   
                    else
                    {
                        Log.Info("AWB not found in the container");
                    }
                }
               
                if (handlingCode.Contains(expectedHandlingCode))
                {
                    Log.Info("Handling Code "+ expectedHandlingCode + " matched successfully");
                }
                else
                {
                    Log.Error("Handling Code not matched");
                    Assert.Fail("Handling Code not matched");   
                }
            }
            catch (Exception e)
            {
                Log.Error("Error in getting Handling Code for AWB");
                Log.Error(e.Message);
            }
        }

        public void LogOutFogsQAPortal()
        {
            Log.Info("Logging out from Fogs QA Portal");
            LogOutApplication();            
        }
    }
}
