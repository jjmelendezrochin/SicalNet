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
	///		Summary description for FormCintas.
	/// </summary>
	public abstract class FormCintasGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dgdFormCintas;
		protected System.Web.UI.WebControls.Label lblErrorMsg;

		private static int _IdFamiliaProducto, _IdMedida, _IdPlanta;
		protected System.Web.UI.WebControls.Label lblallowedit;

		ErrorHandling ExpHand=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			//No data binding on Load
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
			this.dgdFormCintas.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdFormCintas_PageIndexChanged);
			this.dgdFormCintas.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormCintas_CancelCommand);
			this.dgdFormCintas.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormCintas_EditCommand);
			this.dgdFormCintas.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormCintas_UpdateCommand);
			this.dgdFormCintas.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormCintas_DeleteCommand);
			this.dgdFormCintas.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdFormCintas_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void BindGrid(int idFamiliaProducto, int idMedida, int idPlanta,bool AllowEdit)
		{
			try
			{
				_IdFamiliaProducto=idFamiliaProducto;
				_IdMedida=idMedida;
				_IdPlanta=idPlanta;

				SICALNet.BusinessEntities.FormCintasInfo BELFormCintas = new SICALNet.BusinessEntities.FormCintasInfo(_IdFamiliaProducto,_IdMedida,_IdPlanta);
				//to get the instance form BusinessLogicLayer
				SICALNet.BusinessLogicLayer.FormCintas BLLFormCintas= new SICALNet.BusinessLogicLayer.FormCintas();
				// to Call the Select method
				IList RsGrdFormCintas= (IList)BLLFormCintas.SelectFormCintas(BELFormCintas);
				//to assign the result set into datagrid
				dgdFormCintas.DataSource = RsGrdFormCintas;
				//to fill the datagrid
				
				dgdFormCintas.DataBind();

				if (AllowEdit == true)			
					dgdFormCintas.Columns[4].Visible = true;					
				else
					dgdFormCintas.Columns[4].Visible = false;

				lblallowedit.Text = AllowEdit.ToString();
			}
			catch(Exception errHand)
			{
				Session["errMsg"]=ExpHand.HandleException("Structure","FormCintas",errHand,Server.MapPath(".."),errHand.Message);
			}
		}

		//to assign the datasource and values into the dropdowncombo
		private void prcFillCombo(DropDownList cboCntl,string txtFiled,string valField,IList RsCboFill,string CurValue)
		{
			cboCntl.DataSource=RsCboFill;
			cboCntl.DataValueField=valField;
			cboCntl.DataTextField=txtFiled;
			cboCntl.DataBind();
			cboCntl.Items.FindByValue(CurValue).Selected=true;
		}

		//to initialize the control into the datagrid e.g - dropdownlist or textbox
		private void dgdFormCintas_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			try
			{
				if (e.Item.ItemType == ListItemType.EditItem)
				{
					// To Load Data for Planta DropDownList Box
					string IdUnidad= ((Label) e.Item.FindControl("ItemUnidadId")).Text;

					//to fill the Unidad description into the cboUnidad control
					SICALNet.BusinessLogicLayer.Unidad BLLUnidad=new SICALNet.BusinessLogicLayer.Unidad();
					IList RsUnidad=(IList) BLLUnidad.SelectUnidad();
					DropDownList cboUnid = (DropDownList) e.Item.FindControl("EditUnidad");
					prcFillCombo(cboUnid,"Descripcion","IdUnidad",RsUnidad,IdUnidad);
				}
			}
			catch
			{
				// Session["errMsg"]=ExpHand.HandleException("Structure","FormCintas",errHand,Server.MapPath(".."),errHand.Message);

				throw;
			}
		}

		public int funGetCurrentRow()
		{
			return dgdFormCintas.EditItemIndex;
		}

		private void dgdFormCintas_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to get the edit item index
			dgdFormCintas.EditItemIndex = (int)e.Item.ItemIndex;
			//to fill the datagrid
			BindGrid(_IdFamiliaProducto,_IdMedida,_IdPlanta,System.Convert.ToBoolean(lblallowedit.Text));
		}

		private void dgdFormCintas_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdFormCintas.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid(_IdFamiliaProducto,_IdMedida,_IdPlanta,System.Convert.ToBoolean(lblallowedit.Text));
		}

		private void dgdFormCintas_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//to get an instance from validation
				Validation vdtFormCintas = new Validation();
				//to check colorid whether its correct or not
				if (vdtFormCintas.IsPositiveNumber(((TextBox)e.Item.FindControl("EditCantidad")).Text)==false)
				{
					prcErrorDisplay("La cantidad debe ser un número positivo entero.","Error");
					return;
				}

				string Codigo= ((Label)e.Item.FindControl("EditCodigoSAP")).Text;
				float Cantidad=Convert.ToSingle(((TextBox)e.Item.FindControl("EditCantidad")).Text);
				if(Cantidad<=0)
				{
					prcErrorDisplay("","La cantidad debe ser un número mayor que cero");
					return;
				}
				int IdUnidad= Convert.ToInt32(((DropDownList)e.Item.FindControl("EditUnidad")).SelectedItem.Value);

				//to assign the color info into business entity lager
				FormCintasInfo BEFormCintas= new FormCintasInfo(_IdFamiliaProducto,_IdMedida,_IdPlanta,Codigo,string.Empty,(float)Cantidad,IdUnidad,string.Empty);

				//to get an instance from business logic layer
				SICALNet.BusinessLogicLayer.FormCintas BLLFormCintas= new SICALNet.BusinessLogicLayer.FormCintas();
				//to Call the Insert FormCintas method
				BLLFormCintas.UpdateFormCintas(BEFormCintas);
				//to fill the datagrid
				//to calcel the edit mode
				dgdFormCintas.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid(_IdFamiliaProducto,_IdMedida,_IdPlanta,System.Convert.ToBoolean(lblallowedit.Text));
				prcErrorDisplay("El registro se modifico con éxito","Success");
			}
			catch
			{
				// prcErrorDisplay(errHand.Message,"Error");

				throw;
			}
//			catch
//			{
//				// prcErrorDisplay(errHand.Message,"Error");
//
//				throw;
//			}
		}

		private void dgdFormCintas_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				string codigoSAP = ((Label)e.Item.FindControl("ItemCodigoSAP")).Text;
				//to assign the values into BEL
				FormCintasInfo BEFormCintas= new FormCintasInfo(_IdFamiliaProducto,_IdMedida,_IdPlanta,codigoSAP);
				//to create the BBL
				SICALNet.BusinessLogicLayer.FormCintas BLLFormCintas= new SICALNet.BusinessLogicLayer.FormCintas();
				//to Call the Delete method
				BLLFormCintas.DeleteFormCintas(BEFormCintas);
				
				//to set the normal mode
				dgdFormCintas.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid(_IdFamiliaProducto,_IdMedida,_IdPlanta,System.Convert.ToBoolean(lblallowedit.Text));
			}
			catch
			{
				// Session["errMsg"]=ExpHand.HandleException("Structure","FormCintas",errHand,Server.MapPath(".."),"El identificador que proporciono ya se encuentra en uso");
				
				lblErrorMsg.Text = "El identificador que proporciono ya se encuentra en uso";
			}
//			catch
//			{
//				throw;
//			}
		}

		//to display the error msg in the label box and write the error the error msg into error log file
		private void prcErrorDisplay(string strMessage,string errStatus)
		{
			switch (errStatus)
			{
				case "Error":
					//to display the error msg
					lblErrorMsg.Text=strMessage;
					lblErrorMsg.ForeColor=Color.White;
					lblErrorMsg.BackColor=Color.Red;
					break;
				case "NoError":
					//to clear label box
					lblErrorMsg.ForeColor=Color.White;
					lblErrorMsg.BackColor=Color.White;
					break;
				case "Success":
					//to display the success msg
					lblErrorMsg.Text=strMessage;
					lblErrorMsg.ForeColor=Color.White;
					lblErrorMsg.BackColor=Color.Green;
					break;
			}
		}

		private void dgdFormCintas_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdFormCintas.EditItemIndex = -1;
			dgdFormCintas.CurrentPageIndex = e.NewPageIndex;
			BindGrid(_IdFamiliaProducto,_IdMedida,_IdPlanta,System.Convert.ToBoolean(lblallowedit.Text));
		}
	}
}