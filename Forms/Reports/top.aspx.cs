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
using System.Data.OleDb;
using Microsoft.ApplicationBlocks.Data;

namespace UserInterface.Forms.Reports
{
	/// <summary>
	/// Descripción breve de top.
	/// </summary>
	public class top : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblInitial;
		protected System.Web.UI.WebControls.TextBox txtInitial;
		protected System.Web.UI.WebControls.Image imgInitial;
		protected System.Web.UI.WebControls.Label lblFinal;
		protected System.Web.UI.WebControls.TextBox txtFinal;
		protected System.Web.UI.WebControls.Image imgFinal;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Button cmdCatalogo;
		protected System.Web.UI.WebControls.Button cmdExportar;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden idReporte;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList lstReporte;
	
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{			
				string tmpInit = (string) Session["InitialDate"];
				string tmpFin = (string) Session["FinalDate"];
				BorraCsvs();

				String sFechaIni = System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();
				String sFechaFin = System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();

				if (tmpInit == null || tmpFin ==null)
				{
					txtInitial.Text = sFechaIni.Replace(".","");
					txtFinal.Text = sFechaFin.Replace(".","");
					try
					{

					}
					catch
					{
						throw;
					}
				}
				else
				{
					txtInitial.Text = sFechaIni.Replace(".","");
					txtFinal.Text = sFechaFin.Replace(".","");

				}
			}
		}

		
		protected void cmdCatalogo_Click(object sender, EventArgs e)
		{
			int tabla = Convert.ToInt32(Request.Form["lstReporte"]);

			BindGrid(tabla, false);
		}

		
		protected void cmdExportar_Click(object sender, EventArgs e)
		{
			int tabla = Convert.ToInt32(Request.Form["lstReporte"]);

			BindGrid(tabla, true);
		}

		
		private void BindGrid(int iTabla, bool exportar)
		{

			int iExcel = 0;
			string FechaIni = "";
			string FechaFin = "";
			DateTime dFechaIni = System.DateTime.Now;
			DateTime dFechaFin = System.DateTime.Now;
			try
			{
				iExcel = exportar ? 1 : 0;				
				FechaIni = txtInitial.Text;
				FechaFin = txtFinal.Text;			
				dFechaIni = dmy2ymd(FechaIni);
				dFechaFin = dmy2ymd(FechaFin);
			}
			catch (System.NullReferenceException error)
			{
				string sError = error.ToString();
			}

			// Introducir aquí el código de usuario para inicializar la página
			string strSQL = "";			
			// Introducir aquí el código de usuario para inicializar la página
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
			{
				conn.Open();

			// Consulta
			{
				// Consulta
				switch (iTabla)
				{
					case 1:		// Aditivos
						strSQL = "Select  * from SicalNet.dbo.Vw_ListaAditivos  where renglon > 0 order by 11 asc;";
						this.lblTitulo.Text = "Catálogo de Aditivos";
						break;
					case 2:		// Colores
						strSQL = "Select  * from SicalNet.dbo.Vw_ListaColores  where renglon > 0 order by 9 asc;";
						this.lblTitulo.Text = "Catálogo de Colores";
						break;
					case 3:		// Materiales
						strSQL = "Select  * from SicalNet.dbo.Vw_ListaMateriales  where renglon > 0 order by 16 asc;";
						this.lblTitulo.Text = "Catálogo de Materiales";
						break;
					case 4:		// Presentaciones
						strSQL = "Select  * from SicalNet.dbo.Vw_ListaPresentacion  where renglon > 0 order by 8 asc;";
						this.lblTitulo.Text = "Catálogo de Presentación";
						break;
					case 5:		// Pvc
						strSQL = "Select  * from SicalNet.dbo.Vw_ListaPvc  where renglon > 0 order by 10 asc;";
						this.lblTitulo.Text = "Catálogo de PVC";
						break;
					case 6:		// Tabla
						strSQL = "Select  * from SicalNet.dbo.Vw_ListaTablaPesos  where renglon > 0 order by 8 asc;";
						this.lblTitulo.Text = "Tabla de Pesos";
						break;
					case 7:
						strSQL =
							" Select * from Vw_Interface V " +
							" Where Cast(V.fechahora as date) " +
							" between '" + dFechaIni.ToString("yyyy/MM/dd") + "' and  '" + dFechaFin.ToString("yyyy/MM/dd") + "';";
						this.lblTitulo.Text = "Interface Datasul";
						break;
				}
				
				if (iTabla>0)
				{
					// Cración de adaptador
					SqlDataAdapter adapter = new SqlDataAdapter(strSQL, conn);  
					adapter.SelectCommand.CommandTimeout = 300;
					// Creando y llenando dataset
					DataSet dataSet = new DataSet();
					adapter.Fill(dataSet);

					// Creando una nueva vista
					System.Data.DataView oView = new DataView(dataSet.Tables[0]);
					this.DataGrid1.DataSource = oView;
					this.DataGrid1.DataBind();
				}
			}
				// Exportación
				if (iExcel == 1)
				{

					// Generando archivo para interface datasul
					if (iTabla==7)
					{
						/* Ejecuta el proceso que completa los campo y llena la tabla
						 Rep_InterfaceDatasul
						*/ 

						string sProc = "Exec Proc_Completa_Interface_Datasul @FechaIni = '" + dFechaIni.ToString("yyyy/MM/dd") + "',  @FechaFin = '" + dFechaFin.ToString("yyyy/MM/dd")  + "'";
						using (SqlConnection cn = 
								   new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
						{
							using( SqlCommand sqlcmd = new SqlCommand(sProc,cn))
							{
								sqlcmd.CommandTimeout=999999;
								cn.Open();								
								sqlcmd.ExecuteNonQuery();
							}
						}																		
					}
					else
					{		
						string sNombre = string.Empty;
						switch (iTabla)
						{
							case 1:		// Aditivos
								sNombre = "Aditivos";
								break;
							case 2:		// Colores
								sNombre = "Colores";
								break;
							case 3:		// Materiales
								sNombre = "Materiales";
								break;
							case 4:		// Presentaciones
								sNombre = "Presentacion";
								break;
							case 5:		// Pvc
								sNombre = "PVC";
								break;
							case 6:		// Tabla
								sNombre = "Pesos";
								break;
						}


						Response.Clear();

						Response.ContentType = "application/vnd.ms-excel";

						// Generate UUID
						string uuid = Guid.NewGuid().ToString();

						// File name: Exportacion_UUID.xls
						string nombreArchivo = sNombre + "_" + uuid + ".xls";

						Response.AddHeader("Content-Disposition", 
							"attachment;filename=" + nombreArchivo);

						Response.Charset = "UTF-8";

						this.EnableViewState = false;

						using (System.IO.StringWriter tw = new System.IO.StringWriter())
						{
							using (System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw))
							{
								DataGrid1.RenderControl(hw);
								Response.Write(tw.ToString());
							}
						}

						Response.End();
					}


					switch (iTabla)
					{
						case 1:		// Aditivos
							strSQL = "Select * from SicalNet.dbo.Vw_ListaAditivos  where renglon > 0 order by 11 asc;";
							this.lblTitulo.Text = "Catálogo de Aditivos";
							break;
						case 2:		// Colores
							strSQL = "Select * from SicalNet.dbo.Vw_ListaColores  where renglon > 0 order by 9 asc;";
							this.lblTitulo.Text = "Catálogo de Colores";
							break;
						case 3:		// Materiales
							strSQL = "Select * from SicalNet.dbo.Vw_ListaMateriales  where renglon > 0 order by 16 asc;";
							this.lblTitulo.Text = "Catálogo de Materiales";
							break;
						case 4:		// Presentaciones
							strSQL = "Select * from SicalNet.dbo.Vw_ListaPresentacion  where renglon > 0 order by 8 asc;";
							this.lblTitulo.Text = "Catálogo de Presentación";
							break;
						case 5:		// Pvc
							strSQL = "Select * from SicalNet.dbo.Vw_ListaPvc  where renglon > 0 order by 10 asc;";
							this.lblTitulo.Text = "Catálogo de PVC";
							break;
						case 6:		// Tabla
							strSQL = "Select * from SicalNet.dbo.Vw_ListaTablaPesos  where renglon > 0 order by 8 asc;";
							this.lblTitulo.Text = "Tabla de Pesos";
							break;
						case 7:
							strSQL =" Exec Proc_Exporta_interface " +
								" @FechaInicial ='" + dFechaIni.ToString("yyyy/MM/dd") + "'," +
								" @FechaFinal   ='" + dFechaFin.ToString("yyyy/MM/dd") + "'," +
								" @CodigoSap    = ''";

							string sBitacora = string.Format("Exportación {0}", strSQL);
			
							SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
							BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());
								
							this.lblTitulo.Text = "Interface Datasul";
							break;
					}

					// Cración de adaptador
					SqlDataAdapter adapter = new SqlDataAdapter(strSQL, conn);  
					adapter.SelectCommand.CommandTimeout = 300; // 5 minutos
					// Creando y llenando dataset
					DataSet dataSet = new DataSet();
					adapter.Fill(dataSet);

					// Creando una nueva vista
					DataView oView = new DataView(dataSet.Tables[0]);
					this.DataGrid1.DataSource = oView;
					this.DataGrid1.DataBind();	
			
					// Exportando los datos a Excel
					if (iTabla==7)
					{
						string fileName = GeneraCsv(dataSet.Tables[0]);
						
						try
						{
							Response.Redirect(fileName);						
						}
						catch(System.ArgumentNullException e)
						{
							Response.Write("No Hay Datos "  + e.Message);
						}
					}

				}
			}
		}

		// ******************************************
		// Proceso que exporta datos a un archivo de texto delimitado
		private string GeneraCsv(DataTable dtCSV)
		{
			//string redirectPath=null;
			string reportName=null;
			try
			{
				

				if (dtCSV != null && dtCSV.Rows.Count > 0)
				{
					Guid guid = Guid.NewGuid();
					reportName = "Interface_datasul_" + guid.ToString() + ".csv";										
					System.IO.StreamWriter sWriter = System.IO.File.CreateText (string.Format("{0}\\{1}",Server.MapPath("."),reportName));					
					// Encabezados
					sWriter.WriteLine ("CodigoSAP, Descripcion, Nominal, espesor, color, pulgadas_tamanio, espesor_pulgadas, " +
						" proteccion, corte, mercado, PESO_LIC_STD, PESO_LIC_SLP, FAMILIA_SICAL_STD, FAMILIA_SICAL_SLP, Modulo, " +
						" fechahora, Planta, Version_Aditivos, Estado_Material, CodigoComp, cantidad, tipo, unidad, idLinea, orden");

					string sRenglon = "";

					// Fetch rows from datatable and append values as comma saprated to the object of StringBuilder class 
					foreach (DataRow row in dtCSV.Rows)
					{
						foreach (DataColumn col in dtCSV.Columns)
						{	
							sRenglon += row[col].ToString().Replace(",","").Replace("ó","o").Replace("á","a") + ",";
						}	
						sRenglon = sRenglon.Substring(0, sRenglon.Length-1);
						sWriter.WriteLine(sRenglon);
						sRenglon = "";
					}				
					
					sWriter.Flush();
					sWriter.Close();					
				}
				return reportName;
			}
			catch (Exception ex)
			{
				return ex.ToString();				
			}
		}

		
		// ******************************************
		// Proceso que cambia una fecha de formato dmy2ymd
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

		
		// ****************************************
		// Obtener la ruta física del directorio actual de la aplicación
		// Borrando archivos csv.
		private void BorraCsvs()
		{			
			string sRoute = AppDomain.CurrentDomain.BaseDirectory + @"Forms\Reports\";
			string sRoute1 = AppDomain.CurrentDomain.BaseDirectory + @"Forms\";

			string sBitacora = string.Format("--- Ruta a donde se hace el borrado {0} ---", sRoute);
			
			SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
			BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

			// Buscar todos los archivos .csv en ese directorio Forms\Reports\ y Forms
			string[] csvFiles = System.IO.Directory.GetFiles(sRoute, "*.csv");
			string[] pdfFiles = System.IO.Directory.GetFiles(sRoute, "*.pdf");
			string[] csvFiles1 = System.IO.Directory.GetFiles(sRoute1, "*.csv");
			string[] pdfFiles1 = System.IO.Directory.GetFiles(sRoute1, "*.pdf");

			sBitacora = string.Format("** Conteo de archivos csv encontrados {0} **", csvFiles.Length);
			BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

			sBitacora = string.Format("** Conteo de archivos pdfs encontrados {0} **", pdfFiles.Length);
			BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

			try
			{
				// Eliminar cada archivo encontrado csv
				foreach (string file in csvFiles)
				{				
					System.IO.File.Delete(file);							
				}
				// Eliminar cada archivo encontrado pdf
				foreach (string file1 in pdfFiles)
				{
					System.IO.File.Delete(file1);							
				}
				// Eliminar cada archivo encontrado csv
				foreach (string file2 in csvFiles1)
				{				
					System.IO.File.Delete(file2);							
				}
				// Eliminar cada archivo encontrado pdf
				foreach (string file3 in pdfFiles1)
				{
					System.IO.File.Delete(file3);
				}
			}	
			catch (Exception ex)
			{
				sBitacora = " Error " + ex.Message;
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());
			}
		}

		
		// ******************************************
		// Proceso que obtiene el mes
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
			this.cmdCatalogo.Click += new System.EventHandler(this.cmdCatalogo_Click);
			this.cmdExportar.Click += new System.EventHandler(this.cmdExportar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
