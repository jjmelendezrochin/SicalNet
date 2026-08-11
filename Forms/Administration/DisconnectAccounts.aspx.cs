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
using System.Web.Security;

namespace UserInterface.Forms.Administration
{
	/// <summary>
	/// Summary description for DisconnectAccounts.
	/// </summary>
	public class DisconnectAccounts : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnBuscar;
		protected System.Web.UI.WebControls.TextBox txtCriterio;
		protected System.Web.UI.WebControls.DropDownList cboCriterio;
		protected System.Web.UI.WebControls.DataGrid dgdUsers;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				dgdUsers.CurrentPageIndex=0;
				performSearch(txtCriterio.Text,cboCriterio.SelectedItem.Value);
				this.lblTitle.Text = this.lblTitle.Text + ", Usuario actual " + this.User.Identity.Name;
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
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			this.dgdUsers.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdUsers_ItemCommand);
			this.dgdUsers.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdUsers_PageIndexChanged);
			this.dgdUsers.SelectedIndexChanged += new System.EventHandler(this.dgdUsers_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnBuscar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (txtCriterio.Text.Trim()==string.Empty)
					throw new Exception("Favor de proporcionar el criterio de búsqueda!");
				dgdUsers.CurrentPageIndex=0;
				performSearch(txtCriterio.Text,cboCriterio.SelectedItem.Value);
			}
			catch (Exception errHand)
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('"+ errHand.Message +"');</script>"; 
				Page.RegisterStartupScript("ClientScript",ScriptString);
			}
		}

		private void performSearch(string criteriaText, string criteriaId)
		{	
			IList myUserList = new ArrayList(); 
			
			if (HttpContext.Current.Cache.Count>0)
			{
				// generamos la lista de los ususario actuales en el sistema			
				foreach(DictionaryEntry objItem in Cache) 
					{ 
					if (objItem.Key.ToString().IndexOf("||TOKILLSESSION") <= 0)
						{
							UsuarioInfo belUser = new UsuarioInfo(objItem.Key.ToString(),string.Empty,string.Empty,0,0,string.Empty,0,string.Empty,0,string.Empty,false);
							Usuario BLLUser = new Usuario();
							belUser=BLLUser.Load(belUser);
							myUserList.Add(belUser);					 
						}
				}	
				if (myUserList.Count > 0)
				{
					dgdUsers.DataSource=myUserList;
					dgdUsers.DataBind();			
				}
				else
				{
					dgdUsers.DataSource=null;
					dgdUsers.DataBind();			
					//throw new Exception("No se encontraron usuarios de las características deseadas.");			
				}
			}
			else
			{
				//no hay usuarios en el sistema
			}
			
			
		
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
				
				if (_userLogin != this.User.Identity.Name)
				{
					HttpContext.Current.Cache.Remove(_userLogin);
					// agregamois una bandera de borrado
					//System.Web.Security.FormsAuthentication.RedirectFromLoginPage(_userLogin + "||TOKILLSESSION",false);				
					System.Web.Caching.CacheItemRemovedCallback myCallBack = null;
					HttpContext.Current.Cache.Add(_userLogin + "||TOKILLSESSION",
						_userLogin + "||TOKILLSESSION", null, DateTime.MaxValue,
						new TimeSpan(0, 1, 0), 
						System.Web.Caching.CacheItemPriority.Default,
						myCallBack);
 
					//FormsAuthentication.SignOut();
				
					dgdUsers.CurrentPageIndex=0;			
					performSearch(txtCriterio.Text,cboCriterio.SelectedItem.Value);
					Response.Write("<script language='javascript'>alert('La cuenta ["+_userLogin+"] del usuario ["+_userName+"] ha sido desconectada !')</script>");
				}
				else
				{
					Response.Write("<script language='javascript'>alert('La cuenta ["+_userLogin+"] del usuario ["+_userName+"] no puede ser desconectada ya que esta en uso !')</script>");
				}
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

		private void dgdUsers_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
