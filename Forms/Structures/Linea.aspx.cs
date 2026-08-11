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

namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for Linea.
	/// </summary>
	public class PlantaForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtDescription;
		protected System.Web.UI.WebControls.Button cmdCancelC;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		
		protected Controls.LineaGrid LineaGridControl;
		protected System.Web.UI.WebControls.TextBox txtLineaId;
		protected System.Web.UI.WebControls.Button AddLinea;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList cboplanta;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;

		//to get an instance for utility-error handler
		ErrorHandling errFileWrite=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				
				SICALNet.BusinessLogicLayer.Planta plantBLL = new SICALNet.BusinessLogicLayer.Planta();
				cboplanta.DataSource=plantBLL.SelectPlanta();
				cboplanta.DataTextField="Description";
				cboplanta.DataValueField="IdPlanta";
				cboplanta.DataBind();
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
			this.AddLinea.Click += new System.EventHandler(this.AddLinea_Click);
			this.cmdCancelC.Click += new System.EventHandler(this.cmdCancelC_Click);
			this.ID = "LineaForm";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void AddLinea_Click(object sender, System.EventArgs e)
		{
			try
			{
			//Validation pltVdlt = new Validation();

			int IdLinea;
			string Description;
			int idplanta;

			//to check the description whether its correct or not
			if(txtDescription.Text.Trim()=="")
			//if ((pltVdlt.IsAlphaNumeric(txtDescription.Text.Trim())==false) || (txtDescription.Text.Trim()==""))
				throw new Exception("Debe capturar una descripción para esta planta");
			
			
				// to initialize the Stoage Material info into business entities
				IdLinea = Convert.ToInt32(txtLineaId.Text);
				Description = txtDescription.Text.Trim();
				idplanta = Convert.ToInt32(cboplanta.SelectedItem.Value);

				//to assign the linea info into business entity layer
				SICALNet.BusinessEntities.LineaInfoNew  LineaInfo = new SICALNet.BusinessEntities.LineaInfoNew(IdLinea,Description,idplanta);

				//to get an instance for business logic layer
				SICALNet.BusinessLogicLayer.LineaProduccion Linea = new SICALNet.BusinessLogicLayer.LineaProduccion();

				//to Call the Insert Linea Information method
				Linea.InsertLinePdtnew(LineaInfo);
				
				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Alta nueva linea: " + LineaInfo.Description + " planta: " + LineaInfo.Idplanta,this.User.Identity.Name.ToString());

				//to fill the datagrid
				
				LineaGridControl.BindGrid();
				prcErrorDisplay(null,"NoError");
				txtLineaId.Text = string.Empty;
				txtDescription.Text = string.Empty;

			}
			
			catch
			{
				// prcErrorDisplay(errHand,"Error");

				throw;
			}
		}

		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("Información de la línea",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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
				lblErrorMsg.BackColor=Color.Red;
			}
		}

		private void cmdCancelC_Click(object sender, System.EventArgs e)
		{
			txtLineaId.Text = string.Empty;
			txtDescription.Text = string.Empty;
			lblErrorMsg.Text = "";
		}

	}
}
