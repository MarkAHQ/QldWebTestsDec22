using OpenQA.Selenium;

namespace WebTestsQldDec22
{
    internal class PlanetPage
    {
        private IWebDriver driver;

        public PlanetPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal PlanetTile GetPlanet(Func<PlanetTile, bool> strategy)
        {
            foreach (var planetTile in driver.FindElements(By.ClassName("planet")))
            {
                var planet = new PlanetTile(planetTile);
                if (strategy.Invoke(planet))
                {
                    return planet;
                }
            }

            throw new NotFoundException();
        }

        internal bool IsPopupDisplayed()
        {
            return driver.FindElement(By.ClassName("popup")).Displayed;
        }
    }
}
