using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuminusAuto.page
{
	public class TabelaDeCobrancaPage
	{
		IWebDriver driver;

		public TabelaDeCobrancaPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public void Navegar(string url)
		{
			driver.Manage().Timeouts();
			driver.Navigate().GoToUrl(url);
		}

		public void Criar()
		{
			Thread.Sleep(3000);
			driver.FindElement(By.CssSelector("button[funcionalidade='ProdutoEstadia.TabelaCobranca.Incluir']")).Click();
		}

		public void InformacoesGerais(string codigo , string nome)
		{
			Thread.Sleep(2000);
			driver.FindElement(By.CssSelector("input[formcontrolname='Codigo']")).SendKeys(codigo);
			driver.FindElement(By.CssSelector("input[formcontrolname='Nome']")).SendKeys(nome);

			driver.FindElement(By.CssSelector("select[formcontrolname='EstruturaTabelaCobrancaId']")).Click();
			driver.FindElement(By.CssSelector("select[formcontrolname='EstruturaTabelaCobrancaId']")).SendKeys(Keys.Down);
			driver.FindElement(By.CssSelector("select[formcontrolname='EstruturaTabelaCobrancaId']")).SendKeys(Keys.Enter);

			Thread.Sleep(1000);

			driver.FindElement(By.CssSelector("select[formcontrolname='RegraCobrancaId']")).Click();
			driver.FindElement(By.CssSelector("select[formcontrolname='RegraCobrancaId']")).SendKeys(Keys.Down);
			driver.FindElement(By.CssSelector("select[formcontrolname='RegraCobrancaId']")).SendKeys(Keys.Enter);

		}

		public void Adicionar()
		{
			Thread.Sleep(500);
			driver.FindElements(By.CssSelector("button[type='button']"))[0].Click();
		}

		public void TempoTolerancia( int diaSemana , string inicio , int serviceTime , string valorService, int lagTime , string valorLag)
		{
			if(diaSemana == 7)
			{
				Thread.Sleep(500);
				for (int i = 0; i < 2; i++)
				{
					driver.FindElements(By.CssSelector("li[title='Domingo']"))[1].Click();
					driver.FindElements(By.CssSelector("li[title='Segunda-feira']"))[1].Click();
					driver.FindElements(By.CssSelector("li[title='Terça-feira']"))[1].Click();
					driver.FindElements(By.CssSelector("li[title='Quarta-feira']"))[1].Click();
					driver.FindElements(By.CssSelector("li[title='Quinta-feira']"))[1].Click();
					driver.FindElements(By.CssSelector("li[title='Sexta-feira']"))[1].Click();
					driver.FindElements(By.CssSelector("li[title='Sábado']"))[1].Click();
				}
			}

			driver.FindElement(By.CssSelector("input[formcontrolname='VigenteAPartirDe']")).SendKeys(inicio);

			if (serviceTime == 1)
			{
				driver.FindElement(By.CssSelector("input[name='infinitoSemPagamento']")).Click();
				driver.FindElement(By.CssSelector("input[formcontrolname='TempoToleranciaSemPagamento']")).SendKeys(valorService);
				
			}
			if(lagTime == 1)
			{
				driver.FindElement(By.CssSelector("input[name='infinitoAposPagamento']")).Click();
				driver.FindElement(By.CssSelector("input[formcontrolname='TempoToleranciaAposPagamento']")).SendKeys(valorLag);
			}

			driver.FindElements(By.CssSelector("button[type='submit']"))[1].Click();

		}


		public void Salvar()
		{
			Thread.Sleep(1000);
			driver.FindElements(By.CssSelector("button[type='submit']"))[0].Click();
		}



	}
}
