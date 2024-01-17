using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using PruebaTecnica.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PruebaTecnica.Test
{
    [TestClass]
    public class ComputrabajoTest
    {

        private IWebDriver Driver;

        [TestInitialize]
        public void Inicializar()
        {
            Driver = new ChromeDriver();
        }

        [TestMethod]
        public void BusquedaYPostulacionTest()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.NavegarAComputrabajo();

            ColombiaHomePage colombiaHomePage = homePage.IrAColombia();
            colombiaHomePage.CompletarDatosDeBusqueda("Guainía", "qa");
            colombiaHomePage.SeleccionarFiltros();
            Assert.IsTrue(colombiaHomePage.ValidarOfertaDeEmpleo("Test automation Engineer QA", "Guainía"));
           
            PostulacionPage postulacionPage = colombiaHomePage.SeleccionarOferta();
            postulacionPage.CompletarMail("prueba@test.com");
            postulacionPage.CompletarFormulario("Prueba", "Test", "1A0456789", "Tester QA", "0000");

            bool SeMuestraErrorCaptcha = postulacionPage.ValidaErrorCaptcha();
            Assert.IsTrue(SeMuestraErrorCaptcha, "El error de captcha No se encuentro");
            if (SeMuestraErrorCaptcha)
            {
                Console.WriteLine("El error de captcha se muestra correctamente.");
                
            }

        }

        [TestCleanup]
        public void Limpiar()
        {
            Driver.Quit();
        }
    }
}
