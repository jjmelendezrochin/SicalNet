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
using Microsoft.ApplicationBlocks.Data;

namespace UserInterface.Forms.Reports
{
	/// <summary>
	/// Summary description for Report.
	/// </summary>
	public class Report : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblLinea;
		protected System.Web.UI.WebControls.Button cmdprint;
		protected System.Web.UI.WebControls.ImageButton imgLFinal;
		protected System.Web.UI.WebControls.TextBox txtLibFinal;
		protected System.Web.UI.WebControls.ImageButton imgLInicial;
		protected System.Web.UI.WebControls.TextBox txtLibInicial;
		protected System.Web.UI.WebControls.ImageButton imgFFinal;
		protected System.Web.UI.WebControls.TextBox txtFechaFinal;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.TextBox txtFechaInicial;
		protected System.Web.UI.WebControls.ImageButton imgFInicial;
		protected System.Web.UI.WebControls.Label lblLibFinal;
		protected System.Web.UI.WebControls.Label lblLibInicial;
		protected System.Web.UI.WebControls.Label lblFechaFinal;
		protected System.Web.UI.WebControls.Label lblFechaInicial;
		protected System.Web.UI.WebControls.DropDownList cboSecFinal;
		protected System.Web.UI.WebControls.Label lblSecFinal;
		protected System.Web.UI.WebControls.DropDownList cboSecInicial;
		protected System.Web.UI.WebControls.Label lblErrMsg;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblSecInicial;
		protected System.Web.UI.WebControls.TextBox txtSecInicial;
		protected System.Web.UI.WebControls.TextBox txtSecFinal;
		protected System.Web.UI.WebControls.RegularExpressionValidator revInitial;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.ValidationSummary vs;
		protected System.Web.UI.WebControls.Button cmdExportaPvc;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button cmdEtiquetaPvc;
		protected System.Web.UI.WebControls.Button cmdReporteCorte;
		protected System.Web.UI.WebControls.Button cmdReporteInspeccion;

		const string const_All = "Todas";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				lblTitle.Text = lblTitle.Text + " " + Request.QueryString["Title"];
				BindEntryFields();
				if(Request.QueryString["Title"] == "Reacción" || Request.QueryString["Title"] == "Materiales PVC")
				{
					this.lblSecInicial.Visible=false;
					this.lblSecFinal.Visible=false;
					this.lblLibFinal.Visible=false;
					this.lblLibInicial.Visible=false;
					this.txtLibInicial.Visible=false;
					this.txtLibFinal.Visible=false;
					this.txtSecInicial.Visible=false; 
					this.txtSecFinal.Visible=false; 
					this.imgLFinal.Visible = false; 
					this.imgLInicial.Visible = false;
				}
				if(Request.QueryString["Title"] == "Materiales PVC")
				{
					lblTitle.Text = "Reporte de Consumo PVC";
					this.lblLinea.Visible=true;
					this.cboLinea.Visible=true;
					this.cmdExportaPvc.Visible=true;
					this.txtFechaInicial.Enabled=true;
					this.txtFechaFinal.Enabled=true;
					this.txtFechaInicial.Visible=true;
					this.txtFechaFinal.Visible=true;

					this.cmdReporteInspeccion.Visible= true;
					this.cmdReporteCorte.Visible= true;
					this.cmdEtiquetaPvc.Visible=true;
				}
				else
				{
					this.lblLinea.Visible=true;
					this.cboLinea.Visible=true;
					this.cmdExportaPvc.Visible=false;
					this.cmdReporteInspeccion.Visible= false;
					this.cmdReporteCorte.Visible= false;
					this.cmdEtiquetaPvc.Visible=false;
				}
			}
		}

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
			cboLinea.Items.Add(const_All);
			cboLinea.Items.FindByText(const_All).Selected=true;

			//To Load Secuencia
			SICALNet.BusinessLogicLayer.OrdenesTrabajo WO = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
			IList SecunciaList = (IList) WO.LoadSecuencia();

			cboSecInicial.DataSource = SecunciaList;
			cboSecInicial.DataBind();
			cboSecInicial.Items[0].Selected = true;

			SICALNet.BusinessLogicLayer.Planta OPlanta = new SICALNet.BusinessLogicLayer.Planta();
			IList PlantaList = (IList) OPlanta.SelectPlanta();



			cboSecFinal.DataSource = PlantaList;
			cboSecFinal.DataValueField ="IdPlanta";
			cboSecFinal.DataTextField="Description";
			cboSecFinal.DataBind();
			//			cboSecFinal.Items[cboSecFinal.Items.Count-1].Selected=true;

		}
		#region Web Form Designer generated code

		
#pragma warning disable CS0809 // El miembro obsoleto invalida un miembro no obsoleto
        override protected void OnInit(EventArgs e)
#pragma warning restore CS0809 // El miembro obsoleto invalida un miembro no obsoleto
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
		/// 
		
		private void InitializeComponent()
		{    
			this.cmdExportaPvc.Click += new System.EventHandler(this.cmdExportaPvc_Click);
			this.imgFInicial.Click += new System.Web.UI.ImageClickEventHandler(this.imgFInicial_Click);
			this.cmdprint.Click += new System.EventHandler(this.cmdprint_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.cmdEtiquetaPvc.Click += new System.EventHandler(this.cmdEtiquetaPvc_Click);
			this.cmdReporteCorte.Click += new System.EventHandler(this.cmdReporteCorte_Click);
			this.cmdReporteInspeccion.Click += new System.EventHandler(this.cmdReporteInspeccion_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		/*** agregado por alejandro.hernandez@nasoft.com 03/03/2006 ***/
		private void ImprimeReaccion()
		{
			ParameterValues campoPlanta= new ParameterValues();
			ParameterValues campoFecha= new ParameterValues();
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			ParameterDiscreteValue valorPlanta = new ParameterDiscreteValue();
			ParameterValues campoUser= new ParameterValues();
			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
			ParameterValues campoLinea= new ParameterValues();
			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
			/*** comentado por alejandro.hernandez@nasoft.com 07/03/2006 ***/
			//			ParameterValues campoSecuencia= new ParameterValues();
			//			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
			ParameterValues campoSystem= new ParameterValues();
			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();

			string reportName = "";
			string redirectPath = "";
			string SelFormula="";
			
			rptHelper = new Reports.ReportHelper();
			Reports.ConsultReacion reporte = new Reports.ConsultReacion();

			campoFecha= new ParameterValues();
			valorFecha= new ParameterDiscreteValue();

			if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
				valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
			else
				valorFecha.Value="";

			campoFecha.Add(valorFecha);

			campoLinea= new ParameterValues();
			valorLinea= new ParameterDiscreteValue();

			if (cboLinea.SelectedItem.Text != const_All)
				valorLinea.Value=string.Format("Reporte Fase de Reacción Linea: {0}",cboLinea.SelectedItem.Text);
			else
				valorLinea.Value="Reporte Fase de Reacción ";

			campoLinea.Add(valorLinea);
				

			campoPlanta= new ParameterValues(); 
			valorPlanta= new ParameterDiscreteValue();
			if (cboLinea.SelectedItem.Text == const_All) 
			{
				valorPlanta.Value=const_All;
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =3015;  
			}
			else
			{
				valorPlanta.Value="";
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
			}  
			campoPlanta.Add(valorPlanta);

			campoUser= new ParameterValues();
			valorUser= new ParameterDiscreteValue();
			valorUser.Value=Context.User.Identity.Name;
			campoUser.Add(valorUser);

				
			campoSystem= new ParameterValues();
			valorSystem= new ParameterDiscreteValue();
			valorSystem.Value="SICAL";
			campoSystem.Add(valorSystem);
					
			reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
			reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
			reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
			reporte.DataDefinition.ParameterFields["UserName"].ApplyCurrentValues(campoUser);
			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);

			if (cboLinea.SelectedItem.Text != const_All)
				SelFormula = "{OTReaccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);
			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OTReaccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {OTReaccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";

			
			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			
			rptHelper.setPermission(reporte);
			reportName = rptHelper.exportReport(reporte,"PartidasReaccionReport",User.Identity.Name  );
			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
			Response.Redirect(redirectPath);
		}

		/*** agregado por alejandro.hernandez@nasoft.com 03/03/2006 ***/
		private void ImprimeMezclas()
		{
			ParameterValues campoPlanta= new ParameterValues();
			ParameterValues campoFecha= new ParameterValues();
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			ParameterDiscreteValue valorPlanta = new ParameterDiscreteValue();
			ParameterValues campoUser= new ParameterValues();
			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
			ParameterValues campoLinea= new ParameterValues();
			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
			ParameterValues campoSecuencia= new ParameterValues();
			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
			ParameterValues campoSystem= new ParameterValues();
			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();

			string reportName = "";
			string redirectPath = "";
			string SelFormula="";

			rptHelper = new Reports.ReportHelper();
			Reports.ConsultMezclas reporte = new Reports.ConsultMezclas();
					
			campoFecha= new ParameterValues();
			valorFecha= new ParameterDiscreteValue();

			if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
				valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
			else
				valorFecha.Value="";

			campoFecha.Add(valorFecha);
				
			campoSecuencia= new ParameterValues();
			valorSecuencia= new ParameterDiscreteValue();

			if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
				valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
			else
				valorSecuencia.Value="";

			campoSecuencia.Add(valorSecuencia);

			campoLinea= new ParameterValues();
			valorLinea= new ParameterDiscreteValue();

			if (cboLinea.SelectedItem.Text != const_All)
				valorLinea.Value= string.Format("Reporte Fase de Mezclas Linea: {0}",cboLinea.SelectedItem.Text);
			else
				valorLinea.Value=" Reporte Fase de Mezclas ";

			campoLinea.Add(valorLinea);				

			campoPlanta= new ParameterValues(); 
			valorPlanta= new ParameterDiscreteValue();
			//valorPlanta.Value=string.Format("Planta: {0}",ConfigurationManager.AppSettings["LocalPlantText"]);
			if (cboLinea.SelectedItem.Text == const_All) 
			{
				//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
				valorPlanta.Value=const_All;
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =1535;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
			}
			else
			{
				valorPlanta.Value="";
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
			}
			campoPlanta.Add(valorPlanta);

			campoUser= new ParameterValues();
			valorUser= new ParameterDiscreteValue();
			valorUser.Value=Context.User.Identity.Name;
			campoUser.Add(valorUser);

				
			campoSystem= new ParameterValues();
			valorSystem= new ParameterDiscreteValue();
			valorSystem.Value="SICAL";
			campoSystem.Add(valorSystem);
					
			reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
			reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
			reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
			reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
			reporte.DataDefinition.ParameterFields["User"].ApplyCurrentValues(campoUser);
			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);

			//string SelFormula="";
			if (cboLinea.SelectedItem.Text != const_All)
				SelFormula = "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);

			//string txtFechaInicial.Text = txtFechaInicial.Text;
			//string txtFechaFinal.Text = txtFechaFinal.Text;

			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";

			//string txtSecInicial.Text= txtSecInicial.Text;
			//string txtSecFinal.Text= txtSecFinal.Text;

			if (txtSecInicial.Text!= String.Empty)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text;
			if ( txtSecFinal.Text!= String.Empty)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
	
			//txtLibInicial.Text = txtLibInicial.Text;
			//txtLibFinal.Text = txtLibFinal.Text;
			// txtLibInicial.Text != null && txtLibFinal.Text != null && 
			if (txtLibInicial.Text != String.Empty && txtLibFinal.Text != String.Empty)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";

			SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + "  {OrdenesTrabajo.IdArea}=4 AND {OrdenesTrabajo.IdStatus}=5"; 


			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			
			rptHelper.setPermission(reporte);
			reportName = rptHelper.exportReport(reporte,"PartidasMezclasReport",User.Identity.Name);

			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName +  ".pdf";
			Response.Redirect(redirectPath);


			//Response.Redirect("ConsultMezclasReport.aspx?Title=" + Title + "&IdLinea=" + cboLinea.SelectedItem.Value + "&Linea=" + cboLinea.SelectedItem.Text + "&SecInicial=" + cboSecInicial.SelectedItem.Text + "&SecFinal=" + cboSecFinal.SelectedItem.Text + "&txtFechaInicial.Text=" + txtFechaInicial.Text + "&txtFechaFinal.Text=" + txtFechaFinal.Text + "&txtLibInicial.Text=" + txtLibInicial.Text + "&txtLibFinal.Text=" + txtLibFinal.Text);

		}

		/*** agregado por alejandro.hernandez@nasoft.com 03/03/2006 ***/
		private void ImprimeColor()
		{
			ParameterValues campoPlanta= new ParameterValues();
			ParameterValues campoFecha= new ParameterValues();
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			ParameterDiscreteValue valorPlanta = new ParameterDiscreteValue();
			ParameterValues campoUser= new ParameterValues();
			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
			ParameterValues campoLinea= new ParameterValues();
			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
			ParameterValues campoSecuencia= new ParameterValues();
			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
			/*** comentado por alejandro.hernandez@nasoft.com 07/03/2006 ***/
			//			ParameterValues campoSystem= new ParameterValues();
			//			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();

			string reportName = "";
			string redirectPath = "";
			string SelFormula="";

			/*** comentado por alejandro.hernandez@nasoft.com 07/03/2006 ***/
			//			string Title = "Reporte Fase de Color";
			rptHelper = new Reports.ReportHelper();
			Reports.PartidasColorReports reporte = new Reports.PartidasColorReports();

			campoFecha= new ParameterValues();
			valorFecha= new ParameterDiscreteValue();
			if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)
				valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
			else
				valorFecha.Value=string.Empty;
			campoFecha.Add(valorFecha);
				
			campoSecuencia= new ParameterValues();
			valorSecuencia= new ParameterDiscreteValue();

			if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
				valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
			else
				valorSecuencia.Value="";

			campoSecuencia.Add(valorSecuencia);

			campoLinea= new ParameterValues();
			valorLinea= new ParameterDiscreteValue();
			valorLinea.Value=string.Format("Linea: {0}",cboLinea.SelectedItem.Text);
			campoLinea.Add(valorLinea);

			campoPlanta= new ParameterValues();
			valorPlanta= new ParameterDiscreteValue();
			if (cboLinea.SelectedItem.Text == const_All) 
			{
				valorPlanta.Value=const_All;
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =3015;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
			}
			else
			{
				valorPlanta.Value="";
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
			}
			campoPlanta.Add(valorPlanta);

			campoUser= new ParameterValues();
			valorUser= new ParameterDiscreteValue();
			valorUser.Value=Context.User.Identity.Name;
			campoUser.Add(valorUser);

			reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
			reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
			reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
			reporte.DataDefinition.ParameterFields["UserName"].ApplyCurrentValues(campoUser);
			reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);

			if (cboLinea.SelectedItem.Text != const_All)
				SelFormula = "{ProgramaProduccion.IdLinea}=" + cboLinea.SelectedItem.Value;
			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
			if (txtSecInicial.Text!= null && txtSecFinal.Text!= null && txtSecInicial.Text!= "" && txtSecFinal.Text!= "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text+ " AND " + "Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
			if (txtLibInicial.Text != null && txtLibFinal.Text != null && txtLibInicial.Text != "" && txtLibFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
	
			SelFormula = SelFormula + " AND {OrdenesTrabajo.IdArea}=1 AND {OrdenesTrabajo.IdStatus}=5";
			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			rptHelper.setPermission(reporte);
			reportName = rptHelper.exportReport(reporte,"PartidasColorReport",User.Identity.Name);

			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName +  ".pdf";
			Response.Redirect(redirectPath);
		}

		/*** agregado por alejandro.hernandez@nasoft.com 03/03/2006 ***/
		private void ImprimeAditivos()
		{
			ParameterValues campoPlanta= new ParameterValues();
			ParameterValues campoFecha= new ParameterValues();
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			ParameterDiscreteValue valorPlanta = new ParameterDiscreteValue();
			ParameterValues campoUser= new ParameterValues();
			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
			ParameterValues campoLinea= new ParameterValues();
			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
			ParameterValues campoSecuencia= new ParameterValues();
			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
			//ParameterValues campoSystem= new ParameterValues();
			//ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();

			string reportName = "";
			string redirectPath = "";
			string SelFormula="";

			//			string Title = "";
			//
			//			Title = "Reporte Fase de Aditivos";
			rptHelper = new Reports.ReportHelper();
			Reports.AdditivesPhaseReports reporte = new Reports.AdditivesPhaseReports();

			campoFecha= new ParameterValues();
			valorFecha= new ParameterDiscreteValue();
			if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
				valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
			else
				valorFecha.Value="";					
			campoFecha.Add(valorFecha);
				
			campoLinea= new ParameterValues();
			valorLinea= new ParameterDiscreteValue();
			valorLinea.Value=string.Format("Linea: {0}",cboLinea.SelectedItem.Text);
			campoLinea.Add(valorLinea);

			campoPlanta= new ParameterValues();
			valorPlanta= new ParameterDiscreteValue();
			if (cboLinea.SelectedItem.Text == const_All) 
			{
				valorPlanta.Value=const_All;
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =1535;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
			}
			else
			{
				valorPlanta.Value="";
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
			}
			campoPlanta.Add(valorPlanta);

			campoSecuencia= new ParameterValues();
			valorSecuencia= new ParameterDiscreteValue();
			if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
				valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
			else
				valorSecuencia.Value="";
			
			campoSecuencia.Add(valorSecuencia);
			campoUser= new ParameterValues();
			valorUser= new ParameterDiscreteValue();
			valorUser.Value=Context.User.Identity.Name;
			campoUser.Add(valorUser);

			reporte.DataDefinition.ParameterFields["Programa"].ApplyCurrentValues(campoFecha);
			reporte.DataDefinition.ParameterFields["Linea"].ApplyCurrentValues(campoLinea);
			reporte.DataDefinition.ParameterFields["Planta"].ApplyCurrentValues(campoPlanta);
			reporte.DataDefinition.ParameterFields["Secuencia"].ApplyCurrentValues(campoSecuencia);
			reporte.DataDefinition.ParameterFields["UserName"].ApplyCurrentValues(campoUser);
			
			if (cboLinea.SelectedItem.Text != const_All)
				SelFormula = "{ProgramaProduccion.IdLinea}=" + cboLinea.SelectedItem.Value;
			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
			if (txtSecInicial.Text!= null && txtSecFinal.Text!= null && txtSecInicial.Text!= "" && txtSecFinal.Text!= "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text+ " AND " + "Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
			if (txtLibInicial.Text != null && txtLibFinal.Text != null && txtLibInicial.Text != "" && txtLibFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";

			SelFormula = SelFormula + " AND {OrdenesTrabajo.IdArea}=2 AND {OrdenesTrabajo.IdStatus}=5";

			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			rptHelper.setPermission(reporte);
			reportName = rptHelper.exportReport(reporte,"PartidasAditivosReport",User.Identity.Name);
			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName +  ".pdf";
			Response.Redirect(redirectPath);

		}

		/*** agregado por alejandro.hernandez@nasoft.com 03/03/2006 ***/
		private void ImprimeConsumoMezclas()
		{
			ParameterValues campoPlanta= new ParameterValues();
			ParameterValues campoFecha= new ParameterValues();
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			ParameterDiscreteValue valorPlanta = new ParameterDiscreteValue();
			ParameterValues campoUser= new ParameterValues();
			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
			ParameterValues campoLinea= new ParameterValues();
			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
			ParameterValues campoSecuencia= new ParameterValues();
			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
			ParameterValues campoSystem= new ParameterValues();
			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();

			string reportName = "";
			string redirectPath = "";
			string SelFormula="";
			
			rptHelper = new Reports.ReportHelper();
			Reports.ConsumptionMezclas reporte = new Reports.ConsumptionMezclas();

			campoFecha= new ParameterValues();
			valorFecha= new ParameterDiscreteValue();

			if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
				valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
			else
				valorFecha.Value="";

			campoFecha.Add(valorFecha);
				
			campoSecuencia= new ParameterValues();
			valorSecuencia= new ParameterDiscreteValue();

			if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
				valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
			else
				valorSecuencia.Value="";

			campoSecuencia.Add(valorSecuencia);

			campoLinea= new ParameterValues();
			valorLinea= new ParameterDiscreteValue();

			if (cboLinea.SelectedItem.Text != const_All)
				valorLinea.Value=string.Format("Reporte Fase de Consumption Mezclas Linea: {0}",cboLinea.SelectedItem.Text);
			else
				valorLinea.Value="Reporte Fase de Consumption Mezclas ";

			campoLinea.Add(valorLinea);
				

			campoPlanta= new ParameterValues(); 
			valorPlanta= new ParameterDiscreteValue();
			//valorPlanta.Value=string.Format("Planta: {0}",ConfigurationManager.AppSettings["LocalPlantText"]);
			if (cboLinea.SelectedItem.Text == const_All) 
			{
				//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
				valorPlanta.Value=const_All;
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =3015;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
			}
			else
			{
				valorPlanta.Value="";
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
			}
			campoPlanta.Add(valorPlanta);

			campoUser= new ParameterValues();
			valorUser= new ParameterDiscreteValue();
			valorUser.Value=Context.User.Identity.Name;
			campoUser.Add(valorUser);

				
			campoSystem= new ParameterValues();
			valorSystem= new ParameterDiscreteValue();
			valorSystem.Value="SICAL";
			campoSystem.Add(valorSystem);
					
			reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
			reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
			reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
			reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
			reporte.DataDefinition.ParameterFields["User"].ApplyCurrentValues(campoUser);
			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);

			//string SelFormula="";
			if (cboLinea.SelectedItem.Text != const_All)
				SelFormula = "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);
			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
			if (txtSecInicial.Text!= String.Empty)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text;
			if ( txtSecFinal.Text!= String.Empty)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
			if (txtLibInicial.Text != String.Empty && txtLibFinal.Text != String.Empty)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";

			SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + "  {OrdenesTrabajo.IdArea}=4 AND {OrdenesTrabajo.IdStatus}=5"; 

			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			
			rptHelper.setPermission(reporte);
			reportName = rptHelper.exportReport(reporte,"ConsumptionMezclasReport",User.Identity.Name);

			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
			Response.Redirect(redirectPath);
		}

		/*** agregado por alejandro.hernandez@nasoft.com 03/03/2006 ***/
		private void ImprimeConsumoAditivos()
		{
			ParameterValues campoPlanta= new ParameterValues();
			ParameterValues campoFecha= new ParameterValues();
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			ParameterDiscreteValue valorPlanta = new ParameterDiscreteValue();
			ParameterValues campoUser= new ParameterValues();
			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
			ParameterValues campoLinea= new ParameterValues();
			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
			ParameterValues campoSecuencia= new ParameterValues();
			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
			ParameterValues campoSystem= new ParameterValues();
			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();

			string reportName = "";
			string redirectPath = "";
			string SelFormula="";

			//			string Title="";
			//			
			//			Title = "Reporte de Consumo de Aditivos";
			rptHelper = new Reports.ReportHelper();
			Reports.ConsumptionAditivos reporte = new Reports.ConsumptionAditivos();

			campoFecha= new ParameterValues();
			valorFecha= new ParameterDiscreteValue();
			if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
				valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
			else
				valorFecha.Value="";					
			campoFecha.Add(valorFecha);

			campoSecuencia= new ParameterValues();
			valorSecuencia= new ParameterDiscreteValue();
			if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
				valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
			else
				valorSecuencia.Value="";					
			campoSecuencia.Add(valorSecuencia);
				
			campoLinea= new ParameterValues();
			valorLinea= new ParameterDiscreteValue();
			valorLinea.Value=string.Format("Linea: {0}",cboLinea.SelectedItem.Text);
			campoLinea.Add(valorLinea);

			campoPlanta= new ParameterValues();
			valorPlanta= new ParameterDiscreteValue();
			if (cboLinea.SelectedItem.Text == const_All) 
			{
				//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
				valorPlanta.Value=const_All;
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =1535;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
			}
			else
			{
				valorPlanta.Value="";
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
			}					
			campoPlanta.Add(valorPlanta);

			campoUser= new ParameterValues();
			valorUser= new ParameterDiscreteValue();
			valorUser.Value=Context.User.Identity.Name;
			campoUser.Add(valorUser);

				
			campoSystem= new ParameterValues();
			valorSystem= new ParameterDiscreteValue();
			valorSystem.Value="SICAL";
			campoSystem.Add(valorSystem);

			reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
			reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
			reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
			reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
			reporte.DataDefinition.ParameterFields["User"].ApplyCurrentValues(campoUser);
			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);

			//string SelFormula="";
			if (cboLinea.SelectedItem.Text != const_All)
				SelFormula = "{ProgramaProduccion.IdLinea}=" + cboLinea.SelectedItem.Value;
			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
			if (txtSecInicial.Text!= null && txtSecFinal.Text!= null && txtSecInicial.Text!= "" && txtSecFinal.Text!= "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({ProgramaProduccion.Secuencia}) >= " + txtSecInicial.Text+ " AND " + "Val({ProgramaProduccion.Secuencia}) <= " + txtSecFinal.Text;
			if (txtLibInicial.Text != null && txtLibFinal.Text != null && txtLibInicial.Text != "" && txtLibFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
 
			SelFormula = SelFormula + " AND {OrdenesTrabajo.IdArea}=2 AND {OrdenesTrabajo.IdStatus}=5";


			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			
			rptHelper.setPermission(reporte);
			reportName = rptHelper.exportReport(reporte,"ConsumptionAditivosReport",User.Identity.Name);

			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
			Response.Redirect(redirectPath);
		}

		/*** agregado por alejandro.hernandez@nasoft.com 03/03/2006 ***/
		private void ImprimeConsumoColor()
		{
			ParameterValues campoPlanta= new ParameterValues();
			ParameterValues campoFecha= new ParameterValues();
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			ParameterDiscreteValue valorPlanta = new ParameterDiscreteValue();
			ParameterValues campoUser= new ParameterValues();
			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
			ParameterValues campoLinea= new ParameterValues();
			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
			ParameterValues campoSecuencia= new ParameterValues();
			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
			ParameterValues campoSystem= new ParameterValues();
			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();

			string reportName = "";
			string redirectPath = "";
			string SelFormula="";

			/*** comentado por alejandro.hernandez@nasoft.com 07/03/2006 ***/
			//			string Title="";
			//
			//			Title = "Reporte Fase de Consumo de Color";
			rptHelper = new Reports.ReportHelper();
			Reports.ColorConsumptionRpt reporte = new Reports.ColorConsumptionRpt();

			campoFecha= new ParameterValues();
			valorFecha= new ParameterDiscreteValue();
			if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
				valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
			else
				valorFecha.Value=string.Empty;
			campoFecha.Add(valorFecha);
				
			/*
					ParameterValues campoLibFecha= new ParameterValues();
					ParameterDiscreteValue valorLibFecha= new ParameterDiscreteValue();
					valorLibFecha.Value=string.Format("Liberar Fecha Del {0} al {1}",txtLibInicial.Text,txtLibFinal.Text);
					campoLibFecha.Add(valorLibFecha);
					*/

			campoSecuencia= new ParameterValues();
			valorSecuencia= new ParameterDiscreteValue();

			if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty) 
				valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
			else
				valorSecuencia.Value=string.Empty;
			campoSecuencia.Add(valorSecuencia);
				
			campoLinea= new ParameterValues();
			valorLinea= new ParameterDiscreteValue();
			valorLinea.Value=string.Format("Linea: {0}",cboLinea.SelectedItem.Text);
			campoLinea.Add(valorLinea);

			campoPlanta= new ParameterValues();
			valorPlanta= new ParameterDiscreteValue();
			//valorPlanta.Value=string.Format("Planta: {0}",ConfigurationManager.AppSettings["LocalPlantText"]);
			if (cboLinea.SelectedItem.Text == const_All) 
			{
				//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
				valorPlanta.Value=const_All;
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =3015;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
			}
			else
			{
				valorPlanta.Value="";
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
			}
			campoPlanta.Add(valorPlanta);

			campoUser= new ParameterValues();
			valorUser= new ParameterDiscreteValue();
			valorUser.Value=Context.User.Identity.Name;
			campoUser.Add(valorUser);

				
			campoSystem= new ParameterValues();
			valorSystem= new ParameterDiscreteValue();
			valorSystem.Value="SICAL";
			campoSystem.Add(valorSystem);

			reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
			reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
			reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
			//reporte.DataDefinition.ParameterFields["Title3"].ApplyCurrentValues(campoLibFecha);
			reporte.DataDefinition.ParameterFields["Planta"].ApplyCurrentValues(campoPlanta);
			reporte.DataDefinition.ParameterFields["UserName"].ApplyCurrentValues(campoUser);
			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);

			if (cboLinea.SelectedItem.Text != const_All)
				SelFormula = "{ProgramaProduccion.IdLinea}=" + cboLinea.SelectedItem.Value;
			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
			if (txtSecInicial.Text!= null && txtSecFinal.Text!= null && txtSecInicial.Text!= "" && txtSecFinal.Text!= "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({ProgramaProduccion.Secuencia}) >= " + txtSecInicial.Text+ " AND " + "Val({ProgramaProduccion.Secuencia}) <= " + txtSecFinal.Text;
			if (txtLibInicial.Text != null && txtLibFinal.Text != null && txtLibInicial.Text != "" && txtLibFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
			SelFormula = SelFormula + " AND {OrdenesTrabajo.IdArea}=1 AND {OrdenesTrabajo.IdStatus}=5";


			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			
			rptHelper.setPermission(reporte);
			reportName = rptHelper.exportReport(reporte,"ConsumptionColorReport",User.Identity.Name);

			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
			Response.Redirect(redirectPath);

			//Response.Redirect("FrmColorConsumption.aspx?Title=" + Title + "&IdLinea=" + cboLinea.SelectedItem.Value + "&Linea=" + cboLinea.SelectedItem.Text + "&SecInicial=" + cboSecInicial.SelectedItem.Text + "&SecFinal=" + cboSecFinal.SelectedItem.Text + "&txtFechaInicial.Text=" + txtFechaInicial.Text + "&txtFechaFinal.Text=" + txtFechaFinal.Text + "&txtLibInicial.Text=" + txtLibInicial.Text + "&txtLibFinal.Text=" + txtLibFinal.Text);
		}

		/*** agregado por alejandro.hernandez@nasoft.com 03/03/2006 ***/
		private void ImprimeLlenado()
		{
			ParameterValues campoPlanta= new ParameterValues();
			ParameterValues campoFecha= new ParameterValues();
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			ParameterDiscreteValue valorPlanta = new ParameterDiscreteValue();
			ParameterValues campoUser= new ParameterValues();
			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
			ParameterValues campoLinea= new ParameterValues();
			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
			ParameterValues campoSecuencia= new ParameterValues();
			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
			ParameterValues campoSystem= new ParameterValues();
			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();

			string reportName = "";
			string redirectPath = "";
			string SelFormula="";

			string Title="";

			Title = "Reporte Fase de Llenado ";

			rptHelper = new Reports.ReportHelper();
			Reports.FillingPhase reporte = new Reports.FillingPhase();

			campoFecha= new ParameterValues();
			valorFecha= new ParameterDiscreteValue();

			if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
				valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
			else
				valorFecha.Value="";

			campoFecha.Add(valorFecha);
				
			campoSecuencia= new ParameterValues();
			valorSecuencia= new ParameterDiscreteValue();

			if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
				valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
			else
				valorSecuencia.Value="";

			campoSecuencia.Add(valorSecuencia);

			campoLinea= new ParameterValues();
			valorLinea= new ParameterDiscreteValue();

			if (cboLinea.SelectedItem.Text != const_All)
				valorLinea.Value=Title + string.Format("Linea: {0}",cboLinea.SelectedItem.Text);
			else
				valorLinea.Value=Title;

			campoLinea.Add(valorLinea);
				

			campoPlanta= new ParameterValues(); 
			valorPlanta= new ParameterDiscreteValue();
			if (cboLinea.SelectedItem.Text == const_All) 
			{
				//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
				valorPlanta.Value=const_All;
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =3015;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
			}
			else
			{
				valorPlanta.Value="";
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
			}
			campoPlanta.Add(valorPlanta);

			campoUser= new ParameterValues();
			valorUser= new ParameterDiscreteValue();
			valorUser.Value=Context.User.Identity.Name;
			campoUser.Add(valorUser);

				
			campoSystem= new ParameterValues();
			valorSystem= new ParameterDiscreteValue();
			valorSystem.Value="SICAL";
			campoSystem.Add(valorSystem);
					
			reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
			reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
			reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
			reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
			reporte.DataDefinition.ParameterFields["UserName"].ApplyCurrentValues(campoUser);
			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);

			//string SelFormula="";
			if (cboLinea.SelectedItem.Text != const_All)
				SelFormula = "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);

			//string txtFechaInicial.Text = txtFechaInicial.Text;
			//string txtFechaFinal.Text = txtFechaFinal.Text;

			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";

			//string txtSecInicial.Text= txtSecInicial.Text;
			//string txtSecFinal.Text= txtSecFinal.Text;

			if (txtSecInicial.Text!= String.Empty)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text;
			if ( txtSecFinal.Text!= String.Empty)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
	
			//txtLibInicial.Text = txtLibInicial.Text;
			//txtLibFinal.Text = txtLibFinal.Text;
			// txtLibInicial.Text != null && txtLibFinal.Text != null && 
			if (txtLibInicial.Text != String.Empty && txtLibFinal.Text != String.Empty)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";

			SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + "  {OrdenesTrabajo.IdArea}=7 AND {OrdenesTrabajo.IdStatus}=5 AND Time({OrdenesTrabajo.FechaLiberacion}) >= Time({Turno.Horainicial}) AND Time({OrdenesTrabajo.FechaLiberacion}) <= Time({Turno.HoraFinal})"; 
			
			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			
			rptHelper.setPermission(reporte);
			reportName = rptHelper.exportReport(reporte,"ConsultFillReport",User.Identity.Name);
			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
			Response.Redirect(redirectPath);

		}

		/*** agregado por alejandro.hernandez@nasoft.com 03/03/2006 ***/
		private void ImprimeSeparacion()
		{
			ParameterValues campoPlanta= new ParameterValues();
			ParameterValues campoFecha= new ParameterValues();
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			ParameterDiscreteValue valorPlanta = new ParameterDiscreteValue();
			ParameterValues campoUser= new ParameterValues();
			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
			ParameterValues campoLinea= new ParameterValues();
			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
			ParameterValues campoSecuencia= new ParameterValues();
			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
			ParameterValues campoSystem= new ParameterValues();
			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();

			string reportName = "";
			string redirectPath = "";
			string SelFormula="";

			string Title="";

			Title = "Reporte Fase de Separación";

			rptHelper = new Reports.ReportHelper();
			Reports.ConsultSeparation reporte = new Reports.ConsultSeparation();

			campoFecha= new ParameterValues();
			valorFecha= new ParameterDiscreteValue();

			if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
				valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
			else
				valorFecha.Value="";

			campoFecha.Add(valorFecha);
				
			campoSecuencia= new ParameterValues();
			valorSecuencia= new ParameterDiscreteValue();

			if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
				valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
			else
				valorSecuencia.Value="";

			campoSecuencia.Add(valorSecuencia);

			campoLinea= new ParameterValues();
			valorLinea= new ParameterDiscreteValue();

			if (cboLinea.SelectedItem.Text != const_All)
				valorLinea.Value=Title + string.Format("Linea: {0}",cboLinea.SelectedItem.Text);
			else
				valorLinea.Value=Title;

			campoLinea.Add(valorLinea);
				

			campoPlanta= new ParameterValues(); 
			valorPlanta= new ParameterDiscreteValue();
			//valorPlanta.Value=string.Format("Planta: {0}",ConfigurationManager.AppSettings["LocalPlantText"]);
			if (cboLinea.SelectedItem.Text == const_All) 
			{
				//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
				valorPlanta.Value=const_All;
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =3015;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
			}
			else
			{
				valorPlanta.Value="";
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
			}
			campoPlanta.Add(valorPlanta);

			campoUser= new ParameterValues();
			valorUser= new ParameterDiscreteValue();
			valorUser.Value=Context.User.Identity.Name;
			campoUser.Add(valorUser);

				
			campoSystem= new ParameterValues();
			valorSystem= new ParameterDiscreteValue();
			valorSystem.Value="SICAL";
			campoSystem.Add(valorSystem);
					
			reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
			reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
			reporte.DataDefinition.ParameterFields["Title3"].ApplyCurrentValues(campoLinea);
			reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
			reporte.DataDefinition.ParameterFields["User"].ApplyCurrentValues(campoUser);
			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);
				
			//string SelFormula="";
			if (cboLinea.SelectedItem.Text != const_All)
				SelFormula = "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);

			//string txtFechaInicial.Text = txtFechaInicial.Text;
			//string txtFechaFinal.Text = txtFechaFinal.Text;

			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";

			//string txtSecInicial.Text= txtSecInicial.Text;
			//string txtSecFinal.Text= txtSecFinal.Text;

			if (txtSecInicial.Text!= String.Empty)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text;
			if ( txtSecFinal.Text!= String.Empty)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
	
			//txtLibInicial.Text = txtLibInicial.Text;
			//txtLibFinal.Text = txtLibFinal.Text;
			// txtLibInicial.Text != null && txtLibFinal.Text != null && 
			if (txtLibInicial.Text != String.Empty && txtLibFinal.Text != String.Empty)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";

			SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + "  {OrdenesTrabajo.IdArea}=11 AND {OrdenesTrabajo.IdStatus}=5"; 


			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			
			rptHelper.setPermission(reporte);
			reportName = rptHelper.exportReport(reporte,"ConsultSeparationRep",User.Identity.Name);
			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
			Response.Redirect(redirectPath);
		}

		/*** agregado por alejandro.hernandez@nasoft.com 03/03/2006 ***/
		private void ImprimeInspeccion()
		{
			ParameterValues campoPlanta= new ParameterValues();
			ParameterValues campoFecha= new ParameterValues();
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			ParameterDiscreteValue valorPlanta = new ParameterDiscreteValue();
			ParameterValues campoUser= new ParameterValues();
			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
			ParameterValues campoLinea= new ParameterValues();
			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
			ParameterValues campoSecuencia= new ParameterValues();
			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
			ParameterValues campoSystem= new ParameterValues();
			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();

			string reportName = "";
			string redirectPath = "";
			string SelFormula="";

			/*** comentado por alejandro.hernandez@nasoft.com 07/03/2006 ***/
			//			string Title="";
			//
			//			Title = "Reporte Fase de Inspección";

			rptHelper = new Reports.ReportHelper();
			Reports.InspectionPhase reporte = new Reports.InspectionPhase();

			campoFecha= new ParameterValues();
			valorFecha= new ParameterDiscreteValue();

			if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
				valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
			else
				valorFecha.Value="";

			campoFecha.Add(valorFecha);
				
			campoSecuencia= new ParameterValues();
			valorSecuencia= new ParameterDiscreteValue();

			if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
				valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
			else
				valorSecuencia.Value="";

			campoSecuencia.Add(valorSecuencia);

			campoLinea= new ParameterValues();
			valorLinea= new ParameterDiscreteValue();

			if (cboLinea.SelectedItem.Text != const_All)
				valorLinea.Value=string.Format("Reporte Fase de Inspección Linea: {0}",cboLinea.SelectedItem.Text);
			else
				valorLinea.Value="Reporte Fase de Inspección";

			campoLinea.Add(valorLinea);
				

			campoPlanta= new ParameterValues(); 
			valorPlanta= new ParameterDiscreteValue();
			//valorPlanta.Value=string.Format("Planta: {0}",ConfigurationManager.AppSettings["LocalPlantText"]);
			if (cboLinea.SelectedItem.Text == const_All) 
			{
				//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
				valorPlanta.Value=const_All;
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =3015;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
			}
			else
			{
				valorPlanta.Value="";
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
			}
			campoPlanta.Add(valorPlanta);

			campoUser= new ParameterValues();
			valorUser= new ParameterDiscreteValue();
			valorUser.Value=Context.User.Identity.Name;
			campoUser.Add(valorUser);

				
			campoSystem= new ParameterValues();
			valorSystem= new ParameterDiscreteValue();
			valorSystem.Value="SICAL";
			campoSystem.Add(valorSystem);
					
			reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
			reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
			reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
			reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
			reporte.DataDefinition.ParameterFields["User"].ApplyCurrentValues(campoUser);
			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);

					

			//string SelFormula="";
			if (cboLinea.SelectedItem.Text != const_All)
				SelFormula = "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);

			//string txtFechaInicial.Text = txtFechaInicial.Text;
			//string txtFechaFinal.Text = txtFechaFinal.Text;

			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";

			//string txtSecInicial.Text= txtSecInicial.Text;
			//string txtSecFinal.Text= txtSecFinal.Text;

			if (txtSecInicial.Text!= String.Empty)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text;
			if ( txtSecFinal.Text!= String.Empty)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
	
			//txtLibInicial.Text = txtLibInicial.Text;
			//txtLibFinal.Text = txtLibFinal.Text;
			// txtLibInicial.Text != null && txtLibFinal.Text != null && 
			if (txtLibInicial.Text != String.Empty && txtLibFinal.Text != String.Empty)
				// Naosft Roberto Carlos Guzman Vargas
				//modificacion reporte que abar que 3 turnos.

			{
				//SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
				//SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + "  {OrdenesTrabajo.IdArea}=12 AND {OrdenesTrabajo.IdStatus}=5 AND Time({OrdenesTrabajo.FechaLiberacion}) >= Time({Turno.Horainicial}) AND Time({OrdenesTrabajo.FechaLiberacion}) <= Time({Turno.HoraFinal})";  
				// obtenemos los turnos

											
				string d = txtLibFinal.Text; 
				DateTime dt = System.DateTime.Parse(d); 
				long startTicks= dt.Ticks; 							
				long tick = startTicks + 864000000000;
				DateTime df = new DateTime(tick);
						
				SelFormula = SelFormula +  (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion} > " + "CDateTime(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM")+ "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ",07,00,00)";
				SelFormula = SelFormula + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion} <= " + "CDateTime(" + df.Year + "," + df.Month  + "," + df.Day + ",07,00,00)";
			}
			// fin modificacion
			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			
			rptHelper.setPermission(reporte);
			reportName = rptHelper.exportReport(reporte,"ConsultInspectionPhase",User.Identity.Name  );
			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName +  ".pdf";
			Response.Redirect(redirectPath);

		}

		/*** agregado por JJMR 24/07/2014 ***/
		private void ImprimeMateialesPVC()
		{
			ParameterValues campoPlanta= new ParameterValues();
			ParameterValues campoFecha= new ParameterValues();
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			ParameterDiscreteValue valorPlanta = new ParameterDiscreteValue();
			ParameterValues campoUser= new ParameterValues();
			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
			ParameterValues campoLinea= new ParameterValues();
			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
			ParameterValues campoSecuencia= new ParameterValues();
			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
			ParameterValues campoSystem= new ParameterValues();
			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();

			string reportName = "";
			string redirectPath = "";
			string SelFormula="";

			rptHelper = new Reports.ReportHelper();
			Reports.MaterialesPvc reporte = new Reports.MaterialesPvc();

			campoFecha= new ParameterValues();
			valorFecha= new ParameterDiscreteValue();

			if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
				valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
			else
				valorFecha.Value="";

			campoFecha.Add(valorFecha);
				
			campoSecuencia= new ParameterValues();
			valorSecuencia= new ParameterDiscreteValue();

			if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
				valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
			else
				valorSecuencia.Value="";

			campoSecuencia.Add(valorSecuencia);

			campoLinea= new ParameterValues();
			valorLinea= new ParameterDiscreteValue();

			valorLinea.Value="Reporte de Consumo de PVC";

			campoLinea.Add(valorLinea);
				
			campoUser= new ParameterValues();
			valorUser= new ParameterDiscreteValue();
			valorUser.Value=Context.User.Identity.Name;
			campoUser.Add(valorUser);

			String linea = 	cboLinea.SelectedValue;
				
			campoSystem= new ParameterValues();
			valorSystem= new ParameterDiscreteValue();
			valorSystem.Value="SICAL";
			campoSystem.Add(valorSystem);
					
			reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
			reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
			reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
			//			reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
			reporte.DataDefinition.ParameterFields["User"].ApplyCurrentValues(campoUser);
			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);

			// Selección de Planta
			SelFormula = "{Vw_MaterialesPVC_ProgramaProduccion.IdPlanta}=" + Convert.ToInt32(ConfigurationManager.AppSettings["LocalPlant"]);

			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {Vw_MaterialesPVC_ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {Vw_MaterialesPVC_ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";

			if(linea=="1" || linea=="2" || linea=="3" || linea=="4")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {Vw_MaterialesPVC_ProgramaProduccion.idLinea}=" + linea + "";


			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			
			rptHelper.setPermission(reporte);
			reportName = rptHelper.exportReport(reporte,"ReporteConsumoPvc",User.Identity.Name  );
			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName +  ".pdf";
			Response.Redirect(redirectPath);
		}

		/*** agregado por alejandro.hernandez@nasoft.com 03/03/2006 ***/
		private void cmdprint_Click(object sender, System.EventArgs e)
		{
			
			lblErrMsg.Text = "";
			try
			{
				if (txtFechaInicial.Text != string.Empty && txtFechaFinal.Text == string.Empty)
				{
					lblErrMsg.Text = "Fecha Final No puede ser vacía si la Fecha inical existe";
					return;
				}

				if (txtLibInicial.Text != string.Empty && txtLibFinal.Text == string.Empty)
				{
					lblErrMsg.Text = "Fecha Liberacion Final No puede ser vacía, si la Fecha de Liberación Inicial existe";
					return;
				}

				if ( txtSecInicial.Text != string.Empty)
				{
					if(cboSecInicial.Items.FindByText (txtSecInicial.Text) == null)
					{
						lblErrMsg.Text = "Número de Secuencia Inicial inválido";
						txtSecInicial.Text =""; 
						return;
					}
				}
				if (txtSecFinal.Text != string.Empty)
				{
					if (cboSecInicial.Items.FindByText(txtSecFinal.Text) == null)
					{
						lblErrMsg.Text = "Número de Secuencia Final inválido";
						txtSecFinal.Text =""; 
						return;
					}
				}
				if (Request.QueryString["Title"] == "Reacción")
				{
					ImprimeReaccion();
					#region código viejo
					//					rptHelper = new Reports.ReportHelper();
					//					Reports.ConsultReacion reporte = new Reports.ConsultReacion();
					//
					//					campoFecha= new ParameterValues();
					//					valorFecha= new ParameterDiscreteValue();
					//
					//					if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
					//						valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
					//					else
					//						valorFecha.Value="";
					//
					//					campoFecha.Add(valorFecha);
					////				
					////					ParameterValues campoSecuencia= new ParameterValues();
					////					ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
					////
					////					if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
					////						valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
					////					else
					////						valorSecuencia.Value="";
					////
					////					campoSecuencia.Add(valorSecuencia);
					//
					//					campoLinea= new ParameterValues();
					//					valorLinea= new ParameterDiscreteValue();
					//
					//					if (cboLinea.SelectedItem.Text != const_All)
					//						valorLinea.Value=string.Format("Reporte Fase de Reacción Linea: {0}",cboLinea.SelectedItem.Text);
					//					else
					//						valorLinea.Value="Reporte Fase de Reacción ";
					//
					//					campoLinea.Add(valorLinea);
					//				
					//
					//					campoPlanta= new ParameterValues(); 
					//					valorPlanta= new ParameterDiscreteValue();
					//					//valorPlanta.Value=string.Format("Planta: {0}",ConfigurationManager.AppSettings["LocalPlantText"]);
					//					if (cboLinea.SelectedItem.Text == const_All) 
					//					{
					//						//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
					//						valorPlanta.Value=const_All;
					//						//reporte.Section1.ReportObjects["Field7"].Width =0;
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =3015;  
					//						//reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
					//					}
					//					else
					//					{
					//						valorPlanta.Value="";
					//						//reporte.Section1.ReportObjects["Field7"].Width =0;
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
					//						//reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
					//					}  
					//					campoPlanta.Add(valorPlanta);
					//
					//					campoUser= new ParameterValues();
					//					valorUser= new ParameterDiscreteValue();
					//					valorUser.Value=Context.User.Identity.Name;
					//					campoUser.Add(valorUser);
					//
					//				
					//					campoSystem= new ParameterValues();
					//					valorSystem= new ParameterDiscreteValue();
					//					valorSystem.Value="SICAL";
					//					campoSystem.Add(valorSystem);
					//					
					//					reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
					//					reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
					//					//reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
					//					reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
					//					reporte.DataDefinition.ParameterFields["UserName"].ApplyCurrentValues(campoUser);
					//					reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);
					//
					//					
					//
					//					//string SelFormula="";
					//					if (cboLinea.SelectedItem.Text != const_All)
					//						SelFormula = "{OTReaccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);
					//
					//					//string txtFechaInicial.Text = txtFechaInicial.Text;
					//					//string txtFechaFinal.Text = txtFechaFinal.Text;
					//
					//					if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OTReaccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {OTReaccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
					//
					////					//string txtSecInicial.Text= txtSecInicial.Text;
					////					//string txtSecFinal.Text= txtSecFinal.Text;
					////
					////					if (txtSecInicial.Text!= String.Empty)
					////						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text;
					////					if ( txtSecFinal.Text!= String.Empty)
					////						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
					////	
					////					string //txtLibInicial.Text = txtLibInicial.Text;
					////					string //txtLibFinal.Text = txtLibFinal.Text;
					////					// txtLibInicial.Text != null && txtLibFinal.Text != null && 
					////					if (txtLibInicial.Text != String.Empty && txtLibFinal.Text != String.Empty)
					////						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
					//
					//					//SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + "  {OTReaccion.IdStatus}=2"; //{OrdenesTrabajo.IdArea}=3 AND 
					//
					//					reporte.DataDefinition.RecordSelectionFormula=SelFormula;
					//			
					//					rptHelper.setPermission(reporte);
					//					reportName = rptHelper.exportReport(reporte,"PartidasReaccionReport",User.Identity.Name  );
					//					redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
					//					Response.Redirect(redirectPath);
					#endregion
				}
				else if (Request.QueryString["Title"] == "Mezclas")
				{
					ImprimeMezclas();
					#region código viejo
					////					string Title = "Reporte Fase de Mezclas ";
					//
					//					rptHelper = new Reports.ReportHelper();
					//					Reports.ConsultMezclas reporte = new Reports.ConsultMezclas();
					//					
					//					campoFecha= new ParameterValues();
					//					valorFecha= new ParameterDiscreteValue();
					//
					//					if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
					//						valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
					//					else
					//						valorFecha.Value="";
					//
					//					campoFecha.Add(valorFecha);
					//				
					//					campoSecuencia= new ParameterValues();
					//					valorSecuencia= new ParameterDiscreteValue();
					//
					//					if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
					//						valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
					//					else
					//						valorSecuencia.Value="";
					//
					//					campoSecuencia.Add(valorSecuencia);
					//
					//					campoLinea= new ParameterValues();
					//					valorLinea= new ParameterDiscreteValue();
					//
					//					if (cboLinea.SelectedItem.Text != const_All)
					//						valorLinea.Value= string.Format("Reporte Fase de Mezclas Linea: {0}",cboLinea.SelectedItem.Text);
					//					else
					//						valorLinea.Value=" Reporte Fase de Mezclas ";
					//
					//					campoLinea.Add(valorLinea);				
					//
					//					campoPlanta= new ParameterValues(); 
					//					valorPlanta= new ParameterDiscreteValue();
					//					//valorPlanta.Value=string.Format("Planta: {0}",ConfigurationManager.AppSettings["LocalPlantText"]);
					//					if (cboLinea.SelectedItem.Text == const_All) 
					//					{
					//						//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
					//						valorPlanta.Value=const_All;
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =1535;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
					//					}
					//					else
					//					{
					//						valorPlanta.Value="";
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
					//					}
					//					campoPlanta.Add(valorPlanta);
					//
					//					campoUser= new ParameterValues();
					//					valorUser= new ParameterDiscreteValue();
					//					valorUser.Value=Context.User.Identity.Name;
					//					campoUser.Add(valorUser);
					//
					//				
					//					campoSystem= new ParameterValues();
					//					valorSystem= new ParameterDiscreteValue();
					//					valorSystem.Value="SICAL";
					//					campoSystem.Add(valorSystem);
					//					
					//					reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
					//					reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
					//					reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
					//					reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
					//					reporte.DataDefinition.ParameterFields["User"].ApplyCurrentValues(campoUser);
					//					reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);
					//
					//					//string SelFormula="";
					//					if (cboLinea.SelectedItem.Text != const_All)
					//						SelFormula = "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);
					//
					//					//string txtFechaInicial.Text = txtFechaInicial.Text;
					//					//string txtFechaFinal.Text = txtFechaFinal.Text;
					//
					//					if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
					//
					//					//string txtSecInicial.Text= txtSecInicial.Text;
					//					//string txtSecFinal.Text= txtSecFinal.Text;
					//
					//					if (txtSecInicial.Text!= String.Empty)
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text;
					//					if ( txtSecFinal.Text!= String.Empty)
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
					//	
					//					//txtLibInicial.Text = txtLibInicial.Text;
					//					//txtLibFinal.Text = txtLibFinal.Text;
					//					// txtLibInicial.Text != null && txtLibFinal.Text != null && 
					//					if (txtLibInicial.Text != String.Empty && txtLibFinal.Text != String.Empty)
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
					//
					//					SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + "  {OrdenesTrabajo.IdArea}=4 AND {OrdenesTrabajo.IdStatus}=5"; 
					//
					//
					//					reporte.DataDefinition.RecordSelectionFormula=SelFormula;
					//			
					//					rptHelper.setPermission(reporte);
					//					reportName = rptHelper.exportReport(reporte,"PartidasMezclasReport",User.Identity.Name);
					//
					//					redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName +  ".pdf";
					//					Response.Redirect(redirectPath);
					//
					//
					//					//Response.Redirect("ConsultMezclasReport.aspx?Title=" + Title + "&IdLinea=" + cboLinea.SelectedItem.Value + "&Linea=" + cboLinea.SelectedItem.Text + "&SecInicial=" + cboSecInicial.SelectedItem.Text + "&SecFinal=" + cboSecFinal.SelectedItem.Text + "&txtFechaInicial.Text=" + txtFechaInicial.Text + "&txtFechaFinal.Text=" + txtFechaFinal.Text + "&txtLibInicial.Text=" + txtLibInicial.Text + "&txtLibFinal.Text=" + txtLibFinal.Text);
					#endregion
				}
				else if (Request.QueryString["Title"] == "Color")
				{
					ImprimeColor();
					#region código viejo
					//					Title = "Reporte Fase de Color";
					//					rptHelper = new Reports.ReportHelper();
					//					Reports.PartidasColorReports reporte = new Reports.PartidasColorReports();
					//
					//					campoFecha= new ParameterValues();
					//					valorFecha= new ParameterDiscreteValue();
					//					if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)
					//						valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
					//					else
					//						valorFecha.Value=string.Empty;
					//					campoFecha.Add(valorFecha);
					//				
					//					campoSecuencia= new ParameterValues();
					//					valorSecuencia= new ParameterDiscreteValue();
					//
					//					if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
					//						valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
					//					else
					//						valorSecuencia.Value="";
					//
					//					campoSecuencia.Add(valorSecuencia);
					//
					//					campoLinea= new ParameterValues();
					//					valorLinea= new ParameterDiscreteValue();
					//					valorLinea.Value=string.Format("Linea: {0}",cboLinea.SelectedItem.Text);
					//					campoLinea.Add(valorLinea);
					//
					//					campoPlanta= new ParameterValues();
					//					valorPlanta= new ParameterDiscreteValue();
					//					if (cboLinea.SelectedItem.Text == const_All) 
					//					{
					//						//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
					//						valorPlanta.Value=const_All;
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =3015;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
					//					}
					//					else
					//					{
					//						valorPlanta.Value="";
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
					//					}
					//					//valorPlanta.Value=string.Format("Planta: {0}",ConfigurationManager.AppSettings["LocalPlantText"]);
					//					campoPlanta.Add(valorPlanta);
					//
					//					campoUser= new ParameterValues();
					//					valorUser= new ParameterDiscreteValue();
					//					valorUser.Value=Context.User.Identity.Name;
					//					campoUser.Add(valorUser);
					//
					//					reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
					//					reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
					//					reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
					//					reporte.DataDefinition.ParameterFields["UserName"].ApplyCurrentValues(campoUser);
					//					reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
					//
					//					//string SelFormula="";
					//					if (cboLinea.SelectedItem.Text != const_All)
					//						SelFormula = "{ProgramaProduccion.IdLinea}=" + cboLinea.SelectedItem.Value;
					//
					//					//string txtFechaInicial.Text = txtFechaInicial.Text;
					//					//string txtFechaFinal.Text = txtFechaFinal.Text;
					//
					//					if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
					//
					//					//string txtSecInicial.Text= txtSecInicial.Text;
					//					//string txtSecFinal.Text= txtSecFinal.Text;
					//
					//					if (txtSecInicial.Text!= null && txtSecFinal.Text!= null && txtSecInicial.Text!= "" && txtSecFinal.Text!= "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text+ " AND " + "Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
					//
					//					//txtLibInicial.Text = txtLibInicial.Text;
					//					//txtLibFinal.Text = txtLibFinal.Text;
					//
					//					if (txtLibInicial.Text != null && txtLibFinal.Text != null && txtLibInicial.Text != "" && txtLibFinal.Text != "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
					// 
					//					//CRViewer.SelectionFormula="{ProgramaProduccion.Fecha}=Date(" + DateTime.Parse(Fecha).ToString("yyyy") + "," + DateTime.Parse(Fecha).ToString("MM") + "," + DateTime.Parse(Fecha).ToString("dd") + ") and {ProgramaProduccion.IdLinea}=" + IdLinea;
					//					SelFormula = SelFormula + " AND {OrdenesTrabajo.IdArea}=1 AND {OrdenesTrabajo.IdStatus}=5";
					//
					//
					//					reporte.DataDefinition.RecordSelectionFormula=SelFormula;
					//			
					//					rptHelper.setPermission(reporte);
					//					reportName = rptHelper.exportReport(reporte,"PartidasColorReport",User.Identity.Name);
					//
					//					redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName +  ".pdf";
					//					Response.Redirect(redirectPath);
					//
					//					//Response.Redirect("ActivePhaseReport.aspx?Title=" + Title + "&IdLinea=" + cboLinea.SelectedItem.Value + "&Linea=" + cboLinea.SelectedItem.Text + "&SecInicial=" + cboSecInicial.SelectedItem.Text + "&SecFinal=" + cboSecFinal.SelectedItem.Text + "&txtFechaInicial.Text=" + txtFechaInicial.Text + "&txtFechaFinal.Text=" + txtFechaFinal.Text + "&txtLibInicial.Text=" + txtLibInicial.Text + "&txtLibFinal.Text=" + txtLibFinal.Text);
					#endregion
				}

				else if (Request.QueryString["Title"] == "Aditivos")
				{
					ImprimeAditivos();
					#region código viejo
					//					Title = "Reporte Fase de Aditivos";
					//					rptHelper = new Reports.ReportHelper();
					//					Reports.AdditivesPhaseReports reporte = new Reports.AdditivesPhaseReports();
					//
					//					campoFecha= new ParameterValues();
					//					valorFecha= new ParameterDiscreteValue();
					//					if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
					//						valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
					//					else
					//						valorFecha.Value="";					
					//					campoFecha.Add(valorFecha);
					//				
					//					campoLinea= new ParameterValues();
					//					valorLinea= new ParameterDiscreteValue();
					//					valorLinea.Value=string.Format("Linea: {0}",cboLinea.SelectedItem.Text);
					//					campoLinea.Add(valorLinea);
					//
					//					campoPlanta= new ParameterValues();
					//					valorPlanta= new ParameterDiscreteValue();
					//					if (cboLinea.SelectedItem.Text == const_All) 
					//					{
					//						//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
					//						valorPlanta.Value=const_All;
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =1535;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
					//					}
					//					else
					//					{
					//						valorPlanta.Value="";
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
					//					}
					//					campoPlanta.Add(valorPlanta);
					//
					//					campoSecuencia= new ParameterValues();
					//					valorSecuencia= new ParameterDiscreteValue();
					//					if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
					//						valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
					//					else
					//						valorSecuencia.Value="";
					//					campoSecuencia.Add(valorSecuencia);
					//
					//					/*ParameterValues campoLiberar= new ParameterValues();
					//					ParameterDiscreteValue valorLiberar= new ParameterDiscreteValue();
					//					valorLiberar.Value=string.Format("Fecha Liberar Del {0} al {1}",txtLibInicial.Text,txtLibFinal.Text);
					//					campoLiberar.Add(valorLiberar);
					//					*/
					//					campoUser= new ParameterValues();
					//					valorUser= new ParameterDiscreteValue();
					//					valorUser.Value=Context.User.Identity.Name;
					//					campoUser.Add(valorUser);
					//
					//					reporte.DataDefinition.ParameterFields["Programa"].ApplyCurrentValues(campoFecha);
					//					reporte.DataDefinition.ParameterFields["Linea"].ApplyCurrentValues(campoLinea);
					//					reporte.DataDefinition.ParameterFields["Planta"].ApplyCurrentValues(campoPlanta);
					//					reporte.DataDefinition.ParameterFields["Secuencia"].ApplyCurrentValues(campoSecuencia);
					//					//reporte.DataDefinition.ParameterFields["Liberar"].ApplyCurrentValues(campoLiberar);
					//					reporte.DataDefinition.ParameterFields["UserName"].ApplyCurrentValues(campoUser);
					//
					//					//string SelFormula="";
					//					if (cboLinea.SelectedItem.Text != const_All)
					//						SelFormula = "{ProgramaProduccion.IdLinea}=" + cboLinea.SelectedItem.Value;
					//
					//					//string txtFechaInicial.Text = txtFechaInicial.Text;
					//					//string txtFechaFinal.Text = txtFechaFinal.Text;
					//
					//					if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
					//
					//					//string txtSecInicial.Text= txtSecInicial.Text;
					//					//string txtSecFinal.Text= txtSecFinal.Text;
					//
					//					if (txtSecInicial.Text!= null && txtSecFinal.Text!= null && txtSecInicial.Text!= "" && txtSecFinal.Text!= "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text+ " AND " + "Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
					//
					//					//txtLibInicial.Text = txtLibInicial.Text;
					//					//txtLibFinal.Text = txtLibFinal.Text;
					//
					//					if (txtLibInicial.Text != null && txtLibFinal.Text != null && txtLibInicial.Text != "" && txtLibFinal.Text != "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
					// 
					//					//CRViewer.SelectionFormula="{ProgramaProduccion.Fecha}=Date(" + DateTime.Parse(Fecha).ToString("yyyy") + "," + DateTime.Parse(Fecha).ToString("MM") + "," + DateTime.Parse(Fecha).ToString("dd") + ") and {ProgramaProduccion.IdLinea}=" + IdLinea;
					//					SelFormula = SelFormula + " AND {OrdenesTrabajo.IdArea}=2 AND {OrdenesTrabajo.IdStatus}=5";
					//
					//
					//					reporte.DataDefinition.RecordSelectionFormula=SelFormula;
					//			
					//					rptHelper.setPermission(reporte);
					//					reportName = rptHelper.exportReport(reporte,"PartidasAditivosReport",User.Identity.Name);
					//
					//					redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName +  ".pdf";
					//					Response.Redirect(redirectPath);
					//
					//					//Response.Redirect("ActivePhaseReport.aspx?Title=" + Title + "&IdLinea=" + cboLinea.SelectedItem.Value + "&Linea=" + cboLinea.SelectedItem.Text + "&SecInicial=" + cboSecInicial.SelectedItem.Text + "&SecFinal=" + cboSecFinal.SelectedItem.Text + "&txtFechaInicial.Text=" + txtFechaInicial.Text + "&txtFechaFinal.Text=" + txtFechaFinal.Text + "&txtLibInicial.Text=" + txtLibInicial.Text + "&txtLibFinal.Text=" + txtLibFinal.Text);
					#endregion
				}
				else if (Request.QueryString["Title"] == "Consumo de Mezclas")
				{	
					ImprimeConsumoMezclas();
					#region código viejo
					//					rptHelper = new Reports.ReportHelper();
					//					Reports.ConsumptionMezclas reporte = new Reports.ConsumptionMezclas();
					//
					//					campoFecha= new ParameterValues();
					//					valorFecha= new ParameterDiscreteValue();
					//
					//					if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
					//						valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
					//					else
					//						valorFecha.Value="";
					//
					//					campoFecha.Add(valorFecha);
					//				
					//					campoSecuencia= new ParameterValues();
					//					valorSecuencia= new ParameterDiscreteValue();
					//
					//					if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
					//						valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
					//					else
					//						valorSecuencia.Value="";
					//
					//					campoSecuencia.Add(valorSecuencia);
					//
					//					campoLinea= new ParameterValues();
					//					valorLinea= new ParameterDiscreteValue();
					//
					//					if (cboLinea.SelectedItem.Text != const_All)
					//						valorLinea.Value=string.Format("Reporte Fase de Consumption Mezclas Linea: {0}",cboLinea.SelectedItem.Text);
					//					else
					//						valorLinea.Value="Reporte Fase de Consumption Mezclas ";
					//
					//					campoLinea.Add(valorLinea);
					//				
					//
					//					campoPlanta= new ParameterValues(); 
					//					valorPlanta= new ParameterDiscreteValue();
					//					//valorPlanta.Value=string.Format("Planta: {0}",ConfigurationManager.AppSettings["LocalPlantText"]);
					//					if (cboLinea.SelectedItem.Text == const_All) 
					//					{
					//						//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
					//						valorPlanta.Value=const_All;
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =3015;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
					//					}
					//					else
					//					{
					//						valorPlanta.Value="";
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
					//					}
					//					campoPlanta.Add(valorPlanta);
					//
					//					campoUser= new ParameterValues();
					//					valorUser= new ParameterDiscreteValue();
					//					valorUser.Value=Context.User.Identity.Name;
					//					campoUser.Add(valorUser);
					//
					//				
					//					campoSystem= new ParameterValues();
					//					valorSystem= new ParameterDiscreteValue();
					//					valorSystem.Value="SICAL";
					//					campoSystem.Add(valorSystem);
					//					
					//					reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
					//					reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
					//					reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
					//					reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
					//					reporte.DataDefinition.ParameterFields["User"].ApplyCurrentValues(campoUser);
					//					reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);
					//
					//					//string SelFormula="";
					//					if (cboLinea.SelectedItem.Text != const_All)
					//						SelFormula = "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);
					//
					//					//string txtFechaInicial.Text = txtFechaInicial.Text;
					//					//string txtFechaFinal.Text = txtFechaFinal.Text;
					//
					//					if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
					//
					//					//string txtSecInicial.Text= txtSecInicial.Text;
					//					//string txtSecFinal.Text= txtSecFinal.Text;
					//
					//					if (txtSecInicial.Text!= String.Empty)
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text;
					//					if ( txtSecFinal.Text!= String.Empty)
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
					//	
					//					//txtLibInicial.Text = txtLibInicial.Text;
					//					//txtLibFinal.Text = txtLibFinal.Text;
					//					// txtLibInicial.Text != null && txtLibFinal.Text != null && 
					//					if (txtLibInicial.Text != String.Empty && txtLibFinal.Text != String.Empty)
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
					//
					//					SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + "  {OrdenesTrabajo.IdArea}=4 AND {OrdenesTrabajo.IdStatus}=5"; 
					//
					//					reporte.DataDefinition.RecordSelectionFormula=SelFormula;
					//			
					//					rptHelper.setPermission(reporte);
					//					reportName = rptHelper.exportReport(reporte,"ConsumptionMezclasReport",User.Identity.Name);
					//
					//					//string redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+"ConsumptionAditivosReport.pdf";
					//					redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
					//					Response.Redirect(redirectPath);
					//					//Response.Redirect("ConsumptionMezclasReport.aspx?Title=" + Title + "&IdLinea=" + cboLinea.SelectedItem.Value + "&Linea=" + cboLinea.SelectedItem.Text + "&SecInicial=" + cboSecInicial.SelectedItem.Text + "&SecFinal=" + cboSecFinal.SelectedItem.Text + "&txtFechaInicial.Text=" + txtFechaInicial.Text + "&txtFechaFinal.Text=" + txtFechaFinal.Text + "&txtLibInicial.Text=" + txtLibInicial.Text + "&txtLibFinal.Text=" + txtLibFinal.Text);
					#endregion
				}
				else if (Request.QueryString["Title"] == "Consumo de Aditivos")
				{
					ImprimeConsumoAditivos();
					#region código viejo
					//					Title = "Reporte de Consumo de Aditivos";
					//					rptHelper = new Reports.ReportHelper();
					//					Reports.ConsumptionAditivos reporte = new Reports.ConsumptionAditivos();
					//
					//					campoFecha= new ParameterValues();
					//					valorFecha= new ParameterDiscreteValue();
					//					if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
					//						valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
					//					else
					//						valorFecha.Value="";					
					//					campoFecha.Add(valorFecha);
					//
					//					campoSecuencia= new ParameterValues();
					//					valorSecuencia= new ParameterDiscreteValue();
					//					if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
					//						valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
					//					else
					//						valorSecuencia.Value="";					
					//					campoSecuencia.Add(valorSecuencia);
					//				
					//					campoLinea= new ParameterValues();
					//					valorLinea= new ParameterDiscreteValue();
					//					valorLinea.Value=string.Format("Linea: {0}",cboLinea.SelectedItem.Text);
					//					campoLinea.Add(valorLinea);
					//
					//					campoPlanta= new ParameterValues();
					//					valorPlanta= new ParameterDiscreteValue();
					//					if (cboLinea.SelectedItem.Text == const_All) 
					//					{
					//						//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
					//						valorPlanta.Value=const_All;
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =1535;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
					//					}
					//					else
					//					{
					//						valorPlanta.Value="";
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
					//					}					
					//					campoPlanta.Add(valorPlanta);
					//
					//					campoUser= new ParameterValues();
					//					valorUser= new ParameterDiscreteValue();
					//					valorUser.Value=Context.User.Identity.Name;
					//					campoUser.Add(valorUser);
					//
					//				
					//					campoSystem= new ParameterValues();
					//					valorSystem= new ParameterDiscreteValue();
					//					valorSystem.Value="SICAL";
					//					campoSystem.Add(valorSystem);
					//
					//					reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
					//					reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
					//					reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
					//					reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
					//					reporte.DataDefinition.ParameterFields["User"].ApplyCurrentValues(campoUser);
					//					reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);
					//
					//					//string SelFormula="";
					//					if (cboLinea.SelectedItem.Text != const_All)
					//						SelFormula = "{ProgramaProduccion.IdLinea}=" + cboLinea.SelectedItem.Value;
					//
					//					//string txtFechaInicial.Text = txtFechaInicial.Text;
					//					//string txtFechaFinal.Text = txtFechaFinal.Text;
					//
					//					if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
					//
					//					//string txtSecInicial.Text= txtSecInicial.Text;
					//					//string txtSecFinal.Text= txtSecFinal.Text;
					//
					//					if (txtSecInicial.Text!= null && txtSecFinal.Text!= null && txtSecInicial.Text!= "" && txtSecFinal.Text!= "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({ProgramaProduccion.Secuencia}) >= " + txtSecInicial.Text+ " AND " + "Val({ProgramaProduccion.Secuencia}) <= " + txtSecFinal.Text;
					//
					//					//txtLibInicial.Text = txtLibInicial.Text;
					//					//txtLibFinal.Text = txtLibFinal.Text;
					//
					//					if (txtLibInicial.Text != null && txtLibFinal.Text != null && txtLibInicial.Text != "" && txtLibFinal.Text != "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
					// 
					//					//CRViewer.SelectionFormula="{ProgramaProduccion.Fecha}=Date(" + DateTime.Parse(Fecha).ToString("yyyy") + "," + DateTime.Parse(Fecha).ToString("MM") + "," + DateTime.Parse(Fecha).ToString("dd") + ") and {ProgramaProduccion.IdLinea}=" + IdLinea;
					//					SelFormula = SelFormula + " AND {OrdenesTrabajo.IdArea}=2 AND {OrdenesTrabajo.IdStatus}=5";
					//
					//
					//					reporte.DataDefinition.RecordSelectionFormula=SelFormula;
					//			
					//					rptHelper.setPermission(reporte);
					//					reportName = rptHelper.exportReport(reporte,"ConsumptionAditivosReport",User.Identity.Name);
					//
					//					redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
					//					Response.Redirect(redirectPath);
					//
					//					//Response.Redirect("ConsumptionAditivosReport.aspx?Title=" + Title + "&IdLinea=" + cboLinea.SelectedItem.Value + "&Linea=" + cboLinea.SelectedItem.Text + "&SecInicial=" + cboSecInicial.SelectedItem.Text + "&SecFinal=" + cboSecFinal.SelectedItem.Text + "&txtFechaInicial.Text=" + txtFechaInicial.Text + "&txtFechaFinal.Text=" + txtFechaFinal.Text + "&txtLibInicial.Text=" + txtLibInicial.Text + "&txtLibFinal.Text=" + txtLibFinal.Text);
					#endregion
				}
				else if (Request.QueryString["Title"] == "Consumo de Color")
				{
					ImprimeConsumoColor();
					#region código viejo
					//					Title = "Reporte Fase de Consumo de Color";
					//					rptHelper = new Reports.ReportHelper();
					//					Reports.ColorConsumptionRpt reporte = new Reports.ColorConsumptionRpt();
					//
					//					campoFecha= new ParameterValues();
					//					valorFecha= new ParameterDiscreteValue();
					//					if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
					//						valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
					//					else
					//						valorFecha.Value=string.Empty;
					//					campoFecha.Add(valorFecha);
					//				
					//					/*
					//					ParameterValues campoLibFecha= new ParameterValues();
					//					ParameterDiscreteValue valorLibFecha= new ParameterDiscreteValue();
					//					valorLibFecha.Value=string.Format("Liberar Fecha Del {0} al {1}",txtLibInicial.Text,txtLibFinal.Text);
					//					campoLibFecha.Add(valorLibFecha);
					//					*/
					//
					//					campoSecuencia= new ParameterValues();
					//					valorSecuencia= new ParameterDiscreteValue();
					//					if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty) 
					//						valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
					//					else
					//						valorSecuencia.Value=string.Empty;
					//					campoSecuencia.Add(valorSecuencia);
					//				
					//					campoLinea= new ParameterValues();
					//					valorLinea= new ParameterDiscreteValue();
					//					valorLinea.Value=string.Format("Linea: {0}",cboLinea.SelectedItem.Text);
					//					campoLinea.Add(valorLinea);
					//
					//					campoPlanta= new ParameterValues();
					//					valorPlanta= new ParameterDiscreteValue();
					//					//valorPlanta.Value=string.Format("Planta: {0}",ConfigurationManager.AppSettings["LocalPlantText"]);
					//					if (cboLinea.SelectedItem.Text == const_All) 
					//					{
					//						//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
					//						valorPlanta.Value=const_All;
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =3015;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
					//					}
					//					else
					//					{
					//						valorPlanta.Value="";
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
					//					}
					//					campoPlanta.Add(valorPlanta);
					//
					//					campoUser= new ParameterValues();
					//					valorUser= new ParameterDiscreteValue();
					//					valorUser.Value=Context.User.Identity.Name;
					//					campoUser.Add(valorUser);
					//
					//				
					//					campoSystem= new ParameterValues();
					//					valorSystem= new ParameterDiscreteValue();
					//					valorSystem.Value="SICAL";
					//					campoSystem.Add(valorSystem);
					//
					//					reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
					//					reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
					//					reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
					//					//reporte.DataDefinition.ParameterFields["Title3"].ApplyCurrentValues(campoLibFecha);
					//					reporte.DataDefinition.ParameterFields["Planta"].ApplyCurrentValues(campoPlanta);
					//					reporte.DataDefinition.ParameterFields["UserName"].ApplyCurrentValues(campoUser);
					//					reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);
					//
					//					//string SelFormula="";
					//					if (cboLinea.SelectedItem.Text != const_All)
					//						SelFormula = "{ProgramaProduccion.IdLinea}=" + cboLinea.SelectedItem.Value;
					//
					//					//string txtFechaInicial.Text = txtFechaInicial.Text;
					//					//string txtFechaFinal.Text = txtFechaFinal.Text;
					//
					//					if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
					//
					//
					//					//string txtSecInicial.Text= txtSecInicial.Text;
					//					//string txtSecFinal.Text= txtSecFinal.Text;
					//
					//					if (txtSecInicial.Text!= null && txtSecFinal.Text!= null && txtSecInicial.Text!= "" && txtSecFinal.Text!= "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({ProgramaProduccion.Secuencia}) >= " + txtSecInicial.Text+ " AND " + "Val({ProgramaProduccion.Secuencia}) <= " + txtSecFinal.Text;
					//
					//					//txtLibInicial.Text = txtLibInicial.Text;
					//					//txtLibFinal.Text = txtLibFinal.Text;
					//
					//					if (txtLibInicial.Text != null && txtLibFinal.Text != null && txtLibInicial.Text != "" && txtLibFinal.Text != "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
					// 
					//					//CRViewer.SelectionFormula="{ProgramaProduccion.Fecha}=Date(" + DateTime.Parse(Fecha).ToString("yyyy") + "," + DateTime.Parse(Fecha).ToString("MM") + "," + DateTime.Parse(Fecha).ToString("dd") + ") and {ProgramaProduccion.IdLinea}=" + IdLinea;
					//					SelFormula = SelFormula + " AND {OrdenesTrabajo.IdArea}=1 AND {OrdenesTrabajo.IdStatus}=5";
					//
					//
					//					reporte.DataDefinition.RecordSelectionFormula=SelFormula;
					//			
					//					rptHelper.setPermission(reporte);
					//					reportName = rptHelper.exportReport(reporte,"ConsumptionColorReport",User.Identity.Name);
					//
					//					redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
					//					Response.Redirect(redirectPath);
					//
					//					//Response.Redirect("FrmColorConsumption.aspx?Title=" + Title + "&IdLinea=" + cboLinea.SelectedItem.Value + "&Linea=" + cboLinea.SelectedItem.Text + "&SecInicial=" + cboSecInicial.SelectedItem.Text + "&SecFinal=" + cboSecFinal.SelectedItem.Text + "&txtFechaInicial.Text=" + txtFechaInicial.Text + "&txtFechaFinal.Text=" + txtFechaFinal.Text + "&txtLibInicial.Text=" + txtLibInicial.Text + "&txtLibFinal.Text=" + txtLibFinal.Text);
					#endregion
				}
				else if (Request.QueryString["Title"] == "Llenado")
				{
					ImprimeLlenado();
					#region código viejo
					//					Title = "Reporte Fase de Llenado ";
					//
					//					rptHelper = new Reports.ReportHelper();
					//					Reports.FillingPhase reporte = new Reports.FillingPhase();
					//
					//					campoFecha= new ParameterValues();
					//					valorFecha= new ParameterDiscreteValue();
					//
					//					if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
					//						valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
					//					else
					//						valorFecha.Value="";
					//
					//					campoFecha.Add(valorFecha);
					//				
					//					campoSecuencia= new ParameterValues();
					//					valorSecuencia= new ParameterDiscreteValue();
					//
					//					if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
					//						valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
					//					else
					//						valorSecuencia.Value="";
					//
					//					campoSecuencia.Add(valorSecuencia);
					//
					//					campoLinea= new ParameterValues();
					//					valorLinea= new ParameterDiscreteValue();
					//
					//					if (cboLinea.SelectedItem.Text != const_All)
					//						valorLinea.Value=Title + string.Format("Linea: {0}",cboLinea.SelectedItem.Text);
					//					else
					//						valorLinea.Value=Title;
					//
					//					campoLinea.Add(valorLinea);
					//				
					//
					//					campoPlanta= new ParameterValues(); 
					//					valorPlanta= new ParameterDiscreteValue();
					//					if (cboLinea.SelectedItem.Text == const_All) 
					//					{
					//						//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
					//						valorPlanta.Value=const_All;
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =3015;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
					//					}
					//					else
					//					{
					//						valorPlanta.Value="";
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
					//					}
					//					campoPlanta.Add(valorPlanta);
					//
					//					campoUser= new ParameterValues();
					//					valorUser= new ParameterDiscreteValue();
					//					valorUser.Value=Context.User.Identity.Name;
					//					campoUser.Add(valorUser);
					//
					//				
					//					campoSystem= new ParameterValues();
					//					valorSystem= new ParameterDiscreteValue();
					//					valorSystem.Value="SICAL";
					//					campoSystem.Add(valorSystem);
					//					
					//					reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
					//					reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
					//					reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
					//					reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
					//					reporte.DataDefinition.ParameterFields["UserName"].ApplyCurrentValues(campoUser);
					//					reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);
					//
					//					//string SelFormula="";
					//					if (cboLinea.SelectedItem.Text != const_All)
					//						SelFormula = "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);
					//
					//					//string txtFechaInicial.Text = txtFechaInicial.Text;
					//					//string txtFechaFinal.Text = txtFechaFinal.Text;
					//
					//					if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
					//
					//					//string txtSecInicial.Text= txtSecInicial.Text;
					//					//string txtSecFinal.Text= txtSecFinal.Text;
					//
					//					if (txtSecInicial.Text!= String.Empty)
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text;
					//					if ( txtSecFinal.Text!= String.Empty)
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
					//	
					//					//txtLibInicial.Text = txtLibInicial.Text;
					//					//txtLibFinal.Text = txtLibFinal.Text;
					//					// txtLibInicial.Text != null && txtLibFinal.Text != null && 
					//					if (txtLibInicial.Text != String.Empty && txtLibFinal.Text != String.Empty)
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
					//
					//					SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + "  {OrdenesTrabajo.IdArea}=7 AND {OrdenesTrabajo.IdStatus}=5 AND Time({OrdenesTrabajo.FechaLiberacion}) >= Time({Turno.Horainicial}) AND Time({OrdenesTrabajo.FechaLiberacion}) <= Time({Turno.HoraFinal})"; 
					//			
					//					reporte.DataDefinition.RecordSelectionFormula=SelFormula;
					//			
					//					rptHelper.setPermission(reporte);
					//					reportName = rptHelper.exportReport(reporte,"ConsultFillReport",User.Identity.Name);
					//					redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
					//					Response.Redirect(redirectPath);
					#endregion
				}
				else if (Request.QueryString["Title"] == "Separación")
				{
					ImprimeSeparacion();
					#region código viejo
					//					Title = "Reporte Fase de Separación";
					//
					//					rptHelper = new Reports.ReportHelper();
					//					Reports.ConsultSeparation reporte = new Reports.ConsultSeparation();
					//
					//					campoFecha= new ParameterValues();
					//					valorFecha= new ParameterDiscreteValue();
					//
					//					if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
					//						valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
					//					else
					//						valorFecha.Value="";
					//
					//					campoFecha.Add(valorFecha);
					//				
					//					campoSecuencia= new ParameterValues();
					//					valorSecuencia= new ParameterDiscreteValue();
					//
					//					if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
					//						valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
					//					else
					//						valorSecuencia.Value="";
					//
					//					campoSecuencia.Add(valorSecuencia);
					//
					//					campoLinea= new ParameterValues();
					//					valorLinea= new ParameterDiscreteValue();
					//
					//					if (cboLinea.SelectedItem.Text != const_All)
					//						valorLinea.Value=Title + string.Format("Linea: {0}",cboLinea.SelectedItem.Text);
					//					else
					//						valorLinea.Value=Title;
					//
					//					campoLinea.Add(valorLinea);
					//				
					//
					//					campoPlanta= new ParameterValues(); 
					//					valorPlanta= new ParameterDiscreteValue();
					//					//valorPlanta.Value=string.Format("Planta: {0}",ConfigurationManager.AppSettings["LocalPlantText"]);
					//					if (cboLinea.SelectedItem.Text == const_All) 
					//					{
					//						//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
					//						valorPlanta.Value=const_All;
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =3015;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
					//					}
					//					else
					//					{
					//						valorPlanta.Value="";
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
					//					}
					//					campoPlanta.Add(valorPlanta);
					//
					//					campoUser= new ParameterValues();
					//					valorUser= new ParameterDiscreteValue();
					//					valorUser.Value=Context.User.Identity.Name;
					//					campoUser.Add(valorUser);
					//
					//				
					//					campoSystem= new ParameterValues();
					//					valorSystem= new ParameterDiscreteValue();
					//					valorSystem.Value="SICAL";
					//					campoSystem.Add(valorSystem);
					//					
					//					reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
					//					reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
					//					reporte.DataDefinition.ParameterFields["Title3"].ApplyCurrentValues(campoLinea);
					//					reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
					//					reporte.DataDefinition.ParameterFields["User"].ApplyCurrentValues(campoUser);
					//					reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);
					//				
					//					//string SelFormula="";
					//					if (cboLinea.SelectedItem.Text != const_All)
					//						SelFormula = "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);
					//
					//					//string txtFechaInicial.Text = txtFechaInicial.Text;
					//					//string txtFechaFinal.Text = txtFechaFinal.Text;
					//
					//					if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
					//
					//					//string txtSecInicial.Text= txtSecInicial.Text;
					//					//string txtSecFinal.Text= txtSecFinal.Text;
					//
					//					if (txtSecInicial.Text!= String.Empty)
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text;
					//					if ( txtSecFinal.Text!= String.Empty)
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
					//	
					//					//txtLibInicial.Text = txtLibInicial.Text;
					//					//txtLibFinal.Text = txtLibFinal.Text;
					//					// txtLibInicial.Text != null && txtLibFinal.Text != null && 
					//					if (txtLibInicial.Text != String.Empty && txtLibFinal.Text != String.Empty)
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
					//
					//					SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + "  {OrdenesTrabajo.IdArea}=11 AND {OrdenesTrabajo.IdStatus}=5"; 
					//
					//
					//					reporte.DataDefinition.RecordSelectionFormula=SelFormula;
					//			
					//					rptHelper.setPermission(reporte);
					//					reportName = rptHelper.exportReport(reporte,"ConsultSeparationRep",User.Identity.Name);
					//					redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
					//					Response.Redirect(redirectPath);
					//
					#endregion
				}
				else if (Request.QueryString["Title"] == "Inspección")
				{
					ImprimeInspeccion();
					#region código viejo
					//					Title = "Reporte Fase de Inspección";
					//
					//					rptHelper = new Reports.ReportHelper();
					//					Reports.InspectionPhase reporte = new Reports.InspectionPhase();
					//
					//					campoFecha= new ParameterValues();
					//					valorFecha= new ParameterDiscreteValue();
					//
					//					if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
					//						valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
					//					else
					//						valorFecha.Value="";
					//
					//					campoFecha.Add(valorFecha);
					//				
					//					campoSecuencia= new ParameterValues();
					//					valorSecuencia= new ParameterDiscreteValue();
					//
					//					if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
					//						valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
					//					else
					//						valorSecuencia.Value="";
					//
					//					campoSecuencia.Add(valorSecuencia);
					//
					//					campoLinea= new ParameterValues();
					//					valorLinea= new ParameterDiscreteValue();
					//
					//					if (cboLinea.SelectedItem.Text != const_All)
					//						valorLinea.Value=string.Format("Reporte Fase de Inspección Linea: {0}",cboLinea.SelectedItem.Text);
					//					else
					//						valorLinea.Value="Reporte Fase de Inspección";
					//
					//					campoLinea.Add(valorLinea);
					//				
					//
					//					campoPlanta= new ParameterValues(); 
					//					valorPlanta= new ParameterDiscreteValue();
					//					//valorPlanta.Value=string.Format("Planta: {0}",ConfigurationManager.AppSettings["LocalPlantText"]);
					//					if (cboLinea.SelectedItem.Text == const_All) 
					//					{
					//						//valorPlanta.Value=string.Format(" {0}",ConfigurationManager.AppSettings["AllPlantText"]);
					//						valorPlanta.Value=const_All;
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =3015;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
					//					}
					//					else
					//					{
					//						valorPlanta.Value="";
					//						reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
					//						reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
					//					}
					//					campoPlanta.Add(valorPlanta);
					//
					//					campoUser= new ParameterValues();
					//					valorUser= new ParameterDiscreteValue();
					//					valorUser.Value=Context.User.Identity.Name;
					//					campoUser.Add(valorUser);
					//
					//				
					//					campoSystem= new ParameterValues();
					//					valorSystem= new ParameterDiscreteValue();
					//					valorSystem.Value="SICAL";
					//					campoSystem.Add(valorSystem);
					//					
					//					reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
					//					reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
					//					reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
					//					reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
					//					reporte.DataDefinition.ParameterFields["User"].ApplyCurrentValues(campoUser);
					//					reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);
					//
					//					
					//
					//					//string SelFormula="";
					//					if (cboLinea.SelectedItem.Text != const_All)
					//						SelFormula = "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);
					//
					//					//string txtFechaInicial.Text = txtFechaInicial.Text;
					//					//string txtFechaFinal.Text = txtFechaFinal.Text;
					//
					//					if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
					//
					//					//string txtSecInicial.Text= txtSecInicial.Text;
					//					//string txtSecFinal.Text= txtSecFinal.Text;
					//
					//					if (txtSecInicial.Text!= String.Empty)
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text;
					//					if ( txtSecFinal.Text!= String.Empty)
					//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
					//	
					//					//txtLibInicial.Text = txtLibInicial.Text;
					//					//txtLibFinal.Text = txtLibFinal.Text;
					//					// txtLibInicial.Text != null && txtLibFinal.Text != null && 
					//					if (txtLibInicial.Text != String.Empty && txtLibFinal.Text != String.Empty)
					//						// Naosft Roberto Carlos Guzman Vargas
					//						//modificacion reporte que abar que 3 turnos.
					//
					//					{
					//						//SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
					//						//SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + "  {OrdenesTrabajo.IdArea}=12 AND {OrdenesTrabajo.IdStatus}=5 AND Time({OrdenesTrabajo.FechaLiberacion}) >= Time({Turno.Horainicial}) AND Time({OrdenesTrabajo.FechaLiberacion}) <= Time({Turno.HoraFinal})";  
					//						// obtenemos los turnos
					//
					//											
					//						string d = txtLibFinal.Text; 
					//						DateTime dt = System.DateTime.Parse(d); 
					//						long startTicks= dt.Ticks; 							
					//						long tick = startTicks + 864000000000;
					//						DateTime df = new DateTime(tick);
					//						
					//						SelFormula = SelFormula +  (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion} > " + "CDateTime(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM")+ "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ",07,00,00)";
					//						SelFormula = SelFormula + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion} <= " + "CDateTime(" + df.Year + "," + df.Month  + "," + df.Day + ",07,00,00)";
					//					}
					//					// fin modificacion
					//					reporte.DataDefinition.RecordSelectionFormula=SelFormula;
					//			
					//					rptHelper.setPermission(reporte);
					//					reportName = rptHelper.exportReport(reporte,"ConsultInspectionPhase",User.Identity.Name  );
					//					redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName +  ".pdf";
					//					Response.Redirect(redirectPath);
					#endregion
				}
				else if (Request.QueryString["Title"] == "Materiales PVC")
				{
					ImprimeMateialesPVC();
				}
				else if (Request.QueryString["Title"] == "Reporte Materiales")
				{
					
				}
			}
			catch(Exception ex)
			{
				lblErrMsg.Text =ex.Message;
			}
		}
		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			//string redirectpath= "..\\NewMenu.aspx";
			//redirectpath =;
			//Response.Redirect(redirectpath);
			Response.Redirect("../NewMenu.aspx", false);
		}

		private void imgFInicial_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}


		
		private void cmdExportaPvc_Click(object sender, System.EventArgs e)
		{					
			ExportaPvc();
		}


		
		private void ExportaPvc()
		{
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

			string strSQL = "Exec Proc_Materiales_Pvc1 @IdLinea=" + idLinea.ToString() + ", @Initdate = '" + sFechaIni + "', @Finaldate = '" + sFechaFin + "'";	
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
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

				string xlFileName = "MaterialesPvc_" + System.DateTime.Now.ToString("ddMMMyyyy") +".xls";
				//Response.WriteFile(xlFileName);


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

		// ********************
		// Reporte de inspección
		
		private void cmdReporteInspeccion_Click(object sender, System.EventArgs e)
		{
			string redirectPath = "";
			string reportName = "";
			string sInst = "";
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

			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			Forms.Reports.MaterialesPvcIns reporte = new MaterialesPvcIns();
			
			Guid guid = Guid.NewGuid();

			sInst = " ";
			sInst += "declare @guid1 nvarchar(100); ";
			sInst += "set @guid1 = '" + guid.ToString() + "';";
			sInst += "Insert into Rep_Pvc1Inspeccion ( ";
			sInst += "Secuencia,Linea ,Codigo, Descripcion,Material,Caantidad,Medida,Espesor,guid1,Fecha)";
			sInst += "Exec Proc_Materiales_Pvc1_Inspeccion ";
			sInst += "@IdLinea=" + idLinea.ToString() + ", ";
			sInst += "@Initdate = '" + sFechaIni + "', ";
			sInst += "@Finaldate = '"  + sFechaFin +  "', ";
			sInst += "@guid = @guid1;";			

			// *************************
			// Ejecución de instrucción
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
			{
				conn.Open();
				using (SqlTransaction trans = conn.BeginTransaction()) 
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(trans, CommandType.Text,sInst);
						trans.Commit();
					}
					catch (Exception)
					{						
						trans.Rollback();					
					}
				}
			}
			// *************************

			string SelFormula = "{Rep_Pvc1Inspeccion.guid1} = '"+  guid.ToString() + "';";
			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			
			rptHelper.setPermission(reporte);
			reportName = rptHelper.exportReport(reporte,"ReporteConsumoPvcInspección",User.Identity.Name  );
			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName +  ".pdf";
			Response.Redirect(redirectPath);
		}

		
		private void cmdReporteCorte_Click(object sender, System.EventArgs e)
		{
			string redirectPath = "";
			string reportName = "";
			string sInst = "";
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

			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			Forms.Reports.MaterialesPvcCor  reporte = new MaterialesPvcCor();
			
			Guid guid = Guid.NewGuid();

			sInst = " ";
			sInst += "declare @guid1 nvarchar(100); ";
			sInst += "set @guid1 = '" + guid.ToString() + "';";
			sInst += "Insert into Rep_Pvc1Corte ( ";
			sInst += "Secuencia, Linea ,Codigo, Descripcion, Material, Cantidad, Medida, Espesor,Peso, idMedida, idEspesor, guid1, Fecha)";
			sInst += "Exec Proc_Materiales_Pvc1_Corte ";
			sInst += "@IdLinea=" + idLinea.ToString() + ", ";
			sInst += "@Initdate = '" + sFechaIni + "', ";
			sInst += "@Finaldate = '"  + sFechaFin +  "', ";
			sInst += "@guid = @guid1;";			

			// *************************
			// Ejecución de instrucción
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
			{
				conn.Open();
				using (SqlTransaction trans = conn.BeginTransaction()) 
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(trans, CommandType.Text,sInst);
						trans.Commit();
					}
					catch (Exception)
					{						
						trans.Rollback();					
					}
				}
			}
			// *************************

			string SelFormula = "{Rep_Pvc1Corte.guid1} = '"+  guid.ToString() + "';";
			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			
			rptHelper.setPermission(reporte);
			reportName = rptHelper.exportReport(reporte,"ReporteConsumoPvcCorte",User.Identity.Name  );
			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName +  ".pdf";
			Response.Redirect(redirectPath);

		}

        
        private void cmdEtiquetaPvc_Click(object sender, System.EventArgs e)
		{
			string redirectPath = "";
			string reportName = "";
			string sInst = "";
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

			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			Forms.Reports.MaterialesPvcEtqueta reporte = new MaterialesPvcEtqueta();
			
			Guid guid = Guid.NewGuid();

			sInst = " ";
			sInst += "declare @guid1 nvarchar(100); ";
			sInst += "set @guid1 = '" + guid.ToString() + "';";
			sInst += "Insert into Rep_Pvc1Corte ( ";
			sInst += "Secuencia, Linea ,Codigo, Descripcion, Material, Cantidad, Medida, Espesor,Peso, idMedida, idEspesor, guid1, Fecha)";
			sInst += "Exec Proc_Materiales_Pvc1_Corte ";
			sInst += "@IdLinea=" + idLinea.ToString() + ", ";
			sInst += "@Initdate = '" + sFechaIni + "', ";
			sInst += "@Finaldate = '"  + sFechaFin +  "', ";
			sInst += "@guid = @guid1;";			

			// *************************
			// Ejecución de instrucción
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
			{
				conn.Open();
				using (SqlTransaction trans = conn.BeginTransaction()) 
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(trans, CommandType.Text,sInst);
						trans.Commit();
					}
					catch (Exception)
					{						
						trans.Rollback();					
					}
				}
			}
			// *************************

			string SelFormula = "{Vw_Rep_Pvc1Corte.guid1} = '"+  guid.ToString() + "';";
			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			
			rptHelper.setPermission(reporte);
			reportName = rptHelper.exportReport(reporte,"EtiquetaConsumoPvc",User.Identity.Name  );
			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName +  ".pdf";
			Response.Redirect(redirectPath);
		}
		// ********************
	}
}