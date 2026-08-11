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

namespace UserInterface.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Descripción breve de EspecificacionesPvcGrid.
	/// </summary>
	public class EspecificacionesPvcGrid : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblErrorMsg;
		protected System.Web.UI.WebControls.DataGrid dgdEspecificaciones;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				BindGrid();
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
			this.dgdEspecificaciones.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdEspecificaciones_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		public void BindGrid()
		{
			try
			{
				EspecificacionesEmpaquesPvc bllEspecificaciones = 
					new EspecificacionesEmpaquesPvc();				
				IList ilEsp = (IList) bllEspecificaciones.LoadEspecificacion();				
				this.dgdEspecificaciones.DataSource=ilEsp;
				this.dgdEspecificaciones.DataBind();				
				prcErrorDisplay(null,"NoError");
			}
			catch(Exception e)
			{
				prcErrorDisplay(e,"Error");
			}
		}

		public void BindGrid_idEspecificacion(int idEspecificacion)
		{
			try
			{
				if (idEspecificacion == 0)
				{
					EspecificacionesEmpaquesPvc bllEspecificaciones = 
						new EspecificacionesEmpaquesPvc();				
					IList ilEsp = (IList) bllEspecificaciones.LoadEspecificacion();				
					this.dgdEspecificaciones.DataSource=ilEsp;
					this.dgdEspecificaciones.DataBind();				
					prcErrorDisplay(null,"NoError");
				}
				else
				{
					EspecificacionesEmpaquesPvc bllEspecificaciones = 
						new EspecificacionesEmpaquesPvc();				
					IList ilEsp = (IList) bllEspecificaciones.LoadEspecificacion(idEspecificacion);
					this.dgdEspecificaciones.DataSource=ilEsp;
					this.dgdEspecificaciones.DataBind();				
					prcErrorDisplay(null,"NoError");
				
				}
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

		private void dgdEspecificaciones_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdEspecificaciones.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}


			
	}
}
