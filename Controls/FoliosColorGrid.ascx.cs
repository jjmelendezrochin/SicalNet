namespace UserInterface.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.SessionState;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections; 
	using System.Security.Principal; 
	using SICALNet.Utilities;
	using SICALNet.BusinessLogicLayer;
	using SICALNet.BusinessEntities;



	/// <summary>
	///		Summary description for FoliosColorGrid.
	/// </summary>
	public abstract class FoliosColorGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblErrorMsg;

		ErrorHandling errFileWrite=new ErrorHandling();		
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Button btnBuscar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid dgdFoliosColor;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Foliohtml;   

		private void Page_Load(object sender, System.EventArgs e)
		{		
			if(!IsPostBack)
			{

				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);

				SICALNet.BusinessLogicLayer.LineaProduccion  BRlinea = new SICALNet.BusinessLogicLayer.LineaProduccion();
				IList tipoRs= (IList)BRlinea.SelectLinePdt(theUser);
				
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
				SICALNet.BusinessLogicLayer.FoliosColor BRFolios = new SICALNet.BusinessLogicLayer.FoliosColor();				
				IList ListFolios = (IList)BRFolios.SelectFoliosColor(Convert.ToInt32(cboLinea.SelectedItem.Value.ToString()));
				this.dgdFoliosColor.DataSource = ListFolios;
				this.dgdFoliosColor.DataBind();				
				prcErrorDisplay(null,"NoError");
			}
			catch (Exception ex)
			{
				String sError = string.Empty;
				sError = ex.Message; // aquí guardas el mensaje de error en la variable
				prcErrorDisplay(ex, "Error");
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

		private void dgdFoliosColor_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdFoliosColor.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		private void dgdFoliosColor_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text="";			
			dgdFoliosColor.EditItemIndex =(int) e.Item.ItemIndex;
			Foliohtml.Value = ((Label) e.Item.FindControl("ItemFolio")).Text;
			BindGrid();
		}

		private void dgdFoliosColor_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdFoliosColor.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid();
			
		}


		private void dgdFoliosColor_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{


				// to initialize the olla info into business entities
			
				string idLineaAux = ((Label)e.Item.FindControl("EditLinea")).Text;
				string codigoSAPAux = ((Label)e.Item.FindControl("EditCodigoSAP")).Text;
				string FolioAux= (((TextBox)e.Item.FindControl("EditFolio")).Text);
				string ObservacionesAux= (((TextBox)e.Item.FindControl("EditObservaciones")).Text);

				SICALNet.BusinessLogicLayer.FoliosColor  BRFoliosColor = new SICALNet.BusinessLogicLayer.FoliosColor();
				SICALNet.BusinessEntities.FolioMaterialInfo OInfo = new SICALNet.BusinessEntities.FolioMaterialInfo(codigoSAPAux,Convert.ToInt32(idLineaAux),FolioAux,ObservacionesAux,Page.User.Identity.Name );   
				BRFoliosColor.UpdateFoliosColor(OInfo);	

				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualizacion de folio color, codigo SAP: " + codigoSAPAux  + " folio: " + FolioAux,Page.User.Identity.Name.ToString());


				//to calcel the edit mode
				dgdFoliosColor.EditItemIndex = -1;
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

		private void dgdFoliosColor_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				string idLineaAux = ((Label)e.Item.FindControl("EditLinea")).Text;
				string codigoSAPAux = ((Label)e.Item.FindControl("ItemCodigoSAP")).Text;
				string FolioAux= (((Label)e.Item.FindControl("ItemFolio")).Text);				
				SICALNet.BusinessLogicLayer.FoliosColor BRFoliosColor = new SICALNet.BusinessLogicLayer.FoliosColor();				
				SICALNet.BusinessEntities.FolioMaterialInfo OInfo = new SICALNet.BusinessEntities.FolioMaterialInfo(codigoSAPAux,Convert.ToInt32(idLineaAux),FolioAux,string.Empty,Page.User.Identity.Name );   
				BRFoliosColor.DeleteFoliosColor(OInfo);

				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de folio color, codigo SAP: " + codigoSAPAux  + " folio: " + FolioAux,Page.User.Identity.Name.ToString());


				//to calcel the edit mode
				dgdFoliosColor.EditItemIndex = -1;
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
			this.dgdFoliosColor.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdFoliosColor_PageIndexChanged);
			this.dgdFoliosColor.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFoliosColor_CancelCommand);
			this.dgdFoliosColor.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFoliosColor_EditCommand);
			this.dgdFoliosColor.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFoliosColor_UpdateCommand);
			this.dgdFoliosColor.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFoliosColor_DeleteCommand);			
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnBuscar_Click(object sender, System.EventArgs e)
		{
		
           BindGrid();

		}
	}
}
