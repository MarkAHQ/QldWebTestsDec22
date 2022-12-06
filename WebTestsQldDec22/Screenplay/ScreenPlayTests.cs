using Boa.Constrictor.Screenplay;
using Boa.Constrictor.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestsQldDec22.Screenplay.Models;

namespace WebTestsQldDec22.Screenplay
{
    [TestClass]
    public class ScreenPlayTests
    {
        [TestMethod]
        public void Test1()
        {
            IActor mark = new Actor("mark");
            mark.Can(BrowseTheWeb.With(new ChromeDriver()));
            mark.AttemptsTo(Navigate.ToUrl("https://d18u5zoaatmpxx.cloudfront.net/#/"));
            mark.AttemptsTo(Click.On(Homepage.UpDownButton));
        }
    }
}
