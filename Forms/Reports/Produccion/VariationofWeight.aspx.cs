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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;

namespace UserInterface.Forms.Reports.Production
{
	/// <summary>
	/// Summary description for VariationofWeight.
	/// </summary>
	public class VariationofWeight : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblLinea;
		protected System.Web.UI.WebControls.Label lblSeqInit;
		protected System.Web.UI.WebControls.Label lblPrgInit;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label SeqFin;
		protected System.Web.UI.WebControls.Label lblPrgFin;
		protected System.Web.UI.WebControls.DropDownList cboCodigo;
		protected System.Web.UI.WebControls.Button btnOk;
		protected System.Web.UI.WebControls.Image imgPrgInit;
		protected System.Web.UI.WebControls.Image Image2;
		protected CrystalDecisions.Web.CrystalReportViewer crvVarWeight;
		protected System.Web.UI.WebControls.Button btnCancel;		
		const string const_All = "Todas";		
		protected System.Web.UI.WebControls.TextBox txtSecInicial;
		protected System.Web.UI.WebControls.TextBox txtSecFinal;
		protected System.Web.UI.WebControls.TextBox txtFechaInicial;
		protected System.Web.UI.WebControls.DropDownList cboSecInicial;
		protected System.Web.UI.WebControls.Label lblErrMsg;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.TextBox txtFechaFinal;

		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
				BindEntryFields();
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


			//			CodigoSAP
			SICALNet.BusinessLogicLayer.ListMaterial BLLLstMat=new SICALNet.BusinessLogicLayer.ListMaterial();
			IList RsLstMat=(IList) BLLLstMat.SelectListMaterial(theUser.IdPlanta);

			cboCodigo.DataSource = RsLstMat;
			cboCodigo.DataTextField = "CodigoSAP";
			cboCodigo.DataValueField= "CodigoSAP";
			cboCodigo.DataBind();

			cboCodigo.Items.Add(const_All);
			cboCodigo.Items.FindByText(const_All).Selected=true;
 
			//To Load Secuencia
			SICALNet.BusinessLogicLayer.OrdenesTrabajo WO = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
			IList SecunciaList = (IList) WO.LoadSecuencia();

			cboSecInicial.DataSource = SecunciaList;
			cboSecInicial.DataBind();
			cboSecInicial.Items[0].Selected = true;

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
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			lblErrMsg.Text = "";
			// New 
			if (txtFechaInicial.Text != string.Empty && txtFechaFinal.Text == string.Empty)
			{
				lblErrMsg.Text = "Fecha Final No puede ser vacía, si la Fecha inicial existe";
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


			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			Reports.Produccion.Rpt_VariationOfWeights reporte = new Reports.Produccion.Rpt_VariationOfWeights();

			ParameterValues campoFecha= new ParameterValues();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();

			if ( txtFechaInicial.Text !=  String.Empty && txtFechaFinal.Text != string.Empty)   
				valorFecha.Value=string.Format("Del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
			else
				valorFecha.Value="";

			campoFecha.Add(valorFecha);
				
			ParameterValues campoSecuencia= new ParameterValues();
			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();

			if ( txtSecInicial.Text !=  String.Empty && txtSecFinal.Text != string.Empty)   
				valorSecuencia.Value=string.Format("Del {0} al {1}",txtSecInicial.Text,txtSecFinal.Text);
			else
				valorSecuencia.Value="";

			campoSecuencia.Add(valorSecuencia);

			ParameterValues campoLinea= new ParameterValues();
			ParameterValues campoTitle= new ParameterValues();
			ParameterDiscreteValue mainTitle= new ParameterDiscreteValue();
			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
			mainTitle.Value = " Reporte Variaciones de Pesadas";
			campoTitle.Add(mainTitle); 

			if (cboLinea.SelectedItem.Text != const_All)
				valorLinea.Value=string.Format("{0}",cboLinea.SelectedItem.Text);
			else
				valorLinea.Value="";

			campoLinea.Add(valorLinea);
				

			ParameterValues campoPlanta= new ParameterValues(); 
			ParameterDiscreteValue valorPlanta= new ParameterDiscreteValue();
			if (cboLinea.SelectedItem.Text == const_All) 
			{				
				valorPlanta.Value=const_All;
				reporte.Section9.ReportObjects["FldAllPlanta"].Width =3015;  				
			}
			else
			{
				valorPlanta.Value="";
				reporte.Section9.ReportObjects["FldAllPlanta"].Width =0;  				
			}

            
			campoPlanta.Add(valorPlanta);

			ParameterValues campoUser= new ParameterValues();
			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
			valorUser.Value=Context.User.Identity.Name;
			campoUser.Add(valorUser);

				
			ParameterValues campoSystem= new ParameterValues();
			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();
			valorSystem.Value="SICAL";
			campoSystem.Add(valorSystem);
					
			reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoTitle);
			reporte.DataDefinition.ParameterFields["Linea"].ApplyCurrentValues(campoLinea);
			reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
			reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
			reporte.DataDefinition.ParameterFields["Plant"].ApplyCurrentValues(campoPlanta);
			reporte.DataDefinition.ParameterFields["User"].ApplyCurrentValues(campoUser);
			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);

			string SelFormula="";

			if (cboCodigo.SelectedItem.Text != const_All) 
			{				
				SelFormula = SelFormula + "{ProgramaProduccion.CodigoSAP}='" + cboCodigo.SelectedItem.Value + "' " ;
			}

			if (cboLinea.SelectedItem.Text != const_All)
				SelFormula = SelFormula + "{ProgramaProduccion.IdLinea}=" + Convert.ToInt32(cboLinea.SelectedItem.Value);

			string FechaStartDate = txtFechaInicial.Text;
			string FechaEndDate = txtFechaFinal.Text;


			if (FechaStartDate != null && FechaEndDate != null && FechaStartDate != "" && FechaEndDate != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(FechaStartDate).ToString("yyyy") + "," + DateTime.Parse(FechaStartDate).ToString("MM") + "," + DateTime.Parse(FechaStartDate).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(FechaEndDate).ToString("yyyy") + "," + DateTime.Parse(FechaEndDate).ToString("MM") + "," + DateTime.Parse(FechaEndDate).ToString("dd") + ")";

			string SecInicial = txtSecInicial.Text;
			string SecFinal = txtSecFinal.Text;

			if (SecInicial != String.Empty)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({ProgramaProduccion.Secuencia}) >= " + SecInicial;
			if ( SecFinal != String.Empty)
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({ProgramaProduccion.Secuencia}) <= " + SecFinal;
				
			//SelFormula = SelFormula + " AND {OrdenesTrabajo.IdStatus}=5";
			
			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			
			rptHelper.setPermission(reporte);
			string reportName = rptHelper.exportReport(reporte,"CompareReport",User.Identity.Name);
			string redirectPath=ConfigurationSettings.AppSettings["reportsWebPath"]+ reportName + ".pdf";
			Response.Redirect(redirectPath);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			string redirectpath= "..\\..\\NewMenu.aspx";
			//redirectpath =;
			Response.Redirect(redirectpath);
		}
	}
}
