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
	/// Summary description for ConsultAssembleWO1.
	/// </summary>
	public class ConsultAssembleWO1 : System.Web.UI.Page
	{
	
		int IdFamiliaProducto, IdMedida, IdLinea;
		string IdEspesor;
		int IdArea, IdStatus;
		string Secuencia,Fecha1,UTEC,Cantidad,DescFamiliaProducto;
		protected System.Web.UI.WebControls.DataGrid dgdFormPVC;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.TextBox txtSecuencia;
		protected System.Web.UI.WebControls.TextBox txtFecha1;
		protected System.Web.UI.WebControls.TextBox txtUTEC;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected System.Web.UI.WebControls.TextBox txtDescFamiliaProducto;
		protected System.Web.UI.WebControls.TextBox txtPiso;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Button btnAgregarMensaje;
		protected System.Web.UI.WebControls.Button btnLiberar;
		protected System.Web.UI.WebControls.Button btnAgregar;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label6;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetExpires(DateTime.Now);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetValidUntilExpires(false);
			Response.Cache.SetNoStore();
			
			btnAgregar.Attributes.Add("onClick","showWaitControls()");
			btnAgregarMensaje.Attributes.Add("onClick","showWaitControls()");
			btnCancel.Attributes.Add("onClick","showWaitControls()");
			btnLiberar.Attributes.Add("onClick","showWaitControls()");


			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				IdArea = Convert.ToInt32(ConfigurationManager.AppSettings["AssembleRoomId"]);  //Area for Assemble Room
				Secuencia = Request.QueryString["Secuencia"].ToString();
				Fecha1 =  Request.QueryString["Fecha1"].ToString();
				UTEC = Request.QueryString["UTEC"].ToString();
				Cantidad = Request.QueryString["Cantidad"].ToString();
				DescFamiliaProducto = Request.QueryString["DescFamiliaProducto"].ToString();
				IdFamiliaProducto = Convert.ToInt32(Request.QueryString["IdFamiliaProducto"].ToString());
				IdLinea = Convert.ToInt32(Request.QueryString["IdLinea"].ToString());
				IdMedida = Convert.ToInt32(Request.QueryString["IdMedida"].ToString());
				IdEspesor = Request.QueryString["IdEspesor"].ToString();
				IdStatus=Convert.ToInt32(Request.QueryString["IdStatus"].ToString());
				int IdPlanta = Convert.ToInt32(Request.QueryString["IdPlanta"].ToString());

				txtSecuencia.Text = Secuencia;
				txtFecha1.Text =  Fecha1;
				txtUTEC.Text = UTEC;
				txtCantidad.Text = Cantidad;
				txtDescFamiliaProducto.Text = DescFamiliaProducto;

				if (IdStatus==Convert.ToInt32(ConfigurationManager.AppSettings["StatusRelease"]))
				{
					btnLiberar.Enabled=false;
					btnAgregar.Enabled=false;
				}
				// agredamos un parametro mas idacabado
				int idAcabado = getIdAcabado(Request.QueryString["codigoSAP"].ToString(),IdPlanta);
				FormPVCInfo fpInfo = new FormPVCInfo(IdFamiliaProducto, IdMedida, IdEspesor,IdPlanta,idAcabado,IdLinea);
				SICALNet.BusinessLogicLayer.FormPVC pPVC = new SICALNet.BusinessLogicLayer.FormPVC();
				IList FormPVCList = (IList)pPVC.Select(fpInfo);
				dgdFormPVC.DataSource = FormPVCList;
				dgdFormPVC.DataBind();

				// Display the Messages in Multiline Text box
				DisplayFloorMessage();

			}

			// Verifica si el estatus esta    StatusActive = 2
			// Verifica si el estatus esta StatusInProcess = 3

			/*
			if (Request.QueryString["IdStatus"].ToString()==ConfigurationManager.AppSettings["StatusActive"].ToString() 
				&& Request.QueryString["IdStatus"].ToString()==ConfigurationManager.AppSettings["StatusInProcess"].ToString())
			*/

			if (IdStatus==2 && IdStatus==3)
			{
				btnAgregar.Enabled=false;
				btnLiberar.Enabled=false;
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

		private int getIdAcabado(string codigoSAP, int idPlanta)
		{
			MaterialInfo theMaterial = new MaterialInfo(codigoSAP,idPlanta);
			Material bllMaterial = new Material();
			theMaterial = bllMaterial.SelectMaterial(theMaterial);

			return theMaterial.IdAcabado;
		}

		private void btnLiberar_Click(object sender, System.EventArgs e)
		{
			try
			{
				int idArea=Convert.ToInt32(ConfigurationManager.AppSettings["AssembleRoomId"]);
				int idStatus=Convert.ToInt32(ConfigurationManager.AppSettings["StatusRelease"]);
	
				//Activate Next Area And update Active Area in Programma Production for this Secuencia
				//Depending on sequence available in "FlujoArea" Table
				FlujoArea objFlujoArea = new FlujoArea();
				objFlujoArea.ActivateDependingAreas(txtSecuencia.Text,idArea);

				OrdenesTrabajoInfo WOInfo = new OrdenesTrabajoInfo(txtSecuencia.Text,idArea,idStatus,DateTime.Now.Date.ToString("dd/MMM/yyyy"),Context.User.Identity.Name);
				SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				WorkOrder.UpdateStatus(WOInfo);
				SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text,idArea,Context.User.Identity.Name);
				SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				BLOrdenes.UpdateLoginForm(OTInfo);

				Response.Redirect("ConsultAssembleWO.aspx");
//				Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
//					"alert('"+"La Orden de Trabajo para la secuencia "+ txtSecuencia.Text +" se libero exitosamente"+"');self.location.href='ConsultAssembleWO.aspx';</script>");

			}
			catch
			{
				throw;
			}
		}


		private void DisplayFloorMessage()
		{
			// Display the Messages in Multiline Text box
			MensajePisoInfo mpInfo = new MensajePisoInfo(txtSecuencia.Text,string.Empty,Convert.ToInt32(ConfigurationManager.AppSettings["AssembleRoomId"]));
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

		private void btnAgregarMensaje_Click(object sender, System.EventArgs e)
		{
			string Secuencia = txtSecuencia.Text.ToString();
			string IdArea= ConfigurationManager.AppSettings["AssembleRoomId"].ToString();
			string CodigoSAP=Request.QueryString["CodigoSAP"].ToString();
			string matDesc=txtUTEC.Text.Trim();
			RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodigoSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");	
		}

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ConsultAssembleWO.aspx");
		}


	}

}
