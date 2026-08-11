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
	/// Summary description for FormColor.
	/// </summary>
	public class FormColor : System.Web.UI.Page
	{
		protected Controls.FormColourGrid FormColorGridControl;
		protected System.Web.UI.WebControls.Label lblColor;
		protected System.Web.UI.WebControls.Label lblPlanta;
		protected System.Web.UI.WebControls.Button cmdEditForm;
		protected System.Web.UI.WebControls.Button cmdCancelar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ImageButton imgSaveMessage;
		protected System.Web.UI.WebControls.Label lblMaterial;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblCantidad;
		protected System.Web.UI.WebControls.Button cmdSalir;
		protected System.Web.UI.HtmlControls.HtmlTable tableNewComponents;
		protected System.Web.UI.HtmlControls.HtmlTable tableComponents;
		protected System.Web.UI.WebControls.ImageButton imgbtnFind;
		protected System.Web.UI.WebControls.TextBox txtPorcentaje;
		protected System.Web.UI.WebControls.TextBox txtCodigoSAP;
		protected System.Web.UI.WebControls.TextBox txtGrupo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button AddFormColor;
		protected System.Web.UI.WebControls.DropDownList cboColor;
		protected System.Web.UI.WebControls.DropDownList cboPlanta;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtMensajePiso;

		ErrorHandling errFileWrite=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				SICALNet.BusinessLogicLayer.Colour   bllColor=new SICALNet.BusinessLogicLayer.Colour();
				IList RsColor=(IList) bllColor.SelectColour();
				prcFillCombo(cboColor,"IdColour","",RsColor);

				SICALNet.BusinessLogicLayer.Planta  bllPlanta=new SICALNet.BusinessLogicLayer.Planta();
				IList RsPlanta=(IList) bllPlanta.SelectPlanta();
				prcFillCombo(cboPlanta,"Description","IdPlanta",RsPlanta);
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
					if (ppInfo.IdModulo == "3.6") 
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
			this.AddFormColor.Click += new System.EventHandler(this.AddFormColor_Click);
			this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void AddFormColor_Click(object sender, System.EventArgs e)
		{
			try
			{
				Validation fcVdlt=new Validation();
				
				// to check whether the data correct or not
				if (txtCodigoSAP.Text.Trim() == String.Empty)
				{
					prcErrorDisplay(null,"Debe capturar el codigo SAP, este dato es requerido");
					return;
				}
					//throw new Exception("CodigoSAP Should Not be Empty");
			
				if (txtCodigoSAP.Text.Trim() != String.Empty)
				{
					MaterialInfo mInfo = new MaterialInfo(txtCodigoSAP.Text.Trim(), String.Empty);
					SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();

					if (!Material.isExistMaterial(mInfo))
					{
						prcErrorDisplay(null,"El codigo SAP no se encontro en el catalogo de Materiales");
						return;
					}
						//throw new Exception("Given CodigoSAP Value Does not Exist in Material Table");
				}

				if (fcVdlt.IsPositiveNumber(txtPorcentaje.Text) == false)
				{
					prcErrorDisplay(null,"El porcentage debe ser un dato numerico");
					return;
				}
					//throw new Exception("Porcentaje should be Numeric");

				if (fcVdlt.IsInteger(txtGrupo.Text) == false)
				{
					prcErrorDisplay(null,"El Grupo debe ser un dato numerico");
					return;
				}
					//throw new Exception("Description should be Numeric");

				string IdColor=cboColor.SelectedItem.Text;	
				int IdPlanta=Convert.ToInt32(cboPlanta.SelectedItem.Value);
				string CodigoSAP=txtCodigoSAP.Text.Trim();
				double Porcentaje=Convert.ToDouble(txtPorcentaje.Text.Trim());
				int Grupo = Convert.ToInt32(txtGrupo.Text.Trim());

				//All components when created by default are activated - Daniel Novelo
				SICALNet.BusinessEntities.FormColorInfo belFormColor = new SICALNet.BusinessEntities.FormColorInfo(IdColor,IdPlanta,string.Empty,CodigoSAP,string.Empty,Porcentaje,Grupo,true); 
				SICALNet.BusinessLogicLayer.FormColor bllFormColor = new SICALNet.BusinessLogicLayer.FormColor();
				bllFormColor.InsertFormColor(belFormColor);

				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Alta nueva formulacion color: " + cboColor.SelectedItem.Text + " codigo SAP: "+ CodigoSAP,this.User.Identity.Name.ToString());


				FormColorGridControl.BindGrid(IdColor,IdPlanta,checkpermisions());

				prcErrorDisplay(null,"El componente se agrego exitosamente");

				txtCodigoSAP.Text=string.Empty; txtPorcentaje.Text=string.Empty; txtDescripcion.Text=string.Empty;

			}
			catch(System.Data.SqlClient.SqlException errHand)
			{
				prcErrorDisplay(errHand,"El componente que desea agregar ya pertenece a la formulación.");
			}
			catch
			{
				// prcErrorDisplay(errHand,"Error");

				throw;
			}
		}

		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("Información de catalogo de formulcaión de color",errHnd,Server.MapPath("..")+"\\ErrorLog\\Error"+DateTime.Now.Date.ToString("dd-MM-yy")+".txt");
				lblErrorMsg.Text=errHnd.Message;
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


		private void imgbtnFind_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('FindMaterial.aspx?Form=FormColorForm&CtrlName=txtCodigoSAP&CtrlName2=txtDescripcion&flag=1','anycontent','width=600,height=400,left=100, top=150,status,scrollbars=yes'); </script>");
			}
			catch(Exception ex)
			{
				lblErrorMsg.ForeColor=Color.Red;
				lblErrorMsg.Text=ex.Message;
				txtDescripcion.Text=string.Empty;
			}
		}

		private void cmdSalir_Click(object sender, System.EventArgs e)
		{
			cboColor.SelectedIndex = 0;
			cboPlanta.SelectedIndex = 0;
			txtCodigoSAP.Text = string.Empty;
			txtPorcentaje.Text = string.Empty;
			txtGrupo.Text = string.Empty;
			enableMasterControls(true);
			
			//Clear any error message
			lblErrorMsg.Text=string.Empty;
			//FormColorGridControl.lblErrorMsg.Text=string.Empty;
			cmdSalir.Visible = false;
		}

		private void cmdEditForm_Click(object sender, System.EventArgs e)
		{
			FormColorGridControl.BindGrid(cboColor.SelectedItem.Value,Convert.ToInt32(cboPlanta.SelectedItem.Value),checkpermisions());		
			txtMensajePiso.Text=LoadMensaje(cboColor.SelectedItem.Value,Convert.ToInt32(cboPlanta.SelectedItem.Value));
			
			enableMasterControls(false);
			cmdSalir.Visible = true;
		}

		private string LoadMensaje(string IdColor, int IdPlanta)
		{
			SICALNet.BusinessEntities.FormColorInfo BELmensaje = new SICALNet.BusinessEntities.FormColorInfo(IdColor,IdPlanta);
			SICALNet.BusinessLogicLayer.FormColor BLLmensaje = new SICALNet.BusinessLogicLayer.FormColor();
			BELmensaje=BLLmensaje.LoadMessage(BELmensaje);
			return BELmensaje.Mensaje;
		}

		private void enableMasterControls(bool enabled)
		{
			lblColor.Enabled=enabled;
			lblPlanta.Enabled=enabled;
			cboColor.Enabled=enabled;
			cboPlanta.Enabled=enabled;

			cmdEditForm.Enabled=enabled;
			cmdCancelar.Enabled=enabled;

			tableComponents.Visible=!enabled;
			//tableNewComponents.Visible=!enabled;

		}

		private void cmdCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("..\\NewMenu.aspx");
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

		private void imgSaveMessage_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				string message=txtMensajePiso.Text.Trim();
				SICALNet.BusinessEntities.FormColorInfo  BELMessage= new SICALNet.BusinessEntities.FormColorInfo(cboColor.SelectedItem.Value,Convert.ToInt32(cboPlanta.SelectedItem.Value),message);
				SICALNet.BusinessLogicLayer.FormColor BLLMessage = new SICALNet.BusinessLogicLayer.FormColor();
				BLLMessage.AddMessage(BELMessage);
			}
			catch
			{								
				throw;
			}
		}

	}
}
