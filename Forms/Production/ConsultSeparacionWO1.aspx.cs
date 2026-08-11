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
	/// Summary description for ConsultSeparacionWO1.
	/// </summary>
	public class ConsultSeparacionWO1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cmdAgregar;
		protected System.Web.UI.WebControls.Button cmdLiberar;
		protected System.Web.UI.WebControls.Button btnAgregar;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.TextBox txtSecuencia;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.TextBox txtUTEC;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected System.Web.UI.WebControls.TextBox txtFamilia;
		protected System.Web.UI.WebControls.TextBox txtLinea;
		protected System.Web.UI.WebControls.TextBox txtPiso;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label8;

		string Status;
		//string CodigoSAP;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetExpires(DateTime.Now);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetValidUntilExpires(false);
			Response.Cache.SetNoStore();

			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				cmdAgregar.Attributes.Add("onClick","showWaitControls()");
				cmdLiberar.Attributes.Add("onClick","showWaitControls()");
				btnAgregar.Attributes.Add("onClick","showWaitControls()");
				btnCancelar.Attributes.Add("onClick","showWaitControls()");

				txtSecuencia.Text = Request.QueryString["Secuencia"];
				txtFecha.Text = Request.QueryString["Fecha"];
				txtUTEC.Text = Request.QueryString["UTEC"];
				txtCantidad.Text = Request.QueryString["Cantidad"];
				txtFamilia.Text = Request.QueryString["FamiliaDesc"];
				txtLinea.Text = Request.QueryString["LineaDesc"];
				Status = Request.QueryString["StatusId"];
				//CodigoSAP = Request.QueryString["CodigoSAP"];

				string ReleaseStatus = ConfigurationSettings.AppSettings["StatusRelease"].ToString();
				if (Status == ReleaseStatus)
				{
					btnAgregar.Enabled=false;
					cmdLiberar.Enabled = false;
					cmdAgregar.Enabled=false;
				}

				// Display the Messages in Multiline Text box
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
			this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
			this.cmdLiberar.Click += new System.EventHandler(this.cmdLiberar_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DisplayFloorMessage()
		{
			// Display the Messages in Multiline Text box
			MensajePisoInfo mpInfo = new MensajePisoInfo(txtSecuencia.Text,string.Empty,Convert.ToInt32(ConfigurationSettings.AppSettings["SeparacionRoomId"]));
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


		private void cmdLiberar_Click(object sender, System.EventArgs e)
		{
			
//			// To Get Next Area to Change that status to Activo for this WorkOrder Number
//			FlujoAreaInfo FAInfo = new FlujoAreaInfo ( Convert.ToInt32(ConfigurationSettings.AppSettings["SeparacionRoomId"]), 0 );
//			SICALNet.BusinessLogicLayer.FlujoArea FArea = new SICALNet.BusinessLogicLayer.FlujoArea();
//			ArrayList FAreaList = new ArrayList();
//			FAreaList = (ArrayList) FArea.Load(FAInfo);
//			FAInfo = (FlujoAreaInfo)FAreaList[0];
//
//			// To Change the Next Area Status To Active for this Work Order 
//			int ActiveStatus = Convert.ToInt32(ConfigurationSettings.AppSettings["StatusActive"].ToString());
//			OrdenesTrabajoInfo WOInfo1 = new OrdenesTrabajoInfo(txtSecuencia.Text, FAInfo.IdArea, ActiveStatus); // 2 - Active
//			SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder1 = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
//			WorkOrder1.UpdateWO(WOInfo1);
//
//			//Set Active Area in Programma Produccion Table.
//			OrdenesTrabajoInfo ProgramaInfo = new OrdenesTrabajoInfo(txtSecuencia.Text,FAInfo.IdArea,0);
//			SICALNet.BusinessLogicLayer.Programa ProgramaStatus = new SICALNet.BusinessLogicLayer.Programa();
//			ProgramaStatus.UpdateProgramaActiveArea(ProgramaInfo);
			
			try
			{
				int IdArea = Convert.ToInt32(ConfigurationSettings.AppSettings["SeparacionRoomId"]);
				int IdStatus =  Convert.ToInt32( ConfigurationSettings.AppSettings["StatusRelease"].ToString());
			
				//Activate Next Area in OrdernesTrabajo And update Active Area in Programma Production for this Secuencia
				//Depending on sequence available in "FlujoArea" Table
				FlujoArea objFlujoArea = new FlujoArea();
				objFlujoArea.ActivateDependingAreas(txtSecuencia.Text,IdArea);

				// To Release the Work Order from the Current Phase.
				OrdenesTrabajoInfo WOInfo = new OrdenesTrabajoInfo(txtSecuencia.Text, IdArea, IdStatus, DateTime.Now.Date.ToString("dd/MMM/yyyy"), Context.User.Identity.Name); // 2 - Active
				SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				WorkOrder.UpdateStatus(WOInfo);

				cmdLiberar.Enabled=false;
				Response.Redirect("ConsultSeparacionWO.aspx");
//				Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"La Orden de Trabajo se libero exitosamente"+"');self.location.href='ConsultSeparacionWO.aspx';</script>");
			}
			catch
			{
				throw;
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ConsultSeparacionWO.aspx");
		}

		private void cmdAgregar_Click(object sender, System.EventArgs e)
		{
			string Secuencia = txtSecuencia.Text.ToString();
			string IdArea= ConfigurationSettings.AppSettings["SeparacionRoomId"].ToString();
			string CodigoSAP=Request.QueryString["CodigoSAP"].ToString();
			string matDesc=txtUTEC.Text.Trim();
			RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodigoSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");
		}
	}
}
