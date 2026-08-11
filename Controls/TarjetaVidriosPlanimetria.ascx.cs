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
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descripción breve de TarjetaVidriosPlanimetria.
	/// </summary>
	public class TarjetaVidriosPlanimetria : System.Web.UI.UserControl
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
				EspesorVidrio bllEspesorVidrio=new SICALNet.BusinessLogicLayer.EspesorVidrio();//create instance for business Logic Layer
				IList ilEspesorVidrio=(IList) bllEspesorVidrio.LoadEspesorVidrio();
				dgdEspesor.DataSource =ilEspesorVidrio;
				dgdEspesor.DataBind();
				lblErrorMsg.Text ="";
			}
			catch
			{
				throw;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
