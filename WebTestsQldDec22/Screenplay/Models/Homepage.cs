using Boa.Constrictor.Selenium;
using OpenQA.Selenium;

namespace WebTestsQldDec22.Screenplay.Models
{
    internal class Homepage
    {
        public static IWebLocator UpDownButton => new WebLocator("Click me UP/DOWN button", By.ClassName("anibtn"));

    }
}