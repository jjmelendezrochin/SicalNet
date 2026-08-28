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
//using SICALNet.Interfaces;
using SICALNet.BusinessLogicLayer;

namespace UserInterface.Forms.Production.Work_Order.Post_Cured
{
	/// <summary>
	/// Summary description for Consultar_PostCuredWO.
	/// </summary>
	public class Consultar_PostCuredWO : System.Web.UI.Page
	{
		public static string Codigo="";
		public Label[] lblBarrel = new Label[10];

		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.Label lblSecuencia;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label lblUTEC;
		protected System.Web.UI.WebControls.Label lblCantidad;
		protected System.Web.UI.WebControls.Label lblFamiliaProd;
		protected System.Web.UI.WebControls.DropDownList cboZonas;
		protected System.Web.UI.WebControls.TextBox txtTempZona;
		protected System.Web.UI.WebControls.Button cmdMensajePiso;
		protected System.Web.UI.WebControls.Button cmdLiberar;
		protected System.Web.UI.WebControls.Button cmdCancelar;
		protected System.Web.UI.WebControls.Label lblTiempoPost;
		protected System.Web.UI.WebControls.Label lblTempPost;
		protected System.Web.UI.WebControls.Button btnComienzo;
		protected System.Web.UI.WebControls.Panel pnlPostCured;
		protected System.Web.UI.WebControls.TextBox txtKCT;
		int PostCureTime;
		protected System.Web.UI.WebControls.TextBox txtPiso;
		protected System.Web.UI.WebControls.Button btnTemperature;
		protected static int localAreaId;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label lblTiempoPostreal;
		protected static string FinalTime="";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);

			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				//cmdLiberar.Attributes.Add("onclick", "if(confirm('¿Está seguro que desea liberar esta secuencia?')){}else{return false}");
				cmdLiberar.Attributes.Add(
					"onclick",
					"if(this.getAttribute('data-confirmado') == '1') {" +
						"this.removeAttribute('data-confirmado');" +
						"return true;" +
					"}" +
					"var btn=this;" +
					"SicalAlert.confirmar(" +
						"'¿Está seguro que desea liberar esta secuencia?', " +
						"'Confirmar liberación', " +
						"function(){" +
							"btn.setAttribute('data-confirmado','1');" +
							"btn.click();" +
						"}" +
					");" +
					"return false;"
				);


				// Display the Messages in Multiline Text box
				cmdMensajePiso.Attributes.Add("onClick","showWaitControls()");
				btnTemperature.Attributes.Add("onClick","showWaitControls()");
				btnComienzo.Attributes.Add("onClick","showWaitControls()");
				cmdCancelar.Attributes.Add("onClick","showWaitControls()");
				txtKCT.Attributes.Add("onfocus","stop_refresh()"); 
				txtTempZona.Attributes.Add("onfocus","stop_refresh()");
				cboZonas.Attributes.Add("onfocus","stop_refresh()"); 

				prcBindForm();
				DisplayFloorMessage();	
				if(Request.QueryString["Status"] !=null)
				{
					if (Request.QueryString["Status"].ToString()==ConfigurationSettings.AppSettings["StatusRelease"])
					{
						btnTemperature.Enabled=false;
						this.cmdLiberar.Enabled=false;
						this.btnComienzo.Enabled=false;
					}
				}
			}
			else
			{
				LoadZonasPanel();
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
			localAreaId=Convert.ToInt32(ConfigurationSettings.AppSettings["PostCuredRoomId"]);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.cmdMensajePiso.Click += new System.EventHandler(this.btnAgregar_Click);
			this.btnTemperature.Click += new System.EventHandler(this.btnTemperature_Click);
			this.cmdLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
			this.btnComienzo.Click += new System.EventHandler(this.btnComienzo_Click);
			this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DisplayFloorMessage()
		{
			// Display the Messages in Multiline Text box
			MensajePisoInfo mpInfo = new MensajePisoInfo(lblSecuencia.Text,string.Empty,Convert.ToInt32(ConfigurationSettings.AppSettings["PostCuredRoomId"]));
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
				//Clear Zones arrangement
				pnlPostCured.Controls.Clear();

				//to get the programa produccion details
				Programa BLLPrg = new Programa();
				IList RsPrg = BLLPrg.Load(Request.QueryString["Secuencia"]);
				if (RsPrg.Count == 0)
					throw new Exception("There is no record available for this secuencia");
				
				ProgramaInfo BEprg = (ProgramaInfo) RsPrg[0];
				
					
				txtKCT.Text=BEprg.KCT;
				Codigo = BEprg.CodigoSAP;
				int IdLinea = BEprg.IdLinea;
				int IdPlanta =1;
				if(IdLinea >3 && IdLinea!=9)
					IdPlanta=2;
				//to get material details
				MaterialInfo BEmat=new MaterialInfo(Codigo,"",0,"",0,"",0,"",0,0,0,0,0,"","","","","","","","","",IdPlanta,false);
				Material BLLMat = new Material();
				IList RsMaterial = BLLMat.SelectMaterialList(BEmat);
				if (RsMaterial.Count == 0)
					throw new Exception("There is no record available for this CodigoSAP");

				MaterialInfo BEmaterial = (MaterialInfo) RsMaterial[0];
				int FamPdt=BEmaterial.IdFamiliaProducto;
				string Esp=BEmaterial.IdEspesor;

				//to get the form temparature details
				FormTemperaturaInfo BEFrmTemp = new FormTemperaturaInfo(FamPdt,Esp,IdLinea,0,0,0,0);
				FormTemperatura BLLTemp = new FormTemperatura();
				//to check wethere the temiepo is exists or not
				if (BLLTemp.IsExistPostCured(BEFrmTemp) == false)
					throw new Exception("There is no record available for this Condition");
				IList RsFrmTemp = BLLTemp.SelectFormTemperatura(BEFrmTemp);
				BEFrmTemp = (FormTemperaturaInfo) RsFrmTemp[0];

				//to assign the values into the lables
				lblSecuencia.Text = BEprg.Secuencia;
				lblUTEC.Text = BEmaterial.Descripcion.ToString();
				lblCantidad.Text = BEprg.Cantidad.ToString();
				lblFamiliaProd.Text = BEmat.FamiliaProductoDesc;
				PostCureTime = BEFrmTemp.TiempoPostCurado;
				lblTiempoPostreal.Text = BEFrmTemp.TiempoPostCurado.ToString();
				lblTiempoPost.Text = BEFrmTemp.TiempoPostCurado.ToString()+" minutos";
				lblTempPost.Text = BEFrmTemp.TempPostCurado.ToString()+" grados";
				lblFecha.Text = BEprg.Fecha;
				
				//Load combo of Zonas
				ZonaInfo BEZona = new ZonaInfo(0,IdLinea,false,string.Empty,string.Empty);
				Zona BLLZona = new Zona();
				IList RsZona = BLLZona.SelectLineaZona(BEZona);
				cboZonas.DataSource = RsZona;
				cboZonas.DataValueField = "Zona";
				cboZonas.DataTextField = "Denominacion";
				cboZonas.DataBind();

				if (RsZona.Count == 0)
					throw new Exception("No existen zonas para postcurado, Favor de Verificar");

				//to get details of current Partidas Curado
				PartidasPostCuradoInfo BEPrtPostCurado = new PartidasPostCuradoInfo(BEprg.Secuencia,0,0,0,0,DateTime.MinValue,DateTime.MinValue,DateTime.MinValue,string.Empty);
				PartidasPostCurado BLLPrtPostCurado = new PartidasPostCurado();
				IList RsPrtPostCurado = BLLPrtPostCurado.SelectPartidasPostCurado(BEPrtPostCurado);

				
				

				//If there is PartidaPostCurado for this sequence
				if (RsPrtPostCurado.Count!=0)
				{
					//Disable trigger button
					btnComienzo.Enabled=false;
					//Get PartidasInfo Details
					BEPrtPostCurado = (PartidasPostCuradoInfo) RsPrtPostCurado[0];
					
					//Real Temp
					txtTempZona.Text=BEPrtPostCurado.TemperaturaReal.ToString();
					//txtTempZona.Enabled=false;
					//Real Cuba
					cboZonas.Items.FindByValue(BEPrtPostCurado.Zona.ToString()).Selected=true;
					cboZonas.Enabled=false;
					//Real KCT
					txtKCT.Text=BEPrtPostCurado.KCT;
					txtKCT.Enabled=false;
					btnTemperature.Enabled=true;
				}
				//Display Panel of Cubas
				LoadZonasPanel(RsZona);
			}
			catch
			{
				throw;
			}
		}

		private void LoadZonasPanel()
		{
			//Load combo of Zonas
			ZonaInfo BEZona = new ZonaInfo(0,Convert.ToInt32(Request.QueryString["IdLinea"]),false,string.Empty,string.Empty);
			Zona BLLZona = new Zona();
			IList RsZona = BLLZona.SelectLineaZona(BEZona);
			LoadZonasPanel(RsZona);
		}


		private void LoadZonasPanel(IList zonasList)
		{
			string currentSequence=string.Empty;
			DateTime currentIniDate=DateTime.Now;
			DateTime currentFinDate=DateTime.Now;
			ZonaInfo BEZona;

			for (int ILoop=0; ILoop < zonasList.Count; ILoop++)
			{
				BEZona = (ZonaInfo) zonasList[ILoop];
				if (BEZona.Ocupada)
				{
					//to get details of current Partidas Curado
					PartidasPostCuradoInfo BEPrtPostCurdo = new PartidasPostCuradoInfo(BEZona.SecuenciaActual,0,0,0,0,DateTime.MinValue,DateTime.MinValue,DateTime.MinValue,string.Empty);
					PartidasPostCurado BLLPrtPostCurado = new PartidasPostCurado();
					IList RsPrtPostCurado = BLLPrtPostCurado.SelectPartidasPostCurado(BEPrtPostCurdo);
				
					//If there is PartidaPostCurado for this sequence
					if (RsPrtPostCurado.Count!=0)
					{
						//Load data of Sequence being Cured
						PartidasPostCuradoInfo loadedPartidaPostCurado = (PartidasPostCuradoInfo) RsPrtPostCurado[0];
						currentSequence=loadedPartidaPostCurado.Secuencia;
						currentIniDate=loadedPartidaPostCurado.InicioPostcurado;
						currentFinDate=loadedPartidaPostCurado.FinPostcurado;
						if(currentSequence==lblSecuencia.Text)
							FinalTime=currentFinDate.ToString();

					}
				}
	
				//Add Current Cuba to the Panel
				pnlPostCured.Controls.Add(prcCreateLabel(BEZona.Denominacion.ToString(),BEZona.Ocupada,currentSequence,currentIniDate,currentFinDate));
				//Add Separator
				Label lblDummy = new Label();
				lblDummy.Width=30;
				lblDummy.BackColor=Color.White;
				pnlPostCured.Controls.Add(lblDummy);

			}		
		}

		private Label prcCreateLabel(string zona,bool ocupada,string secuencia,DateTime horaInicio,DateTime horaFin)
		{
			string lblStore;
			Label lblZonas = new Label();
			lblZonas.EnableViewState=true;
			lblZonas.CssClass="standard-text";
			lblZonas.Width=100;
			lblZonas.Height=100;
			lblStore="<center><strong>"+zona+"</strong></center><hr>";
			if (ocupada)
			{
				if (secuencia != "")
				{
					TimeSpan S=horaFin.Subtract(DateTime.Now);
					if(S.TotalSeconds<=(15*60)&& S.TotalSeconds>0)
					{
						lblZonas.ForeColor=Color.Black;
						lblZonas.BackColor = Color.Orange;
					}
					else if(S.TotalSeconds<0)
					{
						lblZonas.ForeColor=Color.White;
						lblZonas.BackColor = Color.Red;
					}
					else
					{
						lblZonas.ForeColor=Color.Black;
						lblZonas.BackColor = Color.Yellow;
					}					
						
					lblStore += "<center><strong><A href='Consultar_PostCuredWO.aspx?Secuencia="+secuencia+"&IdLinea="+ Request.QueryString["IdLinea"] +"'>Seleccione Aquí</A><br>";
					lblStore += secuencia+"</strong><br><br>";
					lblStore += "Inicio: "+ horaInicio.ToShortDateString() + " " +horaInicio.ToShortTimeString()+"<br>";
					lblStore += "Fin: "+horaFin.ToShortDateString()+ " " + horaFin.ToShortTimeString()+"<br>";
					TimeSpan D = horaFin.Subtract(horaInicio);
					S = DateTime.Now.Subtract(horaInicio);
					double duration = Math.Round((S.TotalSeconds/D.TotalSeconds)*100,2);
					if(duration<=100)
						lblStore += "Per: "+duration.ToString()+"%</center>";
					else
						lblStore += "Per:100.00%</center>";	
					lblZonas.ToolTip=" Haga click aquí para cambiar a la secuencia " + secuencia;

				}
			}
			else
			{
				lblZonas.ForeColor=Color.Black;
				lblZonas.BackColor = Color.LightGreen;
			}
			
			lblZonas.Text = lblStore;
			return lblZonas;
		}

		private bool revisasecuencia(string secuencia){
			// revisamos la secuencia de la etiqueta contra la del request
			if(lblSecuencia.Text.ToString() == Request.QueryString["Secuencia"])
			{
				// revisamos que los controles esten activos para saber que no 
				//ha cambiado de secuencia a postcurar
				if(cboZonas.Enabled == true)
					if(txtTempZona.Enabled==true)
						if(txtKCT.Enabled==true)
							return true;
						else
							return false;
					else
						return false;
				else
					return false;
			}
			else
			{
				return false;
			}
 
		}

		private void btnComienzo_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				//int nocas = Convert.ToInt32(txtKCT.Text);
				float temp = Convert.ToSingle(txtTempZona.Text);

				if (temp<=0)
					throw new Exception("La temperatura no puede ser un valor negativo ni cero.");
			}
			catch (Exception)
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('Favor de proporcionar un dato válido en el campo de Temperatura y Número de Cassette');</script>"; 
				Page.RegisterStartupScript("ClientScript",ScriptString);
				return;
			}

			
			try
			{
				// insertamos una función de validación que compare la secuecnia
				//que se esta comenzado a postcurar

				if (revisasecuencia(lblSecuencia.Text.ToString()))
				{
					DateTime InitTime;
					InitTime = DateTime.Now;
					//Nasoft - Roberto Carlos Guzman Vargas
					//DateTime FinalTime = DateTime.Now.AddMinutes(Convert.ToDouble(PostCureTime));
					PostCureTime = System.Convert.ToInt16(lblTiempoPostreal.Text.ToString());
					long tim = Convert.ToInt64(PostCureTime) * 600000000;
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
						BLLLstMat.Insertcomando("Fase de PostCurado - Secuencia: " + lblSecuencia.Text.ToString() + " - Registrar el tiempo fin de una Cuba - Tiempo inicial: " + InitTime.ToString() + " Tiempo de Curado en minutos: " + PostCureTime.ToString() + " Tiempo final calculado por el sistema: " + FinalTime.ToString());
					}
				
					if (SelectedZonaIsFree(Convert.ToInt32(cboZonas.SelectedItem.Value),Convert.ToInt32(Request.QueryString["IdLinea"])))
					{
						int noKct = Convert.ToInt32(txtKCT.Text);
						float temp = Convert.ToSingle(txtTempZona.Text);
						SICALNet.BusinessEntities.PartidasPostCuradoInfo ppcInfo = new SICALNet.BusinessEntities.PartidasPostCuradoInfo(lblSecuencia.Text,localAreaId,Convert.ToInt32(Request.QueryString["IdLinea"]),Convert.ToInt32(cboZonas.SelectedItem.Value),temp,DateTime.Now,FinalTime,DateTime.MinValue,noKct.ToString());
						SICALNet.BusinessLogicLayer.PartidasPostCurado blPPC = new SICALNet.BusinessLogicLayer.PartidasPostCurado();
						blPPC.InsertPartidasPostCurado(ppcInfo);

						prcBindForm();
					}
					else
					{
						string mensaje = "La zona " + cboZonas.SelectedItem.Text.ToString() + " está ocupada, favor de seleccionar otra.";
						Page.ClientScript.RegisterStartupScript(
							this.GetType(),
							"TemperaturaZona",
							"SicalAlert.mostrar('" + mensaje + "', 'advertencia', 'Dato requerido');",
							true
						);

						return;
					}		

				}
			}
			catch (System.Data.SqlClient.SqlException)
			{
				// to display the msg for user
				string ScriptString="<script language='javascript'>alert('Proporcione un valor entero positivo para la temperatura y el Cassette');</script>"; 
				Page.RegisterStartupScript("ClientScript",ScriptString);
			}
			catch 
			{
				throw;
			}

		}

		private bool SelectedZonaIsFree(int selectedZona,int idLinea)
		{
			ZonaInfo selZona= new ZonaInfo(selectedZona,idLinea,false,string.Empty,string.Empty);
			Zona BLLZona = new Zona();
			ZonaInfo BEZona =BLLZona.Load(selZona);

			return !BEZona.Ocupada;
		}

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
			string Secuencia = lblSecuencia.Text.ToString();
			string IdArea = ConfigurationSettings.AppSettings["PostCuredRoomId"].ToString();
			string CodigoSAP = Request.QueryString["CodigoSAP"].ToString();
			string MaterialDescription=lblUTEC.Text.Trim();
			RegisterClientScriptBlock("Enviar Mensaje de Piso", string.Format("<script language='JavaScript'> window.open('../../MensajePopup.aspx?Secuencia={0}&AreaId={1}&CodigoSAP={2}&MaterialDescription={3}','anycontent','width=600, height=550,left=100, top=150, status, scrollbars=no'); </script>",Secuencia,IdArea,CodigoSAP,MaterialDescription));			
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
					RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('../../LoginPopup.aspx?Phase=PostCured&Secuencia="+lblSecuencia.Text+"&Zonas="+cboZonas.SelectedItem.Value+"&IdLinea="+Request.QueryString["IdLinea"]+"','anycontent','width=300,height=300,left=100, top=150,status,scrollbars=no'); </script>");																				
				}
				else
				{

					if (txtTempZona.Text.Trim().Equals(string.Empty))
					{
						Page.ClientScript.RegisterStartupScript(
							this.GetType(),
							"TemperaturaZona",
							"SicalAlert.mostrar('Indique la temperatura de la zona.', 'advertencia', 'Dato requerido');",
							true
						);
						
						return;
					}

					//Update PartidasPostCurado 
					PartidasPostCuradoInfo BEPPC = new PartidasPostCuradoInfo(lblSecuencia.Text,localAreaId,Convert.ToInt32(Request.QueryString["IdLinea"]),Convert.ToInt32(cboZonas.SelectedItem.Value),Convert.ToSingle(txtTempZona.Text),DateTime.Now,DateTime.Now,DateTime.Now,txtKCT.Text.Trim());
					PartidasPostCurado BLLPPC = new PartidasPostCurado();
					IList partidasPC = BLLPPC.SelectPartidasPostCurado(BEPPC);
					if (partidasPC.Count>0)
					{

						BLLPPC.UpdatePartidasPostCurado(BEPPC,Context.User.Identity.Name);
								
						//Activate Next Area And update Active Area in Programma Production for this Secuencia
						//Depending on sequence available in "FlujoArea" Table
						SICALNet.BusinessLogicLayer.FlujoArea objFlujoArea = new SICALNet.BusinessLogicLayer.FlujoArea();
						objFlujoArea.ActivateDependingAreas(lblSecuencia.Text,localAreaId);

						cmdLiberar.Enabled=false;	
						txtTempZona.Enabled=false;

						Response.Redirect("Consultar_PostCured.aspx");
//						Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
//							"alert('"+"La Orden de Trabajo para la secuencia "+ lblSecuencia.Text +" se liberó exitosamente"+"');self.location.href='Consultar_PostCured.aspx';</script>");
					}
					else
					{

						string mensaje = "No se puede liberar una secuencia que no ha sido procesada.";

						ClientScript.RegisterStartupScript(
							this.GetType(),
							"Post curado",
							"SicalAlert.mostrar('" + mensaje + "', 'advertencia');",
							true
						);
						
					}
				}
			}
			catch
			{
				//to display the msg for user
//				string ScriptString="<script language='javascript'>alert('"+ ErHnd.Message.Replace("'"," ") +"');</script>"; 
//				Page.RegisterStartupScript("ClientScript",ScriptString);

				throw;
			}
		}

		private void cmdCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Consultar_PostCured.aspx");
		}

		private void btnTemperature_Click(object sender, System.EventArgs e)
		{
			try
			{
				float selTemp = float.Parse(txtTempZona.Text);
				if (selTemp<=0)
					throw new Exception("La temperatura no puede ser un valor negativo ni cero.");

				PartidasPostCuradoInfo BEPPC = new PartidasPostCuradoInfo(lblSecuencia.Text,localAreaId,Convert.ToInt32(Request.QueryString["IdLinea"]),Convert.ToInt32(cboZonas.SelectedItem.Value),Convert.ToSingle(txtTempZona.Text),DateTime.Now,DateTime.Now,DateTime.Now,txtKCT.Text.Trim());
				PartidasPostCurado BLLPPC = new PartidasPostCurado();
				BLLPPC.UpdateTemperature(BEPPC);
				prcBindForm();				

				Page.ClientScript.RegisterStartupScript(
					this.GetType(),
					"TemperaturaZona",
					"SicalAlert.mostrar('La temperatura fué actualizada exitosamente.', 'advertencia', 'Dato requerido');",
					true
				);


			}
			catch 
			{
				//to display the msg for user
//				string ScriptString="<script language='javascript'>alert('Proporcione un valor entero positivo para la temperatura.');</script>"; 
//				Page.RegisterStartupScript("ClientScript",ScriptString);

				throw;
			}
		}

		
	}
}
