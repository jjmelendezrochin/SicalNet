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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace UserInterface.Forms.Production.WorkOrder.PartidasColor
{
	/// <summary>
	/// Summary description for ColorWOReport1.
	/// </summary>
	public class ColorWOReport1 : System.Web.UI.Page
	{
		protected CrystalDecisions.Web.CrystalReportViewer ColorRpt;
		UserInterface.Forms.Production.WorkOrder.PartidasColor.ColorWOReport crReportDocument;
		Database crDatabase;
		Tables crTables;
		TableLogOnInfo crTableLogOnInfo;
		ConnectionInfo crConnectionInfo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{

			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
			crReportDocument = new UserInterface.Forms.Production.WorkOrder.PartidasColor.ColorWOReport();
			crConnectionInfo = new ConnectionInfo();
			crConnectionInfo.ServerName = ConfigurationSettings.AppSettings["server"];
			crConnectionInfo.UserID = ConfigurationSettings.AppSettings["user id"];
			crConnectionInfo.Password = ConfigurationSettings.AppSettings["Password"];
			crConnectionInfo.DatabaseName = ConfigurationSettings.AppSettings["database"];

			//Get the tables collection from the report object
			crDatabase = crReportDocument.Database;
			crTables = crDatabase.Tables;

			//Apply the logon information to each table in the collection
			foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables)
			{		
				crTableLogOnInfo = crTable.LogOnInfo;
				crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
				crTable.ApplyLogOnInfo(crTableLogOnInfo);
			}
			ParameterFields ParamFields = new ParameterFields();

			// Parameter Field - Title
			ParameterField Fecha = new ParameterField();
			Fecha.ParameterFieldName = "Fecha";
			ParameterDiscreteValue pdv = new ParameterDiscreteValue();
			pdv.Value = Request.QueryString["FechaIni"] + " al " + Request.QueryString["FechaFin"];
			Fecha.CurrentValues.Add(pdv);

			ParamFields.Add(Fecha);

			ColorRpt.ParameterFieldInfo = ParamFields;

			string FechaFin = Request.QueryString["FechaFin"];
			string FechaIni = Request.QueryString["FechaIni"];
			string	SelectionStr="";
			if(Request.QueryString["Linea"]!="0")
			SelectionStr= "{ProgramaProduccion.IdLinea}="+Convert.ToInt32(Request.QueryString["Linea"])+" AND ";
			if(Request.QueryString["Status"]!="0")
			SelectionStr+= "{OrdenesTrabajo.IdStatus}="+Convert.ToInt32(Request.QueryString["Status"])+" AND ";
			SelectionStr+= "{ProgramaProduccion.Fecha}>=Date("+DateTime.Parse(FechaIni).ToString("yyyy")+","+DateTime.Parse(FechaIni).ToString("MM")+","+DateTime.Parse(FechaIni).ToString("dd")+")";
			SelectionStr+= " AND {ProgramaProduccion.Fecha}<=Date("+DateTime.Parse(FechaFin).ToString("yyyy")+","+DateTime.Parse(FechaFin).ToString("MM")+","+DateTime.Parse(FechaFin).ToString("dd")+")";
			ColorRpt.SelectionFormula = SelectionStr+" AND {OrdenesTrabajo.IdArea}=1 AND "+Request.QueryString["Secuencias"].ToString();
			ColorRpt.ReportSource = crReportDocument;
			ColorRpt.DisplayGroupTree=false;
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
