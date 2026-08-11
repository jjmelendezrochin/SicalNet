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
using System.Text;

namespace UserInterface.Forms.Production.WorkOrder.PartidasEnvioPT
{
	/// <summary>
	/// Summary description for ConsultEnvioPT.
	/// </summary>
	public class ConsultEnvioPT : System.Web.UI.Page
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

		// Seleccion de cajas
		public void checkAll(object sender,System.EventArgs e)
		{
			//loop thru the list of available work orders
			for (int i=0;i<lstWorkOrder.Items.Count;i++)
			{
				CheckBox parentCheckbox = (CheckBox)sender;
				//obtain current checkbox
				CheckBox currentCheck = (CheckBox) lstWorkOrder.Items[i].FindControl("chkSelect");
				//if it has Partidas information (is enabled)
				if (currentCheck.Enabled==true)
				{
					//Check the checkbox
					currentCheck.Checked=parentCheckbox.Checked;
					//Display details
				}
			}		
		}

		// **********************
		// Impresión de etiquetas
		public void btnImpresion_click(object sender, System.EventArgs e)
		{
			try
			{
				int i=0;
				string[] secuencia=new string[lstWorkOrder.Items.Count];
				for(int iloop=0;iloop<lstWorkOrder.Items.Count;iloop++)
				{
					if(((CheckBox)lstWorkOrder.Items[iloop].FindControl("chkSelect")).Checked==true)
					{
						secuencia[i]=((Label)lstWorkOrder.Items[iloop].FindControl("ItemSecuencia")).Text.ToString();	
						i++;
					}
				}
				
				if(i==0)
				{
					// throw new Exception(" Select Secuencias to generate report");
					Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
						"alert('Seleccione una secuencia para generar una tarjeta');</script>");
					return;
				}
				else
				{
					// Proceso de generación de etiqueta
					/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
					StringBuilder SecuenciaStr = new StringBuilder();
					//string SecuenciaStr = string.Empty;								
					for(int k=0;k<i;k++)
					{
						SecuenciaStr = SecuenciaStr.Append("{Vw_ProductoTerminado.Secuencia}='").Append(secuencia[k]).Append("'");
						//SecuenciaStr+="{VistaSecuenciasSimples1.Secuencia}='"+secuencia[k]+"'";
						if(k!=(i-1))
						{
							SecuenciaStr.Append(" OR ");
							//SecuenciaStr+=" OR ";
						}
					}

					if(SecuenciaStr.Length > 0)
					{
						SecuenciaStr.Insert(0,"(").Append(")");
						//SecuenciaStr = "(" + SecuenciaStr + ")";
					}

					/*** fin modificación ***/
					PrepareCardReport(SecuenciaStr.ToString());
				}
			}
			catch
			{
				throw;
			}
		}

		private void PrepareCardReport(string secuencias)
		{
			try
			{	
				string reportName = "";	
				Reports.ReportHelper rptHelper = new Reports.ReportHelper();
				Production.WorkOrder.PartidasEnvioPT.ProductoTerminado reporte = new Production.WorkOrder.PartidasEnvioPT.ProductoTerminado();
				reporte.DataDefinition.RecordSelectionFormula=secuencias;
				rptHelper.setPermission(reporte);
				reportName = rptHelper.exportReport(reporte,"ProductoTerminado",User.Identity.Name);
			
				string redirectPath=ConfigurationSettings.AppSettings["reportsWebPath"]+ reportName + ".pdf";			
				string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','Reporte', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>"; 
				Page.RegisterStartupScript("ClientScript",ScriptString);
			}
			catch
			{
				throw;
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
			int IdArea=Convert.ToInt32(ConfigurationSettings.AppSettings["SendFinishProductRoomId"]);
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
				DataGrid dgdEnvio = ((DataGrid)lstWorkOrder.Items[i].FindControl("dgdEnvioPT"));
				SICALNet.BusinessEntities.PartidasEnvioPTInfo PEInfo = new SICALNet.BusinessEntities.PartidasEnvioPTInfo(string.Empty,secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["SendFinishProductRoomId"]),string.Empty,0,string.Empty);
				SICALNet.BusinessLogicLayer.PartidasEnvioPT BlPEPT = new SICALNet.BusinessLogicLayer.PartidasEnvioPT();
				IList EnvioList=BlPEPT.Select(PEInfo);
				dgdEnvio.DataSource=EnvioList;
				dgdEnvio.DataBind();
				if(BlPEPT.GetPacks(secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["SendFinishProductRoomId"]))!=0)
					lstWorkOrder.Items[i].FindControl("Plus").Visible=true;
				if(IdStatuss==5)
					((CheckBox)lstWorkOrder.Items[i].FindControl("chkSelect")).Enabled=false;
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
						if(((CheckBox)e.Item.FindControl("chkSelect")).Checked==true)
						{
							SICALNet.BusinessEntities.PartidasInspeccionInfo PIInfo = new SICALNet.BusinessEntities.PartidasInspeccionInfo(secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["InspeccionRoomId"]));
							SICALNet.BusinessLogicLayer.PartidasInspeccion BLIns = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
							int Laminas=BLIns.ActiveLaminas(PIInfo);
							Response.Redirect("EnvioPTFinal.aspx?InitialDate="+txtInitial.Text+"&FinalDate="+txtFinal.Text+"&cboStatus="+cboStatus.SelectedItem.Value+"&cboLinea="+cboLinea.SelectedItem.Value+"&Reflag=True&Packages=1&Secuencia="+secuencia+"&Descripcion="+Descripcion+"&Laminas="+Laminas+"&Flag=New&IdStatus="+IdStatus+"&Fecha="+Fecha);
						}
						else
						Response.Redirect("NumeroPaquete.aspx?Secuencia="+secuencia+"&Descripcion="+Descripcion+"&IdStatus="+IdStatus+"&CboStatus="+cboStatus.SelectedItem.Value+"&cboLinea="+cboLinea.SelectedItem.Value+"&InitialDate="+txtInitial.Text+"&FinalDate="+txtFinal.Text+"&Fecha="+Fecha);
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
			catch(Exception ex)
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('"+ ex.Message +"');</script>"; 
				Page.RegisterStartupScript("ClientScript",ScriptString);
			}
		}

	}
}
