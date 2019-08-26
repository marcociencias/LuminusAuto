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
	public class RegraDeCobrancaPage
	{
		IWebDriver driver;

		public RegraDeCobrancaPage(IWebDriver driver)
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
			Thread.Sleep(4000);
			driver.FindElement(By.CssSelector("button[funcionalidade='ProdutoEstadia.RegrasCobranca.Incluir']")).Click();
		}

		public void InformacoesGerais(string nome)
		{
			Thread.Sleep(2000);
			driver.FindElement(By.CssSelector("input[formcontrolname='Nome']")).SendKeys(nome);
		}

		public void LimiteDeCobranca(string valorMaxDiario , string valorMaxEstadia , string valorMaxEstadiaSemVal , string nivelOperadorMin , string diasAntecedencia , int refHorarioEntrada , int usarValorMaxEstadia)
		{
			driver.FindElement(By.CssSelector("input[formcontrolname='ValorMaximoDiario']")).Clear();
			driver.FindElement(By.CssSelector("input[formcontrolname='ValorMaximoDiario']")).SendKeys(valorMaxDiario);

			driver.FindElement(By.CssSelector("input[formcontrolname='ValorMaximoEstadia']")).Clear();
			driver.FindElement(By.CssSelector("input[formcontrolname='ValorMaximoEstadia']")).SendKeys(valorMaxEstadia);

			driver.FindElement(By.CssSelector("input[formcontrolname='ValorMaximoEstadiaSemAprovacao']")).Clear();
			driver.FindElement(By.CssSelector("input[formcontrolname='ValorMaximoEstadiaSemAprovacao']")).SendKeys(valorMaxEstadiaSemVal);

			driver.FindElement(By.CssSelector("input[formcontrolname='NivelOperadorMinimoParaAprovacao']")).Clear();
			driver.FindElement(By.CssSelector("input[formcontrolname='NivelOperadorMinimoParaAprovacao']")).SendKeys(nivelOperadorMin);

			driver.FindElement(By.CssSelector("input[formcontrolname='QuantidadeDiasAntecedenciaPermitidaParaRevalidacaoCredenciados']")).Clear();
			driver.FindElement(By.CssSelector("input[formcontrolname='QuantidadeDiasAntecedenciaPermitidaParaRevalidacaoCredenciados']")).SendKeys(diasAntecedencia);

			if(refHorarioEntrada == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='ValorMaximoDiarioReferenteAoHorarioEntrada']")).Click();
			}
			if (usarValorMaxEstadia == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='UsarValorMaximoEstadiaAposMudancaDeDia']")).Click();
			}

		}

		public void ConfiguracaoDeCalculo(int manter ,string proxFracao , int metodoCalculo , int metodoCalcParaPag , int usarValoresEntrada)
		{
			if (manter == 1)
			{
				driver.FindElements(By.CssSelector(".checkbox"))[1].Click();
			}
			else
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='ProximaFracaoPeriodoAposMudancaEstrutura']")).SendKeys(proxFracao);
			}
			if(metodoCalculo == 0)
			{
				driver.FindElements(By.CssSelector("option[value='0']"))[0].Click();
			}
			if(metodoCalculo == 1)
			{
				driver.FindElements(By.CssSelector("option[value='1']"))[0].Click();
			}
			if(metodoCalculo == 2)
			{
				driver.FindElements(By.CssSelector("option[value='2']"))[0].Click();
			}

			if(metodoCalcParaPag == 1)
			{
				driver.FindElements(By.CssSelector("option[value='1']"))[1].Click();
			}
			if(metodoCalcParaPag == 2)
			{
				driver.FindElements(By.CssSelector("option[value='2']"))[1].Click();
			}
			if(usarValoresEntrada == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='CobrarUsandoApenasValoresPeriodoDaEntrada']")).Click();
			}

		}

		public void ConfiguracaoDeCalculoInterromper( int mudancaPeriodo , int mudancaDia , int mudancaEstrutura)
		{
			if (mudancaPeriodo == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='InterromperFracaoDoPeriodoNaMudancaPerido']")).Click();
			}

			if(mudancaDia ==1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='InterromperFracaoDoPeriodoNaMudancaDia']")).Click();
			}

			if(mudancaEstrutura == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='InterromperFracaoDoPeriodoNaMudancaEstrutura']")).Click();
			}
			
		}

		public void ConfiguracaoDeCalculoHabilitar(int OpRecargaManPPago , int PagAvulsoCPPago , int TransfAvulsoPPago)
		{
			if (OpRecargaManPPago == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='HabilitarOpcaoRecargaManualPrePago']")).Click();
			}

			if (PagAvulsoCPPago == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='HabilitarPagamentoAvulsoComCartaoPrePago']")).Click();
			}

			if (TransfAvulsoPPago == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='HabilitarTransferenciaAvulsoParaPrePago']")).Click();
			}
		}

		public void ConfiguracaoDeCalculoPermitir(int teclaUP, int OpAlterarCampos, int teclaDN)
		{
			if (teclaUP == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='PermitirPagarFracaoFuturo']")).Click();
			}

			if (OpAlterarCampos == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='PermitirOperadorAlterarCamposRecarga']")).Click();
			}

			if (teclaDN == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='PermitirRetrocessoEstadiaNaValidacao']")).Click();
			}
		}

		public void ConfiguracaoDeCalculoCobranca( int bloquearTransAvulso , string valorBloqTransAvulso ,string tempoAdicional ,
													string opMinimoExtensao , int otimizacaoCobranca , int revalidacao , int estadiaBloq , int credVencido)
		{
			if(bloquearTransAvulso == 1)
			{
				driver.FindElements(By.CssSelector(".checkbox"))[2].Click();
			}
			else
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='LimiteDeTempoDeEstadiaParaTransferenciaDeAvulsos']")).SendKeys(valorBloqTransAvulso);
			}

			driver.FindElement(By.CssSelector("input[formcontrolname='TempoAdicionalAntesMudancaFracaoPeriodo']")).SendKeys(tempoAdicional);

			driver.FindElement(By.CssSelector("input[formcontrolname='NivelOperadorMinimoParaEditarExtensaoValidade']")).SendKeys(opMinimoExtensao);

			if (otimizacaoCobranca == 0)
			{
				driver.FindElements(By.CssSelector("option[value='0']"))[1].Click();
			}
			if (otimizacaoCobranca == 1)
			{          
				driver.FindElements(By.CssSelector("option[value='1']"))[2].Click();
			}
			if (otimizacaoCobranca == 2)
			{
				driver.FindElements(By.CssSelector("option[value='2']"))[2].Click();
			}
			if (revalidacao == 0)
			{ 
			driver.FindElements(By.CssSelector("option[value='0']"))[2].Click();
			}
			if (revalidacao == 1)
			{
				driver.FindElements(By.CssSelector("option[value='1']"))[3].Click();
			}
			if (revalidacao == 2)
			{
				driver.FindElements(By.CssSelector("option[value='2']"))[3].Click();
			}
			if (revalidacao == 3)
			{
				driver.FindElements(By.CssSelector("option[value='3']"))[0].Click();
			}
			if (estadiaBloq == 1)
			{
				driver.FindElements(By.CssSelector("option[value='1']"))[4].Click();
			}
			if (estadiaBloq == 2)
			{
				driver.FindElements(By.CssSelector("option[value='2']"))[3].Click();
			}
			if (estadiaBloq == 3)
			{
				driver.FindElements(By.CssSelector("option[value='3']"))[1].Click();
			}

			if(credVencido == 0)
			{
				driver.FindElements(By.CssSelector("option[value='0']"))[3].Click();
			}
			if(credVencido == 1)
			{
				driver.FindElements(By.CssSelector("option[value='1']"))[5].Click();
			}

			driver.FindElements(By.CssSelector("option"))[16].Click();
		}

		public void ConfiguracaoDeCalculoEntradasOffLine(string entradaDias, string entradaHoras , string entradaMinutos)
		{
			driver.FindElement(By.CssSelector("input[formcontrolname='QuantidadeTempoSupostaDaEntradaDias']")).SendKeys(entradaDias);
			driver.FindElement(By.CssSelector("input[formcontrolname='QuantidadeTempoSupostaDaEntradaHoras']")).SendKeys(entradaHoras);
			driver.FindElement(By.CssSelector("input[formcontrolname='QuantidadeTempoSupostaDaEntradaMinutos']")).SendKeys(entradaMinutos);
		}

		public void FormaDePagamento(int forma)
		{
			if(forma == 1)
			{
				driver.FindElements(By.CssSelector("option[value='1']"))[6].Click();	
			}
			if (forma == 2)
			{
				driver.FindElements(By.CssSelector("option[value='2']"))[5].Click();	
			}
			if (forma == 3)
			{
				driver.FindElements(By.CssSelector("option[value='3']"))[2].Click();
			}
		}

		public void TabelaDeCobranca(int inibeTabAvulso , int inibeTabPPago , int naoSeAplica )
		{

			if(inibeTabAvulso == 1)
			{
				driver.FindElements(By.CssSelector("button[title='Mover todos']"))[0].Click();

			}

			if(inibeTabPPago == 1)
			{
				driver.FindElements(By.CssSelector("button[title='Mover todos']"))[1].Click();
			}

			if (naoSeAplica == 1)
			{
				driver.FindElement(By.CssSelector("input[id='naoSeAplica']")).Click();
				driver.FindElements(By.CssSelector("button[title='Mover todos']"))[2].Click();
			}
			
		}

		public void Salvar()
		{
			// Clica no botão salvar
			IWebElement salvar = driver.FindElement(By.CssSelector("button[type='submit']"));
			salvar.Click();
		}
	}
}
