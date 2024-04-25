using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace iCargoUIAutomation.pages
{
    public class MaintainBookingPage : BasePage
    {
        public MaintainBookingPage(IWebDriver driver) : base(driver)
        {
        }

        private By CAP018Frame_XPATH = By.XPath("//iframe[@name='iCargoContentFrameCAP018']");
        private By New_List_XPATH = By.XPath("//button[@id='btDisplay']");

        // Shipment Details
        private By origin_ID = By.Id("origin");
        private By destination_XPATH = By.XPath("//input[@name='destination']");
        private By agentCode_ID = By.Id("agentCode");
        private By shippingDate_ID = By.Id("shippingDate");
        private By product_XPATH = By.XPath("//input[@name='productName']");
        private By shipperConsigneeBtn_ID = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperDetails_Button");

        // Shipper Details
        private By shipperConsigneePopup_CLASS = By.ClassName("iCargoPopUpContent");
        private By shipperCode_XPATH = By.XPath("//input[@name='shipperCode']");
        private By consigneeCode_XPATH = By.XPath("//input[@name='consigneeCode']");
        private By shipperConsigneeOkBtn_ID = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperConsignee_OK");

        // Commodity Details
        private By bookingPage_XPATH = By.XPath("//div[@class='ic-main-container']");
        private By commoditydetailssection_XPATH = By.XPath("//div[@id='handlingInfRow']");
        private By commodityCode_XPATH = By.XPath("//input[@name='commodityCode']");
        private By pieces_XPATH = By.XPath("//input[@name='pieces']");
        private By weight_XPATH = By.XPath("//input[@name='weight']");

        // Flight Details
        private By flightOrigin_XPATH = By.XPath("//input[@name='flightOrigin']");
        private By flightDestination_XPATH = By.XPath("//input[@name='flightDestination']");
        private By flightNumber_XPATH = By.XPath("//input[@name='flightNumber']");
        private By flightDate_XPATH = By.XPath("//input[@name='flightDate']");
        private By flightPieces_XPATH = By.XPath("//input[@name='flightPieces']");
        private By flightWeight_XPATH = By.XPath("//input[@name='flightWeight']");

        // Generate AWB
        private By saveBtn_ID = By.Id("btSave");

        // Warning Popups
        private By popupAlertMessage_CSS = By.CssSelector(".alert-messages-list");
        private By popupAlertWarningBooking_CSS = By.CssSelector(".alert-messages-ui");
        private By popupAlertMessageBooking_XPATH = By.XPath("//*[@class='alert-messages-list']//span");
        private By btnYesAlertMessageBooking_XPATH = By.XPath("//*[@class='ui-dialog-buttonpane ui-widget-content ui-helper-clearfix']//*[text()=' Yes ']");

        // Booking Summary
        private By bookingSummaryPopup_CSS = By.CssSelector(".iCargoPopUpContent");
        private By awbNumber_XPATH = By.XPath("//label[contains(text(), 'AWB : ')]/b");
        private By btnOkBookingSummaryPopup_XPATH = By.XPath("//button[@id='CMP_Capacity_Booking_BookingSummary_Ok_Button']");


        //Close Maintain Booking Page
        private By btnCloseMb_XPATH = By.Id("CMP_Capacity_Booking_MaintainReservation_Close_Button");

        //Rebook an already executed awb
        private By awbTextbox_ID = By.Id("awbNum_b");
        private By alreadyExecutedPopup_XPATH = By.XPath("//div[@id='app-message-wrap']/div/span");
        private By flightCheckBox_ID = By.Id("shipmentFlightSelectAll");
        private By deleteFlightDetails_ID = By.Id("deleteFlightLink");
        private By addFlight_ID = By.Id("addFlightLink");
        string dynamicflightOrigin = "flightOrigin";
        private By dynamicflightOrigin_ID = By.Id("flightOrigin1");
        string dynamicflightDestination = "flightDestination";
        private By dynamicflightDestination_ID = By.Id("flightDestination1");
        string dynamicflightNumber = "flightNumber";
        private By dynamicflightNumber_ID = By.Id("flightNumber1");
        string dynamicflightDate = "fltDate";
        private By dynamicflightDate_ID = By.Id("fltDate1");
        string dynamicflightPieces = "flightPieces";
        private By dynamicflightPieces_ID = By.Id("flightPieces1");
        private By dynamicflightWeight_XPATH = By.XPath("//input[@name='flightWeight' and @rowcount = '1']");
        private By bookingIrregularityFrame_ID = By.Id("popupContainerFrame");
        private By irregularityscrollhori_XPATH = By.XPath("//div[@class='portlet row form-body scroll-z-index-fix']//div[@class='slimScrollArrowUpX']");
        private By irregularityTextbox_ID = By.Id("irregularityCodeID_00");
        private By irregularityRemarks_XPATH = By.XPath("//textarea[@id='CMP_Operations_Shipment_Cto_CaptureIrregularity_Remarks0']");
        private By irregularitySaveBtn_ID = By.Id("CMP_Operations_Shipment_Ux_Cto_CaptureIrregularity_Ok");


        //AVI Booking Checksheet Details
        private By aviBookingChecksheet_XPATH = By.XPath("//select[@name='questionwithAnswer[0].templateAnswer']");
        private By aviBookingChecksheetOkBtn_XPATH = By.XPath("//button[@id='btnSave']");
        private By aviTotalChkSheetSections_Xpath = By.XPath("//*[@id='tabs-1']//div[@id='configId']/h2");
        private By aviChecksheetframe_XPath = By.XPath("//*[text()='Capture Check Sheet']//parent::div//following-sibling::div/iframe");

        //Attach /Detach AWB
        private By attachDetachBtn_ID = By.Id("btDetach");
        private By attachDetachawbfield_ID = By.Id("awbNumNew_b");
        private By attachDetachpopupBtn_ID = By.Id("CMP_CAPACITY_BOOKING_DETACHAWB_DETACH_BUTTON");

        //Minimum Connection Time for MultiLeg Flight
        private By selectFlightBtn_ID = By.Id("btSelectFlight");
        private By flightSearchtextbox_XPATH = By.XPath("//input[@placeholder='Enter the keywords to search']");
        private By resColor_Xpath = By.XPath("//label[@class='badge-red']");
        private By resErrorMessage_Xpath = By.XPath("//div[@class='fs12 mar-t-xs text-gray multy-list-flight']/p");
        private By multilegFlightsfilter = By.Id("flightsTable-datafiltercontainer");
        private By oneStopFilter_Xpath = By.XPath("//input[@name='stops.stop1']");
        private By twoStopFilter_Xpath = By.XPath("//input[@name='stops.stop2']");
        private By twoplusStopFilter_Xpath = By.XPath("//input[@name='stops.stop2plus']");
        private By filterApplyBtn_Xpath = By.XPath("//button[@id='flightsTable-datafilter-applybtn']");
        private By multilegFlights_Xpath = By.XPath("//div[@data-id='totalNoOfflights']/div/span/strong[1]");

        //Select Flight
        private By cap_Xpath = By.XPath("//label[contains(@id,'capStatus')]");
        private By rest_Xpath = By.XPath("//label[contains(@id,'restStatus')]");
        private By emb_Xpath = By.XPath("//label[contains(@id,'embargoStatus')]");
        private By rate_Xpath = By.XPath("//label[contains(@id,'rateStatus')]");
        private By flightDetailsOkbtn_Xpath = By.XPath("//button[@accesskey='K']");
        private By flightdetailssection_XPATH = By.CssSelector(".table_grid .ReactVirtualized__Table__row");
        private By flightProductCode_Xpath = By.XPath("//div[@class='d-flex justify-content-between']/strong[1]");

        //Unknown Shipper Consignee Details
        private By unkShipperName_ID = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperConsignee_ShipperName_NEW");
        private By unkShipperFirstAddress_ID = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperConsignee_ShipperFirstAddress_NEW");
        private By unkShipperSecondAddress = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperConsignee_ShipperSecondAddress_NEW");
        private By unkShipperCity_ID = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperConsignee_ShipperCity_NEW");
        private By unkShipperState_ID = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperConsignee_ShipperState");
        private By unkShipperCountry_ID = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperConsignee_ShipperCountry");
        private By unkShipperZip_ID = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperConsignee_ShipperPostalCode");
        private By unkShipperEmail_ID = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperConsignee_ShipperEmail");
        private By unkConsigneeName_ID = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperConsignee_ConsigneeName_NEW");
        private By unkConsigneeFirstAddress_ID = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperConsignee_ConsigneeFirstAddress_NEW");
        private By unkConsigneeSecondAddress = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperConsignee_ConsigneeSecondAddress_NEW");
        private By unkConsigneeCity_ID = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperConsignee_ConsigneeCity_NEW");
        private By unkConsigneeState_ID = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperConsignee_ConsigneeState");
        private By unkConsigneeCountry_ID = By.Id("CMP_Capacity_Booking_Permanent_ShipperConsignee_ConsigneeCountry");
        private By unkConsigneeZip_ID = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperConsignee_ConsigneePostalCode");
        private By unkConsigneeEmail_ID = By.Id("CMP_Capacity_Booking_MaintainReservation_ShipperConsignee_ConsigneeEmail");
        public void SwitchToCAP018Frame()
        {
            WaitForElementToBeVisible(CAP018Frame_XPATH, TimeSpan.FromSeconds(10));
            SwitchToFrame(CAP018Frame_XPATH);
        }

        public void ClickNewListButton()
        {
            ClickOnElementIfPresent(New_List_XPATH);
            //Click(New_List_XPATH);
        }

        public void EnterShipmentDetails(string origin, string destination, string shippingDate, string ProductCode)
        {
            EnterText(origin_ID, origin);
            EnterText(destination_XPATH, destination);
            ClickOnElementIfPresent(agentCode_ID);
            int agentcode = 10763;           
            EnterTextWithCheck(agentCode_ID, agentcode.ToString());            
            EnterText(shippingDate_ID, shippingDate);
            EnterText(product_XPATH, ProductCode);
            Click(shipperConsigneeBtn_ID);
        }

        public void EnterShipperConsigneeDetails()
        {
            SwitchToSecondPopupWindow();
            int ShipperCode = 10763;
            int ConsigneeCode = 10763;
            EnterTextWithCheck(shipperCode_XPATH, ShipperCode.ToString());
            EnterTextWithCheck(consigneeCode_XPATH, ConsigneeCode.ToString());            
            Click(shipperConsigneeOkBtn_ID);           
            SwitchToPopupWindow();
        }

        public void EnterCommodityDetails(string commodityCode, string pieces, string weight)
        {
            //WaitForElementToBeVisible(CAP018Frame_XPATH, TimeSpan.FromSeconds(10)); 
            SwitchToCAP018Frame();
            //ClickOnElementIfPresent(bookingPage_XPATH);
            ClickOnElementIfPresent(commodityCode_XPATH);
            Click(commodityCode_XPATH);
            EnterText(commodityCode_XPATH, commodityCode);
            EnterText(pieces_XPATH, pieces);
            EnterText(weight_XPATH, weight);
        }

        public void EnterCarrierDetails(string flightOrigin, string flightDestination, string flightNumber, string flightDate, string flightPieces, string flightWeight)
        {
            EnterText(flightOrigin_XPATH, flightOrigin);
            EnterText(flightDestination_XPATH, flightDestination);
            EnterText(flightNumber_XPATH, flightNumber);
            EnterText(flightDate_XPATH, flightDate);
            EnterText(flightPieces_XPATH, flightPieces);
            EnterText(flightWeight_XPATH, flightWeight);
        }

        public string clickingYesOnPopupWarnings()
        {
            string errorText = "";
            SwitchToDefaultContent();

            if (IsElementDisplayed(popupAlertWarningBooking_CSS))
            {
                errorText = GetText(popupAlertMessageBooking_XPATH);
                Click(btnYesAlertMessageBooking_XPATH);
            }
            //SwitchToCAP018Frame();
            return errorText;
        }

        public void ClickSaveButton()
        {
            int noOfWindowsBefore = GetNumberOfWindowsOpened();
            Click(saveBtn_ID);          
            clickingYesOnPopupWarnings();
            clickingYesOnPopupWarnings();
            WaitForNewWindowToOpen(TimeSpan.FromSeconds(10), noOfWindowsBefore + 1);
            int noOfWindowsAfter = GetNumberOfWindowsOpened();
            if (noOfWindowsAfter > noOfWindowsBefore)
            {
                SwitchToLastWindow();
                WaitForElementToBeVisible(awbNumber_XPATH, TimeSpan.FromSeconds(10));
                string awbNumber = GetText(awbNumber_XPATH);
                Console.WriteLine(awbNumber); 
                Thread.Sleep(5000);                
                Click(btnOkBookingSummaryPopup_XPATH);
                SwitchToLastWindow();
                SwitchToCAP018Frame();
            }
            ClickOnElementIfPresent(btnCloseMb_XPATH);
        }

        public void EnterAWBNumber(string awbNumber)
        {
            //SwitchToCAP018Frame();
            EnterText(awbTextbox_ID, awbNumber);
        }

        public void DeleteAddFlights()
        {
            try
            {
                SwitchToPopupWindow();
                WaitForElementToBeVisible(alreadyExecutedPopup_XPATH, TimeSpan.FromSeconds(10));
                string alreadyExecutedPopUp = GetText(alreadyExecutedPopup_XPATH);
                Console.WriteLine(alreadyExecutedPopUp);
                SwitchToCAP018Frame();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            ClickOnElementIfPresent(flightCheckBox_ID);
            WaitForElementToBeVisible(deleteFlightDetails_ID, TimeSpan.FromSeconds(10));
            Click(deleteFlightDetails_ID);
            WaitForElementToBeVisible(addFlight_ID, TimeSpan.FromSeconds(10));
            Click(addFlight_ID);
        }

        public void addNewFlightDetails(string fltorg, string fltdest, string fltNbr, string fltDt, string fltPcs, string fltWgt)
        {
            EnterText(dynamicflightOrigin_ID, fltorg);

            EnterText(dynamicflightDestination_ID, fltdest);

            EnterText(dynamicflightNumber_ID, fltNbr);

            EnterText(dynamicflightDate_ID, fltDt);

        }

        public void CaptureIrregularity()
        {
            SwitchToFrame(bookingIrregularityFrame_ID);
            Console.WriteLine("Switched to Irregularity Frame");            
            EnterTextToDropdown(irregularityTextbox_ID, "Booking - Incomplete or inaccurate");            
            DoubleClick(irregularityscrollhori_XPATH);
            Click(irregularityRemarks_XPATH);
            EnterText(irregularityRemarks_XPATH, "test");
            int noOfWindowsBefore = GetNumberOfWindowsOpened();
            Click(irregularitySaveBtn_ID);
            WaitForNewWindowToOpen(TimeSpan.FromSeconds(10), noOfWindowsBefore + 1);
            int noOfWindowsAfter = GetNumberOfWindowsOpened();
            if (noOfWindowsAfter > noOfWindowsBefore)
            {
                SwitchToLastWindow();
                WaitForElementToBeVisible(awbNumber_XPATH, TimeSpan.FromSeconds(10));
                string awbNumber = GetText(awbNumber_XPATH);
                Console.WriteLine(awbNumber);
                WaitForElementToBeVisible(btnOkBookingSummaryPopup_XPATH, TimeSpan.FromSeconds(10));
                Click(btnOkBookingSummaryPopup_XPATH);
                SwitchToLastWindow();
                SwitchToCAP018Frame();
            }
            ClickOnElementIfPresent(btnCloseMb_XPATH);
        }

        public void clickOnSaveButtonToSaveNewFlightDetails()
        {
            Click(saveBtn_ID);
        }

        public void AVIBookingChecksheetDetails()
        {
            int noOfWindowsBefore = GetNumberOfWindowsOpened();
            clickOnSaveButtonToSaveNewFlightDetails();
           clickingYesOnPopupWarnings();
            SwitchToCAP018Frame();       
            SwitchToFrame(aviChecksheetframe_XPath);
            Console.WriteLine("Switched to Irregularity Frame");            
            List<IWebElement> AviChecksheetSections = GetElements(aviTotalChkSheetSections_Xpath);           
            int totalQuestions = 0;

            foreach (var section in AviChecksheetSections)
            {
                if (section.Text == "AVIHDL Statement")
                {

                    string drpDwnQn = "//*[@id='tabs-1']//div[@id='configId']/h2[text()='aviSectionName']/parent::div/following-sibling::div//select";

                    drpDwnQn = drpDwnQn.Replace("aviSectionName", "AVIHDL Statement");
                    totalQuestions = GetElementCount(By.XPath(drpDwnQn));
                    drpDwnQn = drpDwnQn + "[@name= 'questionwithAnswer[0].templateAnswer']";
                    if (!IsDropdownSelectedByVisibleText((By.XPath(drpDwnQn)), "Yes"))
                    {
                        for (int j = 0; j < totalQuestions; j++)
                        {
                            SelectDropdownByVisibleText(By.XPath(drpDwnQn.Replace("0", j.ToString())), "Yes");
                            EnterKeys(By.XPath(drpDwnQn), Keys.Tab);
                        }
                    }

                }
                else if (section.Text == "AVI Booking")
                {
                    string drpDwnQn = "//*[@id='tabs-1']//div[@id='configId']/h2[text()='aviSectionName']/parent::div/following-sibling::div//select";

                    drpDwnQn = drpDwnQn.Replace("aviSectionName", "AVI Booking");
                    totalQuestions = GetElementCount(By.XPath(drpDwnQn));
                    drpDwnQn = drpDwnQn + "[@name= 'questionwithAnswer[0].templateAnswer']";
                    if (!IsDropdownSelectedByVisibleText((By.XPath(drpDwnQn)), "Yes"))
                    {
                        for (int j = 0; j < totalQuestions; j++)
                        {
                            SelectDropdownByVisibleText(By.XPath(drpDwnQn.Replace("0", j.ToString())), "Yes");
                            EnterKeys(By.XPath(drpDwnQn), Keys.Tab);
                        }

                    }

                }
            }
            Click(aviBookingChecksheetOkBtn_XPATH);
            SwitchToCAP018Frame();
            ClickSaveButton();
        }

        public void AttachOrDetachAWB()
        {            
            ClickOnElementIfPresent(attachDetachBtn_ID);            
            SwitchToSecondPopupWindow();
            WaitForElementToBeVisible(shipperConsigneePopup_CLASS, TimeSpan.FromSeconds(10));            
            ClearText(attachDetachawbfield_ID);
            Click(attachDetachpopupBtn_ID);
            SwitchToPopupWindow();
            SwitchToCAP018Frame();            
        }

        public void EnterNewAgentCode(string agentcode)
        {
            EnterTextWithCheck(agentCode_ID, agentcode);
        }

        //public void MultilegFlightSearch(string flightnbrs)
        //{
        //    Click(selectFlightBtn_ID);
        //    SwitchToFrame(bookingIrregularityFrame_ID);
        //    WaitForElementToBeVisible(flightSearchtextbox_XPATH, TimeSpan.FromSeconds(10));
        //    EnterTextWithCheck(flightSearchtextbox_XPATH, flightnbrs);            
        //}

        //public void VerifyMinimumConnectionTimeWarning(string rescolor,string mincontimewarning)
        //{
        //    string resattribute = GetAttributeValue(resColor_Xpath, "class");
        //    string resColor = resattribute.Split('-')[1];
        //    Console.WriteLine(resColor);
        //    Assert.AreEqual(rescolor, resColor);
        //    Click(resColor_Xpath);
        //    string resErrorMessage = GetText(resErrorMessage_Xpath);
        //    Assert.AreEqual(mincontimewarning, resErrorMessage);
        //    Console.WriteLine(resErrorMessage);
        //}

        public void AWBBookingfromStock()
        {
            try
            {
                SwitchToPopupWindow();
                WaitForElementToBeVisible(alreadyExecutedPopup_XPATH, TimeSpan.FromSeconds(10));
                string alreadyExecutedPopUp = GetText(alreadyExecutedPopup_XPATH);
                Console.WriteLine(alreadyExecutedPopUp);
                SwitchToCAP018Frame();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UnknownAgentShipmentDetails(string org, string dest, string agtcode, string shippdt, string prodcode)
        {
            EnterText(origin_ID, org);
            EnterText(destination_XPATH, dest);
            ClickOnElementIfPresent(agentCode_ID);           
            EnterTextWithCheck(agentCode_ID, agtcode.ToString());
            EnterText(shippingDate_ID, shippdt);
            EnterText(product_XPATH, prodcode);
            Click(shipperConsigneeBtn_ID);
        }

        public void UnknownShipperConsigneeDetails(string shipper, string consg)
        {
            SwitchToSecondPopupWindow();           
            EnterTextWithCheck(shipperCode_XPATH, shipper);
            EnterTextWithCheck(consigneeCode_XPATH, consg);            
            Click(shipperConsigneeOkBtn_ID);            
            SwitchToPopupWindow();
        }

        public void UnknownShipperConsigneeALLDetails(string unkshppr, string unkconsgn)
        {
            SwitchToSecondPopupWindow();
            EnterText(shipperCode_XPATH, unkshppr);
            string shipperName = "Test Shipper";
            EnterTextWithCheck(unkShipperName_ID, shipperName);
            string shipperFirstAddress = "Test Address1";
            EnterTextWithCheck(unkShipperFirstAddress_ID, shipperFirstAddress);
            string shipperSecondAddress = "Test Address2";
            EnterTextWithCheck(unkShipperSecondAddress, shipperSecondAddress);
            string shipperCity = "Test City";
            EnterTextWithCheck(unkShipperCity_ID, shipperCity);
            string shipperState = "Test State";
            EnterTextWithCheck(unkShipperState_ID, shipperState);
            string shipperCountry = "US";
            EnterTextWithCheck(unkShipperCountry_ID, shipperCountry);
            string shipperZip = "67890";
            EnterTextWithCheck(unkShipperZip_ID, shipperZip);
            string shipperEmail = "TEST@GMAIL.COM.INVALID";
            EnterTextWithCheck(unkShipperEmail_ID, shipperEmail);
            EnterText(consigneeCode_XPATH, unkconsgn);
            string consigneeName = "Test Consignee";
            EnterTextWithCheck(unkConsigneeName_ID, consigneeName);
            string consigneeFirstAddress = "Test Address1";
            EnterTextWithCheck(unkConsigneeFirstAddress_ID, consigneeFirstAddress);
            string consigneeSecondAddress= "Test Address2";
            EnterTextWithCheck(unkConsigneeSecondAddress, consigneeSecondAddress);
            string consigneeCity = "Test City";
            EnterTextWithCheck(unkConsigneeCity_ID, consigneeCity);
            string consigneeState = "Test State";
            EnterTextWithCheck(unkConsigneeState_ID, consigneeState);
            string consigneeCountry = "US";
            EnterTextWithCheck(unkConsigneeCountry_ID, consigneeCountry);
            string consigneeZip = "67890";
            EnterTextWithCheck(unkConsigneeZip_ID, consigneeZip);
            string consigneeEmail = "TEST@GMAIL.COM.INVALID";
            EnterTextWithCheck(unkConsigneeEmail_ID, consigneeEmail);            
            Click(shipperConsigneeOkBtn_ID);            
            SwitchToPopupWindow();
        }

        public void SelectFlight()
        {
            Click(selectFlightBtn_ID);
            SwitchToFrame(bookingIrregularityFrame_ID);
            WaitForElementToBeVisible(flightdetailssection_XPATH, TimeSpan.FromSeconds(20));
            var noofflights = GetElements(flightdetailssection_XPATH);
            string productcode = GetText(flightProductCode_Xpath);
            string capColor = GetAttributeValue(cap_Xpath, "class");
            string rescolor = GetAttributeValue(rest_Xpath, "class");
            string embcolor = GetAttributeValue(emb_Xpath, "class");
            string ratecolor = GetAttributeValue(rate_Xpath, "class");
            foreach (var item in noofflights)
            {
                if (productcode == "GENERAL")
                {
                    if (capColor != "badge-red" && rescolor != "badge-red" && embcolor != "badge-red" && ratecolor != "badge-red")
                    {
                        Click(By.XPath("//strong[text()='GENERAL']/parent::div/parent::div/parent::div"));
                        Click(flightDetailsOkbtn_Xpath);
                        break;
                    }
                }
                else if (productcode == "PRIORITY")
                {
                    if (capColor != "badge-red" && rescolor != "badge-red" && embcolor != "badge-red" && ratecolor != "badge-red")
                    {
                        Click(By.XPath("//strong[text()='PRIORITY']/parent::div/parent::div/parent::div"));
                        Click(flightDetailsOkbtn_Xpath);
                        break;
                    }
                }
                else if (productcode == "EMPLOYEE SHIPMENT")
                {
                    if (capColor != "badge-red" && rescolor != "badge-red" && embcolor != "badge-red" && ratecolor != "badge-red")
                    {
                        Click(By.XPath("//strong[text()='EMPLOYEE SHIPMENT']/parent::div/parent::div/parent::div"));
                        Click(flightDetailsOkbtn_Xpath);
                        break;
                    }
                }
                else if (productcode == "GOLDSTREAK")
                {
                    if (capColor != "badge-red" && rescolor != "badge-red" && embcolor != "badge-red" && ratecolor != "badge-red")
                    {
                        Click(By.XPath("//strong[text()='GOLDSTREAK']/parent::div/parent::div/parent::div"));
                        Click(flightDetailsOkbtn_Xpath);
                        break;
                    }
                }
                else if (productcode == "PET CONNECT")
                {
                    if (capColor != "badge-red" && rescolor != "badge-red" && embcolor != "badge-red" && ratecolor != "badge-red")
                    {
                        Click(By.XPath("//strong[text()='PET CONNECT']/parent::div/parent::div/parent::div"));
                        Click(flightDetailsOkbtn_Xpath);
                        break;
                    }
                }
            }
            SwitchToCAP018Frame();
        }

        public void selectMultilegflight(string rescolor, string mincontimewarning)
        {
            Click(selectFlightBtn_ID);
            SwitchToFrame(bookingIrregularityFrame_ID);
            Click(multilegFlightsfilter);
            Click(oneStopFilter_Xpath);
            Click(twoStopFilter_Xpath);
            Click(twoplusStopFilter_Xpath);
            Click(filterApplyBtn_Xpath);
            var noofflights = GetElements(flightdetailssection_XPATH);
            string productcode = GetText(flightProductCode_Xpath);
            foreach (var item in noofflights)
            {
                string resattribute = GetAttributeValue(rest_Xpath, "class");
                string noofflightscount = GetText(multilegFlights_Xpath);
                int count = int.Parse(noofflightscount);
                if (count >= 2)
                {
                    if (resattribute == "badge-red" && productcode == "GENERAL")
                    {
                        string resColors = resattribute.Split('-')[1];
                        Console.WriteLine(resColors);
                        Assert.AreEqual(rescolor, resColors);
                        Click(resColor_Xpath);
                        string resErrorMessage = GetText(resErrorMessage_Xpath);
                        Assert.AreEqual(mincontimewarning, resErrorMessage);
                        Console.WriteLine(resErrorMessage);
                        break;
                    }
                    if (resattribute == "badge-red" && productcode == "PRIORITY")
                    {
                        string resColors = resattribute.Split('-')[1];
                        Console.WriteLine(resColors);
                        Assert.AreEqual(rescolor, resColors);
                        Click(resColor_Xpath);
                        string resErrorMessage = GetText(resErrorMessage_Xpath);
                        Assert.AreEqual(mincontimewarning, resErrorMessage);
                        Console.WriteLine(resErrorMessage);
                        break;
                    }
                    if (resattribute == "badge-red" && productcode == "GOLDSTREAK")
                    {
                        string resColors = resattribute.Split('-')[1];
                        Console.WriteLine(resColors);
                        Assert.AreEqual(rescolor, resColors);
                        Click(resColor_Xpath);
                        string resErrorMessage = GetText(resErrorMessage_Xpath);
                        Assert.AreEqual(mincontimewarning, resErrorMessage);
                        Console.WriteLine(resErrorMessage);
                        break;
                    }
                    if (resattribute == "badge-red" && productcode == "PET CONNECT")
                    {
                        string resColors = resattribute.Split('-')[1];
                        Console.WriteLine(resColors);
                        Assert.AreEqual(rescolor, resColors);
                        Click(resColor_Xpath);
                        string resErrorMessage = GetText(resErrorMessage_Xpath);
                        Assert.AreEqual(mincontimewarning, resErrorMessage);
                        Console.WriteLine(resErrorMessage);
                        break;
                    }
                }
            }
        }
    }

}

