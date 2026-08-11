namespace UserInterface.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections;

	using SICALNet.Utilities;
	using SICALNet.BusinessEntities;


	/// <summary>
	///		Summary description for FormPresentacionGrid.
	/// </summary>
	public abstract class FormPresentacionGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dgdFormPresentacion;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected static string _IdPresentacion;
		protected static int _IdMedida,_IdPlanta;
		protected System.Web.UI.WebControls.Label lblallowedit;

		//to get an instance for utility-error handler
		ErrorHandling errFileWrite=new ErrorHandling();


		private void Page_Load(object sender, System.EventArgs e)
		{
			//No initial load of Formulations
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
			this.dgdFormPresentacion.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdFormPresentacion_PageIndexChanged);
			this.dgdFormPresentacion.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormPresentacion_CancelCommand);
			this.dgdFormPresentacion.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormPresentacion_EditCommand);
			this.dgdFormPresentacion.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormPresentacion_UpdateCommand);
			this.dgdFormPresentacion.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormPresentacion_DeleteCommand);
			this.dgdFormPresentacion.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdFormPresentacion_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void BindGrid(string pIdPresentacion, int pIdMedida, int pIdPlanta,bool AllowEdit)
		{
			try
			{
				//Assign parameters to local variables
				_IdPresentacion=pIdPresentacion;
				_IdMedida=pIdMedida;
				_IdPlanta=pIdPlanta;

				//to get the instance for BusinessEntitiesLayer
				SICALNet.BusinessEntities.FormPresentacionInfo formPresBE= new SICALNet.BusinessEntities.FormPresentacionInfo(_IdPresentacion,_IdMedida,_IdPlanta);
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.FormPresentacion formPresBLL= new SICALNet.BusinessLogicLayer.FormPresentacion();
				// to Call the Select method
				IList FormPresentacionList = (IList)formPresBLL.SelectFormPresentacion(formPresBE);
				//to assign the result set into datagrid
				dgdFormPresentacion.DataSource = FormPresentacionList;
				//to fill the datagrid
				dgdFormPresentacion.DataBind();

				//to clear the error msg label
				prcErrorDisplay(null,"NoError");
				//initialy the operation mode is set to default

				if (AllowEdit == true)			
					dgdFormPresentacion.Columns[4].Visible = true;					
				else
					dgdFormPresentacion.Columns[4].Visible = false;

				lblallowedit.Text = AllowEdit.ToString();

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
				errFileWrite.HandleException("FormPresentacion Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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
			else if (errStatus.Substring(0,4)=="Warn")
			{
				lblErrorMsg.Text = errStatus.Substring(6,errStatus.Length-7);
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;
			}
			else
			{
				//to display the success msg
				lblErrorMsg.Text=errStatus;
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;
			}
		}

		private void prcErrorDisplay(Exception errHnd, string Message, string ErrStatus)
		{
			if (ErrStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("User Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
				lblErrorMsg.Text=errHnd.Message;
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;
			}
			else if (ErrStatus=="NoError")
			{
				//to clear label box
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.White;
			}
			else if (ErrStatus=="Warning")
			{
				//to display the warning msg
				lblErrorMsg.Text=Message;
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Red;
			}
			else if (ErrStatus=="Success")
			{
				//to display the success msg
				lblErrorMsg.Text=Message;
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;
			}

			return;
		}

		private void dgdFormPresentacion_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to get the edit item index
			dgdFormPresentacion.EditItemIndex = (int)e.Item.ItemIndex;

			//to fill the datagrid
			BindGrid(_IdPresentacion,_IdMedida,_IdPlanta,System.Convert.ToBoolean(lblallowedit.Text));

		}

		private void dgdFormPresentacion_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdFormPresentacion.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid(_IdPresentacion,_IdMedida,_IdPlanta,System.Convert.ToBoolean(lblallowedit.Text));
		}

		private void loadData(DropDownList DDList, string ValueField, string TextField, string CurrentValue)
		{
			if (ValueField == "IdUnidad")
			{
				SICALNet.BusinessLogicLayer.Unidad Unidad = new SICALNet.BusinessLogicLayer.Unidad();
				DDList.DataSource = Unidad.SelectUnidad();
			}

			DDList.DataValueField = ValueField;
			DDList.DataTextField  = TextField;
			DDList.DataBind();

			//select the old value in DropDownList
			DDList.Items.FindByValue(CurrentValue.Trim()).Selected=true;
		}

		private void dgdFormPresentacion_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.EditItem)
			{
				// To Load Data for Planta DropDownList Box
				string IdUnidad= ((Label) e.Item.FindControl("ItemUnidadId")).Text;
				DropDownList cboUnidad = (DropDownList) e.Item.FindControl("EditUnidad");
				loadData(cboUnidad, "IdUnidad","Descripcion",IdUnidad);
			}
		
		}

		private void dgdFormPresentacion_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{			
			string CodigoSAP;
			float Cantidad;
			int IdUnidad;

			try
			{
				Validation pltVdlt = new Validation();

				if (((TextBox)e.Item.FindControl("EditCantidad")).Text.Trim() == String.Empty)
				{
					prcErrorDisplay(null, "Debe capturar la cantidad","Warning");
					return;
				}

				if (!pltVdlt.IsNumber(((TextBox)e.Item.FindControl("EditCantidad")).Text.Trim()))
				{
					prcErrorDisplay(null, "La cantidad debe ser un número", "Warning");
					return;
				}
				
				CodigoSAP = ((Label)e.Item.FindControl("EditCodigoSAP")).Text.Trim();
				Cantidad = (float)Convert.ToDecimal(((TextBox)e.Item.FindControl("EditCantidad")).Text.Trim());
				IdUnidad = Convert.ToInt32(((DropDownList)e.Item.FindControl("EditUnidad")).SelectedItem.Value);
				
				FormPresentacionInfo fpInfo = new FormPresentacionInfo(_IdPresentacion, string.Empty, _IdMedida, string.Empty, _IdPlanta, string.Empty, CodigoSAP, string.Empty, Cantidad, IdUnidad, string.Empty);

				SICALNet.BusinessLogicLayer.FormPresentacion FormPresentacion = new SICALNet.BusinessLogicLayer.FormPresentacion();
				FormPresentacion.UpdateFormPresentacion(fpInfo);

				//to calcel the edit mode
				dgdFormPresentacion.EditItemIndex = -1;
				
				BindGrid(_IdPresentacion,_IdMedida,_IdPlanta,System.Convert.ToBoolean(lblallowedit.Text));

				//to call error msg function
				prcErrorDisplay(null,"El registro se modifico con éxito","Success");
			}
			catch 
			{
				//to display the error msg
				// prcErrorDisplay(errHand,"Error");
				//to set focus

				throw;
			}
		}

		// Procedure to Set Focus to Controls
//		private void SetFocus(object sender)
//		{
//			if(sender.GetType().Name=="TextBox")
//				Page.RegisterStartupScript("focus","<SCRIPT language='javascript'>" + "document.all('" + ((TextBox)sender).ClientID + "').focus();" + "</SCRIPT>");
//		}

		private void dgdFormPresentacion_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				// Obtain the Component to delete
				string CodigoSAP=(((Label)e.Item.FindControl("ItemCodigoSAP")).Text.Trim());
			
				FormPresentacionInfo fpInfo = new FormPresentacionInfo(_IdPresentacion,string.Empty, _IdMedida, string.Empty,_IdPlanta, string.Empty,CodigoSAP,string.Empty,0,0,string.Empty);

				SICALNet.BusinessLogicLayer.FormPresentacion FormPresentacion = new SICALNet.BusinessLogicLayer.FormPresentacion();
				FormPresentacion.DeleteFormPresentacion(fpInfo);

				dgdFormPresentacion.EditItemIndex = -1;
				BindGrid(_IdPresentacion,_IdMedida,_IdPlanta,System.Convert.ToBoolean(lblallowedit.Text));

				//to give the confirmation to the user
				prcErrorDisplay(null,"El registro se elimino con éxito");		
			}
			catch 
			{
				//to diaplay error msg
				// prcErrorDisplay(ErrHand,"Error");				
				
				throw;
			}
		}

		private void dgdFormPresentacion_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdFormPresentacion.CurrentPageIndex = e.NewPageIndex;
			BindGrid(_IdPresentacion,_IdMedida,_IdPlanta,System.Convert.ToBoolean(lblallowedit.Text));
		}

	}
	
}
