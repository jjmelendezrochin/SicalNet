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
using System.Collections.Specialized;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace UserInterface.Forms.Logistics
{
	/// <summary>
	/// Summary description for ProgramaProduccionReport.
	/// </summary>
	public class ProgramaProduccionReport : System.Web.UI.Page
	{
		protected CrystalDecisions.Web.CrystalReportViewer CRViewer;
		
		//Crystal Report Related Variables
		UserInterface.Forms.Reports.ProgramaReport crReportDocument;
		Database crDatabase;
		Tables crTables;
		TableLogOnInfo crTableLogOnInfo;
		ConnectionInfo crConnectionInfo;

		// Functional Codes included inside of "Web Form Designer Generated Code

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
			
			crReportDocument = new UserInterface.Forms.Reports.ProgramaReport();

			crConnectionInfo = new ConnectionInfo();
			crConnectionInfo.ServerName = ConfigurationSettings.AppSettings["server"];
			crConnectionInfo.UserID = ConfigurationSettings.AppSettings["user id"];
			crConnectionInfo.Password = ConfigurationSettings.AppSettings["password"];
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
		
			//get fecha and IdLinea from Redirected URL;
			NameValueCollection FechaLinea=Request.QueryString; 
			int IdLinea = Int32.Parse(FechaLinea[1]);
			string Fecha = FechaLinea[0];
			
			//To Display records based on Given Fecha and IdLinea
			CRViewer.SelectionFormula="{ProgramaProduccion.Fecha}=Date(" + DateTime.Parse(Fecha).ToString("yyyy") + "," + DateTime.Parse(Fecha).ToString("MM") + "," + DateTime.Parse(Fecha).ToString("dd") + ") and {ProgramaProduccion.IdLinea}=" + IdLinea;
			
			//Once the connection to the database has been established for
			//each table in the report, the report object can be bound to the viewer
			//using the reportsource property of the viewer to display the report.
			CRViewer.ReportSource = crReportDocument;

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
