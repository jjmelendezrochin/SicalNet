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
	///	Summary description for PlantGrid.
	/// </summary>
	public abstract class FamiliaProductosGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.DataGrid dgdFamiliaProductos;
		protected System.Web.UI.HtmlControls.HtmlInputHidden ItemDescripcionhtml;  

		string TipoPMMA;
		

		//to get an instance for utility-error handler
		ErrorHandling errFileWrite=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			//BindGrid - to fill the datagrid
			if (!IsPostBack)
			{
				BindGrid();
				
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
		/// 

		private void InitializeComponent()
		{
			this.dgdFamiliaProductos.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdFamiliaProductos_PageIndexChanged);
			this.dgdFamiliaProductos.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFamiliaProductos_CancelCommand);
			this.dgdFamiliaProductos.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFamiliaProductos_EditCommand);
			this.dgdFamiliaProductos.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFamiliaProductos_UpdateCommand);
			this.dgdFamiliaProductos.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFamiliaProductos_DeleteCommand);
			this.dgdFamiliaProductos.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdFamiliaProductos_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgdFamiliaProductos_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.EditItem)
			{
				dgdFamiliaProductos.Columns[2].Visible=true;
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.TipoPMMA tippoBL= new SICALNet.BusinessLogicLayer.TipoPMMA();
				IList fPdsRs= (IList)tippoBL.SelectTipoPMMA();
				// To Load Data for FamilioProductos DropDownList Box
				DropDownList cboTipoPMMA = (DropDownList) e.Item.FindControl("cboTipoPMMA");
				cboTipoPMMA.DataSource=fPdsRs;
				cboTipoPMMA.DataValueField="IdTipoPMMA";
				cboTipoPMMA.DataTextField="DescripcionMaterial";
				cboTipoPMMA.DataBind();
				cboTipoPMMA.Items.FindByValue(TipoPMMA).Selected=true;
			}
		}
                  
		public void BindGrid()
		{
			try
			{
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.FamiliaProducto fPds= new SICALNet.BusinessLogicLayer.FamiliaProducto();
				// to Call the Select method
				IList fProductoRs= (IList)fPds.SelectFamiliaProducto();
				//to assign the result set into datagrid
				dgdFamiliaProductos.DataSource= fProductoRs;
				//to fill the datagrid
				dgdFamiliaProductos.DataBind();

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


		private void dgdFamiliaProductos_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text ="";
			dgdFamiliaProductos.EditItemIndex =-1;
			BindGrid();
			lblErrorMsg.Text="";
		}

		
		 private void dgdFamiliaProductos_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
	    {
			 try
			 {
				 // to initialize the PermisoPerfil info into business entities				              
				 int IdFamiliaProductos = Convert.ToInt32(((Label)e.Item.FindControl("lblIdFamiliadeProductos")).Text);
				 string ItemDescripcion = ((Label)e.Item.FindControl("ItemDescripcion")).Text;
				 //to assign the values into BEL
				 FamiliaProductoInfo fInfo = new FamiliaProductoInfo(IdFamiliaProductos,0,string.Empty,string.Empty);
				 //to create the BBL
				 SICALNet.BusinessLogicLayer.FamiliaProducto fPds= new SICALNet.BusinessLogicLayer.FamiliaProducto();
				 // Call the Delete method
				 fPds.DeleteFamiliaProducto(fInfo);

				 // Borrado de familia de producto en la bitacora
				 SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				 BLLBitacora.Insertcomando("Borrado de familia de producto: " + ItemDescripcion,Page.User.Identity.Name.ToString());
		
				 //to set the normal mode
				 dgdFamiliaProductos.EditItemIndex = -1;
				 //to fill the datagrid
				 BindGrid();

				 //to give the confirmation to the user
				 prcErrorDisplay(null,"El registro se elimino con éxito");		
			 }
			 catch (System.Data.SqlClient.SqlException errHand)
			 {
				prcErrorDisplay(errHand, "La familia de productos que selcciono es utilizada por el sistema actualmente, y no será eliminada");
			 }
			 catch 
			 {								 				
				 throw;
			 }
		}
	
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		


		private void dgdFamiliaProductos_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//Validation pltVdlt=new Validation();
					
				int IdFamiliaProductos =Int32.Parse(((Label)e.Item.FindControl("EditFamiliadeProductosId")).Text.Trim());
				int IdTipoPMMA= Convert.ToInt32(((DropDownList)e.Item.FindControl("cboTipoPMMA")).SelectedItem.Value);
				
				

				//if ((pltVdlt.IsAlphaNumeric((((TextBox)e.Item.FindControl("EditDescripcion")).Text))==false) || ((((TextBox)e.Item.FindControl("EditDescripcion")).Text)==""))
				if((((TextBox)e.Item.FindControl("EditDescripcion")).Text.Trim())==string.Empty )
				{
					prcErrorDisplay(null,"Debe de capturar la decripción de la familia de productos");
					return;
					//throw new Exception("Descripcion should be Alpha Numeric");
				}

				if((((TextBox)e.Item.FindControl("txtTempPre")).Text.Trim())==string.Empty )
				{
					prcErrorDisplay(null,"Debe de capturar la temperatura de preseparación");
					return;
					//throw new Exception("Descripcion should be Alpha Numeric");
				}
				float auxF;
				try
				{
					auxF = Convert.ToSingle( ((TextBox)e.Item.FindControl("txtTempPre")).Text.Trim());
				}
				catch
				{
					throw new Exception("Valor inválido en la temperatura de preseparación");
				}
				if (auxF<=0) throw new Exception("Valor inválido en la temperatura de preseparación");

				string Descripcion=(((TextBox)e.Item.FindControl("EditDescripcion")).Text.Trim());
               	FamiliaProductoInfo fInfo=new FamiliaProductoInfo(IdFamiliaProductos,IdTipoPMMA,Descripcion,auxF.ToString() );
				
				SICALNet.BusinessLogicLayer.FamiliaProducto fPrds=new SICALNet.BusinessLogicLayer.FamiliaProducto();
				fPrds.UpdateFamiliaProducto(fInfo);
				
				// Actualizaciòn de familia de producto en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualizacion de Id familia de producto: " + fInfo.IdFamiliaProductos + " descripción: " + ItemDescripcionhtml.Value ,Page.User.Identity.Name.ToString());
		

				dgdFamiliaProductos.EditItemIndex=-1;
				BindGrid();
				prcErrorDisplay(null,"El registro se modifico con éxito");
			}
			catch
			{				
				throw;
			}
		}


		/*** comentado por alejandro.hernandez@nasoft.com 07/03/2006 ***/
//		public void prcChangeControl(object sender, System.EventArgs e)
//		{
//			
//			Label lblProductosId=(Label)(dgdFamiliaProductos.Items[dgdFamiliaProductos.EditItemIndex].Cells[0].FindControl("EditFamiliadeProductosId"));			
//			Label lblDesc=(Label)(dgdFamiliaProductos.Items[dgdFamiliaProductos.EditItemIndex].Cells[0].FindControl("EditDescripcion"));			
//			Label lblTipoPMMA=(Label)(dgdFamiliaProductos.Items[dgdFamiliaProductos.EditItemIndex].Cells[0].FindControl("lblTipoPMMAId"));			
//
//		}	
			
		
		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				//errFileWrite.HandleException("FamiliaPro Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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

//	   //to set the focus into the corresponding textbox using javascript
//		private void prcSetFocus(int itemIdx,int colPosition, string cntlName,System.Web.UI.WebControls.DataGridCommandEventArgs dgdArgs)
//		{
//			//to get an instance for footer textbox
//			TextBox obj_Cntl=(TextBox)dgdArgs.Item.FindControl(cntlName);
//
//			//if the footer textbox instance is null to get the instance from edit item
//			if (obj_Cntl==null)
//				obj_Cntl=(TextBox)dgdFamiliaProductos.Items[itemIdx].Cells[colPosition].FindControl(cntlName);				
//			if (obj_Cntl==null)
//				obj_Cntl=(TextBox)dgdFamiliaProductos.Controls[0].Controls[dgdFamiliaProductos.Controls[0].Controls.Count-1].Controls[0].FindControl(cntlName);
//
//			//to set the focus
//			Page.RegisterStartupScript("focus", "<script language='JavaScript'>"+
//				"FamiliaProductosForm." + obj_Cntl.ClientID + ".focus();"+
//				"FamiliaProductosForm." + obj_Cntl.ClientID + ".select();" +
//				"<" + "/script>");
//		}

		private void dgdFamiliaProductos_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text="";
			TipoPMMA = ((Label) e.Item.FindControl("ItemTipoPMMAId")).Text.Trim();
			ItemDescripcionhtml.Value = ((Label)e.Item.FindControl("ItemDescripcion")).Text;
			dgdFamiliaProductos.EditItemIndex =(int) e.Item.ItemIndex;
			BindGrid();
		}

		private void dgdFamiliaProductos_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdFamiliaProductos.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
		
	}
}
