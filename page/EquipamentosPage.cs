using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;

namespace LuminusAuto.page
	/*Faltando implementar 
	* Funções com equipamento saida passagem validação
	* operacao de acesso , valores de periodo de funcionamento
	* implementar a checkbox possui escape/gate mode e as abas abaixo
	* tipo periférico 0 - leitor mifare Modela 0 - mifare implementado 
	*/
{
	public class EquipamentosPage
	{
		IWebDriver driver;

		public EquipamentosPage (IWebDriver driver)
		{
			this.driver = driver;
			driver.Manage().Window.Maximize();
		}


		public void Navegar(string url)
		{
			Thread.Sleep(2000);
			driver.Navigate().GoToUrl(url);
			driver.Manage().Timeouts();
		}

		public void Criar(int aviso ,int conectado , int semLimite, string transOffLine , string numEquip , string nomeEquip , string enderecoIpEquip , string mascaraIpEquip , string ipGatewayEquip , string numeroSetorSpn)
		{
			Thread.Sleep(4000);

			if (aviso == 1 )
			{
				driver.Manage().Timeouts();
				driver.FindElement(By.CssSelector(".close[type='button']")).Click();

			}
			
			driver.FindElements(By.CssSelector("button[type=button]"))[3].Click();
			IWebElement numeroDoEquipamento = driver.FindElement(By.CssSelector("input[formcontrolname=Numero"));
			IWebElement nome = driver.FindElement(By.CssSelector("input[formcontrolname=Nome"));
			IWebElement enderecoIp = driver.FindElement(By.CssSelector("input[formcontrolname=EnderecoIP"));
			IWebElement mascaraIp = driver.FindElement(By.CssSelector("input[formcontrolname=MascaraIP"));
			IWebElement ipDoGateway = driver.FindElement(By.CssSelector("input[formcontrolname=IPGateway]"));
			IWebElement limiteDeTransacoesOff = driver.FindElement(By.CssSelector("input[formcontrolname=LimiteTransacoesOffLine"));
			IWebElement numeroSetorSpacenet = driver.FindElement(By.CssSelector("input[formcontrolname=NumeroSetorSpacenet"));
			
			driver.Manage().Timeouts();
			numeroDoEquipamento.SendKeys(numEquip);
			nome.SendKeys(nomeEquip);
			enderecoIp.SendKeys(enderecoIpEquip);
			mascaraIp.SendKeys(mascaraIpEquip);
			ipDoGateway.SendKeys(ipGatewayEquip);
			numeroSetorSpacenet.SendKeys(numeroSetorSpn);

			Thread.Sleep(2000);
			if (conectado == 1)
			{
				driver.Manage().Timeouts();
				driver.FindElement(By.Id("conectado")).Click();
			}
			else
			{
				limiteDeTransacoesOff.Clear();
				limiteDeTransacoesOff.SendKeys(transOffLine);
			}

			if(semLimite == 1)
			{
				driver.Manage().Timeouts();
				driver.FindElement(By.Id("semLimite")).Click();
			}


			(driver.FindElements(By.CssSelector("select[formcontrolname='Aplicativo.Id']"))[0] as IWebElement).Click();
		}

		
		public void AplicativoEntrada()
		{
			Thread.Sleep(500);
			IWebElement aplicativoEntrada = driver.FindElement(By.CssSelector("option"));
			Thread.Sleep(500);
			driver.FindElement(By.Id("aplicativoEntrada")).Click();
		}
		public void AutoAtendimento()
		{
			Thread.Sleep(500);
			driver.FindElements(By.CssSelector("option"))[2].Click();
			Thread.Sleep(500);
			driver.FindElement(By.Id("aplicativoValidacao")).Click();
		}
		public void AplicativoSaida()
		{
			Thread.Sleep(500);
			driver.FindElements(By.CssSelector("option"))[1].Click();
			Thread.Sleep(500);
			driver.FindElement(By.Id("aplicativoSaida")).Click();
		}
		public void AplicativoValidacao()
		{
			Thread.Sleep(500);
			driver.FindElements(By.CssSelector("option"))[3].Click();
			Thread.Sleep(500);
			driver.FindElement(By.Id("aplicativoValidacao")).Click();
		}
		
		public void OperacaoDeAcesso(int semPeriodo ,int detectaMoto , int tagNepos , int possuiEscape)
		{
			if(semPeriodo == 1)
			{
				driver.FindElement(By.Id("semPeriodoDefinido")).Click();
			}
			else
			{
				IWebElement inicio = driver.FindElement(By.CssSelector("input[formcontrolname='OperacaoAcesso.PeriodoFuncionamentoDe']"));
				IWebElement fim = driver.FindElement(By.CssSelector("input[formcontrolname='OperacaoAcesso.PeriodoFuncionamentoAte']"));

				inicio.Clear();
				inicio.Click();
				inicio.SendKeys("06:00");
				fim.Clear();
				fim.Click();
				fim.SendKeys("23:59");

			}
			if(detectaMoto == 1)
			{
				driver.FindElement(By.Id("deteccaoMoto")).Click();
			}
			if(tagNepos == 1)
			{
				driver.FindElement(By.Id("somenteTagNepos")).Click();
			}
			if(possuiEscape == 1)
			{
				driver.FindElement(By.Id("possuiEscpaGateMode")).Click();
			}
			
		}

		public void AcessoBolsaoPrincipal()
		{
			driver.Manage().Timeouts();
			driver.FindElements(By.CssSelector("select[formcontrolname"))[4].Click();
			driver.FindElements(By.CssSelector("option[value"))[15].Click();

		}



		public void ConfiguracaoCancelaEntrada(int possuiCancela,int autoParada, int novaTransacaoSobreLaco , int novaTransacaoAposFechamento , int existeLacoAcionamento , int existeLacoFechamento , string tempoLimite)
		{
			driver.Manage().Timeouts();

			if (possuiCancela == 1)
			{
				driver.FindElement(By.Id("possuiCancelaEntrada")).Click();
			}
			if (autoParada == 1)
			{
				driver.FindElement(By.Id("autoParadaEntrada")).Click();
			}
			if (novaTransacaoSobreLaco == 1)
			{
				driver.FindElement(By.Id("iniciaNovaTransacaoVeiculoSobreLacoFechamentoEntrada")).Click();
			}
			if (novaTransacaoAposFechamento ==1)
			{
				driver.FindElement(By.Id("iniciaNovaTRansacaoAposFechamentoTotalCancelaEntrada")).Click();
			}
			if (existeLacoAcionamento == 1)
			{
				driver.FindElement(By.Id("existeLacoAcionamentoEquipamentoEntrada")).Click();
			}
			if (existeLacoFechamento == 1)
			{
				driver.FindElement(By.Id("existeLacoFechamentoCancelaEntrada")).Click();
			}

			driver.Manage().Timeouts();
			driver.FindElement(By.CssSelector("input[FormControlName='ConfiguracaoCancelaEntrada.TempoLimiteParaRespostaCancelaSeg']")).Click();
			driver.FindElement(By.CssSelector("input[FormControlName='ConfiguracaoCancelaEntrada.TempoLimiteParaRespostaCancelaSeg']")).Clear();
			driver.FindElement(By.CssSelector("input[FormControlName='ConfiguracaoCancelaEntrada.TempoLimiteParaRespostaCancelaSeg']")).Click();
			IWebElement tempoLimiteResposta = driver.FindElement(By.CssSelector("input[FormControlName='ConfiguracaoCancelaEntrada.TempoLimiteParaRespostaCancelaSeg']"));
			tempoLimiteResposta.SendKeys(tempoLimite);
		}

		public void AdicionarPeriferico()
		{
			Thread.Sleep(1000);
			driver.FindElement(By.CssSelector("button[type=button")).Click();
			Thread.Sleep(2000);
		}

		public void ConfiguracaoDeSuporte(int mostrarDetalhesDeEspera , int alternarEntrarMensagem , string tempoDetalheErro , string tempoDetalheEspera)
		{
			Thread.Sleep(1000);
			if(mostrarDetalhesDeEspera == 1)
			{
				driver.FindElement(By.Id("mostrarDetalhesEsperaAposTeclaAcionada")).Click();
			}
			if(alternarEntrarMensagem == 1)
			{
				driver.FindElement(By.Id("alternarEntreMensagensDetalhesEspera")).Click();
			}

			IWebElement tempoDetalhesErro = driver.FindElement(By.CssSelector("input[formcontrolname=TempoParaMostrarDetalhesErro"));
			IWebElement tempoDetalhesEspera = driver.FindElement(By.CssSelector("input[formcontrolname=TempoParaMostrarDetalhesEspera"));
			Thread.Sleep(1000);
			tempoDetalhesErro.Click();
			tempoDetalhesErro.Clear();
			tempoDetalhesErro.Click();
			tempoDetalhesErro.SendKeys(tempoDetalheErro);
			tempoDetalhesEspera.Click();
			tempoDetalhesEspera.Clear();
			tempoDetalhesEspera.Click();
			tempoDetalhesEspera.SendKeys(tempoDetalheEspera);

		}

		public void ModosDeAcionamento(int modoDeAcionamento)
		{
			driver.Manage().Timeouts();
			driver.FindElement(By.CssSelector("select[formcontrolname='OperacaoAcesso.IndexModoAcionamentoEquipamento']")).Click();

			for (int i = 1; i <= modoDeAcionamento; i++)
			{
				driver.FindElement(By.CssSelector("select[formcontrolname='OperacaoAcesso.IndexModoAcionamentoEquipamento']")).SendKeys(Keys.Down);
			}
			driver.FindElement(By.CssSelector("select[formcontrolname='OperacaoAcesso.IndexModoAcionamentoEquipamento']")).SendKeys(Keys.Enter);
		}

		public void TipoPeriferico(int periferico)
		{
			driver.Manage().Timeouts();
			driver.FindElement(By.CssSelector("select[formcontrolname='IndexTipoPeriferico']")).Click();

			for (int i = 1; i <= periferico; i++)
			{
				driver.FindElement(By.CssSelector("select[formcontrolname='IndexTipoPeriferico']")).SendKeys(Keys.Down);
			}
			driver.FindElement(By.CssSelector("select[formcontrolname='IndexTipoPeriferico']")).SendKeys(Keys.Enter);

		}

		public void HabilitarPerifericoPrincipal(int opcao )
		{
			driver.Manage().Timeouts();
			switch (opcao)
			{
				case 1:
					driver.Manage().Timeouts();
					driver.FindElement(By.Id("habilitar")).Click();
					driver.FindElement(By.Id("perifericoPrincipal")).Click();
					break;
				case 2:
					driver.Manage().Timeouts();
					driver.FindElement(By.Id("habilitar")).Click();
					break;
			}
		}
		public void PortaSerial(int porta)
		{
			IWebElement portaSerial = driver.FindElement(By.CssSelector("input[name=leitorMifarePortaSerial]"));
			portaSerial.SendKeys(porta.ToString());
		}

		public void PortaSerialImpressora(int porta)
		{
			IWebElement portaSerial = driver.FindElement(By.CssSelector("input[name=impressoraMifarePortaSerial]"));
			portaSerial.SendKeys(porta.ToString());
		}

		public void PortaSerialLeitor2D3D(int porta)
		{
			IWebElement portaSerial = driver.FindElement(By.CssSelector("input[formcontrolname='ConfiguracaoPeriferico.PortaSerial']"));
			portaSerial.SendKeys(porta.ToString());
		}


		public void ModeloLeitorMifare(int modeloLeitor)
		{
			driver.Manage().Timeouts();
			driver.FindElement(By.CssSelector("select[formcontrolname='ConfiguracaoPeriferico.IndexModelo']")).Click();

			for (int i = 0; i <= modeloLeitor; i++)
			{
				driver.FindElement(By.CssSelector("select[formcontrolname='ConfiguracaoPeriferico.IndexModelo']")).SendKeys(Keys.Down);
			}
			driver.FindElement(By.CssSelector("select[formcontrolname='ConfiguracaoPeriferico.IndexModelo']")).SendKeys(Keys.Enter);
			

		}

		public void TipoLeitor1D2D(int modeloLeitor)
		{
			driver.Manage().Timeouts();
			switch (modeloLeitor)
			{
				case 0:
					driver.FindElements(By.CssSelector("option[value"))[27].Click();
					break;
				case 1:
					driver.FindElements(By.CssSelector("option[value"))[28].Click();
					break;
				case 2:
					driver.FindElements(By.CssSelector("option[value"))[29].Click();
					break;
				case 3:
					driver.FindElements(By.CssSelector("option[value"))[30].Click();
					break;
				case 4:
					driver.FindElements(By.CssSelector("option[value"))[31].Click();
					break;
				case 5:
					driver.FindElements(By.CssSelector("option[value"))[32].Click();
					break;
				case 6:
					driver.FindElements(By.CssSelector("option[value"))[33].Click();
					break;
				case 7:
					driver.FindElements(By.CssSelector("option[value"))[34].Click();
					break;
				case 8:
					driver.FindElements(By.CssSelector("option[value"))[35].Click();
					break;

				default:
					driver.FindElement(By.CssSelector("button[type=button")).Click();
					break;

			}
		}

		public void ConfiguracaoLeitor2D3D(int laserContinuo, int leituraSeloDesc, int digitoVerificador)
		{
			if(laserContinuo == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='ConfiguracaoPeriferico.HabilitarLaserContinuo']")).Click();
			}
			if(leituraSeloDesc == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='ConfiguracaoPeriferico.HabilitarLeituraDeSeloDeDesconto']")).Click();
			}
			
			if(digitoVerificador == 1)
			{
				driver.FindElement(By.CssSelector("input[formcontrolname='ConfiguracaoPeriferico.HabilitarVerificacaoDoDigitoVerificadorDeMidiasCodigoDeBarras']")).Click();
			}
		}



		public void MifareAM10ModeoBocal(int modelo , string tempoEsperaEsteira , string tempoAguardoEmissao)
		{
			Thread.Sleep(2000);

			switch (modelo)
			{
				case 1:

					driver.FindElement(By.CssSelector("select[formcontrolname='ConfiguracaoPeriferico.IndexModeloBocalLeitorMifare']")).Click();
					driver.FindElement(By.CssSelector("select[formcontrolname='ConfiguracaoPeriferico.IndexModeloBocalLeitorMifare']")).SendKeys(Keys.Down);
					driver.FindElement(By.CssSelector("select[formcontrolname='ConfiguracaoPeriferico.IndexModeloBocalLeitorMifare']")).SendKeys(Keys.Enter);
					driver.Manage().Timeouts();
					driver.FindElement(By.CssSelector("input[name=leitorMifareTempoEspera")).SendKeys(tempoEsperaEsteira);
					driver.FindElement(By.CssSelector("input[name=leitorMifareTempoEmissao")).SendKeys(tempoAguardoEmissao);
					break;

				case 2:
					driver.FindElement(By.CssSelector("select[formcontrolname='ConfiguracaoPeriferico.IndexModeloBocalLeitorMifare']")).SendKeys(Keys.Down);
					driver.FindElement(By.CssSelector("select[formcontrolname='ConfiguracaoPeriferico.IndexModeloBocalLeitorMifare']")).SendKeys(Keys.Down);
					driver.FindElement(By.CssSelector("select[formcontrolname='ConfiguracaoPeriferico.IndexModeloBocalLeitorMifare']")).SendKeys(Keys.Enter);
					break;

			}


		}

		public void TipoImpressora(int modeloImpressora)
		{
			Thread.Sleep(2000);

			switch(modeloImpressora)
			{
				case 0:
					driver.FindElements(By.CssSelector("option"))[35].Click();
					break;
				case 1:
					driver.FindElements(By.CssSelector("option"))[36].Click();
					break;
				case 2:
					driver.FindElements(By.CssSelector("option"))[37].Click();
					break;
				case 3:
					driver.FindElements(By.CssSelector("option"))[38].Click();
					break;
				case 4:
					driver.FindElements(By.CssSelector("option"))[39].Click();
					break;
				case 5:
					driver.FindElements(By.CssSelector("option"))[40].Click();
					break;
				case 6:
					driver.FindElements(By.CssSelector("option"))[41].Click();
					break;
				case 7:
					driver.FindElements(By.CssSelector("option"))[42].Click();
					break;
				case 8:
					driver.FindElements(By.CssSelector("option"))[43].Click();
					break;
				case 9:
					driver.FindElements(By.CssSelector("option"))[45].Click();
					break;

			}
		}

		public void EntradaBarras(int porta , int sensor)
		{
			IWebElement portaSerial = driver.FindElement(By.CssSelector("input[formcontrolname='ConfiguracaoPeriferico.PortaSerial']"));
			portaSerial.SendKeys(porta.ToString());
			driver.FindElements(By.CssSelector("select[name='impressoraSensorBocal']"))[0].Click();
			if (sensor == 0)
			{
				driver.FindElements(By.CssSelector("option[value"))[36].Click();
			}
			
			if(sensor == 1)
			{
				driver.FindElements(By.CssSelector("option[value"))[37].Click();
			}
		}


		public void ConfirmarPeriferico()
		{
			driver.Manage().Timeouts();
			driver.FindElements(By.CssSelector("button"))[5].Click();
		}

		public void Salvar()
		{
			driver.Manage().Timeouts();
			driver.FindElements(By.CssSelector("button[type=submit"))[0].Click();
		}

		public void Detalhar()
		{
			driver.FindElements(By.CssSelector("div[class='menu-popovertable']"))[0].Click();
			driver.FindElements(By.CssSelector("div[class='menu-popovertable']"))[1].Submit();

		}

		public void Alterar()
		{
			IWebElement teste = driver.FindElement(By.CssSelector("div[class='menu-popovertable']"));
			driver.Navigate().GoToUrl("");

		}

		public void Excluir()
		{
	
		}

	}
}
