using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private By ahmConfig_Xpath = By.XPath("//*[@test-locator='cargoGate']");
        private By ahmProceed_Id = By.Id("proceedButton");
        private By numberFilter_Xpath = By.XPath("//*[@data-name='NUMBER']");

        public void ClickOnAgentSelectEnterBtn()
        {
            Click(agentSelectEnterBtn_Xpath);
        }

        public void ChooseAssignment()
        {
            Click(flightMonitorBtn_Xpath);
            Click(saveAssignmentBtn_Xpath);
        }

        public void SearchFlight(string flightNumber)
        {
            Click(searchFlight_Xpath); 
            EnterKeys(searchFlight_Xpath, flightNumber);
            Click(flightSearchBtn_Xpath);
            SwitchToNewWindow();
            List<IWebElement> flightList = GetElements(flightList_Xpath);
            List<IWebElement> flightNbrs = GetElements(flightNbr_Xpath); 
            List<IWebElement> cargoListBtn = GetElements(cargoList_Xpath);

            for(int i=0;i<flightList.Count;i++)
            {
                IWebElement flightDetails = flightNbrs[i];               
                string flightDate = flightDetails.Text.Substring(flightDetails.Text.Length - 2);
                if (flightDate == DateTime.Now.ToString("dd"))
                {
                    IWebElement cargoBtn = cargoListBtn[i];
                    ClickOnElement(cargoBtn);
                    SwitchToNewWindow();
                    //SwitchToDefaultContent();
                    //int a = GetNumberOfWindowsOpened();
                    //SwitchToPopupWindow();
                    Console.WriteLine(GetTitle());
                    if (IsElementDisplayed(ahmConfig_Xpath))
                    {
                        Click(ahmProceed_Id);
                    }
                    else
                    {
                        Click(numberFilter_Xpath);
                    }
                    break;
                }                
                if (i == flightList.Count - 1)
                {
                    Click(nextPageFlightList_Xpath);
                    i = 0;
                }
            }
        }
    }
}
