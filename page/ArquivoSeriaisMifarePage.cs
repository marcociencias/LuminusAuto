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
	public class ArquivoSeriaisMifarePage
	{
		IWebDriver driver;

		public ArquivoSeriaisMifarePage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public void Navegar(string url)
		{
			Thread.Sleep(2000);
			driver.Navigate().GoToUrl(url);
		}
		public void EscolherArquivo(string[] diretorio)
		{
			Thread.Sleep(5000);
			driver.FindElement(By.CssSelector("button[type='submit']")).Click();
			Thread.Sleep(2000);
			driver.FindElement(By.CssSelector("input[formcontrolname='Arquivo']")).Click();
			Thread.Sleep(1000);
			SendKeys.SendWait(diretorio[0]);
			Thread.Sleep(3000);
			SendKeys.SendWait(@"{Enter}");
		}
		public void Carregar()
		{
			Thread.Sleep(2000);
			driver.FindElement(By.CssSelector("button[type='submit']")).Click();
			Thread.Sleep(5000);
		}
	}
}
