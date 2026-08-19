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
using SICALNet.BusinessEntities;
using SICALNet.BusinessLogicLayer;

namespace UserInterface.Forms.Structures
{
	/// <summary>
	/// Summary description for FormPVC.
	/// </summary>
	public class FormPVC : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cboIdFamiliaProducto;
		protected System.Web.UI.WebControls.DropDownList cboIdMedida;
		protected System.Web.UI.WebControls.DropDownList cboIdEspesor;
		protected System.Web.UI.WebControls.DropDownList cboPlanta;
		protected System.Web.UI.WebControls.Label lblMaterial;
		protected System.Web.UI.WebControls.TextBox txtCodigoSAP;
		protected System.Web.UI.WebControls.ImageButton cmdFindMaterial;
		protected System.Web.UI.WebControls.Label lblCantidad;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected System.Web.UI.WebControls.Label lblUnidadMedida;
		protected System.Web.UI.WebControls.DropDownList cboUnidad;
		protected System.Web.UI.HtmlControls.HtmlTable tableComponents;
		protected System.Web.UI.HtmlControls.HtmlTable tableNewComponents;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ImageButton imgSaveMessage;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Label lblEspesor;
		protected System.Web.UI.WebControls.Label lblPlanta;
		protected System.Web.UI.WebControls.Label lblFproducto;
		protected System.Web.UI.WebControls.Label lblMedida;
		protected System.Web.UI.WebControls.Button cmdEditForm;
		protected System.Web.UI.WebControls.Button cmdCancelar;
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.TextBox txtMensajePiso;
		protected Controls.FormPVCGrid currentFormGrid;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblAcabado;
		protected System.Web.UI.WebControls.DropDownList cboIdAcabado;
		protected System.Web.UI.WebControls.Button cmdSalir;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Label lblLinea;

		//to get an instance for utility-error handler
		ErrorHandling errFileWrite=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.FamiliaProducto fpdsBL= new SICALNet.BusinessLogicLayer.FamiliaProducto();
				IList fpdsRs= (IList)fpdsBL.SelectFamiliaProducto();
				// To Load Data into to the cboIdFamiliaProducto Dropdown List from FamiliaProductos table
				cboIdFamiliaProducto.DataSource= fpdsRs;
				cboIdFamiliaProducto.DataValueField="IdFamiliaProductos";
				cboIdFamiliaProducto.DataTextField="Descripcion";
				cboIdFamiliaProducto.DataBind();

				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Medida mediBL= new SICALNet.BusinessLogicLayer.Medida();
				IList mediRs= (IList)mediBL.LoadMedida();
				// To Load Data into to the cboIdMedida Dropdown List from Medida table
				cboIdMedida.DataSource= mediRs;
				cboIdMedida.DataValueField="IdMedida";
				cboIdMedida.DataTextField="Centimetros";
				cboIdMedida.DataBind();

				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Espesor espBL= new SICALNet.BusinessLogicLayer.Espesor();
				IList espRs= (IList)espBL.LoadEspesor();
				// To Load Data into to the cboIdEspesor Dropdown List from Espesor table
				cboIdEspesor.DataSource= espRs;
				cboIdEspesor.DataValueField="IdEspesor";
				cboIdEspesor.DataTextField="Centimetros";
				cboIdEspesor.DataBind();

				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Planta pltBL= new SICALNet.BusinessLogicLayer.Planta();
				IList plantRs= (IList)pltBL.SelectPlanta();
				// To Load Data into to the cboPlanta Dropdown List from Planta table
				cboPlanta.DataSource= plantRs;
				cboPlanta.DataValueField="IdPlanta";
				cboPlanta.DataTextField="Description";
				cboPlanta.DataBind();
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Unidad unitBL= new SICALNet.BusinessLogicLayer.Unidad();
				IList unitRs= (IList)unitBL.SelectUnidad();
				// To Load Data into to the cboPlanta Dropdown List from Planta table
				cboUnidad.DataSource= unitRs;
				cboUnidad.DataValueField="IdUnidad";
				cboUnidad.DataTextField="Descripcion";
				cboUnidad.DataBind();
				/*
				 * MODIFICACIÓN
				 *	Procedimiento para poblar el nuevo ComboBox de Acabado
				 * AUTOR
				 *	Ing. Ariel Martínez Morales
				 * FECHA
				 *	27-07-2005
				 */
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Acabado acabadoBL= new SICALNet.BusinessLogicLayer.Acabado();
				IList acabadoRs= (IList)acabadoBL.SelectAcabado();
				// To Load Data into to the cboPlanta Dropdown List from Planta table
				this.cboIdAcabado.DataSource= acabadoRs;
				this.cboIdAcabado.DataValueField="IdAcabado";
				this.cboIdAcabado.DataTextField="Descripcion";
				this.cboIdAcabado.DataBind();


				/*
				 * AGREGAR LINEA
				 *	Procedimiento para poblar el nuevo ComboBox de Línea
				 * AUTOR
				 *	Ing. Juan José Meléndez 
				 * FECHA
				 *	24-06-2024
				 */

				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);

				SICALNet.BusinessLogicLayer.LineaProduccion  BRlinea = new SICALNet.BusinessLogicLayer.LineaProduccion();
				IList tipoRs= (IList)BRlinea.SelectLinePdt(theUser);				
				cboLinea.DataSource= tipoRs;
				cboLinea.DataValueField="IdLinea";
				cboLinea.DataTextField="Description";
				cboLinea.DataBind();	

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
			this.cmdEditForm.Click += new System.EventHandler(this.cmdEditForm_Click);
			this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
			this.imgSaveMessage.Click += new System.Web.UI.ImageClickEventHandler(this.imgSaveMessage_Click);
			this.txtCodigoSAP.TextChanged += new System.EventHandler(this.txtCodigoSAP_TextChanged);
			this.cmdFindMaterial.Click += new System.Web.UI.ImageClickEventHandler(this.cmdFindMaterial_Click);
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
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
					if (ppInfo.IdModulo == "3.8") 
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

		private void enableMasterControls(bool enabled)
		{
			lblFproducto.Enabled=enabled;
			lblMedida.Enabled=enabled;
			lblEspesor.Enabled=enabled;
			lblPlanta.Enabled=enabled;

			cboIdFamiliaProducto.Enabled=enabled;
			cboIdMedida.Enabled=enabled;
			cboIdEspesor.Enabled=enabled;
			cboPlanta.Enabled=enabled;
			this.lblAcabado.Enabled=enabled;
			this.cboIdAcabado.Enabled=enabled;
			this.lblLinea.Enabled=enabled;
			this.cboLinea.Enabled=enabled;
			
			cmdEditForm.Enabled=enabled;
			cmdCancelar.Enabled=enabled;

			tableComponents.Visible=!enabled;
			//tableNewComponents.Visible=!enabled;

		}

		private void cmdCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("..\\NewMenu.aspx");	
		}

		private void cmdEditForm_Click(object sender, System.EventArgs e)
		{
			currentFormGrid.BindGrid(Convert.ToInt32(cboIdFamiliaProducto.SelectedItem.Value),Convert.ToInt32(cboIdMedida.SelectedItem.Value),cboIdEspesor.SelectedItem.Value.ToString(),Convert.ToInt32(cboPlanta.SelectedItem.Value), int.Parse(this.cboIdAcabado.SelectedValue), int.Parse(this.cboLinea.SelectedValue),  checkpermisions());
			txtMensajePiso.Text=LoadMensaje(Convert.ToInt32(cboIdFamiliaProducto.SelectedItem.Value),Convert.ToInt32(cboIdMedida.SelectedItem.Value),cboIdEspesor.SelectedItem.Value.ToString(),Convert.ToInt32(cboPlanta.SelectedItem.Value), int.Parse(this.cboIdAcabado.SelectedValue), int.Parse(this.cboLinea.SelectedValue));
			enableMasterControls(false);

			cmdSalir.Visible = true;
		}

		private string LoadMensaje(int idFamiliaProducto,int idMedida,string idEspesor, int idPlanta, int idAcabado, int idLinea)
		{
			SICALNet.BusinessEntities.FormPVCInfo BELmensaje = new SICALNet.BusinessEntities.FormPVCInfo(idFamiliaProducto,idMedida,idEspesor,idPlanta, idAcabado, idLinea);
			SICALNet.BusinessLogicLayer.FormPVC BLLmensaje = new SICALNet.BusinessLogicLayer.FormPVC();
			BELmensaje=BLLmensaje.LoadMessage(BELmensaje);
			return BELmensaje.Mensaje;
		}

		private void cmdSalir_Click(object sender, System.EventArgs e)
		{
			enableMasterControls(true);
			lblErrorMsg.Text=string.Empty;
			//currentFormGrid.lblErrorMsg.Text=string.Empty;
			cmdSalir.Visible = false; 
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			Validation prdVdlt = new Validation();
			
			int IdFamiliaProducto,IdMedida,IdPlanta,IdUnidad,IdAcabado,IdLinea;						
			string IdEspesor, Mensaje;
			string CodigoSAP;
			int Cantidad;
			
			try
			{
				if((txtCantidad.Text.Trim()==""))
				{
					prcErrorDisplay(null,"Debe capturar la cantidad");
					return;
				}

				if ((prdVdlt.IsNumber(txtCantidad.Text.Trim())==false))
				{
					prcErrorDisplay(null,"La cantidad debe ser un dato numerico");
					return;
				}

				Cantidad=Convert.ToInt32(txtCantidad.Text.Trim());

				if (Cantidad<=0)
				{
					prcErrorDisplay(null,"La cantidad debe ser mayor que cero");
					return;
				}

				if((txtCodigoSAP.Text.Trim()==""))
				{
					prcErrorDisplay(null,"Debe de capturar el código del material código SAP");
					return;
				}

				if (txtCodigoSAP.Text.Trim() != String.Empty)
				{
					MaterialInfo mInfo = new MaterialInfo(txtCodigoSAP.Text.Trim(), String.Empty);
					SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();
			
					if (!Material.isExistMaterial(mInfo))
					{
						prcErrorDisplay(null, "El código SAP del material no se encuentra en el catalogo de Materiales");
						return;
					}
				}
				
				CodigoSAP= txtCodigoSAP.Text.Trim();
				IdFamiliaProducto=Convert.ToInt32(cboIdFamiliaProducto.SelectedItem.Value);
				string FamiliaProducto=cboIdFamiliaProducto.SelectedItem.Text;
				IdMedida=Convert.ToInt32(cboIdMedida.SelectedItem.Value);
				string Medida = cboIdMedida.SelectedItem.Text;
				IdEspesor=cboIdEspesor.SelectedItem.Value;
				IdPlanta=Convert.ToInt32(cboPlanta.SelectedItem.Value);
				IdUnidad=Convert.ToInt32(cboUnidad.SelectedItem.Value);
				Mensaje=txtMensajePiso.Text.Trim();
				/*
				 * MODIFICACIÓN
				 *	Variable nueva que corresponde al nuevo campo en la tabla FormPVC
				 * AUTOR
				 *	Ing. Ariel Martínez Morales
				 * FECHA
				 *	27-07-2005
				 */
				IdAcabado=int.Parse(this.cboIdAcabado.SelectedValue);
				IdLinea = int.Parse(this.cboLinea.SelectedValue);
				
				//to assign the FormPVC info into business entity lager
				FormPVCInfo pvcInfo = new FormPVCInfo(IdFamiliaProducto,IdMedida,IdEspesor,IdPlanta,CodigoSAP,string.Empty,(float)Cantidad,IdUnidad,string.Empty,Mensaje, IdAcabado, IdLinea,string.Empty);
				//to get an instance for business logic layer
				SICALNet.BusinessLogicLayer.FormPVC pvc = new SICALNet.BusinessLogicLayer.FormPVC();
				//to Call the Insert FormPVC Information method
				pvc.InsertFormPVC(pvcInfo);
			
				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Alta nueva formulacion de pvc: " + FamiliaProducto + " medida: " + Medida + " codigo SAP: "+ CodigoSAP,this.User.Identity.Name.ToString());

				currentFormGrid.familiaproducto(FamiliaProducto,Medida);

				//to fill the datagrid
				currentFormGrid.BindGrid(IdFamiliaProducto,IdMedida,IdEspesor,IdPlanta,IdAcabado,IdLinea,checkpermisions());
				
				prcErrorDisplay(null,"El registro se agrego con éxito");		
				
				prcClearControls();
			}
			catch(System.Data.SqlClient.SqlException errHand)
			{
				prcErrorDisplay(errHand,"El material que desea agregar pertenece a la formulación");
			}
			catch
			{
				// prcErrorDisplay(errHand,"Error");

				throw;
			}		
		}

		private void prcClearControls()
		{
			txtCodigoSAP.Text=string.Empty;
			txtDescripcion.Text=string.Empty;
			txtCantidad.Text=string.Empty;
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
				SICALNet.BusinessEntities.FormPVCInfo BELMessage= new SICALNet.BusinessEntities.FormPVCInfo(Convert.ToInt32(cboIdFamiliaProducto.SelectedItem.Value),Convert.ToInt32(cboIdMedida.SelectedItem.Value),cboIdEspesor.SelectedItem.Value,Convert.ToInt32(cboPlanta.SelectedItem.Value),string.Empty,string.Empty,0,0,string.Empty,message, int.Parse(this.cboIdAcabado.SelectedValue), int.Parse(this.cboLinea.SelectedValue),string.Empty);
				SICALNet.BusinessLogicLayer.FormPVC BLLMessage = new SICALNet.BusinessLogicLayer.FormPVC();
				BLLMessage.AddMessage(BELMessage);
				String sMensaje = "Dato guardado exitosamente";
				Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+ "alert('"+ sMensaje +"')"+ "<" + "/script>");
			}
			catch
			{
				throw;
			}
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
					RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('FindMaterial.aspx?Form=FormulationofPVC&CtrlName=txtCodigoSAP&CtrlName2=txtDescripcion&flag=1','anycontent','width=600,height=400,left=100, top=150,status,scrollbars=yes'); </script>");
				}
			}
			catch(Exception ex)
			{
				lblErrorMsg.ForeColor=Color.Red;
				lblErrorMsg.Text=ex.Message;
				txtDescripcion.Text=string.Empty;
			}
		}

		private void txtCodigoSAP_TextChanged(object sender, System.EventArgs e)
		{
			string theCodigoSAP=txtCodigoSAP.Text.Trim();
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

        protected void imgSaveMessage_Click1(object sender, ImageClickEventArgs e)
        {

        }
    }
}
