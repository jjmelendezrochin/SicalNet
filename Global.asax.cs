using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using SICALNet.BusinessLogicLayer.Security;
using System.Web.Caching;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System.Diagnostics;

namespace UserInterface 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
//			Application("LogFile")=Server.MapPath("/");
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
			Session["errMsg"]=string.Empty;
			Session["opMode"]=string.Empty;
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}


		/*** modificado por alejandro.hernandez@nasoft.com 28/02/2006 ***/
		private void Application_AuthenticateRequest(Object sender, EventArgs e)
//		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		/*** fin modificación ***/
		{
			int iExiste = 0;
			if (this.User!=null)
			{
				SecurityManager userInformation = new SecurityManager();
				CustomPrincipal userPrincipal=userInformation.ConstructCustomPrincipal(this.User.Identity);
				this.Context.User=userPrincipal;

				// Verifica si el usuario no esta en el cache lo inserta de otra forma no lo inserta
				if (HttpContext.Current.Cache.Count>0)
				{
					foreach(DictionaryEntry objItem in HttpContext.Current.Cache) 
					{ 
						if (objItem.Key.ToString().IndexOf(this.User.Identity.Name.ToLower()) <= 0)
						{
							iExiste++;
							
						}
					}					
				}
				// ****************************
				// Solo agrega al cache si no existe para no insertarlo múltiples ocasiones
				if (iExiste == 0) {
					HttpContext.Current.Cache.Insert(this.User.Identity.Name.ToLower(),this.User.Identity.Name.ToLower(),null);
				}
				// ****************************
			}
		}

		protected void Application_Error(Object sender, EventArgs e)
		{
			Exception exc = Server.GetLastError();			

			if (exc != null)
			{
				string url = Request.RawUrl;
				string mensaje = exc.GetBaseException().Message;

				System.Diagnostics.Debug.WriteLine(
					"APPLICATION_ERROR URL: " + url
				);

				System.Diagnostics.Debug.WriteLine(
					"APPLICATION_ERROR: " + mensaje
				);

				Session["Exception"] =
					"URL: " + url +
					" | Error: " + mensaje;
			}
		}

		protected void Session_End(Object sender, EventArgs e)
		{
			HttpContext.Current.Cache.Remove(this.User.Identity.Name);
		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
		}
		#endregion
	}
}

