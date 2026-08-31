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
	public abstract class OllaGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dgdOlla;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.DropDownList  EditLinea;
		protected System.Web.UI.WebControls.DropDownList  EditPlanta;
		ErrorHandling errFileWrite=new ErrorHandling();
		string edit_linea;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Button aceptar;
		protected System.Web.UI.WebControls.TextBox txtNumOlla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden ItemDescripcionhtml; 
		string edit_planta;
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
				//BindGrid();
			}
		}

		public void clearMessage()
		{
			//to clear label box
			lblErrorMsg.ForeColor=Color.White;
			lblErrorMsg.BackColor=Color.White;

		}
		private void BindGridPorFiltro()	
			{
		
				SICALNet.Utilities.Validation val = new  SICALNet.Utilities.Validation();
				if(this.txtNumOlla.Text!=string.Empty)
				{
					if(!val.IsNumber(this.txtNumOlla.Text))
					{
						prcErrorDisplay(new Exception("El número de olla debe ser un número"),"Error");
						return;
					}						
				}
			   this.dgdOlla .CurrentPageIndex =0; 
			   this.BindGrid(this.txtNumOlla.Text==string.Empty?0:Convert.ToInt32(this.txtNumOlla.Text),Convert.ToInt32(this.cboLinea.SelectedItem.Value));
			
			}


		private void BindGrid(int numOlla,int idLinea)
		{
			try
			{
				SICALNet.BusinessLogicLayer.Olla BROlla = new SICALNet.BusinessLogicLayer.Olla();				
				IList ListOllas = (IList)BROlla.SelectOlla(numOlla,idLinea);					
				this.dgdOlla.DataSource = ListOllas;
				this.dgdOlla.DataBind();
				prcErrorDisplay(null,"NoError");
			}
			catch
			{
				throw;
			}
		}

		public void BindGrid()
		{
		
			SICALNet.Utilities.Validation val = new  SICALNet.Utilities.Validation();
			if(this.txtNumOlla.Text!=string.Empty)
			{
				if(!val.IsNumber(this.txtNumOlla.Text))
				{
					prcErrorDisplay(new Exception("El número de olla debe ser un número"),"Error");
					return;
				}						
			}
			BindGrid(this.txtNumOlla.Text==string.Empty?0:Convert.ToInt32(this.txtNumOlla.Text),Convert.ToInt32(this.cboLinea.SelectedItem.Value));
			
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

		private void dgdOlla_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdOlla.EditItemIndex = -1;
			dgdOlla.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		private void dgdOlla_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text="";
			edit_linea = ((Label) e.Item.FindControl("ItemLinea")).Text;
			edit_planta = ((Label) e.Item.FindControl("ItemPlanta")).Text;
			ItemDescripcionhtml.Value = ((Label) e.Item.FindControl("ItemDescripcion")).Text;
			dgdOlla.EditItemIndex =(int) e.Item.ItemIndex;
			BindGrid();
		}

		//to initialize the control into the datagrid e.g - dropdownlist or textbox
		private void dgdOlla_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			try
			{
				if (e.Item.ItemType == ListItemType.EditItem)
				{

					SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
					SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
					theUser  = BLLUser.Load(theUser);

					SICALNet.BusinessLogicLayer.LineaProduccion  BRlinea = new SICALNet.BusinessLogicLayer.LineaProduccion();
					IList tipoRs= (IList)BRlinea.SelectLinePdt(theUser);		
					DropDownList EditLinea =  (DropDownList) e.Item.FindControl("EditLinea");
					EditLinea.DataSource= tipoRs;
					EditLinea.DataValueField="IdLinea";
					EditLinea.DataTextField="Description";
					EditLinea.DataBind();
					EditLinea.Items.FindByValue(edit_linea).Selected=true;


					SICALNet.BusinessLogicLayer.Planta  BRPlanta = new SICALNet.BusinessLogicLayer.Planta();
					IList tipoRs2= (IList)BRPlanta.SelectPlanta();		
					DropDownList EditPlanta = (DropDownList) e.Item.FindControl("EditPlanta");
					EditPlanta.DataSource= tipoRs2;
					EditPlanta.DataValueField="IdPlanta";
					EditPlanta.DataTextField="Description";
					EditPlanta.DataBind();
					EditPlanta.Items.FindByText(edit_planta).Selected=true;

				}
			}
			catch
			{
				// prcErrorDisplay(errHand,"Error");				

				throw;
			}			
		}

		private void dgdOlla_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdOlla.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid();
			
		}


		private void dgdOlla_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//to get an instance from validation
				Validation vdtColour=new Validation();

				if ((vdtColour.IsNumber((((TextBox)e.Item.FindControl("EditCapacidadMax")).Text))==false))
					throw new Exception("Valor inválido en el número de olla");
				
				if ((((TextBox)e.Item.FindControl("EditCapacidadMax")).Text)=="")				
					throw new Exception("Debe capturar el número de olla");

				if ((vdtColour.IsNumber((((TextBox)e.Item.FindControl("EditCapacidadMin")).Text))==false))
					throw new Exception("Valor inválido en el número de olla");
				
				if ((((TextBox)e.Item.FindControl("EditCapacidadMin")).Text)=="")				
					throw new Exception("Debe capturar el número de olla");


				// to initialize the olla info into business entities
				string numOllaAux = ((Label)e.Item.FindControl("EditNumeroOlla")).Text;
				string idLineaAux = ((DropDownList)e.Item.FindControl("EditLinea")).SelectedItem.Value;
				string idPlantaAux = ((DropDownList)e.Item.FindControl("EditPlanta")).SelectedItem.Value;
				string CapacidadMaxAux= (((TextBox)e.Item.FindControl("EditCapacidadMax")).Text);				
				string CapacidadMinAux= (((TextBox)e.Item.FindControl("EditCapacidadMin")).Text);				
				string DescripcionAux= (((TextBox)e.Item.FindControl("EditDescripcion")).Text);

				SICALNet.BusinessLogicLayer.Olla BROlla = new SICALNet.BusinessLogicLayer.Olla();
				SICALNet.BusinessEntities.OllaInfo OllaInfo = new SICALNet.BusinessEntities.OllaInfo(Convert.ToInt32(numOllaAux),Convert.ToInt32(idPlantaAux),Convert.ToSingle(CapacidadMaxAux),Convert.ToSingle(CapacidadMinAux),Convert.ToInt32(idLineaAux),DescripcionAux);   
				BROlla.UpdateOlla(OllaInfo);	

				 
					// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualizacion de olla numero: " + numOllaAux + " descripcion: " + ItemDescripcionhtml.Value,Page.User.Identity.Name.ToString());

				//to calcel the edit mode
				dgdOlla.EditItemIndex = -1;
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

		private void dgdOlla_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				string numOllaAux = ((Label)e.Item.FindControl("ItemNumeroOlla")).Text;
				string ItemDescripcion = ((Label)e.Item.FindControl("ItemDescripcion")).Text;
				//string idLineaAux = ((Label)e.Item.FindControl("ItemLinea")).Text;

				SICALNet.BusinessLogicLayer.Olla BROlla = new SICALNet.BusinessLogicLayer.Olla();				
				BROlla.DeleteOlla(Convert.ToInt32(numOllaAux)); 	

				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de olla numero: " + numOllaAux + " descripcion: " + ItemDescripcion,Page.User.Identity.Name.ToString());


				//to calcel the edit mode
				dgdOlla.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();
				lblErrorMsg.Text="El registro se borro satisfactoriamente";
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;


			}
			catch
			{
				// prcErrorDisplay(errHand,"Error");

				throw;
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
			this.dgdOlla.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdOlla_PageIndexChanged);
			this.dgdOlla.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdOlla_CancelCommand);
			this.dgdOlla.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdOlla_EditCommand);
			this.dgdOlla.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdOlla_UpdateCommand);
			this.dgdOlla.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdOlla_DeleteCommand);
			this.dgdOlla.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdOlla_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void aceptar_Click(object sender, System.EventArgs e)
		{
			this.BindGridPorFiltro(); 
		}
	}
}