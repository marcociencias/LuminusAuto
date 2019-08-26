using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuminusAuto.page;


namespace LuminusAuto.testes
{
	public class LuminusLogin
	{
		public LoginLuminusPage usuario;

		public LuminusLogin()
		{
			IWebDriver driver = new ChromeDriver(); // declarando um novo componente driver do tipo chrome
			usuario = new LoginLuminusPage(driver); // passando para o usuario uma nova instancia do LoginLuminusPage para poder utilizar o metodo logar

		}

		public void LogarNoLuminus(string ipLuminus)
		{
			usuario.Logar("administrador","123456",ipLuminus);
		}
		
	}
}
