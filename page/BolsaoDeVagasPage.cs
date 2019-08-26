using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuminusAuto.page
{
	public class BolsaoDeVagasPage
	{

		private IWebDriver driver { get; set; }

		public BolsaoDeVagasPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public void Navegar(string url)
		{
			Thread.Sleep(2000);
			driver.Navigate().GoToUrl(url);
			Thread.Sleep(2000);
		}
	

		public void Criar(string numero, string nome, string qtdVagas)
		{
			driver.Navigate().GoToUrl("http://192.168.1.172:4200/configuracoesdoestacionamento/bolsoesdevagas/criar");

			Thread.Sleep(2000);
			IWebElement codigoBolsao = driver.FindElement(By.CssSelector("input[formcontrolname=Codigo]"));
			IWebElement nomeBolsao = driver.FindElement(By.CssSelector("input[formcontrolname=Nome]"));
			IWebElement quantidadeVagasBolsao = driver.FindElement(By.CssSelector("input[formcontrolname=QuantidadeVagas]"));

			codigoBolsao.Clear();
			codigoBolsao.SendKeys(numero);
			nomeBolsao.Clear();
			nomeBolsao.SendKeys(nome);
			quantidadeVagasBolsao.Clear();
			quantidadeVagasBolsao.SendKeys(qtdVagas);
		}

		public void Salvar()
		{
			Thread.Sleep(3000);
			driver.FindElement(By.CssSelector("button[type=submit]")).Submit();
		}

		public void Alterar()
		{		
			Thread.Sleep(2000);
			driver.FindElements(By.CssSelector("div[class=\"menu-popovertable\"]"))[0].Click();
			Thread.Sleep(500);
			driver.FindElements(By.CssSelector(".menu-popovertable ul>li"))[1].Click();
			Thread.Sleep(1000);
			IWebElement nomeBolsao = driver.FindElement(By.CssSelector("input[formcontrolname=Nome]"));
			nomeBolsao.SendKeys("ALTERADO");
			driver.FindElement(By.CssSelector("button[type=submit")).Submit();
		}

		public void Excluir()
		{
			Thread.Sleep(2000);
			driver.FindElements(By.CssSelector("div[class=\"menu-popovertable\"]"))[0].Click();
			Thread.Sleep(500);
			driver.FindElements(By.CssSelector(".menu-popovertable ul>li"))[2].Click();
			Thread.Sleep(1000);
			driver.FindElement(By.CssSelector("button[type=submit")).Submit();
		}


	}
}
