using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Projekat
{
    class KlasaKlasa : SeleniumBaseClass
    {
        [Test]
        [Category("Vjezba")]
        public void Test1()
        {
            this.NavigateTo("https://www.emmi.rs/");
            this.DoWait(5);
            IWebElement monitori = this.FindElement(By.XPath("//a[@title='Monitori']"));
            monitori.Click();
            this.DoWait(5);
            IWebElement brend = this.FindElement(By.Name("brandId"));
            var select = new SelectElement(brend);
            select.SelectByValue("448");
            this.DoWait(5);
            IWebElement tip = this.FindElement(By.Name("tip"));
            select = new SelectElement(tip);
            select.SelectByText("TN");
            this.DoWait(5);
            IWebElement trazi = this.FindElement(By.XPath("//input[@value='traži']"));
            trazi.Click();
            this.DoWait(5);
            IWebElement omen = this.FindElement(By.XPath("//a[contains(text(), 'OMEN')]"));
            omen.Click();
            this.DoWait(5);
            IWebElement price = this.FindElement(By.XPath("//div[@class='price']"));
            var cijena = price.Text.Trim();
            Assert.AreEqual("29.990", cijena);
            this.DoWait(3);
        }

        [SetUp]
        public void SetUpTests()
        {
            //this.Driver = new FirefoxDriver();
            this.Driver = new ChromeDriver();
            this.Driver.Manage().Cookies.DeleteAllCookies();
            this.Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDownTests()
        {
            this.Close();
        }
    }
}