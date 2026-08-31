namespace UserInterface.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections; 
	using System.Security.Principal; 
	using SICALNet.Utilities;
	using SICALNet.BusinessLogicLayer;
	using SICALNet.BusinessEntities;

	/// <summary>
	///		Summary description for FoliosAditivosGrid.
	/// </summary>
	public abstract class FoliosAditivosGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Foliohtml; 

		ErrorHandling errFileWrite=new ErrorHandling();		
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Button btnBuscar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid dgdFoliosAditivos;
		private String Foliohtml1;
		private void Page_Load(object sender, System.EventArgs e)
		{		
			if(!IsPostBack)
			{
				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);

				SICALNet.BusinessLogicLayer.LineaProduccion  BRlinea = new SICALNet.BusinessLogicLayer.LineaProduccion();
				IList tipoRs= (IList)BRlinea.SelectLinePdt(theUser);
				
//				JJMR 281113 14:22 
//				LineaProduccionInfo lpInfo = new LineaProduccionInfo(0," TODAS ");
//				tipoRs.Add(lpInfo);
				
				cboLinea.DataSource= tipoRs;
				cboLinea.DataValueField="IdLinea";
				cboLinea.DataTextField="Description";
				cboLinea.DataBind();	


				BindGrid();
			}
		}

		public void clearMessage()
		{
			//to clear label box
			lblErrorMsg.ForeColor=Color.White;
			lblErrorMsg.BackColor=Color.White;

		}
		public void BindGrid()
		{
			try
			{				
				SICALNet.BusinessLogicLayer.FoliosAditivos BRFolios = new SICALNet.BusinessLogicLayer.FoliosAditivos();				
				IList ListFolios = (IList)BRFolios.SelectFoliosAditivos(Convert.ToInt32(cboLinea.SelectedItem.Value.ToString()));
				this.dgdFoliosAditivos.DataSource = ListFolios;
				this.dgdFoliosAditivos.DataBind();				
				prcErrorDisplay(null,"NoError");
			}
			catch
			{
				// prcErrorDisplay(e,"Error");

				throw;
			}
		}

		
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//ErrorHandling errFileWrite=new ErrorHandling();
				//errFileWrite.HandleException("Espesor Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
				lblErrorMsg.Text=errHnd.Message;
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;
			}
			else if (errStatus=="NoError")
			{
				//to clear label box
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.White;
			}
			else
			{
				//to display the success msg
				lblErrorMsg.Text=errStatus;
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;
			}
		}

		private void dgdFoliosAditivos_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdFoliosAditivos.EditItemIndex = -1;
			dgdFoliosAditivos.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		private void dgdFoliosAditivos_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text="";			
			dgdFoliosAditivos.EditItemIndex =(int) e.Item.ItemIndex;
			string FolioAux  = ((Label) e.Item.FindControl("ItemFolio")).Text;
			Foliohtml1 =  FolioAux;
			BindGrid();
		}

		private void dgdFoliosAditivos_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdFoliosAditivos.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid();
			
		}


		private void dgdFoliosAditivos_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{


				// to initialize the olla info into business entities
			
				string idLineaAux = ((Label)e.Item.FindControl("EditLinea")).Text;
				string codigoSAPAux = ((Label)e.Item.FindControl("EditCodigoSAP")).Text;
				string FolioAux= (((TextBox)e.Item.FindControl("EditFolio")).Text);
				string ObservacionesAux= (((TextBox)e.Item.FindControl("EditObservaciones")).Text);

				SICALNet.BusinessLogicLayer.FoliosAditivos  BRFoliosAditivos = new SICALNet.BusinessLogicLayer.FoliosAditivos();
				SICALNet.BusinessEntities.FolioMaterialInfo OInfo = new SICALNet.BusinessEntities.FolioMaterialInfo(codigoSAPAux,Convert.ToInt32(idLineaAux),FolioAux,ObservacionesAux,Page.User.Identity.Name );   
				BRFoliosAditivos.UpdateFoliosAditivos(OInfo);	

				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualizacion de folio aditivos, codigo SAP: " + codigoSAPAux  + " folio: " + Foliohtml1,Page.User.Identity.Name.ToString());


				//to calcel the edit mode
				dgdFoliosAditivos.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();
				lblErrorMsg.Text="El registro de actualizó satisfactoriamente";
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;

				
			}
			catch
			{
				// prcErrorDisplay(errHand,"Error");

				throw;
			}
		}

		private void dgdFoliosAditivos_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				string idLineaAux = ((Label)e.Item.FindControl("EditLinea")).Text;
				string codigoSAPAux = ((Label)e.Item.FindControl("ItemCodigoSAP")).Text;
				string FolioAux= (((Label)e.Item.FindControl("ItemFolio")).Text);
				SICALNet.BusinessLogicLayer.FoliosAditivos BRFoliosAditivos = new SICALNet.BusinessLogicLayer.FoliosAditivos();				
				SICALNet.BusinessEntities.FolioMaterialInfo OInfo = new SICALNet.BusinessEntities.FolioMaterialInfo(codigoSAPAux,Convert.ToInt32(idLineaAux),FolioAux,string.Empty,Page.User.Identity.Name );   
				BRFoliosAditivos.DeleteFoliosAditivos(OInfo);

				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de folio aditivos, codigo SAP: " + codigoSAPAux  + " folio: " + FolioAux,Page.User.Identity.Name.ToString());


				//to calcel the edit mode
				dgdFoliosAditivos.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();
				lblErrorMsg.Text="El registro se borro satisfactoriamente";
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;
			}
			catch
			{
				// prcErrorDisplay(errHand,"Error");

				throw;
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
		
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			this.dgdFoliosAditivos.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdFoliosAditivos_PageIndexChanged);
			this.dgdFoliosAditivos.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFoliosAditivos_CancelCommand);
			this.dgdFoliosAditivos.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFoliosAditivos_EditCommand);
			this.dgdFoliosAditivos.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFoliosAditivos_UpdateCommand);
			this.dgdFoliosAditivos.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFoliosAditivos_DeleteCommand);
			this.dgdFoliosAditivos.SelectedIndexChanged += new System.EventHandler(this.dgdFoliosAditivos_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnBuscar_Click(object sender, System.EventArgs e)
		{
		
			BindGrid();

		}

		private void dgdFoliosAditivos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
