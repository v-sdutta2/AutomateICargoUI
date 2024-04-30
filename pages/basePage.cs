using iCargoUIAutomation.utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using log4net;
using AventStack.ExtentReports;

namespace iCargoUIAutomation.pages
{
    public class BasePage
    {
        private readonly IWebDriver driver;

        public static readonly ILog log = LogManager.GetLogger(typeof(BasePage));
        private readonly logFileConfiguration logConfig;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.logConfig = new logFileConfiguration();
            this.logConfig.ConfigureLog4Net();
        }    
                

        // Browser Actions

        // delete all cookiies & caches & verify if all cookies are deleted
        public void DeleteAllCookies()
        {
            driver.Manage().Cookies.DeleteAllCookies();

            // Verify if all cookies are deleted
            if (driver.Manage().Cookies.AllCookies.Count == 0)
            {
                log.Info("All cookies are deleted");
            }
            else
            {
                log.Info("All cookies are not deleted");
            }
        }
        public void Open(string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
                log.Info("Opened the url: " + url);
            }
            catch (Exception e)
            {
                log.Error("Failed to open the url: " + url);
                log.Error(e.ToString());
            }
        }

        public string GetTitle()
        {
            try
            {
                string pageTitle = driver.Title;
                log.Info("The title of the page is: " + pageTitle);
                return pageTitle;
            }
            catch (Exception e)
            {
                log.Error("Failed to get the title of the page");
                log.Error(e.ToString());
                return string.Empty;
            }
        }

        public void MinimizeWindow()
        {
            try
            {
                driver.Manage().Window.Minimize();
                log.Info("Minimized the window");
            }
            catch (Exception e)
            {
                log.Error("Failed to minimize the window");
                log.Error(e.ToString());
            }
        }

        public void RefreshPage()
        {

            driver.Navigate().Refresh();
            log.Info("Refreshed the page");
            //Thread.Sleep(5000);


        }

        public string CurrentWindowHandle()
        {
            return driver.CurrentWindowHandle;
        }


        public void SwitchToNewWindow()
        {
            // Store the original window handle in a variable
            string originalWindow = driver.CurrentWindowHandle;

            // Wait for the new window or tab to open
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.WindowHandles.Count > 1);

            // Loop through until we find a new window handle
            foreach (string window in driver.WindowHandles)
            {
                if (window != originalWindow)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
            log.Info("Switched to the new window");
        }


        public void CloseBrowser()
        {
            try
            {
                driver.Quit();
                log.Info("Closed the browser");
            }
            catch (Exception e)
            {
                log.Error("Failed to close the browser");
                log.Error(e.ToString());
            }
        }

        public void CloseCurrentWindow()
        {
            driver.Close();
            log.Info("Closed the current window");
        }

        public void CloseCurrentWindowAltF4()
        {
            driver.FindElement(By.TagName("html")).SendKeys(Keys.Alt + Keys.F4);
        }

        public void SwitchToPopupWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles[1]);
        }

        public void SwitchToMainWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        //method to switch to second popup window
        public void SwitchToSecondPopupWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles[2]);
        }

        public void SwitchToLastWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles[^1]);
            log.Info("Switched to the last window");
        }

        public void SwitchToPreviousWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles[^2]);
        }

        public int GetNumberOfWindowsOpened()
        {
            int numberOfWindows = driver.WindowHandles.Count;
            log.Info("The number of windows opened are: " + numberOfWindows);
            return numberOfWindows;
        }

        public bool IsNewWindowOpened()
        {
            return driver.WindowHandles.Count > 1;
        }


        // Click Actions

        public void Click(By byLocator)
        {

            driver.FindElement(byLocator).Click();
           // Thread.Sleep(1000);
            log.Info("Clicked on the element " + byLocator);

        }   



        public bool IsCheckboxChecked(By byLocator)
        {
            return driver.FindElement(byLocator).Selected;
        }

        public void DoubleClick(By byLocator)
        {

            Actions action = new Actions(driver);
            action.DoubleClick(driver.FindElement(byLocator)).Perform();
            log.Info("Double clicked on the element " + byLocator);
            //Thread.Sleep(2000);

        }

        // WebElement Actions

        public int GetElementCount(By byLocator)
        {
            int elementCount = driver.FindElements(byLocator).Count;
            log.Info("The number of elements found are: " + elementCount);
            return elementCount;
        }

        // get the elemnts and store it in a list
        public List<IWebElement> GetElements(By byLocator)
        {
            List<IWebElement> elements = driver.FindElements(byLocator).ToList();
            log.Info("The elements found are: " + elements);
            return elements;
        }


        /* Text Actions */

        public void EnterText(By byLocator, string text)
        {

            IWebElement element = driver.FindElement(byLocator);
            element.Clear();
            element.SendKeys(text);
            log.Info("Entered the text " + text + " in the element " + byLocator);

        }
        public void EnterTextWithCheck(By byLocator, string text)
        {

            while (true)
            {

                IWebElement element = driver.FindElement(byLocator);
                element.Clear();
                element.SendKeys(text);
                EnterKeys(byLocator, Keys.Tab.ToString());

                if (element.GetAttribute("value") == text)
                {
                    log.Info("Entered the text " + text + " in the element " + byLocator);
                    break; // The text was entered correctly, so break the loop
                }
            }


        }


        public void EnterTextUsingJavaScript(By locator, string text)
        {
            var element = driver.FindElement(locator);
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].value = arguments[1];", element, text);
        }

        public void ClearText(By byLocator)
        {
            try
            {
                driver.FindElement(byLocator).Clear();
                log.Info("Cleared the text in the element " + byLocator);
            }
            catch (Exception e)
            {
                log.Error("Failed to clear the text in the element " + byLocator);
                log.Error(e.ToString());
            }
        }

        public void EnterTextToDropdown(By byLocator, string text)
        {
            driver.FindElement(byLocator).SendKeys(text + Keys.Enter + Keys.Tab);

        }

        public string GetText(By byLocator)
        {

            string textExtracted = driver.FindElement(byLocator).Text;
            log.Info("Extracted the text " + textExtracted);
            return textExtracted;

        }

        // get the text from the IWebElement and return it       
        public string GetTextFromElement(IWebElement element)
        {
            string textExtracted = element.Text;
            log.Info("Extracted the text " + textExtracted);
            return textExtracted;
        }

        //click on IWebElement
        public void ClickOnElement(IWebElement element)
        {
            element.Click();
            log.Info("Clicked on the element " + element);
        }

        //get the attribute value from the IWebElement
        public string GetAttributeValueFromElement(IWebElement element, string attribute)
        {
            string attributeValue = element.GetAttribute(attribute);
            log.Info("Extracted the attribute value " + attributeValue);
            return attributeValue;
        }

        

        public void EnterKeys(By byLocator, string key)
        {

            driver.FindElement(byLocator).SendKeys(key);
            log.Info("Entered the key in the element " + byLocator);

        }

        public string GetAttributeValue(By byLocator, string attribute)
        {

            string attributeValue = driver.FindElement(byLocator).GetAttribute(attribute);
            log.Info("Extracted the attribute value " + attributeValue);
            return attributeValue;

        }

        /* Wait Actions */

        public void WaitForElementToBeVisible(By byLocator, TimeSpan time)
        {
            WebDriverWait wait = new WebDriverWait(driver, time);
            wait.PollingInterval = TimeSpan.FromSeconds(1);
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException), typeof(NoSuchElementException), typeof(TimeoutException));
            wait.Until(driver => driver.FindElement(byLocator).Displayed);
            log.Info("The element " + byLocator + " is visible");

        }

        public void WaitForElementToBeInvisible(By byLocator, TimeSpan time)
        {
            WebDriverWait wait = new WebDriverWait(driver, time);
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(byLocator));
        }

        // wait for the element to be clickable
        public void WaitForElementToBeClickable(By byLocator, TimeSpan time)
        {
            WebDriverWait wait = new WebDriverWait(driver, time);
            wait.PollingInterval = TimeSpan.FromSeconds(1);
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException), typeof(NoSuchElementException), typeof(TimeoutException));
            wait.Until(driver => driver.FindElement(byLocator).Enabled);
            log.Info("The element " + byLocator + " is clickable");

        }

        


        public void ClickOnElementIfPresent(By byLocator)
        {

            WaitForElementToBeVisible(byLocator, TimeSpan.FromSeconds(20));
            Click(byLocator);

        }

        // click on element if enabled
        public void ClickOnElementIfEnabled(By byLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(byLocator).Enabled);
            Click(byLocator);
        }

        public bool IsElementDisplayed(By byLocator,int time=10)
        {
            try
            {
                WaitForElementToBeVisible(byLocator, TimeSpan.FromSeconds(time));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void WaitForNewWindowToOpen(TimeSpan time, int windowCount)
        {
            WebDriverWait wait = new WebDriverWait(driver, time);
            wait.Until(driver => driver.WindowHandles.Count == windowCount);
        }

        public void WaitUntilTextIsDisplayed(By byLocator, string text)
        {
            //Thread.Sleep(5000);
            string textCaptured = driver.FindElement(byLocator).Text;
            // wait until the textCaptured is not equal to text
            while (true)
            {
                if (textCaptured.Trim() == text)
                {
                    break;
                }
            }
        }

        // check if the textbox is not empty
        public bool checkTextboxIsNotEmpty(By byLocator)
        {

            string textCaptured = driver.FindElement(byLocator).GetAttribute("value");            
            
            if (textCaptured.Trim() != "")
            {
                   return true;
            }
            else
            {
                return false;
            }
            
        }

        // wait until the text box is not empty
        public void WaitUntilTextboxIsNotEmpty(By byLocator)
        {
            while (true)
            {
                string textCaptured = driver.FindElement(byLocator).GetAttribute("value");
                if (textCaptured.Trim() != "")
                {
                    break;
                }
            }
        }

        public bool IsElementEnabled(By byLocator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.FindElement(byLocator).Enabled);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /* Scroll Actions */
        public void ScrollDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            log.Info("Scrolled down");
        }

        //scroll horizontally
        public void ScrollRight()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(2000,0)");
        }


        /* Frame Actions */
        public void SwitchToFrame(By byLocator)
        {
            driver.SwitchTo().Frame(driver.FindElement(byLocator));
            log.Info("Switched to frame");
        }

        public void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
            log.Info("Switched to default content");
        }

        /* Dropdown Actions */
        public void SelectDropdownByVisibleText(By byLocator, string text)
        {

            SelectElement select = new SelectElement(driver.FindElement(byLocator));
            if (text != "None")
            {
                // wait untill the value is visible
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => select.Options.Any(option => option.Text == text));
                select.SelectByText(text);           
            
            }
            else
            {
                select.SelectByIndex(0);
            }
            log.Info("Selected the dropdown by visible text " + text + " in the element " + byLocator);

        }

        public void SelectDropdownByVisibleTextUsingActions(By byLocator, string text)
        {

            IWebElement dropdown = driver.FindElement(byLocator);
            Actions actions = new Actions(driver);
            actions.MoveToElement(dropdown).Click().Perform();
            // Thread.Sleep(2000);
            actions.SendKeys(text).Perform();
            // Thread.Sleep(2000);
            actions.SendKeys(Keys.Enter).Perform();
            log.Info("Selected the dropdown by visible text " + text + " in the element " + byLocator);

        }

        //wait until the dropdown options are populated
        public void WaitForDropdownOptions(By dropdownLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
            {
                IWebElement dropdown = d.FindElement(dropdownLocator);
                SelectElement select = new SelectElement(dropdown);
                return select.Options.Count > 0;
            });
        }




        // check if the dropdown is selected by visible text if not then return false or true
        public bool IsDropdownSelectedByVisibleText(By byLocator, string text)
        {
            SelectElement select = new SelectElement(driver.FindElement(byLocator));
            return select.SelectedOption.Text == text;
        }

        //Select item from dropdown by index
        public void SelectDropdownByIndex(By byLocator, int index)
        {
            SelectElement select = new SelectElement(driver.FindElement(byLocator));
            select.SelectByIndex(index);
            log.Info("Selected the dropdown by index " + index + " in the element " + byLocator);
        }

        //Select item from dropdown by value
        public void SelectDropdownByValue(By byLocator, string value)
        {
            SelectElement select = new SelectElement(driver.FindElement(byLocator));
            select.SelectByValue(value);
            log.Info("Selected the dropdown by value " + value + " in the element " + byLocator);
        }

        // select dropdown by visible text until the text is selected
        public void SelectDropdownByVisibleTextUntil(By byLocator, string text)
        {
            while (true)
            {
                SelectElement select = new SelectElement(driver.FindElement(byLocator));
                select.SelectByText(text);
                //select.SelectByValue(text);
                WaitUntilTextboxIsNotEmpty(byLocator);
                if (select.SelectedOption.Text == text)
                {
                    log.Info("Selected the dropdown by visible text " + text + " in the element " + byLocator);
                    break; // The text was selected correctly, so break the loop
                }
            }
        }



        /* Random Number Generate */
        public int RandomNumber(int digits)
        {
            if (digits <= 0)
            {
                throw new ArgumentException("Number of digits (n) must be a positive integer.");
            }

            Random random = new Random();
            int rangeStart = (int)Math.Pow(10, digits - 1);
            int rangeEnd = (int)Math.Pow(10, digits) - 1;
            return random.Next(rangeStart, rangeEnd + 1);
        }











    }
}
