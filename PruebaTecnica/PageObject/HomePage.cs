using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.PageObject
{
    public class HomePage
    {
        private IWebDriver Driver;

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavegarAComputrabajo()
        {
            Driver.Navigate().GoToUrl("https://www.computrabajo.com/");
        }

        public ColombiaHomePage IrAColombia()
        {
            IWebElement SelectColombia = Driver.FindElement(By.Id("Colombialink"));
            SelectColombia.Click();
            return new ColombiaHomePage(Driver);
        }

    }
}
