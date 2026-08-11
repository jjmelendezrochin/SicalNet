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

using CYBERAKT.WebControls.Navigation;
using SICALNet.BusinessEntities;

namespace UserInterface.Forms.Production.WorkOrder.PartidasColor
{
	/// <summary>
	/// Summary description for ColorWOFinal.
	/// </summary>
	public class ColorWOFinal : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtSecuencia;
		protected System.Web.UI.WebControls.TextBox txtUTEC;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected CYBERAKT.WebControls.Navigation.ASPnetMenu tabColor;
		protected System.Web.UI.WebControls.DataGrid dgdColorWO;
		protected System.Web.UI.WebControls.TextBox txtPiso;
		protected System.Web.UI.WebControls.Button btnAgregarMensaje;
		protected System.Web.UI.WebControls.Button btnAceptar;
		protected System.Web.UI.WebControls.Button btnImprimir;
		protected System.Web.UI.WebControls.Button btnLiberar;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		//protected static ArrayList[] ColorList;
		protected static int prvSelected, iVaso, totVaso;
		protected static int[] iVasoQty, newVasoQty;
		protected static ArrayList[] SecuenciaList;
		protected static ArrayList[] SecuenciaLaminasList;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnAditivos;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Label Label8;
		protected static string ShortCut="False";
		//protected double rendimientoColor=1;

		private void Page_Load(object sender, System.EventArgs e)
		{
						
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);
					
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				btnAditivos.Attributes.Add("onClick","showWaitControls()");
				btnAgregarMensaje.Attributes.Add("onClick","showWaitControls()");
				btnImprimir.Attributes.Add("onClick","showWaitControls()");
				btnLiberar.Attributes.Add("onClick","showWaitControls()");
				btnAceptar.Attributes.Add("onClick","showWaitControls()");
				btnCancel.Attributes.Add("onClick","showWaitControls()");

				iVaso = Convert.ToInt32(Session[this.Context.User.Identity.Name+"TotNoVaso"]); 
				prvSelected = 0; //To Set the Default TAB Selection as First
				totVaso = iVaso;
				if(Request.QueryString["ShortCut"]!=null)
					ShortCut=Request.QueryString["ShortCut"];
				iVasoQty = new int[iVaso];
				iVasoQty = (int[]) Session[this.Context.User.Identity.Name+"VasoQty"];
				if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
				{
					txtSecuencia.Text = Session[this.Context.User.Identity.Name+"Secuencia"].ToString();
					txtFecha.Text = Session[this.Context.User.Identity.Name+"Fecha"].ToString();
					txtUTEC.Text = Session[this.Context.User.Identity.Name+"UTEC"].ToString();
					txtCantidad.Text  = Session[this.Context.User.Identity.Name+"Cantidad"].ToString();
				}
				else
				{
					string[] Secuencia = (string[]) Session[this.Context.User.Identity.Name+"Secuencia"];
					int[] Cantidad = (int[]) Session[this.Context.User.Identity.Name+"Cantidad"];
					string[] Fecha = (string[])Session[this.Context.User.Identity.Name+"Fecha"];
					txtUTEC.Text=Session[this.Context.User.Identity.Name+"UTEC"].ToString();
					float CantidadSum=0;
					for(int i=0;i<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);i++)
					{
						txtSecuencia.Text+=Secuencia[i]+",";
						txtFecha.Text+=Fecha[i]+",";
						CantidadSum+=Cantidad[i];
					}
					txtCantidad.Text=CantidadSum.ToString();
				}
				SecuenciaList = new ArrayList[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
				SecuenciaLaminasList = new ArrayList[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
				LoadGrid(); //To Load the Data into Grid
				CreateTabctripControl(totVaso); //To Create the TAB Control
				if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()!="0")
					SaparateCantidad();
				if(Session[this.Context.User.Identity.Name+"IdStatus"].ToString()=="5")
				{
					btnAceptar.Enabled=false;
					btnLiberar.Enabled=false;
					dgdColorWO.Columns[4].Visible=false;
					dgdColorWO.Columns[5].Visible=true;
					dgdColorWO.Columns[7].Visible=false;
					dgdColorWO.Columns[8].Visible=true;

				}

				// Display the Messages in Multiline Text box
				DisplayFloorMessage();				
			}
			else
			{
				iVaso = Convert.ToInt32(Session[this.Context.User.Identity.Name+"TotNoVaso"]); 
				totVaso = iVaso;
				if(Request.QueryString["ShortCut"]!=null)
					ShortCut=Request.QueryString["ShortCut"];
				iVasoQty = new int[iVaso];
				iVasoQty = (int[]) Session[this.Context.User.Identity.Name+"VasoQty"];
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
			//rendimientoColor=Convert.ToDouble(ConfigurationSettings.AppSettings["RendimientoColor"]);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.tabColor.MenuItemSelected += new CYBERAKT.WebControls.Navigation.ASPnetMenu.MenuItemSelectedEvent(this.tabColor_MenuItemSelected);
			this.dgdColorWO.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdColorWO_ItemDataBound);
			this.dgdColorWO.SelectedIndexChanged += new System.EventHandler(this.dgdColorWO_SelectedIndexChanged);
			this.btnAditivos.Click += new System.EventHandler(this.btnAditivos_Click);
			this.btnAgregarMensaje.Click += new System.EventHandler(this.btnAgregarMensaje_Click);
			this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
			this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void LoadGrid()
		{
			ArrayList[] theColorList;

			SICALNet.BusinessLogicLayer.PartidasColor PColor = new SICALNet.BusinessLogicLayer.PartidasColor();
			bool IsExist;
			/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
			System.Text.StringBuilder sec = new System.Text.StringBuilder("'");
//			string sec="'";
			float[] Aforo = (float[])Session[this.Context.User.Identity.Name+"Aforo"];
			if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
				IsExist = PColor.IsExistSecuencia(txtSecuencia.Text);
			else
			{
				string[] secuencia = (string[]) Session[this.Context.User.Identity.Name+"Secuencia"];
				
				for(int i=0;i<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);i++)
				{
					sec.Append(secuencia[i]);
//					sec+=secuencia[i];
					if(i==(Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])-1))
					{
						sec.Append("'");
//						sec+="'";
					}
					else
					{
						sec.Append("','");
//						sec+="','";
					}
				}
				IsExist = PColor.IsExistSecuencia(secuencia[0]);
			}
			
			bool isNew = Convert.ToBoolean(Request.QueryString["isNew"]);
			if (!IsExist || isNew )
			{
				if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()!="0")
					SaparateLaminas();
				ArrayList FormColor = new ArrayList();
				SICALNet.BusinessLogicLayer.PartidasColor PartidasColor = new SICALNet.BusinessLogicLayer.PartidasColor();				

				SICALNet.BusinessEntities.PlantaInfo PlantaInfo = new PlantaInfo(Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"].ToString()),"","",0);
				SICALNet.BusinessLogicLayer.Planta BLPlanta = new SICALNet.BusinessLogicLayer.Planta();
				PlantaInfo = BLPlanta.Load(PlantaInfo);


				double BaseThickness = PartidasColor.GetBaseThickness(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(), Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"].ToString()));
				double ProductThickness = PartidasColor.GetProductThickness(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(), Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"].ToString()));
				double ProductWeight = PartidasColor.GetProductWeight(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(), Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"].ToString()));
				
				theColorList = new ArrayList[iVaso]; 
				int cIndex = 0;

				int[] NoVaso =(int[])Session[this.Context.User.Identity.Name+"NoVaso"];
				for (int i = 0; i < Convert.ToInt32(Session[this.Context.User.Identity.Name+"NoGroup"].ToString()); i++)
				{
					
					FormColor = (ArrayList) PartidasColor.GetFormColor(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),i+1,Aforo[i],Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"].ToString()),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdLinea"].ToString()) );
					for (int j = 0; j < NoVaso[i]; j++)
					{
						ArrayList tmpList = new ArrayList();
						for(int k=0; k < FormColor.Count; k++)
						{
							PartidasColorInfo pcInfo = new PartidasColorInfo();
							pcInfo = (PartidasColorInfo) FormColor[k];
							
							double Percentage = Convert.ToDouble(pcInfo.Porcentaje);
							/* Adding message from Form Color */
							/* 
							txtPiso.Text += 
							txtPiso.Text += "\n";
                            */
							
							// JJMR 
							// CALCULO DE CANTIDAD
							//PartidasColorInfo pcInfo1 = new PartidasColorInfo(pcInfo.CodigoSAP, pcInfo.Descripcion, Convert.ToDecimal((iVasoQty[cIndex] * (((Percentage * BaseThickness)/ProductThickness)*ProductWeight/100*1000))/rendimientoColor), 0, pcInfo.Grupo,pcInfo.LotePasta,Aforo[i]);
							PartidasColorInfo pcInfo1 = new PartidasColorInfo(pcInfo.CodigoSAP, pcInfo.Descripcion, Convert.ToDecimal((iVasoQty[cIndex] * (((Percentage * BaseThickness)/ProductThickness)*ProductWeight/100*1000))/PlantaInfo.RendimientoColor), 0, pcInfo.Grupo,pcInfo.LotePasta,Aforo[i]);
							tmpList.Add(pcInfo1);
						}
						theColorList[cIndex++] = (ArrayList) tmpList;
					}
				}

				/*
								//new code starts
								int cIndex = 0; //ColorList Index
								int NoGroup = PartidasColor.GetNoGroup(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString());

								//totVaso = iVaso * NoGroup;

								totVaso = iVaso;

								ColorList = new ArrayList[totVaso]; 
								for(int i = 0; i < iVaso; i++)
								{
									int k = 0;
									// To Get the Initial Group No
									PartidasColorInfo tmpPCInfo = new PartidasColorInfo();
									tmpPCInfo = (PartidasColorInfo) FormColor[k];
									int CurGroup = tmpPCInfo.Grupo;

									ArrayList tmpList = new ArrayList();
					
									for(; k <= FormColor.Count; k++)
									{
										if (k < FormColor.Count)
										{
											PartidasColorInfo pcInfo = new PartidasColorInfo();
											pcInfo = (PartidasColorInfo) FormColor[k];
											if (CurGroup != pcInfo.Grupo) 
											{
												ColorList[cIndex++] = (ArrayList) tmpList;
												CurGroup = pcInfo.Grupo;
								
												tmpList = new ArrayList();
								
												double Percentage = Convert.ToDouble(pcInfo.Porcentaje);
												PartidasColorInfo pcInfo1 = new PartidasColorInfo(pcInfo.CodigoSAP, pcInfo.Descripcion, Convert.ToDecimal(iVasoQty[i] * (((Percentage * BaseThickness)/ProductThickness)*ProductWeight/100*1000)), 0, pcInfo.Grupo);
												tmpList.Add(pcInfo1);
											}
											else
											{
												double Percentage = Convert.ToDouble(pcInfo.Porcentaje);
												PartidasColorInfo pcInfo1 = new PartidasColorInfo(pcInfo.CodigoSAP, pcInfo.Descripcion, Convert.ToDecimal(iVasoQty[i] * (((Percentage * BaseThickness)/ProductThickness)*ProductWeight/100*1000)), 0, pcInfo.Grupo);
												tmpList.Add(pcInfo1);
											}
										}
										else
										{
											ColorList[cIndex++] = (ArrayList) tmpList;
										}
									}
								}

								//new code ends
				*/

				/*
								ColorList = new ArrayList[iVaso];
								for(int i=0; i < iVaso; i++)
								{
									ArrayList tmpList = new ArrayList();
									for(int j=0; j < FormColor.Count; j++)
									{
										PartidasColorInfo pcInfo = new PartidasColorInfo();
										pcInfo = (PartidasColorInfo) FormColor[j];
										double Percentage = Convert.ToDouble(pcInfo.Porcentaje);
					
										PartidasColorInfo pcInfo1 = new PartidasColorInfo(pcInfo.CodigoSAP, pcInfo.Descripcion, Convert.ToDecimal(iVasoQty[i] * (((Percentage * BaseThickness)/ProductThickness)*ProductWeight/100*1000)), 0);
										tmpList.Add(pcInfo1);
									}
									ColorList[i] = tmpList;
								} 
				*/
				
				//Upload resulting color list to Session
				Session[this.Context.User.Identity.Name+"ListaColores"]=theColorList;

				dgdColorWO.DataSource = theColorList[prvSelected];
				dgdColorWO.DataBind();
			}
			else
			{
				theColorList = new ArrayList[iVaso];
				int[] NoVaso = (int[])Session[this.Context.User.Identity.Name+"NoVaso"];
				if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()!="0")
				{
					string[] Secuencia = (string[])Session[this.Context.User.Identity.Name+"Secuencia"];
					for(int i=0;i<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);i++)
					{
						SICALNet.BusinessLogicLayer.PartidasColor PartidasColor = new SICALNet.BusinessLogicLayer.PartidasColor();
						IList SecuenciaVasoList=(IList)PartidasColor.LoadEachLaminaCombined(Secuencia[i],Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]));
						SecuenciaLaminasList[i]=(ArrayList)SecuenciaVasoList;
						
					}
				}
				
				int k=1;
				for (int i = 0,j=0; i <iVaso; i++,k++)
				{					
					if(NoVaso[j]<k)
					{
						j++;
						k=1;
					}
					SICALNet.BusinessLogicLayer.PartidasColor PartidasColor = new SICALNet.BusinessLogicLayer.PartidasColor();
					IList tmpList;
					if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
						tmpList = PartidasColor.Load(txtSecuencia.Text, Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]), i + 1,Aforo[j]);
					else
						tmpList = PartidasColor.LoadCombined(sec.ToString(),Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]), i + 1,Aforo[j]);
					if (tmpList.Count > 0)
					{
						theColorList[i] = (ArrayList) tmpList;
						if(i == 0)
						{
							dgdColorWO.DataSource = theColorList[i];
							dgdColorWO.DataBind();		
						}
					}
				}
				//Upload resulting color list to Session
				Session[this.Context.User.Identity.Name+"ListaColores"]=theColorList;

			}
		}

		private void CreateTabctripControl(int NoTABs)
		{
            CYBERAKT.WebControls.Navigation.MenuItem newItem;
			float[] Aforo = (float[])Session[this.Context.User.Identity.Name+"Aforo"];
			int[] NoVaso = (int[])Session[this.Context.User.Identity.Name+"NoVaso"];
			int k=1;
			for (int iLoop = 1,j=0; iLoop <= NoTABs; iLoop++,k++)
			{
				if(NoVaso[j]<k)
				{
					j++;
					k=1;
				}
				newItem = tabColor.TopGroup.Items.Add();
				newItem.Label = string.Format("<center> Vaso {0} <br><i> ({1} láminas) </i><br><i> {2} Aforo </i></center>", iLoop.ToString(),iVasoQty[iLoop-1].ToString(),Aforo[j]);
				newItem.SelectedCssClass="SelectedMenuItem";
				newItem.ID = Convert.ToString(iLoop-1);
			}
			tabColor.TopGroup.Items[0].IsSelected =  true;
		}

		
		private void DisplayFloorMessage()
		{
			string[] secuencias = txtSecuencia.Text.Split(Convert.ToChar(","));

			for (int i=0;i<secuencias.Length;i++)
			{
			// Display the messages
				SICALNet.BusinessLogicLayer.PartidasColor PartidasColor = new SICALNet.BusinessLogicLayer.PartidasColor();			
				string mensaje = PartidasColor.GetMessageFormColor(secuencias[i].ToString());
				txtPiso.Text += mensaje;
				txtPiso.Text += "\n";
				txtPiso.Text += "\n";

			// Display the Messages in Multiline Text box

				MensajePisoInfo mpInfo = new MensajePisoInfo(secuencias[i].ToString(),string.Empty,Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]));
			SICALNet.BusinessLogicLayer.MensajePiso mPiso = new SICALNet.BusinessLogicLayer.MensajePiso();
					
			IList mPisoList = mPiso.Select(mpInfo);
			if(mPisoList.Count>0)
			{
				for(int iloop=0; iloop<mPisoList.Count; iloop++)
				{	
					MensajePisoInfo mpInfo1 = new MensajePisoInfo();
					mpInfo1 = (MensajePisoInfo)mPisoList[iloop];
					txtPiso.Text += mpInfo1.Mensaje.ToString();
					txtPiso.Text += "\n";
				}
			}
		}

		}

		private void tabColor_MenuItemSelected(object sender, CYBERAKT.WebControls.Navigation.MenuItemSelectedEventArgs e)
		{
			ArrayList[] theColorList=(ArrayList[])Session[this.Context.User.Identity.Name+"ListaColores"];

			theColorList[prvSelected].Clear();
			for(int i = 0; i < dgdColorWO.Items.Count; i++)
			{
				string CodigoSAP = ((Label)dgdColorWO.Items[i].FindControl("lblCodigoSAP")).Text;
				string Descripcion = ((Label)dgdColorWO.Items[i].FindControl("lblDescripcion")).Text;
				decimal Cantidad = Convert.ToDecimal(((Label)dgdColorWO.Items[i].FindControl("lblCantidad")).Text);
				decimal CantidadReal;
				if (Session[this.Context.User.Identity.Name+"IdStatus"].ToString()=="5")
					CantidadReal = Convert.ToDecimal(((Label)dgdColorWO.Items[i].FindControl("lblRegistro")).Text);
				else					
					CantidadReal = Convert.ToDecimal(((TextBox)dgdColorWO.Items[i].FindControl("txtRegistro")).Text);
				string LotePasta;
				if (Session[this.Context.User.Identity.Name+"IdStatus"].ToString()=="5")
					LotePasta = ((Label)dgdColorWO.Items[i].FindControl("lblLotePasta")).Text;
				else					
					LotePasta = ((TextBox)dgdColorWO.Items[i].FindControl("txtLotePasta")).Text;

				int Grupo = Convert.ToInt32(((Label)dgdColorWO.Items[i].FindControl("lblGrupo")).Text);
				float Aforo = Convert.ToSingle(((Label)dgdColorWO.Items[i].FindControl("lblAforo")).Text);

				SICALNet.BusinessEntities.PartidasColorInfo  pcInfo = new SICALNet.BusinessEntities.PartidasColorInfo(CodigoSAP,Descripcion,Cantidad,CantidadReal,Grupo,LotePasta,Aforo);
				theColorList[prvSelected].Add(pcInfo);
			}
			// Get the Current TAB Number
			//prvSelected = Convert.ToInt32(e.Item.Label.Substring(e.Item.Label.IndexOf(" ",0)))-1;
			prvSelected = Convert.ToInt32(e.Item.ID);

			Session[this.Context.User.Identity.Name+"ListaColores"]=theColorList;
			dgdColorWO.DataSource = theColorList[prvSelected];
			dgdColorWO.DataBind();
		}

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (SaveWorkOrderData())
				{
					if(Request.Form["txtHidden"].ToString()=="true")
						Response.Redirect("ConsultColorWO.aspx?RedFlag=true&ShortCut="+ShortCut);
					else
						Response.Redirect("ConsultColorWO.aspx");
				}
			}
			catch
			{
				throw;
			}
		}

		private bool SaveWorkOrderData()
		{
			ArrayList[] theColorList = (ArrayList[])Session[this.Context.User.Identity.Name+"ListaColores"];

			//To Save the Current TAB Information
			theColorList[prvSelected].Clear();
			for(int i = 0; i < dgdColorWO.Items.Count; i++)
			{
				string CodigoSAP = ((Label)dgdColorWO.Items[i].FindControl("lblCodigoSAP")).Text;
				string Descripcion = ((Label)dgdColorWO.Items[i].FindControl("lblDescripcion")).Text;
				decimal Cantidad = Convert.ToDecimal(((Label)dgdColorWO.Items[i].FindControl("lblCantidad")).Text);
				decimal CantidadReal = Convert.ToDecimal(((TextBox)dgdColorWO.Items[i].FindControl("txtRegistro")).Text);
				string lotePasta= ((TextBox)dgdColorWO.Items[i].FindControl("txtLotePasta")).Text;
				int Grupo = Convert.ToInt32(((Label)dgdColorWO.Items[i].FindControl("lblGrupo")).Text);
				float Aforo = Convert.ToSingle(((Label)dgdColorWO.Items[i].FindControl("lblAforo")).Text);
				
				PartidasColorInfo  pcInfo = new PartidasColorInfo(CodigoSAP, Descripcion, Cantidad, CantidadReal, Grupo,lotePasta,Aforo);
				theColorList[prvSelected].Add(pcInfo);
			}

			//Update Session object
			Session[this.Context.User.Identity.Name+"ListaColores"]=theColorList;

			//Transfer the Double Dimension ArrayList to Single Dimension ArrayList
			ArrayList tmpList = new ArrayList();
			if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
			{
				for(int i = 0; i < totVaso; i++)
				{
					int NoLaminas = iVasoQty[i];
					for(int j = 0; j < theColorList[i].Count; j++)
					{
						PartidasColorInfo  pcInfo = new PartidasColorInfo();
						pcInfo = (PartidasColorInfo)theColorList[i][j];
					
						int IdArea = Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]);

						PartidasColorInfo  pcInfo1 = new PartidasColorInfo(txtSecuencia.Text, IdArea, pcInfo.CodigoSAP, i+1, NoLaminas, pcInfo.Cantidad, pcInfo.CantidadReal, null, pcInfo.LotePasta, pcInfo.Grupo,pcInfo.Aforo);
						tmpList.Add(pcInfo1);
					}
				}
			}
			else
			{
				SaparateCantidad();
				for(int i=0;i<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);i++)
				{
					int count=0;
					for(int k=0;k<totVaso;k++)
					{
						for(int j=0;j<theColorList[k].Count;j++)
						{
							PartidasColorInfo  pcInfo = new PartidasColorInfo();
							pcInfo = (PartidasColorInfo)SecuenciaList[i][count++];
							tmpList.Add(pcInfo);
						}
					}
				}
			}
			
			if (tmpList.Count > 0)
			{
				if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
				{
					SICALNet.BusinessLogicLayer.PartidasColor PColor = new SICALNet.BusinessLogicLayer.PartidasColor();
					//Delete the Existing Records in PartidasColor to adopt the Modification & Insertion
					PColor.Delete(txtSecuencia.Text);
					PColor.Insert(tmpList);
					SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text.ToString(),Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),Context.User.Identity.Name);
					SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
					BLOrdenes.UpdateLoginForm(OTInfo);
					/*SICALNet.BusinessEntities.SecuenciaCombinasInfo SCInfo = new SICALNet.BusinessEntities.SecuenciaCombinasInfo(txtSecuencia.Text+",",1);
					SICALNet.BusinessLogicLayer.SecuenciaCombinas BLLCombinas= new SICALNet.BusinessLogicLayer.SecuenciaCombinas();
					BLLCombinas.DeleteSecuenciaCombinas(SCInfo);*/
					return true;
				}
				else
				{
					string[] Secuencia = (string[])Session[this.Context.User.Identity.Name+"Secuencia"];
					SICALNet.BusinessLogicLayer.PartidasColor PColor = new SICALNet.BusinessLogicLayer.PartidasColor();
					//SICALNet.BusinessEntities.SecuenciaCombinasInfo SCInfo = new SICALNet.BusinessEntities.SecuenciaCombinasInfo(txtSecuencia.Text,1);
					//SICALNet.BusinessLogicLayer.SecuenciaCombinas BLLCombinas= new SICALNet.BusinessLogicLayer.SecuenciaCombinas();
					//Delete the Existing Records in PartidasColor to adopt the Modification & Insertion
					PColor.DeleteCombined(Secuencia,Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]));
					PColor.Insert(tmpList);
					string[] secuencia = (string[]) Session[this.Context.User.Identity.Name+"Secuencia"];
					/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
					System.Text.StringBuilder sec = new System.Text.StringBuilder();
					sec.Append("'");
					for(int i=0;i<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);i++)
					{
						sec.Append(secuencia[i]);
//						sec+=secuencia[i];
						if(i==(Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])-1))
						{
							sec.Append("'");
//							sec+="'";
						}
						else
						{
							sec.Append("','");
//							sec+="','";
						}
					}
					SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(sec.ToString(),Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),Context.User.Identity.Name);
					/*** fin modificación ***/
					SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
					BLOrdenes.UpdateLoginFormCombined(OTInfo);
					//BLLCombinas.DeleteSecuenciaCombinas(SCInfo);
					//BLLCombinas.InsertSecuenciaCombinas(txtSecuencia.Text);
					return true;
					
				}				
			}		
			else
				return false;
		}

		private void btnLiberar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(Session[this.Context.User.Identity.Name+"IdStatus"].ToString()==ConfigurationSettings.AppSettings["StatusRelease"].ToString())
				{
					Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"La orden de trabajo ya ha sido liberada !"+"')" + "<" + "/script>");
				}
				else
				{
					//Save any information provided prior to release
					SaveWorkOrderData();

					int IdArea = Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]);
					if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
					{
						//Activate Next Area And update Active Area in Programma Production for this Secuencia
						//Depending on sequence available in "FlujoArea" Table
						SICALNet.BusinessLogicLayer.FlujoArea objFlujoArea = new SICALNet.BusinessLogicLayer.FlujoArea();
						objFlujoArea.ActivateDependingAreas(txtSecuencia.Text,IdArea);

						//Release the work order
						SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text.ToString(),2,Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]),Convert.ToInt32(ConfigurationSettings.AppSettings["PVCRoomId"]),Convert.ToInt32(ConfigurationSettings.AppSettings["MixturesRoomId"]),5,DateTime.Now.Date.ToString("dd-MMM-yyyy"),Context.User.Identity.Name);
						SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						BLOrdenes.ColorUpdate(OTInfo);
					}
					else
					{
						string [] secuencia = new String[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
						secuencia = (string[])Session[this.Context.User.Identity.Name+"Secuencia"];
						//Activate Next Area And update Active Area in Programma Production for this Secuencia
						//Depending on sequence available in "FlujoArea" Table
						SICALNet.BusinessLogicLayer.FlujoArea objFlujoArea = new SICALNet.BusinessLogicLayer.FlujoArea();
						/*** modificado por alejandro.hernandez@nasoft.com 28/02/2006 ***/
						objFlujoArea.ActivateDependingAreasCombined(secuencia,IdArea);
//						objFlujoArea.ActivateDependingAreasCombined(secuencia,IdArea,Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]));
						/*** fin modificación ***/
						//Release the work order
						SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(secuencia,2,Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]),Convert.ToInt32(ConfigurationSettings.AppSettings["PVCRoomId"]),Convert.ToInt32(ConfigurationSettings.AppSettings["MixturesRoomId"]),5,DateTime.Now.Date.ToString("dd-MMM-yyyy"),Context.User.Identity.Name);
						SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						BLOrdenes.ColorUpdateCombined(OTInfo,Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]));

					}

					string sBitacora = string.Format("Liberación de Secuencia {0} en Fase de color, por el usuario {1}",txtSecuencia.Text, this.User.Identity.Name.ToString());
					// guardamos en la bitacora
					SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
					BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

					btnAceptar.Enabled=false;
					btnLiberar.Enabled=false;
					Response.Redirect("ConsultColorWO.aspx");

					
					//Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"La Orden de Trabajo se libero exitosamente"+"');self.location.href='ConsultColorWO.aspx';</script>");
				}
			}
			catch (Exception ex)
			{
					string sErrMsg;
					sErrMsg=ex.Message;
					string ScriptString="<script language='javascript'>alert('"+ sErrMsg +"');</script>"; 
					Page.RegisterStartupScript("ClientScript",ScriptString);

				throw;
			}
		}

		private void btnAgregarMensaje_Click(object sender, System.EventArgs e)
		{
			string Secuencia = txtSecuencia.Text.ToString();
			string IdArea = ConfigurationSettings.AppSettings["ColorRoomId"].ToString();
			string CodigoSAP = Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString();
			string MaterialDescription=txtUTEC.Text.Trim();
			RegisterClientScriptBlock("Enviar Mensaje de Piso", string.Format("<script language='JavaScript'> window.open('../../MensajePopup.aspx?Secuencia={0}&AreaId={1}&CodigoSAP={2}&MaterialDescription={3}','anycontent','width=600, height=550,left=100, top=150, status, scrollbars=no'); </script>",Secuencia,IdArea,CodigoSAP,MaterialDescription));
		}

		private void btnImprimir_Click(object sender, System.EventArgs e)
		{
//			if(!this.chkPrintByComp.Checked)
//				this.PrintNormalSticker();
//			else
				this.PrintNewStricker();
		}

//		private void PrintNormalSticker()
//		{
//			/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
//			System.Text.StringBuilder SecuenciaStr = new System.Text.StringBuilder();
////			string SecuenciaStr="";
//			if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()!="0")
//			{
//				string [] secuencia = new String[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
//				secuencia = (string[])Session[this.Context.User.Identity.Name+"Secuencia"];
//				for(int i=0;i<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);i++)
//				{
//					SecuenciaStr.AppendFormat("PP.Secuencia='{0}'",secuencia[i].ToString());
//					//					SecuenciaStr+=string.Format("PP.Secuencia='{0}'",secuencia[i].ToString());
//					if(i!=(Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])-1))
//					{
//						SecuenciaStr.Append(" OR ");
//						//						SecuenciaStr+=" OR ";
//					}
//				}
//			}
//			else
//			{
//				SecuenciaStr.AppendFormat("PP.Secuencia='{0}'",txtSecuencia.Text.Trim());
////				SecuenciaStr+=string.Format("PP.Secuencia='{0}'",txtSecuencia.Text.Trim());
//			}
//
//			int currentLine= Convert.ToInt32(Session[this.Context.User.Identity.Name+"selectedLine"]);
//			int currentStatus = Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdStatus"]);
//			PrepareStickerReport(txtFecha.Text,txtFecha.Text,currentLine, currentStatus,SecuenciaStr.ToString());
//			
//			/*** fin modificación ***/
//		}

		private void PrintNewStricker()
		{
			System.Text.StringBuilder secuencias=new System.Text.StringBuilder();
			if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()!="0")
			{
				//secuencia combinada
				if(Session[this.Context.User.Identity.Name+"Secuencia"]==null)
					throw new Exception("No se han asignado las secuencias");
				foreach(string sec in (string[])Session[this.Context.User.Identity.Name+"Secuencia"])
				{
					if(secuencias.Length>0)
						secuencias.Append(",");
					secuencias.Append(string.Format("'{0}'",sec));
				}
			}
			else
				secuencias.Append(string.Format("'{0}'",txtSecuencia.Text.Trim()));
		
			this.PrepareNewStickerReport(secuencias.ToString());
		}

//		private void PrepareStickerReport(string fechaInicial, string fechaFinal, int linea,int status, string secuencias)
//		{
//		
//			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
//			//Reports.PrintStickerColor ClrSticker = new Reports.PrintStickerColor();
//			//WorkOrder.PartidasColor.EtiquetaColor ClrSticker = new WorkOrder.PartidasColor.EtiquetaColor();
//			WorkOrder.PartidasColor.NewEtiquetaColor ClrSticker = new WorkOrder.PartidasColor.NewEtiquetaColor();
//
//			SICALNet.BusinessLogicLayer.FormColor theFormColor = new SICALNet.BusinessLogicLayer.FormColor();
//			DataSet theReportSource=theFormColor.getSequenceStickers(secuencias);
//
//			ClrSticker.SetDataSource(theReportSource.Tables[0]);
//			rptHelper.setPermission(ClrSticker);
//			string reportname = rptHelper.exportReport(ClrSticker,"StickerColor",User.Identity.Name );
//
//			string redirectPath=ConfigurationSettings.AppSettings["reportsWebPath"]+ reportname + ".pdf";
//			//Response.Redirect(redirectPath);
//			string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','Reporte', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>"; 
//			Page.RegisterStartupScript("ClientScript",ScriptString);
//		}

		private void PrepareNewStickerReport(string Secuencias)
		{
			Reports.ReportHelper rptHelper = new Reports.ReportHelper();
			//WorkOrder.PartidasColor.NewEtiquetaColor ClrSticker = new WorkOrder.PartidasColor.NewEtiquetaColor();
			UserInterface.Forms.Reports.Produccion.StickerColor objReporte 
				= new UserInterface.Forms.Reports.Produccion.StickerColor();

			ParameterValues rptParams=null;
			ParameterDiscreteValue userParam= new ParameterDiscreteValue();
			ParameterDiscreteValue PlantaParam= new ParameterDiscreteValue();
			ParameterDiscreteValue SecuenciaParam= new ParameterDiscreteValue();
			ParameterDiscreteValue ReimpresionParam= new ParameterDiscreteValue();
			//se obtiene el nombre del usuario autenticado
			SICALNet.BusinessEntities.UsuarioInfo objUsuarioInfo = new SICALNet.BusinessEntities.UsuarioInfo(User.Identity.Name);
			SICALNet.BusinessLogicLayer.Usuario objUsuario = new SICALNet.BusinessLogicLayer.Usuario();
			SICALNet.BusinessEntities.UsuarioInfo objUser = objUsuario.Load(objUsuarioInfo);
			userParam.Value = objUser.Nombre;
			string planta=(objUser.IdPlanta==1?"OCO":"SLP");
			PlantaParam.Value=planta;
			//Se asignan los valores de los parámetros que a su vez son parámetros del SP asociado al Reporte
			SecuenciaParam.Value=" WHERE prog.secuencia in (" + Secuencias+") ";

			SICALNet.BusinessLogicLayer.OrdenesTrabajo objOrden = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
			bool reimpresion=false;
			string []arrSecuencias=Secuencias.Split(',');
			for(int i=0;i<arrSecuencias.Length;i++)
			{
				reimpresion=(reimpresion||objOrden.FueImpresaEtiqueta(arrSecuencias[i].Replace("'",""), objUser.IdArea));
			}
			ReimpresionParam.Value=reimpresion;
	
			rptParams = new ParameterValues();
			rptParams.Add(userParam);
			objReporte.DataDefinition.ParameterFields["Usuario"].ApplyCurrentValues(rptParams);

			rptParams = new ParameterValues();
			rptParams.Add(PlantaParam);
			objReporte.DataDefinition.ParameterFields["Planta"].ApplyCurrentValues(rptParams);

			/*
			rptParams= new ParameterValues();
			rptParams.Add(SecuenciaParam);
			objReporte.DataDefinition.ParameterFields["@Secuencia"].ApplyCurrentValues(rptParams);
			*/

			rptParams= new ParameterValues();
			rptParams.Add(ReimpresionParam);
			objReporte.DataDefinition.ParameterFields["reimpresion"].ApplyCurrentValues(rptParams);

			rptHelper.setPermission(objReporte);
			string reportname = rptHelper.exportReport(objReporte,"SLPStickerColor",User.Identity.Name );

			string redirectPath=ConfigurationSettings.AppSettings["reportsWebPath"]+ reportname + ".pdf";
			string ScriptString="<script language='javascript'>window.open('" + redirectPath + "','Reporte', 'width=550,height=600,top=100,left=200,toolbars=no,scrollbars=yes,status=yes,resizable=yes');</script>"; 
			Page.RegisterStartupScript("ClientScript",ScriptString);
			//se evaluar el estatus de impresión
			this.CheckPrintStatus(Secuencias);
		}
		/// <summary>
		/// Verifica el estatus de impresión de la secuencia, en caso de no haber generardo una impresión
		/// se actualiza el estatus
		/// </summary>
		/// <author>Ing. Ariel Martínez Morales</author>
		/// <date>08-08-2005</date>
		/// <param name="Secuencia"></param>
		private void CheckPrintStatus(string Secuencia)
		{
			string []secuencias = Secuencia.Split(',');
			SICALNet.BusinessEntities.UsuarioInfo objUsuarioInfo = new SICALNet.BusinessEntities.UsuarioInfo(User.Identity.Name);
			SICALNet.BusinessLogicLayer.Usuario objUsuario = new SICALNet.BusinessLogicLayer.Usuario();
			SICALNet.BusinessEntities.UsuarioInfo objUser = objUsuario.Load(objUsuarioInfo);

			SICALNet.BusinessLogicLayer.OrdenesTrabajo objOrden = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
			//se recorren las secuencias para evaluar/modificar su estatus de impresión
			for(int i=0;i<secuencias.Length;i++)
			{
				if(!objOrden.FueImpresaEtiqueta(secuencias[i].Replace("'",""), objUser.IdArea))
					objOrden.ActualizaEstatusImpresion(secuencias[i].Replace("'",""), objUser.IdArea);
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ConsultColorWO.aspx");
		}

		private void dgdColorWO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		private void SaparateCantidad()
		{
			ArrayList[] theColorList =(ArrayList[]) Session[this.Context.User.Identity.Name+"ListaColores"];
			ArrayList Temp = new ArrayList();			
			for(int i=0;i<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);i++)
			{
				Temp=(ArrayList)SecuenciaLaminasList[i];
				ArrayList Dummy = new ArrayList();
				ArrayList SecList = new ArrayList();
				for(int j=0;j<theColorList.Length;j++)
				{
					Dummy = (ArrayList)theColorList[j];
					for(int k=0;k<Dummy.Count;k++)
					{
						SICALNet.BusinessEntities.PartidasColorInfo PCInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
						PCInfo = (SICALNet.BusinessEntities.PartidasColorInfo)Dummy[k];
						SICALNet.BusinessEntities.PartidasColorInfo PCInfo2 = new SICALNet.BusinessEntities.PartidasColorInfo();
						PCInfo2 = (SICALNet.BusinessEntities.PartidasColorInfo)Temp[j];
						decimal Cantidad = PCInfo.Cantidad*PCInfo2.NoLaminas/iVasoQty[j];
						decimal CantidadReal = PCInfo.CantidadReal*PCInfo2.NoLaminas/iVasoQty[j];				
						PCInfo = new SICALNet.BusinessEntities.PartidasColorInfo(PCInfo2.Secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),PCInfo.CodigoSAP,j+1,PCInfo2.NoLaminas,Cantidad,CantidadReal,PCInfo.FechaMovimiento,PCInfo.LotePasta,PCInfo.Grupo,PCInfo.Aforo);
						SecList.Add(PCInfo);
					}
				}
				SecuenciaList[i]=(ArrayList)SecList;
			}
		}
		public void CalculateDifferance(object sender, System.EventArgs e)
		{
			//To get the string "ctl2" - that is available between "_" of the Client ID
			//Client Id Example = "dgdDefecto__ctl2__
			/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/

			TextBox txtSender = (TextBox)sender;
			string id =txtSender.ClientID ;							//Get the Client ID "dgdAditivos__ctl2_txtAditivosRegistro"
			//string id =(((TextBox)sender).ClientID);							//Get the Client ID "dgdAditivos__ctl2_txtAditivosRegistro"
			/*** fin de modificación ***/

			int First = id.IndexOf("_");												// Get the First Underscore("_") Position
			int Second = id.LastIndexOf("_");											// Get the Next Underscore("_") Position
			int Index = Convert.ToInt32((id.Substring(0,Second)).Substring(First+5));	//Get that index ("2") which is avilable after "ctl"

			Label lblCantidad = (Label) dgdColorWO.Controls[0].Controls[Index-1].FindControl("lblCantidad");
			Label lblDiference = (Label) dgdColorWO.Controls[0].Controls[Index-1].FindControl("lblDiffrencia");
			TextBox txtDiferenceia= (TextBox) dgdColorWO.Controls[0].Controls[Index-1].FindControl("txtDif");

			/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/
			decimal Diff = Convert.ToDecimal(lblCantidad.Text) - Convert.ToDecimal(txtSender.Text);
			//decimal Diff = Convert.ToDecimal(lblCantidad.Text) - Convert.ToDecimal(((TextBox)sender).Text);
			/*** fin de modificación ***/

			lblDiference.Text =  Diff.ToString();
			txtDiferenceia.Text =  Diff.ToString();

		}

		private void dgdColorWO_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		
			if(e.Item.ItemType==ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
			{
				Label Diff=(Label)e.Item.FindControl("lblDiffrencia");
				decimal CantidadReal;
				if(Session[this.Context.User.Identity.Name+"IdStatus"].ToString()=="5")
					CantidadReal=Convert.ToDecimal(((Label)e.Item.FindControl("lblRegistro")).Text);
				else
					CantidadReal=Convert.ToDecimal(((TextBox)e.Item.FindControl("txtRegistro")).Text);
				CantidadReal= (Convert.ToDecimal(((Label)e.Item.FindControl("lblCantidad")).Text)-CantidadReal);
				Diff.Text=CantidadReal.ToString();

			}
		}
		private void SaparateLaminas()
		{
			int[] NoVaso =(int[])Session[this.Context.User.Identity.Name+"NoVaso"];
			int[] sCantidad =(int[])Session[this.Context.User.Identity.Name+"Cantidad"];
			string[] Secuencia = (string[])Session[this.Context.User.Identity.Name+"Secuencia"]; 
			for(int j=0;j<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);j++)
			{
					int count=0;
				ArrayList SecList = new ArrayList();
				for (int i = 0; i < Convert.ToInt32(Session[this.Context.User.Identity.Name+"NoGroup"].ToString()); i++)
				{
					int sum=0;
					for(int k=0;k<NoVaso[i];k++)
					{
						int temp= Convert.ToInt32(iVasoQty[count++]*sCantidad[j]);
						int Laminas =Convert.ToInt32(Math.Round(Convert.ToDecimal(temp/Convert.ToInt32(txtCantidad.Text))));
						sum+=Laminas;
						SICALNet.BusinessEntities.PartidasColorInfo PCInfo = new SICALNet.BusinessEntities.PartidasColorInfo();
						if(k==(NoVaso[i]-1))
							if(sum!=sCantidad[j])
							{
								for(int f=0;;f++)
								{
									Laminas++;
									sum++;
									if(sum==sCantidad[j])
									{
										PCInfo = new SICALNet.BusinessEntities.PartidasColorInfo(Secuencia[j],0,string.Empty,count,Laminas,0,0,string.Empty,string.Empty,i+1,0);
										break;
									}
								}
							}
							else
							{
								PCInfo = new SICALNet.BusinessEntities.PartidasColorInfo(Secuencia[j],0,string.Empty,count,Laminas,0,0,string.Empty,string.Empty,i+1,0);
							}
						else
							PCInfo = new SICALNet.BusinessEntities.PartidasColorInfo(Secuencia[j],0,string.Empty,count,Laminas,0,0,string.Empty,string.Empty,i+1,0);  
						SecList.Add(PCInfo);
					}

				}
				SecuenciaLaminasList[j]=(ArrayList)SecList;
			}
		}

		private void btnAditivos_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
				{
					SICALNet.BusinessLogicLayer.PartidasAditivos blPartidasAdi = new SICALNet.BusinessLogicLayer.PartidasAditivos();
					if(blPartidasAdi.IsExistSecuencia(txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"])))
					{
						SICALNet.BusinessEntities.OrdenesTrabajoInfo OInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["ColorRoomId"]),0);
						SICALNet.BusinessLogicLayer.OrdenesTrabajo blOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						int Status=blOrdenes.GetStatus(OInfo);
						Session[this.Context.User.Identity.Name+"IdStatus"]=Status;
						if(Status==2)
						{
							int Container=(int)blPartidasAdi.GetNoContainers(txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]));
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
							Response.Redirect("../../AditivosCuarto.aspx?CantidadSum="+Session[this.Context.User.Identity.Name+"Cantidad"]);
						}
						else if(Status==5)
						{
							
							int Container=(int)blPartidasAdi.GetNoContainers(txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]));
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
							Response.Redirect("../../AditivosCuarto.aspx?CantidadSum="+Session[this.Context.User.Identity.Name+"Cantidad"]);

						}
					}
					else
					{
						int Container=1;
						Session[this.Context.User.Identity.Name+"NoCuanto"]=Container;
						int[] aryLaminas = new int[Container];
						float[] aryOlla = new float[Container]; 
						aryLaminas[0]=Convert.ToInt32(Session[this.Context.User.Identity.Name+"Cantidad"]);
						Session[this.Context.User.Identity.Name+"VasoQty"]=aryLaminas;
						SICALNet.BusinessEntities.OllaInfo oInfo = new SICALNet.BusinessEntities.OllaInfo(0,Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"]),0,0);
						SICALNet.BusinessLogicLayer.Olla blOlla = new SICALNet.BusinessLogicLayer.Olla();
						IList OllaList=(IList)blOlla.SelectOlla(oInfo); 
						oInfo=(SICALNet.BusinessEntities.OllaInfo)OllaList[0];
						aryOlla[0]=oInfo.CapacidadMax;
						SICALNet.BusinessLogicLayer.PartidasAditivos blPartidas = new SICALNet.BusinessLogicLayer.PartidasAditivos();
						/*** modificado por alejandro.hernandez@nasoft.com 28/02/2006 ***/
						blPartidas.CheckOlla(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),aryLaminas[0],aryOlla[0],10,Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"]));
						//blPartidas.CheckOlla(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),aryLaminas[0],1,aryOlla[0],10,Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"]));
						/*** fin modificación ***/
						
						Session[this.Context.User.Identity.Name+"flag"]="0";
						Session[this.Context.User.Identity.Name+"Olla"]=aryOlla;
						Response.Redirect("../../AditivosCuarto.aspx?CantidadSum="+Session[this.Context.User.Identity.Name+"Cantidad"]+"&flag=0&ReFlag=False&Descripcion="+txtUTEC.Text+"&Secuencia="+txtSecuencia.Text);		
					}
				}
				else
				{
					SICALNet.BusinessLogicLayer.PartidasAditivos blPartidasAdi = new SICALNet.BusinessLogicLayer.PartidasAditivos();
					string[] Secuencia = (string[])Session[this.Context.User.Identity.Name+"Secuencia"]; 
					SICALNet.BusinessEntities.OrdenesTrabajoInfo OInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(Secuencia[0],Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]),0);
					SICALNet.BusinessLogicLayer.OrdenesTrabajo blOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
					int Status=blOrdenes.GetStatus(OInfo);
					Session[this.Context.User.Identity.Name+"IdStatus"]=Status;
					if(blPartidasAdi.IsExistSecuencia(Secuencia[0],Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"])))
					{
						
						int Container=(int)blPartidasAdi.GetNoContainers(Secuencia[0],Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]));
						Session[this.Context.User.Identity.Name+"NoCuanto"]=Container;
						/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
						System.Text.StringBuilder sec = new System.Text.StringBuilder();
//						string sec="'";
						int CantidadSum=Convert.ToInt32(txtCantidad.Text);
						for(int i=0;i<Secuencia.Length;i++)
						{
							sec.Append(Secuencia[i]);
//							sec+=Secuencia[i];
							if(i==((Secuencia.Length)-1))
							{
								sec.Append("'");
//								sec+="'";
							}
							else
							{
								sec.Append("','");
//								sec+="','";
							}
						}
						IList NoOllaList=(IList)blPartidasAdi.LoadOllaCombined(sec.ToString());
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
						Response.Redirect("../../AditivosCuarto.aspx?CantidadSum="+CantidadSum);
					}
					else
					{
						int Container=1;
						Session[this.Context.User.Identity.Name+"NoCuanto"]=Container;
						int[] aryLaminas = new int[Container];
						float[] aryOlla = new float[Container];
						int CantidadSum=Convert.ToInt32(txtCantidad.Text);
						aryLaminas[0]=CantidadSum;
						Session[this.Context.User.Identity.Name+"VasoQty"]=aryLaminas;
						Session[this.Context.User.Identity.Name+"flag"]="0";
						SICALNet.BusinessEntities.OllaInfo oInfo = new SICALNet.BusinessEntities.OllaInfo(0,Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"]),0,0);
						SICALNet.BusinessLogicLayer.Olla blOlla = new SICALNet.BusinessLogicLayer.Olla();
						IList OllaList=(IList)blOlla.SelectOlla(oInfo); 
						oInfo=(SICALNet.BusinessEntities.OllaInfo)OllaList[0];
						aryOlla[0]=oInfo.CapacidadMax;
						SICALNet.BusinessLogicLayer.PartidasAditivos blPartidas = new SICALNet.BusinessLogicLayer.PartidasAditivos();
						/*** modificado por alejandro.hernandez@nasoft.com 28/02/2006 ***/
						blPartidas.CheckOlla(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),aryLaminas[0],aryOlla[0],10,Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"]));
						//blPartidas.CheckOlla(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),aryLaminas[0],1,aryOlla[0],10,Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"]));
						/*** fin modificación ***/
						Session[this.Context.User.Identity.Name+"Olla"]=aryOlla;
						Response.Redirect("../../AditivosCuarto.aspx?CantidadSum="+CantidadSum+"&flag=0&ReFlag=False&Descripcion="+txtUTEC.Text);	

					}

				}
		
			}
			catch
			{
//				string sErrMsg;
//				sErrMsg=ex.Message;
//				string ScriptString="<script language='javascript'>alert('"+ sErrMsg +"');</script>"; 
//				Page.RegisterStartupScript("ClientScript",ScriptString);

				throw;
			}
		}
		
		
	}
}
