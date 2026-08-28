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

using SICALNet.BusinessLogicLayer;
using SICALNet.BusinessEntities;
using SICALNet.Utilities;
using System.Configuration;

namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for ConsultQuarantineWO1.
	/// </summary>
	public class ConsultQuarantineWO1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Calendar cdrFecha;
		protected System.Web.UI.WebControls.Panel pnlCalendar;
		protected System.Web.UI.WebControls.Label lblSecuencia;
		protected System.Web.UI.WebControls.TextBox txtSecuencia;
		protected System.Web.UI.WebControls.Label lblFecha2;
		protected System.Web.UI.WebControls.TextBox txtFecha2;
		protected System.Web.UI.WebControls.Label lblUtec;
		protected System.Web.UI.WebControls.TextBox txtUtec;
		protected System.Web.UI.WebControls.Label lblCantidad;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected System.Web.UI.WebControls.Label lblFamilia;
		protected System.Web.UI.WebControls.TextBox txtFamilia;
		protected System.Web.UI.WebControls.Label lblLinea2;
		protected System.Web.UI.WebControls.TextBox txtLinea2;
		protected System.Web.UI.WebControls.DataGrid dgdEmpaque;
		protected System.Web.UI.WebControls.DataGrid dgdDefecto;
		protected System.Web.UI.WebControls.Button btnMensaje;
		protected System.Web.UI.WebControls.Button btnLiberar;
		protected System.Web.UI.WebControls.TextBox txtPiso;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.Button btnAcceptar;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.WebControls.TextBox txtMaterialRecuperado;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtOrdenRecuperacion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label7;
	
		int Sts;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetExpires(DateTime.Now);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetValidUntilExpires(false);
			Response.Cache.SetNoStore();

			// Put user code to initialize the page here
			if (!IsPostBack)
			{

				btnAcceptar.Attributes.Add("onClick","showWaitControls()");
				btnCancelar.Attributes.Add("onClick","showWaitControls()");
				btnLiberar.Attributes.Add("onClick","showWaitControls()");
				btnMensaje.Attributes.Add("onClick","showWaitControls()");

				
				Sts=Convert.ToInt32(Request.QueryString["Status"]);

				txtSecuencia.Text =Request.QueryString["Secuencia"];
				txtFecha2.Text =Request.QueryString["Fecha2"];
				txtUtec.Text =Request.QueryString["UTEC"];
				txtLinea2.Text =Request.QueryString["Linea2"];
				txtCantidad.Text =Request.QueryString["Cantidad"];
				txtFamilia.Text =Request.QueryString["Familia"];

				int IdFamilio=Convert.ToInt32(Request.QueryString["IdFamilia"]);
				int IdMedida=Convert.ToInt32(Request.QueryString["IdMedida"]);
				int IdLinea=Convert.ToInt32(Request.QueryString["IdLinea"]);
				int IdPlanta=Convert.ToInt32(Request.QueryString["IdPlanta"]);					
				string IdPresentacion=Request.QueryString["IdPresentacion"];

				//string CodigoSAP=Request.QueryString["CodigoSAP"];

				PartidasInspeccionInfo piInfo = new PartidasInspeccionInfo(IdPresentacion,IdFamilio,IdMedida,IdPlanta,IdLinea);
				// To Load the WO List
				SICALNet.BusinessLogicLayer.PartidasInspeccion paIns = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
				IList EmList = (IList)paIns.SelectEmpaque(piInfo);
				dgdEmpaque.DataSource = EmList;
				dgdEmpaque.DataBind();


				// To Load the WO List
				int IdArea = Convert.ToInt32(ConfigurationManager.AppSettings["InspeccionRoomId"]);
				PartidasInspeccionInfo piInfo2 = new PartidasInspeccionInfo(txtSecuencia.Text.ToString(),IdArea);	
				//SICALNet.BusinessLogicLayer.PartidasInspeccion paIns1 = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
				IList LmList = (IList)paIns.LoadLamina(piInfo2);
				dgdDefecto.DataSource = LmList;
				dgdDefecto.DataBind();

				int ReleaseStatus = Convert.ToInt32(ConfigurationManager.AppSettings["StatusRelease"]);
				if(Sts==ReleaseStatus)
				{
					
					MessageShow("Esta Orden de Trabajo ya ha sido Liberada.");
					btnLiberar.Enabled=false;
					btnAcceptar.Enabled=false;
					dgdDefecto.Enabled=false;
				}
				
				// Display the Messages in Multiline Text box
				DisplayFloorMessage();
				SICALNet.BusinessEntities.ProgramaInfo prgInfo = new SICALNet.BusinessEntities.ProgramaInfo(txtSecuencia.Text,string.Empty,string.Empty);
				SICALNet.BusinessLogicLayer.Programa blPrg = new SICALNet.BusinessLogicLayer.Programa();
				IList RecupList=blPrg.GetSequenceRecuperado(prgInfo);
				prgInfo = (SICALNet.BusinessEntities.ProgramaInfo)RecupList[0];
				txtMaterialRecuperado.Text=prgInfo.MaterialRecuperado;
				txtOrdenRecuperacion.Text=prgInfo.OrdenRecuperacion;
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
			this.txtMaterialRecuperado.TextChanged += new System.EventHandler(this.txtMaterialRecuperado_TextChanged);
			this.ImageButton1.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton1_Click);
			this.dgdDefecto.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdDefecto_ItemDataBound);
			this.btnMensaje.Click += new System.EventHandler(this.btnMensaje_Click);
			this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
			this.btnAcceptar.Click += new System.EventHandler(this.btnAcceptar_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
		private void DisplayFloorMessage()
		{
			// Display the Messages in Multiline Text box
			MensajePisoInfo mpInfo = new MensajePisoInfo(txtSecuencia.Text,string.Empty,Convert.ToInt32(ConfigurationManager.AppSettings["QuarantineRoomId"]));
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



		private void dgdDefecto_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				int i = dgdDefecto.Items.Count+1;	
				if (i==0) return;

				//string FPRoomId = ConfigurationManager.AppSettings["SendFinishProductRoomId"].ToString();
				switch(((Label)dgdDefecto.Controls[0].Controls[i].FindControl("lblDefArea")).Text)
				{
					case "15":
						((Label)dgdDefecto.Controls[0].Controls[i].FindControl("lblArea")).Text="Envio Producto Terminado";
						break;
					case "17":
						((Label)dgdDefecto.Controls[0].Controls[i].FindControl("lblArea")).Text="Segundas";
						break;
					case "18":
						((Label)dgdDefecto.Controls[0].Controls[i].FindControl("lblArea")).Text="Terceras";
						break;
				}

				// To Store the Area Description Combo Box.
				/*AreaInfo aInfo = new AreaInfo();
				SICALNet.BusinessLogicLayer.Area aIns = new SICALNet.BusinessLogicLayer.Area();				
				DropDownList cboAreaDestino = (DropDownList)dgdDefecto.Controls[0].Controls[i].FindControl("cmbDestino");
				IList AreaList = (IList)aIns.SelectArea();
				cboAreaDestino.DataSource=AreaList;
				cboAreaDestino.DataValueField="IdArea";
				cboAreaDestino.DataTextField="Descripcion";
				cboAreaDestino.DataBind();
				Label IdArea=(Label)dgdDefecto.Controls[0].Controls[i].FindControl("lblDefArea");
				if (IdArea.Text != "0")
					cboAreaDestino.Items.FindByValue(IdArea.Text).Selected=true;
				else
					cboAreaDestino.Items.FindByValue(FPRoomId).Selected=true;*/
				
				SICALNet.BusinessLogicLayer.PartidasInspeccion Def = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
				IList DefectoList = (IList) Def.LoadDefecto();
				
				DropDownList DDLDefecto = (DropDownList) dgdDefecto.Controls[0].Controls[i].FindControl("ddlDefecto");
				DDLDefecto.DataSource=DefectoList;
				DDLDefecto.DataValueField = "IdDefecto";
				DDLDefecto.DataTextField = "Defecto";
				DDLDefecto.DataBind();
				Label IdDefecto=(Label)dgdDefecto.Controls[0].Controls[i].FindControl("lblDefecto");
				string Cuarentena=((Label)dgdDefecto.Controls[0].Controls[i].FindControl("lblCuarentena")).Text;				
				//if (IdDefecto.Text != "")
					//DDLDefecto.Items.FindByText(IdDefecto.Text).Selected=true;


				//To Select the option button in the Radio Button List...
				Label Calidad = (Label) dgdDefecto.Controls[0].Controls[i].FindControl("lblCalidad");
				RadioButtonList RDL = (RadioButtonList) dgdDefecto.Controls[0].Controls[i].FindControl("RDLCalidad");
				//if (Calidad.Text != "0")
					RDL.Items.FindByValue(Calidad.Text).Selected=true;

				if(Calidad.Text!="1" && Cuarentena=="False")
				{	
					DDLDefecto.Items.FindByValue(IdDefecto.Text).Selected=true;
					DDLDefecto.Enabled=false;
					RDL.Enabled=false;
				}
				else if(IdDefecto.Text!="0" && Cuarentena=="True")
				{						
					DDLDefecto.Items.FindByValue(IdDefecto.Text).Selected=true;
				}
				//else
				//	RDL.Items.FindByValue("1").Selected=true; //Select 1st Quality as default

				
				// Si el material de producto terminado no maneja segundas deshabilitar la selección de segundas.

				string CodigoSAP = Request.QueryString["CodigoSAP"].ToString();
				int IdPlanta=Convert.ToInt32(Request.QueryString["IdPlanta"].ToString());

				MaterialInfo mInfo= new MaterialInfo(CodigoSAP,string.Empty,0,string.Empty,0,string.Empty,0,string.Empty,0,0,0,0,0,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,IdPlanta,false);
				SICALNet.BusinessLogicLayer.Material BRMaterial = new SICALNet.BusinessLogicLayer.Material();
				MaterialInfo mInfoAux = BRMaterial.SelectMaterial(mInfo);

				if(!mInfoAux.Segundas)
				{												
					ListItem segitem = RDL.Items.FindByValue("2");
					RDL.Items.Remove(segitem);
				}



				//If the Status of this Secuencia is Released, Disable combo boxes
				int ReleaseStatus = Convert.ToInt32( ConfigurationManager.AppSettings["StatusRelease"].ToString());
				if (Sts==ReleaseStatus)
				{
					DDLDefecto.Enabled =false;
				}
				
			}
		}

		private void btnLiberar_Click(object sender, System.EventArgs e)
		{
			try
			{
				UpdateInspection();

				int IdRelease = Convert.ToInt32(ConfigurationManager.AppSettings["StatusRelease"].ToString());
				int IdArea= Convert.ToInt32(ConfigurationManager.AppSettings["QuarantineRoomId"]);

				//			// To Get Next Area to Change that status to Activo for this WorkOrder Number
				//			FlujoAreaInfo FAInfo = new FlujoAreaInfo ( AreaId, 0 );
				//			SICALNet.BusinessLogicLayer.FlujoArea FArea = new SICALNet.BusinessLogicLayer.FlujoArea();
				//			ArrayList FAreaList = new ArrayList();
				//			FAreaList = (ArrayList) FArea.Load(FAInfo);
				//			FAInfo = (FlujoAreaInfo)FAreaList[0];
				//
				//			// To Change the Next Area Status To Active for this Work Order 
				//			int ActiveStatus = Convert.ToInt32(ConfigurationManager.AppSettings["StatusActive"].ToString());
				//			OrdenesTrabajoInfo WOInfo1 = new OrdenesTrabajoInfo(txtSecuencia.Text, FAInfo.IdArea, ActiveStatus); 
				//			SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder1 = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				//			WorkOrder1.UpdateWO(WOInfo1);
				//
				//			//Set Active Area in Programma Produccion Table for this Work Order
				//			OrdenesTrabajoInfo ProgramaInfo = new OrdenesTrabajoInfo(txtSecuencia.Text,FAInfo.IdArea,0);
				//			SICALNet.BusinessLogicLayer.Programa ProgramaStatus = new SICALNet.BusinessLogicLayer.Programa();
				//			ProgramaStatus.UpdateProgramaActiveArea(ProgramaInfo);



				//Activate Next Area And update Active Area in Programma Production for this Secuencia
				//Depending on sequence available in "FlujoArea" Table
				FlujoArea objFlujoArea = new FlujoArea();
				objFlujoArea.ActivateDependingAreas(txtSecuencia.Text,IdArea);

				//Release Work Order From Current Area.
				OrdenesTrabajoInfo WOInfo = new OrdenesTrabajoInfo(txtSecuencia.Text,IdArea,IdRelease,DateTime.Now.Date.ToString("dd/MMM/yyyy"),Context.User.Identity.Name);
				SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				WorkOrder.UpdateStatus(WOInfo);

			
				dgdDefecto.Enabled=false;
				btnLiberar.Enabled=false;
				btnAcceptar.Enabled = false;

//				MessageShowLiberar("La Orden de Trabajo se libero exitosamente");				
				
				Response.Redirect("ConsultQuarantineWO.aspx");
			}
			catch
			{
				throw;
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ConsultQuarantineWO.aspx");
		}

		private void btnMensaje_Click(object sender, System.EventArgs e)
		{
			string Secuencia = txtSecuencia.Text.ToString();
			string IdArea= ConfigurationManager.AppSettings["QuarantineRoomId"].ToString();
			string CodigoSAP=Request.QueryString["CodigoSAP"].ToString();
			string matDesc=txtUtec.Text.Trim();
			RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodigoSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");		
		}

		private void btnAcceptar_Click(object sender, System.EventArgs e)
		{
		
			try
			{
				UpdateInspection();
				MessageShow("La orden de trabajo se actualizó safisfactoriamente");

			}
			catch
			{
				//to display the msg for user
//				string ScriptString="<script language='javascript'>alert('"+ errHand.Message +"');</script>"; 
//				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
				
				throw;
			}

			
		}


		private void UpdateInspection()
		{
		
			IList InspList = new ArrayList();
//			int IdQuarantineArea = Convert.ToInt32(ConfigurationManager.AppSettings["QuarantineRoomId"]);
			SICALNet.Utilities.Validation pltVlt = new SICALNet.Utilities.Validation();
			if(txtMaterialRecuperado.Text!=string.Empty||txtMaterialRecuperado.Text!="")
				if(!pltVlt.IsWholeNumber(txtOrdenRecuperacion.Text)||txtOrdenRecuperacion.Text==string.Empty||txtOrdenRecuperacion.Text=="")
					throw new Exception("Favor de proporcionar el campo -No. Orden de Recuperación-");
			if(txtOrdenRecuperacion.Text!=string.Empty||txtOrdenRecuperacion.Text!="")
				if(!pltVlt.IsWholeNumber(txtMaterialRecuperado.Text)||txtMaterialRecuperado.Text==string.Empty||txtOrdenRecuperacion.Text=="")
					throw new Exception("Favor de proporcionar el campo -Material Recuperado-");

			for (int i=0; i<dgdDefecto.Items.Count; i++)
			{
                			
				int NoLamina = Convert.ToInt32(((Label)dgdDefecto.Items[i].FindControl("lblLamina")).Text);
				//int Calificacion = Convert.ToInt32(((RadioButtonList) dgdDefecto.Items[i].FindControl("RDLCalidad")).SelectedItem.Value);
				//int IdAreaDestino = Convert.ToInt32(((DropDownList)dgdDefecto.Items[i].FindControl("cmbDestino")).SelectedItem.Value);
				int Calificacion = Convert.ToInt32(((RadioButtonList) dgdDefecto.Items[i].FindControl("RDLCalidad")).SelectedItem.Value);
				//int IdAreaDestino = Convert.ToInt32(((Label)dgdDefecto.Items[i].FindControl("lblAreaId")).Text);
				switch(Calificacion)
				{
					case 1:
						PartidasInspeccionInfo pInfo = new PartidasInspeccionInfo(txtSecuencia.Text,0,NoLamina,Calificacion,0,Convert.ToInt32(ConfigurationManager.AppSettings["SendFinishProductRoomId"]));
						InspList.Add(pInfo);
						break;
					case 2:
						int IdDefecto = Convert.ToInt32(((DropDownList)dgdDefecto.Items[i].FindControl("ddlDefecto")).SelectedItem.Value);
						pInfo = new PartidasInspeccionInfo(txtSecuencia.Text,0,NoLamina,Calificacion,IdDefecto,Convert.ToInt32(ConfigurationManager.AppSettings["SegundasRoomId"]));
						InspList.Add(pInfo);
						break;
					case 3:
						IdDefecto = Convert.ToInt32(((DropDownList)dgdDefecto.Items[i].FindControl("ddlDefecto")).SelectedItem.Value);
						pInfo = new PartidasInspeccionInfo(txtSecuencia.Text,0,NoLamina,Calificacion,IdDefecto,Convert.ToInt32(ConfigurationManager.AppSettings["TercerasRoomId"]));
						InspList.Add(pInfo);
						break;

				}
//				if (Calificacion > 1)
//				{
//					int IdDefecto = Convert.ToInt32(((DropDownList)dgdDefecto.Items[i].FindControl("ddlDefecto")).SelectedItem.Value);
//
//					PartidasInspeccionInfo pInfo = new PartidasInspeccionInfo(txtSecuencia.Text,IdInspectArea,NoLamina,Calificacion,IdDefecto,IdAreaDestino);
//					InspList.Add(pInfo);
//				}
//				else
//				{
					//PartidasInspeccionInfo pInfo = new PartidasInspeccionInfo(txtSecuencia.Text,0,NoLamina,0,0,IdAreaDestino);
					//InspList.Add(pInfo);
//				}					
			}
			
			SICALNet.BusinessLogicLayer.PartidasInspeccion BLLInsp = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
			BLLInsp.UpdateInspeccion(InspList);
			SICALNet.BusinessLogicLayer.Programa blPrograma = new SICALNet.BusinessLogicLayer.Programa();
			/*
			string Recuperado=string.Empty;
			string Orden=string.Empty;
			if(txtMaterialRecuperado.Text!=string.Empty||txtMaterialRecuperado.Text!="")
			{
				Recuperado=txtMaterialRecuperado.Text;
				Orden=txtOrdenRecuperacion.Text;
			}
			*/
			blPrograma.UpdateRecuperado(txtSecuencia.Text,txtMaterialRecuperado.Text,txtOrdenRecuperacion.Text);
			SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text,Convert.ToInt32(ConfigurationManager.AppSettings["QuarantineRoomId"]),Context.User.Identity.Name);
			SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
			BLOrdenes.UpdateLoginForm(OTInfo);
			
		}

		private void MessageShow(string Msg)
		{
			Page.RegisterStartupScript("alert", "<script language='JavaScript'>alert('"+ Msg +"');</script>");

		}

//		private void MessageShowLiberar(string Msg)
//		{
//			Page.RegisterStartupScript("alert", "<script language='JavaScript'>alert('"+ Msg +"');self.location.href='ConsultQuarantineWO.aspx';</script>");
//
//		}

		private void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('../Structures/FindMaterial.aspx?Form=ConsultQuarantineWO1&CtrlName=txtMaterialRecuperado&CtrlName2=txtDescripcion&flag=1','anycontent','width=600,height=400,left=100, top=150,status,scrollbars=yes'); </script>");
		}

		private void txtMaterialRecuperado_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(txtMaterialRecuperado.Text!=string.Empty||txtMaterialRecuperado.Text!="")
				{
					int IdPlantaAux=Convert.ToInt32(Request.QueryString["IdPlanta"]);	
					MaterialInfo BEmat=new MaterialInfo(txtMaterialRecuperado.Text,"",0,"",0,string.Empty,0,string.Empty,0,0,0,0,0,"","","","","","","","","",IdPlantaAux,false);
					Material BLLMat = new Material();
					IList RsMaterial = BLLMat.SelectMaterialList(BEmat);
					if (RsMaterial.Count == 0)
						throw new Exception(string.Format("No se pudieron cargar los detalles del producto {0}",txtMaterialRecuperado.Text));
					MaterialInfo BEmaterial = (MaterialInfo) RsMaterial[0];
					txtDescripcion.Text=BEmaterial.Descripcion;
				}
				
			}
			catch
			{
//				//to display the msg for user
//				string ScriptString="<script language='javascript'>alert('"+ errHand.Message +"');</script>"; 
//				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
//				txtDescripcion.Text=string.Empty;

				throw;
			}


		}

        protected void dgdEmpaque_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
