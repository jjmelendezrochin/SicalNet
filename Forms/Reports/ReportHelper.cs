using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Configuration;
using System.IO;

namespace UserInterface.Forms.Reports
{
	/// <summary>
	/// Summary description for ReportHelper.
	/// </summary>
	public class ReportHelper
	{
		public ReportHelper()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		
		public string exportReport(ReportDocument pReport, string reportName,string userName)
		{	
		try
			{	
				DeletePreviousReportFiles(reportName,userName);
				// Declare variables and get the export options.
				ExportOptions exportOpts = new ExportOptions();
				DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();			
				exportOpts = pReport.ExportOptions;
				// Set the export format.			
				exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
				exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
				// Set the disk file options.
				//Get filepath from Configuration Settings
				string allReportName = GetNewReportName(reportName,userName);
				diskOpts.DiskFileName = ConfigurationSettings.AppSettings["reportsLocalPath"].ToString() + allReportName +".pdf";
				exportOpts.DestinationOptions = diskOpts;
				// Export the report.
				pReport.Export();
				return(allReportName);

			}
			catch (Exception e)
			{
				string sError = e.Message;
				throw;
			}
		}


		private void DeletePreviousReportFiles(string reportName,string userName)
		{
			try
			{
				DirectoryInfo dir = new DirectoryInfo(ConfigurationSettings.AppSettings["reportsLocalPath"].ToString());
				foreach(FileInfo file in dir.GetFiles())
				{
					if( file.Name.IndexOf(reportName + "_" + userName) != -1)
					{
						try
						{
							file.Delete();

						}
						catch(System.IO.IOException )
						{
						}
					}

				}
			}
			catch
			{
				throw;
			}
		}

		private string GetNewReportName(string reportName,string userName)
		{
			string guid = Guid.NewGuid().ToString();
			return reportName + "_" + userName + "_" + guid;

		}

		public void setPermission(ReportDocument currentReport)
		{
			
			CrystalDecisions.Shared.TableLogOnInfo logOn = new CrystalDecisions.Shared.TableLogOnInfo();

			logOn.ConnectionInfo.ServerName = ConfigurationSettings.AppSettings["server"].ToString();
			logOn.ConnectionInfo.DatabaseName= ConfigurationSettings.AppSettings["database"].ToString();
			logOn.ConnectionInfo.UserID = ConfigurationSettings.AppSettings["user id"].ToString();
			logOn.ConnectionInfo.Password= ConfigurationSettings.AppSettings["password"].ToString();
		
			// int intSuccess=0;
			foreach(CrystalDecisions.CrystalReports.Engine.Table tbl in currentReport.Database.Tables)
			{

				tbl.LogOnInfo.ConnectionInfo=logOn.ConnectionInfo;
				tbl.ApplyLogOnInfo(logOn);
				try
					{
					if (!(tbl.TestConnectivity()))
					{
						// intSuccess = 2;

						throw new Exception("Error al conectar reporte a la base de datos " + ConfigurationSettings.AppSettings["database"].ToString() + " en el servidor " + ConfigurationSettings.AppSettings["server"].ToString());
						
					}
				}
				catch // (Exception exe)
				{
				}
			}			
		}
	}
}
