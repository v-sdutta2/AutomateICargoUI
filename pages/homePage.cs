using iCargoUIAutomation.Features;
using iCargoUIAutomation.utilities;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCargoUIAutomation.pages
{
    public class homePage : BasePage
    {
        public static string? role;        
        public homePage(IWebDriver driver) : base(driver)
        {
        }

        private By btnHomeIcon_Xpath = By.XPath("//li[@role='tab']//span[normalize-space(text()='Home')]");
        private By lblBaseStation_Xpath = By.XPath("//*[@id='header_panel']//*[@id='ic-user-stationcode']");
        private By btnMore_Xpath = By.XPath("//*[@id='header_panel']//*[@class='ic-header-menu-icon' and @title='More..']");
        private By lnkSwitchRole_Xpath = By.XPath("//*[@class='ic-switch-role']/a");
        private By frameSwitchRole_Id = By.Id("swichRoleiframe");
        private By drpdwnSelectStation_Id = By.Id("CMB_ADMIN_USER_SWITCHROLES_LISTSTATIONS");
        private By btnOKSwitchRole_Xpath = By.XPath("//*[@name='SwitchRolesForm']//*[@id='CMB_ADMIN_USER_SWITCHROLES_OK_BUTTON']");
        private By btnClickHere_Xpath = By.XPath("//*[@id='header_panel']//*[@class='ic-header-menu-icon' and @title='Click Here']");
        private By lnkLogOut_Xpath = By.XPath("//*[@class='ic-header-items-sub-menu']//*[@class='ic-log-off']/a");
        private By btnYesLogoutConfirmation_Xpath = By.XPath("//button[text()=' Yes ']");
        private By txt_ScreenName_Css = By.CssSelector(".ic-screen-search");

        //Login Page Details
        private By userName_Id = By.Id("username");
        private By password_Id = By.Id("password");
        private By loginButton_Id = By.XPath("//input[@title='Sign In']");

        ILog Log = LogManager.GetLogger(typeof(homePage));

        
        public void ClickHomeIcon()
        {
            try
            {
                Click(btnHomeIcon_Xpath);
            }
            catch (Exception e)
            {
                Log.Error("Error in ClickHomeIcon method: " + e.Message);
            }
            
        }
        
        public void SwitchStation(string station)
        {
            try
            {
                string baseStation="";
                while (true)
                {
                    baseStation = GetText(lblBaseStation_Xpath);
                    if (baseStation == station)
                        break;                  
                    
                        Click(btnMore_Xpath);
                        Click(lnkSwitchRole_Xpath);
                        SwitchToFrame(frameSwitchRole_Id);
                        WaitForElementToBeVisible(drpdwnSelectStation_Id, TimeSpan.FromSeconds(10));
                        SelectDropdownByVisibleText(drpdwnSelectStation_Id, station);
                        Click(btnOKSwitchRole_Xpath);
                        SwitchToDefaultContent();
                    
                }
                
            }
            catch (Exception e)
            {              
                Log.Error("Error in SwitchStation method: " + e.Message);
            }
            
        }

        public void enterScreenName(string screenName)
        {
            try
            {
                EnterText(txt_ScreenName_Css, screenName);
                EnterKeys(txt_ScreenName_Css, Keys.Enter);
                WaitForElementToBeVisible(By.CssSelector("li[tabindex='0']"), TimeSpan.FromSeconds(5));
               
            }
            catch (Exception e)
            {
                Log.Error("Error in enterScreenName method: " + e.Message);
            }
           
        }

        public void logoutiCargo()
        {
            try
            {
                SwitchToDefaultContent();
                Click(btnClickHere_Xpath);
                Click(lnkLogOut_Xpath);
                Click(btnYesLogoutConfirmation_Xpath);

            }
            catch (Exception e)
            {
                Log.Error("Error in logoutiCargo method: " + e.Message);
            }
            
           
        }

        public void LoginICargo()
        {
            try
            {
                var secrets = KeyVault.GetSecret();
                WaitForElementToBeVisible(userName_Id, TimeSpan.FromSeconds(10));
                role = Environment.GetEnvironmentVariable("ROLE_GROUP", EnvironmentVariableTarget.Process);
                //role = "CCC";
                if (role.ToUpper() == "CCC")
                {
                    EnterText(userName_Id, secrets["CCC_Username"]);
                    EnterText(password_Id, secrets["CCC_Password"]);
                }
                else if (role.ToUpper() == "CGODG")
                {
                    EnterText(userName_Id, secrets["CGODG_Username"]);
                    EnterText(password_Id, secrets["CGODG_Password"]);
                }
                else
                {
                    Log.Error("Role not found");
                }
                Click(loginButton_Id);
                WaitForElementToBeInvisible(userName_Id, TimeSpan.FromSeconds(5));
            }
            catch (Exception e)
            {
                Log.Error("Error in loginiCargo method: " + e.Message);
            }

        }

    }
}
