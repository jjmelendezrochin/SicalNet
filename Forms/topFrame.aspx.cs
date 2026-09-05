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

namespace UserInterface.Forms
{
	/// <summary>
	/// Summary description for topFrame.
	/// </summary>
	public class topFrame : System.Web.UI.Page
	{

		protected System.Web.UI.WebControls.Label lblUsuario;
		private void Page_Load(object sender, System.EventArgs e)
		{
			SICALNet.BusinessEntities.UsuarioInfo objUsuarioInfo =
				  new SICALNet.BusinessEntities.UsuarioInfo(User.Identity.Name);

			SICALNet.BusinessLogicLayer.Usuario objUsuario =
				new SICALNet.BusinessLogicLayer.Usuario();

			SICALNet.BusinessEntities.UsuarioInfo objUser =
				objUsuario.Load(objUsuarioInfo);

			this.lblUsuario.Text = objUser.Nombre;
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
