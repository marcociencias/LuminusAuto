using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuminusAuto.page
{
	
	public class MidiaPerdidaPage
	{
		IWebDriver driver;

		public MidiaPerdidaPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public void Navegar(string url)
		{
			Thread.Sleep(2000);
			driver.Navigate().GoToUrl(url);
			Thread.Sleep(2000);
		}

		public void Criar()
		{
			Thread.Sleep(3000);
			driver.FindElement(By.CssSelector("button[funcionalidade='ProdutoEstadia.RegraMidiaPerdida.Incluir']")).Click();
		}

		public void InformacoesGerais(string nome)
		{
			Thread.Sleep(2000);
			driver.FindElement(By.CssSelector("input[formcontrolname='Nome']")).SendKeys(nome);
		}


		public void RegrasDePerda(int tipo)
		{
			if (tipo == 1)
			{
				driver.FindElements(By.CssSelector(".menu-popovertable"))[0].Click();
				driver.FindElements(By.CssSelector(".menu-popovertable"))[0].FindElement(By.LinkText("alterar")).Click();
			}
			if(tipo == 2)
			{
				driver.FindElements(By.CssSelector(".menu-popovertable"))[1].Click();
				driver.FindElements(By.CssSelector(".menu-popovertable"))[1].FindElement(By.LinkText("alterar")).Click();
			}
			if(tipo == 3)
			{
				driver.FindElements(By.CssSelector(".menu-popovertable"))[2].Click();
				driver.FindElements(By.CssSelector(".menu-popovertable"))[2].FindElement(By.LinkText("alterar")).Click();
			}
			if(tipo == 4)
			{
				driver.FindElements(By.CssSelector(".menu-popovertable"))[3].Click();
				driver.FindElements(By.CssSelector(".menu-popovertable"))[3].FindElement(By.LinkText("alterar")).Click();
			}

		}

		public void MotivoPerda(string valorTaxa , int compCobranca , int permiteAlteracao , int cobrarPPeriodo , int variavel , string horarioCalculo)
		{
			Thread.Sleep(1000);
			driver.FindElement(By.CssSelector("input[formcontrolname='ValorTaxa']")).SendKeys(valorTaxa);

			if (permiteAlteracao == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='PermiteAlterarTaxa']")).Click();
			}
			if (cobrarPPeriodo == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='CobrarPrimeiroPeriodoDaMidiaGerada']")).Click();
			}
			if(compCobranca == 1)
			{
				driver.FindElement(By.CssSelector("option[value='1']")).Click();
			}
			if(compCobranca == 2)
			{
				driver.FindElement(By.CssSelector("option[value='2']")).Click();
			}
			if (variavel == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='HorarioVariavel']")).Click();
				driver.FindElement(By.CssSelector("input[formcontrolname='HorarioCalculoEstadia']")).SendKeys(horarioCalculo);
			}
			driver.FindElement(By.CssSelector("select[formcontrolname='TabelaCobranca.Id']")).Click();
			driver.FindElements(By.CssSelector("select option"))[4].Click();

		}

		public void SalvarMotivoPerda()
		{
			driver.FindElements(By.CssSelector("button[type='submit']"))[1].Click();
		}

		public void Salvar()
		{
			Thread.Sleep(500);
			driver.FindElements(By.CssSelector("button[type='submit']"))[0].Click();
		}

	}
}
