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

using SICALNet.Utilities;
using SICALNet.BusinessLogicLayer;
using SICALNet.BusinessEntities;

namespace UserInterface.Controls
{
	/// <summary>
	///	Summary description for ColourGrid.
	/// </summary>
	public abstract class ColourGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dgdColour;

		public string edit_espesor;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Label Label1;

		ErrorHandling ExpHand=new ErrorHandling();

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
			this.dgdColour.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdColour_PageIndexChanged);
			this.dgdColour.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdColour_CancelCommand);
			this.dgdColour.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdColour_EditCommand);
			this.dgdColour.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdColour_UpdateCommand);
			this.dgdColour.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdColour_DeleteCommand);
			this.dgdColour.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdColour_ItemDataBound);
			this.dgdColour.SelectedIndexChanged += new System.EventHandler(this.dgdColour_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void BindGrid()
		{
			try
			{
				//to get the instance form BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Colour BLLColour= new SICALNet.BusinessLogicLayer.Colour();
				// to Call the Select method
				IList RsGrdColour= (IList)BLLColour.SelectColour();
				//to assign the result set into datagrid
				dgdColour.DataSource = RsGrdColour;
				//to fill the datagrid
				
				dgdColour.DataBind();
			}
			catch(Exception errHand)
			{
				Session["errMsg"]=ExpHand.HandleException("Structure","FormAditivos",errHand,Server.MapPath(".."),errHand.Message);
			}
		}

		//to initialize the control into the datagrid e.g - dropdownlist or textbox
		private void dgdColour_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			try{
				if (e.Item.ItemType == ListItemType.EditItem)
				{
					//to get the instance from BusinessLogicLayer
					SICALNet.BusinessLogicLayer.Espesor BLLEspesor=new SICALNet.BusinessLogicLayer.Espesor();
					IList RsEspesor=(IList) BLLEspesor.LoadEspesor();
					//To Load Data into Colour DropDownList Box
					DropDownList cboIdEspesor = (DropDownList) e.Item.FindControl("cboEspesor");
					cboIdEspesor.DataSource=RsEspesor;
					cboIdEspesor.DataValueField="IdEspesor";
					cboIdEspesor.DataTextField="Centimetros";
					cboIdEspesor.DataBind();
					cboIdEspesor.Items.FindByText(edit_espesor).Selected=true;
				}
			}
			catch(Exception errHand)
			{
				Session["errMsg"]=ExpHand.HandleException("Structure","FormAditivos",errHand,Server.MapPath(".."),errHand.Message);
			}
		}

		private void dgdColour_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try{
				if (Session["opMode"].ToString() == "Insert")
					throw new Exception("Estas en modo de edición. cancela el modo de edición para continuar");
				//to get the edit item index
				edit_espesor = ((Label) e.Item.FindControl("lblEspesor")).Text;
				dgdColour.EditItemIndex = (int)e.Item.ItemIndex;
				//to fill the datagrid
				BindGrid();
				Session["opMode"]="Edit";
			}
			catch
			{
				throw;
			}
		}

		private void dgdColour_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdColour.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid();
			Session["opMode"]=string.Empty;
		}

		private void dgdColour_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//to get an instance from validation
				//Validation vdtColour=new Validation();
				
				// to check whether the data correct or not
				//if ((vdtColour.IsAlphaNumeric((((TextBox)e.Item.FindControl("txtDesc")).Text))==false) || ((((TextBox)e.Item.FindControl("txtDesc")).Text)==""))
				if((((TextBox)e.Item.FindControl("txtDesc")).Text)=="")
					throw new Exception("Debe capturar la descripción");

				// to initialize the planta info into business entities
				string IdColour = ((Label)e.Item.FindControl("lblColourId")).Text;
				string Descripcion = ((TextBox)e.Item.FindControl("txtDesc")).Text;
				string IdExport= (((TextBox)e.Item.FindControl("txtIdExport")).Text);
				string IdEspesor= ((DropDownList)e.Item.FindControl("cboEspesor")).SelectedItem.Value;
				bool Transparente =((CheckBox)e.Item.FindControl("chkTransEdit")).Checked;

				//to assign the values into BEL
				ColourInfo BEColour= new ColourInfo(IdColour,IdExport,Descripcion,IdEspesor,Transparente); //FRM
				// Create the business logic tier
				SICALNet.BusinessLogicLayer.Colour BLLColour= new SICALNet.BusinessLogicLayer.Colour();
				// to Call the Update method
				BLLColour.UpdateColour(BEColour);

				// Actualizaciòn de color en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualizacion de color: " + BEColour.IdColour + " descripcion: " + BEColour.Descripcion,Page.User.Identity.Name.ToString());


				//to calcel the edit mode
				dgdColour.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();
				Session["opMode"]=string.Empty;
			}
			catch(System.Data.SqlClient.SqlException)
			{
				lblErrorMsg.Text = "Este identificador de color ya esta en uso actualmente";
			}
			catch
			{
				throw;
			}
		}

		//to set the focus into the corresponding textbox using javascript
//		private void prcSetFocus(int itemIdx,int colPosition, string cntlName,System.Web.UI.WebControls.DataGridCommandEventArgs dgdArgs)
//		{
//			//to get an instance for footer textbox
//			TextBox obj_Cntl=(TextBox)dgdArgs.Item.FindControl(cntlName);
//
//			//if the footer textbox instance is null to get the instance from edit item
//			if (obj_Cntl==null)
//				obj_Cntl=(TextBox)dgdColour.Items[itemIdx].Cells[colPosition].FindControl(cntlName);				
//			if (obj_Cntl==null)
//				obj_Cntl=(TextBox)dgdColour.Controls[0].Controls[dgdColour.Controls[0].Controls.Count-1].Controls[0].FindControl(cntlName);
//
//			//to set the focus
//			Page.RegisterStartupScript("focus", "<script language='JavaScript'>"+
//				"PlantaForm." + obj_Cntl.ClientID + ".focus();"+
//				"PlantaForm." + obj_Cntl.ClientID + ".select();" +
//				"<" + "/script>");
//		}

		private void dgdColour_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				if (Session["opMode"].ToString() == "Insert" || Session["opMode"].ToString() == "Edit")
					throw new Exception("You are in the "+Session["opMode"] +". Please cancel it");

				// to initialize the Planta info into business entities
				string IdColour = ((Label)e.Item.FindControl("lblColourId")).Text;

				//to assign the values into BEL
				ColourInfo BEColour= new ColourInfo(IdColour,string.Empty,string.Empty,string.Empty,false);
				//to create the BBL
				SICALNet.BusinessLogicLayer.Colour BLLColour= new SICALNet.BusinessLogicLayer.Colour();
				//to Call the Delete method
				BLLColour.DeleteColour(BEColour);
				
				// Borrado de color en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de color: " + BEColour.IdColour + " descripcion: " + BEColour.Descripcion,Page.User.Identity.Name.ToString());


				//to set the normal mode
				dgdColour.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();
				Session["opMode"]=string.Empty;
			}
			catch(System.Data.SqlClient.SqlException)
			{
				lblErrorMsg.Text = "Este identificador de color ya esta en uso actualmente";
			}
			catch
			{
				throw;
			}
		}

		private void dgdColour_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdColour.CurrentPageIndex=e.NewPageIndex;
			BindGrid();
		}

		private void dgdColour_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}