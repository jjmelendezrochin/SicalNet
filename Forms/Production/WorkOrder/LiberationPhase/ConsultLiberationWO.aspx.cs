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
using System.IO;
using System.Net;
using System.Data.SqlClient;
using System.Configuration;
using SICALNet.BusinessEntities;
using Microsoft.ApplicationBlocks.Data;
using SICALNet.Utilities;
using SICALNet.BusinessLogicLayer;
using CrystalDecisions.Shared;
using System.Threading;
using System.Data.OleDb;
using System.Diagnostics;

namespace UserInterface.Forms.Production.WorkOrder.LiberationPhase
{
	/// <summary>
	/// Descripción breve de ConsultLiberationWO.
	/// </summary>
	public class ConsultLiberationWO : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal ltrRefresh;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblLinea;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.TextBox txtFechaInicial;
		protected System.Web.UI.WebControls.ImageButton ImgFechaInicial;
		protected System.Web.UI.WebControls.TextBox txtFechaFinal;
		protected System.Web.UI.WebControls.ImageButton ImgFechaFinal;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.DropDownList cboStatus;
		protected System.Web.UI.WebControls.Button cmdAceptar;
		protected System.Web.UI.WebControls.RegularExpressionValidator revInitial;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.DataGrid dgdInspectionWO;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Button btnImprimir;
		protected System.Web.UI.WebControls.Button cmdEjecutaReporte;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.HiddenField txtSecuenciasSelectionFormula;
		protected System.Web.UI.WebControls.HiddenField txtSecuencias;
		protected System.Web.UI.WebControls.HiddenField txtOrdenes;
	
		// Aqui se hace referencia al área 12 del catálogo de áreas
		// que es la fase de inspección de la tabla de Area
		// JJMR 16/08/2023

		protected static int localAreaId = 12; 
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);

			//if((ConfigurationManager.AppSettings["TiempoRefreshListadoOrdenes"] != "0") && (ConfigurationManager.AppSettings["TiempoRefreshListadoOrdenes"]!=""))
			//	ltrRefresh.Text = "<META http-equiv='Refresh' content='" + ConfigurationManager.AppSettings["TiempoRefreshListadoOrdenes"] + "'>" ;			

			string path = HttpContext.Current.Request.MapPath("~");
			UserInterface.Forms.Production.WorkOrder.LiberationPhase.Log log
				= new Log(path);
			
			//log.Add("Inicio proceso");			

			if (!IsPostBack)
			{
				// log.Add("antes de BindEntryFields");
				BindEntryFields();
				// log.Add("depués de BindEntryFields");

				string tmpInit = (string) Session["InitialDate"];
				string tmpFin = (string) Session["FinalDate"];

				String sFechaIni = System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();
				String sFechaFin = System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();

				if (tmpInit == null || tmpFin ==null)
				{
					txtFechaInicial.Text=System.DateTime.Now.ToString("dd-MMM-yyyy");
					txtFechaFinal.Text=System.DateTime.Now.ToString("dd-MMM-yyyy");
				}
				else
				{
					txtFechaInicial.Text=tmpInit;
					txtFechaFinal.Text=tmpFin;
				}
				//BindGrid(Convert.ToInt32(cboLinea.SelectedItem.Value), Convert.ToInt32(cboStatus.SelectedItem.Value));				
			}
		}
	
		private void BindEntryFields()
		{
			SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
			SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
			theUser  = BLLUser.Load(theUser);

			string path = HttpContext.Current.Request.MapPath("~");
			UserInterface.Forms.Production.WorkOrder.LiberationPhase.Log log
				= new Log(path);
			
			//log.Add("antes depoblar linea");
			//Code to populate Linea ComboBox
			SICALNet.BusinessLogicLayer.LineaProduccion Linea = new SICALNet.BusinessLogicLayer.LineaProduccion();
			IList LineaList = (IList) Linea.SelectLinePdt(theUser);
			

			cboLinea.DataSource = LineaList;
			cboLinea.DataValueField = "IdLinea";
			cboLinea.DataTextField = "Description";
			cboLinea.DataBind();
			//log.Add("depuesdepoblar linea");
			cboLinea.Items.Add(new ListItem(string.Empty,"0"));
			string currentLine=(string)Session["selectedLine"];
			//log.Add("linea actual " + currentLine);
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
			// SICALNet.BusinessLogicLayer.Status Status = new SICALNet.BusinessLogicLayer.Status();
			// IList StatusList = (IList) Status.Load();
			
			// cboStatus.DataSource = StatusList;
			// cboStatus.DataValueField = "IdStatus";
			// cboStatus.DataTextField = "Descripcion";
			// cboStatus.DataBind();
			//log.Add("antes de llenara status");
			cboStatus.Items.Add(new ListItem(string.Empty,"0"));
			cboStatus.Items.Add(new ListItem("Liberado","5"));
			//string currentIdStatus=(string)Session["selectedIdStatus"];
			string currentIdStatus="5";
			//log.Add("depués de llenara status");
			
			//log.Add("Curret idStatus");
			//log.Add(currentIdStatus);
			if (currentIdStatus != null)
				cboStatus.Items.FindByValue(currentIdStatus).Selected=true;
			else
				cboStatus.Items.FindByValue("5").Selected=true;	// Liberado por default
		}
		
		#region Código generado por el Diseñador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Diseñador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{    
			this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
			this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
			this.cmdEjecutaReporte.Click += new System.EventHandler(this.cmdEjecutaReporte_Click);
			this.dgdInspectionWO.SelectedIndexChanged += new System.EventHandler(this.dgdInspectionWO_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdAceptar_Click(object sender, System.EventArgs e)
		{
			int IdLinea = (cboLinea.SelectedItem.Text == "ALL" ? 0 : Convert.ToInt32(cboLinea.SelectedItem.Value));
			int IdStatus = (cboStatus.SelectedItem.Text == "ALL" ? 0 : Convert.ToInt32(cboStatus.SelectedItem.Value));

			
			BindGrid(IdLinea, IdStatus);

			Session["InitialDate"]=txtFechaInicial.Text;
			Session["FinalDate"]=txtFechaFinal.Text;
		}

		public void BindGrid(int IdLinea, int IdStatus)
		{
			OrdenesTrabajoInfo WOInfo = new OrdenesTrabajoInfo(dmy2ymd(txtFechaInicial.Text),dmy2ymd(txtFechaFinal.Text), IdLinea,IdStatus,localAreaId);

			//Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
			//	"alert('"+"localAreaId = "+ localAreaId + "');</script>");

			Session["InitialDate"]=txtFechaInicial.Text;
			Session["FinalDate"]=txtFechaFinal.Text;
			Session["selectedLine"] = IdLinea.ToString();
			Session["selectedIdStatus"] = cboStatus.SelectedItem.Value;

			// To Load the WO List
			SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
			IList WOList = (IList)WorkOrder.LoadWorkOrders(WOInfo);
			dgdInspectionWO.DataSource = WOList;
			dgdInspectionWO.DataBind();
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

		public void CheckAll(object sender, System.EventArgs e)
		{
		

			CheckBox Chk = (CheckBox)sender;
			if(Chk.Checked)
			{
				for(int iloop=0;iloop<dgdInspectionWO.Items.Count;iloop++)
				{
					((CheckBox)dgdInspectionWO.Items[iloop].FindControl("chkSelect")).Checked=true;
				}
			}
			else
			{
				for(int iloop=0;iloop<dgdInspectionWO.Items.Count;iloop++)
				{
					((CheckBox)dgdInspectionWO.Items[iloop].FindControl("chkSelect")).Checked=false;
				}
			}
		}

		private void dgdInspectionWO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnImprimir_Click(object sender, System.EventArgs e)
		{
			string path = HttpContext.Current.Request.MapPath("~");
			Log oLog = new Log(path);

			int i=0;
			string[] secuencia=new string[dgdInspectionWO.Items.Count];
			string secuencias = "";
			string listasecuencias = "";
			string listaordenes = "";
			string listadatosencbb = "";

			for(int iloop=0;iloop<dgdInspectionWO.Items.Count;iloop++)
			{
				if(((CheckBox)dgdInspectionWO.Items[iloop].FindControl("chkSelect")).Checked==true)
				{
					secuencia[i]=((Label)dgdInspectionWO.Items[iloop].FindControl("ItemSecuencia")).Text.ToString();
	
					// ********************************
					// obteniendo mas datos que faltan que son
					// secuencia | orden | código | descripción | programadas | 1a 
					string sConsulta = "Select datos" +
									"	from Vw_datos_etiqueta_liberacion Vw  " +
									"	where Vw.Secuencia = '" + secuencia[i] + "';";
					using(SqlDataReader rsOrden = SqlHelper.ExecuteReader(ConfigurationManager.AppSettings["SICALConnString"], CommandType.Text, sConsulta)) 
					{
						while (rsOrden.Read()) 
						{			
							string datoscompletos = rsOrden.GetString(0);							
							listadatosencbb += " _ " + datoscompletos;
						}
					}	
					// ********************************

					i++;
				}
			}

			// Validación de secuencia mayor a cero
			if (i==0) 
			{				
				string mensaje = string.Format("Favor de seleccionar alguna secuencia para imprimir");

				ClientScript.RegisterStartupScript(
					this.GetType(),
					"Liberación",
					"SicalAlert.mostrar('" + mensaje + "', 'advertencia');",
					true
				);
				return;
			}

			oLog.Add("Secuencias seleccionadas " + i);

			for(int k=0;k<i;k++)
			{
				secuencias += " OR {Vw_etiqueta_liberacion.Secuencia}=" + (char)34 + secuencia[k] + (char)34  ;
				listasecuencias += " _ " + secuencia[k];
				// ********************************
				// obteniendo la lista de ordenes
				string sConsulta = "Select NoOrden from Vw_etiqueta_liberacion WHERE Secuencia = '" + secuencia[k].Trim() + "';";
				using(SqlDataReader rsOrden = SqlHelper.ExecuteReader(ConfigurationManager.AppSettings["SICALConnString"], CommandType.Text, sConsulta)) 
				{
					while (rsOrden.Read()) 
					{			
						string sOrden = rsOrden.GetString(0);
						listaordenes += " _ " + sOrden;
					}
				}	
				// ********************************
			}


			// Quitando la palabra or
			secuencias = secuencias.Substring(4,secuencias.Length-4);
			listasecuencias = listasecuencias.Substring(3,listasecuencias.Length-3);
			listadatosencbb = listadatosencbb.Substring(3,listadatosencbb.Length-3);
			listaordenes = listaordenes.Substring(3,listaordenes.Length-3);
			string servercbb = ConfigurationManager.AppSettings["servercbb"];
			
			oLog.Add("Lista secuencias " + listasecuencias);
			oLog.Add("Lista datos en cbb " + listadatosencbb);							
			oLog.Add("Secuencias " + secuencias);
			oLog.Add("servercbb " + servercbb);
			oLog.Add("Lista listaordenes " + listaordenes);	
			
			if(i==0)
			{
				// throw new Exception(" Select Secuencias to generate report");

				Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
					"alert('"+"Seleccione alguna(s) secuencia(s) para generar las etiquetas"+"');</script>");

				return;
			}				
			else
			{
				// ***********************************************************
				// Ejecución de proceso que genera el cbb para el grupo de secuencias
				// seleccionadas				
				Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
					"GeneraCbb('"+ listasecuencias + "','" + listadatosencbb + "','" + secuencias + "','" + servercbb + "','" + listaordenes + "');</script>");
			}
		
		}
	
		// ***************************
		// Proceso que genera reporte
		private void cmdEjecutaReporte_Click(object sender, System.EventArgs e)
		{		
			string path = HttpContext.Current.Request.MapPath("~");
			Log oLog = new Log(path);
			oLog.Add ("Dentro de cmdEjecutaReporte_Click");

			try{				
				// Lectura de secuencias selection formula
				string secuencias = this.txtSecuencias.Value;
				string ordenes = this.txtOrdenes.Value;

				oLog.Add("Las secuencias son " +  secuencias);
				oLog.Add("Las ordenes son  " +  ordenes);

				string[] secuencia = secuencias.Split('_');
				string[] orden = ordenes.Split('_');

				int i = secuencia.Length;				

				// ***********************************************************
				// Tuncando la tabla tbl_qrcode
				string sIns = "Truncate table tbl_QrCode";				
				using (SqlConnection cn = 
						   new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
				{
					using( SqlCommand sqlcmd = new SqlCommand(sIns,cn))
					{
						cn.Open();
						sqlcmd.ExecuteNonQuery();
					}
				}
				oLog.Add ("Truncando la tabla tbl_QrCode");

				// ***********************************************************
				// Tuncando la tabla tbl_qrcode
				sIns = "Truncate table tbl_QrCode_orden";				
				using (SqlConnection cn = 
						   new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
				{
					using( SqlCommand sqlcmd = new SqlCommand(sIns,cn))
					{
						cn.Open();
						sqlcmd.ExecuteNonQuery();
					}
				}
				oLog.Add ("Truncando la tabla tbl_QrCode_orden");

				// ***********************************************************
				// Guardando una imagen a un archivo local
				WebClient webclient= new WebClient();	
				
				for(int k=0;k<i;k++)
				{	
					// Obtiene la ruta de las imagenes desde el servidor adonde se generan las imagenes
					oLog.Add("secuencia " +  secuencia[k]);
					oLog.Add("orden " +  orden[k]);

					string sRutaImagenes = ConfigurationManager.AppSettings["servercbb_images"];
					string sRutaRemota  = sRutaImagenes + secuencia[k].Trim()+".png";
					string sRutaRemota1 = sRutaImagenes + orden[k].Trim()+".png";
					string sRutaImagenesLocales = ConfigurationManager.AppSettings["servercbb_local_images"];
					string sRutaLocal   =  @sRutaImagenesLocales + secuencia[k].Trim()+".png";
					string sRutaLocal1  =  @sRutaImagenesLocales + orden[k].Trim()+".png";

					oLog.Add("sRutaImagenes " +  sRutaImagenes);
					oLog.Add("sRutaRemota " +  sRutaRemota);
					oLog.Add("sRutaImagenesLocales " +  sRutaImagenesLocales);
					oLog.Add("sRutaLocal " +  sRutaLocal);
					oLog.Add("sRutaLocal1 "+  sRutaLocal1);

					oLog.Add("Descargando " + sRutaRemota + " en " + sRutaLocal);
					oLog.Add("Descargando " + sRutaRemota1 + " en " + sRutaLocal1);

					webclient.DownloadFile(sRutaRemota, sRutaLocal);
					webclient.DownloadFile(sRutaRemota1, sRutaLocal1);

					// *********************************
					// Inserción de imágen bidimensional en tabla

					byte[] photo = GetPhoto(sRutaLocal);
					//oLog.Add("Longitud "+  photo.Length);

					using (SqlConnection cn = 
							   new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
					{
						String sIns1= "INSERT INTO tbl_qrcode(Secuencia,Document) VALUES(@Secuencia, @Document)";

						using( SqlCommand sqlcmd = new SqlCommand(sIns1,cn))
						{
							sqlcmd.Parameters.Add("@Secuencia", System.Data.SqlDbType.Text,10).Value =secuencia[k].Trim();
							sqlcmd.Parameters.Add("@Document", System.Data.SqlDbType.Image,photo.Length).Value=photo;

							cn.Open();
							sqlcmd.ExecuteNonQuery();
						}
					}

					// *********************************
					// Inserción de imágen unidimensional en tabla
					photo = GetPhoto(sRutaLocal1);
					//oLog.Add("Longitud "+  photo.Length);

					using (SqlConnection cn = 
							   new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
					{
						String sIns1= "INSERT INTO tbl_qrcode_orden(Secuencia,Document) VALUES(@Secuencia, @Document)";

						using( SqlCommand sqlcmd = new SqlCommand(sIns1,cn))
						{
							sqlcmd.Parameters.Add("@Secuencia", System.Data.SqlDbType.Text,10).Value =secuencia[k].Trim();
							sqlcmd.Parameters.Add("@Document", System.Data.SqlDbType.Image,photo.Length).Value=photo;

							cn.Open();
							sqlcmd.ExecuteNonQuery();
						}
					}
					// *********************************
				}
				
				oLog.Add("Se insertan los datos ");

				// ***********************************************************

				// Lectura de secuencias selection formula
				string txtSecuenciasSelectionFormula = this.txtSecuenciasSelectionFormula.Value;
				oLog.Add("Selection Formula " + txtSecuenciasSelectionFormula);

				// Impresión de reporte
				Reports.ReportHelper rptHelper = new Reports.ReportHelper();
				Production.WorkOrder.LiberationPhase.EtiquetaLiberacion reporte 
					= new Production.WorkOrder.LiberationPhase.EtiquetaLiberacion();		
				reporte.DataDefinition.RecordSelectionFormula=txtSecuenciasSelectionFormula;
				oLog.Add("Permisos");
				
				rptHelper.setPermission(reporte);
				string reportName = rptHelper.exportReport(reporte,"Liberación",User.Identity.Name);				
				string redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";			
				string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','Reporte', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>"; 
				oLog.Add("Impresión de reporte");
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
				
			}
			catch(Exception ex)
			{
				oLog.Add("Error " +  ex.Message);
				string sError = ex.Message;
			}
		}
	
		// ***************************
		// **** Read Image into Byte Array from Filesystem
		public static byte[] GetPhoto(string filePath)
		{
			FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			BinaryReader br = new BinaryReader(fs);

			byte[] photo = br.ReadBytes((int)fs.Length);

			br.Close();
			fs.Close();

			return photo;
		}
	}
}
