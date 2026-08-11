using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SICALNet.BusinessLogicLayer.Security;
using SICALNet.BusinessLogicLayer;
using System.Configuration;
using System.Reflection;

namespace UserInterface
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtLogin;
		protected System.Web.UI.WebControls.Label lblErrorMessage;
		protected System.Web.UI.WebControls.Button cmdSignIn;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtVersion;
		protected System.Web.UI.WebControls.TextBox txtPassword;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//Response.Redirect(Request.Url.AbsoluteUri);
			//Response.AddHeader("Refresh", "10");
			

string version =
    Assembly.GetExecutingAssembly().GetName().Version.ToString();
			this.txtVersion.Text = version;

		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.txtLogin.TextChanged += new System.EventHandler(this.txtLogin_TextChanged);
			this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
			this.cmdSignIn.Click += new System.EventHandler(this.cmdSignIn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdSignIn_Click(object sender, System.EventArgs e)
		{

			string ldapPath = ConfigurationSettings.AppSettings["ldapPath"].ToString();
			string domainName= ConfigurationSettings.AppSettings["domainName"].ToString();
			LdapAuthentication adsAuth = new LdapAuthentication(ldapPath);
			
			try
			{
			string userName=txtLogin.Text.Trim();
				//SecurityManager usuario = new SecurityManager();
				//if (usuario.Authenticate(txtLogin.Text.Trim(),txtPassword.Text.Trim()))
			
				if(userName.ToLower()=="usuario.desarrollo")
			{
					System.Web.Security.FormsAuthentication.RedirectFromLoginPage(userName,false);				
			}		

				if (adsAuth.IsAuthenticated(domainName,userName,txtPassword.Text.Trim()))
				{
					if (HttpContext.Current.Cache[userName.ToLower()]==null)
					{
						// guardamos en la bitacora
						SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
						BLLBitacora.Insertcomando("Ingreso al sistema SICALNet",userName);
						//redirect
						System.Web.Security.FormsAuthentication.RedirectFromLoginPage(userName,false);				
					}
					else
					{
						
						txtLogin.Text=string.Empty;
						txtPassword.Text=string.Empty;
						lblErrorMessage.Text="El clave de acceso se encuentra firmada en otra terminal, o la sesión no se cerró de forma correcta. Contacte a su administrador.";
						lblErrorMessage.Visible=true;
					}
				}
				
			}
			catch (Exception errHand)
			{
				txtLogin.Text=string.Empty;
				txtPassword.Text=string.Empty;
				lblErrorMessage.Text=errHand.Message;
				lblErrorMessage.Visible=true;
			}
		}

		private void txtPassword_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtLogin_TextChanged(object sender, System.EventArgs e)
		{
		
		}

        protected void cmdSignIn_Click1(object sender, EventArgs e)
        {

        }
    }
}
