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
	/// Summary description for Medida.
	/// </summary>
	public class MedidaGrid : System.Web.UI.UserControl 
	{
		protected System.Web.UI.WebControls.DataGrid dgdMedida;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Centrimetros; 
	
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
				Medida bllMediada=new Medida();//create instance for business Logic Layer
				IList ilMedida=(IList) bllMediada.LoadMedida();
				dgdMedida.DataSource=ilMedida;
				dgdMedida.DataBind();
				//dgdMedida.EditItemIndex =-1;
				prcErrorDisplay(null,"NoError");
			}
			catch(Exception e)
			{
				prcErrorDisplay(e,"Error");
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
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dgdMedida.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdMedida_PageIndexChanged);
			this.dgdMedida.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdMedida_CancelCommand);
			this.dgdMedida.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdMedida_EditCommand);
			this.dgdMedida.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdMedida_UpdateCommand);
			this.dgdMedida.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdMedida_DeleteCommand);
			this.dgdMedida.SelectedIndexChanged += new System.EventHandler(this.dgdMedida_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
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

		private void dgdMedida_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text ="";
			dgdMedida.EditItemIndex =-1;
			BindGrid();
			lblErrorMsg.Text="";
		}

		private void dgdMedida_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text="";
			dgdMedida.EditItemIndex =(int) e.Item.ItemIndex;
			Centrimetros.Value = ((Label)e.Item.FindControl("ItemCentimetros")).Text;
			BindGrid();
		}
		private void dgdMedida_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//Validation Validate=new Validation();
					
				int IdMedida =Int32.Parse(((Label)e.Item.FindControl("EditIdMedida")).Text.Trim());
				string Centimetros = ((TextBox)e.Item.FindControl("EditCentimetros")).Text.Trim();
				string Pulgadas= (((TextBox)e.Item.FindControl("EditPulgadas")).Text).Trim();
				string Nominal= (((TextBox)e.Item.FindControl("EditNominal")).Text).Trim();
				string Otro= (((TextBox)e.Item.FindControl("EditOtro")).Text).Trim();
				
				
				MedidaInfo belMedida=new MedidaInfo(IdMedida,Centimetros,Pulgadas,Nominal,Otro);
				
				SICALNet.BusinessLogicLayer.Medida bllMedida=new SICALNet.BusinessLogicLayer.Medida();
			
				bllMedida.UpdateMedida(belMedida);
		
				// Actualiza medida en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualiza de Id medida: " + belMedida.IdMedida + " medida: " + Centrimetros.Value,Page.User.Identity.Name.ToString());

				dgdMedida.EditItemIndex = -1;
				BindGrid();
				prcErrorDisplay(null,"El registro se modifico con éxito");
			}
			catch
			{
				throw;
			}
		}

		private void dgdMedida_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				int IdMedida =Int32.Parse(((Label)e.Item.FindControl("ItemIdMedida")).Text);

				SICALNet.BusinessEntities.MedidaInfo belMedida=new SICALNet.BusinessEntities.MedidaInfo(IdMedida,null,null,null,null);

				SICALNet.BusinessLogicLayer.Medida bllMedida=new SICALNet.BusinessLogicLayer.Medida();
				bllMedida.DeleteMedida(belMedida);

				// Borrado de medida en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de medida: " + belMedida.IdMedida + " medida: " + Centrimetros.Value,Page.User.Identity.Name.ToString());

				dgdMedida.EditItemIndex=-1;
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


		private void dgdMedida_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dgdMedida_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdMedida.EditItemIndex = -1;
			dgdMedida.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
			
	}
}
