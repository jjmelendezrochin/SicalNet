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
using SICALNet.BusinessEntities;
using SICALNet.BusinessLogicLayer;
using CYBERAKT.WebControls.Navigation;
using System.Data.SqlClient;
using SICALNet.Interfaces;
using Microsoft.ApplicationBlocks.Data;

namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtSecuencia;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.TextBox txtUTEC;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected System.Web.UI.WebControls.DataGrid dgdPMMA;
		protected System.Web.UI.WebControls.DataGrid dgdAditivos;
		protected System.Web.UI.WebControls.DataGrid dgdColor;
		protected CYBERAKT.WebControls.Navigation.ASPnetMenu tabMixture;

		protected static int NoContainer;
		protected static int CurrentTab;
		protected static ArrayList[] PMMAList;
		protected static ArrayList[] AditivosList;
		protected static ArrayList[] ColorList;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblNoLaminas;
		protected static int[] NumLaminas;
		protected static int[] NoAgitador;
		protected static float[] Aforo;
		// protected static float[] Suborante;
		protected static double[] MontoSobrante;
		protected static string[] VisInitial;
		protected static string[] VisFinal;
		protected System.Web.UI.WebControls.DropDownList cmbOlla;
		protected static string[] SecSobrante;
		protected static int[] Olla;
		protected System.Web.UI.WebControls.Label lblOlla;
		protected static bool Consult;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label15;
		protected static int IdStatus;
		protected bool blnSecuenciaCombinada=false;
		protected string secuenciaCombinada;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtOllaRegistro;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtSubrante;
		protected System.Web.UI.WebControls.TextBox sub;
		protected System.Web.UI.WebControls.Label lblSubrante;
		protected System.Web.UI.WebControls.TextBox txtAgitador;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtViscosidadInicial;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtViscosidadFinal;
		protected System.Web.UI.WebControls.TextBox txtSecuenciaSobrante;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.TextBox txtPiso;
		protected System.Web.UI.WebControls.Button btnAgregarMensaje;
		protected System.Web.UI.WebControls.Button cmdLiberar;
		protected System.Web.UI.WebControls.Button btnAgregar;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.DataList lstColor;
		protected IList CombinasList;
		private const string PARM_SECUENCIA	="@SECUENCIA";
		//protected System.Web.UI.WebControls.TextBox txtidPlanta;
		private const string PARM_NUMEROOLLA="@NumeroOlla";
		protected System.Web.UI.WebControls.TextBox txtidPlanta;
		
		public int idPlanta;
			
		public float[] Suborante
		{
			get
			{
				if(Session["Suborante"]==null)
					Session["Suborante"]=new float[20];

				return (float[])Session["Suborante"];
			}
			set
			{
				Session["Suborante"] = value;
			}
		}
		
		private void Page_Load(object sender, System.EventArgs e)
		{			
			SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
			SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
			theUser  = BLLUser.Load(theUser);
			idPlanta = theUser.IdPlanta;

			// Limpieza de cache
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetNoStore();
			Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
			Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
			Response.Cache.SetValidUntilExpires(false);
			
			// Put user code to initialize the page here
			VerificaSecuenciaCombinada();
			if (!IsPostBack)
			{
				txtSubrante.Text = string.Empty;
				txtSubrante.EnableViewState = false;
				cmdLiberar.Attributes.Add("onClick","showWaitControls()");
				btnAgregarMensaje.Attributes.Add("onClick","showWaitControls()");
				btnAgregar.Attributes.Add("onClick","showWaitControls()");
				btnCancel.Attributes.Add("onClick","showWaitControls()");

				LoadInitialInformation();
			}
			this.txtidPlanta.Text = idPlanta.ToString();
		}
		
		private void VerificaSecuenciaCombinada()
		{
			
			string secuance=Request.QueryString["Secuencia"];
			SICALNet.BusinessEntities.SecuenciaCombinasInfo scInfo;
			SICALNet.BusinessEntities.SecuenciaCombinasInfo scInfoAux = new SICALNet.BusinessEntities.SecuenciaCombinasInfo(secuance,0);
			SICALNet.BusinessLogicLayer.SecuenciaCombinas blSC = new SICALNet.BusinessLogicLayer.SecuenciaCombinas();
			CombinasList=blSC.SelectSecuenciaCombinas(scInfoAux);
			if(CombinasList.Count > 0)
			{
				this.blnSecuenciaCombinada = true;
				for(int i=0;i<CombinasList.Count;i++)
				{
					scInfo=(SICALNet.BusinessEntities.SecuenciaCombinasInfo)CombinasList[i];
					secuenciaCombinada += "'"+scInfo.Secuencia +"',";
				}
				secuenciaCombinada=secuenciaCombinada.Remove(secuenciaCombinada.Length-1,1);
			}
			else
				this.blnSecuenciaCombinada = false;
		}

		private void LoadInitialInformation()
		{

			string sBitacora = string.Format("Inicio de proceso LoadInitialInformation {0} en Fase de mezclas, por el usuario {1}",txtSecuencia.Text, this.User.Identity.Name.ToString());
			// guardamos en la bitacora
			SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
			BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

			IdStatus = Convert.ToInt32(Request.QueryString["Status"]);
			if(blnSecuenciaCombinada)
			{
				txtSecuencia.Text = this.secuenciaCombinada;
				float cantidad=0;
				for(int i=0;i<CombinasList.Count;i++)
				{
					SICALNet.BusinessEntities.SecuenciaCombinasInfo scInfo=(SICALNet.BusinessEntities.SecuenciaCombinasInfo)CombinasList[i];
					cantidad += scInfo.Cantidad;
				}
				txtCantidad.Text = cantidad.ToString();
			}
			else
			{
				txtSecuencia.Text = Request.QueryString["Secuencia"];
				txtCantidad.Text = Request.QueryString["Cantidad"];
			}
			
			txtFecha.Text = Request.QueryString["Fecha"];
			txtUTEC.Text = Request.QueryString["UTEC"];
			NoContainer = Convert.ToInt32(Request.QueryString["NoContainer"]);

			// Calculo del numero de containers cuando tiene cero
			if (NoContainer==0)
			{
				int IdAreaAditivos = Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]);
				SICALNet.BusinessLogicLayer.PartidasAditivos PAditivos = new SICALNet.BusinessLogicLayer.PartidasAditivos();
					NoContainer = PAditivos.GetNoContainers(Request.QueryString["Secuencia"], IdAreaAditivos);
			}

			

			sBitacora = string.Format("Fecha es {0}",txtFecha.Text);
			BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());			

			sBitacora = string.Format("Utec es {0}",txtUTEC.Text);
			BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

			sBitacora = string.Format("NoContainer es {0}",NoContainer.ToString());
			BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

			sBitacora = string.Format("el valor de idStatus es {0}",IdStatus.ToString());
			BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

			PMMAList = new ArrayList[NoContainer];
			AditivosList = new ArrayList[NoContainer]; 
			ColorList = new ArrayList[NoContainer];
			NumLaminas =  new Int32[NoContainer];
			MontoSobrante =  new double[NoContainer];
			NoAgitador = new Int32[NoContainer];
			Suborante = new float[NoContainer];
			VisInitial = new string[NoContainer];
			VisFinal = new string[NoContainer];
			SecSobrante = new string[NoContainer];
			Olla = new Int32[NoContainer];

			sBitacora = string.Format("Alta arreglos",txtSecuencia.Text, this.User.Identity.Name.ToString());
			BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

			CurrentTab = 1;			
			//				SICALNet.BusinessLogicLayer.PartidasAditivos PAditivos = new SICALNet.BusinessLogicLayer.PartidasAditivos();
			//				lblNoLaminas.Text = Convert.ToString(PAditivos.GetNoLaminas(txtSecuencia.Text, CurrentTab));

			if(this.blnSecuenciaCombinada)
				{	
					SelectTABCombined();
				}
			else
				{	
					sBitacora = string.Format("antes de entrar al SelectTab()",txtSecuencia.Text, this.User.Identity.Name.ToString());
					BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

					SelectTAB();

					sBitacora = string.Format("después de entrar al SelectTab()",txtSecuencia.Text, this.User.Identity.Name.ToString());
					BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				}

			CreateTab();
			
			//sBitacora = string.Format("CreateTab()", this.User.Identity.Name.ToString());
			//BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

			int IdReleaseStatus = Convert.ToInt32(ConfigurationManager.AppSettings["StatusRelease"]);

			//sBitacora = string.Format("idReleaseStatus es {0}", IdReleaseStatus.ToString());
			//BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

			if (IdStatus == IdReleaseStatus)
			{
				cmdLiberar.Enabled = false;
				btnAgregar.Enabled = false;
				dgdPMMA.Columns[4].Visible=true;
				dgdPMMA.Columns[3].Visible=false;
				cmbOlla.Visible=false;
				lblOlla.Visible=false;
				txtSecuenciaSobrante.Enabled=false;
				txtSubrante.Enabled=false;
				txtAgitador.Enabled=false;
				txtViscosidadFinal.Enabled=false;
				txtViscosidadInicial.Enabled=false;
			}
			
			sBitacora = string.Format("SumRegisterPerOlla()", this.User.Identity.Name.ToString());
			//BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());		

			SumRegisterPerOlla();	

			sBitacora = string.Format("SumRegisterPerOlla()",txtSecuencia.Text, this.User.Identity.Name.ToString());
			BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

			// Display the Messages in Multiline Text box				
			DisplayFloorMessage();

			sBitacora = string.Format("DisplayFloorMessage()",txtSecuencia.Text, this.User.Identity.Name.ToString());
			//BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

			// Seleccionando el primer Tab como default para que se muestre el cálculo del sobrante
			ChangeTab(1);

			sBitacora = string.Format("ChangeTab(1)");
			BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

			if(this.blnSecuenciaCombinada)
			{
				SelectTABCombined();
			}
			else
			{
				SelectTAB();				
			}

			// *****************
			// Seleccionando el primer Tab como default para que se muestre el cálculo del sobrante
			if (NoContainer==1)
			{
				ChangeTab(1);
			}
			// *****************

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
			this.tabMixture.MenuItemSelected += new CYBERAKT.WebControls.Navigation.ASPnetMenu.MenuItemSelectedEvent(this.tabMixture_MenuItemSelected);
			this.dgdPMMA.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdPMMA_ItemDataBound);
			this.btnAgregarMensaje.Click += new System.EventHandler(this.btnAgregarMensaje_Click);
			this.cmdLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void CreateTab()
		{
            CYBERAKT.WebControls.Navigation.MenuItem mnuItem;
		
			for(int i=1; i<=NoContainer; i++)
			{
				mnuItem = tabMixture.TopGroup.Items.Add();				

				if(Consult)
				{
					mnuItem.Label += string.Format("<center>Olla {0}<br><i>({1} láminas)</i></center>",cmbOlla.Items.FindByValue(Olla[i-1].ToString()).Text,NumLaminas[i-1]);
				}
				else
				{
					mnuItem.Label += string.Format("<center>Olla {0}<br><i>({1} láminas)</i></center>",i,NumLaminas[i-1]);
				}

				mnuItem.SelectedCssClass="SelectedMenuItem";
				mnuItem.ID = "Olla " + i.ToString();
			}
			tabMixture.TopGroup.Items[0].IsSelected =  true;
		}


		private void DisplayFloorMessage()
		{
			// Display the Messages in Multiline Text box
			MensajePisoInfo mpInfo;
			if(this.blnSecuenciaCombinada)
				mpInfo = new MensajePisoInfo(this.secuenciaCombinada.Substring(0,this.secuenciaCombinada.IndexOf(",")),string.Empty,Convert.ToInt32(ConfigurationManager.AppSettings["MixturesRoomId"]));
			else
				mpInfo = new MensajePisoInfo(txtSecuencia.Text,string.Empty,Convert.ToInt32(ConfigurationManager.AppSettings["MixturesRoomId"]));

			SICALNet.BusinessLogicLayer.MensajePiso mPiso = new SICALNet.BusinessLogicLayer.MensajePiso();					
			IList mPisoList=mPiso.Select(mpInfo);
			if(mPisoList.Count>0)
			{
				for(int iloop=0;iloop<mPisoList.Count;iloop++)
				{	
					MensajePisoInfo mpInfo1 = new MensajePisoInfo();
					mpInfo1=(MensajePisoInfo)mPisoList[iloop];
					txtPiso.Text+=mpInfo1.Mensaje.ToString();
					txtPiso.Text+="\n";
				}
			}

		}

		private void tabMixture_MenuItemSelected(object sender, CYBERAKT.WebControls.Navigation.MenuItemSelectedEventArgs e)
		{
			ChangeTab(Convert.ToInt32(e.Item.ID.Substring(e.Item.ID.IndexOf(" ",0)+1)));
		}

		private void ChangeTab(int newtab)
		{
			// Inicializando bitácora
			SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();

			try
			{
				// **********************************
				// Iniciando Bitacora en ChangeTab
				string sBitacora = string.Format("***** Dentro de ChangeTab *****");				
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				SICALNet.Utilities.Validation Validate = new SICALNet.Utilities.Validation();
				// Validation for Agitador (Should be Number)
				if (txtAgitador.Text!="" && !Validate.IsInteger(txtAgitador.Text))
					throw new Exception("El numero de agitador debe ser un número entero");				
				NoAgitador[CurrentTab-1] = (txtAgitador.Text==string.Empty)?0:Convert.ToInt32(txtAgitador.Text);				
				VisInitial[CurrentTab-1]=txtViscosidadInicial.Text;
				VisFinal[CurrentTab-1]=txtViscosidadFinal.Text;
				SecSobrante[CurrentTab-1]=txtSecuenciaSobrante.Text;
				Olla[CurrentTab-1]=Convert.ToInt32(cmbOlla.SelectedItem.Value);
				int PreviousTab = CurrentTab; 			
				// Get the Current TAB Number
				CurrentTab = newtab;
				SICALNet.BusinessEntities.OllaInfo OInfo = new SICALNet.BusinessEntities.OllaInfo();		
				if(this.blnSecuenciaCombinada)
				{
					string _initialSeq = ((SecuenciaCombinasInfo)CombinasList[0]).Secuencia;
					if(Olla[CurrentTab-1]==0 || !Consult)
						OInfo = new SICALNet.BusinessEntities.OllaInfo(_initialSeq,CurrentTab,Convert.ToInt32(idPlanta),GetIdLinea(_initialSeq));		
					else if(Consult)
						OInfo = new SICALNet.BusinessEntities.OllaInfo(_initialSeq,1,Convert.ToInt32(idPlanta),GetIdLinea(_initialSeq));		
				}
				else
				{
					if(Olla[CurrentTab-1]==0 || !Consult)
					{
						OInfo = new SICALNet.BusinessEntities.OllaInfo(txtSecuencia.Text,CurrentTab,Convert.ToInt32(idPlanta),GetIdLinea(txtSecuencia.Text));		
						sBitacora = string.Format("Secuencia {0}, CurrenTab {1}, idPlanta {2}, idLinea {3}", txtSecuencia.Text,CurrentTab,Convert.ToInt32(idPlanta),GetIdLinea(txtSecuencia.Text));
					}
					else if(Consult)
					{
						OInfo = new SICALNet.BusinessEntities.OllaInfo(txtSecuencia.Text,1,Convert.ToInt32(idPlanta),GetIdLinea(txtSecuencia.Text));
						sBitacora = string.Format("Secuencia {0}, CurrenTab {1}, idPlanta {2}, idLinea {3}", txtSecuencia.Text,1,Convert.ToInt32(idPlanta),GetIdLinea(txtSecuencia.Text));
					}
				}

				// Información de Olla Info				
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());
						
				SICALNet.BusinessLogicLayer.Olla blOlla = new SICALNet.BusinessLogicLayer.Olla();
				IList MezOlla=blOlla.SelectOllaMezclas(OInfo);

				// Calcula el sobrante del aditivo de esa olla
				//double Sobrante = blOlla.SobranteAditivo(OInfo);				
				sBitacora = string.Format("blOlla.SobranteAditivo1 Secuencia {0}, OInfo.NumeroOlla {1}, Olla[CurrentTab-1] {2}",this.txtSecuencia.Text, OInfo.NumeroOlla, Olla[CurrentTab-1]);
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				BLLBitacora.Insertcomando(
					string.Format(
					"CurrentTab={0}, newtab={1}, Olla={2}, Combo={3}",
					CurrentTab,
					newtab,
					Olla[CurrentTab-1],
					cmbOlla.SelectedValue),
					User.Identity.Name);

				double Sobrante = blOlla.SobranteAditivo1(this.txtSecuencia.Text, OInfo.NumeroOlla, Olla[CurrentTab-1]);
				
				BLLBitacora.Insertcomando(
					"Sobrante=" + Sobrante,
					User.Identity.Name);

				sBitacora = string.Format("Sobrante {0}", Sobrante.ToString());
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());
				
				Suborante[CurrentTab-1]=float.Parse(Sobrante.ToString());
				MontoSobrante[CurrentTab-1]=float.Parse(Sobrante.ToString());

				cmbOlla.DataSource=MezOlla;
				cmbOlla.DataValueField="NumeroOlla";
				cmbOlla.DataTextField="Descripcion";
				cmbOlla.DataBind();
				SwitchTAB(PreviousTab);
				//SelectTAB();
				SumRegisterPerOlla();
				// To Restore the NoAgitador Value for the Current TAB
				txtAgitador.Text = (Convert.ToString(NoAgitador[CurrentTab-1])=="0"?string.Empty:Convert.ToString(NoAgitador[CurrentTab-1]));
				txtSubrante.Text = (Convert.ToString(Suborante[CurrentTab-1])=="0"?"0":Convert.ToString(Suborante[CurrentTab-1]));

				sBitacora = string.Format("txtSubrante.Text {0}", txtSubrante.Text);
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());
				
				sub.Text = txtSubrante.Text;
				
				txtViscosidadInicial.Text=VisInitial[CurrentTab-1];
				txtViscosidadFinal.Text=VisFinal[CurrentTab-1];
				txtSecuenciaSobrante.Text=SecSobrante[CurrentTab-1];
				if(Olla[CurrentTab-1]!=0)
					cmbOlla.Items.FindByValue(Olla[CurrentTab-1].ToString()).Selected=true;

				// **********************************
				// Saliendo en ChangeTab
				sBitacora = string.Format("***** Saliendo de ChangeTab *****");				
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());
				// **********************************
			}
			catch
			{
				//				//to display the msg for user
				//				string ScriptString="<script language='javascript'>alert('"+ ex.Message +"');</script>"; 
				//				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);

				throw;
			}

		}



		private void SwitchTAB(int PreviousTAB)
		{
			try
			{
				ArrayList tmpList = new ArrayList();
				for(int i = 0; i < dgdPMMA.Items.Count; i++)
				{
					string CodigoSAP = ((Label)dgdPMMA.Items[i].FindControl("lblPMMACodigoSAP")).Text;
					int IdTipoPMMA = Convert.ToInt32(((Label)dgdPMMA.Items[i].FindControl("lblIdTipoPMMA")).Text);
					string Descripcion = ((Label)dgdPMMA.Items[i].FindControl("lblPMMADescripcion")).Text;				
					float Cantidad = Convert.ToSingle(((Label)dgdPMMA.Items[i].FindControl("lblPMMACantidad")).Text);				
					string Registro = ((TextBox)dgdPMMA.Items[i].FindControl("txtPMMARegistro")).Text;
					float CantidadReal = (Registro!=string.Empty)?Convert.ToSingle(Registro):0;
					
					string IdTanque = ((Label)dgdPMMA.Items[i].FindControl("lblIDTanque")).Text.ToString();
					if(IdTanque == string.Empty)
					{
						IdTanque = ((DropDownList)dgdPMMA.Items[i].FindControl("cboTanque")).SelectedItem.Value;
					}					
					PartidasMezclasInfo pmInfo = new PartidasMezclasInfo(CodigoSAP, IdTipoPMMA, Descripcion, Cantidad, CantidadReal);
					if(IdTanque != string.Empty)
						pmInfo.NoTanque = Convert.ToInt32(IdTanque);
					tmpList.Add(pmInfo);
				}
				PMMAList[PreviousTAB-1] = tmpList;
				dgdPMMA.DataSource = PMMAList[CurrentTab-1];
				dgdPMMA.DataBind();

				ArrayList tmpList1 = new ArrayList();
				for(int i = 0; i < dgdAditivos.Items.Count; i++)
				{
					string CodigoSAP = ((Label)dgdAditivos.Items[i].FindControl("lblAditivosCodigoSAP")).Text;
					string Descripcion = ((Label)dgdAditivos.Items[i].FindControl("lblAditivosDescripcion")).Text;
					decimal Cantidad = Convert.ToDecimal(((Label)dgdAditivos.Items[i].FindControl("lblAditivosCantidad")).Text);
					//				decimal CantidadReal = Convert.ToDecimal(((TextBox)dgdAditivos.Items[i].FindControl("txtAditivosRegistro")).Text);
					//string Registro = ((TextBox)dgdAditivos.Items[i].FindControl("txtAditivosRegistro")).Text;
					//decimal CantidadReal = (Registro!=string.Empty)?Convert.ToDecimal(Registro):0;

					PartidasAditivosInfo paInfo = new PartidasAditivosInfo(CodigoSAP, Descripcion, Cantidad, Cantidad,string.Empty,0);
					tmpList1.Add(paInfo);
				}
				AditivosList[PreviousTAB-1] = tmpList1;
				dgdAditivos.DataSource = AditivosList[CurrentTab-1];
				dgdAditivos.DataBind();
				ArrayList tmpList2 = new ArrayList();
				for(int i = 0; i < dgdColor.Items.Count; i++)
				{
					//string CodigoSAP = ((Label)dgdColor.Items[i].FindControl("lblColorCodigoSAP")).Text;
					//string Descripcion = ((Label)dgdColor.Items[i].FindControl("lblColorDescripcion")).Text;
					decimal Cantidad = Convert.ToDecimal(((Label)dgdColor.Items[i].FindControl("lblColorCantidad")).Text);
					//				decimal CantidadReal = Convert.ToDecimal(((TextBox)dgdColor.Items[i].FindControl("txtColorRegistro")).Text);
					//string Registro = ((TextBox)dgdColor.Items[i].FindControl("txtColorRegistro")).Text;
					//decimal CantidadReal = (Registro!=string.Empty)?Convert.ToDecimal(Registro):0;
					int Componente = Convert.ToInt32(((Label)dgdColor.Items[i].FindControl("lblComponente")).Text);
					decimal CantidadRealAux = Convert.ToDecimal(((Label)dgdColor.Items[i].FindControl("lblAfLaminas")).Text);
					float Aforo = Convert.ToSingle(((Label)dgdColor.Items[i].FindControl("lblAforo")).Text.ToString());

					PartidasColorInfo pcInfo= new PartidasColorInfo(Componente,Cantidad,Aforo,CantidadRealAux);
					tmpList2.Add(pcInfo);
				}
				ColorList[PreviousTAB-1] = tmpList2;
				dgdColor.DataSource = ColorList[CurrentTab-1];
				dgdColor.DataBind();
				lstColor.DataSource=ColorList[CurrentTab-1];
				lstColor.DataBind();

				lblNoLaminas.Text = NumLaminas[CurrentTab-1].ToString();

				int _noLaminas = Convert.ToInt32(lblNoLaminas.Text);
				for (int k=0;k<lstColor.Items.Count;k++)
				{
					IList _currentVaso= (IList) ColorList[CurrentTab-1];
					PartidasColorInfo  _partidasColor= (PartidasColorInfo) _currentVaso[k];
					int _noComponent = _partidasColor.GroupNo;
					if (CombinasList.Count>0)
					{
						SecuenciaCombinasInfo scInfo = (SecuenciaCombinasInfo)CombinasList[0];
						BindChildGrids(scInfo.Secuencia,_noComponent,_noLaminas,k);
					}
					else
						BindChildGrids(txtSecuencia.Text,_noComponent,_noLaminas,k);

				}
			}
			catch
			{
				//				//to display the msg for user
				//				string ScriptString="<script language='javascript'>alert('"+ ex.Message +"');</script>"; 
				//				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);

				throw;
			}
		}

		private void StoreCurrentTAB()
		{
			ArrayList tmpList = new ArrayList();
			for(int i = 0; i < dgdPMMA.Items.Count; i++)
			{
				string CodigoSAP = ((Label)dgdPMMA.Items[i].FindControl("lblPMMACodigoSAP")).Text;
				int IdTipoPMMA = Convert.ToInt32(((Label)dgdPMMA.Items[i].FindControl("lblIdTipoPMMA")).Text);
				string Descripcion = ((Label)dgdPMMA.Items[i].FindControl("lblPMMADescripcion")).Text;				
				float Cantidad = Convert.ToSingle(((Label)dgdPMMA.Items[i].FindControl("lblPMMACantidad")).Text);
				string Registro = ((TextBox)dgdPMMA.Items[i].FindControl("txtPMMARegistro")).Text;
				float CantidadReal = (Registro!=string.Empty)?Convert.ToSingle(Registro):0;

				string IdTanque = ((Label)dgdPMMA.Items[i].FindControl("lblIDTanque")).Text.ToString();
				if(IdTanque == string.Empty)
				{
					IdTanque = ((DropDownList)dgdPMMA.Items[i].FindControl("cboTanque")).SelectedItem.Value;
				}
				
				PartidasMezclasInfo pmInfo = new PartidasMezclasInfo(CodigoSAP, IdTipoPMMA, Descripcion, Cantidad, CantidadReal);
				if(IdTanque != string.Empty)
					pmInfo.NoTanque = Convert.ToInt32(IdTanque);
				tmpList.Add(pmInfo);
			}
			PMMAList[CurrentTab-1] = tmpList;

			ArrayList tmpList1 = new ArrayList();
			for(int i = 0; i < dgdAditivos.Items.Count; i++)
			{
				string CodigoSAP = ((Label)dgdAditivos.Items[i].FindControl("lblAditivosCodigoSAP")).Text;
				string Descripcion = ((Label)dgdAditivos.Items[i].FindControl("lblAditivosDescripcion")).Text;
				decimal Cantidad = Convert.ToDecimal(((Label)dgdAditivos.Items[i].FindControl("lblAditivosCantidad")).Text);
				//				decimal CantidadReal = Convert.ToDecimal(((TextBox)dgdAditivos.Items[i].FindControl("txtAditivosRegistro")).Text);
				//string Registro = ((TextBox)dgdAditivos.Items[i].FindControl("txtAditivosRegistro")).Text;
				//decimal CantidadReal = (Registro!=string.Empty)?Convert.ToDecimal(Registro):0;

				PartidasAditivosInfo paInfo = new PartidasAditivosInfo(CodigoSAP, Descripcion, Cantidad, Cantidad,string.Empty,0);
				tmpList1.Add(paInfo);
			}
			AditivosList[CurrentTab-1] = tmpList1;

			ArrayList tmpList2 = new ArrayList();
			for(int i = 0; i < dgdColor.Items.Count; i++)
			{
				int Componente = Convert.ToInt32(((Label)dgdColor.Items[i].FindControl("lblComponente")).Text);
				//string CodigoSAP = ((Label)dgdColor.Items[i].FindControl("lblColorCodigoSAP")).Text;
				//string Descripcion = ((Label)dgdColor.Items[i].FindControl("lblColorDescripcion")).Text;
				decimal Cantidad = Convert.ToDecimal(((Label)dgdColor.Items[i].FindControl("lblColorCantidad")).Text);
				//				decimal CantidadReal = Convert.ToDecimal(((TextBox)dgdColor.Items[i].FindControl("txtColorRegistro")).Text);
				//string Registro = ((TextBox)dgdColor.Items[i].FindControl("txtColorRegistro")).Text;
				//decimal CantidadReal = (Registro!=string.Empty)?Convert.ToDecimal(Registro):0;
				float Aforo = Convert.ToSingle(((Label)dgdColor.Items[i].FindControl("lblAforo")).Text);

				PartidasColorInfo pcInfo = new PartidasColorInfo(string.Empty, string.Empty, Cantidad, Cantidad,Componente,string.Empty,Aforo);
				tmpList2.Add(pcInfo);
			}
			ColorList[CurrentTab-1] = tmpList2;
			NoAgitador[CurrentTab-1] = (txtAgitador.Text==string.Empty)?0:Convert.ToInt32(txtAgitador.Text);
			Suborante[CurrentTab-1] = (txtSubrante.Text==string.Empty)?0:Convert.ToSingle(txtSubrante.Text);
			VisInitial[CurrentTab-1]=txtViscosidadInicial.Text;
			VisFinal[CurrentTab-1]=txtViscosidadFinal.Text;
			SecSobrante[CurrentTab-1]=txtSecuenciaSobrante.Text;
			Olla[CurrentTab-1]=Convert.ToInt32(cmbOlla.SelectedItem.Value);
		}

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
			//			
			try
				
			{
				//SICALNet.BusinessLogicLayer.PartidasMezclas PartidasMezclas = new SICALNet.BusinessLogicLayer.PartidasMezclas();


				SICALNet.Utilities.Validation Validate = new SICALNet.Utilities.Validation();

				// Validation for Agitador (Should be Number)
				if (txtAgitador.Text!="" && !Validate.IsInteger(txtAgitador.Text))
					throw new Exception("El numero de agitador debe ser un número entero");

				if(this.cmbOlla.SelectedIndex == -1)
					throw new Exception("Valor inválido en el campo Olla"); 		

				StoreCurrentTAB();

				//string Secuencia = txtSecuencia.Text;

				string delimStr = ",";
				char [] delimiter = delimStr.ToCharArray();			
				string[] ArrSecuencias = txtSecuencia.Text.Split(delimiter);				
				
			
				int IdArea = Convert.ToInt32(ConfigurationManager.AppSettings["MixturesRoomId"]);
				
				
				for(int i=0;i<NoContainer-1;i++)
				{
					for(int j=i+1;j<NoContainer;j++)
					{
						if(Olla[i]==Olla[j])
							if(Olla[i] == 0)
							{
								throw new Exception("No se guardó la secuencia debido a que la olla "+cmbOlla.Items[0].Text+" está seleccionada dos veces.");
							}
							else
							{
								throw new Exception("No se guardó la secuencia debido a que la olla "+cmbOlla.Items.FindByValue(Olla[i].ToString()).Text+" está seleccionada dos veces.");
							}							
					}
				}

				foreach(string Secuencia in ArrSecuencias)
				{
					string currentSecuence =string.Empty;
					if (CombinasList.Count>0)
					{
						currentSecuence = Secuencia.Substring(1);
						currentSecuence=currentSecuence.Substring(0,currentSecuence.Length-1);
					}
					else 
						currentSecuence=Secuencia;

					ArrayList tmpList = new ArrayList();
					for(int iLoop = 0; iLoop < NoContainer; iLoop++)
					{
						int NumeroOlla = Olla[iLoop];
						int NoLaminas = NumLaminas[iLoop];

						//---------------------------------------------------
						// To Store PMMA Info into PartidasMezclas
						//---------------------------------------------------
						for(int i = 0; i < PMMAList[iLoop].Count; i++)
						{
							// Used to retrive CodigoSAP, Cantidad for PMMA
							PartidasMezclasInfo pmInfo = new PartidasMezclasInfo();
							pmInfo = (PartidasMezclasInfo)PMMAList[iLoop][i];
				
							string CodigoSAP = pmInfo.CodigoSAP;
							float Cantidad = pmInfo.Cantidad;
							float CantidadReal = pmInfo.CantidadReal;
							int TipoComponents = 1; // 1 - for PMMA Components Type Value
						
							PartidasMezclasInfo pmInfo1 = new PartidasMezclasInfo(currentSecuence, IdArea, CodigoSAP, NumeroOlla, TipoComponents, NoLaminas, Cantidad, CantidadReal, NoAgitador[iLoop],0,Suborante[iLoop],VisInitial[iLoop],VisFinal[iLoop],SecSobrante[iLoop],Convert.ToInt16(iLoop));
							pmInfo1.NoTanque = pmInfo.NoTanque; 
							tmpList.Add(pmInfo1);
						}

					}

					if (tmpList.Count > 0)
					{
						SICALNet.BusinessLogicLayer.PartidasMezclas PMezclas = new SICALNet.BusinessLogicLayer.PartidasMezclas();
				
						//Delete the Existing Records in PartidasColor to adopt the Modification & Insertion
						PMezclas.Delete(currentSecuence);
						PMezclas.Insert(tmpList);
						SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(currentSecuence,Convert.ToInt32(ConfigurationManager.AppSettings["MixturesRoomId"]),Context.User.Identity.Name);
						SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						BLOrdenes.UpdateLoginForm(OTInfo);					
					}
				}
				//Update the tab information.


				string sec =string.Empty;
				if (CombinasList.Count>0)
				{
					//					string delstring = ",";
					char [] delCh= delimStr.ToCharArray();			
					string[] ArrSecs= txtSecuencia.Text.Split(delCh);				
					
					sec = ArrSecs[0].ToString();
					sec = sec.Substring(1);
					sec=sec.Substring(0,sec.Length-1);
				}
				else 
					sec=txtSecuencia.Text;

//				string nexturl = "ConsultMixturesWO1.aspx?IdPlanta=" + idPlanta +  "&Status=" + IdStatus + "&Secuencia=" + sec + "&Fecha=" + txtFecha.Text + "&Cantidad=" + txtCantidad.Text + "&NoContainer=" + NoContainer + "&CodigoSAP=" + Request.QueryString["CodigoSAP"].ToString();; 
//				Response.Redirect(nexturl);
				Response.Redirect("ConsultMixturesWO.aspx");

			}			
			catch(Exception errHand)
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('"+ errHand.Message +"');</script>"; 
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);

				ChangeTab(CurrentTab);
				string sec;
				if(this.blnSecuenciaCombinada)
					sec=this.secuenciaCombinada.Substring(0,this.secuenciaCombinada.IndexOf(","));
				else
					sec = txtSecuencia.Text;
				SICALNet.BusinessLogicLayer.PartidasMezclas PMezclas = new SICALNet.BusinessLogicLayer.PartidasMezclas();
				IList ASVList = PMezclas.SelectASV(sec);
				if(ASVList.Count >0)
				{
					SICALNet.BusinessEntities.PartidasMezclasInfo PMInfo = new SICALNet.BusinessEntities.PartidasMezclasInfo();
					PMInfo = (SICALNet.BusinessEntities.PartidasMezclasInfo)ASVList[CurrentTab-1];
					this.sub.Text = "0";
					this.txtSubrante.Text=PMInfo.Suborante.ToString(); 
				}
				else
				{
					this.sub.Text = "0";
					this.txtSubrante.Text = "0";
				}		
			
			}

		}

		private void SelectTABCombined()
		{
			string delimStr = ",";
			char [] delimiter = delimStr.ToCharArray();			
			string[] ArrSecuencias = txtSecuencia.Text.Split(delimiter);
			string initialSequence = ArrSecuencias[0].ToString();
			initialSequence=initialSequence.Substring(1);
			initialSequence=initialSequence.Substring(0,initialSequence.Length-1);

			SICALNet.BusinessLogicLayer.PartidasMezclas PartidasMezclas = new SICALNet.BusinessLogicLayer.PartidasMezclas();
			bool Consulted = PartidasMezclas.IsConsulted(initialSequence);
			//Get Amount of Product
			for(int i = 0; i < NoContainer; i++)
			{
				foreach(string sec in ArrSecuencias)
				{
					string singleSequence  = sec.Substring(1);
					singleSequence = singleSequence.Substring(0,singleSequence.Length-1);

					SICALNet.BusinessLogicLayer.PartidasAditivos PAditivos = new SICALNet.BusinessLogicLayer.PartidasAditivos();
					NumLaminas[i] = NumLaminas[i] + PAditivos.GetNoLaminas(singleSequence, i+1);
				}
			}

			SICALNet.BusinessEntities.OllaInfo OInfo = new SICALNet.BusinessEntities.OllaInfo(initialSequence,1,Convert.ToInt32(idPlanta),GetIdLinea(initialSequence));		
			SICALNet.BusinessLogicLayer.Olla blOlla = new SICALNet.BusinessLogicLayer.Olla();
			IList MezOlla=blOlla.SelectOllaMezclas(OInfo);

			cmbOlla.DataSource=MezOlla;
			cmbOlla.DataValueField="NumeroOlla";
			cmbOlla.DataTextField="Descripcion";
			cmbOlla.DataBind();

			// Extract Data for Aditivos Room
			for(int i = 0; i < NoContainer; i++)
			{	
				int AditivosRoomId = Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]);
				SICALNet.BusinessLogicLayer.PartidasAditivos PAditivos = new SICALNet.BusinessLogicLayer.PartidasAditivos();
				AditivosList[i] = (ArrayList) PAditivos.SelectCombined(this.secuenciaCombinada, AditivosRoomId, i+1);
			}
			dgdAditivos.DataSource = AditivosList[CurrentTab-1];
			dgdAditivos.DataBind();
				
			/* Codigo Comentado 27-Enero-2005 */
			/*
			SICALNet.BusinessLogicLayer.PartidasColor BLLPC=new SICALNet.BusinessLogicLayer.PartidasColor();
			IList pcList = (IList) BLLPC.GetNoVaso(Request.QueryString["Secuencia"].ToString());
			*/
			
			int ColorRoomId = Convert.ToInt32(ConfigurationManager.AppSettings["ColorRoomId"]);

			SICALNet.BusinessLogicLayer.PartidasColor PColor = new SICALNet.BusinessLogicLayer.PartidasColor();
			ArrayList AuxAllColorDetails = (ArrayList) PColor.GetPieceCantidadCombinado(initialSequence,ColorRoomId);
			int noLaminasTotal = 0;
			for(int h = 0; h < NoContainer; h++)
				noLaminasTotal += NumLaminas[h];

			

			for(int i = 0; i < NoContainer; i++)
			{	
				ArrayList tmpList = new ArrayList();
				for(int j = 0; j < AuxAllColorDetails.Count; j++)
				{
					PartidasColorInfo pcInfo = new PartidasColorInfo();
					pcInfo = (PartidasColorInfo) AuxAllColorDetails[j];
						
					PartidasColorInfo pcInfo1 = new PartidasColorInfo(pcInfo.GroupNo,(pcInfo.Cantidad/noLaminasTotal)*NumLaminas[i],pcInfo.Aforo*NumLaminas[i],Convert.ToDecimal(pcInfo.Aforo));
					tmpList.Add(pcInfo1); 
				}
				ColorList[i] = tmpList;
			}			

			dgdColor.DataSource = ColorList[CurrentTab-1];
			dgdColor.DataBind();
			lstColor.DataSource=ColorList[CurrentTab-1];
			lstColor.DataBind();

			int _noLaminas = Convert.ToInt32(NumLaminas[0]);
			for (int k=0;k<lstColor.Items.Count;k++)
			{
				IList _currentVaso= (IList) ColorList[CurrentTab-1];
				PartidasColorInfo  _partidasColor= (PartidasColorInfo) _currentVaso[k];
				int _noComponent = _partidasColor.GroupNo;
				BindChildGrids(initialSequence,_noComponent,_noLaminas,k);
			}

			if (Consulted)
			{
				Consult=true;
				//SICALNet.BusinessLogicLayer.Olla blOlla = new SICALNet.BusinessLogicLayer.Olla();
				OInfo = new SICALNet.BusinessEntities.OllaInfo(initialSequence,NoContainer,Convert.ToInt32(idPlanta));		
				Olla = (int[])blOlla.SelectOllaMezclasSelected(OInfo);

				cmbOlla.Items.FindByValue(Olla[0].ToString()).Selected=true;
				SICALNet.BusinessLogicLayer.PartidasMezclas PMezclas = new SICALNet.BusinessLogicLayer.PartidasMezclas();

				IList ASVList = PMezclas.SelectASV(initialSequence);
				for(int i = 0; i < NoContainer; i++)
				{
					SICALNet.BusinessEntities.PartidasMezclasInfo PMInfo = new SICALNet.BusinessEntities.PartidasMezclasInfo();
					PMInfo = (SICALNet.BusinessEntities.PartidasMezclasInfo)ASVList[i];
					NoAgitador[i] = PMInfo.NoAgitador;
					Suborante[i] =	PMInfo.Suborante;
					VisInitial[i] = PMInfo.ViscosidadInicial;
					VisFinal[i] = PMInfo.ViscosidadFinal;
					SecSobrante[i]=PMInfo.SecuenciaSobrante;

				}
				txtAgitador.Text = NoAgitador[CurrentTab-1].ToString();
				
				// Calcula el sobrante del aditivo de esa olla
				//double Sobrante = blOlla.SobranteAditivo(OInfo);
				double Sobrante = blOlla.SobranteAditivo1(this.txtSecuencia.Text, OInfo.NumeroOlla, Olla[CurrentTab-1]);
				Suborante[CurrentTab-1]=float.Parse(Sobrante.ToString());

				txtSubrante.Text = Suborante[CurrentTab-1].ToString();
				sub.Text = txtSubrante.Text;
				lblSubrante.Text = Suborante[CurrentTab-1].ToString();


				txtViscosidadInicial.Text=VisInitial[CurrentTab-1];
				txtViscosidadFinal.Text=VisFinal[CurrentTab-1];		
				txtSecuenciaSobrante.Text=SecSobrante[CurrentTab-1];
				
				// For PMMA related Records
				for(int i = 0; i < NoContainer; i++)
				{
					//SICALNet.BusinessLogicLayer.PartidasMezclas PMezclas = new SICALNet.BusinessLogicLayer.PartidasMezclas();
					PMMAList[i] = (ArrayList) PMezclas.Select(initialSequence, 1,Olla[i]);
				}
				dgdPMMA.DataSource = PMMAList[CurrentTab-1];
				dgdPMMA.DataBind();

			}
			else
			{
				Consult=false;

				// Extract Data for PMMA Grid
				for(int i = 0; i < NoContainer; i++)
				{	
					SICALNet.BusinessLogicLayer.PartidasMezclas PMezclas = new SICALNet.BusinessLogicLayer.PartidasMezclas();
					PMMAList[i] = (ArrayList) PMezclas.SelectPMMA(initialSequence);

					ArrayList tmpList = new ArrayList();
					for(int j = 0; j < PMMAList[i].Count; j++)
					{
						PartidasMezclasInfo pmInfo = new PartidasMezclasInfo();						
						pmInfo = (PartidasMezclasInfo) PMMAList[i][j];
						
						float ColorSUM = 0;
						float auxAforo = 0;
						for(int k = 0; k < ColorList[i].Count; k++)
						{
							PartidasColorInfo pcInfo = new PartidasColorInfo();
							pcInfo = (PartidasColorInfo) ColorList[i][k];
							if(pcInfo.Aforo==0)
								ColorSUM += Convert.ToSingle(pcInfo.Cantidad);
							else
								auxAforo =Convert.ToSingle(pcInfo.CantidadReal);							
						}
						auxAforo = Convert.ToSingle(auxAforo * NumLaminas[i]);
						ColorSUM += auxAforo;
						//for(int m=0;m<Aforo.Length;m++)
						//ColorSUM+=Aforo[m];
						float AditivosSUM = 0;
						for(int k = 0; k < AditivosList[i].Count; k++)
						{
							PartidasAditivosInfo paInfo = new PartidasAditivosInfo();
							paInfo = (PartidasAditivosInfo) AditivosList[i][k];

							AditivosSUM += Convert.ToSingle(paInfo.Cantidad);
						}
									
						float TotPMMACantidad = (pmInfo.Cantidad * NumLaminas[i]) - ((ColorSUM + AditivosSUM + Convert.ToSingle(txtSubrante.Text))/1000);

						PartidasMezclasInfo pmInfo1 = new PartidasMezclasInfo(pmInfo.CodigoSAP, pmInfo.Descripcion, TotPMMACantidad,0);
						pmInfo1.NoTanque = pmInfo.NoTanque;
						tmpList.Add(pmInfo1);
					}

					PMMAList[i] = tmpList;
				}
				dgdPMMA.DataSource = PMMAList[CurrentTab-1];
				dgdPMMA.DataBind();

				txtOllaRegistro.Text = ""; txtAgitador.Text=""; lblErrorMsg.Text = "";
			}
		}

		private void SelectTAB()
		{			
			
			string sBitacora = string.Format("SelectTab()");
			// guardamos en la bitacora
			SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
			BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());


			SICALNet.BusinessLogicLayer.PartidasMezclas PartidasMezclas = new SICALNet.BusinessLogicLayer.PartidasMezclas();
			bool Consulted = PartidasMezclas.IsConsulted(txtSecuencia.Text);

			sBitacora = string.Format("Consulted {0}", Consulted.ToString());
			// guardamos en la bitacora			
			BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

			//Get Amount of Product
			for(int i = 0; i < NoContainer; i++)
			{
				SICALNet.BusinessLogicLayer.PartidasAditivos PAditivos = new SICALNet.BusinessLogicLayer.PartidasAditivos();
				NumLaminas[i] = PAditivos.GetNoLaminas(txtSecuencia.Text, i+1);

				sBitacora = string.Format("NumLaminas[{0}]{0}",i.ToString(), NumLaminas[i]);
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				//MontoSobrante[i] = 0;
			}

			SICALNet.BusinessEntities.OllaInfo OInfo = new SICALNet.BusinessEntities.OllaInfo(txtSecuencia.Text,1,Convert.ToInt32(idPlanta),GetIdLinea(txtSecuencia.Text));		
			SICALNet.BusinessLogicLayer.Olla blOlla = new SICALNet.BusinessLogicLayer.Olla();
			
			IList MezOlla=blOlla.SelectOllaMezclas(OInfo);
			cmbOlla.DataSource=MezOlla;
			cmbOlla.DataValueField="NumeroOlla";
			cmbOlla.DataTextField="Descripcion";
			cmbOlla.DataBind();

			sBitacora = string.Format("Después de llenado de olla");
			BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

			// Extract Data for Aditivos Room
			for(int i = 0; i < NoContainer; i++)
			{	
				int AditivosRoomId = Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]);
				SICALNet.BusinessLogicLayer.PartidasAditivos PAditivos = new SICALNet.BusinessLogicLayer.PartidasAditivos();
				AditivosList[i] = (ArrayList) PAditivos.Select(txtSecuencia.Text, AditivosRoomId, i+1);
			}
			dgdAditivos.DataSource = AditivosList[CurrentTab-1];
			dgdAditivos.DataBind();

			sBitacora = string.Format("Llenado de aditivos");
			BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());
				
			// Extract Data for Color Room
			int ColorRoomId = Convert.ToInt32(ConfigurationManager.AppSettings["ColorRoomId"]);
			
			SICALNet.BusinessLogicLayer.PartidasColor PColor = new SICALNet.BusinessLogicLayer.PartidasColor();
			ArrayList AuxAllColorDetails = (ArrayList) PColor.GetPieceCantidad(txtSecuencia.Text, ColorRoomId);
			int noLaminasTotal = 0;
			for(int h = 0; h < NoContainer; h++)
				noLaminasTotal += NumLaminas[h];
			for(int i = 0; i < NoContainer; i++)
			{	
				ArrayList tmpList = new ArrayList();
				for(int j = 0; j < AuxAllColorDetails.Count; j++)
				{
					PartidasColorInfo pcInfo = new PartidasColorInfo();
					pcInfo = (PartidasColorInfo) AuxAllColorDetails[j];
						
					int _groupNo=pcInfo.GroupNo;
					decimal _cantidad=(pcInfo.Cantidad/noLaminasTotal)*NumLaminas[i];
					float _aforo= Convert.ToInt32(pcInfo.Aforo).Equals(0)?(float)_cantidad:pcInfo.Aforo*NumLaminas[i];
					decimal _cantidadReal = Convert.ToInt32(pcInfo.Aforo).Equals(0)?_cantidad/NumLaminas[i]:Convert.ToDecimal(pcInfo.Aforo);
					//						float _aforo= pcInfo.Aforo*NumLaminas[i];
					//						decimal _cantidadReal = Convert.ToDecimal(pcInfo.Aforo);

					PartidasColorInfo pcInfo1 = new PartidasColorInfo(_groupNo,_cantidad,_aforo,_cantidadReal);
					tmpList.Add(pcInfo1); 
				}
				ColorList[i] = tmpList;
			}
			// fin código descomentado

			sBitacora = string.Format("Llenado de color");
			BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

			dgdColor.DataSource = ColorList[CurrentTab-1];
			dgdColor.DataBind();
			lstColor.DataSource=ColorList[CurrentTab-1];
			lstColor.DataBind();

			int _noLaminas = Convert.ToInt32(NumLaminas[0]);
			for (int k=0;k<lstColor.Items.Count;k++)
			{
				IList _currentVaso= (IList) ColorList[CurrentTab-1];
				PartidasColorInfo  _partidasColor= (PartidasColorInfo) _currentVaso[k];
				int _noComponent = _partidasColor.GroupNo;
				BindChildGrids(txtSecuencia.Text,_noComponent,_noLaminas,k);
			}


			if (Consulted)
			{
				Consult=true;
				//SICALNet.BusinessLogicLayer.Olla blOlla = new SICALNet.BusinessLogicLayer.Olla();
				OInfo = new SICALNet.BusinessEntities.OllaInfo(txtSecuencia.Text,NoContainer,Convert.ToInt32(idPlanta));		
				Olla = (int[])blOlla.SelectOllaMezclasSelected(OInfo);
				//				OInfo = new SICALNet.BusinessEntities.OllaInfo(txtSecuencia.Text,Olla[0],Convert.ToInt32(idPlanta));		
				//				MezOlla=blOlla.SelectOllaMezclas(OInfo);
				//				cmbOlla.DataSource=MezOlla;
				//				cmbOlla.DataValueField="NumeroOlla";
				//				cmbOlla.DataTextField="Descripcion";
				//				cmbOlla.DataBind();
				cmbOlla.Items.FindByValue(Olla[0].ToString()).Selected=true;
				// Code to Load the Existing Data

				//Get Agitador 
				/*for(int i = 0; i < NoContainer; i++)
				{
					SICALNet.BusinessLogicLayer.PartidasMezclas PMezclas = new SICALNet.BusinessLogicLayer.PartidasMezclas();
					NoAgitador[i] = PMezclas.GetAgitador(txtSecuencia.Text, i+1);
					Suborante[i] =	PMezclas.GetSuborante(txtSecuencia.Text, i+1);
				}*/
				SICALNet.BusinessLogicLayer.PartidasMezclas PMezclas = new SICALNet.BusinessLogicLayer.PartidasMezclas();
				IList ASVList = PMezclas.SelectASV(txtSecuencia.Text);
				// Error de lógica, en lugar de consultar 
				//for(int i = 0; i < ASVList.Count; i++)
				for(int i = 0; i < NoContainer; i++)								
				{
					SICALNet.BusinessEntities.PartidasMezclasInfo PMInfo = new SICALNet.BusinessEntities.PartidasMezclasInfo();
					PMInfo = (SICALNet.BusinessEntities.PartidasMezclasInfo)ASVList[i];
					NoAgitador[i] = PMInfo.NoAgitador;
					Suborante[i] =	PMInfo.Suborante;
					VisInitial[i] = PMInfo.ViscosidadInicial;
					VisFinal[i] = PMInfo.ViscosidadFinal;
					SecSobrante[i]=PMInfo.SecuenciaSobrante;

				}
				txtAgitador.Text = NoAgitador[CurrentTab-1].ToString();
				
				// Calcula el sobrante del aditivo de esa olla
				// double Sobrante = 0;
				// Suborante[CurrentTab-1]=float.Parse(Sobrante.ToString());

				txtSubrante.Text = Suborante[CurrentTab-1].ToString();
				sub.Text = txtSubrante.Text;
				lblSubrante.Text = Suborante[CurrentTab-1].ToString();


				txtViscosidadInicial.Text=VisInitial[CurrentTab-1];
				txtViscosidadFinal.Text=VisFinal[CurrentTab-1];		
				txtSecuenciaSobrante.Text=SecSobrante[CurrentTab-1];
				
				// For PMMA related Records
				for(int i = 0; i < NoContainer; i++)
				{
					//SICALNet.BusinessLogicLayer.PartidasMezclas PMezclas = new SICALNet.BusinessLogicLayer.PartidasMezclas();
					PMMAList[i] = (ArrayList) PMezclas.Select(txtSecuencia.Text, 1,Olla[i]);
				}
				dgdPMMA.DataSource = PMMAList[CurrentTab-1];
				dgdPMMA.DataBind();								
			}
			else
			{
				Consult=false;				

				// Extract Data for PMMA Grid
				for(int i = 0; i < NoContainer; i++)
				{	
					SICALNet.BusinessLogicLayer.PartidasMezclas PMezclas = new SICALNet.BusinessLogicLayer.PartidasMezclas();
					PMMAList[i] = (ArrayList) PMezclas.SelectPMMA(txtSecuencia.Text);

					ArrayList tmpList = new ArrayList();
					for(int j = 0; j < PMMAList[i].Count; j++)
					{
						PartidasMezclasInfo pmInfo = new PartidasMezclasInfo();						
						pmInfo = (PartidasMezclasInfo) PMMAList[i][j];
						
						float ColorSUM = 0;
						// float auxAforo = 0;
						for(int k = 0; k < ColorList[i].Count; k++)
						{
							PartidasColorInfo pcInfo = new PartidasColorInfo();
							pcInfo = (PartidasColorInfo) ColorList[i][k];
							
							ColorSUM+=Convert.ToSingle(pcInfo.Aforo);						
						}
						float AditivosSUM = 0;
						for(int k = 0; k < AditivosList[i].Count; k++)
						{
							PartidasAditivosInfo paInfo = new PartidasAditivosInfo();
							paInfo = (PartidasAditivosInfo) AditivosList[i][k];

							AditivosSUM += Convert.ToSingle(paInfo.Cantidad);
						}

						// Calcula el sobrante del aditivo de esa olla
						//double Sobrante = blOlla.SobranteAditivo(OInfo);		
						//float TotPMMACantidad = (pmInfo.Cantidad * NumLaminas[i]) - ((ColorSUM + AditivosSUM + Convert.ToSingle(Sobrante))/1000);
						//float TotPMMACantidad = (pmInfo.Cantidad * NumLaminas[i]) - ((ColorSUM + AditivosSUM + Convert.ToSingle(MontoSobrante[i].ToString()))/1000);
						// JJMR 20/06/2015 Solicitada por Federico en correo 18 de Junio de 2015
						float TotPMMACantidad = (pmInfo.Cantidad * NumLaminas[i]) - ((ColorSUM + AditivosSUM)/1000)- Convert.ToSingle(MontoSobrante[i].ToString());

						PartidasMezclasInfo pmInfo1 = new PartidasMezclasInfo(pmInfo.CodigoSAP, pmInfo.Descripcion, TotPMMACantidad,0);
						pmInfo1.NoTanque = pmInfo.NoTanque;
						tmpList.Add(pmInfo1);
					}

					PMMAList[i] = tmpList;
				}

				sBitacora = string.Format("Llenado de dgdPMMA");
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				dgdPMMA.DataSource = PMMAList[CurrentTab-1];
				dgdPMMA.DataBind();

				txtOllaRegistro.Text = ""; txtAgitador.Text=""; lblErrorMsg.Text = "";
			}
		}

	//	 Procedure to Set Focus to Controls
		/*** comentado por alejandro.hernandez@nasoft.com 07/03/2006 ***/
//		private void SetFocus(object sender)
//		{
//			if(sender.GetType().Name=="TextBox")
//				Page.RegisterStartupScript("focus","<SCRIPT language='javascript'>" + "document.all('" + ((TextBox)sender).ClientID + "').focus();" + "</SCRIPT>");
//		}

		private void BindChildGrids(string secuencia, int noComponente, int noLaminas, int k)
		{
			SICALNet.BusinessLogicLayer.PartidasColor PartidasColor = new SICALNet.BusinessLogicLayer.PartidasColor();
			IList tmpList;
			tmpList = (IList) PartidasColor.Load(secuencia, noLaminas,noComponente);
			
//			if(noComponente>1)
//				noComponente = 1;
//			DataGrid dgdInnerColor=((DataGrid)lstColor.Items[noComponente-1].FindControl("dgdColorWO"));
			DataGrid dgdInnerColor=((DataGrid)lstColor.Items[k].FindControl("dgdColorWO"));

			if (tmpList.Count > 0)
			{
				dgdInnerColor.DataSource = tmpList;
				dgdInnerColor.DataBind();
				dgdInnerColor.Visible=dgdInnerColor.Items.Count>0;
			}
		}


		
		private void btnLiberar_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				SICALNet.Utilities.Validation Validate = new SICALNet.Utilities.Validation();

				// Validation for Agitador (Should be Number)
				if (txtAgitador.Text!="" && !Validate.IsInteger(txtAgitador.Text))
					throw new Exception("El numero de agitador debe ser un número entero");

				if(this.cmbOlla.SelectedIndex == -1)
					throw new Exception("Valor inválido en el campo Olla"); 			
				StoreCurrentTAB();

				string delimStr = ",";
				char [] delimiter = delimStr.ToCharArray();			
				string[] ArrSecuencias = txtSecuencia.Text.Split(delimiter);
				int IdArea = Convert.ToInt32(ConfigurationManager.AppSettings["MixturesRoomId"]);

				//			int NoAgitador = (txtAgitador.Text.Trim()==""?0:Convert.ToInt32(txtAgitador.Text.Trim()));

				
				for(int i=0;i<NoContainer-1;i++)
				{
					for(int j=i+1;j<NoContainer;j++)
					{
						if(Olla[i]==Olla[j])
						{
							if(Olla[i] == 0)
							{
								throw new Exception("No se libéró la secuencia debido a que la olla "+cmbOlla.Items[0].Text+" está seleccionada dos veces.");
							}
							else
							{
								throw new Exception("No se libéró la secuencia debido a que la olla "+cmbOlla.Items.FindByValue(Olla[i].ToString()).Text+" está seleccionada dos veces.");
							}
						}
					}
				}


				double TotalPMMA=0;
				bool blnTanqueActualizado=false;
				foreach(string Secuencia in ArrSecuencias)
				{
					string currentSecuence =string.Empty;
					if (CombinasList.Count>0)
					{
						currentSecuence = Secuencia.Substring(1);
						currentSecuence=currentSecuence.Substring(0,currentSecuence.Length-1);
					}
					else 
						currentSecuence=Secuencia;


					ArrayList tmpList = new ArrayList();
				

					for(int iLoop = 0; iLoop < NoContainer; iLoop++)
					{
						int NumeroOlla = Olla[iLoop];
						int NoLaminas = NumLaminas[iLoop];

						//---------------------------------------------------
						// To Store PMMA Info into PartidasMezclas
						//---------------------------------------------------
						for(int i = 0; i < PMMAList[iLoop].Count; i++)
						{
							// Used to retrive CodigoSAP, Cantidad for PMMA
							PartidasMezclasInfo pmInfo = new PartidasMezclasInfo();
							pmInfo = (PartidasMezclasInfo)PMMAList[iLoop][i];
				
							string CodigoSAP = pmInfo.CodigoSAP;
							float Cantidad = pmInfo.Cantidad;
							float CantidadReal = pmInfo.CantidadReal;
							TotalPMMA = TotalPMMA + pmInfo.CantidadReal;
							int TipoComponents = 1; // 1 - for PMMA Components Type Value



							//-- Descomente este código HRV 11/Sep/2004						
							
							PartidasMezclas PMezclass = new SICALNet.BusinessLogicLayer.PartidasMezclas();
							int IdTipoPMMA = PMezclass.GetIdTipoPMMA(CodigoSAP);
			 
							ArrayList TanqueList = new ArrayList();
							
							// 
							//string IdTanque = ((Label)dgdPMMA.Controls[0].Controls[1].FindControl("lblIDTanque")).Text.ToString();
							string IdTanque = pmInfo.NoTanque.ToString(); 
							TanqueInfo tInfo = new TanqueInfo(IdTipoPMMA);
							//En esta consulta falta verificas como asignan el tanque a esta secuencia
							SICALNet.BusinessLogicLayer.Tanque Tanque = new SICALNet.BusinessLogicLayer.Tanque();
							TanqueList = (ArrayList) Tanque.GetTankInfo(tInfo);

							if(TanqueList.Count ==0)throw new Exception("No existe un tanque con el tipo de PMMA requerido, consulte con el área de Reacción"); 
							
							if(TanqueList.Count > 1)
							{
								//string AuxIdTanque = ((DropDownList)dgdPMMA.Controls[0].Controls[1].FindControl("cboTanque")).SelectedItem.Value;
								for(int j =0;j<TanqueList.Count;j++)
								{
									if( ((TanqueInfo) TanqueList[j]).IdTanque.ToString() == IdTanque)
									{
										tInfo = (TanqueInfo) TanqueList[j];
										break;
									}
								}
							}
							else
							{
								tInfo = (TanqueInfo) TanqueList[0];
							}
 
							// Procedure to discount Tank Quantity from Real Quantity
							double TankQty;
							TankQty = pmInfo.CantidadReal*-1;
			
							// To Update a particular Tanque with the remaining (Discounted) qty
							TanqueInfo tInfo1 = new TanqueInfo(tInfo.IdTanque, string.Empty, TankQty);
							if(!blnTanqueActualizado)
							{
							
								Tanque.UpdateTanque(tInfo1);
							}

							//- Fin del código descomentado

							PartidasMezclasInfo pmInfo1 = new PartidasMezclasInfo(currentSecuence, IdArea, CodigoSAP, NumeroOlla, TipoComponents, NoLaminas, Cantidad, CantidadReal, NoAgitador[iLoop],0,Suborante[iLoop],VisInitial[iLoop],VisFinal[iLoop],SecSobrante[iLoop],Convert.ToInt16(iLoop));						
							pmInfo1.NoTanque = tInfo.IdTanque; 
							tmpList.Add(pmInfo1);							
						}


					}
					blnTanqueActualizado=true;
					if (tmpList.Count > 0)
					{
						SICALNet.BusinessLogicLayer.PartidasMezclas PMezclas = new SICALNet.BusinessLogicLayer.PartidasMezclas();
				
						//Delete the Existing Records in PartidasColor to adopt the Modification & Insertion
						PMezclas.Delete(currentSecuence);
						PMezclas.Insert(tmpList);
						SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(currentSecuence,Convert.ToInt32(ConfigurationManager.AppSettings["MixturesRoomId"]),Context.User.Identity.Name);
						SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						BLOrdenes.UpdateLoginForm(OTInfo);
				
					}
					int IdStatus = Convert.ToInt32(ConfigurationManager.AppSettings["StatusRelease"]); 

					//Activate Next Area And update Active Area in Programma Production for this currentSecuence
					//Depending on sequence available in "FlujoArea" Table
					FlujoArea objFlujoArea = new FlujoArea();
					objFlujoArea.ActivateDependingAreas(currentSecuence,IdArea);
			
					// To Release the Work Order
					OrdenesTrabajoInfo WOInfo = new OrdenesTrabajoInfo(currentSecuence, IdArea, IdStatus, DateTime.Now.Date.ToString("dd/MMM/yyyy"), Context.User.Identity.Name); 
					SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
					WorkOrder.UpdateStatus(WOInfo);
				}
				Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"La Orden de Trabajo se libero exitosamente"+"')" + "<" + "/script>");
				cmdLiberar.Enabled = false;
				btnAgregar.Enabled = false;
				dgdPMMA.Columns[4].Visible=true;
				dgdPMMA.Columns[3].Visible=false;
				cmbOlla.Visible=false;
				lblOlla.Visible=false;
				txtSecuenciaSobrante.Enabled=false;
				txtSubrante.Enabled=false;
				txtAgitador.Enabled=false;
				txtViscosidadFinal.Enabled=false;
				txtViscosidadInicial.Enabled=false;


				string sBitacora = string.Format("Liberación de Secuencia {0} en Fase de mezclas, por el usuario {1}",txtSecuencia.Text, this.User.Identity.Name.ToString());
				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				Response.Redirect("ConsultMixturesWO.aspx");
			}
			catch (Exception ex)
			{
				//to display the msg for user
								string ScriptString="<script language='javascript'>alert('"+ ex.Message+"');</script>"; 								
								ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
				//throw;
			}
			

		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ConsultMixturesWO.aspx");
		}

		
		private void btnAgregarMensaje_Click(object sender, System.EventArgs e)
		{
			string Secuencia;
			if(this.blnSecuenciaCombinada)
				Secuencia = this.secuenciaCombinada.Substring(0,this.secuenciaCombinada.IndexOf(","));
			else
				Secuencia = txtSecuencia.Text.ToString();
				
			string IdArea= ConfigurationManager.AppSettings["MixturesRoomId"].ToString();
			string CodigoSAP=Request.QueryString["CodigoSAP"].ToString();
			string matDesc=txtUTEC.Text.Trim();
			RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodigoSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");
		}

		
		public void TextChangedPMMA(object sender, System.EventArgs e)
		{
			//To get the string "ctl2" - that is available between "_" of the Client ID
			//Client Id Example = "dgdDefecto__ctl2__
			/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/
			TextBox txtSender = (TextBox)sender;
			string id = txtSender.ClientID;
			//string id =(((TextBox)sender).ClientID);							//Get the Client ID "dgdAditivos__ctl2_txtAditivosRegistro"
			/*** fin de modificación ***/
			
			int First = id.IndexOf("_");												// Get the First Underscore("_") Position
			int Second = id.LastIndexOf("_");											// Get the Next Underscore("_") Position
			int Index = Convert.ToInt32((id.Substring(0,Second)).Substring(First+5));	//Get that index ("2") which is avilable after "ctl"

			Label lblCantidad = (Label) dgdPMMA.Controls[0].Controls[Index-1].FindControl("lblPMMACantidad");
			Label lblDiference = (Label) dgdPMMA.Controls[0].Controls[Index-1].FindControl("lblDiferenciasPMMA");

			/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/
			decimal Diff = Convert.ToDecimal(lblCantidad.Text) - Convert.ToDecimal(txtSender.Text);
			//decimal Diff = Convert.ToDecimal(lblCantidad.Text) - Convert.ToDecimal(((TextBox)sender).Text);
			/*** fin de modificación ***/

			lblDiference.Text =  Diff.ToString();

		}


		private void dgdPMMA_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
			{
					
				Label l=(Label)e.Item.FindControl("lblDiferenciasPMMA");
				l.Text= (Convert.ToDecimal(((Label)e.Item.FindControl("lblPMMACantidad")).Text) 
					- Convert.ToDecimal(((TextBox)e.Item.FindControl("txtPMMARegistro")).Text)).ToString();
				
				Label lPPMA = (Label)e.Item.FindControl("lblPMMACodigoSAP");
				Label lTanqueSel = (Label)e.Item.FindControl("lblIDTanqueSelected");

				SICALNet.BusinessLogicLayer.Tanque BLTanque = new SICALNet.BusinessLogicLayer.Tanque();
				IList LTanque = BLTanque.SelectTankBySAPCode(lPPMA.Text,Convert.ToInt32(idPlanta));

				if(LTanque.Count > 1)
				{					
					DropDownList cboT = (DropDownList)e.Item.FindControl("cboTanque");
					cboT.DataSource = LTanque;
					cboT.DataTextField = "TanqueDesc";
					cboT.DataValueField = "IdTanque";
					cboT.DataBind(); 						
					cboT.Visible = true;

					if(lTanqueSel.Text != "0")
					{
						cboT.Items.FindByValue(lTanqueSel.Text).Selected=true;
					}

				}
				else
				{
					if(LTanque.Count>0)
					{
						Label lIDTanque = (Label)e.Item.FindControl("lblIDTanque");
						lIDTanque.Text = ((SICALNet.BusinessEntities.TanqueInfo)LTanque[0]).IdTanque.ToString(); 
						Label lTanque = (Label)e.Item.FindControl("lblTanque");
						lTanque.Text = ((SICALNet.BusinessEntities.TanqueInfo)LTanque[0]).TanqueDesc.ToString(); 
						lTanque.Visible = true;
					}
				}




			}
		}

		/*public void TextChangedAditivos(object sender, System.EventArgs e)
		{
			//To get the string "ctl2" - that is available between "_" of the Client ID
			//Client Id Example = "dgdDefecto__ctl2__
			string id =(((TextBox)sender).ClientID);							//Get the Client ID "dgdAditivos__ctl2_txtAditivosRegistro"
			int First = id.IndexOf("_");												// Get the First Underscore("_") Position
			int Second = id.LastIndexOf("_");											// Get the Next Underscore("_") Position
			int Index = Convert.ToInt32((id.Substring(0,Second)).Substring(First+5));	//Get that index ("2") which is avilable after "ctl"

			Label lblCantidad = (Label) dgdAditivos.Controls[0].Controls[Index-1].FindControl("lblAditivosCantidad");
			Label lblDiference = (Label) dgdAditivos.Controls[0].Controls[Index-1].FindControl("lblDiferenciasAditivos");

			decimal Diff = Convert.ToDecimal(lblCantidad.Text) - Convert.ToDecimal(((TextBox)sender).Text);
			lblDiference.Text =  Diff.ToString();

		}*/

		

		public void TextChangedColor(object sender, System.EventArgs e)
		{
			//To get the string "ctl2" - that is available between "_" of the Client ID
			//Client Id Example = "dgdDefecto__ctl2__
			/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/
			TextBox txtSender = (TextBox)sender;
			string id = txtSender.ClientID;
			//string id =(((TextBox)sender).ClientID);							//Get the Client ID "dgdAditivos__ctl2_txtAditivosRegistro"
			/*** fin de modificación ***/

			int First = id.IndexOf("_");												// Get the First Underscore("_") Position
			int Second = id.LastIndexOf("_");											// Get the Next Underscore("_") Position
			int Index = Convert.ToInt32((id.Substring(0,Second)).Substring(First+5));	//Get that index ("2") which is avilable after "ctl"

			Label lblCantidad = (Label) dgdColor.Controls[0].Controls[Index-1].FindControl("lblColorCantidad");
			Label lblDiference = (Label) dgdColor.Controls[0].Controls[Index-1].FindControl("lblDiferenciasColor");

			/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/
			decimal Diff = Convert.ToDecimal(lblCantidad.Text) - Convert.ToDecimal(txtSender.Text);
			//decimal Diff = Convert.ToDecimal(lblCantidad.Text) - Convert.ToDecimal(((TextBox)sender).Text);
			/*** fin de modificación ***/

			lblDiference.Text =  Diff.ToString();

		}
//		private void ColorAdjustment(int NoContainer,int[] NoLaminas)
//		{			
//			string Codigosap = Request.QueryString["CodigoSAP"].ToString();
//			SICALNet.BusinessLogicLayer.PartidasColor BLLPC=new SICALNet.BusinessLogicLayer.PartidasColor();
//			IList pcList = (IList) BLLPC.GetNoVaso(Request.QueryString["Secuencia"].ToString());
//			Aforo = new float[pcList.Count];
//			int cIndex=0;
//			double BaseThickness = BLLPC.GetBaseThickness(Codigosap,Convert.ToInt32(idPlanta));
//			double ProductThickness = BLLPC.GetProductThickness(Codigosap,Convert.ToInt32(idPlanta));
//			double ProductWeight = BLLPC.GetProductWeight(Codigosap,Convert.ToInt32(idPlanta));
//			for (int j = 0; j < NoContainer; j++)
//			{
//				ArrayList tmpList = new ArrayList();
//				
//				for (int i = 0; i < pcList.Count; i++)
//				{
//					IList FormColor = (ArrayList) BLLPC.GetFormColor(Codigosap,i+1,0,Convert.ToInt32(idPlanta.ToString()),Convert.ToInt32(Request.QueryString["IdLinea"].ToString()));
//					PartidasColorInfo pcInfo1 = new PartidasColorInfo();
//					decimal Cantidad=0;
//					for(int k=0; k < FormColor.Count; k++)
//					{
//						PartidasColorInfo pcInfo = new PartidasColorInfo();
//						PartidasColorInfo pcInfo2 = new PartidasColorInfo();
//						pcInfo = (PartidasColorInfo) FormColor[k];
//						pcInfo2 = (PartidasColorInfo) pcList[i];
//						double Percentage = Convert.ToDouble(pcInfo.Porcentaje);
//						Cantidad+=Convert.ToDecimal(NoLaminas[j] * (((Percentage * BaseThickness)/ProductThickness)*ProductWeight/100*1000));
//						pcInfo1 = new PartidasColorInfo(pcInfo.CodigoSAP, pcInfo.Descripcion, Cantidad,Convert.ToDecimal(pcInfo2.Aforo*NoLaminas[j]),i+1,string.Empty,pcInfo2.Aforo);
//						Aforo[i]=pcInfo2.Aforo;
//					}
//					tmpList.Add(pcInfo1);									
//				}
//				ColorList[cIndex++] = (ArrayList)tmpList;
//			}
//		}

		
		private void SumRegisterPerOlla()
		{
			float sum=0;
			int IdReleaseStatus = Convert.ToInt32(ConfigurationManager.AppSettings["StatusRelease"]);
			if (IdStatus == IdReleaseStatus)
			{
				for(int i=0;i<dgdPMMA.Items.Count;i++)
					sum+=Convert.ToSingle(((Label)dgdPMMA.Items[i].FindControl("lblPMMARegistro")).Text);
				
			}
			else
			{
				for(int i=0;i<dgdPMMA.Items.Count;i++)
					sum+=Convert.ToSingle(((TextBox)dgdPMMA.Items[i].FindControl("txtPMMARegistro")).Text);
			
			}
			txtOllaRegistro.Text=sum.ToString();

		}

		private int GetIdLinea(string secuencia)
		{

			int IdLinea = 0;			
			SICALNet.BusinessLogicLayer.Programa  blPP = new SICALNet.BusinessLogicLayer.Programa();
			IList lpp = blPP.Load(secuencia);
			if(lpp.Count > 0 )
			{
				IdLinea = ((SICALNet.BusinessEntities.ProgramaInfo )lpp[0]).IdLinea;
			}
			return IdLinea;
		}
	}
}