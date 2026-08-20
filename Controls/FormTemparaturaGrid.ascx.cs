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
	///		Summary description for FormTemparaturaGrid.
	/// </summary>
	public abstract class FormTemparaturaGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dgdFrmTemp;
		protected System.Web.UI.WebControls.Label lblallowedit;
		ErrorHandling ExpHand=new ErrorHandling();

//		private string Centimetros;
//		private string FampdtDesc;
//		private string LineDesc;

		private void Page_Load(object sender, System.EventArgs e)
		{
			//BindGrid - to fill the datagrid
			if (!IsPostBack)
			{
					//BindGrid();
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
			this.dgdFrmTemp.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFrmTemp_CancelCommand);
			this.dgdFrmTemp.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFrmTemp_EditCommand);
			this.dgdFrmTemp.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFrmTemp_UpdateCommand);
			this.dgdFrmTemp.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFrmTemp_DeleteCommand);
			this.dgdFrmTemp.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdFrmTemp_ItemDataBound);	

			this.dgdFrmTemp.PageIndexChanged +=
			new System.Web.UI.WebControls.DataGridPageChangedEventHandler(
				this.dgdFrmTemp_PageIndexChanged
			);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		public void BindGrid(bool AllowEdit)
		{
			try
			{
				//to get the instance form BusinessLogicLayer
				SICALNet.BusinessLogicLayer.FormTemperatura BLLFrmTemp= new SICALNet.BusinessLogicLayer.FormTemperatura();
				// to Call the Select method
				IList RsFrmTemp= (IList)BLLFrmTemp.SelectAllFrmTemp();
				//to assign the result set into datagrid
				dgdFrmTemp.DataSource = RsFrmTemp;
				//to fill the datagrid
				dgdFrmTemp.DataBind();

				if (AllowEdit == true)			
					dgdFrmTemp.Columns[8].Visible = true;					
				else
					dgdFrmTemp.Columns[8].Visible = false;

				lblallowedit.Text = AllowEdit.ToString();
			}
			catch
			{
				throw;
			}
		}

//		//to assign the datasource and values into the dropdowncombo
//		private void prcFillCombo(DropDownList cboCntl,string txtFiled,string valField,IList RsCboFill,string CurValue)
//		{
//			cboCntl.DataSource=RsCboFill;
//			cboCntl.DataValueField=valField;
//			cboCntl.DataTextField=txtFiled;
//			cboCntl.DataBind();
//			cboCntl.Items.FindByText(CurValue).Selected=true;
//		}

		//to initialize the control into the datagrid e.g - dropdownlist or textbox
		private void dgdFrmTemp_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			try
			{
				if (e.Item.ItemType == ListItemType.EditItem)
				{
//					//to fill the familia producto's description into the cbofampdt control
//					SICALNet.BusinessLogicLayer.FamiliaProducto BLLFampdt=new SICALNet.BusinessLogicLayer.FamiliaProducto();
//					IList RsFampdt=(IList) BLLFampdt.SelectFamiliaProducto();
//					DropDownList cboFamPdt = (DropDownList) e.Item.FindControl("cboFamPdt");
//					prcFillCombo(cboFamPdt,"Descripcion","IdFamiliaProductos",RsFampdt,FampdtDesc);
//					//to fill the IdEspesor into the cboEspesor control
//					SICALNet.BusinessLogicLayer.Espesor BLLEsp=new SICALNet.BusinessLogicLayer.Espesor();
//					IList RsEsp=(IList) BLLEsp.LoadEspesor();
//					DropDownList cboEsp= (DropDownList) e.Item.FindControl("cboEspesor");
//					prcFillCombo(cboEsp,"Centimetros","IdEspesor",RsEsp,Centimetros);
//					//to fill the Linea description into the cboLinea control
//					SICALNet.BusinessLogicLayer.LineaProduccion BLLLine=new SICALNet.BusinessLogicLayer.LineaProduccion();
//					IList RsLine=(IList) BLLLine.SelectLinePdt();
//					DropDownList cboLinea = (DropDownList) e.Item.FindControl("cboLinea");
//					prcFillCombo(cboLinea,"Description","IdLinea",RsLine,LineDesc);
				}
			}
			catch
			{
				throw;
			}
		}

		public int funGetCurrentRow()
		{
			return dgdFrmTemp.EditItemIndex;
		}

		private void dgdFrmTemp_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to get the edit item index
//			LineDesc= ((Label) e.Item.FindControl("lblLinea")).Text;
//			FampdtDesc= ((Label) e.Item.FindControl("lblFamPdt")).Text;
//			Centimetros= ((Label) e.Item.FindControl("lblespesor")).Text;
			dgdFrmTemp.EditItemIndex = (int)e.Item.ItemIndex;
			//to fill the datagrid
			BindGrid(System.Convert.ToBoolean(lblallowedit.Text));
		}

		private void dgdFrmTemp_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdFrmTemp.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid(System.Convert.ToBoolean(lblallowedit.Text));
		}

		private void dgdFrmTemp_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//to assign the control box values into variables
				int IdFamPdt = Convert.ToInt32(((Label)e.Item.FindControl("lblFamPdtId")).Text);
				string IdEspesor = ((Label)e.Item.FindControl("lblEspesorId")).Text;
				int IdLinea= Convert.ToInt32(((Label)e.Item.FindControl("lblLineaId")).Text);
				//to assign the values into BEL
				FormTemperaturaInfo BEFrmTemp= new FormTemperaturaInfo(IdFamPdt,IdEspesor,IdLinea,0,0,0,0);
				//to create the BBL
				SICALNet.BusinessLogicLayer.FormTemperatura BLLfrmTemp= new SICALNet.BusinessLogicLayer.FormTemperatura();
				//to Call the Delete method
				BLLfrmTemp.DeleteFormTemperatura(BEFrmTemp);
				
				//to set the normal mode
				dgdFrmTemp.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid(System.Convert.ToBoolean(lblallowedit.Text));
			}
			catch
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('El ID Identificador esta siendo ya usado');</script>"; 
				Page.ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
			}
//			catch
//			{
//				throw;
//			}
		}

		private void dgdFrmTemp_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//to get an instance from validation
				Validation vdtfrmTemp = new Validation();
				//to check colorid whether its correct or not
				if (vdtfrmTemp.IsInteger(((TextBox)e.Item.FindControl("txtTimeCurado")).Text)==false)
					throw new Exception("Tiempo de Curado should be an Integer number");
				if (vdtfrmTemp.IsInteger(((TextBox)e.Item.FindControl("txtTimePC")).Text)==false)
					throw new Exception("Tiempo de Curado Post should be an Integer number");

				if (vdtfrmTemp.IsPositiveNumber(((TextBox)e.Item.FindControl("txtTempCurado")).Text)==false)
					throw new Exception("Temp de Curado should be a Postive Real Number");
				if (vdtfrmTemp.IsPositiveNumber(((TextBox)e.Item.FindControl("txtTempPC")).Text)==false)
					throw new Exception("Temp de Post Curado Post should be a Postive Real number");

				//to assign the control box values into variables
//				int IdFamPdt = Convert.ToInt32(((DropDownList)e.Item.FindControl("cboFamPdt")).SelectedItem.Value);
//				string IdEsp = ((DropDownList)e.Item.FindControl("cboEspesor")).SelectedItem.Value;
//				int IdLinea = Convert.ToInt32(((DropDownList)e.Item.FindControl("cboLinea")).SelectedItem.Value);
				int IdFamPdt = Convert.ToInt32(((Label)e.Item.FindControl("lblFamPdtId")).Text);
				string IdEsp = ((Label)e.Item.FindControl("lblEspesorId")).Text;
				int IdLinea= Convert.ToInt32(((Label)e.Item.FindControl("lblLineaId")).Text);

				int TimepoC=Convert.ToInt32(((TextBox)e.Item.FindControl("txtTimeCurado")).Text);
				int TimepoPC=Convert.ToInt32(((TextBox)e.Item.FindControl("txtTimePC")).Text);

				float TmepC=Convert.ToSingle(((TextBox)e.Item.FindControl("txtTempCurado")).Text);
				float TmepPC=Convert.ToSingle(((TextBox)e.Item.FindControl("txtTempPC")).Text);

//				int oldIdFamPdt = Convert.ToInt32(((Label)e.Item.FindControl("lblFamPdtId")).Text);
//				int oldIdEsp = Convert.ToInt32(((Label)e.Item.FindControl("lblEspesorId")).Text);
//				int oldIdLinea = Convert.ToInt32(((Label)e.Item.FindControl("lblLineaId")).Text);

				//to assign the color info into business entity lager
				FormTemperaturaInfo BEFrmTemp= new FormTemperaturaInfo(IdFamPdt,IdEsp,IdLinea,TimepoC,TmepC,TimepoPC,TmepPC);

				//to get an instance from business logic layer
				SICALNet.BusinessLogicLayer.FormTemperatura BLLFrmTemp= new SICALNet.BusinessLogicLayer.FormTemperatura();
				//to Call the Insert FormTemperatura method
				BLLFrmTemp.UpdateFormTemperatura(BEFrmTemp);
				//to fill the datagrid
				//to calcel the edit mode
				dgdFrmTemp.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid(System.Convert.ToBoolean(lblallowedit.Text));
			}
			catch
			{
				//to display the msg for user
				string ScriptString="<script language='javascript'>alert('El ID Identificador esta siendo ya usado');</script>"; 
				Page.ClientScript.RegisterStartupScript(this.GetType(),"ClientScript",ScriptString);
			}
//			catch
//			{
//				throw;
//			}
		}

		private void dgdFrmTemp_PageIndexChanged(
		object source,
		System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			// Cambiar a la página seleccionada
			dgdFrmTemp.CurrentPageIndex = e.NewPageIndex;

			// Salir del modo edición
			dgdFrmTemp.EditItemIndex = -1;

			// Volver a llenar el grid
			BindGrid(System.Convert.ToBoolean(lblallowedit.Text));
		}
	}
}
