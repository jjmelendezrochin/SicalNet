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
	///		Descripción breve de AforoGrid.
	/// </summary>
	public class AforoGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.DataGrid dgdAforo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden ItemDescripcionhtml;

		string sColor;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página			
			if (!IsPostBack)
			{
				BindGrid();				
			}
		}

		public void BindGrid()
		{
			try
			{
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Aforo aforo= new SICALNet.BusinessLogicLayer.Aforo();
				// to Call the Select method
				IList fAforoRs= (IList) aforo.SeleccionaAforo();
				//to assign the result set into datagrid
				dgdAforo.DataSource = fAforoRs;
				//to fill the datagrid
				dgdAforo.DataBind();

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

		public void ConsultaAforo(String sColor)
		{
			try
			{
				dgdAforo.CurrentPageIndex = 0;

				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Aforo aforo= new SICALNet.BusinessLogicLayer.Aforo();

				//to assign the values into BEL
				AforoInfo aforoinfo = new AforoInfo(0,sColor, 0,0);

				// to Call the Select method
				IList fAforoRs= (IList) aforo.ConsultaAforo(aforoinfo);
				//to assign the result set into datagrid
				dgdAforo.DataSource = fAforoRs;
				//to fill the datagrid
				dgdAforo.DataBind();
				
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
		#region Código generado por el Diseñador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Diseñador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Método necesario para admitir el Diseñador. No se puede modificar
		///		el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.dgdAforo.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdAforo_PageIndexChanged);
			this.dgdAforo.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdAforo_CancelCommand);
			this.dgdAforo.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdAforo_EditCommand);
			this.dgdAforo.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdAforo_UpdateCommand);
			this.dgdAforo.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdAforo_DeleteCommand);
			this.dgdAforo.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdAforo_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgdAforo_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdAforo.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		private void dgdAforo_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text="";
			sColor = ((Label) e.Item.FindControl("ItemIdColor")).Text.Trim();

			SICALNet.BusinessLogicLayer.Aforo aforo = new SICALNet.BusinessLogicLayer.Aforo();
			AforoInfo aforoinfo = new AforoInfo(0,sColor,0,0);
			IList lista = (IList) aforo.ConsultaAforo(aforoinfo);

			ItemDescripcionhtml.Value = ((Label)e.Item.FindControl("ItemIdColor")).Text;
			dgdAforo.EditItemIndex =(int) e.Item.ItemIndex;
			dgdAforo.DataSource = lista;
			dgdAforo.DataBind();
		}

		private void dgdAforo_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text ="";
			dgdAforo.EditItemIndex =-1;
			BindGrid();
			lblErrorMsg.Text="";
		}

		private void dgdAforo_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			
				// to initialize the PermisoPerfil info into business entities				              
				int Id = Convert.ToInt32(((Label)e.Item.FindControl("lblId")).Text);				
				String componente = (((Label)e.Item.FindControl("ItemComponente")).Text);
				String aforo = (((Label)e.Item.FindControl("ItemAforo")).Text);
				sColor = ((Label) e.Item.FindControl("ItemIdColor")).Text.Trim();
			try
			{	
				//to assign the values into BEL
				AforoInfo aforoinfo = new AforoInfo(Id,sColor, int.Parse(componente),int.Parse(aforo));
				//to create the BBL
				SICALNet.BusinessLogicLayer.Aforo bllaforo= new SICALNet.BusinessLogicLayer.Aforo();
				// Call the Delete method
				bllaforo.BorraAforo(aforoinfo);				

				// Borrado de familia de producto en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				String sBorraAforo = "Borrado de aforo: (color=" + aforoinfo.idColor + ",componente=" + aforoinfo.Componente.ToString() + ", aforo=" + aforoinfo.Aforo + ")";
				BLLBitacora.Insertcomando(sBorraAforo,Page.User.Identity.Name.ToString());
		
				//to set the normal mode
				this.dgdAforo.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();

				//to give the confirmation to the user
				prcErrorDisplay(null,"El registro se elimino con éxito");		
			}
			catch (System.Data.SqlClient.SqlException errHand)
			{
				prcErrorDisplay(errHand, "El aforo a borrar es utilizado por el sistema actualmente, y no será eliminado");
			}
			catch 
			{								 				
				throw;
			}
		}

		private void dgdAforo_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.EditItem)
			{
				dgdAforo.Columns[2].Visible=true;
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Colour color= new SICALNet.BusinessLogicLayer.Colour();
				IList ListaColor = (IList) color.SelectColour();
				// To Load Data for FamilioProductos DropDownList Box
				DropDownList cboColor = (DropDownList) e.Item.FindControl("cboColor");
				cboColor.DataSource=ListaColor;
				cboColor.DataValueField="IdColour";
				cboColor.DataTextField="IdColour";				
				cboColor.DataBind();
				cboColor.Items.FindByValue(sColor).Selected=true;
			}
		}

		private void dgdAforo_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
					
				Validation Vdlt = new Validation();
				int Id = Convert.ToInt32(((Label)e.Item.FindControl("EditId")).Text);
				String componente = (((TextBox)e.Item.FindControl("EditComponente")).Text);
				String aforo = (((TextBox)e.Item.FindControl("EditAforo")).Text);
				String idColor = ((DropDownList)e.Item.FindControl("cboColor")).SelectedItem.Value;
				
				try
			{	
				if( aforo.Trim()=="" || 
					componente.Trim() =="" || 
					!Vdlt.IsNumber(aforo.Trim()) || 
					!Vdlt.IsNumber(componente.Trim()))
				{
					lblErrorMsg.Text = "Debe Capturar color, Componente y Aforo, éstos últimos deben ser numéricos ";
					return;
				}
				
				AforoInfo aforoinfo = new AforoInfo(Id,idColor,int.Parse(componente), int.Parse(aforo));
				SICALNet.BusinessLogicLayer.Aforo bllaforo= new SICALNet.BusinessLogicLayer.Aforo();
				bllaforo.ActualizaAforo(aforoinfo);

				// Alta de aforo en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();

				String sActAforo = "Actualización de aforo: (color=" + aforoinfo.idColor + ",componente=" + aforoinfo.Componente.ToString() + ", aforo=" + aforoinfo.Aforo + ")";
				BLLBitacora.Insertcomando(sActAforo,Page.User.Identity.Name.ToString());

				this.dgdAforo.EditItemIndex=-1;
				BindGrid();
				prcErrorDisplay(null,"El registro se modifico con éxito");

			}
			catch
			{				
				throw;
			}
		}
	}
}
