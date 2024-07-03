using AventStack.ExtentReports;
using iCargoUIAutomation.Features;
using iCargoUIAutomation.utilities;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V121.Debugger;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace iCargoUIAutomation.pages
{
    public class CreateShipmentPage : BasePage
    {

        private DangerousGoodsPage dgp;
        private PaymentPortalPage ppp;
        private CaptureIrregularityPage cip;
        private ExportManifestPage emp;
        public static string awb_num = "";
        public static string totalPaybleAmount = "";
        public static string totalAmountCharged = "";
        string IATACharge = "";
        string MarketCharge = "";
        public static string origin = "";
        public static string destination = "";
        string shippingDate = DateTime.Now.ToString("dd-MMM-yyyy");
        string scc = "";
        string serviceCargoClass = "";
        public static string pieces = "";
        public static string weight = "";
        string chargeType = "";
        string modeOfPayment = "";
        string iataCharge = "";
        string marketCharge = "";
        string totalChagre = "";
        public static string flightNum = "";
        public static string ConnectingflightNum = "";
        string flightSegment = "";
        string generatedAWB = "";
        public static string cartULDNum = "";
        public static int noOfWindowBefore = 0;
        public static int noOfWindowAfter = 0;
        ILog Log = LogManager.GetLogger(typeof(CreateShipmentPage));


        public CreateShipmentPage(IWebDriver driver) : base(driver)
        {

            ppp = new PaymentPortalPage(driver);
            dgp = new DangerousGoodsPage(driver);
            cip = new CaptureIrregularityPage(driver);
            emp = new ExportManifestPage(driver);

        }

        // LTE001 Header Section   //
        private By contentFrame_Xpath = By.XPath("//div[@id='LTE001']/iframe");
        private By txtAwbNo_Id = By.Id("awb_b");
        private By btnList_Id = By.Id("button_list");
        private By btnClear_Id = By.Id("button_clear");
        private By lblShipmentDetails_Css = By.CssSelector(".card-header h4");
        private By lblAWBNo_Css = By.CssSelector(".awb-no-data a");
        private By lblBookingConfirmation_Xpath = By.XPath("//header//*[text()='Booking']/following-sibling::div");
        private By lblDataCapture_Xpath = By.XPath("//header//*[text()='Data Capture']//following::div[@id='_ajax_shipmentStatus']");
        private By lblAcceptance_Xpath = By.XPath("//header//*[text()='Acceptance']//following::div[@id='_ajax_acceptance_status']");
        private By lblColorReadyForCarriage_Xpath = By.XPath(".//*[@id='_ajax_readyforcarriage_status']//i");
        private By lblColorCaptureChecksheet_Xpath = By.XPath("//*[normalize-space(text())='Capture check sheet']/preceding-sibling::i");
        private By lblColorBlock_Xpath = By.XPath(".//*[normalize-space(text())='Block']/preceding-sibling::i");
        private By btnOrangePencilEditBooking_Css = By.CssSelector("header i.ico-pencil-rounded-orange");

        //   Participants   //
        public static string agentCode = "";
        public static string shipperCode = "";
        public static string consigneeCode = "";
        private By lblParticipantDetails_Id = By.Id("participant");
        private By btnOrangePencilParticipant_Css = By.CssSelector("#view_participant a");
        private By txtAgentCode_Name = By.Name("agentCode");
        private By txtAgentName_Name = By.Name("agentName");
        private By txtShipperCode_Name = By.Name("shipperCode");
        private By txtShipperName_Name = By.Name("shipperName");
        private By txtShipperContact_Name = By.Name("shipperCntctNumber");
        private By btnMoreShipper_Name = By.Name("btnMoreShipper");
        private By txtShipperAddress_Name = By.Name("shipperAddress");
        private By txtShipperCity_Name = By.Name("shipperCity");
        private By txtShipperState_Name = By.Name("shipperState");
        private By txtShipperZip_Name = By.Name("shipperZipCode");
        private By txtShipperCountry_Name = By.Name("shipperCountry");
        private By txtShipperEmail_Name = By.Name("shipperEmail");
        private By btnShipperOk_Name = By.Name("btnShipperOK");


        private By txtConsigneeCode_Name = By.Name("consigneeCode");
        private By btnContinueParticipants_Name = By.Name("btnParticipantCont");
        private By btnContinueCommodity_Name = By.Name("btnCommodityCont");


        //   Certificates   //

        private By txtNameOnId_Name = By.Name("driverName");
        private By drpdwnIdType_Name = By.Name("driverIDType");
        private By txtIdIssueState_Name = By.Name("stateOrCountryIssuingID");
        private By drpdwn_PhotoMatched_Name = By.Name("photoIDVerified");
        private By btnContinueCertificates_Name = By.Name("btnCertificateDetailsCont");

        //   Shipment Commodity Details   //
        private By btnOrangePencilShipment_Css = By.CssSelector("#view_shipmentDtls a");
        private By lblShipmentDetails_Id = By.Id("shipmentaccordion");
        private By txtOrigin_Name = By.Name("origin");
        private By txtDestination_Name = By.Name("destination");
        private By txtShipmentDate_Name = By.Name("shippingDate");
        private By txtProductCode_Name = By.Name("productCode");
        private By txtSCCCode_Name = By.Name("scc");
        private By drpdwnServiceCargoClass_Name = By.Name("serviceCargoClass");
        private By txtCommodityCode_Name = By.Name("commodityCode");
        private By txtShipmentDescription_Name = By.Name("shipmentDesc");
        private By txtPieces_Name = By.Name("shpPcs");
        private By txtWeight_Name = By.Name("shpWgt");
        private By btnContinueShipmentCommodity_Name = By.Name("btnShipmentCont");

        //    Flight Details    //
        private By btnOrangePencilFlight_Css = By.CssSelector("#view_bookingDtls a");
        private By txtCarrierCode_Name = By.Name("flightCarrierCode");
        private By txtFlightNo_Name = By.Name("flightNumber");
        private By txtFlightDate_Name = By.Name("flightDate");
        private By txtSegment_Name = By.Name("flightSegment");
        private By txtBookedPiece_Name = By.Name("bookedPieces");
        private By txtBookedWgt_Name = By.Name("bookedWeight");
        private By btnTrashIcon_Css = By.CssSelector("#flightdetails i[title='Delete']");
        /* Select Flight Functionality */
        private By btnSelectFlight_Name = By.Name("btnSearchFlight");
        private By lblFlightListHeader_Xpath = By.XPath("//*[@id='flight_details']//thead//th[text()='Flight List']");
        private By listAllFlights_Xpath = By.XPath("//*[@id='flight_details']//tbody//tr");
        private string lblFlightType = "";
        private string btnBookFlight = "//*[@id='flight_details']//tbody//tr[1]//input[@type='button']";
        private By btnContinueFlightDetails_Name = By.Name("btnFlightDtlsCont");
        private string lblAvailabilityCap = "";
        private string lblAvailabilityEMB = "";
        private string lblAvailabilityLOAD = "";
        private string lblAvailabilityRES = "";

        //    Charge Details    //
        private By btnOrangePencilCharge_Css = By.CssSelector("#view_chargeDetails a");
        private By btnPaymentType_Xpath = By.XPath("//div[@id='pptype']");
        private By btnCalculateCharges_Name = By.Name("btnCalculateCharges");
        private By txtIATACharge_Xpath = By.XPath("//input[@name='iataCharge']");
        private By txtMarketCharge_Xpath = By.XPath("//input[@name='marketCharge']");
        private By txtTotalCharge_Xpath = By.XPath("(//span[starts-with(normalize-space(text()), 'Total Charge(Inc. Tax):')])[2]");
        private By drpdwnModeOfPayment_Name = By.Name("modeOfPay");
        private By btnContinueChargeDetails_Name = By.Name("btnChargeDtlsCont");
        private By popupActiveCashDraw_Xpath = By.XPath("//*[text()='No Active Cash draw exists, Do you want to open a new Cash draw?']");
        private By btnYesActiveCashDraw_Xpath = By.XPath("//*[@class='ui-dialog-buttonset']/button[text()=' Yes ']");
        private By btnNoActiveCashDraw_Xpath = By.XPath("//*[@class='ui-dialog-buttonset']/button[text()='No']");

        //   Acceptance Details    //
        private By btnOrangePencilAcceptance_Css = By.CssSelector("#view_acceptance a");
        private By txtPieceAccepted_Name = By.Name("acceptedPieces");
        private By btnContinueAcceptanceDetails_Name = By.Name("btnAcceptanceDtlsCont");

        //  Screening Details    //
        private By btnOrangePencilScreening_Css = By.CssSelector("#view_screeningDetails a");
        private By btnAddScreeningRow_Css = By.CssSelector(".templateParentScreening i[title='Add']");

        // string screeningRows = "(//*[@class='row templateParentScreening'])[1]";
        private By txtScreeningAirport1_Xpath = By.XPath("(//*[@class='row templateParentScreening'])[1]//input[@name='screeningAirport']");
        private By drpdwnScreeningMethod1_Xpath = By.XPath("(//*[@class='row templateParentScreening'])[1]//select[@name='screeningMethod']");
        private By txtScreeningPieces1_Xpath = By.XPath("(//*[@class='row templateParentScreening'])[1]//input[@name='screeningPieces']");
        private By drpdwnScreeningResult1_Xpath = By.XPath("(//*[@class='row templateParentScreening'])[1]//select[@name='screeningResult']");
        private By txtScreeningAirport2_Xpath = By.XPath("(//*[@class='row templateParentScreening'])[2]//input[@name='screeningAirport']");
        private By drpdwnScreeningMethod2_Xpath = By.XPath("(//*[@class='row templateParentScreening'])[2]//select[@name='screeningMethod']");
        private By txtScreeningPieces2_Xpath = By.XPath("(//*[@class='row templateParentScreening'])[2]//input[@name='screeningPieces']");
        private By drpdwnScreeningResult2_Xpath = By.XPath("(//*[@class='row templateParentScreening'])[2]//select[@name='screeningResult']");
        private By btnContinueScreeningDetails_Name = By.Name("btnScreeningDtlsCont");

        // LTE001 Footer Section  //
        private By chkBoxAwbVerified_Name = By.Name("verfiedCharges");
        private By btnSaveShipment_Name = By.Name("btnSave");
        private By btnDeleteAwb_Name = By.Name("btnDeleteAWB");
        private By btnCloseShipment_Name = By.Name("btnClose");
        private By btnCloseLTEWindow_Css = By.CssSelector("a.remove");



        //   Warning Popups //
        private By frameCalculateCharges_Css = By.CssSelector("#jsonDataHolder1711185182553");
        private By popupWarning_Css = By.CssSelector(".alert-messages-ui");
        private By popupAlertMessage_Xpath = By.XPath("//*[@class='alert-messages-list']//span");
        private By btnYesAlertMessage_Xpath = By.XPath("//*[@class='ui-dialog-buttonpane ui-widget-content ui-helper-clearfix']//*[text()=' Yes ']");
        private By lblWarningMessage_Css = By.CssSelector("#error-body span");
        private By lblEmbargoDetails_Xpath = By.XPath("//*[text()='Embargo Details']");
        private By btnContinueEmbargo_Xpath = By.XPath("//*[text()='Embargo Details']//following::button[@id='okBtn']");
        private By lblCaptureIrregularity_Xpath = By.XPath("//span[text()='Capture Irregularity']");

        // Capture Check Sheet //
        private By lnkCaptureChecksheet_Xpath = By.XPath("//*[@id='_ajax_shipmentChecksheet']//parent::a");
        private By lblCpatureChecksheetWarning = By.XPath("//*[@id='_ajax_shipmentChecksheet']/i");
        private By popupContainerFrameChksheet = By.XPath("//*[text()='Capture Check Sheet']//parent::div//following-sibling::div/iframe");
        private By lblTotalChkSheetSections_Xpath = By.XPath("//*[@id='tabs-1']//div[@id='configId']/h2");
        /* For Employee Shipment checksheet */
        private By txtDateOfHire_Xpath = By.XPath("//*[text()='EMPLOYEE SHIPMENT VERIFICATION']//following::input[@id='calendar2']");
        private By txtPeoplesoftNumber_Xpath = By.XPath("//*[text()='EMPLOYEE SHIPMENT VERIFICATION']//following::textarea[@id='CMP_Checksheet_Defaults_CaptureCheckSheet_Remarks']");

        private By btnOKCaptureChkSheet_Xpath = By.XPath("//*[@class='btmbtnpane btm-fixed']/button[@id='btnSave']");
        private By btnOKSuccessCheckSheet_Xpath = By.XPath("//*[@class='alert-messages-list']//parent::div//following-sibling::div//button");


        //Maintain Booking Page
        private By awbTextbox_ID = By.Id("awbNum_b");


        public void EnterAWBNumberForMaintainBooking()
        {
            Hooks.Hooks.createNode();
            try
            {
                awb_num = awb_num.Split('-')[1];
                EnterText(awbTextbox_ID, awb_num);
                Hooks.Hooks.UpdateTest(Status.Pass, "Entered AWB Number: " + awb_num);
                Log.Info("Entered AWB Number: " + awb_num);
            }
            catch (Exception e)
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in Entering AWB Number: " + e.Message);
                Log.Error("Error in Entering AWB Number: " + e.Message);
            }
        }
        public void SwitchToLTEContentFrame()
        {
            try
            {
                SwitchToFrame(contentFrame_Xpath);
            }
            catch (Exception e)
            {
                Log.Error("Error in switching to LTE001 content frame: " + e.ToString());
            }

        }

        public void ClickOnAwbTextBox()
        {

            try
            {
                Click(txtAwbNo_Id);
            }
            catch (Exception e)
            {
                Log.Error("Error in clicking on AWB text box: " + e.ToString());
            }

        }

        public void alreadyExecutedAWB()
        {
            try
            {
                Click(btnOrangePencilEditBooking_Css);
                WaitForElementToBeVisible(btnClear_Id, TimeSpan.FromSeconds(5));
                Click(btnClear_Id);
                WaitForElementToBeVisible(btnList_Id, TimeSpan.FromSeconds(10));
                awb_num = awb_num.Split('-')[1];
                EnterAWBTextBox(awb_num);
                ClickOnListButton();
            }
            catch (Exception e)
            {
                Log.Error("Error in entering the already executed AWB: " + e.ToString());
            }

        }

        public void EnterAWBTextBox(string awb)
        {
            try
            {
                EnterText(txtAwbNo_Id, awb);
            }
            catch (Exception e)
            {
                Log.Error("Error in entering AWB number: " + e.ToString());
            }

        }


        public void ClickOnListButton()
        {
            try
            {
                Click(btnList_Id);
                WaitForElementToBeVisible(lblShipmentDetails_Css, TimeSpan.FromSeconds(10));
            }
            catch (Exception e)
            {
                Log.Error("Error in clicking on List button: " + e.ToString());
            }

        }

        public void OpenAndVerifyParticipants()
        {
            try
            {
                Click(lblParticipantDetails_Id);
                Click(btnOrangePencilParticipant_Css);
                WaitForElementToBeInvisible(btnOrangePencilParticipant_Css, TimeSpan.FromSeconds(1));
                agentCode = GetAttributeValue(txtAgentCode_Name, "value");
                shipperCode = GetAttributeValue(txtShipperCode_Name, "value");
                consigneeCode = GetAttributeValue(txtConsigneeCode_Name, "value");

                Assert.IsNotNull(agentCode, "Agent code is null");
                Assert.IsNotNull(shipperCode, "Shipper code is null");
                Assert.IsNotNull(consigneeCode, "Consignee code is null");



            }
            catch (Exception e)
            {
                Log.Error("Error in opening and verifying participants: " + e.ToString());
            }

        }

        public void EnterParticipantDetailsAsync(string agent, string shipper, string consignee)
        {
            agentCode = agent;
            shipperCode = shipper;
            consigneeCode = consignee;
            try
            {
                Click(txtAgentCode_Name);
                EnterTextWithCheck(txtAgentCode_Name, agentCode);
                if (!checkTextboxIsNotEmpty(txtAgentName_Name))
                {
                    EnterTextWithCheck(txtAgentCode_Name, agentCode);
                }

                Click(txtShipperCode_Name);
                EnterTextWithCheck(txtShipperCode_Name, shipperCode);
                if (!checkTextboxIsNotEmpty(txtShipperName_Name))
                {
                    EnterTextWithCheck(txtShipperCode_Name, shipperCode);
                }


                Click(txtConsigneeCode_Name);
                EnterTextWithCheck(txtConsigneeCode_Name, consigneeCode);
                if (!checkTextboxIsNotEmpty(txtConsigneeCode_Name))
                {
                    EnterTextWithCheck(txtConsigneeCode_Name, consigneeCode);
                }


                EnterKeys(txtConsigneeCode_Name, Keys.Tab);
            }
            catch (Exception e)
            {
                Log.Error("Error in entering participant details: " + e.ToString());
            }



        }

        public void EnterParticipantDetailsWithUnknownShipper(string agent, string shipper, string consignee)
        {
            agentCode = agent;
            shipperCode = shipper;
            consigneeCode = consignee;
            try
            {
                Click(txtAgentCode_Name);
                EnterTextWithCheck(txtAgentCode_Name, agentCode);
                Click(txtShipperCode_Name);
                EnterTextWithCheck(txtShipperCode_Name, shipperCode);
                EnterTextWithCheck(txtShipperName_Name, "Test Unknown Shipper");
                EnterTextWithCheck(txtShipperContact_Name, "1234567890");
                Click(btnMoreShipper_Name);
                WaitForElementToBeVisible(txtShipperAddress_Name, TimeSpan.FromSeconds(5));
                EnterTextWithCheck(txtShipperAddress_Name, "Test Address");
                EnterTextWithCheck(txtShipperCity_Name, "ANCHORAGE");
                EnterTextWithCheck(txtShipperState_Name, "Alaska");
                EnterTextWithCheck(txtShipperCountry_Name, "US");
                EnterTextWithCheck(txtShipperZip_Name, "99505");
                EnterTextWithCheck(txtShipperEmail_Name, "test@mail.com");
                ScrollDown();
                Click(btnShipperOk_Name);
                WaitForElementToBeInvisible(btnShipperOk_Name, TimeSpan.FromSeconds(5));

                Click(txtConsigneeCode_Name);
                EnterTextWithCheck(txtConsigneeCode_Name, consigneeCode);
                EnterKeys(txtConsigneeCode_Name, Keys.Tab);
            }
            catch (Exception e)
            {
                Log.Error("Error in entering participant details: " + e.ToString());
            }



        }

        public void reOpenAWB()
        {
            try
            {
                Click(lblShipmentDetails_Id);
                Click(btnOrangePencilShipment_Css);
                ClickingYesOnPopupWarnings("");
            }
            catch (Exception e)
            {
                Log.Error("Error in re-opening AWB: " + e.ToString());
            }

        }



        public void ClickOnContinueParticipantButton()
        {
            ScrollDown();
            try
            {
                Click(btnContinueParticipants_Name);
            }
            catch (Exception e)
            {
                Log.Error("Error in clicking on Continue button for participants: " + e.ToString());

            }

        }

        public void EnterCertificateDetails()
        {
            try
            {
                EnterText(txtNameOnId_Name, "Test");
                SelectDropdownByVisibleText(drpdwnIdType_Name, "Driving License");
                EnterText(txtIdIssueState_Name, "WA");
                SelectDropdownByVisibleText(drpdwn_PhotoMatched_Name, "Yes");
            }
            catch (Exception e)
            {
                Log.Error("Error in entering certificate details: " + e.ToString());
            }

        }

        public void ClickOnContinueCertificateButton()
        {
            try
            {
                ScrollDown();
                Click(btnContinueCertificates_Name);
            }
            catch (Exception e)
            {
                Log.Error("Error in clicking on Continue button for certificates: " + e.ToString());
            }


        }

        public string OpenAndVerifyShipments()
        {
            try
            {
                WaitForElementToBeClickable(btnOrangePencilShipment_Css, TimeSpan.FromSeconds(10));
                Click(btnOrangePencilShipment_Css);
                WaitForElementToBeInvisible(btnOrangePencilShipment_Css, TimeSpan.FromSeconds(5));
                ScrollDown();

                origin = GetAttributeValue(txtOrigin_Name, "value");
                destination = GetAttributeValue(txtDestination_Name, "value");
                this.shippingDate = GetAttributeValue(txtShipmentDate_Name, "value");
                pieces = GetAttributeValue(txtPieces_Name, "value");
                weight = GetAttributeValue(txtWeight_Name, "value");
            }
            catch (Exception e)
            {
                Log.Error("Error in opening and verifying shipment details: " + e.ToString());
            }

            return pieces;
        }

        public void EnterShipmentDetails(string neworigin, string newdestination, string productCode, string scc,
                                         string commodity, string shipmentdesc, string serviceCargoClass, string newpiece, string newweight)
        {
            origin = neworigin;
            destination = newdestination;
            this.scc = scc;
            this.serviceCargoClass = serviceCargoClass;
            pieces = newpiece;
            weight = newweight;

            try
            {
                EnterText(txtOrigin_Name, origin);
                EnterText(txtDestination_Name, destination);
                EnterText(txtShipmentDate_Name, shippingDate);

                if (productCode == "Employee Shipment")
                {
                    EnterText(txtProductCode_Name, productCode);
                    Thread.Sleep(1000);

                    EnterKeys(txtProductCode_Name, Keys.ArrowDown);
                    EnterKeys(txtProductCode_Name, Keys.Tab);
                }
                else
                {
                    EnterText(txtProductCode_Name, productCode);
                }

                if (scc != "None")
                {
                    EnterText(txtSCCCode_Name, scc);
                }
                EnterText(txtCommodityCode_Name, commodity);
                if (shipmentdesc != "None")
                {
                    EnterText(txtShipmentDescription_Name, shipmentdesc);
                }
                SelectDropdownByVisibleText(drpdwnServiceCargoClass_Name, serviceCargoClass);
                EnterText(txtPieces_Name, pieces);
                EnterText(txtWeight_Name, weight);
            }
            catch (Exception e)
            {
                Log.Error("Error in entering shipment details: " + e.ToString());
            }
        }


        public void VerifyAndUpdateShipmentDetails(string fieldToUpdate, string newvalue)
        {
            try
            {
                if (fieldToUpdate.Equals("piece&weight"))
                {
                    pieces = GetAttributeValue(txtPieces_Name, "value");
                    pieces = (int.Parse(pieces) + int.Parse(newvalue)).ToString();
                    weight = GetAttributeValue(txtWeight_Name, "value");
                    weight = (int.Parse(weight) + int.Parse(newvalue)).ToString();
                    EnterText(txtPieces_Name, pieces);
                    EnterText(txtWeight_Name, weight);
                    EnterKeys(txtWeight_Name, Keys.Tab);
                }
                else if (fieldToUpdate.Equals("destination"))
                {
                    destination = newvalue;
                    EnterText(txtDestination_Name, destination);
                    EnterKeys(txtDestination_Name, Keys.Tab);
                }


            }
            catch (Exception e)
            {
                Log.Error("Error in verifying and updating shipment details: " + e.ToString());
            }

        }


        public void ClickOnContinueShipmentButton()
        {
            try
            {
                ScrollDown();
                Click(btnContinueShipmentCommodity_Name);
            }
            catch (Exception e)
            {
                Log.Error("Error in clicking on Continue button for shipment details: " + e.ToString());
            }

        }

        public void OpenAndVerifyFlightDetails()
        {
            try
            {
                Click(btnOrangePencilFlight_Css);
                WaitForElementToBeInvisible(btnOrangePencilFlight_Css, TimeSpan.FromSeconds(5));

                flightNum = GetAttributeValue(txtFlightNo_Name, "value");
                this.flightSegment = GetAttributeValue(txtSegment_Name, "value");
            }
            catch (Exception e)
            {
                Log.Error("Error in opening and verifying flight details: " + e.ToString());
            }

        }

        public void EnterFlightDetails(string carrierCode, string fltnum)
        {

            this.flightSegment = origin + destination;
            flightNum = fltnum;
            try
            {
                EnterText(txtCarrierCode_Name, carrierCode);
                EnterText(txtFlightNo_Name, flightNum);
                EnterText(txtFlightDate_Name, shippingDate);
                EnterText(txtSegment_Name, flightSegment);
                EnterText(txtBookedPiece_Name, pieces);
                EnterText(txtBookedWgt_Name, weight);
            }
            catch (Exception e)
            {
                Log.Error("Error in entering flight details: " + e.ToString());
            }


        }

        public void VerifyAndUpdateFlightDetails(string fieldToUpdate)
        {
            try
            {
                Click(btnOrangePencilFlight_Css);
                if (fieldToUpdate.Equals("piece&weight"))
                {
                    EnterText(txtBookedPiece_Name, pieces);
                    EnterText(txtBookedWgt_Name, weight);
                }
                else if (fieldToUpdate.Equals("destination"))
                {
                    Click(btnTrashIcon_Css);
                }


            }
            catch (Exception e)
            {
                Log.Error("Error in verifying and updating flight details: " + e.ToString());
            }


        }



        public void ClickOnSelectFlightButton()
        {
            try
            {
                ClickOnElementIfPresent(btnSelectFlight_Name);
                WaitForElementToBeVisible(lblFlightListHeader_Xpath, TimeSpan.FromSeconds(30));
                while (IsElementDisplayed(lblFlightListHeader_Xpath))
                {
                    Click(btnSelectFlight_Name);
                    break;
                }


            }
            catch (Exception e)
            {
                Log.Error("Error in clicking on Select Flight button: " + e.ToString());
            }

        }

        public void BookFlightWithAllAvailability()
        {
            try
            {
                int noOfFlights = GetElementCount(listAllFlights_Xpath);
                if (noOfFlights > 0)
                {
                    for (int i = 1; i <= noOfFlights; i++)
                    {
                        if (GetAttributeValue(By.XPath("//*[@id='flight_details']//tbody//tr[" + (i + 1) + "]"), "class").Contains("row-border-merge"))
                        {
                            if (!GetCAPAvailabilityStatus(i).Contains("error") && !GetEMBAvailabilityStatus(i).Contains("error") && !GetLOADAvailabilityStatus(i).Contains("error") && !GetRESAvailabilityStatus(i).Contains("error") && !GetCAPAvailabilityStatus(i + 1).Contains("error") && !GetEMBAvailabilityStatus(i + 1).Contains("error") && !GetLOADAvailabilityStatus(i + 1).Contains("error") && !GetRESAvailabilityStatus(i + 1).Contains("error"))
                            {
                                flightNum = GetText(By.XPath("//*[@id='flight_details']//tbody//tr[" + i + "]//td[1]")).Trim().Split("AS")[1].Trim();
                                ConnectingflightNum = GetText(By.XPath("//*[@id='flight_details']//tbody//tr[" + (i + 1) + "]//td[1]")).Trim().Split("AS")[1].Trim();
                                btnBookFlight = btnBookFlight.Replace("1", i.ToString());
                                ScrollDown();
                                Click(By.XPath(btnBookFlight));

                                Log.Info("Flight " + flightNum + " & connecting flightNum " + ConnectingflightNum + " is booked successfully");

                                break;
                            }
                            i = i + 1;
                        }
                        else
                        {
                            if (!(GetCAPAvailabilityStatus(i).Contains("error") && GetEMBAvailabilityStatus(i).Contains("error") && GetLOADAvailabilityStatus(i).Contains("error") && GetRESAvailabilityStatus(i).Contains("error")))
                            {
                                flightNum = GetText(By.XPath("//*[@id='flight_details']//tbody//tr[" + i + "]//td[1]")).Trim().Split("AS")[1].Trim();

                                btnBookFlight = btnBookFlight.Replace("1", i.ToString());
                                ScrollDown();
                                Click(By.XPath(btnBookFlight));
                                Log.Info("Flight " + flightNum + " is booked successfully");
                                break;
                            }
                        }



                    }


                }
                else
                {
                    Log.Info("No flight is available for booking from " + origin + " to " + destination + " on " + shippingDate);
                }


            }
            catch (Exception e)
            {
                Log.Error("Error in booking flight: " + e.ToString());
            }

        }


        public string BookWithSpecificFlightType(string typeOfFlight)
        {
            try
            {
                int noOfFlights = GetElementCount(listAllFlights_Xpath);
                if (noOfFlights > 0)
                {
                    for (int i = 1; i <= noOfFlights; i++)
                    {
                        if (!GetAttributeValue(By.XPath("//*[@id='flight_details']//tbody//tr[" + (i + 1) + "]"), "class").Contains("row-border-merge"))
                        {
                            if (!GetCAPAvailabilityStatus(i).Contains("error") && !GetEMBAvailabilityStatus(i).Contains("error") && !GetLOADAvailabilityStatus(i).Contains("error") && !GetRESAvailabilityStatus(i).Contains("error") && GetFlightType(i).Contains(typeOfFlight))
                            {
                                flightNum = GetText(By.XPath("//*[@id='flight_details']//tbody//tr[" + i + "]//td[1]")).Trim().Split("AS")[1].Trim();

                                btnBookFlight = btnBookFlight.Replace("1", i.ToString());
                                ScrollDown();
                                Click(By.XPath(btnBookFlight));
                                Log.Info(typeOfFlight + " Flight: " + flightNum + " is booked successfully");
                                break;
                            }

                        }

                    }

                }
                else
                {
                    Log.Info("No flight is available for booking from " + origin + " to " + destination + " on " + shippingDate);
                }


            }
            catch (Exception e)
            {
                Log.Error("Error in booking flight: " + e.ToString());
            }

            return flightNum;

        }

        public void BookConnectingFlightWithDifferentFlightTypes(string firstflttyp, string secondflttype)
        {
            try
            {
                int noOfFlights = GetElementCount(listAllFlights_Xpath);
                if (noOfFlights > 0)
                {
                    for (int i = 1; i <= noOfFlights; i++)
                    {
                        if (GetAttributeValue(By.XPath("//*[@id='flight_details']//tbody//tr[" + (i + 1) + "]"), "class").Contains("row-border-merge"))
                        {
                            if (GetFlightType(i).Contains(firstflttyp) && GetFlightType(i + 1).Contains(secondflttype))
                            {
                                if (!GetCAPAvailabilityStatus(i).Contains("error") && !GetEMBAvailabilityStatus(i).Contains("error") && !GetLOADAvailabilityStatus(i).Contains("error") && !GetRESAvailabilityStatus(i).Contains("error") && !GetCAPAvailabilityStatus(i + 1).Contains("error") && !GetEMBAvailabilityStatus(i + 1).Contains("error") && !GetLOADAvailabilityStatus(i + 1).Contains("error") && !GetRESAvailabilityStatus(i + 1).Contains("error"))
                                {
                                    flightNum = GetText(By.XPath("//*[@id='flight_details']//tbody//tr[" + i + "]//td[1]")).Trim().Split("AS")[1].Trim();
                                    ConnectingflightNum = GetText(By.XPath("//*[@id='flight_details']//tbody//tr[" + (i + 1) + "]//td[1]")).Trim().Split("AS")[1].Trim();
                                    btnBookFlight = btnBookFlight.Replace("1", i.ToString());
                                    ScrollDown();
                                    Click(By.XPath(btnBookFlight));

                                    Log.Info(firstflttyp + " Flight " + flightNum + " & connecting " + secondflttype + " Flight " + ConnectingflightNum + " is booked successfully");

                                    break;
                                }

                            }
                            i += 1;
                        }

                    }

                }
                else
                {
                    Log.Info("No flight is available for booking from " + origin + " to " + destination + " on " + shippingDate);
                }
            }
            catch (Exception e)
            {
                Log.Error("Error in booking flight: " + e.ToString());
            }

        }


        public void SelectFlightWithRestriction()
        {
            try
            {
                int noOfFlights = GetElementCount(listAllFlights_Xpath);
                if (noOfFlights > 0)
                {
                    for (int i = 1; i <= noOfFlights; i++)
                    {
                        if (GetAttributeValue(By.XPath("//*[@id='flight_details']//tbody//tr[" + (i + 1) + "]"), "class").Contains("row-border-merge"))
                        {
                            if (!GetCAPAvailabilityStatus(i).Contains("error") && !GetEMBAvailabilityStatus(i).Contains("error") && !GetLOADAvailabilityStatus(i).Contains("error") || GetRESAvailabilityStatus(i).Contains("error") && !GetCAPAvailabilityStatus(i + 1).Contains("error") && !GetEMBAvailabilityStatus(i + 1).Contains("error") && !GetLOADAvailabilityStatus(i + 1).Contains("error") || GetRESAvailabilityStatus(i + 1).Contains("error"))
                            {
                                flightNum = GetText(By.XPath("//*[@id='flight_details']//tbody//tr[" + i + "]//td[1]")).Trim().Split("AS")[1].Trim();
                                ConnectingflightNum = GetText(By.XPath("//*[@id='flight_details']//tbody//tr[" + (i + 1) + "]//td[1]")).Trim().Split("AS")[1].Trim();
                                btnBookFlight = btnBookFlight.Replace("1", i.ToString());
                                ScrollDown();
                                Click(By.XPath(btnBookFlight));

                                Log.Info("Flight " + flightNum + " & connecting flightNum " + ConnectingflightNum + "having minimum connection time restriction, is booked successfully");

                                break;
                            }
                            i += 1;

                        }

                    }

                }
                else
                {
                    Log.Info("No flight is available for booking from " + origin + " to " + destination + " on " + shippingDate);
                }


            }
            catch (Exception e)
            {
                Log.Error("Error in booking flight: " + e.ToString());
            }

        }


        public string GetFlightType(int flightRowNum)
        {
            lblFlightType = "//*[@id='flight_details']//tbody//tr[" + flightRowNum + "]//td[3]";
            string flightType = GetText(By.XPath(lblFlightType)).Trim();
            return flightType;
        }

        public string GetCAPAvailabilityStatus(int flightRowNum)
        {
            lblAvailabilityCap = "//*[@id='flight_details']//tbody//tr[" + flightRowNum + "]//span[text()='CAP']";
            string status = GetAttributeValue(By.XPath(lblAvailabilityCap), "class");
            return status;
        }

        public string GetEMBAvailabilityStatus(int flightRowNum)
        {
            lblAvailabilityEMB = "//*[@id='flight_details']//tbody//tr[" + flightRowNum + "]//span[text()='EMB']";
            string status = GetAttributeValue(By.XPath(lblAvailabilityEMB), "class");
            return status;
        }

        public string GetLOADAvailabilityStatus(int flightRowNum)
        {
            lblAvailabilityLOAD = "//*[@id='flight_details']//tbody//tr[" + flightRowNum + "]//span[text()='LOAD']";
            string status = GetAttributeValue(By.XPath(lblAvailabilityLOAD), "class");
            return status;
        }

        public string GetRESAvailabilityStatus(int flightRowNum)
        {
            lblAvailabilityRES = "//*[@id='flight_details']//tbody//tr[" + flightRowNum + "]//span[text()='RES']";
            string status = GetAttributeValue(By.XPath(lblAvailabilityRES), "class");
            return status;
        }

        public void ClickOnContinueFlightDetailsButton()
        {
            try
            {
                ScrollDown();
                Click(btnContinueFlightDetails_Name);
            }
            catch (Exception e)
            {
                Log.Error("Error in clicking on Continue button for flight details: " + e.ToString());
            }

        }

        public void OpenAndVerifyChargeDetails()
        {
            try
            {
                WaitForElementToBeClickable(btnOrangePencilCharge_Css, TimeSpan.FromSeconds(10));
                Click(btnOrangePencilCharge_Css);
                WaitForElementToBeInvisible(btnOrangePencilCharge_Css, TimeSpan.FromSeconds(5));
                ScrollDown();
            }
            catch (Exception e)
            {
                Log.Error("Error in opening and verifying charge details: " + e.ToString());
            }

        }

        public void EnterChargeDetails(string paymentType, string modeOfPayment)
        {
            this.chargeType = paymentType;
            this.modeOfPayment = modeOfPayment;

            try
            {
                WaitForElementToBeVisible(btnPaymentType_Xpath, TimeSpan.FromSeconds(10));

                string paymentTypeDisplayed = GetText(btnPaymentType_Xpath);

                if (!paymentTypeDisplayed.Equals(chargeType))
                {
                    Click(btnPaymentType_Xpath);
                }
            }
            catch (Exception e)
            {
                Log.Error("Error in entering charge details: " + e.ToString());
            }

        }


        public void ClickOnCalculateChargeButton()
        {
            try
            {

                while (!checkTextboxIsNotEmpty(txtIATACharge_Xpath))
                {
                    Click(btnCalculateCharges_Name);
                    WaitUntilTextboxIsNotEmpty(txtIATACharge_Xpath);

                }

            }
            catch (Exception e)
            {
                Log.Error("Error in clicking on Calculate Charge button: " + e.ToString());
            }



        }

        public string ClickingYesOnPopupWarnings(string errortype = null)
        {
            string errorText = "";



            if (errortype.Equals("Embargo"))
            {
                if (IsElementDisplayed(lblEmbargoDetails_Xpath, 1))
                {
                    Click(btnContinueEmbargo_Xpath);
                }
            }
            else if (errortype.Equals("Capture Irregularity"))
            {
                if (IsElementDisplayed(lblCaptureIrregularity_Xpath, 1))
                {
                    cip.captureIrregularity(pieces, weight);
                    SwitchToLTEContentFrame();
                }
            }

            else
            {
                SwitchToDefaultContent();
                if (IsElementDisplayed(popupWarning_Css, 1))
                {
                    errorText = GetText(popupAlertMessage_Xpath);
                    if (errorText.Contains("Active Cash Draw"))
                    {
                        Click(btnYesActiveCashDraw_Xpath);
                        WaitForElementToBeInvisible(btnYesActiveCashDraw_Xpath, TimeSpan.FromMilliseconds(500));
                    }

                    else
                    {
                        Click(btnYesActiveCashDraw_Xpath);
                        WaitForTextToBeInvisible(errorText, TimeSpan.FromMilliseconds(500));
                    }
                }

                SwitchToLTEContentFrame();
            }



            return errorText;
        }

        public void SelectModeOfPayment(string modeOfPayment)
        {
            try
            {
                ScrollDown();
                Click(drpdwnModeOfPayment_Name);
                SelectDropdownByVisibleTextUntil(drpdwnModeOfPayment_Name, modeOfPayment);

            }
            catch (Exception e)
            {
                Log.Error("Error in selecting mode of payment: Retrying... " + e.ToString());

            }

        }

        public string ClickOnContinueChargeButton()
        {

            try
            {
                if (chargeType.Equals("PP") && !serviceCargoClass.Equals("Free of Charge") && !serviceCargoClass.Equals("COMAT"))
                {
                    SelectModeOfPayment(modeOfPayment);
                }

            }
            catch (Exception)
            {
                ClickingYesOnPopupWarnings("");
                if (chargeType.Equals("PP") && !serviceCargoClass.Equals("Free of Charge") && !serviceCargoClass.Equals("COMAT"))
                {
                    SelectModeOfPayment(modeOfPayment);
                }

                ScrollDown();

            }
            totalAmountCharged = GetText(txtTotalCharge_Xpath).Split(':')[1].Trim();
            totalAmountCharged = totalAmountCharged.Split("USD")[0];
            Click(btnContinueChargeDetails_Name);
            WaitForElementToBeInvisible(btnContinueChargeDetails_Name, TimeSpan.FromSeconds(5));
            return totalAmountCharged;

        }

        public void EnterAcceptanceDetails()
        {
            try
            {
                EnterText(txtPieceAccepted_Name, pieces);
            }
            catch (Exception e)
            {
                Log.Error("Error in entering acceptance details: " + e.ToString());
            }

        }

        public void VerifyAndUpdateAcceptanceDetails()
        {
            try
            {
                Click(btnOrangePencilAcceptance_Css);
                WaitForElementToBeInvisible(btnOrangePencilAcceptance_Css, TimeSpan.FromSeconds(5));

            }
            catch (Exception)
            {
                Log.Error("Error in clicking the acceptance details, retrying.. ");
                Click(btnOrangePencilAcceptance_Css);
                WaitForElementToBeInvisible(btnOrangePencilAcceptance_Css, TimeSpan.FromSeconds(5));
            }
            EnterText(txtPieceAccepted_Name, pieces);
            EnterKeys(txtPieceAccepted_Name, Keys.Tab);


        }

        public void ClickOnContinueAcceptanceButton()
        {
            try
            {
                ScrollDown();
                Click(btnContinueAcceptanceDetails_Name);
                WaitForElementToBeInvisible(btnContinueAcceptanceDetails_Name, TimeSpan.FromSeconds(5));
            }
            catch (Exception e)
            {
                Log.Error("Error in clicking on Continue button for acceptance details: " + e.ToString());
            }

        }

        public void EnterScreeningDetails(int rownum, string screeningMethod, string screeningResult)
        {
            try
            {

                if (rownum > 1)
                {
                    int totalPieces = int.Parse(pieces);
                    string pieceFirstRow = (totalPieces - 1).ToString();
                    string pieceSecondRow = "1";

                    EnterText(txtScreeningAirport2_Xpath, origin);
                    SelectDropdownByVisibleText(drpdwnScreeningMethod2_Xpath, screeningMethod);
                    EnterText(txtScreeningPieces1_Xpath, pieceFirstRow);
                    EnterText(txtScreeningPieces2_Xpath, pieceSecondRow);
                    SelectDropdownByVisibleText(drpdwnScreeningResult2_Xpath, screeningResult);

                }
                else
                {

                    EnterText(txtScreeningAirport1_Xpath, origin);
                    SelectDropdownByVisibleText(drpdwnScreeningMethod1_Xpath, screeningMethod);
                    EnterText(txtScreeningPieces1_Xpath, pieces);
                    SelectDropdownByVisibleText(drpdwnScreeningResult1_Xpath, screeningResult);
                }
            }
            catch (Exception e)
            {
                Log.Error("Error in entering screening details: " + e.ToString());
            }


        }

        public void AddAnotherScreeningLine()
        {
            try
            {
                Click(btnAddScreeningRow_Css);
            }
            catch (Exception e)
            {
                Log.Error("Error in adding another screening line: " + e.ToString());
            }

        }

        public void VerifyAndUpdateScreeningDetails()
        {
            try
            {
                Click(btnOrangePencilScreening_Css);
                WaitForElementToBeInvisible(btnOrangePencilScreening_Css, TimeSpan.FromSeconds(5));

            }
            catch (Exception)
            {
                Log.Error("Error in verifying and updating screening details,retrying..:");
                Click(btnOrangePencilScreening_Css);
                WaitForElementToBeInvisible(btnOrangePencilScreening_Css, TimeSpan.FromSeconds(5));
            }
            EnterText(txtScreeningPieces1_Xpath, pieces);

        }

        public void ClickOnContinueScreeningButton()
        {
            try
            {
                ScrollDown();
                Click(btnContinueScreeningDetails_Name);
                WaitForElementToBeInvisible(btnContinueScreeningDetails_Name, TimeSpan.FromSeconds(5));
            }
            catch (Exception e)
            {
                Log.Error("Error in clicking on Continue button for screening details: " + e.ToString());
            }

        }

        public void ClickOnAWBVerifiedCheckbox()
        {
            try
            {
                if (!IsCheckboxChecked(chkBoxAwbVerified_Name))
                {
                    Click(chkBoxAwbVerified_Name);
                }
            }
            catch (Exception e)
            {
                Log.Error("Error in clicking on AWB verified checkbox: " + e.ToString());
            }

        }

        public void ClickSave()
        {
            noOfWindowBefore = GetNumberOfWindowsOpened();
            Click(btnSaveShipment_Name);

        }
        public void ClosePaymentPortalWindow()
        {
            WaitForNewWindowToOpen(TimeSpan.FromSeconds(5), noOfWindowBefore + 1);
            SwitchToLastWindow();
            ppp.ClosePaymentPortal();
            SwitchToLastWindow();
            SwitchToLTEContentFrame();
        }

        public void PaymentWithPPCCinPortal(string chargeType)
        {
            WaitForNewWindowToOpen(TimeSpan.FromSeconds(10), noOfWindowBefore + 1);
            SwitchToLastWindow();
            ppp.PaymentWithPPCC(chargeType);
            SwitchToLastWindow();
            SwitchToLTEContentFrame();
        }
   

        public (string, string) SaveShipmentDetailsAndHandlePopups()
        {
            log.Info("Saving Shipment Details and handling all popup function");
            int retryCount = 0;
            const int maxRetries = 3; // Maximum number of retries

            while (true)
            {
                try
                {
                    if ((CaptureBookingStatus() == "Confirmed") && (CaptureDataCaptureStatus() == "EXECUTED") && (CaptureAcceptanceStatus() == "Finalised") && (CaptureColorReadyForCarriageStatus().Contains("green")) && (CaptureColorCaptureCheckSheetStatus().Contains("green")) && (CaptureColorBlockStatus().Contains("green")))
                    {
                        awb_num = captureAWBNumber();
                        break;
                    }

                    try
                    {
                        totalPaybleAmount = ClickOnSaveButtonHandlePaymentPortal();
                    }
                    catch (Exception)
                    {
                        int noOfWindowsBefore = GetNumberOfWindowsOpened();
                        ClickingYesOnPopupWarnings("");
                        int noOfWindowsAfter = GetNumberOfWindowsOpened();
                        if (noOfWindowsAfter > noOfWindowsBefore)
                        {
                            SwitchToLastWindow();
                            totalPaybleAmount = ppp.HandlePaymentInPaymentPortal(this.chargeType);
                            WaitForNewWindowToOpen(TimeSpan.FromSeconds(3), noOfWindowsBefore);
                            SwitchToLastWindow();
                            SwitchToLTEContentFrame();
                        }

                    }
                }
                catch (StaleElementReferenceException)
                {
                    if (retryCount >= maxRetries)
                    {
                        throw; // Rethrow the exception if max retries are exceeded
                    }
                    log.Info($"Encountered StaleElementReferenceException, retrying... Attempt {retryCount + 1}");
                    retryCount++;                   
                    continue; // Retry the loop
                }
            }

            return (awb_num, totalPaybleAmount);
        }


        public string ClickOnSaveButtonHandlePaymentPortal()
        {
            log.Info("ClickOnSaveButtonHandlePaymentPortal function");
            int noOfWindowsBefore = GetNumberOfWindowsOpened();
            Click(btnSaveShipment_Name);
            if (IsElementDisplayed(lblEmbargoDetails_Xpath, 1))
            {
                Click(btnContinueEmbargo_Xpath);
            }

            WaitForNewWindowToOpen(TimeSpan.FromSeconds(3), noOfWindowsBefore + 1);
            int noOfWindowsAfter = GetNumberOfWindowsOpened();
            if (noOfWindowsAfter > noOfWindowsBefore)
            {
                SwitchToLastWindow();
                totalPaybleAmount = ppp.HandlePaymentInPaymentPortal(this.chargeType);               
                SwitchToLastWindow();
                SwitchToLTEContentFrame();
            }
            return totalPaybleAmount;

        }

        public void SaveDetailsWithChargeType(string chargeType)
        {

            this.chargeType = chargeType;
            int noOfWindowsBefore = GetNumberOfWindowsOpened();
            Click(btnSaveShipment_Name);
            if (IsElementDisplayed(lblEmbargoDetails_Xpath, 1))
            {
                Click(btnContinueEmbargo_Xpath);
            }
            WaitForNewWindowToOpen(TimeSpan.FromSeconds(10), noOfWindowsBefore + 1);
            int noOfWindowsAfter = GetNumberOfWindowsOpened();
            if (noOfWindowsAfter > noOfWindowsBefore)
            {
                SwitchToLastWindow();
                ppp.HandlePaymentInPaymentPortal(chargeType);
                SwitchToLastWindow();
                SwitchToLTEContentFrame();
            }

        }

        public void SaveDetailsWithCapturingIrregularity(string chargetyp)
        {
            this.chargeType = chargetyp;
            int noOfWindowsBefore = GetNumberOfWindowsOpened();
            ClickSave();
            ClickingYesOnPopupWarnings("");
            ClickingYesOnPopupWarnings("Embargo");
            ClickingYesOnPopupWarnings("Capture Irregularity");
            WaitForNewWindowToOpen(TimeSpan.FromSeconds(10), noOfWindowsBefore + 1);
            int noOfWindowsAfter = GetNumberOfWindowsOpened();
            if (noOfWindowsAfter > noOfWindowsBefore)
            {
                SwitchToLastWindow();
                ppp.HandlePaymentInPaymentPortal(chargeType);
                SwitchToLastWindow();
                SwitchToLTEContentFrame();
            }
            ClickingYesOnPopupWarnings("");

        }


        public string SaveShipmentCaptureAWB()
        {
            Click(btnSaveShipment_Name);
            if (IsElementDisplayed(lblEmbargoDetails_Xpath, 1))
            {
                Click(btnContinueEmbargo_Xpath);
            }

            awb_num = captureAWBNumber();
            return awb_num;
        }

        public (string, string) SaveWithDGAndCheckSheet(string chargetype, string unid, string propershipmntname, string pi, string noofpkg, string netqtyperpkg, string reportable)
        {
            this.chargeType = chargetype;
            Click(btnSaveShipment_Name);
            ClickingYesOnPopupWarnings("");
            dgp.HandleDGShipment(unid, propershipmntname, pi, noofpkg, netqtyperpkg, reportable);
            SwitchToLTEContentFrame();
            Click(btnSaveShipment_Name);
            ClickingYesOnPopupWarnings("");
            CaptureCheckSheetForDG();
            ClickOnAWBVerifiedCheckbox();

            string awb_num;
            while (true)
            {
                if ((CaptureBookingStatus() == "Confirmed") && (CaptureDataCaptureStatus() == "EXECUTED") && (CaptureAcceptanceStatus() == "Finalised") && (CaptureColorReadyForCarriageStatus().Contains("green")) && (CaptureColorCaptureCheckSheetStatus().Contains("green")) && (CaptureColorBlockStatus().Contains("green")))
                {
                    awb_num = captureAWBNumber();
                    break;
                }

                try
                {
                    totalPaybleAmount = ClickOnSaveButtonHandlePaymentPortal();

                }
                catch (Exception)
                {
                    int noOfWindowsBefore = GetNumberOfWindowsOpened();
                    ClickingYesOnPopupWarnings("");
                    int noOfWindowsAfter = GetNumberOfWindowsOpened();
                    if (noOfWindowsAfter > noOfWindowsBefore)
                    {
                        SwitchToLastWindow();
                        totalPaybleAmount = ppp.HandlePaymentInPaymentPortal(this.chargeType);
                        SwitchToLastWindow();
                        SwitchToLTEContentFrame();
                    }
                }


            }
            return (awb_num, totalPaybleAmount);

        }

        public string captureAWBNumber()
        {
            return GetText(lblAWBNo_Css);
        }

        public string CaptureBookingStatus()
        {
            return GetText(lblBookingConfirmation_Xpath);
        }

        public string CaptureDataCaptureStatus()
        {
            return GetText(lblDataCapture_Xpath);
        }

        public string CaptureAcceptanceStatus()
        {
            return GetText(lblAcceptance_Xpath);
        }

        public string CaptureColorReadyForCarriageStatus()
        {
            return GetAttributeValue(lblColorReadyForCarriage_Xpath, "class");
        }

        public string CaptureColorCaptureCheckSheetStatus()
        {
            return GetAttributeValue(lblColorCaptureChecksheet_Xpath, "class");
        }

        public string CaptureColorBlockStatus()
        {
            return GetAttributeValue(lblColorBlock_Xpath, "class");
        }

        public void CaptureCheckSheetForDG()
        {
            Click(lnkCaptureChecksheet_Xpath);
            SwitchToFrame(popupContainerFrameChksheet);
            List<IWebElement> DgSections = GetElements(lblTotalChkSheetSections_Xpath);
            int totalQuestions = 0;

            foreach (var section in DgSections)
            {
                if (section.Text == "Non Radioactive Checklist")
                {

                    string drpDwnQn = "//*[@id='tabs-1']//div[@id='configId']/h2[text()='dgSectionName']/parent::div/following-sibling::div//select";

                    drpDwnQn = drpDwnQn.Replace("dgSectionName", "Non Radioactive Checklist");
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
                else if (section.Text == "DGR HANDLING INFORMATION")
                {
                    string drpDwnQn = "//*[@id='tabs-1']//div[@id='configId']/h2[text()='dgSectionName']/parent::div/following-sibling::div//select";

                    drpDwnQn = drpDwnQn.Replace("dgSectionName", "DGR HANDLING INFORMATION");
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
                else if (section.Text == "CAO HANDLING INFORMATION")
                {
                    string drpDwnQn = "//*[@id='tabs-1']//div[@id='configId']/h2[text()='dgSectionName']/parent::div/following-sibling::div//select";

                    drpDwnQn = drpDwnQn.Replace("dgSectionName", "CAO HANDLING INFORMATION");
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
                else if (section.Text == "EMPLOYEE SHIPMENT VERIFICATION")
                {
                    string drpDwnQn = "//*[@id='tabs-1']//div[@id='configId']/h2[text()='dgSectionName']/parent::div/following-sibling::div//select";

                    drpDwnQn = drpDwnQn.Replace("dgSectionName", "EMPLOYEE SHIPMENT VERIFICATION");
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
                    EnterText(txtDateOfHire_Xpath, "01-Apr-2020");
                    EnterText(txtPeoplesoftNumber_Xpath, "5034988");
                    EnterKeys(txtPeoplesoftNumber_Xpath, Keys.Tab);

                }
            }
            if (IsElementEnabled(btnOKCaptureChkSheet_Xpath))
                Click(btnOKCaptureChkSheet_Xpath);
            SwitchToDefaultContent();
            Click(btnOKSuccessCheckSheet_Xpath);
            SwitchToLTEContentFrame();
        }

        public void EnterCAODGDetails(string chargetyp, string unid, string propershipmntname, string pi, string noofpkg, string netqtyperpkg, string reportable)
        {
            this.chargeType = chargetyp;
            Click(btnSaveShipment_Name);
            ClickingYesOnPopupWarnings("");
            dgp.EnterDetailsForCAODGShipment(unid, propershipmntname, pi, noofpkg, netqtyperpkg, reportable);
            SwitchToLTEContentFrame();            
        }

        public void SaveCAODGshipment(string flightType)
        {
            if (flightType.Equals("Combination"))
            {
                ClickSave();
                ClickingYesOnPopupWarnings("");
            }

        }

        public void ValidateWarningMessage(string expectedWarningMessage)
        {

            WaitForElementToBeVisible(lblWarningMessage_Css, TimeSpan.FromSeconds(5));
            string actualWarningMessage = GetText(lblWarningMessage_Css);
            if (!actualWarningMessage.Contains(expectedWarningMessage))
            {
                Log.Error("Warning message is not as expected. Expected: " + expectedWarningMessage + " Actual: " + actualWarningMessage);
                Assert.Fail("Warning message is not as expected. Expected: " + expectedWarningMessage + " Actual: " + actualWarningMessage);

            }
            else
            {
                Log.Info("Warning message is as expected: " + actualWarningMessage);
            }
        }

        public string ValidateAWBStatus(string expectedStatus)
        {
            string actualStatus = CaptureDataCaptureStatus();
            if (!actualStatus.Contains(expectedStatus))
            {
                Log.Error("AWB status is not as expected. Expected: " + expectedStatus + " Actual: " + actualStatus);
                Assert.Fail("AWB status is not as expected. Expected: " + expectedStatus + " Actual: " + actualStatus);

            }
            else
            {
                Log.Info("AWB status is as expected: " + actualStatus);
                awb_num = captureAWBNumber();
                Log.Info("AWB number is: " + awb_num);
            }
            return awb_num;
        }

        public void ValidateCommodityChargeAmount()
        {

            if (totalAmountCharged != totalPaybleAmount)
            {
                Log.Error("Total amount charged is not equal to total payable amount. Total Amount Charged: " + totalAmountCharged + " Total Payable Amount: " + totalPaybleAmount);
                Assert.Fail("Total amount charged is not equal to total payable amount. Total Amount Charged: " + totalAmountCharged + " Total Payable Amount: " + totalPaybleAmount);

            }
            else
            {
                Log.Info("Total amount charged is equal to total payable amount. Total Amount Charged: " + totalAmountCharged + " Total Payable Amount: " + totalPaybleAmount);
            }


        }

        public void CloseLTE001Screen()
        {
            while (!IsElementDisplayed(btnCloseShipment_Name))
            {
                try
                {
                    Click(btnCloseShipment_Name);
                    WaitForElementToBeInvisible(btnCloseShipment_Name, TimeSpan.FromSeconds(2));
                }
                catch (Exception)
                {
                    ClickingYesOnPopupWarnings("");
                    Log.Error("Error in closing LTE001 screen, retrying..");
                }

            }


        }

        // Export Manifest Calling Functions //

        public void EnterFlightDateExportManifest()
        {
            try
            {
                emp.EnterFlightDate(shippingDate);
            }
            catch (Exception e)
            {
                Log.Error("Error in entering flight date in export manifest: " + e.ToString());
            }

        }

        public void EnterFlightinExportManifest(string fltnum)
        {
            try
            {
                if (fltnum.Equals(""))
                {
                    emp.EnterFlightNumber(flightNum);
                }
                else
                {
                    emp.EnterFlightNumber(fltnum);
                }

            }
            catch (Exception e)
            {
                Log.Error("Error in entering flight details in export manifest: " + e.ToString());
            }

        }

        public string CreateNewULDCartExportManifest(string carttype, string pou)
        {
            if (pou.Equals(""))
            {
                cartULDNum = emp.CreateULDOrCart(carttype, destination);
            }
            else
            {
                cartULDNum = emp.CreateULDOrCart(carttype, pou);
            }

            return cartULDNum;
        }

        public void FilterOutAWBULDInExportManifest(string awbSectionName)
        {
            if (awbSectionName.Equals("PlannedShipment"))
            {
                awb_num = awb_num.Split("-")[1];
                emp.FilterOutPlannedAWBAndULD(awb_num, cartULDNum);
            }
            else if (awbSectionName.Equals("LyingList"))
            {
                emp.FilterOutLyingListAWBAndULD(cartULDNum);
            }

        }

        public void FilterSplitAndAssignAWBToULDExportManifest(string awbSectionName, string splitPieces)
        {
            if (awbSectionName.Equals("PlannedShipment"))
            {
                awb_num = awb_num.Split("-")[1];
                emp.FilterOutPlannedAWBSplitAndAssign(awb_num, cartULDNum, splitPieces);
            }


        }


    }
}
