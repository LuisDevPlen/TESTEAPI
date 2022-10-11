using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Reflection;

namespace desafioAPI.Automacao
{
    public class RealizaConsultaAutomacao
    {

        public static double BuscaCotacao(string moedaBase, string moedaAlvo)
        {

   

            IWebDriver driver;
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

            // driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver = new ChromeDriver(chromeOptions);
          

            driver.Navigate().GoToUrl("https://www.google.com.br");
            chromeOptions.AddArgument("--ignore-certificate-errors");
            driver.Manage().Window.Maximize();
          

           var campoPesquisa = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input"));
            campoPesquisa.Click();
            campoPesquisa.Clear();
            campoPesquisa.SendKeys("valor " + moedaBase + " para " + moedaAlvo);


            driver.FindElement((By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[3]/center/input[1]"))).SendKeys(Keys.Enter);

            var valor = driver.FindElement(By.XPath("/html/body/div[7]/div/div[11]/div/div[2]/div[2]/div/div/div[1]/div/div/div/div/div/div/div/div[3]/div[1]/div[3]/div/div[2]/input")).GetAttribute("value");

            driver.Quit();
            return Convert.ToDouble(valor.Replace(".",","));


        }

    }
}
