using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CSharpPractice
{
    public class GenName
    {
        public static void Main(string[] args)
        {
            GenName dd = new GenName();
            dd.Start();
        }


        //selenium script
        public ChromeDriver driver;
        public void Start()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.demoqa.com/";
            Thread.Sleep(9000);
            driver.ExecuteScript("scroll(0,100)");
            driver.FindElement(By.XPath("//h5[text()='Elements']")).Click();
            WebTables();
        }
        public void WebTables()
        {
            RandomUserDetails rum = new RandomUserDetails();
            var userdd = rum.GenerateRandomPerson();
            //checking with passing values submit
            driver.FindElement(By.XPath("//span[contains(@class,'text')]  [contains(text(),'Web Tables')]")).Click();
            driver.FindElement(By.XPath("//button[contains(@id,'addNewRecordButton')]  [contains(text(),'Add')]")).Click();
            driver.FindElement(By.XPath("//input[contains(@id,'firstName')]")).SendKeys(userdd.FirstName);
            driver.FindElement(By.XPath("//input[contains(@id,'lastName')]")).SendKeys(userdd.LastName);
            driver.FindElement(By.XPath("//input[contains(@id,'userEmail')]")).SendKeys(userdd.Email);
            driver.FindElement(By.XPath("//input[contains(@id,'age')]")).SendKeys(userdd.Age.ToString());
            driver.FindElement(By.XPath("//input[contains(@id,'salary')]")).SendKeys(userdd.Salary.ToString());
            driver.FindElement(By.XPath("//input[contains(@id,'department')]")).SendKeys(userdd.Department);
            driver.FindElement(By.XPath("//button[contains(@id,'submit')]")).Click();

            
        }

    }
}
