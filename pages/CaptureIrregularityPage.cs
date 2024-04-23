using iCargoUIAutomation.utilities;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace iCargoUIAutomation.pages
{
    public class CaptureIrregularityPage : BasePage
    {
        public CaptureIrregularityPage(IWebDriver driver) : base(driver)
        {
        }

        //   Capture Irregularity //

        private By iframeCaptureIrregularity_Xpath= By.XPath("//span[text()='Capture Irregularity']//following::iframe[@id='popupContainerFrame']");
        private By drpdwnIrregularityCode_Xpath = By.XPath("//*[@id='irregularityTableBody']//select[contains(@id,'irregularityCodeID')]"); 
        //Booking - Incomplete or inaccurate, Cargo Operations Error,Customer - Information Change,Maintenance Delay
        private By txtIrregularityCode_Xpath = By.XPath("//*[@id='irregularityTableBody']//*[@name='irregularityCode']");
        private By txtIrregularityPieces_Xpath = By.XPath("//*[@id='irregularityTableBody']//*[@name='pieces']");
        private By txtIrregularityWeight_Xpath = By.XPath("//*[@id='irregularityTableBody']//*[@name='weight']");        
        private By irregularityscrollhori_XPATH = By.XPath("//div[@class='portlet row form-body scroll-z-index-fix']//div[@class='slimScrollArrowUpX']");
        private By txtIrregularityRemarks_Xpath = By.XPath("//*[@id='irregularityTableBody']//*[@name='irregularityRemarks']");
        private By btnOKIrregularity_Xpath = By.XPath("//button[@name='btnOk']");
        
        
        ILog Log = LogManager.GetLogger(typeof(CaptureIrregularityPage));       

       public void captureIrregularity(string pieces, string weight)
        {
            SwitchToFrame(iframeCaptureIrregularity_Xpath);
           
            Click(txtIrregularityCode_Xpath);
            EnterText(txtIrregularityCode_Xpath, "Customer - Information Change");
            //SelectDropdownByVisibleText(txtIrregularityCode_Xpath, "Customer - Information Change");
            EnterText(txtIrregularityPieces_Xpath, pieces);
            EnterText(txtIrregularityWeight_Xpath, weight);
            DoubleClick(irregularityscrollhori_XPATH);
            EnterText(txtIrregularityRemarks_Xpath, "Flight Changed : Irregularity Captured");
            Click(btnOKIrregularity_Xpath);
            SwitchToDefaultContent();
        }





    }
}
