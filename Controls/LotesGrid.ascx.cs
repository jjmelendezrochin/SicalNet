namespace UserInterface.Controls
{
	using System.Collections;
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using SICALNet.Utilities;
	using SICALNet.BusinessLogicLayer;
	using SICALNet.BusinessEntities;

	/// <summary>
	///		Summary description for LotesGrid.
	/// </summary>
	public abstract class LotesGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dgdLote;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtNoLote;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Button aceptar;
		protected System.Web.UI.WebControls.RangeValidator RangeValidatorNoLote;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		//protected System.Web.UI.WebControls.DropDownList  EditLinea;
		ErrorHandling errFileWrite=new ErrorHandling();
		//string edit_linea;

		private void Page_Load(object sender, System.EventArgs e)
		{		
			if(!IsPostBack)
			{
				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);

				SICALNet.BusinessLogicLayer.LineaProduccion  BRlinea = new SICALNet.BusinessLogicLayer.LineaProduccion();
				IList tipoRs= (IList)BRlinea.SelectLinePdt(theUser);				
				cboLinea.DataSource= tipoRs;
				cboLinea.DataValueField="IdLinea";
				cboLinea.DataTextField="Description";
				cboLinea.DataBind();
				ListItem item = new ListItem("","0");
				cboLinea.Items.Add(item);
				cboLinea.Items.FindByValue("0").Selected = true; 				
				BindGrid();
			}
		}

		public void clearMessage()
		{
			//to clear label box
			lblErrorMsg.ForeColor=Color.White;
			lblErrorMsg.BackColor=Color.White;

		}
		public void BindGridPorFiltro()
		{
			SICALNet.Utilities.Validation val = new  SICALNet.Utilities.Validation();
			if(this.txtNoLote.Text!=string.Empty)
			{
				if(!val.IsNumber(this.txtNoLote.Text))
				{
					prcErrorDisplay(new Exception("El lote debe ser un número"),"Error");
					return;
				}	
				
			}
			this.dgdLote.CurrentPageIndex = 0;
			BindGrid(this.txtNoLote.Text==string.Empty?0:Convert.ToInt32(this.txtNoLote.Text),Convert.ToInt32(this.cboLinea.SelectedItem.Value));


		}
		public void BindGrid()
		{
				SICALNet.Utilities.Validation val = new  SICALNet.Utilities.Validation();
				if(this.txtNoLote.Text!=string.Empty)
				{
					if(!val.IsNumber(this.txtNoLote.Text))
					{
						prcErrorDisplay(new Exception("El lote debe ser un número"),"Error");
						return;
					}						
				}
				BindGrid(this.txtNoLote.Text==string.Empty?0:Convert.ToInt32(this.txtNoLote.Text),Convert.ToInt32(this.cboLinea.SelectedItem.Value));
		}
		private void BindGrid(int NoLote,int Linea)
		{
			try
			{


				SICALNet.BusinessLogicLayer.Lote BRLote = new SICALNet.BusinessLogicLayer.Lote();				
				IList ListLotes = (IList)BRLote.getLote(NoLote,Linea);					
				this.dgdLote.DataSource = ListLotes;
				this.dgdLote.DataBind();				
				prcErrorDisplay(null,"NoError");
			}
			catch
			{
				throw;
			}
		}

		
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//ErrorHandling errFileWrite=new ErrorHandling();
				//errFileWrite.HandleException("Espesor Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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

		private void dgdLote_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdLote.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		private void dgdLote_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text="";
			//edit_linea = ((Label) e.Item.FindControl("ItemLinea")).Text;
			dgdLote.EditItemIndex =(int) e.Item.ItemIndex;
			BindGrid();
		}

		//to initialize the control into the datagrid e.g - dropdownlist or textbox
		private void dgdLote_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			/*
			try
			{
				if (e.Item.ItemType == ListItemType.EditItem)
				{
					SICALNet.BusinessLogicLayer.LineaProduccion  BRlinea = new SICALNet.BusinessLogicLayer.LineaProduccion();
					IList tipoRs= (IList)BRlinea.SelectLinePdt();		
					DropDownList EditLinea = (DropDownList) e.Item.FindControl("EditLinea");
					EditLinea.DataSource= tipoRs;
					EditLinea.DataValueField="IdLinea";
					EditLinea.DataTextField="Description";
					EditLinea.DataBind();
					EditLinea.Items.FindByValue(edit_linea).Selected=true;

				}
			}
			catch(Exception errHand)
			{
				prcErrorDisplay(errHand,"Error");				
			}
			*/
		}
		private void dgdLote_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdLote.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid();
			
		}


		private void dgdLote_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//to get an instance from validation
				Validation vdtColour=new Validation();

				if ((vdtColour.IsPositiveNumber((((TextBox)e.Item.FindControl("EditPiezas")).Text))==false))
				throw new Exception("Valor inválido en el número de piezas");
				
				if ((((TextBox)e.Item.FindControl("EditPiezas")).Text)=="")				
					throw new Exception("Debe capturar el número de piezas");

				// to initialize the planta info into business entities
				string numLoteAux = ((Label)e.Item.FindControl("EditNumeroLote")).Text;
				string idLineaAux = ((Label)e.Item.FindControl("EditLinea")).Text;
				string numPiezasAux= (((TextBox)e.Item.FindControl("EditPiezas")).Text);				
				bool Activo =((CheckBox)e.Item.FindControl("EditActivo")).Checked;

				SICALNet.BusinessLogicLayer.Lote BRLote = new SICALNet.BusinessLogicLayer.Lote();
				SICALNet.BusinessEntities.LoteInfo loteInfo = new SICALNet.BusinessEntities.LoteInfo(Convert.ToInt32(numLoteAux),Convert.ToInt32(idLineaAux),Convert.ToInt32(numPiezasAux),Activo);   
				BRLote.UpdateLote(loteInfo);	

				// Update de Lote en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualizacion de lote: " + loteInfo.NumeroLote,Page.User.Identity.Name.ToString());

				//to calcel the edit mode
				dgdLote.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();
				lblErrorMsg.Text="El registro de actualizó satisfactoriamente";
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;

				
			}
			catch
			{
			   // prcErrorDisplay(errHand,"Error");

				throw;
			}
		}

		private void dgdLote_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				string numLoteAux = ((Label)e.Item.FindControl("ItemNumeroLote")).Text;
				string idLineaAux = ((Label)e.Item.FindControl("ItemLinea")).Text;

				SICALNet.BusinessLogicLayer.Lote BRLote = new SICALNet.BusinessLogicLayer.Lote();				
				BRLote.DeleteLote(Convert.ToInt32(numLoteAux),Convert.ToInt32(idLineaAux)); 	

				// Borrado de Lote en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de lote: " + numLoteAux,Page.User.Identity.Name.ToString());

				//to calcel the edit mode
				dgdLote.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();
				lblErrorMsg.Text="El registro se borro satisfactoriamente";
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;


			}
			catch(Exception errHand)
			{
				// prcErrorDisplay(errHand,"Error");
				//se elimina la siguiente linea se y envia el mensaje de que
				//el producto no se puede borrar por estar usado por el sistema
                //throw;
				string ScriptString="<script language='javascript'>alert('" + errHand.Message.ToString()  + "');</script>"; 
				Page.RegisterStartupScript("ClientScript",ScriptString);
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
			this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
			this.dgdLote.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdLote_PageIndexChanged);
			this.dgdLote.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLote_CancelCommand);
			this.dgdLote.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLote_EditCommand);
			this.dgdLote.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLote_UpdateCommand);
			this.dgdLote.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLote_DeleteCommand);
			this.dgdLote.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdLote_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void aceptar_Click(object sender, System.EventArgs e)
		{
			BindGridPorFiltro();	
		}
	}
}
