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
	/// Summary description for ConsultAssembleWO.
	/// </summary>
	public class ConsultAssembleWO : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton cmdCalendar;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Label lblLinea;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.Button cmdAceptar;
		protected System.Web.UI.WebControls.DropDownList cboStatus;
		protected System.Web.UI.WebControls.DataGrid dgdWorkOrder;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.TextBox txtFechaTo;
		protected System.Web.UI.WebControls.Label To;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.ImageButton ImgFechaTo;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Literal ltrRefresh;
		protected System.Web.UI.WebControls.RegularExpressionValidator revInitial;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label1;

		protected static int localAreaId;
		protected static int idLinea;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetExpires(DateTime.Now);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetValidUntilExpires(false);
			Response.Cache.SetNoStore();
			if((ConfigurationSettings.AppSettings["TiempoRefreshListadoOrdenes"] != "0") && (ConfigurationSettings.AppSettings["TiempoRefreshListadoOrdenes"]!=""))
				ltrRefresh.Text = "<META http-equiv='Refresh' content='" + ConfigurationSettings.AppSettings["TiempoRefreshListadoOrdenes"] + "'>" ;			

			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				BindEntryFields();
				string tmpInit = (string) Session["InitialDate"];
				string tmpFin = (string) Session["FinalDate"];

				String sFechaIni = DateTime.Now.Date.ToString("dd-MMM-yyyy");
				String sFechaFin = DateTime.Now.Date.ToString("dd-MMM-yyyy");

				if (tmpInit == null || tmpFin ==null)
				{
					
					txtFecha.Text = sFechaIni.Replace(".","");
					txtFechaTo.Text = sFechaFin.Replace(".","");

					//txtFecha.Text=System.DateTime.Now.ToString("dd-MMM-yyyy");
					//txtFechaTo.Text=System.DateTime.Now.ToString("dd-MMM-yyyy");
				}
				else
				{
					//txtFecha.Text = sFechaIni.Replace(".","");
					//txtFechaTo.Text = sFechaFin.Replace(".","");

					txtFecha.Text=tmpInit.Replace(".","");
					txtFechaTo.Text=tmpFin.Replace(".","");
				}

				idLinea = Convert.ToInt32(cboLinea.SelectedItem.Value);
				
				int IdStatus = Convert.ToInt32(cboStatus.SelectedItem.Value);
				BindGrid(txtFecha.Text,txtFechaTo.Text, idLinea, IdStatus, localAreaId);
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
			localAreaId=Convert.ToInt32(ConfigurationSettings.AppSettings["AssembleRoomId"]);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
			this.dgdWorkOrder.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdWorkOrder_ItemCommand);
			this.dgdWorkOrder.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdWorkOrder_ItemDataBound);
			this.dgdWorkOrder.SelectedIndexChanged += new System.EventHandler(this.dgdWorkOrder_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindEntryFields()
		{
			SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
			SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
			theUser  = BLLUser.Load(theUser);

			//Code to populate Linea ComboBox
			SICALNet.BusinessLogicLayer.LineaProduccion Linea = new SICALNet.BusinessLogicLayer.LineaProduccion();
			IList LineaList = (IList) Linea.SelectLinePdt(theUser);
			
			cboLinea.DataSource = LineaList;
			cboLinea.DataValueField = "IdLinea";
			cboLinea.DataTextField = "Description";
			cboLinea.DataBind();
			cboLinea.Items.Add(new ListItem(string.Empty,"0"));
			string currentLine=(string)Session["selectedLine"];
			if (currentLine != null)
				cboLinea.Items.FindByValue(currentLine).Selected=true;
			else
			{
				string lineaDefault;

				switch(theUser.IdPlanta)
				{
					case 1:	// Ocoyoacac
						lineaDefault = "1";
						break;
					case 2: // San Luis
						lineaDefault = "4";
						break;
					default:
						lineaDefault = "0";
						break;
				}

				cboLinea.Items.FindByValue(lineaDefault).Selected=true;
			}

			//Code to populate Status ComboBox
			SICALNet.BusinessLogicLayer.Status Status = new SICALNet.BusinessLogicLayer.Status();
			IList StatusList = (IList) Status.Load();
			
			cboStatus.DataSource = StatusList;
			cboStatus.DataValueField = "IdStatus";
			cboStatus.DataTextField = "Descripcion";
			cboStatus.DataBind();
			cboStatus.Items.Add(new ListItem(string.Empty,"0"));

			string currentStatus=(string)Session["selectedIdStatus"];
			if (currentStatus != null)
				cboStatus.Items.FindByValue(currentStatus).Selected=true;
			else
				cboStatus.Items.FindByValue("2").Selected=true;	// Activo por default			

		}

		private void cmdAceptar_Click(object sender, System.EventArgs e)
		{
			string Fecha = txtFecha.Text;
			string FechaTo=txtFechaTo.Text;
			int IdLinea = Convert.ToInt32(cboLinea.SelectedItem.Value);
			int IdStatus = Convert.ToInt32(cboStatus.SelectedItem.Value);
			BindGrid(Fecha,FechaTo, IdLinea, IdStatus, localAreaId);
		}

		public void BindGrid(string Fecha,string FechaTo, int IdLinea, int IdStatus, int IdArea)
		{
			//Set comfortable variables
			Session["InitialDate"]=Fecha;
			Session["FinalDate"]=FechaTo;
			Session["selectedLine"] = IdLinea.ToString();
			Session["selectedIdStatus"] = cboStatus.SelectedItem.Value;

			//TODO:Revisar que la conversión a DateTime se haga correctamente, sino cambiar el tipo de dato de la función
			OrdenesTrabajoInfo WOInfo = new OrdenesTrabajoInfo(dmy2ymd(Fecha),dmy2ymd(FechaTo),IdLinea, IdStatus, IdArea);
			// To Load the WO List
			SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
			IList WOList = (IList)WorkOrder.LoadWorkOrders(WOInfo);
			dgdWorkOrder.DataSource = WOList;
			dgdWorkOrder.DataBind();
		}

		private DateTime dmy2ymd(String Fecha)
		{
			String sDia, sMes, sAnio, sFecha, sFecha1;
			sFecha1 = Fecha.Replace(".", "");			
			sDia = sFecha1.Substring(0, 2);
			sMes = sFecha1.Substring(3, 3);
			sAnio = sFecha1.Substring(7);
			sFecha = sAnio + "/" + GetMonth(sMes) + "/" + sDia ;
			return DateTime.Parse(sFecha);
		}

		private string GetMonth(string smes)
		{
			switch (smes.ToUpper())
			{
				case "ENE" :
					return "01";
					//break;
				case "FEB" :
					return "02";
					//break;
				case "MAR" :
					return "03";
					//break;
				case "ABR" :
					return "04";
					//break;
				case "MAY" :
					return "05";
					//break;
				case "JUN" :
					return "06";
					//break;
				case "JUL" :
					return "07";
					//break;
				case "AGO" :
					return "08";
					//break;
				case "SEP" :
					return "09";
					//break;
				case "OCT" :
					return "10";
					//break;
				case "NOV" :
					return "11";
					//break;
				case "DIC" :
					return "12";
					//break;
				default:
					return "Desconocido";
					//break;
			}
		}


		private void dgdWorkOrder_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Consult")
			{
				string StatusDesc = ((Label) e.Item.FindControl("ItemStatusDesc")).Text;
				string Secuencia = ((Label)e.Item.FindControl("ItemSecuencia")).Text;
				string idStatus= ((Label) e.Item.FindControl("ItemIdStatus")).Text;
				int IddStatus = Convert.ToInt32(((Label) e.Item.FindControl("ItemIdStatus")).Text);

				int IdReleaseStatus = Convert.ToInt32(ConfigurationSettings.AppSettings["StatusRelease"]);
				int IdActiveStatus = Convert.ToInt32(ConfigurationSettings.AppSettings["StatusActive"]);
			    int IdProcessStatus = Convert.ToInt32(ConfigurationSettings.AppSettings["StatusInProcess"]);
				int IdCancelStatus = Convert.ToInt32(ConfigurationSettings.AppSettings["StatusCancel"]);
				int IdPendienteStatus = Convert.ToInt32(ConfigurationSettings.AppSettings["StatusPending"]);

				if ((IddStatus == IdCancelStatus)||(IddStatus == IdPendienteStatus)) 
				{
					string ScriptString="<script language='javascript'>alert('La secuencia " + Secuencia + " esta en estado PENDIENTE, no puede ser consultada');</script>"; 
					Page.RegisterStartupScript("ClientScript",ScriptString);
					//lblErrorMsg.Text = "Una secuencia en estado PENDIENTE no se puede consultar";
					return;
				}

				//if (StatusDesc == "Liberado")
				//{
					//The sequences in status RELEASED can only be consulted in READ ONLY mode
				//}

				if (IddStatus == IdActiveStatus || IddStatus == IdProcessStatus || IddStatus == IdReleaseStatus)

				{
				
					int IdFamiliaProducto, IdMedida;
					string IdEspesor;

									
					int IdArea = Convert.ToInt32(ConfigurationSettings.AppSettings["AssembleRoomId"]);  //Area for Assemble Room
					//pnlConsultAssemble.Visible = true;
//					txtSecuencia.Text = ((Label)e.Item.FindControl("ItemSecuencia")).Text;
//					txtFecha1.Text =  ((Label)e.Item.FindControl("ItemFecha")).Text;
//					txtUTEC.Text = ((Label)e.Item.FindControl("ItemDescripcion")).Text;
//					txtCantidad.Text = ((Label)e.Item.FindControl("ItemCantidad")).Text;
//					txtDescFamiliaProducto.Text = ((Label)e.Item.FindControl("ItemDescFamiliaProducto")).Text;

					string Fecha1 =  ((Label)e.Item.FindControl("ItemFecha")).Text;
					string UTEC = ((Label)e.Item.FindControl("ItemDescripcion")).Text;
					string Cantidad = ((Label)e.Item.FindControl("ItemCantidad")).Text;
					string DescFamiliaProducto = ((Label)e.Item.FindControl("ItemDescFamiliaProducto")).Text;
					// Extract Data from DataGrid
					IdFamiliaProducto = Convert.ToInt32(((Label)e.Item.FindControl("ItemIdFamiliaProducto")).Text);
					IdMedida = Convert.ToInt32(((Label)e.Item.FindControl("ItemIdMedida")).Text);
					IdEspesor = ((Label)e.Item.FindControl("ItemIdEspesor")).Text;
					string CodigoSAP = ((Label)e.Item.FindControl("ItemCodigoSAP")).Text;
					string IdPlanta =  ((Label)e.Item.FindControl("ItemIdPlanta")).Text;

					//if Status is ACTIVE, then change it to 'IN PROCESS'
					if (StatusDesc == "Activo")
					{
						int IdStatus = 3; // Status Number 3 indicates 'IN PROCESS'
						OrdenesTrabajoInfo OTInfo = new OrdenesTrabajoInfo(Secuencia, IdArea, IdStatus);
						SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						WorkOrder.UpdateWO(OTInfo);
						lblErrorMsg.ForeColor = Color.Green;
						lblErrorMsg.Text = "Estado cambiado'EN PROCESO'";
					}

					Response.Redirect("ConsultAssembleWO1.aspx?Secuencia="+ Secuencia 
						+ "&Fecha1=" + Fecha1 							
						+ "&Cantidad=" + Cantidad 
						+ "&DescFamiliaProducto=" + DescFamiliaProducto 
						+ "&IdFamiliaProducto=" + IdFamiliaProducto
						+ "&IdMedida=" + IdMedida 
						+ "&IdEspesor=" + IdEspesor
						+ "&CodigoSAP=" + CodigoSAP 
						+ "&IdStatus=" + idStatus 
						+ "&IdPlanta=" + IdPlanta 
						+ "&IdLinea=" + idLinea
						+ "&UTEC=" + UTEC );
				}
			}

			if (e.CommandName=="Agregar")
			{
				string Secuencia = ((Label)e.Item.FindControl("ItemSecuencia")).Text.ToString();
				string IdArea= ConfigurationSettings.AppSettings["AssembleRoomId"].ToString();
				string CodeSAP=((Label)e.Item.FindControl("ItemCodigoSAP")).Text.ToString();
				string matDesc=((Label)e.Item.FindControl("ItemDescripcion")).Text.ToString();
				RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodeSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");
			}
		}

		private void dgdWorkOrder_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Label lblFechaMod = (Label)e.Item.FindControl("ItemFechaMod");
				if (lblFechaMod.Text != "") 
				{
					e.Item.BackColor = Color.Yellow;

					DateTime timeAux = Convert.ToDateTime(lblFechaMod.Text); 
					if (timeAux.ToString("dd/MMM/yy")   == DateTime.MinValue.ToString("dd/MMM/yy")) 
						e.Item.BackColor = Color.LightBlue;   					
				}

				Label lblStatus = (Label)e.Item.FindControl("ItemIdStatus");
				if (lblStatus.Text == ConfigurationSettings.AppSettings["StatusCancel"]) 
					e.Item.BackColor = Color.Tomato;
			}

		}

//		private void btnLiberer_Click(object sender, System.EventArgs e)
//		{
//			OrdenesTrabajoInfo WOInfo = new OrdenesTrabajoInfo(txtSecuencia.Text,6,2,DateTime.Now.Date.ToString("dd/MMM/yyyy"),this.Context.User.Identity.Name);
//			SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
//			WorkOrder.UpdateStatus(WOInfo);
//			FlujoAreaInfo FAInfo=new FlujoAreaInfo(6,0);
//			SICALNet.BusinessLogicLayer.FlujoArea FArea= new SICALNet.BusinessLogicLayer.FlujoArea();
//			ArrayList FAreaList = new ArrayList();
//			FAreaList = (ArrayList) FArea.Load(FAInfo);
//			FAInfo = (FlujoAreaInfo)FAreaList[0];
//			OrdenesTrabajoInfo WOInfo2 = new OrdenesTrabajoInfo(txtSecuencia.Text,5,0);
//			SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder2 = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
//			int i = WorkOrder2.GetStatus(WOInfo2);
//			if (i==2) 
//			{
//				OrdenesTrabajoInfo WOInfo1 = new OrdenesTrabajoInfo(txtSecuencia.Text,FAInfo.IdAreaPadre,1);
//				SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder1 = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
//				WorkOrder.UpdateWO(WOInfo);
//				Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
//					"alert('"+"La Orden de Trabajo se libero exitosamente"+"')"+
//					"<" + "/script>");
//			}
//			else
//			{
//				Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
//					"alert('"+"Fase de Mezclas no se libero "+"')"+
//					"<" + "/script>");
//			}
//
//			
//		}

		private void dgdWorkOrder_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
