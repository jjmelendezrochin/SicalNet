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
	///		Descripción breve de AnillosGrid.
	/// </summary>
	public class AnillosGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dgdAnillos;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		public string sCodigoSap = string.Empty;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			if(!IsPostBack)
			{

				SICALNet.BusinessEntities.UsuarioInfo theUser = new SICALNet.BusinessEntities.UsuarioInfo(this.Context.User.Identity.Name, string.Empty, string.Empty, 0, 0, string.Empty, 0, string.Empty, 0, string.Empty, true);
				SICALNet.BusinessLogicLayer.Usuario BLLUser = new SICALNet.BusinessLogicLayer.Usuario();
				theUser  = BLLUser.Load(theUser);

				SICALNet.BusinessLogicLayer.LineaProduccion  BRlinea = new SICALNet.BusinessLogicLayer.LineaProduccion();
				IList tipoRs= (IList)BRlinea.SelectLinePdt(theUser);
				
				string sCodigoSap = string.Empty;
				BindGrid(sCodigoSap);
			}
		}

		// Consulta Anillo
		public void ConsultaAnillo(string sCodigoSap)
		{
			this.sCodigoSap = sCodigoSap;
			BindGrid(this.sCodigoSap);
		}

		// Bind Grid
		public void BindGrid(string sCodigoSap)
		{
			try
			{							
				SICALNet.BusinessLogicLayer.Anillos bllAnillos = new SICALNet.BusinessLogicLayer.Anillos(); 
				IList ListaAnillos = (IList)bllAnillos.ListAnillos(sCodigoSap);
				this.dgdAnillos.DataSource = ListaAnillos;
				this.dgdAnillos.DataBind();				
				prcErrorDisplay(null,"NoError");
			}
			catch (Exception ex)
			{
				string sError = string.Empty;
				sError = ex.Message; // aquí guardas el mensaje de error en la variable
				prcErrorDisplay(ex, "Error");
				// throw;
			}
		}

		
		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
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

		
		private void dgdAnillos_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdAnillos.CurrentPageIndex = e.NewPageIndex;
			BindGrid(string.Empty);
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
			this.dgdAnillos.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdAnillos_PageIndexChanged);
			this.dgdAnillos.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdAnillos_CancelCommand);
			this.dgdAnillos.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdAnillos_EditCommand_1);
			this.dgdAnillos.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdAnillos_UpdateCommand);
			this.dgdAnillos.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdAnillos_DeleteCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgdAnillos_EditCommand_1(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text="";
			// Primero se filtra del dato
			string itemCodigoSap = (((Label)e.Item.FindControl("ItemCodigoSap")).Text);			
			//this.ConsultaAnillo(itemCodigoSap);

			// Se edita el datos
			dgdAnillos.EditItemIndex =(int) e.Item.ItemIndex;
			BindGrid(itemCodigoSap);
		}

		private void dgdAnillos_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdAnillos.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid(string.Empty);

		}

		private void dgdAnillos_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{						
				string idAnillo		  = ((Label)e.Item.FindControl("EditAnilloId")).Text;				
				string itemCodigoSap1 = (((Label)e.Item.FindControl("ItemCodigoSap1")).Text);
				string editLineaI	  = (((TextBox)e.Item.FindControl("EditLineaI")).Text);
				string editLineaII	  = (((TextBox)e.Item.FindControl("EditLineaII")).Text);
				string editLineaIII	  = (((TextBox)e.Item.FindControl("EditLineaIII")).Text);

				// Verifica si tiene todos los datos
				if (itemCodigoSap1 == string.Empty || editLineaI == string.Empty || editLineaII == string.Empty || editLineaIII == string.Empty)
				{
					prcErrorDisplay(null,"Favor de capturar todos los datos");
					return;
				}

				SICALNet.BusinessLogicLayer.Anillos bllAnillos = new SICALNet.BusinessLogicLayer.Anillos();
				SICALNet.BusinessEntities.AnillosInfo OInfo = 
					new SICALNet.BusinessEntities.AnillosInfo(int.Parse(idAnillo),itemCodigoSap1, string.Empty,editLineaI, editLineaII, editLineaIII,Page.User.Identity.Name);  
				bllAnillos.UpdateAnillos(OInfo);
				
				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualizacion de anillos, codigo SAP: " + itemCodigoSap1,Page.User.Identity.Name.ToString());
				
				//to calcel the edit mode
				dgdAnillos.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid(string.Empty);
				lblErrorMsg.Text="El registro de actualizó satisfactoriamente";
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;
			}
			catch (Exception ex)
			{
				prcErrorDisplay(ex,"Error");
				throw;
			}
			
		}

		private void dgdAnillos_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{								
				string itemCodigoSap = (((Label)e.Item.FindControl("ItemCodigoSap")).Text);
				string editLineaI	  = string.Empty;
				string editLineaII	  = string.Empty;
				string editLineaIII	  = string.Empty;
				

				SICALNet.BusinessLogicLayer.Anillos bllAnillos = new SICALNet.BusinessLogicLayer.Anillos();
				SICALNet.BusinessEntities.AnillosInfo OInfo = 
					new SICALNet.BusinessEntities.AnillosInfo(int.Parse("0"),itemCodigoSap, string.Empty,editLineaI, editLineaII, editLineaIII,Page.User.Identity.Name);  
				bllAnillos.DeleteAnillos(OInfo);
				
				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de anillos, codigo SAP: " + itemCodigoSap,Page.User.Identity.Name.ToString());
				
				//to calcel the edit mode
				dgdAnillos.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid(string.Empty);
				lblErrorMsg.Text="El registro de borro satisfactoriamente";
				lblErrorMsg.ForeColor=Color.White;
				lblErrorMsg.BackColor=Color.Green;
			}
			catch (Exception ex)
			{
				prcErrorDisplay(ex,"Error");
				throw;
			}
		}
	
	}
}
