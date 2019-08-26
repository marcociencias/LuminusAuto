using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuminusAuto.page
{
	public class RegraDeDescontoPage
	{
		IWebDriver driver;

		public RegraDeDescontoPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public void Navegar(string url)
		{
			Thread.Sleep(3000);
			driver.Navigate().GoToUrl(url);
		}

		public void Criar()
		{
			Thread.Sleep(3000);
			driver.FindElement(By.CssSelector("button[funcionalidade='ProdutoEstadia.RegrasDesconto.Incluir']")).Click();
		}

		public void InformacoesGerais(string nome)
		{
			Thread.Sleep(2000);
			driver.FindElement(By.CssSelector("input[name='NomeRegraDesconto']")).SendKeys(nome);
		}

		public void FuncionamentoGeralDesconto(int desabilitaDesc, string valorMax, string maxPorPag, string limiteDesc, int truncar)
		{
			if (desabilitaDesc == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='DesabilitarTodosDescontos']")).Click();
			}

			driver.FindElement(By.CssSelector("input[formcontrolname='ValorMaximoDesconto']")).SendKeys(valorMax);
			driver.FindElement(By.CssSelector("input[formcontrolname='MaximoDescontosPorPagamento']")).SendKeys(maxPorPag);
			driver.FindElement(By.CssSelector("input[formcontrolname='LimiteDescontoAvancoParaEstadia']")).SendKeys(limiteDesc);


			if (truncar == 1)
			{
				driver.FindElement(By.CssSelector("input[name='truncarValorDesconto']")).Click();

			}

		}

		public void DescontoTecla(int descontoTecla, string periodoIni, string periodoFim)
		{
			if (descontoTecla == 1)
			{
				driver.FindElement(By.CssSelector("input[name='habilitarDescontoPorTecla']")).Click();
			}
			else
			{
				driver.FindElement(By.CssSelector("input[name='periodoValidadeDescontoInicio']")).Clear();
				driver.FindElement(By.CssSelector("input[name='periodoValidadeDescontoFim']")).Clear();
				driver.FindElement(By.CssSelector("input[name='periodoValidadeDescontoInicio']")).SendKeys(periodoIni);
				driver.FindElement(By.CssSelector("input[name='periodoValidadeDescontoFim']")).SendKeys(periodoFim);

			}
		}

		public void TeclaSelecionada(int teclaDesconto)
		{
			Thread.Sleep(500);
			driver.FindElements(By.CssSelector(".menu-popovertable"))[teclaDesconto].Click();
			driver.FindElements(By.CssSelector(".menu-popovertable"))[teclaDesconto].FindElement(By.LinkText("alterar")).Click();
		}
		public void alteraTeclaDesconto(int tipoDesconto , string valor , string percentual)
		{
			if (tipoDesconto == 0)
			{
				Thread.Sleep(200);
				driver.FindElements(By.CssSelector("option[value"))[10].Click();
				botaoAlterar();
			}
			if (tipoDesconto == 1)
			{
				Thread.Sleep(200);
				driver.FindElements(By.CssSelector("option[value"))[11].Click();
				Thread.Sleep(200);
				driver.FindElement(By.CssSelector("input[formcontrolname='Valor']")).SendKeys(valor);
				botaoAlterar();
			}

			if (tipoDesconto == 5)
			{
				Thread.Sleep(200);
				driver.FindElements(By.CssSelector("option[value"))[12].Click();
				Thread.Sleep(200);
				driver.FindElement(By.CssSelector("input[formcontrolname='Porcentagem']")).SendKeys(percentual);
				botaoAlterar();
			}
			if (tipoDesconto == 6)
			{
				Thread.Sleep(200);
				driver.FindElements(By.CssSelector("option[value"))[13].Click();
				driver.FindElement(By.CssSelector("select[formcontrolname='TabelaID']")).SendKeys(Keys.Down);
				driver.FindElement(By.CssSelector("select[formcontrolname='TabelaID']")).SendKeys(Keys.Enter);
				botaoAlterar();
			}
		}

		public void botaoAlterar()
		{
			driver.FindElements(By.CssSelector("button[type"))[8].Click();
		}

		public void DescontoSeloDesconto( int habilitar , string periodoIni , string periodoFim , int diasValidos )
		{
			if (habilitar == 1)
			{
				driver.FindElement(By.CssSelector("input[name='habilitarDescontoSelo']")).Click();
			}
			else
			{
				Thread.Sleep(500);
				driver.FindElement(By.CssSelector("input[name='periodoValidadeSeloInicio']")).Clear();
				driver.FindElement(By.CssSelector("input[name='periodoValidadeSeloFim']")).Clear();

				driver.FindElement(By.CssSelector("input[name='periodoValidadeSeloInicio']")).SendKeys(periodoIni);
				driver.FindElement(By.CssSelector("input[name='periodoValidadeSeloFim']")).SendKeys(periodoFim);
			}

			if (diasValidos == 7)
			{
				for (int i = 0; i < 2; i++)
				{
					driver.FindElements(By.CssSelector("li[title='Domingo']"))[0].Click();
					driver.FindElements(By.CssSelector("li[title='Segunda-feira']"))[0].Click();
					driver.FindElements(By.CssSelector("li[title='Terça-feira']"))[0].Click();
					driver.FindElements(By.CssSelector("li[title='Quarta-feira']"))[0].Click();
					driver.FindElements(By.CssSelector("li[title='Quinta-feira']"))[0].Click();
					driver.FindElements(By.CssSelector("li[title='Sexta-feira']"))[0].Click();
					driver.FindElements(By.CssSelector("li[title='Sábado']"))[0].Click();
				}
			}

		}



		public void DescontosSeloGenerico(int habilita, int tipoDesconto, string valor, string percentual)
		{
			if (habilita == 1)
			{
				driver.FindElement(By.CssSelector("input[name='habilitarDescontoSeloGenerico']")).Click();
			}
			if (tipoDesconto == 0)
			{
				Thread.Sleep(200);
				driver.FindElements(By.CssSelector("option[value"))[0].Click();

			}
			if (tipoDesconto == 1)
			{
				Thread.Sleep(200);
				driver.FindElements(By.CssSelector("option[value"))[1].Click();
				Thread.Sleep(200);
				driver.FindElement(By.CssSelector("input[formcontrolname='ValorDescontoGenericoValor']")).SendKeys(valor);
	
			}

			if (tipoDesconto == 5)
			{
				Thread.Sleep(200);
				driver.FindElements(By.CssSelector("option[value"))[2].Click();
				Thread.Sleep(200);
				driver.FindElement(By.CssSelector("input[formcontrolname='ValorDescontoGenericoPorcentagem']")).SendKeys(percentual);
				
			}
			if (tipoDesconto == 6)
			{
				Thread.Sleep(200);
				driver.FindElements(By.CssSelector("option[value"))[3].Click();
				driver.FindElement(By.CssSelector("select[formcontrolname='MudancaTabelaCobranca.Id']")).SendKeys(Keys.Down);
				driver.FindElement(By.CssSelector("select[formcontrolname='MudancaTabelaCobranca.Id']")).SendKeys(Keys.Enter);


			}
		}

		public void DescontoMudancaDeTabela(int habilitar)
		{
			if(habilitar == 1)
			{
				driver.FindElement(By.CssSelector("input[name='habilitarDescontoTabela']")).Click();
			}
			else
			{
				Thread.Sleep(500);
				driver.FindElement(By.CssSelector("button[type='button']")).Click();
				Thread.Sleep(500);
				driver.FindElement(By.CssSelector("select[formcontrolname='Id']")).Click();
				driver.FindElement(By.CssSelector("select[formcontrolname='Id']")).SendKeys(Keys.Down);
				driver.FindElement(By.CssSelector("select[formcontrolname='Id']")).SendKeys(Keys.Enter);
				driver.FindElements(By.CssSelector("button[type='submit']"))[1].Click();

			}

		}

		public void BotaoSalvar()
		{
			Thread.Sleep(500);
			driver.FindElements(By.CssSelector("button[type='submit']"))[0].Click();
		}

	}
}
