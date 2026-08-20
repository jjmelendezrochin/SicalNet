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
//sicalnet references
using SICALNet.Utilities;
using SICALNet.BusinessLogicLayer;
using SICALNet.BusinessEntities;

namespace UserInterface.Controls
{
	/// <summary>
	///		Summary description for ListofMaterialGrid.
	/// </summary>
	public abstract class ListofMaterialGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dgdLstMat;
		ErrorHandling ExpHand=new ErrorHandling();

		private string UnidadDesc;
		private string PlantaDesc;

		private void Page_Load(object sender, System.EventArgs e)
		{
			//BindGrid - to fill the datagrid
			if (!IsPostBack)
				BindGrid();
		}

		public void PublicMethodInUsercontrol(int valuetopasstocontrol)
		{
			try
			{
				//to get the instance form BusinessLogicLayer
				SICALNet.BusinessLogicLayer.ListMaterial BLLLstMat= new SICALNet.BusinessLogicLayer.ListMaterial();
				// to Call the Select method
				
				IList RsLstMat= (IList)BLLLstMat.SelectListMaterial(valuetopasstocontrol);
				//to assign the result set into datagrid
				dgdLstMat.DataSource = RsLstMat;
				//to fill the datagrid
				dgdLstMat.CurrentPageIndex = 0;
				dgdLstMat.DataBind();
			}
			catch
			{
				throw;
			}
		}

		public void BindGrid()
		{
			try
			{
				//to get the instance form BusinessLogicLayer
				SICALNet.BusinessLogicLayer.ListMaterial BLLLstMat= new SICALNet.BusinessLogicLayer.ListMaterial();
				// to Call the Select method
				
				IList RsLstMat= (IList)BLLLstMat.SelectListMaterial(System.Convert.ToInt16(Session["idplantae"].ToString()));
				//to assign the result set into datagrid
				dgdLstMat.DataSource = RsLstMat;
				//to fill the datagrid				
				dgdLstMat.DataBind();
			}
			catch
			{
				throw;
			}
		}

		//to assign the datasource and values into the dropdowncombo
		private void prcFillCombo(DropDownList cboCntl,string txtFiled,string valField,IList RsCboFill,string CurValue)
		{
			cboCntl.DataSource=RsCboFill;
			cboCntl.DataValueField=valField;
			cboCntl.DataTextField=txtFiled;
			cboCntl.DataBind();
			cboCntl.Items.FindByText(CurValue).Selected=true;
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
			this.dgdLstMat.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLstMat_ItemCommand);
			this.dgdLstMat.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdLstMat_PageIndexChanged);
			this.dgdLstMat.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLstMat_CancelCommand);
			this.dgdLstMat.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLstMat_EditCommand);
			this.dgdLstMat.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLstMat_UpdateCommand);
			this.dgdLstMat.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLstMat_DeleteCommand);
			this.dgdLstMat.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdLstMat_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//to initialize the control into the datagrid e.g - dropdownlist or textbox
		private void dgdLstMat_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			try
			{
				if (e.Item.ItemType == ListItemType.EditItem)
				{
					//to fill the codigosap into the cboCodigo control
//					SICALNet.BusinessLogicLayer.Material BLLMat=new SICALNet.BusinessLogicLayer.Material();
//					IList RsMat=(IList) BLLMat.SelectMaterialList(new MaterialInfo("",""));
//					DropDownList cboCodigo = (DropDownList) e.Item.FindControl("cboCodigo");
//					prcFillCombo(cboCodigo,"CodigoSAP","CodigoSAP",RsMat,CodigoDesc);
//
//					DropDownList cboHijo = (DropDownList) e.Item.FindControl("cboHijo");
//					prcFillCombo(cboHijo,"CodigoSAP","CodigoSAP",RsMat,HijoDesc);

					//to fill the unidad description into the cboUnidad control
					Unidad BLLUnidad=new Unidad();
					IList RsUnidad=(IList) BLLUnidad.SelectUnidad();
					DropDownList cboUnidad = (DropDownList) e.Item.FindControl("cboUnidad");
					prcFillCombo(cboUnidad,"Abreviacion","IdUnidad",RsUnidad,UnidadDesc);

					//to fill the Linea description into the cboLinea control
					Planta BLLPlant=new Planta();
					IList RsPlant=(IList) BLLPlant.SelectPlanta();
					DropDownList cboPlanta = (DropDownList) e.Item.FindControl("cboPlanta");
					prcFillCombo(cboPlanta,"Description","IdPlanta",RsPlant,PlantaDesc);
				}
			}
			catch
			{
				throw;
			}
		}

		public int funGetCurrentRow()
		{
			return dgdLstMat.EditItemIndex;
		}

		private void dgdLstMat_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to get the edit item index
//			CodigoDesc = ((Label) e.Item.FindControl("lblCodigo")).Text;
//			HijoDesc= ((Label)e.Item.FindControl("lblHijo")).Text;
//			LineDesc= ((Label) e.Item.FindControl("lblLinea")).Text;
			PlantaDesc= ((Label) e.Item.FindControl("lblPlanta")).Text;
			UnidadDesc= ((Label) e.Item.FindControl("lblUnidad")).Text;
			dgdLstMat.EditItemIndex = (int)e.Item.ItemIndex;
			//to fill the datagrid
			BindGrid();
		}

		private void dgdLstMat_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdLstMat.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid();
		}

		private void dgdLstMat_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//to assign the control box values into variables
				string Codigo= ((Label)e.Item.FindControl("lblCodigo")).Text;
				//to assign the values into BEL
				ListMaterialInfo BELstMat= new ListMaterialInfo(Codigo);
				//to create the BBL
				SICALNet.BusinessLogicLayer.ListMaterial BLLLstMat= new SICALNet.BusinessLogicLayer.ListMaterial();
				//to Call the Delete method
				BLLLstMat.DeleteListMaterial(BELstMat);
				
				//to set the normal mode
				dgdLstMat.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();
				//throw new Exception("La formulación de color fue eliminada");
				string ScriptString="<script language='javascript'>alert('La formulación de color fue eliminada');</script>"; 
				Page.ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);

			}
			catch
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('Ya existe una formulación de color para el color solicitado');</script>"; 
				Page.ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);								
			}
//			catch
//			{				
//				throw;
//			}
		}

		private void dgdLstMat_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//to get an instance from validation
				Validation vdtLstMat = new Validation();

				if (vdtLstMat.IsPositiveNumber(((TextBox)e.Item.FindControl("txtCandidad")).Text)==false)
					throw new Exception("Cantidad should be a Postive Real Number");

				string Codigo= ((Label)e.Item.FindControl("lblcodigo1")).Text;
				string Hijo= ((TextBox)e.Item.FindControl("EditHijo")).Text;

				SICALNet.BusinessLogicLayer.Material Material = new SICALNet.BusinessLogicLayer.Material();
				if (Codigo.Trim() != String.Empty)
				{
					MaterialInfo BESAP = new MaterialInfo(Codigo, String.Empty);
					if (!Material.isExistMaterial(BESAP))
						throw new Exception("Given CodigoSAP Value Does not Exist in Material Table");
				}
				if (Hijo.Trim() != String.Empty)
				{
					MaterialInfo BEHijo = new MaterialInfo(Hijo.Trim(), String.Empty);
					if (!Material.isExistMaterial(BEHijo))
						throw new Exception("Given CodigoSAP Hijo Value Does not Exist in Material Table");
				}

				float Cantidad=Convert.ToSingle(((TextBox)e.Item.FindControl("txtCandidad")).Text);
				int Unidad = Convert.ToInt32(((DropDownList)e.Item.FindControl("cboUnidad")).SelectedItem.Value);
				int Planta = Convert.ToInt32(((DropDownList)e.Item.FindControl("cboPlanta")).SelectedItem.Value);

				//to assign the color info into business entity lager
				SICALNet.BusinessEntities.ListMaterialInfo BELstMat= new SICALNet.BusinessEntities.ListMaterialInfo(Codigo,string.Empty,Hijo,string.Empty,Cantidad,Unidad,Planta,string.Empty,string.Empty);

				//to get an instance from business logic layer
				SICALNet.BusinessLogicLayer.ListMaterial BLLLstMat= new SICALNet.BusinessLogicLayer.ListMaterial();
				//to Call the Insert FormTemperatura method
				BLLLstMat.UpdateListMaterial(BELstMat);
				//to fill the datagrid
				//to calcel the edit mode
				dgdLstMat.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();
				//throw new Exception("Los Datos fueron actualizados existosamente"); 
				string ScriptString="<script language='javascript'>alert('Los Datos fueron actualizados existosamente');</script>"; 
				Page.ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
			}
			catch
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('El ID Identificador ya esta siendo usado por el sistema');</script>"; 
				Page.ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
			}
//			catch
//			{
//				throw;
//			}
		}

		private void dgdLstMat_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i=e.Item.ItemIndex+2;
			if(e.CommandName=="Find")
			{
				
				//Page.RegisterClientScriptBlock("", "<script language='JavaScript'>window.open('FindMaterial.asp?','anycontent','width=1000,height=500,left=100, top=150,status'); </script>");
				Page.RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('FindMaterial.aspx?Form=ListMat&CtrlName=LstMatGrid:dgdLstMat:_ctl"+i+":txtCodigo&CtrlName2=LstMatGrid:dgdLstMat:_ctl"+i+":lblMaterialDesc&flag=1','anycontent','width=600,height=500,left=100, top=150,status,scrollbars=yes'); </script>");
			
				
			}
			if(e.CommandName=="FindHijo")
			{
				
				//Page.RegisterClientScriptBlock("", "<script language='JavaScript'>window.open('FindMaterial.asp?','anycontent','width=1000,height=500,left=100, top=150,status'); </script>");
				Page.RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('FindMaterial.aspx?Form=ListMat&CtrlName=LstMatGrid:dgdLstMat:_ctl"+i+":EditHijo&CtrlName2=LstMatGrid:dgdLstMat:_ctl"+i+":lblHijoDesc&flag=1','anycontent','width=600,height=500,left=100, top=150,status,scrollbars=yes'); </script>");
			
				
			}
		}

		private void dgdLstMat_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdLstMat.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
	}
}
