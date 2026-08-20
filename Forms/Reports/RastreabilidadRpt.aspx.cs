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

namespace UserInterface.Forms.Reports
{
	/// <summary>
	/// Summary description for RastreabilidadRpt1.
	/// </summary>
	public class RastreabilidadRpt1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnImprimir;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.TextBox txtSecuencia;
		protected System.Web.UI.HtmlControls.HtmlForm RastreabilidadRpt;
		protected System.Web.UI.WebControls.Label Label1;
	
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
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnImprimir_Click(object sender, System.EventArgs e)
		{
			try
			{
				SICALNet.Utilities.Validation oValidation = new   SICALNet.Utilities.Validation ();
				if ( ! (oValidation.IsNumber(txtSecuencia.Text))|| txtSecuencia.Text==String.Empty || txtSecuencia.Text =="")   
					throw new Exception("Enter Valid Secuencia") ;


				Reports.ReportHelper rptHelper = new Reports.ReportHelper();
				Reports.RastreabilidadRpt reporte = new Reports.RastreabilidadRpt();
				string SelFormula = "Val({OrdenesTrabajo.Secuencia})="+ txtSecuencia.Text; //+ " AND Time({OrdenesTrabajo.FechaLiberacion}) >= Time({Turno.Horainicial}) AND Time({OrdenesTrabajo.FechaLiberacion}) <= Time({Turno.HoraFinal})";

				ParameterValues cboSecuencia= new ParameterValues();
				ParameterDiscreteValue Secuencia= new ParameterDiscreteValue();
				Secuencia.Value=txtSecuencia.Text;
				cboSecuencia.Add(Secuencia);	
				reporte.DataDefinition.ParameterFields["Secuencia"].ApplyCurrentValues(cboSecuencia);
				//CRViewer.SelectionFormula="{ProgramaProduccion.Fecha}=Date(" + DateTime.Parse(Fecha).ToString("yyyy") + "," + DateTime.Parse(Fecha).ToString("MM") + "," + DateTime.Parse(Fecha).ToString("dd") + ") and {ProgramaProduccion.IdLinea}=" + IdLinea;
				//SelFormula = SelFormula + " AND {OrdenesTrabajo.IdStatus}=5";
				reporte.DataDefinition.RecordSelectionFormula=SelFormula;			
			
				rptHelper.setPermission(reporte);
				string reportName = rptHelper.exportReport(reporte,"RastreabilidadRpt",User.Identity.Name);
				string redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
				Response.Redirect(redirectPath);
			}
			catch(Exception errHand)
			{
				string ScriptString = "<script language = 'javascript'> alert('" + errHand.Message  + "'); </script>"; 
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
		   Response.Redirect("../NewMenu.aspx");
		}
	}
}
