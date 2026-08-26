using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using SICALNet.BusinessEntities;
using SICALNet.BusinessLogicLayer;
using SICALNet.Interfaces;
using Microsoft.ApplicationBlocks.Data;
namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for ConsultColorWO.
	/// </summary>
	public class PartidasAditivos : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblLinea;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Image imgInitial;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblInitial;
		protected System.Web.UI.WebControls.Button btnSel;
		protected System.Web.UI.WebControls.Label Status;
		protected System.Web.UI.WebControls.DropDownList cboStatus;
		protected System.Web.UI.WebControls.Label lblFinal;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.TextBox txtFechaFinal;
		protected System.Web.UI.WebControls.Image imgFinal;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Button btnAgregar;
		protected System.Web.UI.WebControls.Button btnLiberar;
		protected System.Web.UI.WebControls.Button btnRpt;
		protected System.Web.UI.WebControls.DropDownList CmbOlla;
		protected System.Web.UI.WebControls.Button btnImprimirEqu;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DataList lstWorkOrder;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.RegularExpressionValidator revInitial;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.CheckBox chkSeparate;
		protected System.Web.UI.WebControls.Button btnCard;
		protected System.Web.UI.WebControls.Button btnPreform;
		protected System.Web.UI.WebControls.Button btnDust;
		protected System.Web.UI.WebControls.Button btnImprimirSLPC;
		protected System.Web.UI.WebControls.Literal ltrRefresh;
		private enum TipoEtiqueta { StickerColor=1, StickerAditivo, StickerAditivog };

		private const string SECUENCIA = "@SEC";
		private const string PROC_INSERTAPMAA_TARJETAFORMULACION = "Proc_InsertaPMMA_TarjetaFormulacion";
		private const string PROC_ACTUALIZAPMAA_TARJETAFORMULACION = "Proc_ActualizaPMMA_TarjetaFormulacion";
		private const string PROC_CALCULOPMMA_TARJETAFORMULACION = "Proc_CalculoPmma";
		private const string PROC_ACTUALIZASUMACOMOLADITIVOS_TARJETAFORMULACION = "Proc_ActualizColorAditivos";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);


			if((ConfigurationManager.AppSettings["TiempoRefreshListadoOrdenesColorAditivos"] != "0") && (ConfigurationManager.AppSettings["TiempoRefreshListadoOrdenesColorAditivos"]!=""))
				ltrRefresh.Text = "<META http-equiv='Refresh' content='" + ConfigurationManager.AppSettings["TiempoRefreshListadoOrdenesColorAditivos"] + "'>" ;						

			if(!IsPostBack)
			{
				string InitDt, FinalDt;

				InitDt = (string) Session["InitialDate"];
				FinalDt = (string) Session["FinalDate"];

				String sFechaIni = System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();
				String sFechaFin = System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();

				if (InitDt == null || FinalDt ==null)
				{					
					txtFecha.Text = sFechaIni.Replace(".","");
					txtFechaFinal.Text = sFechaFin.Replace(".","");
				}
				else
				{							
					txtFecha.Text = InitDt;
					txtFechaFinal.Text = FinalDt;
				}

				LoadWorkOrders(txtFecha.Text,txtFechaFinal.Text);
			
				if(Request.QueryString["RedFlag"]!=null)
				{
					if(Request.QueryString["RedFlag"]=="1")
						ReDirect(Convert.ToInt32(Session[this.Context.User.Identity.Name+"ItemIndex"]),Request.QueryString["ShortCut"].ToString());
				}

////				se agrega lineas de botones para planta 2

				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);

				//Planta OCO
				if (theUser.IdPlanta.Equals(1))
				{
					btnImprimirEqu.Text = "Imp. Etiquetas";
					btnImprimirSLPC.Visible = false; 
					this.btnPreform.Visible = false;			// Solicitado por Rafael Troche 08/06/2016
				}
				else
				{
					btnImprimirEqu.Text = "Imp. Aditivos" ;
					btnImprimirSLPC.Text = "Imp. Color" ;
					btnImprimirSLPC.Visible = true; 
					this.btnPreform.Visible = true;			// Solicitado por Rafael Troche 08/06/2016	
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
			prcCboFill();
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>

		
		private void InitializeComponent()
		{    
			this.cboLinea.SelectedIndexChanged += new System.EventHandler(this.cboLinea_SelectedIndexChanged);
			this.btnImprimirEqu.Click += new System.EventHandler(this.btnImprimirEqu_Click);
			this.btnImprimirSLPC.Click += new System.EventHandler(this.btnImprimirSLPC_Click);
			this.btnRpt.Click += new System.EventHandler(this.btnRpt_Click);
			this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
			this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
			this.btnPreform.Click += new System.EventHandler(this.btnPreform_Click);
			this.btnDust.Click += new System.EventHandler(this.btnDust_Click);
			this.lstWorkOrder.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.lstWorkOrder_ItemCommand);
			this.lstWorkOrder.ItemDataBound += new System.Web.UI.WebControls.DataListItemEventHandler(this.lstWorkOrder_ItemDataBound);
			this.lstWorkOrder.SelectedIndexChanged += new System.EventHandler(this.lstWorkOrder_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		
		#endregion

		private void LoadWorkOrders(string initialDate, string finalDate) 
		{

//			Session[this.Context.User.Identity.Name+"InitialDate"]=initialDate;
//			Session[this.Context.User.Identity.Name+"FinalDate"]=finalDate;

			Session["InitialDate"]=initialDate;
			Session["FinalDate"]=finalDate;

			int IdStatus=int.Parse(cboStatus.SelectedItem.Value);
			int IdLinea=int.Parse(cboLinea.SelectedItem.Value);
			int IdArea=Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]);
			Session[this.Context.User.Identity.Name+"selectedLine"] = IdLinea.ToString();
			Session[this.Context.User.Identity.Name+"selectedIdStatus"] = cboStatus.SelectedItem.Value;

			SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
			IList WOList = (IList)WorkOrder.LoadWorkOrders(IdArea,IdLinea,IdStatus,string.Empty,initialDate,finalDate);
			lstWorkOrder.DataSource = WOList;
			lstWorkOrder.DataBind();
			for(int i=0;i<lstWorkOrder.Items.Count;i++)
			{
				SICALNet.BusinessLogicLayer.PartidasAditivos blPartidasAdi = new SICALNet.BusinessLogicLayer.PartidasAditivos();
				string secuencia=((Label)lstWorkOrder.Items[i].FindControl("ItemSecuencia")).Text.ToString();
				int Status =Convert.ToInt32(((Label)lstWorkOrder.Items[i].FindControl("ItemIdStatus")).Text.ToString());
				if(blPartidasAdi.IsExistSecuencia(secuencia,Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"])))
				{
					lstWorkOrder.Items[i].FindControl("aspPlus").Visible=true;
					((Label)lstWorkOrder.Items[i].FindControl("spacer")).Visible=false;
					//((CheckBox)lstWorkOrder.Items[i].FindControl("chkSelect")).Enabled=false;
				}
				if(Status==5)
					((CheckBox)lstWorkOrder.Items[i].FindControl("chkSelect")).Enabled=false;
			}
			int idAuxPlanta=1;
			if(this.cboLinea.SelectedItem.Value != "0")
			{
				SICALNet.BusinessLogicLayer.LineaProduccion  blLinea =  new SICALNet.BusinessLogicLayer.LineaProduccion();						
				idAuxPlanta = blLinea.GetIdPlanta( Convert.ToInt32(this.cboLinea.SelectedItem.Value));				
				
			}
			SICALNet.BusinessEntities.OllaInfo oInfo = new SICALNet.BusinessEntities.OllaInfo(0,idAuxPlanta,0,0);

			SICALNet.BusinessLogicLayer.Olla blOlla = new SICALNet.BusinessLogicLayer.Olla();
			IList OllaList=(IList)blOlla.SelectOlla(oInfo); 
			CmbOlla.DataSource=OllaList;
			CmbOlla.DataTextField="CapacidadMax";
			/*** comentado por alejandro.hernandez@nasoft.com 07/03/2006 ***/
			//float[] max = new float[OllaList.Count];
			CmbOlla.DataBind();
			CmbOlla.Items[0].Selected=true;
			//LoadChildGrid();
		}



		private void prcCboFill()
		{
			SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
			SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
			theUser  = BLLUser.Load(theUser);

			//to fill the Linea description into the cboLinea control
			SICALNet.BusinessLogicLayer.LineaProduccion BLLLine=new SICALNet.BusinessLogicLayer.LineaProduccion();
			IList RsLine=(IList) BLLLine.SelectLinePdt(theUser);
			prcCboCommon(cboLinea,"IdLinea","Description",RsLine);
			//to fill the Status description into the cboStatus control
			SICALNet.BusinessLogicLayer.Status BLLStatus=new SICALNet.BusinessLogicLayer.Status();
			IList RsStatus=(IList) BLLStatus.Load();
			prcCboCommon(cboStatus,"IdStatus","Descripcion",RsStatus);
			
		}

		private void prcCboCommon(DropDownList cbo,string sVal,string sTxt,IList RsList)
		{
			cbo.DataSource=RsList;
			cbo.DataValueField=sVal;
			cbo.DataTextField=sTxt;
			cbo.DataBind();
			cbo.Items.Add(new ListItem(string.Empty,"0"));
			
			if (sVal=="IdLinea")
			{
				string currentLine=(string)Session[this.Context.User.Identity.Name+"selectedLine"];
				if (currentLine != null)
					cbo.Items.FindByValue(currentLine).Selected=true;
				else
				{
					SICALNet.BusinessEntities.UsuarioInfo User = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
					SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				
					User = BLLUser.Load(User);
					string lineaDefault;

					switch(User.IdPlanta)
					{
						case 1:	// Ocoyoacac
							lineaDefault = "1";
							break;
						case 2: // San Luis
							lineaDefault = "4";
							break;
						default:
							lineaDefault = "0";
							break;
					}

					cbo.Items.FindByValue(lineaDefault).Selected=true;
					
				}
				return;
			}
	

			if (sVal=="IdStatus")
			{
				string currentStatus=(string)Session[this.Context.User.Identity.Name+"selectedIdStatus"];
				if (currentStatus != null)
					cbo.Items.FindByValue(currentStatus).Selected=true;
				else
					// cbo.Items.FindByValue("0").Selected=true;
					cbo.Items.FindByValue("2").Selected=true; // Activo por default
				return;
			}
		
			cbo.Items.FindByValue("0").Selected=true;		




		}

		private void btnSel_Click(object sender, System.EventArgs e)
		{
			try
			{
				LoadWorkOrders(txtFecha.Text.Trim(),txtFechaFinal.Text.Trim());
			}
			catch
			{
				throw;
			}
		}

//		private void dgdWorkOrder_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
//		{
//			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
//			{
//				Label lblFechaMod = (Label)e.Item.FindControl("ItemFechaMod");
//				if (lblFechaMod.Text != "") 
//				{
//					e.Item.BackColor = Color.Yellow;
//					DateTime timeAux = Convert.ToDateTime(lblFechaMod.Text); 
//					if (timeAux.ToString("dd/MMM/yy")   == DateTime.MinValue.ToString("dd/MMM/yy")) 
//						e.Item.BackColor = Color.LightBlue;   
//
//				}
//
//				Label lblStatus = (Label)e.Item.FindControl("ItemIdStatus");
//				if (lblStatus.Text == ConfigurationManager.AppSettings["StatusCancel"]) 
//					e.Item.BackColor = Color.Tomato;
//
//			}
//		}

//		private void dgdWorkOrder_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//		
//		}
		private void lstWorkOrder_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			try
			{
				/*** modificado por alejandro.hernandez@nasoft.com 24/02/2006 ***/
				string Status= "";
				string Codigosap= "";
				string planta="";
				string Desc="";
				int[] aryLaminas = new int[0];
				float[] aryOlla = new float[0];
				int i=0;
				int Container=0;
				/*** fin de modificación ***/


				if (e.CommandName == "Consult")
			{	
					int itemidx=0;
					/*for (int iLoop=0; iLoop < lstWorkOrder.Items.Count; iLoop++)
						lstWorkOrder.Items[iLoop].BackColor=Color.White;
					lstWorkOrder.Items[e.Item.ItemIndex].BackColor=Color.Lavender; */
					string secuance=((Label)e.Item.FindControl("ItemSecuencia")).Text.ToString();
					SICALNet.BusinessEntities.SecuenciaCombinasInfo scInfo = new SICALNet.BusinessEntities.SecuenciaCombinasInfo(secuance,0);
					SICALNet.BusinessLogicLayer.SecuenciaCombinas blSC = new SICALNet.BusinessLogicLayer.SecuenciaCombinas();
					IList CombinasList=blSC.SelectSecuenciaCombinas(scInfo);
					int plantaAux= Convert.ToInt32(((Label)e.Item.FindControl("ItemIdPlanta")).Text.ToString()); 
					MaterialInfo BEMaterial=new MaterialInfo(((Label)e.Item.FindControl("ItemCodigoSAP")).Text.ToString(),"",0,"",0,"",0,"",0,0,0,0,0,"","","","","","","","","",plantaAux,false);
					//MaterialInfo BEMaterial = new MaterialInfo(((Label)e.Item.FindControl("ItemCodigoSAP")).Text.ToString(),string.Empty);				
					Material  BLMaterial = new Material();
					BEMaterial=BLMaterial.SelectMaterial(BEMaterial);

					if(CombinasList.Count==0)
					{
						string Cantidad=((Label)e.Item.FindControl("ItemCantidad")).Text.ToString();
						Status=((Label)e.Item.FindControl("ItemIdStatus")).Text.ToString();
						string IdLinea=((Label)e.Item.FindControl("ItemIdLinea")).Text.ToString(); 
						Codigosap=((Label)e.Item.FindControl("ItemCodigoSAP")).Text.ToString(); 
						planta=((Label)e.Item.FindControl("ItemIdPlanta")).Text.ToString(); 
						Desc=((Label)e.Item.FindControl("ItemDescripcion")).Text.ToString();
						// -------------------------------------------------------------------------------
						// 
						// Validate that there exists at least one formulation of additives for that Material 
						// for the current row
						// -------------------------------------------------------------------------------
				
						FormAditivosInfo faInfo = new FormAditivosInfo(string.Empty,string.Empty,Convert.ToInt32(IdLinea),Convert.ToInt32(planta),Codigosap,0);
						FormAditivos FormAditivos = new FormAditivos();
						if(!FormAditivos.isExistMaterialFormAditivos(faInfo) && (BEMaterial.IdEstadoMaterial!=Convert.ToInt32(ConfigurationManager.AppSettings["IdInstrucciones"])))
						{
							throw new Exception("El material " + Codigosap + " " + BEMaterial.IdColor + "/" + BEMaterial.IdEspesor + "/" + BEMaterial.VersionAditivos + " no tiene formulación de Aditivos"); 							
						}


						for(i=1;i<(lstWorkOrder.Items.Count-e.Item.ItemIndex);i++)
						{
							if(itemidx==0)
							{
								if(((Label)lstWorkOrder.Items[e.Item.ItemIndex+i].FindControl("ItemIdStatus")).Text.ToString()=="2")
									itemidx=e.Item.ItemIndex+i;
							}
						}
						if(itemidx==0)
							itemidx=e.Item.ItemIndex+1;
						//session variable is used for rest of the forms in wizards
						Session[this.Context.User.Identity.Name+"Secuencia"]=secuance;
						Session[this.Context.User.Identity.Name+"Cantidad"]=Cantidad;
						Session[this.Context.User.Identity.Name+"IdLinea"]=IdLinea;
						Session[this.Context.User.Identity.Name+"cmbIdLinea"]=cboLinea.SelectedItem.Value.ToString();
						Session[this.Context.User.Identity.Name+"cmbIdStatus"]=cboStatus.SelectedItem.Value.ToString();
						Session[this.Context.User.Identity.Name+"CodigoSAP"]=Codigosap;
						Session[this.Context.User.Identity.Name+"IdPlanta"]=planta;
						Session[this.Context.User.Identity.Name+"IdStatus"]=Status;
						Session[this.Context.User.Identity.Name+"FormularFlag"]="0";
						Session[this.Context.User.Identity.Name+"ItemIndex"]=itemidx;
						if(Status=="5")
						{
							SICALNet.BusinessLogicLayer.PartidasAditivos blPartidasAdi = new SICALNet.BusinessLogicLayer.PartidasAditivos();
							Container=(int)blPartidasAdi.GetNoContainers(secuance,Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]));
							Session[this.Context.User.Identity.Name+"NoCuanto"]=Container;
							IList NoOllaList=(IList)blPartidasAdi.LoadOlla(Session[this.Context.User.Identity.Name+"Secuencia"].ToString(),0,"Olla");
							aryLaminas = new int[Container];
							aryOlla = new float[Container];
							for(i=0;i<NoOllaList.Count;i++)
							{
								SICALNet.BusinessEntities.PartidasAditivosInfo PAInfo = new SICALNet.BusinessEntities.PartidasAditivosInfo();
								PAInfo = (SICALNet.BusinessEntities.PartidasAditivosInfo)NoOllaList[i];
								aryLaminas[i]=PAInfo.NoLaminas;
								aryOlla[i]=PAInfo.CapacidadOlla;
							}
							Session[this.Context.User.Identity.Name+"VasoQty"]=aryLaminas;
							Session[this.Context.User.Identity.Name+"flag"]="1";
							Session[this.Context.User.Identity.Name+"Olla"]=aryOlla;
							Response.Redirect("AditivosCuarto.aspx?CantidadSum="+Cantidad);
						}
						else if(((CheckBox)e.Item.FindControl("chkSelect")).Checked==true)
						{
							SICALNet.BusinessLogicLayer.PartidasAditivos blPartidasAdi = new SICALNet.BusinessLogicLayer.PartidasAditivos();
							if(blPartidasAdi.IsExistSecuencia(secuance,Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"])))
							{
								//SICALNet.BusinessEntities.OrdenesTrabajoInfo OInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text,Convert.ToInt32(ConfigurationManager.AppSettings["ColorRoomId"]),0);
								//SICALNet.BusinessLogicLayer.OrdenesTrabajo blOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
								//int Status=blOrdenes.GetStatus(OInfo);
								//Session[this.Context.User.Identity.Name+"IdStatus"]=Status;
								Container=(int)blPartidasAdi.GetNoContainers(secuance,Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]));
								Session[this.Context.User.Identity.Name+"NoCuanto"]=Container;
								IList NoOllaList=(IList)blPartidasAdi.LoadOlla(Session[this.Context.User.Identity.Name+"Secuencia"].ToString(),0,"Olla");
								aryLaminas = new int[Container];
								aryOlla = new float[Container];
								for(i=0;i<NoOllaList.Count;i++)
								{
									SICALNet.BusinessEntities.PartidasAditivosInfo PAInfo = new SICALNet.BusinessEntities.PartidasAditivosInfo();
									PAInfo = (SICALNet.BusinessEntities.PartidasAditivosInfo)NoOllaList[i];
									aryLaminas[i]=PAInfo.NoLaminas;
									aryOlla[i]=PAInfo.CapacidadOlla;
								}
								Session[this.Context.User.Identity.Name+"VasoQty"]=aryLaminas;
								Session[this.Context.User.Identity.Name+"flag"]="1";
								Session[this.Context.User.Identity.Name+"Olla"]=aryOlla;
								Response.Redirect("AditivosCuarto.aspx?CantidadSum="+Session[this.Context.User.Identity.Name+"Cantidad"]+"&ShortCut=True");
							
							}
							else
							{
						
								Container=1;
								Session[this.Context.User.Identity.Name+"NoCuanto"]=Container;
								aryLaminas = new int[Container];
								aryOlla = new float[Container];
								aryLaminas[0]=Convert.ToInt32(Cantidad);
								aryOlla[0]=Convert.ToSingle(CmbOlla.SelectedItem.Text);
								Session[this.Context.User.Identity.Name+"VasoQty"]=aryLaminas;
								Session[this.Context.User.Identity.Name+"flag"]="0";
								Session[this.Context.User.Identity.Name+"Olla"]=aryOlla;
								SICALNet.BusinessLogicLayer.PartidasAditivos blPartidas = new SICALNet.BusinessLogicLayer.PartidasAditivos();
								/*** modificado por alejandro.hernandez@nasoft.com 28/02/2006 ***/
								blPartidas.CheckOlla(Codigosap,aryLaminas[0],aryOlla[0],10,Convert.ToInt32(planta));
								//blPartidas.CheckOlla(Codigosap,aryLaminas[0],1,aryOlla[0],10,Convert.ToInt32(planta));
								/*** fin modificación ***/
								Response.Redirect("AditivosCuarto.aspx?CantidadSum="+Cantidad+"&ShortCut=True");									
							}
							
						}
							//string queryString=string.Format("?Secuencia={0}&Cantidad={1}&Fecha={2}&UTEC={3}&CodigoSAP={4}&IdStatus={5}&IdPlanta={6}",secuance,Cantidad,Fecha,UTEC,CodigoSAP,IdStatus,IdPlanta);
							//Response.Redirect(string.Format("NoOfVasos.aspx{0}",queryString));
						else
							//Response.Redirect("AditivosCuantos.aspx");
							Response.Redirect("AditivosCuantos.aspx?Secuencia="+secuance+"&Cantidad="+Cantidad+"&IdLinea="+IdLinea+"&Status="+Status+"&Descripcion="+Desc+"&ReFlag=False");
					}
					else
					{
						Status=((Label)e.Item.FindControl("ItemIdStatus")).Text.ToString();
						Codigosap=((Label)e.Item.FindControl("ItemCodigoSAP")).Text.ToString(); 
						planta=((Label)e.Item.FindControl("ItemIdPlanta")).Text.ToString(); 
						Desc=((Label)e.Item.FindControl("ItemDescripcion")).Text.ToString(); 




						for(i=0;i<(lstWorkOrder.Items.Count-e.Item.ItemIndex);i++)
						{
							if(((Label)lstWorkOrder.Items[e.Item.ItemIndex+i].FindControl("ItemIdStatus")).Text.ToString()=="2")
								itemidx=e.Item.ItemIndex+i;
						}
						if(itemidx==0)
							itemidx=e.Item.ItemIndex+1;
						string[] secuencia = new string[CombinasList.Count];
						int[] Cantidad = new int[CombinasList.Count];
						int[] Linea = new int[CombinasList.Count];
						string[] Fecha = new string[CombinasList.Count];
						for(int iloop=0;iloop<CombinasList.Count;iloop++)
						{	
			
							// -------------------------------------------------------------------------------
							// 
							// Validate that there exists at least one formulation of additives for that Material 
							// for the current row
							// -------------------------------------------------------------------------------
							scInfo=(SICALNet.BusinessEntities.SecuenciaCombinasInfo)CombinasList[iloop];

							FormAditivosInfo faInfo = new FormAditivosInfo(string.Empty,string.Empty,scInfo.Linea,Convert.ToInt32(planta),Codigosap,0);
							FormAditivos FormAditivos = new FormAditivos();
							if(!FormAditivos.isExistMaterialFormAditivos(faInfo) && (BEMaterial.IdEstadoMaterial!=Convert.ToInt32(ConfigurationManager.AppSettings["IdInstrucciones"])))
							{
								throw new Exception("El material " + Codigosap + " " + BEMaterial.IdColor + "/" + BEMaterial.EspesorDesc + "/" + BEMaterial.VersionAditivos + " no tiene formulación de Aditivos"); 							
							}




							//SICALNet.BusinessEntities.SecuenciaCombinasInfo scInfo = new SICALNet.BusinessEntities.SecuenciaCombinasInfo();
									
							secuencia[iloop]=scInfo.Secuencia;
							Cantidad[iloop]=Convert.ToInt32(scInfo.Cantidad);
							Linea[iloop]=scInfo.Linea;
							Fecha[iloop]=scInfo.Fecha;
						}
						//session variable is used for rest of the forms in wizards
						Session[this.Context.User.Identity.Name+"Secuencia"]=secuencia;
						Session[this.Context.User.Identity.Name+"Cantidad"]=Cantidad;
						Session[this.Context.User.Identity.Name+"IdLinea"]=Linea[0];
						Session[this.Context.User.Identity.Name+"cmbIdLinea"]=cboLinea.SelectedItem.Value.ToString();
						Session[this.Context.User.Identity.Name+"cmbIdStatus"]=cboStatus.SelectedItem.Value.ToString();
						Session[this.Context.User.Identity.Name+"CodigoSAP"]=Codigosap;
						Session[this.Context.User.Identity.Name+"IdPlanta"]=planta;
						Session[this.Context.User.Identity.Name+"IdStatus"]=Status;
						Session[this.Context.User.Identity.Name+"FormularFlag"]=CombinasList.Count;
						Session[this.Context.User.Identity.Name+"ItemIndex"]=itemidx;
						Session[this.Context.User.Identity.Name+"Fecha"]=Fecha;
						if(Status=="5")
						{
							SICALNet.BusinessLogicLayer.PartidasAditivos blPartidasAdi = new SICALNet.BusinessLogicLayer.PartidasAditivos();
							Container=(int)blPartidasAdi.GetNoContainers(secuencia[0],Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]));
							Session[this.Context.User.Identity.Name+"NoCuanto"]=Container;
							string sec="'";
							int CantidadSum=0;
							for(i=0;i<secuencia.Length;i++)
							{
								CantidadSum+=Cantidad[i];
								sec+=secuencia[i];
								if(i==((secuencia.Length)-1))
									sec+="'";
								else
									sec+="','";
							}
							IList NoOllaList=(IList)blPartidasAdi.LoadOllaCombined(sec);
							aryLaminas = new int[Container];
							aryOlla = new float[Container];
							for(i=0;i<NoOllaList.Count;i++)
							{
								SICALNet.BusinessEntities.PartidasAditivosInfo PAInfo = new SICALNet.BusinessEntities.PartidasAditivosInfo();
								PAInfo = (SICALNet.BusinessEntities.PartidasAditivosInfo)NoOllaList[i];
								aryLaminas[i]=PAInfo.NoLaminas;
								aryOlla[i]=PAInfo.CapacidadOlla;
							}
							Session[this.Context.User.Identity.Name+"VasoQty"]=aryLaminas;
							Session[this.Context.User.Identity.Name+"flag"]="1";
							Session[this.Context.User.Identity.Name+"Olla"]=aryOlla;
							Response.Redirect("AditivosCuarto.aspx?CantidadSum="+CantidadSum);
						}
						else if(((CheckBox)e.Item.FindControl("chkSelect")).Checked==true)
						{
							SICALNet.BusinessLogicLayer.PartidasAditivos blPartidasAdi = new SICALNet.BusinessLogicLayer.PartidasAditivos();
							string[] Secuencia = (string[])Session[this.Context.User.Identity.Name+"Secuencia"]; 
							//SICALNet.BusinessEntities.OrdenesTrabajoInfo OInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(Secuencia[0],Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]),0);
							//SICALNet.BusinessLogicLayer.OrdenesTrabajo blOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
							//int Status=blOrdenes.GetStatus(OInfo);
							//Session[this.Context.User.Identity.Name+"IdStatus"]=Status;
							if(blPartidasAdi.IsExistSecuencia(Secuencia[0],Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"])))
							{
						
								Container=(int)blPartidasAdi.GetNoContainers(Secuencia[0],Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]));
								Session[this.Context.User.Identity.Name+"NoCuanto"]=Container;
								string sec="'";
								int CantidadSum=0;
								for(i=0;i<Secuencia.Length;i++)
									CantidadSum+=Cantidad[i];
								//int CantidadSum=Convert.ToInt32(txtCantidad.Text);
								for(i=0;i<Secuencia.Length;i++)
								{
						
									sec+=Secuencia[i];
									if(i==((Secuencia.Length)-1))
										sec+="'";
									else
										sec+="','";
								}
								IList NoOllaList=(IList)blPartidasAdi.LoadOllaCombined(sec);
								aryLaminas = new int[Container];
								aryOlla = new float[Container];
								for(i=0;i<NoOllaList.Count;i++)
								{
									SICALNet.BusinessEntities.PartidasAditivosInfo PAInfo = new SICALNet.BusinessEntities.PartidasAditivosInfo();
									PAInfo = (SICALNet.BusinessEntities.PartidasAditivosInfo)NoOllaList[i];
									aryLaminas[i]=PAInfo.NoLaminas;
									aryOlla[i]=PAInfo.CapacidadOlla;
								}
								Session[this.Context.User.Identity.Name+"VasoQty"]=aryLaminas;
								Session[this.Context.User.Identity.Name+"flag"]="1";
								Session[this.Context.User.Identity.Name+"Olla"]=aryOlla;
								Response.Redirect("AditivosCuarto.aspx?CantidadSum="+CantidadSum+"&ShortCut=True");
							}
							else
							{
						
								Container=1;
								Session[this.Context.User.Identity.Name+"NoCuanto"]=Container;
								aryLaminas = new int[Container];
								aryOlla = new float[Container];
								int CantidadSum=0;
								for(i=0;i<secuencia.Length;i++)
									CantidadSum+=Cantidad[i];
								aryLaminas[0]=CantidadSum;
								aryOlla[0]=Convert.ToSingle(CmbOlla.SelectedItem.Text);
								Session[this.Context.User.Identity.Name+"VasoQty"]=aryLaminas;
								Session[this.Context.User.Identity.Name+"flag"]="0";
								Session[this.Context.User.Identity.Name+"Olla"]=aryOlla;
								SICALNet.BusinessLogicLayer.PartidasAditivos blPartidas = new SICALNet.BusinessLogicLayer.PartidasAditivos();
								/*** modificado por alejandro.hernandez@nasoft.com 28/02/2006 ***/
								blPartidas.CheckOlla(Codigosap,aryLaminas[0],aryOlla[0],10,Convert.ToInt32(planta));
								//blPartidas.CheckOlla(Codigosap,aryLaminas[0],1,aryOlla[0],10,Convert.ToInt32(planta));
								/*** fin modificación ***/
								Response.Redirect("AditivosCuarto.aspx?CantidadSum="+CantidadSum+"&ShortCut=True");									
							}
							
						}
							//string queryString=string.Format("?Secuencia={0}&Cantidad={1}&Fecha={2}&UTEC={3}&CodigoSAP={4}&IdStatus={5}&IdPlanta={6}",secuance,Cantidad,Fecha,UTEC,CodigoSAP,IdStatus,IdPlanta);
							//Response.Redirect(string.Format("NoOfVasos.aspx{0}",queryString));
						else
							//Response.Redirect("AditivosCuantos.aspx");
							Response.Redirect("AditivosCuantos.aspx?Secuencia="+secuance+"&Cantidad="+Cantidad+"&IdLinea="+Linea+"&Status="+Status+"&Descripcion="+Desc+"&ReFlag=False");
				

						//Response.Redirect("SecuenciasCombinadas.aspx?Descripcion="+Desc+"&Room=Aditivos");
					}

				}
				if (e.CommandName=="Mensaje")
				{
					string Secuencia = ((Label)e.Item.FindControl("ItemSecuencia")).Text.ToString();
					string IdArea= ConfigurationManager.AppSettings["AditivosRoomId"].ToString();
					Codigosap=((Label)e.Item.FindControl("ItemCodigoSAP")).Text.ToString();
					string matDesc=((Label)e.Item.FindControl("ItemDescripcion")).Text.ToString();
					RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+Codigosap+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");
				}
				if(e.CommandName=="Expand")
				{
					string _secuencia = ((Label)e.Item.FindControl("ItemSecuencia")).Text.ToString();
					int _status  = Convert.ToInt32(((Label)e.Item.FindControl("ItemIdStatus")).Text.ToString());
					LoadChildGrid(_secuencia,_status);
				}
				/*
				if(e.CommandName=="Contract")
				{
					DataList lstLaminas=((DataList)lstWorkOrder.Items[e.Item.ItemIndex].FindControl("dstLaminas"));
					lstLaminas.Visible=false;
					((ImageButton)lstWorkOrder.Items[e.Item.ItemIndex].FindControl("imgbtnPlus")).Visible=true;
					((ImageButton)lstWorkOrder.Items[e.Item.ItemIndex].FindControl("imgbtnminus")).Visible=false;
				}*/
			}
			catch
			{
				throw;
			}
		}

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
			try
			{
				IList aryClrRm = new ArrayList();
				int IdArea= Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"].ToString());
				for(int iloop=0;iloop<lstWorkOrder.Items.Count;iloop++)
				{
					string secuencia=((Label)lstWorkOrder.Items[iloop].FindControl("ItemSecuencia")).Text.ToString();
					DateTime Fecha=Convert.ToDateTime(((Label)lstWorkOrder.Items[iloop].FindControl("ItemFecha")).Text.ToString());
					DataList lstLaminas=((DataList)lstWorkOrder.Items[iloop].FindControl("dstLaminas"));
					if(((CheckBox)lstWorkOrder.Items[iloop].FindControl("chkSelect")).Checked==true)
					{					
						for(int inloop=0;inloop<lstLaminas.Items.Count;inloop++)
						{
							int Olla=Convert.ToInt32(((Label)lstLaminas.Items[inloop].FindControl("lblVaso")).Text.ToString());
							int Laminas=Convert.ToInt32(((Label)lstLaminas.Items[inloop].FindControl("lblLaminas")).Text.ToString());
							DataGrid dgdAditivos = ((DataGrid)lstLaminas.Items[inloop].FindControl("dgdAditivos"));
							SICALNet.Utilities.Validation pdvlt = new SICALNet.Utilities.Validation();
							for(int iinloop=0;iinloop<dgdAditivos.Items.Count;iinloop++)
							{
								string Codigo=((Label) dgdAditivos.Items[iinloop].FindControl("AditivosCodigoSAP")).Text.ToString();
								decimal Cantidad=Convert.ToDecimal(((Label) dgdAditivos.Items[iinloop].FindControl("AditivosCantidad")).Text.ToString());
								if(!pdvlt.IsNumber(((TextBox) dgdAditivos.Items[iinloop].FindControl("txtCantidadReal")).Text.ToString()))
									throw new Exception(" The Cantidad Real Should be Number");
								decimal CantidadReal=Convert.ToDecimal(((TextBox) dgdAditivos.Items[iinloop].FindControl("txtCantidadReal")).Text.ToString());
								string folio=((TextBox) dgdAditivos.Items[iinloop].FindControl("txtFolio")).Text;
								string capacidadOlla= ((Label) dgdAditivos.Items[iinloop].FindControl("lblCapacidadOlla")).Text;
								float capolla=0;
								if (capacidadOlla!=string.Empty)
								{
									capolla = Convert.ToSingle(capacidadOlla.ToString());
								}

								SICALNet.BusinessEntities.PartidasAditivosInfo  BEparti=new SICALNet.BusinessEntities.PartidasAditivosInfo(
									secuencia,IdArea,Codigo,Olla,Laminas,Cantidad,CantidadReal,Fecha.ToString("dd/MMM/yyyy"),folio,capolla,0);
								aryClrRm.Add(BEparti);
							}
						}

						SICALNet.BusinessLogicLayer.PartidasAditivos PAd = new SICALNet.BusinessLogicLayer.PartidasAditivos();
						PAd.Delete(secuencia);
						PAd.Insert(aryClrRm);
						aryClrRm.Clear();
						SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(secuencia,Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]),this.Context.User.Identity.Name);
						SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						BLOrdenes.UpdateLoginForm(OTInfo);
					}
				}
			}
			catch
			{
//				string sErrMsg;
//				sErrMsg=ErrHand.Message.Replace("'","-");
//				string ScriptString="<script language='javascript'>alert('"+ sErrMsg +"');</script>"; 
//				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);

				throw;
			}

		}
//		private void BindWO()
//		{
//			//to get the instance for BusinessLogicLayer
//			SICALNet.BusinessLogicLayer.OrdenesTrabajo BLLOrdTra= new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
//			//to Call the Select method
//			//			int IdArea=int.Parse(cboArea.SelectedItem.Value);
//			int IdStatus=int.Parse(cboStatus.SelectedItem.Value);
//			int IdLinea=int.Parse(cboLinea.SelectedItem.Value);
//			int IdArea=Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]);
//			//			string IdColor=cboColor.SelectedItem.Value;
//			DateTime FechaInicial=Convert.ToDateTime(txtFecha.Text);
//			DateTime FechaFinal=Convert.ToDateTime(txtFechaFinal.Text);
//			
////			Session[this.Context.User.Identity.Name+"InitialDate"]=FechaInicial.ToString("dd-MMM-yy");
////			Session[this.Context.User.Identity.Name+"FinalDate"]=FechaFinal.ToString("dd-MMM-yy");
//
//			Session["InitialDate"]=FechaInicial.ToString("dd-MMM-yy");
//			Session["FinalDate"]=FechaFinal.ToString("dd-MMM-yy");
//				
//			////				IList RsOrdTra= (IList)BLLOrdTra.LoadWorkOrders(IdArea,IdLine,IdStatus,IdColor,InitDt,FinalDt);
//			////				IList RsOrdTra= (IList)BLLOrdTra.LoadWorkOrders(1,IdLine,1,string.Empty,InitDt,FinalDt);
//				
//			SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
//			IList WOList = (IList)WorkOrder.LoadWorkOrders(IdArea,IdLinea,IdStatus,string.Empty,FechaInicial.ToString("dd/MMM/yy"),FechaFinal.ToString("dd/MMM/yy"));
//			lstWorkOrder.DataSource = WOList;
//			lstWorkOrder.DataBind();
//			for(int i=0;i<lstWorkOrder.Items.Count;i++)
//			{
//				SICALNet.BusinessLogicLayer.PartidasAditivos blPartidasAdi = new SICALNet.BusinessLogicLayer.PartidasAditivos();
//				string secuencia=((Label)lstWorkOrder.Items[i].FindControl("ItemSecuencia")).Text.ToString();
//				int Status =Convert.ToInt32(((Label)lstWorkOrder.Items[i].FindControl("ItemIdStatus")).Text.ToString());
//				if(blPartidasAdi.IsExistSecuencia(secuencia,Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"])))
//				{
//					((CheckBox)lstWorkOrder.Items[i].FindControl("chkSelect")).Enabled=true;
//					SICALNet.BusinessLogicLayer.PartidasAditivos blPAdt= new SICALNet.BusinessLogicLayer.PartidasAditivos();
//					IList NoOllaList=(IList)blPAdt.LoadOlla(secuencia,0,"Laminas");
//					DataList lstLaminas=((DataList)lstWorkOrder.Items[i].FindControl("dstLaminas"));
//					lstLaminas.DataSource=NoOllaList;
//					lstLaminas.DataBind();
//					for(int inloop=0;inloop<NoOllaList.Count;inloop++)
//					{
//						SICALNet.BusinessEntities.PartidasAditivosInfo bePAdd = new SICALNet.BusinessEntities.PartidasAditivosInfo();
//						bePAdd=(SICALNet.BusinessEntities.PartidasAditivosInfo)NoOllaList[inloop];
//						SICALNet.BusinessLogicLayer.PartidasAditivos blPAdd=new SICALNet.BusinessLogicLayer.PartidasAditivos();
//						IList OllaList=blPAdd.Select(secuencia,Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]),bePAdd.NumeroOlla);
//						DataGrid dgdAditivos = ((DataGrid)lstLaminas.Items[inloop].FindControl("dgdAditivos"));
//						dgdAditivos.DataSource=OllaList;
//						dgdAditivos.DataBind();
//						if(Status==5)
//						{
//							dgdAditivos.Columns[4].Visible=true;
//							dgdAditivos.Columns[6].Visible=true;
//							dgdAditivos.Columns[3].Visible=false;
//							dgdAditivos.Columns[5].Visible=false;
//								
//						}
//					}
//				}
//
//			}
//		}
		private void btnLiberar_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
				System.Text.StringBuilder Secuencias = new System.Text.StringBuilder();
//				string Secuencias="";
				for(int i=0;i<lstWorkOrder.Items.Count;i++)
				{
					if((((CheckBox)lstWorkOrder.Items[i].FindControl("chkSelect")).Checked==true))
					{
						SICALNet.BusinessLogicLayer.PartidasAditivos blPartidasAdi = new SICALNet.BusinessLogicLayer.PartidasAditivos();
						string secuencia=((Label)lstWorkOrder.Items[i].FindControl("ItemSecuencia")).Text.ToString();
						if(!blPartidasAdi.IsExistSecuencia(secuencia,Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"])))
						{
							Secuencias.Append(secuencia).Append(",");

//							Secuencias+=secuencia+",";
						}
					}
				}
				if(Secuencias.Length==0)
					
					/*** fin modificación ***/
				{
					IList aryClrRm = new ArrayList();
					int IdArea= Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"].ToString());
					for(int iloop=0;iloop<lstWorkOrder.Items.Count;iloop++)
					{
						string secuencia=((Label)lstWorkOrder.Items[iloop].FindControl("ItemSecuencia")).Text.ToString();
						int Status =Convert.ToInt32(((Label)lstWorkOrder.Items[iloop].FindControl("ItemIdStatus")).Text.ToString());
						DateTime Fecha=Convert.ToDateTime(((Label)lstWorkOrder.Items[iloop].FindControl("ItemFecha")).Text.ToString());
						if((((CheckBox)lstWorkOrder.Items[iloop].FindControl("chkSelect")).Checked==true))
						{	
							LoadChildGrid(secuencia,Status);
							DataList lstLaminas=((DataList)lstWorkOrder.Items[iloop].FindControl("dstLaminas"));
							for(int inloop=0;inloop<lstLaminas.Items.Count;inloop++)
							{
								int Olla=Convert.ToInt32(((Label)lstLaminas.Items[inloop].FindControl("lblVaso")).Text.ToString());
								int Laminas=Convert.ToInt32(((Label)lstLaminas.Items[inloop].FindControl("lblLaminas")).Text.ToString());
								DataGrid dgdAditivos = ((DataGrid)lstLaminas.Items[inloop].FindControl("dgdAditivos"));
								SICALNet.Utilities.Validation pdvlt = new SICALNet.Utilities.Validation();
								for(int iinloop=0;iinloop<dgdAditivos.Items.Count;iinloop++)
								{
									string Codigo=((Label) dgdAditivos.Items[iinloop].FindControl("AditivosCodigoSAP")).Text.ToString();
									decimal Cantidad=Convert.ToDecimal(((Label) dgdAditivos.Items[iinloop].FindControl("AditivosCantidad")).Text.ToString());
									if(!pdvlt.IsNumber(((TextBox) dgdAditivos.Items[iinloop].FindControl("txtCantidadReal")).Text.ToString()))
										throw new Exception(" The Cantidad Real Should be Number");
									decimal CantidadReal=Convert.ToDecimal(((TextBox) dgdAditivos.Items[iinloop].FindControl("txtCantidadReal")).Text.ToString());
									string folio=((TextBox) dgdAditivos.Items[iinloop].FindControl("txtFolio")).Text;									
									string capacidadOlla= ((Label) dgdAditivos.Items[iinloop].FindControl("lblCapacidadOlla")).Text;
									float capolla=0;
									if (capacidadOlla!=string.Empty)
									{
										capolla = Convert.ToSingle(capacidadOlla.ToString());
									}
									SICALNet.BusinessEntities.PartidasAditivosInfo  BEparti=new SICALNet.BusinessEntities.PartidasAditivosInfo(
										secuencia,IdArea,Codigo,Olla,Laminas,Cantidad,CantidadReal,Fecha.ToString("dd/MMM/yyyy"),folio,capolla,0);
									aryClrRm.Add(BEparti);
								}
							}

							SICALNet.BusinessLogicLayer.PartidasAditivos PAd = new SICALNet.BusinessLogicLayer.PartidasAditivos();
							PAd.Delete(secuencia);
							PAd.Insert(aryClrRm);
							aryClrRm.Clear();


							//Update Login Form

							//HRV codigo comentado 26-Enero-2005
							//SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(secuencia,Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]),this.Context.User.Identity.Name);
							//SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
							//BLOrdenes.UpdateLoginForm(OTInfo);
							// fin código comentado

							//Release Functionality 
							//Verifica si la secuencia es combinada
							SICALNet.BusinessEntities.SecuenciaCombinasInfo scInfoAux= new SICALNet.BusinessEntities.SecuenciaCombinasInfo(secuencia,0);
							SICALNet.BusinessLogicLayer.SecuenciaCombinas blSCAux = new SICALNet.BusinessLogicLayer.SecuenciaCombinas();
							IList CombinasListAux=blSCAux.SelectSecuenciaCombinas(scInfoAux);

							
							if(CombinasListAux.Count==0 )
							{
								SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo1 = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(secuencia,2,Convert.ToInt32(ConfigurationManager.AppSettings["ColorRoomId"]),Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]),Convert.ToInt32(ConfigurationManager.AppSettings["PVCRoomId"]),Convert.ToInt32(ConfigurationManager.AppSettings["MixturesRoomId"]),5,DateTime.Now.Date.ToString("dd-MMM-yyyy"),Context.User.Identity.Name);
								SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes1 = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
								BLOrdenes1.AdditivesUpdate(OTInfo1);
							}
							else
							{	/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
								System.Text.StringBuilder secuencia_combinada = new System.Text.StringBuilder();
//								string secuencia_combinada=string.Empty;
								
								for(int i=0;i<CombinasListAux.Count;i++)
								{
									SICALNet.BusinessEntities.SecuenciaCombinasInfo scInfo=(SICALNet.BusinessEntities.SecuenciaCombinasInfo)CombinasListAux[i];
									secuencia_combinada.Append(scInfo.Secuencia).Append(",");
//									secuencia_combinada += scInfo.Secuencia +",";
								}
								SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo1 = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(secuencia_combinada.ToString(),2,Convert.ToInt32(ConfigurationManager.AppSettings["ColorRoomId"]),Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]),Convert.ToInt32(ConfigurationManager.AppSettings["PVCRoomId"]),Convert.ToInt32(ConfigurationManager.AppSettings["MixturesRoomId"]),5,DateTime.Now.Date.ToString("dd-MMM-yyyy"),Context.User.Identity.Name);
								
								/*** fin modificación ***/
								SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes1 = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
								BLOrdenes1.AdditivesUpdateCombined(OTInfo1);
							}

							Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"La Orden de Trabajo " + secuencia + " se libero exitosamente"+"')" + "<" + "/script>");
							
						}
				
					}
				}
				else
					throw new Exception(" La(s) Ordenes de trabajo "+ Secuencias + " no han sido formulada(s)");
				LoadWorkOrders(txtFecha.Text.Trim(),txtFechaFinal.Text.Trim());

			}
			catch
			{
//				string sErrMsg;
//				sErrMsg=ErrHand.Message.Replace("'","-");
//				string ScriptString="<script language='javascript'>alert('"+ sErrMsg +"');</script>"; 
//				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);

				throw;
			}
		
		}

		private void btnRpt_Click(object sender, System.EventArgs e)
		{
			// Limpieza de cache
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetNoStore();
			Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
			Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
			Response.Cache.SetValidUntilExpires(false);

			try
			{
				int i=0;
				string[] secuencia=new string[lstWorkOrder.Items.Count];
				for(int iloop=0;iloop<lstWorkOrder.Items.Count;iloop++)
				{
					if(((CheckBox)lstWorkOrder.Items[iloop].FindControl("chkSelect")).Checked==true)
					{
						secuencia[i]=((Label)lstWorkOrder.Items[iloop].FindControl("ItemSecuencia")).Text.ToString();	
						i++;
					}
				}
				if(i==0)
				{
					MostrarAlerta("Seleccione alguna(s) secuencia(s) para generar el reporte");
				
					return;
				}
				/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
				System.Text.StringBuilder SecuenciaStr = new System.Text.StringBuilder();
//				string SecuenciaStr="";
				for(int k=0;k<i;k++)
				{
					SecuenciaStr.Append("{ProgramaProduccion.Secuencia}= '").Append(secuencia[k]).Append("'");
//					SecuenciaStr+="{ProgramaProduccion.Secuencia}= '"+secuencia[k]+"'";
					if(k!=(i-1))
					{
						SecuenciaStr.Append(" OR ");
//						SecuenciaStr+=" OR ";
					}
				}
				//Response.Redirect("AditivosWORpt.aspx?FechaIni="+txtFecha.Text+"&FechaFin="+txtFechaFinal.Text+"&Linea="+cboLinea.SelectedItem.Value+"&Status="+cboStatus.SelectedItem.Value+"&Secuencias="+SecuenciaStr);

				if(chkSeparate.Checked)
				{
					/*** modificado por alejandro.hernandez@nasoft.com 28/02/2006 ***/
					PrepareReportSeparate(txtFecha.Text,txtFechaFinal.Text,SecuenciaStr.ToString());
//					PrepareReportSeparate(txtFecha.Text,txtFechaFinal.Text,Convert.ToInt32(cboLinea.SelectedItem.Value),Convert.ToInt32(cboStatus.SelectedItem.Value),SecuenciaStr.ToString());
					/*** fin modificación ***/
				}
				else
					PrepareReport(txtFecha.Text,txtFechaFinal.Text,SecuenciaStr.ToString());
				/*** fin modificación ***/
			}
			catch
			{
				throw;
			}
			
		}
		public void CheckAll(object sender, System.EventArgs e)
		{
			CheckBox Chk = (CheckBox)sender;
			if(Chk.Checked)
			{
				for(int iloop=0;iloop<lstWorkOrder.Items.Count;iloop++)
				{
					((CheckBox)lstWorkOrder.Items[iloop].FindControl("chkSelect")).Checked=true;
				}
			}
			else
			{
				for(int iloop=0;iloop<lstWorkOrder.Items.Count;iloop++)
				{
					((CheckBox)lstWorkOrder.Items[iloop].FindControl("chkSelect")).Checked=false;
				}

			}
		}
//		private void btnFormular_Click(object sender, System.EventArgs e)
//		{
//			try
//			{
//				int i=0;
//				string Desc="";
//				string[] secuencia=new string[lstWorkOrder.Items.Count];
//				string[] CodigoSAP=new string[lstWorkOrder.Items.Count]; 
//				string[] Status= new string[lstWorkOrder.Items.Count];
//				int[] Cantidad= new int[lstWorkOrder.Items.Count];
//				string[] IdLinea= new string[lstWorkOrder.Items.Count];
//				string IdPlanta="1";
//				int itemidx=0;
//				for(int iloop=0;iloop<lstWorkOrder.Items.Count;iloop++)
//				{
//					if(((CheckBox)lstWorkOrder.Items[iloop].FindControl("chkSelect")).Checked==true)
//					{
//						itemidx=iloop+1;
//						secuencia[i]=((Label)lstWorkOrder.Items[iloop].FindControl("ItemSecuencia")).Text.ToString();	
//						CodigoSAP[i]=((Label)lstWorkOrder.Items[iloop].FindControl("ItemCodigoSAP")).Text.ToString();
//						Status[i]=((Label)lstWorkOrder.Items[iloop].FindControl("ItemIdStatus")).Text.ToString();
//						Cantidad[i]=Convert.ToInt32(((Label)lstWorkOrder.Items[iloop].FindControl("ItemCantidad")).Text.ToString());
//						IdLinea[i]=((Label)lstWorkOrder.Items[iloop].FindControl("ItemIdLinea")).Text.ToString();
//						IdPlanta=((Label)lstWorkOrder.Items[iloop].FindControl("ItemIdPlanta")).Text.ToString();
//						Desc=((Label)lstWorkOrder.Items[iloop].FindControl("ItemDescripcion")).Text.ToString();
//						if(itemidx==0)
//						{
//							if(((Label)lstWorkOrder.Items[iloop+1].FindControl("ItemIdStatus")).Text.ToString()=="2")
//								itemidx=iloop+1;
//						}
//						if(i!=0)
//						{
//							if(CodigoSAP[i-1]!=CodigoSAP[i])
//							{
//								throw new Exception("The Material Codes for selected Secuencias are not same");
//							}
//							else if(Status[i-1]!=Status[i])
//							{
//								throw new Exception("The Status of selected Secuencias are not same");
//							}
//						}
//					i++;
//					}
//					
//				}
//				switch(i)
//				{
//					case 1:
//					{
//						throw new Exception("For Consuting one Secuencia Please use Consultar Link.");
//						break;
//					}
//					case 0:
//					{
//						throw new Exception("No Secuencias are selected");
//						break;
//
//					}
//				}
//
//				//session variable is used for rest of the forms in wizards
//				Session[this.Context.User.Identity.Name+"Secuencia"]=secuencia;
//				Session[this.Context.User.Identity.Name+"Cantidad"]=Cantidad;
//				Session[this.Context.User.Identity.Name+"IdLinea"]=IdLinea[0];
//				Session[this.Context.User.Identity.Name+"cmbIdLinea"]=cboLinea.SelectedItem.Value.ToString();
//				Session[this.Context.User.Identity.Name+"cmbIdStatus"]=cboStatus.SelectedItem.Value.ToString();
//				Session[this.Context.User.Identity.Name+"CodigoSAP"]=CodigoSAP[0];
//				Session[this.Context.User.Identity.Name+"IdPlanta"]=IdPlanta;
//				Session[this.Context.User.Identity.Name+"IdStatus"]=Status[0];
//				Session[this.Context.User.Identity.Name+"FormularFlag"]=i.ToString();
//				Session[this.Context.User.Identity.Name+"ItemIndex"]=itemidx;
//				SICALNet.BusinessEntities.SecuenciaCombinasInfo scInfo = new SICALNet.BusinessEntities.SecuenciaCombinasInfo(secuencia[0],0);
//				SICALNet.BusinessLogicLayer.SecuenciaCombinas blSC = new SICALNet.BusinessLogicLayer.SecuenciaCombinas();
//				IList CombinasList=blSC.SelectSecuenciaCombinas(scInfo);
//				bool reflag=false;
//				if(CombinasList.Count>0)
//				{
//					if(CombinasList.Count!=i)
//					{
//						reflag=true;
//					
//					}
//					else
//					{
//						for(int iloop=0;iloop<CombinasList.Count;iloop++)
//						{				
//							scInfo=(SICALNet.BusinessEntities.SecuenciaCombinasInfo)CombinasList[iloop];		
//							if(secuencia[iloop]!=scInfo.Secuencia)
//								reflag=true;					
//						}
//					}
//				}
//				//Response.Redirect("AditivosCuantos.aspx");
//				if(reflag==false)
//				Response.Redirect("AditivosCuantos.aspx?Secuencia="+secuencia+"&Cantidad="+Cantidad+"&IdLinea="+IdLinea+"&Status="+Status+"&ReFlag="+reflag.ToString()+"&Descripcion="+Desc);
//				else
//				Response.Redirect("SecuenciasCombinadas.aspx?ReFlag="+reflag.ToString()+"&Descripcion="+Desc+"&Room=Aditivos");
//			}
//			catch(Exception errHand)
//			{
//				throw;
//
//			}
//		}
		public void ReDirect(int ItemIndex,string ShortCut)
		{
			try
			{
				string secuance=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemSecuencia")).Text.ToString();
				SICALNet.BusinessEntities.SecuenciaCombinasInfo scInfo = new SICALNet.BusinessEntities.SecuenciaCombinasInfo(secuance,0);
				SICALNet.BusinessLogicLayer.SecuenciaCombinas blSC = new SICALNet.BusinessLogicLayer.SecuenciaCombinas();
				IList CombinasList=blSC.SelectSecuenciaCombinas(scInfo);
				int itemidx=ItemIndex;
				
				if(CombinasList.Count==0)
				{
					string Cantidad=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemCantidad")).Text.ToString();
					string Status=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemIdStatus")).Text.ToString();
					string IdLinea=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemIdLinea")).Text.ToString(); 
					string Codigosap=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemCodigoSAP")).Text.ToString(); 
					string planta=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemIdPlanta")).Text.ToString(); 
					string Desc=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemDescripcion")).Text.ToString(); 
					for(int i=0;i<(lstWorkOrder.Items.Count-ItemIndex);i++)
					{
						if(itemidx!=ItemIndex)
							if(((Label)lstWorkOrder.Items[ItemIndex+i].FindControl("ItemIdStatus")).Text.ToString()=="2")
								itemidx=ItemIndex+i;
					}
					if(ItemIndex>=lstWorkOrder.Items.Count)
					{
						Response.Redirect("ConsultAditivosWO.aspx");
						throw new Exception("There are no Secuencias to Consult furthur...."); 
					}
					//session variable is used for rest of the forms in wizards
					Session[this.Context.User.Identity.Name+"Secuencia"]=secuance;
					Session[this.Context.User.Identity.Name+"Cantidad"]=Cantidad;
					Session[this.Context.User.Identity.Name+"IdLinea"]=IdLinea;
					Session[this.Context.User.Identity.Name+"cmbIdLinea"]=cboLinea.SelectedItem.Value.ToString();
					Session[this.Context.User.Identity.Name+"cmbIdStatus"]=cboStatus.SelectedItem.Value.ToString();
					Session[this.Context.User.Identity.Name+"CodigoSAP"]=Codigosap;
					Session[this.Context.User.Identity.Name+"IdPlanta"]=planta;
					Session[this.Context.User.Identity.Name+"IdStatus"]=Status;
					Session[this.Context.User.Identity.Name+"FormularFlag"]="0";
					Session[this.Context.User.Identity.Name+"ItemIndex"]=itemidx;
					if(ShortCut=="True")
					{
						SICALNet.BusinessLogicLayer.PartidasAditivos blPartidasAdi = new SICALNet.BusinessLogicLayer.PartidasAditivos();
						if(blPartidasAdi.IsExistSecuencia(secuance,Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"])))
						{
							//SICALNet.BusinessEntities.OrdenesTrabajoInfo OInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text,Convert.ToInt32(ConfigurationManager.AppSettings["ColorRoomId"]),0);
							//SICALNet.BusinessLogicLayer.OrdenesTrabajo blOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
							//int Status=blOrdenes.GetStatus(OInfo);
							//Session[this.Context.User.Identity.Name+"IdStatus"]=Status;
							int Container=(int)blPartidasAdi.GetNoContainers(secuance,Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]));
							Session[this.Context.User.Identity.Name+"NoCuanto"]=Container;
							IList NoOllaList=(IList)blPartidasAdi.LoadOlla(Session[this.Context.User.Identity.Name+"Secuencia"].ToString(),0,"Olla");
							int[] aryLaminas = new int[Container];
							float[] aryOlla = new float[Container];
							for(int i=0;i<NoOllaList.Count;i++)
							{
								SICALNet.BusinessEntities.PartidasAditivosInfo PAInfo = new SICALNet.BusinessEntities.PartidasAditivosInfo();
								PAInfo = (SICALNet.BusinessEntities.PartidasAditivosInfo)NoOllaList[i];
								aryLaminas[i]=PAInfo.NoLaminas;
								aryOlla[i]=PAInfo.CapacidadOlla;
							}
							Session[this.Context.User.Identity.Name+"VasoQty"]=aryLaminas;
							Session[this.Context.User.Identity.Name+"flag"]="1";
							Session[this.Context.User.Identity.Name+"Olla"]=aryOlla;
							Response.Redirect("AditivosCuarto.aspx?CantidadSum="+Session[this.Context.User.Identity.Name+"Cantidad"]+"&ShortCut=True");
					
						}
						else
						{
					
							int Container=1;
							Session[this.Context.User.Identity.Name+"NoCuanto"]=Container;
							int[] aryLaminas = new int[Container];
							float[] aryOlla = new float[Container];
							aryLaminas[0]=Convert.ToInt32(Cantidad);
							aryOlla[0]=Convert.ToSingle(CmbOlla.SelectedItem.Text);
							Session[this.Context.User.Identity.Name+"VasoQty"]=aryLaminas;
							Session[this.Context.User.Identity.Name+"flag"]="0";
							Session[this.Context.User.Identity.Name+"Olla"]=aryOlla;

							SICALNet.BusinessLogicLayer.PartidasAditivos blPartidas = new SICALNet.BusinessLogicLayer.PartidasAditivos();
							/*** modificado por alejandro.hernandez@nasoft.com 28/02/2006 ***/
							blPartidas.CheckOlla(Codigosap,aryLaminas[0],aryOlla[0],10,Convert.ToInt32(planta));
//							blPartidas.CheckOlla(Codigosap,aryLaminas[0],1,aryOlla[0],10,Convert.ToInt32(planta));
							/*** fin modificación ***/

							Response.Redirect("AditivosCuarto.aspx?CantidadSum="+Cantidad+"&ShortCut=True");									
						}
						
					}
					else
					//Response.Redirect("AditivosCuantos.aspx");
						Response.Redirect("AditivosCuantos.aspx?Secuencia="+secuance+"&Cantidad="+Cantidad+"&IdLinea="+IdLinea+"&Status="+Status+"&Descripcion="+Desc);
				}
				else
				{
					string Status=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemIdStatus")).Text.ToString();
					string Codigosap=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemCodigoSAP")).Text.ToString(); 
					string planta=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemIdPlanta")).Text.ToString(); 
					string Desc=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemDescripcion")).Text.ToString(); 
					for(int i=0;i<(lstWorkOrder.Items.Count-ItemIndex);i++)
					{
						if(itemidx!=ItemIndex)
							if(((Label)lstWorkOrder.Items[ItemIndex+i].FindControl("ItemIdStatus")).Text.ToString()=="2")
								itemidx=ItemIndex+i;
					}
					if(ItemIndex>=lstWorkOrder.Items.Count)
					{
						Response.Redirect("ConsultAditivosWO.aspx");
						throw new Exception("There are no active Secuencias to Consult furthur...."); 
					}
					string[] secuencia = new string[CombinasList.Count];
					int[] Cantidad = new int[CombinasList.Count];
					int[] Linea = new int[CombinasList.Count];
					string[] Fecha = new string[CombinasList.Count];
					for(int iloop=0;iloop<CombinasList.Count;iloop++)
					{				
						//SICALNet.BusinessEntities.SecuenciaCombinasInfo scInfo = new SICALNet.BusinessEntities.SecuenciaCombinasInfo();
						scInfo=(SICALNet.BusinessEntities.SecuenciaCombinasInfo)CombinasList[iloop];		
						secuencia[iloop]=scInfo.Secuencia;
						Cantidad[iloop]=Convert.ToInt32(scInfo.Cantidad);
						Linea[iloop]=scInfo.Linea;
						Fecha[iloop]=scInfo.Fecha;
					}
					//session variable is used for rest of the forms in wizards
					Session[this.Context.User.Identity.Name+"Secuencia"]=secuencia;
					Session[this.Context.User.Identity.Name+"Cantidad"]=Cantidad;
					Session[this.Context.User.Identity.Name+"IdLinea"]=Linea[0];
					Session[this.Context.User.Identity.Name+"cmbIdLinea"]=cboLinea.SelectedItem.Value.ToString();
					Session[this.Context.User.Identity.Name+"cmbIdStatus"]=cboStatus.SelectedItem.Value.ToString();
					Session[this.Context.User.Identity.Name+"CodigoSAP"]=Codigosap;
					Session[this.Context.User.Identity.Name+"IdPlanta"]=planta;
					Session[this.Context.User.Identity.Name+"IdStatus"]=Status;
					Session[this.Context.User.Identity.Name+"FormularFlag"]=CombinasList.Count;
					Session[this.Context.User.Identity.Name+"ItemIndex"]=itemidx;
					if(ShortCut=="True")
					{
						SICALNet.BusinessLogicLayer.PartidasAditivos blPartidasAdi = new SICALNet.BusinessLogicLayer.PartidasAditivos();
						string[] Secuencia = (string[])Session[this.Context.User.Identity.Name+"Secuencia"]; 
						//SICALNet.BusinessEntities.OrdenesTrabajoInfo OInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(Secuencia[0],Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]),0);
						//SICALNet.BusinessLogicLayer.OrdenesTrabajo blOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						//int Status=blOrdenes.GetStatus(OInfo);
						//Session[this.Context.User.Identity.Name+"IdStatus"]=Status;
						if(blPartidasAdi.IsExistSecuencia(Secuencia[0],Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"])))
						{
					
							int Container=(int)blPartidasAdi.GetNoContainers(Secuencia[0],Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]));
							Session[this.Context.User.Identity.Name+"NoCuanto"]=Container;
							string sec="'";
							int CantidadSum=0;
							for(int i=0;i<Secuencia.Length;i++)
								CantidadSum+=Cantidad[i];
							//int CantidadSum=Convert.ToInt32(txtCantidad.Text);
							for(int i=0;i<Secuencia.Length;i++)
							{
					
								sec+=Secuencia[i];
								if(i==((Secuencia.Length)-1))
									sec+="'";
								else
									sec+="','";
							}
							IList NoOllaList=(IList)blPartidasAdi.LoadOllaCombined(sec);
							int[] aryLaminas = new int[Container];
							float[] aryOlla = new float[Container];
							for(int i=0;i<NoOllaList.Count;i++)
							{
								SICALNet.BusinessEntities.PartidasAditivosInfo PAInfo = new SICALNet.BusinessEntities.PartidasAditivosInfo();
								PAInfo = (SICALNet.BusinessEntities.PartidasAditivosInfo)NoOllaList[i];
								aryLaminas[i]=PAInfo.NoLaminas;
								aryOlla[i]=PAInfo.CapacidadOlla;
							}
							Session[this.Context.User.Identity.Name+"VasoQty"]=aryLaminas;
							Session[this.Context.User.Identity.Name+"flag"]="1";
							Session[this.Context.User.Identity.Name+"Olla"]=aryOlla;
							Response.Redirect("AditivosCuarto.aspx?CantidadSum="+CantidadSum+"&ShortCut=True");
						}
						else
						{
					
							int Container=1;
							Session[this.Context.User.Identity.Name+"NoCuanto"]=Container;
							int[] aryLaminas = new int[Container];
							float[] aryOlla = new float[Container];
							int CantidadSum=0;
							for(int i=0;i<secuencia.Length;i++)
								CantidadSum+=Cantidad[i];
							aryLaminas[0]=CantidadSum;
							aryOlla[0]=Convert.ToSingle(CmbOlla.SelectedItem.Text);
							Session[this.Context.User.Identity.Name+"VasoQty"]=aryLaminas;
							Session[this.Context.User.Identity.Name+"flag"]="0";
							Session[this.Context.User.Identity.Name+"Olla"]=aryOlla;
							SICALNet.BusinessLogicLayer.PartidasAditivos blPartidas = new SICALNet.BusinessLogicLayer.PartidasAditivos();
							/*** modificado por alejandro.hernandez@nasoft.com 28/02/2006 ***/
							blPartidas.CheckOlla(Codigosap,aryLaminas[0],aryOlla[0],10,Convert.ToInt32(planta));
							//blPartidas.CheckOlla(Codigosap,aryLaminas[0],1,aryOlla[0],10,Convert.ToInt32(planta));
							/*** fin modificación ***/
							Response.Redirect("AditivosCuarto.aspx?CantidadSum="+CantidadSum+"&ShortCut=True");									
						}
						
					}
					else
					Response.Redirect("AditivosCuantos.aspx?Secuencia="+secuance+"&Cantidad="+Cantidad+"&IdLinea="+Linea+"&Status="+Status+"&Descripcion="+Desc+"&ReFlag=False");
				}
			}
			catch
			{
				throw;

			}


		}
		private void LoadChildGrid(string secuencia, int Status)
		{
			int i=-1;

			for(int j=0;j<lstWorkOrder.Items.Count;j++)
			{
				string currentSecuencia=((Label)lstWorkOrder.Items[j].FindControl("ItemSecuencia")).Text.ToString();
				if (currentSecuencia.Equals(secuencia))
				{
					i=j;
					continue;				
				}
			}

			if (i.Equals(-1))
				return;

			//SICALNet.BusinessLogicLayer.PartidasAditivos blPartidasAdi = new SICALNet.BusinessLogicLayer.PartidasAditivos();
			SICALNet.BusinessLogicLayer.PartidasAditivos blPAdt= new SICALNet.BusinessLogicLayer.PartidasAditivos();
			IList NoOllaList=(IList)blPAdt.LoadOlla(secuencia,0,"Laminas");
			DataList lstLaminas=((DataList)lstWorkOrder.Items[i].FindControl("dstLaminas"));
			((ImageButton) lstWorkOrder.Items[i].FindControl("aspPlus")).Visible=false; 
			((System.Web.UI.WebControls.Image) lstWorkOrder.Items[i].FindControl("jsPlus")).Visible=true; 

			lstLaminas.DataSource=NoOllaList;
			lstLaminas.DataBind();
			lstLaminas.Visible=lstLaminas.Items.Count>0;

			for(int inloop=0;inloop<NoOllaList.Count;inloop++)
			{
				SICALNet.BusinessEntities.PartidasAditivosInfo bePAdd = new SICALNet.BusinessEntities.PartidasAditivosInfo();
				bePAdd=(SICALNet.BusinessEntities.PartidasAditivosInfo)NoOllaList[inloop];
				SICALNet.BusinessLogicLayer.PartidasAditivos blPAdd=new SICALNet.BusinessLogicLayer.PartidasAditivos();
				IList OllaList=blPAdd.Select(secuencia,Convert.ToInt32(ConfigurationManager.AppSettings["AditivosRoomId"]),bePAdd.NumeroOlla);
				DataGrid dgdAditivos = ((DataGrid)lstLaminas.Items[inloop].FindControl("dgdAditivos"));
				dgdAditivos.DataSource=OllaList;
				dgdAditivos.DataBind();
				if(Status==5)
				{
					dgdAditivos.Columns[4].Visible=true;
					dgdAditivos.Columns[6].Visible=true;
					dgdAditivos.Columns[3].Visible=false;
					dgdAditivos.Columns[5].Visible=false;
				}
					
			}
		}

		
		private void btnImprimirEqu_Click(object sender, System.EventArgs e)
		{
			// Limpieza de cache
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetNoStore();
			Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
			Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
			Response.Cache.SetValidUntilExpires(false);

			SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
			SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
			theUser  = BLLUser.Load(theUser);

			//Planta OCO
			if (theUser.IdPlanta.Equals(1))
			{
				printRegularStickers();
			}
			else
			{
				printNewStickers();
			}
		}

		
		private void printNewStickers()
		{
			try
			{
				int i=0;
				string[] secuencia=new string[lstWorkOrder.Items.Count];
				for(int iloop=0;iloop<lstWorkOrder.Items.Count;iloop++)
				{
					if(((CheckBox)lstWorkOrder.Items[iloop].FindControl("chkSelect")).Checked==true)
					{
						secuencia[i]=((Label)lstWorkOrder.Items[iloop].FindControl("ItemSecuencia")).Text.ToString();	
						i++;
					}
				}
				if(i==0)
				{
					// throw new Exception(" Select Secuencias to generate report");

					Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
						"alert('"+"Seleccione alguna(s) secuencia(s) para generar las etiquetas"+"');</script>");

					return;
				}
				// secuencias normales de aditivos
				/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
				System.Text.StringBuilder SecuenciaStr = new System.Text.StringBuilder();
//				string SecuenciaStr=string.Empty;
				for(int k=0;k<i;k++)
				{			
					SecuenciaStr.Append("{vw_Tarjeta_Formulacion_Aditivos.Secuencia} = '").Append(secuencia[k]).Append("'");
//					SecuenciaStr+="{vw_Tarjeta_Formulacion_Aditivos.Secuencia} = '"+secuencia[k]+"'";
						
					if(k!=(i-1))
					{
						SecuenciaStr.Append(" OR ");
//						SecuenciaStr+=" OR ";
					}
				}

				PrepareNewStickerReport(SecuenciaStr.ToString(),TipoEtiqueta.StickerAditivog);

				// secuencias combinadas de aditivos

				// se arma la cadena del select que se mandar al sp para devolver los
				// numeros de GrupoCombinado
				System.Text.StringBuilder SecuenciaspStr = new System.Text.StringBuilder();
//				string SecuenciaspStr=string.Empty;
				for(int k=0;k<i;k++)
				{					
					SecuenciaspStr.Append("secuencia = '").Append(secuencia[k]).Append("'");
//					SecuenciaspStr+="secuencia = '"+secuencia[k]+"'";
										
					if(k!=(i-1))
					{
						SecuenciaspStr.Append(" OR ");
//						SecuenciaspStr+=" OR ";
					}
				}

				// ejecutamos el sp y el resultado lo guardamos en un datatable
				SICALNet.BusinessLogicLayer.SecuenciaCombinas blSC = new SICALNet.BusinessLogicLayer.SecuenciaCombinas();
				IList grupos;				
				grupos= blSC.GetGrupoCombinado(SecuenciaspStr.ToString());
				
				// armamos la cadena donde se le pegaran la cagena de los gruposcombinados
				SecuenciaStr=new System.Text.StringBuilder();
//				SecuenciaStr=string.Empty;
				int fin;
				fin = grupos.Count;
				for(int k=0;k<fin;k++)
				{		
					SecuenciaStr.Append("{vw_Tarjeta_Formulacion_Aditivos_Comb.GrupoCombinado} = ").Append(grupos[k]);
//					SecuenciaStr+="{vw_Tarjeta_Formulacion_Aditivos_Comb.GrupoCombinado} = "+grupos[k];
										
					if(k!=(fin-1))
					{
						SecuenciaStr.Append(" OR ");
//						SecuenciaStr+=" OR ";
					}
				}
				if (SecuenciaStr.ToString() != "")
					PrepareNewStickerReport(SecuenciaStr.ToString(),TipoEtiqueta.StickerAditivo);


////////				SecuenciaStr = new System.Text.StringBuilder();
//////////				SecuenciaStr=string.Empty;
////////				for(int k=0;k<i;k++)
////////				{					
////////					SecuenciaStr.Append("{vw_Tarjeta_Formulacion_Color.Secuencia} = '").Append(secuencia[k]).Append("'");
//////////					SecuenciaStr+="{vw_Tarjeta_Formulacion_Color.Secuencia} = '"+secuencia[k]+"'";
////////						
////////					if(k!=(i-1))
////////					{
////////						SecuenciaStr.Append(" OR ");
//////////						SecuenciaStr+=" OR ";
////////					}
////////				}
////////
////////				PrepareNewStickerReport(SecuenciaStr.ToString(),TipoEtiqueta.StickerColor);
			}
			catch
			{
				throw;
			}
		}

		
		private void printNewStickersSLPColor()
		{
			// Limpieza de cache
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetNoStore();
			Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
			Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
			Response.Cache.SetValidUntilExpires(false);

			try
			{
				int i=0;
				string[] secuencia=new string[lstWorkOrder.Items.Count];
				for(int iloop=0;iloop<lstWorkOrder.Items.Count;iloop++)
				{
					if(((CheckBox)lstWorkOrder.Items[iloop].FindControl("chkSelect")).Checked==true)
					{
						secuencia[i]=((Label)lstWorkOrder.Items[iloop].FindControl("ItemSecuencia")).Text.ToString();	
						i++;
					}
				}
				if(i==0)
				{
					// throw new Exception(" Select Secuencias to generate report");

					Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
						"alert('"+"Seleccione alguna(s) secuencia(s) para generar las etiquetas"+"');</script>");

					return;
				}

				System.Text.StringBuilder SecuenciaStr = new System.Text.StringBuilder();

				SecuenciaStr = new System.Text.StringBuilder();
				//				SecuenciaStr=string.Empty;
				for(int k=0;k<i;k++)
				{					
					SecuenciaStr.Append("{vw_Tarjeta_Formulacion_Color.Secuencia} = '").Append(secuencia[k]).Append("'");
					//					SecuenciaStr+="{vw_Tarjeta_Formulacion_Color.Secuencia} = '"+secuencia[k]+"'";
						
					if(k!=(i-1))
					{
						SecuenciaStr.Append(" OR ");
						//						SecuenciaStr+=" OR ";
					}
				}

				PrepareNewStickerReport(SecuenciaStr.ToString(),TipoEtiqueta.StickerColor);
			}
			catch
			{
				throw;
			}
		}

		
		private void PrepareNewStickerReport(string secuencias, TipoEtiqueta tipoEtiqueta)
		{
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			CrystalDecisions.CrystalReports.Engine.ReportClass objReporte=null;
			switch(tipoEtiqueta)
			{
				case TipoEtiqueta.StickerColor:
					objReporte = new Reports.Produccion.StickerColor();
					break;
				case TipoEtiqueta.StickerAditivo:
					objReporte = new Reports.Produccion.StickerAditivosdetailsSLP();
					break;
				case TipoEtiqueta.StickerAditivog:										
					objReporte = new Reports.Produccion.StickerAditivosrelg();					
					break;
			}
			//ParameterFields crParams = new ParameterFields();

			ParameterValues rptParams= new ParameterValues();
			ParameterDiscreteValue userParam= new ParameterDiscreteValue();
			// ParameterDiscreteValue PlantaParam= new ParameterDiscreteValue();
			ParameterDiscreteValue ReimpresionParam= new ParameterDiscreteValue();

			//se obtiene el nombre del usuario autenticado
			SICALNet.BusinessEntities.UsuarioInfo objUsuarioInfo = new SICALNet.BusinessEntities.UsuarioInfo(User.Identity.Name);
			SICALNet.BusinessLogicLayer.Usuario objUsuario = new SICALNet.BusinessLogicLayer.Usuario();
			SICALNet.BusinessEntities.UsuarioInfo objUser = objUsuario.Load(objUsuarioInfo);
			userParam.Value = objUser.Nombre;

			//string planta=(objUser.IdPlanta==1?"OCO":"SLP");
			//PlantaParam.Value=planta;

			SICALNet.BusinessLogicLayer.OrdenesTrabajo objOrden = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
			bool reimpresion=false;
			
			string []arrSecuencias=secuencias.Split(',');
			for(int i=0;i<arrSecuencias.Length;i++)
			{
				reimpresion=(reimpresion||objOrden.FueImpresaEtiqueta(arrSecuencias[i].Replace("'",""), objUser.IdArea));
			}
			ReimpresionParam.Value=reimpresion;
	
			rptParams= new ParameterValues();
			rptParams.Add(userParam);
			objReporte.DataDefinition.ParameterFields["Usuario"].ApplyCurrentValues(rptParams);

//			rptParams= new ParameterValues();
//			rptParams.Add(PlantaParam);
//			objReporte.DataDefinition.ParameterFields["Planta"].ApplyCurrentValues(rptParams);

			rptParams= new ParameterValues();
			rptParams.Add(ReimpresionParam);
			objReporte.DataDefinition.ParameterFields["reimpresion"].ApplyCurrentValues(rptParams);

			if (tipoEtiqueta.Equals(TipoEtiqueta.StickerAditivo) | tipoEtiqueta.Equals(TipoEtiqueta.StickerAditivog))
			{
				if (tipoEtiqueta.Equals(TipoEtiqueta.StickerAditivog))
				{
					// secuencias solas
					objReporte.DataDefinition.RecordSelectionFormula="(" + secuencias + ") AND (isnull({vw_Tarjeta_Formulacion_Aditivos.EtiquetaColor}) OR {vw_Tarjeta_Formulacion_Aditivos.EtiquetaColor}=false)";				
				}
				else
				{
					//secuencias combinadas
					objReporte.DataDefinition.RecordSelectionFormula=secuencias;
					//objReporte.DataDefinition.RecordSelectionFormula="(" + secuencias + ") AND (isnull({vw_Tarjeta_Formulacion_Aditivos_Comb.EtiquetaColor}) OR {vw_Tarjeta_Formulacion_Aditivos_Comb.EtiquetaColor}=false)";				
				}
			}
			else
			{
				objReporte.DataDefinition.RecordSelectionFormula="(" + secuencias + ")";
			}
		
			rptHelper.setPermission(objReporte);
			string reportname = rptHelper.exportReport(objReporte, tipoEtiqueta.ToString(), User.Identity.Name);
			string redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportname + ".pdf";
			string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','"+tipoEtiqueta.ToString()+"', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>"; 
			Page.RegisterClientScriptBlock("ClientScript_"+tipoEtiqueta.ToString(),ScriptString);
			//se evaluar el estatus de impresión
			//this.CheckPrintStatus(tipoEtiqueta);
		
		}

		
		private void printRegularStickers()
		{
			try
			{
				int i=0;
				string[] secuencia=new string[lstWorkOrder.Items.Count];
				for(int iloop=0;iloop<lstWorkOrder.Items.Count;iloop++)
				{
					if(((CheckBox)lstWorkOrder.Items[iloop].FindControl("chkSelect")).Checked==true)
					{
						secuencia[i]=((Label)lstWorkOrder.Items[iloop].FindControl("ItemSecuencia")).Text.ToString();	
						i++;
					}
				}
				if(i==0)
				{					
					MostrarAlerta("Seleccione alguna(s) secuencia(s) para generar el reporte");

					return;
				}
				/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
				System.Text.StringBuilder SecuenciaStr = new System.Text.StringBuilder();
//				string SecuenciaStr="";
				for(int k=0;k<i;k++)
				{
					SecuenciaStr.Append("{OrdenesTrabajo.Secuencia}= '").Append(secuencia[k]).Append("'");
//					SecuenciaStr+="{OrdenesTrabajo.Secuencia}= '"+secuencia[k]+"'";
					if(k!=(i-1))
					{
						SecuenciaStr.Append(" OR ");
//						SecuenciaStr+=" OR ";
					}
				}
				//Response.Redirect("..\\..\\Forms\\Reports\\FrmStickerAdditoves.aspx?Secuencia="+SecuenciaStr);
				PrepareStickerReport(txtFecha.Text,txtFechaFinal.Text,Convert.ToInt32(cboLinea.SelectedItem.Value),Convert.ToInt32(cboStatus.SelectedItem.Value),SecuenciaStr.ToString());
			}
			catch
			{
				throw;
			}
		}

		private void lstWorkOrder_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Label lblFechaMod = (Label)e.Item.FindControl("ItemFechaMod");
				if (lblFechaMod.Text != "")
				{
					e.Item.BackColor = Color.Yellow;
					DateTime timeAux = Convert.ToDateTime(lblFechaMod.Text); 
					if (timeAux.ToString("dd/MMM/yy")   == DateTime.MinValue.ToString("dd/MMM/yy")) 
						e.Item.BackColor = Color.LightBlue;   
				}
				Label lblStatus = (Label)e.Item.FindControl("ItemIdStatus");
				if (lblStatus.Text == ConfigurationManager.AppSettings["StatusCancel"]) 
					e.Item.BackColor = Color.Tomato;
			}
		}
		/*** modificado por alejandro.hernandez@nasoft.com 28/02/2006 ***/
		private void PrepareReport(string fechaInicial, string fechaFinal, string secuencias)
//		private void PrepareReport(string fechaInicial, string fechaFinal, int linea,int status, string secuencias)
		/*** fin modificación ***/
		{
			try
			{
				Reports.ReportHelper rptHelper = new Reports.ReportHelper();
				Production.AditivosWORpt reporte = new Production.AditivosWORpt();

				
				ParameterValues campoFecha= new ParameterValues();
				ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
				valorFecha.Value=string.Format("{0} al {1}",fechaInicial,fechaFinal);
				campoFecha.Add(valorFecha);
				
				reporte.DataDefinition.ParameterFields["Fecha"].ApplyCurrentValues(campoFecha);
				

				string	SelectionStr="";
				
				SelectionStr+=secuencias + " AND {OrdenesTrabajo.IdArea}=2";

				reporte.DataDefinition.RecordSelectionFormula=SelectionStr;
			
				rptHelper.setPermission(reporte);
				string reportName = rptHelper.exportReport(reporte,"FormulacionAditivos",User.Identity.Name);

				string redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
				//Response.Redirect(redirectPath);
				string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','Reporte', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>"; 
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);

			}
			catch
			{
				throw;
			}

		}

		/*** modificado por alejandro.hernandez@nasoft.com 01/03/2006 ***/
		private void PrepareReportSeparate(string fechaInicial, string fechaFinal, string secuencias)
//		private void PrepareReportSeparate(string fechaInicial, string fechaFinal, int linea,int status, string secuencias)
		/*** fin modificación ***/
		{
			try
			{
				Reports.ReportHelper rptHelper = new Reports.ReportHelper();
				Production.AditivosWORptBySequence reporte = new Production.AditivosWORptBySequence();

				ParameterValues campoFecha= new ParameterValues();
				ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
				valorFecha.Value=string.Format("{0} al {1}",fechaInicial,fechaFinal);
				campoFecha.Add(valorFecha);
				
				reporte.DataDefinition.ParameterFields["Fecha"].ApplyCurrentValues(campoFecha);

				string	SelectionStr="";
				
				SelectionStr+=secuencias + " AND {OrdenesTrabajo.IdArea}=2";

				reporte.DataDefinition.RecordSelectionFormula=SelectionStr;
			
				rptHelper.setPermission(reporte);
				string reportName = rptHelper.exportReport(reporte,"FormulacionAditivos",User.Identity.Name);

				string redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
				
				string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','Reporte', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>"; 
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);

			}
			catch
			{
				throw;
			}

		}

		private void PrepareStickerReport(string fechaInicial, string fechaFinal, int linea,int status, string secuencias)
		{
		
			try
			{
				UserInterface.Helpers.Funciones fn = new UserInterface.Helpers.Funciones();				

				Reports.ReportHelper rptHelper = new Reports.ReportHelper();
				Reports.PrintStickerAdditoves AdiSticker = new Reports.PrintStickerAdditoves();
				fechaInicial = fn.ConvertirFechaMesNumero(fechaInicial);
				fechaFinal = fn.ConvertirFechaMesNumero(fechaFinal);

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
				string reportName = rptHelper.exportReport(AdiSticker,"StickerAditivos",User.Identity.Name );

				string redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
				//Response.Redirect(redirectPath);
				string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','Reporte', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>";
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
		
			}
			catch
			{
				throw;
			}
		}

		private void lstWorkOrder_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void cboLinea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int idAuxPlanta=1;
			if(cboLinea.SelectedItem.Value != "0")
			{
				//Cambia el combo de ollas con las ollas de la linea	
				SICALNet.BusinessLogicLayer.LineaProduccion  blLinea =  new SICALNet.BusinessLogicLayer.LineaProduccion();						
				idAuxPlanta = blLinea.GetIdPlanta( Convert.ToInt32(this.cboLinea.SelectedItem.Value));

			}
			SICALNet.BusinessEntities.OllaInfo oInfo = new SICALNet.BusinessEntities.OllaInfo(0,idAuxPlanta,0,0);
			SICALNet.BusinessLogicLayer.Olla blOlla = new SICALNet.BusinessLogicLayer.Olla();
			IList OllaList=(IList)blOlla.SelectOlla(oInfo); 
			CmbOlla.DataSource=OllaList;
			CmbOlla.DataTextField="CapacidadMax";			
			CmbOlla.DataBind();
			CmbOlla.Items[0].Selected=true;

		}
		
		private void btnCard_Click(object sender, System.EventArgs e)
		{
			// Limpieza de cache
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetNoStore();
			Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
			Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
			Response.Cache.SetValidUntilExpires(false);

			try
			{
				int i=0;
				string[] secuencia=new string[lstWorkOrder.Items.Count];
				for(int iloop=0;iloop<lstWorkOrder.Items.Count;iloop++)
				{
					if(((CheckBox)lstWorkOrder.Items[iloop].FindControl("chkSelect")).Checked==true)
					{
						secuencia[i]=((Label)lstWorkOrder.Items[iloop].FindControl("ItemSecuencia")).Text.ToString();	
						i++;
					}
				}
				
				if(i==0)
				{					
					MostrarAlerta("Seleccione una secuencia para generar una tarjeta");
					
					return;
				}

				/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
				System.Text.StringBuilder SecuenciaStr = new System.Text.StringBuilder();
//				string SecuenciaStr = string.Empty;
								
				for(int k=0;k<i;k++)
				{
					SecuenciaStr.Append("{VistaSecuenciasSimples1.Secuencia}='").Append(secuencia[k]).Append("'");
//					SecuenciaStr+="{VistaSecuenciasSimples1.Secuencia}='"+secuencia[k]+"'";
					if(k!=(i-1))
					{
						SecuenciaStr.Append(" OR ");
//						SecuenciaStr+=" OR ";
					}
				}

				if(SecuenciaStr.Length > 0)
				{
					SecuenciaStr.Insert(0,"(").Append(")");
//					SecuenciaStr = "(" + SecuenciaStr + ")";
				}
				
				PrepareCardReport(SecuenciaStr.ToString(), int.Parse(this.cboLinea.SelectedValue));
				
			}
			catch
			{
				throw;

			}
		}

		private void PrepareCardReport(string secuencias,  int idLinea)
		{
			try
			{
				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);

				/*********************************************/
				// Procedimiento adicionado para agregar mezclas a la tarjeta de formulación
				/** JJMR Adición para agregar datos al reporte **/
				string ListaSecuencia="";
				ListaSecuencia = secuencias.Replace("{VistaSecuenciasSimples1.Secuencia}=", " ");
				ListaSecuencia = ListaSecuencia.Replace("OR", ",");
				ListaSecuencia = ListaSecuencia.Replace("(", "");
				ListaSecuencia = ListaSecuencia.Replace(")", "");
				ListaSecuencia = ListaSecuencia.Replace("'", "");

				TruncaRep_PMMA_TarjetaFormulacion(); // Trunca tabla Rep_PMMA_TarjetaFormulacion
				TruncaRep_PMMA_TarjetaFormulacion_Sludy();

				string [] split = ListaSecuencia.Split(new Char [] {','});
				foreach (string s in split) 
				{
					if (s.Trim() != "")
						InsertaPMMA(s.Trim());		// Inserta en la tabla Rep_PMMA_TarjetaFormulacion	
						ActualizaPMMA(s.Trim());	// Actualiza los campos SumaColorAditivos y Laminas en la tabla Rep_PMMA_TarjetaFormulacion
						//Proc_CalculoPmma(s.Trim());
				}
				/*********************************************/
				//Proc_ActualizaSumaColorAditivos();
				string textoReporte = string.Empty;

				//Planta OCO
				if (theUser.IdPlanta.Equals(1))
				{
					textoReporte = ConfigurationManager.AppSettings["TextoOCO"];
				}
				else
				{
					textoReporte = ConfigurationManager.AppSettings["TextoSLP"];
				}

				Reports.ReportHelper rptHelper = new Reports.ReportHelper();
				ParameterValues campoCadenaTexto= new ParameterValues();
				ParameterDiscreteValue valorCadenaTexto= new ParameterDiscreteValue();
				valorCadenaTexto.Value=string.Format("{0}", textoReporte);
				campoCadenaTexto.Add(valorCadenaTexto);

				string reportName = "";				
				
				if (idLinea==4)
				{
					Production.WorkOrder.PartidasColor.FormulationCardWORpt1 reporte = new Production.WorkOrder.PartidasColor.FormulationCardWORpt1();
					secuencias = secuencias + " AND ({VistaSecuenciasSimples1.CodigoSAP}<>'23372')";
					reporte.DataDefinition.ParameterFields["CadenaTexto"].ApplyCurrentValues(campoCadenaTexto);
					reporte.DataDefinition.RecordSelectionFormula=secuencias;
					// *************************
					reporte.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
					reporte.PrintOptions.PaperSize =  PaperSize.PaperStatement;	
					// *************************
					rptHelper.setPermission(reporte);
					reportName = rptHelper.exportReport(reporte,"TarjetaFormulacion",User.Identity.Name);
				}
				else
				{
					Production.WorkOrder.PartidasColor.FormulationCardWORpt reporte = new Production.WorkOrder.PartidasColor.FormulationCardWORpt();
					reporte.DataDefinition.ParameterFields["CadenaTexto"].ApplyCurrentValues(campoCadenaTexto);
					reporte.DataDefinition.RecordSelectionFormula=secuencias;
					rptHelper.setPermission(reporte);
					reportName = rptHelper.exportReport(reporte,"TarjetaFormulacion",User.Identity.Name);
				}

				string redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";			
				string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','Reporte', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>"; 
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);				
			}
			catch
			{
				throw;
			}
		}
		
		private void btnPreform_Click(object sender, System.EventArgs e)
		{
			// Limpieza de cache
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetNoStore();
			Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
			Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
			Response.Cache.SetValidUntilExpires(false);

			try
			{
				int i=0;
				string[] secuencia=new string[lstWorkOrder.Items.Count];
				for(int iloop=0;iloop<lstWorkOrder.Items.Count;iloop++)
				{
					if(((CheckBox)lstWorkOrder.Items[iloop].FindControl("chkSelect")).Checked==true)
					{
						secuencia[i]=((Label)lstWorkOrder.Items[iloop].FindControl("ItemSecuencia")).Text.ToString();	
						i++;
					}
				}
				
				if(i==0)
				{
					// throw new Exception(" Select Secuencias to generate report");

					Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
						"alert('Seleccione las secuencias para desea preformular');</script>");

					return;
				}
				/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
				System.Text.StringBuilder SecuenciaStr = new System.Text.StringBuilder();				
				for(int k=0;k<i;k++)
				{
					SecuenciaStr.Append("'").Append(secuencia[k]).Append("'");
					if(k!=(i-1))
					{
						SecuenciaStr.Append(",");
					}
				}


				Preformular(SecuenciaStr.ToString());
				// Registrando en bitácora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Se registra evento de Preformulación en Ordenes de Trabajo Fase Aditivos para la secuencia '" + SecuenciaStr.ToString() + "'",Page.User.Identity.Name.ToString());				
			}
			catch
			{
				throw;

			}		
		}

		private void Preformular(string sequenceString)
		{
			try
			{
				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);

				SICALNet.BusinessLogicLayer.OrdenesTrabajo oWorkOrders = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				oWorkOrders.Preformulate(sequenceString, theUser.IdPlanta);
				LoadWorkOrders(txtFecha.Text.Trim(),txtFechaFinal.Text.Trim());
			}
			catch
			{
				throw;
			}
		}
		
		private void btnDust_Click(object sender, System.EventArgs e)
		{
			// Limpieza de cache
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetNoStore();
			Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
			Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
			Response.Cache.SetValidUntilExpires(false);

			try
			{
				int i=0;
				string[] secuencia=new string[lstWorkOrder.Items.Count];
				for(int iloop=0;iloop<lstWorkOrder.Items.Count;iloop++)
				{
					if(((CheckBox)lstWorkOrder.Items[iloop].FindControl("chkSelect")).Checked==true)
					{
						secuencia[i]=((Label)lstWorkOrder.Items[iloop].FindControl("ItemSecuencia")).Text.ToString();	
						i++;
					}
				}
				
				if(i==0)
				{
					MostrarAlerta("Seleccione una secuencia para generar una tarjeta");

					return;
				}
				/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
				System.Text.StringBuilder SecuenciaStr = new System.Text.StringBuilder();
//				string SecuenciaStr = string.Empty;
								
				for(int k=0;k<i;k++)
				{
					SecuenciaStr.Append("{VistaAditivosEnPolvoSecuenciasSimples.Secuencia} = '").Append(secuencia[k]).Append("'");
//					SecuenciaStr+="{VistaAditivosEnPolvoSecuenciasSimples.Secuencia} = '"+secuencia[k]+"'";
					if(k!=(i-1))
					{
						SecuenciaStr.Append(" OR ");
//						SecuenciaStr+=" OR ";
					}
				}

				if(SecuenciaStr.Length > 0)
				{
					SecuenciaStr.Insert(0,"(").Append(")");
//					SecuenciaStr = "(" + SecuenciaStr + ")";
				}
				
				PrepareDustReport(SecuenciaStr.ToString());
				/*** fin modificación ***/
				
			}
			catch
			{
				throw;

			}		
		}

		private void PrepareDustReport(string secuencias)
		{
			try
			{
				Reports.ReportHelper rptHelper = new Reports.ReportHelper();
				
				Production.AditivosConPolvoWORpt reporte = new Production.AditivosConPolvoWORpt();

				reporte.DataDefinition.RecordSelectionFormula=secuencias;

				rptHelper.setPermission(reporte);
				string reportName = rptHelper.exportReport(reporte,"FormulacionConPolvo",User.Identity.Name);

				string redirectPath=ConfigurationManager.AppSettings["reportsWebPath"]+ reportName + ".pdf";
			
				string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','Reporte', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>"; 				
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
			}
			catch
			{
				throw;
			}
		}

		
		private void btnImprimirSLPC_Click(object sender, System.EventArgs e)
		{
				printNewStickersSLPColor();
		
		}
		/// <summary>
		/// An internal function to get the database parameters for select and delete
		/// </summary>
		/// <returns>Parameter array</returns>
		private static SqlParameter[] GetUserParaSingle() 
		{			
			SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(ConfigurationManager.AppSettings["SICALConnString"],PROC_INSERTAPMAA_TARJETAFORMULACION);
			if (parms == null) 
			{
				parms = new SqlParameter[] {
											   new SqlParameter(SECUENCIA, SqlDbType.VarChar, 10)};

				SqlHelperParameterCache.CacheParameterSet(ConfigurationManager.AppSettings["SICALConnString"],PROC_INSERTAPMAA_TARJETAFORMULACION, parms);
			}
			return parms;
		}


		public void TruncaRep_PMMA_TarjetaFormulacion()
		{	
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
			{
				conn.Open();
				using (SqlTransaction trans = conn.BeginTransaction()) 
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(trans, CommandType.Text, "TRUNCATE TABLE Rep_PMMA_TarjetaFormulacion;");
						trans.Commit();
					}
					catch 
					{
						trans.Rollback();
						throw;
					}
				}
			}
		}

		public void TruncaRep_PMMA_TarjetaFormulacion_Sludy()
		{	
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
			{
				conn.Open();
				using (SqlTransaction trans = conn.BeginTransaction()) 
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(trans, CommandType.Text, "Delete from Rep_PMMA_TarjetaFormulacion_Sludy");
						trans.Commit();
					}
					catch 
					{
						trans.Rollback();
						throw;
					}
				}
			}
		}


		public void Proc_ActualizaSumaColorAditivos()
		{		
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
			{
				conn.Open();
				using (SqlTransaction trans = conn.BeginTransaction()) 
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, PROC_ACTUALIZASUMACOMOLADITIVOS_TARJETAFORMULACION);
						trans.Commit();
					}
					catch 
					{
						trans.Rollback();
						throw;
					}
				}
			}
		}


		public void Proc_CalculoPmma(string secuencia)
		{
			SqlParameter[] UserParms = GetUserParaSingle();
			UserParms[0].Value=secuencia;			
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
			{
				conn.Open();
				using (SqlTransaction trans = conn.BeginTransaction()) 
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, PROC_CALCULOPMMA_TARJETAFORMULACION, UserParms);
						trans.Commit();
					}
					catch 
					{
						trans.Rollback();
						throw;
					}
				}
			}
		}


		public void InsertaPMMA(string secuencia)
		{
			SqlParameter[] UserParms = GetUserParaSingle();
			UserParms[0].Value=secuencia;
			
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
			{
				conn.Open();
				using (SqlTransaction trans = conn.BeginTransaction()) 
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, PROC_INSERTAPMAA_TARJETAFORMULACION, UserParms);
						trans.Commit();
					}
					catch 
					{
						trans.Rollback();
						throw;
					}
				}
			}
		}

		public void ActualizaPMMA(string secuencia)
		{
			SqlParameter[] UserParms = GetUserParaSingle();
			UserParms[0].Value=secuencia;
			
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SICALConnString"])) 
			{
				conn.Open();
				using (SqlTransaction trans = conn.BeginTransaction()) 
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, PROC_ACTUALIZAPMAA_TARJETAFORMULACION, UserParms);
						trans.Commit();
					}
					catch 
					{
						trans.Rollback();
						throw;
					}
				}
			}
		}

		private void MostrarAlerta(string mensaje)
		{
			ClientScript.RegisterStartupScript(
				this.GetType(),
				"SicalAlerta",
				"SicalAlert.mostrar('" + mensaje.Replace("\\", "\\\\").Replace("'", "\\'") + "');",
				true
			);
		}



	}
}
