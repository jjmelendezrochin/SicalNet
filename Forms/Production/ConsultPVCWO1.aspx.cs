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

namespace UserInterface.Forms
{
	/// <summary>
	/// Summary description for ConsultPVCWO1.
	/// </summary>
	public class ConsultPVCWO1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblSecuencia;
		protected System.Web.UI.WebControls.TextBox txtSecuencia;
		protected System.Web.UI.WebControls.Label lblFecha1;
		protected System.Web.UI.WebControls.TextBox txtFecha1;
		protected System.Web.UI.WebControls.Label lblUTEC;
		protected System.Web.UI.WebControls.TextBox txtUTEC;
		protected System.Web.UI.WebControls.Label lblCantidad;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected System.Web.UI.WebControls.DataGrid dgdPartidasPVC;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Button cmdMensaje;
		protected System.Web.UI.WebControls.Button cmdLiberar;
		protected System.Web.UI.WebControls.Button btnAgregar;
		protected System.Web.UI.WebControls.Button cmdCancelar;
		protected System.Web.UI.WebControls.TextBox txtPiso;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label7;

		protected static int IdPVCArea;
	
		private void Page_Load(object sender, System.EventArgs e)
		
		{
			Response.Cache.SetExpires(DateTime.Now);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetValidUntilExpires(false);
			Response.Cache.SetNoStore();

			if (!IsPostBack) 
			{
				cmdMensaje.Attributes.Add("onClick","showWaitControls()");
				cmdLiberar.Attributes.Add("onClick","showWaitControls()");
				btnAgregar.Attributes.Add("onClick","showWaitControls()");
				cmdCancelar.Attributes.Add("onClick","showWaitControls()");

				string sBitacora = string.Format("Inicio");
				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				txtSecuencia.Text=Request.QueryString["Secuencia"].ToString();
				sBitacora = string.Format("1");
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				txtCantidad.Text=Request.QueryString["Cantidad"].ToString();
				sBitacora = string.Format("2");
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				txtFecha1.Text=Request.QueryString["Fecha"].ToString();
				sBitacora = string.Format("3");
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				txtUTEC.Text=Request.QueryString["UTEC"].ToString();
				sBitacora = string.Format("4");
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());
				
			//	ConsultPVCWO1.aspx?Secuencia={0}&Cantidad={1}&Fecha={2}&UTEC={3}&Status={4}&IdFamiliaProducto={5}&IdMedida={6}
				// &IdEspesor={7}&IdPlanta={8}&CodigoSAP={9}

				int St = int.Parse(Request.QueryString["Status"].ToString());
				sBitacora = string.Format("5");
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());


				//The sequences in status RELEASED can only be consulted in READ ONLY mode
				IdPVCArea = Convert.ToInt32(ConfigurationSettings.AppSettings["PVCRoomId"]);  //Area for PVC Room
				sBitacora = string.Format("6");
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				string _idEspesor = Request.QueryString["IdEspesor"].ToString();
				int _idMedida = Convert.ToInt32(Request.QueryString["IdMedida"]);
				sBitacora = string.Format("7");
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				int _idFamiliaProducto = Convert.ToInt32(Request.QueryString["idFamiliaProducto"]);
				sBitacora = string.Format("8");
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				int _cantidad = Convert.ToInt32(Request.QueryString["Cantidad"]);
				sBitacora = string.Format("9");
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				string _codigoSAP = Request.QueryString["CodigoSAP"].ToString();
				sBitacora = string.Format("10");
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				LoadWOInfo(St,txtSecuencia.Text,_idEspesor,_idMedida,_idFamiliaProducto,_cantidad,_codigoSAP);

				sBitacora = string.Format("11");
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());

				// Display the Messages in Multiline Text box
				DisplayFloorMessage();

				sBitacora = string.Format("12");
				BLLBitacora.Insertcomando(sBitacora ,this.User.Identity.Name.ToString());


			}
		}

		private void DisplayFloorMessage()
		{
			//Displaying Floor Message
			MensajePisoInfo mpInfo = new MensajePisoInfo(txtSecuencia.Text,string.Empty,IdPVCArea);
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

        private void LoadWOInfo(int status, string secuencia, string idEspesor, int idMedida, int idFamiliaProducto, int cantidad, string _codigoSAP)
		{

			int ReleaseStatus = Convert.ToInt32(ConfigurationSettings.AppSettings["StatusRelease"]);
			int ActiveStatus = Convert.ToInt32(ConfigurationSettings.AppSettings["StatusActive"]);

			if (status==ReleaseStatus)
			{
				SICALNet.BusinessLogicLayer.PartidasPVC pPVC = new SICALNet.BusinessLogicLayer.PartidasPVC();
				IList PartidasPVCList = (IList)pPVC.Load(secuencia, IdPVCArea);
				dgdPartidasPVC.DataSource = PartidasPVCList;
				dgdPartidasPVC.DataBind();	
				
				dgdPartidasPVC.Columns[3].Visible=true;
				dgdPartidasPVC.Columns[4].Visible=false;
				dgdPartidasPVC.Columns[5].Visible=true;
				dgdPartidasPVC.Columns[6].Visible=false;
				cmdLiberar.Enabled = false;
				this.btnAgregar.Enabled = false;
				RegisterStartupScript("Startup", "<script type=\"text/javascript\">document.forms[0]." + cmdCancelar.ClientID 
					+ ".focus();</script>");
			}

			if (status == ActiveStatus)
			{
				dgdPartidasPVC.Columns[3].Visible=false;
				dgdPartidasPVC.Columns[4].Visible=true;
				dgdPartidasPVC.Columns[5].Visible=false;
				dgdPartidasPVC.Columns[6].Visible=true;

				PartidasPVCInfo ppInfo1 = new PartidasPVCInfo(secuencia, IdPVCArea,string.Empty);
				SICALNet.BusinessLogicLayer.PartidasPVC PartidasPVC = new SICALNet.BusinessLogicLayer.PartidasPVC();
					
				IList FormPVCList;

				if (!PartidasPVC.IsExists(ppInfo1))
				{
					int idPlanta = Convert.ToInt32(Request.QueryString["IdPlanta"].ToString());
					int idAcabado = getIdAcabado(_codigoSAP,idPlanta);
					// Load Method for FormPVC
					FormPVCInfo fpInfo = new FormPVCInfo(idFamiliaProducto, idMedida, idEspesor,idPlanta, cantidad,idAcabado, int.Parse(secuencia.Substring(0,1)));					
					
					SICALNet.BusinessLogicLayer.FormPVC FormPVC = new SICALNet.BusinessLogicLayer.FormPVC();
					FormPVCList = FormPVC.Load(fpInfo);
					IList PartidasPVCList = new ArrayList();
					for(int i=0; i<FormPVCList.Count; i++)
					{
						FormPVCInfo tmpfpInfo = new FormPVCInfo();
						tmpfpInfo = (FormPVCInfo) FormPVCList[i];
						
						string CodigoSAP = tmpfpInfo.CodigoSAP;
						float Cantidad1 = tmpfpInfo.Cantidad; 
						float CantidadReal=0;
						MaterialInfo BEmat=new MaterialInfo(CodigoSAP,"",0,"",0,"",0,"",0,0,0,0,0,"","","","","","","","","");
						SICALNet.BusinessLogicLayer.Material blMaterial = new SICALNet.BusinessLogicLayer.Material();
						IList RsMaterial = blMaterial.SelectMaterialList(BEmat);
						MaterialInfo BEmaterial = (MaterialInfo) RsMaterial[0];
						PartidasPVCInfo ppInfo = new PartidasPVCInfo(secuencia, IdPVCArea, CodigoSAP, Cantidad1,CantidadReal,string.Empty,BEmaterial.Descripcion);
						PartidasPVCList.Add(ppInfo);

						// To Check weather the Record is Already exists are not in partidas reaccion
						// (that is to check weather it is already Consulted or not)
						//Commented by Karthik(AITS)
						/*SICALNet.BusinessLogicLayer.PartidasPVC PartidasPVC = new SICALNet.BusinessLogicLayer.PartidasPVC();
							if (!(PartidasPVC.IsExists(ppInfo)))
							{
								// Insert that rows to PartidasPVC
								PartidasPVC.Insert(ppInfo);
							}*/
					}

					//SICALNet.BusinessLogicLayer.PartidasPVC pPVC = new SICALNet.BusinessLogicLayer.PartidasPVC();
					//IList PartidasPVCList = (IList)pPVC.Load(txtSecuencia.Text, IdArea);
					dgdPartidasPVC.DataSource = PartidasPVCList;
					dgdPartidasPVC.DataBind();

					// Coding for Liberar
					// To Disable Liberar Button
					cmdLiberar.Enabled = false;
					// To Enable Liberar Button based on Cantidad Real
					if (dgdPartidasPVC.Items.Count > 0)
						if (dgdPartidasPVC.Controls[0].Controls.Count > 2)
						{
							for (int i=1; i<= dgdPartidasPVC.Controls[0].Controls.Count-2; i++)
							{
								double CantidadReal = Convert.ToDouble(((Label)dgdPartidasPVC.Controls[0].Controls[i].FindControl("ItemMCantidadReal")).Text);
								if (CantidadReal > 0)
								{
									lblErrorMsg.Text = "Debe existir la cantidad real " + "in Row " + i.ToString();
									return;
								}
							}
							cmdLiberar.Enabled = true;
						}
				}
				else
				{
					IList PartidasPVCList=PartidasPVC.Load(secuencia,IdPVCArea);
					dgdPartidasPVC.DataSource = PartidasPVCList;
					dgdPartidasPVC.DataBind();

				}
			}

		}
	
		private int getIdAcabado(string codigoSAP, int idPlanta)
		{
			MaterialInfo theMaterial = new MaterialInfo(codigoSAP,idPlanta);
			Material bllMaterial = new Material();
			theMaterial = bllMaterial.SelectMaterial(theMaterial);

			return theMaterial.IdAcabado;
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
			this.cmdMensaje.Click += new System.EventHandler(this.cmdMensaje_Click);
			this.cmdLiberar.Click += new System.EventHandler(this.cmdLiberar_Click);
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdLiberar_Click(object sender, System.EventArgs e)
		{
			try
			{
				//by default authorize to release work order
				bool proceedToRelease = true;

				for(int i=0;i<dgdPartidasPVC.Items.Count;i++)
				{
					string Codigo=((Label)dgdPartidasPVC.Items[i].FindControl("ItemCodigoSAP")).Text.ToString();
					float Cantidad=Convert.ToSingle(((Label)dgdPartidasPVC.Items[i].FindControl("ItemMCantidad")).Text.ToString());
					float CantidadReal=Convert.ToSingle(((TextBox)dgdPartidasPVC.Items[i].FindControl("txtCantidadReal")).Text.ToString());
					string FolioCompuesto = ((TextBox)dgdPartidasPVC.Items[i].FindControl("txtFolioCompuesto")).Text.ToString();
					SICALNet.BusinessEntities.PartidasPVCInfo PVCInfo = new SICALNet.BusinessEntities.PartidasPVCInfo(txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["PVCRoomId"]),Codigo,Cantidad,CantidadReal,DateTime.Now.Date.ToString("dd/MMM/yyyy"),string.Empty,FolioCompuesto);
					SICALNet.BusinessLogicLayer.PartidasPVC PartidasPVC = new SICALNet.BusinessLogicLayer.PartidasPVC();
					PartidasPVC.Insert(PVCInfo);

					//if current suppied quantity is smaller than requested, then dont allow the work order to be released
					if (CantidadReal!=Cantidad)
						proceedToRelease=false;
				}
			
				if (proceedToRelease)
				{
					// To Release the Work Order
					int IdArea = Convert.ToInt32(ConfigurationSettings.AppSettings["PVCRoomId"]);
					int IdStatus = Convert.ToInt32(ConfigurationSettings.AppSettings["StatusRelease"]); 
					OrdenesTrabajoInfo WOInfo = new OrdenesTrabajoInfo(txtSecuencia.Text, IdArea, IdStatus, DateTime.Now.Date.ToString("dd/MMM/yyyy"),Context.User.Identity.Name); // 1 - Active
					SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
					WorkOrder.UpdateStatus(WOInfo);

					//Activate Next Area And update Active Area in Programma Production for this Secuencia
					//Depending on sequence available in "FlujoArea" Table
					FlujoArea objFlujoArea = new FlujoArea();
					objFlujoArea.ActivateDependingAreas(txtSecuencia.Text,IdArea);

					//Confirm operation to the user via message.
					Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"La Orden de Trabajo se libero exitosamente"+"');self.location.href='ConsultPVCWO.aspx';</script>");
					Response.Redirect("ConsultPVCWO.aspx");
				}
				else
					//Confirm operation to the user via message.
					Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"Para poder liberar, proporcione la cantidad de material solicitada !"+"')" + "<" + "/script>");
			}
			catch
			{
				throw;
			}
		}

		private void cmdMensaje_Click(object sender, System.EventArgs e)
		{
			string Secuencia = txtSecuencia.Text.ToString();
			string IdArea= ConfigurationSettings.AppSettings["PVCRoomId"].ToString();
			string CodigoSAP=Session["CodigoSAP"].ToString();
			string matDesc=txtUTEC.Text.Trim();
			RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodigoSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");
		}

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
			try
			{
				int sequenceStatus = Convert.ToInt32(Request.QueryString["status"].ToString());
				if (sequenceStatus==Convert.ToInt32(ConfigurationSettings.AppSettings["StatusRelease"]))
				{
					Response.Redirect("ConsultPVCWO.aspx");
				}
				else
				{
					for(int i=0;i<dgdPartidasPVC.Items.Count;i++)
					{
						string Codigo=((Label)dgdPartidasPVC.Items[i].FindControl("ItemCodigoSAP")).Text.ToString();
						float Cantidad=Convert.ToSingle(((Label)dgdPartidasPVC.Items[i].FindControl("ItemMCantidad")).Text.ToString());
						float CantidadReal=Convert.ToSingle(((TextBox)dgdPartidasPVC.Items[i].FindControl("txtCantidadReal")).Text);
						string FolioCompuesto = ((TextBox)dgdPartidasPVC.Items[i].FindControl("txtFolioCompuesto")).Text.ToString();
						SICALNet.BusinessEntities.PartidasPVCInfo PVCInfo = new SICALNet.BusinessEntities.PartidasPVCInfo(txtSecuencia.Text,IdPVCArea,Codigo,Cantidad,CantidadReal,string.Empty,string.Empty,FolioCompuesto);
						SICALNet.BusinessLogicLayer.PartidasPVC PartidasPVC = new SICALNet.BusinessLogicLayer.PartidasPVC();
						PartidasPVC.Insert(PVCInfo);
						SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo( txtSecuencia.Text.ToString(),Convert.ToInt32(ConfigurationSettings.AppSettings["PVCRoomId"]),Context.User.Identity.Name);
						SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						BLOrdenes.UpdateLoginForm(OTInfo);
					}			
				}
			}
			catch
			{
				throw;
			}
		}

		private void cmdCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ConsultPVCWO.aspx");
		}

	}
}
