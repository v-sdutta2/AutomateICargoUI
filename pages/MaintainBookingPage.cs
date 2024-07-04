﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using FluentAssertions.Execution;
using iCargoUIAutomation.Hooks;
using log4net;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V121.Debugger;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace iCargoUIAutomation.pages
{

    public class MaintainBookingPage : BasePage
    {
        string shippingDate = DateTime.Now.ToString("dd-MMM-yyyy");
        string presentdate = DateTime.Now.ToString("dd-MMM");
        public static string firstflightnum = "";      
        public static string awbNumber = "";                             
        ILog Log = LogManager.GetLogger(typeof(MaintainBookingPage));

        public MaintainBookingPage(IWebDriver driver) : base(driver)
        {
        }

        private By CAP018Frame_XPATH = By.XPath("//iframe[@name='iCargoContentFrameCAP018']");
        private By newList_XPATH = By.XPath("//button[@id='btDisplay']");
        private By homePage_CSS = By.CssSelector(".ic-home-tab");
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
        private By commoityDetailSection_XPATH = By.XPath("//div[@id='handlingInfRow']");
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
        string dynamicFlightOrigin = "flightOrigin";
        private By dynamicFlightOrigin_ID = By.Id("flightOrigin1");
        string dynamicFlightDestination = "flightDestination";
        private By dynamicFlightDestination_ID = By.Id("flightDestination1");
        string dynamicFlightNumber = "flightNumber";
        private By dynamicFlightNumber_ID = By.Id("flightNumber1");
        string dynamicFlightDate = "fltDate";
        private By dynamicFlightDate_ID = By.Id("fltDate1");
        string dynamicFlightPieces = "flightPieces";
        private By dynamicFlightPieces_ID = By.Id("flightPieces1");
        private By dynamicFlightWeight_XPATH = By.XPath("//input[@name='flightWeight' and @rowcount = '1']");
        private By bookingIrregularityFrame_ID = By.Id("popupContainerFrame");
        private By irregularityScrollHori_XPATH = By.XPath("//div[@class='portlet row form-body scroll-z-index-fix']//div[@class='slimScrollArrowUpX']");
        private By irregularityTextbox_ID = By.Id("irregularityCodeID_00");
        private By irregularityRemarks_XPATH = By.XPath("//textarea[@id='CMP_Operations_Shipment_Cto_CaptureIrregularity_Remarks0']");
        private By irregularitySaveBtn_ID = By.Id("CMP_Operations_Shipment_Ux_Cto_CaptureIrregularity_Ok");
        private By selectFlightBtn_Xpath = By.XPath("//div[@class='ReactVirtualized__Table__rowColumn']//button[text()='Select']");
        private By rebookFlightDetails_Xpath = By.XPath("//div[@aria-colindex='6']/div/span/strong/label");
        private By rebookSelectFlightbtn_Xpath = By.XPath("//div[@aria-colindex='8']/div/button");
        private By rebookRateStatus_btn_Xpath = By.XPath("//div[@data-id='rateIndicator']");

        //AVI Booking Checksheet Details
        private By aviBookingChecksheet_XPATH = By.XPath("//select[@name='questionwithAnswer[0].templateAnswer']");
        private By aviBookingChecksheetOkBtn_XPATH = By.XPath("//button[@id='btnSave']");
        private By aviTotalChkSheetSections_Xpath = By.XPath("//*[@id='tabs-1']//div[@id='configId']/h2");
        private By aviChecksheetFrame_XPath = By.XPath("//*[text()='Capture Check Sheet']//parent::div//following-sibling::div/iframe");

        //Attach /Detach AWB
        private By attachDetachBtn_ID = By.Id("btDetach");
        private By attachDetachAwbField_ID = By.Id("awbNumNew_b");
        private By attachDetachPopupBtn_ID = By.Id("CMP_CAPACITY_BOOKING_DETACHAWB_DETACH_BUTTON");
        private By clearAWBBtn_ID = By.Id("btClear");               //new line added

        //Minimum Connection Time for MultiLeg Flight
        private By selectFlightBtn_ID = By.Id("btSelectFlight");
        private By flightSearchTextBox_XPATH = By.XPath("//input[@placeholder='Enter the keywords to search']");
        private By resColor_Xpath = By.XPath("//label[@class='badge-red']");
        private By resErrorMessage_Xpath = By.XPath("//div[@class='fs12 mar-t-xs text-gray multy-list-flight']/p");
        private By multilegFlightsfilter = By.XPath("//div[@id='flightsTable-datafilter']/i");
        private By flightSearchBox_Xpath = By.XPath("//input[@placeholder='Enter the keywords to search']");
        private By oneStopFilter_Xpath = By.XPath("//input[@name='stops.stop1']");
        private By twoStopFilter_Xpath = By.XPath("//input[@name='stops.stop2']");
        private By twoplusStopFilter_Xpath = By.XPath("//input[@name='stops.stop2plus']");
        private By filterApplyBtn_Xpath = By.XPath("//button[@id='flightsTable-datafilter-applybtn']");
        private By multilegFlights_Xpath = By.XPath("//div[@data-id='totalNoOfflights']/div/span/strong[1]");
        private By selectFlightError_Xpath = By.XPath("//div[(@class='errorrow row')]/div[2]/p");

        //Select Flight
        private By cap_Xpath = By.XPath("//label[contains(@id,'capStatus')]");
        private By rest_Xpath = By.XPath("//label[contains(@id,'restStatus')]");
        private By emb_Xpath = By.XPath("//label[contains(@id,'embargoStatus')]");
        private By rate_Xpath = By.XPath("//label[contains(@id,'rateStatus')]");
        private By flightDetailsOkbtn_Xpath = By.XPath("//button[@accesskey='K']");
        private By flightDetailsSection_XPATH = By.CssSelector(".table_grid .ReactVirtualized__Table__row");
        private By flightProductCode_Xpath = By.XPath("//div[@class='d-flex justify-content-between']/strong[1]");
        private By flightDate_Xpath = By.XPath("//div[@data-id='departureArrivalDate']");
        private By flightDepartureTime_Xpath = By.XPath("//div[@data-id='departureTime']");
        private By selectFlightNumber_Xpath = By.XPath("//div[contains(@class, 'ReactVirtualized__Table__rowColumn')]//strong[@class='align-self-center']/label");
        private By generalProdBtn_Xpath = By.XPath("//strong[text()='GENERAL']/parent::div/parent::div/parent::div");
        private By priorityProdBtn_Xpath = By.XPath("//strong[text()='PRIORITY']/parent::div/parent::div/parent::div");
        private By employeeProdBtn_Xpath = By.XPath("//strong[text()='EMPLOYEE SHIPMENT']/parent::div/parent::div/parent::div");
        private By goldstreakProdBtn_Xpath = By.XPath("//strong[text()='GOLDSTREAK']/parent::div/parent::div/parent::div");
        private By petConnectProdBtn_Xpath = By.XPath("//strong[text()='PET CONNECT']/parent::div/parent::div/parent::div");
        private By destinationErrorPopup_Xpath = By.XPath("//div[@id='error-body']/div/span");

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
            try
            {
                SwitchToFrame(CAP018Frame_XPATH);
                Log.Info("Switched to CAP018 Frame");

            }
            catch (Exception e)
            {
                Log.Error("Error in Switching to CAP018 Frame: " + e.Message);
            }
        }

        public void ClickNewListButton()
        {
            Hooks.Hooks.createNode();
            try
            {
                WaitForElementToBeInvisible(homePage_CSS, TimeSpan.FromSeconds(5));
                ClickOnElementIfPresent(newList_XPATH);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked New List Button");
                Log.Info("Clicked New List Button"); 
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Clicking New List Button: " + e.Message);
                Log.Error("Error in Clicking New List Button: " + e.Message);
            }
        }

        public void EnterShipmentDetails(string origin, string destination, string ProductCode)
        {
            Hooks.Hooks.createNode();
            try
            {
                //WaitForElementToBeVisible(origin_ID, TimeSpan.FromSeconds(15));
                WaitForElementToBeInvisible(homePage_CSS, TimeSpan.FromSeconds(5));                                                                                                                                                                  
                if (IsElementEnabled(origin_ID) && CheckForValueInTextbox(origin_ID,origin)==false)
                {
                    EnterTextWithCheck(origin_ID, origin);
                    Hooks.Hooks.UpdateTest(Status.Pass, "Entered Origin: " + origin);
                    Log.Info("Entered Origin: " + origin);
                }
                EnterText(destination_XPATH, destination);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Destination: " + destination);
                Log.Info("Entered Destination: " + destination);
                ClickOnElementIfPresent(agentCode_ID);
                if (CheckForValueInTextbox(agentCode_ID, "A1001") == true)
                {
                    int agentCode = 10763;
                    EnterTextWithCheck(agentCode_ID, agentCode.ToString());
                    Hooks.Hooks.UpdateTest(Status.Pass, "Entered Agent Code: " + agentCode);
                    Log.Info("Entered Agent Code: " + agentCode);
                }
                    EnterText(shippingDate_ID, shippingDate);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Shipping Date: " + shippingDate);
                Log.Info("Entered Shipping Date: " + shippingDate);
                EnterText(product_XPATH, ProductCode);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Product Code: " + ProductCode);
                Log.Info("Entered Product Code: " + ProductCode);
                Click(shipperConsigneeBtn_ID);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on Shipper Consignee Button");
                Log.Info("Clicked on Shipper Consignee Button");
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Entering Shipment Details: " + e.Message);
                Log.Error("Error in Entering Shipment Details: " + e.Message);
            }
        }

        public void EnterShipperConsigneeDetails()
        {
            Hooks.Hooks.createNode();
            try
            {
                GetNumberOfWindowsOpened();
                SwitchToSecondPopupWindow();
                int ShipperCode = 10763;
                int ConsigneeCode = 10763;
                WaitForElementToBeInvisible(CAP018Frame_XPATH, TimeSpan.FromSeconds(10));
                EnterText(shipperCode_XPATH, ShipperCode.ToString());
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Shipper Code: " + ShipperCode);
                Log.Info("Entered Shipper Code: " + ShipperCode);
                if (IsElementEnabled(unkShipperName_ID))
                {
                    ClickOnElementIfPresent(unkShipperName_ID);
                    EnterKeys(unkShipperName_ID, Keys.Tab);
                }
                EnterText(consigneeCode_XPATH, ConsigneeCode.ToString());
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Consignee Code: " + ConsigneeCode);
                Log.Info("Entered Consignee Code: " + ConsigneeCode);
                Click(unkConsigneeName_ID);
                ClickOnElementIfPresent(shipperConsigneeOkBtn_ID);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on Shipper Consignee OK Button");
                Log.Info("Clicked on Shipper Consignee OK Button");
                SwitchToPopupWindow();
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Entering Shipper Consignee Details: " + e.Message);
                Log.Error("Error in Entering Shipper Consignee Details: " + e.Message);
            }
        }

        public void EnterCommodityDetails(string commodityCode, string pieces, string weight)
        {
            Hooks.Hooks.createNode();
            try
            {
                SwitchToCAP018Frame();
                WaitForElementToBeVisible(commodityCode_XPATH, TimeSpan.FromSeconds(10));
                ClickOnElementIfPresent(commodityCode_XPATH);
                Click(commodityCode_XPATH);
                EnterText(commodityCode_XPATH, commodityCode);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Commodity Code: " + commodityCode);
                Log.Info("Entered Commodity Code: " + commodityCode);
                EnterText(pieces_XPATH, pieces);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Pieces: " + pieces);
                Log.Info("Entered Pieces: " + pieces);
                EnterText(weight_XPATH, weight);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Weight: " + weight);
                Log.Info("Entered Weight: " + weight);
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Entering Commodity Details: " + e.Message);
                Log.Error("Error in Entering Commodity Details: " + e.Message);
            }
        }

        public void EnterCarrierDetails(string flightOrigin, string flightDestination, string flightNumber, string flightDate, string flightPieces, string flightWeight)
        {
            Hooks.Hooks.createNode();
            try
            {
                EnterText(flightOrigin_XPATH, flightOrigin);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Flight Origin: " + flightOrigin);
                Log.Info("Entered Flight Origin: " + flightOrigin);
                EnterText(flightDestination_XPATH, flightDestination);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Flight Destination: " + flightDestination);
                Log.Info("Entered Flight Destination: " + flightDestination);
                EnterText(flightNumber_XPATH, flightNumber);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Flight Number: " + flightNumber);
                Log.Info("Entered Flight Number: " + flightNumber);
                EnterText(flightDate_XPATH, flightDate);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Flight Date: " + flightDate);
                Log.Info("Entered Flight Date: " + flightDate);
                EnterText(flightPieces_XPATH, flightPieces);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Flight Pieces: " + flightPieces);
                Log.Info("Entered Flight Pieces: " + flightPieces);
                EnterText(flightWeight_XPATH, flightWeight);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Flight Weight: " + flightWeight);
                Log.Info("Entered Flight Weight: " + flightWeight);
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Entering Carrier Details: " + e.Message);
                Log.Error("Error in Entering Carrier Details: " + e.Message);
            }
        }

        public string clickingYesOnPopupWarnings()
        {
            string errorText = "";
            SwitchToDefaultContent();

            if (IsElementDisplayed(popupAlertWarningBooking_CSS))
            {
                errorText = GetText(popupAlertMessageBooking_XPATH);
                WaitForElementToBeVisible(btnYesAlertMessageBooking_XPATH, TimeSpan.FromSeconds(10));
                Click(btnYesAlertMessageBooking_XPATH);
            }
            return errorText;
        }

        public void ClickSaveButton()
        {
            Hooks.Hooks.createNode();
            try
            {                
                int noOfWindowsBefore = GetNumberOfWindowsOpened();
                WaitForElementToBeInvisible(flightDetailsOkbtn_Xpath, TimeSpan.FromSeconds(15));
                ClickOnElementIfPresent(saveBtn_ID);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Save Button");
                Log.Info("Clicked Save Button");
                clickingYesOnPopupWarnings();
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Yes on Popup Warnings");
                Log.Info("Clicked Yes on Popup Warnings");
                WaitForNewWindowToOpen(TimeSpan.FromSeconds(20), noOfWindowsBefore + 1);
                int noOfWindowsAfter = GetNumberOfWindowsOpened();
                if (noOfWindowsAfter > noOfWindowsBefore)
                {
                    SwitchToLastWindow();
                    Log.Info("Switched to Last Window");
                    WaitForElementToBeInvisible(btnYesAlertMessageBooking_XPATH, TimeSpan.FromSeconds(15));
                    WaitForElementToBeVisible(awbNumber_XPATH, TimeSpan.FromSeconds(15));
                    awbNumber = GetText(awbNumber_XPATH);
                    Hooks.Hooks.UpdateTest(Status.Pass, "AWB Number: " + awbNumber);
                    Log.Info("AWB Number: " + awbNumber);                                        
                    if (IsElementEnabled(btnOkBookingSummaryPopup_XPATH))
                    {
                        WaitForElementToBeClickable(btnOkBookingSummaryPopup_XPATH, TimeSpan.FromSeconds(10));
                        Click(btnOkBookingSummaryPopup_XPATH);
                        Hooks.Hooks.UpdateTest(Status.Pass, "Clicked OK Button on Booking Summary Popup");
                        Log.Info("Clicked OK Button on Booking Summary Popup");
                    }
                    SwitchToLastWindow();
                    Log.Info("Switched to Last Window");
                    SwitchToCAP018Frame();
                    Log.Info("Switched to CAP018 Frame");
                }
                ClickOnElementIfPresent(clearAWBBtn_ID);   //new lines added
                //ClickOnElementIfPresent(btnCloseMb_XPATH);
                //Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Close Button on Maintain Booking Page");
                //Log.Info("Clicked Close Button on Maintain Booking Page");
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Clicking Save Button: " + e.Message);
                Log.Error("Error in Clicking Save Button: " + e.Message);
            }
        }


        public void EnterAWBNumber()
        {
            Hooks.Hooks.createNode();
            try
            {
                Click(clearAWBBtn_ID);   //new lines added
                awbNumber = awbNumber.Split('-')[1];
                EnterText(awbTextbox_ID, awbNumber);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered AWB Number: " + awbNumber);
                Log.Info("Entered AWB Number: " + awbNumber);
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Entering AWB Number: " + e.Message);
                Log.Error("Error in Entering AWB Number: " + e.Message);
            }
        }

        public void EnterAWBNumberFromStock(string awb)  // new method
        {
            Hooks.Hooks.createNode();
            try
            {                
                EnterText(awbTextbox_ID, awb);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered AWB Number: " + awb);
                Log.Info("Entered AWB Number: " + awb);
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Entering AWB Number: " + e.Message);
                Log.Error("Error in Entering AWB Number: " + e.Message);
            }
        }

        public void DeleteAddFlights()
        {
            Hooks.Hooks.createNode();
            try
            {
                SwitchToPopupWindow();
                Log.Info("Switched to Popup Window");
                WaitForElementToBeVisible(alreadyExecutedPopup_XPATH, TimeSpan.FromSeconds(10));
                string alreadyExecutedPopUp = GetText(alreadyExecutedPopup_XPATH);
                Hooks.Hooks.UpdateTest(Status.Pass, "Already Executed Popup: " + alreadyExecutedPopUp);
                Log.Info("Already Executed Popup: " + alreadyExecutedPopUp);
                SwitchToCAP018Frame();
                Log.Info("Switched to CAP018 Frame");
                firstflightnum = GetAttributeValue(flightNumber_XPATH, "value");
                Log.Info("First Flight Number: " + firstflightnum);
                ClickOnElementIfPresent(flightCheckBox_ID);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on Flight Check Box");
                Log.Info("Clicked on Flight Check Box");
                WaitForElementToBeVisible(deleteFlightDetails_ID, TimeSpan.FromSeconds(10));
                Click(deleteFlightDetails_ID);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on Delete Flight Details");
                Log.Info("Clicked on Delete Flight Details");
                WaitForElementToBeVisible(addFlight_ID, TimeSpan.FromSeconds(10));
                Click(addFlight_ID);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on Add Flight Details");
                Log.Info("Clicked on Add Flight Details");
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Deleting and Adding Flights: " + e.Message);
                Log.Error("Error in Deleting and Adding Flights: " + e.Message);
            }
        }



        public void CaptureIrregularity()
        {
            Hooks.Hooks.createNode();
            try
            {
                WaitForElementToBeInvisible(CAP018Frame_XPATH, TimeSpan.FromSeconds(10));
                SwitchToFrame(bookingIrregularityFrame_ID);
                Log.Info("Switched to Irregularity Frame");
                EnterTextToDropdown(irregularityTextbox_ID, "Booking - Incomplete or inaccurate");
                Hooks.Hooks.UpdateTest(Status.Pass, "Selected Irregularity Code");
                Log.Info("Selected Irregularity Code");
                DoubleClick(irregularityScrollHori_XPATH);
                Log.Info("Double Clicked on Horizontal Scroll");
                Click(irregularityRemarks_XPATH);
                Log.Info("Clicked on Irregularity Remarks");
                EnterText(irregularityRemarks_XPATH, "test");
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Irrgularity Remarks");
                Log.Info("Entered Irrgularity Remarks");
                int noOfWindowsBefore = GetNumberOfWindowsOpened();
                Click(irregularitySaveBtn_ID);
                Log.Info("Clicked on Irregularity Save Button");
                WaitForNewWindowToOpen(TimeSpan.FromSeconds(10), noOfWindowsBefore + 1);
                int noOfWindowsAfter = GetNumberOfWindowsOpened();
                if (noOfWindowsAfter > noOfWindowsBefore)
                {
                    SwitchToLastWindow();
                    WaitForElementToBeInvisible(bookingIrregularityFrame_ID, TimeSpan.FromSeconds(15));
                    WaitForElementToBeVisible(awbNumber_XPATH, TimeSpan.FromSeconds(10));
                    string awbNumber = GetText(awbNumber_XPATH);
                    Hooks.Hooks.UpdateTest(Status.Pass, "AWB Number Captured: " + awbNumber);
                    Log.Info("AWB Number Captured: " + awbNumber);
                    if (IsElementEnabled(btnOkBookingSummaryPopup_XPATH))
                    {
                        WaitForElementToBeClickable(btnOkBookingSummaryPopup_XPATH, TimeSpan.FromSeconds(10));
                        Click(btnOkBookingSummaryPopup_XPATH);
                        Hooks.Hooks.UpdateTest(Status.Pass, "Clicked OK Button on Booking Summary Popup");
                        Log.Info("Clicked OK Button on Booking Summary Popup");
                    }
                    SwitchToLastWindow();
                    Log.Info("Switched to Last Window");
                    SwitchToCAP018Frame();
                    Log.Info("Switched to CAP018 Frame");
                }
                ClickOnElementIfPresent(btnCloseMb_XPATH);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Close Button on Maintain Booking Page");
                Log.Info("Clicked Close Button on Maintain Booking Page");
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Capturing Irregularity: " + e.Message);
                Log.Error("Error in Capturing Irregularity: " + e.Message);
            }
        }

        public void clickOnSaveButtonToSaveNewFlightDetails()
        {
            try
            {
                WaitForElementToBeInvisible(flightDetailsOkbtn_Xpath, TimeSpan.FromSeconds(15));
                ClickOnElementIfPresent(saveBtn_ID);
                Log.Info("Clicked Save Button to save new flight details");
            }
            catch (Exception e)
            {
                Log.Error("Error in Clicking Save Button to Save New Flight Details: " + e.Message);
            }
        }

        public void AVIBookingChecksheetDetails()
        {
            Hooks.Hooks.createNode();
            try
            {
                int noOfWindowsBefore = GetNumberOfWindowsOpened();
                clickOnSaveButtonToSaveNewFlightDetails();
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Save Button to save new flight details");
                clickingYesOnPopupWarnings();
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Yes on Popup Warnings");
                Log.Info("Clicked Yes on Popup Warnings");
                SwitchToCAP018Frame();
                SwitchToFrame(aviChecksheetFrame_XPath);
                Log.Info("Switched to Irregularity Frame");
                List<IWebElement> AviChecksheetSections = GetElements(aviTotalChkSheetSections_Xpath);
                Log.Info("Total AVI Checksheet Sections: " + AviChecksheetSections.Count);
                int totalQuestions = 0;

                foreach (var section in AviChecksheetSections)
                {
                    if (section.Text == "AVIHDL Statement")
                    {

                        string drpDwnQn = "//*[@id='tabs-1']//div[@id='configId']/h2[text()='aviSectionName']/parent::div/following-sibling::div//select";

                        drpDwnQn = drpDwnQn.Replace("aviSectionName", "AVIHDL Statement");
                        totalQuestions = GetElementCount(By.XPath(drpDwnQn));
                        Log.Info("Total Questions in AVIHDL Statement: " + totalQuestions);
                        drpDwnQn = drpDwnQn + "[@name= 'questionwithAnswer[0].templateAnswer']";
                        if (!IsDropdownSelectedByVisibleText((By.XPath(drpDwnQn)), "Yes"))
                        {
                            for (int j = 0; j < totalQuestions; j++)
                            {
                                SelectDropdownByVisibleText(By.XPath(drpDwnQn.Replace("0", j.ToString())), "Yes");
                                Hooks.Hooks.UpdateTest(Status.Pass, "Selected Yes for AVIHDL Statement Checksheet");
                                Log.Info("Selected Yes for AVIHDL Statement Checksheet");
                                EnterKeys(By.XPath(drpDwnQn), Keys.Tab);
                                Log.Info("Entered Tab Key");
                            }
                        }

                    }
                    else if (section.Text == "AVI Booking")
                    {
                        string drpDwnQn = "//*[@id='tabs-1']//div[@id='configId']/h2[text()='aviSectionName']/parent::div/following-sibling::div//select";

                        drpDwnQn = drpDwnQn.Replace("aviSectionName", "AVI Booking");
                        totalQuestions = GetElementCount(By.XPath(drpDwnQn));
                        Log.Info("Total Questions in AVI Booking Checksheet: " + totalQuestions);
                        drpDwnQn = drpDwnQn + "[@name= 'questionwithAnswer[0].templateAnswer']";
                        if (!IsDropdownSelectedByVisibleText((By.XPath(drpDwnQn)), "Yes"))
                        {
                            for (int j = 0; j < totalQuestions; j++)
                            {
                                SelectDropdownByVisibleText(By.XPath(drpDwnQn.Replace("0", j.ToString())), "Yes");
                                Hooks.Hooks.UpdateTest(Status.Pass, "Selected Yes for AVI Booking Checksheet");
                                Log.Info("Selected Yes for AVI Booking Checksheet");
                                EnterKeys(By.XPath(drpDwnQn), Keys.Tab);
                            }

                        }

                    }
                }
                Click(aviBookingChecksheetOkBtn_XPATH);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked OK Button on AVI Booking Checksheet");
                Log.Info("Clicked OK Button on AVI Booking Checksheet");
                SwitchToPopupWindow();
                SwitchToCAP018Frame();
                ClickSaveButton();
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in AVI Booking Checksheet Details: " + e.Message);
                Log.Error("Error in AVI Booking Checksheet Details: " + e.Message);
            }
        }

        public void AttachOrDetachAWB()
        {
            Hooks.Hooks.createNode();
            try
            {
                int noOfWindowsBefore = GetNumberOfWindowsOpened();
                WaitForElementToBeInvisible(homePage_CSS, TimeSpan.FromSeconds(5));
                ClickOnElementIfPresent(attachDetachBtn_ID);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Attach/Detach Button");
                Log.Info("Clicked Attach/Detach Button");                
                WaitForNewWindowToOpen(TimeSpan.FromSeconds(20), noOfWindowsBefore + 1);
                int noOfWindowsAfter = GetNumberOfWindowsOpened();
                if (noOfWindowsAfter > noOfWindowsBefore)
                {
                    SwitchToSecondPopupWindow();
                    Log.Info("Switched to Second Popup Window");
                    WaitForElementToBeInvisible(CAP018Frame_XPATH, TimeSpan.FromSeconds(10));
                    WaitForElementToBeVisible(shipperConsigneePopup_CLASS, TimeSpan.FromSeconds(10));
                    Click(attachDetachAwbField_ID);
                    ClearText(attachDetachAwbField_ID);                    
                    Hooks.Hooks.UpdateTest(Status.Pass, "Cleared AWB Field");
                    Click(attachDetachPopupBtn_ID);
                    Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on Attach/Detach Button in Popup");
                    Log.Info("Clicked on Attach/Detach Button in Popup");
                }
                SwitchToPopupWindow();
                Log.Info("Switched to Popup Window");
                SwitchToCAP018Frame();
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Attaching/Detaching AWB: " + e.Message);
                Log.Error("Error in Attaching/Detaching AWB: " + e.Message);
            }
        }

        public void EnterNewAgentCode(string agentcode)
        {
            Hooks.Hooks.createNode();
            try
            {
                WaitForElementToBeInvisible(awbNumber_XPATH, TimeSpan.FromSeconds(5));
                EnterTextWithCheck(agentCode_ID, agentcode);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered New Agent Code: " + agentcode);
                Log.Info("Entered New Agent Code: " + agentcode);
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Entering New Agent Code: " + e.Message);
                Log.Error("Error in Entering New Agent Code: " + e.Message);
            }
        }


        public void AWBBookingfromStock()
        {
            Hooks.Hooks.createNode();
            try
            {
                SwitchToPopupWindow();
                Log.Info("Switched to Popup Window");
                WaitForElementToBeVisible(alreadyExecutedPopup_XPATH, TimeSpan.FromSeconds(10));
                string alreadyExecutedPopUp = GetText(alreadyExecutedPopup_XPATH);
                Hooks.Hooks.UpdateTest(Status.Pass, "Already Executed Popup: " + alreadyExecutedPopUp);
                Log.Info("Already Executed Popup: " + alreadyExecutedPopUp);
                SwitchToCAP018Frame();
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in AWB Booking from Stock: " + e.Message);
                Log.Error("Error in AWB Booking from Stock: " + e.Message);
            }
        }

        public void UnknownAgentShipmentDetails(string org, string dest, string prodcode)
        {
            Hooks.Hooks.createNode();
            try
            {
                EnterText(origin_ID, org);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Origin: " + org);
                Log.Info("Entered Origin: " + org);
                EnterText(destination_XPATH, dest);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Destination: " + dest);
                Log.Info("Entered Destination: " + dest);
                ClickOnElementIfPresent(agentCode_ID);
                Log.Info("Clicked on Agent Code field");
                EnterText(shippingDate_ID, shippingDate);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Shipping Date: " + shippingDate);
                Log.Info("Entered Shipping Date: " + shippingDate);
                EnterText(product_XPATH, prodcode);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Product Code: " + prodcode);
                Log.Info("Entered Product Code: " + prodcode);
                Click(shipperConsigneeBtn_ID);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on Shipper Consignee Button");
                Log.Info("Clicked on Shipper Consignee Button");
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Entering Unknown Agent Shipment Details: " + e.Message);
                Log.Error("Error in Entering Unknown Agent Shipment Details: " + e.Message);
            }
        }

        public void NewUnknownAgentShipmentDetails(string org, string dest, string agtcode, string prodcode)
        {
            Hooks.Hooks.createNode();
            try
            {
                WaitForElementToBeInvisible(homePage_CSS, TimeSpan.FromSeconds(10));            //new line added                                                       
                if (IsElementEnabled(origin_ID))
                {
                    EnterTextWithCheck(origin_ID, org);
                    Hooks.Hooks.UpdateTest(Status.Pass, "Entered Origin: " + org);
                    Log.Info("Entered Origin: " + org);
                }
                EnterText(destination_XPATH, dest);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Destination: " + dest);
                Log.Info("Entered Destination: " + dest);
                ClickOnElementIfPresent(agentCode_ID);
                Log.Info("Clicked on Agent Code field");
                EnterTextWithCheck(agentCode_ID, agtcode.ToString());
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Agent Code: " + agtcode);
                Log.Info("Entered Agent Code: " + agtcode);
                EnterText(shippingDate_ID, shippingDate);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Shipping Date: " + shippingDate);
                Log.Info("Entered Shipping Date: " + shippingDate);
                EnterText(product_XPATH, prodcode);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Product Code: " + prodcode);
                Log.Info("Entered Product Code: " + prodcode);
                Click(shipperConsigneeBtn_ID);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on Shipper Consignee Button");
                Log.Info("Clicked on Shipper Consignee Button");
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Entering Unknown Agent Shipment Details: " + e.Message);
                Log.Error("Error in Entering Unknown Agent Shipment Details: " + e.Message);
            }
        }

        public void UnknownShipperConsigneeDetails(string shipper, string consg)
        {
            Hooks.Hooks.createNode();
            try
            {
                SwitchToSecondPopupWindow();
                Log.Info("Switched to Second Popup Window");
                EnterTextWithCheck(shipperCode_XPATH, shipper);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Shipper Code: " + shipper);
                Log.Info("Entered Shipper Code: " + shipper);
                EnterTextWithCheck(consigneeCode_XPATH, consg);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Consignee Code: " + consg);
                Log.Info("Entered Consignee Code: " + consg);
                Click(shipperConsigneeOkBtn_ID);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on Shipper Consignee OK Button");
                Log.Info("Clicked on Shipper Consignee OK Button");
                SwitchToPopupWindow();
                Log.Info("Switched to Popup Window");
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Entering Unknown Shipper Consignee Details: " + e.Message);
                Log.Error("Error in Entering Unknown Shipper Consignee Details: " + e.Message);
            }
        }

        public void UnknownShipperConsigneeALLDetails(string unkshppr, string unkconsgn)
        {
            Hooks.Hooks.createNode();
            try
            {
                SwitchToSecondPopupWindow();
                Log.Info("Switched to Second Popup Window");
                WaitForElementToBeInvisible(CAP018Frame_XPATH, TimeSpan.FromSeconds(10));
                EnterText(shipperCode_XPATH, unkshppr);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Shipper Code: " + unkshppr);
                Log.Info("Entered Shipper Code: " + unkshppr);
                string shipperName = "Test Shipper";
                if (checkTextboxIsNotEmpty(unkShipperName_ID))
                {
                    ClickOnElementIfPresent(unkShipperName_ID);
                    Log.Info("Clicked on Shipper Name Field");
                }
                else
                {
                    Click(unkShipperName_ID);
                    WaitForElementToBeInvisible(CAP018Frame_XPATH, TimeSpan.FromSeconds(10));
                    EnterTextWithCheck(unkShipperName_ID, shipperName);
                    Hooks.Hooks.UpdateTest(Status.Pass, "Entered Shipper Name: " + shipperName);
                    Log.Info("Entered Shipper Name: " + shipperName);
                }
                string shipperFirstAddress = "Test Address1";
                EnterTextWithCheck(unkShipperFirstAddress_ID, shipperFirstAddress);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Shipper First Address: " + shipperFirstAddress);
                Log.Info("Entered Shipper First Address: " + shipperFirstAddress);
                string shipperSecondAddress = "Test Address2";
                EnterTextWithCheck(unkShipperSecondAddress, shipperSecondAddress);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Shipper Second Address: " + shipperSecondAddress);
                Log.Info("Entered Shipper Second Address: " + shipperSecondAddress);
                string shipperCity = "Test City";
                EnterTextWithCheck(unkShipperCity_ID, shipperCity);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Shipper City: " + shipperCity);
                Log.Info("Entered Shipper City: " + shipperCity);
                string shipperState = "Test State";
                EnterTextWithCheck(unkShipperState_ID, shipperState);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Shipper State: " + shipperState);
                Log.Info("Entered Shipper State: " + shipperState);
                string shipperCountry = "US";
                EnterTextWithCheck(unkShipperCountry_ID, shipperCountry);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Shipper Country: " + shipperCountry);
                Log.Info("Entered Shipper Country: " + shipperCountry);
                string shipperZip = "67890";
                EnterTextWithCheck(unkShipperZip_ID, shipperZip);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Shipper Zip: " + shipperZip);
                Log.Info("Entered Shipper Zip: " + shipperZip);
                string shipperEmail = "TEST@GMAIL.COM.INVALID";
                EnterTextWithCheck(unkShipperEmail_ID, shipperEmail);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Shipper Email: " + shipperEmail);
                Log.Info("Entered Shipper Email: " + shipperEmail);
                EnterText(consigneeCode_XPATH, unkconsgn);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Consignee Code: " + unkconsgn);
                Log.Info("Entered Consignee Code: " + unkconsgn);
                string consigneeName = "Test Consignee";
                if (checkTextboxIsNotEmpty(unkConsigneeName_ID))
                {
                    ClickOnElementIfPresent(unkConsigneeName_ID);
                    Log.Info("Clicked on Consignee Name Field");
                }
                else
                {
                    Click(unkConsigneeName_ID);
                    WaitForElementToBeInvisible(CAP018Frame_XPATH, TimeSpan.FromSeconds(10));
                    EnterTextWithCheck(unkConsigneeName_ID, consigneeName);
                    Hooks.Hooks.UpdateTest(Status.Pass, "Entered Consignee Name: " + consigneeName);
                    Log.Info("Entered Consignee Name: " + consigneeName);
                }
                string consigneeFirstAddress = "Test Address1";
                EnterTextWithCheck(unkConsigneeFirstAddress_ID, consigneeFirstAddress);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Consignee First Address: " + consigneeFirstAddress);
                Log.Info("Entered Consignee First Address: " + consigneeFirstAddress);
                string consigneeSecondAddress = "Test Address2";
                EnterTextWithCheck(unkConsigneeSecondAddress, consigneeSecondAddress);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Consignee Second Address: " + consigneeSecondAddress);
                Log.Info("Entered Consignee Second Address: " + consigneeSecondAddress);
                string consigneeCity = "Test City";
                EnterTextWithCheck(unkConsigneeCity_ID, consigneeCity);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Consignee City: " + consigneeCity);
                Log.Info("Entered Consignee City: " + consigneeCity);
                string consigneeState = "Test State";
                EnterTextWithCheck(unkConsigneeState_ID, consigneeState);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Consignee State: " + consigneeState);
                Log.Info("Entered Consignee State: " + consigneeState);
                string consigneeCountry = "US";
                EnterTextWithCheck(unkConsigneeCountry_ID, consigneeCountry);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Consignee Country: " + consigneeCountry);
                string consigneeZip = "67890";
                EnterTextWithCheck(unkConsigneeZip_ID, consigneeZip);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Consignee Zip: " + consigneeZip);
                Log.Info("Entered Consignee Zip: " + consigneeZip);
                string consigneeEmail = "TEST@GMAIL.COM.INVALID";
                EnterTextWithCheck(unkConsigneeEmail_ID, consigneeEmail);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered Consignee Email: " + consigneeEmail);
                Log.Info("Entered Consignee Email: " + consigneeEmail);
                Click(shipperConsigneeOkBtn_ID);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on Shipper Consignee OK Button");
                Log.Info("Clicked on Shipper Consignee OK Button");
                SwitchToPopupWindow();
                Log.Info("Switched to Popup Window");
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Entering Unknown Shipper Consignee ALL Details: " + e.Message);
                Log.Error("Error in Entering Unknown Shipper Consignee ALL Details: " + e.Message);
            }
        }

        public void SelectFlight(string givenproductcode)
        {
            Hooks.Hooks.createNode();
            try
            {
                Click(selectFlightBtn_ID);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Select Flight Button");
                Log.Info("Clicked Select Flight Button");                
                WaitForElementToBeInvisible(CAP018Frame_XPATH, TimeSpan.FromSeconds(10));
                SwitchToFrame(bookingIrregularityFrame_ID);
                Log.Info("Switched to Irregularity Frame");
                List<IWebElement> noofflights = GetElements(flightDetailsSection_XPATH);
                Log.Info("Total Flights: " + noofflights.Count);
                List<IWebElement> ratestatusbtn = GetElements(rate_Xpath);
                Log.Info("Total Rate Status Buttons: " + ratestatusbtn.Count);
                List<IWebElement> capstatusbtn = GetElements(cap_Xpath);
                Log.Info("Total CAP Status Buttons: " + capstatusbtn.Count);
                List<IWebElement> reststatusbtn = GetElements(rest_Xpath);
                Log.Info("Total REST Status Buttons: " + reststatusbtn.Count);
                List<IWebElement> embstatusbtn = GetElements(emb_Xpath);
                Log.Info("Total EMB Status Buttons: " + embstatusbtn.Count);
                List<IWebElement> prodcodes = GetElements(flightProductCode_Xpath);
                Log.Info("Total Product Codes: " + prodcodes.Count);
                List<IWebElement> flightdates = GetElements(flightDate_Xpath);
                Log.Info("Total Flight Dates: " + flightdates.Count);
                List<IWebElement> GeneralProd = GetElements(generalProdBtn_Xpath);
                Log.Info("Total General Product Buttons: " + GeneralProd.Count);
                List<IWebElement> PriorityProd = GetElements(priorityProdBtn_Xpath);
                Log.Info("Total Priority Product Buttons: " + PriorityProd.Count);
                List<IWebElement> EmployeeProd = GetElements(employeeProdBtn_Xpath);
                Log.Info("Total Employee Product Buttons: " + EmployeeProd.Count);
                List<IWebElement> GoldstreakProd = GetElements(goldstreakProdBtn_Xpath);
                Log.Info("Total Goldstreak Product Buttons: " + GoldstreakProd.Count);
                List<IWebElement> PetConnectProd = GetElements(petConnectProdBtn_Xpath);
                Log.Info("Total Pet Connect Product Buttons: " + PetConnectProd.Count);
                for (int i = 0; i < noofflights.Count; i++)
                {
                    IWebElement item = prodcodes[i];
                    string productcode = GetTextFromElement(item);
                    IWebElement capstatus = capstatusbtn[i];
                    string capColor = GetAttributeValueFromElement(capstatus, "class");
                    IWebElement reststatus = reststatusbtn[i];
                    string rescolor = GetAttributeValueFromElement(reststatus, "class");
                    IWebElement embstatus = embstatusbtn[i];
                    string embcolor = GetAttributeValueFromElement(embstatus, "class");
                    IWebElement ratestatus = ratestatusbtn[i];
                    string ratecolor = GetAttributeValueFromElement(ratestatus, "class");
                    IWebElement flightdate = flightdates[i];
                    string flightdatevalue = GetTextFromElement(flightdate);
                    if (presentdate == flightdatevalue)
                    {
                        if (productcode == givenproductcode && productcode == "GENERAL")
                        {
                            if (capColor != "badge-red" && rescolor != "badge-red" && embcolor != "badge-red" && ratecolor != "badge-red")
                            {
                                IWebElement GeneralProdBtn = GeneralProd[i];
                                if (IsElementDisplayed(generalProdBtn_Xpath))
                                {
                                    ClickOnElement(GeneralProdBtn);
                                    Hooks.Hooks.UpdateTest(Status.Pass, "Selected General Product");
                                    Log.Info("Selected General Product");
                                }
                                Click(flightDetailsOkbtn_Xpath);
                                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Flight Details OK Button");
                                Log.Info("Clicked Flight Details OK Button");
                                break;
                            }
                        }
                        else if (productcode == givenproductcode && productcode == "PRIORITY")
                        {
                            if (capColor != "badge-red" && rescolor != "badge-red" && embcolor != "badge-red" && ratecolor != "badge-red")
                            {
                                IWebElement PriorityProdBtn = PriorityProd[i];
                                if (IsElementDisplayed(priorityProdBtn_Xpath))
                                {
                                    ClickOnElement(PriorityProdBtn);
                                    Hooks.Hooks.UpdateTest(Status.Pass, "Selected Priority Product");
                                    Log.Info("Selected Priority Product");
                                }
                                Click(flightDetailsOkbtn_Xpath);
                                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Flight Details OK Button");
                                Log.Info("Clicked Flight Details OK Button");
                                break;
                            }
                        }
                        else if (productcode == givenproductcode && productcode == "EMPLOYEE SHIPMENT")
                        {
                            if (capColor != "badge-red" && rescolor != "badge-red" && embcolor != "badge-red" && ratecolor != "badge-red")
                            {
                                IWebElement EmployeeProdBtn = EmployeeProd[i];
                                if (IsElementDisplayed(employeeProdBtn_Xpath))
                                {
                                    ClickOnElement(EmployeeProdBtn);
                                    Hooks.Hooks.UpdateTest(Status.Pass, "Selected Employee Shipment Product");
                                    Log.Info("Selected Employee Shipment Product");
                                }
                                Click(flightDetailsOkbtn_Xpath);
                                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Flight Details OK Button");
                                Log.Info("Clicked Flight Details OK Button");
                                break;
                            }
                        }
                        else if (productcode == givenproductcode && productcode == "GOLDSTREAK")
                        {
                            if (capColor != "badge-red" && rescolor != "badge-red" && embcolor != "badge-red" && ratecolor != "badge-red")
                            {
                                IWebElement GoldstreakProdBtn = GoldstreakProd[i];
                                if (IsElementDisplayed(goldstreakProdBtn_Xpath))
                                {
                                    ClickOnElement(GoldstreakProdBtn);
                                    Hooks.Hooks.UpdateTest(Status.Pass, "Selected Goldstreak Product");
                                    Log.Info("Selected Goldstreak Product");
                                }
                                Click(flightDetailsOkbtn_Xpath);
                                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Flight Details OK Button");
                                Log.Info("Clicked Flight Details OK Button");
                                break;
                            }
                        }
                        else if (productcode == givenproductcode && productcode == "PET CONNECT")
                        {
                            if (capColor != "badge-red" && rescolor != "badge-red" && embcolor != "badge-red" && ratecolor != "badge-red")
                            {
                                IWebElement PetConnectProdBtn = PetConnectProd[i];
                                if (IsElementDisplayed(petConnectProdBtn_Xpath))
                                {
                                    ClickOnElement(PetConnectProdBtn);
                                    Hooks.Hooks.UpdateTest(Status.Pass, "Selected Pet Connect Product");
                                    Log.Info("Selected Pet Connect Product");
                                }
                                Click(flightDetailsOkbtn_Xpath);
                                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Flight Details OK Button");
                                Log.Info("Clicked Flight Details OK Button");
                                break;
                            }
                        }
                    }
                }
                SwitchToPopupWindow();
                SwitchToCAP018Frame();
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, e.ToString());
                Log.Error(e.ToString());
            }
        }

        public void selectMultilegflight(string rescolor, string mincontimewarning, string givenprodcode)
        {
            Hooks.Hooks.createNode();
            try
            {
                Click(selectFlightBtn_ID);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Select Flight Button");
                Log.Info("Clicked Select Flight Button");
                WaitForElementToBeInvisible(CAP018Frame_XPATH, TimeSpan.FromSeconds(10));
                SwitchToFrame(bookingIrregularityFrame_ID);
                Log.Info("Switched to Irregularity Frame");
                WaitForElementToBeVisible(flightDetailsSection_XPATH, TimeSpan.FromSeconds(30));
                Click(flightSearchBox_Xpath);
                Log.Info("Clicked Flight Search Box");
                ClickOnElementIfPresent(multilegFlightsfilter);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Multileg Flights Filter");
                Log.Info("Clicked Multileg Flights Filter");
                Click(oneStopFilter_Xpath);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked One Stop Filter");
                Log.Info("Clicked One Stop Filter");
                Click(twoStopFilter_Xpath);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Two Stop Filter");
                Log.Info("Clicked Two Stop Filter");
                Click(twoplusStopFilter_Xpath);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Two Plus Stop Filter");
                Log.Info("Clicked Two Plus Stop Filter");
                Click(filterApplyBtn_Xpath);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Filter Apply Button");
                Log.Info("Clicked Filter Apply Button");
                List<IWebElement> noofflights = GetElements(flightDetailsSection_XPATH);
                Log.Info("Total Flights: " + noofflights.Count);
                List<IWebElement> reststatusbtn = GetElements(rest_Xpath);
                Log.Info("Total REST Status Buttons: " + reststatusbtn.Count);
                List<IWebElement> multilegflights = GetElements(multilegFlights_Xpath);
                Log.Info("Total Multileg Flights: " + multilegflights.Count);
                string productcode = GetText(flightProductCode_Xpath);
                for (int i = 0; i < noofflights.Count; i++)
                {
                    IWebElement reststatus = reststatusbtn[i];
                    string resattribute = GetAttributeValueFromElement(reststatus, "class");
                    string nooflegscount = GetTextFromElement(multilegflights[i]);
                    int count = int.Parse(nooflegscount);
                    if (count >= 2)
                    {
                        if (resattribute == "badge-red" && productcode == "GENERAL" && productcode == givenprodcode)
                        {
                            string resColors = resattribute.Split('-')[1];
                            Hooks.Hooks.UpdateTest(Status.Pass, "Rest Status Color: " + resColors);
                            Log.Info("Rest Status Color: " + resColors);
                            Assert.AreEqual(rescolor, resColors);
                            Log.Info("Rest Status Color: " + resColors);
                            Click(resColor_Xpath);
                            Log.Info("Clicked on Rest Status Color");
                            string resErrorMessage = GetText(resErrorMessage_Xpath);
                            Assert.AreEqual(mincontimewarning, resErrorMessage);
                            Log.Info("Rest Error Message: " + resErrorMessage);
                            Hooks.Hooks.UpdateTest(Status.Pass, "Rest Error Message: " + resErrorMessage);
                            Click(resColor_Xpath);
                            Log.Info("Clicked on Rest Status Color");
                            Click(flightDetailsOkbtn_Xpath);
                            Log.Info("Clicked Flight Details OK Button");
                            WaitForElementToBeVisible(selectFlightError_Xpath, TimeSpan.FromSeconds(10));
                            string popUpMessage = GetText(selectFlightError_Xpath);
                            Log.Info("PopUp Message: " + popUpMessage);
                            Assert.AreEqual("Please select at least one flight.", popUpMessage);
                            Hooks.Hooks.UpdateTest(Status.Pass, "PopUp Message: " + popUpMessage);
                            break;
                        }
                        if (resattribute == "badge-red" && productcode == "PRIORITY" && productcode == givenprodcode)
                        {
                            string resColors = resattribute.Split('-')[1];
                            Log.Info(resColors);
                            Assert.AreEqual(rescolor, resColors);
                            Hooks.Hooks.UpdateTest(Status.Pass, "Rest Status Color: " + resColors);
                            Click(resColor_Xpath);
                            string resErrorMessage = GetText(resErrorMessage_Xpath);
                            Assert.AreEqual(mincontimewarning, resErrorMessage);
                            Hooks.Hooks.UpdateTest(Status.Pass, "Rest Error" + resErrorMessage);
                            Log.Info(resErrorMessage);
                            Click(resColor_Xpath);
                            Log.Info("Clicked on Rest Status Color");
                            Click(flightDetailsOkbtn_Xpath);
                            Log.Info("Clicked Flight Details OK Button");
                            WaitForElementToBeVisible(selectFlightError_Xpath, TimeSpan.FromSeconds(10));
                            string popUpMessage = GetText(selectFlightError_Xpath);
                            Log.Info(popUpMessage);
                            Assert.AreEqual("Please select at least one flight.", popUpMessage);
                            Hooks.Hooks.UpdateTest(Status.Pass, popUpMessage);
                            break;
                        }
                        if (resattribute == "badge-red" && productcode == "GOLDSTREAK" && productcode == givenprodcode)
                        {
                            string resColors = resattribute.Split('-')[1];
                            Log.Info(resColors);
                            Assert.AreEqual(rescolor, resColors);
                            Hooks.Hooks.UpdateTest(Status.Pass, "Rest Status Color: " + resColors);
                            Click(resColor_Xpath);
                            Log.Info("Clicked on Rest Status Color");
                            string resErrorMessage = GetText(resErrorMessage_Xpath);
                            Assert.AreEqual(mincontimewarning, resErrorMessage);
                            Hooks.Hooks.UpdateTest(Status.Pass, "Rest Error Message: " + resErrorMessage);
                            Log.Info(resErrorMessage);
                            Click(resColor_Xpath);
                            Log.Info("Clicked on Rest Status Color");
                            Click(flightDetailsOkbtn_Xpath);
                            Log.Info("Clicked Flight Details OK Button");
                            WaitForElementToBeVisible(selectFlightError_Xpath, TimeSpan.FromSeconds(10));
                            string popUpMessage = GetText(selectFlightError_Xpath);
                            Log.Info(popUpMessage);
                            Assert.AreEqual("Please select at least one flight.", popUpMessage);
                            Hooks.Hooks.UpdateTest(Status.Pass, popUpMessage);
                            break;
                        }
                        if (resattribute == "badge-red" && productcode == "PET CONNECT" && productcode == givenprodcode)
                        {
                            string resColors = resattribute.Split('-')[1];
                            Log.Info(resColors);
                            Assert.AreEqual(rescolor, resColors);
                            Hooks.Hooks.UpdateTest(Status.Pass, "Rest Status Color: " + resColors);
                            Click(resColor_Xpath);
                            Log.Info("Clicked on Rest Status Color");
                            string resErrorMessage = GetText(resErrorMessage_Xpath);
                            Log.Info(resErrorMessage);
                            Assert.AreEqual(mincontimewarning, resErrorMessage);
                            Hooks.Hooks.UpdateTest(Status.Pass, "Rest Error Message: " + resErrorMessage);
                            Click(resColor_Xpath);
                            Log.Info("Clicked on Rest Status Color");
                            Click(flightDetailsOkbtn_Xpath);
                            Log.Info("Clicked Flight Details OK Button");
                            WaitForElementToBeVisible(selectFlightError_Xpath, TimeSpan.FromSeconds(10));
                            string popUpMessage = GetText(selectFlightError_Xpath);
                            Log.Info(popUpMessage);
                            Assert.AreEqual("Please select at least one flight.", popUpMessage);
                            Hooks.Hooks.UpdateTest(Status.Pass, popUpMessage);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Selecting Multileg Flight: " + e.Message);
                Log.Error("Error in Selecting Multileg Flight: " + e.Message);
            }
        }

        public void addNewFlightDetails()
        {
            Hooks.Hooks.createNode();
            try
            {
                Click(selectFlightBtn_ID);
                Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Select Flight Button");
                Log.Info("Clicked Select Flight Button");
                WaitForElementToBeInvisible(CAP018Frame_XPATH, TimeSpan.FromSeconds(10));
                SwitchToFrame(bookingIrregularityFrame_ID);
                Log.Info("Switched to Irregularity Frame");
                WaitForElementToBeVisible(rebookFlightDetails_Xpath, TimeSpan.FromSeconds(20));
                List<IWebElement> nosofflights = GetElements(rebookFlightDetails_Xpath);
                Log.Info("Total Flights: " + nosofflights.Count);
                List<IWebElement> flightnumbersbtn = GetElements(rebookSelectFlightbtn_Xpath);
                Log.Info("Total Flight Numbers: " + flightnumbersbtn.Count);
                List<IWebElement> ratestatusbtn = GetElements(rate_Xpath);
                Log.Info("Total Rate Status Buttons: " + ratestatusbtn.Count);
                List<IWebElement> capstatusbtn = GetElements(cap_Xpath);
                Log.Info("Total CAP Status Buttons: " + capstatusbtn.Count);
                List<IWebElement> reststatusbtn = GetElements(rest_Xpath);
                Log.Info("Total REST Status Buttons: " + reststatusbtn.Count);
                List<IWebElement> embstatusbtn = GetElements(emb_Xpath);
                Log.Info("Total EMB Status Buttons: " + embstatusbtn.Count);
                for (int i = 0; i < nosofflights.Count; i++)
                {
                    IWebElement item = nosofflights[i];
                    string selectflightnum = GetTextFromElement(item);
                    IWebElement capstatus = capstatusbtn[i];
                    string capColor = GetAttributeValueFromElement(capstatus, "class");
                    IWebElement reststatus = reststatusbtn[i];
                    string rescolor = GetAttributeValueFromElement(reststatus, "class");
                    IWebElement embstatus = embstatusbtn[i];
                    string embcolor = GetAttributeValueFromElement(embstatus, "class");
                    IWebElement ratestatus = ratestatusbtn[i];
                    string ratecolor = GetAttributeValueFromElement(ratestatus, "class");

                    if (capColor != "badge-red" && rescolor != "badge-red" && embcolor != "badge-red" && ratecolor != "badge-red" && firstflightnum != selectflightnum)
                    {
                        IWebElement selectflightbtn = flightnumbersbtn[i];
                        ClickOnElement(selectflightbtn);
                        Hooks.Hooks.UpdateTest(Status.Pass, "Selected Flight Number: " + selectflightnum);
                        Log.Info("Selected Flight Number: " + selectflightnum);
                        Click(flightDetailsOkbtn_Xpath);
                        Hooks.Hooks.UpdateTest(Status.Pass, "Clicked Flight Details OK Button");
                        Log.Info("Clicked Flight Details OK Button");
                        break;
                    }
                }

                SwitchToCAP018Frame();
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Adding New Flight Details: " + e.Message);
                Log.Error("Error in Adding New Flight Details: " + e.Message);
            }
        }

        public string CaptureAwbNumber()
        {
            string awb_num = "";
            awb_num = awbNumber;
            return awb_num;
        }
    }
}