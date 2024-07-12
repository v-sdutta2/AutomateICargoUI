using AventStack.ExtentReports;
using iCargoUIAutomation.Features;
using iCargoUIAutomation.utilities;
using log4net;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V121.Debugger;
using SharpCompress.Compressors.Xz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace iCargoUIAutomation.pages
{
    public class ExportManifestPage : BasePage
    {
        public static string cartUldNum = "";
        ILog Log = LogManager.GetLogger(typeof(ExportManifestPage));


        public ExportManifestPage(IWebDriver driver) : base(driver)
        {

        }

        //OPR344 - Export Manifest/Screen
        private By contentFrameManifest_Xpath = By.XPath("//div[@id='OPR344']/iframe");
        private By txtFlightNoManifest_Name = By.Name("flightnumber.flightNumber");
        private By txtFlightDateManifest_Name = By.Name("flightnumber.flightDate");
        private By btnListManifest_Id = By.Id("CMP_Operations_FltHandling_ExportManifest_List");
        private By btnClearManifest_Id = By.Id("CMP_Operations_FltHandling_ExportManifest_Clear");

        //Export Manifest Headers 
        private By lblStatus_CSS = By.CssSelector(".header-panel .portlet-footer strong");
        private By btnOrangePencilEditManifest_Css = By.CssSelector(".header-panel .ico-pencil-rounded-orange");


        //Assigned Shipment;
        private By btnAddULD_Xpath = By.XPath("//button//span[text()='Add ULD']");
        private By chkBoxBarrow_Xpath = By.XPath("//*[text()='Barrow']/preceding-sibling::input");
        private By txtULDNumber_Name = By.Name("uld.uldNumber");
        private By drpdwnPOU_Xpath = By.XPath("//*[contains(@class,'assignshipments')]//*[text()='POU']//following-sibling::div");
        private By drpdwnPOUCOMBO_Xpath = By.XPath("//*[@class='Select-input' and @role='combobox']");
        private By txtAWBNumberAssignShipment_Id = By.Id("Awb_DocumentNumber_idx");
        private By txtPiecesAssignShipment_Name = By.Name("awb.pieces");
        private By btnSave_Xpath = By.XPath("//button[text()='Save ']");
        private By btnClose_Xpath = By.XPath("//*[contains(@class,'assignshipments')]//button[text()='Close']");
        private By txtAssignShipmentFilter_Xpath = By.XPath("//*[contains(@class,'assignshipments')]//*[@class='table-header__search']/input");
        private By chkBoxSelectCartULDNum_Xpath = By.XPath("//*[contains(@class,'assignshipments')]//input[@id='select-0']");
        private By btnCartULDNum_Xpath = By.XPath("//*[@aria-describedby='uldNumber']");
        private By btnExpandCartULD_Xpath = By.XPath("//*[contains(@class,'assignshipments')]//button[@data-type='row-toggler']");
        private By btnOffloadAWB_Xpath = By.XPath("//button[contains(@id,'awb_offload')]");

        //Offload AWB Modal
        private By modalOffloadAWB_Css = By.CssSelector(".modal-content");
        private By drpdwnOffloadReason_Xpath = By.XPath("//label[text()='Offload Reason']/parent::div//*[@class='Select-control']");
        private By txtOffloadRemarks_Css = By.CssSelector("input[name='offloadRemarks']");
        private By chkBoxMoveToAnotherFlight_Css = By.CssSelector("input[name='reassignCheckbox']");
        private By chkBoxBarrowOffloadModal_Css = By.CssSelector("input[name='barrowFlag']");
        private By txtUldNumOffloadModal_Css = By.CssSelector("#uld_uldNumber");
        private By txtPOUOffloadModal_CSS = By.CssSelector("input[name='pou']");
        private By txtFltNumOffloadModal_CSS = By.CssSelector("input[id='flightnumber_flightcode']");
        private By txtFltDateOffloadModal_Css = By.CssSelector("input[id='flightnumber_dateField']");
        private By btnSaveOffloadModal_Xpath = By.XPath("//button[@formname='offloadPopupForm' and text()='Save']");
        private By btnClearOffloadModal_Xpath = By.XPath("//button[@formname='offloadPopupForm' and text()='Clear']");
        private By btnCloseOffloadModal_Xpath = By.XPath("//button[@formname='offloadPopupForm' and text()='Close']");

        // Planned Shipment
        private By chkBoxIncludeQueued_Xpath = By.XPath("//*[text()='Include Queued']//preceding-sibling::input");
        private By txtPlannedShipmentFilter_Xpath = By.XPath("//*[contains(@class,'planned-shipment')]//*[@class='table-header__search']/input");
        private By chkBoxSelectAWBNum_Xpath = By.XPath("//*[contains(@class,'planned-shipment')]//input[@id='select-0']");
        private By chkBoxSelectAWBNumSplitted_Xpath = By.XPath("//*[contains(@class,'planned-shipment')]//input[@id='select-1']");
        private By btnSplitAssignThreeDots_Xpath = By.XPath("(//*[contains(@class,'planned-shipment')]//button[contains(@class,'dropdown-toggle')])[2]");
        private By drpdwnMenuSplitAssign_Xpath = By.XPath("//*[contains(@class,'planned-shipment')]//div[@role='rowgroup']//div[@role='menu']");
        private By btnSplitAssign_Xpath = By.XPath("//*[contains(@class,'planned-shipment')]//button[text()=' Split & Assign']");
        private By btnCaptureIrregularity_Xpath = By.XPath("//*[contains(@class,'planned-shipment')]//button[text()=' Capture Irregularity']");
        private By listPlannedShipmentAWBs_Xpath = By.XPath("//*[contains(@class,'planned-shipment')]//a[@class='awb-number awb-number-link']");
        //Split and Assign Modal
        private By modalSplitShipment_Css = By.CssSelector(".modal-content");
        private By txtSplitAssignPieces_Css = By.CssSelector(".modal-content input[name='pieces']");
        private By txtSplitAssignWeight_Css = By.CssSelector(".modal-content input[name='weight.roundedDisplayValue']");
        private By btnOkSplitAssign_Xpath = By.XPath("//*[@class='modal-footer']//button[text()='Ok']");
        private By btnClearSplitAssign_Xpath = By.XPath("//*[@class='modal-footer']//button[text()='Clear']");
        

        //Lying List
        private By btnLyingList_Xpath = By.XPath("//*[text()='Lying List']");
        private By btnLyingListAWB_Xpath = By.XPath("//button[text()='AWB(s)']");
        private By btnLyingListFilter_Id = By.Id("lyingListTable-datafilter");
        private By txtLyingListFilterOrigin_Name = By.Name("filter.origin");
        private By txtLyingListFilterAWB_Name = By.Name("filter.documentNumber");
        private By drpdwnReadyForcarriage_Xpath = By.XPath("//label[text()='Ready For Carriage']/parent::div//*[@class='Select-control']");
        private By btnApplyFilter_Id = By.Id("lyingListTable-datafilter-applybtn");
        private By chkBoxLyingListAWB_Xpath = By.XPath("//*[contains(@class,'lying-list')]//input[@id='select-0']");

        //Export Manifest Warning Popups
        private By WarningPopup_Xpath = By.XPath("//*[@aria-describedby='popupContainer']");
        private By lblWarningPopup_Xpath = By.XPath("//*[@aria-describedby='popupContainer']//span");
        private By framePopupContainerFrame_Id = By.Id("popupContainerFrame");
        private By lblEmbargoDescription_Xpath = By.XPath("//table[@id='showEmbargo']//td[text()='Description']");
        private By btnContinueWarningPopup_Xpath = By.XPath("//button[@name='btContinue']");
        private By lblWarningMessageModal_CSS = By.CssSelector(".modal-content .icdialog_message");
        private By btnOkWarningMessageModal_Xpath = By.XPath("//*[@class='modal-footer']/button[text()='Ok']");
        private By btnCancelWarningMessageModal_Xpath = By.XPath("//*[@class='modal-footer']/button[text()='Cancel']");
        private By lblErrorPopOver_CSS = By.CssSelector(".errorpopover p");
        private By lblScreeningWarning_Css= By.CssSelector("#showEmbargo tbody td:nth-child(3)");
        private By btnCloseScreeningWarning_Id= By.Id("CMP_Reco_Defaults_UX_ShowEmbargo_btnClose");


        //Export Manifest Footer Section
        private By btnManifest_Xpath = By.XPath("//*[@class='footer-panel']//button[text()='Manifest']");
        private By btnCloseManifest_Xpath = By.XPath("//*[@class='footer-panel']//button[text()='Close']");

        //Print Manifest Window
        private By lblPrintManifest_Xpath = By.XPath("//*[text()='Print Manifest']");
        private By framePrintManifest_Id = By.Id("popupContainerFrame");
        private By btnOKPrintManifest_Name = By.Name("btOk");
        private By btnClosePrintManifest_Name = By.Name("btClose");
        private By btnCrossPrintManifestWindow_Xpath = By.XPath("//*[contains(@class,'ui-dialog-titlebar') and contains(.,'Print Manifest')]/button");
        private By lblMessagePrintManifestWindow_CSS = By.CssSelector("#bodyStyle h1");

        //Manifest PDF Report
        private By frameManifestPDF_Id = By.Id("ReportContainerFrame");
        private By btnSavePDFMenu_Xpath = By.XPath("//*[@id='__menuBar']//*[@id='save']");
        private By btnSavePDF_Xpath = By.XPath("//*[@class='__submenu __menuSave open']//div[@id='ok']");


        public void SwitchToManifestFrame()
        {
            SwitchToFrame(contentFrameManifest_Xpath);
            Hooks.Hooks.UpdateTest(Status.Info,"Switched to Manifest Frame");
        }

        public void ClickOnFlightTextBox()
        {
            Click(txtFlightNoManifest_Name);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Flight Number Text Box");
        }

        public void EnterFlightNumber(string flightNumber)
        {
            EnterText(txtFlightNoManifest_Name, flightNumber);
            Hooks.Hooks.UpdateTest(Status.Info, "Entered Flight Number: " + flightNumber);
        }

        public void EnterFlightDate(string flightDate)
        {
            EnterText(txtFlightDateManifest_Name, flightDate);
            Hooks.Hooks.UpdateTest(Status.Info, "Entered Flight Date: " + flightDate);
        }

        public void ClickOnListButton()
        {
            Click(btnListManifest_Id);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on List Button");
        }

        public void ClickOrangePencilToEditManifest()
        {
            Click(btnOrangePencilEditManifest_Css);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Orange Pencil to Edit Manifest");
            WaitForElementToBeVisible(btnListManifest_Id, TimeSpan.FromSeconds(3));
        }

        public string CreateULDOrCart(string cartType, string POU)
        {
            ClickOnADDULDButton();
            int cartUldNumInt = GetCartOrULDNumber(cartType);

            while (true)
            {
                if (cartType.ToLower() == "cart")
                {
                    cartUldNum = "BC" + cartUldNumInt;
                }
                else
                {
                    cartUldNum = "AAA" + cartUldNumInt + "AS";
                }


                EnterTextWithCheck(txtULDNumber_Name, cartUldNum);
                Hooks.Hooks.UpdateTest(Status.Info, "Entered ULD/Cart Number: " + cartUldNum);
                EnterKeys(txtULDNumber_Name, Keys.Tab);
                Thread.Sleep(2000);         

                if (GetAttributeValue(drpdwnPOUCOMBO_Xpath, "aria-disabled") == "false")
                {
                    break;
                }
                else
                {
                    cartUldNumInt++;
                }
            }
            SelectPOU(POU);
            ClickOnSaveULDButton();
            ClickOnCloseULDButton();

            return cartUldNum;
        }

        public string CreateNewULDCartByTypingAWB(string cartType, string POU, string awb, string pieces)
        {
            ClickOnADDULDButton();
            int cartUldNumInt = GetCartOrULDNumber(cartType);

            while (true)
            {
                if (cartType.ToLower() == "cart")
                {
                    cartUldNum = "BC" + cartUldNumInt;
                }
                else
                {
                    cartUldNum = "AAA" + cartUldNumInt + "AS";
                }


                EnterTextWithCheck(txtULDNumber_Name, cartUldNum);
                Hooks.Hooks.UpdateTest(Status.Info, "Entered ULD/Cart Number: " + cartUldNum);
                EnterKeys(txtULDNumber_Name, Keys.Tab);
                Thread.Sleep(2000);

                if (GetAttributeValue(drpdwnPOUCOMBO_Xpath, "aria-disabled") == "false")
                {
                    break;
                }
                else
                {
                    cartUldNumInt++;
                }
            }
            SelectPOU(POU);
            TypeAWBNumberAndPiecesInsideCart(awb, pieces);
            WaitForElementToBeVisible(btnSave_Xpath, TimeSpan.FromSeconds(5));
            ClickOnElementIfEnabled(btnSave_Xpath);            
            HandleWarningMessage();
            if (IsElementDisplayed(btnOkWarningMessageModal_Xpath))
            {
                Click(btnOkWarningMessageModal_Xpath);
                Hooks.Hooks.UpdateTest(Status.Info, "Clicked on OK button on Warning Message Modal");
                WaitForElementToBeInvisible(btnOkWarningMessageModal_Xpath, TimeSpan.FromSeconds(3));
            }           

            return cartUldNum;
        }

        public void TypeAWBNumberAndPiecesInsideCart(string awb, string pieces)
        {
            EnterText(txtAWBNumberAssignShipment_Id, awb);
            Hooks.Hooks.UpdateTest(Status.Info, "Entered AWB Number: " + awb);
            EnterKeys(txtAWBNumberAssignShipment_Id, Keys.Tab);
            ClickOnElementIfEnabled(txtPiecesAssignShipment_Name);
            EnterText(txtPiecesAssignShipment_Name, pieces);
            Hooks.Hooks.UpdateTest(Status.Info, "Entered Pieces: " + pieces);
            EnterKeys(txtPiecesAssignShipment_Name, Keys.Tab);
        }

        public void AssignAWBToPreBuiltCartByAWBTyping(string awb, string pieces)
        {
            TypeAWBNumberAndPiecesInsideCart(awb, pieces);
            WaitForElementToBeVisible(btnSave_Xpath, TimeSpan.FromSeconds(5));
            ClickOnElementIfEnabled(btnSave_Xpath);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Save Button");
            HandleWarningMessage();
            if (IsElementDisplayed(btnOkWarningMessageModal_Xpath))
            {
                Click(btnOkWarningMessageModal_Xpath);
                Hooks.Hooks.UpdateTest(Status.Info, "Clicked on OK button on Warning Message Modal");
                WaitForElementToBeInvisible(btnOkWarningMessageModal_Xpath, TimeSpan.FromSeconds(3));
            }
        }

        public void ClickOnADDULDButton()
        {
            Click(btnAddULD_Xpath);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Add ULD Button");
        }

        public int GetCartOrULDNumber(string cartType)
        {
            int cartUldNumInt = 0;
            if (cartType.ToLower() == "cart")
            {
                Click(chkBoxBarrow_Xpath);
                cartUldNumInt = RandomNumber(5);
            }
            else
            {
                cartUldNumInt = RandomNumber(4);
            }
            Hooks.Hooks.UpdateTest(Status.Info, "Generated ULD/Cart Number: " + cartUldNumInt);
            return cartUldNumInt;
        }

        public void SelectPOU(string POU)
        {
            Click(drpdwnPOU_Xpath);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on POU Dropdown");
            WaitForElementToBeVisible(By.XPath($"//div[contains(@class,'assignshipments')]//div[text()='{POU}']"), TimeSpan.FromSeconds(5));
            By optionXpath = By.XPath($"//div[contains(@class,'assignshipments')]//div[text()='{POU}']");
            Click(optionXpath);
            Hooks.Hooks.UpdateTest(Status.Info, "Selected POU: " + POU);
        }

        public void ClickOnSaveULDButton()
        {
            WaitForElementToBeVisible(btnSave_Xpath, TimeSpan.FromSeconds(5));
            ClickOnElementIfEnabled(btnSave_Xpath);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Save Button");
            WaitForElementToBeDisabled(txtULDNumber_Name, TimeSpan.FromSeconds(10));
        }

        public void ClickOnCloseULDButton()
        {
            WaitForElementToBeVisible(btnClose_Xpath, TimeSpan.FromSeconds(5));
            ClickOnElementIfEnabled(btnClose_Xpath);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Close Button");
        }

        public void ClickOnEditULDButton()
        {
            WaitForElementToBeVisible(By.XPath("//button[contains(@id,'uld_edituld-" + cartUldNum + "')]"), TimeSpan.FromSeconds(5));
            Click(By.XPath("//button[contains(@id,'uld_edituld-"+cartUldNum+"')]"));
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Edit ULD Button");
            WaitForElementToBeVisible(txtAWBNumberAssignShipment_Id, TimeSpan.FromSeconds(5));
        }

        public void SelectAWBFromPlannedShipmentList(string AWB_Number)
        {
            List<IWebElement> AWBList = GetElements(listPlannedShipmentAWBs_Xpath);
            foreach (IWebElement AWB in AWBList)
            {
                if (AWB.Text.Contains(AWB_Number))
                {                    
                    Click(By.XPath("//*[text()='"+ AWB_Number + "']/ancestor::div[@aria-colindex=4]/preceding-sibling::div[@aria-colindex=2]/input"));
                    Hooks.Hooks.UpdateTest(Status.Info, "Selected AWB: " + AWB_Number);
                    break;
                }
            }
        }

        public void FilterOutPlannedAWBAndULD(string AWB_Number, string Cart_Uld_Num)
        {
            int attempts = 0;
            while (attempts < 2)
            {
                try
                {
                    Click(txtAssignShipmentFilter_Xpath);

                    while (true)
                    {
                        if (IsElementDisplayed(By.CssSelector("[data-uldnumber='" + Cart_Uld_Num + "']")))
                        {
                            break;
                        }
                        EnterText(txtAssignShipmentFilter_Xpath, Cart_Uld_Num);
                        Hooks.Hooks.UpdateTest(Status.Info, "Entered ULD/Cart Number: " + Cart_Uld_Num);
                        Click(txtAssignShipmentFilter_Xpath);
                        EnterKeys(txtAssignShipmentFilter_Xpath, Keys.Tab);
                        WaitForElementToBeVisible(By.XPath("//*[text()='" + Cart_Uld_Num + "']"), TimeSpan.FromSeconds(5));
                    }                   
                    Click(By.XPath("//input[@name='uldManifestTable-select' and contains(@rowkey,'" + Cart_Uld_Num + "')]"));
                    
                    ClickOnElementIfEnabled(chkBoxIncludeQueued_Xpath);
                    Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Include Queued Checkbox");
                    WaitForElementToBeVisible(txtPlannedShipmentFilter_Xpath, TimeSpan.FromSeconds(10));
                    EnterText(txtPlannedShipmentFilter_Xpath, AWB_Number);
                    Hooks.Hooks.UpdateTest(Status.Info, "Entered AWB Number: " + AWB_Number);
                    Click(txtPlannedShipmentFilter_Xpath);
                    EnterKeys(txtPlannedShipmentFilter_Xpath, Keys.Tab);
                    WaitForElementToBeVisible(By.XPath("//*[text()='" + AWB_Number + "']"), TimeSpan.FromSeconds(5));
                    SelectAWBFromPlannedShipmentList(AWB_Number);
                    Click(By.XPath("//*[@aria-describedby='uldNumber']/*[@data-uldnumber='" + Cart_Uld_Num + "']"));

                    HandleWarningMessage();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    attempts++;
                    Hooks.Hooks.UpdateTest(Status.Info, "Stale Element Exception Occurred. Retrying...");
                }
            }
        }

        public void FilterOutPlannedAWBSplitAndAssign(string AWB_Number, string Cart_Uld_Num, string splitPieces)
        {
            int attempts = 0;
            while (attempts < 2)
            {
                try
                {
                    Click(txtAssignShipmentFilter_Xpath);

                    while (true)
                    {
                        if (IsElementDisplayed(By.CssSelector("[data-uldnumber='" + Cart_Uld_Num + "']")))
                        {
                            break;
                        }
                        EnterText(txtAssignShipmentFilter_Xpath, Cart_Uld_Num);
                        Hooks.Hooks.UpdateTest(Status.Info, "Entered ULD/Cart Number: " + Cart_Uld_Num);
                        Click(txtAssignShipmentFilter_Xpath);
                        EnterKeys(txtAssignShipmentFilter_Xpath, Keys.Tab);
                        WaitForElementToBeVisible(By.XPath("//*[text()='" + Cart_Uld_Num + "']"), TimeSpan.FromSeconds(5));
                    }
                   
                    Click(By.XPath("//input[@name='uldManifestTable-select' and contains(@rowkey,'" + Cart_Uld_Num + "')]"));
                    ClickOnElementIfEnabled(chkBoxIncludeQueued_Xpath);
                    Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Include Queued Checkbox");
                    WaitForElementToBeVisible(txtPlannedShipmentFilter_Xpath, TimeSpan.FromSeconds(10));
                    EnterText(txtPlannedShipmentFilter_Xpath, AWB_Number);
                    Hooks.Hooks.UpdateTest(Status.Info, "Entered AWB Number: " + AWB_Number);
                    Click(txtPlannedShipmentFilter_Xpath);
                    EnterKeys(txtPlannedShipmentFilter_Xpath, Keys.Tab);
                    WaitForElementToBeVisible(By.XPath("//*[text()='" + AWB_Number + "']"), TimeSpan.FromSeconds(5));

                    SplitAndAssignAWB(splitPieces);
                    SelectAWBFromPlannedShipmentList(AWB_Number);                
                    Click(By.XPath("//*[@aria-describedby='uldNumber']/*[@data-uldnumber='" + Cart_Uld_Num + "']"));
                    HandleWarningMessage();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    attempts++;
                    Hooks.Hooks.UpdateTest(Status.Info, "Stale Element Exception Occurred. Retrying...");
                }
            }
        }

        public void SplitAndAssignAWB(string splitPiece)
        {
            Click(btnSplitAssignThreeDots_Xpath);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Three Dots for Split & Assign");
            WaitForElementToBeVisible(drpdwnMenuSplitAssign_Xpath, TimeSpan.FromSeconds(2));
            Click(btnSplitAssign_Xpath);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Split & Assign");
            WaitForElementToBeVisible(modalSplitShipment_Css, TimeSpan.FromSeconds(2));
            Click(txtSplitAssignPieces_Css);
            EnterText(txtSplitAssignPieces_Css, splitPiece);
            Hooks.Hooks.UpdateTest(Status.Info, "Entered Split Pieces: " + splitPiece);
            EnterKeys(txtSplitAssignPieces_Css, Keys.Tab);
            Click(btnOkSplitAssign_Xpath);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on OK Button");
            WaitForElementToBeInvisible(modalSplitShipment_Css, TimeSpan.FromSeconds(2));
        }


        public void FilterOutLyingListAWBAndULD(string Cart_Uld_Num, string preBookedAWB="", string readyForCarriageOption = "Yes")
        {
            ClickOnLyingList();
            ClickOnLyingListFilter();            
            if (preBookedAWB != "")
            {
                EnterText(txtLyingListFilterAWB_Name, preBookedAWB);
                Hooks.Hooks.UpdateTest(Status.Info, "Entered AWB Number: " + preBookedAWB);
                EnterKeys(txtLyingListFilterAWB_Name, Keys.Tab);
                ClickOnApplyFilter(); 
                Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Apply Filter");
                Click(By.XPath("//*[text()='" + preBookedAWB + "']/ancestor::div[@aria-colindex=4]/preceding-sibling::div[@aria-colindex=2]/input"));
                Hooks.Hooks.UpdateTest(Status.Info, "Selected AWB: " + preBookedAWB);
                PlaceShipmentOnCartToManifest();
               
            }
            else
            {
                SelectReadyForCarriage(readyForCarriageOption);
                ClickOnApplyFilter();
                ClickOnCheckBoxLyingListAWB();
                PlaceShipmentOnCartToManifest();
                HandleWarningMessage();
            }         
           
           
            
        }
       

        public void ClickOnLyingList()
        {
            Click(btnLyingList_Xpath);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Lying List");
            WaitForElementToBeVisible(btnLyingListFilter_Id, TimeSpan.FromSeconds(3));
        }

        public void ClickOnLyingListFilter()
        {
            try
            {
                if (IsElementDisplayed(chkBoxLyingListAWB_Xpath))
                {
                    Click(btnLyingListFilter_Id);
                    Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Lying List Filter");
                }
                else
                {
                    Hooks.Hooks.UpdateTest(Status.Fail, "AWB is not available in Lying List");
                    Log.Error("AWB is not available in Lying List");
                }
            }
            catch
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Error in clicking on the Lying List");
                Log.Error("Error in clicking on the Lying List");
            }


        }

        public void SelectReadyForCarriage(string optionReadyForCarriage)
        {
            Click(drpdwnReadyForcarriage_Xpath);
            Click(By.XPath($"//div[contains(@class,'lying-list')]//div[text()='{optionReadyForCarriage}']"));
            Hooks.Hooks.UpdateTest(Status.Info, "Selected Ready For Carriage Option: " + optionReadyForCarriage);
        }

        public void ClickOnApplyFilter()
        {
            Click(btnApplyFilter_Id);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Apply Filter");
            WaitForElementToBeInvisible(btnApplyFilter_Id, TimeSpan.FromSeconds(5));

        }

        public void ClickOnCheckBoxLyingListAWB()
        {
            Click(chkBoxLyingListAWB_Xpath);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on AWB Checkbox");
        }

        public void PlaceShipmentOnCartToManifest()
        {
            EnterText(txtAssignShipmentFilter_Xpath, cartUldNum);
            Hooks.Hooks.UpdateTest(Status.Info, "Entered ULD/Cart Number: " + cartUldNum);
            Click(txtAssignShipmentFilter_Xpath);
            EnterKeys(txtAssignShipmentFilter_Xpath, Keys.Tab);
            WaitForElementToBeVisible(By.XPath("//*[text()='" + cartUldNum + "']"), TimeSpan.FromSeconds(5));
            Click(By.XPath("//input[@name='uldManifestTable-select' and contains(@rowkey,'" + cartUldNum + "')]"));           
            Click(By.XPath("//*[@aria-describedby='uldNumber']/*[@data-uldnumber='" + cartUldNum + "']"));  
            Hooks.Hooks.UpdateTest(Status.Info, "Selected ULD/Cart Number: " + cartUldNum);
        }

        public void ValidateWarningMessageAndCloseModal(string messageToValidate)
        {
            WaitForElementToBeVisible(lblWarningMessageModal_CSS, TimeSpan.FromSeconds(5));
            string warningModalMessage = GetText(lblWarningMessageModal_CSS);
            if (warningModalMessage.Contains(messageToValidate))
            {
                //Assert.Pass("Warning message is displayed as expected: " + warningModalMessage);
                while (IsElementDisplayed(btnOkWarningMessageModal_Xpath))
                {
                    Click(btnOkWarningMessageModal_Xpath);
                    Hooks.Hooks.UpdateTest(Status.Info, "Clicked on OK Button on Warning Modal");
                }

                WaitForElementToBeInvisible(btnOkWarningMessageModal_Xpath, TimeSpan.FromSeconds(3));
            }
            else
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Warning message is not displayed as expected");
                Assert.Fail("Warning message is not displayed as expected");
            }

        }

        public void ValidateWarningMessageAndCancelModal(string messageToValidate)
        {
            WaitForElementToBeVisible(lblWarningMessageModal_CSS, TimeSpan.FromSeconds(5));
            string warningModalMessage = GetText(lblWarningMessageModal_CSS);
            if (warningModalMessage.Contains(messageToValidate))
            {               
                while (IsElementDisplayed(btnCancelWarningMessageModal_Xpath))
                {
                    Click(btnCancelWarningMessageModal_Xpath);
                    Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Cancel Button on Warning Modal");
                }
                
                Hooks.Hooks.UpdateTest(Status.Info, "Warning message is displayed as expected: " + warningModalMessage);
                Assert.Pass("Warning message is displayed as expected: " + warningModalMessage);
            }
            else
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Warning message is not displayed as expected");
                Assert.Fail("Warning message is not displayed as expected");
            }

        }

        public void HandleWarningMessage()
        {
            if (IsElementDisplayed(WarningPopup_Xpath))
            {
                string popupTitle = GetText(lblWarningPopup_Xpath);

                if (popupTitle == "Check Embargo")
                {
                    SwitchToFrame(framePopupContainerFrame_Id);
                    Click(lblEmbargoDescription_Xpath);
                    while (IsElementDisplayed(btnContinueWarningPopup_Xpath))
                    {
                        ClickElementUsingActions(btnContinueWarningPopup_Xpath);  
                        Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Continue Button on Warning Popup");
                        WaitForElementToBeInvisible(btnContinueWarningPopup_Xpath, TimeSpan.FromSeconds(3));
                    }
                    SwitchToDefaultContent();
                    SwitchToManifestFrame();
                }
            }
        }

        public void ValidateErrorMessageOnPopup(string expectedErrorMessage)
        {

            if (IsElementDisplayed(WarningPopup_Xpath))
            {
                SwitchToFrame(framePopupContainerFrame_Id);
                string actualErrorMessage = GetText(lblScreeningWarning_Css);
                if (actualErrorMessage.Contains(expectedErrorMessage))
                {
                    Hooks.Hooks.UpdateTest(Status.Info, "Error message is as expected: " + actualErrorMessage);
                    Log.Info("Error message is as expected: " + actualErrorMessage);
                }
                else
                {
                    Hooks.Hooks.UpdateTest(Status.Fail, "Error message is not as expected. Expected: " + expectedErrorMessage + " Actual: " + actualErrorMessage);
                    Log.Error("Error message is not as expected. Expected: " + expectedErrorMessage + " Actual: " + actualErrorMessage);
                    Assert.Fail("Error message is not as expected. Expected: " + expectedErrorMessage + " Actual: " + actualErrorMessage);
                }
                ClickElementUsingActions(btnCloseScreeningWarning_Id);
                Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Close Button on Screening Warning Popup");
                WaitForElementToBeInvisible(btnCloseScreeningWarning_Id, TimeSpan.FromSeconds(2));
                SwitchToDefaultContent();
                SwitchToManifestFrame();
            }
        }

        public void ClickOnCartULDExpandButton()
        {            
            Click(By.XPath("//*[@data-uldnumber='"+cartUldNum+"']/parent::div/preceding-sibling::div[@aria-colindex=2]/button"));   
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Expand Button for ULD/Cart Number: " + cartUldNum);
        }

        public void ClickOnOffloadAWBButton()
        {
            Click(By.XPath("//button[contains(@id,'awb_offload-" + cartUldNum + "')]"));  
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Offload AWB Button for ULD/Cart Number: " + cartUldNum);
            WaitForElementToBeVisible(modalOffloadAWB_Css, TimeSpan.FromSeconds(2));
        }

        public void FillOffloadFormAndMoveToAnotherFlight(string newFlight, string POUoffload)
        {
            Click(drpdwnOffloadReason_Xpath);
            SelectDropdownByVisibleTextUsingActions(drpdwnOffloadReason_Xpath, "Bulk Out");
            Hooks.Hooks.UpdateTest(Status.Info, "Selected Offload Reason: Bulk Out");
            EnterText(txtOffloadRemarks_Css, "Offloading & moving to another flight");
            Hooks.Hooks.UpdateTest(Status.Info, "Entered Offload Remarks: Offloading & moving to another flight");
            Click(chkBoxMoveToAnotherFlight_Css);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Move to Another Flight Checkbox");
            WaitForElementToBeVisible(txtUldNumOffloadModal_Css, TimeSpan.FromSeconds(2));
            ScrollDown();
            Click(chkBoxBarrowOffloadModal_Css);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Barrow Checkbox");
            EnterText(txtUldNumOffloadModal_Css, cartUldNum);
            Hooks.Hooks.UpdateTest(Status.Info, "Entered ULD/Cart Number: " + cartUldNum);
            EnterText(txtPOUOffloadModal_CSS, POUoffload);
            Hooks.Hooks.UpdateTest(Status.Info, "Entered POU: " + POUoffload);
            EnterText(txtFltNumOffloadModal_CSS, newFlight);
            Hooks.Hooks.UpdateTest(Status.Info, "Entered Flight Number: " + newFlight);
            EnterText(txtFltDateOffloadModal_Css, DateTime.Now.ToString("dd-MMM-yyyy"));
            Hooks.Hooks.UpdateTest(Status.Info, "Entered Flight Date: " + DateTime.Now.ToString("dd-MMM-yyyy"));
            Click(btnSaveOffloadModal_Xpath);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Save Button");
            HandleWarningMessage();            
        }

        public void clickOnManifestButton()
        {
            WaitForElementToBeVisible(btnManifest_Xpath, TimeSpan.FromSeconds(5));
            Click(btnManifest_Xpath);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Manifest Button");
            WaitForElementToBeInvisible(contentFrameManifest_Xpath, TimeSpan.FromSeconds(5));
        }


        public void PrintManifestWindow()
        {
            if (IsElementDisplayed(lblPrintManifest_Xpath))
            {
                SwitchToFrame(framePrintManifest_Id);
                int noOfWindowsOpenedCurrently = GetNumberOfWindowsOpened();
                ClickOnElementIfPresent(btnOKPrintManifest_Name);
                Hooks.Hooks.UpdateTest(Status.Info, "Clicked on OK Button on Print Manifest Window");
                WaitForElementToBeInvisible(framePrintManifest_Id, TimeSpan.FromSeconds(5));
                int noOfWindowsOpenedAfterButtonClicked = GetNumberOfWindowsOpened();
                if (noOfWindowsOpenedCurrently < noOfWindowsOpenedAfterButtonClicked)
                {
                    SwitchToLastWindow();
                    SaveManifestPDF();
                }
                if (IsElementDisplayed(lblPrintManifest_Xpath))
                {
                    SwitchToFrame(framePrintManifest_Id);
                    Click(btnClosePrintManifest_Name);
                    Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Close Button on Print Manifest Window");
                    WaitForElementToBeInvisible(framePrintManifest_Id, TimeSpan.FromSeconds(3));
                    CurrentWindowHandle();
                    SwitchToDefaultContent();
                }
            }
        }

        public void ClosePrintPDFWindow()
        {
            if (IsElementDisplayed(lblPrintManifest_Xpath))
            {
                SwitchToFrame(framePrintManifest_Id);

                if(!IsElementDisplayed(lblMessagePrintManifestWindow_CSS))
                {
                    Click(btnClosePrintManifest_Name);
                    Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Close Button on Print Manifest Window");
                    WaitForElementToBeInvisible(framePrintManifest_Id, TimeSpan.FromSeconds(3));
                }
                else
                {
                    SwitchToDefaultContent();
                    SwitchToManifestFrame();
                    Click(btnCrossPrintManifestWindow_Xpath);
                    Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Cross Button on Print Manifest Window");
                    WaitForElementToBeInvisible(framePrintManifest_Id, TimeSpan.FromSeconds(3));
                    SwitchToDefaultContent();
                    SwitchToManifestFrame();
                    Click(btnManifest_Xpath);
                    Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Manifest Button");
                    WaitForElementToBeInvisible(contentFrameManifest_Xpath, TimeSpan.FromSeconds(5));
                    SwitchToFrame(framePrintManifest_Id);
                    Click(btnClosePrintManifest_Name);
                    Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Close Button on Print Manifest Window");
                    WaitForElementToBeInvisible(framePrintManifest_Id, TimeSpan.FromSeconds(3));
                }        

                SwitchToDefaultContent();
                SwitchToManifestFrame();
            }
        }

        public void ValidateAWBStatusInExportManifest(string expectedAWBStatus)
        {
            WaitForElementToBeVisible(lblStatus_CSS, TimeSpan.FromSeconds(5));
            string actualAWBStatus = GetText(lblStatus_CSS);
            if (actualAWBStatus.Contains(expectedAWBStatus) || actualAWBStatus.Contains("Offloaded"))
            {
                Hooks.Hooks.UpdateTest(Status.Info, "AWB status is as expected: " + actualAWBStatus);
                Log.Info("AWB status is as expected: " + actualAWBStatus);
            }
            else
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "AWB status is not as expected. Expected: " + expectedAWBStatus + " Actual: " + actualAWBStatus);
                Log.Error("AWB status is not as expected. Expected: " + expectedAWBStatus + " Actual: " + actualAWBStatus);
                Assert.Fail("AWB status is not as expected. Expected: " + expectedAWBStatus + " Actual: " + actualAWBStatus);
            }
        }

        public void SaveManifestPDF()
        {
            SwitchToFrame(frameManifestPDF_Id);
            Click(btnSavePDFMenu_Xpath);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Save PDF Menu");
            WaitForElementToBeVisible(btnSavePDF_Xpath, TimeSpan.FromSeconds(5));
            Click(btnSavePDF_Xpath);
            Hooks.Hooks.UpdateTest(Status.Info, "Clicked on Save PDF");
            WaitForElementToBeInvisible(btnSavePDF_Xpath, TimeSpan.FromSeconds(5));
            CloseCurrentWindow();
            SwitchToLastWindow();
            SwitchToManifestFrame();
        }
        public void ValidateOPR344WarningMessage(string expectedWarningMessage)
        {

            WaitForElementToBeVisible(lblErrorPopOver_CSS, TimeSpan.FromSeconds(5));
            string actualWarningMessage = GetText(lblErrorPopOver_CSS);
            if (!actualWarningMessage.Contains(expectedWarningMessage))
            {
                Hooks.Hooks.UpdateTest(Status.Fail, "Warning message is not as expected. Expected: " + expectedWarningMessage + " Actual: " + actualWarningMessage);
                Log.Error("Warning message is not as expected. Expected: " + expectedWarningMessage + " Actual: " + actualWarningMessage);
                Assert.Fail("Warning message is not as expected. Expected: " + expectedWarningMessage + " Actual: " + actualWarningMessage);

            }
            else
            {               
                Hooks.Hooks.UpdateTest(Status.Info, "Warning message is as expected: " + actualWarningMessage);
                Log.Info("Warning message is as expected: " + actualWarningMessage);
            }
        }

        public void CloseOPR344Screen()
        {
            
            WaitForElementToBeVisible(btnCloseManifest_Xpath, TimeSpan.FromSeconds(5));            
            ClickOnElementIfEnabled(btnCloseManifest_Xpath);
            Hooks.Hooks.UpdateTest(Status.Info, "Close OPR344 Screen");
            SwitchToDefaultContent();

        }


    }
}
