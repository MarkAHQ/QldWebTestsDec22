using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebTestsQldDec22
{
    internal class Form
    {
        private readonly IWebDriver driver;

        public Form(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string PopupMsg
        {
            get
            {
                IWebElement popupElement = driver.FindElement(By.ClassName("popup-message"));
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => popupElement.Displayed);
                return popupElement.Text;
            }
        }

        IWebElement Email => driver.FindElement(By.Id("email"));

        internal void ClickAgree()
        {
            driver.FindElement(By.CssSelector("[for=agree]")).Click();
        }

        internal void ClickSubmit()
        {
            foreach (var button in driver.FindElements(By.TagName("button")))
            {
                if (button.Text.ToLower() == "submit".ToLower())
                {
                    button.Click();
                    return;
                }
            }

            throw new NotFoundException("Could not find the submit button");
        }

        internal void SetEmail(string email)
        {
            Email.SendKeys(email);
        }

        internal void SetName(string name)
        {
            driver.FindElement(By.Id("name")).SendKeys(name);
        }

        internal IWebElement SetState(string state)
        {
            driver.FindElement(By.ClassName("v-select__selections")).Click();
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(250)).Until(
                d => driver.FindElement(By.CssSelector("[role=option]")).Displayed);

            foreach (var stateSelection in driver.FindElements(By.CssSelector("[role=option]")))
            {
                if (stateSelection.Text == state)
                {
                    stateSelection.Click();
                    return stateSelection;
                }
            }

            throw new NotFoundException("Could not find " + state);
        }
    }
}