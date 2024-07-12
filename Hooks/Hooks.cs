using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using iCargoUIAutomation.pages;
using iCargoUIAutomation.utilities;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Firefox;
using System.Net.Mail;
using System.Configuration;


namespace iCargoUIAutomation.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _container;
        public static ExtentReports? extent;
        public static ExtentTest? feature;
        public static ExtentTest? scenario;
        public static ExtentTest? step;
        public static string? testResultPath;
        public static string? reportPath;
        private static IWebDriver? driver;
        public static string? featureName;
        public static string? browser;
        public static string? appUrl = "https://asstg-icargo.ibsplc.aero/icargo/login.do";

        public Hooks(IObjectContainer container)
        {
            _container = container;

        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");
            reportPath = @"\\seavvfile1\projectmgmt_pmo\iCargoAutomationReports\Reports\TestResults_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");            
            testResultPath = reportPath + @"\index.html";
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            feature = extent.CreateTest(featureContext.FeatureInfo.Title);
            feature.Log(Status.Info, featureContext.FeatureInfo.Description);
            browser = Environment.GetEnvironmentVariable("Browser", EnvironmentVariableTarget.Process);
            //browser = "firefox";
            
                if (browser.Equals("chrome", StringComparison.OrdinalIgnoreCase))
                {
                    driver = new ChromeDriver();
                }
                else if (browser.Equals("edge", StringComparison.OrdinalIgnoreCase))
                {
                    driver = new EdgeDriver();
                }
                else if (browser.Equals("firefox", StringComparison.OrdinalIgnoreCase))
                {
                    driver = new FirefoxDriver();
                }
                else if (browser.Equals("safari", StringComparison.OrdinalIgnoreCase))
                {
                    driver = new SafariDriver();
                }
                else
                {
                    throw new NotSupportedException($"Browser '{browser}' is not supported");
                }
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                driver.Manage().Window.Maximize();
                homePage hp = new homePage(driver);
                BasePage bp = new BasePage(driver);
                bp.DeleteAllCookies();
                bp.Open(appUrl);                
                driver.FindElement(By.XPath("//a[@id='social-oidc']")).Click();                
                if (bp.IsElementDisplayed(By.XPath("//body[@class='login']")))
                {
                    hp.LoginICargo();                    
                }
                bp.SwitchToNewWindow();                       
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            homePage hp = new homePage(driver);
            hp.logoutiCargo();
            extent.Flush();
            driver.Quit();
        }

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {

        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {

            _container.RegisterInstanceAs(driver);
            scenario = feature.CreateNode(scenarioContext.ScenarioInfo.Title);

        }

        public static void createNode()
        {
            step = scenario.CreateNode(ScenarioStepContext.Current.StepInfo.Text);
        }

        public static void outOfStep()
        {
            step = scenario;
        }

        public static void UpdateTest(Status status, string stepMessaage)
        {
            step.Log(status, stepMessaage);
        }

        [BeforeStep]
        public void BeforeStep()
        { }

        [AfterScenario]
        public void AfterScenario(FeatureContext featureContext)
        {            
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            DateTime time = DateTime.Now;
            featureName = featureContext.FeatureInfo.Title;
            string fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            if (status == TestStatus.Failed)
            {
                scenario.Fail("Test Failed", captureScreenshot(fileName));
                scenario.Log(Status.Fail, "Test failed with log" + stackTrace);
            }            
            if (MaintainBookingPage.awbNumber != "" || CreateShipmentPage.awb_num != "" && ScenarioContext.Current["Execute"] == "true")
            {
                string filePath = @"\\seavvfile1\projectmgmt_pmo\iCargoAutomationReports\AWB_Numbers\AWB_Details.xlsx";
                if (featureName.Contains("CAP018"))
                {
                    ExcelFileConfig excelFileConfig = new ExcelFileConfig();
                    excelFileConfig.AppendDataToExcel(filePath, DateTime.Now.ToString("dd-MM-yyyy"), DateTime.Now.ToString("HH:mm:ss"), "CAP018", MaintainBookingPage.awbNumber);
                }
                else
                {
                    ExcelFileConfig excelConfig = new ExcelFileConfig();
                    excelConfig.AppendDataToExcel(filePath, DateTime.Now.ToString("dd-MM-yyyy"), DateTime.Now.ToString("HH:mm:ss"), "LTE001", CreateShipmentPage.awb_num);
                }
            }
            else
            {
                ScenarioContext.Current.Pending();
            }
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {            
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
            

        }

        public static MediaEntityModelProvider captureScreenshot(string fileName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string screenshotPath = reportPath;
            string screenshotLocation = Path.Combine(screenshotPath, fileName);
            screenshot.SaveAsFile(screenshotLocation);
            return MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotLocation).Build();
        }
    }
}

