using iCargoUIAutomation.pages;
using OpenQA.Selenium;

public class PageObjectManager : BasePage
{

    private IWebDriver driver;
    private homePage hp;
    private CreateShipmentPage csp;
    private MaintainBookingPage mbp;
    private ExportManifestPage emp;

    // Add other page classes as needed

    public PageObjectManager(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
    }

    public homePage GetHomePage()
    {
        return hp ?? (hp = new homePage(driver));
    }

    public CreateShipmentPage GetCreateShipmentPage()
    {
        return csp ?? (csp = new CreateShipmentPage(driver));
    }

    public MaintainBookingPage GetMaintainBookingPage()
    {
        return mbp ?? (mbp = new MaintainBookingPage(driver));
    }

    public ExportManifestPage GetExportManifestPage()
    {
        return emp ?? (emp = new ExportManifestPage(driver));
    }


    // Add other getter methods for other page classes as needed
}
