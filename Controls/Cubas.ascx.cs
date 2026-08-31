namespace UserInterface.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.SessionState;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections; 
	using System.Security.Principal; 
	using SICALNet.Utilities;
	using SICALNet.BusinessLogicLayer;
	using SICALNet.BusinessEntities;



	/// <summary>
	///		Summary description for FoliosColorGrid.
	/// </summary>
	public abstract class CubasGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblErrorMsg;

		ErrorHandling errFileWrite=new ErrorHandling();		
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Button btnBuscar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid dgdCubas;
		protected System.Web.UI.HtmlControls.HtmlInputHidden SecuenciaActualhtml;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Cubahtml;   

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

				BindGrid();
			}
		}

		public void clearMessage()
		{
			//to clear label box
			lblErrorMsg.ForeColor=Color.White;
			lblErrorMsg.BackColor=Color.White;

		}
		public void BindGrid()
		{
			try
			{				
				SICALNet.BusinessLogicLayer.Cuba BLCubas = new SICALNet.BusinessLogicLayer.Cuba();				
				CubaInfo BECuba = new CubaInfo(0,Convert.ToInt32(cboLinea.SelectedItem.Value.ToString()),false,string.Empty,string.Empty);
				IList ListCubas = (IList)BLCubas.SelectCuba(BECuba);
				this.dgdCubas.DataSource = ListCubas;
				this.dgdCubas.DataBind();				
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

		private void dgdCubas_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdCubas.EditItemIndex = -1;
			dgdCubas.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		private void dgdCubas_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ItemSecuenciaActual = (((Label)e.Item.FindControl("ItemSecuenciaActual")).Text);

			if(ItemSecuenciaActual.Length>0)
			{
				//to calcel the edit mode
				dgdCubas.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();
				lblErrorMsg.Text="No se permite modificar cubas con secuecia";
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;	
				return;
			}

			lblErrorMsg.Text="";			
			dgdCubas.EditItemIndex =(int) e.Item.ItemIndex;
			Cubahtml.Value = ((Label) e.Item.FindControl("ItemCuba")).Text;
			BindGrid();
		}

		private void dgdCubas_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdCubas.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid();
			
		}


		private void dgdCubas_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				// to initialize the cuba info into business entities			
				string Cuba= ((Label)e.Item.FindControl("EditCuba")).Text;
				string idLinea = ((Label)e.Item.FindControl("EditLinea")).Text;
				string SecuenciaActual = "";
				string sDenomicacion = (((TextBox)e.Item.FindControl("EditDenominacion")).Text);

				SICALNet.BusinessLogicLayer.Cuba BRCuba = new SICALNet.BusinessLogicLayer.Cuba();
				SICALNet.BusinessEntities.CubaInfo OInfo = new SICALNet.BusinessEntities.CubaInfo(int.Parse(Cuba),int.Parse(idLinea),false,SecuenciaActual,sDenomicacion);   
				BRCuba.ActualizaCuba(OInfo);	

				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualizacion de cuba: " + Cuba  + " Demonimacion: " + sDenomicacion,Page.User.Identity.Name.ToString());


				//to calcel the edit mode
				dgdCubas.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();
				lblErrorMsg.Text="El registro de actualizó satisfactoriamente";
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;	
			}
			catch
			{
				//prcErrorDisplay(errHand,"Error");

				throw;
			}
		}

		private void dgdCubas_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//				lblErrorMsg.Text="No se permite borrar cubas porque tienen historial asociado en partidas cuarado";
				//				//lblErrorMsg.Text="El registro de actualizó satisfactoriamente";
				//				lblErrorMsg.ForeColor=Color.White;
				//				lblErrorMsg.BackColor=Color.Green;	
				//				return;

				string Cuba= ((Label)e.Item.FindControl("ItemCuba")).Text;
				string idLinea = ((Label)e.Item.FindControl("EditLinea")).Text;
				
				SICALNet.BusinessLogicLayer.Cuba BRCuba = new SICALNet.BusinessLogicLayer.Cuba();
				SICALNet.BusinessEntities.CubaInfo OInfo = new SICALNet.BusinessEntities.CubaInfo(int.Parse(Cuba),int.Parse(idLinea),false,"","");   
				BRCuba.DeleteCuba(OInfo);	

				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de cuba: " + Cuba  + " Linea: " + idLinea,Page.User.Identity.Name.ToString());

				//to calcel the edit mode
				dgdCubas.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();
				lblErrorMsg.Text="El registro se borro satisfactoriamente";
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;
			}
			catch (Exception errHand)
			{
				if(errHand.Message=="Valor CurrentPageIndex no válido. Debe ser >= 0 y < PageCount.")
				{
					BindGrid();
				}
				else
				{
					prcErrorDisplay(errHand,"Error");
				}
				//throw;
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
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			this.dgdCubas.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdCubas_PageIndexChanged);
			this.dgdCubas.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdCubas_CancelCommand);
			this.dgdCubas.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdCubas_EditCommand);
			this.dgdCubas.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdCubas_UpdateCommand);
			this.dgdCubas.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdCubas_DeleteCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnBuscar_Click(object sender, System.EventArgs e)
		{
		
           BindGrid();

		}
	}
}
