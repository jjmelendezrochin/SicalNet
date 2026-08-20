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
using SICALNet.BusinessEntities;
using SICALNet.BusinessLogicLayer;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;


namespace UserInterface.Forms.Reports
{
	/// <summary>
	/// Summary description for ConsultCuradoReport.
	/// </summary>
	public class ConsultCuradoReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblcaption;
		protected System.Web.UI.WebControls.Button cmdprint;
		protected System.Web.UI.WebControls.Label LblSequencia2;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Label lblLinea;
		protected System.Web.UI.WebControls.Label LblLiberacion2;
		protected System.Web.UI.WebControls.Label LblLiberacion1;
		protected System.Web.UI.WebControls.Label LblSecquencia1;
		protected System.Web.UI.WebControls.Label LbFechaPrograma1;
		protected System.Web.UI.WebControls.DropDownList cboFamilia;
		protected System.Web.UI.WebControls.Label lblFamilia;
		protected System.Web.UI.WebControls.Label lblFechaPrograma12;
		protected System.Web.UI.WebControls.DropDownList cboEspesor2;
		protected System.Web.UI.WebControls.DropDownList cboEspesor1;
		protected System.Web.UI.WebControls.Label lblEspesor1;
		protected System.Web.UI.WebControls.Label lblEspesor2;
		protected System.Web.UI.WebControls.Image imgProgrammaFinal;
		protected System.Web.UI.WebControls.Image imgLieractionFinal;
		protected System.Web.UI.WebControls.Image imgLieractionInitial;
		protected System.Web.UI.WebControls.Image imgProgrammaInitial;
		protected System.Web.UI.WebControls.Label lblErrMsg;
		protected System.Web.UI.WebControls.DropDownList cboSecInicial;
		protected System.Web.UI.WebControls.DropDownList cboSecFinal;
		protected System.Web.UI.WebControls.TextBox txtFechaFinal;
		protected System.Web.UI.WebControls.TextBox txtLibInicial;
		protected System.Web.UI.WebControls.TextBox txtLibFinal;
		protected System.Web.UI.WebControls.TextBox txtFechaInicial;
		protected System.Web.UI.WebControls.TextBox txtSecInicial;
		protected System.Web.UI.WebControls.TextBox txtSecFinal;
		protected System.Web.UI.WebControls.Button cmdCancelar;
		protected System.Web.UI.WebControls.ValidationSummary vs;
		protected System.Web.UI.WebControls.RegularExpressionValidator revInitial;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected CrystalDecisions.Web.CrystalReportViewer CrystalReportViewer1;
		protected CrystalDecisions.Web.CrystalReportViewer CrystalReportViewer2;
	
		public const string const_All = "Todas";

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here			

			
			if (!IsPostBack)
			{
				BindEntryFields();
				lblcaption.Text = lblcaption.Text  + Request.QueryString["Title"];
			}
		}
		private void BindEntryFields()
		{
			try
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

				//Code to populate Familia ComboBox
				SICALNet.BusinessLogicLayer.FamiliaProducto Familia = new SICALNet.BusinessLogicLayer.FamiliaProducto();
				IList FamiliaList = (IList)Familia.SelectFamiliaProducto();

				cboFamilia.DataSource = FamiliaList;
				cboFamilia.DataValueField="IdFamiliaProductos";
				cboFamilia.DataTextField="Descripcion";
				cboFamilia.DataBind();
				cboFamilia.Items.Add(const_All);
				cboFamilia.Items.FindByText(const_All).Selected=true;

				
		
				//Code to populate Sequenica ComboBox
				SICALNet.BusinessLogicLayer.Programa Progra = new SICALNet.BusinessLogicLayer.Programa();
				
				IList PrograList = (IList) Progra.LoadSecuencia();
				cboSecInicial.DataSource = PrograList;
			
				cboSecInicial.DataBind();
				cboSecInicial.Items.Add(const_All);
				cboSecInicial.Items.FindByText(const_All).Selected = true;
				/**/
				
			
				//Code to populate Espesor ComboBox
				SICALNet.BusinessLogicLayer.Espesor Espeso = new SICALNet.BusinessLogicLayer.Espesor();
				IList EspesorList = (IList)Espeso.LoadEspesor();
				cboEspesor1.DataSource=EspesorList;
				cboEspesor1.DataTextField = "Centimetros";
				cboEspesor1.DataValueField = "IdEspesor";
				cboEspesor1.DataBind();
				cboEspesor1.Items.Add(const_All);
				cboEspesor1.Items.FindByText(const_All).Selected=true;
	

				cboEspesor2.DataSource=EspesorList;
				cboEspesor2.DataTextField = "Centimetros";
				cboEspesor2.DataValueField = "IdEspesor";
				cboEspesor2.DataBind();
				cboEspesor2.Items.Add(const_All);
				cboEspesor2.Items.FindByText(const_All).Selected=true;  
				
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
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.cmdprint.Click += new System.EventHandler(this.cmdprint_Click);
			this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
			this.ID = "ConsultReport";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Button Event
		private void cmdCancelar_Click(object sender, System.EventArgs e)
		{
			string redirectpath= "..\\NewMenu.aspx";
			//redirectpath =;
			Response.Redirect(redirectpath);

		}
		/*** agregado por alejandro.hernandez@nasoft.com 03/03/2006 ***/
		private void ImprimeCurado()
		{
			ParameterValues campoFecha= new ParameterValues();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			ParameterValues campoSecuencia= new ParameterValues();
			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
			ParameterValues campoEspesor= new ParameterValues();
			ParameterDiscreteValue valorEspesor= new ParameterDiscreteValue();
			ParameterValues campoPlanta= new ParameterValues();
			ParameterValues campoLinea= new ParameterValues();
			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
			ParameterValues campoFamilia= new ParameterValues();
			ParameterDiscreteValue valorFamilia= new ParameterDiscreteValue();
			ParameterValues campoUser= new ParameterValues();
			ParameterDiscreteValue valorPlanta= new ParameterDiscreteValue();
			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
			ParameterValues campoSystem= new ParameterValues();
			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();

			string SelFormula="";
			string reportName= "";
			string redirectPath="";
			
			rptHelper = new Reports.ReportHelper();
			Reports.ConsultCuradoPhase reporte = new Reports.ConsultCuradoPhase();/*****/

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

			campoEspesor= new ParameterValues();
			valorEspesor= new ParameterDiscreteValue();
			valorEspesor.Value=string.Format("Del {0} al {1}",cboEspesor1.SelectedItem.Text,cboEspesor2.SelectedItem.Text);
			campoEspesor.Add(valorEspesor);

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

			campoLinea= new ParameterValues();
			valorLinea= new ParameterDiscreteValue();
			if (cboLinea.SelectedItem.Text != const_All)
				valorLinea.Value=string.Format("Reporte Consumos Fase de Curado Linea: {0}",cboLinea.SelectedItem.Text);
			else
				valorLinea.Value="Reporte Consumos Fase de Curado";
					
			campoLinea.Add(valorLinea);

			campoFamilia= new ParameterValues();
			valorFamilia= new ParameterDiscreteValue();
			valorFamilia.Value=string.Format("Familia: {0}",cboFamilia.SelectedItem.Text);
			campoFamilia.Add(valorFamilia);
				
			campoUser= new ParameterValues();
			valorUser= new ParameterDiscreteValue();
			valorUser.Value=Context.User.Identity.Name;
			campoUser.Add(valorUser);
				
			campoSystem= new ParameterValues();
			valorSystem= new ParameterDiscreteValue();
			valorSystem.Value=this.Context.User.Identity.Name;
			campoSystem.Add(valorSystem);
					
			reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
			reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
			reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
			reporte.DataDefinition.ParameterFields["Title3"].ApplyCurrentValues(campoFamilia);
			reporte.DataDefinition.ParameterFields["Title4"].ApplyCurrentValues(campoEspesor);
			reporte.DataDefinition.ParameterFields["UserName"].ApplyCurrentValues(campoUser);
			reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);

			SelFormula="";
			if (cboLinea.SelectedItem.Text != const_All)
				SelFormula = "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);

			if (cboFamilia.SelectedItem.Text != const_All)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + "{FamiliaProducto.idFamiliaProducto}=" + Convert.ToInt32(cboFamilia.SelectedItem.Value);

			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";

			if (txtSecInicial.Text != const_All && txtSecFinal.Text != const_All && txtSecInicial.Text != "" && txtSecFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text + " AND " + "Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;

			if (cboEspesor1.SelectedItem.Text != const_All && cboEspesor2.SelectedItem.Text != const_All && cboEspesor1.SelectedItem.Text != const_All && cboEspesor2.SelectedItem.Text != const_All)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " val({Material.idEspesor}) >= " + cboEspesor1.SelectedItem.Text + " AND " + "val({Material.idEspesor}) <= " + cboEspesor2.SelectedItem.Text;
					
			if (txtLibInicial.Text != null && txtLibFinal.Text != null && txtLibInicial.Text != "" && txtLibFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
			//antes
			SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.IdArea}=8 AND {OrdenesTrabajo.IdStatus}=5"; 

			reporte.DataDefinition.RecordSelectionFormula=SelFormula;			
			rptHelper.setPermission(reporte);
			reportName=rptHelper.exportReport(reporte,"ConsultCuradoReport",User.Identity.Name);
			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
					
			Response.Redirect(redirectPath, false);
		}

		/*** agregado por alejandro.hernandez@nasoft.com 03/03/2006 ***/
		private void ImprimePostCurado()
		{
			ParameterValues campoFecha= new ParameterValues();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			ParameterValues campoSecuencia= new ParameterValues();
			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
			ParameterValues campoEspesor= new ParameterValues();
			ParameterDiscreteValue valorEspesor= new ParameterDiscreteValue();
			ParameterValues campoPlanta= new ParameterValues();
			ParameterValues campoLinea= new ParameterValues();
			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
			ParameterValues campoFamilia= new ParameterValues();
			ParameterDiscreteValue valorFamilia= new ParameterDiscreteValue();
			ParameterValues campoUser= new ParameterValues();
			ParameterDiscreteValue valorPlanta= new ParameterDiscreteValue();
			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
			ParameterValues campoSystem= new ParameterValues();
			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();

			string SelFormula="";
			string reportName= "";
			string redirectPath="";

			rptHelper = new Reports.ReportHelper();
			Reports.ConsumPostCurado reporte = new Reports.ConsumPostCurado();

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

			campoEspesor= new ParameterValues();
			valorEspesor= new ParameterDiscreteValue();
			valorEspesor.Value=string.Format("Del {0} al {1}",cboEspesor1.SelectedItem.Text,cboEspesor2.SelectedItem.Text);
			campoEspesor.Add(valorSecuencia);

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

			campoLinea= new ParameterValues();
			valorLinea= new ParameterDiscreteValue();
			if (cboLinea.SelectedItem.Text != const_All)
				valorLinea.Value=string.Format("Reporte Consumos Fase de PostCurado : {0}",cboLinea.SelectedItem.Text);/****/
			else
				valorLinea.Value="Reporte Consumos Fase de PostCurado";/****/
			campoLinea.Add(valorLinea);

			campoFamilia= new ParameterValues();
			valorFamilia= new ParameterDiscreteValue();
			valorFamilia.Value=string.Format("Familia: {0}",cboFamilia.SelectedItem.Text);
			campoFamilia.Add(valorFamilia);
				
			campoUser= new ParameterValues();/***/
			valorUser= new ParameterDiscreteValue();/***/
			valorUser.Value=Context.User.Identity.Name;/***/
			campoUser.Add(valorUser);/***/

				
			campoSystem= new ParameterValues();
			valorSystem= new ParameterDiscreteValue();
			valorSystem.Value="SICAL";/***/
			campoSystem.Add(valorSystem);
					
			reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
			reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
			reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
					
			//					reporte.DataDefinition.ParameterFields["Title3"].ApplyCurrentValues(campoFamilia);/***/
			//					reporte.DataDefinition.ParameterFields["Title4"].ApplyCurrentValues(campoEspesor);/***/

			reporte.DataDefinition.ParameterFields["User"].ApplyCurrentValues(campoUser);
			reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);

			SelFormula="";
			if (cboLinea.SelectedItem.Text != const_All)
				SelFormula = "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);

			if (cboFamilia.SelectedItem.Text != const_All)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " " + "{FamiliaProducto.idFamiliaProducto}=" + Convert.ToInt32(cboFamilia.SelectedItem.Value);


			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";

			if (txtSecInicial.Text != const_All && txtSecFinal.Text != const_All && txtSecInicial.Text != "" && txtSecFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text + " AND " + "Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;

			if (cboEspesor1.SelectedItem.Text != const_All && cboEspesor2.SelectedItem.Text != const_All && cboEspesor1.SelectedItem.Text != "" && cboEspesor2.SelectedItem.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") +  " val({Espesor.idEspesor}) >= " + cboEspesor1.SelectedItem.Text + " AND " + "val({Espesor.idEspesor}) <= " + cboEspesor2.SelectedItem.Text;
					
			if (txtLibInicial.Text != "" && txtLibFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") +  " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";

			SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") +  " {OrdenesTrabajo.IdArea}=9 AND {OrdenesTrabajo.IdStatus}=5"; // AND Time({OrdenesTrabajo.FechaLiberacion}) >= Time({Turno.Horainicial}) AND Time({OrdenesTrabajo.FechaLiberacion}) <= Time({Turno.HoraFinal})"; 

			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			rptHelper.setPermission(reporte);
			reportName= rptHelper.exportReport(reporte, "ConsultPostCuradoRep",User.Identity.Name);/***/
			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
					
			Response.Redirect(redirectPath);
		}

		/*** agregado por alejandro.hernandez@nasoft.com 03/03/2006 ***/
		private void ImprimePreseparacion()
		{
			string Title = "Reporte Fase de Consulta de Preseparación";

			ParameterValues campoFecha= new ParameterValues();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			ParameterValues campoSecuencia= new ParameterValues();
			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
			ParameterValues campoEspesor= new ParameterValues();
			ParameterDiscreteValue valorEspesor= new ParameterDiscreteValue();
			ParameterValues campoPlanta= new ParameterValues();
			ParameterValues campoLinea= new ParameterValues();
			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
			ParameterValues campoFamilia= new ParameterValues();
			ParameterDiscreteValue valorFamilia= new ParameterDiscreteValue();
			ParameterValues campoUser= new ParameterValues();
			ParameterDiscreteValue valorPlanta= new ParameterDiscreteValue();
			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
			ParameterValues campoSystem= new ParameterValues();
			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();

			string SelFormula="";
			string reportName= "";
			string redirectPath="";

			rptHelper = new Reports.ReportHelper();
			Reports.ConsultPreSeparationPhase reporte = new Reports.ConsultPreSeparationPhase();

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

			campoEspesor= new ParameterValues();
			valorEspesor= new ParameterDiscreteValue();
			valorEspesor.Value=string.Format("Del {0} al {1}",cboEspesor1.SelectedItem.Text,cboEspesor2.SelectedItem.Text);
			campoEspesor.Add(valorSecuencia);

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

			campoLinea= new ParameterValues();
			valorLinea= new ParameterDiscreteValue();
			if (cboLinea.SelectedItem.Text != const_All)
				valorLinea.Value=Title + string.Format("Linea: {0}",cboLinea.SelectedItem.Text);
			else
				valorLinea.Value=Title;
			campoLinea.Add(valorLinea);

			campoFamilia= new ParameterValues();
			valorFamilia= new ParameterDiscreteValue();
			valorFamilia.Value=string.Format("Familia: {0}",cboFamilia.SelectedItem.Text);
			campoFamilia.Add(valorFamilia);
				
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
			reporte.DataDefinition.ParameterFields["User"].ApplyCurrentValues(campoUser);
			reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);

			SelFormula="";
			if (cboLinea.SelectedItem.Text != const_All)
				SelFormula = "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);
			//if (cboFamilia.SelectedItem.Text != const_All)
			//	SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " " + "{FamiliaProducto.idFamiliaProducto}=" + Convert.ToInt32(cboFamilia.SelectedItem.Value);
			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
			if (txtSecInicial.Text != const_All && txtSecFinal.Text != const_All && txtSecInicial.Text != "" && txtSecFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text + " AND " + "Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
			if (cboEspesor1.SelectedItem.Text != const_All && cboEspesor2.SelectedItem.Text != const_All && cboEspesor1.SelectedItem.Text != "" && cboEspesor2.SelectedItem.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") +  " {Espesor.Centimetros} >= " + cboEspesor1.SelectedItem.Text + " AND " + " {Espesor.Centimetros} <= " + cboEspesor2.SelectedItem.Text;
			if (txtLibInicial.Text != "" && txtLibFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") +  " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";

			SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") +  " {OrdenesTrabajo.IdArea}=10 AND {OrdenesTrabajo.IdStatus}=5 AND {PartidasPostCurado.IdArea}=9";

			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			rptHelper.setPermission(reporte);
			reportName= rptHelper.exportReport(reporte, "ConsultPreseparacionReport",User.Identity.Name );
			redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
					
			Response.Redirect(redirectPath);
		}

        private void cmdprint_Click(object sender, System.EventArgs e)
		{
			lblErrMsg.Text = "";

			#region*** comentado por alejandro.hernandez@nasoft.com 24/02/2006 ***/
//			ParameterValues campoFecha= new ParameterValues();
//			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
//			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
//			ParameterValues campoSecuencia= new ParameterValues();
//			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
//			ParameterValues campoEspesor= new ParameterValues();
//			ParameterDiscreteValue valorEspesor= new ParameterDiscreteValue();
//			ParameterValues campoPlanta= new ParameterValues();
//			ParameterValues campoLinea= new ParameterValues();
//			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
//			ParameterValues campoFamilia= new ParameterValues();
//			ParameterDiscreteValue valorFamilia= new ParameterDiscreteValue();
//			ParameterValues campoUser= new ParameterValues();
//			ParameterDiscreteValue valorPlanta= new ParameterDiscreteValue();
//			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
//			ParameterValues campoSystem= new ParameterValues();
//			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();
//			
//			string SelFormula="";
//			string reportName= "";
//			string redirectPath="";
			#endregion/*** fin de modificación ***/

			try
			{

				if (txtFechaInicial.Text != string.Empty && txtFechaFinal.Text == string.Empty)
				{
					lblErrMsg.Text = "Fecha Final Should Not be Empty, if Fecha Inicial Exists";
					return;
				}

				if (txtLibInicial.Text != string.Empty && txtLibFinal.Text == string.Empty)
				{
					lblErrMsg.Text = "Liberacion Final Should Not be Empty, if Liberacion Inicial Exists";
					return;
				}

				// Calling that particular aspx file.

				/*** modificado por alejandro.hernandez@nasoft.com 03/03/2006 ***/
				if (Request.QueryString["Title"] == "Curado")
				{
					ImprimeCurado();
					#region código viejo
//					rptHelper = new Reports.ReportHelper();
//					Reports.ConsultCuradoPhase reporte = new Reports.ConsultCuradoPhase();/*****/
//
//					campoFecha= new ParameterValues();
//					valorFecha= new ParameterDiscreteValue();
//					if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
//						valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
//					else
//						valorFecha.Value="";
//
//					campoFecha.Add(valorFecha);
//				
//					campoSecuencia= new ParameterValues();
//					valorSecuencia= new ParameterDiscreteValue();
//					if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
//						valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
//					else
//						valorSecuencia.Value="";
//
//					campoSecuencia.Add(valorSecuencia);
//
//					campoEspesor= new ParameterValues();
//					valorEspesor= new ParameterDiscreteValue();
//					valorEspesor.Value=string.Format("Del {0} al {1}",cboEspesor1.SelectedItem.Text,cboEspesor2.SelectedItem.Text);
//					campoEspesor.Add(valorEspesor);
//
//					campoPlanta= new ParameterValues();
//					valorPlanta= new ParameterDiscreteValue();
//					
//					if (cboLinea.SelectedItem.Text == const_All) 
//					{
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
//
//					campoPlanta.Add(valorPlanta);
//
//					campoLinea= new ParameterValues();
//					valorLinea= new ParameterDiscreteValue();
//					if (cboLinea.SelectedItem.Text != const_All)
//						valorLinea.Value=string.Format("Reporte Consumos Fase de Curado Linea: {0}",cboLinea.SelectedItem.Text);
//					else
//						valorLinea.Value="Reporte Consumos Fase de Curado";
//					
//					campoLinea.Add(valorLinea);
//
//					campoFamilia= new ParameterValues();
//					valorFamilia= new ParameterDiscreteValue();
//					valorFamilia.Value=string.Format("Familia: {0}",cboFamilia.SelectedItem.Text);
//					campoFamilia.Add(valorFamilia);
//				
//					campoUser= new ParameterValues();
//					valorUser= new ParameterDiscreteValue();
//					valorUser.Value=Context.User.Identity.Name;
//					campoUser.Add(valorUser);
//				
//					campoSystem= new ParameterValues();
//					valorSystem= new ParameterDiscreteValue();
//					valorSystem.Value=this.Context.User.Identity.Name;
//					campoSystem.Add(valorSystem);
//					
//					reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
//					reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
//					reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
//					reporte.DataDefinition.ParameterFields["Title3"].ApplyCurrentValues(campoFamilia);
//					reporte.DataDefinition.ParameterFields["Title4"].ApplyCurrentValues(campoEspesor);
//					reporte.DataDefinition.ParameterFields["UserName"].ApplyCurrentValues(campoUser);
//					reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
//					reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);
//
//					SelFormula="";
//					if (cboLinea.SelectedItem.Text != const_All)
//						SelFormula = "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);
//
//					if (cboFamilia.SelectedItem.Text != const_All)
//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + "{FamiliaProducto.idFamiliaProducto}=" + Convert.ToInt32(cboFamilia.SelectedItem.Value);
//
//					if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
//
//					if (txtSecInicial.Text != const_All && txtSecFinal.Text != const_All && txtSecInicial.Text != "" && txtSecFinal.Text != "")
//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text + " AND " + "Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
//
//					if (cboEspesor1.SelectedItem.Text != const_All && cboEspesor2.SelectedItem.Text != const_All && cboEspesor1.SelectedItem.Text != const_All && cboEspesor2.SelectedItem.Text != const_All)
//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " val({Material.idEspesor}) >= " + cboEspesor1.SelectedItem.Text + " AND " + "val({Material.idEspesor}) <= " + cboEspesor2.SelectedItem.Text;
//					
//					if (txtLibInicial.Text != null && txtLibFinal.Text != null && txtLibInicial.Text != "" && txtLibFinal.Text != "")
//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
//					//antes
//					SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.IdArea}=8 AND {OrdenesTrabajo.IdStatus}=5"; 
//
//					reporte.DataDefinition.RecordSelectionFormula=SelFormula;			
//					rptHelper.setPermission(reporte);
//					reportName=rptHelper.exportReport(reporte,"ConsultCuradoReport",User.Identity.Name);
//					redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
//					
//					Response.Redirect(redirectPath, false);
					#endregion
				}
				else if (Request.QueryString["Title"] == "PostCurado")
				{
					ImprimePostCurado();
					#region código viejo
					
		//			rptHelper = new Reports.ReportHelper();
		//			Reports.ConsumPostCurado reporte = new Reports.ConsumPostCurado();
		//
		//			campoFecha= new ParameterValues();
		//			valorFecha= new ParameterDiscreteValue();
		//			if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
		//				valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
		//			else
		//				valorFecha.Value="";
		//
		//			campoFecha.Add(valorFecha);
		//				
		//			campoSecuencia= new ParameterValues();
		//			valorSecuencia= new ParameterDiscreteValue();
		//			if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
		//				valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
		//			else
		//				valorSecuencia.Value="";
		//
		//			campoSecuencia.Add(valorSecuencia);
		//
		//			campoEspesor= new ParameterValues();
		//			valorEspesor= new ParameterDiscreteValue();
		//			valorEspesor.Value=string.Format("Del {0} al {1}",cboEspesor1.SelectedItem.Text,cboEspesor2.SelectedItem.Text);
		//			campoEspesor.Add(valorSecuencia);
		//
		//			campoPlanta= new ParameterValues();
		//			valorPlanta= new ParameterDiscreteValue();
		//
		//			if (cboLinea.SelectedItem.Text == const_All) 
		//			{
		//				valorPlanta.Value=const_All;
		//				reporte.Section1.ReportObjects["FldAllPlanta"].Width =3015;  
		//				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
		//			}
		//			else
		//			{
		//				valorPlanta.Value="";
		//				reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
		//				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
		//			}
		//			campoPlanta.Add(valorPlanta);
		//
		//			campoLinea= new ParameterValues();
		//			valorLinea= new ParameterDiscreteValue();
		//			if (cboLinea.SelectedItem.Text != const_All)
		//				valorLinea.Value=string.Format("Reporte Consumos Fase de PostCurado : {0}",cboLinea.SelectedItem.Text);/****/
		//				else
		//					valorLinea.Value="Reporte Consumos Fase de PostCurado";/****/
		//					campoLinea.Add(valorLinea);
		//
		//					campoFamilia= new ParameterValues();
		//					valorFamilia= new ParameterDiscreteValue();
		//					valorFamilia.Value=string.Format("Familia: {0}",cboFamilia.SelectedItem.Text);
		//					campoFamilia.Add(valorFamilia);
		//				
		//					campoUser= new ParameterValues();/***/
		//					valorUser= new ParameterDiscreteValue();/***/
		//					valorUser.Value=Context.User.Identity.Name;/***/
		//					campoUser.Add(valorUser);/***/
		//
		//				
		//					campoSystem= new ParameterValues();
		//					valorSystem= new ParameterDiscreteValue();
		//					valorSystem.Value="SICAL";/***/
		//					campoSystem.Add(valorSystem);
		//					
		//					reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
		//					reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
		//					reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
		//					
		//					//					reporte.DataDefinition.ParameterFields["Title3"].ApplyCurrentValues(campoFamilia);/***/
		//					//					reporte.DataDefinition.ParameterFields["Title4"].ApplyCurrentValues(campoEspesor);/***/
		//
		//					reporte.DataDefinition.ParameterFields["User"].ApplyCurrentValues(campoUser);
		//					reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
		//					reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);
		//
		//					SelFormula="";
		//					if (cboLinea.SelectedItem.Text != const_All)
		//						SelFormula = "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);
		//
		//					if (cboFamilia.SelectedItem.Text != const_All)
		//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " " + "{FamiliaProducto.idFamiliaProducto}=" + Convert.ToInt32(cboFamilia.SelectedItem.Value);
		//
		//
		//					if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
		//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
		//
		//					if (txtSecInicial.Text != const_All && txtSecFinal.Text != const_All && txtSecInicial.Text != "" && txtSecFinal.Text != "")
		//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text + " AND " + "Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
		//
		//					if (cboEspesor1.SelectedItem.Text != const_All && cboEspesor2.SelectedItem.Text != const_All && cboEspesor1.SelectedItem.Text != "" && cboEspesor2.SelectedItem.Text != "")
		//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") +  " val({Espesor.idEspesor}) >= " + cboEspesor1.SelectedItem.Text + " AND " + "val({Espesor.idEspesor}) <= " + cboEspesor2.SelectedItem.Text;
		//					
		//					if (txtLibInicial.Text != "" && txtLibFinal.Text != "")
		//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") +  " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
		//
		//					SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") +  " {OrdenesTrabajo.IdArea}=9 AND {OrdenesTrabajo.IdStatus}=5"; // AND Time({OrdenesTrabajo.FechaLiberacion}) >= Time({Turno.Horainicial}) AND Time({OrdenesTrabajo.FechaLiberacion}) <= Time({Turno.HoraFinal})"; 
		//
		//					reporte.DataDefinition.RecordSelectionFormula=SelFormula;
		//					rptHelper.setPermission(reporte);
		//					reportName= rptHelper.exportReport(reporte, "ConsultPostCuradoRep",User.Identity.Name);/***/
		//					redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
		//					
		//					Response.Redirect(redirectPath);
//					 
					#endregion
				}
				else if (Request.QueryString["Title"] == "Preseparación")
				{
					ImprimePreseparacion();
					#region código viejo

//					string Title = "Reporte Fase de Consulta de Preseparación";
//
//					rptHelper = new Reports.ReportHelper();
//					Reports.ConsultPreSeparationPhase reporte = new Reports.ConsultPreSeparationPhase();
//
//					campoFecha= new ParameterValues();
//					valorFecha= new ParameterDiscreteValue();
//					if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
//						valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
//					else
//						valorFecha.Value="";
//
//					campoFecha.Add(valorFecha);
//				
//					campoSecuencia= new ParameterValues();
//					valorSecuencia= new ParameterDiscreteValue();
//					if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
//						valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
//					else
//						valorSecuencia.Value="";
//
//					campoSecuencia.Add(valorSecuencia);
//
//					campoEspesor= new ParameterValues();
//					valorEspesor= new ParameterDiscreteValue();
//					valorEspesor.Value=string.Format("Del {0} al {1}",cboEspesor1.SelectedItem.Text,cboEspesor2.SelectedItem.Text);
//					campoEspesor.Add(valorSecuencia);
//
//					campoPlanta= new ParameterValues();
//					valorPlanta= new ParameterDiscreteValue();
//
//					if (cboLinea.SelectedItem.Text == const_All) 
//					{
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
//					campoLinea= new ParameterValues();
//					valorLinea= new ParameterDiscreteValue();
//					if (cboLinea.SelectedItem.Text != const_All)
//						valorLinea.Value=Title + string.Format("Linea: {0}",cboLinea.SelectedItem.Text);
//					else
//						valorLinea.Value=Title;
//					campoLinea.Add(valorLinea);
//
//					campoFamilia= new ParameterValues();
//					valorFamilia= new ParameterDiscreteValue();
//					valorFamilia.Value=string.Format("Familia: {0}",cboFamilia.SelectedItem.Text);
//					campoFamilia.Add(valorFamilia);
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
//					//reporte.DataDefinition.ParameterFields["Title3"].ApplyCurrentValues(campoFamilia);
//					reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
//					//reporte.DataDefinition.ParameterFields["Title4"].ApplyCurrentValues(campoEspesor);
//					reporte.DataDefinition.ParameterFields["User"].ApplyCurrentValues(campoUser);
//					reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
//					reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);
//
//					SelFormula="";
//					if (cboLinea.SelectedItem.Text != const_All)
//						SelFormula = "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);
//
//					if (cboFamilia.SelectedItem.Text != const_All)
//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " " + "{FamiliaProducto.idFamiliaProducto}=" + Convert.ToInt32(cboFamilia.SelectedItem.Value);
//
//					if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";
//
//					//					txtSecInicial.Text = cbotxtSecInicial.Text.SelectedItem.Text;
//					//					txtSecFinal.Text = cbotxtSecFinal.Text.SelectedItem.Text;
//					//txtSecInicial.Text = txtSecInicial.Text;
//					//txtSecFinal.Text = txtSecFinal.Text;
//
//					if (txtSecInicial.Text != const_All && txtSecFinal.Text != const_All && txtSecInicial.Text != "" && txtSecFinal.Text != "")
//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + txtSecInicial.Text + " AND " + "Val({OrdenesTrabajo.Secuencia}) <= " + txtSecFinal.Text;
//
//					//cboEspesor1.SelectedItem.Text = cboEspesor1.SelectedItem.Text;
//					//cboEspesor2.SelectedItem.Text = cboEspesor2.SelectedItem.Text;
//
//					if (cboEspesor1.SelectedItem.Text != const_All && cboEspesor2.SelectedItem.Text != const_All && cboEspesor1.SelectedItem.Text != "" && cboEspesor2.SelectedItem.Text != "")
//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") +  " val({Material.idEspesor}) >= " + cboEspesor1.SelectedItem.Text + " AND " + "val({Material.idEspesor}) <= " + cboEspesor2.SelectedItem.Text;
//					
//					//txtLibInicial.Text = txtLibInicial.Text;
//					//txtLibFinal.Text = txtLibFinal.Text;
//					
//					//txtLibInicial.Text != null && txtLibFinal.Text != null && 
//					if (txtLibInicial.Text != "" && txtLibFinal.Text != "")
//						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") +  " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";
//
//					SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") +  " {OrdenesTrabajo.IdArea}=10 AND {OrdenesTrabajo.IdStatus}=5 AND {PartidasPostCurado.IdArea}=9";
//
//					reporte.DataDefinition.RecordSelectionFormula=SelFormula;
//			
//					rptHelper.setPermission(reporte);
//					reportName= rptHelper.exportReport(reporte, "ConsultPreseparacionReport",User.Identity.Name );
//					redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
//					
//					Response.Redirect(redirectPath);
//										
//					//Response.Redirect("ConsultCuradoReport.aspx?Title=" + Title + "&IdLinea=" + cboLinea.SelectedItem.Value + "&Linea=" + cboLinea.SelectedItem.Text + "&txtSecInicial.Text=" + cbotxtSecInicial.Text.SelectedItem.Text + "&txtSecFinal.Text=" + cbotxtSecFinal.Text.SelectedItem.Text + "&txtFechaInicial.Text=" + txtFechaInicial.Text + "&txtFechaFinal.Text=" + txtFechaFinal.Text + "&txtLibInicial.Text=" + txtLibInicial.Text + "&txtLibFinal.Text=" + txtLibFinal.Text);
					#endregion
				}
				/*** fin modificación ***/
			}		
			//catch(IndexOutOfRangeException errHand)
			catch
			{
				throw;
			}
//			catch
//			{
//				// lblErrMsg.Text=ex.Message;
//
//				throw;
//			}
	
		}
		#endregion
	}
}
