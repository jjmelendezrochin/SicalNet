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
	/// Summary description for Zonas.
	/// </summary>
	public class Zonas : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Button cmdFProducto;
		protected System.Web.UI.WebControls.Button cmdCancelC;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.ImageButton imgbtnFind;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtDenominacion;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
	
		protected Controls.ZonasGrid Zonas1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				cmdFProducto.Attributes.Add(
					"onclick",
					"return ConfirmarInsertarZona(this);"
				);

				SICALNet.BusinessEntities.UsuarioInfo theUser =
					new SICALNet.BusinessEntities.UsuarioInfo(
						this.Context.User.Identity.Name,
						string.Empty,
						string.Empty,
						0,
						0,
						string.Empty,
						0,
						string.Empty,
						0,
						string.Empty,
						true
					);

				SICALNet.BusinessLogicLayer.Usuario BLLUser =
					new SICALNet.BusinessLogicLayer.Usuario();

				theUser = BLLUser.Load(theUser);

				SICALNet.BusinessLogicLayer.LineaProduccion BRlinea =
					new SICALNet.BusinessLogicLayer.LineaProduccion();

				IList tipoRs = (IList)BRlinea.SelectLinePdt(theUser);

				cboLinea.DataSource = tipoRs;
				cboLinea.DataValueField = "IdLinea";
				cboLinea.DataTextField = "Description";
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
			this.cmdFProducto.Click += new System.EventHandler(this.cmdFProducto_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

//		private void cmdCancelC_Click(object sender, System.EventArgs e)
//		{
//			clearControl();
//		}

		public void cmdFProducto_Click(object sender, System.EventArgs e)
		{
			//Guardar un nuevo Folio
			try
			{
				string idLinea = this.cboLinea.SelectedValue;				
				string sDenominacion =  this.txtDenominacion.Text;

				SICALNet.BusinessLogicLayer.Zona BRZona = new SICALNet.BusinessLogicLayer.Zona();
				SICALNet.BusinessEntities.ZonaInfo OInfo  = new SICALNet.BusinessEntities.ZonaInfo(1,int.Parse(idLinea),false,"",sDenominacion);    
				BRZona.InsertaZonaNueva(OInfo);
				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Alta de Zona: " + OInfo.Denominacion ,this.User.Identity.Name.ToString());

				//clearControl();
				this.Zonas1.BindGrid();

				prcErrorDisplay(null,"La zona se agregó existosamente");
				
			}
			catch (Exception ex)
			{
				prcErrorDisplay(ex,"Error");

				throw;
			}

		}	

		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				//errFileWrite.HandleException("Inforamción sobre el catalogo de Medida",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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

//		private void cboLinea_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//
//			SICALNet.BusinessLogicLayer.FoliosColor  BRFolio = new SICALNet.BusinessLogicLayer.FoliosColor();
//			SortedList tipoRs2= BRFolio.ListCodigoSAPFolioColor( System.Convert.ToInt32(cboLinea.SelectedItem.Value));  
//			cboCodigoSAP.DataSource= tipoRs2;
//			cboCodigoSAP.DataValueField="Value";
//			cboCodigoSAP.DataTextField="Key";
//			cboCodigoSAP.DataBind();
//			cboCodigoSAP.Items.Insert(0,new ListItem("Seleccione una opción","-1"));
//		}

//		private void prcErrorDisplay(Exception errHnd,string errStatus)
//		{
//			if (errStatus=="Error")
//			{
//				//to display the error msg
//				errFileWrite.HandleException("Información de catalogo de formulcaión de color",errHnd,Server.MapPath("..")+"\\ErrorLog\\Error"+DateTime.Now.Date.ToString("dd-MM-yy")+".txt");
//				lblErrorMsg.Text=errHnd.Message;
//				lblErrorMsg.ForeColor=Color.White;
//				lblErrorMsg.BackColor=Color.Red;
//			}
//			else if (errStatus=="NoError")
//			{
//				//to clear label box
//				lblErrorMsg.ForeColor=Color.White;
//				lblErrorMsg.BackColor=Color.White;
//			}
//			else
//			{
//				//to display the success msg
//				lblErrorMsg.Text=errStatus;
//				lblErrorMsg.ForeColor=Color.White;
//				lblErrorMsg.BackColor=Color.Green;
//			}
//		}
//
//		private void txtCodigoSAP_TextChanged(object sender, System.EventArgs e)
//		{
//			string theCodigoSAP=txtCodigoSAP.Text.Trim();
//			if (theCodigoSAP!=string.Empty)
//			{
//				MaterialInfo mInfo = new MaterialInfo(theCodigoSAP, String.Empty);
//				SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();
//			
//				if (!Material.isExistMaterial(mInfo))
//				{
//					txtDescripcion.Text=string.Empty;
//					prcErrorDisplay(null,string.Format("El sistema no pudo encontrar el material -{0}- en el catálogo",theCodigoSAP));
//					txtCodigoSAP.Text = string.Empty;
//					cboCodigoSAP.SelectedIndex = -1;
//					return;
//				}
//				else
//				{
//					MaterialInfo material = new MaterialInfo(theCodigoSAP,string.Empty);
//					SICALNet.BusinessLogicLayer.Material materialBLL = new SICALNet.BusinessLogicLayer.Material();
//					material=materialBLL.SelectMaterial(material);
//					txtDescripcion.Text=material.Descripcion;
//					cboCodigoSAP.SelectedIndex = -1;					
//					prcErrorDisplay(null,"NoError");
//				}
//				
//			}
//			else
//			{
//				prcErrorDisplay(null,"NoError");			
//			}		
//
//		}

//		private void cboCodigoSAP_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			txtCodigoSAP.Text = string.Empty;
//			txtDescripcion.Text = string.Empty;
//			prcErrorDisplay(null,string.Empty);
//		}

	}
}
