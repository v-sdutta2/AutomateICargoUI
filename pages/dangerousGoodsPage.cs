using AventStack.ExtentReports;
using iCargoUIAutomation.utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCargoUIAutomation.pages
{
    public class DangerousGoodsPage : BasePage
    {
        public DangerousGoodsPage(IWebDriver driver) : base(driver)
        {

        }

        // DG Details Screen //
        private By lnkDangerousGoods_Xpath = By.XPath("//*[@id='dangerousGoodsLink']//parent::a");
        private By popupDGName_Xpath = By.XPath("//*[text()='Dangerous Goods Details']");
        private By popupContainerFrame_Xpath = By.XPath("//*[text()='Dangerous Goods Details']//parent::div//following-sibling::div/iframe");
        private By btnDGPencil_Xpath = By.XPath("//*[@name='DangerousGoodsDetailsForm']//*[@name='toeditshipperdetails']");
        private By txtEmergencyContactName_Name = By.Name("firstEmergencyContactName");
        private By txtEmergencyContactNumber_Name = By.Name("firstEmergencyContactNumber");
        private By btnOKsaveContact_Name = By.Name("btnShipperReferenceOk");
        private By txtUNID_Xpath = By.XPath("//input[@id='unidId']");
        private By drpdwnProperShippingName_Xpath = By.XPath("//*[@id='properShippingName']/select");
        private By chkbxCAO_Xpath = By.XPath("//input[@id='caoChecked']");
        private By txtPI_Name = By.Name("packingInstruction");
        private By txtNoOfPkgs_Name = By.Name("numberOfPackages");
        private By txtNetQtyPerPkg_Name = By.Name("netQuantityPerPackage");
        private By drpdwn_NetQtyPerPkgUnit_Name = By.Name("netQuantityPerPackageUnit");
        private By txtGrossIndicator_Name = By.Name("netGrossIndicator");
        private By drpdwnReportableQnty_Name = By.Name("reportableQuantity");
        private By btnAddDgDetails_Xpath = By.XPath("//button[text()='Add']");
        private By chkboxDGVerified_Xpath = By.XPath("//*[@id='footerbutton']//input[@type='checkbox' and @name='dgVerifiedFlag']");
        private By btnOKDGVerified_Xpath = By.XPath("//*[@id='footerbutton']//button[@name='butOk']");

        public void HandleDGShipment(string unid, string propershipmntname, string pi, string noofpkg, string netqtyperpkg, string reportable)
        {
            Click(lnkDangerousGoods_Xpath);
            Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on Dangerous Goods Link");
            SwitchToFrame(popupContainerFrame_Xpath);
            Click(btnDGPencil_Xpath);
            Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on Pencil Icon");
            EnterText(txtEmergencyContactName_Name, "Chem Trec");
            Hooks.Hooks.UpdateTest(Status.Pass, "Entered Emergency Contact Name: Chem Trec");
            EnterText(txtEmergencyContactNumber_Name, "8008008000");
            Hooks.Hooks.UpdateTest(Status.Pass, "Entered Emergency Contact Number: 8008008000");
            Click(btnOKsaveContact_Name);
            Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on OK Button");
            WaitForElementToBeVisible(txtUNID_Xpath, TimeSpan.FromSeconds(5));
            ScrollDown();
            EnterText(txtUNID_Xpath, unid);
            Hooks.Hooks.UpdateTest(Status.Pass, "Entered UNID: " + unid);
            EnterKeys(txtUNID_Xpath, Keys.Tab);
            EnterText(txtNoOfPkgs_Name, noofpkg);
            Hooks.Hooks.UpdateTest(Status.Pass, "Entered No of Packages: " + noofpkg);
            EnterText(txtNetQtyPerPkg_Name, netqtyperpkg);
            Hooks.Hooks.UpdateTest(Status.Pass, "Entered Net Quantity Per Package: " + netqtyperpkg);
            SelectDropdownByVisibleText(drpdwnReportableQnty_Name, reportable);
            Hooks.Hooks.UpdateTest(Status.Pass, "Selected Reportable Quantity: " + reportable);
            SelectDropdownByVisibleText(drpdwnProperShippingName_Xpath, propershipmntname);
            Hooks.Hooks.UpdateTest(Status.Pass, "Selected Proper Shipping Name: " + propershipmntname);
            EnterTextWithCheck(txtPI_Name, pi);
            Hooks.Hooks.UpdateTest(Status.Pass, "Entered Packing Instruction: " + pi);
            Click(btnAddDgDetails_Xpath);
            WaitForElementToBeVisible(chkboxDGVerified_Xpath, TimeSpan.FromSeconds(5));
            Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on Add DG Details Button");
            Click(chkboxDGVerified_Xpath);
            Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on DG Verified Checkbox");
            Click(btnOKDGVerified_Xpath);
            Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on OK Button");
            SwitchToDefaultContent();
        }

        public void EnterDetailsForCAODGShipment(string unid, string propershipmntname, string pi, string noofpkg, string netqtyperpkg, string reportable)
        {
            Click(lnkDangerousGoods_Xpath);
            Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on Dangerous Goods Link");
            SwitchToFrame(popupContainerFrame_Xpath);
            Click(btnDGPencil_Xpath);
            Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on Pencil Icon");
            EnterText(txtEmergencyContactName_Name, "Chem Trec");
            Hooks.Hooks.UpdateTest(Status.Pass, "Entered Emergency Contact Name: Chem Trec");
            EnterText(txtEmergencyContactNumber_Name, "8008008000");
            Hooks.Hooks.UpdateTest(Status.Pass, "Entered Emergency Contact Number: 8008008000");
            Click(btnOKsaveContact_Name);
            Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on OK Button");
            WaitForElementToBeVisible(txtUNID_Xpath, TimeSpan.FromSeconds(5));
            ScrollDown();
            EnterText(txtUNID_Xpath, unid);
            Hooks.Hooks.UpdateTest(Status.Pass, "Entered UNID: " + unid);
            EnterKeys(txtUNID_Xpath, Keys.Tab);
            Click(chkbxCAO_Xpath);
            Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on CAO Checkbox");
            EnterText(txtNoOfPkgs_Name, noofpkg);
            Hooks.Hooks.UpdateTest(Status.Pass, "Entered No of Packages: " + noofpkg);
            EnterText(txtNetQtyPerPkg_Name, netqtyperpkg);
            Hooks.Hooks.UpdateTest(Status.Pass, "Entered Net Quantity Per Package: " + netqtyperpkg);
            SelectDropdownByVisibleText(drpdwn_NetQtyPerPkgUnit_Name, "KG");
            Hooks.Hooks.UpdateTest(Status.Pass, "Selected Net Quantity Per Package Unit: KG");
            SelectDropdownByVisibleText(drpdwnReportableQnty_Name, reportable);
            Hooks.Hooks.UpdateTest(Status.Pass, "Selected Reportable Quantity: " + reportable);
            SelectDropdownByVisibleText(drpdwnProperShippingName_Xpath, propershipmntname);
            Hooks.Hooks.UpdateTest(Status.Pass, "Selected Proper Shipping Name: " + propershipmntname);
            EnterTextWithCheck(txtPI_Name, pi);
            Hooks.Hooks.UpdateTest(Status.Pass, "Entered Packing Instruction: " + pi);
            Click(btnAddDgDetails_Xpath);
            Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on Add DG Details Button");
            WaitForElementToBeVisible(chkboxDGVerified_Xpath, TimeSpan.FromSeconds(5));
            ScrollDown();
            Click(chkboxDGVerified_Xpath);
            Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on DG Verified Checkbox");
            Click(btnOKDGVerified_Xpath);
            Hooks.Hooks.UpdateTest(Status.Pass, "Clicked on OK Button");
            SwitchToDefaultContent();

        }



    }
}
