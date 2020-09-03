using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoSquare_Maintenance
{
    class Program
    {
        IWebDriver driver;
        public IWebDriver SetUpDriver()
        {
            driver = new ChromeDriver(@"C:\Webdrivers\");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return driver;
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public void SendText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        #region Google Locators
        By GoogleSearchBar = By.XPath("//input[@name='q']");
        By GoogleSearIcon = By.XPath("//div[@class='tfB0Bf']//input[@name='btnK']");
        By UnoSquareGoogleResult = By.CssSelector("div > a[href='https://www.unosquare.com/']");
        #endregion

        #region UnoSquare Locators
        By UnoSquareServicesMenu = By.CssSelector("li > a[href='/Services']");
        By PracticeAreas = By.CssSelector("li > a[href='/PracticeAreas']");
        By ContactUs = By.CssSelector("li > a[href='/ContactUs']");
        #endregion  
        static void Main(string[] args)
        {

            IWebDriver Browser;
            IWebElement element;
            Program program = new Program();
            Browser = program.SetUpDriver();
            Browser.Url = "https://www.google.com";

            //Wirite the locator for the Google Search Bar
            element = Browser.FindElement(program.GoogleSearchBar);

            // Write Assert True that element is present [Google Search] button
            Assert.IsTrue(program.GoogleSearIcon != null);

            //Send the text "Unosquare" to the Text Bar
            program.SendText(element, "Unosquare");

            // Click on the Search Button
            program.Click(Browser.FindElement(program.GoogleSearIcon));

            // Write Assert Equal [Unosquare: Digital Transformation Services | Agile Staffing ...] vs [Element.text]
            Assert.AreEqual("Unosquare: Digital Transformation Services | Agile Staffing ...", Browser.FindElement(By.XPath("//h3[contains(text(),'Unosquare: Digital Transformation Services | Agile')]")).Text);

            // Locate the first result corresponding to Unosquare and click on the Link
            element = Browser.FindElement(program.UnoSquareGoogleResult);
            program.Click(element);

            // Write Assert True that element is present [Our Dna] menu object
            Assert.IsTrue(Browser.FindElement(By.CssSelector("li > a[href='/OurDna']")).Displayed);
            // Write Assert True that element is present [Articles & Events] menu object
            Assert.IsTrue(Browser.FindElement(By.CssSelector("li > a[href='/Articles']")).Displayed);
            // Write Assert Equal [Digital transformation solutions] vs [Element.text] h2 ojbect -- Where is this element? I don't see it. -Sergio.


            //Locate the Service Menu and Click the element
            element = Browser.FindElement(program.UnoSquareServicesMenu);

            program.Click(element);

            //Locate the Practice Areas Menu and Click the Element
            element = Browser.FindElement(program.PracticeAreas);

            program.Click(element);

            //Locate the Contact Us Menu and Click the Element
            element = Browser.FindElement(program.ContactUs);

            program.Click(element);

        }
    }
}
