using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;
using System.Configuration;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CYBERAKT.WebControls.Navigation;
using SICALNet.BusinessEntities;
using System.Data.SqlClient;
using SICALNet.Interfaces;
using Microsoft.ApplicationBlocks.Data;



namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for ColorWOqty.
	/// </summary>
	public class AditivosCuarto : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtSecuencia;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.TextBox txtUtec;
		protected System.Web.UI.WebControls.TextBox txtPiso;
		protected System.Web.UI.WebControls.Button btnImprimir;
		protected System.Web.UI.WebControls.TextBox txtArea;
		static int itemselected=0;
		static int iVaso=0;
		static string status;
		protected System.Web.UI.WebControls.DataGrid dgdAditivos;
		//protected static ArrayList[] AditivosList;
		protected static ArrayList[] SecuenciaList;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected CYBERAKT.WebControls.Navigation.ASPnetMenu Menu1;
		private static int[] iVasoQty=new int[20];
		protected System.Web.UI.WebControls.Label lblTitle;
		private static float[] iOlla=new float[20];
		private static float[] iSobrante=new float[20];

		private static string[] Secuencia;
		protected System.Web.UI.WebControls.Label lblInitial;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		private static ArrayList[] SecuenciaOlla;
		protected System.Web.UI.WebControls.Button btnColor;
		protected System.Web.UI.WebControls.Button btnAgregarMensaje;
		protected System.Web.UI.WebControls.Button btnImprimer;
		protected System.Web.UI.WebControls.Button btnLiberar;
		protected System.Web.UI.WebControls.Button btnAgregar;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Image Image1;
		private static string ShortCut="False";
		private const string PARM_SECUENCIA	="@SECUENCIA";

		private enum TipoEtiqueta { StickerAcabado=1, StickerMateriaPrima, StickerSemiTerminado };
		
		private void Page_Load(object sender, System.EventArgs e)
		{	
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);

			if (!IsPostBack)
			{
				btnColor.Attributes.Add("onClick","showWaitControls()");
				btnAgregarMensaje.Attributes.Add("onClick","showWaitControls()");
				btnImprimer.Attributes.Add("onClick","showWaitControls()");
				btnLiberar.Attributes.Add("onClick","showWaitControls()");
				btnAgregar.Attributes.Add("onClick","showWaitControls()");
				btnCancelar.Attributes.Add("onClick","showWaitControls()");

				itemselected=0;
				status=Session[this.Context.User.Identity.Name+"IdStatus"].ToString();
				iVaso =Convert.ToInt32(Session[this.Context.User.Identity.Name+"NoCuanto"]);
				iVasoQty = (int[]) Session[this.Context.User.Identity.Name+"VasoQty"];
				iOlla = (float[])Session[this.Context.User.Identity.Name+"Olla"];
				iSobrante = (float[])Session[this.Context.User.Identity.Name+"Sobrante"];

				if(Request.QueryString["ShortCut"]!=null)
					ShortCut=Request.QueryString["ShortCut"].ToString();
				CreateTabstripControl();

				if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
				{
					prcBindForm();	// Datos del encabezado de la forma Secuencia, Fecha, Utec, Cantidad			
					GridControl(int.Parse(status));
					if(status=="5")
					{
						btnAgregar.Enabled=false;
						dgdAditivos.Columns[3].Visible=false;
						dgdAditivos.Columns[4].Visible=true;
						dgdAditivos.Columns[6].Visible=false;
						dgdAditivos.Columns[7].Visible=true;
					}
				
				}
				else
				{
					//SecuenciaOlla = new ArrayList[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
					//SecuenciaOlla = (ArrayList[])Context.Items["SecuenciaEachOlla"];
					prcBindFormCombined();
					
					SecuenciaList = new ArrayList[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
								
					GridControlCombined();
					GetEachSecuenciaCantidad();
					if(status=="5")
					{
						btnAgregar.Enabled=false;
						dgdAditivos.Columns[3].Visible=false;
						dgdAditivos.Columns[4].Visible=true;
						dgdAditivos.Columns[6].Visible=false;
						dgdAditivos.Columns[7].Visible=true;
					}
				}
			}
			else
			{
				status=Session[this.Context.User.Identity.Name+"IdStatus"].ToString();
				iVaso =Convert.ToInt32(Session[this.Context.User.Identity.Name+"NoCuanto"]);
				iVasoQty = (int[]) Session[this.Context.User.Identity.Name+"VasoQty"];
				iOlla = (float[])Session[this.Context.User.Identity.Name+"Olla"];
				iSobrante = (float[])Session[this.Context.User.Identity.Name+"Sobrante"];				

				if(Request.QueryString["ShortCut"]!=null)
					ShortCut=Request.QueryString["ShortCut"].ToString();
			}
		}

		//to create the tabstrip control dynamically
		private void CreateTabstripControl()
		{
			try
			{
                CYBERAKT.WebControls.Navigation.MenuItem newItem;
					
				for (int iLoop = 1; iLoop <= iVaso; iLoop++)
				{
					newItem = Menu1.TopGroup.Items.Add();
					newItem.Label=string.Format("<center>Olla {0} - {1} Kilos <br><i>({2} láminas)</i></center>",iLoop,iOlla[iLoop-1],iVasoQty[iLoop-1]);
					newItem.SelectedCssClass="SelectedMenuItem";
					newItem.ID=iLoop.ToString();
				}
				Menu1.TopGroup.Items[0].IsSelected=true;
			}
			catch
			{
				throw;
			}
		}

		//to Assign the values into textboxes. this vales is get from programma produccion
		private void prcBindForm()
		{
			try
			{
				
				SICALNet.BusinessLogicLayer.PartidasAditivos BLLparti = new SICALNet.BusinessLogicLayer.PartidasAditivos();
				IList RsParti=(IList)BLLparti.LoadPartidasAditivos(Session[this.Context.User.Identity.Name+"Secuencia"].ToString());
				if (RsParti.Count == 0)
					throw new Exception("There is no record available for this secuencia");

				SICALNet.BusinessEntities.ProgramaInfo BEprg = (SICALNet.BusinessEntities.ProgramaInfo) RsParti[0];
				txtSecuencia.Text=BEprg.Secuencia;
				txtFecha.Text=BEprg.Fecha;
				txtUtec.Text=BEprg.MaterialDesc;
				txtCantidad.Text=BEprg.Cantidad.ToString();
				
				
				txtPiso.Text=BEprg.DetalleOperacion;
				//			txtArea.Text=BEprg.IdArea.ToString();
				txtArea.Text= ConfigurationSettings.AppSettings["AditivosRoomId"];
			}
			catch
			{
				throw;
			}
		}
		//to Assign the values into textboxes. this vales is get from programma produccion
		private void prcBindFormCombined()
		{
			try
			{
				Secuencia = new string[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
				Secuencia =(string[])Session[this.Context.User.Identity.Name+"Secuencia"];				
				SICALNet.BusinessLogicLayer.PartidasAditivos BLLparti = new SICALNet.BusinessLogicLayer.PartidasAditivos();
				IList RsParti=(IList)BLLparti.LoadPartidasAditivos(Secuencia[0]);
				if (RsParti.Count == 0)
					throw new Exception("There is no record available for this secuencia");

				SICALNet.BusinessEntities.ProgramaInfo BEprg = (SICALNet.BusinessEntities.ProgramaInfo) RsParti[0];
			
				txtFecha.Text=BEprg.Fecha;
				txtUtec.Text=BEprg.MaterialDesc;
				//txtCantidad.Text=BEprg.Cantidad.ToString();
				txtCantidad.Text= Request.QueryString["CantidadSum"];
				txtArea.Text= ConfigurationSettings.AppSettings["AditivosRoomId"];
				for(int i=0;i<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);i++)
				txtSecuencia.Text+=Secuencia[i]+",";
				
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
		
		

		private void InitializeComponent()
		{    
			this.Menu1.MenuItemSelected += new CYBERAKT.WebControls.Navigation.ASPnetMenu.MenuItemSelectedEvent(this.Menu1_MenuItemSelected);
			this.dgdAditivos.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdAditivos_ItemDataBound);
			this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
			this.btnAgregarMensaje.Click += new System.EventHandler(this.btnAgregarMensaje_Click);
			this.btnImprimer.Click += new System.EventHandler(this.btnImprimer_Click);
			this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SaveWorkOrderData()
		{

			ArrayList[] theAditivosList = (ArrayList[])Session[this.User.Identity.Name+"ListaAds"];
			IList aryClrRm = new ArrayList();
			string Secuence=txtSecuencia.Text.ToString();
			int Area=int.Parse(txtArea.Text);
			string Fecha=txtFecha.Text.ToString();
			int Laminas;
			theAditivosList[itemselected].Clear();
			//to store the current datagrid to arraylist
			for(int inLoop=0; inLoop<dgdAditivos.Items.Count;inLoop++)
			{
				string Codigo=((Label) dgdAditivos.Items[inLoop].FindControl("AditivosCodigoSAP")).Text.ToString();
				string Descripcion=((Label) dgdAditivos.Items[inLoop].FindControl("AditivosDescripcion")).Text.ToString();
				decimal Cantidad=Convert.ToDecimal(((Label) dgdAditivos.Items[inLoop].FindControl("AditivosCantidad")).Text.ToString());
				decimal CantidadReal;
				string folio;
				if(status==ConfigurationSettings.AppSettings["StatusRelease"].ToString())
				{
					CantidadReal=Convert.ToDecimal(((Label) dgdAditivos.Items[inLoop].Cells[2].FindControl("lblCantidadReal")).Text.ToString());
					folio=((Label) dgdAditivos.Items[inLoop].Cells[2].FindControl("lblFolio")).Text;
				}
				else
				{
					CantidadReal=Convert.ToDecimal(((TextBox) dgdAditivos.Items[inLoop].Cells[2].FindControl("txtCantidadReal")).Text.ToString());
					folio=((TextBox) dgdAditivos.Items[inLoop].Cells[2].FindControl("txtFolio")).Text;
				}

				SICALNet.BusinessEntities.PartidasAditivosInfo  BEparti=new SICALNet.BusinessEntities.PartidasAditivosInfo(Codigo,Descripcion,Cantidad,CantidadReal,folio,0);
					
				theAditivosList[itemselected].Add(BEparti);
			}


			Session[this.User.Identity.Name+"ListaAds"]=theAditivosList;
			//to store thr arraylist to business entities for insert process
			if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
			{
				for(int iLoop=1; iLoop <= iVaso; iLoop++)
				{
					// Cálculo del porcentaje peso
					Laminas=iVasoQty[iLoop-1];
					for(int inLoop=0;inLoop<theAditivosList[iLoop-1].Count;inLoop++)
					{
						SICALNet.BusinessEntities.PartidasAditivosInfo  BEparti1=new SICALNet.BusinessEntities.PartidasAditivosInfo();
						BEparti1=(SICALNet.BusinessEntities.PartidasAditivosInfo)theAditivosList[iLoop-1][inLoop];
						SICALNet.BusinessEntities.PartidasAditivosInfo BEparti;
						if (iSobrante == null)
						{
							BEparti=new SICALNet.BusinessEntities.PartidasAditivosInfo(
								Secuence,Area,BEparti1.CodigoSAP,iLoop,Laminas,BEparti1.Cantidad,BEparti1.CantidadReal,Fecha,BEparti1.LoteReferencia,iOlla[iLoop-1], 0);
						}
						else
						{
							BEparti=new SICALNet.BusinessEntities.PartidasAditivosInfo(
								Secuence,Area,BEparti1.CodigoSAP,iLoop,Laminas,BEparti1.Cantidad,BEparti1.CantidadReal,Fecha,BEparti1.LoteReferencia,iOlla[iLoop-1], iSobrante[iLoop-1]);
						}
					    BEparti.PorcentajePeso = BEparti1.PorcentajePeso;
						aryClrRm.Add(BEparti);
					}
					
				}
				if (aryClrRm.Count>0)
				{
					//SICALNet.BusinessLogicLayer.PartidasAditivos BLLparti= new SICALNet.BusinessLogicLayer.PartidasAditivos();
					SICALNet.BusinessLogicLayer.PartidasAditivos PAd = new SICALNet.BusinessLogicLayer.PartidasAditivos();
					PAd.Delete(txtSecuencia.Text);
                    PAd.Insert(aryClrRm);
					SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text.ToString(),Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]),Context.User.Identity.Name);
					SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
					BLOrdenes.UpdateLoginForm(OTInfo);
					/*SICALNet.BusinessEntities.SecuenciaCombinasInfo SCInfo = new SICALNet.BusinessEntities.SecuenciaCombinasInfo(txtSecuencia.Text,1);
					SICALNet.BusinessLogicLayer.SecuenciaCombinas BLLCombinas= new SICALNet.BusinessLogicLayer.SecuenciaCombinas();
					BLLCombinas.DeleteSecuenciaCombinas(SCInfo);*/
					
				}		
			}
			else 
			{
				GetEachSecuenciaCantidad();
				for(int secloop=0;secloop<SecuenciaList.Length;secloop++)
				{
					for(int ollaloop=0;ollaloop<(dgdAditivos.Items.Count*iVaso);ollaloop++)
					{
						SICALNet.BusinessEntities.PartidasAditivosInfo  BEparti1=new SICALNet.BusinessEntities.PartidasAditivosInfo();
						BEparti1=(SICALNet.BusinessEntities.PartidasAditivosInfo)SecuenciaList[secloop][ollaloop];
						SICALNet.BusinessEntities.PartidasAditivosInfo  BEparti=new SICALNet.BusinessEntities.PartidasAditivosInfo(
							BEparti1.Secuencia,Area,BEparti1.CodigoSAP,BEparti1.NumeroOlla,BEparti1.NoLaminas,BEparti1.Cantidad,BEparti1.CantidadReal,Fecha,BEparti1.LoteReferencia,BEparti1.CapacidadOlla, BEparti1.Sobrante);
						aryClrRm.Add(BEparti);

					}
				}
			
				if (aryClrRm.Count>0)
				{
					string[] secuencia= new String[SecuenciaList.Length];
					secuencia=(string[])txtSecuencia.Text.Split(',');					
					/*SICALNet.BusinessEntities.SecuenciaCombinasInfo SCInfo = new SICALNet.BusinessEntities.SecuenciaCombinasInfo(secuencia[0],0);
					SICALNet.BusinessLogicLayer.SecuenciaCombinas BLLCombinas= new SICALNet.BusinessLogicLayer.SecuenciaCombinas();*/
					SICALNet.BusinessLogicLayer.PartidasAditivos PAd = new SICALNet.BusinessLogicLayer.PartidasAditivos();
					PAd.DeleteCombined(secuencia);
					PAd.Insert(aryClrRm);
					//string[] secuencias = (string[]) Session[this.Context.User.Identity.Name+"Secuencia"];
					/****modificado por alejandro.hernandez@nasoft.com 1022006 ****/
					StringBuilder sec = new StringBuilder("'");
					//string sec="'";
					for(int i=0;i<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);i++)
					{
						sec.Append(secuencia[i]);
						//sec+=secuencia[i];
						if(i==(Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])-1))
						{
							sec.Append("'");
							//sec+="'";
						}
						else
						{
							sec.Append("','");
							//sec+="','";
						}
					}
					SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(sec.ToString(),Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),Context.User.Identity.Name);
					//SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(sec,Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),Context.User.Identity.Name);
					/**** fin modificación ****/
					SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
					BLOrdenes.UpdateLoginFormCombined(OTInfo);
					//BLLCombinas.DeleteSecuenciaCombinas(SCInfo);
					//BLLCombinas.InsertSecuenciaCombinas(txtSecuencia.Text);

				}
			}
		}


		//to save data into the DB
		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
			try
			{
				SaveWorkOrderData();
				Response.Redirect("ConsultAditivosWO.aspx");										
			}
			catch(System.Data.SqlClient.SqlException)
			{
				string ScriptString="<script language='javascript'>alert('El ID Identificador ya esta siendo usado');</script>"; 
				Page.RegisterStartupScript("ClientScript",ScriptString);
			}
			catch
			{				
				throw;
			}
		}

		private void GridControl(int status)
  		{
			ArrayList[] theAditivosList=new ArrayList[iVaso]; 
			string Secuencia = "";
			int[] aryLaminas = new int[10];			// Arreglo de láminas
			float[] aryOlla = new float[10];		// Arreglo de ollas
			float[] arySobrante = new float[10];	// Arreglo de Sobrante
			IList RsList = new IList[20];			// Arreglo de Objetos

			//to get the info from material table
			MaterialInfo BEmat=new MaterialInfo(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),"",0,"",0,"",0,"",0,0,0,0,0,"","","","","","","","","",Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"].ToString()),false);
			SICALNet.BusinessLogicLayer.Material blMaterial = new SICALNet.BusinessLogicLayer.Material();
            IList RsMaterial = blMaterial.SelectMaterialList(BEmat);
			MaterialInfo BEmaterial = (MaterialInfo) RsMaterial[0];
			
			string Color=BEmaterial.IdColor;
			//int FamPdt=BEmaterial.IdFamiliaProducto;
			int Med=BEmaterial.IdMedida;
			string Esp = BEmaterial.IdEspesor;
			//string MatDesc=BEmaterial.Descripcion;
			int version = BEmaterial.VersionAditivos;
		
			Secuencia = Session[this.Context.User.Identity.Name+"Secuencia"].ToString();
			aryLaminas = (int[]) Session[this.Context.User.Identity.Name+"VasoQty"];	// Coloca en variable de sesion el arreglo de laminas
			aryOlla= (float[])Session[this.Context.User.Identity.Name+"Olla"];			// Coloca en variable de sesion el arreglo de ollas
			arySobrante = (float[]) Session[this.Context.User.Identity.Name+"Sobrante"];
			IList ArregloSobrante = this.Sobrante(Secuencia);

			// Obtención del sobrante
			
			for (int iLoop = 1; iLoop <= iVaso; iLoop++)
			{
				int Qty;
				// Cálculo de peso
				SICALNet.BusinessLogicLayer.FormAditivos bllFormAdt = new SICALNet.BusinessLogicLayer.FormAditivos();		
				if (status==5)
					if (ArregloSobrante == null)
					{
						RsList=bllFormAdt.LoadAditivosFormulation1(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"].ToString()),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdLinea"].ToString()),Color,Med,Esp,version, Secuencia, aryLaminas[iLoop-1],aryOlla[iLoop-1],0);
					}
					else
					{
						RsList=bllFormAdt.LoadAditivosFormulation1(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"].ToString()),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdLinea"].ToString()),Color,Med,Esp,version, Secuencia, aryLaminas[iLoop-1],aryOlla[iLoop-1],float.Parse(ArregloSobrante[iLoop-1].ToString()));
					}
				else
				{
					if (arySobrante == null)
					{
						RsList=bllFormAdt.LoadAditivosFormulation1(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"].ToString()),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdLinea"].ToString()),Color,Med,Esp,version, Secuencia, aryLaminas[iLoop-1],aryOlla[iLoop-1],0);
					}
					else
					{
						RsList=bllFormAdt.LoadAditivosFormulation1(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"].ToString()),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdLinea"].ToString()),Color,Med,Esp,version, Secuencia, aryLaminas[iLoop-1],aryOlla[iLoop-1],arySobrante[iLoop-1]);
					}
				}
				Qty = (int) iVasoQty[iLoop-1];
				ArrayList RsTmp = new ArrayList();
				for (int inLoop = 1; inLoop <= RsList.Count; inLoop++)
				{						
					SICALNet.BusinessEntities.PartidasAditivosInfo BEparti=(SICALNet.BusinessEntities.PartidasAditivosInfo) RsList[inLoop-1];

					// *******************************
					// Obteniendo la cantidad Real
						//String CodigoSap="";
						String sSql = "Select CantidadReal, Cantidad, CodigoSap from PartidasAditivos Where Secuencia = '" + Secuencia + 
						"' and CodigoSAP = '" + BEparti.CodigoSAP + 
						"' and NumeroOlla = '" + iLoop + 
						"' and LoteReferencia = '" + BEparti.LoteReferencia + "';";
						double dCantidadReal = 0;
						using(SqlDataReader fadReader=SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["SICALConnString"],CommandType.Text,sSql))
						{
							while(fadReader.Read())
							{
								if (!fadReader.IsDBNull(0))
								{
									dCantidadReal=(float)fadReader.GetDouble(0);
									dCantidadReal = Math.Round(dCantidadReal, 4);
								}
								
							}
						}
					// *******************************
					// SICALNet.BusinessEntities.PartidasAditivosInfo BEtmp=new SICALNet.BusinessEntities.PartidasAditivosInfo(BEparti.CodigoSAP,BEparti.Descripcion,BEparti.Cantidad*Qty,0,BEparti.LoteReferencia,0); // Multiplica por cantidad
					SICALNet.BusinessEntities.PartidasAditivosInfo BEtmp=new SICALNet.BusinessEntities.PartidasAditivosInfo(BEparti.CodigoSAP,BEparti.Descripcion,BEparti.Cantidad,Decimal.Parse(dCantidadReal.ToString()),BEparti.LoteReferencia,0);		// No multiplica por cantidad
					BEtmp.PorcentajePeso = BEparti.PorcentajePeso;
					RsTmp.Add(BEtmp);
				}
				if (RsTmp.Count > 0)
				{
					theAditivosList[iLoop-1]=(ArrayList)RsTmp;
					if(iLoop==1)
					{
						dgdAditivos.DataSource=theAditivosList[iLoop-1];
						dgdAditivos.DataBind();			
					}
				}

			}
					
			//Update the session object with the Aditives List
			Session[this.Context.User.Identity.Name+"ListaAds"]=theAditivosList;

			MensajePisoInfo mpInfo = new MensajePisoInfo(txtSecuencia.Text,string.Empty,Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]));
			SICALNet.BusinessLogicLayer.MensajePiso mPiso = new SICALNet.BusinessLogicLayer.MensajePiso();					
			IList mPisoList=mPiso.Select(mpInfo);

			if(mPisoList.Count>0)
			{
				/*** modificado por alejandro.hernandez@nasoft.com 21022006 ***/
				StringBuilder str_txtPiso = new StringBuilder();

				for(int iloop=0;iloop<mPisoList.Count;iloop++)
				{	
					MensajePisoInfo mpInfo1 = new MensajePisoInfo();
					mpInfo1=(MensajePisoInfo)mPisoList[iloop];
					str_txtPiso.Append(mpInfo1.Mensaje.ToString());
					//txtPiso.Text+=mpInfo1.Mensaje.ToString();
					str_txtPiso.Append("\n");
					//txtPiso.Text+="\n";
				}

				txtPiso.Text = str_txtPiso.ToString();
				/***** fin modificación ****/
				
			}
			SICALNet.BusinessEntities.FormAditivosInfo BEAditivos = new FormAditivosInfo(Color,Esp,Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdLinea"].ToString()),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"].ToString()));
			SICALNet.BusinessEntities.FormAditivosInfo BEAditivos1 = new FormAditivosInfo();
			SICALNet.BusinessLogicLayer.FormAditivos blAditivos = new SICALNet.BusinessLogicLayer.FormAditivos();
			BEAditivos1=(FormAditivosInfo)blAditivos.LoadMessage(BEAditivos);

			if(BEAditivos1!=null)
				txtPiso.Text+=BEAditivos1.Mensaje;
			
		}

		private void GridControlCombined()
		{
			try
			{
				ArrayList[] theAditivosList = new ArrayList[iVaso];
				/*** modificado por alejandro.hernandez@nasoft.com 21022006 ***/
				StringBuilder sec = new StringBuilder("'");
				//string sec="'";
				/*** fin modificación ***/
				
				//to get the info from material table
				MaterialInfo BEmat=new MaterialInfo(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),"",0,"",0,"",0,"",0,0,0,0,0,"","","","","","","","","",Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"].ToString()),false);
				SICALNet.BusinessLogicLayer.Material blMaterial = new SICALNet.BusinessLogicLayer.Material();
				IList RsMaterial = blMaterial.SelectMaterialList(BEmat);
				MaterialInfo BEmaterial = (MaterialInfo) RsMaterial[0];
			
				string Color=BEmaterial.IdColor;
				/*** comentado por alejandro.hernandez@nasoft.com 07/03/2006 ***/
				//int FamPdt=BEmaterial.IdFamiliaProducto;
				int Med=BEmaterial.IdMedida;
				string Esp = BEmaterial.IdEspesor;
				//string MatDesc=BEmaterial.Descripcion;
				int version = BEmaterial.VersionAditivos;
			
				if(Session[this.Context.User.Identity.Name+"flag"].ToString()=="0")
				{
					SaparateCantidad();								
					SICALNet.BusinessLogicLayer.FormAditivos bllFormAdt = new SICALNet.BusinessLogicLayer.FormAditivos();
					IList RsList=bllFormAdt.LoadAditivosFormulation(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"].ToString()),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdLinea"].ToString()),Color,Med,Esp,version);
					int Qty;
				
					IList RsTmp;
					for (int iLoop = 1; iLoop <= iVaso; iLoop++)
					{
						Qty = (int) iVasoQty[iLoop-1];
						RsTmp = new ArrayList();
						for (int inLoop = 1; inLoop <= RsList.Count; inLoop++)
						{
							SICALNet.BusinessEntities.PartidasAditivosInfo BEparti=(SICALNet.BusinessEntities.PartidasAditivosInfo) RsList[inLoop-1];
							SICALNet.BusinessEntities.PartidasAditivosInfo BEtmp=new SICALNet.BusinessEntities.PartidasAditivosInfo(BEparti.CodigoSAP,BEparti.Descripcion,BEparti.Cantidad*Qty,0,BEparti.LoteReferencia,0);
							BEtmp.PorcentajePeso = BEparti.PorcentajePeso;
							RsTmp.Add(BEtmp);
						}
						if (RsTmp.Count > 0)
						{
							theAditivosList[iLoop-1]=(ArrayList)RsTmp;
							if(iLoop==1)
							{
								dgdAditivos.DataSource=theAditivosList[iLoop-1];
								dgdAditivos.DataBind();		
								
							}
						}
					}

	
							
				}
				else
				{
					string[] secuencia = new string[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
					secuencia=(string[])Session[this.Context.User.Identity.Name+"Secuencia"];
					for(int i=0;i<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);i++)
					{
						/*** modificado por alejandro.hernandez@nasoft.com 21022006 ***/
						sec.Append(secuencia[i]);
						//sec+=secuencia[i];
						if(i!=(Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])-1))
						{
							sec.Append("','");
							//sec+="','";
						}
						else
						{
							sec.Append("'");
							//sec+="'";
						}
						/*** fin modificación ***/
					}
					SecuenciaOlla = new ArrayList[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
					for(int j=0;j<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);j++)
					{
						SICALNet.BusinessLogicLayer.PartidasAditivos blPAdd=new SICALNet.BusinessLogicLayer.PartidasAditivos();
						IList SecuenciaLaminaList=(IList)blPAdd.SelectEachLaminaCombined(secuencia[j],Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]));
						SecuenciaOlla[j]=(ArrayList)SecuenciaLaminaList;
					}
					for (int iLoop = 1; iLoop <= iVaso; iLoop++)
					{
						SICALNet.BusinessLogicLayer.PartidasAditivos blPAdd=new SICALNet.BusinessLogicLayer.PartidasAditivos();
						/*********modificado por alejandro.hernandez@nasoft.com 21022006********/
						IList OllaList=blPAdd.SelectCombined(sec.ToString(),Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]),iLoop);
						//IList OllaList=blPAdd.SelectCombined(sec,Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]),iLoop);
						/*********fin modificación****************/
						if (OllaList.Count > 0)
						{
							theAditivosList[iLoop-1]=(ArrayList)OllaList;
							if(iLoop==1)
							{
								dgdAditivos.DataSource=theAditivosList[iLoop-1];
								dgdAditivos.DataBind();		
								
							}
						}
						
					}
				}

				//Update the session object with the Aditives List
				Session[this.Context.User.Identity.Name+"ListaAds"]=theAditivosList;

				MensajePisoInfo mpInfo = new MensajePisoInfo(txtSecuencia.Text,string.Empty,Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]));
				SICALNet.BusinessLogicLayer.MensajePiso mPiso = new SICALNet.BusinessLogicLayer.MensajePiso();					
				IList mPisoList=mPiso.Select(mpInfo);

				if(mPisoList.Count>0)
				{
					/*** modificado por alejandro.hernandez@nasoft.com 21022006 ***/
					StringBuilder str_txtPiso = new StringBuilder();

					for(int iloop=0;iloop<mPisoList.Count;iloop++)
					{	
						MensajePisoInfo mpInfo1 = new MensajePisoInfo();
						mpInfo1=(MensajePisoInfo)mPisoList[iloop];

						str_txtPiso.Append(mpInfo1.Mensaje.ToString()).Append("\n");
						//txtPiso.Text+=mpInfo1.Mensaje.ToString();
						//txtPiso.Text+="\n";
					}
					txtPiso.Text = str_txtPiso.ToString();
					/***** fin modificación ****/
				}
				SICALNet.BusinessEntities.FormAditivosInfo BEAditivos = new FormAditivosInfo(Color,Esp,Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdLinea"].ToString()),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"].ToString()));
				SICALNet.BusinessEntities.FormAditivosInfo BEAditivos1 = new FormAditivosInfo();
				SICALNet.BusinessLogicLayer.FormAditivos blAditivos = new SICALNet.BusinessLogicLayer.FormAditivos();
				BEAditivos1=(FormAditivosInfo)blAditivos.LoadMessage(BEAditivos);
				if(BEAditivos1!=null)
					txtPiso.Text+=BEAditivos1.Mensaje.ToString();
			}
			catch
			{
				throw;

			}
			
		}
		

		//to select the datagrid dynamically
		

		private void btnImprimer_Click(object sender, System.EventArgs e)
		{
//			if (chkPrintByComp.Checked)
//				printSticketByComponent();
//			else
				printRegularSticker();
		}

		private void printRegularSticker()
		{
			/*** modificado por alejandro.hernandez@nasoft.com 21022006 ***/
			StringBuilder SecuenciaStr = new StringBuilder();
			//string SecuenciaStr="";

			if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()!="0")
			{
				string [] secuencia = new String[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
				secuencia = (string[])Session[this.Context.User.Identity.Name+"Secuencia"];
				for(int i=0;i<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);i++)
				{
					SecuenciaStr.Append("{OrdenesTrabajo.Secuencia}= '").Append(secuencia[i]).Append("'");
					//SecuenciaStr+="{OrdenesTrabajo.Secuencia}= '"+secuencia[i]+"'";
					if(i!=(Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])-1))
					{
						SecuenciaStr.Append(" OR ");
						//SecuenciaStr+=" OR ";
					}
				}
			}
			
			else
			{
				SecuenciaStr.Append("{OrdenesTrabajo.Secuencia}= '");
				SecuenciaStr.Append(txtSecuencia.Text);
				SecuenciaStr.Append("'");
				//SecuenciaStr+="{OrdenesTrabajo.Secuencia}= '"+txtSecuencia.Text+"'";
			}

			

			//Response.Redirect("..\\..\\Forms\\Reports\\FrmStickerAdditoves.aspx?Secuencia="+SecuenciaStr);
			PrepareStickerReport(txtFecha.Text,txtFecha.Text,Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdLinea"]),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdStatus"]),SecuenciaStr.ToString());
			//PrepareStickerReport(txtFecha.Text,txtFecha.Text,Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdLinea"]),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdStatus"]),SecuenciaStr);

			/***** fin modificación ****/
		}
		private void PrepareStickerReport(string fechaInicial, string fechaFinal, int linea,int status, string secuencias)
		{
		
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			Reports.PrintStickerAdditoves AdiSticker = new Reports.PrintStickerAdditoves();

			string	SelectionStr="";
			if(linea!=0)
				SelectionStr= "{ProgramaProduccion.IdLinea}="+linea.ToString()+" AND ";
			if(status!=0)
				SelectionStr+= "{OrdenesTrabajo.IdStatus}="+ status.ToString() +" AND ";

			SelectionStr+="{ProgramaProduccion.Fecha}>=Date("+DateTime.Parse(fechaInicial).ToString("yyyy")+","+DateTime.Parse(fechaInicial).ToString("MM")+","+DateTime.Parse(fechaInicial).ToString("dd")+")";
			SelectionStr+=" AND {ProgramaProduccion.Fecha}<=Date("+DateTime.Parse(fechaFinal).ToString("yyyy")+","+DateTime.Parse(fechaFinal).ToString("MM")+","+DateTime.Parse(fechaFinal).ToString("dd")+")";
			SelectionStr+=" AND {OrdenesTrabajo.IdArea}=2 AND "+secuencias;

			AdiSticker.DataDefinition.RecordSelectionFormula=SelectionStr;
			
			rptHelper.setPermission(AdiSticker);
			string reportname = rptHelper.exportReport(AdiSticker,"StickerAditivos", User.Identity.Name);

			string redirectPath=ConfigurationSettings.AppSettings["reportsWebPath"]+ reportname + ".pdf";
			//Response.Redirect(redirectPath);
			string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','Reporte', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>"; 
			Page.RegisterStartupScript("ClientScript",ScriptString);



		}

		private void Menu1_MenuItemSelected(object sender, CYBERAKT.WebControls.Navigation.MenuItemSelectedEventArgs e)
		{
			ArrayList[] theAditivosList = (ArrayList[])Session[this.Context.User.Identity.Name+"ListaAds"];

			for (int iLoop=1; iLoop <= iVaso; iLoop++)
			{
				if (e.ItemID.ToString()==iLoop.ToString())
				{
					theAditivosList[itemselected].Clear();
					for(int inLoop=0; inLoop<dgdAditivos.Items.Count;inLoop++)
					{
						string Codigo=((Label) dgdAditivos.Items[inLoop].Cells[0].FindControl("AditivosCodigoSAP")).Text.ToString();
						string Descripcion=((Label) dgdAditivos.Items[inLoop].Cells[0].FindControl("AditivosDescripcion")).Text.ToString();
						decimal Cantidad=Convert.ToDecimal(((Label) dgdAditivos.Items[inLoop].Cells[1].FindControl("AditivosCantidad")).Text.ToString());
						float porPeso=Convert.ToSingle(((Label) dgdAditivos.Items[inLoop].Cells[1].FindControl("lblPorPeso")).Text.ToString());
						decimal CantidadReal;
						string folio;
						if(status=="5")
						{
							CantidadReal=Convert.ToDecimal(((Label) dgdAditivos.Items[inLoop].Cells[2].FindControl("lblCantidadReal")).Text.ToString());
							folio=((Label) dgdAditivos.Items[inLoop].Cells[2].FindControl("lblFolio")).Text;
						}
						else
						{
							CantidadReal=Convert.ToDecimal(((TextBox) dgdAditivos.Items[inLoop].Cells[2].FindControl("txtCantidadReal")).Text.ToString());
							folio=((TextBox) dgdAditivos.Items[inLoop].Cells[2].FindControl("txtFolio")).Text;
						}

						SICALNet.BusinessEntities.PartidasAditivosInfo  BEparti=new SICALNet.BusinessEntities.PartidasAditivosInfo(Codigo,Descripcion,Cantidad,CantidadReal,folio,0);
						BEparti.PorcentajePeso  = porPeso;
						theAditivosList[itemselected].Add(BEparti);
					}
				
					dgdAditivos.DataSource=theAditivosList[iLoop-1];
					dgdAditivos.DataBind();
					itemselected=iLoop-1;
				}
				
			}
			//Update the session object with the Aditives List
			Session[this.Context.User.Identity.Name+"ListaAds"]=theAditivosList;

			if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()!="0")
			GetEachSecuenciaCantidad();
		}

		private void btnLiberar_Click(object sender, System.EventArgs e)
		{
			try
			{				
				if(status==ConfigurationSettings.AppSettings["StatusRelease"].ToString())
				{
					Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"Esta orden de trabajo ya está liberada !"+"')" + "<" + "/script>");	
				}
				else
				{
					//Update current information of the work order
					SaveWorkOrderData();
					//Release work order
					SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo;
					if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
					{
						OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text.ToString(),2,Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]),Convert.ToInt32(ConfigurationSettings.AppSettings["PVCRoomId"]),Convert.ToInt32(ConfigurationSettings.AppSettings["MixturesRoomId"]),5,DateTime.Now.Date.ToString("dd-MMM-yyyy"),Context.User.Identity.Name);
						SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						BLOrdenes.AdditivesUpdate(OTInfo);
					}
					else
					{	
						
						OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text,2,Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]),Convert.ToInt32(ConfigurationSettings.AppSettings["PVCRoomId"]),Convert.ToInt32(ConfigurationSettings.AppSettings["MixturesRoomId"]),5,DateTime.Now.Date.ToString("dd-MMM-yyyy"),Context.User.Identity.Name);
						SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						BLOrdenes.AdditivesUpdateCombined(OTInfo);
					}
					
					string sBitacora = string.Format("Liberación de Secuencia {0} en Fase de aditivos, por el usuario {1}",txtSecuencia.Text, this.User.Identity.Name.ToString());
					// guardamos en la bitacora
					SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
					BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

					btnAgregar.Enabled=false;
					btnLiberar.Enabled=false;
					dgdAditivos.Columns[3].Visible=false;
					dgdAditivos.Columns[4].Visible=true;
					Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"La Orden de Trabajo se libero exitosamente"+"');self.location.href='ConsultAditivosWO.aspx';</script>");
					Response.Redirect("ConsultAditivosWO.aspx");
				}
			}
			catch
			{
//				//to display the msg for user
//				string sErrMsg;
//				sErrMsg=ErrHand.Message.Replace("'","-");
//				string ScriptString="<script language='javascript'>alert('"+ sErrMsg +"');</script>"; 
//				Page.RegisterStartupScript("ClientScript",ScriptString);
				
				throw;
			}
			
			
		}

		private void btnAgregarMensaje_Click(object sender, System.EventArgs e)
		{
			string Secuencia = txtSecuencia.Text.ToString();
			string IdArea= ConfigurationSettings.AppSettings["AditivosRoomId"].ToString();
			string CodigoSAP=Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString();
			string matDesc=txtUtec.Text.Trim();
			RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodigoSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ConsultAditivosWO.aspx");
		}
		public void CalculateDifferance(object sender, System.EventArgs e)
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

			Label lblCantidad = (Label) dgdAditivos.Controls[0].Controls[Index-1].FindControl("AditivosCantidad");
			Label lblDiference = (Label) dgdAditivos.Controls[0].Controls[Index-1].FindControl("lblDiffrencia");

			/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/
			decimal Diff = Convert.ToDecimal(lblCantidad.Text) - Convert.ToDecimal(txtSender.Text);
			//decimal Diff = Convert.ToDecimal(lblCantidad.Text) - Convert.ToDecimal(((TextBox)sender).Text);
			/*** fin de modificación ***/


			lblDiference.Text =  Diff.ToString();

		}

		private void GetEachSecuenciaCantidad()
		{
			//Update the session object with the Aditives List
			ArrayList[] theAditivosList=(ArrayList[])Session[this.Context.User.Identity.Name+"ListaAds"];

			try
			{
				for(int iloop=0;iloop<SecuenciaOlla.Length;iloop++)
				{
					ArrayList Dummy = new ArrayList();
					Dummy = SecuenciaOlla[iloop];
					ArrayList Dummy1 = new ArrayList();
					for(int inloop=0;inloop<iVasoQty.Length;inloop++)
					{
						SICALNet.BusinessEntities.PartidasAditivosInfo PAInfo = new SICALNet.BusinessEntities.PartidasAditivosInfo();
						PAInfo = (SICALNet.BusinessEntities.PartidasAditivosInfo)Dummy[inloop];
						SICALNet.BusinessEntities.PartidasAditivosInfo PAInfo1 = new SICALNet.BusinessEntities.PartidasAditivosInfo();
						for(int innloop=0;innloop<dgdAditivos.Items.Count;innloop++)
						{
							PAInfo1=(SICALNet.BusinessEntities.PartidasAditivosInfo)theAditivosList[inloop][innloop];
							decimal Cantidad=(PAInfo1.Cantidad/iVasoQty[inloop])*PAInfo.NoLaminas;
							//PAInfo.LoteReferencia=PAInfo1.LoteReferencia;
							decimal CantidadReal=0;
							if(PAInfo1.CantidadReal!=0)
								CantidadReal=(PAInfo1.CantidadReal/iVasoQty[inloop])*PAInfo.NoLaminas;	
							SICALNet.BusinessEntities.PartidasAditivosInfo PAInfo2 = new SICALNet.BusinessEntities.PartidasAditivosInfo(PAInfo.Secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]),PAInfo1.CodigoSAP,PAInfo.NumeroOlla,PAInfo.NoLaminas,Cantidad,CantidadReal,string.Empty,PAInfo.LoteReferencia,PAInfo.CapacidadOlla,PAInfo.Sobrante);
							Dummy1.Add(PAInfo2);
						}						
					}
					SecuenciaList[iloop]=(ArrayList)Dummy1;
				}
			}
			catch
			{
				throw;
			}
		}
		private void SaparateCantidad()
		{
			//to calculate Laminas assigned to each Olla in Combined COnsultation.
			int CantidadSum=Convert.ToInt32(txtCantidad.Text.ToString());
			//ArrayList[] SecuenciaEachOlla = new ArrayList[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
			SecuenciaOlla = new ArrayList[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
			int[] aryLaminas =(int[])Session[this.Context.User.Identity.Name+"VasoQty"];
			float[] aryOlla = (float[])Session[this.Context.User.Identity.Name+"Olla"];
			float[] arySobrante = (float[])Session[this.Context.User.Identity.Name+"Sobrante"];

			int[] Cantidad=new int[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
			Cantidad=(int[])Session[this.Context.User.Identity.Name+"Cantidad"];
			//string[] secuencia = new string[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
			string[] secuencia = (string[])Session[this.Context.User.Identity.Name+"Secuencia"];
			int arySecLaminas;
			for(int secloop=0;secloop<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);secloop++)
			{
				ArrayList EachSecuencia = new ArrayList();
				int sum=0;
				for(int Ollaloop=0;Ollaloop<aryOlla.Length;Ollaloop++)
				{
					float value=aryLaminas[Ollaloop]*Cantidad[secloop];
					arySecLaminas=Convert.ToInt32(Math.Round(value/CantidadSum,0));	
					sum+=arySecLaminas;
					SICALNet.BusinessEntities.PartidasAditivosInfo PAInfo = new SICALNet.BusinessEntities.PartidasAditivosInfo();
					if(Ollaloop==(aryOlla.Length-1))
						if(sum==Cantidad[secloop])
							PAInfo = new SICALNet.BusinessEntities.PartidasAditivosInfo(secuencia[secloop],0,string.Empty,Ollaloop+1,arySecLaminas,0,0,string.Empty,string.Empty,aryOlla[Ollaloop], arySobrante[Ollaloop]);
						else
						{
							for(int i=0;;i++)
							{
								arySecLaminas++;
								sum++;
								if(sum==Cantidad[secloop])
								{
									PAInfo = new SICALNet.BusinessEntities.PartidasAditivosInfo(secuencia[secloop],0,string.Empty,Ollaloop+1,arySecLaminas,0,0,string.Empty,string.Empty,aryOlla[Ollaloop], arySobrante[Ollaloop]);
									break;
								}
							}
						}
					else
					PAInfo = new SICALNet.BusinessEntities.PartidasAditivosInfo(secuencia[secloop],0,string.Empty,Ollaloop+1,arySecLaminas,0,0,string.Empty,string.Empty,aryOlla[Ollaloop], arySobrante[Ollaloop]);							
					EachSecuencia.Add(PAInfo);
				}
				SecuenciaOlla[secloop]=(ArrayList)EachSecuencia;
			}
		}
		private void dgdAditivos_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
			{
				Label Diff=(Label)e.Item.FindControl("lblDiffrencia");
				TextBox Dif = (TextBox) e.Item.FindControl("txtDif");
				decimal CantidadReal;
				if(status=="5")
					CantidadReal=Convert.ToDecimal(((Label)e.Item.FindControl("lblCantidadReal")).Text);
				else
					CantidadReal=Convert.ToDecimal(((TextBox)e.Item.FindControl("txtCantidadReal")).Text);
				CantidadReal= (Convert.ToDecimal(((Label)e.Item.FindControl("AditivosCantidad")).Text)-CantidadReal);
				Diff.Text=CantidadReal.ToString();
				Dif.Text=CantidadReal.ToString();
			}
		}

		
		private void btnColor_Click(object sender, System.EventArgs e)
		{
			try
			{
				Session[this.Context.User.Identity.Name+"UTEC"]=txtUtec.Text;
				if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
				{
					Session[this.Context.User.Identity.Name+"Fecha"]=txtFecha.Text;
					SICALNet.BusinessLogicLayer.PartidasColor BLLPC = new SICALNet.BusinessLogicLayer.PartidasColor();
					if(BLLPC.IsExistSecuencia(txtSecuencia.Text))
					{
						SICALNet.BusinessEntities.OrdenesTrabajoInfo OInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),0);
						SICALNet.BusinessLogicLayer.OrdenesTrabajo blOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						int Status=blOrdenes.GetStatus(OInfo);
						if(Status==2)
						{
							IList pcList = (IList) BLLPC.GetNoVaso(Session[this.Context.User.Identity.Name+"Secuencia"].ToString());
							Session[this.Context.User.Identity.Name+"NoGroup"] = pcList.Count.ToString();
							IList RsPC=(IList) BLLPC.GetLaminas(Session[this.Context.User.Identity.Name+"Secuencia"].ToString());
							int[] NoVaso=new int[pcList.Count];
							float[] Aforo = new float[pcList.Count];
							for(int i=0;i<pcList.Count;i++)
							{
								SICALNet.BusinessEntities.PartidasColorInfo BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
								BEInfo = (SICALNet.BusinessEntities.PartidasColorInfo)pcList[i];
								NoVaso[i]=BEInfo.NoVaso;
								Aforo[i]=BEInfo.Aforo;
							}
							Session[this.Context.User.Identity.Name+"NoVaso"]=NoVaso;
							Session[this.Context.User.Identity.Name+"Aforo"]=Aforo;
							int[] aryLaminas = new int[RsPC.Count];
							for(int i=0;i<RsPC.Count;i++)
							{
								SICALNet.BusinessEntities.PartidasColorInfo BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
								BEInfo = (SICALNet.BusinessEntities.PartidasColorInfo)RsPC[i];
								aryLaminas[i]=BEInfo.NoLaminas;
							}
							Session[this.Context.User.Identity.Name+"VasoQty"] = aryLaminas;
							Session[this.Context.User.Identity.Name+"TotNoVaso"] = RsPC.Count;
							Response.Redirect("WorkOrder/PartidasColor/ColorWOFinal.aspx?isNew=false");
						}
						else if(Status==5)
						{
							Session[this.Context.User.Identity.Name+"IdStatus"] = Status;
							IList pcList = (IList) BLLPC.GetNoVaso(Session[this.Context.User.Identity.Name+"Secuencia"].ToString());
							Session[this.Context.User.Identity.Name+"NoGroup"] = pcList.Count.ToString();
							IList RsPC=(IList) BLLPC.GetLaminas(Session[this.Context.User.Identity.Name+"Secuencia"].ToString());
							int[] NoVaso=new int[pcList.Count];
							float[] Aforo = new float[pcList.Count];
							for(int i=0;i<pcList.Count;i++)
							{
								SICALNet.BusinessEntities.PartidasColorInfo BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
								BEInfo = (SICALNet.BusinessEntities.PartidasColorInfo)pcList[i];
								NoVaso[i]=BEInfo.NoVaso;
								Aforo[i]=BEInfo.Aforo;
							}
							Session[this.Context.User.Identity.Name+"NoVaso"]=NoVaso;
							Session[this.Context.User.Identity.Name+"Aforo"]=Aforo;
							int[] aryLaminas = new int[RsPC.Count];
							for(int i=0;i<RsPC.Count;i++)
							{
								SICALNet.BusinessEntities.PartidasColorInfo BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
								BEInfo = (SICALNet.BusinessEntities.PartidasColorInfo)RsPC[i];
								aryLaminas[i]=BEInfo.NoLaminas;
							}
							Session[this.Context.User.Identity.Name+"VasoQty"] = aryLaminas;
							Session[this.Context.User.Identity.Name+"TotNoVaso"] = RsPC.Count;
							Response.Redirect("WorkOrder/PartidasColor/ColorWOFinal.aspx?isNew=false");
						}
					}
					else
					{
						int NoGroup = BLLPC.GetNoGroup(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"]));
						Session[this.Context.User.Identity.Name+"NoGroup"] = NoGroup;
						int[] NoVaso=new int[NoGroup];
						float[] Aforo = new float[NoGroup];
						int[] aryLaminas = new int[NoGroup];
						for(int i=0;i<NoGroup;i++)
						{
							NoVaso[i]=1;
							Aforo[i]=0;
							aryLaminas[i]=Convert.ToInt32(txtCantidad.Text);
						}
						Session[this.Context.User.Identity.Name+"NoVaso"]=NoVaso;
						Session[this.Context.User.Identity.Name+"Aforo"]=Aforo;	
						Session[this.Context.User.Identity.Name+"VasoQty"] = aryLaminas;
						Session[this.Context.User.Identity.Name+"TotNoVaso"] = NoGroup;
						Response.Redirect("WorkOrder/PartidasColor/ColorWOFinal.aspx?isNew=true");	
					}
				}
				else
				{					
					SICALNet.BusinessLogicLayer.PartidasColor BLLPC = new SICALNet.BusinessLogicLayer.PartidasColor();
					string[] secuencia = (string[])Session[this.Context.User.Identity.Name+"Secuencia"];
					if(BLLPC.IsExistSecuencia(secuencia[0]))
					{
						SICALNet.BusinessEntities.OrdenesTrabajoInfo OInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(secuencia[0],Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),0);
						SICALNet.BusinessLogicLayer.OrdenesTrabajo blOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						int Status=blOrdenes.GetStatus(OInfo);
						Session[this.Context.User.Identity.Name+"IdStatus"] = Status;
						IList pcList = (IList) BLLPC.GetNoVaso(secuencia[0]);
						Session[this.Context.User.Identity.Name+"NoGroup"] = pcList.Count.ToString();
						/*** modificado por alejandro.hernandez@nasoft.com 21022006 ***/
						StringBuilder sec = new StringBuilder("'");
						//string sec="'";
						/*** fin modificación ***/

						for(int i=0;i<secuencia.Length;i++)
						{
							/*** modificado por alejandro.hernandez@nasoft.com 21022006 ***/
							sec.Append(secuencia[i]);
							//sec+=secuencia[i];
							if(i==((secuencia.Length)-1))
							{
								sec.Append("'");
								//sec+="'";
							}
							else
							{
								sec.Append("','");
								//sec+="','";
							}
						}
						IList RsPC=(IList) BLLPC.GetLaminasCombined(sec.ToString());
						//IList RsPC=(IList) BLLPC.GetLaminasCombined(sec);
						/*** fin modificación ***/
						int[] NoVaso=new int[pcList.Count];
						float[] Aforo = new float[pcList.Count];
						for(int i=0;i<pcList.Count;i++)
						{
							SICALNet.BusinessEntities.PartidasColorInfo BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
							BEInfo = (SICALNet.BusinessEntities.PartidasColorInfo)pcList[i];
							NoVaso[i]=BEInfo.NoVaso;
							Aforo[i]=BEInfo.Aforo;
						}
						Session[this.Context.User.Identity.Name+"NoVaso"]=NoVaso;
						Session[this.Context.User.Identity.Name+"Aforo"]=Aforo;
						int[] aryLaminas = new int[RsPC.Count];
						for(int i=0;i<RsPC.Count;i++)
						{
							SICALNet.BusinessEntities.PartidasColorInfo BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
							BEInfo = (SICALNet.BusinessEntities.PartidasColorInfo)RsPC[i];
							aryLaminas[i]=BEInfo.NoLaminas;
						}
						Session[this.Context.User.Identity.Name+"VasoQty"] = aryLaminas;
						Session[this.Context.User.Identity.Name+"TotNoVaso"] = RsPC.Count;
						Response.Redirect("WorkOrder/PartidasColor/ColorWOFinal.aspx?isNew=false");
					}
					else
					{
						SICALNet.BusinessEntities.OrdenesTrabajoInfo OInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(secuencia[0],Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),0);
						SICALNet.BusinessLogicLayer.OrdenesTrabajo blOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						int Status=blOrdenes.GetStatus(OInfo);
						Session[this.Context.User.Identity.Name+"IdStatus"] = Status;
						int NoGroup = BLLPC.GetNoGroup(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"]));
						Session[this.Context.User.Identity.Name+"NoGroup"] = NoGroup;
						int[] NoVaso=new int[NoGroup];
						float[] Aforo = new float[NoGroup];
						int[] aryLaminas = new int[NoGroup];
						for(int i=0;i<NoGroup;i++)
						{
							NoVaso[i]=1;
							Aforo[i]=0;
							aryLaminas[i]=Convert.ToInt32(txtCantidad.Text);
						}
						Session[this.Context.User.Identity.Name+"NoVaso"]=NoVaso;
						Session[this.Context.User.Identity.Name+"Aforo"]=Aforo;	
						Session[this.Context.User.Identity.Name+"VasoQty"] = aryLaminas;
						Session[this.Context.User.Identity.Name+"TotNoVaso"] = NoGroup;
						Response.Redirect("WorkOrder/PartidasColor/ColorWOFinal.aspx?isNew=true");	
					}
					
				}
		
			}
			catch
			{
				throw;
			}

		
		}

		public  IList Sobrante(string Secuencia)
		{						
			IList ListaSobrante = new ArrayList();
			SqlParameter[] TamanioParms=ParametrosSecuencia();
			EstableceParametrosSecuencia(TamanioParms, Secuencia);
			double Sobrante = 0;

			using (SqlDataReader pltRdr = SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["SICALConnString"], CommandType.StoredProcedure,"Proc_Consulta_Sobrante_Aditivos_Secuencia",TamanioParms)) 
			{
				try
				{
					while(pltRdr.Read())
					{
						Sobrante = pltRdr.GetDouble(0);
						ListaSobrante.Add(Sobrante);
					}
					return ListaSobrante;
				}
				catch
				{
					throw;
				}
			}		
		}
		public static SqlParameter[] ParametrosSecuencia()
		{
			SqlParameter[] parms;
			parms = SqlHelperParameterCache.GetCachedParameterSet(ConfigurationSettings.AppSettings["SICALConnString"],"Proc_Consulta_Sobrante_Aditivos_Secuencia");
			parms= new SqlParameter[]{
										 new SqlParameter(PARM_SECUENCIA,SqlDbType.VarChar)
									 };
			SqlHelperParameterCache.CacheParameterSet(ConfigurationSettings.AppSettings["SICALConnString"],"Proc_Consulta_Sobrante_Aditivos_Secuencia",parms);
			return parms;
		}

		public static void EstableceParametrosSecuencia(SqlParameter[] parms,string Secuencia)
		{
			parms[0].Value = Secuencia;
		}	

	}
}
