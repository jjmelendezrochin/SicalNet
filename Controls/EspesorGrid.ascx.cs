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
	
	/// </summary>
	public class EspesorGrid : System.Web.UI.UserControl 
	{
		protected System.Web.UI.WebControls.DataGrid dgdEspesor;
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
				Espesor bllEspesor=new Espesor();//create instance for business Logic Layer
				IList ilEspesor=(IList) bllEspesor.LoadEspesor();
				dgdEspesor.DataSource =ilEspesor;
				dgdEspesor.DataBind();
				lblErrorMsg.Text ="";
			}
			catch
			{
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
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dgdEspesor.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdEspesor_PageIndexChanged);
			this.dgdEspesor.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdEspesor_CancelCommand_1);
			this.dgdEspesor.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdEspesor_EditCommand_1);
			this.dgdEspesor.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdEspesor_UpdateCommand);
			this.dgdEspesor.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdEspesor_DeleteCommand);
			this.dgdEspesor.SelectedIndexChanged += new System.EventHandler(this.dgdEspesor_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		private void prcErrorHandling(Exception e)
		{
			//ErrorHandling errFileWrite=new ErrorHandling();
			// errFileWrite.HandleException("Espesor Information",errFileWrite,Server.MapPath("SICALNet")+"Error.txt");
			lblErrorMsg.Text=e.Message;
			
		}

		private void dgdEspesor_EditCommand_1(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text="";
			dgdEspesor.EditItemIndex =(int) e.Item.ItemIndex;
			BindGrid();
		}

		private void dgdEspesor_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text ="";
			string IdEspesor =((Label)e.Item.FindControl("ItemIdEspesor")).Text.Trim();

			SICALNet.BusinessEntities.EspesorInfo  belEspesor=new SICALNet.BusinessEntities.EspesorInfo(IdEspesor,0,0,0,0); // null - 0 FRM

			SICALNet.BusinessLogicLayer.Espesor  bllEspesor=new SICALNet.BusinessLogicLayer.Espesor();
			try
			{
				bllEspesor.DeleteEspesor(belEspesor);
				
				// borrado de espesor en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado de espesor: " + belEspesor.IdEspesor,Page.User.Identity.Name.ToString());

				
				dgdEspesor.EditItemIndex=-1;
				BindGrid();
				lblErrorMsg.Text ="El registro se elimino con éxito";
			}
			catch(System.Data.SqlClient.SqlException errHand)
			{
				prcErrorHandling(errHand);
			}
			catch
			{				
				throw;
			}
		}

		private void dgdEspesor_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Validation Validate=new Validation();
				
			string IdEspesor =((Label)e.Item.FindControl("EditIdEspesor")).Text.Trim();

			string Centimetros = ((TextBox)e.Item.FindControl("EditCentimetros")).Text.Trim();
			if((!Validate.IsNumber(Centimetros)) || (Centimetros.Length==0))
			{
				lblErrorMsg.Text ="Debe de capturar una cantidad en centimetros valida";
				return;
			}
			double dblCent = Convert.ToDouble(Centimetros);

			string Pulgadas= (((TextBox)e.Item.FindControl("EditPulgadas")).Text.Trim());
			if((!Validate.IsNumber(Pulgadas)) || (Pulgadas.Length==0))
			{
				lblErrorMsg.Text ="Debe de capturar una cantidad en pulgadas valida";
				return;
			}
			double dblPulg = Convert.ToDouble(Pulgadas);

			string Nominal= (((TextBox)e.Item.FindControl("EditNominal")).Text.Trim());
			if((!Validate.IsNumber(Nominal)) || (Nominal.Length==0))
			{
				lblErrorMsg.Text ="Debe de capturar una cantidad nominal valida";
				return;
			}
			double dblNom = Convert.ToDouble(Nominal);
			string Otro= (((TextBox)e.Item.FindControl("EditOtro")).Text.Trim());
			if((!Validate.IsNumber(Otro)) && (Otro.Length>0))
			{
				lblErrorMsg.Text ="El campo 'OTRA CANTIDAD' debe ser numérico";
				return;
			}
			double dblOtro=Otro==string.Empty?0:Convert.ToDouble(Otro);
			
			EspesorInfo  belEspesor=new EspesorInfo(IdEspesor,dblCent,dblPulg,dblNom,dblOtro);
			SICALNet.BusinessLogicLayer.Espesor  bllEspesor=new SICALNet.BusinessLogicLayer.Espesor();
			try
			{
				bllEspesor.UpdateEspesor(belEspesor);
				
				// Update de espesor en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualizacion de espesor: " + belEspesor.IdEspesor,Page.User.Identity.Name.ToString());


				dgdEspesor.EditItemIndex = -1;
				BindGrid();
				lblErrorMsg.Text ="El registro se modifico con éxito";
			}
			catch
			{				
				throw;
			}
		}

		private void dgdEspesor_CancelCommand_1(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			lblErrorMsg.Text ="";
			dgdEspesor.EditItemIndex =-1;
			BindGrid();
			lblErrorMsg.Text="";
		}

		private void dgdEspesor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dgdEspesor_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdEspesor.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

	}
}
