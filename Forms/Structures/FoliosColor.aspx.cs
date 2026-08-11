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
	/// Summary description for FoliosColor.
	/// </summary>
	public class FoliosColor : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtFolio;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Button cmdFProducto;
		protected System.Web.UI.WebControls.Button cmdCancelC;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.DropDownList cboCodigoSAP;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Label lblMaterial;
		protected System.Web.UI.WebControls.TextBox txtCodigoSAP;
		protected System.Web.UI.WebControls.ImageButton imgbtnFind;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
	
		protected Controls.FoliosColorGrid FoliosColorGridControl;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);

				SICALNet.BusinessLogicLayer.LineaProduccion  BRlinea = new SICALNet.BusinessLogicLayer.LineaProduccion();
				IList tipoRs= (IList)BRlinea.SelectLinePdt(theUser);				
				cboLinea.DataSource= tipoRs;
				cboLinea.DataValueField="IdLinea";
				cboLinea.DataTextField="Description";
				cboLinea.DataBind();	
	
				SICALNet.BusinessLogicLayer.FoliosColor  BRFolio = new SICALNet.BusinessLogicLayer.FoliosColor();
				SortedList tipoRs2= BRFolio.ListCodigoSAPFolioColor( System.Convert.ToInt32(cboLinea.SelectedItem.Value));  
				cboCodigoSAP.DataSource= tipoRs2;
				cboCodigoSAP.DataValueField="Value";
				cboCodigoSAP.DataTextField="Key";
				cboCodigoSAP.DataBind();
                
				cboCodigoSAP.Items.Insert(0,new ListItem("Seleccione una opción","-1"));
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
			this.cboLinea.SelectedIndexChanged += new System.EventHandler(this.cboLinea_SelectedIndexChanged);
			this.cboCodigoSAP.SelectedIndexChanged += new System.EventHandler(this.cboCodigoSAP_SelectedIndexChanged);
			this.txtCodigoSAP.TextChanged += new System.EventHandler(this.txtCodigoSAP_TextChanged);
			this.cmdFProducto.Click += new System.EventHandler(this.cmdFProducto_Click);
			this.cmdCancelC.Click += new System.EventHandler(this.cmdCancelC_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdCancelC_Click(object sender, System.EventArgs e)
		{
			clearControl();
		}

		private void cmdFProducto_Click(object sender, System.EventArgs e)
		{
			//Guardar un nuevo Folio
			try
			{
				string codigoSAP;

				if (cboCodigoSAP.SelectedIndex > 0)
				{
					codigoSAP = cboCodigoSAP.SelectedItem.Value;  
				}
				else
				{
					codigoSAP = txtCodigoSAP.Text;  
				}

				if (codigoSAP == string.Empty)
				{
					prcErrorDisplay(null,"Seleccione el codigo SAP del material");
					return;
				}

				SICALNet.BusinessLogicLayer.FoliosColor BRFolioColor = new SICALNet.BusinessLogicLayer.FoliosColor();
				SICALNet.BusinessEntities.FolioMaterialInfo OInfo  = new SICALNet.BusinessEntities.FolioMaterialInfo(codigoSAP,System.Convert.ToInt32(this.cboLinea.SelectedItem.Value),this.txtFolio.Text.ToString().Trim(),this.txtObservaciones.Text.ToString().Trim(),User.Identity.Name);    
				BRFolioColor.SaveFoliosColor(OInfo);
				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Alta de folio color, codigo SAP: " + OInfo.CodigoSAP  + " folio: " + OInfo.Folio,this.User.Identity.Name.ToString());


				clearControl();		
				FoliosColorGridControl.BindGrid();
				txtCodigoSAP.Text = string.Empty;
				txtDescripcion.Text = string.Empty; 

				prcErrorDisplay(null,"El nuevo folio se agregó existosamente");
				
			}
			catch
			{
				// prcErrorDisplay(ex,"Error");

				throw;
			}

		}	

		private void clearControl()
		{						
			cboLinea.SelectedIndex  = 0;			
				SICALNet.BusinessLogicLayer.FoliosColor  BRFolio = new SICALNet.BusinessLogicLayer.FoliosColor();
				SortedList tipoRs2= BRFolio.ListCodigoSAPFolioColor( System.Convert.ToInt32(cboLinea.SelectedItem.Value));  
				cboCodigoSAP.DataSource= tipoRs2;
				cboCodigoSAP.DataValueField="Value";
				cboCodigoSAP.DataTextField="Key";
				cboCodigoSAP.DataBind();
				cboCodigoSAP.Items.Insert(0,new ListItem("Seleccione una opción","-1"));
			
			this.txtFolio.Text=string.Empty; 
			this.txtObservaciones.Text = string.Empty; 
			lblErrorMsg.Text = String.Empty;
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

		private void cboLinea_SelectedIndexChanged(object sender, System.EventArgs e)
		{

			SICALNet.BusinessLogicLayer.FoliosColor  BRFolio = new SICALNet.BusinessLogicLayer.FoliosColor();
			SortedList tipoRs2= BRFolio.ListCodigoSAPFolioColor( System.Convert.ToInt32(cboLinea.SelectedItem.Value));  
			cboCodigoSAP.DataSource= tipoRs2;
			cboCodigoSAP.DataValueField="Value";
			cboCodigoSAP.DataTextField="Key";
			cboCodigoSAP.DataBind();
			cboCodigoSAP.Items.Insert(0,new ListItem("Seleccione una opción","-1"));
		}

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
					prcErrorDisplay(null,string.Format("El sistema no pudo encontrar el material -{0}- en el catálogo",theCodigoSAP));
					txtCodigoSAP.Text = string.Empty;
					cboCodigoSAP.SelectedIndex = -1;
					return;
				}
				else
				{
					MaterialInfo material = new MaterialInfo(theCodigoSAP,string.Empty);
					SICALNet.BusinessLogicLayer.Material materialBLL = new SICALNet.BusinessLogicLayer.Material();
					material=materialBLL.SelectMaterial(material);
					txtDescripcion.Text=material.Descripcion;
					cboCodigoSAP.SelectedIndex = -1;					
					prcErrorDisplay(null,"NoError");
				}
				
			}
			else
			{
				prcErrorDisplay(null,"NoError");			
			}		

		}

		private void cboCodigoSAP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtCodigoSAP.Text = string.Empty;
			txtDescripcion.Text = string.Empty;
			prcErrorDisplay(null,string.Empty);
		}

		



	}
}
