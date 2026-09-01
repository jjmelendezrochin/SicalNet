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
using OWC10;

using SICALNet.Utilities;
using SICALNet.BusinessEntities;
using SICALNet.BusinessLogicLayer;
namespace UserInterface.Forms.Structures
{
	/// <summary>
	/// Descripción breve de InvVidrios.
	/// </summary>
	public class InvVidrios : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtIdVidrio;
		protected System.Web.UI.WebControls.TextBox txtFechaInicio;
		protected System.Web.UI.WebControls.Image imgFrom;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtClaveFabricante;
		protected System.Web.UI.WebControls.TextBox txtFechaCapa;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DropDownList cboVidrioTamanio;
		protected System.Web.UI.WebControls.DropDownList cboClasificacionCalidad;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.DropDownList cboProveedor;
		protected System.Web.UI.WebControls.DropDownList cboTipo;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.TextBox txtLote;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.DropDownList cboPlanta;
		protected System.Web.UI.WebControls.DropDownList cboClasificacionConservacion;
		protected System.Web.UI.WebControls.Button cmdAdd;
		protected System.Web.UI.WebControls.TextBox txtNumeroVidrio;
		protected System.Web.UI.WebControls.Button cmdEditar;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.DropDownList cboEspesor;
		protected System.Web.UI.WebControls.Button cmdCancel;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator5;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.TextBox txtCostoDolares;
		protected System.Web.UI.WebControls.TextBox txtCostoPesos;
		protected System.Web.UI.WebControls.Label lblTarjeta;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.TextBox txtFechaAmortizacion;
		protected System.Web.UI.WebControls.Image Image3;
		protected System.Web.UI.WebControls.TextBox txtFechaDanio;
		protected System.Web.UI.WebControls.TextBox txtFechaRotura;
		protected System.Web.UI.WebControls.Image Image4;
		protected System.Web.UI.WebControls.DropDownList cboCausaAmortizacion;
		protected System.Web.UI.WebControls.DropDownList cboCausaDanio;
		protected System.Web.UI.WebControls.Button cmdReporteGlobal;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.DropDownList cboLineaReporte;
		protected System.Web.UI.WebControls.Button cmdReporteUsoxLinea;
		protected System.Web.UI.WebControls.ImageButton imgFInicial;
		protected System.Web.UI.WebControls.TextBox txtFechaInicial;
		protected System.Web.UI.WebControls.Label lblFechaInicial;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.TextBox txtFechaFinal;
		protected System.Web.UI.WebControls.ImageButton imgFFinal;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.DropDownList cboClasificacionReporte;
		protected System.Web.UI.WebControls.Button cmdReporteRDA;
		protected System.Web.UI.WebControls.Label lblErrorMsg;


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
			this.txtClaveFabricante.TextChanged += new System.EventHandler(this.txtClaveFabricante_TextChanged);
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.cmdEditar.Click += new System.EventHandler(this.cmdEditar_Click);
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			this.cmdReporteGlobal.Click += new System.EventHandler(this.cmdReporteGlobal_Click);
			this.cmdReporteUsoxLinea.Click += new System.EventHandler(this.cmdReporteUsoxLinea_Click);
			this.cmdReporteRDA.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		ErrorHandling errFileWrite=new ErrorHandling();
		protected Controls.InventarioVidrios InventarioVidrios1;
		protected Controls.TarjetaVidriosHistorial TarjetaVidriosHistorial1;
		protected Controls.TarjetaVidriosPlanimetria TarjetaVidriosPlanimetria1;
		protected Controls.TarjetaVidriosEspesor TarjetaVidriosEspesor1 ;
		protected Controls.TarjetaVidrioEspesorEditar TarjetaVidrioEspesorEditar1;
		protected Controls.TarjetaVidrioPlanimetriaEditar TarjetaVidrioPlanimetriaEditar1;


		private void Page_Load(object sender, System.EventArgs e)
		{
			this.cmdEditar.Attributes["onclick"] =
			"if (this.getAttribute('data-confirmado') === '1') {" +
				"this.removeAttribute('data-confirmado');" +
				"return true;" +
			"}" +
			"SicalAlert.confirmar(" +
				"'¿Seguro de guardar este dato?'," +
				"'Confirmar operación'," +
				"function () {" +
					"var btn = document.getElementById('" + this.cmdEditar.ClientID + "');" +
					"btn.setAttribute('data-confirmado', '1');" +
					"btn.click();" +
				"}" +
			");" +
			"return false;";

			this.cmdAdd.Attributes["onclick"] =
			"if (this.getAttribute('data-confirmado') === '1') {" +
				"this.removeAttribute('data-confirmado');" +
				"return true;" +
			"}" +

			"var lote = document.forms[0].txtLote.value;" +
			"var seleccion;" +

			"if (lote.length > 0) {" +
				"seleccion = '¿Seguro que desea guardar este registro?';" +
			"} else {" +
				"seleccion = '¿El lote no está asignado, está seguro que desea guardar este registro?';" +
			"}" +

			"SicalAlert.confirmar(" +
				"seleccion," +
				"'Confirmar operación'," +
				"function () {" +
					"var btn = document.getElementById('" + this.cmdAdd.ClientID + "');" +
					"btn.setAttribute('data-confirmado', '1');" +
					"btn.click();" +
				"}" +
			");" +

			"return false;";


			this.lblTarjeta.Visible=false;
			this.TarjetaVidriosHistorial1.Visible=false;
			this.TarjetaVidriosPlanimetria1.Visible= false;
			this.TarjetaVidriosEspesor1.Visible=false;
			this.TarjetaVidrioEspesorEditar1.Visible=false;
			this.TarjetaVidrioPlanimetriaEditar1.Visible=false;


			if (!Page.IsPostBack)
			{
				// *************************************
				// Fechas
				txtFechaCapa.Text = DateTime.Now.Date.ToString("dd-MMM-yyyy");
				txtFechaInicio.Text=DateTime.Now.Date.ToString("dd-MMM-yyyy");
				// *************************************
				// Llenando Tipo del vidrio
				//Code to populate Linea ComboBox
				SICALNet.BusinessLogicLayer.VidrioCatalogos vidrioCatalogosInfo2= new SICALNet.BusinessLogicLayer.VidrioCatalogos();
				IList vidrioCatalogosList2= (IList) vidrioCatalogosInfo2.LoadVidriosConservacion();
			
				cboClasificacionConservacion.DataSource = vidrioCatalogosList2;
				cboClasificacionConservacion.DataValueField = "idClasificacionConservacion";
				cboClasificacionConservacion.DataTextField = "Nombre";
				cboClasificacionConservacion.DataBind();
				
				IList ListaClasificacionReporte= (IList) vidrioCatalogosInfo2.LoadVidriosConservacionReporte();

				cboClasificacionReporte.DataSource = ListaClasificacionReporte;
				cboClasificacionReporte.DataValueField = "idClasificacionConservacion";
				cboClasificacionReporte.DataTextField = "Nombre";
				cboClasificacionReporte.DataBind();

				// *************************************
				// Llenando Tipo del vidrio
				//Code to populate Linea ComboBox
				SICALNet.BusinessLogicLayer.VidrioCatalogos vidrioCatalogosInfo1= new SICALNet.BusinessLogicLayer.VidrioCatalogos();
				IList vidrioCatalogosList1= (IList) vidrioCatalogosInfo1.LoadVidriosTipo();
			
				cboTipo.DataSource = vidrioCatalogosList1;
				cboTipo.DataValueField = "idTipo";
				cboTipo.DataTextField = "Nombre";
				cboTipo.DataBind();

				// *************************************
				// Llenando Lista Proveedor del vidrio
				//Code to populate Linea ComboBox
				SICALNet.BusinessLogicLayer.VidrioCatalogos vidrioCatalogosInfo0= new SICALNet.BusinessLogicLayer.VidrioCatalogos();
				IList vidrioCatalogosList0= (IList) vidrioCatalogosInfo0.LoadVidriosProveedor();
			
				cboProveedor.DataSource = vidrioCatalogosList0;
				cboProveedor.DataValueField = "idProveedor";
				cboProveedor.DataTextField = "Nombre";
				cboProveedor.DataBind();

				// *************************************
				// Llenando Lista Clasificación Calidad del vidrio
				//Code to populate Linea ComboBox
				SICALNet.BusinessLogicLayer.VidrioCatalogos vidrioCatalogosInfo= new SICALNet.BusinessLogicLayer.VidrioCatalogos();
				IList vidrioCatalogosList= (IList) vidrioCatalogosInfo.LoadClasificacionCalidad();
			
				cboClasificacionCalidad.DataSource = vidrioCatalogosList;
				cboClasificacionCalidad.DataValueField = "idClasificacionCalidad";
				cboClasificacionCalidad.DataTextField = "Nombre";
				cboClasificacionCalidad.DataBind();

				// *************************************
				// Llenando Lista Tamaño del vidrio
				//Code to populate Linea ComboBox
				SICALNet.BusinessLogicLayer.VidrioTamanio vidrioTamanioInfo= new SICALNet.BusinessLogicLayer.VidrioTamanio();
				IList vidrioTamanioList= (IList) vidrioTamanioInfo.LoadVidrioTamanio();
			
				cboVidrioTamanio.DataSource = vidrioTamanioList;
				cboVidrioTamanio.DataValueField = "idTamanio";
				cboVidrioTamanio.DataTextField = "Medida";
				cboVidrioTamanio.DataBind();

				// *************************************
				// Llenando Lista cboLinea y cboLineaReporte
				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);

				SICALNet.BusinessLogicLayer.LineaProduccion  BRlinea = new SICALNet.BusinessLogicLayer.LineaProduccion();
				IList tipoRs= (IList)BRlinea.SelectLinePdt(theUser);

				cboLinea.DataSource= tipoRs;
				cboLinea.DataValueField="IdLinea";
				cboLinea.DataTextField="Description";
				cboLinea.DataBind();

				SICALNet.BusinessLogicLayer.LineaProduccion  BRlineaTodas = new SICALNet.BusinessLogicLayer.LineaProduccion();
				IList tipoRs1= (IList)BRlineaTodas.SelectLinePdtTodas();

				cboLineaReporte.DataSource= tipoRs1;
				cboLineaReporte.DataValueField="IdLinea";
				cboLineaReporte.DataTextField="Description";
				cboLineaReporte.DataBind();
				// *************************************
				// Llenando Lista cboPlanta
				//Code to populate Linea ComboBox
				SICALNet.BusinessLogicLayer.Planta plantInfo= new SICALNet.BusinessLogicLayer.Planta();
				IList plantaList= (IList) plantInfo.SelectPlanta();
			
				cboPlanta.DataSource = plantaList;
				cboPlanta.DataValueField = "IdPlanta";
				cboPlanta.DataTextField = "Description";
				cboPlanta.DataBind();
				// *************************************
				// Llenando Lista cboEspesor
				SICALNet.BusinessLogicLayer.VidrioEspesor espesorInfo= new SICALNet.BusinessLogicLayer.VidrioEspesor();
				IList espesorList= (IList) espesorInfo.LoadVidriosEspesor();

				cboEspesor.DataSource= espesorList;
				cboEspesor.DataValueField="idEspesor";
				cboEspesor.DataTextField="Espesor";				
				cboEspesor.DataBind();

				// *************************************
				// Llenando Causa del Daño para amortización
				SICALNet.BusinessLogicLayer.VidrioCatalogos vidrioCatalogosInfo3= new SICALNet.BusinessLogicLayer.VidrioCatalogos();
				IList vidrioCatalogosList3= (IList) vidrioCatalogosInfo3.LoadVidrioCausaDanio();
			
				cboCausaAmortizacion.DataSource = vidrioCatalogosList3;
				cboCausaAmortizacion.DataValueField = "idCausa";
				cboCausaAmortizacion.DataTextField = "Causa";
				cboCausaAmortizacion.DataBind();

				// *************************************
				// Llenando Causa del Daño
				cboCausaDanio.DataSource = vidrioCatalogosList3;
				cboCausaDanio.DataValueField = "idCausa";
				cboCausaDanio.DataTextField = "Causa";
				cboCausaDanio.DataBind();

				// *************************************

				int idPlanta = theUser.IdPlanta;
				if(idPlanta==1)
					cboEspesor.SelectedIndex=1;
				else
					cboEspesor.SelectedIndex=0;

				this.lblTarjeta.Visible = false;
				this.TarjetaVidriosHistorial1.Visible=false;
				this.TarjetaVidriosPlanimetria1.Visible= false;
				this.TarjetaVidriosEspesor1.Visible=false;
				this.TarjetaVidrioEspesorEditar1.Visible=false;
				this.TarjetaVidrioPlanimetriaEditar1.Visible=false;

				int idVidrio = 0;
				long NumeroVidrio = 0;
				if (Request["id"] == null)
				{
					idVidrio = -1;
					this.cmdAdd.Visible = true;
					this.cmdEditar.Visible = false;
					this.lblTarjeta.Visible = false;
					this.TarjetaVidriosHistorial1.Visible=false;
					this.TarjetaVidriosPlanimetria1.Visible= false;
					this.TarjetaVidriosEspesor1.Visible=false;
					this.TarjetaVidrioEspesorEditar1.Visible=false;
					this.TarjetaVidrioPlanimetriaEditar1.Visible=false;
				}
				else
				{
					//SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
					idPlanta = theUser.IdPlanta;
					idVidrio = int.Parse(Request["id"]);				
					NumeroVidrio = long.Parse(Request["NumeroVidrio"]);
					Session["NumeroVidrio"]=NumeroVidrio; 

					// Llena la tabla que mostrará la planimetría
					EspesorVidrio bllPlanimetriaVidrio = new EspesorVidrio();
					bllPlanimetriaVidrio.LoadEspesorVidrio(idVidrio, idPlanta);

					// Llena la tabla que mostrará la planimetría				
					bllPlanimetriaVidrio.LoadPlanimetriaVidrio(idVidrio, idPlanta);


					// Llena la tabla que mostrará la tabla de espesor
					EspesorVidrio0 bllEspesorVidrio = new EspesorVidrio0();
					bllEspesorVidrio.LoadEspesorVidrio(idVidrio, idPlanta);

					// Llena la tabla que mostrará la tabla de espesor para su edición				
					bllEspesorVidrio.LoadEspesorVidrioEditar(idVidrio, idPlanta);

					// Llena la tabla que mostrará el historial de la tabla
					VidrioHistorial bllVidrioHistorial = new VidrioHistorial();
					bllVidrioHistorial.LoadVidriosHistorial0(idVidrio);

					// Selección del vidio y colocación en pantalla
					Vidrio bllVidrio=new Vidrio();
					SICALNet.BusinessEntities.VidInfo beVidrio=(SICALNet.BusinessEntities.VidInfo) bllVidrio.SelectVidrio(idVidrio);

					this.txtIdVidrio.Text = idVidrio.ToString();
					this.txtClaveFabricante.Text= beVidrio.ClaveFabricante;
					this.cboVidrioTamanio.SelectedValue  = (beVidrio.idTamanio.ToString());
					this.cboProveedor.SelectedValue= (beVidrio.idProveedor.ToString());
					this.cboLinea.SelectedValue= (beVidrio.idLinea.ToString());
					this.txtNumeroVidrio.Text = beVidrio.NumeroVidrio.ToString(); 
					this.txtFechaInicio.Text = beVidrio.FechaInicio.ToString("dd-MMM-yyyy");
					this.txtFechaCapa.Text = beVidrio.FechaCapa.ToString("dd-MMM-yyyy");
					
					this.cboClasificacionCalidad.SelectedValue = beVidrio.idClasificacionCalidad.ToString();
					this.cboClasificacionConservacion.SelectedValue= beVidrio.idClasificacionConservacion.ToString();
					this.cboTipo.SelectedValue= (beVidrio.idTipo.ToString());
					this.txtLote.Text= beVidrio.Lote.ToString();
					this.cboPlanta.SelectedValue= (theUser.IdPlanta.ToString());
					this.cboEspesor.SelectedValue= (beVidrio.idEspesor.ToString());
					this.txtCostoDolares.Text=beVidrio.CostoDolares.ToString();
					this.txtCostoPesos.Text=beVidrio.CostoDolares.ToString();
					
					if(beVidrio.FechaRotura.ToString("dd-MMM-yyyy").ToUpper()!="01-ENE-1900")
						this.txtFechaRotura.Text = beVidrio.FechaRotura.ToString("dd-MMM-yyyy");
					else
						this.txtFechaRotura.Text ="";

					if(beVidrio.FechaAmortizacion.ToString("dd-MMM-yyyy").ToUpper()!="01-ENE-1900")
						this.txtFechaAmortizacion.Text = beVidrio.FechaAmortizacion.ToString("dd-MMM-yyyy");
					else
						this.txtFechaAmortizacion.Text ="";

					this.cboCausaAmortizacion.SelectedValue= beVidrio.idCausaAmortizacion.ToString();

					if(beVidrio.FechaDanio.ToString("dd-MMM-yyyy").ToUpper()!="01-ENE-1900")
						this.txtFechaDanio.Text = beVidrio.FechaDanio.ToString("dd-MMM-yyyy");
					else
						this.txtFechaDanio.Text ="";
					this.cboCausaDanio.SelectedValue= beVidrio.idCausaDanio.ToString();

					this.cmdAdd.Visible = false;
					this.cmdEditar.Visible = true;
					this.lblTarjeta.Visible = true;
					this.TarjetaVidriosHistorial1.Visible=true;
					this.TarjetaVidriosPlanimetria1.Visible= false;
					this.TarjetaVidriosEspesor1.Visible=false;
					this.TarjetaVidrioEspesorEditar1.Visible=true;
					this.TarjetaVidrioPlanimetriaEditar1.Visible=true;
				}
			}
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{					
			//Guardar un nuevo Folio
			try
			{
				string idIdentificador = this.txtIdVidrio.Text.ToUpper();
				string sClaveFabricante = this.txtClaveFabricante.Text.ToUpper();
				int iTamanio  = int.Parse(this.cboVidrioTamanio.SelectedValue);
				int iProveedor  = int.Parse(this.cboProveedor.SelectedValue);
				int iLinea  = int.Parse(this.cboLinea .SelectedValue);
				long NumeroVidrio = long.Parse(this.txtNumeroVidrio.Text);
				string sFechaInicio = this.txtFechaInicio.Text.ToUpper();				
				string sFechaCapa = this.txtFechaCapa.Text.ToUpper();	
				string sFechaRotura="";
				if(this.txtFechaRotura.Text=="") 
					sFechaRotura = "01/01/1900";
				else
					sFechaRotura = this.txtFechaRotura.Text;			
				int iClasificacionCalidad = int.Parse(this.cboClasificacionCalidad .SelectedValue);								
				int iClasificacionConservacion = int.Parse(this.cboClasificacionConservacion.SelectedValue);
				int iTipo = int.Parse(this.cboTipo.SelectedValue);				
				int iLote;
				if(this.txtLote.Text.Trim()!="")
					iLote = int.Parse(this.txtLote.Text.Trim());
				else
					iLote = 0;
				int iPlanta  = int.Parse(this.cboPlanta.SelectedValue);
				int iEspesor  = int.Parse(this.cboEspesor.SelectedValue);
				double dCostoDolares;  
				if (this.txtCostoDolares.Text=="")
					dCostoDolares=0;
				else
					dCostoDolares  = double.Parse(this.txtCostoDolares.Text);

				double dCostoPesos;  
				if (this.txtCostoPesos.Text=="")
					dCostoPesos=0;
				else
					dCostoPesos  = double.Parse(this.txtCostoPesos.Text);

				string sFechaAmortizacion ="";
				if(this.txtFechaAmortizacion.Text=="") 
					sFechaAmortizacion = "01/01/1900";
				else
					sFechaAmortizacion = this.txtFechaAmortizacion.Text;
				int idCausaAmortizacion = int.Parse(this.cboCausaAmortizacion.SelectedValue);
				string sFechaDanio;
				if(this.txtFechaDanio.Text=="") 
					sFechaDanio = "01/01/1900";
				else
					sFechaDanio = this.txtFechaDanio.Text;
				int idCausaDanio = int.Parse(this.cboCausaDanio.SelectedValue);

				SICALNet.BusinessLogicLayer.Vidrio bllVidrio = new SICALNet.BusinessLogicLayer.Vidrio();
				SICALNet.BusinessEntities.VidInfo belVidrioInfo  = 
					new SICALNet.BusinessEntities.VidInfo(
					sClaveFabricante,
					iTamanio,
					iProveedor, 
					iLinea,
					NumeroVidrio,
					System.DateTime.Parse(sFechaInicio),
					System.DateTime.Parse(sFechaCapa),
					System.DateTime.Parse(sFechaRotura),
					iClasificacionCalidad,
					iClasificacionConservacion,
					iTipo,
					iLote,
					iPlanta,
					this.User.Identity.Name.ToString(),
					System.DateTime.Now,
					iEspesor,
					dCostoDolares,						// Costo Dólares
					dCostoPesos,						// Costo Pesos
					System.DateTime.Parse(sFechaAmortizacion),	// Fecha Amortizacion
					idCausaAmortizacion,						// idCausaAmortizacion
					System.DateTime.Parse(sFechaDanio),	// Fecha Danio
					idCausaDanio);						// idCausaDanio					

				if(bllVidrio.InsertVidrio(belVidrioInfo))
				{
					// guardamos en la bitacora
					SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
					BLLBitacora.Insertcomando("Alta de Vidrio: " + belVidrioInfo.NumeroVidrio + " clave fabricante " + sClaveFabricante ,this.User.Identity.Name.ToString());

					//clearControl();
					this.InventarioVidrios1.BindGrid();
					LimpiaCajas();
					prcErrorDisplay(null,"el registro se agregó existosamente");
				}
				
			}
			catch (Exception ex)
			{
				prcErrorDisplay(ex,"Error");

				//throw;
			}
		}

		private void LimpiaCajas()
		{
			this.txtIdVidrio.Text = "";
			this.txtClaveFabricante.Text= "";
			this.cboVidrioTamanio.SelectedIndex  = 0;
			this.cboProveedor.SelectedIndex= 0;
			this.cboLinea.SelectedIndex= 0;
			this.txtNumeroVidrio.Text = "";
			this.txtFechaCapa.Text = DateTime.Now.Date.ToString("dd-MMM-yyyy");
			this.txtFechaInicio.Text=DateTime.Now.Date.ToString("dd-MMM-yyyy");
			this.txtFechaRotura.Text="";
			this.cboClasificacionCalidad.SelectedIndex = 0;
			this.cboClasificacionConservacion.SelectedIndex= 0;
			this.cboTipo.SelectedIndex= 0;
			this.txtLote.Text= "0";
			this.cboPlanta.SelectedIndex= 0;
			SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
			SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
			theUser  = BLLUser.Load(theUser);
			int idPlanta = theUser.IdPlanta;
			if(idPlanta==1)
				cboEspesor.SelectedIndex=1;
			else
				cboEspesor.SelectedIndex=0;
			this.txtCostoDolares.Text="0";
			this.txtCostoPesos.Text="0";

			this.txtFechaAmortizacion.Text ="";			
			this.cboCausaAmortizacion.SelectedIndex=0;
			this.txtFechaDanio.Text ="";
			this.cboCausaDanio.SelectedIndex=0;
			
			prcErrorDisplay(null,"");
		}

		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("Información sobre el catlogo de espesor",errHnd,Server.MapPath("SICALNet")+"Error.txt");
				lblErrorMsg.Text=errHnd.Message;
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;
			}
			else if (errStatus=="NoError")
			{
				//to clear label box
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.White;
			}
			else
			{
				//to display the success msg
				lblErrorMsg.Text=errStatus;
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;
			}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.cmdEditar.Visible = false;
			this.cmdAdd.Visible= true;
			LimpiaCajas();
		}

		private void cmdEditar_Click(object sender, System.EventArgs e)
		{		
			try
			{
				int idVidrio = int.Parse(this.txtIdVidrio.Text);
				string sClaveFabricante = this.txtClaveFabricante.Text.ToUpper();
				int iTamanio  = int.Parse(this.cboVidrioTamanio.SelectedValue);
				int iProveedor  = int.Parse(this.cboProveedor.SelectedValue);
				int iLinea  = int.Parse(this.cboLinea.SelectedValue);
				long NumeroVidrio = long.Parse(this.txtNumeroVidrio.Text);
				string sFechaInicio = this.txtFechaInicio.Text;				
				string sFechaCapa = this.txtFechaCapa.Text;
				string sFechaRotura="";
				if(this.txtFechaRotura.Text=="") 
					sFechaRotura = "01/01/1900";
				else
					sFechaRotura = this.txtFechaRotura.Text;

				int iClasificacionCalidad = int.Parse(this.cboClasificacionCalidad .SelectedValue);								
				int iClasificacionConservacion = int.Parse(this.cboClasificacionConservacion.SelectedValue);
				int iTipo = int.Parse(this.cboTipo.SelectedValue);				
				int iLote = int.Parse(this.txtLote.Text.Trim());
				int iPlanta  = int.Parse(this.cboPlanta.SelectedValue);
				int iEspesor  = int.Parse(this.cboEspesor.SelectedValue);
				double dCostoDolares;  
				if (this.txtCostoDolares.Text=="")
					dCostoDolares=0;
				else
					dCostoDolares  = double.Parse(this.txtCostoDolares.Text);

				double dCostoPesos;  
				if (this.txtCostoPesos.Text=="")
					dCostoPesos=0;
				else
					dCostoPesos  = double.Parse(this.txtCostoPesos.Text);

				string sFechaAmortizacion ="";
				if(this.txtFechaAmortizacion.Text=="") 
					sFechaAmortizacion = "01/01/1900";
				else
					sFechaAmortizacion = this.txtFechaAmortizacion.Text;

				int idCausaAmortizacion = int.Parse(this.cboCausaAmortizacion.SelectedValue);
				string sFechaDanio ="";
				if(this.txtFechaDanio.Text=="") 
					sFechaDanio = "01/01/1900";
				else
					sFechaDanio = this.txtFechaDanio.Text;
				int idCausaDanio = int.Parse(this.cboCausaDanio.SelectedValue);

				SICALNet.BusinessLogicLayer.Vidrio bllVidrio = new SICALNet.BusinessLogicLayer.Vidrio();
				SICALNet.BusinessEntities.VidInfo belVidrioInfo  = 
					new SICALNet.BusinessEntities.VidInfo(
					idVidrio, 
					sClaveFabricante,
					iTamanio,
					iProveedor, 
					iLinea,
					NumeroVidrio,
					System.DateTime.Parse(sFechaInicio),
					System.DateTime.Parse(sFechaCapa),
					System.DateTime.Parse(sFechaRotura),
					iClasificacionCalidad,
					iClasificacionConservacion,
					iTipo,
					iLote,
					iPlanta,
					this.User.Identity.Name.ToString(),
					System.DateTime.Now,
					iEspesor,
					dCostoDolares,
					dCostoPesos,
					System.DateTime.Parse(sFechaAmortizacion),	// Fecha Amortizacion
					idCausaAmortizacion,						// idCausaAmortizacion
					System.DateTime.Parse(sFechaDanio),	// Fecha Danio
					idCausaDanio);						// idCausaDanio		
					
				if(bllVidrio.UpdateVidrio(belVidrioInfo))
				{
					// guardamos en la bitacora
					SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
					BLLBitacora.Insertcomando("Actualización de Vidrio id:" + idVidrio + " con clave " + sClaveFabricante ,this.User.Identity.Name.ToString());

					//clearControl();
					this.InventarioVidrios1.BindGrid();
					LimpiaCajas();
					prcErrorDisplay(null,"el registro se guardó existosamente");
				}
			}
			catch (Exception ex)
			{
				prcErrorDisplay(ex,"Error");

				//throw;
			}
		}

		private void txtClaveFabricante_TextChanged(object sender, System.EventArgs e)
		{
			this.txtClaveFabricante.Text = this.txtClaveFabricante.Text.ToUpper();
		}

		private void cmdReporteGlobal_Click(object sender, System.EventArgs e)
		{
			string sDato = "";
			//			int idLinea;
			//			if(this.cboLinea.SelectedValue=="Todas")
			//				idLinea =0;
			//			else
			//				idLinea = int.Parse(this.cboLinea.SelectedValue);			
			//			String sFechaIni = this.txtFechaInicial.Text;
			//			String sFechaFin = this.txtFechaFinal.Text;
			//
			//			if(sFechaIni=="" || sFechaFin=="")
			//			{
			//				Page.RegisterStartupScript("ClientScript","<script language=JavaScript>alert('Favor de especificar fecha inicial y final');</script>");		
			//				return;
			//			}

			ArrayList ListaInventarioGlobal; 
			SICALNet.BusinessLogicLayer.VidriosInventarioGlobal bllVidrios= new SICALNet.BusinessLogicLayer.VidriosInventarioGlobal();
			ListaInventarioGlobal = (ArrayList)bllVidrios.MuestraInventario(int.Parse(this.cboLineaReporte.SelectedValue));

			// Export Data To Excel
			OWC10.SpreadsheetClass xlsheet = new SpreadsheetClass();
			// To Write Excel Header
			for(int j=0; j<39; j++)
			{
				if(j==0)
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "Campo";
				}
				else if(j==37)
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "Suma";
				}
				else if(j>=38)
				{
					//xlsheet.ActiveSheet.Cells[1,j+1] = "Orden";
				}
				else
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "Medida";
				}
			}

			try
			{
				int row = 2, col=1;
				for(int i=0; i<ListaInventarioGlobal.Count; i++)
				{
					SICALNet.BusinessEntities.VidriosInventarioGlobal UnVidrio ;
					UnVidrio = (SICALNet.BusinessEntities.VidriosInventarioGlobal) ListaInventarioGlobal[i];
					sDato = UnVidrio.c0.ToString();
					xlsheet.ActiveSheet.Cells[row,col] = sDato;
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c1.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c2.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c3.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c4.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c5.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c6.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c7.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c8.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c9.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c10.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c11.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c12.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c13.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c14.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c15.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c16.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c17.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c18.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c19.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c20.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c21.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c22.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c23.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c24.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c25.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c26.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c27.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c28.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c29.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c30.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c31.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c32.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c33.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c34.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c35.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c36.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.suma.ToString(); 
					col=col+1;
					// Reiniciando fila y columna
					row++;
					col=1;
				}

				// xlsheet.ActiveSheet.Columns.AutoFit();

				string xlFileName = "VidriosInventarioGlobal_" + System.DateTime.Now.ToString("ddMMMyyyy") +".xls";
			
				string fullFileName = string.Format("{0}\\{1}",Server.MapPath("."),xlFileName);
				// save it off to the filesystem...
				xlsheet.Export(fullFileName,OWC10.SheetExportActionEnum.ssExportActionNone,OWC10.SheetExportFormat.ssExportHTML);
			
				DownloadFile(fullFileName);
			}
			catch (Exception ex)
			{
				prcErrorDisplay(ex,"Error");

				//throw;
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

		private void cmdReporteUsoxLinea_Click(object sender, System.EventArgs e)
		{
			string sDato = "";


			ArrayList ListaUsoxLinea; 
			SICALNet.BusinessLogicLayer.VidriosUsoxLinea bllVidrios= new SICALNet.BusinessLogicLayer.VidriosUsoxLinea();
			ListaUsoxLinea = (ArrayList)bllVidrios.MuestraUsoxLinea(int.Parse(this.cboLineaReporte.SelectedValue));

			// Export Data To Excel
			OWC10.SpreadsheetClass xlsheet = new SpreadsheetClass();
			// To Write Excel Header
			for(int j=0; j<76; j++)
			{
				if(j==0)
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "Calidad";
				}
				else if(j==75)
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "";
				}
				else if(j==74)
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "Suma";
				}
				else if(j==65)
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "Orden";
				}
				else
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "Medida";
				}
			}

			try
			{
				int row = 2, col=1;
				for(int i=0; i<ListaUsoxLinea.Count; i++)
				{
					SICALNet.BusinessEntities.VidriosUsoxLinea UnVidrio ;
					UnVidrio = (SICALNet.BusinessEntities.VidriosUsoxLinea) ListaUsoxLinea[i];
					sDato = UnVidrio.c0.ToString();
					xlsheet.ActiveSheet.Cells[row,col] = sDato;
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c1a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c1b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c2a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c2b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c3a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c3b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c4a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c4b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c5a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c5b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c6a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c6b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c7a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c7b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c8a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c8b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c9a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c9b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c10a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c10b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c11a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c11b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c12a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c12b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c13a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c13b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c14a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c14b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c15a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c15b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c16a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c16b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c17a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c17b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c18a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c18b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c19a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c19b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c20a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c20b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c21a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c21b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c22a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c22b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c23a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c23b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c24a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c24b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c25a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c25b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c26a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c26b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c27a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c27b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c28a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c28b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c29a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c29b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c30a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c30b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c31a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c31b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c32a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c32b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c33a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c33b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c34a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c34b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c35a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c35b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c36a.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.c36b.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.orden.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.suma.ToString(); 
					col=col+1;

					// Reiniciando fila y columna
					row++;
					col=1;
				}

				// xlsheet.ActiveSheet.Columns.AutoFit();

				string xlFileName = "VidriosUsoxLinea_" + System.DateTime.Now.ToString("ddMMMyyyy") +".xls";
			
				string fullFileName = string.Format("{0}\\{1}",Server.MapPath("."),xlFileName);
				// save it off to the filesystem...
				xlsheet.Export(fullFileName,OWC10.SheetExportActionEnum.ssExportActionNone,OWC10.SheetExportFormat.ssExportHTML);
			
				DownloadFile(fullFileName);
			}
			catch (Exception ex)
			{
				prcErrorDisplay(ex,"Error");

				//throw;
			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if (this.txtFechaInicial.Text.Trim() == "" || this.txtFechaFinal.Text.Trim() == ""){
				Page.RegisterStartupScript("ClientScript","<script language=JavaScript>alert('Favor de especificar fecha inicial y final');</script>");		
				return;			
			}
			string sDato = "";
			ArrayList ListaReporteRda; 
			SICALNet.BusinessLogicLayer.VidriosReporteRDA bllVidrios= new SICALNet.BusinessLogicLayer.VidriosReporteRDA();
			ListaReporteRda = (ArrayList)bllVidrios.MuestraReporteRDA(this.txtFechaInicial.Text, this.txtFechaFinal.Text, int.Parse(this.cboClasificacionReporte.SelectedValue));

			// Export Data To Excel
			OWC10.SpreadsheetClass xlsheet = new SpreadsheetClass();
			// To Write Excel Header
			for(int j=0; j<9; j++)
			{
				if(j==0)
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "Año";
				}
				else if(j==1)
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "Mes";
				}
				else if(j==2)
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "Fecha";
				}
				else if(j==3)
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "Lote";
				}
				else if(j==4)
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "Medida";
				}
				else if(j==5)
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "Linea";
				}
				else if(j==6)
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "Causa";
				}
				else if(j==7)
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "FechaCapa";
				}
				else if(j==8)
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "Tipo";
				}
				else if(j==9)
				{
					xlsheet.ActiveSheet.Cells[1,j+1] = "CC";
				}
			}

			try
			{
				int row = 2, col=1;
				for(int i=0; i<ListaReporteRda.Count; i++)
				{
					SICALNet.BusinessEntities.VidriosReporteRDA UnVidrio ;
					UnVidrio = (SICALNet.BusinessEntities.VidriosReporteRDA) ListaReporteRda[i];
					sDato = UnVidrio.Anio.ToString();
					xlsheet.ActiveSheet.Cells[row,col] = sDato;
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.Mes.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.Fecha.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.Lote.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.Medida.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.Linea.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.Causa.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.FechaCapa.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.DesTipo.ToString(); 
					col=col+1;
					xlsheet.ActiveSheet.Cells[row,col] = UnVidrio.idCC.ToString(); 

					// Reiniciando fila y columna
					row++;
					col=1;
				}

				// xlsheet.ActiveSheet.Columns.AutoFit();

				string xlFileName = "VidriosReporteRDA_" + System.DateTime.Now.ToString("ddMMMyyyy") +".xls";
			
				string fullFileName = string.Format("{0}\\{1}",Server.MapPath("."),xlFileName);
				// save it off to the filesystem...
				xlsheet.Export(fullFileName,OWC10.SheetExportActionEnum.ssExportActionNone,OWC10.SheetExportFormat.ssExportHTML);
			
				DownloadFile(fullFileName);
			}
			catch (Exception ex)
			{
				prcErrorDisplay(ex,"Error");

				//throw;
			}

		}

	}
}
