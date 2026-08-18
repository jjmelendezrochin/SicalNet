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
using SICALNet.BusinessEntities;
using SICALNet.BusinessLogicLayer;

namespace UserInterface.Forms.Administration
{
	/// <summary>
	/// Summary description for UsersList.
	/// </summary>
	public class UsersList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnBuscar;
		protected System.Web.UI.WebControls.Button btnNuevo;
		protected System.Web.UI.WebControls.TextBox txtCriterio;
		protected System.Web.UI.WebControls.DataGrid dgdUsers;
		protected System.Web.UI.WebControls.DropDownList cboCriterio;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
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
			this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			this.dgdUsers.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdUsers_ItemCommand);
			this.dgdUsers.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdUsers_PageIndexChanged);
			this.dgdUsers.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdUsers_EditCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnBuscar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (txtCriterio.Text.Trim() == string.Empty)
				{
					throw new Exception(
						"Favor de proporcionar el criterio de búsqueda."
					);
				}

				dgdUsers.CurrentPageIndex = 0;

				performSearch(
					txtCriterio.Text,
					cboCriterio.SelectedItem.Value
				);
			}
			catch (Exception errHand)
			{
				Mensajes.Advertencia(
					Page,
					errHand.Message
				);
			}
		}

		private void performSearch(string criteriaText, string criteriaId)
		{	
			/*** modificado por alejandro.hernandez@nasoft.com 01/03/2006 ***/
			string whereString = createWhereString(criteriaId);
//			string whereString = createWhereString(criteriaText,criteriaId);
			/*** fin de modificación ***/
			
			Usuario BLLUsers = new Usuario();
			IList usersList=BLLUsers.SelectUsers(whereString,"%"+criteriaText+"%");
			
			if (usersList.Count>0)
			{

				dgdUsers.DataSource=usersList;
				dgdUsers.DataBind();			
			}
			else
			{
				dgdUsers.DataSource=null;
				dgdUsers.DataBind();			
				throw new Exception("No se encontraron usuarios de las características deseadas.");			
			}
		}
		/*** modificado por alejandro.hernandez@nasoft.com 01/03/2006 ***/
		private string createWhereString(string criteriaId)
//		private string createWhereString(string criteriaText,string criteriaId)

		/*** fin de modificación ***/
		{
			string resultString=string.Empty;
			switch (criteriaId)
			{
				case "Login":
					resultString = "WHERE Usuario.Login like ";
					break;
				case "Nombre":
					resultString = "WHERE Usuario.Nombre like ";
					break;
				case "IdPlanta":
					resultString = "WHERE Planta.Descripcion like ";
					break;
				case "Turno":
					resultString = "WHERE Usuario.Turno like ";
					break;
				case "IdPerfil":
					resultString = "WHERE Perfil.Descripcion like ";
					break;
				default: //IdArea
					resultString = "WHERE Area.Descripcion like ";
					break;
			}
			return resultString;
		}

		private void btnNuevo_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("EditUsers.aspx?Mode=Nuevo&login=");
		}

		private void dgdUsers_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Label selectedLogin=(Label)e.Item.FindControl("ItemLogin");
			string redirectURL = string.Format("EditUsers.aspx?Mode=Edicion&login={0}",selectedLogin.Text);
			Response.Redirect(redirectURL);
		}

		private void dgdUsers_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdUsers.CurrentPageIndex = e.NewPageIndex;
			performSearch(txtCriterio.Text,cboCriterio.SelectedItem.Value);
		}

		private void dgdUsers_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName.Equals("Release"))
			{
				string _userLogin = ((Label) e.Item.FindControl("ItemLogin")).Text.Trim();
				string _userName = ((Label) e.Item.FindControl("ItemNombre")).Text.Trim();
				HttpContext.Current.Cache.Remove(_userLogin.ToLower());

				Response.Write("<script language='javascript'>alert('La cuenta ["+_userLogin+"] del usuario ["+_userName+"] ha quedado liberada !')</script>");
			}
		}

        protected void btnNuevo_Click1(object sender, EventArgs e)
        {

        }
    }
}
