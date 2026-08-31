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

using SICALNet.BusinessLogicLayer;
using SICALNet.BusinessEntities;
using SICALNet.Utilities;
namespace UserInterface.Controls
{
	/// <summary>
	/// Summary description for ColorForm.
	/// </summary>
	public abstract class FormColourGrid : System.Web.UI.UserControl
	{
		public System.Web.UI.WebControls.DataGrid dgdFormColor;
		protected System.Web.UI.WebControls.Label lblErrorMsg;

		private static string _idColor;
		private static int _idPlanta;
		protected System.Web.UI.WebControls.Label lblallowedit;
		
		ErrorHandling errFileWrite=new ErrorHandling();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//No Load of all Formulations on load.
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
			this.dgdFormColor.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormColor_ItemCommand);
			this.dgdFormColor.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdFormColor_PageIndexChanged);
			this.dgdFormColor.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormColor_CancelCommand);
			this.dgdFormColor.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormColor_EditCommand);
			this.dgdFormColor.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormColor_UpdateCommand);
			this.dgdFormColor.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormColor_DeleteCommand);
			this.dgdFormColor.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdFormColor_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void BindGrid(string idColor, int idPlanta,bool AllowEdit)
		{
			_idColor=idColor;
			_idPlanta=idPlanta;
			
			SICALNet.BusinessEntities.FormColorInfo belFormColor = new SICALNet.BusinessEntities.FormColorInfo(_idColor,_idPlanta);
			SICALNet.BusinessLogicLayer.FormColor  bllFormColor = new SICALNet.BusinessLogicLayer.FormColor();
			dgdFormColor.DataSource = bllFormColor.LoadColorForm(belFormColor);
			dgdFormColor.DataBind();
			Session["opMode"]=string.Empty;

			if (AllowEdit == true)			
				dgdFormColor.Columns[5].Visible = true;					
			else
				dgdFormColor.Columns[5].Visible = false;
			
			lblallowedit.Text = AllowEdit.ToString();
		}

		private void dgdFormColor_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgdFormColor.EditItemIndex=(int) e.Item.ItemIndex;

			BindGrid(_idColor,_idPlanta,System.Convert.ToBoolean(lblallowedit.Text));
			Session["opMode"]="Edit";
			lblErrorMsg.Text=string.Empty;
		}

		private void dgdFormColor_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

		}

		private void dgdFormColor_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				Validation fcVdlt=new Validation();
				
				// to check whether the data correct or not
				if (((Label)e.Item.FindControl("EditCodigoSAP")).Text.Trim() == String.Empty)
				{
					prcErrorDisplay(null,"Debe de capturar el código del material código SAP");
					return;
				}
					//throw new Exception("CodigoSAP Should Not be Empty");
			
				if (fcVdlt.IsPositiveNumber((((TextBox)e.Item.FindControl("EditPorcentaje")).Text))==false)
				{
					prcErrorDisplay(null,"El porcentaje debe de ser un número ");
					return;
				}
					//throw new Exception("Description should be Numeric");

				if (fcVdlt.IsNumber((((TextBox)e.Item.FindControl("EditGrupo")).Text))==false)
				{
					prcErrorDisplay(null,"El grupo debe de ser un número ");
					return;
				}
					//throw new Exception("Description should be Numeric");

				string CodigoSAP=((Label)e.Item.FindControl("EditCodigoSAP")).Text;
				double Porcentaje=Convert.ToDouble(((TextBox)e.Item.FindControl("EditPorcentaje")).Text);
				int Grupo = Convert.ToInt32(((TextBox)e.Item.FindControl("EditGrupo")).Text);
				bool Activo=((CheckBox)e.Item.FindControl("EditActivo")).Checked;

				SICALNet.BusinessEntities.FormColorInfo belFormColor = new SICALNet.BusinessEntities.FormColorInfo(_idColor,_idPlanta,string.Empty,CodigoSAP,string.Empty,Porcentaje,Grupo,Activo);
				SICALNet.BusinessLogicLayer.FormColor bllFormColor = new SICALNet.BusinessLogicLayer.FormColor();
				bllFormColor.UpdateFormColor(belFormColor);

				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualizacion formulacion color: " + _idColor + " codigo SAP: "+ CodigoSAP,Page.User.Identity.Name.ToString());


				dgdFormColor.EditItemIndex = -1;
				BindGrid(_idColor,_idPlanta,System.Convert.ToBoolean(lblallowedit.Text));
				prcErrorDisplay(null,"El registro se modifico con éxito");
			}
			catch 
			{
//				prcErrorDisplay(errHand,"Error");
//				Page.RegisterStartupScript("focus","<SCRIPT language='javascript'>" + "document.all('" +((DropDownList) e.Item.FindControl("EditPorcentaje")).ClientID + "').focus();" + "</SCRIPT>");

				throw;
			}
		}

		private void prcErrorDisplay(Exception errHnd,string errStatus)
		{
			if (errStatus=="Error")
			{
				//to display the error msg
				errFileWrite.HandleException("FormColor Information",errHnd,Server.MapPath("..")+"\\ErrorLog\\Error"+DateTime.Now.Date.ToString("dd-MM-yy")+".txt");
//				errFileWrite.HandleException("PermisoPerfil Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
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

		private void dgdFormColor_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				string CodigoSAP = ((Label)e.Item.FindControl("ItemCodigoSAP")).Text;

				SICALNet.BusinessEntities.FormColorInfo belFormColor = new SICALNet.BusinessEntities.FormColorInfo(_idColor,_idPlanta,string.Empty,CodigoSAP,string.Empty,0,0,false);
				SICALNet.BusinessLogicLayer.FormColor bllFormColor = new SICALNet.BusinessLogicLayer.FormColor();
				bllFormColor.DeleteFormColor(belFormColor);
				lblErrorMsg.Text = "Deleted";

				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado formulacion color: " + _idColor + " codigo SAP: "+ CodigoSAP,Page.User.Identity.Name.ToString());

				BindGrid(_idColor,_idPlanta,System.Convert.ToBoolean(lblallowedit.Text));
				prcErrorDisplay(null,"El registro se modifico con éxito");
			}
			catch 
			{
				// prcErrorDisplay(errHand,"Error");

				throw;
			}

		}

		private void dgdFormColor_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdFormColor.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid(_idColor,_idPlanta,System.Convert.ToBoolean(lblallowedit.Text));
			prcErrorDisplay(null,"NoError");
		}

		private void dgdFormColor_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdFormColor.EditItemIndex = -1;
			dgdFormColor.CurrentPageIndex = e.NewPageIndex;
			BindGrid(_idColor,_idPlanta,System.Convert.ToBoolean(lblallowedit.Text));
		}

		private void dgdFormColor_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{

		}
	}
}