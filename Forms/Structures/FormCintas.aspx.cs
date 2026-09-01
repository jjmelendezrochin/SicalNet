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
//References to SICALNet specific libraries
using SICALNet.BusinessEntities;
using SICALNet.BusinessLogicLayer;
using SICALNet.Utilities;

namespace UserInterface.Forms.Structures
{
	/// <summary>
	/// Summary description for FormCintas.
	/// </summary>
	public class FormCintas : System.Web.UI.Page
	{
		protected Controls.FormCintasGrid FormCintasGridControl;
		protected System.Web.UI.WebControls.Label lblFamProd;
		protected System.Web.UI.WebControls.Label lblPlanta;
		protected System.Web.UI.WebControls.Button cmdEditForm;
		protected System.Web.UI.WebControls.Button cmdCancelar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtMensajePiso;
		protected System.Web.UI.WebControls.ImageButton imgSaveMessage;
		protected System.Web.UI.WebControls.Label lblMaterial;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblCantidad;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button cmdSalir;
		protected System.Web.UI.HtmlControls.HtmlTable tableNewComponents;
		protected System.Web.UI.WebControls.DropDownList cboFamPdt;
		protected System.Web.UI.WebControls.DropDownList cboMedida;
		protected System.Web.UI.WebControls.Label lblMedida;
		protected System.Web.UI.WebControls.DropDownList cboPlanta;
		protected System.Web.UI.HtmlControls.HtmlTable tableComponents;
		protected System.Web.UI.WebControls.TextBox txtCodigoSAP;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected System.Web.UI.WebControls.DropDownList cboUnidad;
		protected System.Web.UI.WebControls.Button AddFormCintas;
		protected System.Web.UI.WebControls.ImageButton imgbtnFind;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Label Label2;

		ErrorHandling errFileWrite=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				//to fill the familia producto's description into the cbofampdt control
				SICALNet.BusinessLogicLayer.FamiliaProducto BLLFampdt=new SICALNet.BusinessLogicLayer.FamiliaProducto();
				IList RsFampdt=(IList) BLLFampdt.SelectFamiliaProducto();
				prcFillCombo(cboFamPdt,"Descripcion","IdFamiliaProductos",RsFampdt);
				//to fill the Medida into the cboMedida control
				SICALNet.BusinessLogicLayer.Medida BLLMedida=new SICALNet.BusinessLogicLayer.Medida();
				IList RsMedida=(IList) BLLMedida.LoadMedida();
				prcFillCombo(cboMedida,"Centimetros","IdMedida",RsMedida);
				//to fill the planta description in to the cboplanta control
				SICALNet.BusinessLogicLayer.Planta BLLPlant=new SICALNet.BusinessLogicLayer.Planta();
				IList RsPlanta=(IList) BLLPlant.SelectPlanta();
				prcFillCombo(cboPlanta,"Description","IdPlanta",RsPlanta);
				//to fill the Unidad description into the cboUnidad control
				SICALNet.BusinessLogicLayer.Unidad BLLUnidad=new SICALNet.BusinessLogicLayer.Unidad();
				IList RsUnidad=(IList) BLLUnidad.SelectUnidad();
				prcFillCombo(cboUnidad,"Descripcion","IdUnidad",RsUnidad);
			}
			else
			{
				Session["errMsg"]=string.Empty;
				prcErrorDisplay(string.Empty,"NoError");
			}
		}


		private Boolean checkpermisions()
		{
			SICALNet.BusinessEntities.UsuarioInfo objUsuarioInfo = new SICALNet.BusinessEntities.UsuarioInfo(User.Identity.Name);
			SICALNet.BusinessLogicLayer.Usuario objUsuario = new SICALNet.BusinessLogicLayer.Usuario();
			SICALNet.BusinessEntities.UsuarioInfo objUser = objUsuario.Load(objUsuarioInfo);

			PermisoPerfilInfo ppInfo = new PermisoPerfilInfo (objUser.IdPerfil,string.Empty,0);
			PermisoPerfil bllInfo = new PermisoPerfil();
			IList currentPermissionsList=bllInfo.Load(ppInfo);
			
			for (int i=0;i<currentPermissionsList.Count;i++)
			{
				ppInfo = (PermisoPerfilInfo) currentPermissionsList[i];
				
				if (ppInfo.IdModulo.IndexOf("3.")>=0)
				{
					if (ppInfo.IdModulo == "3.10") 
					{
						if (ppInfo.IdPermiso == 1)
						{
							BlockControlsToEdit(true);
							return true;
						}
						
						if (ppInfo.IdPermiso == 3)
						{
							BlockControlsToEdit(false);
							return false;
						}
					}
				}
			}
			return true;
			
		}

		private void BlockControlsToEdit(Boolean Activar)
		{
		
			tableNewComponents.Visible = Activar;
			imgSaveMessage.Visible = Activar;
		}

		//to assign the data source and value into the dropdown combo
		private void prcFillCombo(DropDownList cboCntl,string txtFiled,string valField,IList RsCboFill)
		{
			cboCntl.DataSource=RsCboFill;
			cboCntl.DataValueField=valField;
			cboCntl.DataTextField=txtFiled;
			cboCntl.DataBind();
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
			this.cmdEditForm.Click += new System.EventHandler(this.cmdEditForm_Click);
			this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
			this.imgSaveMessage.Click += new System.Web.UI.ImageClickEventHandler(this.imgSaveMessage_Click);
			this.txtCodigoSAP.TextChanged += new System.EventHandler(this.txtCodigoSAP_TextChanged);
			this.imgbtnFind.Click += new System.Web.UI.ImageClickEventHandler(this.imgbtnFind_Click);
			this.AddFormCintas.Click += new System.EventHandler(this.AddFormCintas_Click);
			this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
			this.ID = "FormCintasForm";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

//		private void cmdCancelC_Click(object sender, System.EventArgs e)
//		{
//			FormAditClear();
//		}

		private void AddFormCintas_Click(object sender, System.EventArgs e)
		{
			try
			{
				//to get an instance from validation
				Validation vdtFormCintas = new Validation();

				if (FormCintasGridControl.funGetCurrentRow() > 0){
					prcErrorDisplay("Se encuentra en modo de edición. cancele el modo de edición para continuar","Error");
					return;}
				//to check colorid whether its correct or not
				if (vdtFormCintas.IsPositiveNumber(txtCantidad.Text)==false){
					prcErrorDisplay("La cantidad debe ser un número positivo","Error");
					return;}
					//throw new Exception("candidad should be a positive real number");

				if (txtCodigoSAP.Text.Trim() == String.Empty){
					prcErrorDisplay("Debe de capturar el código del material código SAP","Error");
					return;}
					//throw new Exception("CodigoSAP Should Not be Empty");
			
				if (txtCodigoSAP.Text.Trim() != String.Empty)
				{
					MaterialInfo mInfo = new MaterialInfo(txtCodigoSAP.Text.Trim(), String.Empty);
					SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();

					if (!Material.isExistMaterial(mInfo)){
						prcErrorDisplay("El código SAP del material no se encuentra en el catalogo de Materiales","Error");
						return;}
				}

				//to assign the control box values into variables
				int IdFamPdt = Convert.ToInt32(cboFamPdt.SelectedItem.Value);
				int IdMedida = Convert.ToInt32(cboMedida.SelectedItem.Value);
				int IdPlanta= Convert.ToInt32(cboPlanta.SelectedItem.Value);
				string CodigoSAP= txtCodigoSAP.Text;
				float Cantidad=(float)Convert.ToDecimal(txtCantidad.Text);
					if(Cantidad<=0){
						prcErrorDisplay("La cantidad debe ser mayor que cero","Error");
						return;}
						//throw new Exception("Cantidad Id Should be greater than Zero");

				int IdUnidad=Convert.ToInt32(cboUnidad.SelectedItem.Value);

				//to assign the color info into business entity lager
				FormCintasInfo BEFormCintas= new FormCintasInfo(IdFamPdt,IdMedida,IdPlanta,CodigoSAP,string.Empty,Cantidad,IdUnidad,string.Empty);

				//to get an instance from business logic layer
				SICALNet.BusinessLogicLayer.FormCintas BLLFormCintas= new SICALNet.BusinessLogicLayer.FormCintas();
				//to Call the Insert FormCintas method
				BLLFormCintas.InsertFormCintas(BEFormCintas);
				//to fill the datagrid
				FormCintasGridControl.BindGrid(IdFamPdt,IdMedida,IdPlanta,checkpermisions());
				//to clear all the textbox values
				FormAditClear();
				prcErrorDisplay("El componente para la formulacion se agrego con éxito","Success");
				txtCodigoSAP.Text=string.Empty; txtCantidad.Text=string.Empty; txtDescripcion.Text=string.Empty;cboUnidad.SelectedIndex=0;
				//throw new Exception("Form Cintas is added successfully");
			}
			catch(System.Data.SqlClient.SqlException errHand)
			{
				prcErrorDisplay(errHand,"El componente que desea agregar ya pertenece a la formulación.","Warning");
			}
			catch (Exception errHand)
			{
				string mensaje =
					errHand.Message
						.Replace("\\", "\\\\")
						.Replace("'", "\\'")
						.Replace("\r", "")
						.Replace("\n", "\\n");

				string ScriptString =
					"<script language='javascript'>" +
					"SicalAlert.mostrar(" +
					"'" + mensaje + "'," +
					"'Aviso'" +
					");" +
					"</script>";

				ClientScript.RegisterStartupScript(
					this.GetType(),
					"ErrorValidacion",
					ScriptString
				);
			}
		}

		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(string strMessage,string errStatus)
		{
			switch (errStatus)
			{
				case "Error":
					//to display the error msg
					lblErrorMsg.Text=strMessage;
					Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+ "alert('"+ strMessage +"')"+ "<" + "/script>");
					lblErrorMsg.ForeColor=Color.White;
					lblErrorMsg.BackColor=Color.Red;
					break;
				case "NoError":
					//to clear label box
					lblErrorMsg.ForeColor=Color.White;
					lblErrorMsg.BackColor=Color.White;
					break;
				case "Success":
					//to display the success msg
					lblErrorMsg.Text=strMessage;
					lblErrorMsg.ForeColor=Color.White;
					lblErrorMsg.BackColor=Color.Green;
					break;
			}
		}

		private void imgSaveMessage_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				string message=txtMensajePiso.Text.Trim();
				SICALNet.BusinessEntities.FormCintasInfo BELMessage= new SICALNet.BusinessEntities.FormCintasInfo(message,Convert.ToInt32(cboFamPdt.SelectedItem.Value),Convert.ToInt32(cboMedida.SelectedItem.Value),Convert.ToInt32(cboPlanta.SelectedItem.Value));
				SICALNet.BusinessLogicLayer.FormCintas BLLMessage = new SICALNet.BusinessLogicLayer.FormCintas();
				BLLMessage.AddMessage(BELMessage);
			}
			catch
			{
				throw;
			}
		}

		private void FormAditClear()
		{
			txtCodigoSAP.Text=string.Empty;
			txtCantidad.Text=string.Empty;
			lblErrorMsg.Text = "";
		}


		private void imgbtnFind_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
					RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('FindMaterial.aspx?Form=FormCintasForm&CtrlName=txtCodigoSAP&CtrlName2=txtDescripcion&flag=1','anycontent','width=600,height=400,left=100, top=150,status,scrollbars=yes'); </script>");
			}
			catch(Exception ex)
			{
				lblErrorMsg.ForeColor=Color.Red;
				lblErrorMsg.Text=ex.Message;
				txtDescripcion.Text=string.Empty;
			}
		}

		private void cmdEditForm_Click(object sender, System.EventArgs e)
		{
			FormCintasGridControl.BindGrid(Convert.ToInt32(cboFamPdt.SelectedItem.Value),Convert.ToInt32(cboMedida.SelectedItem.Value),Convert.ToInt32(cboPlanta.SelectedItem.Value),checkpermisions());
			txtMensajePiso.Text=LoadMensaje(Convert.ToInt32(cboFamPdt.SelectedItem.Value),Convert.ToInt32(cboMedida.SelectedItem.Value),Convert.ToInt32(cboPlanta.SelectedItem.Value));
			enableMasterControls(false);

			cmdSalir.Visible = true;
		}

		private string LoadMensaje(int IdFamiliaProducto, int IdMedida, int IdPlanta)
		{
			SICALNet.BusinessEntities.FormCintasInfo BELmensaje = new SICALNet.BusinessEntities.FormCintasInfo(string.Empty,IdFamiliaProducto,IdMedida,IdPlanta);
			SICALNet.BusinessLogicLayer.FormCintas BLLmensaje = new SICALNet.BusinessLogicLayer.FormCintas();
			BELmensaje=BLLmensaje.LoadMessage(BELmensaje);
			return BELmensaje.Mensaje;
		}

		private void cmdCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("..\\NewMenu.aspx");
		}

		private void enableMasterControls(bool enabled)
		{
			lblFamProd.Enabled=enabled;
			lblMedida.Enabled=enabled;
			lblPlanta.Enabled=enabled;
			cboFamPdt.Enabled=enabled;
			cboMedida.Enabled=enabled;
			cboPlanta.Enabled=enabled;

			cmdEditForm.Enabled=enabled;
			cmdCancelar.Enabled=enabled;

			tableComponents.Visible=!enabled;
			//tableNewComponents.Visible=!enabled;

		}

		private void cmdSalir_Click(object sender, System.EventArgs e)
		{
			enableMasterControls(true);
			lblErrorMsg.Text=string.Empty;
			//FormCintasGridControl.lblErrorMsg.Text=string.Empty;
			cmdSalir.Visible = false;
		}

		private void txtCodigoSAP_TextChanged(object sender, System.EventArgs e)
		{
			string theCodigoSAP=txtCodigoSAP.Text.Trim();
			if (theCodigoSAP!=string.Empty)
			{
				MaterialInfo mInfo = new MaterialInfo(theCodigoSAP, String.Empty);
				SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();
			
				if (!Material.isExistMaterial(mInfo))
				{
					txtDescripcion.Text=string.Empty;
					prcErrorDisplay(null, string.Format("El sistema no pudo encontrar el material -{0}- en el catálogo",theCodigoSAP),"Warning");
					return;
				}
				else
				{
					MaterialInfo material = new MaterialInfo(theCodigoSAP,string.Empty);
					SICALNet.BusinessLogicLayer.Material materialBLL = new SICALNet.BusinessLogicLayer.Material();
					material=materialBLL.SelectMaterial(material);
					txtDescripcion.Text=material.Descripcion;

					prcErrorDisplay(null,string.Empty,"NoError");
				}
			}
			else
			{
				prcErrorDisplay(null,string.Empty,"NoError");			
			}		
		}

		private void prcErrorDisplay(Exception errHnd, string Message, string ErrStatus)
		{
			if (ErrStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("User Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
				lblErrorMsg.Text=errHnd.Message;
				Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+ "alert('"+ Message +"')"+ "<" + "/script>");
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;
			}
			else if (ErrStatus=="NoError")
			{
				//to clear label box
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.White;
			}
			else if (ErrStatus=="Warning")
			{
				//to display the warning msg
				lblErrorMsg.Text=Message;
				Page.RegisterStartupScript("alert", string.Format("<script language='JavaScript'>alert('{0}')</script>",Message));
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;
			}
			else if (ErrStatus=="Success")
			{
				//to display the success msg
				lblErrorMsg.Text=Message;
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;
			}

			return;
		}


	}
}