using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WindowsFormsApp1
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.ebay.com");
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }

        [Test]
        public void Test1_field()
        {
            var element = driver.FindElement(By.Id("gh-ac"));
            Assert.IsNotNull(element);
        }

        [Test]
        public void Test2_search()
        {
            var element = driver.FindElement(By.Id("gh-btn"));
            Assert.IsNotNull(element);
        }
    }
}