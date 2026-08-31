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
	///		Summary description for PlantGrid.
	/// </summary>
	public abstract class PlantGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dgdPlant;
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
			this.dgdPlant.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdPlant_PageIndexChanged);
			this.dgdPlant.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPlant_CancelCommand);
			this.dgdPlant.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPlant_EditCommand);
			this.dgdPlant.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPlant_UpdateCommand);
			this.dgdPlant.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPlant_DeleteCommand);
			this.dgdPlant.SelectedIndexChanged += new System.EventHandler(this.dgdPlant_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void BindGrid()
		{
			try
			{
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Planta planta= new SICALNet.BusinessLogicLayer.Planta();
				// to Call the Select method
				IList plantaRs= (IList)planta.SelectPlanta();
				//to assign the result set into datagrid
				dgdPlant.DataSource = plantaRs;
				//to fill the datagrid
				dgdPlant.DataBind();

				//to clear the error msg label
				prcErrorDisplay(null,"NoError");
				//initialy the operation mode is set to default
				Session["Mode"]="Default";
			}
			catch(Exception errHand)
			{
				//to display the error msg
				prcErrorDisplay(errHand,"Error");
			}
		}


		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("Información de Planta",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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

		private void dgdPlant_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to get the edit item index
			dgdPlant.EditItemIndex = (int)e.Item.ItemIndex;
			//to fill the datagrid
			BindGrid();
		}

		private void dgdPlant_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdPlant.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid();
		}

		private void dgdPlant_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//to get an instance for validation
				/*** comentado por alejandro.hernandez@nasoft.com 07/03/2006 ***/
				//Validation pltVdlt=new Validation();
				
				// to check whether the data correct or not
				if(((TextBox)e.Item.FindControl("EditPlantDescription")).Text == string.Empty)
					throw new Exception("Debe de capturar la descripcion para esta planta");
				/*if ((pltVdlt.IsAlphaNumeric((((TextBox)e.Item.FindControl("EditPlantDescription")).Text))==false) || ((((TextBox)e.Item.FindControl("EditPlantDescription")).Text)==""))
					throw new Exception("Description should be Alpha Numeric");*/

				// to initialize the planta info into business entities
				int IdPlanta = Convert.ToInt32(((Label)e.Item.FindControl("EditPlantId")).Text);
				string Description = ((TextBox)e.Item.FindControl("EditPlantDescription")).Text;
				string DenomSAP= (((TextBox)e.Item.FindControl("EditDenomSAP")).Text);
				float Merma= (float)Convert.ToDouble(((TextBox)e.Item.FindControl("EditMerma")).Text);
				float PorcentajeColor= (float)Convert.ToDouble(((TextBox)e.Item.FindControl("EditRendimientoColor")).Text);

				//to assign the values into BEL
				PlantaInfo plantaInfo= new PlantaInfo(IdPlanta,Description,DenomSAP,Merma,PorcentajeColor);
				// Create the business logic tier
				SICALNet.BusinessLogicLayer.Planta planta= new SICALNet.BusinessLogicLayer.Planta();
				// Call the Update Storage method
				planta.UpdatePlanta(plantaInfo);

				// Bitacora update de de planta
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualiza planta: " + plantaInfo.Description,Page.User.Identity.Name.ToString());

				//to calcel the edit mode
				dgdPlant.EditItemIndex = -1;
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
//				obj_Cntl=(TextBox)dgdPlant.Items[itemIdx].Cells[colPosition].FindControl(cntlName);				
//			if (obj_Cntl==null)
//				obj_Cntl=(TextBox)dgdPlant.Controls[0].Controls[dgdPlant.Controls[0].Controls.Count-1].Controls[0].FindControl(cntlName);
//
//			//to set the focus
//			Page.RegisterStartupScript("focus", "<script language='JavaScript'>"+
//				"PlantaForm." + obj_Cntl.ClientID + ".focus();"+
//				"PlantaForm." + obj_Cntl.ClientID + ".select();" +
//				"<" + "/script>");
//		}

		private void dgdPlant_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				// to initialize the Planta info into business entities
				int IdPlanta = Convert.ToInt32((((Label)e.Item.FindControl("ItemPlantId")).Text));
				string Description = (((Label)e.Item.FindControl("ItemPlantDescription")).Text);
				string DenomSAP= (((Label)e.Item.FindControl("ItemDenomSAP")).Text);
				float Merma=(float)Convert.ToDouble(((Label)e.Item.FindControl("ItemMerma")).Text);

				//to assign the values into BEL
				PlantaInfo plantaInfo = new PlantaInfo(IdPlanta,Description, DenomSAP,Merma);
				//to create the BBL
				SICALNet.BusinessLogicLayer.Planta planta= new SICALNet.BusinessLogicLayer.Planta();
				// Call the Delete method
				planta.DeletePlanta(plantaInfo);

				// Bitacora borrado de planta
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de planta: " + plantaInfo.Description,Page.User.Identity.Name.ToString());
			
				//to set the normal mode
				dgdPlant.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();

				//to give the confirmation to the user
				prcErrorDisplay(null,"El registro de esta planta se elimino con exito");		
			}
			catch(System.Data.SqlClient.SqlException errHand)
			{
				prcErrorDisplay(errHand, "La planta seleccionada es usada actualmente por el sistema, y no puede ser eliminada");				
			}
			catch 
			{			
				throw;
			}
		}

		private void dgdPlant_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dgdPlant_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdPlant.EditItemIndex = -1;
			dgdPlant.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
	}
}
