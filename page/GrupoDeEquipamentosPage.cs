using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuminusAuto.page
{
	public class GrupoDeEquipamentosPage
	{
		IWebDriver driver;

		public GrupoDeEquipamentosPage(IWebDriver driver)
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
			driver.FindElement(By.CssSelector("button[funcionalidade='ConfiguracoesdoEstacionamento.GrupoEquipamentos.Incluir']")).Click();
		}
	
		public void CriarGrupoEquipamentos(string nome, int posicao)
		{
			Thread.Sleep(2000);
			driver.FindElement(By.CssSelector("input[formcontrolname='Nome']")).SendKeys(nome);
			Thread.Sleep(1000);
			driver.FindElements(By.CssSelector("span[class='glyphicon glyphicon-plus']"))[posicao].Click();

		}

		public void AdicionarEquipamento(int equipamento , int direcao , int tipo)
		{
			Thread.Sleep(500);
			driver.FindElement(By.CssSelector("select[formcontrolname='EquipamentoId']")).Click();

			for (int i = 0; i < equipamento; i++)
			{
				driver.FindElement(By.CssSelector("select[formcontrolname='EquipamentoId']")).SendKeys(Keys.Down);
			}


			driver.FindElement(By.CssSelector("select[formcontrolname='EquipamentoId']")).SendKeys(Keys.Enter);
			driver.FindElement(By.CssSelector("select[formcontrolname='IndexDirecaoImagem']")).Click();

			for (int i = 0; i <= direcao; i++)
			{
				driver.FindElement(By.CssSelector("select[formcontrolname='IndexDirecaoImagem']")).SendKeys(Keys.Down);
			}
			driver.FindElement(By.CssSelector("select[formcontrolname='IndexDirecaoImagem']")).SendKeys(Keys.Enter);

			if(tipo == 1)
			{
				driver.FindElements(By.CssSelector("input[name='ImagemEquipamento.Id']"))[0].Click();
			}
			if (tipo == 2)
			{
				driver.FindElements(By.CssSelector("input[name='ImagemEquipamento.Id']"))[1].Click();
			}
			if (tipo == 3)
			{
				driver.FindElements(By.CssSelector("input[name='ImagemEquipamento.Id']"))[2].Click();
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
