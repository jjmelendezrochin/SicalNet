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
	/// Summary description for EditUsers.
	/// </summary>
	public class EditUsers : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtLogin;
		protected System.Web.UI.WebControls.Button btnSalvar;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList cboPlanta;
		protected System.Web.UI.WebControls.DropDownList cboArea;
		protected System.Web.UI.WebControls.DropDownList cboPerfil;
		protected System.Web.UI.WebControls.TextBox txtTurno;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.CheckBox chkActivo;
		protected static string currentMode=string.Empty;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				BindEntryFields();
				if (currentMode=="Edicion")
					loadUserInfo();
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
			currentMode=Request.QueryString["Mode"].ToString();
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void loadUserInfo()
		{
			UsuarioInfo belUser = new UsuarioInfo(Request.QueryString["login"].ToString(),string.Empty,string.Empty,0,0,string.Empty,0,string.Empty,0,string.Empty,false);
			Usuario BLLUser = new Usuario();
			belUser=BLLUser.Load(belUser);

			txtNombre.Text=belUser.Nombre;
			txtLogin.Text=belUser.Login;
			txtTurno.Text=belUser.Turno.ToString();

			cboPlanta.Items.FindByValue(belUser.IdPlanta.ToString()).Selected=true;
			cboPerfil.Items.FindByValue(belUser.IdPerfil.ToString()).Selected=true;
			cboArea.Items.FindByValue(belUser.IdArea.ToString()).Selected=true;

			chkActivo.Checked=belUser.Activo;

			txtLogin.Enabled=false;
		}

		private void BindEntryFields()
		{
			//Code to populate Linea ComboBox
			SICALNet.BusinessLogicLayer.Planta plantInfo= new SICALNet.BusinessLogicLayer.Planta();
			IList plantaList= (IList) plantInfo.SelectPlanta();
			
			cboPlanta.DataSource = plantaList;
			cboPlanta.DataValueField = "IdPlanta";
			cboPlanta.DataTextField = "Description";
			cboPlanta.DataBind();

			//Code to populate Area Combo Box
			SICALNet.BusinessLogicLayer.Area Area = new SICALNet.BusinessLogicLayer.Area();
			IList AreaList = (IList) Area.SelectArea();
			
			cboArea.DataSource = AreaList;
			cboArea.DataValueField = "IdArea";
			cboArea.DataTextField = "Descripcion";
			cboArea.DataBind();

			//Code to populate Perfil Combo Box
			SICALNet.BusinessLogicLayer.Perfil Perfil = new SICALNet.BusinessLogicLayer.Perfil();
			IList PerfilList = (IList) Perfil.SelectPerfil();
			
			cboPerfil.DataSource = PerfilList;
			cboPerfil.DataValueField = "IdPerfil";
			cboPerfil.DataTextField = "Descripcion";
			cboPerfil.DataBind();
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("UsersList.aspx");
		}

		private void btnSalvar_Click(object sender, System.EventArgs e)
		{

			try
			{
				if (txtLogin.Text.Trim() == string.Empty)
				{
					string mensaje = "Proporcione el login del usuario";
					Mensajes.Advertencia(
						Page,
						mensaje
					);
					return;
				}
				if (txtNombre.Text.Trim()==string.Empty)
				{
					string mensaje = "Proporcione el nombre del usuario";
					Mensajes.Advertencia(
						Page,
						mensaje
					);
					return;
				}
				if (txtTurno.Text.Trim()==string.Empty)
				{
					string mensaje = "Proporcione el turno del usuario";
					Mensajes.Advertencia(
						Page,
						mensaje
					);
					return;
				}
			}
			catch (Exception errHand)
			{
				Mensajes.Advertencia(
					Page,
					errHand.Message
				);
			}

			if (currentMode=="Edicion")
			{
				updateUserInfo();
				//to display the msg for user
				string mensaje = "El usuario fue modificado exitosamente";

				Mensajes.Exito(
					Page,
					mensaje
				);
			}
			else
			{
				insertUserInfo();
				//to display the msg for user
				string mensaje = "El usuario fue creado exitosamente";

				Mensajes.Exito(
					Page,
					mensaje
				);
			}
		}

		private void insertUserInfo()
		{
			try
			{
				UsuarioInfo newUser = new UsuarioInfo(txtLogin.Text,string.Empty, txtNombre.Text.Trim(),Convert.ToInt32(txtTurno.Text.Trim()),Convert.ToInt32(cboPlanta.SelectedItem.Value),string.Empty,Convert.ToInt32(cboPerfil.SelectedItem.Value),String.Empty,Convert.ToInt32(cboArea.SelectedItem.Value),string.Empty,chkActivo.Checked);
				Usuario belUser = new Usuario();
				belUser.InsertUsuario(newUser);
			}
			catch (Exception errHand)
			{
				Mensajes.Advertencia(
					Page,
					errHand.Message
				);
			}
		}

		private void updateUserInfo()
		{
			try
			{
				UsuarioInfo newUser = new UsuarioInfo(txtLogin.Text,string.Empty, txtNombre.Text.Trim(),Convert.ToInt32(txtTurno.Text.Trim()),Convert.ToInt32(cboPlanta.SelectedItem.Value),string.Empty,Convert.ToInt32(cboPerfil.SelectedItem.Value),String.Empty,Convert.ToInt32(cboArea.SelectedItem.Value),string.Empty,chkActivo.Checked);
				Usuario belUser = new Usuario();
				belUser.UpdateUsuario(newUser);
			}
			catch (Exception errHand)
			{
				Mensajes.Advertencia(
					Page,
					errHand.Message
				);
			}
		}

	}
}
