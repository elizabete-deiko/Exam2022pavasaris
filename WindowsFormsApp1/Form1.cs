using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        IWebDriver driver;
        public Form1()
        {
            InitializeComponent();
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.ebay.com");

            System.Threading.Thread.Sleep(3000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var searchBox = wait.Until(d => d.FindElement(By.Id("gh-ac")));
            searchBox.Clear();
            searchBox.SendKeys(textBox1.Text);

            var searchBtn = wait.Until(d => d.FindElement(By.Id("gh-btn")));
            searchBtn.Click();

            wait.Until(d => d.Url.Contains("_nkw"));

            string url = driver.Url;

            textBox2.Text = url;
            richTextBox1.AppendText(url + Environment.NewLine);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            driver.Navigate().Back();

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            driver.Quit();
        }
    }
}
