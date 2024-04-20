
using BoDi;
using iCargoUIAutomation.pages;
using iCargoUIAutomation.utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;


namespace iCargoUIAutomation.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _container;
       
        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
           
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            Console.WriteLine("Running before scenario...");
            

            //IWebDriver driver = new EdgeDriver();
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();     

          _container.RegisterInstanceAs<IWebDriver>(driver);
           
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();

            driver?.Quit();
        }
    }
}