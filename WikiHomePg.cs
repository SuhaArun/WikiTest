using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using UnitTestProject4.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject4.PageObjects
{
    class WikiHomePg

    {
        private static IWebDriver driver { get; set; }

        [FindsBy(How = How.Name, Using = "search")]
        public IWebElement txtSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/form/fieldset/button")]
        public IWebElement btnSearch { get; set; }

        [FindsBy(How = How.Id, Using = "firstHeading")]
        public IWebElement header { get; set; }

        [FindsBy(How = How.LinkText, Using = "English")]
        public IWebElement englishlink { get; set; }

        [FindsBy(How = How.Id, Using = "searchLanguage")]
        public IWebElement ddLang { get; set; }


        public void SelectLang(string Lang)
        {
            SelectElement langselect = new SelectElement(ddLang);
            langselect.SelectByValue(Lang);

        }

        public ResultsPage WikiSearch(string Searchtxt, string Lang)
        {
            txtSearch.SendKeys(Searchtxt);
           
            SelectLang(Lang);
            btnSearch.Click();

            return new ResultsPage();
        }

        public string PageHeader()
        {
            string heading = header.Text;
            return heading.ToLower();
           
        }
    }
 
}
