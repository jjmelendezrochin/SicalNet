namespace UserInterface.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections;

	using SICALNet.Utilities;
	using SICALNet.BusinessEntities;

	/// <summary>
	///		Summary descripcion for TipoPMMAGrid.
	/// </summary>
	public abstract class TipoPMMAGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dgdTipoPMMA;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.HtmlControls.HtmlInputHidden CodigoSAPhtml; 

		//to get an instance for utility-error handler
		ErrorHandling errFileWrite=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			//BindGrid - to fill the datagrid
			if (!IsPostBack)
				BindGrid();
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
			this.dgdTipoPMMA.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdTipoPMMA_PageIndexChanged);
			this.dgdTipoPMMA.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdTipoPMMA_CancelCommand);
			this.dgdTipoPMMA.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdTipoPMMA_EditCommand);
			this.dgdTipoPMMA.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdTipoPMMA_UpdateCommand);
			this.dgdTipoPMMA.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdTipoPMMA_DeleteCommand);
			this.dgdTipoPMMA.SelectedIndexChanged += new System.EventHandler(this.dgdTipoPMMA_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void BindGrid()
		{
			try
			{
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.TipoPMMA TipoPMMA = new SICALNet.BusinessLogicLayer.TipoPMMA();
				// to Call the Select method
				IList TipoPMMARs= (IList)TipoPMMA.SelectTipoPMMA();
				//to assign the result set into datagrid
				dgdTipoPMMA.DataSource = TipoPMMARs;
				//to fill the datagrid
				dgdTipoPMMA.DataBind();

				//to clear the error msg label
				prcErrorDisplay(null,"NoError");
				//initialy the operation mode is set to default
				Session["Mode"]="Default";
			}
			catch
			{
				throw;
			}
		}


		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("TipoPMMA Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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

		private void dgdTipoPMMA_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to Get the Edit Item Index
			dgdTipoPMMA.EditItemIndex = (int)e.Item.ItemIndex;
			CodigoSAPhtml.Value = (((Label)e.Item.FindControl("ItemCodigoSAP")).Text);
			//to Fill the DataGrid
			BindGrid();
		}

		private void dgdTipoPMMA_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to Set the Display Mode
			dgdTipoPMMA.EditItemIndex = -1;
			//to Fill the DataGrid
			BindGrid();
		}

		private void dgdTipoPMMA_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//to get an instance for validation
				//Validation pltVdlt=new Validation();

				// to initialize the TipoPMMA info into business entities
				int IdTipoPMMA = Convert.ToInt32(((Label)e.Item.FindControl("EditIdTipoPMMA")).Text);
				string CodigoSAP = (((TextBox)e.Item.FindControl("EditCodigoSAP")).Text.Trim());
				string EditDescripcion = ((Label)e.Item.FindControl("EditDescripcion")).Text;

				if (CodigoSAP == String.Empty)
				{
					prcErrorDisplay(null,"Debe de capturar el código del material código SAP");
					return;
				}
				else
				{
					MaterialInfo mInfo = new MaterialInfo(CodigoSAP, String.Empty);
					SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();

					if (!Material.isExistMaterial(mInfo))
					{
						prcErrorDisplay(null,"El código SAP del material no se encuentra en el catalogo de Materiales");
						return;
					}
				}

				//to assign the values into Business Entities
				TipoPMMAInfo TipoPMMAInfo= new TipoPMMAInfo(IdTipoPMMA,CodigoSAP,string.Empty);
				// Create the Business Logic Tier
				SICALNet.BusinessLogicLayer.TipoPMMA TipoPMMA= new SICALNet.BusinessLogicLayer.TipoPMMA();
				// Call the Update Storage method
				TipoPMMA.UpdateTipoPMMA(TipoPMMAInfo);

				// Actualiza de tipoPMMA en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualizacion de codigo: " + CodigoSAPhtml.Value + " descripcion: " +  EditDescripcion + " nuevo codigo: " + TipoPMMAInfo.CodigoSAP,Page.User.Identity.Name.ToString());


				//to Cancel the Edit Mode
				dgdTipoPMMA.EditItemIndex = -1;
				//to Fill the DataGrid
				BindGrid();
				//to Call Error Msg Function
				prcErrorDisplay(null,"El registro se modifico con éxito");
			}
			catch 
			{				
				throw;
			}
		}

//		//to set the focus into the corresponding textbox using javascript
//		private void prcSetFocus(int itemIdx,int colPosition, string cntlName,System.Web.UI.WebControls.DataGridCommandEventArgs dgdArgs)
//		{
//			//to get an instance for footer textbox
//			TextBox obj_Cntl=(TextBox)dgdArgs.Item.FindControl(cntlName);
//
//			//if the footer textbox instance is null to get the instance from edit item
//			if (obj_Cntl==null)
//				obj_Cntl=(TextBox)dgdTipoPMMA.Items[itemIdx].Cells[colPosition].FindControl(cntlName);				
//			if (obj_Cntl==null)
//				obj_Cntl=(TextBox)dgdTipoPMMA.Controls[0].Controls[dgdTipoPMMA.Controls[0].Controls.Count-1].Controls[0].FindControl(cntlName);
//
//			//to set the focus
//			Page.RegisterStartupScript("focus", "<script language='JavaScript'>"+
//				"TipoPMMAForm." + obj_Cntl.ClientID + ".focus();"+
//				"TipoPMMAForm." + obj_Cntl.ClientID + ".select();" +
//				"<" + "/script>");
//		}

		private void dgdTipoPMMA_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				// to initialize the TipoPMMA info into business entities
				int IdTipoPMMA = Convert.ToInt32((((Label)e.Item.FindControl("ItemIdTipoPMMA")).Text));
				//string Descripcion = (((Label)e.Item.FindControl("ItemDescripcion")).Text);
				string CodigoSAP= (((Label)e.Item.FindControl("ItemCodigoSAP")).Text);
				string ItemDescripcion= (((Label)e.Item.FindControl("ItemDescripcion")).Text);

				//to Assign the Values into Business Entities
				TipoPMMAInfo TipoPMMAInfo = new TipoPMMAInfo(IdTipoPMMA, CodigoSAP,string.Empty);
				//to Create Instance for the Business Logic Layer
				SICALNet.BusinessLogicLayer.TipoPMMA TipoPMMA= new SICALNet.BusinessLogicLayer.TipoPMMA();
				// Call the Delete method
				TipoPMMA.DeleteTipoPMMA(TipoPMMAInfo);
				
				// Borrado de tipoPMMA en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de codigo: " + CodigoSAP + " descripcion: " +  ItemDescripcion,Page.User.Identity.Name.ToString());


				//to Set the Normal Mode
				dgdTipoPMMA.EditItemIndex = -1;
				//to Fill the DataGrid
				BindGrid();

				//to Display the Confirmation to the User
				prcErrorDisplay(null,"El registro se elimino con éxito");		
			}

			catch (System.Data.SqlClient.SqlException errHand)
			{
				prcErrorDisplay(errHand,"El TipoPMMA esta siendo usado por el sistema, y no puede ser borrado");				
			}
			catch 
			{
				throw;
			}
		}

		private void dgdTipoPMMA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dgdTipoPMMA_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdTipoPMMA.EditItemIndex = -1;
			dgdTipoPMMA.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

	}
}
