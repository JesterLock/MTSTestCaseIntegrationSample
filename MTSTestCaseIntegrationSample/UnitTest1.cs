using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

namespace MTSTestCaseIntegrationSample
{
    public class Tests
    {

        private IWebDriver driver;
        private const string appURL = "https://moskva.mts.ru/personal";

        [SetUp]
        public void Setup()
        {

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [Test]
        public void Test1()
        {
            driver.Manage().Window.FullScreen();
            driver.Navigate().GoToUrl(appURL);
            Assert.IsTrue(driver.FindElement(By.CssSelector("body > div.g-page-wrapper > div > div.mts16-footer__to-bottom-content > header > div.header__body > div > div > a > img")).Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}