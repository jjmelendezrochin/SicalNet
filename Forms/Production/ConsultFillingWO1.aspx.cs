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
using SICALNet.BusinessLogicLayer;

namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for ConsultFillingWO1.
	/// </summary>
	public class ConsultFillingWO1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblSecuencia;
		protected System.Web.UI.WebControls.Label lblLinea2;
		protected System.Web.UI.WebControls.TextBox txtLinea2;
		protected System.Web.UI.WebControls.Label lblKilos;
		protected System.Web.UI.WebControls.TextBox txtKilos;
		protected System.Web.UI.WebControls.Label lblTolen;
		protected System.Web.UI.WebControls.TextBox txtTolen;
		protected System.Web.UI.WebControls.Button btnLiberar;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.TextBox txtSecuencia;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.TextBox txtUTEC;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected System.Web.UI.WebControls.Button btnAgregarMensaje;
		protected System.Web.UI.WebControls.Button btnAgregar;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtPiso;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtKCT;
		protected System.Web.UI.WebControls.DataGrid dgdQtyOlla;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.TextBox txtFamilia;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);

			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				btnAgregar.Attributes.Add("onClick","showWaitControls()");
				btnAgregarMensaje.Attributes.Add("onClick","showWaitControls()");
				btnCancel.Attributes.Add("onClick","showWaitControls()");
				btnLiberar.Attributes.Add("onClick","showWaitControls()");


				btnLiberar.Enabled=true;

				int Sts=Convert.ToInt32(Request.QueryString["Status"].ToString());
				string Secuencia=Request.QueryString["Secuencia"].ToString();
				string Fecha2=Request.QueryString["Fecha2"].ToString();
				string Utec=Request.QueryString["UTEC"].ToString();
				string Linea2=Request.QueryString["Linea2"].ToString();
				string Cantidad=Request.QueryString["Cantidad"].ToString();
				string Familia=Request.QueryString["Familia"].ToString();
				
				//int IdFamilio=Convert.ToInt32(Request.QueryString["IdFamilia"].ToString());
				int IdMedida=Convert.ToInt32(Request.QueryString["IdMedida"].ToString());
				string IdEspesor=Request.QueryString["IdEspesor"].ToString();
				int IdLinea=Convert.ToInt32(Request.QueryString["IdLinea"].ToString());
				int IdPlanta=Convert.ToInt32(Request.QueryString["IdPlanta"].ToString());	
				string KCT=Request.QueryString["KCT"].ToString();

				int ReleaseStatus = Convert.ToInt32(ConfigurationSettings.AppSettings["StatusRelease"]);
				if(Sts==ReleaseStatus)
				{
					btnLiberar.Enabled=false;
					btnAgregar.Enabled=false;
					txtKCT.Enabled=false;
					txtTolen.Enabled=false;
					txtKCT.Enabled=false;
				}

				txtSecuencia.Text=Secuencia;
				txtFecha.Text=Fecha2;
				txtUTEC.Text=Utec;
				txtLinea2.Text=Linea2;
				txtCantidad.Text=Cantidad;
				txtFamilia.Text=Familia;

				PesoInfo pkInfo= new PesoInfo();
				PesoInfo ppInfo= new PesoInfo(IdMedida,IdEspesor,IdPlanta,IdLinea);
				SICALNet.BusinessLogicLayer.Peso PPeso= new SICALNet.BusinessLogicLayer.Peso();
				pkInfo=PPeso.SelectPeso(ppInfo);
				txtKilos.Text=pkInfo.Kilos.ToString();
				txtTolen.Text=pkInfo.Tolerancia.ToString();
				txtKCT.Text=KCT;
				SICALNet.BusinessEntities.OllaInfo OInfo = new SICALNet.BusinessEntities.OllaInfo(txtSecuencia.Text,0,0);
				SICALNet.BusinessLogicLayer.Olla BlOlla = new SICALNet.BusinessLogicLayer.Olla();
				IList FillingOlla=BlOlla.SelectOllaFilling(OInfo);
				dgdQtyOlla.DataSource=FillingOlla;
				dgdQtyOlla.DataBind();
				DisplayFloorMessage();

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
			this.btnAgregarMensaje.Click += new System.EventHandler(this.btnAgregarMensaje_Click);
			this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DisplayFloorMessage()
		{
			MensajePisoInfo mpInfo = new MensajePisoInfo(txtSecuencia.Text,string.Empty,Convert.ToInt32(ConfigurationSettings.AppSettings["FillingRoomId"]));
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
			try
			{
				UpdateFillingWO();
				int IdArea= Convert.ToInt32(ConfigurationSettings.AppSettings["FillingRoomId"]);
				int IdStatus = Convert.ToInt32(ConfigurationSettings.AppSettings["StatusRelease"]); 
				SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["FillingRoomId"]),this.Context.User.Identity.Name);
				SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				BLOrdenes.UpdateLoginForm(OTInfo);
				//Activate Next Area in OrdernesTrabajo And update Active Area in Programma Production for this Secuencia
				//Depending on sequence available in "FlujoArea" Table
				FlujoArea objFlujoArea = new FlujoArea();
				objFlujoArea.ActivateDependingAreas(txtSecuencia.Text,IdArea);

				//To Release the Work Order From Current Area.
				OrdenesTrabajoInfo WOInfo = new OrdenesTrabajoInfo(txtSecuencia.Text,IdArea,IdStatus,DateTime.Now.Date.ToString("dd/MMM/yyyy"),Context.User.Identity.Name);
				SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				WorkOrder.UpdateStatus(WOInfo);

				Response.Redirect("ConsultFillingWO.aspx");

//				Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
//					"alert('"+"La Orden de Trabajo se liberó exitosamente"+"');self.location.href='ConsultFillingWO.aspx';</script>");
			}
			catch
			{
				throw;
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ConsultFillingWO.aspx");
		}

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
			try
			{
				UpdateFillingWO();
			}
			catch
			{
				throw;
			}
		}

		private void UpdateFillingWO()
		{
			int IdArea= Convert.ToInt32(ConfigurationSettings.AppSettings["FillingRoomId"]);
			SICALNet.BusinessLogicLayer.Programa Prog = new SICALNet.BusinessLogicLayer.Programa();
			Prog.UpdateKCT(txtSecuencia.Text,txtKCT.Text,IdArea);
			SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["FillingRoomId"]),this.Context.User.Identity.Name);
			SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
			BLOrdenes.UpdateLoginForm(OTInfo);
		}

		private void btnAgregarMensaje_Click(object sender, System.EventArgs e)
		{
			string Secuencia = txtSecuencia.Text.ToString();
			string IdArea= ConfigurationSettings.AppSettings["FillingRoomId"].ToString();
			string CodigoSAP=Request.QueryString["CodigoSAP"].ToString();
			string matDesc=txtUTEC.Text.Trim();
			RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodigoSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");
		}
	}
}
