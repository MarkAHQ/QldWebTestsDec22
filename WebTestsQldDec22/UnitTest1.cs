using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebTestsQldDec22
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            driver = DriverFactory.Build(TestContext);
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net/#/";
            driver.Manage().Window.Maximize();
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

        [TestMethod]
        public void EnterDetails_CLickSubmit_CheckPopup()
        {
            // Arrange
            new Toolbar(driver).ClickFormsButton();
            var form = new Form(driver);
            form.SetName("Mark Arnold");
            form.SetEmail("mark.arnold@accesshq.com");
            form.SetState("QLD");
            form.ClickAgree();

            // Act
            form.ClickSubmit();

            // Assert
            Assert.AreEqual("Thanks for your feedback Mark Arnold", form.PopupMsg);
        }

        [TestMethod]
        public void OnPlanetPage_ClickEarthExplore_VerifyPopup()
        {
            new Toolbar(driver).ClickPlanetsButton();

            var planetPage = new PlanetPage(driver);
            planetPage.GetPlanet(planet => planet.Name == "earth").ClickExplore();

            Assert.IsTrue(planetPage.IsPopupDisplayed());
        }

        [TestMethod]
        public void DistGreaterThan1M_IsSaturn()
        {
            new Toolbar(driver).ClickPlanetsButton();

            var planetPage = new PlanetPage(driver);
            planetPage.GetPlanet(planet => planet.Distance > 1000000).ClickExplore();
            Assert.IsTrue(planetPage.IsPopupDisplayed());
        }

        [TestMethod]
        public void OnPlanetPage_VerifyVenusRadius()
        {
            new Toolbar(driver).ClickPlanetsButton();

            var planetPage = new PlanetPage(driver);
            Assert.AreEqual(expected: 6051.8, 
                            actual: planetPage.GetPlanet(planet => planet.Name == "venus").Radius);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}