namespace UserInterface.Controls
{
	using System;
	using System.Data;
	using System.Collections;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using SICALNet.BusinessLogicLayer;

	/// <summary>
	///		Descripción breve de TarjetaVidriosHistorial.
	/// </summary>
	public class TarjetaVidriosHistorial : System.Web.UI.UserControl
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
				VidrioHistorial bllHistorialVidrio=new SICALNet.BusinessLogicLayer.VidrioHistorial();//create instance for business Logic Layer
				IList ilVidrioHistorial =(IList) bllHistorialVidrio.LoadVidriosHistorial();
				dgdEspesor.DataSource =ilVidrioHistorial;
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
