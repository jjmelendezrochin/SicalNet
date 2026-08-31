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
	///		Summary description for FormAditivos.
	/// </summary>
	public abstract class FormAditivosGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dgdFormAditivos;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		
//		private static string _idColor, _idEspesor;
//		private static int _idLinea, _idPlanta;
		private string _idColor, _idEspesor;
		private int _idLinea, _idPlanta;
 		ErrorHandling errFileWrite=new ErrorHandling();

		// se adieren al control las propiedades del materiasl que se esta formulando
		
		public string idcolor 
		{
			get 
			{
				object o = ViewState["idcolor"];
				return (string) o; 
			}
			set 
			{
				ViewState["idcolor"] = value; 
			}
		}

		public string idespesor
		{
			get 
			{
				object o = ViewState["idespesor"];
				return (string) o; 
			}
			set 
			{
				ViewState["idespesor"] = value; 
			}
		}

		public int idlinea
		{
			get 
			{
				object o = ViewState["idlinea"];
				return (int) o; 
			}
			set 
			{
				ViewState["idlinea"] = value; 
			}
		}

		public int idplanta
		{
			get 
			{
				object o = ViewState["idplanta"];
				return (int) o; 
			}
			set 
			{
				ViewState["idplanta"] = value; 
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			
	    }

		private void BlockControlsToEdit(Boolean Activar)
		{
			dgdFormAditivos.Columns[6].Visible = Activar; 

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
			this.dgdFormAditivos.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdFormAditivos_PageIndexChanged);
			this.dgdFormAditivos.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormAditivos_CancelCommand);
			this.dgdFormAditivos.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormAditivos_EditCommand);
			this.dgdFormAditivos.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormAditivos_UpdateCommand);
			this.dgdFormAditivos.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdFormAditivos_DeleteCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void setmatini(string idColor,string idEspesor, int idLinea, int idPlanta, Boolean blockcontrols)
		{
			this.idcolor= idColor.ToString();
			this.idespesor= idEspesor.ToString();
			this.idlinea=idLinea;
			this.idplanta=idPlanta;

			BlockControlsToEdit(blockcontrols);
		}


		public void BindGrid(string idColor,string idEspesor, int idLinea, int idPlanta)
		{
			try
			{
				_idColor=idColor;
				_idEspesor=idEspesor;
				_idLinea=idLinea;
				_idPlanta=idPlanta;

				//to get the instance form BusinessLogicLayer
				SICALNet.BusinessEntities.FormAditivosInfo BELFormAditivos= new SICALNet.BusinessEntities.FormAditivosInfo(_idColor,_idEspesor,_idLinea,_idPlanta);
				//to get the instance form BusinessLogicLayer
				SICALNet.BusinessLogicLayer.FormAditivos BLLFormAditivos= new SICALNet.BusinessLogicLayer.FormAditivos();
				// to Call the Select method
				IList RsGrdFormAditivos= (IList)BLLFormAditivos.SelectFormAditivos(BELFormAditivos);
				//to assign the result set into datagrid
				dgdFormAditivos.DataSource = RsGrdFormAditivos;
				//to fill the datagrid
				
				dgdFormAditivos.DataBind();
			}
			catch
			{
				throw;
			}
		}

//		private void prcFillCombo(DropDownList cboCntl,string txtFiled,string valField,IList RsCboFill,string CurValue)
//		{
//			cboCntl.DataSource=RsCboFill;
//			cboCntl.DataValueField=valField;
//			cboCntl.DataTextField=txtFiled;
//			cboCntl.DataBind();
//			cboCntl.Items.FindByText(CurValue).Selected=true;
//		}

		public int funGetCurrentRow()
		{
			return dgdFormAditivos.EditItemIndex;
		}

		private void dgdFormAditivos_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// obtenemos los valores idcolor,idespesor,idlinea,idplanta
			dgdFormAditivos.EditItemIndex = (int)e.Item.ItemIndex;
			
			//to fill the datagrid
			BindGrid(this.idcolor,this.idespesor,this.idlinea,this.idplanta);
		}

		private void dgdFormAditivos_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//to set the view mode
			dgdFormAditivos.EditItemIndex = -1;
			//to fill the datagrid
			BindGrid(this.idcolor,this.idespesor,this.idlinea,this.idplanta);
		}

		private void dgdFormAditivos_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				//to get an instance from validation
				Validation vdtFormAditivos = new Validation();
				//to check colorid whether its correct or not
				if (vdtFormAditivos.IsPositiveNumber(((TextBox)e.Item.FindControl("EditPorcentaje")).Text)==false)
				{
					lblErrorMsg.Text = "El porcentaje de peso debe de ser un numero real positivo";
					return;
				}


				//to assign the control box values into variables
				string CodigoSAP= ((Label)e.Item.FindControl("EditCodigoSAP")).Text;
				float depeso=Convert.ToSingle(((TextBox)e.Item.FindControl("EditPorcentaje")).Text);
				bool Activo= ((CheckBox)e.Item.FindControl("EditActivo")).Checked;
				int version=Convert.ToInt32(((Label)e.Item.FindControl("EditVersion")).Text);
				//int idfamiliaproductonobase=Convert.ToInt32(((DropDownList)e.Item.FindControl("cboFamPdt")).SelectedItem.Value);
				
				//to assign the color info into business entity lager
				FormAditivosInfo BEFormAditivos= new FormAditivosInfo(this.idcolor,this.idespesor,this.idlinea,this.idplanta,CodigoSAP,string.Empty,depeso,Activo, string.Empty,version);

				//to get an instance from business logic layer
				SICALNet.BusinessLogicLayer.FormAditivos BLLFormAditivos= new SICALNet.BusinessLogicLayer.FormAditivos();
				//to Call the Insert FormAditivos method
				BLLFormAditivos.UpdateFormAditivos(BEFormAditivos);

				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Actualizacion formulacion de aditivos: " + _idColor + " codigo SAP: "+ CodigoSAP,Page.User.Identity.Name.ToString());

				//to fill the datagrid
				//to calcel the edit mode
				dgdFormAditivos.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid(this.idcolor,this.idespesor,this.idlinea,this.idplanta);
			}
			catch
			{
				// prcErrorDisplay(errHand,"Error");

				throw;
			}
		}

		private void dgdFormAditivos_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				string CodigoSAP = ((Label)e.Item.FindControl("ItemCodigoSAP")).Text;
				int Version= Convert.ToInt32(((Label)e.Item.FindControl("ItemVersion")).Text);

				//to assign the values into BEL
				FormAditivosInfo BEFormAditivos= new FormAditivosInfo(this.idcolor,this.idespesor,this.idlinea,this.idplanta ,CodigoSAP,Version);
				//to create the BBL
				SICALNet.BusinessLogicLayer.FormAditivos BLLFormAditivos= new SICALNet.BusinessLogicLayer.FormAditivos();
				//to Call the Delete method
				BLLFormAditivos.DeleteFormAditivos(BEFormAditivos);
				
				// guardamos en la bitacora
				SICALNet.BusinessLogicLayer.Bitacora  BLLBitacora= new SICALNet.BusinessLogicLayer.Bitacora();
				BLLBitacora.Insertcomando("Borrado formulacion de aditivos: " + _idColor + " codigo SAP: "+ CodigoSAP,Page.User.Identity.Name.ToString());

				//to set the normal mode
				dgdFormAditivos.EditItemIndex = -1;
				//to fill the datagrid
				BindGrid(this.idcolor,this.idespesor,this.idlinea,this.idplanta);
			}
			catch
			{
				// prcErrorDisplay(errHand,"Error");

				throw;
			}
		}

		private void dgdFormAditivos_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdFormAditivos.EditItemIndex = -1;
			dgdFormAditivos.CurrentPageIndex = e.NewPageIndex;
			BindGrid(this.idcolor,this.idespesor,this.idlinea,this.idplanta);
		}

		
		private void prcFillCombo(DropDownList cboCntl,string txtFiled,string valField,IList RsCboFill,string CurValue)
		{
			cboCntl.DataSource=RsCboFill;
			cboCntl.DataValueField=valField;
			cboCntl.DataTextField=txtFiled;
			cboCntl.DataBind();
			
			if (System.Convert.ToInt32(CurValue) > 0)
			cboCntl.Items.FindByValue(CurValue).Selected=true;
		}

		public void dgdFormAditivos_OnItemDataBound(object sender, 
			System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			// Check if the current row contains items; if it's
			// a header or footer row that will throw an error
			if (e.Item.ItemType == ListItemType.EditItem)
			{

				Label lblidFamiliaprodedit = (Label)e.Item.FindControl("lblidFamiliaprodedit");
				DropDownList cboFamPdt =  (DropDownList)e.Item.FindControl("cboFamPdt");

				SICALNet.BusinessLogicLayer.FamiliaProducto BLLFampdt=new SICALNet.BusinessLogicLayer.FamiliaProducto();
				IList RsFampdt=(IList) BLLFampdt.SelectFamiliaProducto();

				prcFillCombo(cboFamPdt,"Descripcion","IdFamiliaProductos",RsFampdt,lblidFamiliaprodedit.Text);

			}

			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Label lblidFamiliaprod = (Label)e.Item.FindControl("lblidFamiliaprod");
				Label lblidFamiliaprodText = (Label)e.Item.FindControl("lblidFamiliaprodText");
				

				SICALNet.BusinessLogicLayer.FamiliaProducto BLLFampdt=new SICALNet.BusinessLogicLayer.FamiliaProducto();
				IList RsFampdt=(IList) BLLFampdt.SelectFamiliaProducto();				

				int idFamiliaprod = Convert.ToInt32(lblidFamiliaprod.Text);
				
				

				if (idFamiliaprod > 0)
				{				
					
					foreach(FamiliaProductoInfo myFamiliaProductoInfo in RsFampdt)
					{
						if (myFamiliaProductoInfo.IdFamiliaProductos == idFamiliaprod)
						{
							lblidFamiliaprodText.Text  = myFamiliaProductoInfo.Descripcion;
							break;
						} 
						lblidFamiliaprodText.Text  = String.Empty;
					}       					
				}					
			}
		}


//		private void prcErrorDisplay(Exception errHnd,string errStatus)
//		{
//			if (errStatus=="Error")
//			{
//				//to display the error msg
//				errFileWrite.HandleException("FormColor Information",errHnd,Server.MapPath("..")+"\\ErrorLog\\Error"+DateTime.Now.Date.ToString("dd-MM-yy")+".txt");
//				//				errFileWrite.HandleException("PermisoPerfil Information",errHnd,Server.MapPath("SICALNet")+"Error.txt");
//				lblErrorMsg.Text=errHnd.Message;
//				lblErrorMsg.ForeColor=Color.White;
//				lblErrorMsg.BackColor=Color.Red;
//			}
//			else if (errStatus=="NoError")
//			{
//				//to clear label box
//				lblErrorMsg.ForeColor=Color.White;
//				lblErrorMsg.BackColor=Color.White;
//			}
//			else
//			{
//				//to display the success msg
//				lblErrorMsg.Text=errStatus;
//				lblErrorMsg.ForeColor=Color.White;
//				lblErrorMsg.BackColor=Color.Green;
//			}
//		}

	}
}