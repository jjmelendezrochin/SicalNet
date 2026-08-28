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
using SICALNet.Interfaces;
using SICALNet.BusinessLogicLayer;
using SICALNet.Utilities;




 namespace UserInterface.Forms.Production.CuredWO
 {
	 /// <summary>
	 /// Summary description for ConsultarCuredWO.
	 /// </summary>
	 public class ConsultarCuredWO : System.Web.UI.Page
	 {
		 protected System.Web.UI.WebControls.Label lblHd;
		 protected System.Web.UI.WebControls.Panel pnlCured;
		 protected System.Web.UI.WebControls.Label Label1;
		 protected System.Web.UI.WebControls.Label lblSecuencia;
		 protected System.Web.UI.WebControls.Label Label3;
		 protected System.Web.UI.WebControls.DropDownList cboSel;
		 protected System.Web.UI.WebControls.Label Label5;
		 protected System.Web.UI.WebControls.Label lblUTEC;
		 protected System.Web.UI.WebControls.Label Label7;
		 protected System.Web.UI.WebControls.TextBox txtTempCuba;
		 protected System.Web.UI.WebControls.Label Label9;
		 protected System.Web.UI.WebControls.Label lblCandidad;
		 protected System.Web.UI.WebControls.Label Label11;
		 protected System.Web.UI.WebControls.TextBox txtNumero;
		 protected System.Web.UI.WebControls.Label Label13;
		 protected System.Web.UI.WebControls.Label lblFamilia;
		 protected System.Web.UI.WebControls.Button btnComienzo;
		 protected System.Web.UI.WebControls.Label Label2;
		 protected System.Web.UI.WebControls.Label lblTiemp;
		 protected System.Web.UI.WebControls.Label Label4;
		 protected System.Web.UI.WebControls.Label lblTemparaturo;
		 protected System.Web.UI.WebControls.Button btnAgregar;
		 protected System.Web.UI.WebControls.Button btnLiberar;
		 protected System.Web.UI.WebControls.Button btnCancel;
		 public static Label[] lblCuba;
		 static string Codigo;
		 static DateTime InitTime;
		 protected System.Web.UI.WebControls.Label lblTitle;
		 protected System.Web.UI.WebControls.Label Label6;
		 protected System.Web.UI.WebControls.Label lblFecha;
		 protected System.Web.UI.WebControls.Label Label8;
		 protected System.Web.UI.WebControls.TextBox txtPiso;
		 protected System.Web.UI.WebControls.Label Label10;
		 float CuredTime;
		 protected System.Web.UI.WebControls.Label Label12;
		 protected System.Web.UI.WebControls.Label lblPorcentage;
		 protected System.Web.UI.WebControls.Label lblPer;
		 protected static int localAreaId,TotalDuration;
		 protected System.Web.UI.WebControls.Button btnTemperature;
		 protected System.Web.UI.WebControls.TextBox txtHidden;
	 	protected System.Web.UI.WebControls.Image Image1;
	 	protected System.Web.UI.WebControls.Label Label14;
	 	protected System.Web.UI.WebControls.Label Label15;
	 	protected System.Web.UI.WebControls.CheckBox CheckBox1;
		 protected static string FinalTime="";
	 	protected System.Web.UI.WebControls.Label Label16;
	 	protected System.Web.UI.WebControls.Label lblTiempreal;
		 protected System.Web.UI.HtmlControls.HtmlInputText tt;
	
		 private void Page_Load(object sender, System.EventArgs e)
		 {
			 Response.Cache.SetExpires(DateTime.Now);
			 Response.Cache.SetCacheability(HttpCacheability.NoCache);
			 Response.Cache.SetValidUntilExpires(false);
			 Response.Cache.SetNoStore();

			 // Put user code to initialize the page here
			 
				 if(!IsPostBack)
			 {

				btnLiberar.Attributes.Add(
					"onclick",
					"var boton=this;" +
					"SicalAlert.confirmar(" +
					   "'¿Está seguro que desea liberar esta secuencia?', " +
					   "'Confirmar liberación', " +
					   "function(){" +
						   "boton.onclick=null;" +
						   "boton.click();" +
					   "}" +
					");" +
					"return false;"
					);
				btnCancel.Attributes.Add("onClick","showWaitControls()");
					 btnAgregar.Attributes.Add("onClick","showWaitControls()");
					 btnComienzo.Attributes.Add("onClick","showWaitControls()");
					 btnTemperature.Attributes.Add("onClick","showWaitControls()");
					 txtNumero.Attributes.Add("onfocus","stop_refresh()"); 
					 txtTempCuba.Attributes.Add("onfocus","stop_refresh()");
					 cboSel.Attributes.Add("onfocus","stop_refresh()"); 

					 // Display the Messages in Multiline Text box
					 prcBindForm();				 
					 DisplayFloorMessage();

					 if (Request.QueryString["Status"].ToString()==ConfigurationSettings.AppSettings["StatusRelease"])
					 {
						 btnComienzo.Enabled=false;
						 btnTemperature.Enabled=false;
						 btnLiberar.Enabled=false;
						 btnAgregar.Enabled=false;
					 }					 
				 
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
			 localAreaId=Convert.ToInt32(ConfigurationSettings.AppSettings["CuredRoomId"]);
		 }
		
		 /// <summary>
		 /// Required method for Designer support - do not modify
		 /// the contents of this method with the code editor.
		 /// </summary>
		 private void InitializeComponent()
		 {    
			 this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			 this.btnTemperature.Click += new System.EventHandler(this.btnTemperature_Click);
			 this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
			 this.btnComienzo.Click += new System.EventHandler(this.btnComienzo_Click);
			 this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			 this.Load += new System.EventHandler(this.Page_Load);

		 }
		#endregion

		 
		 private void DisplayFloorMessage()
		 {
			 // Display the Messages in Multiline Text box
			 MensajePisoInfo mpInfo = new MensajePisoInfo(lblSecuencia.Text,string.Empty,localAreaId);
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


		 private void prcBindForm()
		 {
			 try
			 {
				 //clear current Cubas
				 pnlCured.Controls.Clear();

				 //Load details of the production program
				 Programa programLoader= new Programa();
				 ArrayList listaProgramas=(ArrayList) programLoader.Load(Request.QueryString["Secuencia"]);
				 //if (listaProgramas.Count == 0)
				 //	throw new Exception(string.Format("No se pudo cargar la clave del producto al que pertenece la secuencia {0}",Session["Secuencia"].ToString()));
				
				 //Obtain codigo SAP of the selected sequence.
				 ProgramaInfo loadedProgram =(ProgramaInfo) listaProgramas[0];
				 Codigo = loadedProgram.CodigoSAP;
				 int IdLinea = loadedProgram.IdLinea;
				 int IdPlanta=1;
				 if (IdLinea >3 && IdLinea!=9)
					 IdPlanta=2;

				 //to get material details
				 MaterialInfo BEmat=new MaterialInfo(Codigo,"",0,"",0,string.Empty,0,string.Empty,0,0,0,0,0,"","","","","","","","","",IdPlanta,false);
				 Material BLLMat = new Material();
				 IList RsMaterial = BLLMat.SelectMaterialList(BEmat);
				 if (RsMaterial.Count == 0)
					 throw new Exception(string.Format("No se pudieron cargar los detalles del producto {0}",Codigo));

				 MaterialInfo BEmaterial = (MaterialInfo) RsMaterial[0];
				 int FamPdt=BEmaterial.IdFamiliaProducto;
				 string Esp=BEmaterial.IdEspesor;

				 //to get the form temparature details
				 FormTemperaturaInfo BEFrmTemp = new FormTemperaturaInfo(FamPdt,Esp,IdLinea,0,0,0,0);
				 FormTemperatura BLLTemp = new FormTemperatura();
				 IList RsFrmTemp = BLLTemp.SelectFormTemperatura(BEFrmTemp);
				 if (RsFrmTemp.Count == 0)
				{
					string mensaje = (string.Format("No existe formulación de temperatura para el producto {0}", Codigo));

					ClientScript.RegisterStartupScript(
						this.GetType(),
						"CubaOcupada",
						"SicalAlert.mostrar('" + mensaje + "', 'advertencia');",
						true
					);
				}

				BEFrmTemp = (FormTemperaturaInfo) RsFrmTemp[0]; 

				 //to assign the values into the lables
				 lblSecuencia.Text = loadedProgram.Secuencia;
				 lblUTEC.Text =BEmaterial.Descripcion;
				 lblCandidad.Text = loadedProgram.Cantidad.ToString();
				 lblFamilia.Text = BEmat.FamiliaProductoDesc;
				 lblFecha.Text= loadedProgram.Fecha;
				 txtNumero.Text = loadedProgram.KCT;
				 CuredTime=BEFrmTemp.TiempoCurado;
				 lblTiempreal.Text = BEFrmTemp.TiempoCurado.ToString();
				 lblTiemp.Text = BEFrmTemp.TiempoCurado.ToString()+" minutos";
				 TotalDuration=	BEFrmTemp.TiempoCurado;
				 lblTemparaturo.Text = BEFrmTemp.TempCurado.ToString()+" grados";

				 //Load Combo of Cubas
				 CubaInfo BECuba = new CubaInfo(0,IdLinea,false,string.Empty,string.Empty);
				 Cuba BLLCuba = new Cuba();
				 IList RsCuba = BLLCuba.SelectCuba(BECuba);
				 cboSel.DataSource = RsCuba;
				 cboSel.DataTextField = "Denominacion";
				 cboSel.DataValueField= "Cuba";
				 cboSel.DataBind();

				 //to get details of current Partidas Curado
				 PartidasCuradoInfo BEPrtCurdo = new PartidasCuradoInfo(lblSecuencia.Text,localAreaId,IdLinea,0,0,DateTime.MinValue,DateTime.MinValue,DateTime.MinValue,string.Empty);
				 PartidasCurado BLLPrtCurdo = new PartidasCurado();
				 IList RsPrtCurdo = BLLPrtCurdo.SelectPartidasCurado(BEPrtCurdo);
				
				 //If there is PartidaCurado for this sequence
				 if (RsPrtCurdo.Count!=0)
				 {
					 //Disable trigger button
					 btnComienzo.Enabled=false;
					 //Get PartidasInfo Details
					 BEPrtCurdo = (PartidasCuradoInfo) RsPrtCurdo[0];
					
					 //Real Temp
					 txtTempCuba.Text=BEPrtCurdo.TemperaturaReal.ToString();
					 //Real Cuba
					 cboSel.Items.FindByValue(BEPrtCurdo.Cuba.ToString()).Selected=true;
					 cboSel.Enabled=false;
					 btnTemperature.Enabled=true;
					 //Real KCT
					 txtNumero.Text=BEPrtCurdo.NoCassette;
					 txtNumero.Enabled=false;
				 }

				 //Display Panel of Cubas
				 if (RsCuba.Count==0)
					 throw new Exception("No existen cubas para la línea seleccionada, Favor de verificar.");
				 else
					 LoadCubasPanel(RsCuba);

			 }
			 catch
			 {
//				 //to display the msg for user
//				 string ScriptString="<script language='javascript'>alert('"+ errHand.Message +"');</script>"; 
//				 Page.RegisterStartupScript("ClientScript",ScriptString);
//				 btnComienzo.Enabled=false;
//				 btnAgregar.Enabled=false;
//				 btnLiberar.Enabled=false;

				 throw;
			 }
		 }

		 

//		 private void LoadCubasPanel()
//		 {
//			 CubaInfo BECuba = new CubaInfo(0,Convert.ToInt32(Request.QueryString["IdLinea"]),false,string.Empty,string.Empty);
//			 Cuba BLLCuba = new Cuba();
//			 IList RsCuba = BLLCuba.SelectCuba(BECuba);
//			 LoadCubasPanel(RsCuba);		
//		 }

		 private void LoadCubasPanel(IList listOfCubas)
		 {
			 string currentSequence=string.Empty;
			 DateTime currentIniDate=DateTime.Now;
			 DateTime currentFinDate=DateTime.Now;
			 CubaInfo BECuba;

			 for (int ILoop=0; ILoop < listOfCubas.Count; ILoop++)
			 {
				 BECuba = (CubaInfo) listOfCubas[ILoop];
				 if (BECuba.Ocupada)
				 {
					 //to get details of current Partidas Curado
					 PartidasCuradoInfo BEPrtCurdo = new PartidasCuradoInfo(BECuba.SecuenciaActual,0,0,0,0,DateTime.Now,DateTime.Now,DateTime.Now,string.Empty);
					 PartidasCurado BLLPrtCurdo = new PartidasCurado();
					 IList RsPrtCurdo = BLLPrtCurdo.SelectPartidasCurado(BEPrtCurdo);
				
					 //If there is PartidaCurado for this sequence
					 if (RsPrtCurdo.Count!=0)
					 {
						 //Load data of Sequence being Cured
						 PartidasCuradoInfo loadedPartidaCurado = (PartidasCuradoInfo) RsPrtCurdo[0];
						 currentSequence=loadedPartidaCurado.Secuencia;
						 currentIniDate=loadedPartidaCurado.InicioCurado;
						 currentFinDate=loadedPartidaCurado.FinCurado;
						 if(currentSequence==lblSecuencia.Text)
							 FinalTime=loadedPartidaCurado.FinCurado.ToString();
							
					 }
				 }
	
				 //Add Current Cuba to the Panel
				 pnlCured.Controls.Add(prcCreateLabel(BECuba.Denominacion,BECuba.Ocupada,currentSequence,currentIniDate,currentFinDate));
				 //Add Separator
				 Label lblDummy = new Label();
				 lblDummy.Width=30;
				 lblDummy.BackColor=Color.White;
				 lblDummy.CssClass="standard-text";
				 pnlCured.Controls.Add(lblDummy);

			 }
		 }

		 private Label prcCreateLabel(string cuba,bool ocupada,string secuencia,DateTime horaInicio,DateTime horaFin)
		 {
			 string lblStore;
			 Label lblCubas = new Label();
			 lblCubas.CssClass="standard-text";
			 lblCubas.Width=100;
			 lblCubas.Height=100;
			 lblStore="<center><strong>"+cuba+"</strong></center><hr>";
			 if (ocupada)
			 {
				 if (secuencia != "")
				 {
					 TimeSpan S=horaFin.Subtract(DateTime.Now);
					 if(S.TotalSeconds<=(15*60)&& S.TotalSeconds>0)
					 {
						 lblCubas.ForeColor=Color.Black;
						 lblCubas.BackColor = Color.Orange;
					 }
					 else if(S.TotalSeconds<0)
					 {
						 lblCubas.ForeColor=Color.White;
						 lblCubas.BackColor = Color.Red;
					 }
					 else
					 {
						 lblCubas.ForeColor=Color.Black;
						 lblCubas.BackColor = Color.Yellow;
					 }
					 lblStore += "<center><strong><A href='ConsultarCuredWO.aspx?Secuencia="+secuencia+"&IdLinea="+Request.QueryString["IdLinea"].ToString()+"&Status="+Request.QueryString["Status"].ToString()+"'>Seleccione Aquí</A><br>";
					 lblStore += secuencia+"</strong><br><br>";
//					 lblStore += "Inicio: "+horaInicio.ToShortTimeString()+"<br>";
//					 lblStore += "Fin: "+horaFin.ToShortTimeString()+"<br>";
					 lblStore += "Inicio: "+ horaInicio.ToShortDateString() + " " + horaInicio.ToShortTimeString()+"<br>";
					 lblStore += "Fin: "+horaFin.ToShortDateString() + " " + horaFin.ToShortTimeString()+"<br>";
					 TimeSpan D = horaFin.Subtract(horaInicio);
					 S = DateTime.Now.Subtract(horaInicio);
					 double duration = Math.Round((S.TotalSeconds/D.TotalSeconds)*100,2);
					 if(duration<=100)
						 lblStore += "Per: "+duration.ToString()+"%</center>";
					 else
						 lblStore += "Per:100.00%</center>";	
					 lblCubas.ToolTip=" Haga click aquí para cambiar a la secuencia "+secuencia;
				 }
			 }
			 else
			 {
				 lblCubas.ForeColor=Color.Black;
				 lblCubas.BackColor = Color.LightGreen;
			 }
			 lblCubas.Text = lblStore;
			 return lblCubas;
		 }

		 private void btnComienzo_Click(object sender, System.EventArgs e)
		 {
			 int nocas=0;
			 float temp=0;
			 try
			 {
				 nocas = Convert.ToInt32(txtNumero.Text);
				 temp = Convert.ToSingle(txtTempCuba.Text);
			 }
			 catch
			 {
				 //to display the msg for user
				 string ScriptString="<script language='javascript'>alert('Favor de proporcionar un dato válido en el campo de Temperatura y Número de Cassette');</script>"; 
				 Page.RegisterStartupScript("ClientScript",ScriptString);
			 }

			 try
			 {
				 InitTime = DateTime.Now;
				 // Nasoft - Roberto Carlos Guzman Vargas
				 //DateTime FinalTime = DateTime.Now.AddMinutes(Convert.ToDouble(CuredTime));
				 CuredTime = System.Convert.ToInt16(lblTiempreal.Text.ToString());
				 long tim = Convert.ToInt64(CuredTime) * 600000000;
				 //long startTicks= DateTime.Now.Ticks; 							
				 long tick = DateTime.Now.Ticks + tim;
				 DateTime FinalTime = new DateTime(tick);

				// insertamos los datos en un cadena para su analisis
				 //sintaxis
				 //modulo - accion - cparametos usados
				 //si esta prendida la bandera se hace
				 if (System.Configuration.ConfigurationSettings.AppSettings["CuradoLog"]=="yes")
				 {
					 SICALNet.BusinessLogicLayer.Logger  BLLLstMat= new SICALNet.BusinessLogicLayer.Logger();
					 BLLLstMat.Insertcomando("Fase de Curado - Secuencia: " + lblSecuencia.Text.ToString() + " - Registrar el tiempo fin de una Cuba - Tiempo inicial: " + InitTime.ToString() + " Tiempo de Curado en minutos: " + CuredTime.ToString() + " Tiempo final calculado por el sistema: " + FinalTime.ToString());
				 }
							 
				 nocas = Convert.ToInt32(txtNumero.Text);
				 temp = Convert.ToSingle(txtTempCuba.Text);

				 if (SelectedCubaIsFree(Convert.ToInt32(cboSel.SelectedItem.Value),Convert.ToInt32(Request.QueryString["IdLinea"])))
				 {
					 if (temp<=0)
					 {
						 Page.RegisterStartupScript("Temperatura inválida", "<script language='JavaScript'>"+
							 "alert('La temperatura de la cuba no puede ser un número negativo ni cero.')"+
							 "<" + "/script>");
					 }
					 else
					 {
						 SICALNet.BusinessEntities.PartidasCuradoInfo pcInfo = new SICALNet.BusinessEntities.PartidasCuradoInfo(lblSecuencia.Text,localAreaId,Convert.ToInt32(Request.QueryString["IdLinea"]),Convert.ToInt32(cboSel.SelectedItem.Value),temp,InitTime,FinalTime,InitTime,nocas.ToString());
						 SICALNet.BusinessLogicLayer.PartidasCurado blPC = new SICALNet.BusinessLogicLayer.PartidasCurado();
						 blPC.InsertPartidasCurado(pcInfo);
						 SICALNet.BusinessEntities.CubaInfo CInfo = new SICALNet.BusinessEntities.CubaInfo(Convert.ToInt32(cboSel.SelectedItem.Value),Convert.ToInt32(Request.QueryString["IdLinea"]),true,lblSecuencia.Text,string.Empty);
						 SICALNet.BusinessLogicLayer.Cuba blCuba = new SICALNet.BusinessLogicLayer.Cuba();
						 blCuba.UpdateCuba(CInfo);

						 SICALNet.BusinessEntities.OrdenesTrabajoInfo orInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(lblSecuencia.Text,localAreaId,Convert.ToInt32(ConfigurationSettings.AppSettings["StatusInProcess"]),string.Empty,Context.User.Identity.Name);
						 SICALNet.BusinessLogicLayer.OrdenesTrabajo blOr = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						 blOr.UpdateStatus(orInfo);
						 SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(lblSecuencia.Text,localAreaId,Context.User.Identity.Name);
						 SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						 BLOrdenes.UpdateLoginForm(OTInfo);
						 prcBindForm();
					 }
				 }
				 else
				 {
					string mensaje =
				   "La cuba " + cboSel.SelectedItem.Text.ToString() +
				   " está ocupada, favor de seleccionar otra.";

					ClientScript.RegisterStartupScript(
						this.GetType(),
						"CubaOcupada",
						"SicalAlert.mostrar('" + mensaje + "', 'advertencia');",
						true
					);
				}
			}
			 catch (System.Exception errHand)
			 {
				 //to display the msg for user
				 string ScriptString="<script language='javascript'>alert('"+ errHand.Message +"');</script>"; 
				 Page.RegisterStartupScript("ClientScript",ScriptString);

				 throw;
			 }

		 }


		private bool SelectedCubaIsFree(int selectedCuba,int idLinea)
		{
			CubaInfo selCuba= new CubaInfo(selectedCuba,idLinea,false,string.Empty,string.Empty);
			Cuba BLLCuba = new Cuba();
			CubaInfo BECuba =BLLCuba.Load(selCuba);

			return !BECuba.Ocupada;
		}

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
			string Secuencia = lblSecuencia.Text.ToString();
			string IdArea= ConfigurationSettings.AppSettings["CuredRoomId"].ToString();
			string CodigoSAP=Request.QueryString["CodigoSAP"].ToString();
			string matDesc=lblUTEC.Text.Trim();
			RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodigoSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");	
		}

		private void btnLiberar_Click(object sender, System.EventArgs e)
		{
			try
			{
				TimeSpan timeS;
				try
				{
					timeS=DateTime.Now.Subtract(Convert.ToDateTime(FinalTime));				
				}
				catch
				{
					timeS= new TimeSpan(0);
				}


				if(timeS.TotalSeconds<0)
				{
					RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('LoginPopup.aspx?Phase=Cured&Secuencia="+lblSecuencia.Text+"&Cuba="+cboSel.SelectedItem.Value+"&IdLinea="+Request.QueryString["IdLinea"]+"','anycontent','width=300,height=300,left=100, top=150,status,scrollbars=no'); </script>");						
				}
				else
				{
					//Update the data on Partidas Curado (regarding the Sequence)
					SICALNet.BusinessEntities.PartidasCuradoInfo pcInfo = new SICALNet.BusinessEntities.PartidasCuradoInfo(lblSecuencia.Text,localAreaId,Convert.ToInt32(Request.QueryString["IdLinea"]),Convert.ToInt32(cboSel.SelectedItem.Value),0,DateTime.Now,DateTime.Now,DateTime.Now,txtNumero.Text.Trim());
					SICALNet.BusinessLogicLayer.PartidasCurado blPC = new SICALNet.BusinessLogicLayer.PartidasCurado();

					IList partidasCurado = blPC.SelectPartidasCurado(pcInfo);
					if (partidasCurado.Count>0)
					{
						blPC.UpdatePartidasCurado(pcInfo);
						//Release the Cuba that was being used
						SICALNet.BusinessEntities.CubaInfo CInfo = new SICALNet.BusinessEntities.CubaInfo(Convert.ToInt32(cboSel.SelectedItem.Value),Convert.ToInt32(Request.QueryString["IdLinea"]),false,string.Empty,string.Empty);
						SICALNet.BusinessLogicLayer.Cuba blCuba = new SICALNet.BusinessLogicLayer.Cuba();
						blCuba.UpdateCuba(CInfo);			
						//Activate Next Area And update Active Area in Programma Production for this Secuencia
						//Depending on sequence available in "FlujoArea" Table
						FlujoArea objFlujoArea = new FlujoArea();
						objFlujoArea.ActivateDependingAreas(lblSecuencia.Text,localAreaId);
						//Release the work Order from the Current Area.
						SICALNet.BusinessEntities.OrdenesTrabajoInfo orInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(lblSecuencia.Text,localAreaId,Convert.ToInt32(ConfigurationSettings.AppSettings["StatusRelease"]),DateTime.Now.Date.ToString("dd/MMM/yyyy"),Context.User.Identity.Name);
						SICALNet.BusinessLogicLayer.OrdenesTrabajo blOr = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						blOr.UpdateStatus(orInfo);

						Response.Redirect("ConsultarCured.aspx");
						
//						Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
//							"alert('"+"La Orden de Trabajo para la secuencia "+ lblSecuencia.Text +" se libero exitosamente"+"');self.location.href='ConsultarCured.aspx';</script>");
					}
					else
					{ 
						string script =
						"<script language='JavaScript'>" +
						"SicalAlert.mostrar(" +
							"'No se puede liberar una secuencia que no ha sido procesada.', " +
							"'advertencia'" +
						");" +
						"</script>";
						Page.RegisterStartupScript("alert", script);
					}
				}			
                }
			catch
			{
				//to display the msg for user
//				string ScriptString="<script language='javascript'>alert('"+ errHand.Message +"');</script>"; 
//				Page.RegisterStartupScript("ClientScript",ScriptString);

				throw;
			}
		
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ConsultarCured.aspx");
		}

		private void btnTemperature_Click(object sender, System.EventArgs e)
		{
			try
			{
				float selTemp = float.Parse(txtTempCuba.Text);
				if (selTemp<=0)
					throw new Exception("La temperatura no puede ser un valor negativo ni cero.");


				//Update the Temperature on Partidas Curado (regarding the Sequence)
				SICALNet.BusinessEntities.PartidasCuradoInfo pcInfo = new SICALNet.BusinessEntities.PartidasCuradoInfo(lblSecuencia.Text,localAreaId,Convert.ToInt32(Request.QueryString["IdLinea"]),Convert.ToInt32(cboSel.SelectedItem.Value),Convert.ToSingle(txtTempCuba.Text),DateTime.Now,DateTime.Now,DateTime.Now,txtNumero.Text.Trim());
				SICALNet.BusinessLogicLayer.PartidasCurado blPC = new SICALNet.BusinessLogicLayer.PartidasCurado();
				blPC.UpdateTemperature(pcInfo);
				prcBindForm();
				Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
					"alert('"+"La temperatura fue actualizada existosamente..."+"')"+
					"<" + "/script>");	
			}
			catch(System.Data.SqlClient.SqlException)
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('Proporcione un valor entero positivo para la temperatura.');</script>"; 
				Page.RegisterStartupScript("ClientScript",ScriptString);

			}
			catch
			{				
				throw;
			}
		
		}

		
	}
}
