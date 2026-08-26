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
using SICALNet.Utilities;

namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for AdjustTanque.
	/// </summary>
	public class AdjustTanque : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgdTanque;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Button btnAceptar;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.DataGrid dgdAdjustTanque;
		protected System.Web.UI.WebControls.Label lblTanqueDesc2;
		protected System.Web.UI.WebControls.Label txtTanqueDesc2;
		protected System.Web.UI.WebControls.Label lblPmmaOrg2;
		protected System.Web.UI.WebControls.Label txtPmmaOrg2;
		protected System.Web.UI.WebControls.Label lblCantOrg2;
		protected System.Web.UI.WebControls.Label txtCantOrg2;
		protected System.Web.UI.WebControls.Label lblPMMAFin2;
		protected System.Web.UI.WebControls.DropDownList cmbPMMAFin;
		protected System.Web.UI.WebControls.Label lblCantFin2;
		protected System.Web.UI.WebControls.TextBox txtCantFin2;
		protected System.Web.UI.WebControls.Label lblCassa;
		protected System.Web.UI.WebControls.TextBox txtCassa;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label2;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
		
			Response.Cache.SetExpires(DateTime.Now);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetValidUntilExpires(false);
			Response.Cache.SetNoStore();	
			try
			{
				if(!IsPostBack)
				{
					btnAceptar.Attributes.Add(
					   "onclick",
					   "if (this.getAttribute('data-confirmado') == '1') {" +
						   "this.setAttribute('data-confirmado', '0');" +
						   "return true;" +
					   "}" +
					   "var boton=this;" +
					   "SicalAlert.confirmar(" +
						   "'¿Está seguro de hacer este ajuste al tanque?', " +
						   "'Confirmar ajuste', " +
						   "function() {" +
							   "boton.setAttribute('data-confirmado','1');" +
							   "boton.click();" +
						   "}" +
					   ");" +
					   "return false;"
				   );

					BindGrid();
				}
			}
			catch(Exception ex)
			{
				lblErrorMsg.Text=ex.Message;
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
			this.dgdTanque.SelectedIndexChanged += new System.EventHandler(this.dgdTanque_SelectedIndexChanged);
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindGrid()
		{
			//Bind the data with datagrid
			SICALNet.BusinessLogicLayer.Tanque Tanque = new SICALNet.BusinessLogicLayer.Tanque();
			//TODO: Cambiar este hardcode de id de linea
			IList TanqueList = (IList)Tanque.LoadTank(0);
			dgdTanque.DataSource = TanqueList;
			dgdTanque.DataBind();
			SICALNet.BusinessLogicLayer.AjustesTanque AjTanque = new SICALNet.BusinessLogicLayer.AjustesTanque();
			IList AjTanqueList = (IList)AjTanque.LoadAjusteTanque();
			dgdAdjustTanque.DataSource = AjTanqueList;
			dgdAdjustTanque.DataBind();
		}

		private void dgdTanque_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Panel1.Visible=true;
			//to get the instance for BusinessLogicLayer
			SICALNet.BusinessLogicLayer.TipoPMMA TipoPMMA = new SICALNet.BusinessLogicLayer.TipoPMMA();
			// to Call the Select method
			IList TipoPMMARs= (IList)TipoPMMA.SelectTipoPMMATanque();
			//to assign the result set into ComboBox
			cmbPMMAFin.DataSource = TipoPMMARs;
			cmbPMMAFin.DataTextField="DescripcionMaterial";//This CodigoSAP describes the Description of Material Table
			cmbPMMAFin.DataValueField="IdTipoPMMA";
			//to fill the datagrid
			cmbPMMAFin.DataBind();
			txtTanqueDesc2.Text=((Label)dgdTanque.SelectedItem.FindControl("ItemTanqueDesc")).Text.ToString();
			txtPmmaOrg2.Text=((Label)dgdTanque.SelectedItem.FindControl("ItemTipoPMMADesc")).Text.ToString();
			txtCantOrg2.Text=((Label)dgdTanque.SelectedItem.FindControl("ItemTankCantidad")).Text.ToString();
			//to set the default value
			cmbPMMAFin.Items.FindByText(txtPmmaOrg2.Text.ToString()).Selected=true;
			//to set the focus on the textbox of Cantidad
			Page.RegisterStartupScript("focus", "<script language='JavaScript'>"+
				"AdjustTanque." + txtCantFin2.ClientID + ".focus();"+
				"<" + "/script>");
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			try
			{
				lblErrorMsg.Text=string.Empty;
				int IdTanque=Convert.ToInt32(((Label)dgdTanque.SelectedItem.FindControl("ItemIdTanque")).Text);
				int IdPMMAOrg=Convert.ToInt32(((Label)dgdTanque.SelectedItem.FindControl("ItemTipoPMMAId")).Text);
				double Cantorg=Convert.ToDouble(txtCantOrg2.Text);
				Validation vlt = new Validation();
				// To Validate the Given Inputed Values is Number or Not
				if(!vlt.IsNumber(txtCantFin2.Text.ToString())&& (txtCantFin2.Text==string.Empty))
					throw new Exception("The Cantidad Final Should be Numeric and not Empty");
				int IdPMMAFin=Convert.ToInt32(cmbPMMAFin.SelectedItem.Value);
				double Cantfin=Convert.ToDouble(txtCantFin2.Text);
				AjustesTanqueInfo AjInfo= new AjustesTanqueInfo(IdTanque,DateTime.Now.Date.ToString("MM/dd/yyyy"),IdPMMAOrg,Cantorg,IdPMMAFin,Cantfin,txtCassa.Text.ToString());
				// Create the Business Logic Tier
				SICALNet.BusinessLogicLayer.AjustesTanque AjTanque = new SICALNet.BusinessLogicLayer.AjustesTanque();
				// Call the Update Storage method
				double CapacidadMax=Convert.ToDouble(((Label)dgdTanque.SelectedItem.FindControl("ItemCapacidadMax")).Text);
				AjTanque.Validate(CapacidadMax,Cantfin);
				AjTanque.InsertAjusteTanque(AjInfo);
				BindGrid();
				Panel1.Visible=false;
				txtCassa.Text=string.Empty;
				txtCantFin2.Text=string.Empty;
				lblErrorMsg.Text=string.Empty;
			}
			catch
			{

				throw;
			}
		
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			//to clear the data
			Panel1.Visible=false;
			lblErrorMsg.Text=string.Empty;
			txtCassa.Text=string.Empty;
			txtCantOrg2.Text=string.Empty;
		}
		
	}
}
