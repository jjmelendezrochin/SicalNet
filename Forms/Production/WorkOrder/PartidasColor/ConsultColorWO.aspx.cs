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
using System.Threading;
using System.Globalization;
namespace UserInterface.Forms.Production.ColorRoom
{
	/// <summary>
	/// Summary description for ConsultColorWO.
	/// </summary>
	public class ConsultColorWO : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblFinal;
		protected System.Web.UI.WebControls.Label lblLinea;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.TextBox txtInitial;
		protected System.Web.UI.WebControls.TextBox txtFinal;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.DropDownList cboColor;
		protected System.Web.UI.WebControls.Image imgInitial;
		protected System.Web.UI.WebControls.Image imgFinal;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblInitial;
		protected System.Web.UI.WebControls.Button btnSel;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DataList lstWorkOrder;
		protected System.Web.UI.WebControls.Button btnAgregar;
		protected System.Web.UI.WebControls.Button btnLiberado;
		protected System.Web.UI.WebControls.Button btnRpt;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Button btnImprimirEqu;
		protected System.Web.UI.WebControls.TextBox txtAforo;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.DropDownList cboStatus;
		protected System.Web.UI.WebControls.Image ImagenPiso;
		protected System.Web.UI.WebControls.RegularExpressionValidator revInitial;
		protected System.Web.UI.WebControls.RegularExpressionValidator revAforo;
		protected System.Web.UI.WebControls.RegularExpressionValidator revFinal;
		protected System.Web.UI.WebControls.CheckBox chkSeparate;
		protected System.Web.UI.WebControls.Button btnCard;
		protected System.Web.UI.WebControls.Button btnPreform;
		private enum TipoEtiqueta { StickerColor=1, StickerAditivo, StickerAditivog };

		private const string SECUENCIA = "@SEC";
		private const string PROC_INSERTAPMAA_TARJETAFORMULACION = "Proc_InsertaPMMA_TarjetaFormulacion";
		private const string PROC_ACTUALIZAPMAA_TARJETAFORMULACION = "Proc_ActualizaPMMA_TarjetaFormulacion";
		private const string PROC_CALCULOPMMA_TARJETAFORMULACION = "Proc_CalculoPmma";
		protected System.Web.UI.WebControls.Literal ltrRefresh;
		private const string PROC_ACTUALIZASUMACOMOLADITIVOS_TARJETAFORMULACION = "Proc_ActualizColorAditivos";

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);

			if((ConfigurationSettings.AppSettings["TiempoRefreshListadoOrdenesColorAditivos"] != "0") && (ConfigurationSettings.AppSettings["TiempoRefreshListadoOrdenesColorAditivos"]!=""))
				ltrRefresh.Text = "<META http-equiv='Refresh' content='" + ConfigurationSettings.AppSettings["TiempoRefreshListadoOrdenesColorAditivos"] + "'>" ;			

			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				string InitDt, FinalDt;
				
				InitDt = (string) Session["InitialDate"];
				FinalDt = (string) Session["FinalDate"];

				String sFechaIni = System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();
				String sFechaFin = System.DateTime.Now.ToString("dd-MMM-yyyy").Replace(".", "").ToLower();

				if (InitDt == null || FinalDt ==null)
				{
					txtInitial.Text = sFechaIni.Replace(".","");
					txtFinal.Text = sFechaFin.Replace(".","");
				}
				else
				{										
					txtInitial.Text = InitDt;
					txtFinal.Text = FinalDt;					
				}

				LoadWorkOrders(txtInitial.Text,txtFinal.Text);				

				if(Request.QueryString["RedFlag"]!=null)
					ConsultNextSecuencia(Convert.ToInt32(Session[this.Context.User.Identity.Name+"ItemIndex"]),Request.QueryString["ShortCut"].ToString());
			}
		}

		private bool LoadWorkOrders(string initialDate, string finalDate) 
		{
			try
			{		

//				Session[this.Context.User.Identity.Name+"InitialDate"] = initialDate;
//				Session[this.Context.User.Identity.Name+"FinalDate"] = finalDate;

				Session["InitialDate"] = initialDate;
				Session["FinalDate"] = finalDate;
				
				Session[this.Context.User.Identity.Name+"selectedLine"] = cboLinea.SelectedItem.Value;
				Session[this.Context.User.Identity.Name+"selectedIdStatus"] = cboStatus.SelectedItem.Value;

				SICALNet.BusinessLogicLayer.OrdenesTrabajo BLLOrdTra= new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				int IdArea=Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]);
				int IdStatus=int.Parse(cboStatus.SelectedItem.Value);
				int IdLine=int.Parse(cboLinea.SelectedItem.Value);
				string IdColor=cboColor.SelectedItem.Value;
				
				string InitDt=initialDate;
				string FinalDt=finalDate;

				IList RsOrdTra= (IList)BLLOrdTra.LoadWorkOrders(IdArea,IdLine,IdStatus,IdColor,InitDt,FinalDt);

				if (RsOrdTra.Count == 0)
				{
					lstWorkOrder.DataSource = null;
					lstWorkOrder.DataBind();
					return false;
				}

				//to fill the datagrid
				lstWorkOrder.DataSource = RsOrdTra;
				lstWorkOrder.DataBind();

				//After binding, verify the elements that will be showing the PLUS button
				for(int i=0;i<lstWorkOrder.Items.Count;i++)
				{
					SICALNet.BusinessLogicLayer.PartidasColor blPColor = new SICALNet.BusinessLogicLayer.PartidasColor();	
					string secuencia=((Label)lstWorkOrder.Items[i].FindControl("ItemSecuencia")).Text.ToString();
					if(blPColor.IsExistSecuencia(secuencia))
					{
						lstWorkOrder.Items[i].FindControl("aspPlus").Visible=true;
						((Label)lstWorkOrder.Items[i].FindControl("spacer")).Visible=false;
						//((CheckBox)lstWorkOrder.Items[i].FindControl("chkSelect")).Enabled=false;
					}
					string StatusId = ((Label)lstWorkOrder.Items[i].FindControl("ItemIdStatus")).Text;
					if(StatusId=="5")
						((CheckBox)lstWorkOrder.Items[i].FindControl("chkSelect")).Enabled=false;					
					//Label lblFechaMod = (Label)lstWorkOrder.Items[i].FindControl("ItemFechaMod");
					/*if (lblFechaMod.Text != "") 
						lstWorkOrder.Items[i].BackColor = Color.Tomato;*/
				}
				//BindChildGrids();
				btnAgregar.Visible=true;
				btnLiberado.Visible=true;
				btnRpt.Visible=true;
				btnImprimirEqu.Visible=true;
				chkSeparate.Visible = true;
				btnCard.Visible = true;
				/* JJMR 16/04/2015 */
				// btnPreform.Visible=true;
				btnPreform.Visible=false;
				return true;
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
			prcCboFill();
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnImprimirEqu.Click += new System.EventHandler(this.btnImprimirEqu_Click);
			this.btnRpt.Click += new System.EventHandler(this.btnRpt_Click);
			this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
			this.btnLiberado.Click += new System.EventHandler(this.btnLiberado_Click);
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
			this.btnPreform.Click += new System.EventHandler(this.btnPreform_Click);
			this.lstWorkOrder.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.lstWorkOrder_ItemCommand);
			this.lstWorkOrder.ItemDataBound += new System.Web.UI.WebControls.DataListItemEventHandler(this.lstWorkOrder_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


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
			//to fill the Color description into the cboColor control
			SICALNet.BusinessLogicLayer.Colour BLLColor=new SICALNet.BusinessLogicLayer.Colour();
			IList RsColor=(IList) BLLColor.SelectColour();
			prcCboCommon(cboColor,"IdColour","Descripcion",RsColor);
			//to fill the Area description into the cboArea control
//			SICALNet.BusinessLogicLayer.Area BLLArea=new SICALNet.BusinessLogicLayer.Area();
//			IList RsArea=(IList) BLLArea.SelectArea();
//			prcCboCommon(cboArea,"IdArea","Descripcion",RsArea);
//			cboArea.Items.FindByValue("0").Selected=false;
//			cboArea.Items[0].Selected=true;
		}

		//common function is used to fill the combo box
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
			}
			else if(sVal=="IdStatus" )
			{
				string currentStatus=(string)Session[this.Context.User.Identity.Name+"selectedIdStatus"];
				if (currentStatus != null)
					cbo.Items.FindByValue(currentStatus).Selected=true;
				else
					// cbo.Items.FindByValue("0").Selected=true;
					cbo.Items.FindByValue("2").Selected=true; // Activo por default

			}
			else
			{
				cbo.Items.FindByValue("0").Selected=true;
			}

		}

		//to fill the datagid
		private void btnSel_Click(object sender, System.EventArgs e)
		{
			try
			{		
				if (LoadWorkOrders(txtInitial.Text,txtFinal.Text))
				{
					btnAgregar.Visible=true;
					btnLiberado.Visible=true;
					btnRpt.Visible=true;
					btnImprimirEqu.Visible=true;
					chkSeparate.Visible = true;
					btnCard.Visible = true;
					/* JJMR 14/04/2015 */
					//btnPreform.Visible=true;
					btnPreform.Visible=false;
				}
				else
				{
					btnAgregar.Visible=false;
					btnLiberado.Visible=false;
					btnRpt.Visible=false;
					btnImprimirEqu.Visible=false;
					chkSeparate.Visible = false;
					btnCard.Visible = false;
					btnPreform.Visible=false;
	
					// throw new Exception("No se encontraron órdenes de trabajo para los valores solicitados...");

					Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
						"alert('"+"No se encontraron órdenes de trabajo para los valores solicitados..."+"');</script>");
				}
			}
			catch
			{
				//to display the msg for user
//				string prtMsg=errHand.Message.Replace("'"," ");
//				string ScriptString = "<script language = 'javascript'> alert('" + prtMsg + "'); </script>"; 
//				Page.RegisterStartupScript("ClientScript",ScriptString);

				throw;
			}

		}
		/*public void extend(object sender,System.EventArgs e)
		{
			if(((CheckBox)lstWorkOrder.Items[index-1].FindControl("chkSelect")).Checked==true)
			{
				SICALNet.BusinessLogicLayer.PartidasAditivos blPartidasAdi = new SICALNet.BusinessLogicLayer.PartidasAditivos();
				string secuencia=((Label)lstWorkOrder.Items[index-1].FindControl("ItemSecuencia")).Text.ToString();
				int Status =Convert.ToInt32(((Label)lstWorkOrder.Items[index-1].FindControl("ItemIdStatus")).Text.ToString());
				SICALNet.BusinessLogicLayer.PartidasColor BLLPC=new SICALNet.BusinessLogicLayer.PartidasColor();
				IList RsPC=(IList) BLLPC.GetLaminas(secuencia);			
				DataList lstLaminas=((DataList)lstWorkOrder.Items[index-1].FindControl("dstLaminas"));
				if (RsPC.Count > 0)
				{
					lstLaminas.DataSource = RsPC;
					lstLaminas.DataBind();
				}
				lstLaminas.Visible=true;
				for(int inloop=0;inloop<RsPC.Count;inloop++)
				{
					SICALNet.BusinessEntities.PartidasColorInfo bePCol = new SICALNet.BusinessEntities.PartidasColorInfo();
					bePCol=(SICALNet.BusinessEntities.PartidasColorInfo)RsPC[inloop];
					SICALNet.BusinessLogicLayer.PartidasColor blPCol=new SICALNet.BusinessLogicLayer.PartidasColor();
					IList VasoList=blPCol.Load(secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),bePCol.VasoNo);
					DataGrid dgdColor = ((DataGrid)lstLaminas.Items[inloop].FindControl("dgdColorWO"));
					dgdColor.DataSource=VasoList;
					dgdColor.DataBind();
					dgdColor.Visible=true;
					if(Status==5)
					{
						dgdColor.Columns[5].Visible=true;
						dgdColor.Columns[7].Visible=true;
						dgdColor.Columns[4].Visible=false;
						dgdColor.Columns[6].Visible=false;
					}
					
				}
			}
			else
			{
				DataList lstLaminas=((DataList)lstWorkOrder.Items[index-1].FindControl("dstLaminas"));
				lstLaminas.Visible=false;
			}
		}*/

		private void lstWorkOrder_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			try
			{
				string CodigoSAP;	
				string IdStatusAux = ((Label)e.Item.FindControl("ItemIdStatus")).Text;
				string SecuanceAux=((Label)e.Item.FindControl("ItemSecuencia")).Text.ToString();

				/*** modificado por alejandro.hernandez@nasoft.com ***/
				SICALNet.BusinessEntities.PartidasColorInfo BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
				int i=0;
				float[] Aforo;
				int[] aryLaminas;
				int[] NoVaso;
				int NoGroup=0;
				/*** fin de modificación ***/

				if(IdStatusAux ==ConfigurationSettings.AppSettings["StatusCancel"].ToString())
				{
					throw new Exception("La Secuencia "+SecuanceAux+" ya se encuentra cancelada por lo cual no puede ser consultada");
				}
			
				switch (e.CommandName)
				{

					case "Consult":
						string secuance=((Label)e.Item.FindControl("ItemSecuencia")).Text.ToString();
						SICALNet.BusinessEntities.SecuenciaCombinasInfo scInfo = new SICALNet.BusinessEntities.SecuenciaCombinasInfo(secuance,0);
						SICALNet.BusinessLogicLayer.SecuenciaCombinas blSC = new SICALNet.BusinessLogicLayer.SecuenciaCombinas();
						IList CombinasList=blSC.SelectSecuenciaCombinas(scInfo);
						

						int itemidx=0;
						if(CombinasList.Count==0)
						{
					
							string Secuance=((Label)e.Item.FindControl("ItemSecuencia")).Text.ToString();
							string Cantidad=((Label)e.Item.FindControl("ItemCantidad")).Text.ToString();
							string Fecha = ((Label)e.Item.FindControl("ItemFecha")).Text.ToString();
							string UTEC  = ((Label)e.Item.FindControl("ItemDescripcion")).Text.ToString();
							CodigoSAP = ((Label)e.Item.FindControl("ItemCodigoSAP")).Text.ToString();
							string IdStatus = ((Label)e.Item.FindControl("ItemIdStatus")).Text;
							string IdPlanta = ((Label)e.Item.FindControl("ItemIdPlanta")).Text;
							string IdLinea = ((Label)e.Item.FindControl("ItemIdLinea")).Text;

							for(i=1;i<(lstWorkOrder.Items.Count-e.Item.ItemIndex);i++)
							{
								if(itemidx==0)
								{
									if(((Label)lstWorkOrder.Items[e.Item.ItemIndex+i].FindControl("ItemIdStatus")).Text.ToString()=="2")
										itemidx=e.Item.ItemIndex+i;
								}
							}
							if(itemidx==0)
								itemidx=lstWorkOrder.Items.Count+1;
							//session variable is used for rest of the forms in wizards
							Session[this.Context.User.Identity.Name+"Secuencia"]=Secuance;
							Session[this.Context.User.Identity.Name+"Cantidad"]=Cantidad;
							Session[this.Context.User.Identity.Name+"Fecha"] = Fecha;
							Session[this.Context.User.Identity.Name+"UTEC"]  = UTEC;
							Session[this.Context.User.Identity.Name+"CodigoSAP"] = CodigoSAP;
							Session[this.Context.User.Identity.Name+"IdStatus"] = IdStatus;
							Session[this.Context.User.Identity.Name+"IdPlanta"] = IdPlanta;
							Session[this.Context.User.Identity.Name+"IdLinea"] = IdLinea;
							Session[this.Context.User.Identity.Name+"FormularFlag"]="0";
							Session[this.Context.User.Identity.Name+"ItemIndex"]=itemidx;

							//Before performing any consult, the system will verify if the sequence is transparent
							SICALNet.BusinessLogicLayer.Colour blColor = new SICALNet.BusinessLogicLayer.Colour();
							int Transperant=blColor.CheckTransperant(Secuance,0);
							if(Transperant==1)							
								throw new Exception("La Secuencia "+Secuance+" se refiere a una lámina de color transparente, por lo tanto no tiene componentes de color.");
								//throw new Exception(" The Color for this Secunecia is Transperant so cannot be Consulted and it is already Released");

							if(IdStatus=="5")
							{
								SICALNet.BusinessLogicLayer.PartidasColor BLLPC=new SICALNet.BusinessLogicLayer.PartidasColor();
								IList pcList = (IList) BLLPC.GetNoVaso(Session[this.Context.User.Identity.Name+"Secuencia"].ToString());
								Session[this.Context.User.Identity.Name+"NoGroup"] = pcList.Count.ToString();
								IList RsPC=(IList) BLLPC.GetLaminas(Session[this.Context.User.Identity.Name+"Secuencia"].ToString());
								NoVaso=new int[pcList.Count];
								Aforo = new float[pcList.Count];
								for(i=0;i<pcList.Count;i++)
								{
//									SICALNet.BusinessEntities.PartidasColorInfo BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
									
									BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();

									BEInfo = (SICALNet.BusinessEntities.PartidasColorInfo)pcList[i];
									NoVaso[i]=BEInfo.NoVaso;
									Aforo[i]=BEInfo.Aforo;
								}
								Session[this.Context.User.Identity.Name+"NoVaso"]=NoVaso;
								Session[this.Context.User.Identity.Name+"Aforo"]=Aforo;
								aryLaminas = new int[RsPC.Count];
								for(i=0;i<RsPC.Count;i++)
								{
//									SICALNet.BusinessEntities.PartidasColorInfo BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
									BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
									BEInfo = (SICALNet.BusinessEntities.PartidasColorInfo)RsPC[i];
									aryLaminas[i]=BEInfo.NoLaminas;
								}
								Session[this.Context.User.Identity.Name+"VasoQty"] = aryLaminas;
								Session[this.Context.User.Identity.Name+"TotNoVaso"] = RsPC.Count;
								Response.Redirect("ColorWOFinal.aspx?isNew=false");
							}
							else if(((CheckBox)e.Item.FindControl("chkSelect")).Checked==true)
							{
								//string ShortCut="True";
								SICALNet.BusinessLogicLayer.PartidasColor BLLPC=new SICALNet.BusinessLogicLayer.PartidasColor();
								if(BLLPC.IsExistSecuencia(secuance))
								{
									IList pcList = (IList) BLLPC.GetNoVaso(Session[this.Context.User.Identity.Name+"Secuencia"].ToString());
									Session[this.Context.User.Identity.Name+"NoGroup"] = pcList.Count.ToString();
									IList RsPC=(IList) BLLPC.GetLaminas(Session[this.Context.User.Identity.Name+"Secuencia"].ToString());
									NoVaso=new int[pcList.Count];
									Aforo = new float[pcList.Count];
									for(i=0;i<pcList.Count;i++)
									{
//										SICALNet.BusinessEntities.PartidasColorInfo BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
										BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
										BEInfo = (SICALNet.BusinessEntities.PartidasColorInfo)pcList[i];
										NoVaso[i]=BEInfo.NoVaso;
										Aforo[i]=BEInfo.Aforo;
									}
									Session[this.Context.User.Identity.Name+"NoVaso"]=NoVaso;
									Session[this.Context.User.Identity.Name+"Aforo"]=Aforo;
									aryLaminas = new int[RsPC.Count];
									for(i=0;i<RsPC.Count;i++)
									{
//										SICALNet.BusinessEntities.PartidasColorInfo BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
										BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
										BEInfo = (SICALNet.BusinessEntities.PartidasColorInfo)RsPC[i];
										aryLaminas[i]=BEInfo.NoLaminas;
									}
									Session[this.Context.User.Identity.Name+"VasoQty"] = aryLaminas;
									Session[this.Context.User.Identity.Name+"TotNoVaso"] = RsPC.Count;
									Response.Redirect("ColorWOFinal.aspx?isNew=false&ShortCut=True");
								
								}
								else
								{
                                    SICALNet.Utilities.Validation pltVt = new SICALNet.Utilities.Validation();
									if(!pltVt.IsNumber(txtAforo.Text)||txtAforo.Text==""||txtAforo.Text==string.Empty)
										throw new Exception(" The Value of Aforo should be Numeric or Zero");
									NoGroup = BLLPC.GetNoGroup(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"]));
									Session[this.Context.User.Identity.Name+"NoGroup"] = NoGroup;
									NoVaso=new int[NoGroup];
									Aforo = new float[NoGroup];
									aryLaminas = new int[NoGroup];
									for(i=0;i<NoGroup;i++)
									{
										NoVaso[i]=1;
										Aforo[i]=Convert.ToSingle(txtAforo.Text);
										aryLaminas[i]=Convert.ToInt32(Cantidad);
									}
									Session[this.Context.User.Identity.Name+"NoVaso"]=NoVaso;
									Session[this.Context.User.Identity.Name+"Aforo"]=Aforo;	
									Session[this.Context.User.Identity.Name+"VasoQty"] = aryLaminas;
									Session[this.Context.User.Identity.Name+"TotNoVaso"] = NoGroup;
									Response.Redirect("ColorWOFinal.aspx?isNew=true&ShortCut=True");							
								}					
							
							}
								//string queryString=string.Format("?Secuencia={0}&Cantidad={1}&Fecha={2}&UTEC={3}&CodigoSAP={4}&IdStatus={5}&IdPlanta={6}",secuance,Cantidad,Fecha,UTEC,CodigoSAP,IdStatus,IdPlanta);
								//Response.Redirect(string.Format("NoOfVasos.aspx{0}",queryString));
							else
								Response.Redirect("NoOfVasos.aspx");
						}
						else
						{
						
							string UTEC  = ((Label)e.Item.FindControl("ItemDescripcion")).Text.ToString();
							CodigoSAP = ((Label)e.Item.FindControl("ItemCodigoSAP")).Text.ToString();
							string IdStatus = ((Label)e.Item.FindControl("ItemIdStatus")).Text;
							string IdPlanta = ((Label)e.Item.FindControl("ItemIdPlanta")).Text;
							for(i=1;i<(lstWorkOrder.Items.Count-e.Item.ItemIndex);i++)
							{
								if(itemidx==0)
								{
									if(((Label)lstWorkOrder.Items[e.Item.ItemIndex+i].FindControl("ItemIdStatus")).Text.ToString()=="2")
										itemidx=e.Item.ItemIndex+i;
								}
							}
							if(itemidx==0)
								itemidx=lstWorkOrder.Items.Count+1;
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
							Session[this.Context.User.Identity.Name+"Fecha"] = Fecha;
							Session[this.Context.User.Identity.Name+"UTEC"]  = UTEC;
							Session[this.Context.User.Identity.Name+"CodigoSAP"] = CodigoSAP;
							Session[this.Context.User.Identity.Name+"IdStatus"] = IdStatus;
							Session[this.Context.User.Identity.Name+"IdPlanta"] = IdPlanta;
							Session[this.Context.User.Identity.Name+"IdLinea"] = Linea[0];
							Session[this.Context.User.Identity.Name+"FormularFlag"]=CombinasList.Count;
							Session[this.Context.User.Identity.Name+"ItemIndex"]=itemidx;
							if(IdStatus=="5")
							{
								SICALNet.BusinessLogicLayer.Colour blColor = new SICALNet.BusinessLogicLayer.Colour();
								int Transperant=blColor.CheckTransperant(secuencia[0],0);
								if(Transperant==1)
									throw new Exception("La Secuencia "+secuencia[0].ToString()+" se refiere a una lámina de color transparente, por lo tanto no tiene componentes de color.");
								SICALNet.BusinessLogicLayer.PartidasColor BLLPC=new SICALNet.BusinessLogicLayer.PartidasColor();
								IList pcList = (IList) BLLPC.GetNoVaso(secuencia[0]);
								Session[this.Context.User.Identity.Name+"NoGroup"] = pcList.Count.ToString();
								/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
								StringBuilder sec = new StringBuilder("'");
								//string sec="'";
								for(i=0;i<secuencia.Length;i++)
								{
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
//										sec+="','";
									}
									/*** fin modificación ***/
								}
								IList RsPC=(IList) BLLPC.GetLaminasCombined(sec.ToString());
								NoVaso=new int[pcList.Count];
								Aforo = new float[pcList.Count];
								for(i=0;i<pcList.Count;i++)
								{
									//SICALNet.BusinessEntities.PartidasColorInfo BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
									BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
									BEInfo = (SICALNet.BusinessEntities.PartidasColorInfo)pcList[i];
									NoVaso[i]=BEInfo.NoVaso;
									Aforo[i]=BEInfo.Aforo;
								}
								Session[this.Context.User.Identity.Name+"NoVaso"]=NoVaso;
								Session[this.Context.User.Identity.Name+"Aforo"]=Aforo;
								aryLaminas = new int[RsPC.Count];
								for(i=0;i<RsPC.Count;i++)
								{
//									SICALNet.BusinessEntities.PartidasColorInfo BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
									BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
									BEInfo = (SICALNet.BusinessEntities.PartidasColorInfo)RsPC[i];
									aryLaminas[i]=BEInfo.NoLaminas;
								}
								Session[this.Context.User.Identity.Name+"VasoQty"] = aryLaminas;
								Session[this.Context.User.Identity.Name+"TotNoVaso"] = RsPC.Count;
								Response.Redirect("ColorWOFinal.aspx?isNew=false");
							}
							else if(((CheckBox)e.Item.FindControl("chkSelect")).Checked==true)
							{
								
								SICALNet.BusinessLogicLayer.PartidasColor BLLPC = new SICALNet.BusinessLogicLayer.PartidasColor();
								//string[] secuencia = (string[])Session[this.Context.User.Identity.Name+"Secuencia"];
								if(BLLPC.IsExistSecuencia(secuencia[0]))
								{
									//SICALNet.BusinessEntities.OrdenesTrabajoInfo OInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(secuencia[0],Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),0);
									//SICALNet.BusinessLogicLayer.OrdenesTrabajo blOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
									//int Status=blOrdenes.GetStatus(OInfo);
									//Session[this.Context.User.Identity.Name+"IdStatus"] = Status;
									
									IList pcList = (IList) BLLPC.GetNoVaso(secuencia[0]);
									Session[this.Context.User.Identity.Name+"NoGroup"] = pcList.Count.ToString();
									/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
									StringBuilder sec = new StringBuilder("'");
//									string sec="'";
									for(i=0;i<secuencia.Length;i++)
									{
										sec.Append(secuencia[i]);
//										sec+=secuencia[i];
										if(i==((secuencia.Length)-1))
										{
											sec.Append("'");
//											sec+="'";
										}
										else
										{
											sec.Append("','");
//											sec+="','";
										}
										/*** fin modificación ***/
									}
									IList RsPC=(IList) BLLPC.GetLaminasCombined(sec.ToString());
									NoVaso=new int[pcList.Count];
									Aforo = new float[pcList.Count];
									for(i=0;i<pcList.Count;i++)
									{
//										SICALNet.BusinessEntities.PartidasColorInfo BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
										BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
										BEInfo = (SICALNet.BusinessEntities.PartidasColorInfo)pcList[i];
										NoVaso[i]=BEInfo.NoVaso;
										Aforo[i]=BEInfo.Aforo;
									}
									Session[this.Context.User.Identity.Name+"NoVaso"]=NoVaso;
									Session[this.Context.User.Identity.Name+"Aforo"]=Aforo;
									aryLaminas = new int[RsPC.Count];
									for(i=0;i<RsPC.Count;i++)
									{
//										SICALNet.BusinessEntities.PartidasColorInfo BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
										BEInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
										BEInfo = (SICALNet.BusinessEntities.PartidasColorInfo)RsPC[i];
										aryLaminas[i]=BEInfo.NoLaminas;
									}
									Session[this.Context.User.Identity.Name+"VasoQty"] = aryLaminas;
									Session[this.Context.User.Identity.Name+"TotNoVaso"] = RsPC.Count;
									Response.Redirect("ColorWOFinal.aspx?isNew=false&ShortCut=True");
								}
								else
								{
									SICALNet.Utilities.Validation pltVt = new SICALNet.Utilities.Validation();
									if(!pltVt.IsNumber(txtAforo.Text)||txtAforo.Text==""||txtAforo.Text==string.Empty)
										throw new Exception(" The Value of Aforo should be Numeric or Zero");
									NoGroup = BLLPC.GetNoGroup(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"]));
									Session[this.Context.User.Identity.Name+"NoGroup"] = NoGroup;
									
									NoVaso=new int[NoGroup];
									Aforo = new float[NoGroup];
									aryLaminas = new int[NoGroup];
									int CantidadSum=0;
									for(i=0;i<Cantidad.Length;i++)
										CantidadSum+=Cantidad[i];
									for(i=0;i<NoGroup;i++)
									{
										NoVaso[i]=1;
										Aforo[i]=Convert.ToSingle(txtAforo.Text);
										aryLaminas[i]=CantidadSum;
									}
									Session[this.Context.User.Identity.Name+"NoVaso"]=NoVaso;
									Session[this.Context.User.Identity.Name+"Aforo"]=Aforo;	
									Session[this.Context.User.Identity.Name+"VasoQty"] = aryLaminas;
									Session[this.Context.User.Identity.Name+"TotNoVaso"] = NoGroup;
									Response.Redirect("ColorWOFinal.aspx?isNew=true&ShortCut=True");	
								}

							}
								//string queryString=string.Format("?Secuencia={0}&Cantidad={1}&Fecha={2}&UTEC={3}&CodigoSAP={4}&IdStatus={5}&IdPlanta={6}",secuance,Cantidad,Fecha,UTEC,CodigoSAP,IdStatus,IdPlanta);
								//Response.Redirect(string.Format("NoOfVasos.aspx{0}",queryString));
							else
								//string queryString=string.Format("?Secuencia={0}&Cantidad={1}&Fecha={2}&UTEC={3}&CodigoSAP={4}&IdStatus={5}&IdPlanta={6}",secuance,Cantidad,Fecha,UTEC,CodigoSAP,IdStatus,IdPlanta);
								//Response.Redirect(string.Format("NoOfVasos.aspx{0}",queryString));
								Response.Redirect("NoOfVasos.aspx?Room=Color&Descripcion="+UTEC);

						}
						break;
					case "Mensaje":
						string Secuencia = ((Label)e.Item.FindControl("ItemSecuencia")).Text.ToString();
						string IdArea= ConfigurationSettings.AppSettings["ColorRoomId"].ToString();
						string CodeSAP=((Label)e.Item.FindControl("ItemCodigoSAP")).Text.ToString();
						string matDesc=((Label)e.Item.FindControl("ItemDescripcion")).Text.ToString();
						RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('../../MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodeSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");
						break;
					case "Expand":
						string _secuencia = ((Label)e.Item.FindControl("ItemSecuencia")).Text.ToString();
						int _status  = Convert.ToInt32(((Label)e.Item.FindControl("ItemIdStatus")).Text.ToString());
						BindChildGrids(_secuencia,_status);
						break;
				}
			}
			catch(Exception errHand)
			{
				
				if (errHand.Message.IndexOf("se refiere a una lámina de color transparente, por lo tanto no tiene componentes de color.") >0)
				{
					string ScriptString="<script language='javascript'>alert('" + errHand.Message.ToString() + "');</script>"; 
					Page.RegisterStartupScript("ClientScript",ScriptString);
				}
				else{
					throw;
				}
			}
		}

		public void checkAll(object sender,System.EventArgs e)
		{
			//loop thru the list of available work orders
			for (int i=0;i<lstWorkOrder.Items.Count;i++)
			{
				CheckBox parentCheckbox = (CheckBox)sender;
				//obtain current checkbox
				CheckBox currentCheck = (CheckBox) lstWorkOrder.Items[i].FindControl("chkSelect");
				//if it has Partidas information (is enabled)
				if (currentCheck.Enabled==true)
				{
					//Check the checkbox
					currentCheck.Checked=parentCheckbox.Checked;
					//Display details
				}
			}		
		}

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
			try
			{
				IList aryClrRm = new ArrayList();
				//Obtain IdArea of Color Area
				int IdArea= Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"].ToString());
				//Obtain status for released work order
				int releasedStatus=Convert.ToInt32(ConfigurationSettings.AppSettings["StatusRelease"]);
				
				//Loop parent list
				for(int iloop=0;iloop<lstWorkOrder.Items.Count;iloop++)
				{
					//Obtain sequence
					string secuencia=((Label)lstWorkOrder.Items[iloop].FindControl("ItemSecuencia")).Text.ToString();
					//Obtain current status of the work order, date and list of components
					int sequenceStatus=Convert.ToInt32(((Label) lstWorkOrder.Items[iloop].FindControl("ItemIdStatus")).Text);
					DateTime Fecha=Convert.ToDateTime(((Label)lstWorkOrder.Items[iloop].FindControl("ItemFecha")).Text.ToString());
					DataList lstLaminas=((DataList)lstWorkOrder.Items[iloop].FindControl("dstLaminas"));
					
					//Only when current item is selected, and it is not released
					if(((CheckBox)lstWorkOrder.Items[iloop].FindControl("chkSelect")).Checked && (sequenceStatus !=releasedStatus))
					{					
						for(int inloop=0;inloop<lstLaminas.Items.Count;inloop++)
						{
							//Proceed to gather the data from Interface
							int Olla=Convert.ToInt32(((Label)lstLaminas.Items[inloop].FindControl("lblVaso")).Text.ToString());
							int Laminas=Convert.ToInt32(((Label)lstLaminas.Items[inloop].FindControl("lblLaminas")).Text.ToString());
					
							DataGrid dgdColorWO = ((DataGrid)lstLaminas.Items[inloop].FindControl("dgdColorWO"));
							// SICALNet.Utilities.Validation pdvlt = new SICALNet.Utilities.Validation();
							//Loop the elements grid
							for(int iinloop=0;iinloop<dgdColorWO.Items.Count;iinloop++)
							{
								string Codigo=((Label) dgdColorWO.Items[iinloop].FindControl("lblCodigoSAP")).Text.ToString();
								decimal Cantidad=Convert.ToDecimal(((Label) dgdColorWO.Items[iinloop].FindControl("lblCantidad")).Text.Trim().ToString());
								try
								{
									Decimal.Parse(((TextBox) dgdColorWO.Items[iinloop].FindControl("txtRegistro")).Text.Trim().ToString());
								}
								catch
								{
									throw new Exception(" Proporcione un número válido en el campo de Cantidad Real");
								}
								decimal CantidadReal=Convert.ToDecimal(((TextBox) dgdColorWO.Items[iinloop].FindControl("txtRegistro")).Text.Trim().ToString());
								string folio=((TextBox) dgdColorWO.Items[iinloop].FindControl("txtlotePasta")).Text.Trim();
								int Grupo=Convert.ToInt32(((Label)dgdColorWO.Items[iinloop].FindControl("lblGrupo")).Text.ToString());
								//
								SICALNet.BusinessEntities.PartidasColorInfo  BEparti=new SICALNet.BusinessEntities.PartidasColorInfo(
									secuencia,IdArea,Codigo,Olla,Laminas,Cantidad,CantidadReal,Fecha.ToString("dd/MMM/yyyy"),folio,Grupo,0);
								aryClrRm.Add(BEparti);
							}

						}
						//Save all the VASOS, and all the ELEMENTS of each VASO of the current Sequence.
						SICALNet.BusinessLogicLayer.PartidasColor PAd = new SICALNet.BusinessLogicLayer.PartidasColor();
						PAd.Delete(secuencia);
						PAd.Insert(aryClrRm);
						aryClrRm.Clear();
						SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),this.Context.User.Identity.Name);
						SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						BLOrdenes.UpdateLoginForm(OTInfo);
					}
				}
				LoadWorkOrders(txtInitial.Text,txtFinal.Text);

			}
			catch
			{
//				string sErrMsg;
//				sErrMsg=ErrHand.Message;
//				string ScriptString="<script language='javascript'>alert('"+ sErrMsg +"');</script>"; 
//				Page.RegisterStartupScript("ClientScript",ScriptString);

				throw;
			}
		}

		private void btnLiberado_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
				StringBuilder Secuencias = new StringBuilder();
				//string Secuencias="";
				for(int i=0;i<lstWorkOrder.Items.Count;i++)
				{
					if((((CheckBox)lstWorkOrder.Items[i].FindControl("chkSelect")).Checked==true))
					{
						SICALNet.BusinessLogicLayer.PartidasColor blPartidasCol = new SICALNet.BusinessLogicLayer.PartidasColor();
						string secuencia=((Label)lstWorkOrder.Items[i].FindControl("ItemSecuencia")).Text.ToString();
						if(!blPartidasCol.IsExistSecuencia(secuencia))
						{
							Secuencias.Append(secuencia).Append(",");
							//Secuencias+=secuencia+",";
							/*** fin modificación ***/
						}
					}
				}
				if(Secuencias.Length==0)
				{
					IList aryClrRm = new ArrayList();
					//Obtain IdArea of Color Area
					int IdArea= Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"].ToString());
					//Obtain status for released work order
					//int releasedStatus=Convert.ToInt32(ConfigurationSettings.AppSettings["StatusRelease"]);
					for(int iloop=0;iloop<lstWorkOrder.Items.Count;iloop++)
					{
						string secuencia=((Label)lstWorkOrder.Items[iloop].FindControl("ItemSecuencia")).Text.ToString();
						//Obtain current status of the work order, date and list of components
						int sequenceStatus=Convert.ToInt32(((Label) lstWorkOrder.Items[iloop].FindControl("ItemIdStatus")).Text);
						DateTime Fecha=Convert.ToDateTime(((Label)lstWorkOrder.Items[iloop].FindControl("ItemFecha")).Text.ToString());
						if(((CheckBox)lstWorkOrder.Items[iloop].FindControl("chkSelect")).Checked==true)
						{
							BindChildGrids(secuencia,sequenceStatus);
							DataList lstLaminas=((DataList)lstWorkOrder.Items[iloop].FindControl("dstLaminas"));
							for(int inloop=0;inloop<lstLaminas.Items.Count;inloop++)
							{
								//Proceed to gather the data from Interface
								int Olla=Convert.ToInt32(((Label)lstLaminas.Items[inloop].FindControl("lblVaso")).Text.ToString());
								int Laminas=Convert.ToInt32(((Label)lstLaminas.Items[inloop].FindControl("lblLaminas")).Text.ToString());
					
								DataGrid dgdColorWO = ((DataGrid)lstLaminas.Items[inloop].FindControl("dgdColorWO"));
								SICALNet.Utilities.Validation pdvlt = new SICALNet.Utilities.Validation();
								//Loop the elements grid
								for(int iinloop=0;iinloop<dgdColorWO.Items.Count;iinloop++)
								{
									string Codigo=((Label) dgdColorWO.Items[iinloop].FindControl("lblCodigoSAP")).Text.ToString();
									decimal Cantidad=Convert.ToDecimal(((Label) dgdColorWO.Items[iinloop].FindControl("lblCantidad")).Text.Trim().ToString());
									if(!pdvlt.IsNumber(((TextBox) dgdColorWO.Items[iinloop].FindControl("txtRegistro")).Text.Trim().ToString()))
										throw new Exception(" Proporcione una cantidad real válida.");
									decimal CantidadReal=Convert.ToDecimal(((TextBox) dgdColorWO.Items[iinloop].FindControl("txtRegistro")).Text.Trim().ToString());
									string folio=((TextBox) dgdColorWO.Items[iinloop].FindControl("txtlotePasta")).Text.Trim();
									int Grupo=Convert.ToInt32(((Label)dgdColorWO.Items[iinloop].FindControl("lblGrupo")).Text.ToString());
									//
									SICALNet.BusinessEntities.PartidasColorInfo  BEparti=new SICALNet.BusinessEntities.PartidasColorInfo(
										secuencia,IdArea,Codigo,Olla,Laminas,Cantidad,CantidadReal,Fecha.ToString("dd/MMM/yyyy"),folio,Grupo,0);
									aryClrRm.Add(BEparti);
								}

							}
							//Save all the VASOS, and all the ELEMENTS of each VASO of the current Sequence.
							SICALNet.BusinessLogicLayer.PartidasColor PAd = new SICALNet.BusinessLogicLayer.PartidasColor();
							PAd.Delete(secuencia);
							PAd.Insert(aryClrRm);
							aryClrRm.Clear();
							SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),this.Context.User.Identity.Name);
							SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
							BLOrdenes.UpdateLoginForm(OTInfo);				

							//Activate Next Area And update Active Area in Programma Production for this Secuencia
							//Depending on sequence available in "FlujoArea" Table
							SICALNet.BusinessLogicLayer.FlujoArea objFlujoArea = new SICALNet.BusinessLogicLayer.FlujoArea();
							objFlujoArea.ActivateDependingAreas(secuencia,IdArea);
							
							SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo1 = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(secuencia,2,Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]),Convert.ToInt32(ConfigurationSettings.AppSettings["PVCRoomId"]),Convert.ToInt32(ConfigurationSettings.AppSettings["MixtureRoomId"]),5,DateTime.Now.Date.ToString("dd-MMM-yyyy"),Context.User.Identity.Name);
							SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes1 = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
							BLOrdenes1.ColorUpdate(OTInfo1);
							Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"La Orden de Trabajo se libero exitosamente"+"')" + "<" + "/script>");
					
						}
					}
					LoadWorkOrders(txtInitial.Text,txtFinal.Text);
				}
				else
					throw new Exception(" No se ha establecido formulación para las secuencias "+ Secuencias + ", por lo tanto no se pueden liberar.");
			}
			catch
			{
//				string sErrMsg;
//				sErrMsg=ErrHand.Message.Replace("'","-");
//				string ScriptString="<script language='javascript'>alert('"+ sErrMsg +"');</script>"; 
//				Page.RegisterStartupScript("ClientScript",ScriptString);

				throw;
			}
		}

		private void btnRpt_Click(object sender, System.EventArgs e)
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
						"alert('Seleccione una secuencia para generar un reporte');</script>");

					return;
				}

				/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
				StringBuilder SecuenciaStr=new StringBuilder();
				//string SecuenciaStr="";
				for(int k=0;k<i;k++)
				{
					SecuenciaStr.Append("{PartidasColor.Secuencia}= '").Append(secuencia[k]).Append("'");
					//SecuenciaStr+="{PartidasColor.Secuencia}= '"+secuencia[k]+"'";
					if(k!=(i-1))
					{
						SecuenciaStr.Append(" OR ");
						//SecuenciaStr+=" OR ";
					}
				}

				// Limpieza de cache
				Response.Cache.SetCacheability(HttpCacheability.NoCache);
				Response.Cache.SetNoStore();
				Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
				Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
				Response.Cache.SetValidUntilExpires(false);

				if(chkSeparate.Checked)
					PrepareReportSeparate(txtInitial.Text,txtFinal.Text,Convert.ToInt32(cboLinea.SelectedItem.Value),Convert.ToInt32(cboStatus.SelectedItem.Value),SecuenciaStr.ToString());						
				else
					PrepareReport(txtInitial.Text,txtFinal.Text,Convert.ToInt32(cboLinea.SelectedItem.Value),Convert.ToInt32(cboStatus.SelectedItem.Value),SecuenciaStr.ToString());
				
				//Response.Redirect("ColorWOReport.aspx?FechaIni="+txtInitial.Text+"&FechaFin="+txtFinal.Text+"&Linea="+cboLinea.SelectedItem.Value+"&Status="+cboStatus.SelectedItem.Value+"&Secuencias="+SecuenciaStr);
			}
			catch
			{
				throw;

			}
			
		}

		private void PrepareReport(string fechaInicial, string fechaFinal, int linea,int status, string secuencias)
		{
		
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			Production.WorkOrder.PartidasColor.ColorWOReport reporte = new Production.WorkOrder.PartidasColor.ColorWOReport();

			ParameterValues campoFecha= new ParameterValues();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			valorFecha.Value=string.Format("{0} al {1}",fechaInicial,fechaFinal);
			campoFecha.Add(valorFecha);
				
			reporte.DataDefinition.ParameterFields["Fecha"].ApplyCurrentValues(campoFecha);

			string	SelectionStr="";
			if(linea!=0)
				SelectionStr= "{ProgramaProduccion.IdLinea}="+linea.ToString()+" AND ";
			if(status!=0)
				SelectionStr+= "{OrdenesTrabajo.IdStatus}="+ status.ToString() +" AND ";

			SelectionStr+="{ProgramaProduccion.Fecha}>=Date("+DateTime.Parse(fechaInicial).ToString("yyyy")+","+DateTime.Parse(fechaInicial).ToString("MM")+","+DateTime.Parse(fechaInicial).ToString("dd")+")";
			SelectionStr+=" AND {ProgramaProduccion.Fecha}<=Date("+DateTime.Parse(fechaFinal).ToString("yyyy")+","+DateTime.Parse(fechaFinal).ToString("MM")+","+DateTime.Parse(fechaFinal).ToString("dd")+")";
			SelectionStr+=" AND {OrdenesTrabajo.IdArea}=1 AND "+secuencias;

			reporte.DataDefinition.RecordSelectionFormula=SelectionStr;
			
			rptHelper.setPermission(reporte);
			string reportName = rptHelper.exportReport(reporte,"FormulacionColor",User.Identity.Name);

			string redirectPath=ConfigurationSettings.AppSettings["reportsWebPath"]+ reportName + ".pdf";

			//window.open('..\\..\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=270,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=yes,resizable=no");
			string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','Reporte', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>"; 
			Page.RegisterStartupScript("ClientScript",ScriptString);

			//Response.Redirect(redirectPath);
			

		}

		private void PrepareReportSeparate(string fechaInicial, string fechaFinal, int linea,int status, string secuencias)
		{
		
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			Production.WorkOrder.PartidasColor.ColorWOReportBySequence reporte = new Production.WorkOrder.PartidasColor.ColorWOReportBySequence();

			ParameterValues campoFecha= new ParameterValues();
			ParameterDiscreteValue valorFecha= new ParameterDiscreteValue();
			valorFecha.Value=string.Format("{0} al {1}",fechaInicial,fechaFinal);
			campoFecha.Add(valorFecha);
				
			reporte.DataDefinition.ParameterFields["Fecha"].ApplyCurrentValues(campoFecha);

			string	SelectionStr="";
			if(linea!=0)
				SelectionStr= "{ProgramaProduccion.IdLinea}="+linea.ToString()+" AND ";
			if(status!=0)
				SelectionStr+= "{OrdenesTrabajo.IdStatus}="+ status.ToString() +" AND ";

			SelectionStr+="{ProgramaProduccion.Fecha}>=Date("+DateTime.Parse(fechaInicial).ToString("yyyy")+","+DateTime.Parse(fechaInicial).ToString("MM")+","+DateTime.Parse(fechaInicial).ToString("dd")+")";
			SelectionStr+=" AND {ProgramaProduccion.Fecha}<=Date("+DateTime.Parse(fechaFinal).ToString("yyyy")+","+DateTime.Parse(fechaFinal).ToString("MM")+","+DateTime.Parse(fechaFinal).ToString("dd")+")";
			SelectionStr+=" AND {OrdenesTrabajo.IdArea}=1 AND "+secuencias;

			reporte.DataDefinition.RecordSelectionFormula=SelectionStr;
			
			rptHelper.setPermission(reporte);
			string reportName = rptHelper.exportReport(reporte,"FormulacionColor",User.Identity.Name);

			string redirectPath=ConfigurationSettings.AppSettings["reportsWebPath"]+ reportName + ".pdf";

			//window.open('..\\..\\Calendar.aspx?FormName=' + document.forms[0].name + '&CtrlName=' + CtrlName + '&txtDate=' + document.forms[0].elements[CtrlName].value, "PopUpCalendar", "width=270,height=300,top=200,left=200,toolbars=no,scrollbars=no,status=yes,resizable=no");
			string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','Reporte', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>"; 
			Page.RegisterStartupScript("ClientScript",ScriptString);

			//Response.Redirect(redirectPath);
			

		}

		/*** modificado por alejandro.hernandez@nasoft.com 01/03/2006 ***/
		//private void PrepareStickerReport(string secuencias)
		private void PrepareStickerReport()
//		private void PrepareStickerReport(string fechaInicial, string fechaFinal, int linea,int status, string secuencias)
		/*** fin de modificación ***/
		{		
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			CrystalDecisions.CrystalReports.Engine.ReportClass objReporte=null;
			objReporte = new WorkOrder.PartidasColor.NewEtiquetaColor();

			//objReporte = new WorkOrder.PartidasColor.NewEtiquetaColor2();
			rptHelper.setPermission(objReporte);
			string reportname = rptHelper.exportReport(objReporte, "StickerColor", User.Identity.Name);
			string redirectPath=ConfigurationSettings.AppSettings["reportsWebPath"]+ reportname + ".pdf";
			
			string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','Reporte', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>"; 
			Page.RegisterStartupScript("ClientScript",ScriptString);	
		}

		public void ConsultNextSecuencia(int ItemIndex,string ShortCut)
		{
			try
			{
				/* Aqui esta el problema */
				string secuance=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemSecuencia")).Text.ToString();
				SICALNet.BusinessEntities.SecuenciaCombinasInfo scInfo = new SICALNet.BusinessEntities.SecuenciaCombinasInfo(secuance,0);
				SICALNet.BusinessLogicLayer.SecuenciaCombinas blSC = new SICALNet.BusinessLogicLayer.SecuenciaCombinas();
				IList CombinasList=blSC.SelectSecuenciaCombinas(scInfo);
				int itemidx=0;
				if(CombinasList.Count==0)
				{
					string Cantidad=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemCantidad")).Text.ToString();
					string Status=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemIdStatus")).Text.ToString();
					string IdLinea=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemIdLinea")).Text.ToString(); 
					string Codigosap=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemCodigoSAP")).Text.ToString(); 
					string planta=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemIdPlanta")).Text.ToString(); 
					string Desc=((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemDescripcion")).Text.ToString(); 
					for(int i=1;i<(lstWorkOrder.Items.Count-ItemIndex);i++)
					{
						if(itemidx==ItemIndex)
						{
							if(((Label)lstWorkOrder.Items[ItemIndex+i].FindControl("ItemIdStatus")).Text.ToString()=="2")
								itemidx=ItemIndex+i;
						}
					}
					if(ItemIndex>=lstWorkOrder.Items.Count)
					{
						Response.Redirect("CNoOfVasos.aspx?RedFlag="+"0");
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
						SICALNet.BusinessLogicLayer.PartidasColor BLLPC=new SICALNet.BusinessLogicLayer.PartidasColor();
						if(BLLPC.IsExistSecuencia(secuance))
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
							Response.Redirect("ColorWOFinal.aspx?isNew=false&ShortCut=True");
						}
						else
						{
							SICALNet.Utilities.Validation pltVt = new SICALNet.Utilities.Validation();
							if(!pltVt.IsNumber(txtAforo.Text)||txtAforo.Text==""||txtAforo.Text==string.Empty)
								throw new Exception(" The Value of Aforo should be Numeric or Zero");
							int NoGroup = BLLPC.GetNoGroup(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"]));
							Session[this.Context.User.Identity.Name+"NoGroup"] = NoGroup;
							int[] NoVaso=new int[NoGroup];
							float[] Aforo = new float[NoGroup];
							int[] aryLaminas = new int[NoGroup];
							for(int i=0;i<NoGroup;i++)
							{
								NoVaso[i]=1;
								Aforo[i]=Convert.ToSingle(txtAforo.Text);
								aryLaminas[i]=Convert.ToInt32(Cantidad);
							}
							Session[this.Context.User.Identity.Name+"NoVaso"]=NoVaso;
							Session[this.Context.User.Identity.Name+"Aforo"]=Aforo;	
							Session[this.Context.User.Identity.Name+"VasoQty"] = aryLaminas;
							Session[this.Context.User.Identity.Name+"TotNoVaso"] = NoGroup;
							Response.Redirect("ColorWOFinal.aspx?isNew=true&ShortCut=True");							
						}
					}
					else	
					{
						//Response.Redirect("AditivosCuantos.aspx");
						string newURL = "NoOfVasos.aspx?Secuencia="+secuance+"&Cantidad="+Cantidad+"&IdLinea="+IdLinea+"&Status="+Status+"&Descripcion="+Desc;
						
						Session[this.Context.User.Identity.Name+"CodigoSAP"]= Codigosap;
						Response.Redirect(newURL);
					}
				}
				else
				{
					string UTEC  = ((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemDescripcion")).Text.ToString();
					string CodigoSAP = ((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemCodigoSAP")).Text.ToString();
					string IdStatus = ((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemIdStatus")).Text;
					string IdPlanta = ((Label)lstWorkOrder.Items[ItemIndex].FindControl("ItemIdPlanta")).Text;
					for(int i=1;i<(lstWorkOrder.Items.Count-ItemIndex);i++)
					{
						if(itemidx==ItemIndex)
						{
							if(((Label)lstWorkOrder.Items[ItemIndex+i].FindControl("ItemIdStatus")).Text.ToString()=="2")
								itemidx=ItemIndex+i;
						}
					}
					if(ItemIndex>=lstWorkOrder.Items.Count)
					{
						Response.Redirect("NoOfVasos.aspx?RedFlag="+"0");
						throw new Exception("There are no Secuencias to Consult furthur...."); 
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
					Session[this.Context.User.Identity.Name+"Fecha"] = Fecha;
					Session[this.Context.User.Identity.Name+"UTEC"]  = UTEC;
					Session[this.Context.User.Identity.Name+"CodigoSAP"] = CodigoSAP;
					Session[this.Context.User.Identity.Name+"IdStatus"] = IdStatus;
					Session[this.Context.User.Identity.Name+"IdPlanta"] = IdPlanta;
					Session[this.Context.User.Identity.Name+"FormularFlag"]=CombinasList.Count;
					Session[this.Context.User.Identity.Name+"ItemIndex"]=itemidx;
					if(ShortCut=="True")
					{
						SICALNet.BusinessLogicLayer.PartidasColor BLLPC = new SICALNet.BusinessLogicLayer.PartidasColor();
						//string[] secuencia = (string[])Session[this.Context.User.Identity.Name+"Secuencia"];
						if(BLLPC.IsExistSecuencia(secuencia[0]))
						{
							//SICALNet.BusinessEntities.OrdenesTrabajoInfo OInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(secuencia[0],Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),0);
							//SICALNet.BusinessLogicLayer.OrdenesTrabajo blOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
							//int Status=blOrdenes.GetStatus(OInfo);
							//Session[this.Context.User.Identity.Name+"IdStatus"] = Status;
						
							IList pcList = (IList) BLLPC.GetNoVaso(secuencia[0]);
							Session[this.Context.User.Identity.Name+"NoGroup"] = pcList.Count.ToString();
							/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
							StringBuilder sec = new StringBuilder("'");
							//string sec="'";
							for(int i=0;i<secuencia.Length;i++)
							{
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
								
								/*** fin modificación ***/
							}
							IList RsPC=(IList) BLLPC.GetLaminasCombined(sec.ToString());
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
							Response.Redirect("ColorWOFinal.aspx?isNew=false&ShortCut=True");
						}
						else
						{
							SICALNet.Utilities.Validation pltVt = new SICALNet.Utilities.Validation();
							if(!pltVt.IsNumber(txtAforo.Text)||txtAforo.Text==""||txtAforo.Text==string.Empty)
								throw new Exception(" The Value of Aforo should be Numeric or Zero");
							int NoGroup = BLLPC.GetNoGroup(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"]));
							Session[this.Context.User.Identity.Name+"NoGroup"] = NoGroup;
							int[] NoVaso=new int[NoGroup];
							float[] Aforo = new float[NoGroup];
							int[] aryLaminas = new int[NoGroup];
							int CantidadSum=0;
							for(int i=0;i<Cantidad.Length;i++)
								CantidadSum+=Cantidad[i];
							for(int i=0;i<NoGroup;i++)
							{
								NoVaso[i]=1;
								Aforo[i]=Convert.ToSingle(txtAforo.Text);
								aryLaminas[i]=CantidadSum;
							}
							Session[this.Context.User.Identity.Name+"NoVaso"]=NoVaso;
							Session[this.Context.User.Identity.Name+"Aforo"]=Aforo;	
							Session[this.Context.User.Identity.Name+"VasoQty"] = aryLaminas;
							Session[this.Context.User.Identity.Name+"TotNoVaso"] = NoGroup;
							Response.Redirect("ColorWOFinal.aspx?isNew=true&ShortCut=True");	
						}
					}
					else
						Response.Redirect("NoOfVasos.aspx?Room=Color&Descripcion="+UTEC);
				}

			}
			catch
			{
				throw;

			}
		}

		private void BindChildGrids(string secuencia, int Status)
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
			//string secuencia=((Label)lstWorkOrder.Items[i].FindControl("ItemSecuencia")).Text.ToString();
			//int Status =Convert.ToInt32(((Label)lstWorkOrder.Items[i].FindControl("ItemIdStatus")).Text.ToString());

			SICALNet.BusinessLogicLayer.PartidasColor BLLPC=new SICALNet.BusinessLogicLayer.PartidasColor();
			IList RsPC=(IList) BLLPC.GetLaminas(secuencia);
			DataList lstLaminas=((DataList)lstWorkOrder.Items[i].FindControl("dstLaminas"));
			((ImageButton) lstWorkOrder.Items[i].FindControl("aspPlus")).Visible=false; 
			((System.Web.UI.WebControls.Image) lstWorkOrder.Items[i].FindControl("jsPlus")).Visible=true; 

			if (RsPC.Count > 0)
			{
				lstLaminas.DataSource = RsPC;
				lstLaminas.DataBind();
				lstLaminas.Visible=lstLaminas.Items.Count>0;
			}
			for(int inloop=0;inloop<RsPC.Count;inloop++)
			{
				SICALNet.BusinessEntities.PartidasColorInfo bePCol = new SICALNet.BusinessEntities.PartidasColorInfo();
				bePCol=(SICALNet.BusinessEntities.PartidasColorInfo)RsPC[inloop];
				SICALNet.BusinessLogicLayer.PartidasColor blPCol=new SICALNet.BusinessLogicLayer.PartidasColor();
				IList VasoList=blPCol.Load(secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),bePCol.VasoNo,0);
				DataGrid dgdColor = ((DataGrid)lstLaminas.Items[inloop].FindControl("dgdColorWO"));
				dgdColor.DataSource=VasoList;
				dgdColor.DataBind();
				if(Status==5)
				{
					dgdColor.Columns[5].Visible=true;
					dgdColor.Columns[7].Visible=true;
					dgdColor.Columns[4].Visible=false;
					dgdColor.Columns[6].Visible=false;
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

		private void printRegularStickers()
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
				string ScriptString = "<script language = 'javascript'> alert('Seleccione una secuencia para generar un reporte'); </script>"; 
				Page.RegisterStartupScript("ClientScript",ScriptString);
				
				return;
			}

			SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["SICALConnString"],CommandType.Text,"Truncate table Tempo;");
			StringBuilder SecuenciaStr = new StringBuilder();
			for(int k=0;k<i;k++)
			{
				string sSecuenciaAdicional = "PP.Secuencia='" + secuencia[k].ToString() + "'";
				string sProc = "Exec sp_sicalnet_Reportes_NuevaEtiquetaColor @Secuencia=\"" + sSecuenciaAdicional + "\"";
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["SICALConnString"],CommandType.Text,sProc);				
			}
			PrepareStickerReport();
			
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
				StringBuilder SecuenciaStr = new StringBuilder();
//				string SecuenciaStr=string.Empty;
				for(int k=0;k<i;k++)
				{					
					SecuenciaStr.Append("{vw_Tarjeta_Formulacion_Aditivos.Secuencia} = '").Append(secuencia[k]).Append("'");					
					if(k!=(i-1))
					{
						SecuenciaStr.Append(" OR ");
//						SecuenciaStr+=" OR ";
					}
				}

				PrepareNewStickerReport(SecuenciaStr.ToString(),TipoEtiqueta.StickerAditivog);
				/*** fin modificación ***/

				// secuencias combinadas de aditivos

				// se arma la cadena del select que se mandar al sp para devolver los
				// numeros de GrupoCombinado

				/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
				StringBuilder SecuenciaspStr = new StringBuilder();
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
				SecuenciaStr=new StringBuilder();
				int fin;
				fin = grupos.Count;

				for(int k=0;k<fin;k++)
				{				
					SecuenciaStr.Append("{vw_Tarjeta_Formulacion_Aditivos_Comb.GrupoCombinado} = ").Append(grupos[k]);
//						SecuenciaStr+="{vw_Tarjeta_Formulacion_Aditivos_Comb.GrupoCombinado} = "+grupos[k];
									
					if(k!=(fin-1))
					{
						SecuenciaStr.Append(" OR ");
//						SecuenciaStr+=" OR ";
					}
				}
				if (SecuenciaStr.ToString() != "")
					PrepareNewStickerReport(SecuenciaStr.ToString(),TipoEtiqueta.StickerAditivo);

////				//primera
////				PrepareNewStickerReport(SecuenciaStr,TipoEtiqueta.StickerAditivo);
////				//segunda
//				SecuenciaStr=string.Empty;
//				for(int k=0;k<i;k++)
//				{					
//					SecuenciaStr+="{vw_Tarjeta_Formulacion_Aditivos.Secuencia} = '"+secuencia[k]+"'";
//						
//					if(k!=(i-1))
//						SecuenciaStr+=" OR ";
//				}
//
//				PrepareNewStickerReport(SecuenciaStr,TipoEtiqueta.StickerAditivog);
				
				// etiquetas de color
				SecuenciaStr=new StringBuilder();
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
				/*** fin modificación ***/
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
					//objReporte = new Reports.Produccion.StickerAditivosrelf();					
					//objReporte = new Reports.Produccion.StickerAditivosrel();					
					break;
				case TipoEtiqueta.StickerAditivog:										
				objReporte = new Reports.Produccion.StickerAditivosrelg();					
			    break;
			}
		
			// ParameterFields crParams = new ParameterFields();

			ParameterValues rptParams= new ParameterValues();
			ParameterDiscreteValue userParam= new ParameterDiscreteValue();
			// ParameterDiscreteValue PlantaParam= new ParameterDiscreteValue();
			ParameterDiscreteValue ReimpresionParam= new ParameterDiscreteValue();

			//se obtiene el nombre del usuario autenticado
			SICALNet.BusinessEntities.UsuarioInfo objUsuarioInfo = new SICALNet.BusinessEntities.UsuarioInfo(User.Identity.Name);
			SICALNet.BusinessLogicLayer.Usuario objUsuario = new SICALNet.BusinessLogicLayer.Usuario();
			SICALNet.BusinessEntities.UsuarioInfo objUser = objUsuario.Load(objUsuarioInfo);
			userParam.Value = objUser.Nombre;

//			string planta=(objUser.IdPlanta==1?"OCO":"SLP");
//			PlantaParam.Value=planta;

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
//					//secuencias combinadas
//					if (secuencias != "")
//					objReporte.DataDefinition.RecordSelectionFormula="(" + secuencias + ") AND (isnull({vw_Tarjeta_Formulacion_Aditivos_Comb.EtiquetaColor}) OR {vw_Tarjeta_Formulacion_Aditivos_Comb.EtiquetaColor}=false)";				
//					else
//					objReporte.DataDefinition.RecordSelectionFormula=" (isnull({vw_Tarjeta_Formulacion_Aditivos_Comb.EtiquetaColor}) OR {vw_Tarjeta_Formulacion_Aditivos_Comb.EtiquetaColor}=false)";				

					//secuencias combinadas
					if (secuencias != "")
						objReporte.DataDefinition.RecordSelectionFormula= secuencias;
						//objReporte.DataDefinition.RecordSelectionFormula= secuencias + " AND {vw_Tarjeta_Formulacion_Aditivos_Comb.EtiquetaColor} IS NULL OR {vw_Tarjeta_Formulacion_Aditivos_Comb.EtiquetaColor}=0";				
					else
						objReporte.DataDefinition.RecordSelectionFormula=" ({vw_Tarjeta_Formulacion_Aditivos_Comb.EtiquetaColor} IS NULL OR {vw_Tarjeta_Formulacion_Aditivos_Comb.EtiquetaColor}=0)";				

				}
			}
			else
			{
				objReporte.DataDefinition.RecordSelectionFormula="(" + secuencias + ")";
			}
		
			rptHelper.setPermission(objReporte);
			string reportname = rptHelper.exportReport(objReporte, tipoEtiqueta.ToString(), User.Identity.Name);
			string redirectPath=ConfigurationSettings.AppSettings["reportsWebPath"]+ reportname + ".pdf";
			string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','"+tipoEtiqueta.ToString()+"', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>"; 
			Page.RegisterClientScriptBlock("ClientScript_"+tipoEtiqueta.ToString(),ScriptString);
			//se evaluar el estatus de impresión
			//this.CheckPrintStatus(tipoEtiqueta);
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
				if (lblStatus.Text == ConfigurationSettings.AppSettings["StatusCancel"]) 
					e.Item.BackColor = Color.Tomato;

			}
		}

		private void btnCard_Click(object sender, System.EventArgs e)
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
						"alert('Seleccione una secuencia para generar una tarjeta');</script>");

					return;
				}
				/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
				StringBuilder SecuenciaStr = new StringBuilder();
				//string SecuenciaStr = string.Empty;								
				for(int k=0;k<i;k++)
				{
					SecuenciaStr = SecuenciaStr.Append("{VistaSecuenciasSimples1.Secuencia}='").Append(secuencia[k]).Append("'");
					//SecuenciaStr+="{VistaSecuenciasSimples1.Secuencia}='"+secuencia[k]+"'";
					if(k!=(i-1))
					{
						SecuenciaStr.Append(" OR ");
						//SecuenciaStr+=" OR ";
					}
				}

				if(SecuenciaStr.Length > 0)
				{
					SecuenciaStr.Insert(0,"(").Append(")");
					//SecuenciaStr = "(" + SecuenciaStr + ")";
				}

				/*** fin modificación ***/
				PrepareCardReport(SecuenciaStr.ToString(), int.Parse(this.cboLinea.SelectedValue));
				
			}
			catch
			{
				throw;

			}		
		}

		private void PrepareCardReport(string secuencias,  int idLinea)
		{
			// Limpieza de cache
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetNoStore();
			Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
			Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
			Response.Cache.SetValidUntilExpires(false);

			try
			{
				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);

				/*********************************************/
				// Procedimiento adicionado para agregar mezclas a la tarjeta de formulación
				// JJMR Adición para agregar datos al reporte 
				string ListaSecuencia="";
				ListaSecuencia = secuencias.Replace("{VistaSecuenciasSimples1.Secuencia}=", " ");
				ListaSecuencia = ListaSecuencia.Replace("OR", ",");
				ListaSecuencia = ListaSecuencia.Replace("(", "");
				ListaSecuencia = ListaSecuencia.Replace(")", "");
				ListaSecuencia = ListaSecuencia.Replace("'", "");
				
				TruncaRep_PMMA_TarjetaFormulacion();			// Trunca tabla Rep_PMMA_TarjetaFormulacion
				TruncaRep_PMMA_TarjetaFormulacion_Sludy();	// Trunca tabla Rep_PMMA_TarjetaFormulacion_Sludy

				string [] split = ListaSecuencia.Split(new Char [] {','});
				foreach (string s in split) 
				{
					if (s.Trim() != "")
						InsertaPMMA(s.Trim());		// Inserta en la tabla Rep_PMMA_TarjetaFormulacion	
						ActualizaPMMA(s.Trim());	// Actualiza los campos SumaColorAditivos y Laminas en la tabla Rep_PMMA_TarjetaFormulacion						
				}
				/*********************************************/
				//Proc_ActualizaSumaColorAditivos();
				string textoReporte = string.Empty;

				//Planta OCO
				if (theUser.IdPlanta.Equals(1))
				{
					textoReporte = ConfigurationSettings.AppSettings["TextoOCO"];
				}
				else
				{
					textoReporte = ConfigurationSettings.AppSettings["TextoSLP"];
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
					//reporte.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Simplex;
					//reporte.PrintOptions.
					
//					Production.WorkOrder.PartidasColor.RepContenedor reporte = new Production.WorkOrder.PartidasColor.RepContenedor();
//					secuencias = secuencias + " AND ({VistaSecuenciasSimples1.CodigoSAP}<>'23372')";
//					reporte.DataDefinition.ParameterFields["CadenaTexto"].ApplyCurrentValues(campoCadenaTexto);
//					reporte.DataDefinition.RecordSelectionFormula=secuencias;

					// *************************
					//reporte.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
					//reporte.PrintOptions.PaperSize =  PaperSize.PaperStatement;					
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

				string redirectPath=ConfigurationSettings.AppSettings["reportsWebPath"]+ reportName + ".pdf";			
				string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','Reporte', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>"; 
				Page.RegisterStartupScript("ClientScript",ScriptString);
			}
			catch
			{
				throw;
			}
		}
	
		private void btnPreform_Click(object sender, System.EventArgs e)
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
						"alert('Seleccione una secuencia para preformular');</script>");

					return;
				}
				/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
				StringBuilder SecuenciaStr = new StringBuilder();
				for(int k=0;k<i;k++)
				{
					SecuenciaStr= SecuenciaStr.Append("'").Append(secuencia[k]).Append("'");
					//SecuenciaStr+="'"+secuencia[k]+"'";
					if(k!=(i-1))
					{
						SecuenciaStr.Append(",");
					}
				}

				Preformular(SecuenciaStr.ToString());
			    // Registrando en bitácora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Se registra evento de Preformulación en Ordenes de Trabajo Fase Color para la secuencia '" + SecuenciaStr.ToString() + "'",Page.User.Identity.Name.ToString());
				
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
				LoadWorkOrders(txtInitial.Text,txtFinal.Text);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// An internal function to get the database parameters for select and delete
		/// </summary>
		/// <returns>Parameter array</returns>
		private static SqlParameter[] GetUserParaSingle() 
		{			
			SqlParameter[] parms = SqlHelperParameterCache.GetCachedParameterSet(ConfigurationSettings.AppSettings["SICALConnString"],PROC_INSERTAPMAA_TARJETAFORMULACION);
			if (parms == null) 
			{
				parms = new SqlParameter[] {
											   new SqlParameter(SECUENCIA, SqlDbType.VarChar, 10)};

				SqlHelperParameterCache.CacheParameterSet(ConfigurationSettings.AppSettings["SICALConnString"],PROC_INSERTAPMAA_TARJETAFORMULACION, parms);
			}
			return parms;
		}

		public void TruncaRep_PMMA_TarjetaFormulacion()
		{	
			using (SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["SICALConnString"])) 
			{
				conn.Open();
				using (SqlTransaction trans = conn.BeginTransaction()) 
				{
					try 
					{
						SqlHelper.ExecuteNonQuery(trans, CommandType.Text, "Delete from Rep_PMMA_TarjetaFormulacion");
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
			using (SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["SICALConnString"])) 
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

		public void Proc_CalculoPmma(string secuencia)
		{
			SqlParameter[] UserParms = GetUserParaSingle();
			UserParms[0].Value=secuencia;	
			using (SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["SICALConnString"])) 
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
			using (SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["SICALConnString"])) 
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

		public void Proc_ActualizaSumaColorAditivos()
		{		
			using (SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["SICALConnString"])) 
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

		public void ActualizaPMMA(string secuencia)
		{
			SqlParameter[] UserParms = GetUserParaSingle();
			UserParms[0].Value=secuencia;
			
			using (SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["SICALConnString"])) 
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


	}
}
