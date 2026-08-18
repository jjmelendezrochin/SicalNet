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
	/// Summary description for Lotes.
	/// </summary>
	public class Lotes : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button cmdFProducto;
		protected System.Web.UI.WebControls.Button cmdCancelC;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtNoLote;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.TextBox txtPiezas;
		protected System.Web.UI.WebControls.CheckBox chkActivo;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorNoLote;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorPiezas;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RangeValidator RangeValidatorNoLote;
		protected System.Web.UI.WebControls.RangeValidator RangeValidatorPiezas;
		protected System.Web.UI.WebControls.Label lblErrorMsg;

		protected Controls.LotesGrid LotesGridControl;

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
				chkActivo.Checked = true;
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
			//Guardar un nuevo lote 
			try
			{
				SICALNet.BusinessLogicLayer.Lote BRLote = new SICALNet.BusinessLogicLayer.Lote();
				SICALNet.BusinessEntities.LoteInfo loteInfo = new SICALNet.BusinessEntities.LoteInfo(Convert.ToInt32(this.txtNoLote.Text),Convert.ToInt32(this.cboLinea.SelectedItem.Value),Convert.ToInt32(this.txtPiezas.Text),this.chkActivo.Checked);   
				BRLote.SaveLote(loteInfo);	

				// Alta de Lote en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Alta de lote: " + loteInfo.NumeroLote,this.User.Identity.Name.ToString());

				clearControl();		
				LotesGridControl.BindGrid();
				prcErrorDisplay(null,"El nuevo lote se agregó existosamente");
			}
			catch
			{
				// prcErrorDisplay(ex,"Error");

				throw;
			}

		}	

		private void clearControl()
		{
			txtNoLote.Text=String.Empty;
			cboLinea.SelectedIndex  = 0;
			lblErrorMsg.Text = String.Empty;
			txtPiezas.Text = string.Empty;
			chkActivo.Checked = true;
			LotesGridControl.clearMessage();
			LotesGridControl.BindGrid();
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

        protected void cmdFProducto_Click1(object sender, EventArgs e)
        {

        }
    }
}
