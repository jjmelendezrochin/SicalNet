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

using SICALNet.Utilities;
using SICALNet.BusinessLogicLayer;
using SICALNet.BusinessEntities;

namespace UserInterface.Controls
{

	/// <summary>
	///		Descripción breve de VidriosTamanio.
	/// </summary>
	public class VidriosTamanio : System.Web.UI.UserControl
	{
		protected System.Web.UI.HtmlControls.HtmlInputHidden Medida;
		protected System.Web.UI.WebControls.DataGrid dgdVidrios;
		protected System.Web.UI.WebControls.DataGrid dgdVidriosTamanio;
		protected System.Web.UI.WebControls.Label lblErrorMsg;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				BindGrid();
			}

		}
		public void BindGrid()
		{
			try
			{
				VidrioTamanio bllVidriosTamanio=new VidrioTamanio();//create instance for business Logic Layer
				IList ilVidrioTamanio=(IList) bllVidriosTamanio.LoadVidrioTamanio();
				dgdVidriosTamanio.DataSource=ilVidrioTamanio;
				dgdVidriosTamanio.DataBind();
				//dgdMedida.EditItemIndex =-1;
				prcErrorDisplay(null,"NoError");
			}
			catch(Exception e)
			{
				prcErrorDisplay(e,"Error");
			}
		}

		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				ErrorHandling errFileWrite=new ErrorHandling();
				errFileWrite.HandleException("Espesor Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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
			this.dgdVidriosTamanio.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdVidriosTamanio_PageIndexChanged);
			this.dgdVidriosTamanio.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdVidriosTamanio_CancelCommand);
			this.dgdVidriosTamanio.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdVidriosTamanio_EditCommand);
			this.dgdVidriosTamanio.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdVidriosTamanio_UpdateCommand);
			this.dgdVidriosTamanio.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdVidriosTamanio_DeleteCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgdVidriosTamanio_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdVidriosTamanio.CurrentPageIndex = e.NewPageIndex;
			BindGrid();	
		}

		private void dgdVidriosTamanio_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text ="";
			dgdVidriosTamanio.EditItemIndex =-1;
			BindGrid();
			lblErrorMsg.Text="";
		}

		private void dgdVidriosTamanio_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				int idTamanio =Int32.Parse(((Label)e.Item.FindControl("ItemidTamanio")).Text);
				string Medida =((Label)e.Item.FindControl("ItemMedida")).Text;
				
				SICALNet.BusinessEntities.VidrioInfo belVidrioTamanio=new SICALNet.BusinessEntities.VidrioInfo(idTamanio, null, null, 0, 0, 0, 0, 0,"");
				SICALNet.BusinessLogicLayer.VidrioTamanio bllVidriosTamanio=new SICALNet.BusinessLogicLayer.VidrioTamanio();
				bllVidriosTamanio.DeleteVidrioTamanio(belVidrioTamanio);

				// Borrado de medida en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de vidrio: " + belVidrioTamanio.idTamanio + " medida: " + this.Medida.Value,Page.User.Identity.Name.ToString());

				dgdVidriosTamanio.EditItemIndex=-1;
				BindGrid();
				prcErrorDisplay(null,"El registro se elimino con éxito");		
			}
			catch(System.Data.SqlClient.SqlException errHand)
			{
				prcErrorDisplay(errHand, "La medida seleccionada actualmente esta siendo utilizada por el sistema, y no sera eliminada");
			}
			catch
			{
				throw;
			}		
		}

		private void dgdVidriosTamanio_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text="";
			dgdVidriosTamanio.EditItemIndex =(int) e.Item.ItemIndex;
			Medida.Value = ((Label)e.Item.FindControl("ItemMedida")).Text;
			BindGrid();
		}

		private void dgdVidriosTamanio_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{	
				int idTamanio =Int32.Parse(((Label)e.Item.FindControl("EditidTamanio")).Text.Trim());
				int EditAnchoNormal = Int32.Parse(((TextBox)e.Item.FindControl("EditAnchoNormal")).Text.Trim());
				int EditLargoNormal = Int32.Parse(((TextBox)e.Item.FindControl("EditLargoNormal")).Text.Trim());
				int EditAnchoVidrio = Int32.Parse(((TextBox)e.Item.FindControl("EditAnchoVidrio")).Text.Trim());
				int EditLargoVidrio = Int32.Parse(((TextBox)e.Item.FindControl("EditLargoVidrio")).Text.Trim());
				float EditEspesor = float.Parse(((TextBox)e.Item.FindControl("EditEspesor")).Text.Trim());
				string EditGrosor =(((TextBox)e.Item.FindControl("EditGrosor")).Text.Trim());
								
				VidrioInfo belVidrioTamanio=new VidrioInfo(idTamanio,"","",EditAnchoNormal,EditLargoNormal,EditAnchoVidrio,EditLargoVidrio,EditEspesor,EditGrosor);				
				SICALNet.BusinessLogicLayer.VidrioTamanio bllVidriosTamanio=new SICALNet.BusinessLogicLayer.VidrioTamanio();
			
				bllVidriosTamanio.UpdateVidrioTamanio(belVidrioTamanio);
		
				// Actualiza medida en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualiza de vidrio idTamanio: " + belVidrioTamanio.idTamanio + " medida: " + this.Medida.Value,Page.User.Identity.Name.ToString());

				dgdVidriosTamanio.EditItemIndex = -1;
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