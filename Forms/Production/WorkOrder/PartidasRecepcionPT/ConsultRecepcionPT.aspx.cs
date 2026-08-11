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

namespace UserInterface.Forms.Production.WorkOrder.PartidasRecepcionPT
{
	/// <summary>
	/// Summary description for ConsultRecepcionPT.
	/// </summary>
	public class ConsultRecepcionPT : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblInitial;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblFinal;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtInitial;
		protected System.Web.UI.WebControls.Image imgInitial;
		protected System.Web.UI.WebControls.TextBox txtFinal;
		protected System.Web.UI.WebControls.Image imgFinal;
		protected System.Web.UI.WebControls.DropDownList cboStatus;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Button btnSel;
		protected System.Web.UI.WebControls.Button btnAgregar;
		protected System.Web.UI.WebControls.Button btnLiberar;
		protected System.Web.UI.WebControls.DataList lstWorkOrder;
		protected System.Web.UI.WebControls.RegularExpressionValidator revInitial;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Literal ltrRefresh;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);

			if((ConfigurationSettings.AppSettings["TiempoRefreshListadoOrdenes"] != "0") && (ConfigurationSettings.AppSettings["TiempoRefreshListadoOrdenes"]!=""))
				ltrRefresh.Text = "<META http-equiv='Refresh' content='" + ConfigurationSettings.AppSettings["TiempoRefreshListadoOrdenes"] + "'>" ;			


			if(!IsPostBack)
			{

				string tmpInit = (string) Session["InitialDate"];
				string tmpFin = (string) Session["FinalDate"];


				String sFechaIni = DateTime.Now.Date.ToString("dd-MMM-yyyy");
				String sFechaFin = DateTime.Now.Date.ToString("dd-MMM-yyyy");

				if (tmpInit == null || tmpFin ==null)
				{					
					txtInitial.Text = sFechaIni.Replace(".","");
					txtFinal.Text = sFechaFin.Replace(".","");
				}
				else
				{
					txtInitial.Text=tmpInit;
					txtFinal.Text=tmpFin;
				}

				BindWorkOrders();

				if(Request.QueryString["Reflag"]!=null)
				{
					txtInitial.Text=Request.QueryString["InitialDate"];
					txtFinal.Text=Request.QueryString["FinalDate"];
					cboStatus.SelectedItem.Selected=false;
					cboLinea.SelectedItem.Selected=false;
					cboStatus.Items.FindByValue(Request.QueryString["cboStatus"]).Selected=true;
					cboLinea.Items.FindByValue(Request.QueryString["cboLinea"]).Selected=true;
					BindWorkOrders();
				}
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
			BindEntryFields();
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
			this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
			this.lstWorkOrder.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.lstWorkOrder_ItemCommand);
			this.lstWorkOrder.ItemDataBound += new System.Web.UI.WebControls.DataListItemEventHandler(this.lstWorkOrder_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindEntryFields()
		{
			SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
			SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
			theUser  = BLLUser.Load(theUser);

			//to fill the Linea description into the cboLinea control
			SICALNet.BusinessLogicLayer.LineaProduccion BLLLine=new SICALNet.BusinessLogicLayer.LineaProduccion();
			IList RsLine=(IList) BLLLine.SelectLinePdt(theUser);
			prcCboCommon(cboLinea,"IdLinea","Description",RsLine);
			//to fill the Status description into the cboStatus control
			SICALNet.BusinessLogicLayer.Status BLLStatus=new SICALNet.BusinessLogicLayer.Status();
			IList RsStatus=(IList) BLLStatus.Load();
			prcCboCommon(cboStatus,"IdStatus","Descripcion",RsStatus);
		}

		//common function is used to fill the combo box
		private void prcCboCommon(DropDownList cbo,string sVal,string sTxt,IList RsList)
		{
			cbo.DataSource=RsList;
			cbo.DataValueField=sVal;
			cbo.DataTextField=sTxt;
			cbo.DataBind();
			cbo.Items.Add(new ListItem(string.Empty,"0"));
			if (sVal=="IdLinea")
			{
				string currentLine=(string)Session["selectedLine"];
				if (currentLine != null)
					cbo.Items.FindByValue(currentLine).Selected=true;
				else
				{
					SICALNet.BusinessEntities.UsuarioInfo User = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
					SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				
					User = BLLUser.Load(User);
					string lineaDefault;

					switch(User.IdPlanta)
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

					cbo.Items.FindByValue(lineaDefault).Selected=true;
					
				}
			}
			else if(sVal=="IdStatus" )
			{
				string currentStatus=(string)Session["selectedIdStatus"];
				if (currentStatus != null)
					cbo.Items.FindByValue(currentStatus).Selected=true;
				else
					cbo.Items.FindByValue("2").Selected=true; // Activo por default

			}
			else
				cbo.Items.FindByValue("0").Selected=true;
		}
		private bool BindWorkOrders()
		{
			SICALNet.BusinessLogicLayer.OrdenesTrabajo BLLOrdTra= new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
			int IdArea=Convert.ToInt32(ConfigurationSettings.AppSettings["ReceiveFinishProductRoomId"]);
			int IdStatus=int.Parse(cboStatus.SelectedItem.Value);
			int IdLine=int.Parse(cboLinea.SelectedItem.Value);
			string InitDt=txtInitial.Text.ToString();
			string FinalDt=txtFinal.Text.ToString();
			Session["InitialDate"] = InitDt;
			Session["FinalDate"] = FinalDt;
			Session["selectedLine"] = IdLine.ToString();
			Session["selectedIdStatus"] = cboStatus.SelectedItem.Value;


			IList RsOrdTra= (IList)BLLOrdTra.LoadWorkOrders(IdArea,IdLine,IdStatus,"0",InitDt,FinalDt);
			if (RsOrdTra.Count == 0)
			{
				lstWorkOrder.DataSource = null;
				lstWorkOrder.DataBind();
				return false;
			}
			//to fill the datagrid
			lstWorkOrder.DataSource = RsOrdTra;
			lstWorkOrder.DataBind();
			for(int i=0;i<lstWorkOrder.Items.Count;i++)
			{
				string secuencia=((Label)lstWorkOrder.Items[i].FindControl("ItemSecuencia")).Text;
				int IdStatuss = Convert.ToInt32(((Label)lstWorkOrder.Items[i].FindControl("ItemIdStatus")).Text);
				DataGrid dgdRecepcion = ((DataGrid)lstWorkOrder.Items[i].FindControl("dgdRecepcionPT"));
				SICALNet.BusinessEntities.PartidasRecepcionPTInfo PRInfo = new SICALNet.BusinessEntities.PartidasRecepcionPTInfo(string.Empty,secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["ReceiveFinishProductRoomId"]),string.Empty,0,0,string.Empty);
				SICALNet.BusinessLogicLayer.PartidasRecepcionPT BlPRPT = new SICALNet.BusinessLogicLayer.PartidasRecepcionPT();
				IList RecepcionList=BlPRPT.Select(PRInfo);
				if(RecepcionList.Count==0)
				{
					// Create a DataSet.
					DataSet dsPaquete = new DataSet("dsPaquete");
					//Create a DataTable.
					DataTable dtPaquete = new DataTable("Paquete");
					//Create three columns, and add them to the first table.
					DataColumn dcPaqueteNo = new DataColumn("PaqueteNo");
					DataColumn dcPaquete = new DataColumn("Paquete"); 
					DataColumn dcLaminas = new DataColumn("Laminas");
					DataColumn dcLaminasReal = new DataColumn("LaminasReal");
					DataColumn dcTarima = new DataColumn("Tarima");
					//assign the datacolum into datatable
					dtPaquete.Columns.Add(dcPaqueteNo);
					dtPaquete.Columns.Add(dcPaquete);
					dtPaquete.Columns.Add(dcLaminas);
					dtPaquete.Columns.Add(dcLaminasReal);
					dtPaquete.Columns.Add(dcTarima);
					//Add the tables to the DataSet.
					dsPaquete.Tables.Add(dtPaquete);
					SICALNet.BusinessEntities.PartidasEnvioPTInfo PEInfo = new SICALNet.BusinessEntities.PartidasEnvioPTInfo(string.Empty,secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["SendFinishProductRoomId"]),string.Empty,0,string.Empty);
					SICALNet.BusinessLogicLayer.PartidasEnvioPT BlPEPT = new SICALNet.BusinessLogicLayer.PartidasEnvioPT();
					IList EnvioList=BlPEPT.Select(PEInfo);
					for (int iLoop=1; iLoop <= EnvioList.Count; iLoop++)
					{
						PEInfo = (SICALNet.BusinessEntities.PartidasEnvioPTInfo)EnvioList[iLoop-1];
						DataRow drPaquete = dtPaquete.NewRow();
						drPaquete["PaqueteNo"] = PEInfo.PaqueteNo;
						drPaquete["Paquete"]=PEInfo.Paquete;
						drPaquete["Laminas"] = PEInfo.Laminas;
						drPaquete["LaminasReal"] = 0;
						drPaquete["Tarima"] = PEInfo.Tarima;
						dtPaquete.Rows.Add(drPaquete);
					}
					dgdRecepcion.DataSource=dsPaquete;
					dgdRecepcion.DataBind();
				}
				else
				{
					dgdRecepcion.DataSource=RecepcionList;
					dgdRecepcion.DataBind();
				}
				if(IdStatuss!=Convert.ToInt32(ConfigurationSettings.AppSettings["StatusPending"]))
				{
					lstWorkOrder.Items[i].FindControl("Plus").Visible=true;
				}
				if(IdStatuss==Convert.ToInt32(ConfigurationSettings.AppSettings["StatusRelease"])||IdStatuss==Convert.ToInt32(ConfigurationSettings.AppSettings["StatusPending"]))
				{
					((CheckBox)lstWorkOrder.Items[i].FindControl("chkSelect")).Enabled=false;
					dgdRecepcion.Columns[3].Visible=false;
					dgdRecepcion.Columns[4].Visible=true;
				}
			}
			
			
			return true;
		}

		private void btnSel_Click(object sender, System.EventArgs e)
		{
			BindWorkOrders();
		}

		private void lstWorkOrder_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
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

		private void lstWorkOrder_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			try
			{
				switch(e.CommandName)
				{
					case "Consult":
						string CodeSAP=((Label)e.Item.FindControl("ItemCodigoSAP")).Text.ToString();
						Session["CodigoSAP"]=CodeSAP;
						int IdPendingStatus = Convert.ToInt32(ConfigurationSettings.AppSettings["StatusPending"]);
						string secuencia=((Label)e.Item.FindControl("ItemSecuencia")).Text;
						string Descripcion = ((Label)e.Item.FindControl("ItemDescripcion")).Text;
						string Fecha = ((Label)e.Item.FindControl("ItemFecha")).Text;
						int IdStatus = Convert.ToInt32(((Label)e.Item.FindControl("ItemIdStatus")).Text);
						if(IdStatus==IdPendingStatus)
							throw new Exception(string.Format("La Secuencia {0} está en estado PENDIENTE, aún no puede ser Consultada",secuencia));
						Response.Redirect("ConsultRecepcionPT1.aspx?Secuencia="+secuencia+"&Descripcion="+Descripcion+"&IdStatus="+IdStatus+"&CboStatus="+cboStatus.SelectedItem.Value+"&cboLinea="+cboLinea.SelectedItem.Value+"&InitialDate="+txtInitial.Text+"&FinalDate="+txtFinal.Text+"&Status="+IdStatus+"&Fecha="+Fecha);
						break;

					case "Mensaje":
						string Secuencia = ((Label)e.Item.FindControl("ItemSecuencia")).Text.ToString();
						string IdArea= ConfigurationSettings.AppSettings["SendFinishProductRoomId"].ToString();
						CodeSAP=((Label)e.Item.FindControl("ItemCodigoSAP")).Text.ToString();
						string matDesc=((Label)e.Item.FindControl("ItemDescripcion")).Text.ToString();
						RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('../../MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodeSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");
						break;
				}
			}
			catch
			{
				throw;
			}

		}

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
			try
			{
				for(int i=0;i<lstWorkOrder.Items.Count;i++)
				{
					string secuencia=((Label)lstWorkOrder.Items[i].FindControl("ItemSecuencia")).Text;
					int IdStatuss = Convert.ToInt32(((Label)lstWorkOrder.Items[i].FindControl("ItemIdStatus")).Text);
					if(IdStatuss==Convert.ToInt32(ConfigurationSettings.AppSettings["StatusActive"])&& ((CheckBox)lstWorkOrder.Items[i].FindControl("chkSelect")).Checked==true)
					{
						DataGrid dgdRecepcionPT = ((DataGrid)lstWorkOrder.Items[i].FindControl("dgdRecepcionPT"));
						IList RecepcionList=new ArrayList();
						for(int iloop=0;iloop<dgdRecepcionPT.Items.Count;iloop++)
						{
							string Paquete = ((Label)dgdRecepcionPT.Items[iloop].FindControl("lblPaquete")).Text;
							int Laminas=Convert.ToInt32(((Label)dgdRecepcionPT.Items[iloop].FindControl("lblLaminas")).Text);
							int LaminasReal = Convert.ToInt32(((TextBox)dgdRecepcionPT.Items[iloop].FindControl("txtLaminasReal")).Text);
							string Tarima = ((Label)dgdRecepcionPT.Items[iloop].FindControl("lblTarima")).Text;
							SICALNet.BusinessEntities.PartidasRecepcionPTInfo PRInfo = new SICALNet.BusinessEntities.PartidasRecepcionPTInfo(string.Empty,secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["ReceiveFinishProductRoomId"]),Paquete,Laminas,LaminasReal,Tarima);
							RecepcionList.Add(PRInfo);
						}
						if(RecepcionList.Count>0)
						{
							SICALNet.BusinessLogicLayer.PartidasRecepcionPT BlPRPT = new SICALNet.BusinessLogicLayer.PartidasRecepcionPT();
							BlPRPT.Delete(secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["ReceiveFinishProductRoomId"]));
							BlPRPT.Insert(RecepcionList);
							SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["ReceiveFinishProductRoomId"]),Context.User.Identity.Name);
							SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
							BLOrdenes.UpdateLoginForm(OTInfo);
							Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"The WorkOrder Saved Successfully..."+"')" + "<" + "/script>");
						}				

					}
				}
			}
			catch
			{
				throw;
			}
		
		}

		private void btnLiberar_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				for(int i=0;i<lstWorkOrder.Items.Count;i++)
				{
					int sumLaminasReal=0;
					string secuencia=((Label)lstWorkOrder.Items[i].FindControl("ItemSecuencia")).Text;
					int IdStatuss = Convert.ToInt32(((Label)lstWorkOrder.Items[i].FindControl("ItemIdStatus")).Text);
					if(IdStatuss==Convert.ToInt32(ConfigurationSettings.AppSettings["StatusActive"])&& ((CheckBox)lstWorkOrder.Items[i].FindControl("chkSelect")).Checked==true)
					{
						DataGrid dgdRecepcionPT = ((DataGrid)lstWorkOrder.Items[i].FindControl("dgdRecepcionPT"));
						IList RecepcionList=new ArrayList();
						for(int iloop=0;iloop<dgdRecepcionPT.Items.Count;iloop++)
						{
							string Paquete = ((Label)dgdRecepcionPT.Items[iloop].FindControl("lblPaquete")).Text;
							int Laminas=Convert.ToInt32(((Label)dgdRecepcionPT.Items[iloop].FindControl("lblLaminas")).Text);
							int LaminasReal = Convert.ToInt32(((TextBox)dgdRecepcionPT.Items[iloop].FindControl("txtLaminasReal")).Text);
							string Tarima = ((Label)dgdRecepcionPT.Items[iloop].FindControl("lblTarima")).Text;
							SICALNet.BusinessEntities.PartidasRecepcionPTInfo PRInfo = new SICALNet.BusinessEntities.PartidasRecepcionPTInfo(string.Empty,secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["ReceiveFinishProductRoomId"]),Paquete,Laminas,LaminasReal,Tarima);
							RecepcionList.Add(PRInfo);
							sumLaminasReal+=LaminasReal;
						}
						SICALNet.BusinessEntities.PartidasInspeccionInfo PIInfo = new SICALNet.BusinessEntities.PartidasInspeccionInfo(secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["InspeccionRoomId"]));
						SICALNet.BusinessLogicLayer.PartidasInspeccion BLIns = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
						int Laminas1=BLIns.ActiveLaminas(PIInfo);
						if(sumLaminasReal!=Laminas1)
							throw new Exception(" La cantidad de láminas de la secuencia "+secuencia+" no es igual a la cantidad de láminas liberadas en fase de Inspección.");				
						if(RecepcionList.Count>0)
						{
							SICALNet.BusinessLogicLayer.PartidasRecepcionPT BlPRPT = new SICALNet.BusinessLogicLayer.PartidasRecepcionPT();
							BlPRPT.Delete(secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["ReceiveFinishProductRoomId"]));
							BlPRPT.Insert(RecepcionList);
							SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["ReceiveFinishProductRoomId"]),Context.User.Identity.Name);
							SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
							BLOrdenes.UpdateLoginForm(OTInfo);
							Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"The WorkOrder Saved Successfully..."+"')" + "<" + "/script>");
						}			

					}
				}
				for(int i=0;i<lstWorkOrder.Items.Count;i++)
				{
					string secuencia=((Label)lstWorkOrder.Items[i].FindControl("ItemSecuencia")).Text;
					DataGrid dgdRecepcionPT = ((DataGrid)lstWorkOrder.Items[i].FindControl("dgdRecepcionPT"));
					int IdStatuss = Convert.ToInt32(((Label)lstWorkOrder.Items[i].FindControl("ItemIdStatus")).Text);
					if(IdStatuss==Convert.ToInt32(ConfigurationSettings.AppSettings["StatusActive"])&& ((CheckBox)lstWorkOrder.Items[i].FindControl("chkSelect")).Checked==true)
					{
						//Activate Next Area And update Active Area in Programma Production for this Secuencia
						//Depending on sequence available in "FlujoArea" Table
						SICALNet.BusinessLogicLayer.FlujoArea objFlujoArea = new SICALNet.BusinessLogicLayer.FlujoArea();
						objFlujoArea.ActivateDependingAreas(secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["ReceiveFinishProductRoomId"]));
						// To Release the Work Order
						SICALNet.BusinessEntities.OrdenesTrabajoInfo WOInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(secuencia, Convert.ToInt32(ConfigurationSettings.AppSettings["ReceiveFinishProductRoomId"]), Convert.ToInt32(ConfigurationSettings.AppSettings["StatusRelease"]), DateTime.Now.Date.ToString("dd/MMM/yyyy"), Context.User.Identity.Name); 
						SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						WorkOrder.UpdateStatus(WOInfo);
						SICALNet.BusinessEntities.PartidasRecepcionPTInfo PRInfo1 = new SICALNet.BusinessEntities.PartidasRecepcionPTInfo(string.Empty,secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["ReceiveFinishProductRoomId"]),string.Empty,0,0,string.Empty);
						SICALNet.BusinessLogicLayer.PartidasRecepcionPT BlPRPT1 = new SICALNet.BusinessLogicLayer.PartidasRecepcionPT();
						IList RecepcionList=BlPRPT1.Select(PRInfo1);
						dgdRecepcionPT.DataSource=RecepcionList;
						dgdRecepcionPT.DataBind();
						dgdRecepcionPT.Columns[3].Visible=false;
						dgdRecepcionPT.Columns[4].Visible=true;
					}
					Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"La Orden de Trabajo se libero exitosamente"+"')" + "<" + "/script>");

				}
			
		
			}
			catch
			{
				throw;
			}

		}

	}
}
