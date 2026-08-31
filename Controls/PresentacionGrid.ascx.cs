
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
	///		Summary Descripcion for PresentacionGrid.
	/// </summary>
	public abstract class PresentacionGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dgdPresentacion;
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
			this.dgdPresentacion.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdPresentacion_PageIndexChanged);
			this.dgdPresentacion.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPresentacion_CancelCommand);
			this.dgdPresentacion.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPresentacion_EditCommand);
			this.dgdPresentacion.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPresentacion_UpdateCommand);
			this.dgdPresentacion.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPresentacion_DeleteCommand);
			this.dgdPresentacion.SelectedIndexChanged += new System.EventHandler(this.dgdPresentacion_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void BindGrid()
		{
			try
			{
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Presentacion Presentacion= new SICALNet.BusinessLogicLayer.Presentacion();
				// to Call the Select method
				IList PresentacionRs= (IList)Presentacion.SelectPresentacion();
				//to assign the result set into datagrid
				dgdPresentacion.DataSource = PresentacionRs;
				//to fill the datagrid
				dgdPresentacion.DataBind();

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
				errFileWrite.HandleException("Presentacion Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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

		private void dgdPresentacion_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to get the edit item index
			dgdPresentacion.EditItemIndex = (int)e.Item.ItemIndex;
			//to fill the datagrid
			BindGrid();
		}

		private void dgdPresentacion_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdPresentacion.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid();
		}

		private void dgdPresentacion_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//to get an instance for validation
				//Validation pltVdlt=new Validation();
				
				// to check whether the data correct or not
				//if ((pltVdlt.IsAlphaNumeric((((TextBox)e.Item.FindControl("EditPresentacionDescripcion")).Text))==false) || ((((TextBox)e.Item.FindControl("EditPresentacionDescripcion")).Text)==""))
				if(((((TextBox)e.Item.FindControl("EditPresentacionDescripcion")).Text)==""))
					throw new Exception("Debe de capturar la descripción para esta presentación");

				// to initialize the Presentacion info into business entities
				string IdPresentacion = ((Label)e.Item.FindControl("EditPresentacionId")).Text;
				string Descripcion = ((TextBox)e.Item.FindControl("EditPresentacionDescripcion")).Text;

				//to assign the values into BEL
				PresentacionInfo PresentacionInfo= new PresentacionInfo(IdPresentacion,Descripcion);

				// Create the business logic tier
				SICALNet.BusinessLogicLayer.Presentacion Presentacion= new SICALNet.BusinessLogicLayer.Presentacion();

				// Call the Update Storage method
				Presentacion.UpdatePresentacion(PresentacionInfo);
				
				// actualiza presentacion en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualiza presentacion: " + PresentacionInfo.IdPresentacion,Page.User.Identity.Name.ToString());

				//to calcel the edit mode
				dgdPresentacion.EditItemIndex = -1;

				//to fill the datagrid
				BindGrid();

				//to call error msg function
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
//				obj_Cntl=(TextBox)dgdPresentacion.Items[itemIdx].Cells[colPosition].FindControl(cntlName);				
//			if (obj_Cntl==null)
//				obj_Cntl=(TextBox)dgdPresentacion.Controls[0].Controls[dgdPresentacion.Controls[0].Controls.Count-1].Controls[0].FindControl(cntlName);
//
//			//to set the focus
//			Page.RegisterStartupScript("focus", "<script language='JavaScript'>"+
//				"PresentacionForm." + obj_Cntl.ClientID + ".focus();"+
//				"PresentacionForm." + obj_Cntl.ClientID + ".select();" +
//				"<" + "/script>");
//		}

		private void dgdPresentacion_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				// to initialize the Presentacion info into business entities
				string IdPresentacion = (((Label)e.Item.FindControl("ItemPresentacionId")).Text);
				string Descripcion = (((Label)e.Item.FindControl("ItemPresentacionDescripcion")).Text);

				//to assign the values into BEL
				PresentacionInfo PresentacionInfo = new PresentacionInfo(IdPresentacion,Descripcion);
				//to create the BBL
				SICALNet.BusinessLogicLayer.Presentacion Presentacion= new SICALNet.BusinessLogicLayer.Presentacion();
				// Call the Delete method
				Presentacion.DeletePresentacion(PresentacionInfo);
	
				// borrado de presentacion en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de presentacion: " + PresentacionInfo.IdPresentacion,Page.User.Identity.Name.ToString());
			
				//to set the normal mode
				dgdPresentacion.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();

				//to give the confirmation to the user
				prcErrorDisplay(null,"El registro se elimino con éxito");		
			}
			catch (System.Data.SqlClient.SqlException errHand)
			{
				prcErrorDisplay(errHand, "La presentación seleccionada esta siendo utilizada por el sistema, y no podrá eliminarse");				
			}
			catch 
			{
				throw;
			}
		}

		private void dgdPresentacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dgdPresentacion_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdPresentacion.EditItemIndex = -1;
			dgdPresentacion.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

	}
}
