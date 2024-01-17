using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.PageObject
{
    public class ColombiaHomePage
    {
        private IWebDriver Driver;

        public ColombiaHomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        //localizadores 
        protected By EmpleoInput = By.Id("prof-cat-search-input");
        protected By UbicacionInput = By.Id("place-search-input");
        protected By PopUp = By.XPath("//*[@id='pop-up-webpush-sub']/div[2]/div/button[1]");
        protected By BttnBuscar = By.Id("search-button");
        protected By BttnSalario = By.XPath("/html/body/main/div[8]/div/div[1]/div[6]/p");
        protected By FiltroSalario = By.CssSelector("span[data-path='?sal=1']");
        protected By BttnExperiencia = By.XPath("/html/body/main/div[8]/div/div[1]/div[6]/p");
        protected By FiltroExperiencia = By.CssSelector("span[data-path='?iex=4&sal=1']");
        protected By BttnOferta = By.XPath("//*[@id=\"7A797577CC74F11161373E686DCF3405\"]/div[1]");
        protected By OpcionPostularse = By.XPath("//*[@id=\"7A797577CC74F11161373E686DCF3405\"]/div[1]/div/a");

        public void CompletarDatosDeBusqueda(string Ubicacion, string Empleo)
        {
            Driver.FindElement(UbicacionInput).SendKeys(Ubicacion);
            Driver.FindElement(BttnBuscar).Click();
            Driver.FindElement(PopUp).Click();
            Driver.FindElement(EmpleoInput).SendKeys(Empleo);
            Driver.FindElement(BttnBuscar).Click();

        }

        public void SeleccionarFiltros()
        {
            Driver.FindElement(BttnSalario).Click();
            Driver.FindElement(FiltroSalario).Click();
            Driver.FindElement(BttnExperiencia).Click();
            Driver.FindElement(FiltroExperiencia).Click();
        }

        public bool ValidarOfertaDeEmpleo(string Empleo, string Ubicacion)
        {
            IWebElement ValidarNombre = Driver.FindElement(By.XPath("//a[contains(text(), 'Test automation Engineer QA')]"));
            IWebElement ValidarUbicacion = Driver.FindElement(By.XPath("//*[@id='7A797577CC74F11161373E686DCF3405']/p[2]/span"));

            if (ValidarNombre.Text.Contains(Empleo) && ValidarUbicacion.Text.Contains(Ubicacion))
            {
                Console.Write("Se visualiza Test automation Engineer QA y que está localizado en Guainía");
                return true;
            }
            else
            {
                return false;
            }

        }


        public PostulacionPage SeleccionarOferta()
        {
            Thread.Sleep(2000);
            Driver.FindElement(BttnOferta).Click();
            Driver.FindElement(OpcionPostularse).Click();
            return new PostulacionPage(Driver);

        }
    }

}
