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
	public class ParametrosGeraisDoEstacionamento
	{
		IWebDriver driver;

		public ParametrosGeraisDoEstacionamento(IWebDriver driver)
		{
			this.driver = driver;
		}

		public void Navegar(string url)
		{
			Thread.Sleep(2000);
			driver.Navigate().GoToUrl(url);
			Thread.Sleep(2000);
		}
		
		public void Criar(string enderecoIp, string portaIp, string tempoLimiteEx, string tempoLimiteRec, string tempoLimiteEnvio)
		{
			Thread.Sleep(2000);
			driver.FindElement(By.CssSelector("button[funcionalidade='ConfiguracoesdoEstacionamento.ParametrosGeraisEstacionamento.Alterar']")).Click();
			//driver.FindElements(By.CssSelector("div[class=\"menu-popovertable\"]"))[0].Click();
			//Thread.Sleep(2000);
			//driver.FindElements(By.CssSelector(".menu-popovertable ul>li"))[2].Click();
			//Thread.Sleep(2000);
			//driver.FindElements(By.CssSelector("button[type=submit"))[1].Click();
			Thread.Sleep(2000);
			Clear();
			driver.FindElement(By.CssSelector("input[name=EnderecoIP")).SendKeys(enderecoIp);
			driver.FindElement(By.CssSelector("input[name=PortaIP]")).SendKeys(portaIp); ;
			driver.FindElement(By.CssSelector("input[name=TempoLimiteExecucoes")).SendKeys(tempoLimiteEx);
			driver.FindElement(By.CssSelector("input[name=TempoLimiteRecebimento")).SendKeys(tempoLimiteRec);
			driver.FindElement(By.CssSelector("input[name=TempoLimiteEnvio")).SendKeys(tempoLimiteEnvio);
		}

		public void Operacao(string horarioVirada)
		{
			driver.FindElement(By.CssSelector("input[name=HorarioVirada")).SendKeys(horarioVirada);
			driver.FindElements(By.CssSelector("input[type=checkbox]"))[0].Click();
			driver.FindElements(By.CssSelector("input[type=checkbox]"))[1].Click();
			driver.FindElements(By.CssSelector("input[type=checkbox]"))[2].Click();
			driver.FindElements(By.CssSelector("input[type=checkbox]"))[3].Click();
			driver.FindElements(By.CssSelector("input[type=checkbox]"))[4].Click();
			driver.FindElements(By.CssSelector("input[type=checkbox]"))[5].Click();
			driver.FindElements(By.CssSelector("input[type=checkbox]"))[6].Click();
			driver.FindElements(By.CssSelector("input[type=checkbox]"))[7].Click();
			driver.FindElements(By.CssSelector("input[type=checkbox]"))[8].Click();
			driver.FindElements(By.CssSelector("input[type=checkbox]"))[9].Click();
		}

		public void SeloDesconto(string dataSeloDesc)
		{
			driver.FindElement(By.CssSelector("input[name=DataBaseSeloDesconto")).Click();
			driver.FindElement(By.CssSelector("input[name=DataBaseSeloDesconto")).Clear();
			driver.FindElement(By.CssSelector("input[name=DataBaseSeloDesconto")).SendKeys(dataSeloDesc);
		}

		public void ControleVagas(string tempoVerif, string quantVerOffline)
		{
			driver.FindElement(By.CssSelector("input[name=TempoVerificacoes]")).SendKeys(tempoVerif);
			driver.FindElement(By.CssSelector("input[name=QuantidadeVerificacoesOffline")).SendKeys(quantVerOffline);
			driver.FindElement(By.CssSelector("option[value=LiberarAcesso]")).Click();
		}

		public void Clear()
		{

			IWebElement enderecoIp = driver.FindElement(By.CssSelector("input[name=EnderecoIP"));
			IWebElement portaIp = driver.FindElement(By.CssSelector("input[name=PortaIP]"));
			IWebElement tempoLimiteExecucoes = driver.FindElement(By.CssSelector("input[name=TempoLimiteExecucoes"));
			IWebElement tempoLimiteRecebimento = driver.FindElement(By.CssSelector("input[name=TempoLimiteRecebimento"));
			IWebElement tempoLimiteEnvio = driver.FindElement(By.CssSelector("input[name=TempoLimiteEnvio"));
			IWebElement horarioVirada = driver.FindElement(By.CssSelector("input[name=HorarioVirada"));
			IWebElement dataSeloDesconto = driver.FindElement(By.CssSelector("input[name=DataBaseSeloDesconto"));
			IWebElement tempoVerificacoes = driver.FindElement(By.CssSelector("input[name=TempoVerificacoes]"));
			IWebElement quantidadeVerificacoesOffLine = driver.FindElement(By.CssSelector("input[name=QuantidadeVerificacoesOffline"));

			enderecoIp.Clear();
			portaIp.Clear();
			tempoLimiteExecucoes.Clear();
			tempoLimiteRecebimento.Clear();
			tempoLimiteEnvio.Clear();
			horarioVirada.Clear();
			dataSeloDesconto.Clear();
			tempoVerificacoes.Clear();
			quantidadeVerificacoesOffLine.Clear();
		}

		public void Salvar()
		{
			Thread.Sleep(1500);
			driver.FindElement(By.CssSelector("button[type='submit']")).Click();
		}

		public void Detalhar()
		{
			Thread.Sleep(2000);
			driver.FindElements(By.CssSelector("div[class=\"menu-popovertable\"]"))[0].Click();
			Thread.Sleep(2000);
			driver.FindElements(By.CssSelector(".menu-popovertable ul>li"))[0].FindElement(By.LinkText("detalhar")).Click();
			Thread.Sleep(2000);
			driver.FindElement(By.CssSelector("button[type=button]")).Click();
		}

		public void Alterar()
		{
			driver.FindElements(By.CssSelector("div[class=\"menu-popovertable\"]"))[0].Click();
			Thread.Sleep(2000);
			driver.FindElements(By.CssSelector(".menu-popovertable ul>li"))[1].FindElement(By.LinkText("alterar")).Click();
			Thread.Sleep(2000);
			driver.FindElement(By.CssSelector("button[type=button]")).Click();
		}
	}
}
