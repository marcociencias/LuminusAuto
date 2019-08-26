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
	
	public class ProdutoEstadiaPage
	{
		IWebDriver driver;

		public ProdutoEstadiaPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public void Navegar(string url)
		{
			driver.Manage().Timeouts();
			driver.Navigate().GoToUrl(url);
			Thread.Sleep(2000);
		}

		public void Criar(string nome , int tipoUsuario)
		{
			Thread.Sleep(3000);
			driver.FindElement(By.CssSelector("button[funcionalidade='ProdutoEstadia.ProdutoEstadia.Incluir'")).Click();
			driver.Manage().Timeouts();
			driver.FindElement(By.CssSelector("input[formcontrolname='Nome'")).SendKeys(nome);
			
			switch(tipoUsuario)
			{
				case 1:
					driver.FindElement(By.CssSelector("option[value='Avulso'")).Click();
					break;
				case 2:
					driver.FindElement(By.CssSelector("option[value='Credenciado'")).Click();
					break;
				case 3:
					driver.FindElement(By.CssSelector("option[value='PrePago'")).Click();
					break;
				case 4:
					driver.FindElement(By.CssSelector("option[value='PosPago'")).Click();
					break;
			}

		}

		public void ConfiguracaoCredenciado(string grupo , int tipoRevalidacao )
		{
			driver.FindElement(By.CssSelector("input[formcontrolname='CodigoGrupo'")).SendKeys(grupo);

			switch (tipoRevalidacao)
			{
				case 1:
					driver.FindElement(By.CssSelector("option[value='QuantidadeDias'")).Click();
					BotaoAdicionar();
					break;
				case 2:
					driver.FindElement(By.CssSelector("option[value='DiaMes'")).Click();		
					BotaoAdicionar();
					break;
				case 3:
					driver.FindElement(By.CssSelector("option[value='Diarista'")).Click();
					break;
			}

		}
		
		public void BotaoAdicionar()
		{
			Thread.Sleep(1000);
			driver.FindElements(By.CssSelector("button[type='button'"))[0].Click();
		}

		public void ConfiguracaoRevalidacaoQuantDias(string quantDias , string valor)
		{
			Thread.Sleep(2000);
			driver.FindElement(By.CssSelector("input[formcontrolname='QtdeDias'")).SendKeys(quantDias);
			driver.FindElement(By.CssSelector("input[formcontrolname='Valor'")).SendKeys(valor);
			driver.FindElements(By.CssSelector("button[type=submit"))[1].Click();
		}
		public void ConfiguracaoRevalidacaoDiaMes(string diaDoMes , string valor , string repeticao)
		{
			Thread.Sleep(1000);
			driver.FindElement(By.CssSelector("input[formcontrolname='DiaMes'")).SendKeys(diaDoMes);
			driver.FindElement(By.CssSelector("input[formcontrolname='Valor'")).SendKeys(valor);
			driver.FindElement(By.CssSelector("input[formcontrolname='Repeticao'")).SendKeys(repeticao);
			driver.FindElements(By.CssSelector("button[type=submit"))[1].Click();
		}

		public void Diarista(string valor , string quantMaxDiario, int indiceTabela , int permiteVendaPrevDiaria , string nivelMiminoReimpressao)
		{
			Thread.Sleep(1000);
			driver.FindElement(By.CssSelector("input[formcontrolname='Valor'")).SendKeys(valor);
			driver.FindElement(By.CssSelector("input[formcontrolname='QuantidadeMaximaDiarias'")).SendKeys(quantMaxDiario);
			driver.FindElements(By.CssSelector("option[value"))[6+indiceTabela].Click();

			if (permiteVendaPrevDiaria == 2)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='PermitirVendaPrevia'")).Click();
			}

			driver.FindElement(By.CssSelector("input[formcontrolname='NivelMinimoOperadorReImpressaoTicket'")).SendKeys(nivelMiminoReimpressao);

		}

		public void BotaoSalvar()
		{
			Thread.Sleep(1000);
			driver.FindElement(By.CssSelector("button[type='submit'")).Click();
		}

		public void ConfigurarBolsaoDeVagas()
		{
			Thread.Sleep(1000);
			driver.FindElements(By.CssSelector("div[class=\"menu-popovertable\"]"))[0].Click();
			driver.FindElements(By.CssSelector(".menu-popovertable ul a"))[0].Click();
		}

		public void ConfiguracaoPrePago(string grupo,string valorDeRecarga , string valorDoPagamento, string quantDiasExtensao)
		{
			driver.FindElement(By.CssSelector("input[formcontrolname='CodigoGrupo'")).Click();
			driver.FindElement(By.CssSelector("input[formcontrolname='CodigoGrupo'")).Clear();
			driver.FindElement(By.CssSelector("input[formcontrolname='CodigoGrupo'")).SendKeys(grupo);
			Thread.Sleep(1000);
			BotaoAdicionar();
			driver.FindElement(By.CssSelector("input[formcontrolname='ValorRecarga']")).SendKeys(valorDeRecarga);
			driver.FindElement(By.CssSelector("input[formcontrolname='ValorPagamento']")).SendKeys(valorDoPagamento);
			driver.FindElement(By.CssSelector("input[formcontrolname='QtdeDiasExtensaoValidade']")).SendKeys(quantDiasExtensao);
			driver.FindElements(By.CssSelector("button[type=submit"))[1].Click();

		}

		public void ConfiguracaoPrePagoSaldos(string quantValidadeInicial , string saldoMin , string saldoMax , string saldoNeg , string valorMaxD )
		{
			Thread.Sleep(1000);
			driver.FindElement(By.CssSelector("input[formcontrolname='QtdeDiasValidadeInicial'")).SendKeys(quantValidadeInicial);
			driver.FindElement(By.CssSelector("input[formcontrolname='SaldoMinimo'")).SendKeys(saldoMin);
			driver.FindElement(By.CssSelector("input[formcontrolname='SaldoMaximo'")).SendKeys(saldoMax);
			driver.FindElement(By.CssSelector("input[formcontrolname='SaldoNegativoLimite'")).SendKeys(saldoNeg);
			driver.FindElement(By.CssSelector("input[formcontrolname='ValorMaximoDiario'")).SendKeys(valorMaxD);

		}
		
		public void ConfiguracaoPrePagoUtilizacao(string quantiUtiDia, string tempoMinUti, string tempoMaxUti, string quantValMan)
		{
			Thread.Sleep(1000);
			driver.FindElement(By.CssSelector("input[formcontrolname='QdeUtilizacoesDiaria'")).Click();
			driver.FindElement(By.CssSelector("input[formcontrolname='QdeUtilizacoesDiaria'")).Clear();
			driver.FindElement(By.CssSelector("input[formcontrolname='QdeUtilizacoesDiaria'")).SendKeys(quantiUtiDia);
			driver.FindElement(By.CssSelector("input[formcontrolname='TempoMinimoUtilizacao'")).SendKeys(tempoMinUti);
			driver.FindElement(By.CssSelector("input[formcontrolname='TempoMaximoUtilizacao'")).SendKeys(tempoMaxUti);
			driver.FindElement(By.CssSelector("input[formcontrolname='QtdeDiasSugeridosExtensaoValidade'")).SendKeys(quantValMan);
			
		}

		public void ConfiguracaoPrePagoRecarga(int sugerirRecargaMax , int recargaAtingirSaldoMax , int habilitaBonus , int tipoBonus)
		{
			if(sugerirRecargaMax == 1)
			{
				Thread.Sleep(1000);
				driver.FindElements(By.CssSelector("input[type=checkbox"))[1].Click();
			}
			if(sugerirRecargaMax == 1)
			{
				Thread.Sleep(1000);
				driver.FindElements(By.CssSelector("input[type=checkbox"))[2].Click();
			}
			if(habilitaBonus == 1)
			{
				Thread.Sleep(1000);
				driver.FindElements(By.CssSelector("input[type=checkbox"))[3].Click();
				if(tipoBonus == 0)
				driver.FindElements(By.CssSelector("option[value"))[4].Click();

				if(tipoBonus == 1)
				driver.FindElements(By.CssSelector("option[value"))[5].Click();

				if(tipoBonus == 2)
				driver.FindElements(By.CssSelector("option[value"))[6].Click();

				driver.FindElement(By.CssSelector("input[formcontrolname='TempoBonusMaximo'")).SendKeys("10");

			}
		}
	}
}
