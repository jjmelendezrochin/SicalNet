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

using SICALNet.Utilities;

namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for ConsultMessage.
	/// </summary>
	public class ProgrammaProduction : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Panel pnlStart;
		protected System.Web.UI.WebControls.TextBox txtBitacora;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.Button btnEditar;
		protected System.Web.UI.WebControls.TextBox txtAddBita;
		protected System.Web.UI.WebControls.Button btnAddAceptar;
		protected System.Web.UI.WebControls.Button btnAddCancel;
		protected System.Web.UI.WebControls.Panel pnlAddLog;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
		protected Controls.ProgrammaGrid grdProgram;
	
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

		private void Page_Load(object sender, System.EventArgs e)
		{
		
		}

	
	}
}
