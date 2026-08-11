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
	/// Summary description for Ollas.
	/// </summary>
	public class Ollas : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button cmdFProducto;
		protected System.Web.UI.WebControls.Button cmdCancelC;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtNoOlla;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorNoOlla;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RangeValidator RangeValidatorNoOlla;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorNoLote;
		protected System.Web.UI.WebControls.RangeValidator RangeValidatorNoLote;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtCapacidadMax;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtCapacidadMin;
		protected System.Web.UI.WebControls.DropDownList cboPlanta;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.RangeValidator Rangevalidator2;
		protected System.Web.UI.WebControls.RangeValidator Rangevalidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;

		protected Controls.OllaGrid OllasGridControl;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);

				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.LineaProduccion  BRlinea = new SICALNet.BusinessLogicLayer.LineaProduccion();
				IList tipoRs= (IList)BRlinea.SelectLinePdt(theUser);				
				cboLinea.DataSource= tipoRs;
				cboLinea.DataValueField="IdLinea";
				cboLinea.DataTextField="Description";
				cboLinea.DataBind();
				
				SICALNet.BusinessLogicLayer.Planta  BRPlanta = new SICALNet.BusinessLogicLayer.Planta();
				IList tipoRs2= (IList)BRPlanta.SelectPlanta();						
				cboPlanta.DataSource= tipoRs2;
				cboPlanta.DataValueField="IdPlanta";
				cboPlanta.DataTextField="Description";
				cboPlanta.DataBind();				


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
			//Guardar un nuevo Olla 
			try
			{
				SICALNet.BusinessLogicLayer.Olla BROlla = new SICALNet.BusinessLogicLayer.Olla();
			    SICALNet.BusinessEntities.OllaInfo OllaInfo = new SICALNet.BusinessEntities.OllaInfo(Convert.ToInt32(this.txtNoOlla.Text),Convert.ToInt32(this.cboPlanta.SelectedItem.Value),Convert.ToSingle(this.txtCapacidadMax.Text),Convert.ToSingle(this.txtCapacidadMin.Text),Convert.ToInt32(this.cboLinea.SelectedItem.Value),this.txtDescripcion.Text);  
				BROlla.SaveOlla(OllaInfo);	

				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Alta nueva olla numero: " + OllaInfo.NumeroOlla + " descripcion: " + OllaInfo.Descripcion,this.User.Identity.Name.ToString());


				clearControl();		
				OllasGridControl.BindGrid();
				prcErrorDisplay(null,"La nueva olla se agregó existosamente");
			}
			catch
			{
				// prcErrorDisplay(ex,"Error");

				throw;
			}

		}	

		private void clearControl()
		{
			txtNoOlla.Text=String.Empty;
			cboLinea.SelectedIndex  = 0;
			cboPlanta.SelectedIndex = 0;
			txtDescripcion.Text = String.Empty;
			txtCapacidadMax.Text = String.Empty;
			txtCapacidadMin.Text = String.Empty;
			lblErrorMsg.Text = String.Empty;
			OllasGridControl.clearMessage();
			OllasGridControl.BindGrid();
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


	}
}
