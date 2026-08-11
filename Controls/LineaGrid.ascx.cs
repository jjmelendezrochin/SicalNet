
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
	///		Summary description for LineaGrid.
	/// </summary>
	public abstract class LineaGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dgdLinea;
		protected System.Web.UI.WebControls.Label lblErrorMsg;

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
			this.dgdLinea.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdLinea_PageIndexChanged);
			this.dgdLinea.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLinea_CancelCommand);
			this.dgdLinea.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLinea_EditCommand);
			this.dgdLinea.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLinea_UpdateCommand);
			this.dgdLinea.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLinea_DeleteCommand);
			this.dgdLinea.SelectedIndexChanged += new System.EventHandler(this.dgdLinea_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void BindGrid()
		{
			try
			{

				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);

				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.LineaProduccion Linea= new SICALNet.BusinessLogicLayer.LineaProduccion();
				// to Call the Select method
				IList LineaRs= (IList)Linea.SelectLinePdt(theUser);
				//to assign the result set into datagrid
				dgdLinea.DataSource = LineaRs;
				//to fill the datagrid
				dgdLinea.DataBind();

				//to clear the error msg label
				prcErrorDisplay(null,"NoError");
				//initialy the operation mode is set to default
				Session["Mode"]="Default";
			}
			catch
			{
				//to display the error msg
				// prcErrorDisplay(errHand,"Error");

				throw;
			}
		}


		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("Información de Líneas",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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

		private void dgdLinea_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to get the edit item index
			dgdLinea.EditItemIndex = (int)e.Item.ItemIndex;
			//to fill the datagrid
			BindGrid();
		}

		private void dgdLinea_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdLinea.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid();
		}

		private void dgdLinea_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//to get an instance for validation
				//Validation pltVdlt=new Validation();
				
				// to check whether the data correct or not
				if((((TextBox)e.Item.FindControl("EditLineaDescription")).Text)==string.Empty)
				//if ((pltVdlt.IsAlphaNumeric((((TextBox)e.Item.FindControl("EditLineaDescription")).Text))==false) || ((((TextBox)e.Item.FindControl("EditLineaDescription")).Text)==""))
					throw new Exception("Debe de capturar la descripción de la planta");

				// to initialize the Linea info into business entities
				int IdLinea = Convert.ToInt32(((Label)e.Item.FindControl("EditLineaId")).Text);
				string Description = ((TextBox)e.Item.FindControl("EditLineaDescription")).Text;

				//to assign the values into BEL
				LineaProduccionInfo LineaInfo= new LineaProduccionInfo(IdLinea,Description);

				// Create the business logic tier
				SICALNet.BusinessLogicLayer.LineaProduccion Linea= new SICALNet.BusinessLogicLayer.LineaProduccion();

				// Call the Update Storage method
				Linea.UpdateLinePdt(LineaInfo);

				// Update de linea en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualiza de linea: " + LineaInfo.Description,Page.User.Identity.Name.ToString());

				//to calcel the edit mode
				dgdLinea.EditItemIndex = -1;

				//to fill the datagrid
				BindGrid();

				//to call error msg function
				prcErrorDisplay(null,"El registro se modifico con exito");
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
//				obj_Cntl=(TextBox)dgdLinea.Items[itemIdx].Cells[colPosition].FindControl(cntlName);				
//			if (obj_Cntl==null)
//				obj_Cntl=(TextBox)dgdLinea.Controls[0].Controls[dgdLinea.Controls[0].Controls.Count-1].Controls[0].FindControl(cntlName);
//
//			//to set the focus
//			Page.RegisterStartupScript("focus", "<script language='JavaScript'>"+
//				"LineaForm." + obj_Cntl.ClientID + ".focus();"+
//				"LineaForm." + obj_Cntl.ClientID + ".select();" +
//				"<" + "/script>");
//		}

		private void dgdLinea_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				// to initialize the Linea info into business entities
				int IdLinea = Convert.ToInt32((((Label)e.Item.FindControl("ItemLineaId")).Text));
				string Description = (((Label)e.Item.FindControl("ItemLineaDescription")).Text);

				//to assign the values into BEL
				LineaProduccionInfo LineaInfo = new LineaProduccionInfo(IdLinea,Description);
				//to create the BBL
				SICALNet.BusinessLogicLayer.LineaProduccion Linea= new SICALNet.BusinessLogicLayer.LineaProduccion();
				// Call the Delete method
				Linea.DeleteLinePdt(LineaInfo);
							
				// borrado de linea en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de linea: " + LineaInfo.Description,Page.User.Identity.Name.ToString());

				//to set the normal mode
				dgdLinea.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();

				//to give the confirmation to the user
				prcErrorDisplay(null,"El registro se elimino con exito");		
			}
			catch(System.Data.SqlClient.SqlException errHand)
			{
				prcErrorDisplay(errHand, "La línea que selecciono esta siendo utilizada por el sistema actualmente, y no podra eliminarse");
			}
			catch 
			{				
				throw;
			}
		}

		private void dgdLinea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dgdLinea_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdLinea.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
	}
}
