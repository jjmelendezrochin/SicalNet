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
	/// Summary description for NumeroPaquete.
	/// </summary>
	public class NumeroPaquete : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblSecuencia;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtCuanto;
		protected System.Web.UI.WebControls.Button cmdAnterior;
		protected System.Web.UI.WebControls.Label lblLaminas;
		protected System.Web.UI.WebControls.Button btnOk;
		protected static string Initial;
		protected static string Final;
		protected static string cboStatus;
		protected static string cboLinea;
		protected static int Packs;
		protected static string IdStatus;
		protected System.Web.UI.WebControls.Label Label5;
		protected static string Fecha;
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetExpires(System.DateTime.Now.AddDays(-5));		
			Response.Cache.SetNoStore();
			Response.Cache.SetValidUntilExpires(false);

			if(!IsPostBack)
			{
				Initial=Request.QueryString["InitialDate"].ToString();
				Final=Request.QueryString["FinalDate"].ToString();
				cboStatus=Request.QueryString["cboStatus"].ToString();
				cboLinea=Request.QueryString["cboLinea"].ToString();
				Fecha=Request.QueryString["Fecha"].ToString();
				lblSecuencia.Text=Request.QueryString["Secuencia"].ToString();
				lblDescripcion.Text=Request.QueryString["Descripcion"].ToString();
				if(Request.QueryString["ReFlag"]==null)
				{
					SICALNet.BusinessEntities.PartidasInspeccionInfo PIInfo = new SICALNet.BusinessEntities.PartidasInspeccionInfo(lblSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["InspeccionRoomId"]));
					SICALNet.BusinessLogicLayer.PartidasInspeccion BLIns = new SICALNet.BusinessLogicLayer.PartidasInspeccion();
					int Laminas=BLIns.ActiveLaminas(PIInfo);
					lblLaminas.Text=Laminas.ToString();
					SICALNet.BusinessLogicLayer.PartidasEnvioPT BlPEPT = new SICALNet.BusinessLogicLayer.PartidasEnvioPT();
					Packs=BlPEPT.GetPacks(lblSecuencia.Text,Convert.ToInt32(ConfigurationSettings.AppSettings["SendFinishProductRoomId"]));
					txtCuanto.Text=Packs.ToString();
					IdStatus = Request.QueryString["IdStatus"].ToString();
					if(IdStatus=="5")
						txtCuanto.ReadOnly=true;
				}
				else
				{
					txtCuanto.Text=Request.QueryString["Paquete"].ToString();
					lblLaminas.Text = Request.QueryString["Laminas"].ToString();
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

		private void cmdAnterior_Click(object sender, System.EventArgs e)
		{
			try
			{
				
				Response.Redirect("ConsultEnvioPT.aspx?InitialDate="+Initial+"&FinalDate="+Final+"&cboStatus="+cboStatus+"&cboLinea="+cboLinea+"&Reflag=True");
			}
			catch(Exception ex)
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('"+ ex.Message +"');</script>"; 
				Page.RegisterStartupScript("ClientScript",ScriptString);
			}

		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				SICALNet.Utilities.Validation Plt = new SICALNet.Utilities.Validation();

				if (!Plt.IsWholeNumber(txtCuanto.Text) ||
					txtCuanto.Text == "" ||
					txtCuanto.Text == string.Empty)
				{
					throw new Exception("Proporcione un número válido de paquetes.");
				}

				if (int.Parse(txtCuanto.Text.Trim()) <= 0)
				{
					throw new Exception("Proporcione un número válido de paquetes.");
				}

				string Flag = "Exist";

				if (Packs.ToString() != txtCuanto.Text)
				{
					Flag = "New";
				}

				Response.Redirect(
					"EnvioPTFinal.aspx?InitialDate=" + Initial +
					"&FinalDate=" + Final +
					"&cboStatus=" + cboStatus +
					"&cboLinea=" + cboLinea +
					"&Reflag=True" +
					"&Packages=" + txtCuanto.Text +
					"&Secuencia=" + lblSecuencia.Text +
					"&Descripcion=" + lblDescripcion.Text +
					"&Laminas=" + lblLaminas.Text +
					"&Flag=" + Flag +
					"&IdStatus=" + IdStatus +
					"&Fecha=" + Fecha
				);
			}
			catch (Exception ex)
			{
				string ScriptString =
			   "<script type='text/javascript'>" +
			   "SicalAlert.mostrar('Proporcione un número válido de paquetes.', 'error');" +
			   "</script>";

				ClientScript.RegisterStartupScript(
					this.GetType(),
					"ClientScript",
					ScriptString
				);
			}
		}
	}
}
