using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuminusAuto.page;

namespace LuminusAuto.page
{
	public class LoginLuminusPage
	{
		internal string _usuario;

		public string _senha;

		public string _luminus;

		public IWebDriver driver { get; set; }

		public string Usuario
		{
			get
			{
				return _usuario;
			}
			set
			{
				_usuario = value;
			}
		}

		public string Senha
		{
			get
			{
				return _senha;
			}
			set
			{
				_senha = value;
			}
		}

		public string Luminus
		{
			get
			{
				return _luminus;
			}
			set
			{
				_luminus = value;
			}
		}

		public LoginLuminusPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public void Logar(string _usuario , string _senha , string _luminus)
		{
			driver.Navigate().GoToUrl(_luminus);
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
 
			IWebElement elementUser = driver.FindElement(By.Id("inputEmail"));
			elementUser.SendKeys(_usuario);
			IWebElement elementPassword = driver.FindElement(By.Id("password"));
			elementPassword.SendKeys(_senha);
			driver.FindElement(By.Id("entrar")).Submit();
		}


	}
}
