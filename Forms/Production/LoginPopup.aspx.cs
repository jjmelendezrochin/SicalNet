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
using SICALNet.BusinessLogicLayer.Security;
using SICALNet.BusinessEntities;
using System.Configuration;
using SICALNet.BusinessLogicLayer;
using SICALNet.Utilities;

namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for LoginPopup.
	/// </summary>
	public class LoginPopup : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtLogin;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.Button cmdSignIn;
		protected static string Phase="";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				Phase=Request.QueryString["Phase"].ToString();
				lblMsg.ForeColor=Color.Red;
				lblMsg.Font.Bold=true;
				lblMsg.Text=" La Secuencia "+Request.QueryString["Secuencia"].ToString();
				lblMsg.Text+=" está a punto de ser liberada antes de que su proceso de "+Phase+" termine";
				lblMsg.Text+=" Proporcione el login de autorización para este proceso.";
				
			}
			 // Put user code to initialize the page here
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
			this.cmdSignIn.Click += new System.EventHandler(this.cmdSignIn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdSignIn_Click(object sender, System.EventArgs e)
		{
			try
			{
				
				string ldapPath = ConfigurationManager.AppSettings["ldapPath"].ToString();
				string domainName= ConfigurationManager.AppSettings["domainName"].ToString();
				LdapAuthentication adsAuth = new LdapAuthentication(ldapPath);

				if (adsAuth.IsAuthenticated(domainName,txtLogin.Text.Trim(),txtPassword.Text.Trim()))                
				{


					if(Phase=="Cured")
					{
						bool ExistInRole=false;
						SecurityManager security = new SecurityManager();
						DataSet usuario=security.GetUserRoles(txtLogin.Text.Trim());
						for (int i=0;i<usuario.Tables[0].Rows.Count;i++)
						{
							DataRow userDetails = usuario.Tables[0].Rows[i];
							if("5.8.1" == userDetails["Rol"].ToString())
							{
								ExistInRole=true;
							}
							
						}
						
						if(!ExistInRole)
						{ 
							throw new Exception("La Orden de Trabajo para la secuencia "+ Request.QueryString["Secuencia"] +" No se ha liberado dado que no tienes el permiso de liberarla antes de su tiempo");
						}

						int localAreaId=Convert.ToInt32(ConfigurationManager.AppSettings["CuredRoomId"]);
						//Update the data on Partidas Curado (regarding the Sequence)
						SICALNet.BusinessEntities.PartidasCuradoInfo pcInfo = new SICALNet.BusinessEntities.PartidasCuradoInfo(Request.QueryString["Secuencia"],localAreaId,Convert.ToInt32(Request.QueryString["IdLinea"]),Convert.ToInt32(Request.QueryString["Cuba"]),0,DateTime.Now,DateTime.Now,DateTime.Now,string.Empty);
						SICALNet.BusinessLogicLayer.PartidasCurado blPC = new SICALNet.BusinessLogicLayer.PartidasCurado();
						blPC.UpdatePartidasCurado(pcInfo);
						//Release the Cuba that was being used
						SICALNet.BusinessEntities.CubaInfo CInfo = new SICALNet.BusinessEntities.CubaInfo(Convert.ToInt32(Request.QueryString["Cuba"]),Convert.ToInt32(Request.QueryString["IdLinea"]),false,string.Empty,string.Empty);
						SICALNet.BusinessLogicLayer.Cuba blCuba = new SICALNet.BusinessLogicLayer.Cuba();
						blCuba.UpdateCuba(CInfo);			
						//Activate Next Area And update Active Area in Programma Production for this Secuencia
						//Depending on sequence available in "FlujoArea" Table
						SICALNet.BusinessLogicLayer.FlujoArea objFlujoArea = new SICALNet.BusinessLogicLayer.FlujoArea();
						objFlujoArea.ActivateDependingAreas(Request.QueryString["Secuencia"],localAreaId);
						//Release the work Order from the Current Area.
						SICALNet.BusinessEntities.OrdenesTrabajoInfo orInfo = new SICALNet.BusinessEntities.OrdenesTrabajoInfo(Request.QueryString["Secuencia"],localAreaId,Convert.ToInt32(ConfigurationManager.AppSettings["StatusRelease"]),DateTime.Now.Date.ToString("dd/MMM/yyyy"),Context.User.Identity.Name);
						SICALNet.BusinessLogicLayer.OrdenesTrabajo blOr = new SICALNet.BusinessLogicLayer.OrdenesTrabajo();
						blOr.UpdateStatus(orInfo);
						Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
							"alert('"+"La Orden de Trabajo para la secuencia "+ Request.QueryString["Secuencia"] +" se liberó exitosamente"+"')"+
							"<" + "/script>");
						Page.RegisterStartupScript("__close", "<script>opener.location='ConsultarCured.aspx';self.close()</script>");
					}
					else if(Phase=="PostCured")
					{

						bool ExistInRole=false;
						SecurityManager security = new SecurityManager();
						DataSet usuario=security.GetUserRoles(txtLogin.Text.Trim());
						for (int i=0;i<usuario.Tables[0].Rows.Count;i++)
						{
							DataRow userDetails = usuario.Tables[0].Rows[i];
							if("5.9.1" == userDetails["Rol"].ToString())
							{
								ExistInRole=true;
							}
							
						}
						
						if(!ExistInRole)throw new Exception("La Orden de Trabajo para la secuencia "+ Request.QueryString["Secuencia"] +" No se ha liberado dado que no tienes el permiso de liberarla antes de su tiempo");

						int localAreaId=Convert.ToInt32(ConfigurationManager.AppSettings["PostCuredRoomId"]);
						//Update PartidasPostCurado 
						SICALNet.BusinessEntities.PartidasPostCuradoInfo BEPPC = new SICALNet.BusinessEntities.PartidasPostCuradoInfo(Request.QueryString["Secuencia"],localAreaId,Convert.ToInt32(Request.QueryString["IdLinea"]),Convert.ToInt32(Request.QueryString["Zonas"]),0,DateTime.Now,DateTime.Now,DateTime.Now,string.Empty);
						SICALNet.BusinessLogicLayer.PartidasPostCurado BLLPPC = new SICALNet.BusinessLogicLayer.PartidasPostCurado();
						BLLPPC.UpdatePartidasPostCurado(BEPPC,Context.User.Identity.Name);
								
						//Activate Next Area And update Active Area in Programma Production for this Secuencia
						//Depending on sequence available in "FlujoArea" Table
						SICALNet.BusinessLogicLayer.FlujoArea objFlujoArea = new SICALNet.BusinessLogicLayer.FlujoArea();
						objFlujoArea.ActivateDependingAreas(Request.QueryString["Secuencia"],localAreaId);
						Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
							"alert('"+"La Orden de Trabajo para la secuencia "+ Request.QueryString["Secuencia"] +" se liberó exitosamente"+"')"+
							"<" + "/script>");
						Page.RegisterStartupScript("__close", "<script>opener.location='WorkOrder/PartidasPostCurado/Consultar_PostCured.aspx';window.close()</script>");
					}
					//System.Web.Security.FormsAuthentication.RedirectFromLoginPage(txtLogin.Text,false);
					// Page.RegisterStartupScript("__close", "<script>document.forms['ConsultarCuredWO'].elements['txtHidden'].value='True'</script>");
					//Page.RegisterStartupScript("__close", "<script>window.close()document.forms['ConsultarCuredWO'].elements['txtHidden'].value=Truedocument.forms['ConsultarCuredWO'].elements['btnLiberar'].click()</script>");
				}
				else
				{
					txtLogin.Text=string.Empty;
					txtPassword.Text=string.Empty;
					Page.RegisterStartupScript("alert", "<script language='JavaScript'>"+
						"alert('"+"Datos incorrectos"+"')"+
						"<" + "/script>");
				}
			}
			catch(Exception errHand)
			{
				string ScriptString="<script language='javascript'>alert('"+ errHand.Message +"');</script>"; 
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);

			}
		}
	}
}
