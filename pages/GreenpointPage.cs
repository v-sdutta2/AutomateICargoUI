using MongoDB.Driver.Core.Operations;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace iCargoUIAutomation.pages
{
    public class GreenpointPage : BasePage
    {
        public GreenpointPage(IWebDriver driver) : base(driver)
        {
        }
        private By agentSelectEnterBtn_Xpath = By.XPath("//*[@test-locator='enter']");
        private By flightMonitorBtn_Xpath = By.XPath("//*[@test-locator='monitor-button']");
        private By saveAssignmentBtn_Xpath = By.XPath("//*[@test-locator='saveChooseAssignments']");

        //flight search
        private By flightSearchBtn_Xpath = By.XPath("//*[@test-locator='goToModal']/div/div[2]");
        private By searchFlight_Xpath = By.XPath("//*[@test-locator='goToFlightInput']/div/div/input");
        private By flightList_Xpath = By.XPath("//*[@test-locator='flights']/div");
        //private By flightNbr_Xpath = By.XPath("//*[@test-locator='flights']/div/div[1]");
        private By flightNbr_Xpath = By.XPath("//*[@test-locator='formattedFlightNumber']");
        private By cargoList_Xpath = By.XPath("//*[@test-locator='Cargo']");
        private By nextPageFlightList_Xpath = By.XPath("//*[@test-locator='nextPage']");

        //Cargo gate
        private By cargoGateFrame_Xpath = By.XPath("//*[@name='main']");
        private By ahmConfig_Xpath = By.XPath("//span[text()='Choose ahm configurations']");
        private By ahmProceed_Id = By.Id("proceedButton");
        private By numberFilter_Xpath = By.XPath("//*[@data-name='NUMBER']");
        private By cargoAWBList_Xpath = By.XPath("//*[@id='unassignedTbody']//tr[contains(@class,'itemRow')]");
        private By cargoAWBNo_Xpath = By.XPath("//input[@data-prop='airWayBillNo']");
        private By cartNumber_Xpath = By.XPath("//*[contains(@name,'number')]");
        private By cargoDetailsHideBtn_Xpath = By.XPath("//*[contains(@class,'showHideBtn')]");
        private By cargoWeight_Xpath = By.XPath("//input[contains(@name,'detWeight')]");
        private By cargoPieces_Xpath = By.XPath("//input[contains(@name,'detPieces')]");


        //Greenpoint logout
        private By userProfileBtn_Xpath = By.XPath("//*[@title='User Profile']");
        private By logOutBtn_Xpath = By.XPath("//*[(text()='Log out')]");
        private By logOutConfirmMessage_Xpath = By.XPath("//*[@test-locator='logOutNotification']");

        public void ClickOnAgentSelectEnterBtn()
        {
            try
            {
                Click(agentSelectEnterBtn_Xpath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ChooseAssignment()
        {
            try
            {
                Click(flightMonitorBtn_Xpath);
                Click(saveAssignmentBtn_Xpath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SearchFlight(string flightNumber)
        {
            try
            {
                Click(searchFlight_Xpath);
                EnterKeys(searchFlight_Xpath, flightNumber);
                Click(flightSearchBtn_Xpath);
                SwitchToNewWindow();
                List<IWebElement> flightList = GetElements(flightList_Xpath);
                List<IWebElement> flightNbrs = GetElements(flightNbr_Xpath);
                List<IWebElement> cargoListBtn = GetElements(cargoList_Xpath);
                int flightListCount = GetElementCount(flightList_Xpath);
                int count = 0;
                if (flightListCount > 0)
                {
                    while (count == 0)
                    {
                        for (int i = 0; i < flightList.Count; i++)
                        {
                            IWebElement flightDetails = flightNbrs[i];
                            string flightDate = flightDetails.Text.Substring(flightDetails.Text.Length - 2);
                            if (flightDate == DateTime.Now.ToString("dd"))
                            {
                                count++;
                                IWebElement cargoBtn = cargoListBtn[i];
                                ClickOnElement(cargoBtn);
                                SwitchToLastWindow();
                                Console.WriteLine(GetTitle());
                                SwitchToFrame(cargoGateFrame_Xpath);
                                if (IsElementDisplayed(ahmConfig_Xpath))
                                {
                                    Click(ahmProceed_Id);
                                }
                                else
                                {
                                    Console.WriteLine("No AHM Configurations");
                                }
                                break;
                            }
                        }
                        if (count == 0)
                        {
                            Click(nextPageFlightList_Xpath);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No Flights available");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CargoAwbValidation(string awbNum, string piecesNum, string weightNum)
        {
            try
            {
                SwitchToLastWindow();
                SwitchToFrame(cargoGateFrame_Xpath);                
                int cargoAWBListCount = GetElementCount(cargoAWBList_Xpath);
                int c = 0;
                if (cargoAWBListCount > 0)
                {
                    List<IWebElement> cargoAWBList = GetElements(cargoAWBList_Xpath);
                    List<IWebElement> cartNumberList = GetElements(cartNumber_Xpath);
                    List<IWebElement> cargoDetailsHideBtn = GetElements(cargoDetailsHideBtn_Xpath);
                    List<IWebElement> cargoAWBNos = GetElements(cargoAWBNo_Xpath);
                    List<IWebElement> cargoWeight = GetElements(cargoWeight_Xpath);
                    List<IWebElement> cargoPieces = GetElements(cargoPieces_Xpath);
                    for (int j = 0; j < cargoAWBList.Count; j++)
                    {
                        IWebElement cartNumber = cartNumberList[j];
                        string cartNumberValue = GetAttributeValueFromElement(cartNumber, "value");
                        bool containsSpecificNumbers = Regex.IsMatch(cartNumberValue, @"[1-9]");
                        bool containsAlphabets = Regex.IsMatch(cartNumberValue, @"[a-zA-Z]");
                        c++;
                        if (containsSpecificNumbers && containsAlphabets)
                        {
                            IWebElement cargoDetailsHide = cargoDetailsHideBtn[j];
                            IWebElement cargoAWB = cargoAWBNos[j];
                            IWebElement cargoWeightValue = cargoWeight[j];
                            IWebElement cargoPiecesValue = cargoPieces[j];
                            ClickOnElement(cargoDetailsHide);
                            string awb = GetAttributeValueFromElement(cargoAWB, "value");
                            string weight = GetAttributeValueFromElement(cargoWeightValue, "value");
                            string pieces = GetAttributeValueFromElement(cargoPiecesValue, "value");
                            Assert.AreEqual(awbNum, awb);
                            Assert.AreEqual(piecesNum, pieces);
                            Assert.AreEqual(weightNum, weight);
                            break;
                        }
                        else if(c== cargoAWBListCount)
                        {
                            Console.WriteLine("AWB " +awbNum+" is not available");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No Cargo AWB's available");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void GreenpointLogOut()
        {
            try
            {
                SwitchToMainWindow();
                Click(userProfileBtn_Xpath);
                Click(logOutBtn_Xpath);
                Assert.IsTrue(IsElementDisplayed(logOutConfirmMessage_Xpath));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}


