using iCargoUIAutomation.Features;
using iCargoUIAutomation.pages;
using iCargoUIAutomation.utilities;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Edge;

namespace iCargoUIAutomation.StepDefinitions
{
    [Binding]
    public class LoginSteps : BasePage
    {
        private IWebDriver driver;
        private PageObjectManager pageObjectManager;
        private homePage hp;
        ILog Log = LogManager.GetLogger(typeof(ICargoLoginFeature));
       


        public string appUrl = "https://asstg-icargo.ibsplc.aero/icargo/login.do";
        

        public LoginSteps(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            pageObjectManager = new PageObjectManager(driver);
            hp = pageObjectManager.GetHomePage();
           
        }


        [Given(@"User lauches the Url of iCargo Staging UI")]
        public void GivenUserLauchesTheUrlOfICargoStagingUI()
        {
            Log.Info("Step: Launching the iCargo Staging UI");

            DeleteAllCookies();
            Open(appUrl);

        }



        [Then(@"User enters into the  iCargo '([^']*)' page successfully")]
        public void ThenUserEntersIntoTheICargoSuccessfully(string pageName)
        {
            Log.Info("Step: Verifying the page title");
            string expectedPageTitle = pageName;
            string actualPageTitle = driver.Title;
            Assert.AreEqual(expectedPageTitle, actualPageTitle);
        }


        [When(@"User clicks on the oidc button")]
        public void WhenUserEntersValidUsernameAndPassword()
        {

            Log.Info("Step: Clicking on the oidc button");
            driver.FindElement(By.XPath("//a[@id='social-oidc']")).Click();
        }

        [Then(@"A new window is opened")]
        public void ThenANewWindowIsOpened()
        {
            Log.Info("Step: Switching to new window");
            SwitchToNewWindow();
        }

        [When(@"User switches station if BaseStation other than ""([^""]*)""")]
        public void SwitchStationForDifferentBase(string origin)
        {
            //this.origin = origin;
            Log.Info("Step: Switching station if BaseStation other than Origin ");
            hp.SwitchStation(origin);
        }

        [When(@"User enters the screen name as '([^']*)'")]
        public void EnteriCargoScreenName(string screenName)
        {
            Log.Info("Step: Entering the screen name");
            hp.enterScreenName(screenName);
        }


        [Then(@"User logs out from the application")]
        public void WhenUserLogsOutFromTheApplication()
        {

            Log.Info("Step: Logging out from the application");
            hp.logoutiCargo();
        }




    }
}
