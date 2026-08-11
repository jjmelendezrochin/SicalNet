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
using SICALNet.Utilities;

namespace UserInterface.Forms.Structures
{
	/// <summary>
	/// Summary description for FormPresent.
	/// </summary>
	public class FormPresentacion : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cmdEditForm;
		protected System.Web.UI.WebControls.Button cmdCancelar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtMensajePiso;
		protected System.Web.UI.WebControls.ImageButton imgSaveMessage;
		protected System.Web.UI.WebControls.Label lblMaterial;
		protected System.Web.UI.WebControls.TextBox txtCodigoSAP;
		protected System.Web.UI.WebControls.ImageButton cmdFindMaterial;
		protected System.Web.UI.WebControls.Label lblCantidad;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected System.Web.UI.WebControls.Label lblUnidadMedida;
		protected System.Web.UI.WebControls.DropDownList cboUnidad;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.Button cmdSalir;
		protected System.Web.UI.WebControls.DropDownList cboIdPresentacion;
		protected System.Web.UI.WebControls.DropDownList cboIdMedida;
		protected System.Web.UI.WebControls.DropDownList cboIdPlanta;
		protected System.Web.UI.HtmlControls.HtmlTable tableComponents;
		protected System.Web.UI.WebControls.Label lblPresentacion;
		protected System.Web.UI.WebControls.Label lblMedida;
		protected System.Web.UI.WebControls.Label lblPlanta;
		protected System.Web.UI.HtmlControls.HtmlTable tableNewComponents;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected Controls.FormPresentacionGrid gridFormPresentacion;
		protected System.Web.UI.WebControls.Label Label2;

		//to get an instance for utility-error handler
		ErrorHandling errFileWrite=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				BindEntryFields();
			}
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
			this.cmdEditForm.Click += new System.EventHandler(this.cmdEditForm_Click);
			this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
			this.imgSaveMessage.Click += new System.Web.UI.ImageClickEventHandler(this.imgSaveMessage_Click);
			this.txtCodigoSAP.TextChanged += new System.EventHandler(this.txtCodigoSAP_TextChanged);
			this.cmdFindMaterial.Click += new System.Web.UI.ImageClickEventHandler(this.cmdFindMaterial_Click);
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
			this.ID = "FormPresentaciones";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


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
					if (ppInfo.IdModulo == "3.9") 
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

		private void BindEntryFields()
		{
			//Code to populate Presentacion Combo Box
			SICALNet.BusinessLogicLayer.Presentacion Presentacion = new SICALNet.BusinessLogicLayer.Presentacion();
			IList PresentacionList = (IList) Presentacion.SelectPresentacion();
			
			cboIdPresentacion.DataSource = PresentacionList;
			cboIdPresentacion.DataValueField = "IdPresentacion";
			cboIdPresentacion.DataTextField = "Descripcion";
			cboIdPresentacion.DataBind();

			//Code to populate Medida Combo Box
			SICALNet.BusinessLogicLayer.Medida Medida = new SICALNet.BusinessLogicLayer.Medida();
			IList MedidaList = (IList) Medida.LoadMedida();
			
			cboIdMedida.DataSource = MedidaList;
			cboIdMedida.DataValueField = "IdMedida";
			cboIdMedida.DataTextField = "Centimetros";
			cboIdMedida.DataBind();

			//Code to populate Planta Combo box
			SICALNet.BusinessLogicLayer.Planta Plant = new SICALNet.BusinessLogicLayer.Planta();
			IList PlantaList = (IList) Plant.SelectPlanta();
			
			cboIdPlanta.DataSource = PlantaList;
			cboIdPlanta.DataValueField = "IdPlanta";
			cboIdPlanta.DataTextField = "Description";
			cboIdPlanta.DataBind();

			//Code to populate Form Presentacion Combo box
			SICALNet.BusinessLogicLayer.Unidad Unidad = new SICALNet.BusinessLogicLayer.Unidad();
			IList UnidadList = (IList) Unidad.SelectUnidad();
			
			cboUnidad.DataSource = UnidadList;
			cboUnidad.DataValueField = "IdUnidad";
			cboUnidad.DataTextField = "Descripcion";
			cboUnidad.DataBind();		
		}

		private void cmdFindMaterial_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(txtCodigoSAP.Text!=string.Empty||txtCodigoSAP.Text!="")
				{
					MaterialInfo mInfo = new MaterialInfo(txtCodigoSAP.Text,string.Empty);
					SICALNet.BusinessLogicLayer.Material blMaterial= new SICALNet.BusinessLogicLayer.Material();
					MaterialInfo mInfo1 = new MaterialInfo();
					mInfo1=(MaterialInfo)blMaterial.SelectMaterial(mInfo);
					if(mInfo1.Descripcion.ToString()=="")
						throw new Exception("The Entered CodigoSAP is invalid please use Find");
					txtDescripcion.Text=mInfo1.Descripcion.ToString();
				}
				else
				{
					RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('FindMaterial.aspx?Form=FormPresentaciones&CtrlName=txtCodigoSAP&CtrlName2=txtDescripcion&flag=1','anycontent','width=600,height=400,left=100, top=150,status,scrollbars=yes'); </script>");
				}
			}
			catch(Exception ex)
			{
				lblErrorMsg.ForeColor=Color.Red;
				lblErrorMsg.Text=ex.Message;
				txtDescripcion.Text=string.Empty;
			}
		}

		private void cmdCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("..\\NewMenu.aspx");		
		}

		private void enableMasterControls(bool enabled)
		{
			lblPresentacion.Enabled=enabled;
			lblPlanta.Enabled=enabled;
			lblMedida.Enabled=enabled;
			cboIdPresentacion.Enabled=enabled;
			cboIdPlanta.Enabled=enabled;
			cboIdMedida.Enabled=enabled;

			cmdEditForm.Enabled=enabled;
			cmdCancelar.Enabled=enabled;

			tableComponents.Visible=!enabled;
			//tableNewComponents.Visible=!enabled;

		}

		private void cmdEditForm_Click(object sender, System.EventArgs e)
		{
			gridFormPresentacion.BindGrid(cboIdPresentacion.SelectedItem.Value,Convert.ToInt32(cboIdMedida.SelectedItem.Value),Convert.ToInt32(cboIdPlanta.SelectedItem.Value),checkpermisions());		
			txtMensajePiso.Text=LoadMensaje(cboIdPresentacion.SelectedItem.Value,Convert.ToInt32(cboIdMedida.SelectedItem.Value),Convert.ToInt32(cboIdPlanta.SelectedItem.Value));
			enableMasterControls(false);
			cmdSalir.Visible = true;
		}

		private string LoadMensaje(string idPresentacion,int idMedida,int idPlanta)
		{
			SICALNet.BusinessEntities.FormPresentacionInfo BELmensaje = new SICALNet.BusinessEntities.FormPresentacionInfo(idPresentacion,idMedida,idPlanta);
			SICALNet.BusinessLogicLayer.FormPresentacion BLLmensaje = new SICALNet.BusinessLogicLayer.FormPresentacion();
			BELmensaje=BLLmensaje.LoadMessage(BELmensaje);
			return BELmensaje.Mensaje;
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			Validation pltVdlt = new Validation();

			string IdPresentacion,CodigoSAP;
			int IdMedida,IdPlanta,IdUnidad;
			float Cantidad;

			//UserInterface Validations

			// to check Presentacion List whether its Empty or not
			try {IdPresentacion = cboIdPresentacion.SelectedItem.Value;}
			catch
			{
				throw new Exception("Debe seleccionar la presentación");
			}

			// to check Medida List - whether its Empty or Not
			try {IdMedida = Convert.ToInt32(cboIdMedida.SelectedItem.Value);}
			catch
			{
				throw new Exception("Debe seleccionar la medida");
			}
			
			// to check Planta List whether its Empty or not
			try {IdPlanta = Convert.ToInt32(cboIdPlanta.SelectedItem.Value);}
			catch
			{
				throw new Exception("Debe de seleccionar un planta");
			}
			
			if (txtCodigoSAP.Text.Trim() == String.Empty)
			{
				prcErrorDisplay(null, "Debe de capturar el código del material código SAP","Warning");
				return;
			}

			
			if (txtCodigoSAP.Text.Trim() != String.Empty)
			{
				MaterialInfo mInfo = new MaterialInfo(txtCodigoSAP.Text.Trim(), String.Empty);
				SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();
			
				if (!Material.isExistMaterial(mInfo))
				{
					prcErrorDisplay(null, "El código SAP del material no se encuentra en el catalogo de Materiales","Warning");
					return;
				}
			}

			Cantidad=(float)Convert.ToDouble(txtCantidad.Text.Trim());

			if (Cantidad<=0)
			{
				prcErrorDisplay(null,"La cantidad debe ser mayor que cero");
				return;
			}

			if (!pltVdlt.IsNumber(txtCantidad.Text.Trim()))
			{
				prcErrorDisplay(null, "La cantidad debe ser un número", "Warning");
				return;
			}

			// to check Unidad List - whether its Empty or Not
			try {IdUnidad = Convert.ToInt32(cboUnidad.SelectedItem.Value);}
			catch
			{
				throw new Exception("Debe capturar la unidad de medida");
			}

			try
			{
				IdPresentacion = cboIdPresentacion.SelectedItem.Value;
				IdMedida  = Convert.ToInt32(cboIdMedida.SelectedItem.Value);
				IdPlanta  = Convert.ToInt32(cboIdPlanta.SelectedItem.Value);
			
				CodigoSAP = txtCodigoSAP.Text.Trim();
				Cantidad = (float)Convert.ToDouble(txtCantidad.Text.Trim());
				IdUnidad  = Convert.ToInt32(cboUnidad.SelectedItem.Value);

				FormPresentacionInfo pInfo = new FormPresentacionInfo(IdPresentacion, string.Empty, IdMedida, string.Empty, IdPlanta, string.Empty, CodigoSAP,string.Empty, Cantidad, IdUnidad,string.Empty);
				SICALNet.BusinessLogicLayer.FormPresentacion FormPresentacion = new SICALNet.BusinessLogicLayer.FormPresentacion();
				FormPresentacion.InsertFormPresentacion(pInfo);
			
				gridFormPresentacion.BindGrid(IdPresentacion,IdMedida,IdPlanta,checkpermisions());

				prcErrorDisplay(null, "El registro se agrego con éxito","Success");

				txtCodigoSAP.Text = string.Empty;
				txtCantidad.Text = string.Empty;

			}
			catch
			{
				// prcErrorDisplay(errHand,"Error");

				throw;
			}		

			txtCodigoSAP.Text=string.Empty; txtCantidad.Text=string.Empty; txtDescripcion.Text=string.Empty; cboUnidad.SelectedIndex=0;
		}


		private void cmdSalir_Click(object sender, System.EventArgs e)
		{
			enableMasterControls(true);

			//clear any error message
			lblErrorMsg.Text=string.Empty;
			//gridFormPresentacion.lblErrorMsg.Text=string.Empty;
			cmdSalir.Visible = false;
		}

		#region ErrorHandling Section
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

		private void imgSaveMessage_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				string message=txtMensajePiso.Text.Trim();
				SICALNet.BusinessEntities.FormPresentacionInfo BELMessage= new SICALNet.BusinessEntities.FormPresentacionInfo(cboIdPresentacion.SelectedItem.Value,Convert.ToInt32(cboIdMedida.SelectedItem.Value),Convert.ToInt32(cboIdPlanta.SelectedItem.Value),message);
				SICALNet.BusinessLogicLayer.FormPresentacion  BLLMessage = new SICALNet.BusinessLogicLayer.FormPresentacion();
				BLLMessage.AddMessage(BELMessage);
			}
			catch
			{
				throw;
			}
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

		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("User Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
				lblErrorMsg.Text=errHnd.Message;
				Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+ "alert('"+ errHnd.Message +"')"+ "<" + "/script>");
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;
			}
			else if (errStatus=="NoError")
			{
				//to clear label box
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.White;
			}
			else
			{
				//to display the success msg
				lblErrorMsg.Text=errStatus;
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;
			}

			return;
		}
		#endregion

	}
}
