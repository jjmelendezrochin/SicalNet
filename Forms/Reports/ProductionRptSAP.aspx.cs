using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Collections; 
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SICALNet.BusinessEntities;

namespace UserInterface.Forms.Reports
{
	/// <summary>
	/// Summary description for ProductionRptSAP.
	/// </summary>
	public class ProductionRptSAP : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList cmbDefecto;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList cmbLinea;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList cmbEspInicial;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtFechaInicial;
		protected System.Web.UI.WebControls.ImageButton cmdCalInicial;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtLibInicial;
		protected System.Web.UI.WebControls.ImageButton Imagebutton1;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList cmbColor;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList cmbTurno;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.DropDownList cmbEspFinal;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtFechaFinal;
		protected System.Web.UI.WebControls.ImageButton Imagebutton2;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtLibFinal;
		protected System.Web.UI.WebControls.ImageButton Imagebutton3;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.DropDownList cmbMedida;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.DropDownList cmbFamilia;
		protected System.Web.UI.WebControls.Button cmdImprimir;
		protected System.Web.UI.WebControls.Button cmdCancelar;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator4;
	
		const string const_All = "Todas";
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				//To bind data for Defecto DropDownList
				SICALNet.BusinessLogicLayer.PartidasInspeccion Def = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
				IList DefectoList = (IList) Def.LoadDefecto();
				cmbDefecto.DataSource=DefectoList;
				cmbDefecto.DataValueField = "IdDefecto";
				cmbDefecto.DataTextField = "Defecto";
				cmbDefecto.DataBind();
				cmbDefecto.Items.Add(new ListItem(string.Empty,"0"));
				cmbDefecto.Items.FindByValue("0").Selected=true;
				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);
				//To bind data for Linea DropDownList
				SICALNet.BusinessLogicLayer.LineaProduccion Linea = new SICALNet.BusinessLogicLayer.LineaProduccion();
				IList LineaList = (IList) Linea.SelectLinePdt(theUser);
				cmbLinea.DataSource = LineaList;
				cmbLinea.DataValueField = "IdLinea";
				cmbLinea.DataTextField = "Description";
				cmbLinea.DataBind();
				cmbLinea.Items.Add(new ListItem(string.Empty,"0"));
				cmbLinea.Items.FindByValue("0").Selected=true;
				//To Bind Espesor
				//to fill the espesor description into the cboEspesor control
				SICALNet.BusinessLogicLayer.Espesor BLLEspesor=new SICALNet.BusinessLogicLayer.Espesor();
				IList EspList=(IList) BLLEspesor.LoadEspesor();
				cmbEspInicial.DataSource=EspList;
				cmbEspInicial.DataTextField= "Centimetros";
				cmbEspInicial.DataValueField= "IdEspesor";
				cmbEspInicial.DataBind();
				cmbEspInicial.Items[0].Selected=true;
				cmbEspFinal.DataSource=EspList;
				cmbEspFinal.DataTextField= "Centimetros";
				cmbEspFinal.DataValueField= "IdEspesor";
				cmbEspFinal.DataBind();
				cmbEspFinal.Items[cmbEspFinal.Items.Count-1].Selected=true;
				//to fill the medida description into the cboMedida control
				SICALNet.BusinessLogicLayer.Medida BLLMedida=new SICALNet.BusinessLogicLayer.Medida();
				IList MedidaList=(IList) BLLMedida.LoadMedida();
				cmbMedida.DataSource=MedidaList;
				cmbMedida.DataTextField="Centimetros";
				cmbMedida.DataValueField= "IdMedida";				
				cmbMedida.DataBind();
				cmbMedida.Items.Add(new ListItem(string.Empty,"0"));
				cmbMedida.Items.FindByValue("0").Selected=true;
				//to fill Color Combo
				SICALNet.BusinessLogicLayer.Colour BLLColor=new SICALNet.BusinessLogicLayer.Colour();
				IList ColorList=(IList) BLLColor.SelectColour();
				cmbColor.DataSource=ColorList;
				cmbColor.DataTextField="IdColour";
				cmbColor.DataValueField="IdColour";				
				cmbColor.DataBind();
				cmbColor.Items.Add(new ListItem(string.Empty,"0"));
				cmbColor.Items.FindByValue("0").Selected=true;
				//to fill Familia Producto Combo
				SICALNet.BusinessLogicLayer.FamiliaProducto BLLFampdt=new SICALNet.BusinessLogicLayer.FamiliaProducto();
				IList FamiliaList=(IList) BLLFampdt.SelectFamiliaProducto();
				cmbFamilia.DataSource=FamiliaList;
				cmbFamilia.DataTextField= "Descripcion";
				cmbFamilia.DataValueField= "IdFamiliaProductos";
				cmbFamilia.DataBind();
				cmbFamilia.Items.Add(new ListItem(string.Empty,"0"));
				cmbFamilia.Items.FindByValue("0").Selected=true;
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
			this.cmbLinea.SelectedIndexChanged += new System.EventHandler(this.cmbLinea_SelectedIndexChanged);
			this.cmdCalInicial.Click += new System.Web.UI.ImageClickEventHandler(this.cmdCalInicial_Click);
			this.Imagebutton2.Click += new System.Web.UI.ImageClickEventHandler(this.Imagebutton2_Click);
			this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
			this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdImprimir_Click(object sender, System.EventArgs e)
		{
			/*** comentado por alejandro.hernandez@nasoft.com ***/
//			string Prg_Ini = null;
//			string Prg_Fin = null;
//			string Lib_Ini = null;
//			string Lib_Fin = null;
//			if(txtFechaInicial.Text!=string.Empty || txtFechaInicial.Text!="")
//				Prg_Ini = txtFechaInicial.Text;
//			if(txtFechaFinal.Text!=string.Empty || txtFechaFinal.Text!="")
//				Prg_Fin = txtFechaFinal.Text;
//			if(txtLibInicial.Text!=string.Empty || txtLibInicial.Text!="")
//				Lib_Ini = txtLibInicial.Text;
//			if(txtLibFinal.Text!=string.Empty || txtLibFinal.Text!="")
//				Lib_Fin = txtLibFinal.Text;

			//HRV Código comentado 26 Enero 2005
			/*SICALNet.BusinessLogicLayer.PartidasInspeccion pIns = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
			pIns.DefectsRpt(string.Empty,string.Empty,Convert.ToInt32(cmbMedida.SelectedItem.Value),cmbColor.SelectedItem.Value,Convert.ToInt32(cmbFamilia.SelectedItem.Value),Prg_Ini,Prg_Fin,Lib_Ini,Lib_Fin,Convert.ToInt32(cmbLinea.SelectedItem.Value));
			*/

			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			Reports.ProduccionRptSAP reporte = new Reports.ProduccionRptSAP();

			//Reports.DefectoRpt DefReporte = new Reports.DefectoRpt();

			ParameterValues campoFecha= new ParameterValues();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			if(txtFechaInicial.Text  !=string.Empty && txtFechaFinal.Text != string.Empty)
				valorFecha.Value=string.Format("Fecha Programa del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
			else
				valorFecha.Value=string.Empty;

			campoFecha.Add(valorFecha);
				
			ParameterValues campoLibFecha= new ParameterValues();
			ParameterDiscreteValue valorLibFecha= new ParameterDiscreteValue();
			if(txtLibInicial.Text  !=string.Empty && txtLibFinal.Text != string.Empty)
				valorLibFecha.Value=string.Format("Fecha Liberación del {0} al {1}",txtLibInicial.Text,txtLibFinal.Text);
			else
				valorLibFecha.Value=string.Empty;
			//valorLibFecha.Value=string.Format("Fecha Liberación Del {0} al {1}",txtLibInicial.Text,txtLibFinal.Text);
			campoLibFecha.Add(valorLibFecha);

			/*ParameterValues campoSecuencia= new ParameterValues();
			ParameterDiscreteValue valorSecuencia= new ParameterDiscreteValue();
			valorSecuencia.Value=string.Format("Del {0} al {1}",cmbSecInicial.SelectedItem.Text,cmbSecFinal.SelectedItem.Text);
			campoSecuencia.Add(valorSecuencia);*/
				
			ParameterValues campoLinea= new ParameterValues();
			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();
			if(cmbLinea.SelectedItem.Text != string.Empty )
				valorLinea.Value=string.Format("Linea: {0}",cmbLinea.SelectedItem.Text);
			else
				valorLinea.Value=string.Empty;

			campoLinea.Add(valorLinea);

			ParameterValues campoPlanta= new ParameterValues();
			ParameterDiscreteValue valorPlanta= new ParameterDiscreteValue();
			if (this.cmbLinea.SelectedItem.Text == const_All) 
			{
				//valorPlanta.Value=string.Format(" {0}",ConfigurationSettings.AppSettings["AllPlantText"]);
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
			//valorPlanta.Value=string.Format("Planta: {0}",ConfigurationSettings.AppSettings["LocalPlantText"]);
			campoPlanta.Add(valorPlanta);

			ParameterValues campoUser= new ParameterValues();
			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
			valorUser.Value=Context.User.Identity.Name;
			campoUser.Add(valorUser);

				
			ParameterValues campoSystem= new ParameterValues();
			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();
			valorSystem.Value=Context.User.Identity.Name;
			campoSystem.Add(valorSystem);

			reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
			reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
			//reporte.DataDefinition.ParameterFields["Title2"].ApplyCurrentValues(campoSecuencia);
			reporte.DataDefinition.ParameterFields["Title3"].ApplyCurrentValues(campoLibFecha);
			reporte.DataDefinition.ParameterFields["Planta"].ApplyCurrentValues(campoPlanta);
			reporte.DataDefinition.ParameterFields["UserName"].ApplyCurrentValues(campoUser);
			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);

			string SelFormula="";
			if (cmbLinea.SelectedItem.Value != "0")
				SelFormula = "{ProgramaProduccion.IdLinea}=" + cmbLinea.SelectedItem.Value;
//
//			string FechaStartDate = txtFechaInicial.Text;
//			string FechaEndDate = txtFechaFinal.Text;

			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(txtFechaInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("MM") + "," + DateTime.Parse(txtFechaInicial.Text).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(txtFechaFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("MM") + "," + DateTime.Parse(txtFechaFinal.Text).ToString("dd") + ")";

//			string FechaStartDate = txtFechaInicial.Text;
//			string FechaEndDate = txtFechaFinal.Text;
//
//			if (FechaStartDate != null && FechaEndDate != null && FechaStartDate != "" && FechaEndDate != "")
//				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {ProgramaProduccion.Fecha}>=Date(" + DateTime.Parse(FechaStartDate).ToString("yyyy") + "," + DateTime.Parse(FechaStartDate).ToString("MM") + "," + DateTime.Parse(FechaStartDate).ToString("dd") + ") AND {ProgramaProduccion.Fecha}<=Date(" + DateTime.Parse(FechaEndDate).ToString("yyyy") + "," + DateTime.Parse(FechaEndDate).ToString("MM") + "," + DateTime.Parse(FechaEndDate).ToString("dd") + ")";

			/*string SecInicial = cmbSecInicial.SelectedItem.Text;
			string SecFinal = cmbSecFinal.SelectedItem.Text;

			if (SecInicial != null && SecFinal != null && SecInicial != "" && SecFinal != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " Val({OrdenesTrabajo.Secuencia}) >= " + SecInicial + " AND " + "Val({OrdenesTrabajo.Secuencia}) <= " + SecFinal;*/

//			string LibStartDate = txtLibInicial.Text;
//			string LibEndDate = txtLibFinal.Text;

			//if (LibStartDate != null && LibEndDate != null && LibStartDate != "" && LibEndDate != "")
			if (txtLibFinal.Text != null && txtLibFinal.Text != null && txtLibFinal.Text != "" && txtLibFinal.Text != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {OrdenesTrabajo.FechaLiberacion}>=Date(" + DateTime.Parse(txtLibInicial.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibInicial.Text).ToString("MM") + "," + DateTime.Parse(txtLibInicial.Text).ToString("dd") + ") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" + DateTime.Parse(txtLibFinal.Text).ToString("yyyy") + "," + DateTime.Parse(txtLibFinal.Text).ToString("MM") + "," + DateTime.Parse(txtLibFinal.Text).ToString("dd") + ")";

			if(cmbColor.SelectedItem.Value!="0")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {Material.IdColor}='"+cmbColor.SelectedItem.Text+"'";

			if(cmbMedida.SelectedItem.Value!="0")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {Material.IdMedida}="+cmbMedida.SelectedItem.Value;

			if(cmbDefecto.SelectedItem.Value!="0")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {PartidasInspeccion.IdDefecto}="+cmbDefecto.SelectedItem.Value;			

			if(cmbFamilia.SelectedItem.Value!="0")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {Material.IdFamiliaProducto}="+cmbFamilia.SelectedItem.Value;
			if(cmbTurno.Items.Count>0)
			{
				if(cmbTurno.SelectedItem.Value!="0")
				{

					SICALNet.BusinessLogicLayer.Usuario BLLUsuario = new SICALNet.BusinessLogicLayer.Usuario();
					TurnoInfo turno = BLLUsuario.SelectTurno(int.Parse(cmbTurno.SelectedItem.Value));
					if (turno.HoraFinal.Hour > turno.HoraInicial.Hour)	
					{
						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND (":"(") + " Time({OrdenesTrabajo.FechaLiberacion})> Time( " + turno.HoraInicial.Hour.ToString() + "," + turno.HoraInicial.Minute.ToString() + ",00)";
						SelFormula = SelFormula + " AND " + " Time({OrdenesTrabajo.FechaLiberacion})<= Time( " + turno.HoraFinal.Hour.ToString() + "," + turno.HoraFinal.Minute.ToString() + ",00))";
					}
					else
					{
						SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND (":"(") + " Time({OrdenesTrabajo.FechaLiberacion})> Time( " + turno.HoraInicial.Hour.ToString() + "," + turno.HoraInicial.Minute.ToString() + ",00)";
						SelFormula = SelFormula + " OR " + " Time({OrdenesTrabajo.FechaLiberacion})<= Time( " + turno.HoraFinal.Hour.ToString() + "," + turno.HoraFinal.Minute.ToString() + ",00))";
					}
				}
			}
			string EspInicial = cmbEspInicial.SelectedItem.Text;
			string EspFinal = cmbEspFinal.SelectedItem.Text;
		
			
			if (EspInicial != null && EspFinal != null && EspInicial != "" && EspFinal != "")
				SelFormula = SelFormula + " " + (SelFormula!=string.Empty?"AND":"") + " {Espesor.Centimetros} >= " + EspInicial + " AND " + "{Espesor.Centimetros} <= " + EspFinal;

			

			//CRViewer.SelectionFormula="{ProgramaProduccion.Fecha}=Date(" + DateTime.Parse(Fecha).ToString("yyyy") + "," + DateTime.Parse(Fecha).ToString("MM") + "," + DateTime.Parse(Fecha).ToString("dd") + ") and {ProgramaProduccion.IdLinea}=" + IdLinea;

			SelFormula = SelFormula + " AND {OrdenesTrabajo.IdArea}=12 AND {OrdenesTrabajo.IdStatus}=5";
			

			reporte.DataDefinition.RecordSelectionFormula=SelFormula;
			reporte.OpenSubreport("DefectoRpt.rpt - 01").RecordSelectionFormula=SelFormula;
			
			//DefReporte.DataDefinition.RecordSelectionFormula=SelFormula;			
			//rptHelper.setPermission(DefReporte);

			rptHelper.setPermission(reporte);
			rptHelper.setPermission(reporte.OpenSubreport("DefectoRpt.rpt - 01"));
		
			string reportName = rptHelper.exportReport(reporte,"ProduccionReportSAP",User.Identity.Name);
			//rptHelper.exportReport(DefReporte,"ProduccionReportSAP");

			string redirectPath=ConfigurationSettings.AppSettings["reportsWebPath"]+ reportName + ".pdf";
			Response.Redirect(redirectPath);

				
		}

		private void Imagebutton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}

		private void cmdCalInicial_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}

		private void cmdCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../NewMenu.aspx");
		}

		private void cmbLinea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// fill linea combo

			if (this.cmbLinea.SelectedItem.Value != "0")
			{
				SICALNet.BusinessLogicLayer.Usuario BLLUsuario=new SICALNet.BusinessLogicLayer.Usuario();
				SortedList TurnoList= BLLUsuario.SelectTurnoByLinea(int.Parse(this.cmbLinea.SelectedItem.Value));
				this.cmbTurno.DataSource =  TurnoList;
				this.cmbTurno.DataValueField = "key";
				this.cmbTurno.DataTextField = "value";
				this.cmbTurno.DataBind();
				cmbTurno.Items.Add(new ListItem(string.Empty,"0"));
				cmbTurno.Items.FindByValue("0").Selected=true;
			}
			else
			{
				this.cmbTurno.Items.Clear();
				cmbTurno.Items.Add(new ListItem(string.Empty,"0"));
				cmbTurno.Items.FindByValue("0").Selected=true;


			}

		}
	}
}
