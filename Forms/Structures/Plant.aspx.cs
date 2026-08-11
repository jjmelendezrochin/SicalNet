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
	/// Summary description for Plant.
	/// </summary>
	public class PlantaForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button AddPlant;
		protected System.Web.UI.WebControls.TextBox txtDescription;
		protected System.Web.UI.WebControls.Button cmdCancelC;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected Controls.PlantGrid plantGridControl;
		protected System.Web.UI.WebControls.TextBox txtDenomSAP;
		protected System.Web.UI.WebControls.TextBox txtMerma;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtRendimientoColor;

		//to get an instance for utility-error handler
		ErrorHandling errFileWrite=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.AddPlant.Click += new System.EventHandler(this.AddPlant_Click);
			this.cmdCancelC.Click += new System.EventHandler(this.cmdCancelC_Click);
			this.ID = "PlantaForm";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void AddPlant_Click(object sender, System.EventArgs e)
		{
			try
			{
			Validation pltVdlt = new Validation();

			//int IdPlanta;
			string Description;
			string DenomSAP;
			float Merma;
			float PorcentajeColor;

		

			// to check plantaid whether its correct or not
			/*try {IdPlanta=Convert.ToInt32(txtPlantId.Text);}
			catch	{
				throw new Exception("Planta Information ID should be Numeric");}
			if (IdPlanta<=0)
				throw new Exception("Planta Information ID should be greater than Zero");*/

			//to check the description whether its correct or not
			//if ((pltVdlt.IsAlphaNumeric(txtDescription.Text.Trim())==false) || (txtDescription.Text.Trim()==""))
			
				if (!pltVdlt.IsAlphaNumeric(txtDescription.Text))
				{
					lblErrorMsg.Text = "InValid Descripcion";
					return;
				}

				try 
					{Merma=(float)Double.Parse(txtMerma.Text);}
				catch	
					{throw new Exception("Proporcione un valor de Merma válido para la Planta");}

				try 
				{PorcentajeColor=(float)Double.Parse(this.txtRendimientoColor.Text);}
				catch	
				{throw new Exception("Proporcione un valor de Porcentaje de Rendimiento de Color válido para la Planta");}



			 if(txtDescription.Text.Trim()==string.Empty)
				throw new Exception("Debe capturar una descripción para esta planta");

		
				// to initialize the Stoage Material info into business entities
				//IdPlanta = Convert.ToInt32(txtPlantId.Text);
				Description = txtDescription.Text.Trim();
				DenomSAP= txtDenomSAP.Text.Trim();

				//to assign the planta info into business entity lager
				PlantaInfo plantaInfo = new PlantaInfo(0,Description,DenomSAP,Merma,PorcentajeColor); //IdPlanta,Description,Zona

				//to get an instance for business logic layer
				SICALNet.BusinessLogicLayer.Planta planta = new SICALNet.BusinessLogicLayer.Planta();
				//to Call the Insert Planta Information method
				planta.InsertPlanta(plantaInfo);
				// Bitacora guardado de de planta nueva
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Se crea nueva planta: " + plantaInfo.Description,this.User.Identity.Name.ToString());

				//to fill the datagrid
				plantGridControl.BindGrid();
				prcErrorDisplay(null,"NoError");
				txtDescription.Text = string.Empty;
				txtDenomSAP.Text=string.Empty;
				txtMerma.Text="0";
				txtRendimientoColor.Text="0";
			}
			catch(System.Data.SqlClient.SqlException)
			{
				prcErrorDisplay(null,"Este ID identificador ya esta en uso para otra planta");				
			}
			catch
			{				
				throw;
			}

		}

		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				//errFileWrite.HandleException("Información de la Planta",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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
			txtDescription.Text = string.Empty;
			lblErrorMsg.Text = "";
		}

	}
}
