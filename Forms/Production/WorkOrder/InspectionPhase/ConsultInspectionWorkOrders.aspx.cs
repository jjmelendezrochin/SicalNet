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
using System.Data.SqlClient;
using System.Configuration;
using SICALNet.BusinessEntities;
using Microsoft.ApplicationBlocks.Data;
using SICALNet.Utilities;
using SICALNet.BusinessLogicLayer;
using CrystalDecisions.Shared;
using System.Threading;
using System.Data.OleDb;


namespace UserInterface.Forms.Production.WorkOrder.InspectionPhase
{
	/// <summary>
	/// Summary description for ConsultInspectionWorkOrders.
	/// </summary>
	public class ConsultInspectionWorkOrders : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblSecuencia;
		protected System.Web.UI.WebControls.Label lblFecha2;
		protected System.Web.UI.WebControls.Label lblUtec;
		protected System.Web.UI.WebControls.Label lblCantidad;
		protected System.Web.UI.WebControls.Label lblFamilia;
		protected System.Web.UI.WebControls.TextBox txtFamilia;
		protected System.Web.UI.WebControls.Label lblLinea2;
		protected System.Web.UI.WebControls.TextBox txtLinea2;
		protected System.Web.UI.WebControls.DataGrid dgdEmpaque;
		protected System.Web.UI.WebControls.DataGrid dgdDefecto;
		protected System.Web.UI.WebControls.Button btnMensaje;
		protected System.Web.UI.WebControls.Button btnLiberar;
		protected System.Web.UI.WebControls.Button btnAceptar;
		protected System.Web.UI.WebControls.Button btnCancelar;

		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.TextBox txtPiso;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.TextBox txtSecuencia;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.TextBox txtUtec;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnQuarentine;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label8;

		private int Sts;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);


			if (IsPostBack) return;

			btnAceptar.Attributes.Add("onClick","showWaitControls()");
			btnCancelar.Attributes.Add("onClick","showWaitControls()");
			btnLiberar.Attributes.Add("onClick","showWaitControls()");
			btnMensaje.Attributes.Add("onClick","showWaitControls()");
			btnQuarentine.Attributes.Add("onClick","showWaitControls()");

			// Put user code to initialize the page here
			Sts=Convert.ToInt32(Request.QueryString["Status"].ToString());
			txtSecuencia.Text = Request.QueryString["Secuencia"].ToString();
			txtFecha.Text=Request.QueryString["Fecha2"].ToString();
			txtUtec.Text=Request.QueryString["UTEC"].ToString();
			txtLinea2.Text=Request.QueryString["Linea2"].ToString();
			txtCantidad.Text=Request.QueryString["Cantidad"].ToString();
			txtFamilia.Text=Request.QueryString["Familia"].ToString();
			
			int IdFamilio=Convert.ToInt32(Request.QueryString["IdFamilio"].ToString());
			int IdMedida=Convert.ToInt32(Request.QueryString["IdMedida"].ToString());
			int IdLinea=Convert.ToInt32(Request.QueryString["IdLinea"].ToString());
			int IdPlanta=Convert.ToInt32(Request.QueryString["IdPlanta"].ToString());					
			string IdPresentacion=Request.QueryString["IdPresentacion"].ToString();					

			// To Load the Empaque List Grid
			PartidasInspeccionInfo piInfo = new PartidasInspeccionInfo(IdPresentacion,IdFamilio,IdMedida,IdPlanta,IdLinea);
			SICALNet.BusinessLogicLayer.PartidasInspeccion paIns = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
			IList EmList = (IList)paIns.SelectEmpaque(piInfo);
			dgdEmpaque.DataSource = EmList;
			dgdEmpaque.DataBind();
			
			// To Load the WO List Grid
			int IdArea = Convert.ToInt32( ConfigurationManager.AppSettings["InspeccionRoomId"]);
			PartidasInspeccionInfo piInfo2 = new PartidasInspeccionInfo(txtSecuencia.Text.ToString(),IdArea);
			// SICALNet.BusinessLogicLayer.PartidasInspeccion paIns1 = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
			IList LmList = (IList)paIns.LoadLamina(piInfo2);
			if (LmList.Count != 0)
			{
				dgdDefecto.DataSource = LmList;
				dgdDefecto.DataBind();
			}
			else
			{
				ArrayList LaminaCount= new ArrayList();
				for(int i=1; i<=Convert.ToInt32(txtCantidad.Text); i++)
				{
					PartidasInspeccionInfo InspecInfo = new PartidasInspeccionInfo(i,0,string.Empty ,Convert.ToInt32(ConfigurationManager.AppSettings["SendFinishProductRoomId"]),false,false,false,false);
					LaminaCount.Add(InspecInfo);
				}
				dgdDefecto.DataSource = LaminaCount;
				dgdDefecto.DataBind();
			}

			int ReleaseStatus = Convert.ToInt32(ConfigurationManager.AppSettings["StatusRelease"].ToString());
			if(Sts==ReleaseStatus)
			{
				btnLiberar.Enabled=false;
				btnAceptar.Enabled=false;
				btnQuarentine.Enabled=false;
				for(int i=1; i<=dgdDefecto.Items.Count; i++)
				{
					((RadioButtonList)dgdDefecto.Controls[0].Controls[i].FindControl("RDLCalidad")).Enabled=false;
					String sSel = ((RadioButtonList)dgdDefecto.Controls[0].Controls[i].FindControl("RDLCalidad")).SelectedValue;
					DropDownList DDLDefecto = (DropDownList) dgdDefecto.Controls[0].Controls[i].FindControl("ddlDefecto");
					if(sSel=="2" || sSel=="3")
					{
						DDLDefecto.Visible=true; 
						DDLDefecto.Visible=true; 
						DDLDefecto.Visible=true; 
						DDLDefecto.Enabled=true;
						DDLDefecto.Enabled=true;
						DDLDefecto.Enabled=true;
						//if (DDLDefecto.Visible) DDLDefecto.Enabled=false;
					}				
				}				
				Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
					"alert('"+"La orden de trabajo ya ha sido liberada."+"')"+
					"<" + "/script>");
			}

			//btnLiberar.Attributes.Add("onclick","return cofirm('Are you sure you want to release this secuencia to Envio Producto Terminado?');");
			//btnQuarentine.Attributes.Add("onclick","return cofirm('Are you sure you want to release this secuencia to Quarentine?');");

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
			this.dgdDefecto.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdDefecto_ItemCommand);
			this.dgdDefecto.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdDefecto_ItemDataBound);
			this.btnMensaje.Click += new System.EventHandler(this.btnMensaje_Click);
			this.btnQuarentine.Click += new System.EventHandler(this.btnQuarentine_Click);
			this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DisplayFloorMessage()
		{
			// Display the Messages in Multiline Text box
			MensajePisoInfo mpInfo = new MensajePisoInfo(txtSecuencia.Text,string.Empty,Convert.ToInt32(ConfigurationManager.AppSettings["InspeccionRoomId"]));
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
				
				// string FPRoomId = ConfigurationManager.AppSettings["SendFinishProductRoomId"].ToString();
				switch(((Label)dgdDefecto.Controls[0].Controls[i].FindControl("lblAreaId")).Text)
				{
					case "15":
						((Label)dgdDefecto.Controls[0].Controls[i].FindControl("lblDefArea")).Text="Envio Producto Terminado";
						break;
					case "17":
						((Label)dgdDefecto.Controls[0].Controls[i].FindControl("lblDefArea")).Text="Segundas";
						break;
					case "18":
						((Label)dgdDefecto.Controls[0].Controls[i].FindControl("lblDefArea")).Text="Terceras";
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

				// To Store the Defecto Combo Box.
				SICALNet.BusinessLogicLayer.PartidasInspeccion Def = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
				IList DefectoList = (IList) Def.LoadDefecto();
				
				DropDownList DDLDefecto = (DropDownList) dgdDefecto.Controls[0].Controls[i].FindControl("ddlDefecto");
				DDLDefecto.DataSource=DefectoList;
				DDLDefecto.DataValueField = "IdDefecto";
				DDLDefecto.DataTextField = "Defecto";
				DDLDefecto.DataBind();
				Label IdDefecto=(Label)dgdDefecto.Controls[0].Controls[i].FindControl("lblDefecto");
				Label lblReactivado=(Label)dgdDefecto.Controls[0].Controls[i].FindControl("lblReactivado");
				Label lblCuarentena=(Label)dgdDefecto.Controls[0].Controls[i].FindControl("lblCuarentena");


				Label lblDescripcionDefecto=(Label)dgdDefecto.Controls[0].Controls[i].FindControl("lblDescripcionDefecto");
							
				if (IdDefecto.Text != "0")
				{
					DDLDefecto.Items.FindByValue(IdDefecto.Text).Selected=true;
					if(lblReactivado.Text=="False")
					{ 
							DDLDefecto.Enabled=false;						
					}
					else
					{
						if(lblCuarentena.Text=="True")
						{
							DDLDefecto.Enabled=false;
						}						
					}
				
					string sDefecto = "";
					string sConsulta = "Select Descripcion from Defecto where idDefecto = " + IdDefecto.Text ;
					using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
					{						
						using (SqlDataReader RsDefecto = SqlHelper.ExecuteReader(ConfigurationManager.AppSettings["SICALConnString"], CommandType.Text, sConsulta)) 
						{
							while (RsDefecto.Read()) 
							{			
								sDefecto = RsDefecto["Descripcion"].ToString();
							}
						}
					}
					lblDescripcionDefecto.Text= sDefecto;
					lblDescripcionDefecto.Visible = true;
 				}

				//To Select the option button in the Radio Button List...
				Label Calidad = (Label) dgdDefecto.Controls[0].Controls[i].FindControl("lblCalidad");
				RadioButtonList RDL = (RadioButtonList) dgdDefecto.Controls[0].Controls[i].FindControl("RDLCalidad");
				if (Calidad.Text != "0")
					RDL.Items.FindByValue(Calidad.Text).Selected=true;
				else
					RDL.Items.FindByValue("1").Selected=true; //Select 1st Quality as default
				if(Calidad.Text!="1" && Calidad.Text!="0")
				{
					if(lblReactivado.Text=="False")
					{
						RDL.Enabled=false;	
					}
					else
					{
						if(lblCuarentena.Text=="True")
						{
							RDL.Enabled=false;
						}						
					}

				}	

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
					DDLDefecto.Enabled=false;
					//cboAreaDestino.Enabled =false;
				}

			}
		}

		public void OnSelectionChanged(object sender,EventArgs e)
		{
			RadioButtonList rdl = (RadioButtonList) sender;
			
			//To get the string "ctl2" - that is available between "_" of the Client ID
			//Client Id Example = "dgdDefecto__ctl2__

			/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/
			//RadioButtonList rblSender = rdl;
			string id = rdl.ClientID ;							//Get the Client ID
			//string id =(((RadioButtonList)sender).ClientID);
			/*** fin de modificación ***///Get the Client ID
			int First = id.IndexOf("_");												// Get the First Underscore("_") Position
			int Second = id.LastIndexOf("_");											// Get the Next Underscore("_") Position
			int Index = Convert.ToInt32((id.Substring(0,Second)).Substring(First+5));	//Get that index ("2") which is avilable after "ctl"
			
			DropDownList ddDefecto = (DropDownList) dgdDefecto.Controls[0].Controls[Index-1].FindControl("ddlDefecto");
			Label IdAreaDestino =(Label) dgdDefecto.Controls[0].Controls[Index-1].FindControl("lblAreaId");
			Label AreaDestino = (Label) dgdDefecto.Controls[0].Controls[Index-1].FindControl("lblDefArea");
			//DropDownList ddArea = (DropDownList) dgdDefecto.Controls[0].Controls[Index-1].FindControl("cmbDestino");

			/*if (Convert.ToInt32(rdl.SelectedItem.Value)>1)
			{
				ddDefecto.Visible=true;
			}
			else
			{
				ddDefecto.Visible=false;
			}*/
			switch(Convert.ToInt32(rdl.SelectedItem.Value))
			{
				case 1:
					ddDefecto.Visible=false;
					IdAreaDestino.Text=ConfigurationManager.AppSettings["SendFinishProductRoomId"];
					AreaDestino.Text="Envio Producto Terminado";
					break;
				case 2:
					ddDefecto.Visible=true;
					IdAreaDestino.Text=ConfigurationManager.AppSettings["SegundasRoomId"];
					AreaDestino.Text="Segundas";
					break;
				case 3:
					ddDefecto.Visible=true;
					IdAreaDestino.Text=ConfigurationManager.AppSettings["TercerasRoomId"];
					AreaDestino.Text="Terceras";
					break;

			}
		}

		private void dgdDefecto_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{

		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			try
			{
				InsertInspection();
				Response.Redirect("ConsultInspectionWO.aspx");
			}
			catch
			{
				throw;
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Session["InitialDate"]=txtFecha.Text;
			Session["FinalDate"]=txtFecha.Text;
			Response.Redirect("ConsultInspectionWO.aspx");
		}

		private void btnLiberar_Click(object sender, System.EventArgs e)
		{
			try
			{
				InsertInspection();
				int AreaId= Convert.ToInt32(ConfigurationManager.AppSettings["InspeccionRoomId"]);
				int IdRelease = Convert.ToInt32(ConfigurationManager.AppSettings["StatusRelease"].ToString());
				int IdActive = Convert.ToInt32(ConfigurationManager.AppSettings["StatusActive"]);
				int QuarantineRoomId= Convert.ToInt32(ConfigurationManager.AppSettings["QuarantineRoomId"]);

				//Release the Inspeccion Phase
				OrdenesTrabajoInfo WOInfo = new OrdenesTrabajoInfo(txtSecuencia.Text,AreaId,IdRelease,DateTime.Now.Date.ToString("dd/MMM/yyyy"),Context.User.Identity.Name);
				SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder1 = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				WorkOrder1.UpdateStatus(WOInfo);
				// If there is any damage occured, Cuarantine phase become Active
				/*bool CuarantineActive=false;
				for ( int i=0; i<dgdDefecto.Items.Count; i++)
				{
					//RadioButtonList rdl = (RadioButtonList) dgdDefecto.Items[i].FindControl("RDLCalidad");
					DropDownList ddl = (DropDownList) dgdDefecto.Items[i].FindControl("cmbDestino");
					if (Convert.ToInt32(ddl.SelectedItem.Value) == QuarantineRoomId)
					{
						CuarantineActive = true;
						break;

					}
				}*/
			
			

				//if (CuarantineActive)
				/*{

					//Active - to Cuarantine Phase\
					OrdenesTrabajoInfo WOInfo1 = new OrdenesTrabajoInfo(txtSecuencia.Text,QuarantineRoomId,IdActive,DateTime.Now.Date.ToString("dd/MMM/yyyy"),this.Context.User.Identity.Name);
					SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
					WorkOrder.UpdateStatus(WOInfo1);

					//Set Active Area in Programma Produccion Table.
					OrdenesTrabajoInfo ProgramaInfo = new OrdenesTrabajoInfo(txtSecuencia.Text,QuarantineRoomId,0);
					SICALNet.BusinessLogicLayer.Programa ProgramaStatus = new SICALNet.BusinessLogicLayer.Programa();
					ProgramaStatus.UpdateProgramaActiveArea(ProgramaInfo);

				}
				else
				{*/
				//Release - to Cuarantine Phase
				OrdenesTrabajoInfo WOInfo1 = new OrdenesTrabajoInfo(txtSecuencia.Text,QuarantineRoomId,IdRelease,DateTime.Now.Date.ToString("dd/MMM/yyyy"),Context.User.Identity.Name);
				SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				WorkOrder.UpdateStatus(WOInfo1);

				//Active - to Send Finish Product Phase
				int IdAreaFP= Convert.ToInt32(ConfigurationManager.AppSettings["SendFinishProductRoomId"]);
				OrdenesTrabajoInfo WOInfo2 = new OrdenesTrabajoInfo(txtSecuencia.Text,IdAreaFP,IdActive,DateTime.Now.Date.ToString("dd/MMM/yyyy"),Context.User.Identity.Name);
				SICALNet.BusinessLogicLayer.OrdenesTrabajo WOFP = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				WOFP.UpdateStatus(WOInfo2);
	
				//Set Active Area in Programma Produccion Table.
				OrdenesTrabajoInfo ProgramaInfo = new OrdenesTrabajoInfo(txtSecuencia.Text,IdAreaFP,0);
				SICALNet.BusinessLogicLayer.Programa ProgramaStatus = new SICALNet.BusinessLogicLayer.Programa();
				ProgramaStatus.UpdateProgramaActiveArea(ProgramaInfo);
				PartidasInspeccionInfo piInfo2 = new PartidasInspeccionInfo(txtSecuencia.Text.ToString(),AreaId);
				SICALNet.BusinessLogicLayer.PartidasInspeccion paIns1 = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
				IList LmList = (IList)paIns1.LoadLamina(piInfo2);
				if (LmList.Count != 0)
				{
					dgdDefecto.DataSource = LmList;
					dgdDefecto.DataBind();
				}
				

				//}				
			

				//				Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
//					"alert('"+"La Orden de Trabajo se liberó exitosamente"+"');self.location.href='ConsultInspectionWO.aspx';</script>");

				btnLiberar.Enabled=false;
				btnAceptar.Enabled=false;
				btnQuarentine.Enabled=false;

				for(int i=1; i<=dgdDefecto.Items.Count; i++)
				{
					((RadioButtonList)dgdDefecto.Controls[0].Controls[i].FindControl("RDLCalidad")).Enabled=false;
				
					DropDownList DDLDefecto = (DropDownList) dgdDefecto.Controls[0].Controls[i].FindControl("ddlDefecto");
					if (DDLDefecto.Visible) DDLDefecto.Enabled=false;
				
				}
				Response.Redirect("ConsultInspectionWO.aspx");

				//dgdDefecto.Enabled=false;
			}
			catch
			{
				throw;
			}
		}

		private void InsertInspection()
		{
			IList InspList = new ArrayList();
			int IdInspectArea = Convert.ToInt32(ConfigurationManager.AppSettings["InspeccionRoomId"]);

			for (int i=0; i<dgdDefecto.Items.Count; i++)
			{
				
				int NoLamina = Convert.ToInt32(((Label)dgdDefecto.Items[i].FindControl("lblLamina")).Text);
				int Calificacion = Convert.ToInt32(((RadioButtonList) dgdDefecto.Items[i].FindControl("RDLCalidad")).SelectedItem.Value);
				//int IdAreaDestino = Convert.ToInt32(((Label)dgdDefecto.Items[i].FindControl("lblAreaId")).Text);
				switch(Calificacion)
				{
					case 1:
						PartidasInspeccionInfo pInfo = new PartidasInspeccionInfo(txtSecuencia.Text,IdInspectArea,NoLamina,Calificacion,0,Convert.ToInt32(ConfigurationManager.AppSettings["SendFinishProductRoomId"]));
						InspList.Add(pInfo);
						break;
					case 2:
						int IdDefecto = Convert.ToInt32(((DropDownList)dgdDefecto.Items[i].FindControl("ddlDefecto")).SelectedItem.Value);
						pInfo = new PartidasInspeccionInfo(txtSecuencia.Text,IdInspectArea,NoLamina,Calificacion,IdDefecto,Convert.ToInt32(ConfigurationManager.AppSettings["SegundasRoomId"]));
						InspList.Add(pInfo);
						break;
					case 3:
						IdDefecto = Convert.ToInt32(((DropDownList)dgdDefecto.Items[i].FindControl("ddlDefecto")).SelectedItem.Value);
						pInfo = new PartidasInspeccionInfo(txtSecuencia.Text,IdInspectArea,NoLamina,Calificacion,IdDefecto,Convert.ToInt32(ConfigurationManager.AppSettings["TercerasRoomId"]));
						InspList.Add(pInfo);
						break;

				}
				/*if (Calificacion > 1)
				{
					int IdDefecto = Convert.ToInt32(((DropDownList)dgdDefecto.Items[i].FindControl("ddlDefecto")).SelectedItem.Value);

					PartidasInspeccionInfo pInfo = new PartidasInspeccionInfo(txtSecuencia.Text,IdInspectArea,NoLamina,Calificacion,IdDefecto,IdAreaDestino);
					InspList.Add(pInfo);
				}
				else
				{
					PartidasInspeccionInfo pInfo = new PartidasInspeccionInfo(txtSecuencia.Text,IdInspectArea,NoLamina,Calificacion,0,Convert.ToInt32(ConfigurationManager.AppSettings["FinishProductRoomId"]));
					InspList.Add(pInfo);
				}*/					
			}
			
			SICALNet.BusinessLogicLayer.PartidasInspeccion BLLInsp = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
			BLLInsp.InsertInspeccion(InspList);
		}

		private void btnMensaje_Click(object sender, System.EventArgs e)
		{
			string Secuencia = txtSecuencia.Text.ToString();
			string IdArea = ConfigurationManager.AppSettings["InspeccionRoomId"].ToString();
			string CodigoSAP = Request.QueryString["CodigoSAP"].ToString();
			string MaterialDescription=txtUtec.Text.Trim();
			RegisterClientScriptBlock("Enviar Mensaje de Piso", string.Format("<script language='JavaScript'> window.open('../../MensajePopup.aspx?Secuencia={0}&AreaId={1}&CodigoSAP={2}&MaterialDescription={3}','anycontent','width=600, height=550,left=100, top=150, status, scrollbars=no'); </script>",Secuencia,IdArea,CodigoSAP,MaterialDescription));			
		}

		private void btnQuarentine_Click(object sender, System.EventArgs e)
		{
			try
			{
				InsertInspection();
				int AreaId= Convert.ToInt32(ConfigurationManager.AppSettings["InspeccionRoomId"]);
				IList InspList = new ArrayList();
				for (int i=0; i<dgdDefecto.Items.Count; i++)
				{
					int Calificacion = Convert.ToInt32(((RadioButtonList) dgdDefecto.Items[i].FindControl("RDLCalidad")).SelectedItem.Value);
					int NoLamina = Convert.ToInt32(((Label)dgdDefecto.Items[i].FindControl("lblLamina")).Text);
					if(Calificacion==1)
					{
						PartidasInspeccionInfo pInfo = new PartidasInspeccionInfo(txtSecuencia.Text,AreaId,NoLamina,true);
						InspList.Add(pInfo);						
					}

				}
				SICALNet.BusinessLogicLayer.PartidasInspeccion BLLInsp = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
				BLLInsp.UpdateCuarentena(InspList);
				//int AreaId= Convert.ToInt32(ConfigurationManager.AppSettings["InspeccionRoomId"]);
				int IdRelease = Convert.ToInt32(ConfigurationManager.AppSettings["StatusRelease"].ToString());
				int IdActive = Convert.ToInt32(ConfigurationManager.AppSettings["StatusActive"]);
				int QuarantineRoomId= Convert.ToInt32(ConfigurationManager.AppSettings["QuarantineRoomId"]);

				//Release the Inspeccion Phase
				OrdenesTrabajoInfo WOInfo = new OrdenesTrabajoInfo(txtSecuencia.Text,AreaId,IdRelease,DateTime.Now.Date.ToString("dd/MMM/yyyy"),Context.User.Identity.Name);
				SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder1 = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				WorkOrder1.UpdateStatus(WOInfo);
			

				/*// If there is any damage occured, Cuarantine phase become Active
				bool CuarantineActive=false;
				for ( int i=0; i<dgdDefecto.Items.Count; i++)
				{
					//RadioButtonList rdl = (RadioButtonList) dgdDefecto.Items[i].FindControl("RDLCalidad");
					DropDownList ddl = (DropDownList) dgdDefecto.Items[i].FindControl("cmbDestino");
					if (Convert.ToInt32(ddl.SelectedItem.Value) == QuarantineRoomId)
					{
						CuarantineActive = true;
						break;

					}
				}*/
			
			

				//Active - to Cuarantine Phase\
				//OrdenesTrabajoInfo WOInfo1 = new OrdenesTrabajoInfo(txtSecuencia.Text,QuarantineRoomId,IdActive,DateTime.Now.Date.ToString("dd/MMM/yyyy"),this.Context.User.Identity.Name);
				SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				WorkOrder.InsertQuarentine(txtSecuencia.Text,QuarantineRoomId,Context.User.Identity.Name,IdActive);

				//Set Active Area in Programma Produccion Table.
				OrdenesTrabajoInfo ProgramaInfo = new OrdenesTrabajoInfo(txtSecuencia.Text,QuarantineRoomId,0);
				SICALNet.BusinessLogicLayer.Programa ProgramaStatus = new SICALNet.BusinessLogicLayer.Programa();
				ProgramaStatus.UpdateProgramaActiveArea(ProgramaInfo);
				PartidasInspeccionInfo piInfo2 = new PartidasInspeccionInfo(txtSecuencia.Text.ToString(),AreaId);
				SICALNet.BusinessLogicLayer.PartidasInspeccion paIns1 = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
				IList LmList = (IList)paIns1.LoadLamina(piInfo2);
				if (LmList.Count != 0)
				{
					dgdDefecto.DataSource = LmList;
					dgdDefecto.DataBind();
				}
			
				
//				Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
//					"alert('"+"La Orden de Trabajo se liberó exitosamente"+"');self.location.href='ConsultInspectionWO.aspx';</script>");

				btnLiberar.Enabled=false;
				btnAceptar.Enabled=false;
				btnQuarentine.Enabled=false;
				for(int i=1; i<=dgdDefecto.Items.Count; i++)
				{
					((RadioButtonList)dgdDefecto.Controls[0].Controls[i].FindControl("RDLCalidad")).Enabled=false;
					DropDownList DDLDefecto = (DropDownList) dgdDefecto.Controls[0].Controls[i].FindControl("ddlDefecto");
					if (DDLDefecto.Visible) DDLDefecto.Enabled=false;
				
				}
			

				Response.Redirect("ConsultInspectionWO.aspx");
				//dgdDefecto.Enabled=false;
			}
			catch
			{
				throw;
			}
		}
	}

}
