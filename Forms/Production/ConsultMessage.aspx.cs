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
using System.Data.SqlClient;
using System.Configuration;
using SICALNet.BusinessEntities;
using SICALNet.Interfaces;
using Microsoft.ApplicationBlocks.Data;


namespace UserInterface.Forms.Production
{
	/// <summary>
	/// Summary description for ConsultMessage.
	/// </summary>
	public class ConsultMessage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblSecuencia;
		protected System.Web.UI.WebControls.Button btnAgregar;
		protected System.Web.UI.WebControls.Button Cancelar;
		protected System.Web.UI.WebControls.Label lblSecuecniaNo;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtNewMessage;
		protected System.Web.UI.WebControls.TextBox txtOldMessages;
		protected System.Web.UI.HtmlControls.HtmlForm PdtLogForm;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblLaminas;
		protected System.Web.UI.WebControls.Label lblBitaCora;
		protected System.Web.UI.WebControls.Label lblDescripcion;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetExpires(DateTime.Now);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetValidUntilExpires(false);
			Response.Cache.SetNoStore();

			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				lblSecuecniaNo.Text=Request.QueryString["Secuencia"].ToString();
				lblFecha.Text=Request.QueryString["Fecha"].ToString();
				lblDescripcion.Text=Request.QueryString["Descripcion"].ToString();
				lblLaminas.Text=Request.QueryString["Cantidad"].ToString();

				SICALNet.BusinessLogicLayer.Programa blProgramma = new SICALNet.BusinessLogicLayer.Programa();
				txtOldMessages.Text=(string)blProgramma.LoadLog(lblSecuecniaNo.Text.ToString());
			}
				
			// *****************************************
			// Consultando los datos de la secuencia
			String sBitacora = null;
			String SQL_CONSULTA_COMENTARIOS = 
					" Select top 1 ('En fecha ' + Convert(varchar(10), fecha, 103)  + ' '  + comando) as textoBitacora from Bitacora "  +
					" where comando like '%" + lblSecuecniaNo.Text.Trim() + "%'  and comando like '%por el motivo%'  order by idBitacora desc;";
			using (SqlDataReader rsBitacora = SqlHelper.ExecuteReader(ConfigurationManager.AppSettings["SICALConnString"], CommandType.Text, SQL_CONSULTA_COMENTARIOS)) 
			{
				while (rsBitacora.Read()) 
				{
					sBitacora = rsBitacora.GetString(0); 					
				}
			}
			this.txtOldMessages.Text = sBitacora;
			// *****************************************
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
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAgregar_Click(object sender, System.EventArgs e)
		{
			SICALNet.BusinessLogicLayer.Programa blProgramma = new SICALNet.BusinessLogicLayer.Programa();
			string messageToSave= string.Format("{0} \n {1} [{2} {3}]",txtOldMessages.Text.Trim(),txtNewMessage.Text.Trim(),this.Context.User.Identity.Name,DateTime.Now.ToString("dd-MMM-yy"));
			blProgramma.AddLog(lblSecuecniaNo.Text.ToString(),messageToSave);
			Page.RegisterStartupScript("__close", "<script>window.close();</script>");
		}

		private void Cancelar_Click(object sender, System.EventArgs e)
		{
			Page.RegisterStartupScript("__close", "<script>window.close();</script>");
		}

		

		

		//this event is called , when the user select the record from datagrid
	/*	private void btnSecuencia_Click(object sender, System.EventArgs e)
		{
			try
			{
				
				
				string sSec = ((Label) ConsultPrgGridControl.dgdProgram.Items[ConsultPrgGridControl.dgdProgram.SelectedIndex].Cells[0].FindControl("lblSecuencia")).Text.ToString();
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Programa BLLPrg= new SICALNet.BusinessLogicLayer.Programa();
				// to Call the Select method
				txtBitacora.Text= BLLPrg.LoadLog(sSec);
				btnSecuencia.Text=sSec;
				//to set the visibilities
				if (btnCancelar.CommandName != "Add")
					prc_EnableDisable("011110");
				else
					prc_EnableDisable("011111");
			}
			catch
			{
			}
		}

		//to call the add log UC 
		private void btnAddLog_Click(object sender, System.EventArgs e)
		{	btnCancelar.CommandName="Add";
			btnCancelar.Text="Add Log Canceler";
			btnCancelar.Width=120;
			prc_EnableDisable("011010");
		}

		//to cancel the operation
		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			if (btnCancelar.CommandName != "Cancel")
				prc_EnableDisable("100000");
			else
			{
				btnCancelar.CommandName="Add";
				btnCancelar.Text = "Add Log Canceler";
				prc_EnableDisable("011111");
			}
		}

		//to edit the data
		private void btnEditar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (btnEditar.CommandName == "Edit")
				{
					btnEditar.CommandName="Accept";
					btnCancelar.CommandName="Cancel";
					btnEditar.Text="Acteptar";
					btnCancelar.Text="Canceler";
				}
				else
				{
					if (txtBitacora.Text.ToString().Trim() == string.Empty)
						throw new Exception("Bitacora should not be null");
					//to get the instance for BusinessLogicLayer
					SICALNet.BusinessLogicLayer.Programa BLLPrg= new SICALNet.BusinessLogicLayer.Programa();
					// to Call the Select method
					BLLPrg.AddLog(btnSecuencia.Text.ToString(),txtBitacora.Text.ToString());

					//to set the name for corresponding controls
					btnEditar.CommandName="Edit";
					btnCancelar.CommandName="Add";

					btnEditar.Text="Editar";
					btnCancelar.Text="Add Log Canceler";
					//to give the success msg
					throw new Exception("La bitácora se agrego con éxito");
				}
			}
			catch(Exception erHnd)
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('"+ erHnd.Message +"');</script>"; 
				ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
			}
		}*/
	}
}