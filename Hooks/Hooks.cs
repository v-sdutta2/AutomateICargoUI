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
        public static string? browser;
        public MaintainBookingPage mbp;
        public static string featureName;

        public Hooks(IObjectContainer container)
        {
            _container = container;

        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");

            string dir = AppDomain.CurrentDomain.BaseDirectory;
            testResultPath = dir.Replace("bin\\Debug\\net6.0", "Reports\\TestResults_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
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
            Console.WriteLine("Running before feature...");
            feature = extent.CreateTest(featureContext.FeatureInfo.Title);
            feature.Log(Status.Info, featureContext.FeatureInfo.Description);
        }

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {

        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            //browser = Environment.GetEnvironmentVariable("Browser", EnvironmentVariableTarget.Process);
            //browser = "chrome";
            //IWebDriver driver;

            //if (browser.Equals("chrome", StringComparison.OrdinalIgnoreCase))
            //{
            //    driver = new ChromeDriver();
            //}
            //else if (browser.Equals("edge", StringComparison.OrdinalIgnoreCase))
            //{
            //    driver = new EdgeDriver();
            //}
            //else if(browser.Equals("firefox", StringComparison.OrdinalIgnoreCase))
            //{
            //    driver = new FirefoxDriver();
            //}
            //else if(browser.Equals("safari", StringComparison.OrdinalIgnoreCase))
            //{
            //    driver = new SafariDriver();
            //}
            //else
            //{
            //    throw new NotSupportedException($"Browser '{browser}' is not supported");
            //}


            //IWebDriver driver = new EdgeDriver();
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();

            _container.RegisterInstanceAs<IWebDriver>(driver);
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
            var driver = _container.Resolve<IWebDriver>();
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            DateTime time = DateTime.Now;
            featureName = featureContext.FeatureInfo.Title;
            string fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            if (status == TestStatus.Failed)
            {                
                scenario.Fail("Test Failed", captureScreenshot(driver, fileName));
                scenario.Log(Status.Fail, "Test failed with log" + stackTrace);
            }
            extent.Flush();
            string fromEmail = "avijit.saha@alaskaair.com";
            // Recipient's email address
            string toEmail = "sourav.dutta2@alaskaair.com";
            // Create and configure the SMTP client
            SmtpClient smtpClient = new SmtpClient("outbound.alaskaair.com", 25);
            MailMessage mail = new MailMessage(fromEmail, toEmail);
            mail.Subject = "AWB Number";
            if (featureName.Contains("CAP018"))
            mail.Body = "The AWB Number is " + MaintainBookingPage.awbNumber;
            else
                mail.Body = "The AWB Number is " + CreateShipmentPage.awb_num;
            smtpClient.Send(mail);
            driver?.Quit();
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running after step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            var driver = _container.Resolve<IWebDriver>();
            
        }

        public static MediaEntityModelProvider captureScreenshot(IWebDriver driver, string fileName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath,fileName);
            screenshot.SaveAsFile(screenshotLocation);            
            return MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotLocation).Build();
        }
    }
}