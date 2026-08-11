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
	/// Summary description for FamiliaProductos.
	/// </summary>
	public class FamilioProductosaForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.DropDownList cbotipodePMMA;
		protected System.Web.UI.WebControls.Button cmdFProducto;
		protected System.Web.UI.WebControls.Button cmdCancelC;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected Controls.FamiliaProductosGrid FamiliaProductosGridControl;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtTempPre;
		protected System.Web.UI.WebControls.Label Label4;
		
		//to get an instance for utility-error handler
		ErrorHandling errFileWrite=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.TipoPMMA tipoBL= new SICALNet.BusinessLogicLayer.TipoPMMA();
				IList tipoRs= (IList)tipoBL.SelectTipoPMMA();
				// To Load Data into to the cbotipoPMMA Dropdown List from TipoPMMA table
				cbotipodePMMA.DataSource= tipoRs;
				cbotipodePMMA.DataValueField="IdTipoPMMA";
				cbotipodePMMA.DataTextField="DescripcionMaterial";
				cbotipodePMMA.DataBind();
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
			this.cmdFProducto.Click += new System.EventHandler(this.AddFamilioProductos_Click);
			this.cmdCancelC.Click += new System.EventHandler(this.cmdCancelC_Click);
			this.ID = "FamilioProductosaForm";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void AddFamilioProductos_Click(object sender, System.EventArgs e)
		{
			//Validation prdVdlt = new Validation();
			
			//int IdFamiliaProductos;
			int IdTipoPMMA;
			string Descripcion;
			
			try
			{
				/*if ((prdVdlt.IsNumber(txtFamiliaProductosId.Text.Trim())==false))
				throw new Exception("FamiliaProductos ID should be Numeric");
			
				IdFamiliaProductos=Convert.ToInt32(txtFamiliaProductosId.Text);

				if (IdFamiliaProductos<0)
					throw new Exception("FamiliaProductos ID should be greater than Zero");*/

				// to initialize the FamiliaProductos info into business entities
				
				
				//to check the description whether its correct or not
				//if ((prdVdlt.IsAlphaNumeric(txtDescripcion.Text.Trim())==false) || (txtDescripcion.Text.Trim()==""))
				if(txtDescripcion.Text.Trim()=="")
				{
					lblErrorMsg.Text = "Debe captura la descripción de la familia de productos";
					return;
					//throw new Exception("Description should be Alpha Numeric and Not Empty");
				}

				if(txtTempPre.Text.Trim()=="")
				{
					lblErrorMsg.Text = "Debe captura la temperatura de preseparación de la familia de productos";
					return;
					//throw new Exception("Description should be Alpha Numeric and Not Empty");
				}
				float auxTemp;
				try
				{
					auxTemp = Convert.ToSingle(txtTempPre.Text);
				}
				catch
				{
					throw new Exception("Valor inválido en la temperatura de preseparación");
				}
				if(auxTemp <=0)throw new Exception("Valor inválido en la temperatura de preseparación");

				Descripcion = txtDescripcion.Text.Trim();
				IdTipoPMMA=Convert.ToInt32(cbotipodePMMA.SelectedItem.Value);
				
				//to assign the FamilioProducto info into business entity lager
				FamiliaProductoInfo fInfo = new FamiliaProductoInfo(IdTipoPMMA,Descripcion,auxTemp.ToString());
				//to get an instance for business logic layer
				SICALNet.BusinessLogicLayer.FamiliaProducto fPds = new SICALNet.BusinessLogicLayer.FamiliaProducto();
				//to Call the Insert Perfil Information method
				fPds.InsertFamiliaProducto(fInfo);
				
				// Alta de familia de producto en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Alta de familia de producto: " + fInfo.Descripcion,this.User.Identity.Name.ToString());

				//to fill the datagrid
				FamiliaProductosGridControl.BindGrid();

				prcErrorDisplay(null,"La nueva familia de productos se agrego exitosamente");		
				
				prcClearControls();
			}
			//catch(System.Data.SqlClient.SqlException errHand)
			catch
			{
				// prcErrorDisplay(errHand,errHand.Message);

				throw;
			}
//			catch
//			{
//				// prcErrorDisplay(errHand,"Error");
//
//				throw;
//			}
		}


		private void prcClearControls()
		{
			txtDescripcion.Text=String.Empty;
			cbotipodePMMA.SelectedIndex=0;
			
		}
		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				//errFileWrite.HandleException("Información del catalogo de Familias de productos",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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

		private void cmdCancelC_Click(object sender, System.EventArgs e)
		{

			txtDescripcion.Text=String.Empty;
			txtTempPre.Text = string.Empty;
			lblErrorMsg.Text = String.Empty;
		}
	}
}

