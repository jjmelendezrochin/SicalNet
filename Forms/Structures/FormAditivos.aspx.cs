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
	/// Summary description for FormAditivos.
	/// </summary>
	public class FormAditivos : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl divError;
		protected Controls.FormAditivosGrid FormAditivosGridControl;
		protected System.Web.UI.WebControls.ImageButton imgbtnFind;
		protected System.Web.UI.WebControls.Label lblColor;
		protected System.Web.UI.WebControls.Button cmdEditForm;
		protected System.Web.UI.WebControls.Button cmdCancelar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtMensajePiso;
		protected System.Web.UI.WebControls.ImageButton imgSaveMessage;
		protected System.Web.UI.WebControls.Label lblMaterial;
		protected System.Web.UI.WebControls.Label lblCantidad;
		protected System.Web.UI.WebControls.Button cmdSalir;
		protected System.Web.UI.HtmlControls.HtmlTable tableNewComponents;
		protected System.Web.UI.WebControls.DropDownList cboColor;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.DropDownList cboEspesor;
		protected System.Web.UI.WebControls.DropDownList cboPlanta;
		protected System.Web.UI.WebControls.Label lblPlanta;
		protected System.Web.UI.WebControls.Label lblLinea;
		protected System.Web.UI.WebControls.Label lblEspesor;
		protected System.Web.UI.HtmlControls.HtmlTable tableComponents;
		protected System.Web.UI.WebControls.TextBox txtCodigoSAP;
		protected System.Web.UI.WebControls.TextBox txtdepeso;
		protected System.Web.UI.WebControls.Button AddFormAditivos;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtVersion;
		protected System.Web.UI.WebControls.Label Label3;

		ErrorHandling errFileWrite=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					//to fill the espesorid  into the cboespesor control
					SICALNet.BusinessLogicLayer.Espesor BLLEspesor=new SICALNet.BusinessLogicLayer.Espesor();
					IList RsEspesor=(IList) BLLEspesor.LoadEspesor();
					prcFillCombo(cboEspesor,"Centimetros","IdEspesor",RsEspesor);

					//to fill the planta description in to the cboplanta control
					SICALNet.BusinessLogicLayer.Planta BLLPlant=new SICALNet.BusinessLogicLayer.Planta();
					IList RsPlanta=(IList) BLLPlant.SelectPlanta();
					prcFillCombo(cboPlanta,"Description","IdPlanta",RsPlanta);

					//to fill the ColorId into the cboColor control
					SICALNet.BusinessLogicLayer.Colour BLLColor=new SICALNet.BusinessLogicLayer.Colour();
					IList RsColor=(IList) BLLColor.SelectColour();
					prcFillCombo(cboColor,"IdColour","IdColour",RsColor);

					SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
					SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
					theUser  = BLLUser.Load(theUser);

					//to fill the Linea description into the cboLinea control
					SICALNet.BusinessLogicLayer.LineaProduccion BLLLine=new SICALNet.BusinessLogicLayer.LineaProduccion();
					IList RsLine=(IList) BLLLine.SelectLinePdt(theUser);
					prcFillCombo(cboLinea,"Description","IdLinea",RsLine);


				}
				Session["errMsg"]=string.Empty;
			}
			catch(Exception errHand)
			{
				prcErrorDisplay(errHand,"Error al cargar datos de la pantalla inicial","Error");			
			}
		}

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
			this.AddFormAditivos.Click += new System.EventHandler(this.AddFormAditivos_Click);
			this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
			this.ID = "FormAditivosForm";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

//		private void cmdCancelC_Click(object sender, System.EventArgs e)
//		{
//			FormAditClear();
//			//Response.Redirect("../Menu.Aspx",true);
//		}

		private void AddFormAditivos_Click(object sender, System.EventArgs e)
		{
			try
			{
				//to get an instance from validation
				Validation vdtFormAditivos = new Validation();

				if (FormAditivosGridControl.funGetCurrentRow() > 0)
				{
					lblErrorMsg.Text = "Se encuentra en modo de edición. Cancel el modo de edición para continuar";
					return;
				}
					//throw new Exception("You are in the Edit Mode. Please cancel the edit mode");
				//to check colorid whether its correct or not
				if (vdtFormAditivos.IsPositiveNumber(txtdepeso.Text)==false)
				{
					lblErrorMsg.Text = "El peso debe de ser un número positivo";
					return;
					//throw new Exception("de peso should be a positive real number");
				}

				//to check colorid whether its correct or not
				if (vdtFormAditivos.IsPositiveNumber(txtVersion.Text)==false)
				{
					lblErrorMsg.Text = "La versión debe de ser un número positivo";
					return;
					//throw new Exception("de peso should be a positive real number");
				}


				if (txtCodigoSAP.Text.Trim() == String.Empty)
				{
					lblErrorMsg.Text = "El Codigo SAP del material que desea agregar a la formulación es obligatorio";
					return;
					//throw new Exception("CodigoSAP Should Not be Empty");
				}
			
				if (txtCodigoSAP.Text.Trim() != String.Empty)
				{
					MaterialInfo mInfo = new MaterialInfo(txtCodigoSAP.Text.Trim(), String.Empty);
					SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();

					if (!Material.isExistMaterial(mInfo))
					{
						lblErrorMsg.Text = "El codigo SAP no se encuentra en el catalogo de Materiales";
						return;
						//throw new Exception("Given CodigoSAP Value Does not Exist in Material Table");
					}
				}

				//to assign the control box values into variables
				string IdColor = cboColor.SelectedItem.Text;
				int IdPlanta= Convert.ToInt32(cboPlanta.SelectedItem.Value);
				string IdEspesor=cboEspesor.SelectedItem.Value;
				int IdLinea = Convert.ToInt32(cboLinea.SelectedItem.Value);
				string CodigoSAP= txtCodigoSAP.Text.Trim();
				float depeso=Convert.ToSingle(txtdepeso.Text);
				int version=Convert.ToInt32(txtVersion.Text);

				//to assign the color info into business entity lager
				FormAditivosInfo BEFormAditivos= new FormAditivosInfo(IdColor,IdEspesor,IdLinea,IdPlanta,CodigoSAP,string.Empty,depeso,true,string.Empty,version);

				//to get an instance from business logic layer
				SICALNet.BusinessLogicLayer.FormAditivos BLLFormAditivos= new SICALNet.BusinessLogicLayer.FormAditivos();
				//to Call the Insert FormAditivos method
				BLLFormAditivos.InsertFormAditivos(BEFormAditivos);
				
				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Alta nueva formulacion aditivos: " + IdColor + " codigo SAP: "+ CodigoSAP,this.User.Identity.Name.ToString());


				//to fill the datagrid
				FormAditivosGridControl.BindGrid(IdColor,IdEspesor,IdLinea,IdPlanta);
				//to clear all the textbox values
				FormAditClear();

				lblErrorMsg.Text = "El componente fue agregado al catalogo exitosamente";
				//throw new Exception("Form Aditivaos is added successfully");
			}
			catch(System.Data.SqlClient.SqlException errHand)
			{
				prcErrorDisplay(errHand,"¡ El componente que desea agregar ya pertenece a la formulación !","Warning");			
			}
			catch
			{
				// prcErrorDisplay(errHand,"El identificador ya esta en uso para otro componente en este catalogo","Error");			

				throw;
			}
		}

		private void FormAditClear()
		{
			txtCodigoSAP.Text=string.Empty;
			txtdepeso.Text=string.Empty;
		}

		private void imgbtnFind_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
					RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('FindMaterial.aspx?Form=FormAditivosForm&CtrlName=txtCodigoSAP&CtrlName2=txtDescripcion&flag=1','anycontent','width=600,height=400,left=100, top=150,status,scrollbars=yes'); </script>");
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
			enableMasterControls(false);
			FormAditivosGridControl.BindGrid(cboColor.SelectedItem.Value,cboEspesor.SelectedItem.Value,Convert.ToInt32(cboLinea.SelectedItem.Value),Convert.ToInt32(cboPlanta.SelectedItem.Value));
			FormAditivosGridControl.setmatini(cboColor.SelectedItem.Value,cboEspesor.SelectedItem.Value,Convert.ToInt32(cboLinea.SelectedItem.Value),Convert.ToInt32(cboPlanta.SelectedItem.Value),checkpermisions());
			txtMensajePiso.Text=LoadMensaje(cboColor.SelectedItem.Value,cboEspesor.SelectedItem.Value,Convert.ToInt32(cboLinea.SelectedItem.Value),Convert.ToInt32(cboPlanta.SelectedItem.Value));
			cmdSalir.Visible = true;
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
					if (ppInfo.IdModulo == "3.7") 
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
		}

		private void enableMasterControls(bool enabled)
		{
			lblColor.Enabled=enabled;
			lblEspesor.Enabled=enabled;
			lblLinea.Enabled=enabled;
			lblPlanta.Enabled=enabled;
			cboColor.Enabled=enabled;
			cboEspesor.Enabled=enabled;
			cboLinea.Enabled=enabled;
			cboPlanta.Enabled=enabled;

			cmdEditForm.Enabled=enabled;
			cmdCancelar.Enabled=enabled;

			tableComponents.Visible=!enabled;
			tableNewComponents.Visible=!enabled;

		}


		private string LoadMensaje(string idColor, string idEspesor, int idLinea, int IdPlanta)
		{
			SICALNet.BusinessEntities.FormAditivosInfo BELmensaje = new SICALNet.BusinessEntities.FormAditivosInfo(idColor,idEspesor,idLinea,IdPlanta);
			SICALNet.BusinessLogicLayer.FormAditivos BLLmensaje = new SICALNet.BusinessLogicLayer.FormAditivos();
			BELmensaje=BLLmensaje.LoadMessage(BELmensaje);
			return BELmensaje.Mensaje;
		}

		private void imgSaveMessage_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				string message=txtMensajePiso.Text.Trim();
				SICALNet.BusinessEntities.FormAditivosInfo  BELMessage= new SICALNet.BusinessEntities.FormAditivosInfo(cboColor.SelectedItem.Value,cboEspesor.SelectedItem.Value,Convert.ToInt32(cboLinea.SelectedItem.Value),Convert.ToInt32(cboPlanta.SelectedItem.Value),string.Empty,string.Empty,0,false,message,0);
				SICALNet.BusinessLogicLayer.FormAditivos BLLMessage = new SICALNet.BusinessLogicLayer.FormAditivos();
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

		private void prcErrorDisplay(Exception errHnd, string Message, string ErrStatus)
		{
			if (ErrStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("User Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
				lblErrorMsg.Text=errHnd.Message;
				string mensaje = Message.Replace("\\", "\\\\").Replace("'", "\\'");

				Page.RegisterStartupScript(
					"alert",
					"<script language='JavaScript'>" +
					"SicalAlert.mostrar('" + mensaje + "', 'advertencia');" +
					"</script>"
				);
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
				string mensaje = Message.Replace("\\", "\\\\").Replace("'", "\\'");

				Page.RegisterStartupScript(
					"alert",
					"<script language='JavaScript'>" +
					"SicalAlert.mostrar('" + mensaje + "', 'advertencia');" +
					"</script>"
				);
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

		private void cmdSalir_Click(object sender, System.EventArgs e)
		{
			cboColor.SelectedIndex = 0;
			cboEspesor.SelectedIndex=0;
			cboLinea.SelectedIndex=0;
			cboPlanta.SelectedIndex = 0;
			txtCodigoSAP.Text = string.Empty;
			txtDescripcion.Text=string.Empty;
			txtdepeso.Text = string.Empty;
			enableMasterControls(true);
			
			//Clear any error message
			lblErrorMsg.Text=string.Empty;
//			FormAditivosGridControl.lblErrorMsg.Text=string.Empty;			

			cmdSalir.Visible = false;
		}

		private void cmdCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("..\\NewMenu.aspx");
		}

	}
}