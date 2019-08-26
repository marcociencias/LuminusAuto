using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using LuminusAuto.page;

namespace LuminusAuto
{
	public class Program
	{

		public enum MenuPopupOver
		{
			Detalhar = 0,
			Alterar = 1,
			Excluir = 2
		}

		/* Sequencia de configuração do luminus
		 *  PASSO A PASSO PARA AUTOMAÇÃO DO LUMINUS - INSTALAÇÃO
		 * Arquivo serial Mifare -- ok
		 * Bolsão de vagas para criação dos setores -- pk
		 * aplicativos e versões - ok
		 * Equipamentos EAE - ok
		 * Grupo de Equipamentos - ok
		 * Parametros gerais do estacionamento - ok
		 * Estrutura de tabela de cobrança - ok
		 * Produto estadia - ok
		 * Regra de Acesso - ok
		 * Regra de Cobrança - ok
		 * Regra de Desconto - ok
		 * Regra de Midia Perdida
		 * Tabela de cobrança - após a criação retornar ao Produto estadia e Regra de cobrança para adicionar a tabela;
		 * Agendamento de tarefas automatizadas - procedimento manual
		 * Cliente do estacionamento - ok
		 * Contrato de Estadia - procedimento manual
		 */

		static void Main(string[] args)
		{
			//string url = "http://192.168.1.172:4200/produtosdeestadia/regrasdecobranca/consultar";

			string ipLuminus = "http://192.168.1.124:4200";

			string[] pagina = new string[14];

			pagina[0] = "/configuracoesdoestacionamento/arquivoseriaismifare/carregar";
			pagina[1] = "/instalacoeseatualizacoes/aplicativoseversoes/consultar";
			pagina[2] = "/configuracoesdoestacionamento/bolsoesdevagas/consultar";
			pagina[3] = "/configuracoesdoestacionamento/equipamentos/consultar";
			pagina[4] = "/configuracoesdoestacionamento/gruposdeequipamentos/consultar";
			pagina[5] = "/configuracoesdoestacionamento/parametrosgerais/detalhar";
			pagina[6] = "/produtosdeestadia/estruturasdetabelasdecobranca/consultar";
			pagina[7] = "/produtosdeestadia/produtosdeestadia/consultar";
			pagina[8] = "/produtosdeestadia/regrasdeacesso/consultar";
			pagina[9] = "/produtosdeestadia/regrasdecobranca/consultar";
			pagina[10] = "/produtosdeestadia/regrasdedescontos/consultar";
			pagina[11] = "/produtosdeestadia/regrasdemidiaperdida/consultar";
			pagina[12] = "/produtosdeestadia/tabelasdecobranca/consultar";
			pagina[13] = "/operacao/clientesdoestacionamento/consultar";

			string[] diretorio = new string[4];
			diretorio[0] = @"C:\Luminus\Licenca\novaEstruturaJson_V3.lic";
			diretorio[1] = "C:\\Luminus\\AplicativosEVersoes\\EAC_V3.01.zip";
			diretorio[2] = "C:\\Luminus\\AplicativosEVersoes\\EAE_V0.0.3.zip";
			diretorio[3] = "C:\\Luminus\\AplicativosEVersoes\\EAP_V2.2.5.111.zip"; 

			IWebDriver driver = new ChromeDriver();

			LoginLuminusPage usuarioLogin = new LoginLuminusPage(driver);
			usuarioLogin.Usuario = "Administrador";
			usuarioLogin.Senha = "123456";
			usuarioLogin.Luminus = ipLuminus;
			usuarioLogin.Logar(usuarioLogin._usuario, usuarioLogin._senha, usuarioLogin._luminus);

			//ArquivoSeriaisMifarePage usuarioLicenca = new ArquivoSeriaisMifarePage(driver);
			////usuarioLicenca.Navegar(ipLuminus + pagina[0]);
			//usuarioLicenca.EscolherArquivo(diretorio);
			//usuarioLicenca.Carregar();

			//AplicativosVersoesPage usuarioAplicativo = new AplicativosVersoesPage(driver);
			//usuarioAplicativo.Navegar(ipLuminus + pagina[1]);
			//usuarioAplicativo.EscolherArquivo(1, diretorio);
			//usuarioAplicativo.Carregar();
			//usuarioAplicativo.EscolherArquivo(2, diretorio);
			//usuarioAplicativo.Carregar();
			//usuarioAplicativo.EscolherArquivo(3, diretorio);
			//usuarioAplicativo.Carregar();

			//BolsaoDeVagasPage usuarioBolsao = new BolsaoDeVagasPage(driver);
			//usuarioBolsao.Navegar(ipLuminus + pagina[2]);
			//usuarioBolsao.Criar("1", "Bolsão Selenium", "1000");
			//usuarioBolsao.Salvar();

			//EquipamentosPage usuarioEquipamento = new EquipamentosPage(driver);
			//usuarioEquipamento.Navegar(ipLuminus + pagina[3]);
			//usuarioEquipamento.Criar(0, 0, 0, "8", "1", "Selenium", "10.10.10.10", "255.255.255.0", "192.168.0.1", "8");
			//usuarioEquipamento.AplicativoEntrada();
			//usuarioEquipamento.OperacaoDeAcesso(0, 1, 1, 0);
			//usuarioEquipamento.ModosDeAcionamento(1);
			//usuarioEquipamento.AcessoBolsaoPrincipal();
			//usuarioEquipamento.ConfiguracaoCancelaEntrada(1, 1, 1, 1, 1, 1, "6");
			//usuarioEquipamento.AdicionarPeriferico();
			//usuarioEquipamento.TipoPeriferico(1);
			//usuarioEquipamento.HabilitarPerifericoPrincipal(1);
			//usuarioEquipamento.PortaSerial(7);
			//usuarioEquipamento.ModeloLeitorMifare(0);
			//usuarioEquipamento.MifareAM10ModeoBocal(1, "10", "10");
			//usuarioEquipamento.ConfirmarPeriferico();
			//usuarioEquipamento.ConfiguracaoDeSuporte(1, 1, "9", "9");
			//usuarioEquipamento.Salvar();

			//GrupoDeEquipamentosPage usuarioGrupo = new GrupoDeEquipamentosPage(driver);
			//usuarioGrupo.Navegar(ipLuminus + pagina[4]);
			//usuarioGrupo.Criar();
			//usuarioGrupo.CriarGrupoEquipamentos("Selenium", 0);
			//usuarioGrupo.AdicionarEquipamento(1, 0, 1);
			//usuarioGrupo.Salvar();

			//ParametrosGeraisDoEstacionamento usuarioParametrosEstac = new ParametrosGeraisDoEstacionamento(driver);
			//usuarioParametrosEstac.Navegar(ipLuminus + pagina[5]);
			//usuarioParametrosEstac.Criar("192.168.10.10", "4200", "2000", "2000", "5000");
			//usuarioParametrosEstac.Operacao("04:00");
			//usuarioParametrosEstac.SeloDesconto("01012018");
			//usuarioParametrosEstac.ControleVagas("10", "10");
			//usuarioParametrosEstac.Salvar();

			//EstruturaDeTabelaPage tabela = new EstruturaDeTabelaPage(driver);
			//tabela.Navegar(ipLuminus + pagina[6]);
			//tabela.Criar();
			//tabela.InformacoesGerais("Tabela Selenium ");

			//tabela.Periodo("0600", 0);
			//tabela.AdicionarFracao("0100", "2", 2, 2);
			//tabela.Repeticao(0, 3);

			//tabela.AdicionarPeriodo(3000);
			//tabela.Periodo("0700", 1);
			//tabela.AdicionarFracao("0500", "2", 2, 3);
			//tabela.Repeticao(4, 7);

			//tabela.AdicionarPeriodo(30000);
			//tabela.Periodo("0800", 2);
			//tabela.AdicionarFracao("0500", "2", 2, 4);
			//tabela.Repeticao(8, 11);
			//tabela.Salvar();

			//ProdutoEstadiaPage usuarioPE = new ProdutoEstadiaPage(driver);

			//usuarioPE.Navegar(ipLuminus + pagina[7]);
			///*
			// Tipos de Usuário
			// 1- Avulso usuarioPE.Criar("Produto Automatizado", 1);
			// 2- Credenciado usuarioPE.Criar("Produto Automatizado", 2);
			// 3- Pré-pago usuarioPE.Criar("Produto Automatizado", 3);
			// 4- Pós Pago usuarioPE.Criar("Produto Automatizado", 4);
			// */
			//usuarioPE.Criar("Produto Selenium", 2);
			////usuarioPE.ConfiguracaoPrePago("8", "1000", "0800", "30");
			////usuarioPE.ConfiguracaoPrePagoSaldos("10", "1000", "2000", "0500", "0100");
			////usuarioPE.ConfiguracaoPrePagoUtilizacao("5", "1000", "1000", "2");
			////usuarioPE.ConfiguracaoPrePagoRecarga(1, 1, 1, 0);

			//usuarioPE.ConfiguracaoCredenciado("10", 1);
			///*
			// Configuração Credenciado
			// 1- Quantidade de Dias usuarioPE.ConfiguracaoCredenciado("10", 1);
			// 2- Dias do Mes usuarioPE.ConfiguracaoCredenciado("10", 2);
			// 3- Diarista usuarioPE.ConfiguracaoCredenciado("10", 3);
			// */
			//usuarioPE.ConfiguracaoRevalidacaoQuantDias("30", "2000");
			////	tipo credenciado 2  dia do mes
			////	 usuarioPE.ConfiguracaoRevalidacaoDiaMes("30", "1000", "5");

			////	tipo 3 diarista
			////	 usuarioPE.Diarista("1000", "10", 2, 1, "8");
			//usuarioPE.BotaoSalvar();

			RegraDeAcessoPage usuarioRegra = new RegraDeAcessoPage(driver);
			usuarioRegra.Navegar(ipLuminus + pagina[8]);
			usuarioRegra.Criar();
			usuarioRegra.InformacoesGerais("teste automatizacao", "Entrada");
			usuarioRegra.InformacoesDeAcesso("1000", "1200");
			usuarioRegra.BolsaoVagasPrecValidos(1, 1, 1, 0, "1000", "1200");
			usuarioRegra.ConfigRegraDeAcesso(1, 1, 1, 1, 2);
			usuarioRegra.TempoDeTransito(0, "0020", 2, 1);
			usuarioRegra.AcessoAssistido(3, 1, 1, 1);
			usuarioRegra.AcessoAssistidoInformar(1, 1, 1);
			usuarioRegra.AcessoAssistidoPermitir(1, 1, 1);
			usuarioRegra.AcessoAssistidoReimprimir(1, 1);
			usuarioRegra.Salvar();

			RegraDeCobrancaPage Usuariocobranca = new RegraDeCobrancaPage(driver);
			Usuariocobranca.Navegar(ipLuminus + pagina[9]);
			Usuariocobranca.Criar();
			Usuariocobranca.InformacoesGerais("Selenium");
			Usuariocobranca.LimiteDeCobranca("111111", "111111", "100000", "10", "30", 1, 1);
			Usuariocobranca.ConfiguracaoDeCalculo(1, "10", 2, 1, 1);
			Usuariocobranca.ConfiguracaoDeCalculoHabilitar(1, 1, 1);
			Usuariocobranca.ConfiguracaoDeCalculoInterromper(1, 1, 1);
			Usuariocobranca.ConfiguracaoDeCalculoPermitir(1, 1, 1);
			Usuariocobranca.ConfiguracaoDeCalculoCobranca(1, "1000", "1000", "9", 1, 1, 1, 1);
			Usuariocobranca.ConfiguracaoDeCalculoEntradasOffLine("30", "5", "59");
			Usuariocobranca.FormaDePagamento(1);
			Usuariocobranca.TabelaDeCobranca(1, 1, 1);
			Usuariocobranca.Salvar();

			TabelaDeCobrancaPage usuarioTabela = new TabelaDeCobrancaPage(driver);
			usuarioTabela.Navegar(ipLuminus+pagina[12]);
			usuarioTabela.Criar();
			usuarioTabela.InformacoesGerais("3", "Teste Tabela Selenium");
			usuarioTabela.Adicionar();
			usuarioTabela.TempoTolerancia(7, "1100", 1, "0030", 1, "0030");
			usuarioTabela.Salvar();


			RegraDeDescontoPage usuarioDesconto = new RegraDeDescontoPage(driver);
			usuarioDesconto.Navegar(ipLuminus+pagina[10]);
			usuarioDesconto.Criar();
			usuarioDesconto.InformacoesGerais("teste automatizado");
			usuarioDesconto.FuncionamentoGeralDesconto(0, "111100", "2", "500", 1);
			usuarioDesconto.DescontoTecla(0, "1200", "2300");
			usuarioDesconto.TeclaSelecionada(0);
			usuarioDesconto.alteraTeclaDesconto(5, "1000", "10");
			usuarioDesconto.TeclaSelecionada(1);
			usuarioDesconto.alteraTeclaDesconto(5, "1000", "50");
			usuarioDesconto.TeclaSelecionada(2);
			usuarioDesconto.alteraTeclaDesconto(1, "1000", "50");
			usuarioDesconto.TeclaSelecionada(3);
			usuarioDesconto.alteraTeclaDesconto(0, "1000", "50");
			usuarioDesconto.TeclaSelecionada(4);
			usuarioDesconto.alteraTeclaDesconto(1, "2000", "10");
			usuarioDesconto.TeclaSelecionada(5);
			usuarioDesconto.alteraTeclaDesconto(1, "1000", "10");
			usuarioDesconto.DescontoSeloDesconto(0, "1000", "2300", 7);
			usuarioDesconto.DescontosSeloGenerico(0, 1, "1000", "50");
			usuarioDesconto.DescontoMudancaDeTabela(1);
			usuarioDesconto.BotaoSalvar();

			MidiaPerdidaPage usuarioLost = new MidiaPerdidaPage(driver);
			usuarioLost.Navegar(ipLuminus+pagina[11]);
			usuarioLost.Criar();
			usuarioLost.InformacoesGerais("Teste Selenium");
			usuarioLost.RegrasDePerda(2);
			usuarioLost.MotivoPerda("1000", 2, 1, 1, 1, "2000");
			usuarioLost.SalvarMotivoPerda();
			usuarioLost.Salvar();

			ClienteEstacionamentoPage usuarioCliente = new ClienteEstacionamentoPage(driver);
			usuarioCliente.Navegar(ipLuminus+pagina[13]);
			usuarioCliente.Criar();
			usuarioCliente.InformacoesGerais("Marco Junior", "marco.junior@nepos.com.br", 1, "123456789", 1, "123456789");
			usuarioCliente.InformacoesDeContato("20425313", "976451704", "Rua pitagoras", "398", "Casa", "03693010", "Sâo Paulo", "SP");
			usuarioCliente.InformacoesComplementares();
			usuarioCliente.Veiculo("DPA9164", 15, 30);
			usuarioCliente.Salvar();
		}
	}

	
}
