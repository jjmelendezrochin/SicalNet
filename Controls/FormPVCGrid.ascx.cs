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
	///		Summary description for FormPVCGrid.
	/// </summary>
	
	public abstract class FormPVCGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dgdFormPVC;
		protected System.Web.UI.WebControls.Label lblErrorMsg;

		//to get an instance for utility-error handler
		ErrorHandling errFileWrite=new ErrorHandling();
		protected static string _Familiaproducto;
		protected static string _Medida;
		protected static string _IdEspesor;
		protected static int _IdFamiliaProducto, _IdMedida,_IdPlanta, _IdAcabado, _IdLinea;
		protected System.Web.UI.WebControls.Label lblallowedit;

		private void Page_Load(object sender, System.EventArgs e)
		{
			//No Loading of Formulations on Page Load - Daniel Novelo
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
			this.dgdFormPVC.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormPVC_ItemCommand);
			this.dgdFormPVC.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdFormPVC_PageIndexChanged);
			this.dgdFormPVC.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormPVC_CancelCommand);
			this.dgdFormPVC.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormPVC_EditCommand);
			this.dgdFormPVC.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormPVC_UpdateCommand);
			this.dgdFormPVC.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormPVC_DeleteCommand);
			this.dgdFormPVC.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdFormPVC_ItemDataBound);
			this.dgdFormPVC.SelectedIndexChanged += new System.EventHandler(this.dgdFormPVC_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void familiaproducto(string familia, string medida)
		{
			_Familiaproducto = familia;
			_Medida = medida;
		}

		public bool BindGrid(int pIdFamiliaProducto, int pIdMedida, string pIdEspesor, 
			int pIdPlanta, int pIdAcabado, int pIdLinea, bool AllowEdit)
		{
			try
			{
				//Assign parameters to local variables
				_IdFamiliaProducto	= pIdFamiliaProducto;
				_IdMedida			= pIdMedida;
				_IdEspesor			= pIdEspesor;
				_IdPlanta			= pIdPlanta;
				_IdAcabado			= pIdAcabado;
				_IdLinea			= pIdLinea;

				//Create the entity FormPVCInfo
				FormPVCInfo pvcInfo = new FormPVCInfo(_IdFamiliaProducto,_IdMedida,_IdEspesor,_IdPlanta, 0,_IdAcabado, _IdLinea);
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.FormPVC pvc= new SICALNet.BusinessLogicLayer.FormPVC();
				// to Call the Select method
				IList pvcRs= (IList)pvc.SelectFormPVC(pvcInfo);
				//to assign the result set into datagrid
				dgdFormPVC.DataSource = pvcRs;
				//to fill the datagrid
				dgdFormPVC.DataBind();
				//to clear the error msg label
				prcErrorDisplay(null,"NoError");
				//initialy the operation mode is set to default
				Session["Mode"]="Default";

				if (AllowEdit == true)			
					dgdFormPVC.Columns[4].Visible = true;					
				else
					dgdFormPVC.Columns[4].Visible = false;

				lblallowedit.Text = AllowEdit.ToString();

				return (pvcRs.Count>0);
			}
			catch
			{
				throw;
			}
		}

		private void dgdFormPVC_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.EditItem)
			{
				// To Load Data for Planta DropDownList Box
				string IdUnidad= ((Label) e.Item.FindControl("ItemUnidadId")).Text;
				DropDownList cboUnidad = (DropDownList) e.Item.FindControl("EditUnidad");
				loadData(cboUnidad, "IdUnidad","Descripcion",IdUnidad);
			}
		}

		//to display the error msg in the label box and write the error the error msg into error log file
		public void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("PermisoPerfil Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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

		
		private void dgdFormPVC_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				Validation prdVdlt=new Validation();
					
				string CodigoSAP=(((Label)e.Item.FindControl("EditCodigoSAP")).Text.Trim());
				int IdUnidad=Convert.ToInt32(((DropDownList)e.Item.FindControl("EditUnidad")).SelectedItem.Value);
				
				Double Cantidad; 

				if (((TextBox)e.Item.FindControl("EditCantidad")).Text.Trim() == String.Empty)
				{
					prcErrorDisplay(null, "Debe captura la cantidad");
					return;
				}
				
				if (!(prdVdlt.IsNumber(((TextBox)e.Item.FindControl("EditCantidad")).Text)))
				{
					prcErrorDisplay(null, "La cantidad debe ser un número");
					return;
					//throw new Exception("Cantidad should be Numeric");
				}
				else
					Cantidad=Convert.ToDouble(((TextBox)e.Item.FindControl("EditCantidad")).Text.Trim());

				if(Cantidad<=0)
				{
					prcErrorDisplay(null, "La cantidad debe ser un dato mayor que cero");
					return;
				}
					//throw new Exception("Cantidad value Should be greater than Zero");

				FormPVCInfo pvcInfo=new FormPVCInfo(_IdFamiliaProducto,_IdMedida,_IdEspesor,_IdPlanta,CodigoSAP,string.Empty,(float)Cantidad,IdUnidad,string.Empty,string.Empty, _IdAcabado, _IdLinea, String.Empty);
				
				SICALNet.BusinessLogicLayer.FormPVC pvcBL=new SICALNet.BusinessLogicLayer.FormPVC();
				pvcBL.UpdateFormPVC(pvcInfo);
				
				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualizacion formulacion de pvc: " + _Familiaproducto + " medida: " + _Medida + " codigo SAP: "+ CodigoSAP,Page.User.Identity.Name.ToString());

			

				dgdFormPVC.EditItemIndex=-1;
				BindGrid(_IdFamiliaProducto,_IdMedida,_IdEspesor,_IdPlanta, _IdAcabado, _IdLinea, System.Convert.ToBoolean(lblallowedit.Text));
				prcErrorDisplay(null,"El registro se modifico con éxito");
			}
			catch
			{
				// prcErrorDisplay(ex,"Error");
				
				throw;
			}
		}


		private void dgdFormPVC_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text="";
			dgdFormPVC.EditItemIndex =(int) e.Item.ItemIndex;

			BindGrid(_IdFamiliaProducto,_IdMedida,_IdEspesor,_IdPlanta, _IdAcabado, _IdLinea, System.Convert.ToBoolean(lblallowedit.Text));
		}

		private void dgdFormPVC_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				// Obtain the Component to delete
				string CodigoSAP=(((Label)e.Item.FindControl("ItemCodigoSAP")).Text.Trim());

				//to assign the values into BEL
				FormPVCInfo pvcInfo = new FormPVCInfo(_IdFamiliaProducto,_IdMedida,_IdEspesor,_IdPlanta,CodigoSAP,string.Empty,0,0,string.Empty,string.Empty, _IdAcabado, _IdLinea, string.Empty);
				//to create the BBL
				SICALNet.BusinessLogicLayer.FormPVC pvc= new SICALNet.BusinessLogicLayer.FormPVC();
				// Call the Delete method
				pvc.DeleteFormPVC(pvcInfo);
				
				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado formulacion de pvc: " + _Familiaproducto + " medida: " + _Medida +  " codigo SAP: "+ CodigoSAP,Page.User.Identity.Name.ToString());

			
			
				//to set the normal mode
				dgdFormPVC.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid(_IdFamiliaProducto,_IdMedida,_IdEspesor,_IdPlanta, _IdAcabado, _IdLinea, System.Convert.ToBoolean(lblallowedit.Text));

				//to give the confirmation to the user
				prcErrorDisplay(null,"El registro se elimino con éxito");	
			}
			catch 
			{
				//to diaplay error msg
				//prcErrorDisplay(ErrHand,"The selected FormPVCIds is being used by the system, and cannot be deleted");				
				// prcErrorDisplay(ErrHand,"Error");

				throw;
			}
		}

		

		private void dgdFormPVC_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdFormPVC.EditItemIndex = -1;

			//to fill the datagrid
			BindGrid(_IdFamiliaProducto,_IdMedida,_IdEspesor,_IdPlanta, _IdAcabado, _IdLinea, System.Convert.ToBoolean(lblallowedit.Text));
		}

		private void dgdFormPVC_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdFormPVC.EditItemIndex = -1;
			dgdFormPVC.CurrentPageIndex = e.NewPageIndex;
			BindGrid(_IdFamiliaProducto,_IdMedida,_IdEspesor,_IdPlanta, _IdAcabado, _IdLinea,  System.Convert.ToBoolean(lblallowedit.Text));
		}

		private void dgdFormPVC_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i=e.Item.ItemIndex+3;
			if(e.CommandName=="Find")
			{
				//Page.RegisterClientScriptBlock("", "<script language='JavaScript'>window.open('FindMaterial.asp?','anycontent','width=1000,height=500,left=100, top=150,status'); </script>");
				Page.RegisterClientScriptBlock("", "<script language='JavaScript'> window.open('FindMaterial.aspx?Form=FormulationofPVC&CtrlName=FormPVCGridControl:dgdFormPVC:_ctl"+i+":EditCodigoSAP&CtrlName2=FormPVCGridControl:dgdFormPVC:_ctl"+i+":txtDescripcion&flag=1','anycontent','width=600,height=300,left=100, top=150,status,scrollbars=yes'); </script>");
							
			}
		}
		
		private void loadData(DropDownList DDList, string ValueField, string TextField, string CurrentValue)
		{
			if (ValueField == "IdUnidad")
			{
				SICALNet.BusinessLogicLayer.Unidad bllUnidad= new SICALNet.BusinessLogicLayer.Unidad();
				DDList.DataSource = bllUnidad.SelectUnidad();
			}

			DDList.DataValueField = ValueField;
			DDList.DataTextField  = TextField;
			DDList.DataBind();

			//select the old value in DropDownList
			DDList.Items.FindByValue(CurrentValue.Trim()).Selected=true;
		}

		private void dgdFormPVC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		
	}
}
