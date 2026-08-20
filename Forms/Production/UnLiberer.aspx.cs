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

namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for UnLiberer.
	/// </summary>
	public class UnLiberer : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtSecuencia;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnUnLiberer;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DataList DLArea;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (IsPostBack) return;

			BindList();
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
			this.btnUnLiberer.Click += new System.EventHandler(this.btnUnLiberer_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindList()
		{
			//SICALNet.BusinessEntities.AreaInfo aInfo = new SICALNet.BusinessEntities.AreaInfo();
			SICALNet.BusinessLogicLayer.Area blArea = new SICALNet.BusinessLogicLayer.Area();
			IList Arealist = (IList)blArea.SelectArea();
			DLArea.DataSource=Arealist;
			DLArea.DataBind();
		}

		private void btnUnLiberer_Click(object sender, System.EventArgs e)
		{
			string selectedSequence = txtSecuencia.Text.Trim();

			//Validate that the user provided a sequence
			if (selectedSequence==string.Empty)
			{
				MessageDisplay("Por favor indique el número de secuencia que desea reactivar");
				return;
			}

			//Validate that the sequence exists.
			Programa BLLProgram = new Programa();
			ArrayList existingProgram = (ArrayList) BLLProgram.Load(selectedSequence);
			if (existingProgram.Count<=0)
			{
				MessageDisplay(string.Format("La secuencia -{0}- no existe",selectedSequence));
				return;
			}

			ArrayList ArrLib = new ArrayList();
			
			//Obtain active status
			int IdStatus = Convert.ToInt32(ConfigurationManager.AppSettings["StatusActive"]);
			//Obtain released status
			int IdReleaseStatus = Convert.ToInt32(ConfigurationManager.AppSettings["StatusRelease"]);
			//determine if the user didnt select an area
			bool areaWasSelected = false;

			for (int i=0; i<DLArea.Items.Count; i++)
			{
				if (((CheckBox) DLArea.Items[i].FindControl("chkSelect")).Checked==true)
				{
					areaWasSelected=true;
					int IdArea = Convert.ToInt32(((Label) DLArea.Items[i].FindControl("lblIdArea")).Text);
					SICALNet.BusinessEntities.LibererInfo Lib = new SICALNet.BusinessEntities.LibererInfo(selectedSequence,IdArea,IdStatus);
					ArrLib.Add(Lib);
				}
			}

			//Validate tha the user selected an area
			if (areaWasSelected)
			{
				SICALNet.BusinessLogicLayer.Liberer BLLLib = new SICALNet.BusinessLogicLayer.Liberer();
				if (BLLLib.SetUnReleaseStatus(ArrLib,IdReleaseStatus,Context.User.Identity.Name))
				{
					txtSecuencia.Text=string.Empty;
					BindList();
					MessageDisplay(string.Format("La secuencia -{0}- fue reactivada exitosamente",selectedSequence));
				}
				else
					MessageDisplay(string.Format("La secuencia -{0}- no fue reactivada, debido a que no se encuentra liberada !!",selectedSequence));
			}
			else
			{
				MessageDisplay(string.Format("Por favor indique el área (o las áreas) en donde desea reactivar la secuencia -{0}- ",selectedSequence));
			}

		}

		private void MessageDisplay(string Msg)
		{
			Page.RegisterStartupScript("ClientSc","<script language=JavaScript> alert('" + Msg + "') </script>");
		}


	}
}
