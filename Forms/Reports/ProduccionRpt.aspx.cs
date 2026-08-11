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
using SICALNet.BusinessEntities;


namespace UserInterface.Forms.Reports
{
	/// <summary>
	/// Summary description for ProduccionRpt1.
	/// </summary>
	public class ProduccionRpt1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList cmbDefecto;
		protected System.Web.UI.WebControls.Button cmdImprimir;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Button cmdCancelar;
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
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
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
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator4;
	
		const string const_All = "Todas";
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);

				//To bind data for Defecto DropDownList
				SICALNet.BusinessLogicLayer.PartidasInspeccion Def = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
				IList DefectoList = (IList) Def.LoadDefecto();
				cmbDefecto.DataSource=DefectoList;
				cmbDefecto.DataValueField = "IdDefecto";
				cmbDefecto.DataTextField = "Defecto";
				cmbDefecto.DataBind();
				cmbDefecto.Items.Add(new ListItem(string.Empty,"0"));
				cmbDefecto.Items.FindByValue("0").Selected=true;
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
			this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
			this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/*** modificado por alejandro.hernandez@nasoft.com 06/03/2006 ***/
		private void cmdImprimir_Click(object sender, System.EventArgs e)
		{
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			Reports.ProduccionRpt reporte = new Reports.ProduccionRpt();

			
			/*** agregado por alejandro.hernandez@nasoft.com 06/03/2006 ***/
			ParameterValues parameterValue = new ParameterValues();
			ParameterDiscreteValue parameterDiscreteValue = new ParameterDiscreteValue();


			//### 1era utilización de parameterValue ###
//			ParameterValues campoFecha= new ParameterValues();
//			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();

			TurnoInfo turno;
			SICALNet.BusinessLogicLayer.Usuario BLLUsuario;

			DateTime Dtt, Dff;
			long StartTicks;
			long Tick;
			string strTemp="";

			if(txtFechaInicial.Text  !=string.Empty && txtFechaFinal.Text != string.Empty)
				parameterDiscreteValue.Value=string.Format("Fecha Programa del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
			else
				parameterDiscreteValue.Value=string.Empty;

//			if(txtFechaInicial.Text  !=string.Empty && txtFechaFinal.Text != string.Empty)
//				valorFecha.Value=string.Format("Fecha Programa del {0} al {1}",txtFechaInicial.Text,txtFechaFinal.Text);
//			else
//				valorFecha.Value=string.Empty;

			parameterValue.Add(parameterDiscreteValue);
			reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(parameterValue);

//			campoFecha.Add(valorFecha);
			//### 2da utilización de parameterValue ###
			parameterValue = new ParameterValues();
			parameterDiscreteValue = new ParameterDiscreteValue();

//			ParameterValues campoLibFecha= new ParameterValues();
//			ParameterDiscreteValue valorLibFecha= new ParameterDiscreteValue();

			if(txtLibInicial.Text  !=string.Empty && txtLibFinal.Text != string.Empty)
				parameterDiscreteValue.Value=string.Format("Fecha Liberación del {0} al {1}",txtLibInicial.Text,txtLibFinal.Text);
			else
				parameterDiscreteValue.Value=string.Empty;

 //			if(txtLibInicial.Text  !=string.Empty && txtLibFinal.Text != string.Empty)
//				valorLibFecha.Value=string.Format("Fecha Liberación del {0} al {1}",txtLibInicial.Text,txtLibFinal.Text);
//			else
//				valorLibFecha.Value=string.Empty;

			parameterValue.Add(parameterDiscreteValue);
//			campoLibFecha.Add(valorLibFecha);
			reporte.DataDefinition.ParameterFields["Title3"].ApplyCurrentValues(parameterValue);

			//### 3era utilización de parameterValue ###
			parameterValue = new ParameterValues();
			parameterDiscreteValue = new ParameterDiscreteValue();

//			ParameterValues campoLinea= new ParameterValues();
//			ParameterDiscreteValue valorLinea= new ParameterDiscreteValue();

			if(cmbLinea.SelectedItem.Text != string.Empty )
				parameterDiscreteValue.Value=string.Format("Linea: {0}",cmbLinea.SelectedItem.Text);
			else
				parameterDiscreteValue.Value=string.Empty;

			parameterValue.Add(parameterDiscreteValue);
			reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(parameterValue);

//			if(cmbLinea.SelectedItem.Text != string.Empty )
//				valorLinea.Value=string.Format("Linea: {0}",cmbLinea.SelectedItem.Text);
//			else
//				valorLinea.Value=string.Empty;
//
//			campoLinea.Add(valorLinea);


			//### 4ta utilización de parameterValue ###
			parameterValue = new ParameterValues();
			parameterDiscreteValue = new ParameterDiscreteValue();

//			ParameterValues campoPlanta= new ParameterValues();
//			ParameterDiscreteValue valorPlanta= new ParameterDiscreteValue();

			if (this.cmbLinea.SelectedItem.Text == const_All) 
			{
				//valorPlanta.Value=string.Format(" {0}",ConfigurationSettings.AppSettings["AllPlantText"]);
				parameterDiscreteValue.Value=const_All;
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =3015;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =0;  
			}
			else
			{
				parameterDiscreteValue.Value="";
				reporte.Section1.ReportObjects["FldAllPlanta"].Width =0;  
				reporte.Section1.ReportObjects["FldSinglePlanta"].Width =3015;  
			}
			//valorPlanta.Value=string.Format("Planta: {0}",ConfigurationSettings.AppSettings["LocalPlantText"]);
			parameterValue.Add(parameterDiscreteValue);
			reporte.DataDefinition.ParameterFields["Planta"].ApplyCurrentValues(parameterValue);
//			campoPlanta.Add(valorPlanta);

//			if (this.cmbLinea.SelectedItem.Text == const_All) 
//			{
//				//valorPlanta.Value=string.Format(" {0}",ConfigurationSettings.AppSettings["AllPlantText"]);
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
//			//valorPlanta.Value=string.Format("Planta: {0}",ConfigurationSettings.AppSettings["LocalPlantText"]);
//			campoPlanta.Add(valorPlanta);

			
			//### 5ta y 6ta utilización de parameterValue ###
			parameterValue = new ParameterValues();
			parameterDiscreteValue = new ParameterDiscreteValue();

			parameterDiscreteValue.Value=Context.User.Identity.Name;
			parameterValue.Add(parameterDiscreteValue);

			reporte.DataDefinition.ParameterFields["UserName"].ApplyCurrentValues(parameterValue );
			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(parameterValue );


//			ParameterValues campoUser= new ParameterValues();
//			ParameterDiscreteValue valorUser= new ParameterDiscreteValue();
//			valorUser.Value=Context.User.Identity.Name;
//			campoUser.Add(valorUser);

//				
			/*** modificado por alejandro.hernandez@nasoft.com 06/03/2006 ***/
			//campoUser y campoSystem son idénticos en valor

//			ParameterValues campoSystem= new ParameterValues();
//			ParameterDiscreteValue valorSystem= new ParameterDiscreteValue();
//			valorSystem.Value=Context.User.Identity.Name;
//			campoSystem.Add(valorSystem);

//			reporte.DataDefinition.ParameterFields["Title1"].ApplyCurrentValues(campoFecha);
//			reporte.DataDefinition.ParameterFields["Title"].ApplyCurrentValues(campoLinea);
//			reporte.DataDefinition.ParameterFields["Title3"].ApplyCurrentValues(campoLibFecha);
//			reporte.DataDefinition.ParameterFields["Planta"].ApplyCurrentValues(campoPlanta);
//			reporte.DataDefinition.ParameterFields["UserName"].ApplyCurrentValues(campoUser);
//			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoUser);
//			reporte.DataDefinition.ParameterFields["System"].ApplyCurrentValues(campoSystem);

			System.Text.StringBuilder SelFormula=new System.Text.StringBuilder();

			if (cmbLinea.SelectedItem.Value != "0")
			{
				SelFormula.Append("{ProgramaProduccion.IdLinea}=").Append(cmbLinea.SelectedItem.Value);
			}
			if (txtFechaInicial.Text != null && txtFechaFinal.Text != null && txtFechaInicial.Text != "" && txtFechaFinal.Text != "")
			{
				strTemp = (SelFormula.ToString()!=string.Empty?"AND":"");

				SelFormula
					.Append(" ")
					.Append(strTemp)
					.Append(" {ProgramaProduccion.Fecha}>=Date(")
					.Append(DateTime.Parse(txtFechaInicial.Text).ToString("yyyy"))
					.Append(",")
					.Append(DateTime.Parse(txtFechaInicial.Text).ToString("MM"))
					.Append(",")
					.Append(DateTime.Parse(txtFechaInicial.Text).ToString("dd"))
					.Append(") AND {ProgramaProduccion.Fecha}<=Date(")
					.Append(DateTime.Parse(txtFechaFinal.Text).ToString("yyyy"))
					.Append(",")
					.Append(DateTime.Parse(txtFechaFinal.Text).ToString("MM"))
					.Append("," )
					.Append(DateTime.Parse(txtFechaFinal.Text).ToString("dd"))
					.Append(")");
			}

			if (txtLibInicial.Text != null && txtLibFinal.Text != null && txtLibInicial.Text != "" && txtLibFinal.Text != "")
			{

				// dependiendo si es el 3 turno ampliaremos el rango
				// a 7 horas del dia sigeuinte que termina el 3 turno
				if(cmbTurno.Items.Count>0) 
				{
					if(cmbTurno.SelectedItem.Value!="0")
					{

						BLLUsuario = new SICALNet.BusinessLogicLayer.Usuario();
						//SICALNet.BusinessLogicLayer.Usuario BLLUsuario2 = new SICALNet.BusinessLogicLayer.Usuario();
						turno = BLLUsuario.SelectTurno(int.Parse(cmbTurno.SelectedItem.Value));
						//TurnoInfo turno2 = BLLUsuario2.SelectTurno(int.Parse(cmbTurno.SelectedItem.Value));
						if (turno.HoraFinal.Hour > turno.HoraInicial.Hour)	
						{
							//1 y 2 turno
							strTemp = (SelFormula.ToString()!=string.Empty?"AND":"");
							SelFormula
								.Append(" ")
								.Append(strTemp)
								.Append(" {OrdenesTrabajo.FechaLiberacion}>=Date(" )
								.Append(DateTime.Parse(txtLibInicial.Text).ToString("yyyy") )
								.Append("," )
								.Append(DateTime.Parse(txtLibInicial.Text).ToString("MM") )
								.Append("," )
								.Append(DateTime.Parse(txtLibInicial.Text).ToString("dd") )
								.Append(") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" )
								.Append(DateTime.Parse(txtLibFinal.Text).ToString("yyyy") )
								.Append("," )
								.Append(DateTime.Parse(txtLibFinal.Text).ToString("MM") )
								.Append("," )
								.Append(DateTime.Parse(txtLibFinal.Text).ToString("dd") )
								.Append(")");
						}
						else
						{
							// turno abarca al dia siguiente
							Dtt = System.DateTime.Parse(txtLibFinal.Text); 
							StartTicks= Dtt.Ticks; 							
							Tick = StartTicks + 864000000000;
							Dff = new DateTime(Tick);

							strTemp = (SelFormula.ToString()!=string.Empty?"AND":"");

							SelFormula
								.Append(" " )
								.Append(strTemp)
								.Append(" {OrdenesTrabajo.FechaLiberacion}>=Date(" )
								.Append(DateTime.Parse(txtLibInicial.Text).ToString("yyyy") )
								.Append("," )
								.Append(DateTime.Parse(txtLibInicial.Text).ToString("MM") )
								.Append("," )
								.Append(DateTime.Parse(txtLibInicial.Text).ToString("dd") )
								.Append(") AND {OrdenesTrabajo.FechaLiberacion}<=Date(" )
								.Append(Dff.Year )
								.Append("," )
								.Append(Dff.Month)
								.Append(",")
								.Append(Dff.Day)
								.Append(")");
						}
					}
				
					else
					{
						// el dia actual pero tomando los 3 horarios
						// turno abarca al dia siguiente
						Dtt = System.DateTime.Parse(txtLibFinal.Text); 
						StartTicks= Dtt.Ticks; 							
						Tick = StartTicks + 864000000000;
						Dff = new DateTime(Tick);
						strTemp = (SelFormula.ToString()!=string.Empty?"AND":"");

						SelFormula
							.Append(" ")
							.Append(strTemp)
							.Append(" {OrdenesTrabajo.FechaLiberacion}>=CDateTime(")
							.Append(DateTime.Parse(txtLibInicial.Text).ToString("yyyy"))
							.Append(",")
							.Append(DateTime.Parse(txtLibInicial.Text).ToString("MM"))
							.Append(",")
							.Append(DateTime.Parse(txtLibInicial.Text).ToString("dd"))
							.Append(",07,00,00" +") AND {OrdenesTrabajo.FechaLiberacion}<=CDateTime(")
							.Append(Dff.Year)
							.Append(",")
							.Append(Dff.Month)
							.Append(",")
							.Append(Dff.Day)
							.Append(",07,00,00" + ")");
					}
				}
			}
			if(cmbColor.SelectedItem.Value!="0")
			{
				strTemp = (SelFormula.ToString()!=string.Empty?"AND":"");

				SelFormula
					.Append(" ")
					.Append(strTemp)
					.Append(" {Material.IdColor}='")
					.Append(cmbColor.SelectedItem.Text)
					.Append("'");
			}

			if(cmbMedida.SelectedItem.Value!="0")
			{
				strTemp = (SelFormula.ToString()!=string.Empty?"AND":"");
				SelFormula
					.Append(" ")
					.Append(strTemp)
					.Append(" {Material.IdMedida}=")
					.Append(cmbMedida.SelectedItem.Value);
			}
			if(cmbDefecto.SelectedItem.Value!="0")
			{
				strTemp = (SelFormula.ToString()!=string.Empty?"AND":"");

				SelFormula
					.Append(" ")
					.Append(strTemp)
					.Append(" {PartidasInspeccion.IdDefecto}=")
					.Append(cmbDefecto.SelectedItem.Value);
			}
			if(cmbFamilia.SelectedItem.Value!="0")
			{
				strTemp = (SelFormula.ToString()!=string.Empty?"AND":"");

				SelFormula
					.Append(" " )
					.Append(strTemp)
					.Append(" {Material.IdFamiliaProducto}=")
					.Append(cmbFamilia.SelectedItem.Value);
			}
			if(cmbTurno.Items.Count>0) 
			{
				if(cmbTurno.SelectedItem.Value!="0")
				{
					BLLUsuario = new SICALNet.BusinessLogicLayer.Usuario();
//					SICALNet.BusinessLogicLayer.Usuario BLLUsuario = new SICALNet.BusinessLogicLayer.Usuario();
					turno = BLLUsuario.SelectTurno(int.Parse(cmbTurno.SelectedItem.Value));
					//TurnoInfo turno = BLLUsuario.SelectTurno(int.Parse(cmbTurno.SelectedItem.Value));
					if (turno.HoraFinal.Hour > turno.HoraInicial.Hour)	
					{
						strTemp = (SelFormula.ToString()!=string.Empty?"AND (":"(");

						SelFormula
							.Append(" " )
							.Append(strTemp)
							.Append(" Time({OrdenesTrabajo.FechaLiberacion})> Time( " )
							.Append(turno.HoraInicial.Hour.ToString() )
							.Append("," )
							.Append(turno.HoraInicial.Minute.ToString())
							.Append(",00)");

						SelFormula
							.Append(" AND " )
							.Append(" Time({OrdenesTrabajo.FechaLiberacion})<= Time( " )
							.Append(turno.HoraFinal.Hour.ToString() )
							.Append("," )
							.Append(turno.HoraFinal.Minute.ToString())
							.Append(",00))");
					}
					else
					{
						DateTime dt = System.DateTime.Parse(txtLibFinal.Text); 
						StartTicks= dt.Ticks; 							
						Tick = StartTicks + 864000000000;
						Dff = new DateTime(Tick);

//						string d = ; 
//
//						DateTime dt = System.DateTime.Parse(d); 
//						long startTicks= dt.Ticks; 							
//						long tick = startTicks + 864000000000;
//						DateTime df = new DateTime(tick);

						strTemp = (SelFormula.ToString()!=string.Empty?"AND":"") ;

						SelFormula
							.Append(strTemp)
							.Append(" {OrdenesTrabajo.FechaLiberacion} > ")
							.Append("CDateTime(" )
							.Append(DateTime.Parse(txtLibInicial.Text).ToString("yyyy") )
							.Append("," )
							.Append(DateTime.Parse(txtLibInicial.Text).ToString("MM"))
							.Append("," )
							.Append(DateTime.Parse(txtLibInicial.Text).ToString("dd") )
							.Append("," )
							.Append(turno.HoraInicial.Hour.ToString() )
							.Append("," )
							.Append(turno.HoraInicial.Minute.ToString() )
							.Append(",00)");

						SelFormula
							.Append(" " )
							.Append("AND {OrdenesTrabajo.FechaLiberacion} <= ")
							.Append("CDateTime(")
							.Append(Dff.Year )
							.Append(",")
							.Append(Dff.Month)
							.Append( "," )
							.Append(Dff.Day)
							.Append(",")
							.Append(turno.HoraFinal.Hour.ToString())
							.Append(",")
							.Append(turno.HoraFinal.Minute.ToString())
							.Append(",00)");
					}
				}
				
			}
			else
			{				
				//todas las lineas y los 3 turnos
				Dff = DateTime.Now;
				if (txtLibFinal.Text!="")
				{
					DateTime dt = System.DateTime.Parse(txtLibFinal.Text); 
					StartTicks= dt.Ticks; 							
					Tick = StartTicks + 864000000000;
					Dff = new DateTime(Tick);
				}
				strTemp = (SelFormula.ToString()!=string.Empty?"AND":"") ;

				if (txtLibInicial.Text!="")
				{
					SelFormula
						.Append(strTemp)
						.Append(" {OrdenesTrabajo.FechaLiberacion} > " )
						.Append("CDateTime(" )
						.Append(DateTime.Parse(txtLibInicial.Text).ToString("yyyy") )
						.Append("," )
						.Append(DateTime.Parse(txtLibInicial.Text).ToString("MM"))
						.Append("," )
						.Append(DateTime.Parse(txtLibInicial.Text).ToString("dd") )
						.Append(",07,00,00)");
				}

				if (txtLibFinal.Text!="")
				{
					SelFormula
						.Append(" " )
						.Append("AND {OrdenesTrabajo.FechaLiberacion} <= " )
						.Append("CDateTime(" )
						.Append(Dff.Year )
						.Append("," )
						.Append(Dff.Month)
						.Append(",")
						.Append(Dff.Day)
						.Append(",07,00,00)");
				}
			}
			
			if (cmbEspInicial.SelectedItem.Text != null && 
				cmbEspFinal.SelectedItem.Text   != null && 
				cmbEspInicial.SelectedItem.Text != "" 	&& 
				cmbEspFinal.SelectedItem.Text   != "")
			{
				strTemp = (SelFormula.ToString()!=string.Empty?"AND":"");

				SelFormula
					.Append(" ")
					.Append(strTemp)
					.Append(" {Espesor.Centimetros} >= " )
					.Append(cmbEspInicial.SelectedItem.Text )
					.Append(" AND " )
					.Append("{Espesor.Centimetros} <= " )
					.Append(cmbEspFinal.SelectedItem.Text);
			}

			SelFormula.Append(" AND {OrdenesTrabajo.IdArea}=12 AND {OrdenesTrabajo.IdStatus}=5");

			reporte.DataDefinition.RecordSelectionFormula=SelFormula.ToString();
			rptHelper.setPermission(reporte);
			rptHelper.setPermission(reporte.OpenSubreport("DefectoRpt.rpt - 01"));
			reporte.OpenSubreport("DefectoRpt.rpt - 01").RecordSelectionFormula=SelFormula.ToString();

			string reportName = rptHelper.exportReport(reporte,"ProduccionReport",User.Identity.Name);
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
