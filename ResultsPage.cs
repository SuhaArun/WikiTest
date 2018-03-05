using System;
using System.Collections.Generic;
using System.Threading;
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
    class ResultsPage
    {

        private static IWebDriver driver { get; set; }

        [FindsBy(How = How.LinkText, Using = "English")]
        public IWebElement englishLink { get; set; }

      }
}
