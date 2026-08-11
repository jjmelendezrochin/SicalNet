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
using System.Web.Security;
namespace UserInterface
{
	/// <summary>
	/// Summary description for LogOut.
	/// </summary>
	public class LogOut : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			Session["selectedLine"] = null;
			for (int i=0; i <100; i++)
			{
				HttpContext.Current.Cache.Remove(this.User.Identity.Name.ToLower());
			}						
			FormsAuthentication.SignOut();
			
			// guardamos en la bitacora
			//SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
			//BLLBitacora.Insertcomando("Salida del sistema SICALNet",this.User.Identity.Name.ToString());

			//
			//Response.Redirect("location.reload()");
			Response.Redirect("Login.aspx");

			// Put user code to initialize the page here
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
