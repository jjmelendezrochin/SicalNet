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
using SICALNet.BusinessLogicLayer;

namespace UserInterface.Forms.Administration
{
	/// <summary>
	/// Summary description for Profiles.
	/// </summary>
	public class Profiles : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid dgdPerfiles;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label2;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (!IsPostBack)
			{
				LoadProfilesList();
			}
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.dgdPerfiles.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPerfiles_ItemCommand);
			this.dgdPerfiles.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdPerfiles_PageIndexChanged);
			this.dgdPerfiles.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPerfiles_EditCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		/// <summary>
		/// Method to populate grid of profiles
		/// </summary>
		private void LoadProfilesList()
		{
			Perfil BLLProfiles= new Perfil();
			dgdPerfiles.DataSource=BLLProfiles.SelectPerfil();
			dgdPerfiles.DataBind();
		}

		private void dgdPerfiles_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{

		}

		private void dgdPerfiles_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string profileId=((Label)e.Item.FindControl("ItemIdPerfil")).Text;
			string profileDesc=((Label)e.Item.FindControl("ItemDescripcion")).Text;
			string redirectURL =string.Format("EditProfiles.aspx?Mode=Edicion&IdPerfil={0}&DescripcionPerfil={1}",profileId,profileDesc);
			Response.Redirect(redirectURL);
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("EditProfiles.aspx?Mode=Nuevo&IdPerfil=&DescripcionPerfil=");
		}

		private void dgdPerfiles_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdPerfiles.CurrentPageIndex = e.NewPageIndex;
			LoadProfilesList();

		}
	}
}
