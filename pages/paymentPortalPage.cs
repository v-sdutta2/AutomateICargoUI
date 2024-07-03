using iCargoUIAutomation.utilities;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCargoUIAutomation.pages
{
    public class PaymentPortalPage : BasePage
    {
        public PaymentPortalPage(IWebDriver driver) : base(driver)
        {
        }

        //   Payment Portal //
        private By txtPleaseCloseTabRetry_Xpath = By.XPath("//*[text()='Please close the tab and retry.']");
        private By optionManualPaymentMethod_Xpath = By.XPath("//input[@name='paymentRadio' and @id='manual']");
        private By optionCustomerPaymentMethod_Xpath = By.XPath("//input[@name='paymentRadio' and @id='customer']");
        private By btnNext_Xpath = By.XPath("//*[@id='nextBtn']");
        private By btnConfirmManualPayment_Xpath = By.XPath("//*[text()=' Continue ']");
        private By lblPaymentSuccess_Xpath = By.XPath("//*[@class='messageBox']//*[text()='Payment successfully completed. ']");
        private By lblTotalAmount_Xpath = By.XPath("(//*[@class='aiBoxTwo'])[2]//label[13]");
        private By btnDone_Xpath = By.XPath("//*[text()='Done']");
        private By btnExitIcargo_Xpath = By.XPath("//*[text()='Exit to iCargo']");
        private By btnContinuePlsConfirm = By.XPath("//*[text()=' Continue ']");
        ILog Log = LogManager.GetLogger(typeof(PaymentPortalPage));

        public void ClosePaymentPortal()
        {
            Log.Info("Closing Payment Portal");
            CloseCurrentWindow();
        }

        public string PaymentWithPPCC(string chargtyp)
        {
            Log.Info("Handling Payment in Payment Portal with "+chargtyp);
            string totalPaybleAmount = "";
            try
            {
                if (chargtyp.Equals("PP"))
                {
                    ConfirmManualPayment();
                    ScrollDown();
                    totalPaybleAmount = GetText(lblTotalAmount_Xpath).Split("$")[1];
                    ClickOnElementIfEnabled(btnDone_Xpath);
                    WaitForElementToBeInvisible(btnDone_Xpath, TimeSpan.FromSeconds(7));

                }
                else if (chargtyp.Equals("CC"))
                {
                    ConfirmManualPayment();
                    Click(btnExitIcargo_Xpath);
                    Click(btnContinuePlsConfirm);
                }

            }
            catch (Exception e)
            {
                Log.Error("Error in handling Payment in Payment Portal" + e.Message);
            }
            return totalPaybleAmount;
        }


        public string HandlePaymentInPaymentPortal(string chargetyp)
        {
            Log.Info("Handling Payment in Payment Portal");
            string totalPaybleAmount = "";
            try
            {
                if (chargetyp.Equals("PP") || chargetyp.Equals("CC"))
                {
                    if (IsElementDisplayed(txtPleaseCloseTabRetry_Xpath, 3))
                    {
                        CloseCurrentWindow();
                    }
                    else if (chargetyp.Equals("PP"))
                    {
                        ConfirmManualPayment();
                        ScrollDown();
                        totalPaybleAmount = GetText(lblTotalAmount_Xpath).Split("$")[1];
                        ClickOnElementIfEnabled(btnDone_Xpath);
                        WaitForElementToBeInvisible(btnDone_Xpath, TimeSpan.FromSeconds(7));
                    }
                    else if (chargetyp.Equals("CC"))
                    {
                        ConfirmManualPayment();
                        Click(btnExitIcargo_Xpath);
                        Click(btnContinuePlsConfirm);
                    }

                }

            }
            catch (Exception e)
            {
                Log.Error("Error in handling Payment in Payment Portal" + e.Message);
            }

            return totalPaybleAmount;
        }



        public void ConfirmManualPayment()
        {
            Log.Info("Confirming Manual Payment");
            Click(optionManualPaymentMethod_Xpath);
            Click(btnNext_Xpath);
            Click(btnConfirmManualPayment_Xpath);

        }


    }
}
