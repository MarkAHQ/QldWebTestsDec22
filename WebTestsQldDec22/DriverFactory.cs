using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace WebTestsQldDec22
{
    internal static class DriverFactory
    {
        internal static IWebDriver Build(TestContext testContext)
        {
            string browserType = (string)testContext.Properties["browserType"];
            switch (browserType)
            {
                case "local":
                    return new ChromeDriver();
                case "remote":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--no-sandbox");
                    chromeOptions.BrowserVersion = "108.0";
                    chromeOptions.PlatformName = "ANY";
                    return new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions);
                default:
                    throw new Exception($"Browser type of {browserType} must be 'local' or 'remote'");
            }
        }
    }
}