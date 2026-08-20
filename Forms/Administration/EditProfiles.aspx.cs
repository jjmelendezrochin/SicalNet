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
using SICALNet.BusinessLogicLayer;
using SICALNet.BusinessEntities;

namespace UserInterface.Forms.Administration
{
	/// <summary>
	/// Summary description for EditProfiles.
	/// </summary>
	public class EditProfiles : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtProfileName;
		protected System.Web.UI.WebControls.Button btnSalvar;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.Label Label2;
		private static string currentMode=string.Empty;
		private static string currentProfileName=string.Empty;
		protected System.Web.UI.WebControls.Label txtProfileId;
		protected System.Web.UI.WebControls.DataList lstAdminModules;
		protected System.Web.UI.WebControls.DataList lstCatalogModules;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DataList lstProductionModules;
		protected System.Web.UI.WebControls.DataList lstReportModules;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DataList lstStructModules;
		protected System.Web.UI.WebControls.DataList lstLogisticsModules;
		private static string currentProfileId=string.Empty;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				LoadProfileInfo();
				LoadModulesList();
				if (currentMode=="Edicion")
					LoadCurrentPermissions();
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
			currentMode=Request.QueryString["Mode"].ToString();
			currentProfileId=Request.QueryString["IdPerfil"].ToString();
			currentProfileName=Request.QueryString["DescripcionPerfil"].ToString();
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void LoadCurrentPermissions()
		{
			PermisoPerfilInfo ppInfo = new PermisoPerfilInfo (Convert.ToInt32(currentProfileId),string.Empty,0);
			PermisoPerfil bllInfo = new PermisoPerfil();
			IList currentPermissionsList=bllInfo.Load(ppInfo);
			
			for (int i=0;i<currentPermissionsList.Count;i++)
			{
				ppInfo = (PermisoPerfilInfo) currentPermissionsList[i];
				
				if (ppInfo.IdModulo.IndexOf("1.")>=0)
				{
					
					bool flagAdmin=false;
					for (int j=0;j<lstAdminModules.Items.Count;j++)	
					{
						if (ppInfo.IdModulo==((Label) lstAdminModules.Items[j].FindControl("lblIdModulo")).Text)
						{
							flagAdmin=true;
							((CheckBox) lstAdminModules.Items[j].FindControl("chkSelect")).Checked=true;
						}
						
					}
					if(flagAdmin)
						((CheckBox) lstAdminModules.Controls[0].Controls[1]).Checked=true;
		

				}



				if (ppInfo.IdModulo.IndexOf("2.")>=0)
				{
					((CheckBox) lstCatalogModules.Controls[0].Controls[1]).Checked=true;
					for (int j=0;j<lstCatalogModules.Items.Count;j++)	
					{
						if (ppInfo.IdModulo==((Label) lstCatalogModules.Items[j].FindControl("lblIdModulo")).Text)
						{
							((CheckBox) lstCatalogModules.Items[j].FindControl("chkSelect")).Checked=true;
						}
					}
				}

				if (ppInfo.IdModulo.IndexOf("3.")>=0)
				{
					((CheckBox) lstStructModules.Controls[0].Controls[1]).Checked=true;
					for (int j=0;j<lstStructModules.Items.Count;j++)	
					{
						if (ppInfo.IdModulo==((Label) lstStructModules.Items[j].FindControl("lblIdModulo")).Text)
						{
							((CheckBox) lstStructModules.Items[j].FindControl("chkSelect")).Checked=true;
							
								if (ppInfo.IdPermiso == 3)
								{
									((CheckBox) lstStructModules.Items[j].FindControl("CheckReadOnly")).Checked=true;
								}
							
						}
					}
				}

				if (ppInfo.IdModulo.IndexOf("4.")>=0)
				{
					((CheckBox) lstLogisticsModules.Controls[0].Controls[1]).Checked=true;
					for (int j=0;j<lstLogisticsModules.Items.Count;j++)	
					{
						if (ppInfo.IdModulo==((Label) lstLogisticsModules.Items[j].FindControl("lblIdModulo")).Text)
						{
							((CheckBox) lstLogisticsModules.Items[j].FindControl("chkSelect")).Checked=true;
						}
					}
				}

				if (ppInfo.IdModulo.IndexOf("5.")>=0)
				{
					((CheckBox) lstProductionModules.Controls[0].Controls[1]).Checked=true;
					for (int j=0;j<lstProductionModules.Items.Count;j++)	
					{
						if (ppInfo.IdModulo==((Label) lstProductionModules.Items[j].FindControl("lblIdModulo")).Text)
						{
							((CheckBox) lstProductionModules.Items[j].FindControl("chkSelect")).Checked=true;
						}
					}
				}

				if (ppInfo.IdModulo.IndexOf("6.")>=0)
				{
					((CheckBox) lstReportModules.Controls[0].Controls[1]).Checked=true;
					for (int j=0;j<lstReportModules.Items.Count;j++)	
					{
						if (ppInfo.IdModulo==((Label) lstReportModules.Items[j].FindControl("lblIdModulo")).Text)
						{
							((CheckBox) lstReportModules.Items[j].FindControl("chkSelect")).Checked=true;
						}
					}
				}

			}
		}

		private void LoadModulesList()
		{
			Modulo modulesList =  new Modulo();
			lstAdminModules.DataSource=modulesList.SelectModulo("1.%");
			lstAdminModules.DataBind();

			lstCatalogModules.DataSource=modulesList.SelectModulo("2.%");
			lstCatalogModules.DataBind();

			lstStructModules.DataSource=modulesList.SelectModulo("3.%");
			lstStructModules.DataBind();
			
			lstLogisticsModules.DataSource=modulesList.SelectModulo("4.%");
			lstLogisticsModules.DataBind();

			lstProductionModules.DataSource=modulesList.SelectModulo("5.%");
			lstProductionModules.DataBind();

			lstReportModules.DataSource=modulesList.SelectModulo("6.%");
			lstReportModules.DataBind();
		}

		private void LoadProfileInfo()
		{
			txtProfileId.Text=currentProfileId;
			txtProfileName.Text=currentProfileName;
		}

		private void btnSalvar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (txtProfileName.Text.Trim()==string.Empty)
					throw new Exception("Proporcione el nombre del perfil.");
				
				if (currentMode=="Nuevo")
					createNewProfile(txtProfileName.Text.Trim());
				else
					editProfile(Convert.ToInt32(currentProfileId));

				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('El perfil ha sido salvado exitosamente');self.location.href='Profiles.aspx';</script>"; 
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
				
				//Response.Redirect("Profiles.aspx");

			}			
			catch (Exception errHand)
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('"+ errHand.Message +"');</script>"; 
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Profiles.aspx");
		}

		private void createNewProfile(string descProfile)
		{			
			try
			{			
				//List of items of each module
				ArrayList ArrLib = new ArrayList();			
				ArrLib= getProfilePermission(0);

				if (ArrLib.Count<=0)
					throw new Exception("Seleccione el o los módulos a los que tendrá acceso el perfil que está creando");

				PermisoPerfil BLLppInfo = new PermisoPerfil();
				BLLppInfo.Insert(descProfile,ArrLib);
			}
			catch (Exception errHand)
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('"+ errHand.Message +"');</script>"; 
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
			}
		}

		private void editProfile(int idProfile)
		{			
			try
			{			
				//List of items of each module
				ArrayList ArrLib = new ArrayList();			
				ArrLib= getProfilePermission(idProfile);

				if (ArrLib.Count<=0)
					throw new Exception("Seleccione el o los módulos a los que tendrá acceso el perfil");

				PermisoPerfil BLLppInfo = new PermisoPerfil();
				BLLppInfo.Update(idProfile,ArrLib);
			}
			catch (Exception errHand)
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('"+ errHand.Message +"');</script>"; 
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
			}
		}

		private ArrayList getProfilePermission(int idPerfil)
		{
			//Indicate if no module is selected.
			bool moduleWasSelected=false;
			string selectedModule=string.Empty;
			
			//List of items of each module
			ArrayList ArrLib = new ArrayList();

			//Loop thru the list of Administrative Modules, to get the selected modules
			for (int i=0; i<lstAdminModules.Items.Count; i++)
			{
				if (((CheckBox) lstAdminModules.Items[i].FindControl("chkSelect")).Checked==true)
				{
					moduleWasSelected=true;
					selectedModule= ((Label) lstAdminModules.Items[i].FindControl("lblIdModulo")).Text;
					PermisoPerfilInfo  Lib = new PermisoPerfilInfo(idPerfil,selectedModule,1);
					ArrLib.Add(Lib);
				}
			}
			if (moduleWasSelected)
			{
				PermisoPerfilInfo  Lib = new PermisoPerfilInfo(idPerfil,"1.0",1);
				ArrLib.Add(Lib);
			}

			moduleWasSelected=false;
			//Loop thru the list of Strcutures Modules, to get the selected modules
			for (int i=0; i<lstLogisticsModules.Items.Count; i++)
			{
				if (((CheckBox) lstLogisticsModules.Items[i].FindControl("chkSelect")).Checked==true)
				{
					moduleWasSelected=true;
					selectedModule= ((Label) lstLogisticsModules.Items[i].FindControl("lblIdModulo")).Text;
					PermisoPerfilInfo  Lib = new PermisoPerfilInfo(idPerfil,selectedModule,1);
					ArrLib.Add(Lib);
				}
			}
			if (moduleWasSelected)
			{
				PermisoPerfilInfo  Lib = new PermisoPerfilInfo(idPerfil,"4.0",1);
				ArrLib.Add(Lib);
			}

			//Loop thru the list of Strcutures Modules, to get the selected modules
			moduleWasSelected=false;
			for (int i=0; i<lstStructModules.Items.Count; i++)
			{
				if (((CheckBox) lstStructModules.Items[i].FindControl("chkSelect")).Checked==true)
				{
					moduleWasSelected=true;
					selectedModule= ((Label) lstStructModules.Items[i].FindControl("lblIdModulo")).Text;
					int idpermiso = 1;
				
					if (((CheckBox) lstStructModules.Items[i].FindControl("CheckReadOnly")).Visible == true)
					{
						if (((CheckBox) lstStructModules.Items[i].FindControl("CheckReadOnly")).Checked == true)
							idpermiso = 3;						

					}


					PermisoPerfilInfo  Lib = new PermisoPerfilInfo(idPerfil,selectedModule,idpermiso);
					ArrLib.Add(Lib);
				}
			}
			if (moduleWasSelected)
			{
				PermisoPerfilInfo  Lib = new PermisoPerfilInfo(idPerfil,"3.0",1);
				ArrLib.Add(Lib);
			}

			moduleWasSelected=false;
			//Loop thru the list of Strcutures Modules, to get the selected modules
			for (int i=0; i<lstCatalogModules.Items.Count; i++)
			{
				if (((CheckBox) lstCatalogModules.Items[i].FindControl("chkSelect")).Checked==true)
				{
					moduleWasSelected=true;
					selectedModule= ((Label) lstCatalogModules.Items[i].FindControl("lblIdModulo")).Text;
					PermisoPerfilInfo  Lib = new PermisoPerfilInfo(idPerfil,selectedModule,1);
					ArrLib.Add(Lib);
				}
			}
			if (moduleWasSelected)
			{
				PermisoPerfilInfo  Lib = new PermisoPerfilInfo(idPerfil,"2.0",1);
				ArrLib.Add(Lib);
			}


			moduleWasSelected=false;
			//Loop thru the list of Strcutures Modules, to get the selected modules
			for (int i=0; i<lstProductionModules.Items.Count; i++)
			{
				if (((CheckBox) lstProductionModules.Items[i].FindControl("chkSelect")).Checked==true)
				{
					moduleWasSelected=true;
					selectedModule= ((Label) lstProductionModules.Items[i].FindControl("lblIdModulo")).Text;
					PermisoPerfilInfo  Lib = new PermisoPerfilInfo(idPerfil,selectedModule,1);
					ArrLib.Add(Lib);
				}
			}
			if (moduleWasSelected)
			{
				PermisoPerfilInfo  Lib = new PermisoPerfilInfo(idPerfil,"5.0",1);
				ArrLib.Add(Lib);
			}

			moduleWasSelected=false;
			//Loop thru the list of Strcutures Modules, to get the selected modules
			for (int i=0; i<lstReportModules.Items.Count; i++)
			{
				if (((CheckBox) lstReportModules.Items[i].FindControl("chkSelect")).Checked==true)
				{
					moduleWasSelected=true;
					selectedModule= ((Label) lstReportModules.Items[i].FindControl("lblIdModulo")).Text;
					PermisoPerfilInfo  Lib = new PermisoPerfilInfo(idPerfil,selectedModule,1);
					ArrLib.Add(Lib);
				}
			}
			if (moduleWasSelected)
			{
				PermisoPerfilInfo  Lib = new PermisoPerfilInfo(idPerfil,"6.0",1);
				ArrLib.Add(Lib);
			}

			//returns the list of selected permisssion
			return ArrLib;
		}


		public Boolean ViewReadOnly(string IdModulo)
		{
			switch (IdModulo)
			{
				case "3.5":
					return true;

				case "3.6":
					return true;

				case "3.7":
					return true;
				
			    case "3.8":
					return true;
				
				case "3.9":
					return true;
				
				case "3.10":
					return true;
				
				case "3.11":
					return true;
					
				default:
					return false;
					
			}
		}

//		private void PopulatePermissions()
//		{
//			
//		}

	}
}
