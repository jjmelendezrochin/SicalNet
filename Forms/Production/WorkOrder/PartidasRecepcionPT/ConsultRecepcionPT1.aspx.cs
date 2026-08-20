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

namespace UserInterface.Forms.Production.WorkOrder.PartidasRecepcionPT
{
	/// <summary>
	/// Summary description for ConsultRecepcionPT1.
	/// </summary>
	public class ConsultRecepcionPT1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.TextBox txtSecuencia;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.TextBox txtUTEC;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected System.Web.UI.WebControls.Button btnAgregar;
		protected System.Web.UI.WebControls.Button btnLiberar;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected static string Initial;
		protected static string Final;
		protected static string cboStatus;
		protected static string cboLinea;
		protected System.Web.UI.WebControls.DataGrid dgdRecepcionPT;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtPiso;
		protected System.Web.UI.WebControls.Button btnMensaje;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label Label8;
		protected static string IdStatus;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);

			if(!IsPostBack)
			{
				btnAgregar.Attributes.Add("onClick","showWaitControls()");
				btnCancelar.Attributes.Add("onClick","showWaitControls()");
				btnLiberar.Attributes.Add("onClick","showWaitControls()");
				btnMensaje.Attributes.Add("onClick","showWaitControls()");

				Initial=Request.QueryString["InitialDate"].ToString();
				Final=Request.QueryString["FinalDate"].ToString();
				cboStatus=Request.QueryString["cboStatus"].ToString();
				cboLinea=Request.QueryString["cboLinea"].ToString();
				txtSecuencia.Text=Request.QueryString["Secuencia"].ToString();
				txtUTEC.Text=Request.QueryString["Descripcion"].ToString();
				txtFecha.Text=Request.QueryString["Fecha"].ToString();
				SICALNet.BusinessEntities.PartidasRecepcionPTInfo PRInfo = new SICALNet.BusinessEntities.PartidasRecepcionPTInfo(string.Empty,txtSecuencia.Text,Convert.ToInt32(ConfigurationManager.AppSettings["ReceiveFinishProductRoomId"]),string.Empty,0,0,string.Empty);
				SICALNet.BusinessLogicLayer.PartidasRecepcionPT BlPRPT = new SICALNet.BusinessLogicLayer.PartidasRecepcionPT();
				IList RecepcionList=BlPRPT.Select(PRInfo);
				if(RecepcionList.Count==0)
				{
				
					// Create a DataSet.
					DataSet dsPaquete = new DataSet("dsPaquete");
					//Create a DataTable.
					DataTable dtPaquete = new DataTable("Paquete");
					//Create three columns, and add them to the first table.
					DataColumn dcPaqueteNo = new DataColumn("PaqueteNo");
					DataColumn dcPaquete = new DataColumn("Paquete"); 
					DataColumn dcLaminas = new DataColumn("Laminas");
					DataColumn dcLaminasReal = new DataColumn("LaminasReal");
					DataColumn dcTarima = new DataColumn("Tarima");
					//assign the datacolum into datatable
					dtPaquete.Columns.Add(dcPaqueteNo);
					dtPaquete.Columns.Add(dcPaquete);
					dtPaquete.Columns.Add(dcLaminas);
					dtPaquete.Columns.Add(dcLaminasReal);
					dtPaquete.Columns.Add(dcTarima);
					//Add the tables to the DataSet.
					dsPaquete.Tables.Add(dtPaquete);
					SICALNet.BusinessEntities.PartidasEnvioPTInfo PEInfo = new SICALNet.BusinessEntities.PartidasEnvioPTInfo(string.Empty,txtSecuencia.Text,Convert.ToInt32(ConfigurationManager.AppSettings["SendFinishProductRoomId"]),string.Empty,0,string.Empty);
					SICALNet.BusinessLogicLayer.PartidasEnvioPT BlPEPT = new SICALNet.BusinessLogicLayer.PartidasEnvioPT();
					IList EnvioList=BlPEPT.Select(PEInfo);
					for (int iLoop=1; iLoop <= EnvioList.Count; iLoop++)
					{
						PEInfo = (SICALNet.BusinessEntities.PartidasEnvioPTInfo)EnvioList[iLoop-1];
						DataRow drPaquete = dtPaquete.NewRow();
						drPaquete["PaqueteNo"] = PEInfo.PaqueteNo;
						drPaquete["Paquete"]=PEInfo.Paquete;
						drPaquete["Laminas"] = PEInfo.Laminas;
						drPaquete["LaminasReal"] = 0;
						drPaquete["Tarima"] = PEInfo.Tarima;
						dtPaquete.Rows.Add(drPaquete);
					}
					dgdRecepcionPT.DataSource=dsPaquete;
					dgdRecepcionPT.DataBind();
				}
				else
				{
					dgdRecepcionPT.DataSource=RecepcionList;
					dgdRecepcionPT.DataBind();
				}
				CalculateDifferance();
				if(Request.QueryString["Status"]==ConfigurationManager.AppSettings["StatusRelease"])
				{
					btnAgregar.Enabled=false;
					btnLiberar.Enabled=false;
					dgdRecepcionPT.Columns[3].Visible=false;
					dgdRecepcionPT.Columns[4].Visible=true;
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
			this.dgdRecepcionPT.SelectedIndexChanged += new System.EventHandler(this.dgdRecepcionPT_SelectedIndexChanged);
			this.btnMensaje.Click += new System.EventHandler(this.btnMensaje_Click);
			this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void txtlaminas(object sender, System.EventArgs e)
		{
			TextBox laminas=(TextBox)sender;
			int g;
			try
			{
				g = System.Convert.ToInt32(laminas.Text);
			
			if (g > 0)
			{
				// revisamos que sea la diferencia
				checkDifferance();
			}
			else
			{
				laminas.Text = "0";				
			} 
			}
			catch
			{
				if (laminas.Text.IndexOf(".") > 0){				
				string ScriptString="<script language='javascript'>alert('La cantidad ingresada es incorrecta');</script>"; 
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
				laminas.Text = "0";
				}
				
			}
			
		}

		private void checkDifferance()
		{
			int sumLaminas=0;
			for(int i=0;i<dgdRecepcionPT.Items.Count;i++)
			{
				int Laminas=Convert.ToInt32(((Label)dgdRecepcionPT.Items[i].FindControl("lblLaminas")).Text);
				int LaminasReal = Convert.ToInt32(((TextBox)dgdRecepcionPT.Items[i].FindControl("txtLaminasReal")).Text);
				int tt = Laminas - LaminasReal;
				if (tt == 0)
				{
					sumLaminas+=Laminas;
					((Label)dgdRecepcionPT.Items[i].FindControl("lblDifferencia")).Text = Convert.ToString(Laminas-LaminasReal);
				}
				else
				{
					((Label)dgdRecepcionPT.Items[i].FindControl("lblDifferencia")).Text = Convert.ToString(Laminas);
					TextBox LamReal = (TextBox)dgdRecepcionPT.Items[i].FindControl("txtLaminasReal");
					if (LamReal.Text != "0")
					{ 
						string ScriptString="<script language='javascript'>alert('La cantidad ingresada debe ser igual al número de Laminas por Paquete');</script>"; 
						ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
					}
					LamReal.Text = "0";
				}
			}
			txtCantidad.Text=sumLaminas.ToString();
		}

		private void CalculateDifferance()
		{
			int sumLaminas=0;
			for(int i=0;i<dgdRecepcionPT.Items.Count;i++)
			{
				int Laminas=Convert.ToInt32(((Label)dgdRecepcionPT.Items[i].FindControl("lblLaminas")).Text);
				int LaminasReal = Convert.ToInt32(((TextBox)dgdRecepcionPT.Items[i].FindControl("txtLaminasReal")).Text);
				sumLaminas+=Laminas;
				((Label)dgdRecepcionPT.Items[i].FindControl("lblDifferencia")).Text = Convert.ToString(Laminas-LaminasReal);
			}
			txtCantidad.Text=sumLaminas.ToString();
		}

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
			try
			{
				IList RecepcionList=new ArrayList();
				for(int i=0;i<dgdRecepcionPT.Items.Count;i++)
				{
					string Paquete = ((Label)dgdRecepcionPT.Items[i].FindControl("lblPaquete")).Text;
					int Laminas=Convert.ToInt32(((Label)dgdRecepcionPT.Items[i].FindControl("lblLaminas")).Text);
					int LaminasReal = Convert.ToInt32(((TextBox)dgdRecepcionPT.Items[i].FindControl("txtLaminasReal")).Text);
					string Tarima = ((Label)dgdRecepcionPT.Items[i].FindControl("lblTarima")).Text;
					SICALNet.BusinessEntities.PartidasRecepcionPTInfo PRInfo = new SICALNet.BusinessEntities.PartidasRecepcionPTInfo(string.Empty,txtSecuencia.Text,Convert.ToInt32(ConfigurationManager.AppSettings["ReceiveFinishProductRoomId"]),Paquete,Laminas,LaminasReal,Tarima);
					RecepcionList.Add(PRInfo);
				}
				if(RecepcionList.Count>0)
				{
					SICALNet.BusinessLogicLayer.PartidasRecepcionPT BlPRPT = new SICALNet.BusinessLogicLayer.PartidasRecepcionPT();
					BlPRPT.Delete(txtSecuencia.Text,Convert.ToInt32(ConfigurationManager.AppSettings["ReceiveFinishProductRoomId"]));
					BlPRPT.Insert(RecepcionList);
					SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text,Convert.ToInt32(ConfigurationManager.AppSettings["ReceiveFinishProductRoomId"]),Context.User.Identity.Name);
					SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
					BLOrdenes.UpdateLoginForm(OTInfo);
					Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"La orden de trabajo se salvó exitosamente"+"')" + "<" + "/script>");
				}
			}
			catch
			{
				//to display the msg for user
//				string ScriptString="<script language='javascript'>alert('"+ ex.Message +"');</script>"; 
//				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);

				throw;
			}
		}

		private void btnLiberar_Click(object sender, System.EventArgs e)
		{
			try
			{
				int SumLaminasReal=0;
				IList RecepcionList=new ArrayList();
				for(int i=0;i<dgdRecepcionPT.Items.Count;i++)
				{
					string Paquete = ((Label)dgdRecepcionPT.Items[i].FindControl("lblPaquete")).Text;
					int Laminas=Convert.ToInt32(((Label)dgdRecepcionPT.Items[i].FindControl("lblLaminas")).Text);
					int LaminasReal = Convert.ToInt32(((TextBox)dgdRecepcionPT.Items[i].FindControl("txtLaminasReal")).Text);
					string Tarima = ((Label)dgdRecepcionPT.Items[i].FindControl("lblTarima")).Text;
					SICALNet.BusinessEntities.PartidasRecepcionPTInfo PRInfo = new SICALNet.BusinessEntities.PartidasRecepcionPTInfo(string.Empty,txtSecuencia.Text,Convert.ToInt32(ConfigurationManager.AppSettings["ReceiveFinishProductRoomId"]),Paquete,Laminas,LaminasReal,Tarima);
					RecepcionList.Add(PRInfo);
					SumLaminasReal+=LaminasReal;
				}
				if(RecepcionList.Count>0)
				{
					SICALNet.BusinessLogicLayer.PartidasRecepcionPT BlPRPT = new SICALNet.BusinessLogicLayer.PartidasRecepcionPT();
					BlPRPT.Delete(txtSecuencia.Text,Convert.ToInt32(ConfigurationManager.AppSettings["ReceiveFinishProductRoomId"]));
					BlPRPT.Insert(RecepcionList);
					SICALNet.BusinessEntities.OrdenesTrabajoInfo OTInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text,Convert.ToInt32(ConfigurationManager.AppSettings["ReceiveFinishProductRoomId"]),Context.User.Identity.Name);
					SICALNet.BusinessLogicLayer.OrdenesTrabajo BLOrdenes = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
					BLOrdenes.UpdateLoginForm(OTInfo);
					
				}

				
				//Activate Next Area And update Active Area in Programma Production for this Secuencia
				//Depending on sequence available in "FlujoArea" Table
				SICALNet.BusinessLogicLayer.FlujoArea objFlujoArea = new SICALNet.BusinessLogicLayer.FlujoArea();
				objFlujoArea.ActivateDependingAreas(txtSecuencia.Text,Convert.ToInt32(ConfigurationManager.AppSettings["ReceiveFinishProductRoomId"]));
				// To Release the Work Order
				SICALNet.BusinessEntities.OrdenesTrabajoInfo WOInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(txtSecuencia.Text, Convert.ToInt32(ConfigurationManager.AppSettings["ReceiveFinishProductRoomId"]), Convert.ToInt32(ConfigurationManager.AppSettings["StatusRelease"]), DateTime.Now.Date.ToString("dd/MMM/yyyy"), Context.User.Identity.Name); 
				SICALNet.BusinessLogicLayer.OrdenesTrabajo WorkOrder = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
				WorkOrder.UpdateStatus(WOInfo);
				SICALNet.BusinessEntities.PartidasRecepcionPTInfo PRInfo1 = new SICALNet.BusinessEntities.PartidasRecepcionPTInfo(string.Empty,txtSecuencia.Text,Convert.ToInt32(ConfigurationManager.AppSettings["ReceiveFinishProductRoomId"]),string.Empty,0,0,string.Empty);
				SICALNet.BusinessLogicLayer.PartidasRecepcionPT BlPRPT1 = new SICALNet.BusinessLogicLayer.PartidasRecepcionPT();
				RecepcionList=BlPRPT1.Select(PRInfo1);
				dgdRecepcionPT.DataSource=RecepcionList;
				dgdRecepcionPT.DataBind();
				btnAgregar.Enabled=false;
				btnLiberar.Enabled=false;
				dgdRecepcionPT.Columns[3].Visible=false;
				dgdRecepcionPT.Columns[4].Visible=true;
				Response.Redirect("ConsultRecepcionPT.aspx");
//				Page.RegisterStartupScript("alert", "<script language='JavaScript'>" + "alert('"+"La Orden de Trabajo se libero exitosamente"+"');self.location.href='ConsultRecepcionPT.aspx';</script>");
			
            }
			catch
			{
				//to display the msg for user
//				string ScriptString="<script language='javascript'>alert('"+ ex.Message +"');</script>"; 
//				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);

				throw;
			}
			 
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ConsultRecepcionPT.aspx?InitialDate="+Initial+"&FinalDate="+Final+"&cboStatus="+cboStatus+"&cboLinea="+cboLinea+"&Reflag=True");
		}

		private void dgdRecepcionPT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ShowMensaje()
		{
			// Display the Messages in Multiline Text box
			SICALNet.BusinessEntities.MensajePisoInfo mpInfo = new SICALNet.BusinessEntities.MensajePisoInfo(txtSecuencia.Text,string.Empty,Convert.ToInt32(ConfigurationManager.AppSettings["ReceiveFinishProductRoomId"]));
			SICALNet.BusinessLogicLayer.MensajePiso mPiso = new SICALNet.BusinessLogicLayer.MensajePiso();					
			IList mPisoList=mPiso.Select(mpInfo);
			if(mPisoList.Count>0)
			{
				for(int iloop=0;iloop<mPisoList.Count;iloop++)
				{	
					SICALNet.BusinessEntities.MensajePisoInfo mpInfo1 = new SICALNet.BusinessEntities.MensajePisoInfo();
					mpInfo1=(SICALNet.BusinessEntities.MensajePisoInfo)mPisoList[iloop];
					txtPiso.Text+=mpInfo1.Mensaje.ToString();
					txtPiso.Text+="\n";
				}
			}
		}

		private void btnMensaje_Click(object sender, System.EventArgs e)
		{
			string Secuencia = txtSecuencia.Text;
			string IdArea= ConfigurationManager.AppSettings["ReceiveFinishProductRoomId"].ToString();
			string CodeSAP=Session["CodigoSAP"].ToString();
			string matDesc=txtUTEC.Text;
			RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('../../MensajePopup.aspx?Secuencia="+Secuencia+"&AreaId="+IdArea+"&CodigoSAP="+CodeSAP+"&MaterialDescription="+matDesc+"','anycontent','width=600,height=550,left=100, top=150,status,scrollbars=no'); </script>");
		}
	}
}
