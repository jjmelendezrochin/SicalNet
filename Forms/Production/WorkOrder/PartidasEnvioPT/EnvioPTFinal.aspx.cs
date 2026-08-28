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

namespace UserInterface.Forms.Production.WorkOrder.PartidasEnvioPT
{
	/// <summary>
	/// Summary description for EnvioPTFinal.
	/// </summary>
	public class EnvioPTFinal : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.TextBox txtSecuencia;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.TextBox txtUTEC;
		protected System.Web.UI.WebControls.DataGrid dgdEnvioPT;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Button btnAgregar;
		protected System.Web.UI.WebControls.Button btnLiberar;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected static string Initial;
		protected static string Final;
		protected static string cboStatus;
		protected static string cboLinea;
		protected static string IdStatus;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtMensajePiso;
		protected System.Web.UI.WebControls.Button cmdMsgPiso;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label8;
		protected static int Paquete;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);

			if(!IsPostBack)
			{
				cmdMsgPiso.Attributes.Add("onClick","showWaitControls()");
				btnBack.Attributes.Add("onClick","showWaitControls()");
				btnLiberar.Attributes.Add("onClick","showWaitControls()");
				btnAgregar.Attributes.Add("onClick","showWaitControls()");
				btnCancelar.Attributes.Add("onClick","showWaitControls()");

				txtFecha.Text = Request.QueryString["Fecha"].ToString();
				Initial=Request.QueryString["InitialDate"].ToString();
				Final=Request.QueryString["FinalDate"].ToString();
				cboStatus=Request.QueryString["cboStatus"].ToString();
				cboLinea=Request.QueryString["cboLinea"].ToString();
				txtSecuencia.Text=Request.QueryString["Secuencia"].ToString();
				txtUTEC.Text=Request.QueryString["Descripcion"].ToString();
				txtCantidad.Text=Request.QueryString["Laminas"].ToString();
				SICALNet.BusinessEntities.PartidasEnvioPTInfo PEInfo = new SICALNet.BusinessEntities.PartidasEnvioPTInfo(string.Empty,txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["SendFinishProductRoomId"]),string.Empty,0,string.Empty);
				SICALNet.BusinessLogicLayer.PartidasEnvioPT BlPEPT = new SICALNet.BusinessLogicLayer.PartidasEnvioPT();
				IList EnvioList=BlPEPT.Select(PEInfo);
				Paquete = Convert.ToInt32(Request.QueryString["Packages"]);
				//if(EnvioList.Count==0||Request.QueryString["Flag"]=="New")
				if(EnvioList.Count==0)
				{
					// Create a DataSet.
					DataSet dsPaquete = new DataSet("dsPaquete");
					//Create a DataTable.
					DataTable dtPaquete = new DataTable("Paquete");
					//Create three columns, and add them to the first table.
					DataColumn dcPaqueteNo = new DataColumn("PaqueteNo");
					DataColumn dcPaquete = new DataColumn("Paquete"); 
					DataColumn dcLaminas = new DataColumn("Laminas");
					DataColumn dcTarima = new DataColumn("Tarima");
					//assign the datacolum into datatable
					dtPaquete.Columns.Add(dcPaqueteNo);
					dtPaquete.Columns.Add(dcPaquete);
					dtPaquete.Columns.Add(dcLaminas);
					dtPaquete.Columns.Add(dcTarima);
					//Add the tables to the DataSet.
					dsPaquete.Tables.Add(dtPaquete);
					for (int iLoop=1; iLoop <= Paquete; iLoop++)
					{
						DataRow drPaquete = dtPaquete.NewRow();
						drPaquete["PaqueteNo"] = "Paquete "+iLoop.ToString();
						drPaquete["Paquete"]=string.Empty;
						drPaquete["Laminas"] = string.Empty;
						drPaquete["Tarima"] = string.Empty;
						dtPaquete.Rows.Add(drPaquete);
					}
					dgdEnvioPT.DataSource=dsPaquete;
					dgdEnvioPT.DataBind();
				}
				else
				{
					dgdEnvioPT.DataSource=EnvioList;
					dgdEnvioPT.DataBind();
				}
				IdStatus = Request.QueryString["IdStatus"].ToString();
				if(IdStatus=="5")
				{
					btnAgregar.Enabled=false;
					btnLiberar.Enabled=false;
					dgdEnvioPT.Columns[1].Visible=false;
					dgdEnvioPT.Columns[2].Visible=true;
					dgdEnvioPT.Columns[3].Visible=false;
					dgdEnvioPT.Columns[4].Visible=true;
					dgdEnvioPT.Columns[5].Visible=false;
					dgdEnvioPT.Columns[6].Visible=true;
				}
				ShowMensaje(); //Display Floor Message
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
			this.cmdMsgPiso.Click += new System.EventHandler(this.cmdMsgPiso_Click);
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ConsultEnvioPT.aspx?InitialDate="+Initial+"&FinalDate="+Final+"&cboStatus="+cboStatus+"&cboLinea="+cboLinea+"&Reflag=True");
		}

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
			try
			{
				string[] Paquetes = new string[dgdEnvioPT.Items.Count];
				IList EnvioList=new ArrayList();
				int sumLaminas = 0;
				SICALNet.Utilities.Validation Plt = new SICALNet.Utilities.Validation();
				
				for(int i=0;i<dgdEnvioPT.Items.Count;i++)
				{
					Paquetes[i] = ((TextBox)dgdEnvioPT.Items[i].FindControl("txtPaquete")).Text;
					string Lamins=((TextBox)dgdEnvioPT.Items[i].FindControl("txtLaminas")).Text;
					if(!Plt.IsWholeNumber(Lamins)||Lamins==""||Lamins==string.Empty)
							throw new Exception("Proporcione un número válido para la cantidad de láminas.");
					int Laminas = Convert.ToInt32(((TextBox)dgdEnvioPT.Items[i].FindControl("txtLaminas")).Text);
					string Tarima=((TextBox)dgdEnvioPT.Items[i].FindControl("txtTarima")).Text;
						sumLaminas+=Laminas;
					SICALNet.BusinessEntities.PartidasEnvioPTInfo PEInfo = new SICALNet.BusinessEntities.PartidasEnvioPTInfo(string.Empty,txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["SendFinishProductRoomId"]),Paquetes[i],Laminas,Tarima);
					EnvioList.Add(PEInfo);				
				}
				for(int i=0;i<Paquetes.Length-1;i++)
				{
					for(int j=i+1;j<Paquetes.Length;j++)
					{
						if(Paquetes[i]==string.Empty||Paquetes[i]=="")
							throw new Exception(" Proporcione un nombre para el paquete "+ Paquetes[i]);
						
						/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/
						if(String.Compare(Paquetes[i].ToUpper(),Paquetes[j].ToUpper())==0)
//						if(Paquetes[i].ToUpper()==Paquetes[j].ToUpper())
							/*** fin de modificación ***/
						{
							throw new Exception("El Paquete "+Paquetes[i]+" está repetido");
						}
					}
				}
				if(sumLaminas.ToString()!=txtCantidad.Text)
					throw new Exception("El No. de Laminas no coincide con el Numero de Piezas distribuido en los Paquetes");
				SICALNet.BusinessLogicLayer.PartidasEnvioPT BlPEPT = new SICALNet.BusinessLogicLayer.PartidasEnvioPT();
				BlPEPT.Delete(txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["SendFinishProductRoomId"]));
				BlPEPT.Insert(EnvioList);
				SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["SendFinishProductRoomId"]),Context.User.Identity.Name);
				SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				BLOrdenes.UpdateLoginForm(OTInfo);

			}
			catch
			{
				//to display the msg for user
//				string ScriptString="<script language='javascript'>alert('"+ ex.Message +"');</script>"; 
//				Page.RegisterStartupScript("ClientScript",ScriptString);

				throw;
			}
		}

		private void showalertmessage(string Message)
		{
			//to display the friendly msg for user
			string ScriptString="<script language='javascript'>alert('"+ Message +"');</script>"; 
			Page.RegisterStartupScript("ClientScript",ScriptString);
		}
		
		private void btnLiberar_Click(object sender, System.EventArgs e)
		{
			try
			{
				int packnumber = 0;
				string[] Paquetes = new string[dgdEnvioPT.Items.Count];
				IList EnvioList=new ArrayList();
				int sumLaminas = 0;
				SICALNet.Utilities.Validation Plt = new SICALNet.Utilities.Validation();
				

				//should have unique pack name every packet
				bool flaguniquenamepacks = true;
				bool flagnamepack= true;
					
				ArrayList packnames= new ArrayList();					

				for(int i=0;i<Paquetes.Length;i++)
				{
					
					if ((flaguniquenamepacks) && (flagnamepack))
					{
						packnumber = i+1;
						if(packnames.Contains(((TextBox)dgdEnvioPT.Items[i].FindControl("txtPaquete")).Text))						
						{
							flaguniquenamepacks = false;
							
							//throw new Exception("El Paquete "+Paquetes[i]+" está repetido");
						}
						if(((TextBox)dgdEnvioPT.Items[i].FindControl("txtPaquete")).Text==string.Empty||((TextBox)dgdEnvioPT.Items[i].FindControl("txtPaquete")).Text=="")
							flagnamepack =  false;
						else
							packnames.Add(((TextBox)dgdEnvioPT.Items[i].FindControl("txtPaquete")).Text);
						//throw new Exception(" Proporcione un nombre para el paquete "+ Paquetes[i]);
						/*** modificado por alejandro.hernandez@nasoft.com 27/02/2006 ***/
								
						
					}
					else
						break;
				}

				if (flagnamepack)
				{
				
					if (flaguniquenamepacks)
					{
						// validacion de grid de numeros
						bool flagnumlaminas = true;
						for(int i=0;i<dgdEnvioPT.Items.Count;i++)
						{
							if (flagnumlaminas)
							{
								packnumber = i+1;
								Paquetes[i] = ((TextBox)dgdEnvioPT.Items[i].FindControl("txtPaquete")).Text;
								string Lamins=((TextBox)dgdEnvioPT.Items[i].FindControl("txtLaminas")).Text;
								if(!Plt.IsWholeNumber(Lamins)||Lamins==""||Lamins==string.Empty)
									flagnumlaminas = false;
								else
								{
									int Laminas = Convert.ToInt32(((TextBox)dgdEnvioPT.Items[i].FindControl("txtLaminas")).Text);
									string Tarima=((TextBox)dgdEnvioPT.Items[i].FindControl("txtTarima")).Text;
									sumLaminas+=Laminas;
									SICALNet.BusinessEntities.PartidasEnvioPTInfo PEInfo = new SICALNet.BusinessEntities.PartidasEnvioPTInfo(string.Empty,txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["SendFinishProductRoomId"]),Paquetes[i],Laminas,Tarima);
									EnvioList.Add(PEInfo);				
								}
							}else
								break;

						}
				
						if (flagnumlaminas)			
				
						{

							if(sumLaminas.ToString()!=txtCantidad.Text)
							{
								showalertmessage("El No. de Laminas no coincide con el Numero de Piezas distribuido en los Paquetes");					
							}
							else
							{
								SICALNet.BusinessLogicLayer.PartidasEnvioPT BlPEPT = new SICALNet.BusinessLogicLayer.PartidasEnvioPT();
								BlPEPT.Delete(txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["SendFinishProductRoomId"]));
								BlPEPT.Insert(EnvioList);
								SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["SendFinishProductRoomId"]),Context.User.Identity.Name);
								SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
								BLOrdenes.UpdateLoginForm(OTInfo);
								//Activate Next Area And update Active Area in Programma Production for this Secuencia
								//Depending on sequence available in "FlujoArea" Table
								SICALNet.BusinessLogicLayer.FlujoArea objFlujoArea = new SICALNet.BusinessLogicLayer.FlujoArea();
								objFlujoArea.ActivateDependingAreas(txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["SendFinishProductRoomId"]));
								// To Release the Work Order
								SICALNet.BusinessEntities.OrdenesTrabajoInfo WOInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text, Convert.ToInt32(ConfigurationSettings.AppSettings["SendFinishProductRoomId"]), Convert.ToInt32(ConfigurationSettings.AppSettings["StatusRelease"]), DateTime.Now.Date.ToString("dd/MMM/yyyy"), Context.User.Identity.Name); 
								SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
								WorkOrder.UpdateStatus(WOInfo);
								SICALNet.BusinessLogicLayer.Programa blPrg = new SICALNet.BusinessLogicLayer.Programa();
								blPrg.UpdateProgramaStatus(txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["SequenceStatusReleased"]));
								SICALNet.BusinessEntities.PartidasEnvioPTInfo PEInfo1 = new SICALNet.BusinessEntities.PartidasEnvioPTInfo(string.Empty,txtSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["SendFinishProductRoomId"]),string.Empty,0,string.Empty);
								BlPEPT = new SICALNet.BusinessLogicLayer.PartidasEnvioPT();
								EnvioList=BlPEPT.Select(PEInfo1);
								dgdEnvioPT.DataSource=EnvioList;
								dgdEnvioPT.DataBind();
								btnAgregar.Enabled=false;
								btnLiberar.Enabled=false;
								dgdEnvioPT.Columns[1].Visible=false;
								dgdEnvioPT.Columns[2].Visible=true;
								dgdEnvioPT.Columns[3].Visible=false;
								dgdEnvioPT.Columns[4].Visible=true;
								dgdEnvioPT.Columns[5].Visible=false;
								dgdEnvioPT.Columns[6].Visible=true;
								Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"La Orden de Trabajo se liberó exitosamente"+"');self.location.href='ConsultEnvioPT.aspx';</script>");
								Response.Redirect("ConsultEnvioPT.aspx");					
							}
						}
						else
							showalertmessage("El número de laminas del Paquete " + packnumber.ToString() +  "  debe ser un valor numerico");
					}
					else
						showalertmessage("El nombre del Paquete "+  packnumber.ToString() +" está repetido");
				}
				else
					showalertmessage("Proporcione un nombre para el Paquete "+ packnumber.ToString());
				
			}
			catch
			{
				throw;
			}
		}
		private void ShowMensaje()
		{
			// Display the Messages in Multiline Text box
			SICALNet.BusinessEntities.MensajePisoInfo mpInfo = new SICALNet.BusinessEntities.MensajePisoInfo(txtSecuencia.Text,string.Empty,Convert.ToInt32(ConfigurationSettings.AppSettings["ReceiveFinishProductRoomId"]));
			SICALNet.BusinessLogicLayer.MensajePiso mPiso = new SICALNet.BusinessLogicLayer.MensajePiso();					
			IList mPisoList=mPiso.Select(mpInfo);
			if(mPisoList.Count>0)
			{
				for(int iloop=0;iloop<mPisoList.Count;iloop++)
				{	
					SICALNet.BusinessEntities.MensajePisoInfo mpInfo1 = new SICALNet.BusinessEntities.MensajePisoInfo();
					mpInfo1=(SICALNet.BusinessEntities.MensajePisoInfo)mPisoList[iloop];
					txtMensajePiso.Text+=mpInfo1.Mensaje.ToString();
					txtMensajePiso.Text+="\n";
				}
			}
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("NumeroPaquete.aspx?InitialDate="+Initial+"&FinalDate="+Final+"&cboStatus="+cboStatus+"&cboLinea="+cboLinea+"&Reflag=True&Paquete="+Paquete+"&Laminas="+txtCantidad.Text+"&Fecha="+txtFecha.Text+"&Secuencia="+txtSecuencia.Text+"&Descripcion="+txtUTEC.Text);
		}

		private void cmdMsgPiso_Click(object sender, System.EventArgs e)
		{
			string Secuencia = txtSecuencia.Text;
			string IdArea= ConfigurationSettings.AppSettings["SendFinishProductRoomId"].ToString();
			string CodeSAP=Session["CodigoSAP"].ToString();
			string matDesc=txtUTEC.Text;
			RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('../../MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodeSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");
		}
	}
}
