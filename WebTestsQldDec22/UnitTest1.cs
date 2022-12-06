using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebTestsQldDec22
{
    [TestClass]
    public class UnitTest1
    {
        private WebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net/#/";
        }

        [TestMethod]
        public void EnterName_ClickSubmit_PopupAppears()
        {
            // Arrange
            const string expectedText = "Mark Arnold Selenium";        
            driver.FindElement(By.Id("forename")).SendKeys(expectedText);
            
            // Act
            driver.FindElement(By.Id("submit")).Click();

            // Assert
            var popup = driver.FindElement(By.ClassName("popup-message"));
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(500)).Until(d => popup.Displayed);
            Assert.AreEqual(expected: "Hello " + expectedText, actual: popup.Text);

            driver.Quit();
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}