using OpenQA.Selenium;
using System.Globalization;

namespace WebTestsQldDec22
{
    internal class PlanetTile
    {
        private IWebElement tileElement;

        public PlanetTile(IWebElement tileElement)
        {
            this.tileElement = tileElement;
        }

        public string Name => tileElement.FindElement(By.ClassName("name")).Text.ToLower();

        public double Radius
        {
            get
            {
                var distanceText = tileElement.FindElement(By.ClassName("radius")).Text;
                distanceText = RemoveKms(distanceText);
                return double.Parse(distanceText);
            }
        }

        public long Distance
        {
            get
            {
                var distanceText = tileElement.FindElement(By.ClassName("distance")).Text;
                distanceText = RemoveKms(distanceText);
                return long.Parse(distanceText, NumberStyles.AllowThousands);
            }
        }

        internal void ClickExplore()
        {
            tileElement.FindElement(By.TagName("button")).Click();
        }

        private static string RemoveKms(string distanceText)
        {
            return distanceText.Split(' ')[0];
        }
    }
}