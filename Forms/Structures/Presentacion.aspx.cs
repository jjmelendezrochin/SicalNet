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
	/// Summary Descripcion for Presentacion.
	/// </summary>
	public class PresentacionForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cmdCancelC;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.TextBox txtPresentacionId;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Button AddPresentacion;
		protected Controls.PresentacionGrid PresentacionGrid1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;

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
			this.AddPresentacion.Click += new System.EventHandler(this.AddPresentacion_Click);
			this.cmdCancelC.Click += new System.EventHandler(this.cmdCancelC_Click);
			this.ID = "PresentacionForm";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void AddPresentacion_Click(object sender, System.EventArgs e)
		{
			//Validation pltVdlt = new Validation();

			string IdPresentacion;
			string Descripcion;
			try
			{
				// to check Presentacion id whether its correct or not
				if (txtPresentacionId.Text.Length == 0)
				{
					throw new Exception("Favor de Ingresar el Identificador");
				}
				/*try {IdPresentacion=Convert.ToInt32(txtPresentacionId.Text);}
				catch	{
					throw new Exception("Presentacion ID should be Numeric");}
				if (IdPresentacion<=0)
					throw new Exception("Presentacion ID should be greater than Zero");*/

				//to check the Descripcion whether its correct or not
				//if ((pltVdlt.IsAlphaNumeric(txtDescripcion.Text.Trim())==false) || (txtDescripcion.Text.Trim()==""))
				if(txtDescripcion.Text.Trim()=="")
					throw new Exception("Debe capturar la descripción de esta presentación");
			
				// to initialize the Stoage Material info into business entities
				IdPresentacion = txtPresentacionId.Text.Trim();
				Descripcion = txtDescripcion.Text.Trim();

				//to assign the Presentacion info into business entity layer
				PresentacionInfo pInfo = new PresentacionInfo(IdPresentacion,Descripcion);

				//to get an instance for business logic layer
				SICALNet.BusinessLogicLayer.Presentacion Presentacion = new SICALNet.BusinessLogicLayer.Presentacion();

				//to Call the Insert Presentacion Information method
				Presentacion.InsertPresentacion(pInfo);

				// agregar nueva presentacion en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Alta nueva presentacion: " + pInfo.IdPresentacion ,this.User.Identity.Name.ToString());

				//to fill the datagrid
				PresentacionGrid1.BindGrid();

				//To Clear TextBoxs after addition
				txtPresentacionId.Text=""; txtDescripcion.Text="";

				prcErrorDisplay(null,"NoError");

				txtPresentacionId.Text=string.Empty; 
				txtDescripcion.Text=string.Empty;

			}
			catch(System.Data.SqlClient.SqlException errHand)
			{
				prcErrorDisplay(errHand, "Este ID Identificador ya esta siendo usado por el sistema");				
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
				errFileWrite.HandleException("Informacion de Presentaciones",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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
			txtPresentacionId.Text=string.Empty; 
			txtDescripcion.Text=string.Empty;
			lblErrorMsg.Text = "";
		}

	}
}
