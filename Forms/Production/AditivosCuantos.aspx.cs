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
using System.Configuration;

namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for NoOfVasos.
	/// </summary>
	public class CuantosOllas : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnOk;
		protected System.Web.UI.WebControls.TextBox txtNoVasos;
		protected System.Web.UI.WebControls.TextBox txtCuanto;
		static string flag="0";
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button cmdAnterior;
		static int Container=0;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblSecuencia;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		static string reflag;
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);

			if(!IsPostBack)
			{
				if(Session[this.Context.User.Identity.Name+"FormularFlag"].ToString()=="0")
				{
					flag="0";
					string secuencia=Session[this.Context.User.Identity.Name+"Secuencia"].ToString();
					lblSecuencia.Text=secuencia;
					lblDescripcion.Text=Request.QueryString["Descripcion"].ToString();
					if(Session[this.Context.User.Identity.Name+"IdStatus"].ToString()=="5")
						txtCuanto.Enabled=false;
					SICALNet.BusinessLogicLayer.PartidasAditivos blPartidasAdi = new SICALNet.BusinessLogicLayer.PartidasAditivos();
					if(blPartidasAdi.IsExistSecuencia(secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"])))
					{
						flag="1";
						Container=(int)blPartidasAdi.GetNoContainers(secuencia,Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]));
						txtCuanto.Text=Container.ToString();
					}
				}
				else
				{
					flag="0";
					string[] secuencia=(string[])Session[this.Context.User.Identity.Name+"Secuencia"];
					for(int i=0;i<Convert.ToInt32(Session[this.Context.User.Identity.Name+"FormularFlag"]);i++)
						lblSecuencia.Text+=secuencia[i]+",";
					lblDescripcion.Text=Request.QueryString["Descripcion"].ToString();
					if(Session[this.Context.User.Identity.Name+"IdStatus"].ToString()=="5")
						txtCuanto.Enabled=false;
					SICALNet.BusinessLogicLayer.PartidasAditivos blPartidasAdi = new SICALNet.BusinessLogicLayer.PartidasAditivos();
					reflag=Request.QueryString["ReFlag"].ToString();
					if(Request.QueryString["ReFlag"].ToString()=="False")
					{
						flag="1";
						Container=(int)blPartidasAdi.GetNoContainers(secuencia[0],Convert.ToInt32(ConfigurationSettings.AppSettings["AditivosRoomId"]));
						txtCuanto.Text=Container.ToString();
					}

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
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.cmdAnterior.Click += new System.EventHandler(this.cmdAnterior_Click);
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				//to get an instance for validation
				Validation pltVdlt=new Validation();
				if(flag=="11")//to change the flag settings when back button is pressed in next page
					flag="1";
				if (pltVdlt.IsNumber(txtCuanto.Text) == false)
					throw new Exception("Favor de especificar el número de láminas x olla.");
				string seqence=Session[this.Context.User.Identity.Name+"Secuencia"].ToString();
				string Cantidad=Session[this.Context.User.Identity.Name+"Cantidad"].ToString();
				if (int.Parse(txtCuanto.Text) > 0)
				{
					string IdLinea=Session[this.Context.User.Identity.Name+"IdLinea"].ToString();
					Session[this.Context.User.Identity.Name+"NoCuanto"]=txtCuanto.Text;
					if(Convert.ToString(Container)==txtCuanto.Text.ToString())
						flag+="1";
					else
						flag+="0";
					string Status=Session[this.Context.User.Identity.Name+"IdStatus"].ToString();
					Response.Redirect("AditivosLaminos.aspx?Secuencia="+seqence+"&NoCuanto="+txtCuanto.Text+"&Cantidad="+Cantidad+"&IdLinea="+IdLinea+"&flag="+flag+"&Status="+Status+"&ReFlag="+reflag+"&Descripcion="+lblDescripcion.Text);

				}

			}
			catch(Exception ErrHand)
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('"+ ErrHand.Message +"');</script>"; 
				Page.RegisterStartupScript("ClientScript",ScriptString);
			}
		}

		private void cmdAnterior_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ConsultAditivosWO.aspx");
		}
	}
}
