using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuminusAuto.page
{
	public class ClienteEstacionamentoPage
	{
		IWebDriver driver;

		public ClienteEstacionamentoPage(IWebDriver driver)
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
			Thread.Sleep(5000);
			driver.FindElement(By.CssSelector("button[funcionalidade='Operacao.ClienteEstacionamento.Incluir']")).Click();
		}

		public void InformacoesGerais(string nome , string email , int tipoDoc1 , string doc1 , int tipoDoc2 , string doc2 )
		{
			Thread.Sleep(3000);
			driver.FindElement(By.CssSelector("input[formcontrolname='Nome']")).SendKeys(nome);
			driver.FindElement(By.CssSelector("input[formcontrolname='Email']")).SendKeys(email);

			if( tipoDoc1 == 0)
			{
				driver.FindElements(By.CssSelector("option[value='0']"))[0].Click();
			}
			if (tipoDoc1 == 1)
			{
				driver.FindElements(By.CssSelector("option[value='1']"))[0].Click();
			}
			if (tipoDoc1 == 2)
			{
				driver.FindElements(By.CssSelector("option[value='2']"))[0].Click();
			}
			driver.FindElement(By.CssSelector("input[formcontrolname='NumeroDocumento1']")).SendKeys(doc1);

			if (tipoDoc2 == 0)
			{
				driver.FindElements(By.CssSelector("option[value='0']"))[1].Click();
			}
			if (tipoDoc2 == 1)
			{
				driver.FindElements(By.CssSelector("option[value='1']"))[1].Click();
			}
			if (tipoDoc2 == 2)
			{
				driver.FindElements(By.CssSelector("option[value='2']"))[1].Click();
			}
			driver.FindElement(By.CssSelector("input[formcontrolname='NumeroDocumento2']")).SendKeys(doc2);

		}

		public void InformacoesDeContato(string telefone , string celular, string logradouro , string numero , string complemento, string cep, string cidade, string uf)
		{
			driver.FindElement(By.CssSelector("input[formcontrolname='Telefone']")).SendKeys(telefone);
			driver.FindElement(By.CssSelector("input[formcontrolname='Celular']")).SendKeys(celular);
			driver.FindElement(By.CssSelector("input[formcontrolname='Logradouro']")).SendKeys(logradouro);
			driver.FindElement(By.CssSelector("input[formcontrolname='Numero']")).SendKeys(numero);
			driver.FindElement(By.CssSelector("input[formcontrolname='Complemento']")).SendKeys(complemento);
			driver.FindElement(By.CssSelector("input[formcontrolname='CEP']")).SendKeys(cep);
			driver.FindElement(By.CssSelector("input[formcontrolname='Cidade']")).SendKeys(cidade);
			driver.FindElement(By.CssSelector("input[formcontrolname='UF']")).SendKeys(uf);
		}

		public void InformacoesComplementares()
		{
			driver.FindElement(By.CssSelector("textarea[formcontrolname='Observacao1']")).SendKeys("Teste Observação1");
			driver.FindElement(By.CssSelector("textarea[formcontrolname='Observacao2']")).SendKeys("Teste Observação2");
		}

		public void Veiculo(string placa , int modelo , int cor)
		{
			driver.FindElements(By.CssSelector("button[type='button']"))[0].Click();

			Thread.Sleep(1000);
			driver.FindElement(By.CssSelector("input[formcontrolname='Placa']")).SendKeys(placa);

			//driver.FindElements(By.CssSelector("option[value"))[0].Click();

			for(int i = 6; i <= modelo; i ++)
			{
				Thread.Sleep(200);
				driver.FindElements(By.CssSelector("option[value"))[i].Click();

			}

			for (int j = 27; j <= cor; j++)
			{
				Thread.Sleep(200);
				driver.FindElements(By.CssSelector("option[value"))[j].Click();

			}

			driver.FindElements(By.CssSelector("button[type='submit']"))[1].Click();

		}

		public void Salvar()
		{
			Thread.Sleep(500);
				driver.FindElements(By.CssSelector("button[type='submit']"))[0].Click();
		}



	}
}
