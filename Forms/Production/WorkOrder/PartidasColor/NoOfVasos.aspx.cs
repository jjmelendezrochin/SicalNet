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

namespace UserInterface.Forms.Production.ColorRoom
{
	/// <summary>
	/// Summary description for NoOfVasos.
	/// </summary>
	public class NoOfVasos : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnOk;
		static bool isNew;
		protected System.Web.UI.WebControls.DataGrid dgdNoVaso;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnBack;
		//static int iVaso;
		protected System.Web.UI.WebControls.DataList lstWorkOrder;
		static int[] aVaso;
		protected System.Web.UI.WebControls.TextBox txtSecuencia;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.TextBox txtUTEC;
		protected System.Web.UI.WebControls.TextBox txtCantidad;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label lblGroup;
		static float[] Aforo;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				try
				{
/*					IList RsPC=(IList) BLLPC.LoadVasoPArtidasColor(Session[this.Context.User.Identity.Name+"Secuencia"].ToString(),0,"Vaso");
					if (RsPC.Count > 0)
					{
						SICALNet.BusinessEntities.PartidasColorInfo BEPC= (SICALNet.BusinessEntities.PartidasColorInfo) RsPC[0];
						if (BEPC.VasoNo > 0)
						{
							txtNoVasos.Text = BEPC.VasoNo.ToString();
							iVaso = BEPC.VasoNo;
						}
					}
					else if (txtNoVasos.Text == "")
					{
						txtNoVasos.Text=Session[this.Context.User.Identity.Name+"NoVaso"].ToString();
						isNew = true;
					}

					if (Session[this.Context.User.Identity.Name+"IdStatus"].ToString() == "5") //if Released then Make the txtNoVasos as ReadOnly
						txtNoVasos.Enabled = false;
	*/
					IList pcList = new ArrayList();
					SICALNet.BusinessLogicLayer.PartidasColor BLLPC = new SICALNet.BusinessLogicLayer.PartidasColor();

					/*Genera un error de invalid Cast */
					int NoGroup = BLLPC.GetNoGroup(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"]));
					IList GrupoList=new ArrayList();
					Aforo = new float[NoGroup];
					for(int i=1;i<=NoGroup;i++)
					{
						SICALNet.BusinessEntities.PartidasColorInfo PCInfo = new SICALNet.BusinessEntities.PartidasColorInfo(i,0,0);
						GrupoList.Add(PCInfo);
					}
					lstWorkOrder.DataSource=GrupoList;
					lstWorkOrder.DataBind();
					for(int i=0;i<lstWorkOrder.Items.Count;i++)
					{
						IList FormColor = new ArrayList();
						DataGrid dgdComp=(DataGrid)lstWorkOrder.Items[i].FindControl("dgdComponent");
						FormColor = (ArrayList) BLLPC.GetFormColor(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString(),i+1,0,Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdPlanta"]),Convert.ToInt32(Session[this.Context.User.Identity.Name+"IdLinea"]));
						dgdComp.DataSource=FormColor;
						dgdComp.DataBind();
					}
					if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
					{
						isNew = false;
						pcList = (IList) BLLPC.GetNoVaso(Session[this.Context.User.Identity.Name+"Secuencia"].ToString());
					}
					else 
					{
						string[] secuencia = (string[])Session[this.Context.User.Identity.Name+"Secuencia"];
						isNew = false;
						pcList = (IList) BLLPC.GetNoVaso(secuencia[0]);

					}
					if (pcList.Count > 0) 
					{
						lblGroup.Text = pcList.Count.ToString();
						Session[this.Context.User.Identity.Name+"NoGroup"] = pcList.Count.ToString();
						dgdNoVaso.DataSource = pcList;
						dgdNoVaso.DataBind();
						aVaso = new int[pcList.Count];
						for(int i=0;i<aVaso.Length;i++)
							aVaso[i] = Convert.ToInt32(((TextBox)dgdNoVaso.Items[i].FindControl("txtNoVaso")).Text);
						
					}
					else
					{
						aVaso=null;
						//int NoGroup = BLLPC.GetNoGroup(Session[this.Context.User.Identity.Name+"CodigoSAP"].ToString());
						lblGroup.Text = NoGroup.ToString();
						Session[this.Context.User.Identity.Name+"NoGroup"] = NoGroup.ToString();

						isNew = true;
						DataTable dtVaso = new DataTable("Vaso");
						DataColumn dcVaso = new DataColumn("GroupNo"); 
						DataColumn dcLaminas = new DataColumn("NoVaso");
						DataColumn dcAforo = new DataColumn("Aforo");
						dtVaso.Columns.Add(dcVaso);
						dtVaso.Columns.Add(dcLaminas);
						dtVaso.Columns.Add(dcAforo);

						for (int iLoop = 1; iLoop <= NoGroup; iLoop++)
						{
							DataRow drVaso = dtVaso.NewRow();
							drVaso["GroupNo"]="Componente " + iLoop.ToString();
							drVaso["NoVaso"] = string.Empty;
							drVaso["Aforo"] = string.Empty;
							dtVaso.Rows.Add(drVaso);
						}
						dgdNoVaso.DataSource = dtVaso;
						dgdNoVaso.DataBind();
						
					}
					
					if (Session[this.Context.User.Identity.Name+"IdStatus"].ToString() == "5") //if its Released then disable the textbox column
					{
						dgdNoVaso.Columns[1].Visible = false;
						dgdNoVaso.Columns[2].Visible = true;
						dgdNoVaso.Columns[3].Visible = true;
						dgdNoVaso.Columns[4].Visible = false;
					}

					//display information of the sequence on the page
					displaySelectedSequenceValues();
				}
				catch(Exception ErHnd)
				{
					//to display the msg for user
					string ScriptString="<script language='javascript'>alert('"+ ErHnd.Message +"');</script>"; 
					ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
				}
			}
		}

		private void displaySelectedSequenceValues()
		{
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
				int CantidadSum=0;
				for(int i=0;i<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);i++)
				{
					txtSecuencia.Text+=Secuencia[i]+",";
					txtFecha.Text+=Fecha[i]+",";
					CantidadSum+=Cantidad[i];
				}
				txtCantidad.Text=CantidadSum.ToString();
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
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//to set the session variable and navigate next form
		private void btnOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				int[] NoVaso = new int[Convert.ToInt32(lblGroup.Text)];
				for(int i=0;i<dgdNoVaso.Items.Count;i++)
				{
					if (Session[this.Context.User.Identity.Name+"IdStatus"].ToString()=="5")
					{
						NoVaso[i] = Convert.ToInt32(((Label)dgdNoVaso.Items[i].FindControl("lblNoVaso")).Text);
						Aforo[i]=Convert.ToSingle(((Label)dgdNoVaso.Items[i].FindControl("lblAforo")).Text);
					}
					else
					{
						NoVaso[i] = Convert.ToInt32(((TextBox)dgdNoVaso.Items[i].FindControl("txtNoVaso")).Text);
						TextBox currentAforo =  (TextBox)dgdNoVaso.Items[i].FindControl("txtAforo");
						Aforo[i]=Convert.ToSingle(currentAforo.Text.Trim()==string.Empty?"0":currentAforo.Text);
					}
					if (aVaso==null)
						isNew=true;
					else if(aVaso[i]!=NoVaso[i])
					isNew=true;
				}
				
				Session[this.Context.User.Identity.Name+"NoVaso"] = NoVaso;
				Session[this.Context.User.Identity.Name+"Aforo"] = Aforo;
				Response.Redirect("VasosDetails.aspx?isNew=" + isNew);

				//to get an instance for validation
/*				Validation pltVdlt=new Validation();

				if (pltVdlt.IsNumber(txtNoVasos.Text) == false)
					throw new Exception("It should be number");
				if (int.Parse(txtNoVasos.Text) > 0)
				{
					if (iVaso != Convert.ToInt32(txtNoVasos.Text)) isNew = true;
					Session[this.Context.User.Identity.Name+"NoVaso"]=txtNoVasos.Text;
					Response.Redirect("VasosDetails.aspx?isNew=" + isNew);
				}
*/
			}
			catch(FormatException)
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('El número de vasos es incorrecto');</script>"; 
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
			}
			catch
			{
				throw;
			}
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ConsultColorWO.aspx");
		}

	}
}
