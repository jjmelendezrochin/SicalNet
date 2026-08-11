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

namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for SecuenciasCombinadas.
	/// </summary>
	public class SecuenciasCombinadas : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Button btnNext;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblSecuencia;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblTitle;
		static string reflag;
		static string Room;
		static string Descripcion;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetExpires(DateTime.Now);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetValidUntilExpires(false);
			Response.Cache.SetNoStore();

			if(!IsPostBack)
			{
				Descripcion = Request.QueryString["Descripcion"].ToString();
				Room=Request.QueryString["Room"].ToString();
				if(Session["FormularFlag"].ToString()!="0")
				{
					reflag=Request.QueryString["ReFlag"];
					string[] Secuencia = (string[])Session["Secuencia"];
					SICALNet.BusinessEntities.SecuenciaCombinasInfo scInfo = new SICALNet.BusinessEntities.SecuenciaCombinasInfo(Secuencia[0],0);
					SICALNet.BusinessLogicLayer.SecuenciaCombinas blSC = new SICALNet.BusinessLogicLayer.SecuenciaCombinas();
					IList CombinasList=blSC.SelectSecuenciaCombinas(scInfo);
					Label1.Text=" The Previously Selected Secuencias are:\n";
					for(int i=0;i<CombinasList.Count;i++)
					{
						scInfo=(SICALNet.BusinessEntities.SecuenciaCombinasInfo)CombinasList[i];		
						Label1.Text+= scInfo.Secuencia+"\n";
					}
					Label1.Text+=" But Now you Selected Secuencias :\n";
					for (int i=0;i<Secuencia.Length;i++)
					{
						Label1.Text+=Secuencia[i]+"\n";
			//			lblSecuencia.Text+=Secuencia[i]+",";
					}
					Label1.Text+=" Click Back to refine the Selection otherwise Click Next";
				}
				else
				{
					reflag=Request.QueryString["ReFlag"];
					string Secuencia = Session["Secuencia"].ToString();
			//		lblSecuencia.Text=Secuencia;
					SICALNet.BusinessEntities.SecuenciaCombinasInfo scInfo = new SICALNet.BusinessEntities.SecuenciaCombinasInfo(Secuencia,0);
					SICALNet.BusinessLogicLayer.SecuenciaCombinas blSC = new SICALNet.BusinessLogicLayer.SecuenciaCombinas();
					IList CombinasList=blSC.SelectSecuenciaCombinas(scInfo);
					Label1.Text="<br><br> La Secuencia "+Secuencia+ " fue formulada en conjunto con las siguientes secuencias: <br>";
					for(int i=0;i<CombinasList.Count;i++)
					{
						scInfo=(SICALNet.BusinessEntities.SecuenciaCombinasInfo)CombinasList[i];		
						Label1.Text+= scInfo.Secuencia+"<br>";
					}
					Label1.Text+=" Si deseas eliminar la formulación conjunta, y volver a formular para la secuencia "+Secuencia+", presiona -Continuar-<br>";
					Label1.Text+=" Si deseas consultar la formulación conjunta , presiona -Regresar- y selecciona las secuencias indicadas y presiona el botón -Formular-<br><br><br>";
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
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			if(Room=="Color")
			Response.Redirect("WorkOrder/PartidasColor/ConsultColorWO.aspx");
			else if(Room=="Aditivos")
			Response.Redirect("ConsultAditivosWO.aspx");
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			if(Room=="Color")
				Response.Redirect("WorkOrder/PartidasColor/NoOfVasos.aspx?ReFlag="+reflag);
			else if(Room=="Aditivos")
				Response.Redirect("AditivosCuantos.aspx?ReFlag="+reflag+"&Descripcion="+Descripcion);
			
		}
	}
}
