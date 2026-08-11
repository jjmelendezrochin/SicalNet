using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;

namespace UserInterface.Forms.Reports
{
	/// <summary>
	/// Descripción breve de ReporteMotivosAjusteProgProd.
	/// </summary>
	public class ReporteMotivosAjusteProgProd : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Label lblLinea;
		protected System.Web.UI.WebControls.DropDownList cboPlanta;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ImageButton imgFFinal;
		protected System.Web.UI.WebControls.TextBox txtFechaFinal;
		protected System.Web.UI.WebControls.Label lblFechaFinal;
		protected System.Web.UI.WebControls.ImageButton imgFInicial;
		protected System.Web.UI.WebControls.TextBox txtFechaInicial;
		protected System.Web.UI.WebControls.Label lblFechaInicial;
		protected System.Web.UI.WebControls.RegularExpressionValidator revInitial;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList cboCausa;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Button cmdReporte;
		protected System.Web.UI.WebControls.Label lblErrMsg;
		protected System.Web.UI.WebControls.Button cmdExportaPvc;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		const string const_All = "Todas";

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			// Introducir aquí el código de usuario para inicializar la página
			if (!IsPostBack)
			{
				
				String sFechaIni = DateTime.Now.Date.ToString("dd-MMM-yyyy");
				String sFechaFin = DateTime.Now.Date.ToString("dd-MMM-yyyy");

				txtFechaInicial.Text = sFechaIni.Replace(".","");
				txtFechaFinal.Text = sFechaFin.Replace(".","");

				// this.txtFechaInicial.Text=System.DateTime.Now.ToString("dd-MMM-yyyy");
				// this.txtFechaFinal.Text=System.DateTime.Now.ToString("dd-MMM-yyyy");

				//Code to populate Planta ComboBox
				SICALNet.BusinessLogicLayer.Planta plantInfo= new SICALNet.BusinessLogicLayer.Planta();
				IList plantaList= (IList) plantInfo.SelectPlanta();
			
				cboPlanta.DataSource = plantaList;
				cboPlanta.DataValueField = "IdPlanta";
				cboPlanta.DataTextField = "Description";
				cboPlanta.DataBind();
				cboPlanta.Items.Add(const_All);
				cboPlanta.Items.FindByText(const_All).Selected=true;

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
				cboLinea.Items.Add(const_All);
				cboLinea.Items.FindByText(const_All).Selected=true;

				//Code to populate Linea ComboBox
				this.cboCausa.Items.Insert(0, const_All);
				this.cboCausa.Items.Insert(1, "REPROGRAMACIONES");
				this.cboCausa.Items.Insert(2, "CANCELACIONES");
				this.cboCausa.Items.Insert(3, "MODIFICACIONES");				
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
			this.cmdExportaPvc.Click += new System.EventHandler(this.cmdExportaPvc_Click);
			this.cmdReporte.Click += new System.EventHandler(this.cmdReporte_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			string redirectpath= "..\\NewMenu.aspx";
			//redirectpath =;
			Response.Redirect(redirectpath);
		}


		private void cmdReporte_Click(object sender, System.EventArgs e)
		{
			lblErrMsg.Text = "";
			if (txtFechaInicial.Text == string.Empty && txtFechaFinal.Text == string.Empty)
			{
				lblErrMsg.Text = "Fecha Inicial y Final deben de tener valores";
				return;
			}
						
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			ParameterValues campoSystem= new ParameterValues();
			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();

			string reportName = "";
			string redirectPath = "";
			string SelFormula="";
			
			if (this.cboPlanta.SelectedItem.Text != const_All)
				SelFormula = "{MotivosAjusteProgProd.idPlanta}=" + Convert.ToInt32(this.cboPlanta.SelectedIndex+1);

			if (this.cboLinea.SelectedItem.Text.ToUpper() != const_All.ToUpper())
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"")  + " " + "{MotivosAjusteProgProd.idLinea}=" + Convert.ToInt32(cboLinea.SelectedIndex);
			else
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"")  + " " + "{MotivosAjusteProgProd.idLinea}>0";

			if (this.cboCausa.SelectedItem.Text != const_All)
			{
				if 	(Convert.ToInt32(this.cboCausa.SelectedIndex) != 2 && Convert.ToInt32(this.cboCausa.SelectedIndex) != 4)
					SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"")  + " " + "{MotivosAjusteProgProd.idAccion}=" + Convert.ToInt32(this.cboCausa.SelectedIndex);
				else
					SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"")  + " " + "({MotivosAjusteProgProd.idAccion}=2 or {MotivosAjusteProgProd.idAccion}=4)";
			}

			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
			{
				// SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {MotivosAjusteProgProd.Fdc}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {MotivosAjusteProgProd.Fdc}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {MotivosAjusteProgProd.Fdc}>=Date('" + dmy2ymd(txtFechaInicial.Text)+ "') AND {MotivosAjusteProgProd.Fdc}<=Date('" + dmy2ymd(txtFechaFinal.Text) + "')";
			}

			rptHelper = new Reports.ReportHelper();
			Reports.AjustesProgramaProduccion reporte = new Reports.AjustesProgramaProduccion();		
			reporte.DataDefinition.RecordSelectionFormula=SelFormula;

			rptHelper.setPermission(reporte);
			reportName = rptHelper.exportReport(reporte,"AjustesProgramaProduccion",User.Identity.Name  );
			redirectPath=ConfigurationSettings.AppSettings["reportsWebPath"]+ reportName + ".pdf";
			Response.Redirect(redirectPath);
		}

		private string dmy2ymd(String Fecha)
		{
			String sDia, sMes, sAnio, sFecha, sFecha1;
			sFecha1 = Fecha.Replace(".", "");			
			sDia = sFecha1.Substring(0, 2);
			sMes = sFecha1.Substring(3, 3);
			sAnio = sFecha1.Substring(7);
			sFecha = sAnio + "/" + GetMonth(sMes) + "/" + sDia ;
			return sFecha;
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


		private void cmdExportaPvc_Click(object sender, System.EventArgs e)
		{
			int idPlanta;
			if(this.cboPlanta.SelectedValue=="Todas")
				idPlanta =0;
			else
				idPlanta = int.Parse(this.cboPlanta.SelectedValue);

			int idLinea;
			if(this.cboLinea.SelectedValue=="Todas")
				idLinea =0;
			else
				idLinea = int.Parse(this.cboLinea.SelectedValue);
		
			String sFechaIni = this.txtFechaInicial.Text;
			String sFechaFin = this.txtFechaFinal.Text;

			if(sFechaIni=="" || sFechaFin=="")
			{
				Page.RegisterStartupScript("ClientScript","<script language=JavaScript>alert('Favor de especificar fecha inicial y final');</script>");		
				return;
			}

			sFechaIni = dmy2ymd(txtFechaInicial.Text);
			sFechaFin = dmy2ymd(this.txtFechaFinal.Text);

			//MSList = (ArrayList)mAjuste.Load(idPlanta, idLinea, sFechaIni, sFechaFin);


			string strSQL = "Exec Proc_ExportaMotivosAjuste @idPlanta=" + idPlanta.ToString() + ", @IdLinea=" + idLinea.ToString() + ", @FechaIni = '" + sFechaIni + "', @FechaFin = '" + sFechaFin + "'";	
			using (SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["SICALConnString"])) 
			{
				conn.Open();
				// Cración de adaptador
				SqlDataAdapter adapter = new SqlDataAdapter(strSQL, conn);  
				// Creando y llenando dataset
				DataSet dataSet = new DataSet();
				adapter.Fill(dataSet);

				// Creando una nueva vista
				System.Data.DataView oView = new DataView(dataSet.Tables[0]);
				this.DataGrid1.DataSource = oView;
				this.DataGrid1.DataBind();

				// Cración de adaptador
				adapter = new SqlDataAdapter(strSQL, conn);  
				// Creando y llenando dataset
				dataSet = new DataSet();
				adapter.Fill(dataSet);

				// Creando una nueva vista
				oView = new DataView(dataSet.Tables[0]);
				this.DataGrid1.DataSource = oView;
				this.DataGrid1.DataBind();

				Response.ContentType = "application/vnd.ms-excel";
				// Remove the charset from the Content-Type header.
				Response.Charset = "";

				string xlFileName = GetNewReportName("Modificacion_Prog_Produccion",User.Identity.Name );
				xlFileName += ".xls";

				// Establecer cabecera para descarga
				Response.AddHeader("Content-Disposition", "attachment; filename=\"" + xlFileName + "\"");

				// Turn off the view state.
				this.EnableViewState = false;

				System.IO.StringWriter tw = new System.IO.StringWriter();
				System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

				// Get the HTML for the control.
				DataGrid1.RenderControl(hw);
				// Write the HTML back to the browser.
				Response.Write(tw.ToString());
				// End the response.
				Response.End();
			}			
		}

		private string GetNewReportName(string reportName,string userName)
		{
			string guid = Guid.NewGuid().ToString();
			return reportName + "_" + userName + "_" + guid;

		}

		private void DownloadFile(string filePath)
		{
			System.IO.FileInfo TargetFile = new System.IO.FileInfo(filePath);
			
			//clear the current output content from the buffer
			Response.Clear();
			//add the header that specifies the default filename for the Download/
			//SaveAs dialog
			Response.AddHeader("Content-Disposition", "attachment; filename=" + TargetFile.Name);
			//add the header that specifies the file size, so that the browser
			//can show the download progress
			Response.AddHeader("Content-Length", TargetFile.Length.ToString());
			// specify that the response is a stream that cannot be read by the client and must be downloaded
			Response.ContentType = "application/octet-stream";
			// send the file stream to the client
			Response.WriteFile(TargetFile.FullName);
			// stop the execution of this page
			Response.End();
		}
	}
}
