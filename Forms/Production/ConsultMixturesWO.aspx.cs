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
using System.Data.SqlClient;
using SICALNet.BusinessEntities;
using Microsoft.ApplicationBlocks.Data;

namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for ConsultMixturesWO.
	/// </summary>
	public class ConsultMixturesWO : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblFechaInicial;
		protected System.Web.UI.WebControls.Label lblFechaFinal;
		protected System.Web.UI.WebControls.Label lblLinea;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.TextBox txtFechaInicial;
		protected System.Web.UI.WebControls.ImageButton cmdCalInicial;
		protected System.Web.UI.WebControls.TextBox txtFechaFinal;
		protected System.Web.UI.WebControls.ImageButton cmdCalFinal;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.DropDownList cboStatus;
		protected System.Web.UI.WebControls.Button cmdAceptar;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.DataGrid dgdWorkOrder;
		protected System.Web.UI.WebControls.RegularExpressionValidator revInitial;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button btnCard;
		protected static int localAreaId; 
		private const string PARM_SECUENCIA	="@Secuencia";
		protected System.Web.UI.WebControls.Literal ltrRefresh;
		private const string PARM_USUARIO   	="@Usuario";
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Limpieza de cache
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetNoStore();
			Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
			Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
			Response.Cache.SetValidUntilExpires(false);
			
			/*
			Response.Cache.SetExpires(DateTime.Now);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetValidUntilExpires(false);
			Response.Cache.SetNoStore();
			*/

			if((ConfigurationManager.AppSettings["TiempoRefreshListadoOrdenes"] != "0") && (ConfigurationManager.AppSettings["TiempoRefreshListadoOrdenes"]!=""))
				ltrRefresh.Text = "<META http-equiv='Refresh' content='" + ConfigurationManager.AppSettings["TiempoRefreshListadoOrdenes"] + "'>" ;			

			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				string InitDt, FinalDt;

				BindEntryFields();
				InitDt = (string) Session["InitialDate"];
				FinalDt = (string) Session["FinalDate"];

				String sFechaIni = System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();
				String sFechaFin = System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();

				if (InitDt == null || FinalDt ==null)
				{
					txtFechaInicial.Text = sFechaIni.Replace(".","");
					txtFechaFinal.Text = sFechaFin.Replace(".","");
				}
				else
				{					
					txtFechaInicial.Text = InitDt;
					txtFechaFinal.Text = FinalDt;
				}

				int IdLinea = Convert.ToInt32(cboLinea.SelectedItem.Value);
				int IdStatus = Convert.ToInt32(cboStatus.SelectedItem.Value);
				BindGrid(txtFechaInicial.Text,txtFechaFinal.Text, IdLinea, IdStatus, localAreaId);
			}
			//			object sender1=null;
			//			System.EventArgs e1=null;
			//			checkAll(sender1,e1);
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
			localAreaId=Convert.ToInt32(ConfigurationManager.AppSettings["MixturesRoomId"]);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
			this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
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

			
			
			//			cboStatus.Items.Add("ALL");
			//			string IdActiveStatus = ConfigurationManager.AppSettings["StatusActive"]; // For ACTIVO
			//			cboStatus.Items.FindByValue(IdActiveStatus).Selected = true;
		}

		private void cmdAceptar_Click(object sender, System.EventArgs e)
		{
			string FechaInicial = txtFechaInicial.Text;
			string FechaFinal = txtFechaFinal.Text;
			int IdLinea = (cboLinea.SelectedItem.Text == "ALL" ? 0 : Convert.ToInt32(cboLinea.SelectedItem.Value)); // Convert.ToInt32(cboLinea.SelectedItem.Value);
			int IdStatus = (cboStatus.SelectedItem.Text == "ALL" ? 0 : Convert.ToInt32(cboStatus.SelectedItem.Value)); //Convert.ToInt32(cboStatus.SelectedItem.Value); 
			BindGrid(FechaInicial, FechaFinal, IdLinea, IdStatus, localAreaId);
		}


		public void checkAll(object sender,System.EventArgs e)
		{
			//loop thru the list of checkboxes
			for (int i=0;i< this.dgdWorkOrder.Items.Count;i++)
			{
				CheckBox parentCheckbox = (CheckBox)sender;
				//obtain current checkbox
				CheckBox currentCheck = (CheckBox) dgdWorkOrder.Items[i].FindControl("chkSelect");
				//if it has Partidas information (is enabled)
				if (currentCheck.Enabled==true)
				{
					//Check the checkbox
					currentCheck.Checked=parentCheckbox.Checked;
					//Display details
				}
			}		
		}


		//		private void cmdCalendar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		//		{
		//			// To Show the Panel & Calender Control
		//			pnlCalendar.Visible = !pnlCalendar.Visible;
		//			cdrFecha.Visible = true;
		//		}
		//
		//		private void cdrFecha_SelectionChanged(object sender, System.EventArgs e)
		//		{
		//			// To Hide the Calender Control
		//			pnlCalendar.Visible = false;
		//			cdrFecha.Visible = false;
		//			txtFecha.Text = cdrFecha.SelectedDate.ToString("dd/MMM/yyyy");
		//		}

		public void BindGrid(string FechaInicial, string FechaFinal, int IdLinea, int IdStatus, int IdArea)
		{
			Session["InitialDate"]=FechaInicial;
			Session["FinalDate"]=FechaFinal;
			Session["selectedLine"] = IdLinea.ToString();
			Session["selectedIdStatus"] = cboStatus.SelectedItem.Value;
			//TODO:Revisar que la conversión a DateTime se haga correctamente, sino cambiar el tipo de dato de la función
			OrdenesTrabajoInfo WOInfo = new OrdenesTrabajoInfo(dmy2ymd(FechaInicial),dmy2ymd(FechaFinal),IdLinea, IdStatus, IdArea);
			// To Load the WO List
			SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
			IList WOList = (IList)WorkOrder.LoadWorkOrders(WOInfo);
			dgdWorkOrder.DataSource = WOList;
			dgdWorkOrder.DataBind();

			// ***************************************
			// Deshabilita los pendientes y cancelados
			for(int i=0;i<dgdWorkOrder.Items.Count;i++)
			{
				string Status = ((Label)dgdWorkOrder.Items[i].FindControl("ItemStatusDesc")).Text;
				if (Status == "Pendiente" || Status == "Cancelado" || Status == "N/A" )
				{
					((CheckBox)dgdWorkOrder.Items[i].FindControl("chkSelect")).Enabled=false;
				}
				else
				{
					((CheckBox)dgdWorkOrder.Items[i].FindControl("chkSelect")).Enabled=true;
				}
			}
			// ***************************************
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
				int IdStatus = Convert.ToInt32(((Label) e.Item.FindControl("ItemIdStatus")).Text);
				int IdCancelStatus = Convert.ToInt32(ConfigurationManager.AppSettings["StatusCancel"]);
				int IdPendienteStatus = Convert.ToInt32(ConfigurationManager.AppSettings["StatusPending"]);
				int IdReleaseStatus = Convert.ToInt32(ConfigurationManager.AppSettings["StatusRelease"]);
				int IdActiveStatus = Convert.ToInt32(ConfigurationManager.AppSettings["StatusActive"]);
				string Secuencia;
				Secuencia = ((Label)e.Item.FindControl("ItemSecuencia")).Text;
				if ((IdStatus == IdCancelStatus)||(IdStatus == IdPendienteStatus)) 
				{
					string ScriptString="<script language='javascript'>alert('La secuencia " + Secuencia + " esta en estado PENDIENTE, no puede ser consultada');</script>"; 
					ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
					//lblErrorMsg.Text = "Una secuencia en estado PENDIENTE no se puede consultar";
					return;
				}

				if (IdStatus == IdActiveStatus || IdStatus == IdReleaseStatus)
				{
					string Fecha, UTEC, CodigoSAP,IdPlanta;
					int NoContainer, IdArea, Cantidad;

					try
					{
						
						Fecha = ((Label)e.Item.FindControl("ItemFecha")).Text;
						UTEC = ((Label)e.Item.FindControl("ItemDescripcion")).Text;
						Cantidad = Convert.ToInt32(((Label)e.Item.FindControl("ItemCantidad")).Text);
						CodigoSAP=((Label)e.Item.FindControl("ItemCodigoSAP")).Text;
						IdPlanta=((Label)e.Item.FindControl("ItemIdPlanta")).Text;


						IdArea = Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]);
						SICALNet.BusinessLogicLayer.PartidasAditivos PAditivos = new SICALNet.BusinessLogicLayer.PartidasAditivos();
						NoContainer = PAditivos.GetNoContainers(Secuencia, IdArea);

					}
					catch(Exception ex)
					{
						lblErrorMsg.Text = ex.Message;
						return;
					}

					string sBitacora = string.Format("Secuencia {0}, Fecha {1}, UTEC {2}, Cantidad {3}, Container {4}",
						Secuencia.ToString(), Fecha.ToString(), UTEC.ToString(), Cantidad.ToString(), NoContainer.ToString());
					// guardamos en la bitacora
					SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
					BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

					Response.Redirect("ConsultMixturesWO1.aspx?Secuencia=" + Secuencia 
						+ "&Fecha=" + Fecha 
						+ "&Cantidad=" + Cantidad 
						+ "&NoContainer=" + NoContainer 
						+ "&Status=" + IdStatus 
						+ "&CodigoSAP=" + CodigoSAP 
						+ "&IdPlanta=" + IdPlanta 
						+ "&UTEC=" + UTEC.Replace("#",""));
				}
			}

			if (e.CommandName=="Agregar")
			{
				string Secuencia = ((Label)e.Item.FindControl("ItemSecuencia")).Text.ToString();
				string IdArea= ConfigurationManager.AppSettings["MixturesRoomId"].ToString();
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
				if (lblStatus.Text == ConfigurationManager.AppSettings["StatusCancel"]) 
					e.Item.BackColor = Color.Tomato;
			}
		}

		private void dgdWorkOrder_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnCard_Click(object sender, System.EventArgs e)
		{
			try
			{	
				TruncaTablaReporte();
				int i=0;
				string[] secuencia=new string[this.dgdWorkOrder.Items.Count];
				for(int iloop=0;iloop<dgdWorkOrder.Items.Count;iloop++)
				{
					if(((CheckBox)dgdWorkOrder.Items[iloop].FindControl("chkSelect")).Checked==true)
					{
						secuencia[i]=((Label)dgdWorkOrder.Items[iloop].FindControl("ItemSecuencia")).Text.ToString();
						InsertaTablaEtiqueta(secuencia[i], this.User.Identity.Name);
						i++;
					}
				}
				
				if(i==0)
				{
					Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
						"alert('Seleccione una secuencia para generar una tarjeta');</script>");

					return;
				}				
				
				string reportName = "";	
				Reports.ReportHelper rptHelper = new Reports.ReportHelper();
				//Production.EtiquetaIdentificacionMaterial reporte = new UserInterface.Forms.Production.EtiquetaIdentificacionMaterial();				
				//Production.ReporteMezclas reporte = new UserInterface.Forms.Production.ReporteMezclas();				
				Production.EtiquetaMezclas reporte = new UserInterface.Forms.Production.EtiquetaMezclas();				
				rptHelper.setPermission(reporte);
				reportName = rptHelper.exportReport(reporte,"Etiqueta Identificación",User.Identity.Name);

				string redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";			
				string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','Reporte', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>"; 
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
			}
			catch
			{
				throw;
			}
		}

		public  void InsertaTablaEtiqueta(string Secuencia, string sUsuario)
		{									
			SqlParameter[] Parms=Parametros();
			EstableceParametrosSecuencia(Parms, Secuencia, sUsuario);
			
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
			{
				conn.Open();
				using (SqlTransaction trans = conn.BeginTransaction()) 
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "Proc_ReporteEtiquetasMezclas", Parms);
						trans.Commit();
					}
					catch 
					{
						trans.Rollback();
						throw;
					}
				}
			}
		}

		public  void TruncaTablaReporte()
		{												
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
			{
				conn.Open();
				using (SqlTransaction trans = conn.BeginTransaction()) 
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(trans, CommandType.Text, "Truncate table Rep_ReporteIdentificacionEtiqueta;");
						trans.Commit();
					}
					catch 
					{
						trans.Rollback();
						throw;
					}
				}
			}
		}
		

		public static SqlParameter[] Parametros()
		{
			SqlParameter[] parms;
			parms = SqlHelperParameterCache.GetCachedParameterSet(ConfigurationManager.AppSettings["SICALConnString"],"Proc_EtiquetaMezclas");
			parms= new SqlParameter[]{
										 new SqlParameter(PARM_SECUENCIA,SqlDbType.VarChar),
										 new SqlParameter(PARM_USUARIO,SqlDbType.VarChar)
									 };
			SqlHelperParameterCache.CacheParameterSet(ConfigurationManager.AppSettings["SICALConnString"],"Proc_EtiquetaMezclas",parms);
			return parms;
		}

		public static void EstableceParametrosSecuencia(SqlParameter[] parms,string Secuencia, string Usuario)
		{
			parms[0].Value = Secuencia;
			parms[1].Value = Usuario;
		}	
	}
}