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
using  SICALNet.BusinessLogicLayer;

namespace UserInterface.Structures
{
	/// <summary>
	/// Summary description for Medida.
	/// </summary>
	public class Espesor : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtIdEspesor;
		protected System.Web.UI.WebControls.TextBox txtCentimetros;
		protected System.Web.UI.WebControls.TextBox txtPulgadas;
		protected System.Web.UI.WebControls.TextBox txtNominal;
		protected System.Web.UI.WebControls.TextBox txtOtro;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.Button cmdCancel;

		protected Controls.EspesorGrid dgEspesor;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;

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
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
		
			double dblCent;
			double dblPulg;
			double dblNom;
			double dblOtro;

			Validation utlValidate=new Validation();
			if(txtIdEspesor.Text.Trim()==string.Empty)
			{
				lblErrorMsg.Text ="Favor de Ingresar el Identitificador";
				//Clear();
				RegisterStartupScript("focus","<SCRIPT language='javascript'>" + "document.all('" +txtIdEspesor.ClientID + "').focus();" + "</SCRIPT>");
				return;
			}
			if((!utlValidate.IsNumber(txtCentimetros.Text.Trim())) || (txtCentimetros.Text.Length==0))
			{
				lblErrorMsg.Text ="Favor de ingresar una cantidad en centimetros valida";
				//Clear();
				RegisterStartupScript("focus","<SCRIPT language='javascript'>" + "document.all('" +txtIdEspesor.ClientID + "').focus();" + "</SCRIPT>");
				return;
			}
			if((!utlValidate.IsNumber(txtPulgadas.Text.Trim())) || (txtPulgadas.Text.Length==0))
			{
				lblErrorMsg.Text ="Favor de Ingresar una Cantidad en pulgadas valida";
				//Clear();
				RegisterStartupScript("focus","<SCRIPT language='javascript'>" + "document.all('" +txtIdEspesor.ClientID + "').focus();" + "</SCRIPT>");
				return;
			}
			if((!utlValidate.IsNumber(txtNominal.Text.Trim())) || (txtNominal.Text.Length==0))
			{
				lblErrorMsg.Text ="Favor de Ingresar una cantidad nominal valida";
				//Clear();
				RegisterStartupScript("focus","<SCRIPT language='javascript'>" + "document.all('" +txtIdEspesor.ClientID + "').focus();" + "</SCRIPT>");
				return;
			}
			
			if((!utlValidate.IsNumber(txtOtro.Text.Trim())) && (txtOtro.Text.Length>0))
			{
				lblErrorMsg.Text ="El campo 'OTRA ESPESOR' debe ser numérico";
				//Clear();
				RegisterStartupScript("focus","<SCRIPT language='javascript'>" + "document.all('" +txtIdEspesor.ClientID + "').focus();" + "</SCRIPT>");
				return;
			}

			dblCent = Convert.ToDouble(txtCentimetros.Text.Trim());
			dblPulg = Convert.ToDouble(txtPulgadas.Text.Trim());
			dblNom = Convert.ToDouble(txtNominal.Text.Trim());
			dblOtro = txtOtro.Text.Trim()==string.Empty?0:Convert.ToDouble(txtOtro.Text.Trim());

			EspesorInfo belEspesor=new EspesorInfo(txtIdEspesor.Text.Trim(),dblCent,dblPulg,dblNom,dblOtro);
			SICALNet.BusinessLogicLayer.Espesor  bllEspesor =new SICALNet.BusinessLogicLayer.Espesor();
			try
			{
				bllEspesor.InsertEspesor(belEspesor);

				// alta de medida en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Alta de espesor: " + belEspesor.IdEspesor,this.User.Identity.Name.ToString());

				dgEspesor.BindGrid();
				Clear();
				prcErrorDisplay(null,"El nuevo espesor se agrego exitosamente");
			}
			
			catch(System.Data.SqlClient.SqlException errHand)
			{
				prcErrorDisplay(errHand,"Este identificador ya se encuantra en uso en el catalogo");				
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
				errFileWrite.HandleException("Información sobre el catlogo de espesor",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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
				lblErrorMsg.BackColor=Color.Red;
			}
		}
	

		private void Clear()
		{
			txtIdEspesor.Text="";
			txtCentimetros.Text="";
			txtPulgadas.Text="";
			txtNominal.Text="";
			txtOtro.Text="";
		
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			Clear();
		}
			

	}
}
