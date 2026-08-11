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
//sicalnet references
using SICALNet.Utilities;
using SICALNet.BusinessLogicLayer;
using SICALNet.BusinessEntities;

namespace UserInterface.Controls
{
	/// <summary>
	///		Summary description for MaterialGrid.
	/// </summary>
	public abstract class MaterialGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid dgdMaterial;

		public string selCodigo=string.Empty;

		ErrorHandling ExpHand=new ErrorHandling();

		private void Page_Load(object sender, System.EventArgs e)
		{
			//BindGrid - to fill the datagrid
			if (!IsPostBack)
				BindGrid();
		}

		public void BindGrid()
		{
//			try
//			{
//				//to get the instance for BusinessLogicLayer
//				SICALNet.BusinessLogicLayer.Material BLLMaterial= new SICALNet.BusinessLogicLayer.Material();
//				// to Call the Select method
//				IList RsMaterial= (IList)BLLMaterial.SelectMaterial(BLLMaterial);
//				//to assign the result set into datagrid
//				dgdMaterial.DataSource = RsMaterial;
//				//to fill the datagrid
//				dgdMaterial.DataBind();
//			}
//			catch(Exception errHand)
//			{
//				Session["errMsg"]=ExpHand.HandleException("Structure","Material",errHand,Server.MapPath(".."),errHand.Message);
//			}
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
			this.dgdMaterial.SelectedIndexChanged += new System.EventHandler(this.dgdMaterial_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgdMaterial_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			selCodigo=dgdMaterial.DataKeys[dgdMaterial.SelectedIndex].ToString();
			this.Visible=false;		
		}
	}
}
