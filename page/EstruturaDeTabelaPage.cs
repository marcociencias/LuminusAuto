using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuminusAuto.page
{
	public class EstruturaDeTabelaPage
	{
		IWebDriver driver;
		

		public EstruturaDeTabelaPage(IWebDriver driver )
		{
			this.driver = driver;

		}


		public void Navegar(string url)
		{
			driver.Manage().Timeouts();
			driver.Navigate().GoToUrl(url);
			Thread.Sleep(2000);

		}

		public void Criar()
		{
			Thread.Sleep(3000);
			IWebElement descricao = driver.FindElement(By.CssSelector("button[funcionalidade='ProdutoEstadia.EstruturaTabelaCobranca.Incluir'"));
			descricao.Click();

			}

		public void InformacoesGerais(string nome)
		{
			driver.Manage().Timeouts();
			driver.FindElement(By.CssSelector("input[formcontrolname='Nome']")).SendKeys(nome);
		}
		
		public void AdicionarEstrutura()
		{
			driver.Manage().Timeouts();
			driver.FindElement(By.CssSelector("button[type]")).Click();
		}

		public void Periodo(string periodo , int indice)
		{
			driver.FindElements(By.CssSelector("input[formcontrolname=Inicio]"))[indice].SendKeys(periodo);

		}
		public void AdicionarFracao(string duracao , string repeticao , int quant, int indice)
		{
			// Iniciar a fração pelo indice de numero 2
			// Exemplo
			// fraçao 1 = indice 2
			// fração 2 = incide 3 ....

			for (int i = 0; i < quant; i++)
			{
				Thread.Sleep(1800);
				driver.FindElements(By.CssSelector("button[type=button"))[indice].Click();
				Thread.Sleep(1000);
				driver.FindElement(By.CssSelector("input[formcontrolname=Duracao")).SendKeys(duracao);
				driver.Manage().Timeouts();
				driver.FindElement(By.CssSelector("input[formcontrolname=Repeticao")).SendKeys(repeticao);
				driver.FindElements(By.CssSelector("button[type=submit"))[1].Click();
			}
		}

		public void Repeticao(int de , int ate)
		{
			
			driver.FindElements(By.CssSelector("option[value"))[de].Click(); 
			driver.FindElements(By.CssSelector("option[value"))[ate].Click();

		}

		public void AdicionarPeriodo(int miliTimer)
		{
			IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("scroll(0,-250);");
			Thread.Sleep(2000);
			driver.FindElements(By.CssSelector("button[type='button']"))[1].Click();
			
		}

		public void Salvar()
		{
			IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("scroll(0,250);");
			Thread.Sleep(1000);
			driver.FindElements(By.CssSelector("button[type='submit']"))[0].Click();
		}
	}
}
