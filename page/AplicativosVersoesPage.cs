using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuminusAuto.page
{
	public class AplicativosVersoesPage
	{
		IWebDriver driver;

		public AplicativosVersoesPage(IWebDriver driver)
		{
			this.driver = driver;
		}


		public void Navegar(string url)
		{
			Thread.Sleep(4000);
			driver.Navigate().GoToUrl(url);
			
		}

		public void EscolherArquivo(int tipo , string[] diretorio)
		{
			Thread.Sleep(5000);
			driver.FindElement(By.CssSelector("button[funcionalidade='InstalacoesEAtualizacoes.AplicativosVersoes.Carregar']")).Click();
			driver.FindElement(By.CssSelector("input[formcontrolname='Arquivo']")).Click();
			Thread.Sleep(2000);

			if (tipo == 1)
			{
				SendKeys.SendWait(diretorio[1]);
				Thread.Sleep(1000);
				SendKeys.SendWait(@"{Enter}");
			}

			if (tipo == 2)
			{
				SendKeys.SendWait(diretorio[2]);
				Thread.Sleep(1000);
				SendKeys.SendWait(@"{Enter}");
			}

			if (tipo == 3)
			{
				SendKeys.SendWait(diretorio[3]);
				Thread.Sleep(1000);
				SendKeys.SendWait(@"{Enter}");
			}
		}

        public void teste()
        {

        }


		public void Carregar()
		{
			Thread.Sleep(500);
			driver.FindElement(By.CssSelector("button[type='submit']")).Click();
		}

	}
}
