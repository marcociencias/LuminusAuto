using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace LuminusAuto.page
{

	
	public class RegraDeAcessoPage
	{
		IWebDriver driver;

		public RegraDeAcessoPage(IWebDriver driver)
		{
			this.driver = driver;
		}


		public void Navegar(string url)
		{
			driver.Manage().Timeouts();
			Thread.Sleep(5000);
			driver.Navigate().GoToUrl(url);
		}

		/*
		 * Until((driver) =>
			{
				try
				{
					var element = driver.FindElement(By.CssSelector(".np-loader-full--component"));
					return !element.Displayed;
				}
				catch (NoSuchElementException)
				{
					// Returns true because the element is not present in DOM. The
					// try block checks if the element is present but is invisible.
					return true;
				}
				catch (StaleElementReferenceException)
				{
					// Returns true because stale element reference implies that element
					// is no longer visible.
					return true;
				}
			});
		 * */


		public void Criar()
		{

			driver.Manage().Timeouts();
			Thread.Sleep(15000);
			driver.FindElement(By.CssSelector("button[funcionalidade='ProdutoEstadia.RegrasAcesso.Incluir'")).Click();

		}

		public void InformacoesGerais(string nome, string equip)
		{
			// CONFIGURAÇÃO DE INFORMAÇÕES GERAIS DA REGRA DE ACESSO
			driver.Manage().Timeouts().ImplicitWait = Timeout.InfiniteTimeSpan;
			Thread.Sleep(5000);
			driver.FindElement(By.CssSelector("input[formcontrolname='Nome']")).SendKeys(nome);
			IWebElement tipoOperacaoDeEquipamento =	driver.FindElement(By.CssSelector("select[formcontrolname='IndexFuncaoOperacao']"));
			SelectElement select = new SelectElement(tipoOperacaoDeEquipamento);
			select.SelectByText("1 - Entrada");
			////EQUIPAMENTO ENTRADA
			//if (select == "")0
			//{
			//	driver.FindElements(By.CssSelector("option[value"))[0].Click();
			//}
			////EQUIPAMENTO PASSAGEM
			//if (equip == 2)
			//{
			//	driver.FindElements(By.CssSelector("option[value"))[1].Click();
			//}
			////EQUIPAMENTO SAÍDA
			//if (equip == 4)
			//{
			//	driver.FindElement(By.CssSelector("select[formcontrolname='IndexFuncaoOperacao']"));
			//	var select = new SelectElement()
			//	driver.FindElements(By.CssSelector("option[value"))[2].Click();
			//}

		}

		public void InformacoesDeAcesso(string periodoIni, string periodoFim)
		{
			// CONFIGURAÇÃO DE INFORMAÇÕES GERAIS DE ACESSO


			driver.FindElement(By.CssSelector(".form-group li[title='Domingo']")).Click();
			driver.FindElement(By.CssSelector(".form-group li[title='Segunda-feira']")).Click();
			driver.FindElement(By.CssSelector(".form-group li[title='Terça-feira']")).Click();
			driver.FindElement(By.CssSelector(".form-group li[title='Quarta-feira']")).Click();
			driver.FindElement(By.CssSelector(".form-group li[title='Quinta-feira']")).Click();
			driver.FindElement(By.CssSelector(".form-group li[title='Sexta-feira']")).Click();
			driver.FindElement(By.CssSelector(".form-group li[title='Sábado']")).Click();
			//PERIODO INICIO E FIM
			driver.FindElement(By.CssSelector("input[formcontrolname='PeriodoValidoInicial']")).SendKeys(periodoIni);
			driver.FindElement(By.CssSelector("input[formcontrolname='PeriodoValidoFinal']")).SendKeys(periodoFim);

		}

		public void BolsaoVagasPrecValidos(int precedentesValidos, int veiculoPermitido, int cartaoVencido, int tempoInf, string tempoCartaoVenc, string tempoDesisEnt)
		{
			//CONFIGURAÇÃO DE BOLSÃO PRECEDENTES VÁLIDOS
			if (precedentesValidos == 1)
			{
				driver.FindElement(By.CssSelector("input[name='naoSeAplica'")).Click();
				driver.FindElements(By.CssSelector(".btn"))[0].Click();
			}

			// CONFIGURAÇÃO DE VEICULOS PERMITIDOS 
			if (veiculoPermitido == 1)
			{    // selecionar carro
				driver.FindElements(By.CssSelector(".form-control option[value='1']"))[1].Click();
			}
			if (veiculoPermitido == 2)
			{   //selecionar moto
				driver.FindElements(By.CssSelector(".form-control option[value='2']"))[1].Click();
			}
			if (veiculoPermitido == 3)
			{ //selecionar ambos
				driver.FindElements(By.CssSelector(".form-control option[value='3']"))[0].Click();
			}
			// CONFIGURAÇÃO DE CARTÃO VENCIDO
			if (cartaoVencido == 1)
			{ // Cartão vencido recolher
				driver.FindElements(By.CssSelector(".form-control option[value='1']"))[2].Click();
			}
			if (cartaoVencido == 2)
			{ // Cartão vencido bloquear
				driver.FindElements(By.CssSelector(".form-control option[value='2']"))[2].Click();
			}
			// Configuração de Tolerância de Vencidos e Desistência entrada
			if (tempoInf == 1)
			{
				driver.FindElement(By.CssSelector("input[id='infinitoDesistenciaEntrada']")).Click();
			}
			else
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='ToleranciaEmDiasCartoesVencidos']")).SendKeys(tempoCartaoVenc);
				driver.FindElement(By.CssSelector("input[formcontrolname='TempoDesistenciaEntrada']")).SendKeys(tempoDesisEnt);
			}

		}

		public void ConfigRegraDeAcesso(int fantasma, int cartaoInconsistente, int validaEstadiaEnt, int impRemotaPermite, int prePagoSaldoNeg)
		{
			if (fantasma == 1)
			{ // Ativa CheckBox cartão fantasma
				driver.FindElement(By.CssSelector("input[formcontrolname='TratarCartoesFantasma']")).Click();
			}
			if (cartaoInconsistente == 1)
			{ // Ativa CheckBox cartão inconsistente
				driver.FindElement(By.CssSelector("input[formcontrolname='RejeitarCartoesInconsistentes']")).Click();
			}
			if (validaEstadiaEnt == 1)
			{ // Ativa CheckBox Realizar validação da estadia na Entrada
				driver.FindElement(By.CssSelector("input[formcontrolname='RealizarValidacaoEstadiaEntrada']")).Click();
			}
			if (impRemotaPermite == 1)
			{ // Ativa CheckBox Permitir emissão de recibo em impressora remota
				driver.FindElement(By.CssSelector("input[formcontrolname='PermitirEmissaoReciboImpressoraRemota']")).Click();
			}
			if (prePagoSaldoNeg == 1)
			{ // Opção recolhe para pré pago
				driver.FindElements(By.CssSelector("option[value='1']"))[3].Click();
			}
			if (prePagoSaldoNeg == 2)
			{ // Opção Devolve para pré pago
				driver.FindElements(By.CssSelector("option[value='2']"))[3].Click();
			}


		}

		public void TempoDeTransito(int tempoTransitoInf, string valorTempoTrans, int transPartir, int tempoExc)
		{
			if (tempoTransitoInf == 1)
			{   //Ativa CheckBox Infinito
				driver.FindElement(By.CssSelector("input[id='infinitoTransitoEntreEquipamentos']")).Click();

			}
			else
			{   //Insere valor do tempo de transito
				driver.FindElement(By.CssSelector("input[formcontrolname='TempoTransitoEntreEquipamentos']")).SendKeys(valorTempoTrans);
			}

			if (transPartir == 1)
			{   //Tempo de trânsito a partir da ultima passagem
				driver.FindElements(By.CssSelector(".form-control option[value"))[12].Click();
			}
			if (transPartir == 2)
			{   //Tempo de trânsito a partir da entrada
				driver.FindElements(By.CssSelector(".form-control option[value"))[13].Click();
			}
			if (tempoExc == 1)
			{   //Mudar a tabela de cobrança
				driver.FindElements(By.CssSelector(".form-control option[value"))[14].Click();
			}
			if (tempoExc == 2)
			{   //Bloquear
				driver.FindElements(By.CssSelector(".form-control option[value"))[15].Click();
			}
		}

		public void AcessoAssistido(int considerarVeic, int habilitar, int exibir, int utilizar)
		{
			if (considerarVeic == 0)
			{   // Acesso assistido 0 - Sem Diferenciação
				driver.FindElements(By.CssSelector(".form-control option[value"))[16].Click();
			}
			if (considerarVeic == 1)
			{   // Acesso assistido 1 - Moto
				driver.FindElements(By.CssSelector(".form-control option[value"))[17].Click();
			}
			if (considerarVeic == 2)
			{   // Acesso assistido 2 - Carro
				driver.FindElements(By.CssSelector(".form-control option[value"))[18].Click();
			}
			if (considerarVeic == 3)
			{   // Acesso assistido 3 - Escolher
				driver.FindElements(By.CssSelector(".form-control option[value"))[19].Click();
			}
			if (habilitar == 1)
			{   // Ativa CheckBox Habilitar numero do prisma igual ao ticket de entrada
				driver.FindElement(By.CssSelector("input[formcontrolname='HabilitarPrismaIgualTicketEntrada']")).Click();
			}
			if (exibir == 1)
			{   // Ativa CheckBox Exibir informação de lotada no display secundário
				driver.FindElement(By.CssSelector("input[formcontrolname='ExibirInformacaoLotadoDisplaySecundario']")).Click();
			}
			if (utilizar == 1)
			{   // Ativa CheckBox utiliar lista de veículos com modelo e marca
				driver.FindElement(By.CssSelector("input[formcontrolname='UtilizarListaVeiculosModeloMarca']")).Click();
			}

		}

		public void AcessoAssistidoPermitir(int ticketAvulsoEntrada, int validacaoEstadiaEntrada, int impressaoRemota)
		{
			if (ticketAvulsoEntrada == 1)
			{   // Ativa CheckBox Permitir geração de ticket na entrada
				driver.FindElement(By.CssSelector("input[formcontrolname='PermitirTicketAvulsoEntrada']")).Click();
			}
			if (validacaoEstadiaEntrada == 1)
			{   // Ativa CheckBox Permitir validação de estadia na entrada
				driver.FindElement(By.CssSelector("input[formcontrolname='HabilitarValidacaoEstadiaEntrada']")).Click();
			}
			if (impressaoRemota == 1)
			{   // Ativa CheckBox  Permitir impressão remota de informativo para chamada de veículo sem realizar saída
				driver.FindElement(By.CssSelector("input[formcontrolname='PermitirImpressaoRemotaInformativoParaChamadaVeiculoSemRealizarSaida']")).Click();
			}

		}

		public void AcessoAssistidoInformar(int prismaEntrada, int placaEntrada, int localizacaoEntrada)
		{
			if (prismaEntrada == 1)
			{   // Ativa CheckBox informar prisma em operação de entrada
				driver.FindElement(By.CssSelector("input[formcontrolname='DigitarPrismaEntrada']")).Click();
			}
			if (placaEntrada == 1)
			{   // Ativa CheckBox informar placa em operação de entrada
				driver.FindElement(By.CssSelector("input[formcontrolname='DigitarPlacaEntrada']")).Click();
			}
			if (localizacaoEntrada == 1)
			{   // Ativa CheckBox Informar localização do veículo em operação de entrada
				driver.FindElement(By.CssSelector("input[formcontrolname='InformarLocalizacaoNaEntrada']")).Click();
			}
		}

		public void AcessoAssistidoReimprimir(int codBarraEntradaInfoCred, int codBarraChamadaCred)
		{
			if (codBarraEntradaInfoCred == 1)
			{   // Ativa CheckBox Reimprimir código de barras no informe de entrada de credenciado
				driver.FindElement(By.CssSelector("input[formcontrolname='ReimprimirCodigoBarrasTicketEntradaCredenciado']")).Click();
			}
			if (codBarraChamadaCred == 1)
			{   // Ativa CheckBox Reimprimir código de barras na chamada de veículo(impressora remota) para credenciado
				driver.FindElement(By.CssSelector("input[formcontrolname='ReimprimirCodigoBarrasTicketDevolucaoCredenciado']")).Click();
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
