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

using SICALNet.BusinessEntities;
using SICALNet.BusinessLogicLayer;
using SICALNet.Utilities;



namespace UserInterface.Forms.Structures
{
	/// <summary>
	/// Descripción breve de EspecificacionesEmpaquesPvc.
	/// </summary>
	public class EspecificacionesEmpaquesPvc : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList cboCodigoSap;
		protected System.Web.UI.WebControls.Button cmdConsulta;
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected Controls.EspecificacionesPvcGrid dgEspecificaciones;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				//to get the instance for BusinessLogicLayer
				SICALNet.BusinessLogicLayer.Especificaciones esp= new SICALNet.BusinessLogicLayer.Especificaciones();
				IList ListaEsp = (IList)esp.SelectEspecificacion();
				// To Load Data into to the cbotipoPMMA Dropdown List from TipoPMMA table
				cboCodigoSap.DataSource= ListaEsp;
				cboCodigoSap.DataValueField="idEspecificaciones";
				cboCodigoSap.DataTextField="Codigo";
				cboCodigoSap.DataBind();
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
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{    
			this.cmdConsulta.Click += new System.EventHandler(this.cmdConsulta_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdConsulta_Click(object sender, System.EventArgs e)
		{
			int idEspecificacion = int.Parse( this.cboCodigoSap.SelectedItem.Value);
			this.dgEspecificaciones.BindGrid_idEspecificacion(idEspecificacion);
			
		}
	}
}
