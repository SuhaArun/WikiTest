using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;
using UnitTestProject4.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;
using UnitTestProject5.Features;
using System.Threading;

namespace UnitTestProject4.Steps
{
    [Binding]
    public class WikipediaSearchSteps

    {
        private IWebDriver driver;
        WikiHomePg Hpage = new WikiHomePg();
             
        [BeforeScenario()]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [AfterScenario()]
        public void TearDown()
        {
            driver.Quit();
        }

        [Given(@"a web browser is at the Wiki home page")]
        public void GivenAWebBrowserIsAtTheWikiHomePage()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            PageFactory.InitElements(driver, Hpage);

            Console.WriteLine("WIKI page opened");
        }

                
        [When(@"user searches (.*) in English")]
        public void WhenUserSearchesInEnglish(string searchstring)
        {   

            ResultsPage Rpage = Hpage.WikiSearch(searchstring, "en");
        }

        [Then(@"the result page with (.*) heading is displayed")]
        public void ThenTheResultPageWithHeadingIsDisplayed(string searchstring)

        {
            Assert.AreEqual(searchstring.ToLower(), Hpage.PageHeader().ToLower());
        }
        

        [When(@"user searches a ""(.*)"" in any (.*)")]
        public void WhenUserSearchesAInAdAnyFr(string searchid, string lang)
        {
            ResultsPage Rpage = Hpage.WikiSearch(searchid, lang);
        }

        [Then(@"the search result page is available in that (.*)")]
        public void ThenTheSearchResultPageIsAvailableInThatFR(string lang)
        {
            string pageurl = driver.Url;
            string urlLang = pageurl.Substring(8, 2);
            Assert.AreEqual(lang, urlLang);

        }

        [Then(@"the result page should have English language link available")]
        public void ThenTheResultPageShouldHaveEnglishLanguageLinkAvailable()
        {
           
            string pageurl = driver.Url;
            string urlLang = pageurl.Substring(8, 2);

            if (urlLang == "en")
            {
                Console.WriteLine("Already in an English page");
            }
            else
            {
                try
                {
                    Assert.IsTrue(driver.FindElement(By.LinkText("English")).Displayed);
                }
                catch 
                {
                    Console.WriteLine("English Link not available for the search result page");
                    Assert.Fail();
                }
            }
        }
    }
}
