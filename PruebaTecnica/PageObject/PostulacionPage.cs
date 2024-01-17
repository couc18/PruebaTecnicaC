using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PruebaTecnica.PageObject
{
    public class PostulacionPage
    {
        private IWebDriver Driver;

        public PostulacionPage(IWebDriver driver)
        {
            Driver = driver;
        }

        //localizadores
        protected By MailInput = By.Id("LoginModel_Email");
        protected By BttnContinueWMail = By.Id("continueWithMailButton");
        protected By NameInput = By.Id("Name");
        protected By LastNameInput = By.Id("SurName");
        protected By PassInput = By.Id("Password");
        protected By SelectDepartamento = By.XPath("//span[contains(text(),'Selecciona')]");
        protected By SelectUbicacion = By.XPath("//li[starts-with(@data-value,'31')]");
        protected By CaptchaInput = By.Id("CaptchaInputText");
        protected By BttnContinue = By.Id("continueButton");


        public void CompletarMail(string mail)
        {
            Thread.Sleep(2000);
            Driver.FindElement(MailInput).SendKeys(mail);
            Driver.FindElement(BttnContinueWMail).Click();
        }

        public void CompletarFormulario(string Name, string LastName, string Password, string Cargo, string Captcha)
        {
            Thread.Sleep(2000);
            Driver.FindElement(NameInput).SendKeys(Name);
            Driver.FindElement(LastNameInput).SendKeys(LastName);
            Driver.FindElement(PassInput).SendKeys(Password);


            IWebElement CargoInput = Driver.FindElement(By.Id("Cargo"));
            CargoInput.SendKeys(Cargo);
            Actions actions = new Actions(Driver);
            actions.MoveToElement(CargoInput)
                .SendKeys(Keys.Enter)
                .Perform();

            Driver.FindElement(SelectDepartamento).Click();
            Thread.Sleep(2000);
            Driver.FindElement(SelectUbicacion).Click();
            Driver.FindElement(CaptchaInput).SendKeys(Captcha);
            Driver.FindElement(BttnContinue).Click();
            
        }

        public bool ValidaErrorCaptcha()
        {


            try
            {

                IWebElement captchaError = Driver.FindElement(By.XPath("//span[contains(text(), 'Captcha incorrecto')]"));


                return captchaError != null && captchaError.Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;
            }



        }
    }
} 
        
