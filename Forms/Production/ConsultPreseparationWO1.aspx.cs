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

using System.Configuration;
using SICALNet.BusinessEntities;

namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for ConsultPreseparationWO1.
	/// </summary>
	public class ConsultPreseparationWO1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Button btnAgregarMensaje;
		protected System.Web.UI.WebControls.Button btnAgregar;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.TextBox txtSecuencia;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.TextBox txtUTEC;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected System.Web.UI.WebControls.TextBox txtFamilia;
		protected System.Web.UI.WebControls.TextBox txtLinea;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnLiberar;
		protected System.Web.UI.WebControls.TextBox txtTemp;
		protected System.Web.UI.WebControls.TextBox txtPiso;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtTempPre;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label3;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetExpires(DateTime.Now);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetValidUntilExpires(false);
			Response.Cache.SetNoStore();

			// Put user code to initialize the page here
			if (IsPostBack) return;

			btnAgregar.Attributes.Add("onClick","showWaitControls()");
			btnAgregarMensaje.Attributes.Add("onClick","showWaitControls()");
			btnCancel.Attributes.Add("onClick","showWaitControls()");
			btnLiberar.Attributes.Add("onClick","showWaitControls()");

			int IdFamiliaProducto;
			//string IdEspesor;
			//int Cantidad;

			//int IdArea = Convert.ToInt32(ConfigurationSettings.AppSettings["PreseparationRoomId"]);  //Area for Preseparation Room

			txtSecuencia.Text = Request.QueryString["Secuencia"].ToString();
			txtFecha.Text =  Request.QueryString["Fecha1"].ToString();
			txtUTEC.Text = Request.QueryString["UTEC"].ToString();
			txtCantidad.Text = Request.QueryString["Cantidad"].ToString();
			txtFamilia.Text = Request.QueryString["Familia"].ToString();
			txtLinea.Text = Request.QueryString["Linea"].ToString();
				
			IdFamiliaProducto = Convert.ToInt32(Request.QueryString["IdFamiliaProducto"].ToString());
			SICALNet.BusinessLogicLayer.FamiliaProducto FProducto = new SICALNet.BusinessLogicLayer.FamiliaProducto();
			float TempPreseparacion = FProducto.GetTempPreseparacion(IdFamiliaProducto);

			SICALNet.BusinessEntities.PartidasPreseparacionInfo PPreInfo = new PartidasPreseparacionInfo( txtSecuencia.Text.ToString(),Convert.ToInt32(ConfigurationSettings.AppSettings["PreseparationRoomId"].ToString()),0);
			SICALNet.BusinessLogicLayer.PartidasPreseparacion BLPreSeparacion = new SICALNet.BusinessLogicLayer.PartidasPreseparacion();
			IList ListPreSe = BLPreSeparacion.Select(PPreInfo); 
			if(ListPreSe.Count > 0)
			{
				this.txtTempPre.Text = ((PartidasPreseparacionInfo)ListPreSe[0]).TempPreseparacion.ToString();
			}
			else
			{
				this.txtTempPre.Text = TempPreseparacion.ToString(); 
			}			
			txtTemp.Text = TempPreseparacion.ToString();
			//IdMedida = Convert.ToInt32(Request.QueryString["IdMedida"].ToString());
			//IdEspesor = Request.QueryString["IdEspesor"].ToString();
			//Cantidad = Convert.ToInt32(Request.QueryString["Cantidad"].ToString());
			string Status = Request.QueryString["Status"].ToString();

			string ReleaseStatus = ConfigurationSettings.AppSettings["StatusRelease"].ToString(); //Get Release Status Code
			if (Status == ReleaseStatus)
			{
				//The sequences in status RELEASED can only be consulted in READ ONLY mode
				lblErrorMsg.Text = "La secuencia se consulto y quedo Liberada.....";
				btnLiberar.Enabled =false;
				btnAgregar.Enabled=false;
				txtTempPre.ReadOnly = true;
			}


			// Display the Messages in Multiline Text box
			DisplayFloorMessage();
	
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
			this.btnAgregarMensaje.Click += new System.EventHandler(this.btnAgrigar_Click);
			this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DisplayFloorMessage()
		{
			// Display the Messages in Multiline Text box
			MensajePisoInfo mpInfo = new MensajePisoInfo(txtSecuencia.Text,string.Empty,Convert.ToInt32(ConfigurationSettings.AppSettings["PreseparationRoomId"]));
			SICALNet.BusinessLogicLayer.MensajePiso mPiso = new SICALNet.BusinessLogicLayer.MensajePiso();					
			IList mPisoList=mPiso.Select(mpInfo);
			if(mPisoList.Count>0)
			{
				for(int iloop=0;iloop<mPisoList.Count;iloop++)
				{	
					MensajePisoInfo mpInfo1 = new MensajePisoInfo();
					mpInfo1=(MensajePisoInfo)mPisoList[iloop];
					txtPiso.Text+=mpInfo1.Mensaje.ToString();
					txtPiso.Text+="\n";
				}
			}

		}


		private void btnLiberar_Click(object sender, System.EventArgs e)
		{
//			// To Get Next WorkOrder Number and Change that status to Activo
//			FlujoAreaInfo FAInfo = new FlujoAreaInfo ( Convert.ToInt32(ConfigurationSettings.AppSettings["PreseparationRoomId"]), 0 );
//			SICALNet.BusinessLogicLayer.FlujoArea FArea = new SICALNet.BusinessLogicLayer.FlujoArea();
//
//			ArrayList FAreaList = new ArrayList();
//			FAreaList = (ArrayList) FArea.Load(FAInfo);
//			FAInfo = (FlujoAreaInfo)FAreaList[0];
//
//			// To Change the Next Work Order Status To Active
//			int ActiveStatus = Convert.ToInt32(ConfigurationSettings.AppSettings["StatusActive"].ToString());
//			OrdenesTrabajoInfo WOInfo1 = new OrdenesTrabajoInfo(txtSecuencia.Text, FAInfo.IdAreaPadre, ActiveStatus); // 2 - Active
//			SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder1 = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
//			WorkOrder1.UpdateWO(WOInfo1);


			try
			{
				int IdArea = Convert.ToInt32(ConfigurationSettings.AppSettings["PreseparationRoomId"]);
				int IdStatus = Convert.ToInt32(ConfigurationSettings.AppSettings["StatusRelease"].ToString());

				//Activate Next Area And update Active Area in Programma Production for this Secuencia
				//Depending on sequence available in "FlujoArea" Table
				SICALNet.BusinessLogicLayer.FlujoArea objFlujoArea = new SICALNet.BusinessLogicLayer.FlujoArea();
				objFlujoArea.ActivateDependingAreas(txtSecuencia.Text,IdArea);

			
				SICALNet.BusinessEntities.PartidasPreseparacionInfo PPreInfo = new PartidasPreseparacionInfo( txtSecuencia.Text.ToString(),Convert.ToInt32(ConfigurationSettings.AppSettings["PreseparationRoomId"].ToString()),Convert.ToSingle(this.txtTempPre.Text));
				SICALNet.BusinessLogicLayer.PartidasPreseparacion BLPreSeparacion = new SICALNet.BusinessLogicLayer.PartidasPreseparacion();
				BLPreSeparacion.Insert(PPreInfo); 


				// To Release the Work Order
				OrdenesTrabajoInfo WOInfo = new OrdenesTrabajoInfo(txtSecuencia.Text, IdArea, IdStatus, DateTime.Now.Date.ToString("dd/MMM/yyyy"),Context.User.Identity.Name); // 1 - Active
				SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				WorkOrder.UpdateStatus(WOInfo);

				btnLiberar.Enabled=false;
				//Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"La Orden de Trabajo se libero exitosamente"+"');self.location.href='ConsultPreseparationWO.aspx';</script>");
				Response.Redirect("ConsultPreseparationWO.aspx");
			}
			catch
			{
				throw;
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ConsultPreseparationWO.aspx");
		}

		private void btnAgrigar_Click(object sender, System.EventArgs e)
		{
			string Secuencia = txtSecuencia.Text.ToString();
			string IdArea= ConfigurationSettings.AppSettings["PreseparationRoomId"].ToString();
			string CodigoSAP=Request.QueryString["CodigoSAP"].ToString();
			string matDesc=txtUTEC.Text.Trim();
			RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodigoSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");
		}

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
			try
			{
				//Registrar cambio en la base de datos

				SICALNet.BusinessEntities.PartidasPreseparacionInfo PPreInfo = new PartidasPreseparacionInfo( txtSecuencia.Text.ToString(),Convert.ToInt32(ConfigurationSettings.AppSettings["PreseparationRoomId"].ToString()),Convert.ToSingle(this.txtTempPre.Text));
				SICALNet.BusinessLogicLayer.PartidasPreseparacion BLPreSeparacion = new SICALNet.BusinessLogicLayer.PartidasPreseparacion();
				BLPreSeparacion.Insert(PPreInfo); 
			}
			catch
			{
				throw;
			}
		}

	
	}
}
