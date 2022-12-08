using OpenQA.Selenium;

namespace WebTestsQldDec22
{
    internal class Toolbar
    {
        private WebDriver driver;

        public Toolbar(WebDriver driver)
        {
            this.driver = driver;
        }

        internal void ClickFormsButton()
        {
            driver.FindElement(By.CssSelector("[aria-label=forms].v-btn")).Click();
        }

        internal void ClickPlanetsButton()
        {
            driver.FindElement(By.CssSelector("[aria-label=planets].v-btn")).Click();
        }
    }
}