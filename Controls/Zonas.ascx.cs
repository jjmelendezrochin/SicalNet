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
	public abstract class ZonasGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblErrorMsg;

		ErrorHandling errFileWrite=new ErrorHandling();		
		protected System.Web.UI.WebControls.DropDownList cboLinea;
		protected System.Web.UI.WebControls.Button btnBuscar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid dgdZonas;
		protected System.Web.UI.HtmlControls.HtmlInputHidden SecuenciaActualhtml;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Zonahtml;   

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
				SICALNet.BusinessLogicLayer.Zona BLZonas = new SICALNet.BusinessLogicLayer.Zona();				
				ZonaInfo BEZona = new ZonaInfo(0,Convert.ToInt32(cboLinea.SelectedItem.Value.ToString()),false,string.Empty,string.Empty);
				IList ListZonas = (IList)BLZonas.SelectLineaZona(BEZona);
				this.dgdZonas.DataSource = ListZonas;
				this.dgdZonas.DataBind();				
				prcErrorDisplay(null,"NoError");
			}
			catch (Exception errHand)
			{
				if(errHand.Message=="Valor CurrentPageIndex no válido. Debe ser >= 0 y < PageCount.")
				{
					//BindGrid();
				}
				else
				{
					prcErrorDisplay(errHand,"Error");
				}
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

		private void dgdZonas_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdZonas.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		private void dgdZonas_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string SecuenciaActual = (((Label)e.Item.FindControl("ItemSecuenciaActual")).Text);
			if(SecuenciaActual.Length>0)
			{
				lblErrorMsg.Text="No se permite modificar cubas con secuencia";
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;	
				return;
			}
			lblErrorMsg.Text="";			
			dgdZonas.EditItemIndex =(int) e.Item.ItemIndex;
			Zonahtml.Value = ((Label) e.Item.FindControl("ItemZona")).Text;
			BindGrid();
		}

		private void dgdZonas_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdZonas.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid();
			
		}


		private void dgdZonas_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				// to initialize the Zona info into business entities			
				string Zona= ((Label)e.Item.FindControl("ItemZona")).Text;
				string idLinea = ((Label)e.Item.FindControl("EditLinea")).Text;
				string SecuenciaActual = "";
				string sDenomicacion = (((TextBox)e.Item.FindControl("EditDenominacion")).Text);

				SICALNet.BusinessLogicLayer.Zona BRZona = new SICALNet.BusinessLogicLayer.Zona();
				SICALNet.BusinessEntities.ZonaInfo OInfo = new SICALNet.BusinessEntities.ZonaInfo(int.Parse(Zona),int.Parse(idLinea),false,SecuenciaActual,sDenomicacion);   
				BRZona.ActualizaZona(OInfo);	

				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualizacion de Zona: " + Zona  + " Demonimacion: " + sDenomicacion,Page.User.Identity.Name.ToString());


				//to calcel the edit mode
				dgdZonas.EditItemIndex = -1;
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

		private void dgdZonas_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{

//				lblErrorMsg.Text="No se permite borrar Zonas porque tienen historial asociado en partidas cuarado";
//				//lblErrorMsg.Text="El registro de actualizó satisfactoriamente";
//				lblErrorMsg.ForeColor=Color.White;
//				lblErrorMsg.BackColor=Color.Green;	
//				return;

				string Zona= ((Label)e.Item.FindControl("ItemZona")).Text;
				string idLinea = ((Label)e.Item.FindControl("EditLinea")).Text;
				
				SICALNet.BusinessLogicLayer.Zona BRZona = new SICALNet.BusinessLogicLayer.Zona();
				SICALNet.BusinessEntities.ZonaInfo OInfo = new SICALNet.BusinessEntities.ZonaInfo(int.Parse(Zona),int.Parse(idLinea),false,"","");   
				BRZona.DeleteZona(OInfo);	

				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de Zona: " + Zona  + " Linea: " + idLinea,Page.User.Identity.Name.ToString());

				//to calcel the edit mode
				dgdZonas.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid();
				lblErrorMsg.Text="El registro se borro satisfactoriamente";
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;
			}
			catch (Exception errHand)
			{
				if(errHand.Message=="Valor CurrentPageIndex no válido. Debe ser >= 0 y < PageCount."){
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
			this.dgdZonas.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdZonas_PageIndexChanged);
			this.dgdZonas.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdZonas_CancelCommand);
			this.dgdZonas.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdZonas_EditCommand);
			this.dgdZonas.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdZonas_UpdateCommand);
			this.dgdZonas.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdZonas_DeleteCommand);
			this.dgdZonas.SelectedIndexChanged += new System.EventHandler(this.dgdZonas_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void btnBuscar_Click(object sender, System.EventArgs e)
		{
		
           BindGrid();

		}

		private void dgdZonas_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
