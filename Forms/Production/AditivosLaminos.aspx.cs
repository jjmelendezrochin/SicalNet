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
using SICALNet.Utilities;

namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for OllasDetails.
	/// </summary>
	public class CuantosDetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblCantidad;
		protected System.Web.UI.WebControls.DataGrid dgdQtyOlla;
		protected System.Web.UI.WebControls.Button btnNext;
		protected System.Web.UI.WebControls.Button Button1;
		protected DataSet dsCuanto;
		string flag1="0";
		static string status;
		static string codigosap;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
		static float[] OllaUsed;
		static int[] Cantidad;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblSecuencia;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		static string sec="'";
		protected System.Web.UI.WebControls.Label Label3; 
		static string reflag="";
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);

			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				reflag=Request.QueryString["ReFlag"].ToString();
				if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
				{
					lblCantidad.Text = Session[this.Context.User.Identity.Name+"Cantidad"].ToString();
					lblSecuencia.Text=Session[this.Context.User.Identity.Name+"Secuencia"].ToString();
					lblDescripcion.Text=Request.QueryString["Descripcion"].ToString();
					status=Request.QueryString["Status"].ToString();
					codigosap=Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString();
					prcFillGrid();
				}
				else
				{
					lblDescripcion.Text=Request.QueryString["Descripcion"].ToString();
					codigosap=Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString();
					status=Session[this.Context.User.Identity.Name+"IdStatus"].ToString();
					Cantidad=new int[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
					Cantidad=(int[])Session[this.Context.User.Identity.Name+"Cantidad"];
					int CantidadSum=0;
					for(int i=0;i<Cantidad.Length;i++)
						CantidadSum+=Cantidad[i];
					lblCantidad.Text = CantidadSum.ToString();
					prcFillGrid();
				}
			}
		}

		private void prcFillGrid()
		{
			if(Convert.ToInt32(Session[this.Context.User.Identity.Name+"NoCuanto"].ToString())>0)
			{
				MakeDataSet(Convert.ToInt32(Session[this.Context.User.Identity.Name+"NoCuanto"].ToString()));
			}
		}

		private void MakeDataSet(int NoOlla)
		{
			// Create a DataSet.
			dsCuanto = new DataSet("dsCuanto");
			//Create two DataTables.
			DataTable dtCuanto= new DataTable("Olla");
			//Create two columns, and add them to the first table.
			DataColumn dcCuanto = new DataColumn("NumeroOlla"); 
			DataColumn dcLaminas = new DataColumn("NoLaminas");
			DataColumn dcCapacidadOlla = new DataColumn("CapacidadOlla");			
			DataColumn dcSobrante = new DataColumn("Sobrante");	

			//assign the datacolum into datatable
			dtCuanto.Columns.Add(dcCuanto);
			dtCuanto.Columns.Add(dcLaminas);
			dtCuanto.Columns.Add(dcCapacidadOlla);
			dtCuanto.Columns.Add(dcSobrante);

			//Add the tables to the DataSet.
			dsCuanto.Tables.Add(dtCuanto);
			//Populates the tables., 
			//creates DataRow variables. 
			for(int i=1; i<=NoOlla;i++)
			{
				DataRow drCuanto = dtCuanto.NewRow();
				drCuanto["NumeroOlla"]="No. "+i.ToString();
				dtCuanto.Rows.Add(drCuanto);
   			}
			dgdQtyOlla.DataSource=dsCuanto;
			dgdQtyOlla.DataBind();			
			int Lamina=0;
			double Sobrante = 0;
			OllaUsed = new float[NoOlla];
			IList NoOllaList = new ArrayList();
			if(Request.QueryString["flag"].ToString()=="11")
			{
				if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
				{
					SICALNet.BusinessLogicLayer.PartidasAditivos blPAdt= new SICALNet.BusinessLogicLayer.PartidasAditivos();
					NoOllaList=(IList)blPAdt.LoadOlla(Session[this.Context.User.Identity.Name+"Secuencia"].ToString(),0,"Olla");
					dsCuanto.Clear();
					for (int iLoop=1; iLoop <= NoOlla; iLoop++)
					{
						DataRow drCuanto = dtCuanto.NewRow();
						drCuanto["NumeroOlla"]="Cuanto"+iLoop.ToString();
						if(Request.QueryString["flag"].ToString()=="11")
						{
							SICALNet.BusinessEntities.PartidasAditivosInfo PAInfo = new SICALNet.BusinessEntities.PartidasAditivosInfo();
							PAInfo = (SICALNet.BusinessEntities.PartidasAditivosInfo)NoOllaList[iLoop-1];
							OllaUsed[iLoop-1]=PAInfo.CapacidadOlla;
							Sobrante =PAInfo.Sobrante;
							Lamina=blPAdt.GetNoLaminas1(Request.QueryString["Secuencia"].ToString(),PAInfo.NumeroOlla);
						}
						drCuanto["NoLaminas"]=Lamina;
						drCuanto["CapacidadOlla"]=OllaUsed[iLoop-1];
						drCuanto["Sobrante"]=Math.Round((decimal)Sobrante, 3);
						dtCuanto.Rows.Add(drCuanto);
					}
					dgdQtyOlla.DataSource=dsCuanto;
					dgdQtyOlla.DataBind();
			
				}
				else
				{
					if(sec!="'")
						sec="'";
					string[] secuencia = new string[Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])];
					secuencia=(string[])Session[this.Context.User.Identity.Name+"Secuencia"];
					for(int i=0;i<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);i++)
					{
						
						sec+=secuencia[i];
						if(i!=(Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"])-1))
							sec+="','";
						else
							sec+="'";
					}
				
					SICALNet.BusinessLogicLayer.PartidasAditivos blPAdt= new SICALNet.BusinessLogicLayer.PartidasAditivos();
					NoOllaList=(IList)blPAdt.LoadOllaCombined(sec);
					dgdQtyOlla.DataSource=NoOllaList;
					dgdQtyOlla.DataBind();
					OllaUsed = new float[NoOllaList.Count];
					for (int iLoop=0; iLoop < NoOllaList.Count; iLoop++)
					{
						SICALNet.BusinessEntities.PartidasAditivosInfo bePAdt = new SICALNet.BusinessEntities.PartidasAditivosInfo();
						bePAdt=(SICALNet.BusinessEntities.PartidasAditivosInfo)NoOllaList[iLoop];
						OllaUsed[iLoop]=bePAdt.CapacidadOlla;
					
					}
				}
			}
			
			SICALNet.BusinessEntities.OllaInfo oInfo = new SICALNet.BusinessEntities.OllaInfo(0,Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"]),0,0);
			SICALNet.BusinessLogicLayer.Olla blOlla = new SICALNet.BusinessLogicLayer.Olla();
			IList OllaList=(IList)blOlla.SelectOlla(oInfo); 
			// Llena lista de capacidades de olla	
			for(int i=0;i<dgdQtyOlla.Items.Count;i++)
			{				
				((DropDownList)dgdQtyOlla.Items[i].FindControl("cmbOlla")).DataSource=OllaList;
				//((DropDownList)dgdQtyOlla.Items[i].FindControl("cmbOlla")).DataValueField = "CapacidadMin";
				((DropDownList)dgdQtyOlla.Items[i].FindControl("cmbOlla")).DataTextField = "CapacidadMax";
				((DropDownList)dgdQtyOlla.Items[i].FindControl("cmbOlla")).DataBind();
				if(Request.QueryString["flag"].ToString()=="11")
				{
					SICALNet.BusinessEntities.PartidasAditivosInfo PAInfo = new SICALNet.BusinessEntities.PartidasAditivosInfo();
					PAInfo = (SICALNet.BusinessEntities.PartidasAditivosInfo)NoOllaList[i];
					((DropDownList)dgdQtyOlla.Items[i].FindControl("cmbOlla")).Items.FindByText(PAInfo.CapacidadOlla.ToString()).Selected=true;
				}
				
			}
			if(status=="5")
			{
				dgdQtyOlla.Columns[2].Visible=true;
				dgdQtyOlla.Columns[1].Visible=false;
				dgdQtyOlla.Columns[4].Visible=true;
				dgdQtyOlla.Columns[3].Visible=false;
				
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnNext_Click(object sender, System.EventArgs e)
		{
//			try
//			{
				 Validation pltVdlt=new Validation();
				int NoCuanto=int.Parse(Session[this.Context.User.Identity.Name+"NoCuanto"].ToString());
				int[] aryLaminas = new int[NoCuanto]; // Arreglo de láminas
				float[] aryOlla = new float[NoCuanto]; // Arreglo de ollas
				float[] arySobrante = new float[NoCuanto]; // Arreglo de Sobrante

				/*** modificado por alejandro.hernandez@nasoft.com 22022006 ***/
				System.Text.StringBuilder sQryString = new System.Text.StringBuilder();
//				string sQryString=string.Empty;
				int TtlCuanto=0;
				for(int iLoop=0; iLoop < NoCuanto;iLoop++)
				{
					string sLaminas;
					float Olla=0;
					double Sobrante=0;					
					if(status=="5")
					{
						sLaminas=((Label) dgdQtyOlla.Items[iLoop].Cells[1].FindControl("lblLaminas")).Text.ToString();
						Olla=Convert.ToInt32(((Label)dgdQtyOlla.Items[iLoop].FindControl("lblCapacidad")).Text.ToString());
						Sobrante=Convert.ToDouble(((Label)dgdQtyOlla.Items[iLoop].FindControl("lblSobrante")).Text.ToString());
					}
					else
					{
						string sSobrante = ((TextBox)dgdQtyOlla.Items[iLoop].FindControl("txtSobrante")).Text.ToString();
						if (sSobrante =="")
							sSobrante = "0";
						sLaminas=((TextBox) dgdQtyOlla.Items[iLoop].Cells[1].FindControl("txtLaminas")).Text.ToString();
						Olla=Convert.ToSingle(((DropDownList)dgdQtyOlla.Items[iLoop].FindControl("cmbOlla")).SelectedItem.Text);
						Sobrante=Convert.ToDouble(sSobrante);
					}
					if(status!="5")
					{
						if (pltVdlt.IsNumber(sLaminas) == false)
							throw new Exception("Proporcione la cantidad de láminas a preparar");
						SICALNet.BusinessLogicLayer.PartidasAditivos blPartidas = new SICALNet.BusinessLogicLayer.PartidasAditivos();
						int idplanta=Convert.ToInt32(Session[this.Context.User.Identity.Name+"idplanta"]);
						blPartidas.CheckOlla(codigosap,Convert.ToInt32(sLaminas),Olla,10,idplanta);
					}
					TtlCuanto+=int.Parse(sLaminas);
					sQryString.Append("CuantoQty=").Append(sLaminas);
					if (iLoop < NoCuanto-1)
						sQryString.Append("&");					
					aryLaminas[iLoop]=int.Parse(sLaminas);
					aryOlla[iLoop]=Olla;
					arySobrante[iLoop]=float.Parse(Sobrante.ToString());

					if(Request.QueryString["flag"].ToString()=="11"||OllaUsed[iLoop]==Olla)
					{				
						SICALNet.BusinessLogicLayer.PartidasAditivos blPAdt= new SICALNet.BusinessLogicLayer.PartidasAditivos();
						int Lamina;
						if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
							Lamina=blPAdt.GetNoLaminas1(Request.QueryString["Secuencia"].ToString(),iLoop+1);
						else
							Lamina=blPAdt.GetNoLaminasCombined(sec,iLoop+1);
						if(sLaminas==Lamina.ToString())
							flag1="1";
					}

				}
				

				if(TtlCuanto!=Convert.ToInt32(lblCantidad.Text.ToString()))
					throw new Exception("La suma de las láminas por olla debe ser igual al total de las láminas de la secuencia.");
				Session[this.Context.User.Identity.Name+"VasoQty"]=aryLaminas;  // Coloca en variable de sesion el arreglo de laminas
				Session[this.Context.User.Identity.Name+"flag"]=flag1;			// Coloca en variable de sesion el arreglo de banderas
				Session[this.Context.User.Identity.Name+"Olla"]=aryOlla;		// Coloca en variable de sesion el arreglo de ollas
				Session[this.Context.User.Identity.Name+"Sobrante"]=arySobrante;// Coloca en variable de sesion el arreglo de ollas				
				
				Response.Redirect("AditivosCuarto.aspx?CantidadSum="+lblCantidad.Text);
				
//			}
//			catch(Exception ErrHand)
//			{
//				//to display the msg for user
//				string ScriptString="<script language='javascript'>alert('"+ ErrHand.Message +" Favor de capturar solo números en número de láminas por olla y Sobrante');</script>"; 
//				Page.RegisterStartupScript("ClientScript",ScriptString);
//			}
		}
		
		
		private void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AditivosCuantos.aspx?Descripcion="+lblDescripcion.Text+"&ReFlag="+reflag);
		}

		
	}
}
